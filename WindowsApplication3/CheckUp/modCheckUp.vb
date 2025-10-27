Imports System.Data.Odbc
Module modCheckUp
    Public Sub LoadCheckUpData(dgv As DataGridView)
        Try
            ' Always use designed columns
            dgv.AutoGenerateColumns = False
            Call dbConn()
            Dim sql As String = _
                "SELECT vc.*, ap.doctorName AS AppointedDoctor, ap.appointmentDate AS AppointmentDate " & _
                "FROM db_viewcheckup vc " & _
                "LEFT JOIN ( " & _
                "  SELECT a.checkupID, a.doctorName, a.appointmentDate " & _
                "  FROM tbl_appointments a " & _
                "  JOIN (SELECT checkupID, MAX(appointmentDate) AS maxDate FROM tbl_appointments GROUP BY checkupID) mx " & _
                "    ON mx.checkupID = a.checkupID AND mx.maxDate = a.appointmentDate " & _
                ") ap ON ap.checkupID = vc.CheckupID " & _
                "ORDER BY vc.CheckupID DESC"
            Call LoadDGV(sql, dgv)
            dgv.ClearSelection()
        Catch ex As Exception
            MsgBox("Failed to load data: " & ex.Message, vbCritical, "Error")
        End Try
        DgvStyle(dgv)
    End Sub
    Public Sub DgvStyle(ByRef checkUpDGV As DataGridView)
        ' Basic Grid Setup
        checkUpDGV.AutoGenerateColumns = False
        checkUpDGV.AllowUserToAddRows = False
        checkUpDGV.AllowUserToDeleteRows = False
        checkUpDGV.RowHeadersVisible = False
        checkUpDGV.BorderStyle = BorderStyle.FixedSingle
        checkUpDGV.BackgroundColor = Color.White
        checkUpDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        checkUpDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        checkUpDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        checkUpDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        checkUpDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        checkUpDGV.EnableHeadersVisualStyles = False
        checkUpDGV.DefaultCellStyle.ForeColor = Color.Black
        checkUpDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        checkUpDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        checkUpDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        checkUpDGV.GridColor = Color.Silver
        checkUpDGV.DefaultCellStyle.Padding = New Padding(5)
        checkUpDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        checkUpDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        checkUpDGV.ReadOnly = True
        checkUpDGV.MultiSelect = False
        checkUpDGV.AllowUserToResizeRows = False
        checkUpDGV.RowTemplate.Height = 30
        checkUpDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        checkUpDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub
    Public Sub OnCheckUpFormClosed(sender As Object, e As FormClosedEventArgs, dgv As DataGridView)
        Try
            ' Always use designed columns
            dgv.AutoGenerateColumns = False
            Call dbConn()
            Dim sql As String = _
                "SELECT vc.*, ap.doctorName AS AppointedDoctor, ap.appointmentDate AS AppointmentDate " & _
                "FROM db_viewcheckup vc " & _
                "LEFT JOIN ( " & _
                "  SELECT a.checkupID, a.doctorName, a.appointmentDate " & _
                "  FROM tbl_appointments a " & _
                "  JOIN (SELECT checkupID, MAX(appointmentDate) AS maxDate FROM tbl_appointments GROUP BY checkupID) mx " & _
                "    ON mx.checkupID = a.checkupID AND mx.maxDate = a.appointmentDate " & _
                ") ap ON ap.checkupID = vc.CheckupID " & _
                "ORDER BY vc.CheckupID DESC"
            Call LoadDGV(sql, dgv)
            dgv.Refresh()
        Catch ex As Exception
            MsgBox("Failed to refresh data: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Public Sub SearchCheckUps(filter As String, searchValue As String, dgv As DataGridView)
        Try
            ' Always use designed columns
            dgv.AutoGenerateColumns = False
            Dim sql As String = "SELECT * FROM db_viewcheckup WHERE "
            Dim paramValue As Object = searchValue

            Select Case filter
                Case "Patient Name"
                    sql += "patientName LIKE ?"
                    paramValue = "%" & searchValue & "%"

                Case "Doctor Name"
                    sql += "CheckupDoctor LIKE ?"
                    paramValue = "%" & searchValue & "%"

                Case Else ' Default to patient name if invalid filter
                    sql += "patientName LIKE ?"
                    paramValue = "%" & searchValue & "%"
            End Select

            sql += " ORDER BY checkupID DESC"

            ' Clear previous data
            dgv.DataSource = Nothing

            Using conn As New OdbcConnection(myDSN)
                Using cmd As New OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", paramValue)

                    Dim da As New OdbcDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    dgv.DataSource = dt
                    dgv.ClearSelection()

                    ' Show message if no results found
                    If dt.Rows.Count <= 0 Then
                        MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("Search failed: " & ex.Message)
        End Try
    End Sub

    Public Sub RefreshCheckUpDGV()
        ' Refresh the checkUp DGV if a checkUp form is open
        For Each f As Form In Application.OpenForms
            If TypeOf f Is checkUp Then
                Try
                    Dim formRef As checkUp = CType(f, checkUp)
                    LoadCheckUpData(formRef.checkUpDGV)
                Catch ex As Exception
                    MsgBox("Failed to refresh check-up records: " & ex.Message, vbCritical, "Error")
                End Try
                Exit For
            End If
        Next
    End Sub

End Module
