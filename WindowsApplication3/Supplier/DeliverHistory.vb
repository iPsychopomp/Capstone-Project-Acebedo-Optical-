Public Class DeliverHistory
    Private _NeworderID As Integer
    Private _FilterProductName As String = String.Empty
    Private _ParentForm As Form = Nothing

    Public Sub New(orderID As Integer)
        InitializeComponent()
        _NeworderID = orderID
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
        LoadDeliveryHistory()
    End Sub
    Private Sub LoadDeliveryHistory()
        Call dbConn()
        EnsureDeliveriesProductNameColumn()

        Dim sql As String = "SELECT d.deliveryID, d.orderID, d.itemID, " & _
                            "COALESCE(sp.sProductID, d.productID) AS productID, " & _
                            "COALESCE(sp.product_name, p.productName, poi.productName, d.productName, '(Supplier Item)') AS productName, " & _
                            "d.quantityReceived, d.quantityDefective, d.remarks, d.receivedBy, d.deliveryDate, " & _
                            "COALESCE(d.deliveryStatus, 'Delivered') AS deliveryStatus " & _
                            "FROM tbl_order_deliveries d " & _
                            "LEFT JOIN tbl_productorder_items poi ON poi.orderID = d.orderID AND poi.itemID = d.itemID " & _
                            "LEFT JOIN tbl_products p ON poi.productID = p.productID " & _
                            "LEFT JOIN tbl_productOrders o ON o.orderID = d.orderID " & _
                            "LEFT JOIN tbl_supplier_products sp ON sp.supplierID = o.supplierID " & _
                            "    AND ( " & _
                            "        UPPER(TRIM(sp.product_name)) = UPPER(TRIM(COALESCE(d.productName, poi.productName, p.productName))) " & _
                            "     OR  UPPER(TRIM(sp.product_name)) LIKE CONCAT(UPPER(TRIM(COALESCE(d.productName, poi.productName, p.productName))), '%') " & _
                            "     OR  UPPER(TRIM(COALESCE(d.productName, poi.productName, p.productName))) LIKE CONCAT(UPPER(TRIM(sp.product_name)), '%') " & _
                            "    ) " & _
                            "WHERE d.orderID = ? " & _
                            If(String.IsNullOrWhiteSpace(_FilterProductName), "", " AND UPPER(TRIM(COALESCE(d.productName, poi.productName, p.productName))) = UPPER(TRIM(?)) ") & _
                            "ORDER BY d.deliveryDate DESC, d.deliveryID DESC"

        Dim cmd As New Odbc.OdbcCommand(sql, conn)
        cmd.Parameters.AddWithValue("?", _NeworderID)
        If Not String.IsNullOrWhiteSpace(_FilterProductName) Then
            cmd.Parameters.AddWithValue("?", _FilterProductName)
        End If

        Dim dt As New DataTable()

        Try
            Dim da As New Odbc.OdbcDataAdapter(cmd)
            da.Fill(dt)

            dgvDeliveryHistory.AutoGenerateColumns = False
            dgvDeliveryHistory.DataSource = dt

            da.Dispose()
        Catch ex As Exception
            MsgBox("Error loading delivery history: " & ex.Message, vbCritical, "Error")
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
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