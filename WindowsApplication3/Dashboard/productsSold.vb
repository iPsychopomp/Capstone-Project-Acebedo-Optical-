Imports System.Data.Odbc

Public Class productsSold
    Dim cmd As OdbcCommand
    Dim da As OdbcDataAdapter
    Dim dt As DataTable

    Private Sub productsSold_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dbConn() ' ✅ Use your existing ODBC connection (global conn)

            ' Format date pickers
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy-MM-dd"
            dtpTo.Format = DateTimePickerFormat.Custom
            dtpTo.CustomFormat = "yyyy-MM-dd"

            ' Load all products sold initially (no filter)
            LoadProductSales()
        Catch ex As Exception
            MessageBox.Show("Error loading product sales: " & ex.Message)
        End Try
        DgvStyle(productsSoldDGV)
    End Sub

    Private Sub LoadProductSales(Optional fromDate As String = "", Optional toDate As String = "")
        Try
            Dim query As String = "SELECT productName, SUM(totalQuantitySold) AS totalQuantity, " &
                                  "SUM(totalSalesAmount) AS totalSales, transactionDate " &
                                  "FROM view_product_sales"

            ' Add filter if both dates are set
            If fromDate <> "" AndAlso toDate <> "" Then
                query &= " WHERE transactionDate BETWEEN ? AND ?"
            End If

            query &= " GROUP BY productName, transactionDate ORDER BY transactionDate DESC"

            cmd = New OdbcCommand(query, conn)

            If fromDate <> "" AndAlso toDate <> "" Then
                cmd.Parameters.AddWithValue("@from", fromDate)
                cmd.Parameters.AddWithValue("@to", toDate)
            End If

            da = New OdbcDataAdapter(cmd)
            dt = New DataTable()
            da.Fill(dt)

            ' Clear the DataGridView first
            productsSoldDGV.Rows.Clear()

            ' ✅ Populate existing columns only (assuming same order)
            For Each row As DataRow In dt.Rows
                Dim index As Integer = productsSoldDGV.Rows.Add()
                productsSoldDGV.Rows(index).Cells(0).Value = row("productName").ToString()
                productsSoldDGV.Rows(index).Cells(1).Value = row("totalQuantity").ToString()
                productsSoldDGV.Rows(index).Cells(2).Value = Format(Val(row("totalSales")), "N2")
                productsSoldDGV.Rows(index).Cells(3).Value = Format(CDate(row("transactionDate")), "yyyy-MM-dd")
            Next

            ' ✅ Optional: show message if no records found
            If dt.Rows.Count = 0 Then
                MessageBox.Show("No products sold within the selected date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading sales data: " & ex.Message)
        End Try
    End Sub


    ' Date filter events
    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        LoadProductSales(dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"))
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        LoadProductSales(dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"))
    End Sub

    Private Sub productsSold_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
            conn.Close()
        End If
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
End Class
