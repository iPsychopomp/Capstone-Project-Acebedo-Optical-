Imports System.Data.Odbc

Public Class Profile

    Private Sub Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCurrentUser()
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

            Using conn As New OdbcConnection("DSN=dsnsystem")
                conn.Open()

                Dim oldPass As String = ""
                Dim oldEmail As String = ""
                Dim oldMobile As String = ""

                Using getCmd As New OdbcCommand("SELECT Password, Email, MobileNum FROM tbl_users WHERE UserID=?", conn)
                    getCmd.Parameters.AddWithValue("?", userId)
                    Using rd = getCmd.ExecuteReader()
                        If rd.Read() Then
                            If Not rd.IsDBNull(0) Then oldPass = rd.GetString(0)
                            If Not rd.IsDBNull(1) Then oldEmail = rd.GetString(1)
                            If Not rd.IsDBNull(2) Then oldMobile = rd.GetString(2)
                        End If
                    End Using
                End Using

                Dim newPass As String = txtPass.Text
                Dim newEmail As String = txtEmail.Text
                Dim newMobile As String = txtMobile.Text

                Using upd As New OdbcCommand("UPDATE tbl_users SET Password=?, Email=?, MobileNum=? WHERE UserID=?", conn)
                    upd.Parameters.AddWithValue("?", newPass)
                    upd.Parameters.AddWithValue("?", newEmail)
                    upd.Parameters.AddWithValue("?", newMobile)
                    upd.Parameters.AddWithValue("?", userId)
                    upd.ExecuteNonQuery()
                End Using

                Dim changes As New List(Of String)()
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


End Class