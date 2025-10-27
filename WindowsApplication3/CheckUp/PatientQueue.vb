'Public Class PatientQueue
'    Public SelectedPatientID As Integer

'    Private Sub PatientQueue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        Call dbConn()



'        ' Modified query to only check if patient exists in patient_data
'        Dim sql As String = "SELECT CASE WHEN pd.mname = 'N/A' THEN CONCAT(pd.fname, ' ', pd.lname) ELSE CONCAT(pd.fname, ' ', pd.mname, ' ', pd.lname) END AS patientName " & _
'                    "FROM patient_data pd " & _
'                    "WHERE pd.patientID = ?"


'        Using cmd As New Odbc.OdbcCommand(sql, conn)
'            cmd.Parameters.AddWithValue("?", SelectedPatientID)

'            Try
'                Using reader As Odbc.OdbcDataReader = cmd.ExecuteReader()
'                    If reader.Read() Then
'                        ' Display data
'                        lblPatientID.Text = SelectedPatientID.ToString()
'                        lblPatientName.Text = reader("patientName").ToString()
'                    Else
'                        MessageBox.Show("Patient not found for ID: " & SelectedPatientID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                        Me.Close()
'                    End If
'                End Using
'            Catch ex As Exception
'                MessageBox.Show("Error executing query: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'            End Try
'        End Using

'        conn.Close()
'    End Sub
'    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
'        Try
'            ' Validate patient type is selected
'            If String.IsNullOrWhiteSpace(cmbPatientType.Text) Then
'                MessageBox.Show("Please select a patient type before saving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                cmbPatientType.Focus()
'                Return
'            End If

'            Call dbConn()

'            Dim patientID As Integer = SelectedPatientID
'            Dim patientName As String = lblPatientName.Text.Trim()
'            Dim patientType As String = cmbPatientType.Text.Trim()
'            Dim today As String = DateTime.Now.ToString("yyyy-MM-dd")
'            Dim now As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

'            ' 1. Check if patient already in queue today
'            Dim checkSql As String = "SELECT COUNT(*) FROM tbl_queue WHERE patientID = ? AND queueDate = ?"
'            Using cmd As New Odbc.OdbcCommand(checkSql, conn)
'                cmd.Parameters.AddWithValue("?", patientID)
'                cmd.Parameters.AddWithValue("?", today)
'                If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
'                    MessageBox.Show("Patient is already in the queue today.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                    Exit Sub
'                End If
'            End Using

'            ' 2. Check if patient has appointment today
'            Dim hasAppointment As Boolean = False
'            Dim apptSql As String = "SELECT COUNT(*) FROM tbl_appointments WHERE patientID = ? AND DATE(appointmentDate) = ?"
'            Using cmd As New Odbc.OdbcCommand(apptSql, conn)
'                cmd.Parameters.AddWithValue("?", patientID)
'                cmd.Parameters.AddWithValue("?", today)
'                hasAppointment = Convert.ToInt32(cmd.ExecuteScalar()) > 0
'            End Using

'            ' 3. Determine group priority
'            Dim groupPriority As Integer
'            If patientType = "PWD" OrElse patientType = "Senior Citizen" Then
'                groupPriority = 1
'            ElseIf hasAppointment Then
'                groupPriority = 2
'            Else
'                groupPriority = 3
'            End If

'            ' 4. Count existing in same group
'            Dim countSql As String = "SELECT COUNT(*) FROM tbl_queue WHERE queueDate = ? AND ((? = 1 AND (patientType = 'PWD' OR patientType = 'Senior Citizen')) OR (? = 2 AND patientID IN (SELECT patientID FROM tbl_appointments WHERE DATE(appointmentDate) = ?) AND patientType NOT IN ('PWD', 'Senior Citizen')) OR (? = 3 AND patientID NOT IN (SELECT patientID FROM tbl_appointments WHERE DATE(appointmentDate) = ?) AND patientType NOT IN ('PWD', 'Senior Citizen')))"
'            Dim positionInGroup As Integer = 1
'            Using cmd As New Odbc.OdbcCommand(countSql, conn)
'                cmd.Parameters.AddWithValue("?", today)
'                cmd.Parameters.AddWithValue("?", groupPriority)
'                cmd.Parameters.AddWithValue("?", groupPriority)
'                cmd.Parameters.AddWithValue("?", today)
'                cmd.Parameters.AddWithValue("?", groupPriority)
'                cmd.Parameters.AddWithValue("?", today)
'                positionInGroup += Convert.ToInt32(cmd.ExecuteScalar())
'            End Using

