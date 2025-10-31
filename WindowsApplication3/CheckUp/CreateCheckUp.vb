Public Class CreateCheckUp
    Dim patientDict As New Dictionary(Of String, Integer)

    Private doctorDict As New Dictionary(Of String, String)
    Public Property DataSaved As Boolean = False

    Private Sub LoadPatientNames()
        Try
            Call dbConn()

            Dim query As String = _
                "SELECT patientID, " & _
                "CASE " & _
                " WHEN mname IS NULL OR mname = '' OR mname = 'N/A' THEN CONCAT(fname, ' ', lname) " & _
                " ELSE CONCAT(fname, ' ', mname, ' ', lname) " & _
                "END AS fullName " & _
                "FROM patient_data " & _
                "ORDER BY lname, fname"

            Dim cmd As New Odbc.OdbcCommand(query, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            patientDict.Clear()

            While reader.Read()
                Dim name As String = reader("fullName").ToString()
                Dim id As Integer = Convert.ToInt32(reader("patientID"))
                patientDict(name) = id
            End While

            reader.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading patient names: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupPatientAutoComplete()
        Try
            ' Create autocomplete collection from patientDict
            Dim autoCompleteCollection As New AutoCompleteStringCollection()

            ' Add all patient names to the collection
            For Each patientName As String In patientDict.Keys
                autoCompleteCollection.Add(patientName)
            Next

            ' Configure txtPName for autocomplete
            txtPName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtPName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtPName.AutoCompleteCustomSource = autoCompleteCollection

            ' Add TextChanged event to auto-select patient ID when name matches
            AddHandler txtPName.TextChanged, AddressOf txtPName_TextChanged
        Catch ex As Exception
            ' Silently fail if autocomplete setup fails
        End Try
    End Sub

    Private Sub txtPName_TextChanged(sender As Object, e As EventArgs)
        Try
            ' Check if the entered text matches any patient name exactly
            Dim enteredText As String = txtPName.Text.Trim()

            If patientDict.ContainsKey(enteredText) Then
                ' Set the patient ID in the Tag
                txtPName.Tag = patientDict(enteredText)
            End If
        Catch ex As Exception
            ' Silently handle any errors
        End Try
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
            Return
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

    Private Sub GradeTextBox_TextChanged(sender As Object, e As EventArgs) Handles txtODSP.TextChanged, txtOSSP.TextChanged, txtCYOD.TextChanged, txtCYOS.TextChanged, txtAXOD.TextChanged, txtAXOS.TextChanged, txtAddOD.TextChanged, txtAddOS.TextChanged
        Dim txt As TextBox = CType(sender, TextBox)

        ' Limit length and keep text as-is; no forced sign logic
        If txt.Text.Length > 6 Then
            Dim pos As Integer = txt.SelectionStart
            txt.Text = txt.Text.Substring(0, 6)
            txt.SelectionStart = Math.Min(pos, txt.Text.Length)
        End If
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
                "WHERE (CASE " & _
                "  WHEN mname IS NULL OR mname = '' OR mname = 'N/A' THEN CONCAT(fname, ' ', lname) " & _
                "  ELSE CONCAT(fname, ' ', mname, ' ', lname) " & _
                "END) LIKE ? " & _
                "ORDER BY lname, fname LIMIT 1"

            Dim cmd As New Odbc.OdbcCommand(query, conn)
            cmd.Parameters.AddWithValue("?", "%" & searchName & "%")
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim fullName As String = reader("fullName").ToString()
                Dim patientID As Integer = Convert.ToInt32(reader("patientID"))
                txtPName.Text = fullName
                ' Store the patient ID for later use
                txtPName.Tag = patientID
            Else
                MessageBox.Show("No patient found with that name.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            reader.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error searching for patient: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateCheckUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPatientNames()
        SetupPatientAutoComplete()
        LoadDoctorNames()
        SetupDoctorAutoComplete()

        ' Ensure skipped fields default to 0 on leave
        AddHandler txtODSP.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtOSSP.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtCYOD.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtCYOS.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtAXOD.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtAXOS.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtAddOD.Leave, AddressOf MeasurementTextBox_Leave
        AddHandler txtAddOS.Leave, AddressOf MeasurementTextBox_Leave
    End Sub

    Private Sub SetupDoctorAutoComplete()
        Try
            ' Create autocomplete collection
            Dim autoCompleteCollection As New AutoCompleteStringCollection()

            ' Add all doctor names to the collection
            For Each doctorName As String In doctorDict.Values
                autoCompleteCollection.Add(doctorName)
            Next

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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' Check if patient is selected
            If String.IsNullOrEmpty(txtPName.Text) Or txtPName.Tag Is Nothing Then
                MsgBox("Please search and select a patient first.", vbCritical, "Error")
                txtPName.Focus()
                Exit Sub
            End If

            ' Check if doctor is selected
            If String.IsNullOrEmpty(txtDName.Text) Or txtDName.Tag Is Nothing Then
                MsgBox("Please search and select a doctor.", vbCritical, "Error")
                txtDName.Focus()
                Exit Sub
            End If

            ' Get the selected doctor's ID
            Dim selectedDoctorID As String = txtDName.Tag.ToString()
            Dim checkupFee As Double = 300
            Dim transactionDate As Date = Date.Now
            Dim transactionID As Integer = 0

            ' Call the dbConn function to establish the connection
            Call dbConn()

            ' Default empty measurement fields to 0 for robustness
            If String.IsNullOrWhiteSpace(txtODSP.Text) Then txtODSP.Text = "0"
            If String.IsNullOrWhiteSpace(txtOSSP.Text) Then txtOSSP.Text = "0"
            If String.IsNullOrWhiteSpace(txtCYOD.Text) Then txtCYOD.Text = "0"
            If String.IsNullOrWhiteSpace(txtCYOS.Text) Then txtCYOS.Text = "0"
            If String.IsNullOrWhiteSpace(txtAXOD.Text) Then txtAXOD.Text = "0"
            If String.IsNullOrWhiteSpace(txtAXOS.Text) Then txtAXOS.Text = "0"
            If String.IsNullOrWhiteSpace(txtAddOD.Text) Then txtAddOD.Text = "0"
            If String.IsNullOrWhiteSpace(txtAddOS.Text) Then txtAddOS.Text = "0"

            ' Ensure remarks has a default value
            If String.IsNullOrWhiteSpace(txtRemarks.Text) Then txtRemarks.Text = "N/A"

            conn.Close()

            ' Open the transaction form for payment settlement FIRST
            ' Checkup will only be saved if payment is completed
            Try
                Dim transactionForm As New createTransactions()
                transactionForm.SelectedPatientID = CInt(txtPName.Tag.ToString())
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

                'transactionForm.Text = "Settle Checkup Payment - " & txtPName.Text
                transactionForm.TopMost = True

                ' Show dialog and check if payment was completed
                Dim result As DialogResult = transactionForm.ShowDialog()

                ' Check if payment was completed successfully
                If result = DialogResult.OK Then
                    ' Payment and checkup were saved successfully by the transaction form
                    DataSaved = True
                    Try
                        modCheckUp.RefreshCheckUpDGV()
                    Catch
                    End Try
                Else
                    ' Payment was canceled, so checkup was not saved - no message needed
                End If
            Catch ex As Exception
                MessageBox.Show("Error opening transaction form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("Error saving checkup: " & ex.Message, vbCritical, "Save Error")
        End Try
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
    Private Sub LoadDoctorNames(Optional ByVal doctorIDToSelect As String = "")
        Try
            ' Open connection
            Call dbConn()

            ' Query to fetch doctor names and IDs
            Dim sql As String = "SELECT doctorID, FullName FROM db_viewdoctors ORDER BY FullName"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            ' Create a dictionary to hold the doctors
            doctorDict.Clear()

            While reader.Read()
                doctorDict.Add(reader("doctorID").ToString(), reader("FullName").ToString())
            End While

            ' If doctorIDToSelect is provided, set the selected doctor
            If Not String.IsNullOrEmpty(doctorIDToSelect) Then
                If doctorDict.ContainsKey(doctorIDToSelect) Then
                    txtDName.Text = doctorDict(doctorIDToSelect)
                    txtDName.Tag = doctorIDToSelect
                End If
            End If

            reader.Close()
            conn.Close()

        Catch ex As Exception

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

    Private Sub SetComboValue(comboBox As ComboBox, displayValue As String)
        If String.IsNullOrEmpty(displayValue) Then
            comboBox.SelectedIndex = -1
            Return
        End If

        ' Try to find by display value first
        For i As Integer = 0 To comboBox.Items.Count - 1
            comboBox.SelectedIndex = i
            If comboBox.Text = displayValue Then
                Return
            End If
        Next

        ' If not found by display value, try by value
        For i As Integer = 0 To comboBox.Items.Count - 1
            Dim item As KeyValuePair(Of String, String) = DirectCast(comboBox.Items(i), KeyValuePair(Of String, String))
            If item.Key = displayValue Then
                comboBox.SelectedIndex = i
                Return
            End If
        Next

        ' If still not found, clear selection
        comboBox.SelectedIndex = -1
    End Sub


    'Private Sub SelectDoctorById(doctorID As String)
    '    ' First try the standard approach
    '    cmbDoctorsName.SelectedValue = doctorID

    '    ' If that didn't work, try manual selection
    '    If cmbDoctorsName.SelectedIndex = -1 Then
    '        For i As Integer = 0 To cmbDoctorsName.Items.Count - 1
    '            Dim row As DataRowView = DirectCast(cmbDoctorsName.Items(i), DataRowView)
    '            If row("doctorID").ToString() = doctorID Then
    '                cmbDoctorsName.SelectedIndex = i
    '                Exit For
    '            End If
    '        Next
    '    End If

    '    ' Final verification
    '    If cmbDoctorsName.SelectedIndex = -1 Then
    '        Debug.WriteLine("Failed to select doctor with ID: " & doctorID)
    '    Else
    '        Debug.WriteLine("Successfully selected doctor: " & cmbDoctorsName.Text)
    '    End If
    'End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            ' Clear all inputs inside the group container
            For Each obj As Control In grpCheckUp.Controls
                If TypeOf obj Is TextBox Then
                    CType(obj, TextBox).Clear()
                ElseIf TypeOf obj Is ComboBox Then
                    Dim cb As ComboBox = CType(obj, ComboBox)
                    cb.SelectedIndex = -1
                    cb.Text = String.Empty
                ElseIf TypeOf obj Is RichTextBox Then
                    CType(obj, RichTextBox).Clear()
                ElseIf TypeOf obj Is DateTimePicker Then
                    CType(obj, DateTimePicker).Value = DateTime.Now
                End If
            Next
        Catch ex As Exception
            MsgBox("Failed to clear fields: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

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
                ' Load all checkup data first
                txtPName.Text = dt.Rows(0)("patientID").ToString()
                txtRemarks.Text = dt.Rows(0)("remarks").ToString()
                dtpDate.Text = dt.Rows(0)("CheckupDate").ToString()


                ' Load vision data
                txtODSP.Text = dt.Rows(0)("sphereOD").ToString()
                txtOSSP.Text = dt.Rows(0)("sphereOS").ToString()
                txtCYOD.Text = dt.Rows(0)("cylinderOD").ToString()
                txtCYOS.Text = dt.Rows(0)("cylinderOS").ToString()
                txtAXOD.Text = dt.Rows(0)("axisOD").ToString()
                txtAXOS.Text = dt.Rows(0)("axisOS").ToString()
                txtAddOD.Text = dt.Rows(0)("addOD").ToString()
                txtAddOS.Text = dt.Rows(0)("addOS").ToString()

                ' Load patient name
                Dim patientID As String = dt.Rows(0)("patientID").ToString()
                Dim patientSql As String = "SELECT fullname FROM db_viewpatient WHERE patientID=?"
                Dim patientCmd As New Odbc.OdbcCommand(patientSql, conn)
                patientCmd.Parameters.AddWithValue("?", patientID)

                Dim patientReader As Odbc.OdbcDataReader = patientCmd.ExecuteReader()
                If patientReader.Read() Then
                    Dim fullName As String = patientReader("fullname").ToString()
                    txtPName.Text = fullName
                    txtPName.Tag = patientID
                Else
                    txtPName.Text = ""
                    txtPName.Tag = Nothing
                End If
                patientReader.Close()

                ' Load and select the doctor
                Dim doctorID As String = dt.Rows(0)("doctorID").ToString()
                LoadDoctorNames(doctorID) ' This passes the doctorID to select

            Else
                ' Clear all fields if no record found
                ClearFormFields()
                MsgBox("No record found.", MsgBoxStyle.Information, "Record Not Found")
            End If

        Catch ex As Exception
            MsgBox("Error loading checkup: " & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub ClearFormFields()
        txtPName.Text = ""
        txtPName.Tag = Nothing
        txtDName.Text = ""
        txtDName.Tag = Nothing
        txtRemarks.Text = ""
        dtpDate.Value = DateTime.Now
        txtODSP.Text = ""
        txtOSSP.Text = ""
        txtCYOD.Text = ""
        txtCYOS.Text = ""
        txtAXOD.Text = ""
        txtAXOS.Text = ""
        txtAddOD.Text = ""
        txtAddOS.Text = ""
    End Sub



    Private Sub dtpAppointment_ValueChanged(sender As Object, e As EventArgs)

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
End Class