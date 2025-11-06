Public Class DeliverHistory
    Private _NeworderID As Integer
    Private _FilterProductName As String = String.Empty
    Private _ParentForm As Form = Nothing
    Private currentPage As Integer = 0
    Private pageSize As Integer = 20
    Private totalCount As Integer = 0

    Public Sub New(orderID As Integer)
        InitializeComponent()
        _NeworderID = orderID
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If currentPage > 0 Then
            currentPage -= 1
            LoadPage()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim totalPages As Integer = If(pageSize > 0, If(totalCount Mod pageSize = 0, totalCount \ pageSize, (totalCount \ pageSize) + 1), 1)
        If currentPage < (totalPages - 1) Then
            currentPage += 1
            LoadPage()
        End If
    End Sub

    Public Sub New(orderID As Integer, parentForm As Form)
        InitializeComponent()
        _NeworderID = orderID
        _ParentForm = parentForm
    End Sub

    Public Sub New(orderID As Integer, productName As String)
        InitializeComponent()
        _NeworderID = orderID
        _FilterProductName = If(productName, String.Empty)
    End Sub

    Public Sub DgvStyle(ByRef dgvDeliveryHistory As DataGridView)
        ' Basic Grid Setup
        dgvDeliveryHistory.AutoGenerateColumns = False
        dgvDeliveryHistory.AllowUserToAddRows = False
        dgvDeliveryHistory.AllowUserToDeleteRows = False
        dgvDeliveryHistory.RowHeadersVisible = False
        dgvDeliveryHistory.BorderStyle = BorderStyle.FixedSingle
        dgvDeliveryHistory.BackgroundColor = Color.White
        dgvDeliveryHistory.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        dgvDeliveryHistory.CellBorderStyle = DataGridViewCellBorderStyle.Single
        dgvDeliveryHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        dgvDeliveryHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        dgvDeliveryHistory.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        dgvDeliveryHistory.EnableHeadersVisualStyles = False
        dgvDeliveryHistory.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        dgvDeliveryHistory.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        dgvDeliveryHistory.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvDeliveryHistory.GridColor = Color.Silver
        dgvDeliveryHistory.DefaultCellStyle.Padding = New Padding(5)
        dgvDeliveryHistory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvDeliveryHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvDeliveryHistory.ReadOnly = True
        dgvDeliveryHistory.MultiSelect = False
        dgvDeliveryHistory.AllowUserToResizeRows = False
        dgvDeliveryHistory.RowTemplate.Height = 30
        dgvDeliveryHistory.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        dgvDeliveryHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

    Private Sub DeliverHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentPage = 0
        LoadPage()
    End Sub

    Private Sub LoadDeliveryHistory()
        LoadPage()
    End Sub

    Private Sub LoadPage()
        Try
            Call dbConn()
            EnsureDeliveriesProductNameColumn()

            Dim hasFilter As Boolean = Not String.IsNullOrWhiteSpace(_FilterProductName)

            ' Base SELECT without ORDER to reuse for count
            Dim baseSql As New System.Text.StringBuilder()
            baseSql.Append("SELECT d.deliveryID, d.orderID, d.itemID, ")
            baseSql.Append("COALESCE(sp.sProductID, d.productID) AS productID, ")
            baseSql.Append("COALESCE(sp.product_name, p.productName, poi.productName, d.productName, '(Supplier Item)') AS productName, ")
            baseSql.Append("d.quantityReceived, d.quantityDefective, d.remarks, d.receivedBy, d.deliveryDate, ")
            baseSql.Append("COALESCE(d.deliveryStatus, 'Delivered') AS deliveryStatus ")
            baseSql.Append("FROM tbl_order_deliveries d ")
            baseSql.Append("LEFT JOIN tbl_productorder_items poi ON poi.orderID = d.orderID AND poi.itemID = d.itemID ")
            baseSql.Append("LEFT JOIN tbl_products p ON poi.productID = p.productID ")
            baseSql.Append("LEFT JOIN tbl_productOrders o ON o.orderID = d.orderID ")
            baseSql.Append("LEFT JOIN tbl_supplier_products sp ON sp.supplierID = o.supplierID ")
            baseSql.Append("    AND ( ")
            baseSql.Append("        UPPER(TRIM(sp.product_name)) = UPPER(TRIM(COALESCE(d.productName, poi.productName, p.productName))) ")
            baseSql.Append("     OR UPPER(TRIM(sp.product_name)) LIKE CONCAT(UPPER(TRIM(COALESCE(d.productName, poi.productName, p.productName))), '%') ")
            baseSql.Append("     OR UPPER(TRIM(COALESCE(d.productName, poi.productName, p.productName))) LIKE CONCAT(UPPER(TRIM(sp.product_name)), '%') ")
            baseSql.Append("    ) ")
            baseSql.Append("WHERE d.orderID = ? ")
            If hasFilter Then
                baseSql.Append(" AND UPPER(TRIM(COALESCE(d.productName, poi.productName, p.productName))) = UPPER(TRIM(?)) ")
            End If

            ' Count total
            Dim countSql As String = "SELECT COUNT(*) FROM (" & baseSql.ToString() & ") t"
            Dim total As Integer = 0
            Using cmdCount As New Odbc.OdbcCommand(countSql, conn)
                cmdCount.Parameters.AddWithValue("?", _NeworderID)
                If hasFilter Then cmdCount.Parameters.AddWithValue("?", _FilterProductName)
                Dim obj = cmdCount.ExecuteScalar()
                If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then Integer.TryParse(obj.ToString(), total)
            End Using
            totalCount = total

            ' Paged data
            Dim dataSql As String = baseSql.ToString() & " ORDER BY d.deliveryDate DESC, d.deliveryID DESC LIMIT ? OFFSET ?"
            Dim dt As New DataTable()
            Using cmd As New Odbc.OdbcCommand(dataSql, conn)
                cmd.Parameters.AddWithValue("?", _NeworderID)
                If hasFilter Then cmd.Parameters.AddWithValue("?", _FilterProductName)
                cmd.Parameters.AddWithValue("?", pageSize)
                cmd.Parameters.AddWithValue("?", currentPage * pageSize)
                Using da As New Odbc.OdbcDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            dgvDeliveryHistory.AutoGenerateColumns = False
            dgvDeliveryHistory.DataSource = dt

        Catch ex As Exception
            MsgBox("Error loading delivery history: " & ex.Message, vbCritical, "Error")
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
        End Try

        ' Update pagination UI
        Dim totalPages As Integer = If(pageSize > 0, If(totalCount Mod pageSize = 0, totalCount \ pageSize, (totalCount \ pageSize) + 1), 1)
        If totalPages <= 0 Then totalPages = 1
        txtPage.Text = "Page " & (currentPage + 1).ToString() & " of " & totalPages.ToString()
        btnBack.Enabled = currentPage > 0
        btnNext.Enabled = currentPage < (totalPages - 1)

        DgvStyle(dgvDeliveryHistory)
    End Sub

    Private Sub dgvDeliveryHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDeliveryHistory.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvDeliveryHistory.Rows.Count Then
            Try
                ' Get order status
                Dim status As String = ""
                Call dbConn()
                Dim sqlStatus As String = "SELECT status FROM tbl_productOrders WHERE orderID = ?"
                Dim cmdStatus As New Odbc.OdbcCommand(sqlStatus, conn)
                cmdStatus.Parameters.AddWithValue("?", _NeworderID)
                status = cmdStatus.ExecuteScalar().ToString()
                conn.Close()

                ' Hide this form (DeliverHistory)
                Me.Hide()

                ' Open checkProducts form, pass the parent (OrderProduct) not this form
                Dim checkForm As New checkProducts(_NeworderID, status, _ParentForm)

                ' When checkProducts closes, show this form again
                AddHandler checkForm.FormClosed, Sub(s, ev)
                                                     Me.Show()
                                                 End Sub

                checkForm.ShowDialog()
            Catch ex As Exception
                Me.Show()
                MsgBox("Error opening check products: " & ex.Message, vbCritical, "Error")
            End Try
        End If
    End Sub

    Private Sub EnsureDeliveriesProductNameColumn()
        Try
            Try
                Using testCmd As New Odbc.OdbcCommand("SELECT productName FROM tbl_order_deliveries LIMIT 1", conn)
                    testCmd.ExecuteNonQuery()
                End Using
            Catch
                Using alterCmd As New Odbc.OdbcCommand("ALTER TABLE tbl_order_deliveries ADD COLUMN productName VARCHAR(255) NULL", conn)
                    alterCmd.ExecuteNonQuery()
                End Using
            End Try
        Catch
            ' ignore migration issues
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class