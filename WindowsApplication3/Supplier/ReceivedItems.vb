Public Class ReceivedItems
    Public Property DeliverySaved As Boolean = False
    Private orderID As Integer
    Private itemID As Integer
    Private productID As Integer
    Private Shadows productName As String
    Private pendingQty As Integer
    Private _ParentForm As Form = Nothing

    Public Sub New(oID As Integer, iID As Integer, pID As Integer, pName As String, pending As Integer)
        InitializeComponent()
        orderID = oID
        itemID = iID
        productID = pID
        productName = pName
        pendingQty = pending
    End Sub

    Public Sub New(oID As Integer, iID As Integer, pID As Integer, pName As String, pending As Integer, parentForm As Form)
        InitializeComponent()
        orderID = oID
        itemID = iID
        productID = pID
        productName = pName
        pendingQty = pending
        _ParentForm = parentForm
    End Sub

    ' Enforce numbers-only input for quantities
    Private Sub txtQtyReceived_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQtyReceived.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtQtyDefective_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQtyDefective.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Ensure txtQtyDefective is not left blank by normalizing to 0 on leave
    Private Sub txtQtyDefective_Leave(sender As Object, e As EventArgs) Handles txtQtyDefective.Leave
        If String.IsNullOrWhiteSpace(txtQtyDefective.Text) Then
            txtQtyDefective.Text = "0"
        End If
    End Sub

    ' Make tbl_order_deliveries.productID nullable if it's currently NOT NULL to support supplier-only items
    Private Sub EnsureDeliveriesProductIdNullable()
        Try
            ' Try a simple MODIFY first
            Try
                Using simpleAlter As New Odbc.OdbcCommand("ALTER TABLE tbl_order_deliveries MODIFY COLUMN productID INT NULL", conn)
                    simpleAlter.ExecuteNonQuery()
                End Using
            Catch
                ' If fails (likely due to FK), try drop and recreate with ON DELETE SET NULL
                Try
                    Using dropFk As New Odbc.OdbcCommand("ALTER TABLE tbl_order_deliveries DROP FOREIGN KEY tbl_order_deliveries_ibfk_3", conn)
                        dropFk.ExecuteNonQuery()
                    End Using
                Catch
                    ' ignore if name mismatch
                End Try
                Using alterCol As New Odbc.OdbcCommand("ALTER TABLE tbl_order_deliveries MODIFY COLUMN productID INT NULL", conn)
                    alterCol.ExecuteNonQuery()
                End Using
                Try
                    Using addFk As New Odbc.OdbcCommand("ALTER TABLE tbl_order_deliveries ADD CONSTRAINT tbl_order_deliveries_ibfk_3 FOREIGN KEY (productID) REFERENCES tbl_products(productID) ON DELETE SET NULL ON UPDATE CASCADE", conn)
                        addFk.ExecuteNonQuery()
                    End Using
                Catch
                    ' ignore if cannot add; NULL column is the critical part for now
                End Try
            End Try
        Catch
            ' Ignore errors (e.g., insufficient privileges or already nullable)
        End Try
    End Sub

    Private Sub txtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        If String.IsNullOrWhiteSpace(txtRemarks.Text) Then
            txtRemarks.Text = "N/A"
        End If
    End Sub

    Private Sub txtRemarks_Validated(sender As Object, e As EventArgs) Handles txtRemarks.Validated
        If String.IsNullOrWhiteSpace(txtRemarks.Text) Then
            txtRemarks.Text = "N/A"
        End If
    End Sub

    ' Ensure a productName column exists on deliveries to store supplier item names
    Private Sub EnsureDeliveriesProductNameColumn()
        Try
            Try
                Using testCmd As New Odbc.OdbcCommand("SELECT productName FROM tbl_order_deliveries LIMIT 1", conn)
                    testCmd.ExecuteScalar()
                End Using
            Catch
                Using alterCmd As New Odbc.OdbcCommand("ALTER TABLE tbl_order_deliveries ADD COLUMN productName VARCHAR(255) NULL", conn)
                    alterCmd.ExecuteNonQuery()
                End Using
            End Try
        Catch
        End Try
    End Sub

    Private Sub ReceivedItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblProduct.Text = productName
        lblPending.Text = pendingQty.ToString()
        ' Set Received By to current user's full name and make it read-only
        Try
            txtReceivedBy.Text = GlobalVariables.LoggedInFullName
            txtReceivedBy.ReadOnly = True
        Catch
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim received As Integer
        Dim defective As Integer
        Dim remarks As String = txtRemarks.Text.Trim()
        Dim receivedBy As String = txtReceivedBy.Text.Trim()

        ' Remarks default when skipped
        If String.IsNullOrWhiteSpace(remarks) Then
            remarks = "N/A"
        End If

        ' Qty Received: numbers only, required, and must be > 0
        If Not Integer.TryParse(txtQtyReceived.Text.Trim(), received) OrElse received <= 0 Then
            MsgBox("Quantity Received must be a number greater than 0.", vbExclamation, "Invalid Input")
            Exit Sub
        End If

        ' Qty Defective: numbers only, required (cannot be blank), can be 0
        If Not Integer.TryParse(txtQtyDefective.Text.Trim(), defective) OrElse defective < 0 Then
            MsgBox("Quantity Defective must be a number 0 or greater.", vbExclamation, "Invalid Input")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(receivedBy) Then
            MsgBox("Please enter the name of the person who received the delivery.", vbExclamation, "Missing Info")
            Exit Sub
        End If

        If received + defective > pendingQty Then
            MsgBox("Total of received and defective exceeds pending quantity.", vbExclamation, "Input Error")
            Exit Sub
        End If

        Call dbConn()
        ' Ensure schema allows NULL productID for supplier-only items and name storage
        EnsureDeliveriesProductIdNullable()
        EnsureDeliveriesProductNameColumn()

        Dim sql As String = "INSERT INTO tbl_order_deliveries (orderID, itemID, productID, quantityReceived, quantityDefective, remarks, receivedBy, deliveryDate, deliveryStatus, productName) " &
                            "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim cmd As New Odbc.OdbcCommand(sql, conn)
        cmd.Parameters.AddWithValue("?", orderID)
        cmd.Parameters.AddWithValue("?", itemID)
        ' Allow NULL productID to satisfy FK when item is supplier-only (unmapped)
        Dim pIdParam As New Odbc.OdbcParameter("productID", Odbc.OdbcType.Int)
        If productID = 0 Then
            pIdParam.Value = DBNull.Value
        Else
            pIdParam.Value = productID
        End If
        cmd.Parameters.Add(pIdParam)
        cmd.Parameters.AddWithValue("?", received)
        cmd.Parameters.AddWithValue("?", defective)
        cmd.Parameters.AddWithValue("?", remarks)
        cmd.Parameters.AddWithValue("?", receivedBy)
        cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
        cmd.Parameters.AddWithValue("?", "Delivered")
        cmd.Parameters.AddWithValue("?", productName)

        Try
            cmd.ExecuteNonQuery()
            ' Immediately transfer this received quantity into inventory (even for partial)
            Try
                TransferThisDeliveryToInventory(received)
            Catch exX As Exception
                MsgBox("Transfer to inventory warning: " & exX.Message, vbExclamation, "Transfer")
            End Try

            ' Update the total amount in the order based on received items
            Try
                UpdateOrderTotalAmount(received)
            Catch exUpdate As Exception
                MsgBox("Warning: Could not update order total amount: " & exUpdate.Message, vbExclamation, "Update Warning")
            End Try

            DeliverySaved = True
            MsgBox("Delivery saved.", vbInformation, "Saved")
            Me.Close()
        Catch ex As Exception
            MsgBox("Error saving delivery: " & ex.Message, vbCritical, "Error")
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub

    Private Sub UpdateOrderTotalAmount(receivedQty As Integer)
        Dim trans As Odbc.OdbcTransaction = Nothing
        Try
            Call dbConn()
            If conn.State = ConnectionState.Closed Then conn.Open()
            trans = conn.BeginTransaction()

            ' Calculate the TOTAL VALUE of ALL received items for this order
            ' This will sum up all deliveries to show total received amount
            Dim totalReceivedAmount As Decimal = 0D
            Dim supplierID As Integer = 0

            ' Get the supplierID from the order
            Using getSupplierCmd As New Odbc.OdbcCommand("SELECT supplierID FROM tbl_productOrders WHERE orderID = ?", conn, trans)
                getSupplierCmd.Parameters.AddWithValue("?", orderID)
                Dim supplierObj = getSupplierCmd.ExecuteScalar()
                If supplierObj IsNot Nothing AndAlso supplierObj IsNot DBNull.Value Then
                    Integer.TryParse(supplierObj.ToString(), supplierID)
                End If
            End Using

            ' Calculate total value of all received items for this order
            If supplierID > 0 Then
                ' First try to get total from deliveries with matching supplier products
                Using calcCmd As New Odbc.OdbcCommand(
                    "SELECT " &
                    "  SUM(d.quantityReceived * COALESCE(sp.product_price, 0)) AS totalReceived " &
                    "FROM tbl_order_deliveries d " &
                    "LEFT JOIN tbl_supplier_products sp ON sp.supplierID = ? " &
                    "  AND (UPPER(TRIM(sp.product_name)) = UPPER(TRIM(d.productName)) " &
                    "       OR UPPER(TRIM(sp.product_name)) = UPPER(TRIM((SELECT poi.productName FROM tbl_productorder_items poi WHERE poi.orderID = d.orderID AND poi.itemID = d.itemID LIMIT 1)))) " &
                    "WHERE d.orderID = ? AND COALESCE(d.deliveryStatus, 'Delivered') = 'Delivered'", conn, trans)
                    calcCmd.Parameters.AddWithValue("?", supplierID)
                    calcCmd.Parameters.AddWithValue("?", orderID)
                    Dim result = calcCmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        Decimal.TryParse(result.ToString(), totalReceivedAmount)
                    End If
                End Using
            End If

            ' Update the total amount to reflect ONLY the received items value
            Using updateCmd As New Odbc.OdbcCommand("UPDATE tbl_productOrders SET totalAmount = ? WHERE orderID = ?", conn, trans)
                updateCmd.Parameters.Add(New Odbc.OdbcParameter("totalAmount", Odbc.OdbcType.Double)).Value = CDbl(totalReceivedAmount)
                updateCmd.Parameters.Add(New Odbc.OdbcParameter("orderID", Odbc.OdbcType.Int)).Value = orderID
                updateCmd.ExecuteNonQuery()
            End Using

            trans.Commit()

            ' Refresh OrderProduct form if it's open
            Dim orderForm As OrderProduct = Application.OpenForms().OfType(Of OrderProduct)().FirstOrDefault()
            If orderForm IsNot Nothing Then
                orderForm.LoadOrders()
            End If

        Catch ex As Exception
            Try
                If trans IsNot Nothing Then trans.Rollback()
            Catch
            End Try
            Throw
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub TransferThisDeliveryToInventory(receivedQty As Integer)
        Dim trans As Odbc.OdbcTransaction = Nothing
        Try
            Call dbConn()
            If conn.State = ConnectionState.Closed Then conn.Open()
            trans = conn.BeginTransaction()

            ' Resolve fields: supplierID, resolved product name, category, description
            Dim supplierID As Integer = 0
            Dim resolvedName As String = productName
            Dim category As String = "N/A"
            Dim desc As String = "N/A"

            Using infoCmd As New Odbc.OdbcCommand("SELECT o.supplierID, COALESCE(p.productName, ?, sp.product_name) AS pname, COALESCE(p.category, sp.category) AS cat, COALESCE(p.description, sp.description, 'N/A') AS descr FROM tbl_productOrders o LEFT JOIN tbl_products p ON p.productID = ? LEFT JOIN tbl_supplier_products sp ON sp.supplierID = o.supplierID AND (sp.product_name = ? OR sp.product_name = p.productName) WHERE o.orderID = ? LIMIT 1", conn, trans)
                infoCmd.Parameters.Clear()
                infoCmd.Parameters.Add(New Odbc.OdbcParameter("inName", Odbc.OdbcType.VarChar)).Value = productName
                infoCmd.Parameters.Add(New Odbc.OdbcParameter("pID", Odbc.OdbcType.Int)).Value = productID
                infoCmd.Parameters.Add(New Odbc.OdbcParameter("spName", Odbc.OdbcType.VarChar)).Value = productName
                infoCmd.Parameters.Add(New Odbc.OdbcParameter("ordID", Odbc.OdbcType.Int)).Value = orderID
                Using r = infoCmd.ExecuteReader()
                    If r.Read() Then
                        Integer.TryParse(Convert.ToString(r("supplierID")), supplierID)
                        resolvedName = Convert.ToString(r("pname")).Trim()
                        category = If(String.IsNullOrWhiteSpace(Convert.ToString(r("cat"))), "N/A", Convert.ToString(r("cat")).Trim())
                        desc = If(String.IsNullOrWhiteSpace(Convert.ToString(r("descr"))), "N/A", Convert.ToString(r("descr")).Trim())
                    End If
                End Using
            End Using

            If String.IsNullOrWhiteSpace(resolvedName) OrElse receivedQty <= 0 Then
                Throw New Exception("Invalid delivery data to transfer.")
            End If

            ' Check existing product by case-insensitive name
            Dim existingID As Integer = 0
            Using chk As New Odbc.OdbcCommand("SELECT productID FROM tbl_products WHERE LOWER(productName) = LOWER(?) LIMIT 1", conn, trans)
                chk.Parameters.Clear()
                chk.Parameters.Add(New Odbc.OdbcParameter("nm", Odbc.OdbcType.VarChar)).Value = resolvedName
                Dim obj = chk.ExecuteScalar()
                If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then Integer.TryParse(obj.ToString(), existingID)
            End Using

            If existingID > 0 Then
                Using upd As New Odbc.OdbcCommand("UPDATE tbl_products SET stockQuantity = IFNULL(stockQuantity,0) + ? WHERE productID = ?", conn, trans)
                    upd.Parameters.Clear()
                    upd.Parameters.Add(New Odbc.OdbcParameter("qty", Odbc.OdbcType.Int)).Value = receivedQty
                    upd.Parameters.Add(New Odbc.OdbcParameter("pid", Odbc.OdbcType.Int)).Value = existingID
                    upd.ExecuteNonQuery()
                End Using
            Else
                Using ins As New Odbc.OdbcCommand("INSERT INTO tbl_products (productName, category, stockQuantity, unitPrice, description, reorderLevel, dateAdded, supplierID, discount, discountAppliedDate) VALUES (?,?,?,?,?,?,?,?,?,?)", conn, trans)
                    ins.Parameters.Clear()
                    ins.Parameters.Add(New Odbc.OdbcParameter("productName", Odbc.OdbcType.VarChar)).Value = resolvedName
                    ins.Parameters.Add(New Odbc.OdbcParameter("category", Odbc.OdbcType.VarChar)).Value = category
                    ins.Parameters.Add(New Odbc.OdbcParameter("stockQuantity", Odbc.OdbcType.Int)).Value = receivedQty
                    ins.Parameters.Add(New Odbc.OdbcParameter("unitPrice", Odbc.OdbcType.Double)).Value = CDbl(0)
                    ins.Parameters.Add(New Odbc.OdbcParameter("description", Odbc.OdbcType.VarChar)).Value = desc
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
            Throw
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
