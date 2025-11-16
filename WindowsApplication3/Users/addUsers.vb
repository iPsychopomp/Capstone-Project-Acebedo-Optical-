Imports System.ComponentModel '
Imports System.Text.RegularExpressions
Imports System.Data.Odbc
Public Class addUsers

    Public Property SuppressDefaultPasswordNotice As Boolean = False

    Public Sub loadRecord(ByVal productID As Integer)
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Dim sql As String = "SELECT * FROM tbl_users WHERE UserID=?"

        Try

            Call dbConn()

            cmd = New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", productID)

            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                txtFirst.Text = dt.Rows(0)("Fname").ToString()
                txtMname.Text = dt.Rows(0)("Mname").ToString()
                txtLname.Text = dt.Rows(0)("Lname").ToString()
                If Not IsDBNull(dt.Rows(0)("dob")) Then
                    Dim dobValue As Date = Convert.ToDateTime(dt.Rows(0)("dob"))
                    ' Validate date is within acceptable range before setting
                    If dobValue <= Date.Today AndAlso dobValue >= Date.Today.AddYears(-120) Then
                        dtpDOB.Value = dobValue
                    Else
                        ' Set to today if invalid date
                        dtpDOB.Value = Date.Today
                    End If
                End If
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

    Function checkData(ByVal gb As GroupBox) As Boolean
        For Each obj As Object In gb.Controls
            If TypeOf obj Is TextBox Then
                If Len(obj.text) = 0 Then
                    MsgBox("Please Fill Up the Blanks", vbCritical, "Save")
                    checkData = False
                    Exit Function
                End If
            End If

        Next
        Return True
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        Call cleaner()
    End Sub

    Public Sub New()
        InitializeComponent()
        ' Set date range immediately after initialization to prevent errors
        Try
            dtpDOB.MinDate = Date.Today.AddYears(-120)
            dtpDOB.MaxDate = Date.Today
            dtpDOB.Value = Date.Today
        Catch ex As Exception
            ' Silently handle initialization errors
        End Try
    End Sub

    Private Sub cleaner()
        For Each ctrl As Control In pnlAddUser.Controls
            If TypeOf ctrl Is GroupBox Then
                For Each obj As Control In ctrl.Controls
                    'PANG CLEAR NANG TEXT BOX SA LOOB NANG GRPBOX
                    If TypeOf obj Is TextBox Then
                        Dim txt As TextBox = CType(obj, TextBox)
                        txt.Text = ""
                        ' PANG CLEAR NANG COMBO BOX SA LOOB NANG GRPBOX
                    ElseIf TypeOf obj Is ComboBox Then
                        Dim cmb As ComboBox = CType(obj, ComboBox)
                        cmb.SelectedIndex = -1 ' RESET NANG SELECTED ITEMS
                        ' PANG CLEAR NANG DATE TIME PICKER SA LOOB NANG GRPBOX
                    ElseIf TypeOf obj Is DateTimePicker Then
                        Dim dtp As DateTimePicker = CType(obj, DateTimePicker)
                        dtp.Value = Date.Today
                    End If
                Next
            End If
        Next
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
                MsgBox("Audit Trail Error: " & ex.Message, vbCritical, "Error")
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub pnlAddUser_Paint(sender As Object, e As PaintEventArgs) Handles pnlAddUser.Paint
        txtFirst.TabIndex = 0
        txtMname.TabIndex = 1
        txtLname.TabIndex = 2
        dtpDOB.TabIndex = 3
        txtAge.TabIndex = 4
        txtMobile.TabIndex = 5
        txtEmail.TabIndex = 6
        pnlAccount.TabIndex = 7
        btnSave.TabIndex = 8
    End Sub

    Private Sub pnlAccount_Paint(sender As Object, e As PaintEventArgs)
        txtUser.TabIndex = 0
        txtPass.TabIndex = 1
        cmbRole.TabIndex = 2
    End Sub

    'ITO YUN HANDLER NANG VALIDATION ERROR NA NEED FILL UP-AN YUN MGA REQUIRED
    Private Sub AddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Set minimum date to 120 years ago from today
            dtpDOB.MinDate = Date.Today.AddYears(-120)
            dtpDOB.MaxDate = Date.Today

            ' Unified validation happens on save.
            ' Light Validating only for optional defaults: auto-fill Middle Name with N/A on tab/skip.
            AddHandler txtMname.Validating, AddressOf TextBox_Validating
            AddHandler dtpDOB.Validating, AddressOf DateTimePicker_Validating

            ' Setup Super Admin role visibility
            SetupSuperAdminRoleVisibility()
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupSuperAdminRoleVisibility()
        Try
            ' Remove "Super Admin" from dropdown if not logged in as Super Admin
            If cmbRole.Items.Contains("Super Admin") Then
                If LoggedInRole <> "Super Admin" Then
                    cmbRole.Items.Remove("Super Admin")
                End If
            End If
        Catch ex As Exception
            ' Silently handle any errors
        End Try
    End Sub

    Private Function SuperAdminExists(Optional excludeUserID As Integer = 0) As Boolean
        Try
            Call dbConn()
            Dim sql As String
            If excludeUserID > 0 Then
                ' Exclude current user when checking (for edit mode)
                sql = "SELECT COUNT(*) FROM tbl_users WHERE Role = 'Super Admin' AND UserID <> ?"
                Using cmd As New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", excludeUserID)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            Else
                ' Check if any Super Admin exists
                sql = "SELECT COUNT(*) FROM tbl_users WHERE Role = 'Super Admin'"
                Using cmd As New Odbc.OdbcCommand(sql, conn)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End If
        Catch ex As Exception
            Return False
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

    Private Sub AddUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Dim result As DialogResult = MessageBox.Show("Are you sure you want to close the form?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'If result = DialogResult.No Then
        'e.Cancel = True
        'Else
        'e.Cancel = False ' 
        'End If
    End Sub

    Private Function ValidateAllRequiredFieldsAndFocusFirst() As Boolean
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

        ' Mobile required and basic validity (+63 and 12 digits total excluding +)
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

    ' Per-control Validating removed; keep optional defaulting for Middle Name only if desired.
    Private Sub TextBox_Validating(sender As Object, e As CancelEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        If txt.Name = "txtMname" AndAlso String.IsNullOrWhiteSpace(txt.Text) Then
            txt.Text = "N/A"
        End If

        If txt.Name = "txtSuffix" AndAlso String.IsNullOrWhiteSpace(txt.Text) Then
            txt.Text = "N/A"
        End If
    End Sub

    ' Remove per-combobox validation popups; unified validation will handle required Role on save.
    Private Sub ComboBox_Validating(sender As Object, e As CancelEventArgs)
        ' Intentionally left light; no popups here.
    End Sub

    Private Function IsReservedUsername(username As String) As Boolean
        Dim reservedNames As New List(Of String) From {""}
        Return reservedNames.Contains(username.ToLower())
    End Function

    ' Modified function to handle username suggestions better
    Private Function GetNextAvailableUsername(baseName As String) As String
        Dim nextNumber As Integer = 1
        Dim suggestedUsername As String
        Dim maxAttempts As Integer = 100
        Dim attempt As Integer = 0

        ' First try adding sequential numbers
        Do
            suggestedUsername = baseName.ToLower() & nextNumber.ToString()
            nextNumber += 1
            attempt += 1

            ' Break out if we've tried too many times
            If attempt >= maxAttempts Then
                ' Add a timestamp as a last resort
                Return baseName.ToLower() & DateTime.Now.Ticks.ToString().Substring(0, 5)
            End If
        Loop While IsUsernameTaken(suggestedUsername)

        Return suggestedUsername
    End Function

    Private Function IsUsernameTaken(username As String, Optional currentUserID As String = "") As Boolean
        Try
            Call dbConn()
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

    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Normalize optional fields
        If String.IsNullOrWhiteSpace(txtMname.Text) Then txtMname.Text = "N/A"

        ' Unified validation like addPatient.vb
        If Not ValidateAllRequiredFieldsAndFocusFirst() Then Exit Sub

        Dim originalUsername As String = ""
        Dim username As String = txtUser.Text.Trim().ToLower()
        If Len(pnlAddUser.Tag) > 0 Then
            Try
                Call dbConn()
                Using checkCmd As New Odbc.OdbcCommand("SELECT Username FROM tbl_users WHERE UserID=?", conn)
                    checkCmd.Parameters.AddWithValue("?", pnlAddUser.Tag)
                    Dim result = checkCmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        originalUsername = result.ToString().Trim().ToLower()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving original username: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End If

        If Len(pnlAddUser.Tag) = 0 OrElse (username <> originalUsername) Then
            If IsReservedUsername(username) OrElse IsUsernameTaken(username, pnlAddUser.Tag) Then
                Dim suggestedUsername As String = GetNextAvailableUsername(username)

                Dim result As DialogResult = MessageBox.Show(
                    "Username '" & username & "' is reserved or already taken. Would you like to use '" &
                    suggestedUsername & "' instead?",
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

        ' Removed generic group-based blank check in favor of explicit unified validation

        ' Validate Super Admin role selection
        If cmbRole.Text = "Super Admin" Then
            ' Only Super Admin can create/edit Super Admin role
            If LoggedInRole <> "Super Admin" Then
                MessageBox.Show("Only Super Admin can assign the Super Admin role.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbRole.Focus()
                Exit Sub
            End If

            ' Check if creating new Super Admin
            If Len(pnlAddUser.Tag) = 0 Then
                ' Creating new user - check if Super Admin already exists
                If SuperAdminExists() Then
                    MessageBox.Show("A Super Admin already exists in the system. Only one Super Admin is allowed.", "Super Admin Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbRole.Focus()
                    Exit Sub
                End If
            Else
                ' Editing existing user - check if changing to Super Admin
                Try
                    Call dbConn()
                    Dim currentRole As String = ""
                    Using checkRoleCmd As New Odbc.OdbcCommand("SELECT Role FROM tbl_users WHERE UserID=?", conn)
                        checkRoleCmd.Parameters.AddWithValue("?", pnlAddUser.Tag)
                        Dim roleResult = checkRoleCmd.ExecuteScalar()
                        If roleResult IsNot Nothing Then
                            currentRole = roleResult.ToString()
                        End If
                    End Using
                    conn.Close()

                    ' If changing from non-Super Admin to Super Admin, check if one exists
                    If currentRole <> "Super Admin" Then
                        Dim currentUserID As Integer = Convert.ToInt32(pnlAddUser.Tag)
                        If SuperAdminExists(currentUserID) Then
                            MessageBox.Show("A Super Admin already exists in the system. Only one Super Admin is allowed.", "Super Admin Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            cmbRole.Focus()
                            Exit Sub
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error checking current role: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End Try
            End If
        End If

        If MsgBox("Do you want to save this record?", vbYesNo + vbQuestion, "Save") <> vbYes Then Exit Sub

        Try
            Call dbConn()
            Using cmd As New Odbc.OdbcCommand()
                cmd.Connection = conn

                If Len(pnlAddUser.Tag) = 0 Then

                    cmd.CommandText = "INSERT INTO tbl_users (Username, Password, Role, Fname, Mname, Lname, Suffix, dob, MobileNum, Email) VALUES (?,?,?,?,?,?,?,?,?,?)"
                    cmd.Parameters.AddWithValue("?", username)
                    cmd.Parameters.AddWithValue("?", txtPass.Text)
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(cmbRole.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtFirst.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtMname.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtLname.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", dtpDOB.Value.Date)
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

                    InsertAuditTrail(GlobalVariables.LoggedInUserID, "Add User", "Added user: " & txtUser.Text)

                Else

                    cmd.CommandText = "UPDATE tbl_users SET Username=?, Password=?, Role=?, Fname=?, Mname=?, Lname=?, Suffix=?, dob=?, MobileNum=?, Email=? WHERE UserID=?"
                    cmd.Parameters.AddWithValue("?", username)
                    cmd.Parameters.AddWithValue("?", txtPass.Text)
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(cmbRole.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtFirst.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtMname.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtLname.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", dtpDOB.Value.Date)
                    cmd.Parameters.AddWithValue("?", txtMobile.Text)
                    cmd.Parameters.AddWithValue("?", Trim(txtEmail.Text))
                    cmd.Parameters.AddWithValue("?", pnlAddUser.Tag)

                    cmd.ExecuteNonQuery()
                    MessageBox.Show("The Data Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InsertAuditTrail(GlobalVariables.LoggedInUserID, "Update User", "Update User: " & txtUser.Text)
                End If
            End Using

            ' Reload with proper sorting
            Try
                If LoggedInRole = "Super Admin" Then
                    Call LoadDGV("SELECT * FROM db_viewuser WHERE isArchived = 0 OR isArchived IS NULL ORDER BY Username ASC", users.UserDGV)
                Else
                    Call LoadDGV("SELECT * FROM db_viewuser WHERE (isArchived = 0 OR isArchived IS NULL) AND Role <> 'Super Admin' ORDER BY Username ASC", users.UserDGV)
                End If
            Catch
                ' Fallback if isArchived column doesn't exist yet
                If LoggedInRole = "Super Admin" Then
                    Call LoadDGV("SELECT * FROM db_viewuser ORDER BY Username ASC", users.UserDGV)
                Else
                    Call LoadDGV("SELECT * FROM db_viewuser WHERE Role <> 'Super Admin' ORDER BY Username ASC", users.UserDGV)
                End If
            End Try
        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
        Me.Close()
        cleaner()
    End Sub

    Private Sub txtMobile_Enter(sender As Object, e As EventArgs) Handles txtMobile.Enter
        If String.IsNullOrWhiteSpace(txtMobile.Text) Then
            txtMobile.Text = "+63"
        End If
        If txtMobile.Text.StartsWith("+63") Then
            txtMobile.SelectionStart = 3
            txtMobile.SelectionLength = 0
        End If
    End Sub

    Private Sub txtMobile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMobile.KeyPress
        ' Keep caret after +63 and protect prefix
        If txtMobile.SelectionStart < 3 Then
            If e.KeyChar = ChrW(Keys.Back) OrElse e.KeyChar = ChrW(Keys.Delete) Then
                e.Handled = True
                Return
            End If
            txtMobile.SelectionStart = 3
        End If

        ' Allow digits and control keys only
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        ' Respect max length 13 considering selection
        If Not Char.IsControl(e.KeyChar) Then
            Dim remaining As Integer = 13 - (txtMobile.TextLength - txtMobile.SelectionLength)
            If remaining <= 0 Then
                e.Handled = True
                Return
            End If
        End If
    End Sub

    Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs) Handles txtMobile.TextChanged
        ' Always enforce +63 at the start
        If Not txtMobile.Text.StartsWith("+63") Then
            txtMobile.Text = "+63"
            txtMobile.SelectionStart = txtMobile.Text.Length
        End If
    End Sub




    Private Sub txtPass_TextChanged(sender As Object, e As EventArgs) Handles txtPass.TextChanged

    End Sub

    Private Sub DateTimePicker_Validating(sender As Object, e As CancelEventArgs)
        Dim dtp As DateTimePicker = CType(sender, DateTimePicker)

        ' Custom validation for DateTimePicker fields
        If dtp.Name = "dtpDOB" Then

            ' Check if the date is valid for a birthdate (not in the future)
            If dtp.Value > Date.Today Then
                e.Cancel = True
                MsgBox("Date of Birth cannot be in the future.", vbExclamation, "Error")
            End If

            ' Check if the birthdate is reasonable (not more than 120 years ago)
            Dim maxAge As Integer = 120
            If dtp.Value < Date.Today.AddYears(-maxAge) Then
                e.Cancel = True
                MsgBox("Please enter a Valid Date of Birth.", vbExclamation, "Error")
            End If
        End If
    End Sub

    Private Sub dtpDOB_ValueChanged(sender As Object, e As EventArgs) Handles dtpDOB.ValueChanged
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

        txtAge.Text = age.ToString()

        ' Auto-generate password for new users when DOB changes
        If Len(pnlAddUser.Tag) = 0 AndAlso Not String.IsNullOrWhiteSpace(txtFirst.Text) Then
            GenerateDefaultPassword()
        End If
    End Sub

    Private Sub txtFirst_TextChanged(sender As Object, e As EventArgs) Handles txtFirst.TextChanged
        ' Password will be auto-generated only when DOB is selected
    End Sub

    Private Sub GenerateDefaultPassword()
        ' Only generate for new users (not editing)
        If Len(pnlAddUser.Tag) > 0 Then Exit Sub

        ' Check if logged in user is Admin or Super Admin
        If LoggedInRole <> "Admin" AndAlso LoggedInRole <> "Administrator" AndAlso LoggedInRole <> "Super Admin" Then
            Exit Sub
        End If

        ' Get first 2 letters of first name
        Dim firstName As String = txtFirst.Text.Trim()
        If firstName.Length < 2 Then Exit Sub

        Dim first2Letters As String = firstName.Substring(0, 2).ToLower()

        ' Get birth month, day, and year from dtpDOB
        Dim birthMonth As String = dtpDOB.Value.Month.ToString("00")
        Dim birthDay As String = dtpDOB.Value.Day.ToString("00")
        Dim birthYear As String = dtpDOB.Value.Year.ToString()

        ' Format: first2letters + @ + month + day + year
        ' Example: ju@05122003 (Juan, May 12, 2003)
        txtPass.Text = first2Letters & "@" & birthMonth & birthDay & birthYear
    End Sub

End Class