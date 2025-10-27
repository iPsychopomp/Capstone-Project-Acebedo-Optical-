Public Class PatientNextAppointment
    Public selectedPatientID As Integer
    Public patientName As String
    Public Property latestCheckupID As Integer

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If cmbDoctors.SelectedItem Is Nothing Then
                MsgBox("Please select a doctor.", vbExclamation, "Missing Doctor")
                Exit Sub
            End If

            ' Check if patientType and patientName are available
            If String.IsNullOrEmpty(cmbPatientType.Text) Then
                MsgBox("Please select a patient type.", vbExclamation, "Missing Patient Type")
                Exit Sub
            End If

            If String.IsNullOrEmpty(lblPatientName.Text) Then
                MsgBox("Patient name is not available.", vbExclamation, "Missing Patient Name")
                Exit Sub
            End If

            ' Validate appointment date is in the future
            If dtpDate.Value.Date <= DateTime.Today Then
                MsgBox("Appointment date must be in the future. Please select a date after today.", vbExclamation, "Invalid Date")
                Exit Sub
            End If

            ' Validate that patient has a checkup record TODAY before scheduling next appointment
            If Not HasCheckupRecord(selectedPatientID) Then
                MsgBox("Cannot schedule next appointment. Patient must have a checkup TODAY first." & vbCrLf & vbCrLf & "Please create a checkup for this patient today before scheduling an appointment.", vbExclamation, "No Checkup Today")
                Exit Sub
            End If

            ' Validate that latestCheckupID is set
            If latestCheckupID <= 0 Then
                MsgBox("Invalid checkup reference. Please ensure the patient has a valid checkup record.", vbExclamation, "Invalid Checkup")
                Exit Sub
            End If

            ' Database connection
            Call dbConn()
            Dim selectedDoctor As KeyValuePair(Of String, String) = DirectCast(cmbDoctors.SelectedItem, KeyValuePair(Of String, String))
            Dim selectedDoctorID As String = selectedDoctor.Key
            Dim selectedDoctorName As String = selectedDoctor.Value

            ' Insert SQL with patientType and patientName
            Dim insertSql As String = "INSERT INTO tbl_appointments (patientID, doctorID, doctorName, patientName, patientType, appointmentDate, checkupID) " & _
                                      "VALUES (?, ?, ?, ?, ?, ?, ?)"

            Using insertCmd As New Odbc.OdbcCommand(insertSql, conn)
                insertCmd.Parameters.AddWithValue("?", selectedPatientID)
                insertCmd.Parameters.AddWithValue("?", selectedDoctorID)
                insertCmd.Parameters.AddWithValue("?", selectedDoctorName)
                insertCmd.Parameters.AddWithValue("?", lblPatientName.Text)
                insertCmd.Parameters.AddWithValue("?", cmbPatientType.Text)
                insertCmd.Parameters.AddWithValue("?", dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss"))
                insertCmd.Parameters.AddWithValue("?", latestCheckupID)
                insertCmd.ExecuteNonQuery()
            End Using

            ' Insert audit trail
            InsertAuditTrail("Insert", "Created appointment for patientID " & selectedPatientID & " with doctor " & selectedDoctorName, "tbl_appointments", selectedPatientID)

            ' Success message
            MsgBox("Appointment saved successfully.", vbInformation, "Success")
            conn.Close()
            Me.Close()

        Catch ex As Exception
            MsgBox("Error saving appointment: " & ex.Message, vbCritical, "Error")
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
            Call dbConn()

            Dim sql As String = "SELECT doctorID, FullName FROM db_viewdoctors ORDER BY FullName"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()
            cmbDoctors.Items.Clear()
            Dim doctorList As New List(Of KeyValuePair(Of String, String))

            While reader.Read()
                doctorList.Add(New KeyValuePair(Of String, String)(reader("doctorID").ToString(), reader("FullName").ToString()))
            End While
            cmbDoctors.DataSource = doctorList
            cmbDoctors.DisplayMember = "Value"
            cmbDoctors.ValueMember = "Key"

            If Not String.IsNullOrEmpty(doctorIDToSelect) Then
                For Each doctor As KeyValuePair(Of String, String) In doctorList
                    If doctor.Key = doctorIDToSelect Then
                        cmbDoctors.SelectedItem = doctor
                        Exit For
                    End If
                Next
            End If

            reader.Close()
            conn.Close()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub PatientsQueue_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadDoctorNames()

        ' Set minimum date to tomorrow (cannot select past dates or today)
        dtpDate.MinDate = DateTime.Today.AddDays(1)
        dtpDate.Value = DateTime.Today.AddDays(1)

        Try
            Call dbConn()

            Dim sql As String = "SELECT CASE WHEN mname = 'N/A' THEN CONCAT(fname, ' ', lname) ELSE CONCAT(fname, ' ', mname, ' ', lname) END AS fullName FROM patient_data WHERE patientID = ?"


            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", selectedPatientID)

                Using reader As Odbc.OdbcDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Set the patient's full name in the label
                        lblPatientName.Text = reader("fullName").ToString()
                    Else
                        MessageBox.Show("Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error fetching patient name: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Removed queue auto-add: appointments are saved to tbl_appointments only

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        ' Ensure the selected date is always in the future
        If dtpDate.Value.Date <= DateTime.Today Then
            dtpDate.Value = DateTime.Today.AddDays(1)
            MsgBox("Appointment date must be in the future. Date has been set to tomorrow.", vbInformation, "Date Adjusted")
        End If
    End Sub

    Private Function HasCheckupRecord(patientID As Integer) As Boolean
        Try
            Call dbConn()

            ' Check if patient has a checkup record TODAY
            Dim sql As String = "SELECT COUNT(*) FROM tbl_checkup WHERE patientID = ? AND DATE(checkupDate) = CURDATE()"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", patientID)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                conn.Close()
                Return count > 0
            End Using

        Catch ex As Exception
            MsgBox("Error checking checkup records: " & ex.Message, vbCritical, "Error")
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            Return False
        End Try
    End Function
End Class