'            Dim insertSql As String = "INSERT INTO tbl_queue (patientID, patientName, patientType, queueDate, queuePosition, createdAt, visitType) VALUES (?, ?, ?, ?, ?, ?, ?)"
'            ' Insert patient with queuePosition = 0 (temporary)
'            Using insertCmd As New Odbc.OdbcCommand(insertSql, conn)
'                insertCmd.Parameters.AddWithValue("?", patientID)
'                insertCmd.Parameters.AddWithValue("?", patientName)
'                insertCmd.Parameters.AddWithValue("?", patientType)
'                insertCmd.Parameters.AddWithValue("?", today)
'                insertCmd.Parameters.AddWithValue("?", 0) ' Temporary
'                insertCmd.Parameters.AddWithValue("?", now)
'                insertCmd.Parameters.AddWithValue("?", "Walk-in")
'                insertCmd.ExecuteNonQuery()
'            End Using

'            ' Get the inserted row's ID (if needed, assuming you have an auto-increment ID)
'            Dim lastInsertedID As Integer = 0
'            Using cmdLastID As New Odbc.OdbcCommand("SELECT MAX(queueID) FROM tbl_queue WHERE patientID = ? AND queueDate = ?", conn)
'                cmdLastID.Parameters.AddWithValue("?", patientID)
'                cmdLastID.Parameters.AddWithValue("?", today)
'                lastInsertedID = Convert.ToInt32(cmdLastID.ExecuteScalar())
'            End Using

'            ' Update the inserted patient's queuePosition to positionInGroup
'            Dim updatePositionSql As String = "UPDATE tbl_queue SET queuePosition = ? WHERE queueID = ?"
'            Using updateCmd As New Odbc.OdbcCommand(updatePositionSql, conn)
'                updateCmd.Parameters.AddWithValue("?", positionInGroup)
'                updateCmd.Parameters.AddWithValue("?", lastInsertedID)
'                updateCmd.ExecuteNonQuery()
'            End Using


'            ' 6. Adjust regular queue positions if higher priority
'            If groupPriority = 1 OrElse groupPriority = 2 Then
'                Dim updateSql As String = "UPDATE tbl_queue SET queuePosition = queuePosition + 1 WHERE queueDate = ? AND patientType = 'Regular' AND queuePosition >= ?"
'                Using cmd As New Odbc.OdbcCommand(updateSql, conn)
'                    cmd.Parameters.AddWithValue("?", today)
'                    cmd.Parameters.AddWithValue("?", positionInGroup)
'                    cmd.ExecuteNonQuery()
'                End Using
'            End If

'            MessageBox.Show("Patient added to queue successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            conn.Close()
'            Me.Close()

'        Catch ex As Exception
'            MessageBox.Show("Error adding patient to queue: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End Try
'    End Sub


'    Private Sub RecalculateQueuePositions()
'        Dim today As String = DateTime.Now.ToString("yyyy-MM-dd")
'        Dim recalcSql As String = "SET @row := 0; UPDATE tbl_queue q JOIN (SELECT queueID, @row := @row + 1 AS newPosition FROM tbl_queue WHERE queueDate = ? ORDER BY CASE WHEN patientType = 'PWD' THEN 1 WHEN patientType = 'Senior Citizen' THEN 1 WHEN patientID IN (SELECT patientID FROM tbl_appointments WHERE DATE(appointmentDate) = ?) THEN 2 ELSE 3 END, createdAt) rankedQueue ON q.queueID = rankedQueue.queueID SET q.queuePosition = rankedQueue.newPosition"

'        Try
'            Call dbConn()
'            Using cmd As New Odbc.OdbcCommand(recalcSql, conn)
'                cmd.Parameters.AddWithValue("?", today)
'                cmd.Parameters.AddWithValue("?", today)
'                cmd.ExecuteNonQuery()
'            End Using
'            conn.Close()
'        Catch ex As Exception
'            MessageBox.Show("Error recalculating queue: " & ex.Message)
'        End Try
'    End Sub





'    Private Sub cmbPatientType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatientType.SelectedIndexChanged

'    End Sub

'    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
'        Me.Close()
'    End Sub
'End Class