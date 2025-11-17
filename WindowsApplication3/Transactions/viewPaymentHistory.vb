Public Class viewPaymentHistory

    Public Property TransactionID As Integer = 0

    Private Sub viewPaymentHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If TransactionID <= 0 Then Exit Sub

            ' Use the designer-defined PaymentHistoryDGV
            Dim dgv As DataGridView = PaymentHistoryDGV
            If dgv Is Nothing Then Exit Sub

            ' Load payment history from tbl_payments
            Call dbConn()
            If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
                dbConn()
            End If

            Dim dt As New DataTable()
            Dim sql As String = "SELECT paymentDate, paymentType, amountPaid, referenceNumber FROM tbl_payments WHERE transactionID = ? ORDER BY paymentDate, paymentType"

            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", TransactionID)
                Using da As New Odbc.OdbcDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            dgv.DataSource = dt
            DgvStyle(PaymentHistoryDGV)
        Catch
        End Try
    End Sub
    Public Sub DgvStyle(ByRef dgv As DataGridView)
        Try
            dgv.AutoGenerateColumns = False
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False
            dgv.BorderStyle = BorderStyle.None
            dgv.BackgroundColor = Color.White
            dgv.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.EnableHeadersVisualStyles = False
            dgv.DefaultCellStyle.ForeColor = Color.Black
            dgv.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
            dgv.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black
            dgv.GridColor = Color.Silver
            dgv.DefaultCellStyle.Padding = New Padding(5)
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgv.ReadOnly = True
            dgv.MultiSelect = False
            dgv.AllowUserToResizeRows = False
            dgv.RowTemplate.Height = 30
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            For Each col As DataGridViewColumn In dgv.Columns
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            dgv.Refresh()
        Catch
        End Try
    End Sub

End Class