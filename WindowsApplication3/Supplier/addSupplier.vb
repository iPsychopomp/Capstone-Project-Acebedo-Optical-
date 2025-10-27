Public Class addSupplier

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate required fields (those with *) and auto-fill optional ones with N/A
        If Not ValidateRequiredFieldsAndAutofillOptional() Then Exit Sub
        If MsgBox("Do you want to save this record?", vbYesNo + vbQuestion, "Save") <> vbYes Then Exit Sub

        Try
            Call dbConn()
            Using cmd As New Odbc.OdbcCommand()
                cmd.Connection = conn

                If Len(pnlAddUser.Tag) = 0 Then
                    ' INSERT new supplier
                    cmd.CommandText = "INSERT INTO tbl_suppliers (supplierName, contactPerson, contactNumber, address, email, dateAdded) " &
                                      "VALUES (?, ?, ?, ?, ?, ?)"
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtSupplierName.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtContactPerson.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", Trim(txtContactNumber.Text))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtAddress.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", Trim(txtEmail.Text))
                    cmd.Parameters.AddWithValue("?", Format(CDate(dtpDate.Value), "yyyy-MM-dd"))

                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Supplier successfully added.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InsertAuditTrail(GlobalVariables.LoggedInUserID, "Add Supplier", "Added supplier: " & txtSupplierName.Text)

                Else
                    ' UPDATE existing supplier
                    cmd.CommandText = "UPDATE tbl_suppliers SET supplierName=?, contactPerson=?, contactNumber=?, address=?, email=?, dateAdded=? " &
                                      "WHERE supplierID=?"
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtSupplierName.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtContactPerson.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", Trim(txtContactNumber.Text))
                    cmd.Parameters.AddWithValue("?", StrConv(Trim(txtAddress.Text), VbStrConv.ProperCase))
                    cmd.Parameters.AddWithValue("?", Trim(txtEmail.Text))
                    cmd.Parameters.AddWithValue("?", Format(CDate(dtpDate.Value), "yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("?", pnlAddUser.Tag)

                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Supplier information updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    InsertAuditTrail(GlobalVariables.LoggedInUserID, "Update Supplier", "Updated supplier: " & txtSupplierName.Text)
                End If
            End Using
            Call LoadDGV("SELECT * FROM tbl_suppliers", Supplier.SupplierDGV)

        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        Me.Close()
        Cleaner()
    End Sub

    Private Sub cleaner()
        For Each ctrl As Control In pnlAddUser.Controls
            If TypeOf ctrl Is GroupBox Then
                For Each obj As Control In ctrl.Controls
                    'PANG CLEAR NANG TEXT BOX SA LOOB NANG GRPBOX
                    If TypeOf obj Is TextBox Then
                        Dim txt As TextBox = CType(obj, TextBox)
                        txt.Text = ""

                    End If
                Next
            End If
        Next
    End Sub

    Private Function ValidateRequiredFieldsAndAutofillOptional() As Boolean
        Dim missing As New List(Of String)
        Dim firstInvalid As Control = Nothing

        Dim assignFirst As Action(Of Control) = Sub(c As Control)
                                                    If firstInvalid Is Nothing Then firstInvalid = c
                                                End Sub

        ' Required fields (with *)
        If String.IsNullOrWhiteSpace(txtSupplierName.Text) Then
            missing.Add("Supplier Name")
            assignFirst(txtSupplierName)
        End If
        If String.IsNullOrWhiteSpace(txtContactPerson.Text) Then
            missing.Add("Contact Person")
            assignFirst(txtContactPerson)
        End If
        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            missing.Add("Address")
            assignFirst(txtAddress)
        End If
        ' Contact Number: must start with +63 and contain exactly 10 digits after +63 (total 13 incl +)
        Dim contact As String = If(txtContactNumber.Text, String.Empty).Trim()
        Dim digitsOnlyCN As String = New String(contact.Where(Function(ch) Char.IsDigit(ch)).ToArray())
        If contact = String.Empty OrElse Not contact.StartsWith("+63") OrElse digitsOnlyCN.Length <> 12 Then
            missing.Add("Valid Contact Number (+63XXXXXXXXXX)")
            assignFirst(txtContactNumber)
        End If

        ' Email minimal validation
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

        ' Auto-fill optional text boxes (without *) with N/A when left blank
        Dim requiredSet As New HashSet(Of Control) From {txtSupplierName, txtContactPerson, txtContactNumber, txtAddress, txtEmail}
        For Each ctrl As Control In grpAddUser.Controls
            If TypeOf ctrl Is TextBox AndAlso Not requiredSet.Contains(ctrl) Then
                Dim tb As TextBox = CType(ctrl, TextBox)
                If String.IsNullOrWhiteSpace(tb.Text) Then tb.Text = "N/A"
            End If
        Next

        If missing.Count > 0 Then
            MessageBox.Show("Please complete the required fields marked with (*):" & vbCrLf &
                            " - " & String.Join(vbCrLf & " - ", missing),
                            "Fill the Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If firstInvalid IsNot Nothing Then firstInvalid.Focus()
            Return False
        End If

        Return True
    End Function
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call cleaner()

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
    Public Sub loadRecord(ByVal supplierID As Integer)
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Dim sql As String = "SELECT * FROM tbl_suppliers WHERE supplierID=?"

        Try
            Call dbConn()

            cmd = New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", supplierID)

            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                txtSupplierName.Text = dt.Rows(0)("supplierName").ToString()
                txtContactPerson.Text = dt.Rows(0)("contactPerson").ToString()
                txtContactNumber.Text = dt.Rows(0)("contactNumber").ToString()
                txtAddress.Text = dt.Rows(0)("address").ToString()
                txtEmail.Text = dt.Rows(0)("email").ToString()
                dtpDate.Text = dt.Rows(0)("dateAdded").ToString()
            Else
                txtSupplierName.Text = ""
                txtContactPerson.Text = ""
                txtContactNumber.Text = ""
                txtAddress.Text = ""
                txtEmail.Text = ""
                dtpDate.Text = ""
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

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        ' Non-blocking: allow skipping email during navigation. Email is required and validated on save.
        ' If desired, you can set a non-blocking hint via an ErrorProvider here.
    End Sub

    Private Sub txtContactNumber_Enter(sender As Object, e As EventArgs) Handles txtContactNumber.Enter
        If String.IsNullOrWhiteSpace(txtContactNumber.Text) Then
            txtContactNumber.Text = "+63"
        End If
        If txtContactNumber.Text.StartsWith("+63") Then
            txtContactNumber.SelectionStart = 3
            txtContactNumber.SelectionLength = 0
        End If
    End Sub

    Private Sub txtContactNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactNumber.KeyPress
        ' Keep caret after +63 and protect prefix
        If txtContactNumber.SelectionStart < 3 Then
            If e.KeyChar = ChrW(Keys.Back) OrElse e.KeyChar = ChrW(Keys.Delete) Then
                e.Handled = True
                Return
            End If
            txtContactNumber.SelectionStart = 3
        End If

        ' Allow only digits and control keys
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        ' Prevent typing beyond 13 characters (account for selected text)
        If Not Char.IsControl(e.KeyChar) Then
            Dim remaining As Integer = 13 - (txtContactNumber.TextLength - txtContactNumber.SelectionLength)
            If remaining <= 0 Then
                e.Handled = True
                Return
            End If
        End If
    End Sub

    Private Sub txtContactNumber_TextChanged(sender As Object, e As EventArgs) Handles txtContactNumber.TextChanged
        ' Always enforce +63 at the start
        If Not txtContactNumber.Text.StartsWith("+63") Then
            txtContactNumber.Text = "+63"
            txtContactNumber.SelectionStart = txtContactNumber.Text.Length
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class