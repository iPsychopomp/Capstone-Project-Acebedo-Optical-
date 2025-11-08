Public Class OrderProduct

    Private Sub OrderProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmbSuppliers.AutoCompleteSource = AutoCompleteSource.ListItems
            cmbSuppliers.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Catch
            cmbSuppliers.AutoCompleteMode = AutoCompleteMode.None
        End Try

        ' Ensure database schema is updated (runs once per session)
        EnsureOrderItemsProductIDNullable()

        ' Load suppliers first; products will be bound when a supplier is selected
        LoadSuppliers()
        ' Only load global suggestions if no supplier is selected
        If cmbSuppliers.SelectedIndex = -1 Then
            LoadProductSuggestions()
        End If
        LoadOrders()
        txtTotal.Text = "0.00"
        DgvStyle(dgvSelectedProducts)
        DgvStyle(dgvOrders)
        HideProductIDColumn()

        ' Removed in-tab delivery history grid

        ' Set Ordered By to logged-in user's full name and lock editing
        Try
            txtOrderedBy.Text = GlobalVariables.LoggedInFullName
            txtOrderedBy.ReadOnly = True
        Catch
        End Try

    End Sub

    Private Sub HideProductIDColumn()
        Try
            If dgvSelectedProducts IsNot Nothing AndAlso dgvSelectedProducts.Columns.Contains("productID") Then
                dgvSelectedProducts.Columns("productID").Visible = True
            End If
        Catch
        End Try
    End Sub

    ' Removed in-tab delivery history grid and related loaders/handlers

    ' Ensure order transactions table exists
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
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' Insert a transaction record
    Private Sub LogOrderTransaction(orderID As Integer, status As String, remarks As String)
        Try
            EnsureOrderTransactionsTable()
            Call dbConn()
            Using cmd As New Odbc.OdbcCommand("INSERT INTO tbl_order_transactions (orderID, status, remarks, actionTime) VALUES (?, ?, ?, ?)", conn)
                cmd.Parameters.AddWithValue("?", orderID)
                cmd.Parameters.AddWithValue("?", status)
                cmd.Parameters.AddWithValue("?", remarks)
                cmd.Parameters.AddWithValue("?", DateTime.Now)
                cmd.ExecuteNonQuery()
            End Using
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub EnsureOrderItemsProductNameColumn()
        Try
            Call dbConn()
            ' Try selecting the column; if it fails, create it
            Try
                Using testCmd As New Odbc.OdbcCommand("SELECT productName FROM tbl_productOrder_items LIMIT 1", conn)
                    testCmd.ExecuteScalar()
                End Using
            Catch
                Using alterCmd As New Odbc.OdbcCommand("ALTER TABLE tbl_productOrder_items ADD COLUMN productName VARCHAR(255) NULL", conn)
                    alterCmd.ExecuteNonQuery()
                End Using
            End Try
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Shared schemaUpdated As Boolean = False

    Private Sub EnsureOrderItemsProductIDNullable()
        ' Only run this once per application session to avoid performance issues
        If schemaUpdated Then Return

        Try
            Call dbConn()

            ' Check if productID is already nullable by checking column definition
            Dim isNullable As Boolean = False
            Try
                Using checkCmd As New Odbc.OdbcCommand("SELECT IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'tbl_productorder_items' AND COLUMN_NAME = 'productID'", conn)
                    Dim result = checkCmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso result.ToString().ToUpper() = "YES" Then
                        isNullable = True
                    End If
                End Using
            Catch
                ' If we can't check, assume we need to update
            End Try

            ' If already nullable, no need to modify
            If isNullable Then
                schemaUpdated = True
                Return
            End If

            ' Drop the foreign key constraint that references tbl_products
            Try
                Using dropFkCmd As New Odbc.OdbcCommand("ALTER TABLE tbl_productorder_items DROP FOREIGN KEY tbl_productorder_items_ibfk_2", conn)
                    dropFkCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                ' Log the error but continue - constraint might not exist
                Console.WriteLine("Could not drop FK constraint: " & ex.Message)
            End Try

            ' Make productID nullable
            Try
                Using alterCmd As New Odbc.OdbcCommand("ALTER TABLE tbl_productorder_items MODIFY COLUMN productID INT NULL", conn)
                    alterCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                ' Log the error
                Console.WriteLine("Could not modify productID column: " & ex.Message)
            End Try

            schemaUpdated = True
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Function GetSupplierItemUnitPrice(supplierID As Integer, productName As String) As Decimal
        Dim price As Decimal = 0D
        Try
            Call dbConn()
            Dim sql As String = "SELECT product_price FROM tbl_supplier_products WHERE supplierID = ? AND UPPER(TRIM(product_name)) = UPPER(TRIM(?)) LIMIT 1"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", supplierID)
                cmd.Parameters.AddWithValue("?", productName)
                Dim obj = cmd.ExecuteScalar()
                If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                    Decimal.TryParse(obj.ToString(), price)
                End If
            End Using
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
        Return price
    End Function

    Private Function GetSupplierItemCategory(supplierID As Integer, productName As String) As String
        Dim category As String = String.Empty
        Try
            Call dbConn()
            Dim sql As String = "SELECT category FROM tbl_supplier_products WHERE supplierID = ? AND UPPER(TRIM(product_name)) = UPPER(TRIM(?)) LIMIT 1"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", supplierID)
                cmd.Parameters.AddWithValue("?", productName)
                Dim obj = cmd.ExecuteScalar()
                If obj IsNot Nothing Then category = obj.ToString()
            End Using
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
        Return category
    End Function

    Private Function GetSupplierProductID(supplierID As Integer, productName As String) As Integer
        Dim productID As Integer = 0
        Try
            Call dbConn()
            Dim sql As String = "SELECT sProductID FROM tbl_supplier_products WHERE supplierID = ? AND UPPER(TRIM(product_name)) = UPPER(TRIM(?)) LIMIT 1"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", supplierID)
                cmd.Parameters.AddWithValue("?", productName)
                Dim obj = cmd.ExecuteScalar()
                If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                    Integer.TryParse(obj.ToString(), productID)
                End If
            End Using
        Catch
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
        Return productID
    End Function
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
        dgvDeliveryHistory.DefaultCellStyle.ForeColor = Color.Black
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

        ' If this is dgvSelectedProducts, set up its columns
        If dgvDeliveryHistory Is dgvSelectedProducts Then
            SetupSelectedProductsColumns(dgvDeliveryHistory)
        End If
    End Sub

    Private Sub SetupSelectedProductsColumns(ByRef dgv As DataGridView)
        Try
            dgv.Columns.Clear()
            dgv.Columns.Add("productID", "Product ID")
            dgv.Columns.Add("ProductName", "Product Name")
            dgv.Columns.Add("Category", "Category")
            dgv.Columns.Add("UnitPrice", "Unit Price")
            dgv.Columns.Add("Quantity", "Quantity")
            dgv.Columns.Add("Supplier", "Supplier")
            dgv.Columns.Add("Total", "Total")

            ' Set column properties
            dgv.Columns("UnitPrice").DefaultCellStyle.Format = "C2"
            dgv.Columns("Total").DefaultCellStyle.Format = "C2"
            dgv.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox("Error setting up DataGridView columns: " & ex.Message, vbCritical, "Column Setup Error")
        End Try
    End Sub

    Private Sub LoadLowStockProducts()
        dgvSelectedProducts.Rows.Clear()

        If cmbSuppliers.SelectedIndex = -1 OrElse cmbSuppliers.SelectedValue Is Nothing Then Exit Sub

        Dim supplierID As Integer
        If Not Integer.TryParse(cmbSuppliers.SelectedValue.ToString(), supplierID) Then Exit Sub

        Try
            Call dbConn()
            Dim sql As String = "SELECT p.productID, sp.product_name AS productName, sp.category, sp.product_price, p.stockQuantity, p.reorderLevel, s.supplierName " & _
                                "FROM tbl_products p " & _
                                "JOIN tbl_suppliers s ON p.supplierID = s.supplierID " & _
                                "JOIN tbl_supplier_products sp ON sp.supplierID = p.supplierID " & _
                                "  AND UPPER(TRIM(sp.product_name)) = UPPER(TRIM(p.productName)) " & _
                                "WHERE p.stockQuantity <= p.reorderLevel AND p.supplierID = ?"

            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", supplierID)
                Using reader As Odbc.OdbcDataReader = cmd.ExecuteReader()
                    ' Ensure columns are set up before adding rows
                    SetupSelectedProductsColumns(dgvSelectedProducts)
                    While reader.Read()
                        Dim totalPrice As Decimal = Convert.ToDecimal(reader("product_price")) * 1 ' default quantity = 1
                        dgvSelectedProducts.Rows.Add(
                            reader("productID"),
                            reader("productName").ToString(),
                            reader("category").ToString(),
                            reader("product_price"),
                            20,
                            reader("supplierName").ToString(),
                            totalPrice.ToString("0.00")
                        )
                    End While
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Error loading low stock products: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            UpdateTotalAmount()
            DgvStyle(dgvSelectedProducts)
        End Try
    End Sub


    Private Sub LoadSuppliers()
        Try
            Call dbConn()
            Dim dt As New DataTable
            Dim query As String = "SELECT supplierID, supplierName FROM tbl_suppliers"
            Using cmd As New Odbc.OdbcCommand(query, conn)
                Dim da As New Odbc.OdbcDataAdapter(cmd)
                da.Fill(dt)
            End Using

            cmbSuppliers.DataSource = dt
            cmbSuppliers.DisplayMember = "supplierName"
            cmbSuppliers.ValueMember = "supplierID"
            cmbSuppliers.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("Error loading suppliers: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
        UpdateTotalAmount()
        DgvStyle(dgvSelectedProducts)
        HideProductIDColumn()

    End Sub

    Private Sub LoadProductSuggestions()
        Try
            Call dbConn()

            Dim sql As String = "SELECT productName FROM tbl_products"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            ' Ensure DataSource is not set when using Items collection
            cmbProducts.DataSource = Nothing
            cmbProducts.Items.Clear()

            While reader.Read()
                cmbProducts.Items.Add(reader("productName").ToString())
            End While

            reader.Close()
            conn.Close()

        Catch ex As Exception
            MsgBox("Error loading product suggestions: " & ex.Message)
        End Try
        DgvStyle(dgvSelectedProducts)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgvSelectedProducts.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In dgvSelectedProducts.SelectedRows
                dgvSelectedProducts.Rows.Remove(row)
            Next
        Else
            MsgBox("Please select a product to remove.")
        End If
        UpdateTotalAmount()
        DgvStyle(dgvSelectedProducts)
        HideProductIDColumn()
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If cmbProducts.SelectedIndex = -1 OrElse cmbSuppliers.SelectedIndex = -1 Then
                MsgBox("Please select both product and supplier.", vbCritical, "Error")
                Exit Sub
            End If

            Dim selectedProductName As String = cmbProducts.Text

            Dim selectedSupplierID As Integer = 0
            If Not Integer.TryParse(Convert.ToString(cmbSuppliers.SelectedValue), selectedSupplierID) Then
                MsgBox("Please select a valid supplier.", vbCritical, "Error")
                Exit Sub
            End If

            ' Get price and category from tbl_supplier_products (supplier's catalog)
            Dim productCategory As String = GetSupplierItemCategory(selectedSupplierID, selectedProductName)
            Dim unitPrice As Decimal = GetSupplierItemUnitPrice(selectedSupplierID, selectedProductName)

            ' Validate that product exists in supplier catalog
            If unitPrice = 0 Then
                MsgBox("Product not found in supplier catalog or missing price information.", vbExclamation, "Error")
                Exit Sub
            End If

            ' Try to get productID from tbl_products (main inventory)
            ' If not found, productID will be 0 (NULL in database)
            Dim productID As Integer = 0
            Dim productIDStr As String = GetProductID(selectedProductName)
            If Not String.IsNullOrEmpty(productIDStr) Then
                Integer.TryParse(productIDStr, productID)
            End If

            Dim selectedSupplier As String = GetSupplierNameByID(selectedSupplierID)
            Dim quantity As Integer = 1 ' Default quantity
            If Not Integer.TryParse(numQuantity.Value.ToString(), quantity) OrElse quantity <= 0 Then
                MsgBox("Please enter a valid quantity (must be greater than 0).", vbCritical, "Error")
                Exit Sub
            End If
            Dim totalPrice As Decimal = unitPrice * quantity

            ' Ensure columns are set up only if not already configured
            If dgvSelectedProducts.Columns.Count = 0 Then
                SetupSelectedProductsColumns(dgvSelectedProducts)
            End If

            ' Validate that columns are properly set up
            If dgvSelectedProducts.Columns.Count < 7 Then
                MsgBox("DataGridView columns are not properly configured. Please restart the application.", vbCritical, "Configuration Error")
                Exit Sub
            End If

            ' Check if product already exists in the grid
            Dim existingRow As DataGridViewRow = Nothing
            For Each row As DataGridViewRow In dgvSelectedProducts.Rows
                If Not row.IsNewRow Then
                    Dim rowProductName As String = Convert.ToString(row.Cells("ProductName").Value)
                    If rowProductName.Equals(selectedProductName, StringComparison.OrdinalIgnoreCase) Then
                        existingRow = row
                        Exit For
                    End If
                End If
            Next

            If existingRow IsNot Nothing Then
                ' Product exists, update quantity and total
                Dim currentQty As Integer = Convert.ToInt32(existingRow.Cells("Quantity").Value)
                Dim newQty As Integer = currentQty + quantity
                existingRow.Cells("Quantity").Value = newQty
                existingRow.Cells("Total").Value = (unitPrice * newQty).ToString("0.00")
            Else
                ' Product doesn't exist, add new row
                dgvSelectedProducts.Rows.Add(productID, selectedProductName, productCategory, unitPrice, quantity, selectedSupplier, totalPrice.ToString("0.00"))
            End If

            ' Refresh the DataGridView to ensure the new row is visible
            dgvSelectedProducts.Refresh()

            ' Reset the product selection to allow adding the same product again
            cmbProducts.SelectedIndex = -1
            numQuantity.Value = 1

            ' Show success feedback
            'MsgBox("Product added successfully! You can add more items from the same supplier.", vbInformation, "Success")

        Catch ex As Exception
            MsgBox("Error adding product: " & ex.Message, vbCritical, "Error")
        End Try

        UpdateTotalAmount()

    End Sub

    Private Function GetSupplierNameByID(supplierID As Integer) As String
        Dim supplierName As String = String.Empty
        Try
            Call dbConn()
            Dim sql As String = "SELECT supplierName FROM tbl_suppliers WHERE supplierID = ?"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", supplierID)
                Dim obj = cmd.ExecuteScalar()
                If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                    supplierName = obj.ToString()
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error fetching supplier name: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        Return supplierName
    End Function

    Private Function GetProductID(productName As String) As String
        Dim productID As String = String.Empty
        Try
            Call dbConn()

            Dim sql As String = "SELECT productID FROM tbl_products WHERE productName = ?"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", productName)
                Dim obj = cmd.ExecuteScalar()
                If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                    productID = obj.ToString()
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error fetching product ID: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        Return productID
    End Function

    Private Function GetProductCategory(productID As String) As String
        Dim category As String = String.Empty
        Try
            Call dbConn()

            Dim sql As String = "SELECT category FROM tbl_products WHERE productID = ?"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", productID)
                Dim obj = cmd.ExecuteScalar()
                If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                    category = obj.ToString()
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error fetching product category: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        Return category
    End Function

    Private Function GetUnitPrice(productID As String) As Decimal
        Dim unitPrice As Decimal = 0
        Try
            Call dbConn()
            Dim sql As String = "SELECT unitPrice FROM tbl_products WHERE productID = ?"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", productID)
                Dim obj = cmd.ExecuteScalar()
                If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                    Decimal.TryParse(obj.ToString(), unitPrice)
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error fetching unit price: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        Return unitPrice
    End Function

    Private Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click
        ' Validate supplier selection
        If cmbSuppliers.SelectedIndex = -1 OrElse cmbSuppliers.SelectedValue Is Nothing OrElse String.IsNullOrWhiteSpace(cmbSuppliers.Text) Then
            MsgBox("Please select a supplier.", vbExclamation, "Required")
            Exit Sub
        End If

        ' Validate at least one item
        Dim itemCount As Integer = 0
        For Each r As DataGridViewRow In dgvSelectedProducts.Rows
            If Not r.IsNewRow Then itemCount += 1
        Next
        If itemCount = 0 Then
            MsgBox("Please add at least one item before placing an order.", vbExclamation, "No Items")
            Exit Sub
        End If

        ' Validate Ordered By
        If String.IsNullOrWhiteSpace(txtOrderedBy.Text) Then
            MsgBox("Please enter the name in 'Ordered By'.", vbExclamation, "Required")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to place this order?", vbQuestion + vbYesNo, "Confirm") = vbNo Then Exit Sub

        Dim transaction As Odbc.OdbcTransaction = Nothing

        Try
            Call dbConn()
            If conn.State = ConnectionState.Closed Then conn.Open()

            transaction = conn.BeginTransaction()

            Dim cmd As New Odbc.OdbcCommand()
            cmd.Connection = conn
            cmd.Transaction = transaction
            cmd.CommandText = "INSERT INTO tbl_productOrders (orderDate, supplierID, totalAmount, status, orderedBy) VALUES (?, ?, ?, ?, ?)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add(New Odbc.OdbcParameter("orderDate", Odbc.OdbcType.DateTime)).Value = dtpDate.Value
            cmd.Parameters.Add(New Odbc.OdbcParameter("supplierID", Odbc.OdbcType.Int)).Value = Convert.ToInt32(cmbSuppliers.SelectedValue)

            Dim totalAmount As Double
            If Double.TryParse(txtTotal.Text, totalAmount) Then
                cmd.Parameters.Add(New Odbc.OdbcParameter("totalAmount", Odbc.OdbcType.Double)).Value = totalAmount
            Else
                MsgBox("Invalid total amount.", vbExclamation, "Error")
                Exit Sub
            End If

            cmd.Parameters.Add(New Odbc.OdbcParameter("status", Odbc.OdbcType.VarChar)).Value = "Placed Order"
            cmd.Parameters.Add(New Odbc.OdbcParameter("orderedBy", Odbc.OdbcType.VarChar)).Value = txtOrderedBy.Text.Trim()

            cmd.ExecuteNonQuery()

            cmd.CommandText = "SELECT LAST_INSERT_ID()"
            cmd.Parameters.Clear()
            Dim orderID As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            ' Ensure productName column exists in tbl_productOrder_items
            EnsureOrderItemsProductNameColumn()

            For Each row As DataGridViewRow In dgvSelectedProducts.Rows
                If Not row.IsNewRow Then
                    Dim productID As Integer = 0
                    Integer.TryParse(Convert.ToString(row.Cells("ProductID").Value), productID)
                    Dim quantity As Integer = Convert.ToInt32(row.Cells("Quantity").Value)
                    Dim prodName As String = Convert.ToString(row.Cells("ProductName").Value)

                    ' Always insert productName; productID may be NULL for supplier-only items
                    cmd.CommandText = "INSERT INTO tbl_productOrder_items (orderID, productID, quantity, productName) VALUES (?, ?, ?, ?)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New Odbc.OdbcParameter("orderID", Odbc.OdbcType.Int)).Value = orderID
                    Dim p As New Odbc.OdbcParameter("productID", Odbc.OdbcType.Int)
                    If productID = 0 Then
                        p.Value = DBNull.Value
                    Else
                        p.Value = productID
                    End If
                    cmd.Parameters.Add(p)
                    cmd.Parameters.Add(New Odbc.OdbcParameter("quantity", Odbc.OdbcType.Int)).Value = quantity
                    cmd.Parameters.Add(New Odbc.OdbcParameter("productName", Odbc.OdbcType.VarChar)).Value = prodName
                    cmd.ExecuteNonQuery()
                End If
            Next

            transaction.Commit()
            InsertAuditTrail(GlobalVariables.LoggedInUserID, "Place Order", "Placed a new order with Order ID: " & orderID & " and Total Amount: " & totalAmount)
            LogOrderTransaction(orderID, "Placed Order", "Order placed by " & txtOrderedBy.Text.Trim())
            MsgBox("Order placed successfully!", vbInformation, "Success")

            ' === SHOW ORDER PRODUCT REPORT IMMEDIATELY ===
            Dim reportForm As New Reports()

            ' Set the report type directly to "Order Products"
            reportForm.cboReportType.SelectedItem = "Order Products"
            reportForm.cboReportType.Visible = False
            reportForm.dtpFROM.Visible = False
            reportForm.dtpTO.Visible = False
            reportForm.dtpYear.Visible = False
            reportForm.btnGenerate.Visible = False

            ' Generate the report before showing it
            reportForm.GenerateOrderProductReport(dtpDate.Value)

            ' Set the form to appear on top


            reportForm.TopMost = True


            reportForm.BringToFront()


            reportForm.StartPosition = FormStartPosition.CenterScreen



            ' Show the report as a modal dialog (wait until closed)


            reportForm.ShowDialog(Me)



            ' Reset TopMost after closing


            reportForm.TopMost = False

            ' Refresh and reset form after viewing report
            ResetForm()
            LoadOrders()

            ' Switch to Order History tab
            If TabControl1 IsNot Nothing AndAlso TabControl1.TabPages.Count > 1 Then
                TabControl1.SelectedIndex = 1
            End If

        Catch ex As Exception
            If transaction IsNot Nothing Then
                Try
                    transaction.Rollback()
                Catch rollbackEx As Exception
                    MsgBox("Rollback failed: " & rollbackEx.Message, vbCritical, "Rollback Error")
                End Try
            End If
            MsgBox("Error placing order: " & ex.Message, vbCritical, "Error")

        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        DgvStyle(dgvSelectedProducts)
    End Sub


    Private Sub ResetForm()
        cmbSuppliers.SelectedIndex = -1

        dgvSelectedProducts.Rows.Clear()

        dtpDate.Value = Date.Now

        txtTotal.Text = "0.00"
        ' Keep Ordered By as the logged-in username
        Try
            txtOrderedBy.Text = GlobalVariables.LoggedInUser
            txtOrderedBy.ReadOnly = True
        Catch
        End Try
        numQuantity.Value = 0

        cmbProducts.SelectedIndex = -1
        DgvStyle(dgvSelectedProducts)
    End Sub

    Private Sub UpdateTotalAmount()
        Dim total As Decimal = 0D

        For Each row As DataGridViewRow In dgvSelectedProducts.Rows
            If Not row.IsNewRow Then

                Dim value As Object = row.Cells("Total").Value
                If value IsNot DBNull.Value AndAlso value IsNot Nothing Then
                    Dim price As Decimal
                    If Decimal.TryParse(value.ToString(), price) Then
                        total += price
                    End If
                End If
            End If
        Next
        txtTotal.Text = total.ToString("0.00")
        ' Columns are already properly configured, no need to call DgvStyle here
    End Sub

    Public Sub LoadOrders()
        Call dbConn()
        Call LoadDGV("SELECT * FROM db_viewOrderProducts", dgvOrders)
        DgvStyle(dgvSelectedProducts)
        ' Removed in-tab history refresh
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReceived_Click(sender As Object, e As EventArgs) Handles btnReceived.Click
        If dgvOrders.SelectedRows.Count > 0 Then
            Dim selectedOrderID As Integer = Convert.ToInt32(dgvOrders.SelectedRows(0).Cells("OrderID").Value)

            Call dbConn()

            Dim orderStatus As String = ""
            Dim checkStatusSql As String = "SELECT status FROM tbl_productorders WHERE orderID = ?"
            Using cmd As New Odbc.OdbcCommand(checkStatusSql, conn)
                cmd.Parameters.AddWithValue("?", selectedOrderID)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    orderStatus = result.ToString()
                Else
                    MsgBox("Order status not found.", vbExclamation, "Error")
                    conn.Close()
                    Exit Sub
                End If
            End Using

            conn.Close()

            Dim receiveForm As New checkProducts(selectedOrderID, orderStatus, Me)
            AddHandler receiveForm.FormClosed, Sub(s, ev)
                                                   LoadOrders()
                                               End Sub

            receiveForm.TopMost = True
            receiveForm.ShowDialog()
        Else
            MsgBox("Please select an order to receive.", vbExclamation, "No Order Selected")
        End If
        DgvStyle(dgvSelectedProducts)
    End Sub

    Private Sub btnCancelOrder_Click(sender As Object, e As EventArgs) Handles btnCancelOrder.Click
        If dgvOrders.SelectedRows.Count = 0 Then
            MsgBox("Please select an order to cancel.", vbExclamation, "No Selection")
            Exit Sub
        End If

        Dim selectedOrderID As Integer = Convert.ToInt32(dgvOrders.SelectedRows(0).Cells("OrderID").Value)
        If MsgBox("Are you sure you want to cancel this order?", vbYesNo + vbQuestion, "Confirm Cancel") = vbNo Then Exit Sub

        Try
            Call dbConn()

            Dim currentStatus As String = ""
            Dim statusCheckCmd As New Odbc.OdbcCommand("SELECT status FROM tbl_productOrders WHERE orderID = ?", conn)
            statusCheckCmd.Parameters.AddWithValue("?", selectedOrderID)
            currentStatus = statusCheckCmd.ExecuteScalar().ToString()

            If currentStatus = "Cancelled" OrElse currentStatus = "Completed" Then
                MsgBox("This order is already cancelled or completed.", vbInformation, "Already Processed")
            ElseIf currentStatus = "Received" Then
                MsgBox("This order has already been received and cannot be cancelled.", vbExclamation, "Cannot Cancel")
            ElseIf currentStatus = "Partial" OrElse currentStatus = "To Be Followed" OrElse currentStatus = "Incomplete" Then
                MsgBox("This order has partial deliveries. Cancelled in Check Products.", vbInformation, "Use Check Product")
            Else
                Dim updateCmd As New Odbc.OdbcCommand("UPDATE tbl_productOrders SET status = 'Cancelled' WHERE orderID = ?", conn)
                updateCmd.Parameters.AddWithValue("?", selectedOrderID)
                updateCmd.ExecuteNonQuery()

                MsgBox("Order has been cancelled successfully.", vbInformation, "Cancelled")
                LoadOrders()
            End If

            conn.Close()
        Catch ex As Exception
            MsgBox("Error cancelling order: " & ex.Message, vbCritical, "Error")
        End Try
        DgvStyle(dgvSelectedProducts)
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
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub dgvOrders_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrders.CellDoubleClick
        If e.RowIndex >= 0 Then
            Try
                Dim selectedRow As DataGridViewRow = dgvOrders.Rows(e.RowIndex)
                Dim selectedOrderID As Integer = Convert.ToInt32(selectedRow.Cells("OrderID").Value)
                Dim status As String = selectedRow.Cells("status").Value.ToString()

                ' Check if order is cancelled
                If status.ToLower() = "cancelled" Then
                    MsgBox("No delivery history because this order is cancelled.", vbInformation, "Order Cancelled")
                    Exit Sub
                Else
                    ' For all other statuses (including partial), show delivery history
                    Dim deliveryHistoryForm As New DeliverHistory(selectedOrderID, Me)

                    ' When DeliverHistory closes, show OrderProduct again
                    AddHandler deliveryHistoryForm.FormClosed, Sub(s, ev)
                                                                   Me.Show()
                                                               End Sub

                    Me.Hide()
                    deliveryHistoryForm.TopMost = True
                    deliveryHistoryForm.ShowDialog(Me)
                End If
            Catch ex As Exception
                Me.Show()
                MsgBox("Error opening form: " & ex.Message, vbCritical, "Error")
            End Try
        End If
        DgvStyle(dgvSelectedProducts)
    End Sub

    Private Sub cmbSuppliers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSuppliers.SelectedIndexChanged
        Dim supplierID As Integer
        If Not TryGetSelectedSupplierID(supplierID) Then Exit Sub
        ' Reset current selection and clear any auto-added rows
        dgvSelectedProducts.Rows.Clear()
        UpdateTotalAmount()
        LoadProductsBySupplier(supplierID)
        DgvStyle(dgvSelectedProducts)
        HideProductIDColumn()
    End Sub

    ' Ensure filtering triggers only on user commit as well
    Private Sub cmbSuppliers_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSuppliers.SelectionChangeCommitted
        Dim supplierID As Integer
        If Not TryGetSelectedSupplierID(supplierID) Then Exit Sub
        dgvSelectedProducts.Rows.Clear()
        UpdateTotalAmount()
        LoadProductsBySupplier(supplierID)
    End Sub

    Private Function TryGetSelectedSupplierID(ByRef supplierID As Integer) As Boolean
        supplierID = 0
        If cmbSuppliers.SelectedValue Is Nothing Then Return False
        ' Handle cases where SelectedValue is a DataRowView
        If TypeOf cmbSuppliers.SelectedValue Is DataRowView Then
            Dim drv As DataRowView = DirectCast(cmbSuppliers.SelectedValue, DataRowView)
            If drv.Row.Table.Columns.Contains("supplierID") Then
                supplierID = Convert.ToInt32(drv("supplierID"))
                Return True
            Else
                Return False
            End If
        End If
        ' Normal case where SelectedValue is the ID
        If Integer.TryParse(cmbSuppliers.SelectedValue.ToString(), supplierID) Then
            Return True
        End If
        Return False
    End Function

    Private Sub LoadProductsBySupplier(supplierID As Integer)
        Try
            Call dbConn()
            ' Build supplier catalog list and map to existing tbl_products by exact name match (case-insensitive)
            Dim dt As New DataTable()
            dt.Columns.Add("productID", GetType(Integer))
            dt.Columns.Add("productName", GetType(String))

            Dim q As String = _
                "SELECT sp.product_name, COALESCE(p.productID, 0) AS productID " & _
                "FROM tbl_supplier_products sp " & _
                "LEFT JOIN tbl_products p ON p.supplierID = sp.supplierID " & _
                "  AND UPPER(TRIM(p.productName)) = UPPER(TRIM(sp.product_name)) " & _
                "WHERE sp.supplierID = ? " & _
                "ORDER BY sp.product_name"

            Using cmd As New Odbc.OdbcCommand(q, conn)
                cmd.Parameters.AddWithValue("?", supplierID)
                Using rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim r = dt.NewRow()
                        r("productID") = If(IsDBNull(rdr("productID")), 0, Convert.ToInt32(rdr("productID")))
                        r("productName") = rdr("product_name").ToString()
                        dt.Rows.Add(r)
                    End While
                End Using
            End Using

            ' Clear previous data/suggestions to avoid mixing
            cmbProducts.DataSource = Nothing
            cmbProducts.Items.Clear()

            cmbProducts.DataSource = dt
            cmbProducts.DisplayMember = "productName"
            cmbProducts.ValueMember = "productID"
            cmbProducts.SelectedIndex = -1
            ' Safe autocomplete for DropDownList: use None to avoid NotSupportedException
            cmbProducts.AutoCompleteSource = AutoCompleteSource.ListItems
            cmbProducts.AutoCompleteMode = AutoCompleteMode.None
            cmbProducts.Text = String.Empty
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList

            If dt.Rows.Count = 0 Then
                MsgBox("No supplier items found for the selected supplier.", vbInformation, "No Items")
            End If
        Catch ex As Exception
            MsgBox("Error loading products: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
        UpdateTotalAmount()
        DgvStyle(dgvSelectedProducts)
    End Sub

    Private Sub dgvOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrders.CellContentClick

    End Sub
End Class