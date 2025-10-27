Imports System.ComponentModel

Public Class addDoctors

    Private IsEditMode As Boolean = False
    Private CurrentDoctorID As Integer = 0

    Private Sub addDoctors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Auto-fill middle name with N/A when the field is skipped/tabbed
        AddHandler txtMname.Validating, AddressOf TextBox_Validating
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Function checkData(ByVal gb As GroupBox) As Boolean
        For Each obj As Object In gb.Controls
            If TypeOf obj Is TextBox Then
                If Len(obj.text) = 0 Then
                    MsgBox("Please input data", vbCritical, "Save")
                    checkData = False
                    Exit Function
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cmd As Odbc.OdbcCommand
        Dim sql As String
        Dim doctorID As Integer

        ' Validate required fields and auto-fill optional ones before saving
        If Not ValidateRequiredFieldsAndAutofillOptional() Then
            Exit Sub
        End If

        If True Then
            If MsgBox("Do you want to save this record?", vbYesNo + vbQuestion, "Save") = vbYes Then
                Try
                    Call dbConn()

                    If Not IsEditMode Then
                        sql = "INSERT INTO tbl_doctor(fname, mname, lname, contactNumber, email, dateAdded) VALUES (?,?,?,?,?,?)"
                        cmd = New Odbc.OdbcCommand(sql, conn)
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtFirst.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtMname.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtLname.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", Trim(txtMobile.Text))
                        cmd.Parameters.AddWithValue("?", Trim(txtEmail.Text))
                        cmd.Parameters.AddWithValue("?", DateTime.Now)
                    Else
                        sql = "UPDATE tbl_doctor SET fname=?, mname=?, lname=?, contactNumber=?, email=?, dateAdded=? WHERE doctorID=?"
                        cmd = New Odbc.OdbcCommand(sql, conn)
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtFirst.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtMname.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtLname.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", Trim(txtMobile.Text))
                        cmd.Parameters.AddWithValue("?", Trim(txtEmail.Text))
                        cmd.Parameters.AddWithValue("?", DateTime.Now)
                        cmd.Parameters.AddWithValue("?", CurrentDoctorID)
                    End If

                    cmd.ExecuteNonQuery()
                    If Not IsEditMode Then
                        Dim lastIDCmd As New Odbc.OdbcCommand("SELECT LAST_INSERT_ID()", conn)
                        doctorID = Convert.ToInt32(lastIDCmd.ExecuteScalar())
                        CurrentDoctorID = doctorID
                        InsertAuditTrail("Insert", "Added new doctor named " & txtFirst.Text & " " & txtMname.Text & " " & txtLname.Text, "tbl_doctor", doctorID)
                    Else
                        doctorID = CurrentDoctorID
                        InsertAuditTrail("Update", "Updated doctor named " & txtFirst.Text & " " & txtMname.Text & " " & txtLname.Text, "tbl_doctor", doctorID)
                    End If

                    MsgBox("Saved Succesfully!", vbInformation, "Save")

                    ' Refresh the open doctors list, if present
                    For Each f As Form In Application.OpenForms
                        If TypeOf f Is doctors Then
                            Try
                                Dim listForm As doctors = CType(f, doctors)
                                listForm.LoadDoctors()
                                ' Select the newly added/updated doctor
                                Try
                                    For Each row As DataGridViewRow In listForm.doctorsDGV.Rows
                                        If Not row.IsNewRow Then
                                            Dim idObj As Object = row.Cells("Column1").Value
                                            If idObj IsNot Nothing AndAlso Convert.ToInt32(idObj) = doctorID Then
                                                row.Selected = True
                                                listForm.doctorsDGV.FirstDisplayedScrollingRowIndex = row.Index
                                                Exit For
                                            End If
                                        End If
                                    Next
                                Catch
                                End Try
                            Catch
                            End Try
                        End If
                    Next

                    cmd.Dispose()

                    ' Close the form automatically after successful save
                    Me.Close()

                Catch ex As Exception
                    MsgBox(ex.Message.ToString, vbCritical, "Save")
                Finally
                    GC.Collect()
                    conn.Close()
                    conn.Dispose()
                End Try
            End If
        End If
    End Sub

    Private Sub InsertAuditTrail(actionType As String, actionDetails As String, tableName As String, recordID As Integer)
        Try
            Dim auditSql As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, TableName, RecordID, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
            Dim auditCmd As New Odbc.OdbcCommand(auditSql, conn)

            auditCmd.Parameters.AddWithValue("?", LoggedInUserID)
            auditCmd.Parameters.AddWithValue("?", LoggedInUser)
            auditCmd.Parameters.AddWithValue("?", actionType)
            auditCmd.Parameters.AddWithValue("?", actionDetails)
            auditCmd.Parameters.AddWithValue("?", tableName)
            auditCmd.Parameters.AddWithValue("?", recordID)
            auditCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
            auditCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd"))

            auditCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Audit Trail Error: " & ex.Message, vbCritical, "Audit Error")
        End Try
    End Sub

    Private Function ValidateRequiredFieldsAndAutofillOptional() As Boolean
        Dim missing As New List(Of String)
        Dim firstInvalid As Control = Nothing

        Dim assignFirst As Action(Of Control) = Sub(c As Control)
                                                    If firstInvalid Is Nothing Then firstInvalid = c
                                                End Sub

        ' Required: First Name (*)
        If String.IsNullOrWhiteSpace(txtFirst.Text) Then
            missing.Add("First Name")
            assignFirst(txtFirst)
        End If

        ' Required: Last Name (*)
        If String.IsNullOrWhiteSpace(txtLname.Text) Then
            missing.Add("Last Name")
            assignFirst(txtLname)
        End If

        ' Required: Mobile Number (*) - must start with +63 and contain exactly 10 digits after +63 (total length 13)
        Dim mobile As String = If(txtMobile.Text, String.Empty).Trim()
        Dim digitsOnly As String = New String(mobile.Where(Function(ch) Char.IsDigit(ch)).ToArray())
        If mobile = String.Empty OrElse Not mobile.StartsWith("+63") OrElse digitsOnly.Length <> 12 Then
            missing.Add("Valid Mobile Number (+63XXXXXXXXXX)")
            assignFirst(txtMobile)
        End If

        ' Required: Email (*) - basic check
        Dim email As String = If(txtEmail.Text, String.Empty).Trim()
        If String.IsNullOrWhiteSpace(email) Then
            missing.Add("Email")
            assignFirst(txtEmail)
        Else
            If Not (email.Contains("@") AndAlso email.Contains(".")) Then
                missing.Add("Valid Email")
                assignFirst(txtEmail)
            End If
        End If

        ' Optional field(s): Middle Name -> set to N/A if blank
        If String.IsNullOrWhiteSpace(txtMname.Text) Then
            txtMname.Text = "N/A"
        End If

        If missing.Count > 0 Then
            MessageBox.Show("Please complete the required fields marked with (*):" & vbCrLf &
                            " - " & String.Join(vbCrLf & " - ", missing),
                            "Fill the Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If firstInvalid IsNot Nothing Then firstInvalid.Focus()
            Return False
        End If

        Return True
    End Function

    Public Sub LoadDoctorData(doctorID As Integer)
        Try
            Call dbConn()

            Dim sql As String = "SELECT * FROM tbl_doctor WHERE doctorID = ?"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", doctorID)

            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                txtFirst.Text = reader("fname").ToString()
                txtMname.Text = reader("mname").ToString()
                txtLname.Text = reader("lname").ToString()
                txtMobile.Text = reader("contactNumber").ToString()
                txtEmail.Text = reader("email").ToString()
            End If

            cmd.Dispose()
            reader.Close()
            conn.Close()
            conn.Dispose()

            doctors.doctorsDGV.Tag = doctorID

            btnSave.Text = "Update"
            IsEditMode = True
            CurrentDoctorID = doctorID

        Catch ex As Exception
            MsgBox("Error loading doctor data: " & ex.Message, vbCritical, "Load Doctor")
        End Try
    End Sub

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        ' Non-blocking: allow skipping email during navigation. Email is required and validated on save.
        ' If you want a gentle hint without blocking, you can wire an ErrorProvider here.
    End Sub

    Private Sub txtMobile_Enter(sender As Object, e As EventArgs) Handles txtMobile.Enter
        If String.IsNullOrWhiteSpace(txtMobile.Text) Then
            txtMobile.Text = "+63"
        End If
        ' Always place caret right after +63 and clear selection for easier typing
        If txtMobile.Text.StartsWith("+63") Then
            txtMobile.SelectionStart = 3
            txtMobile.SelectionLength = 0
        End If
    End Sub

    Private Sub txtMobile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMobile.KeyPress
        ' Keep caret after +63 even when +63 is highlighted
        If txtMobile.SelectionStart < 3 Then
            ' Block backspace/delete on the prefix
            If e.KeyChar = ChrW(Keys.Back) OrElse e.KeyChar = ChrW(Keys.Delete) Then
                e.Handled = True
                Return
            End If
            txtMobile.SelectionStart = 3
        End If

        ' Allow only digits (and control keys)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        ' Prevent typing beyond 13 characters (account for selected text)
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

    Private Sub TextBox_Validating(sender As Object, e As CancelEventArgs)
        Dim txt As TextBox = CType(sender, TextBox)
        ' Only apply to Middle Name textbox
        If txt.Name = "txtMname" AndAlso String.IsNullOrWhiteSpace(txt.Text) Then
            txt.Text = "N/A"
        End If
    End Sub

End Class