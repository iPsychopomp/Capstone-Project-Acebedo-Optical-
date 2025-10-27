Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Data.Odbc

Module AddUserModule
    Public Sub LoadRecord(ByVal productID As Integer, ByVal conn As Odbc.OdbcConnection, ByRef txtFirst As TextBox, ByRef txtMname As TextBox, ByRef txtLname As TextBox, ByRef cmbRole As ComboBox, ByRef txtUser As TextBox, ByRef txtPass As TextBox, ByRef txtMobile As TextBox, ByRef txtEmail As TextBox)
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Dim sql As String = "SELECT * FROM tbl_users WHERE UserID=?"

        Try
            cmd = New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", productID)

            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                txtFirst.Text = dt.Rows(0)("Fname").ToString()
                txtMname.Text = dt.Rows(0)("Mname").ToString()
                txtLname.Text = dt.Rows(0)("Lname").ToString()
                cmbRole.Text = dt.Rows(0)("Role").ToString()
                txtUser.Text = dt.Rows(0)("Username").ToString()
                txtPass.Text = dt.Rows(0)("Password").ToString()
                txtMobile.Text = dt.Rows(0)("MobileNum").ToString()
                txtEmail.Text = dt.Rows(0)("Email").ToString()
            Else
                txtFirst.Text = ""
                txtMname.Text = ""
                txtLname.Text = ""
                cmbRole.Text = ""
                txtUser.Text = ""
                txtPass.Text = ""
                txtMobile.Text = ""
                txtEmail.Text = ""
                MsgBox("No record found.", vbInformation, "Record Not Found")
            End If

            cmd.Dispose()
            da.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), vbCritical, "Error Loading Record")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        GC.Collect()
    End Sub

    Public Function CheckData(ByVal gb As GroupBox) As Boolean
        For Each obj As Object In gb.Controls
            If TypeOf obj Is TextBox Then
                If Len(obj.Text) = 0 Then
                    MsgBox("Please Fill Up the Blanks", vbCritical, "Save")
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Sub Cleaner(pnlAddUser As Panel)
        For Each ctrl As Control In pnlAddUser.Controls
            If TypeOf ctrl Is GroupBox Then
                For Each obj As Control In ctrl.Controls
                    If TypeOf obj Is TextBox Then
                        Dim txt As TextBox = CType(obj, TextBox)
                        txt.Text = ""
                    ElseIf TypeOf obj Is ComboBox Then
                        Dim cmb As ComboBox = CType(obj, ComboBox)
                        cmb.SelectedIndex = -1
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub InsertAuditTrail(UserID As Integer, ActionType As String, ActionDetails As String, ByVal conn As Odbc.OdbcConnection)
        Dim connectionString As String = "DSN=dsnsystem"
        Using auditConn As New Odbc.OdbcConnection(connectionString)
            Try
                auditConn.Open()
                Dim query As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?)"
                Using cmd As New Odbc.OdbcCommand(query, auditConn)
                    cmd.Parameters.AddWithValue("?", UserID)
                    cmd.Parameters.AddWithValue("?", GlobalVariables.LoggedInUser)
                    cmd.Parameters.AddWithValue("?", ActionType)
                    cmd.Parameters.AddWithValue("?", ActionDetails)
                    cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("?", DateTime.Now.Date)

                    cmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                MsgBox("Audit Trail Error: " & ex.Message, vbCritical, "Error")
            Finally
                auditConn.Close()
            End Try
        End Using
    End Sub

    Public Function IsReservedUsername(username As String) As Boolean
        Dim reservedNames As New List(Of String) From {""}
        Return reservedNames.Contains(username.ToLower())
    End Function

    Public Function GetNextAvailableUsername(baseName As String, conn As Odbc.OdbcConnection) As String
        Dim nextNumber As Integer = 1
        Dim suggestedUsername As String
        Dim maxAttempts As Integer = 100
        Dim attempt As Integer = 0

        Do
            suggestedUsername = baseName.ToLower() & nextNumber.ToString()
            nextNumber += 1
            attempt += 1

            If attempt >= maxAttempts Then
                Return baseName.ToLower() & DateTime.Now.Ticks.ToString().Substring(0, 5)
            End If
        Loop While IsUsernameTaken(suggestedUsername, conn)

        Return suggestedUsername
    End Function

    Public Function IsUsernameTaken(username As String, conn As Odbc.OdbcConnection, Optional currentUserID As String = "") As Boolean
        Try
            Dim sql As String

            If String.IsNullOrEmpty(currentUserID) Then
                sql = "SELECT COUNT(*) FROM tbl_users WHERE LOWER(Username) = ?"
                Using cmd As New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", username.ToLower())
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            Else
                sql = "SELECT COUNT(*) FROM tbl_users WHERE LOWER(Username) = ? AND UserID <> ?"
                Using cmd As New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", username.ToLower())
                    cmd.Parameters.AddWithValue("?", currentUserID)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error checking if username is taken: " & ex.Message)
            Return False
        Finally
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        End Try
    End Function

    Public Sub SaveRecord(ByVal conn As Odbc.OdbcConnection, ByVal grpAddUser As GroupBox, ByVal pnlAddUser As Panel, ByVal txtUser As TextBox, ByVal txtPass As TextBox, ByVal txtFirst As TextBox, ByVal txtMname As TextBox, ByVal txtLname As TextBox, ByVal cmbRole As ComboBox, ByVal txtMobile As TextBox, ByVal txtEmail As TextBox, ByVal pnlAddUserTag As Object)
        If Not CheckData(grpAddUser) Then Exit Sub

        Dim username As String = txtUser.Text.Trim().ToLower()
        Dim originalUsername As String = ""

        ' Check if Username is taken or reserved
        If Len(pnlAddUserTag) = 0 OrElse (username <> originalUsername) Then
            If IsReservedUsername(username) OrElse IsUsernameTaken(username, conn, pnlAddUserTag) Then
                Dim suggestedUsername As String = GetNextAvailableUsername(username, conn)
                Dim result As DialogResult = MessageBox.Show(
                    "Username '" & username & "' is reserved or already taken. Would you like to use '" & suggestedUsername & "' instead?",
                    "Reserved/Taken Username",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    txtUser.Text = suggestedUsername
                    username = suggestedUsername
                Else
                    txtUser.Focus()
                    txtUser.SelectAll()
                    Exit Sub
                End If
            End If
        End If

        If MsgBox("Do you want to save this record?", vbYesNo + vbQuestion, "Save") <> vbYes Then Exit Sub

        Try
            Call dbConn()
            Using cmd As New Odbc.OdbcCommand()
                cmd.Connection = conn

                If Len(pnlAddUserTag) = 0 Then
                    ' Insert new record
                    cmd.CommandText = "INSERT INTO tbl_users (Username, Password, Role, Fname, Mname, Lname, MobileNum, Email) VALUES (?,?,?,?,?,?,?,?)"
                    cmd.Parameters.AddWithValue("?", username)
                    cmd.Parameters.AddWithValue("?", txtPass.Text)
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(cmbRole.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtFirst.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtMname.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtLname.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", txtMobile.Text)
                    cmd.Parameters.AddWithValue("?", Trim(txtEmail.Text))

                    cmd.ExecuteNonQuery()

                    Dim lastInsertedID As Integer
                    Using lastCmd As New Odbc.OdbcCommand("SELECT MAX(UserID) FROM tbl_users", conn)
                        Dim result = lastCmd.ExecuteScalar()
                        If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                            lastInsertedID = Convert.ToInt32(result)
                        Else
                            lastInsertedID = 0
                        End If
                    End Using

                    InsertAuditTrail(GlobalVariables.LoggedInUserID, "Add User", "Added user: " & txtUser.Text, conn)
                Else
                    ' Update existing record
                    cmd.CommandText = "UPDATE tbl_users SET Username=?, Password=?, Role=?, Fname=?, Mname=?, Lname=?, MobileNum=?, Email=? WHERE UserID=?"
                    cmd.Parameters.AddWithValue("?", username)
                    cmd.Parameters.AddWithValue("?", txtPass.Text)
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(cmbRole.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtFirst.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtMname.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtLname.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", txtMobile.Text)
                    cmd.Parameters.AddWithValue("?", Trim(txtEmail.Text))
                    cmd.Parameters.AddWithValue("?", pnlAddUserTag)

                    cmd.ExecuteNonQuery()

                    MessageBox.Show("The Data Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InsertAuditTrail(GlobalVariables.LoggedInUserID, "Update User", "Update User: " & txtUser.Text, conn)
                End If
            End Using

            ' Refresh Data Grid View (replace 'users.UserDGV' with the actual DataGridView in your form)
            Call LoadDGV("SELECT * FROM db_viewuser", users.UserDGV)
        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        Cleaner(pnlAddUser)
    End Sub
End Module