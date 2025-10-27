Module modAddCheckup

    ' This method loads PatientIDs into the ComboBox.
    Public Sub LoadPatientIDs(cmbPatientID As ComboBox)
        Try
            Call dbConn()
            Dim sql As String = "SELECT PatientID, FullName FROM db_viewpatient"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            Dim patientList As New List(Of KeyValuePair(Of String, String))()
            cmbPatientID.Items.Clear()

            ' Adding patient data to the comboBox.
            While reader.Read()
                patientList.Add(New KeyValuePair(Of String, String)(reader("PatientID").ToString(), reader("FullName").ToString()))
            End While

            cmbPatientID.DataSource = patientList
            cmbPatientID.DisplayMember = "Key" ' Show PatientID in ComboBox
            cmbPatientID.ValueMember = "Key"   ' Use PatientID as the value for the ComboBox

            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox("Error loading patient IDs: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    ' This method loads DoctorNames into the ComboBox.
    Public Sub LoadDoctorNames(cmbDoctorsName As ComboBox)
        Try
            Call dbConn()
            Dim sql As String = "SELECT doctorID, FullName FROM db_viewdoctors"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            Dim doctorDict As New Dictionary(Of String, String)
            cmbDoctorsName.Items.Clear()

            ' Adding doctor data to the comboBox.
            While reader.Read()
                doctorDict.Add(reader("doctorID").ToString(), reader("FullName").ToString())
            End While

            cmbDoctorsName.DataSource = New BindingSource(doctorDict, Nothing)
            cmbDoctorsName.DisplayMember = "Value"
            cmbDoctorsName.ValueMember = "Key"

            reader.Close()
            conn.Close()
        Catch ex As Exception
            MsgBox("Error loading doctor names: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    ' This method handles updating the patient name when PatientID is selected.
    Public Sub UpdatePatientName(cmbPatientID As ComboBox, txtPatientName As TextBox)
        If cmbPatientID.SelectedItem IsNot Nothing Then
            ' Retrieve the selected PatientID and FullName
            Dim selectedPatient As KeyValuePair(Of String, String) = DirectCast(cmbPatientID.SelectedItem, KeyValuePair(Of String, String))

            ' Update the Patient Name TextBox with the full name
            txtPatientName.Text = selectedPatient.Value
        End If
    End Sub

    ' This method handles saving the checkup data.
    Public Sub SaveCheckupData(cmbPatientID As ComboBox, cmbDoctorsName As ComboBox, txtRemarks As RichTextBox, txtODSP As TextBox, txtOSSP As TextBox, txtCYOD As TextBox, txtCYOS As TextBox, txtAXOD As TextBox, txtAXOS As TextBox, txtAddOD As TextBox, txtAddOS As TextBox, dtpDate As DateTimePicker)
        Try
            If cmbPatientID.SelectedItem Is Nothing Then
                MsgBox("Please select a valid patient.", vbCritical, "Error")
                Exit Sub
            End If

            If cmbDoctorsName.SelectedItem Is Nothing Then
                MsgBox("Please select a doctor.", vbCritical, "Error")
                Exit Sub
            End If

            Dim selectedPatientID As String = DirectCast(cmbPatientID.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim selectedDoctorID As String = DirectCast(cmbDoctorsName.SelectedItem, KeyValuePair(Of String, String)).Key

            Call dbConn()
            Dim sql As String = "INSERT INTO tbl_checkup (patientID, remarks, doctorID, sphereOD, sphereOS, cylinderOD, cylinderOS, axisOD, axisOS, addOD, addOS, checkupDate) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)

            cmd.Parameters.AddWithValue("?", selectedPatientID)
            cmd.Parameters.AddWithValue("?", txtRemarks.Text)
            cmd.Parameters.AddWithValue("?", selectedDoctorID)
            cmd.Parameters.AddWithValue("?", txtODSP.Text)
            cmd.Parameters.AddWithValue("?", txtOSSP.Text)
            cmd.Parameters.AddWithValue("?", txtCYOD.Text)
            cmd.Parameters.AddWithValue("?", txtCYOS.Text)
            cmd.Parameters.AddWithValue("?", txtAXOD.Text)
            cmd.Parameters.AddWithValue("?", txtAXOS.Text)
            cmd.Parameters.AddWithValue("?", txtAddOD.Text)
            cmd.Parameters.AddWithValue("?", txtAddOS.Text)
            cmd.Parameters.AddWithValue("?", dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss"))

            cmd.ExecuteNonQuery()

            ' Get the last inserted ID (if necessary, update based on your DB)
            Dim lastInsertedID As Integer = 0
            Dim getIDCmd As New Odbc.OdbcCommand("SELECT LAST_INSERT_ID()", conn)
            Dim result As Object = getIDCmd.ExecuteScalar()
            If result IsNot Nothing Then lastInsertedID = Convert.ToInt32(result)

            ' Insert into audit trail
            InsertAuditTrail("INSERT", "Added new checkup record for Patient ID " & selectedPatientID, "tbl_checkup", lastInsertedID)

            MsgBox("Checkup record saved successfully!", vbInformation, "Success")

            conn.Close()
        Catch ex As Exception
            MsgBox("Error saving checkup record: " & ex.Message, vbCritical, "Save Error")
        End Try
    End Sub

    ' This method logs actions to the audit trail.
    Public Sub InsertAuditTrail(actionType As String, actionDetails As String, tableName As String, recordID As Integer)
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

    ' This method clears the controls in a GroupBox.
    Public Sub ClearControls(grpCheckUp As GroupBox)
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

End Module
