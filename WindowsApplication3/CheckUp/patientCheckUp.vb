Public Class patientCheckUp
    Public Property SelectedPatientID As Integer
    Public Property SelectedPatientName As String
    Public ParentFormRef As patientActions

    Public Sub LoadCheckup(checkupID As Integer)
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Dim sql As String = "SELECT * FROM tbl_checkup WHERE checkupID=?"

        Try
            Call dbConn()
            cmd = New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", checkupID)

            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ' Load checkup data
                lblPatientID.Text = dt.Rows(0)("patientID").ToString()
                txtRemarks.Text = dt.Rows(0)("remarks").ToString()
                dtpDate.Text = dt.Rows(0)("CheckupDate").ToString()

                txtODSP.Text = dt.Rows(0)("sphereOD").ToString()
                txtOSSP.Text = dt.Rows(0)("sphereOS").ToString()
                txtCYOD.Text = dt.Rows(0)("cylinderOD").ToString()
                txtCYOS.Text = dt.Rows(0)("cylinderOS").ToString()
                txtAXOD.Text = dt.Rows(0)("axisOD").ToString()
                txtAXOS.Text = dt.Rows(0)("axisOS").ToString()
                txtAddOD.Text = dt.Rows(0)("addOD").ToString()
                txtAddOS.Text = dt.Rows(0)("addOS").ToString()

                ' Load patient's name based on patientID
                Dim patientSql As String = "SELECT fullname FROM db_viewpatient WHERE patientID=?"
                Dim patientCmd As New Odbc.OdbcCommand(patientSql, conn)
                patientCmd.Parameters.AddWithValue("?", lblPatientID.Text)

                Dim patientReader As Odbc.OdbcDataReader = patientCmd.ExecuteReader()
                If patientReader.Read() Then
                    txtPName.Text = patientReader("fullname").ToString()
                Else
                    txtPName.Text = ""
                End If
                patientReader.Close()

                ' Load doctor's name based on DoctorID
                Dim doctorSql As String = "SELECT fullname FROM db_viewdoctors WHERE doctorID=?"
                Dim doctorCmd As New Odbc.OdbcCommand(doctorSql, conn)
                doctorCmd.Parameters.AddWithValue("?", dt.Rows(0)("DoctorID").ToString()) ' Assuming DoctorID is stored in tbl_checkup

                Dim doctorReader As Odbc.OdbcDataReader = doctorCmd.ExecuteReader()
                If doctorReader.Read() Then
                    txtDName.Text = doctorReader("fullname").ToString()
                    txtDName.Tag = dt.Rows(0)("DoctorID").ToString()
                Else
                    txtDName.Text = ""
                    txtDName.Tag = Nothing
                End If
                doctorReader.Close()



            Else
                ' Clear all fields if no record is found
                lblPatientID.Text = ""
                txtPName.Text = ""
                txtDName.Text = ""
                txtDName.Tag = Nothing
                txtRemarks.Text = ""
                dtpDate.Text = ""
                txtODSP.Text = ""
                txtOSSP.Text = ""
                txtCYOD.Text = ""
                txtCYOS.Text = ""
                txtAXOD.Text = ""
                txtAXOS.Text = ""
                txtAddOD.Text = ""
                txtAddOS.Text = ""
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
    Private Sub cleaner()
        For Each obj As Control In grpCheckUp.Controls
            If TypeOf obj Is TextBox Then
                CType(obj, TextBox).Text = ""
            ElseIf TypeOf obj Is ComboBox Then
                CType(obj, ComboBox).SelectedIndex = -1
            ElseIf TypeOf obj Is RichTextBox Then
                CType(obj, RichTextBox).Clear()
            ElseIf TypeOf obj Is DateTimePicker Then
                CType(obj, DateTimePicker).Value = Date.Today
            End If
        Next
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
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Check if doctor is selected
            If String.IsNullOrEmpty(txtDName.Text) Or txtDName.Tag Is Nothing Then
                MsgBox("Please search and select a doctor.", vbCritical, "Error")
                txtDName.Focus()
                Exit Sub
            End If

            ' Inside btnSave_Click, replace the individual field checks with:
            If String.IsNullOrWhiteSpace(txtODSP.Text) Then txtODSP.Text = "0"
            If String.IsNullOrWhiteSpace(txtOSSP.Text) Then txtOSSP.Text = "0"
            If String.IsNullOrWhiteSpace(txtCYOD.Text) Then txtCYOD.Text = "0"
            If String.IsNullOrWhiteSpace(txtCYOS.Text) Then txtCYOS.Text = "0"
            If String.IsNullOrWhiteSpace(txtAXOD.Text) Then txtAXOD.Text = "0"
            If String.IsNullOrWhiteSpace(txtAXOS.Text) Then txtAXOS.Text = "0"
            If String.IsNullOrWhiteSpace(txtAddOD.Text) Then txtAddOD.Text = "0"
            If String.IsNullOrWhiteSpace(txtAddOS.Text) Then txtAddOS.Text = "0"

            ' Get the selected doctor's ID
            Dim selectedDoctorID As String = txtDName.Tag.ToString()
            Dim checkupFee As Double = 300
            Dim transactionDate As Date = Date.Now
            Dim transactionID As Integer = 0

            ' Ensure remarks has a default value
            If String.IsNullOrWhiteSpace(txtRemarks.Text) Then txtRemarks.Text = "N/A"

            ' Open the transaction form for payment settlement FIRST
            ' Checkup will only be saved if payment is completed
            Try
                Dim transactionForm As New createTransactions()
                transactionForm.SelectedPatientID = selectedPatientID
                transactionForm.SelectedPatientName = txtPName.Text
                transactionForm.IsCheckupPayment = True
                
                ' Pass checkup data to transaction form
                transactionForm.CheckupRemarks = txtRemarks.Text
                transactionForm.CheckupDoctorID = selectedDoctorID
                transactionForm.CheckupSphereOD = txtODSP.Text
                transactionForm.CheckupSphereOS = txtOSSP.Text
                transactionForm.CheckupCylinderOD = txtCYOD.Text
                transactionForm.CheckupCylinderOS = txtCYOS.Text
                transactionForm.CheckupAxisOD = txtAXOD.Text
                transactionForm.CheckupAxisOS = txtAXOS.Text
                transactionForm.CheckupAddOD = txtAddOD.Text
                transactionForm.CheckupAddOS = txtAddOS.Text
                transactionForm.CheckupDate = dtpDate.Value
                
                ' Removed "Settle Checkup Payment" from title
                transactionForm.TopMost = True
                
                ' Show dialog and check if payment was completed
                Dim result As DialogResult = transactionForm.ShowDialog()
                
                ' Check if payment was completed successfully
                If result = DialogResult.OK Then
                    ' Payment and checkup were saved successfully by the transaction form
                    Try
                        modCheckUp.RefreshCheckUpDGV()
                    Catch
                    End Try

                    ' === Optional: Update checkup DataGridView ===
                    If ParentFormRef IsNot Nothing Then
                        ParentFormRef.ViewCheckup(selectedPatientID)
                    End If
                Else
                    ' Payment was canceled, so checkup was not saved - no message needed
                End If
            Catch ex As Exception
                MessageBox.Show("Error opening transaction form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
            
            Me.Close()

        Catch ex As Exception
            MsgBox("Error saving checkup: " & ex.Message, vbCritical, "Save Error")
        End Try
    End Sub



    Private Sub LoadDoctorNames()
        Try
            Call dbConn()
            Dim sql As String = "SELECT doctorID, FullName FROM db_viewdoctors"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            ' Just load the data, no need to populate any control since we're using search
            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox("Error loading doctor names: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Private Sub btnPSearch_Click(sender As Object, e As EventArgs) Handles btnPSearch.Click
        Try
            Call dbConn()

            Dim searchName As String = txtPName.Text.Trim()
            If String.IsNullOrEmpty(searchName) Then
                MessageBox.Show("Please enter a patient name to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPName.Focus()
                Return
            End If

            Dim query As String = _
                "SELECT patientID, " & _
                "CASE " & _
                " WHEN mname IS NULL OR mname = '' OR mname = 'N/A' THEN CONCAT(fname, ' ', lname) " & _
                " ELSE CONCAT(fname, ' ', mname, ' ', lname) " & _
                "END AS fullName " & _
                "FROM patient_data " & _
                "WHERE CONCAT(fname, ' ', IFNULL(mname, ''), ' ', lname) LIKE ? " & _
                "ORDER BY lname, fname LIMIT 1"

            Dim cmd As New Odbc.OdbcCommand(query, conn)
            cmd.Parameters.AddWithValue("?", "%" & searchName & "%")
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim fullName As String = reader("fullName").ToString()
                Dim patientID As Integer = Convert.ToInt32(reader("patientID"))
                txtPName.Text = fullName
                ' Update the selected patient ID
                SelectedPatientID = patientID
                SelectedPatientName = fullName
            Else
                MessageBox.Show("No patient found with that name.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            reader.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error searching for patient: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDSearch_Click(sender As Object, e As EventArgs) Handles btnDSearch.Click
        Try
            Call dbConn()

            Dim searchName As String = txtDName.Text.Trim()
            If String.IsNullOrEmpty(searchName) Then
                MessageBox.Show("Please enter a doctor name to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDName.Focus()
                Return
            End If

            Dim query As String = "SELECT doctorID, FullName FROM db_viewdoctors WHERE FullName LIKE ? ORDER BY FullName LIMIT 1"
            Dim cmd As New Odbc.OdbcCommand(query, conn)
            cmd.Parameters.AddWithValue("?", "%" & searchName & "%")
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim fullName As String = reader("FullName").ToString()
                Dim doctorID As String = reader("doctorID").ToString()
                txtDName.Text = fullName
                txtDName.Tag = doctorID
            Else
                MessageBox.Show("No doctor found with that name.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            reader.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error searching for doctor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub addCheckup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDoctorNames()
        SetupDoctorAutoComplete()
        lblPatientID.Text = SelectedPatientID.ToString()
        txtPName.Text = SelectedPatientName

        ' Default selection: Check-up Only
        ' Note: This form has no 'rbonly' control; check-up-only is enforced via isCheckUp=1 on save.

        ' Add Leave event handlers for all measurement textboxes
        AddHandler txtODSP.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtOSSP.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtCYOD.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtCYOS.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtAXOD.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtAXOS.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtAddOD.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtAddOS.Leave, AddressOf MeasurementTextBox_Leave

        If SelectedPatientID <> 0 Then
            LoadPatientName(SelectedPatientID)
        Else
            MessageBox.Show("Invalid Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Private doctorDict As New Dictionary(Of String, String)

    Private Sub SetupDoctorAutoComplete()
        Try
            Call dbConn()

            ' Load doctor names into dictionary
            Dim sql As String = "SELECT doctorID, FullName FROM db_viewdoctors ORDER BY FullName"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            doctorDict.Clear()
            Dim autoCompleteCollection As New AutoCompleteStringCollection()

            While reader.Read()
                Dim doctorID As String = reader("doctorID").ToString()
                Dim fullName As String = reader("FullName").ToString()
                doctorDict(doctorID) = fullName
                autoCompleteCollection.Add(fullName)
            End While

            reader.Close()
            conn.Close()

            ' Configure txtDName for autocomplete
            txtDName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtDName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtDName.AutoCompleteCustomSource = autoCompleteCollection

            ' Add TextChanged event to auto-select doctor ID when name matches
            AddHandler txtDName.TextChanged, AddressOf txtDName_TextChanged
        Catch ex As Exception
            ' Silently fail if autocomplete setup fails
        End Try
    End Sub

    Private Sub txtDName_TextChanged(sender As Object, e As EventArgs)
        Try
            ' Check if the entered text matches any doctor name exactly
            Dim enteredText As String = txtDName.Text.Trim()

            For Each kvp As KeyValuePair(Of String, String) In doctorDict
                If kvp.Value.Equals(enteredText, StringComparison.OrdinalIgnoreCase) Then
                    ' Set the doctor ID in the Tag
                    txtDName.Tag = kvp.Key
                    Exit For
                End If
            Next
        Catch ex As Exception
            ' Silently handle any errors
        End Try
    End Sub

    Private Sub MeasurementTextBox_Leave(sender As Object, e As EventArgs)
        Dim txt As TextBox = DirectCast(sender, TextBox)
        If String.IsNullOrWhiteSpace(txt.Text) Then
            txt.Text = "0"
        End If
    End Sub

    Private Sub GradeTextBox_Enter(sender As Object, e As EventArgs) Handles txtODSP.Enter, txtOSSP.Enter, txtCYOD.Enter, txtCYOS.Enter, txtAXOD.Enter, txtAXOS.Enter, txtAddOD.Enter, txtAddOS.Enter
        ' No auto-insert of "+"; allow user to type freely
    End Sub

    Private Sub GradeTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtODSP.KeyPress, txtOSSP.KeyPress, txtCYOD.KeyPress, txtCYOS.KeyPress, txtAXOD.KeyPress, txtAXOS.KeyPress, txtAddOD.KeyPress, txtAddOS.KeyPress
        Dim txt As TextBox = CType(sender, TextBox)
        Dim keyChar As Char = e.KeyChar

        ' Allow control keys
        If Char.IsControl(keyChar) Then
            Return
        End If

        ' Only allow digits, one dot, and one + or - at start
        If Not Char.IsDigit(keyChar) AndAlso keyChar <> "."c AndAlso keyChar <> "+"c AndAlso keyChar <> "-"c Then
            e.Handled = True
        End If

        ' Only one dot allowed
        If keyChar = "."c AndAlso txt.Text.Contains(".") Then
            e.Handled = True
            Return
        End If

        ' Only one + or - allowed and only at start
        If (keyChar = "+"c Or keyChar = "-"c) Then
            If txt.SelectionStart <> 0 Or txt.Text.Contains("+") Or txt.Text.Contains("-") Then
                e.Handled = True
                Return
            End If
        End If

        ' Limit max length to 6 characters
        If txt.Text.Length >= 6 AndAlso Not Char.IsControl(keyChar) Then
            e.Handled = True
            Return
        End If
    End Sub

    Private Sub GradeTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles txtODSP.KeyDown, txtOSSP.KeyDown, txtCYOD.KeyDown, txtCYOS.KeyDown, txtAXOD.KeyDown, txtAXOS.KeyDown, txtAddOD.KeyDown, txtAddOS.KeyDown
        ' Allow normal editing keys including Backspace at position 0
    End Sub

    Private Sub GradeTextBox_TextChanged(sender As Object, e As EventArgs) Handles txtODSP.TextChanged, txtOSSP.TextChanged, txtCYOD.TextChanged, txtCYOS.TextChanged, txtAXOD.TextChanged, txtAXOS.TextChanged, txtAddOD.TextChanged, txtAddOS.TextChanged
        Dim txt As TextBox = CType(sender, TextBox)

        ' Limit length and keep text as-is; no forced sign logic
        If txt.Text.Length > 6 Then
            Dim pos As Integer = txt.SelectionStart
            txt.Text = txt.Text.Substring(0, 6)
            txt.SelectionStart = Math.Min(pos, txt.Text.Length)
        End If
    End Sub


    Private Sub LoadPatientName(patientID As Integer)
        Try
            Call dbConn()


            Dim sql As String = "SELECT " & _
                    "CASE WHEN mname = 'N/A' THEN CONCAT(fname, ' ', lname) " & _
                    "ELSE CONCAT(fname, ' ', mname, ' ', lname) " & _
                    "END AS fullName " & _
                    "FROM patient_data WHERE patientID = ?"

            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.Add(New Odbc.OdbcParameter("?", Odbc.OdbcType.Int)).Value = patientID

            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                txtPName.Text = reader("fullName").ToString()
            Else
                MessageBox.Show("Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading patient name: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    ' Ensure Remarks defaults to "N/A" on validation if left blank.
    Private Sub TextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRemarks.Validating
        Dim textControl As Control = DirectCast(sender, Control)

        ' Skip validation if focus is moving to specific buttons
        If ActiveControl Is btnCancel OrElse ActiveControl Is btnClear Then
            Exit Sub
        End If

        ' Custom validation for specific TextBox fields
        Select Case textControl.Name
            Case "txtRemarks"
                If String.IsNullOrWhiteSpace(textControl.Text) Then
                    textControl.Text = "N/A"
                End If
        End Select
    End Sub

    Private Sub grpCheckUp_Enter(sender As Object, e As EventArgs) Handles grpCheckUp.Enter

    End Sub
End Class