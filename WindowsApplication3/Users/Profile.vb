Imports System.Data.Odbc
Imports System.Linq

Public Class Profile
    Private Const MobilePrefix As String = "+63"

    Private Sub Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCurrentUser()
        Try
            txtMobile.ShortcutsEnabled = False
        Catch
        End Try
        EnsureMobileFormat()
    End Sub

    Private Sub LoadCurrentUser()
        Try
            Dim userId As Integer = GlobalVariables.LoggedInUserID
            If userId <= 0 Then
                MessageBox.Show("No logged in user.", "Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Return
            End If

            Using conn As New OdbcConnection("DSN=dsnsystem")
                conn.Open()
                Dim sql As String = "SELECT Username, Password, Role, Fname, Mname, Lname, MobileNum, Email FROM tbl_users WHERE UserID = ?"
                Using cmd As New OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", userId)
                    Using rd = cmd.ExecuteReader()
                        If rd.Read() Then
                            If Not rd.IsDBNull(0) Then txtUser.Text = rd.GetString(0) Else txtUser.Text = ""
                            If Not rd.IsDBNull(1) Then txtPass.Text = rd.GetString(1) Else txtPass.Text = ""
                            If Not rd.IsDBNull(2) Then cmbRole.Text = rd.GetString(2) Else cmbRole.Text = ""
                            If Not rd.IsDBNull(3) Then txtFirst.Text = rd.GetString(3) Else txtFirst.Text = ""
                            If Not rd.IsDBNull(4) Then txtMname.Text = rd.GetString(4) Else txtMname.Text = ""
                            If Not rd.IsDBNull(5) Then txtLname.Text = rd.GetString(5) Else txtLname.Text = ""
                            If Not rd.IsDBNull(6) Then txtMobile.Text = rd.GetString(6) Else txtMobile.Text = ""
                            If Not rd.IsDBNull(7) Then txtEmail.Text = rd.GetString(7) Else txtEmail.Text = ""

                            ' Removed: default-password notice now shows after login, not here
                        Else
                            MessageBox.Show("User not found.", "Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Close()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading profile: " & ex.Message, "Profile", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim userId As Integer = GlobalVariables.LoggedInUserID
            If userId <= 0 Then Return

            If String.IsNullOrWhiteSpace(txtPass.Text) Then
                MessageBox.Show("Password cannot be empty.", "Profile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPass.Focus()
                Return
            End If

            ' Basic email validation: must contain '@' and '.com'
            Dim email As String = txtEmail.Text.Trim()
            If Not (email.Contains("@") AndAlso email.ToLower().Contains(".com")) Then
                MessageBox.Show("Please enter a valid email that contains '@' and '.com'.", "Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmail.Focus()
                txtEmail.SelectAll()
                Return
            End If

            ' Username duplicate check (copied pattern from addUsers.vb)
            Dim username As String = txtUser.Text.Trim().ToLower()
            Dim oldUser As String = ""

            Using conn As New OdbcConnection("DSN=dsnsystem")
                conn.Open()

                Dim oldPass As String = ""
                Dim oldEmail As String = ""
                Dim oldMobile As String = ""

                Using getCmd As New OdbcCommand("SELECT Username, Password, Email, MobileNum FROM tbl_users WHERE UserID= ?", conn)
                    getCmd.Parameters.AddWithValue("?", userId)
                    Using rd = getCmd.ExecuteReader()
                        If rd.Read() Then
                            If Not rd.IsDBNull(0) Then oldUser = rd.GetString(0).Trim().ToLower()
                            If Not rd.IsDBNull(1) Then oldPass = rd.GetString(1)
                            If Not rd.IsDBNull(2) Then oldEmail = rd.GetString(2)
                            If Not rd.IsDBNull(3) Then oldMobile = rd.GetString(3)
                        End If
                    End Using
                End Using

                ' If username changed, enforce uniqueness
                If username <> oldUser Then
                    If IsReservedUsername(username) OrElse IsUsernameTaken(username, userId) Then
                        Dim suggested As String = GetNextAvailableUsername(username)
                        Dim res = MessageBox.Show("Username '" & username & "' is reserved or already taken. Use '" & suggested & "' instead?", "Username Taken", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If res = DialogResult.Yes Then
                            txtUser.Text = suggested
                            username = suggested
                        Else
                            txtUser.Focus()
                            txtUser.SelectAll()
                            Return
                        End If
                    End If
                End If

                Dim newPass As String = txtPass.Text
                Dim newEmail As String = txtEmail.Text
                Dim newMobile As String = txtMobile.Text

                Using upd As New OdbcCommand("UPDATE tbl_users SET Username=?, Password=?, Email=?, MobileNum=? WHERE UserID= ?", conn)
                    upd.Parameters.AddWithValue("?", username)
                    upd.Parameters.AddWithValue("?", newPass)
                    upd.Parameters.AddWithValue("?", newEmail)
                    upd.Parameters.AddWithValue("?", newMobile)
                    upd.Parameters.AddWithValue("?", userId)
                    upd.ExecuteNonQuery()
                End Using

                Dim changes As New List(Of String)()
                If oldUser <> username Then changes.Add("changed username from '" & oldUser & "' to '" & username & "'")
                If oldEmail <> newEmail Then changes.Add("changed email from '" & oldEmail & "' to '" & newEmail & "'")
                If oldMobile <> newMobile Then changes.Add("changed mobile from '" & oldMobile & "' to '" & newMobile & "'")
                If oldPass <> newPass Then changes.Add("changed password")

                If changes.Count > 0 Then
                    InsertAuditTrail(userId, "Update Profile", String.Join("; ", changes))
                End If
            End Using

            MessageBox.Show("Profile updated successfully.", "Profile", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error saving profile: " & ex.Message, "Profile", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub InsertAuditTrail(UserID As Integer, ActionType As String, ActionDetails As String)
        Dim connectionString As String = "DSN=dsnsystem"
        Using conn As New OdbcConnection(connectionString)
            Try
                conn.Open()
                Dim query As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?)"
                Using cmd As New OdbcCommand(query, conn)
                    cmd.Parameters.AddWithValue("?", UserID)
                    cmd.Parameters.AddWithValue("?", GlobalVariables.LoggedInUser)
                    cmd.Parameters.AddWithValue("?", ActionType)
                    cmd.Parameters.AddWithValue("?", ActionDetails)
                    cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                    cmd.ExecuteNonQuery()
                End Using
            Catch
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub txtMobile_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobile.KeyDown
        If e.KeyCode = Keys.Back Then
            If txtMobile.SelectionStart <= MobilePrefix.Length AndAlso txtMobile.SelectionLength = 0 Then
                e.SuppressKeyPress = True
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            If txtMobile.SelectionStart < MobilePrefix.Length Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtMobile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMobile.KeyPress
        If Char.IsControl(e.KeyChar) Then Return
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        Dim digitsAfter As String = New String(txtMobile.Text.Skip(MobilePrefix.Length).Where(Function(c) Char.IsDigit(c)).ToArray())
        If digitsAfter.Length >= 10 AndAlso txtMobile.SelectionLength = 0 Then
            e.Handled = True
        End If
        If txtMobile.SelectionStart < MobilePrefix.Length Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs) Handles txtMobile.TextChanged
        Dim t As String = txtMobile.Text
        If Not t.StartsWith(MobilePrefix) Then
            Dim caret As Integer = txtMobile.SelectionStart
            t = MobilePrefix & t
            txtMobile.Text = t
            txtMobile.SelectionStart = Math.Max(caret + MobilePrefix.Length, MobilePrefix.Length)
            Return
        End If
        Dim rest As String = New String(t.Substring(MobilePrefix.Length).Where(Function(c) Char.IsDigit(c)).ToArray())
        If rest.Length > 10 Then rest = rest.Substring(0, 10)
        Dim rebuilt As String = MobilePrefix & rest
        If rebuilt <> t Then
            Dim pos As Integer = txtMobile.SelectionStart
            txtMobile.Text = rebuilt
            If pos < MobilePrefix.Length Then pos = MobilePrefix.Length
            If pos > txtMobile.TextLength Then pos = txtMobile.TextLength
            txtMobile.SelectionStart = pos
        End If
    End Sub

    Private Sub txtMobile_Enter(sender As Object, e As EventArgs) Handles txtMobile.Enter
        If txtMobile.Text.Length < MobilePrefix.Length OrElse Not txtMobile.Text.StartsWith(MobilePrefix) Then
            txtMobile.Text = MobilePrefix
        End If
        If txtMobile.SelectionStart < MobilePrefix.Length Then
            txtMobile.SelectionStart = txtMobile.TextLength
        End If
    End Sub

    Private Sub txtMobile_MouseDown(sender As Object, e As MouseEventArgs) Handles txtMobile.MouseDown
        Dim idx = txtMobile.GetCharIndexFromPosition(e.Location)
        If idx < MobilePrefix.Length Then
            txtMobile.SelectionStart = MobilePrefix.Length
        End If
    End Sub

    Private Sub EnsureMobileFormat()
        Dim val As String = txtMobile.Text
        If String.IsNullOrWhiteSpace(val) Then
            txtMobile.Text = MobilePrefix
            txtMobile.SelectionStart = txtMobile.TextLength
            Return
        End If
        If Not val.StartsWith(MobilePrefix) Then val = MobilePrefix & val
        Dim rest As String = New String(val.Substring(MobilePrefix.Length).Where(Function(c) Char.IsDigit(c)).ToArray())
        If rest.Length > 10 Then rest = rest.Substring(0, 10)
        txtMobile.Text = MobilePrefix & rest
        txtMobile.SelectionStart = txtMobile.TextLength
    End Sub

    Private Function IsReservedUsername(username As String) As Boolean
        Dim reservedNames As New List(Of String) From {""}
        Return reservedNames.Contains(username.ToLower())
    End Function

    Private Function GetNextAvailableUsername(baseName As String) As String
        Dim nextNumber As Integer = 1
        Dim suggested As String
        Dim maxAttempts As Integer = 100
        Dim attempt As Integer = 0
        Do
            suggested = baseName.ToLower() & nextNumber.ToString()
            nextNumber += 1
            attempt += 1
            If attempt >= maxAttempts Then
                Return baseName.ToLower() & DateTime.Now.Ticks.ToString().Substring(0, 5)
            End If
        Loop While IsUsernameTaken(suggested)
        Return suggested
    End Function

    Private Function IsUsernameTaken(username As String, Optional currentUserID As Integer = 0) As Boolean
        Try
            Using conn As New OdbcConnection("DSN=dsnsystem")
                conn.Open()
                If currentUserID > 0 Then
                    Using cmd As New OdbcCommand("SELECT COUNT(*) FROM tbl_users WHERE LOWER(Username)=? AND UserID <> ?", conn)
                        cmd.Parameters.AddWithValue("?", username.ToLower())
                        cmd.Parameters.AddWithValue("?", currentUserID)
                        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        Return count > 0
                    End Using
                Else
                    Using cmd As New OdbcCommand("SELECT COUNT(*) FROM tbl_users WHERE LOWER(Username)=?", conn)
                        cmd.Parameters.AddWithValue("?", username.ToLower())
                        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        Return count > 0
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking username: " & ex.Message, "Profile", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Class