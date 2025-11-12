Imports System.Data.Odbc
Imports System.Linq

Public Class Profile
    Private Const MobilePrefix As String = "+63"

    Private Sub Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Set date range for DOB
            dtpDOB.MinDate = Date.Today.AddYears(-120)
            dtpDOB.MaxDate = Date.Today
            dtpDOB.Value = Date.Today
        Catch ex As Exception
            ' Silently handle initialization errors
        End Try

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
                Dim sql As String = "SELECT Username, Password, Role, Fname, Mname, Lname, Suffix, dob, MobileNum, Email FROM tbl_users WHERE UserID = ?"
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
                            If Not rd.IsDBNull(7) Then
                                Dim dobValue As Date = rd.GetDateTime(7)
                                ' Validate date is within acceptable range before setting
                                If dobValue <= Date.Today AndAlso dobValue >= Date.Today.AddYears(-120) Then
                                    dtpDOB.Value = dobValue
                                    ' Calculate and display age
                                    CalculateAge()
                                Else
                                    dtpDOB.Value = Date.Today
                                    txtAge.Text = "0"
                                End If
                            Else
                                dtpDOB.Value = Date.Today
                                txtAge.Text = "0"
                            End If
                            If Not rd.IsDBNull(8) Then txtMobile.Text = rd.GetString(8) Else txtMobile.Text = ""
                            If Not rd.IsDBNull(9) Then txtEmail.Text = rd.GetString(9) Else txtEmail.Text = ""

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
        ' Normalize optional fields
        If String.IsNullOrWhiteSpace(txtMname.Text) Then txtMname.Text = "N/A"

        ' Unified validation
        If Not ValidateAllRequiredFields() Then Exit Sub

        Try
            Dim userId As Integer = GlobalVariables.LoggedInUserID
            If userId <= 0 Then Return

            ' Username duplicate check
            Dim username As String = txtUser.Text.Trim().ToLower()
            Dim oldUser As String = ""

            Using conn As New OdbcConnection("DSN=dsnsystem")
                conn.Open()

                Dim oldPass As String = ""
                Dim oldEmail As String = ""
                Dim oldMobile As String = ""
                Dim oldFname As String = ""
                Dim oldMname As String = ""
                Dim oldLname As String = ""
                Dim oldSuffix As String = ""
                Dim oldDob As String = ""

                Using getCmd As New OdbcCommand("SELECT Username, Password, Email, MobileNum, Fname, Mname, Lname, Suffix, dob FROM tbl_users WHERE UserID= ?", conn)
                    getCmd.Parameters.AddWithValue("?", userId)
                    Using rd = getCmd.ExecuteReader()
                        If rd.Read() Then
                            If Not rd.IsDBNull(0) Then oldUser = rd.GetString(0).Trim().ToLower()
                            If Not rd.IsDBNull(1) Then oldPass = rd.GetString(1)
                            If Not rd.IsDBNull(2) Then oldEmail = rd.GetString(2)
                            If Not rd.IsDBNull(3) Then oldMobile = rd.GetString(3)
                            If Not rd.IsDBNull(4) Then oldFname = rd.GetString(4)
                            If Not rd.IsDBNull(5) Then oldMname = rd.GetString(5)
                            If Not rd.IsDBNull(6) Then oldLname = rd.GetString(6)
                            If Not rd.IsDBNull(7) Then oldSuffix = rd.GetString(7)
                            If Not rd.IsDBNull(8) Then oldDob = rd.GetString(8)
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

                If MsgBox("Do you want to save changes to your profile?", vbYesNo + vbQuestion, "Save Profile") <> vbYes Then Exit Sub

                Dim newPass As String = txtPass.Text
                Dim newEmail As String = txtEmail.Text.Trim()
                Dim newMobile As String = txtMobile.Text
                Dim newFname As String = StrConv(Trim(txtFirst.Text), VbStrConv.ProperCase)
                Dim newMname As String = StrConv(Trim(txtMname.Text), VbStrConv.ProperCase)
                Dim newLname As String = StrConv(Trim(txtLname.Text), VbStrConv.ProperCase)
                Dim newDob As String = dtpDOB.Value.Date.ToString("yyyy-MM-dd")

                Using upd As New OdbcCommand("UPDATE tbl_users SET Username=?, Password=?, Fname=?, Mname=?, Lname=?, Suffix=?, dob=?, Email=?, MobileNum=? WHERE UserID= ?", conn)
                    upd.Parameters.AddWithValue("?", username)
                    upd.Parameters.AddWithValue("?", newPass)
                    upd.Parameters.AddWithValue("?", newFname)
                    upd.Parameters.AddWithValue("?", newMname)
                    upd.Parameters.AddWithValue("?", newLname)
                    upd.Parameters.AddWithValue("?", dtpDOB.Value.Date)
                    upd.Parameters.AddWithValue("?", newEmail)
                    upd.Parameters.AddWithValue("?", newMobile)
                    upd.Parameters.AddWithValue("?", userId)
                    upd.ExecuteNonQuery()
                End Using

                Dim changes As New List(Of String)()
                If oldUser <> username Then changes.Add("changed username from '" & oldUser & "' to '" & username & "'")
                If oldFname <> newFname Then changes.Add("changed first name from '" & oldFname & "' to '" & newFname & "'")
                If oldMname <> newMname Then changes.Add("changed middle name from '" & oldMname & "' to '" & newMname & "'")
                If oldLname <> newLname Then changes.Add("changed last name from '" & oldLname & "' to '" & newLname & "'")
                If oldDob <> newDob Then changes.Add("changed date of birth from '" & oldDob & "' to '" & newDob & "'")
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

    Private Function ValidateAllRequiredFields() As Boolean
        Dim missing As New List(Of String)
        Dim firstInvalidControl As Control = Nothing

        Dim assignFirst As Action(Of Control) = Sub(c As Control)
                                                    If firstInvalidControl Is Nothing Then firstInvalidControl = c
                                                End Sub

        If String.IsNullOrWhiteSpace(txtFirst.Text) Then
            missing.Add("First Name")
            assignFirst(txtFirst)
        End If

        If String.IsNullOrWhiteSpace(txtLname.Text) Then
            missing.Add("Last Name")
            assignFirst(txtLname)
        End If

        If String.IsNullOrWhiteSpace(cmbRole.Text) Then
            missing.Add("Role")
            assignFirst(cmbRole)
        End If

        If String.IsNullOrWhiteSpace(txtUser.Text) Then
            missing.Add("Username")
            assignFirst(txtUser)
        End If

        If String.IsNullOrWhiteSpace(txtPass.Text) Then
            missing.Add("Password")
            assignFirst(txtPass)
        End If

        ' Validate Date of Birth and Age
        Dim birthDate As Date = dtpDOB.Value
        Dim today As Date = Date.Today
        Dim ageValue As Integer = today.Year - birthDate.Year
        If today.Month < birthDate.Month OrElse (today.Month = birthDate.Month AndAlso today.Day < birthDate.Day) Then
            ageValue -= 1
        End If

        If ageValue <= 0 Then
            missing.Add("Date of Birth (must be a valid past date)")
            assignFirst(dtpDOB)
        End If

        If ageValue > 120 Then
            missing.Add("Date of Birth (age cannot exceed 120 years)")
            assignFirst(dtpDOB)
        End If

        ' Mobile required and basic validity (+63 and 10 digits after)
        Dim mobileText As String = If(txtMobile.Text, String.Empty).Trim()
        Dim digitsOnly As String = New String(mobileText.Where(Function(c) Char.IsDigit(c)).ToArray())
        If mobileText = String.Empty OrElse Not mobileText.StartsWith("+63") OrElse digitsOnly.Length <> 12 Then
            missing.Add("Valid Mobile Number (+63XXXXXXXXXX)")
            assignFirst(txtMobile)
        End If

        ' Email required and simple format check
        Dim email As String = If(txtEmail.Text, String.Empty).Trim().ToLower()
        If email = String.Empty OrElse Not (email.Contains("@") AndAlso email.EndsWith(".com")) Then
            missing.Add("Valid Email (must contain '@' and end with .com)")
            assignFirst(txtEmail)
        End If

        If missing.Count > 0 Then
            Dim message As String = "Please complete the required fields marked with (*):" & vbCrLf & " - " & String.Join(vbCrLf & " - ", missing)
            MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If firstInvalidControl IsNot Nothing Then firstInvalidControl.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
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

    Private Sub dtpDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDOB.ValueChanged
        CalculateAge()
    End Sub

    Private Sub CalculateAge()
        Try
            Dim birthDate As Date = dtpDOB.Value
            Dim today As Date = Date.Today
            Dim age As Integer = today.Year - birthDate.Year

            ' Adjust age if birthday hasn't occurred yet this year
            If today.Month < birthDate.Month OrElse (today.Month = birthDate.Month AndAlso today.Day < birthDate.Day) Then
                age -= 1
            End If

            If age > 120 Then
                MessageBox.Show("Invalid date of birth. Age cannot exceed 120 years old.", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtpDOB.Value = today.AddYears(-120)
                age = 120
            End If

            If age < 0 Then age = 0

            txtAge.Text = age.ToString()
        Catch ex As Exception
            txtAge.Text = "0"
        End Try
    End Sub

  
End Class