Module GlobalVariables
    Public LoggedInUser As String
    Public LoggedInRole As String
    Public LoggedInUserID As Integer
    Public LoggedInFullName As String
End Module

Public Class Login
    Dim cmd As Odbc.OdbcCommand
    Dim sql As String
    Dim da As New Odbc.OdbcDataAdapter
    Dim dt As New DataTable

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim dash As New dashboard
        Try
            Call dbConn()

            'Dim isdebugging As Boolean = True

            'Dim username As String = "sadmin"
            'Dim password As String = "s1234"

            ' Try to login with isArchived check, fallback if column doesn't exist
            sql = "SELECT userID, username, role, CONCAT(fname, ' ', lname) AS fullName FROM tbl_users WHERE username= ? AND password= ?"
            cmd = New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", txtUser.Text.Trim)
            cmd.Parameters.AddWithValue("?", txtPass.Text.Trim)

            da.SelectCommand = cmd
            dt.Clear()

            Try
                da.Fill(dt)
            Catch ex As Exception
                MsgBox("Database error: " & ex.Message, vbCritical, "Error")
                Exit Sub
            End Try

            If dt.Rows.Count > 0 Then
                ' Check if account is archived (only if column exists in database)
                Dim isArchived As Boolean = False
                Try
                    Dim checkArchiveSql As String = "SELECT isArchived FROM tbl_users WHERE userID = ?"
                    Dim checkCmd As New Odbc.OdbcCommand(checkArchiveSql, conn)
                    checkCmd.Parameters.AddWithValue("?", dt.Rows(0)("userID"))
                    Dim archiveResult = checkCmd.ExecuteScalar()
                    If archiveResult IsNot Nothing AndAlso archiveResult IsNot DBNull.Value Then
                        isArchived = Convert.ToBoolean(archiveResult)
                    End If
                Catch
                    ' Column doesn't exist yet, assume not archived
                    isArchived = False
                End Try

                If isArchived Then
                    MsgBox("This account has been archived and cannot be used to login. Please contact the administrator.", vbExclamation, "Account Archived")
                    Exit Sub
                End If

                GlobalVariables.LoggedInUser = dt.Rows(0)("username").ToString()
                GlobalVariables.LoggedInRole = dt.Rows(0)("role").ToString()
                GlobalVariables.LoggedInUserID = Convert.ToInt32(dt.Rows(0)("userID"))
                GlobalVariables.LoggedInFullName = dt.Rows(0)("fullName").ToString()

                ' Show default-password notice upon login if applicable
                Try
                    Dim checkPwdSql As String = "SELECT Password FROM tbl_users WHERE userID = ?"
                    Using pwdCmd As New Odbc.OdbcCommand(checkPwdSql, conn)
                        pwdCmd.Parameters.AddWithValue("?", GlobalVariables.LoggedInUserID)
                        Dim pwdObj = pwdCmd.ExecuteScalar()
                        Dim pwd As String = If(pwdObj Is Nothing OrElse pwdObj Is DBNull.Value, String.Empty, pwdObj.ToString())
                        If pwd = "1234" Then
                            MessageBox.Show("This is new profile, please change your password", "Security Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                Catch
                End Try


                InsertAuditTrail(GlobalVariables.LoggedInUserID, "Login", "User logged in")

                'MsgBox("Login Success!", vbInformation, "Login")

                ' Role-based navigation
                If GlobalVariables.LoggedInRole = "Doctor" OrElse GlobalVariables.LoggedInRole = "Receptionist" Then
                    ' For Optometrist and Receptionist, go directly to Patient Record
                    Dim Main As New MainForm()
                    MainForm.Show()

                    ' Automatically navigate to Patient Record instead of Dashboard
                    MainForm.btnPatientRecord.PerformClick()
                Else
                    ' For other roles (Admin, etc.), show normal MainForm with Dashboard
                    Dim Main As New MainForm()
                    MainForm.Show()
                End If

                Me.Hide()
                txtPass.Clear()
                txtUser.Clear()
            Else
                MsgBox("Invalid username or password. Please try again.", vbCritical, "Login Failed")
            End If

        Catch ex As Exception

        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Sub InsertAuditTrail(UserID As Integer, ActionType As String, ActionDetails As String)
        Dim connectionString As String = "DSN=dsnsystem"
        Using conn As New Odbc.OdbcConnection(connectionString)
            Try
                conn.Open()
                Dim query As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?)"
                Using cmd As New Odbc.OdbcCommand(query, conn)
                    cmd.Parameters.AddWithValue("?", UserID)
                    cmd.Parameters.AddWithValue("?", GlobalVariables.LoggedInUser)
                    cmd.Parameters.AddWithValue("?", ActionType)
                    cmd.Parameters.AddWithValue("?", ActionDetails)
                    cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                    cmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                MessageBox.Show("Audit Trail Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.ActiveControl = txtUser
    End Sub

    Private Sub txtUser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUser.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnLogin.PerformClick()
        End If
    End Sub
End Class
