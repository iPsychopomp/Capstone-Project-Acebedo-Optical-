Public Class checkProducts
    Private DeliverySaved As Boolean = False
    Dim orderID As Integer
    Dim orderStatus As String
    Private _ParentForm As Form = Nothing

    Public Sub New(orderID As Integer, orderStatus As String)
        InitializeComponent()
        Me.orderID = orderID
        Me.orderStatus = orderStatus
    End Sub

    Public Sub New(orderID As Integer, orderStatus As String, parentForm As Form)
        InitializeComponent()
        Me.orderID = orderID
        Me.orderStatus = orderStatus
        _ParentForm = parentForm
    End Sub

    Private Sub checkProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnsureDeliveryStatusColumn()
        LoadOrderItems(orderID)
        btnOrderReceived.Enabled = (orderStatus <> "Received" AndAlso orderStatus <> "Cancelled")

        ' Show/hide Cancel Remaining Items button based on order status
        btnRemaining.Visible = (orderStatus = "To Be Followed" OrElse orderStatus = "Incomplete" OrElse orderStatus = "Partial")

        If Not btnOrderReceived.Enabled Then
            MsgBox("This order has already been received or cancelled. No further actions can be taken.", vbExclamation, "Order Status Not Editable")
        End If
        DgvStyle(dgvOrderItems)
    End Sub

    ' Ensure productName column exists on tbl_productOrder_items so we can display supplier item names
    Private Sub EnsureOrderItemsProductNameColumn()
        Try
            Try
                Using testCmd As New Odbc.OdbcCommand("SELECT productName FROM tbl_productorder_items LIMIT 1", conn)
                    testCmd.ExecuteScalar()
                End Using
            Catch
                Using alterCmd As New Odbc.OdbcCommand("ALTER TABLE tbl_productorder_items ADD COLUMN productName VARCHAR(255) NULL", conn)
                    alterCmd.ExecuteNonQuery()
                End Using
            End Try
        Catch
            ' ignore migration errors
        End Try
    End Sub

    ' ==== Order transaction logging helpers ====
    Private Sub EnsureOrderTransactionsTable()
        Try
            Call dbConn()
            Dim createSql As String = "CREATE TABLE IF NOT EXISTS tbl_order_transactions (" & _
                                      "transID INT AUTO_INCREMENT PRIMARY KEY, " & _
                                      "orderID INT NOT NULL, " & _
                                      "status VARCHAR(30) NOT NULL, " & _
                                      "remarks VARCHAR(255) NULL, " & _
                                      "actionTime DATETIME NOT NULL, " & _
                                      "FOREIGN KEY (orderID) REFERENCES tbl_productOrders(orderID) ON DELETE CASCADE)"
            Using cmd As New Odbc.OdbcCommand(createSql, conn)
                cmd.ExecuteNonQuery()
            End Using
        Catch
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub LogOrderTransaction(p_orderID As Integer, p_status As String, p_remarks As String)
        Try
            EnsureOrderTransactionsTable()
            Call dbConn()
            Using cmd As New Odbc.OdbcCommand("INSERT INTO tbl_order_transactions (orderID, status, remarks, actionTime) VALUES (?, ?, ?, ?)", conn)
                cmd.Parameters.AddWithValue("?", p_orderID)
                cmd.Parameters.AddWithValue("?", p_status)
                cmd.Parameters.AddWithValue("?", p_remarks)
                cmd.Parameters.AddWithValue("?", DateTime.Now)
                cmd.ExecuteNonQuery()
            End Using
        Catch
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub LoadOrderItems(orderID As Integer)
        Call dbConn()
        ' Ensure schema has productName on tbl_productOrder_items for older databases
        EnsureOrderItemsProductNameColumn()

        Dim sql As String = "SELECT poi.itemID, poi.orderID, poi.productID, " & _
                            "COALESCE(p.productName, poi.productName, sp.product_name, '(Supplier Item)') AS productName, " & _
                            "poi.quantity AS quantityOrdered, " & _
                            "IFNULL(od.totalReceived, 0) AS quantityReceived, " & _
                            "IFNULL(od.totalDefective, 0) AS quantityDefective, " & _
                            "(poi.quantity - IFNULL(od.totalReceived, 0)) AS pendingQuantity, " & _
                            "IFNULL(od.remarks, '') AS remarks " & _
                            "FROM tbl_productorder_items poi " & _
                            "JOIN tbl_productOrders o ON o.orderID = poi.orderID " & _
                            "LEFT JOIN tbl_products p ON poi.productID = p.productID " & _
                            "LEFT JOIN tbl_supplier_products sp ON sp.supplierID = o.supplierID AND (sp.product_name = poi.productName OR sp.product_name = p.productName) " & _
                            "LEFT JOIN ( " & _
                            "   SELECT orderID, itemID, " & _
                            "          SUM(quantityReceived) AS totalReceived, " & _
                            "          SUM(quantityDefective) AS totalDefective, " & _
                            "          MAX(remarks) AS remarks " & _
                            "   FROM tbl_order_deliveries " & _
                            "   GROUP BY orderID, itemID " & _
                            ") od ON od.orderID = poi.orderID AND od.itemID = poi.itemID " & _
                            "WHERE poi.orderID = ?"

        Dim cmd As New Odbc.OdbcCommand(sql, conn)
        cmd.Parameters.AddWithValue("?", orderID)

        Dim reader As Odbc.OdbcDataReader = Nothing

        Try
            dgvOrderItems.Rows.Clear()
            reader = cmd.ExecuteReader()

            While reader.Read()
                Dim pid As Integer = 0
                If Not IsDBNull(reader("productID")) Then
                    Integer.TryParse(reader("productID").ToString(), pid)
                End If
                dgvOrderItems.Rows.Add(
                    Convert.ToInt32(reader("itemID")),
                    Convert.ToInt32(reader("orderID")),
                    pid,
                    reader("productName").ToString(),
                    Convert.ToInt32(reader("quantityOrdered")),
                    Convert.ToInt32(reader("quantityReceived")),
                    Convert.ToInt32(reader("quantityDefective")),
                    Convert.ToInt32(reader("pendingQuantity")),
                    reader("remarks").ToString()
                )
            End While

        Catch ex As Exception
            MsgBox("Error loading order items: " & ex.Message, vbCritical, "Error")
        Finally
            If reader IsNot Nothing Then reader.Close()
            cmd.Dispose()
            conn.Close()
        End Try
        DgvStyle(dgvOrderItems)
    End Sub

    Private Sub TransferReceivedItemsToInventory(p_orderID As Integer)
        Dim trans As Odbc.OdbcTransaction = Nothing
        Try
            Call dbConn()
            If conn.State = ConnectionState.Closed Then conn.Open()
            trans = conn.BeginTransaction()

            ' Aggregate received quantities per item for this order
            Dim sql As String = _
                "SELECT poi.productID, " & _
                "COALESCE(p.productName, poi.productName, sp.product_name) AS productName, " & _
                "COALESCE(p.category, sp.category) AS category, " & _
                "COALESCE(p.description, sp.description, 'N/A') AS description, " & _
                "SUM(od.quantityReceived) AS qtyReceived, " & _
                "o.supplierID " & _
                "FROM tbl_productorder_items poi " & _
                "JOIN tbl_productOrders o ON o.orderID = poi.orderID " & _
                "LEFT JOIN tbl_products p ON poi.productID = p.productID " & _
                "LEFT JOIN tbl_supplier_products sp ON sp.supplierID = o.supplierID AND (sp.product_name = poi.productName OR sp.product_name = p.productName) " & _
                "JOIN tbl_order_deliveries od ON od.orderID = poi.orderID AND od.itemID = poi.itemID " & _
                "WHERE poi.orderID = ? " & _
                "GROUP BY poi.itemID, poi.productID, COALESCE(p.productName, poi.productName, sp.product_name), COALESCE(p.category, sp.category), COALESCE(p.description, sp.description, 'N/A'), o.supplierID"

            Using cmd As New Odbc.OdbcCommand(sql, conn, trans)
                cmd.Parameters.Clear()
                cmd.Parameters.Add(New Odbc.OdbcParameter("orderID", Odbc.OdbcType.Int)).Value = p_orderID
                Using rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim prodName As String = Convert.ToString(rdr("productName")).Trim()
                        Dim category As String = Convert.ToString(rdr("category")).Trim()
                        Dim desc As String = Convert.ToString(rdr("description")).Trim()
                        Dim qtyReceived As Integer = Convert.ToInt32(rdr("qtyReceived"))
                        Dim supplierID As Integer = Convert.ToInt32(rdr("supplierID"))

                        If qtyReceived <= 0 OrElse String.IsNullOrWhiteSpace(prodName) Then Continue While

                        ' Does product already exist? case-insensitive by name
                        Dim existingID As Integer = 0
                        Using checkCmd As New Odbc.OdbcCommand("SELECT productID FROM tbl_products WHERE LOWER(productName) = LOWER(?) LIMIT 1", conn, trans)
                            checkCmd.Parameters.Clear()
                            checkCmd.Parameters.Add(New Odbc.OdbcParameter("productName", Odbc.OdbcType.VarChar)).Value = prodName
                            Dim obj = checkCmd.ExecuteScalar()
                            If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                                Integer.TryParse(obj.ToString(), existingID)
                            End If
                        End Using

                        If existingID > 0 Then
                            ' Update stock quantity only; keep other fields as-is for now
                            Using upd As New Odbc.OdbcCommand("UPDATE tbl_products SET stockQuantity = IFNULL(stockQuantity,0) + ? WHERE productID = ?", conn, trans)
                                upd.Parameters.Clear()
                                upd.Parameters.Add(New Odbc.OdbcParameter("qty", Odbc.OdbcType.Int)).Value = qtyReceived
                                upd.Parameters.Add(New Odbc.OdbcParameter("productID", Odbc.OdbcType.Int)).Value = existingID
                                upd.ExecuteNonQuery()
                            End Using
                        Else
                            ' Insert minimal product record; remaining fields can be edited later in inventory
                            Using ins As New Odbc.OdbcCommand("INSERT INTO tbl_products (productName, category, stockQuantity, unitPrice, description, reorderLevel, dateAdded, supplierID, discount, discountAppliedDate) VALUES (?,?,?,?,?,?,?,?,?,?)", conn, trans)
                                ins.Parameters.Clear()
                                ins.Parameters.Add(New Odbc.OdbcParameter("productName", Odbc.OdbcType.VarChar)).Value = prodName
                                ins.Parameters.Add(New Odbc.OdbcParameter("category", Odbc.OdbcType.VarChar)).Value = If(String.IsNullOrWhiteSpace(category), "N/A", category)
                                ins.Parameters.Add(New Odbc.OdbcParameter("stockQuantity", Odbc.OdbcType.Int)).Value = qtyReceived
                                ins.Parameters.Add(New Odbc.OdbcParameter("unitPrice", Odbc.OdbcType.Double)).Value = CDbl(0)
                                ins.Parameters.Add(New Odbc.OdbcParameter("description", Odbc.OdbcType.VarChar)).Value = If(String.IsNullOrWhiteSpace(desc), "N/A", desc)
                                ins.Parameters.Add(New Odbc.OdbcParameter("reorderLevel", Odbc.OdbcType.Int)).Value = 0
                                ins.Parameters.Add(New Odbc.OdbcParameter("dateAdded", Odbc.OdbcType.Date)).Value = DateTime.Now.Date
                                ins.Parameters.Add(New Odbc.OdbcParameter("supplierID", Odbc.OdbcType.Int)).Value = supplierID
                                ins.Parameters.Add(New Odbc.OdbcParameter("discount", Odbc.OdbcType.Double)).Value = CDbl(0)
                                Dim pDate As New Odbc.OdbcParameter("discountAppliedDate", Odbc.OdbcType.Date)
                                pDate.Value = DBNull.Value
                                ins.Parameters.Add(pDate)
                                ins.ExecuteNonQuery()
                            End Using
                        End If
                    End While
                End Using
            End Using

            trans.Commit()

            ' Refresh inventory grid if open
            Dim inv As inventory = Application.OpenForms().OfType(Of inventory)().FirstOrDefault()
            If inv IsNot Nothing Then
                inv.SafeLoadProducts()
                inv.productDGV.Refresh()
            End If

        Catch ex As Exception
            Try
                If trans IsNot Nothing Then trans.Rollback()
            Catch
            End Try
            MsgBox("Error transferring received items to inventory: " & ex.Message, vbCritical, "Transfer Error")
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub
    Public Sub DgvStyle(ByRef dgvOrderItems As DataGridView)
        ' Basic Grid Setup
        dgvOrderItems.AutoGenerateColumns = False
        dgvOrderItems.AllowUserToAddRows = False
        dgvOrderItems.AllowUserToDeleteRows = False
        dgvOrderItems.RowHeadersVisible = False
        dgvOrderItems.BorderStyle = BorderStyle.FixedSingle
        dgvOrderItems.BackgroundColor = Color.White
        dgvOrderItems.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        dgvOrderItems.CellBorderStyle = DataGridViewCellBorderStyle.Single
        dgvOrderItems.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        dgvOrderItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        dgvOrderItems.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        dgvOrderItems.EnableHeadersVisualStyles = False
        dgvOrderItems.DefaultCellStyle.ForeColor = Color.Black
        dgvOrderItems.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        dgvOrderItems.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        dgvOrderItems.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvOrderItems.GridColor = Color.Silver
        dgvOrderItems.DefaultCellStyle.Padding = New Padding(5)
        dgvOrderItems.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvOrderItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvOrderItems.ReadOnly = True
        dgvOrderItems.MultiSelect = False
        dgvOrderItems.AllowUserToResizeRows = False
        dgvOrderItems.RowTemplate.Height = 30
        dgvOrderItems.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        dgvOrderItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

    Private Sub btnOrderReceived_Click(sender As Object, e As EventArgs) Handles btnOrderReceived.Click
        If dgvOrderItems.Rows.Count = 0 Then
            MsgBox("There are no items to process in this order.", vbExclamation, "No Items")
            Exit Sub
        End If

        If Not DeliverySaved Then
            MsgBox("No item received. Order status will not be updated.", vbInformation, "No Changes")
            Exit Sub
        End If

        Try
            Call dbConn()

            ' 1. Calculate pending items count to determine order status
            Dim pendingSql As String = "SELECT COUNT(*) FROM (" &
                                       " SELECT poi.itemID, poi.quantity, IFNULL(SUM(od.quantityReceived), 0) AS totalReceived " &
                                       " FROM tbl_productorder_items poi " &
                                       " LEFT JOIN tbl_order_deliveries od ON poi.itemID = od.itemID AND poi.orderID = od.orderID " &
                                       " WHERE poi.orderID = ? " &
                                       " GROUP BY poi.itemID, poi.quantity " &
                                       " HAVING poi.quantity > totalReceived) AS pendingItems"

            Dim pendingCmd As New Odbc.OdbcCommand(pendingSql, conn)
            pendingCmd.Parameters.AddWithValue("?", orderID)
            Dim pendingCount As Integer = Convert.ToInt32(pendingCmd.ExecuteScalar())

            Dim newStatus As String = If(pendingCount = 0, "Received", "Partial")

            ' Stock increment now occurs per-delivery in ReceivedItems.btnSave. Avoid cumulative re-application here.

            ' 3. Update order status
            Dim updateSql As String = "UPDATE tbl_productOrders SET status = ? WHERE orderID = ?"
            Dim updateCmd As New Odbc.OdbcCommand(updateSql, conn)
            updateCmd.Parameters.AddWithValue("?", newStatus)
            updateCmd.Parameters.AddWithValue("?", orderID)
            updateCmd.ExecuteNonQuery()

            MsgBox("Order status updated to '" & newStatus & "'.", vbInformation, "Status Updated")

            ' Log transaction (Partial or Received)
            LogOrderTransaction(orderID, newStatus, "Updated via Check Products")


            ' Reset DeliverySaved BEFORE closing or reloading form
            DeliverySaved = False

            If newStatus = "Received" Then
                Me.Close()
            Else
                LoadOrderItems(orderID)
            End If

            Dim openOrderProduct As OrderProduct = Application.OpenForms.OfType(Of OrderProduct)().FirstOrDefault()
            If openOrderProduct IsNot Nothing Then
                openOrderProduct.LoadOrders()
            End If

        Catch ex As Exception
            MsgBox("Error updating order status or stock: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
        DgvStyle(dgvOrderItems)
    End Sub




    Public Sub InsertAuditTrail(UserID As Integer, ActionType As String, ActionDetails As String)
        Dim connectionString As String = "DSN=dsnsystem"
        Using conn As New Odbc.OdbcConnection(connectionString)
            Try
                conn.Open()
                Dim query As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?)"
                Using cmd As New Odbc.OdbcCommand(query, conn)
                    cmd.Parameters.AddWithValue("?", UserID)
                    cmd.Parameters.AddWithValue("?", GlobalVariables.LoggedInUser)
                    cmd.Parameters.AddWithValue("?", ActionType)
                    cmd.Parameters.AddWithValue("?", ActionDetails)
                    cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                    cmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                MsgBox("Audit Trail Error: " & ex.Message, vbCritical, "Error")
            End Try
        End Using
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvOrderItems_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrderItems.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvOrderItems.Rows.Count Then
            Dim row As DataGridViewRow = dgvOrderItems.Rows(e.RowIndex)

            Dim status As String = ""
            Try
                Call dbConn()
                Dim sqlStatus As String = "SELECT status FROM tbl_productOrders WHERE orderID = ?"
                Dim cmdStatus As New Odbc.OdbcCommand(sqlStatus, conn)
                cmdStatus.Parameters.AddWithValue("?", orderID)
                status = cmdStatus.ExecuteScalar().ToString().ToLower()
            Finally
                If conn.State = ConnectionState.Open Then conn.Close()
            End Try

            If status = "cancelled" Then
                MsgBox("This order is cancelled. You cannot receive items.", vbExclamation, "Cancelled Order")
                Exit Sub
            End If

            Dim itemID As Integer = Convert.ToInt32(row.Cells("itemID").Value)
            Dim productID As Integer = 0
            Integer.TryParse(Convert.ToString(row.Cells("productID").Value), productID)
            Dim p_productName As String = row.Cells("productName").Value.ToString()
            Dim pendingQty As Integer = Convert.ToInt32(row.Cells("pendingQuantity").Value)

            If pendingQty <= 0 Then
                MsgBox("No pending quantity for this item.", vbInformation, "Completed Item")
                Exit Sub
            End If

            Dim receiveForm As New ReceivedItems(orderID, itemID, productID, p_productName, pendingQty, Me)

            ' When ReceivedItems closes, reload items if saved
            AddHandler receiveForm.FormClosed, Sub(s, ev)
                                                   If receiveForm.DeliverySaved Then
                                                       DeliverySaved = True ' Set flag so btnOrderReceived can process
                                                       LoadOrderItems(orderID)
                                                   End If
                                               End Sub

            receiveForm.TopMost = True
            receiveForm.ShowDialog()
        End If
        DgvStyle(dgvOrderItems)
    End Sub
    ' Cancel Remaining Items button click event
    Private Sub btnRemaining_Click(sender As Object, e As EventArgs) Handles btnRemaining.Click
        CancelOrder()
    End Sub

    Private Sub CancelOrder()
        ' Confirm cancellation
        If MsgBox("Are you sure you want to cancel the remaining items in this order? This action cannot be undone.", vbYesNo + vbQuestion, "Confirm Cancellation") = vbNo Then
            Exit Sub
        End If

        Try
            Call dbConn()

            ' Check if any items have been received
            Dim hasReceivedItems As Boolean = False
            Dim checkReceivedSql As String = "SELECT COUNT(*) FROM tbl_order_deliveries WHERE orderID = ? AND quantityReceived > 0"
            Using checkCmd As New Odbc.OdbcCommand(checkReceivedSql, conn)
                checkCmd.Parameters.AddWithValue("?", orderID)
                hasReceivedItems = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0
            End Using

            ' Create cancellation records for pending items
            CreateCancellationRecords()

            ' Determine final status based on whether items were received
            Dim finalStatus As String = If(hasReceivedItems, "Completed", "Cancelled")

            ' Update order status
            Dim updateStatusSql As String = "UPDATE tbl_productOrders SET status = ? WHERE orderID = ?"
            Using updateCmd As New Odbc.OdbcCommand(updateStatusSql, conn)
                updateCmd.Parameters.AddWithValue("?", finalStatus)
                updateCmd.Parameters.AddWithValue("?", orderID)
                updateCmd.ExecuteNonQuery()
            End Using

            ' Insert audit trail
            Dim statusMessage As String = If(hasReceivedItems,
                "Order partially completed - remaining items cancelled",
                "Order completely cancelled")
            InsertAuditTrail(GlobalVariables.LoggedInUserID, "Cancel Order",
                           "Order ID " & orderID & ": " & statusMessage)

            ' Log cancellation/completion transaction
            LogOrderTransaction(orderID, finalStatus, statusMessage)

            MsgBox("Order has been cancelled. Status set to '" & finalStatus & "'.", vbInformation, "Order Cancelled")

            ' Refresh the parent form and close this form
            Dim openOrderProduct As OrderProduct = Application.OpenForms.OfType(Of OrderProduct)().FirstOrDefault()
            If openOrderProduct IsNot Nothing Then
                openOrderProduct.LoadOrders()
            End If

            Me.Close()

        Catch ex As Exception
            MsgBox("Error cancelling order: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub EnsureDeliveryStatusColumn()
        Try
            Call dbConn()

            ' Try to select from deliveryStatus column to test if it exists
            Try
                Dim testCmd As New Odbc.OdbcCommand("SELECT deliveryStatus FROM tbl_order_deliveries LIMIT 1", conn)
                testCmd.ExecuteScalar()
                ' If we get here, column exists
            Catch testEx As Exception
                ' Column doesn't exist, create it
                Try
                    Dim alterCmd As New Odbc.OdbcCommand("ALTER TABLE tbl_order_deliveries ADD COLUMN deliveryStatus VARCHAR(20) DEFAULT 'Delivered'", conn)
                    alterCmd.ExecuteNonQuery()
                Catch alterEx As Exception
                    ' Ignore errors here - column might already exist or there might be permission issues
                End Try
            End Try

        Catch ex As Exception
            ' Ignore connection errors here
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub RecalculateOrderTotal(p_orderID As Integer)
        ' Recalculate order total based on delivered items only
        Try
            ' Get supplierID for this order
            Dim supplierID As Integer = 0
            Dim getSupplierSql As String = "SELECT supplierID FROM tbl_productOrders WHERE orderID = ?"
            Using supplierCmd As New Odbc.OdbcCommand(getSupplierSql, conn)
                supplierCmd.Parameters.AddWithValue("?", p_orderID)
                Dim result = supplierCmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    supplierID = Convert.ToInt32(result)
                Else
                    MsgBox("Error: Could not find supplier for order " & p_orderID, vbExclamation, "Recalculation Error")
                    Exit Sub
                End If
            End Using

            ' Query delivered items with their prices
            Dim querySql As String = _
                "SELECT od.productName, od.quantityReceived, sp.product_price " & _
                "FROM tbl_order_deliveries od " & _
                "JOIN tbl_productOrders o ON o.orderID = od.orderID " & _
                "JOIN tbl_supplier_products sp ON sp.supplierID = o.supplierID " & _
                "    AND UPPER(TRIM(sp.product_name)) = UPPER(TRIM(od.productName)) " & _
                "WHERE od.orderID = ? " & _
                "    AND od.deliveryStatus = 'Delivered' " & _
                "    AND od.quantityReceived > 0"

            Dim newTotal As Decimal = 0D
            Dim missingPrices As New List(Of String)

            Using queryCmd As New Odbc.OdbcCommand(querySql, conn)
                queryCmd.Parameters.AddWithValue("?", p_orderID)
                Using reader = queryCmd.ExecuteReader()
                    While reader.Read()
                        Dim productName As String = Convert.ToString(reader("productName"))
                        Dim qtyReceived As Integer = Convert.ToInt32(reader("quantityReceived"))
                        Dim unitPrice As Decimal = 0D

                        If Not IsDBNull(reader("product_price")) Then
                            unitPrice = Convert.ToDecimal(reader("product_price"))
                            newTotal += unitPrice * qtyReceived
                        Else
                            ' Track products with missing prices
                            missingPrices.Add(productName)
                        End If
                    End While
                End Using
            End Using

            ' Show warning if any prices were missing
            If missingPrices.Count > 0 Then
                Dim warningMsg As String = "Warning: Price not found for the following product(s). They were excluded from total calculation:" & vbCrLf & vbCrLf
                For Each prodName In missingPrices
                    warningMsg &= "- " & prodName & vbCrLf
                Next
                MsgBox(warningMsg, vbExclamation, "Missing Prices")
            End If

            ' Update totalAmount in tbl_productOrders
            Dim updateSql As String = "UPDATE tbl_productOrders SET totalAmount = ? WHERE orderID = ?"
            Using updateCmd As New Odbc.OdbcCommand(updateSql, conn)
                updateCmd.Parameters.AddWithValue("?", newTotal)
                updateCmd.Parameters.AddWithValue("?", p_orderID)
                updateCmd.ExecuteNonQuery()
            End Using

            ' Add audit trail entry for total amount change
            InsertAuditTrail(GlobalVariables.LoggedInUserID, "Order Total Recalculated",
                           "Order ID " & p_orderID & ": Total amount updated to " & newTotal.ToString("N2"))

        Catch ex As Exception
            MsgBox("Error recalculating order total: " & ex.Message, vbCritical, "Recalculation Error")
        End Try
    End Sub

    Private Sub CreateCancellationRecords()
        ' Create cancellation delivery records for all pending items
        For Each row As DataGridViewRow In dgvOrderItems.Rows
            If row.IsNewRow Then Continue For

            Dim itemID As Integer = Convert.ToInt32(row.Cells("itemID").Value)
            Dim productID As Integer = 0
            Integer.TryParse(Convert.ToString(row.Cells("productID").Value), productID)
            Dim pendingQty As Integer = Convert.ToInt32(row.Cells("pendingQuantity").Value)

            ' Only create cancellation record if there's pending quantity
            If pendingQty > 0 Then
                Dim insertCancelSql As String = "INSERT INTO tbl_order_deliveries " & _
                    "(orderID, itemID, productID, quantityReceived, quantityDefective, remarks, receivedBy, deliveryDate, deliveryStatus, productName) " & _
                    "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"

                Using cancelCmd As New Odbc.OdbcCommand(insertCancelSql, conn)
                    cancelCmd.Parameters.AddWithValue("?", orderID)
                    cancelCmd.Parameters.AddWithValue("?", itemID)
                    Dim pParam As New Odbc.OdbcParameter("productID", Odbc.OdbcType.Int)
                    If productID = 0 Then
                        pParam.Value = DBNull.Value
                    Else
                        pParam.Value = productID
                    End If
                    cancelCmd.Parameters.Add(pParam)
                    cancelCmd.Parameters.AddWithValue("?", 0) ' quantityReceived = 0
                    cancelCmd.Parameters.AddWithValue("?", 0) ' quantityDefective = 0
                    cancelCmd.Parameters.AddWithValue("?", "Cancelled - " & pendingQty & " items not delivered")
                    cancelCmd.Parameters.AddWithValue("?", GlobalVariables.LoggedInFullName)
                    cancelCmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                    cancelCmd.Parameters.AddWithValue("?", "Cancelled")
                    ' Persist productName for better history display and supplier matching
                    Dim cancelledProdName As String = ""
                    Try
                        cancelledProdName = Convert.ToString(row.Cells("productName").Value)
                    Catch
                    End Try
                    cancelCmd.Parameters.AddWithValue("?", cancelledProdName)
                    cancelCmd.ExecuteNonQuery()
                End Using
            End If
        Next
    End Sub

    Private Sub checkProducts_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If DeliverySaved Then
            Dim result = MessageBox.Show("You have unsaved delivery changes. Please click 'Order Received' to process before closing.",
                                         "Unsaved Changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If result = DialogResult.OK Then
                e.Cancel = True ' User pressed OK, cancel closing so they can save
            End If
        End If

        ' Show the parent form when this form closes
        If Not e.Cancel AndAlso _ParentForm IsNot Nothing AndAlso Not _ParentForm.IsDisposed Then
            _ParentForm.Show()
            _ParentForm.BringToFront()
        End If
    End Sub
End Class