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

    Private Sub GradeTextBox_Leave(sender As Object, e As EventArgs) Handles txtODSP.Leave, txtOSSP.Leave, txtCYOD.Leave, txtCYOS.Leave, txtAXOD.Leave, txtAXOS.Leave, txtAddOD.Leave, txtAddOS.Leave
        Dim txt As TextBox = CType(sender, TextBox)

        ' Skip validation if empty or just a sign
        If String.IsNullOrWhiteSpace(txt.Text) OrElse txt.Text = "+" OrElse txt.Text = "-" Then
            txt.Text = "0"
            Return
        End If

        ' Try to parse the value
        Dim value As Decimal
        If Decimal.TryParse(txt.Text, value) Then
            ' Check if value is within range -50 to +50
            If value < -50 Then
                MessageBox.Show("Value cannot be less than -50. Setting to -50.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt.Text = "-50"
            ElseIf value > 50 Then
                MessageBox.Show("Value cannot be greater than +50. Setting to +50.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt.Text = "50"
            End If
        Else
            ' Invalid format, reset to 0
            MessageBox.Show("Invalid number format. Setting to 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txt.Text = "0"
        End If
    End Sub

    Private Sub btnPSearch_Click(sender As Object, e As EventArgs) Handles btnPSearch.Click
        Using chooseP As New searchPatient
            chooseP.ShowDialog()
        End Using
    End Sub

    Private Sub CreateCheckUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPatientNames()
        SetupPatientAutoComplete()
        LoadDoctorNames()


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
            If String.IsNullOrEmpty(cmbDoctors.Text) Or cmbDoctors.Tag Is Nothing Then
                MsgBox("Please search and select a doctor.", vbCritical, "Error")
                cmbDoctors.Focus()
                Exit Sub
            End If

            ' Get the selected doctor's ID
            Dim selectedDoctorID As String = cmbDoctors.Tag.ToString()
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

            ' Insert checkup directly (no transaction form)
            Try
                Dim insertSql As String = _
                    "INSERT INTO tbl_checkup (patientID, doctorID, remarks, CheckupDate, sphereOD, sphereOS, cylinderOD, cylinderOS, axisOD, axisOS, addOD, addOS) " & _
                    "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"

                Using cmd As New Odbc.OdbcCommand(insertSql, conn)
                    cmd.Parameters.AddWithValue("?", CInt(txtPName.Tag.ToString()))
                    cmd.Parameters.AddWithValue("?", selectedDoctorID)
                    cmd.Parameters.AddWithValue("?", txtRemarks.Text)
                    cmd.Parameters.AddWithValue("?", Date.Now.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("?", txtODSP.Text)
                    cmd.Parameters.AddWithValue("?", txtOSSP.Text)
                    cmd.Parameters.AddWithValue("?", txtCYOD.Text)
                    cmd.Parameters.AddWithValue("?", txtCYOS.Text)
                    cmd.Parameters.AddWithValue("?", txtAXOD.Text)
                    cmd.Parameters.AddWithValue("?", txtAXOS.Text)
                    cmd.Parameters.AddWithValue("?", txtAddOD.Text)
                    cmd.Parameters.AddWithValue("?", txtAddOS.Text)
                    cmd.ExecuteNonQuery()
                End Using

                DataSaved = True
                Try
                    modCheckUp.RefreshCheckUpDGV()
                Catch
                End Try
            Catch ex As Exception
                MsgBox("Error saving checkup: " & ex.Message, vbCritical, "Save Error")
            Finally
                Try
                    If conn IsNot Nothing Then
                        conn.Close()
                    End If
                Catch
                End Try
            End Try

            If DataSaved Then
                MessageBox.Show("The check-up record has been saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
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

            ' Fetch doctor names and concatenate safely (omit empty or N/A middle names)
            Dim sql As String = "SELECT doctorID, TRIM(CONCAT(fname, ' ', CASE WHEN mname IS NULL OR mname = '' OR mname = 'N/A' THEN '' ELSE CONCAT(mname, ' ') END, lname)) AS FullName FROM tbl_doctor ORDER BY lname, fname"

            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            ' Build list and dictionary
            Dim items As New List(Of KeyValuePair(Of String, String))()
            doctorDict.Clear()

            While reader.Read()
                Dim id As String = reader("doctorID").ToString()
                Dim name As String = reader("FullName").ToString()
                doctorDict(id) = name
                items.Add(New KeyValuePair(Of String, String)(id, name))
            End While

            reader.Close()
            conn.Close()

            ' Insert default placeholder at the top
            items.Insert(0, New KeyValuePair(Of String, String)(String.Empty, "--Select Doctor--"))

            ' Bind to combobox
            cmbDoctors.DisplayMember = "Value"
            cmbDoctors.ValueMember = "Key"
            cmbDoctors.DataSource = items

            ' Preselect if provided
            If Not String.IsNullOrEmpty(doctorIDToSelect) Then
                cmbDoctors.SelectedValue = doctorIDToSelect
                cmbDoctors.Tag = doctorIDToSelect
            Else
                ' Default to placeholder
                If items.Count > 0 Then
                    cmbDoctors.SelectedIndex = 0
                    cmbDoctors.Tag = Nothing
                End If
            End If

        Catch ex As Exception
            ' swallow
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
            ' Clear patient name and doctor name textboxes
            txtPName.Text = ""
            txtPName.Tag = Nothing
            cmbDoctors.Text = ""
            cmbDoctors.Tag = Nothing

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

            ' Clear PD fields
            pdOD.Text = "0"
            pdOS.Text = "0"
            pdOU.Text = "0"

            ' Reset date to today
            'dtpDate.Value = DateTime.Now
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
                'dtpDate.Text = dt.Rows(0)("CheckupDate").ToString()


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
        cmbDoctors.Text = ""
        cmbDoctors.Tag = Nothing
        txtRemarks.Text = ""
        'dtpDate.Value = DateTime.Now
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

    ' Auto-fill PD textboxes with "0" if left empty
    Private Sub pdOD_Leave(sender As Object, e As EventArgs) Handles pdOD.Leave
        If String.IsNullOrWhiteSpace(pdOD.Text) Then
            pdOD.Text = "0"
        End If
    End Sub

    Private Sub pdOS_Leave(sender As Object, e As EventArgs) Handles pdOS.Leave
        If String.IsNullOrWhiteSpace(pdOS.Text) Then
            pdOS.Text = "0"
        End If
    End Sub

    Private Sub pdOU_Leave(sender As Object, e As EventArgs) Handles pdOU.Leave
        If String.IsNullOrWhiteSpace(pdOU.Text) Then
            pdOU.Text = "0"
        End If
    End Sub

    Private Sub cmbDoctors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDoctors.SelectedIndexChanged
        Try
            If cmbDoctors.DataSource IsNot Nothing AndAlso cmbDoctors.SelectedIndex >= 0 Then
                cmbDoctors.Tag = cmbDoctors.SelectedValue
            End If
        Catch
        End Try
    End Sub
End Class