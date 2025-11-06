Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Data.Odbc

Module usersModule

    ' Ensure isArchived column exists in tbl_users
    Private Sub EnsureArchivedColumn()
        Try
            ' Check if column exists
            Dim checkSql As String = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'tbl_users' AND COLUMN_NAME = 'isArchived'"
            Using checkCmd As New Odbc.OdbcCommand(checkSql, conn)
                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                If exists = 0 Then
                    ' Add isArchived column if it doesn't exist
                    Dim alterSql As String = "ALTER TABLE tbl_users ADD COLUMN isArchived TINYINT(1) DEFAULT 0"
                    Using alterCmd As New Odbc.OdbcCommand(alterSql, conn)
                        alterCmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
        Catch ex As Exception
            ' Silently handle - column may already exist
            Debug.WriteLine("EnsureArchivedColumn error: " & ex.Message)
        End Try
    End Sub

    Public Sub users_Load(UserDGV As DataGridView)
        Call dbConn()
        ' Ensure isArchived column exists
        EnsureArchivedColumn()
        conn.Close()

        Call dbConn()
        ' Hide Super Admin users and archived users from list
        ' Use try-catch in case column doesn't exist in view yet
        Try
            If LoggedInRole = "Super Admin" Then
                Call LoadDGV("SELECT * FROM db_viewuser WHERE isArchived = 0 OR isArchived IS NULL", UserDGV)
            Else
                Call LoadDGV("SELECT * FROM db_viewuser WHERE (isArchived = 0 OR isArchived IS NULL) AND Role <> 'Super Admin'", UserDGV)
            End If
        Catch ex As Exception
            ' Fallback if isArchived column doesn't exist in view yet
            If LoggedInRole = "Super Admin" Then
                Call LoadDGV("SELECT * FROM db_viewuser", UserDGV)
            Else
                Call LoadDGV("SELECT * FROM db_viewuser WHERE Role <> 'Super Admin'", UserDGV)
            End If
        End Try
        DgvStyle(UserDGV)

        ' Hide isArchived column if it exists
        If UserDGV.Columns.Contains("isArchived") Then
            UserDGV.Columns("isArchived").Visible = False
        End If
    End Sub

    Public Sub btnClose_Click(form As Form)
        form.Close()
    End Sub

    Public Sub LoadData(UserDGV As DataGridView)
        Try
            Call dbConn()
            ' Hide Super Admin users and archived users from list
            Try
                If LoggedInRole = "Super Admin" Then
                    Call LoadDGV("SELECT * FROM db_viewuser WHERE isArchived = 0 OR isArchived IS NULL", UserDGV)
                Else
                    Call LoadDGV("SELECT * FROM db_viewuser WHERE (isArchived = 0 OR isArchived IS NULL) AND Role <> 'Super Admin'", UserDGV)
                End If
            Catch
                ' Fallback if isArchived column doesn't exist yet
                If LoggedInRole = "Super Admin" Then
                    Call LoadDGV("SELECT * FROM db_viewuser", UserDGV)
                Else
                    Call LoadDGV("SELECT * FROM db_viewuser WHERE Role <> 'Super Admin'", UserDGV)
                End If
            End Try

            ' Hide isArchived column if it exists
            If UserDGV.Columns.Contains("isArchived") Then
                UserDGV.Columns("isArchived").Visible = False
            End If

            UserDGV.ClearSelection()
        Catch ex As Exception
            MsgBox("Failed to load data: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Public Sub UserDGV_CellClick(UserDGV As DataGridView, e As DataGridViewCellEventArgs)
        Try
            If e.RowIndex >= 0 Then
                UserDGV.Rows(e.RowIndex).Selected = True
            End If
        Catch ex As Exception
            MessageBox.Show("Select Record First" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub btnAdd_Click(UserDGV As DataGridView, handler As FormClosedEventHandler)
        Dim usersAdd As New addUsers()
        usersAdd.TopMost = True
        AddHandler usersAdd.FormClosed, handler
        usersAdd.ShowDialog()
    End Sub

    Public Sub btnEdit_Click(UserDGV As DataGridView, handler As FormClosedEventHandler)
        If UserDGV.SelectedRows.Count > 0 Then
            Dim UserID As Integer = Convert.ToInt32(UserDGV.SelectedRows(0).Cells("Column1").Value)

            ' Admin can only edit their own account, not other users
            If LoggedInRole = "Admin" OrElse LoggedInRole = "Administrator" Then
                If UserID <> LoggedInUserID Then
                    MessageBox.Show("You can only edit your own account.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If

            If MsgBox("Are you sure you want to edit this record?", vbYesNo + vbQuestion, "Edit") = vbYes Then

                Dim usersAdd As New addUsers()
                AddHandler usersAdd.FormClosed, handler
                usersAdd.TopMost = True
                usersAdd.Show()
                usersAdd.pnlAddUser.Tag = UserID
                usersAdd.Text = "Edit Users Information"
                usersAdd.loadRecord(UserID)

            End If
        Else
            MessageBox.Show("Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Function checkData(gb As GroupBox) As Boolean
        For Each obj As Object In gb.Controls
            If TypeOf obj Is TextBox Then
                If Len(obj.text) = 0 Then
                    MsgBox("Please input data", vbCritical, "Save")
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Sub btnSearch_Click(UserDGV As DataGridView, txtSearch As TextBox)
        Call dbConn()
        ' Hide Super Admin users and archived users from search results
        Try
            If LoggedInRole = "Super Admin" Then
                Call LoadDGV("SELECT * FROM db_viewuser WHERE Username LIKE ? AND (isArchived = 0 OR isArchived IS NULL)", UserDGV, txtSearch.Text)
            Else
                Call LoadDGV("SELECT * FROM db_viewuser WHERE Username LIKE ? AND (isArchived = 0 OR isArchived IS NULL) AND Role <> 'Super Admin'", UserDGV, txtSearch.Text)
            End If
        Catch
            ' Fallback if isArchived column doesn't exist yet
            If LoggedInRole = "Super Admin" Then
                Call LoadDGV("SELECT * FROM db_viewuser WHERE Username LIKE ?", UserDGV, txtSearch.Text)
            Else
                Call LoadDGV("SELECT * FROM db_viewuser WHERE Username LIKE ? AND Role <> 'Super Admin'", UserDGV, txtSearch.Text)
            End If
        End Try

        ' Hide isArchived column if it exists
        If UserDGV.Columns.Contains("isArchived") Then
            UserDGV.Columns("isArchived").Visible = False
        End If
    End Sub

    Public Sub btnDelete_Click(UserDGV As DataGridView)
        Dim cmd As Odbc.OdbcCommand
        Dim sql As String
        Dim username As String = ""
        Dim userRole As String = ""

        If UserDGV.SelectedRows.Count > 0 Then
            Dim UserID As Integer = Convert.ToInt32(UserDGV.SelectedRows(0).Cells("Column1").Value)

            ' Admin can only delete their own account, not other users
            If LoggedInRole = "Admin" OrElse LoggedInRole = "Administrator" Then
                If UserID <> LoggedInUserID Then
                    MessageBox.Show("You can only delete your own account. You cannot delete other users.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If

            ' Check if trying to delete Super Admin or last Admin
            Try
                Call dbConn()
                sql = "SELECT Username, Role FROM tbl_users WHERE UserID = ?"
                cmd = New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", UserID)
                Dim reader = cmd.ExecuteReader()
                If reader.Read() Then
                    username = reader("Username").ToString()
                    userRole = reader("Role").ToString()
                End If
                reader.Close()

                ' Prevent deletion of Super Admin
                If userRole = "Super Admin" Then
                    conn.Close()
                    MsgBox("Super Admin account cannot be deleted.", vbExclamation, "Cannot Delete")
                    Exit Sub
                End If

                ' Check if this is the last Admin account
                If userRole = "Admin" OrElse userRole = "Administrator" Then
                    sql = "SELECT COUNT(*) FROM tbl_users WHERE (Role = 'Admin' OR Role = 'Administrator') AND (isArchived = 0 OR isArchived IS NULL)"
                    cmd = New Odbc.OdbcCommand(sql, conn)
                    Dim adminCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If adminCount <= 1 Then
                        conn.Close()
                        MsgBox("Cannot delete the last Admin account.", vbExclamation, "Cannot Delete")
                        Exit Sub
                    End If
                End If

                conn.Close()
            Catch ex As Exception
                If conn.State = ConnectionState.Open Then conn.Close()
                MsgBox("Error checking user role: " & ex.Message, vbCritical, "Error")
                Exit Sub
            End Try

            If MsgBox("Are you sure you want to Delete this user account?", vbYesNo + vbQuestion, "Delete User") = vbYes Then
                Try
                    Call dbConn()

                    ' First, ensure the isArchived column exists
                    EnsureArchivedColumn()

                    ' Archive the user instead of deleting (soft delete)
                    sql = "UPDATE tbl_users SET isArchived = 1 WHERE UserID = ?"
                    cmd = New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", UserID)
                    cmd.ExecuteNonQuery()

                    InsertAuditTrail(GlobalVariables.LoggedInUserID, "Archive User", "Archived user: " & username)

                    MsgBox("User account Deleted successfully!", vbInformation, "Success")
                    ' Reload with proper filtering
                    If LoggedInRole = "Super Admin" Then
                        Call LoadDGV("SELECT * FROM db_viewuser WHERE isArchived = 0 OR isArchived IS NULL", UserDGV)
                    Else
                        Call LoadDGV("SELECT * FROM db_viewuser WHERE (isArchived = 0 OR isArchived IS NULL) AND Role <> 'Super Admin'", UserDGV)
                    End If

                Catch ex As Exception
                    MsgBox("Error: " & ex.Message, vbCritical, "Archive Failed")
                Finally
                    conn.Close()
                    conn.Dispose()
                End Try
            End If
        Else
            MsgBox("Please select a record to delete.", vbExclamation, "No Row Selected")
        End If
    End Sub

    Public Sub InsertAuditTrail(UserID As Integer, ActionType As String, ActionDetails As String)
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
                MsgBox("Audit Trail Error: " & ex.Message, vbCritical, "Error")
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Public Sub OnAddRecordClosed(UserDGV As DataGridView)
        Call dbConn()
        ' Hide Super Admin users and archived users from list
        Try
            If LoggedInRole = "Super Admin" Then
                Call LoadDGV("SELECT * FROM db_viewuser WHERE isArchived = 0 OR isArchived IS NULL", UserDGV)
            Else
                Call LoadDGV("SELECT * FROM db_viewuser WHERE (isArchived = 0 OR isArchived IS NULL) AND Role <> 'Super Admin'", UserDGV)
            End If
        Catch
            ' Fallback if isArchived column doesn't exist yet
            If LoggedInRole = "Super Admin" Then
                Call LoadDGV("SELECT * FROM db_viewuser", UserDGV)
            Else
                Call LoadDGV("SELECT * FROM db_viewuser WHERE Role <> 'Super Admin'", UserDGV)
            End If
        End Try

        ' Hide isArchived column if it exists
        If UserDGV.Columns.Contains("isArchived") Then
            UserDGV.Columns("isArchived").Visible = False
        End If

        UserDGV.Refresh()
    End Sub

    Public Sub LoadUsersPage(dgv As DataGridView, pageIndex As Integer, pageSize As Integer, ByRef totalCount As Integer, Optional searchUsername As String = Nothing)
        Try
            dgv.AutoGenerateColumns = False

            Dim baseFrom As String = " FROM db_viewuser "
            Dim whereParts As New List(Of String)()

            ' Exclude archived by default
            whereParts.Add("(isArchived = 0 OR isArchived IS NULL)")
            ' Exclude Super Admin unless current is Super Admin
            If LoggedInRole <> "Super Admin" Then
                whereParts.Add("Role <> 'Super Admin'")
            End If
            ' Optional search by username
            Dim hasSearch As Boolean = Not String.IsNullOrWhiteSpace(searchUsername)
            If hasSearch Then
                whereParts.Add("Username LIKE ?")
            End If

            Dim whereSql As String = If(whereParts.Count > 0, " WHERE " & String.Join(" AND ", whereParts), "")

            Dim countSql As String = "SELECT COUNT(*)" & baseFrom & whereSql
            Dim dataSql As String = _
                "SELECT *" & baseFrom & whereSql & _
                " ORDER BY UserID DESC " & _
                "LIMIT ? OFFSET ?"

            Using cn As New Odbc.OdbcConnection(myDSN)
                cn.Open()
                ' Count
                Using cmdCount As New Odbc.OdbcCommand(countSql, cn)
                    If hasSearch Then
                        cmdCount.Parameters.AddWithValue("?", searchUsername)
                    End If
                    Dim obj = cmdCount.ExecuteScalar()
                    totalCount = 0
                    If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                        Integer.TryParse(obj.ToString(), totalCount)
                    End If
                End Using

                ' Page data
                Using cmd As New Odbc.OdbcCommand(dataSql, cn)
                    If hasSearch Then
                        cmd.Parameters.AddWithValue("?", searchUsername)
                    End If
                    cmd.Parameters.AddWithValue("?", pageSize)
                    cmd.Parameters.AddWithValue("?", pageIndex * pageSize)
                    Dim da As New Odbc.OdbcDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dgv.DataSource = dt
                    dgv.ClearSelection()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Failed to load users: " & ex.Message, vbCritical, "Error")
        End Try
        DgvStyle(dgv)
        ' Hide isArchived column if present
        If dgv.Columns.Contains("isArchived") Then
            dgv.Columns("isArchived").Visible = False
        End If
    End Sub

    Public Sub DgvStyle(ByRef UserDGV As DataGridView)
        ' Basic Grid Setup
        UserDGV.AutoGenerateColumns = False
        UserDGV.AllowUserToAddRows = False
        UserDGV.AllowUserToDeleteRows = False
        UserDGV.RowHeadersVisible = False
        UserDGV.BorderStyle = BorderStyle.FixedSingle
        UserDGV.BackgroundColor = Color.White
        UserDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        UserDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        UserDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        UserDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        UserDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        UserDGV.EnableHeadersVisualStyles = False
        UserDGV.DefaultCellStyle.ForeColor = Color.Black
        UserDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        UserDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        UserDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        UserDGV.GridColor = Color.Silver
        UserDGV.DefaultCellStyle.Padding = New Padding(5)
        UserDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        UserDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        UserDGV.ReadOnly = True
        UserDGV.MultiSelect = False
        UserDGV.AllowUserToResizeRows = False
        UserDGV.RowTemplate.Height = 30
        UserDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        UserDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub
End Module