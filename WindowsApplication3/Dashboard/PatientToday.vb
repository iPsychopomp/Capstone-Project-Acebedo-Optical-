Imports System.Data.Odbc

Public Class PatientToday
    Private suppressEvents As Boolean = False

    Private Sub PatientToday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default date range to today without triggering duplicate loads
        suppressEvents = True
        dtpFrom.Value = DateTime.Today
        dtpTo.Value = DateTime.Today
        suppressEvents = False

        ' Load today's patients once
        LoadPatientsWithActivity()

        ' Style the grid
        DgvStyle(patientTDGV)
    End Sub

    Private Sub LoadPatientsWithActivity()
        Try
            Call dbConn()

            ' Get date range
            Dim fromDate As String = dtpFrom.Value.ToString("yyyy-MM-dd")
            Dim toDate As String = dtpTo.Value.ToString("yyyy-MM-dd")

            ' SQL to get patients who either:
            ' 1. Were created within the date range (new patients)
            ' 2. Have checkup records within the date range
            ' 3. Have transaction records within the date range
            Dim sql As String = _
                "SELECT DISTINCT p.patientID, p.fullname " & _
                "FROM db_viewpatient p " & _
                "WHERE DATE(p.date) BETWEEN ? AND ? " & _
                "UNION " & _
                "SELECT DISTINCT c.patientID, c.patientName AS fullname " & _
                "FROM db_viewcheckup c " & _
                "WHERE DATE(c.checkupDate) BETWEEN ? AND ? " & _
                "UNION " & _
                "SELECT DISTINCT t.patientID, COALESCE(p.fullname, t.patientName) AS fullname " & _
                "FROM tbl_transactions t " & _
                "LEFT JOIN db_viewpatient p ON t.patientID = p.patientID " & _
                "WHERE DATE(t.transactionDate) BETWEEN ? AND ? " & _
                "ORDER BY fullname"

            ' Clear previous data
            patientTDGV.DataSource = Nothing
            patientTDGV.Rows.Clear()

            Using conn As New OdbcConnection(myDSN)
                Using cmd As New OdbcCommand(sql, conn)
                    ' Add parameters for all three date ranges
                    cmd.Parameters.AddWithValue("?", fromDate)
                    cmd.Parameters.AddWithValue("?", toDate)
                    cmd.Parameters.AddWithValue("?", fromDate)
                    cmd.Parameters.AddWithValue("?", toDate)
                    cmd.Parameters.AddWithValue("?", fromDate)
                    cmd.Parameters.AddWithValue("?", toDate)

                    Dim da As New OdbcDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    patientTDGV.DataSource = dt

                    ' Hide patientID column if it exists
                    If patientTDGV.Columns.Contains("patientID") Then
                        patientTDGV.Columns("patientID").Visible = False
                    End If

                    ' Show count in label
                    lblhead.Text = "Patient Today" '(" & dt.Rows.Count & " patients)"

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("No patients found for the selected date range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error loading patient data: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        If suppressEvents Then Return
        LoadPatientsWithActivity()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        If suppressEvents Then Return
        LoadPatientsWithActivity()
    End Sub

    Public Sub DgvStyle(ByRef dgv As DataGridView)
        ' Basic Grid Setup
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.RowHeadersVisible = False
        dgv.BorderStyle = BorderStyle.FixedSingle
        dgv.BackgroundColor = Color.White
        dgv.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        dgv.EnableHeadersVisualStyles = False
        dgv.DefaultCellStyle.ForeColor = Color.Black
        dgv.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        dgv.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        dgv.DefaultCellStyle.SelectionForeColor = Color.Black
        dgv.GridColor = Color.Silver
        dgv.DefaultCellStyle.Padding = New Padding(5)
        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.ReadOnly = True
        dgv.MultiSelect = False
        dgv.AllowUserToResizeRows = False
        dgv.RowTemplate.Height = 30
        dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

End Class