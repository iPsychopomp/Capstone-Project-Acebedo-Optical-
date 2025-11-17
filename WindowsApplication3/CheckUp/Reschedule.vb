Public Class Reschedule
    Public selectedPatientID As Integer
    Public appointmentID As Integer
    Public ParentCheckUpForm As checkUp = Nothing

    Private Sub Reschedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set minimum date to tomorrow
        dtpDate.MinDate = DateTime.Today.AddDays(1)

        ' Load doctors first, then load appointment data
        LoadDoctorNames()
        LoadAppointmentData()

        pnlAppointment.TabIndex = 0
        cmbDoctors.TabIndex = 1
        cmbAppointmentType.TabIndex = 2
        dtpDate.TabIndex = 3
        txtReason.TabIndex = 4
        btnUpdate.TabIndex = 5
    End Sub

    Private Sub LoadDoctorNames()
        Try
            Call dbConn()

            Dim sql As String = "SELECT doctorID, FullName FROM db_viewdoctors ORDER BY FullName"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            Dim doctorList As New List(Of KeyValuePair(Of String, String))

            While reader.Read()
                doctorList.Add(New KeyValuePair(Of String, String)(reader("doctorID").ToString(), reader("FullName").ToString()))
            End While

            reader.Close()
            conn.Close()

            ' Bind to combobox
            cmbDoctors.DataSource = doctorList
            cmbDoctors.DisplayMember = "Value"
            cmbDoctors.ValueMember = "Key"

        Catch ex As Exception
            MessageBox.Show("Error loading doctors: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAppointmentData()
        Try
            Call dbConn()

            ' Get the latest appointment for this patient
            Dim sql As String = "SELECT a.appointmentID, a.doctorID, a.doctorName, a.patientName, a.AppointmentType, " & _
                               "a.appointmentDate, a.reason " & _
                               "FROM tbl_appointments a " & _
                               "WHERE a.patientID = ? " & _
                               "ORDER BY a.appointmentDate DESC LIMIT 1"

            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", selectedPatientID)
                Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    appointmentID = Convert.ToInt32(reader("appointmentID"))
                    lblPatientName.Text = reader("patientName").ToString()

                    ' Store values to set after reader is closed
                    Dim savedDoctorID As String = ""
                    Dim savedAppointmentType As String = ""
                    Dim savedAppointmentDate As DateTime = DateTime.Today.AddDays(1)
                    Dim savedReason As String = ""

                    ' Get appointment type
                    If Not IsDBNull(reader("AppointmentType")) Then
                        savedAppointmentType = reader("AppointmentType").ToString()
                    End If

                    ' Get doctor ID
                    If Not IsDBNull(reader("doctorID")) Then
                        savedDoctorID = reader("doctorID").ToString()
                    End If

                    ' Get appointment date
                    If Not IsDBNull(reader("appointmentDate")) Then
                        savedAppointmentDate = Convert.ToDateTime(reader("appointmentDate"))
                    End If

                    ' Get reason
                    If Not IsDBNull(reader("reason")) Then
                        savedReason = reader("reason").ToString()
                    End If

                    reader.Close()

                    ' Now set the values after reader is closed
                    ' Set appointment type
                    If Not String.IsNullOrEmpty(savedAppointmentType) Then
                        cmbAppointmentType.Text = savedAppointmentType
                    End If

                    ' Set doctor
                    If Not String.IsNullOrEmpty(savedDoctorID) AndAlso cmbDoctors.DataSource IsNot Nothing Then
                        Dim doctorList As List(Of KeyValuePair(Of String, String)) = DirectCast(cmbDoctors.DataSource, List(Of KeyValuePair(Of String, String)))
                        For i As Integer = 0 To doctorList.Count - 1
                            If doctorList(i).Key = savedDoctorID Then
                                cmbDoctors.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If

                    ' Set appointment date (only if it's in the future)
                    If savedAppointmentDate > DateTime.Today Then
                        dtpDate.Value = savedAppointmentDate
                    Else
                        dtpDate.Value = DateTime.Today.AddDays(1)
                    End If

                    ' Set reason
                    txtReason.Text = savedReason

                Else
                    MessageBox.Show("No appointment found for this patient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If

            End Using

            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading appointment data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If cmbDoctors.SelectedItem Is Nothing Then
                MsgBox("Please select a doctor.", vbExclamation, "Missing Doctor")
                Exit Sub
            End If

            If String.IsNullOrEmpty(cmbAppointmentType.Text) Then
                MsgBox("Please select an appointment type.", vbExclamation, "Missing Appointment Type")
                Exit Sub
            End If

            ' Validate appointment date is in the future
            If dtpDate.Value.Date <= DateTime.Today Then
                MsgBox("Appointment date must be in the future. Please select a date after today.", vbExclamation, "Invalid Date")
                Exit Sub
            End If

            ' Database connection
            Call dbConn()
            Dim selectedDoctor As KeyValuePair(Of String, String) = DirectCast(cmbDoctors.SelectedItem, KeyValuePair(Of String, String))
            Dim selectedDoctorID As String = selectedDoctor.Key
            Dim selectedDoctorName As String = selectedDoctor.Value

            ' Get reason text
            Dim reason As String = If(String.IsNullOrWhiteSpace(txtReason.Text), "", txtReason.Text.Trim())

            ' Update SQL
            Dim updateSql As String = "UPDATE tbl_appointments SET doctorID = ?, doctorName = ?, AppointmentType = ?, " & _
                                     "appointmentDate = ?, reason = ? WHERE appointmentID = ?"

            Using updateCmd As New Odbc.OdbcCommand(updateSql, conn)
                updateCmd.Parameters.AddWithValue("?", selectedDoctorID)
                updateCmd.Parameters.AddWithValue("?", selectedDoctorName)
                updateCmd.Parameters.AddWithValue("?", cmbAppointmentType.Text)
                updateCmd.Parameters.AddWithValue("?", dtpDate.Value.ToString("yyyy-MM-dd HH:mm:ss"))
                updateCmd.Parameters.AddWithValue("?", reason)
                updateCmd.Parameters.AddWithValue("?", appointmentID)
                updateCmd.ExecuteNonQuery()
            End Using

            ' Insert audit trail
            InsertAuditTrail("Update", "Rescheduled appointment for patientID " & selectedPatientID & " with doctor " & selectedDoctorName, "tbl_appointments", appointmentID)

            ' Success message
            MsgBox("Appointment updated successfully.", vbInformation, "Success")
            conn.Close()

            ' Refresh parent checkUp form if available
            If ParentCheckUpForm IsNot Nothing Then
                Try
                    ParentCheckUpForm.LoadPage()
                Catch ex As Exception
                    ' Ignore refresh errors
                End Try
            End If

            Me.Close()

        Catch ex As Exception
            MsgBox("Error updating appointment: " & ex.Message, vbCritical, "Error")
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

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        ' Ensure the selected date is always in the future
        If dtpDate.Value.Date <= DateTime.Today Then
            dtpDate.Value = DateTime.Today.AddDays(1)
            MsgBox("Appointment date must be in the future. Date has been set to tomorrow.", vbInformation, "Date Adjusted")
        End If
    End Sub

End Class