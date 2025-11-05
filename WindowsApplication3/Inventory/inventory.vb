Public Class inventory
    Private Sub inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Allow columns to be auto-generated from data
        If productDGV IsNot Nothing Then
            productDGV.AllowUserToOrderColumns = False
        End If
        LoadProductsWithDiscountCheck()
        DgvStyle(productDGV)
        txtSearch.Text = "Search by product name"
        txtSearch.ForeColor = Color.Gray

        ' Hide Add, Edit, Supplier buttons for Receptionist and Doctor/Optometrist
        If LoggedInRole = "Receptionist" OrElse LoggedInRole = "Doctor" OrElse LoggedInRole = "Optometrist" Then
            btnAdd.Visible = False
            btnEdit.Visible = False
            btnSupplier.Visible = False
        End If
    End Sub

    ' Load products with discount column check
    Public Sub LoadProductsWithDiscountCheck()
        EnsureDiscountColumn()
        SafeLoadProducts()
    End Sub
    Public Sub DgvStyle(ByRef productDGV As DataGridView)
        ' Basic Grid Setup
        productDGV.AutoGenerateColumns = False
        productDGV.AllowUserToAddRows = False
        productDGV.AllowUserToDeleteRows = False
        productDGV.RowHeadersVisible = False
        productDGV.BorderStyle = BorderStyle.FixedSingle
        productDGV.BackgroundColor = Color.White
        productDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        productDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        productDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        productDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        productDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        productDGV.EnableHeadersVisualStyles = False
        productDGV.DefaultCellStyle.ForeColor = Color.Black
        productDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        productDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        productDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        productDGV.GridColor = Color.Silver
        productDGV.DefaultCellStyle.Padding = New Padding(5)
        productDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        productDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        productDGV.ReadOnly = True
        productDGV.MultiSelect = False
        productDGV.AllowUserToResizeRows = False
        productDGV.RowTemplate.Height = 30
        productDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        productDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        ' Center align all column headers
        For Each col As DataGridViewColumn In productDGV.Columns
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub

    ' Helper method to ensure discount columns exist
    Private Sub EnsureDiscountColumn()
        Try
            Call dbConn()

            ' Try to select from discount column directly to test if it exists
            Try
                Dim testCmd As New Odbc.OdbcCommand("SELECT discount FROM tbl_products LIMIT 1", conn)
                testCmd.ExecuteScalar()
                ' If we get here, discount column exists
            Catch testEx As Exception
                ' Column doesn't exist, create it
                Try
                    Dim alterCmd As New Odbc.OdbcCommand("ALTER TABLE tbl_products ADD COLUMN discount DECIMAL(5,4) DEFAULT 0.0000", conn)
                    alterCmd.ExecuteNonQuery()
                Catch alterEx As Exception
                    ' Ignore errors here since addProduct will handle it
                End Try
            End Try

            ' Try to select from discountAppliedDate column to test if it exists
            Try
                Dim testCmd2 As New Odbc.OdbcCommand("SELECT discountAppliedDate FROM tbl_products LIMIT 1", conn)
                testCmd2.ExecuteScalar()
                ' If we get here, discountAppliedDate column exists
            Catch testEx2 As Exception
                ' Column doesn't exist, create it
                Try
                    Dim alterCmd2 As New Odbc.OdbcCommand("ALTER TABLE tbl_products ADD COLUMN discountAppliedDate DATE DEFAULT NULL", conn)
                    alterCmd2.ExecuteNonQuery()
                Catch alterEx2 As Exception
                    ' Ignore errors here since addProduct will handle it
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

    Public Sub ShowLowStockItems()
        Try
            Call dbConn()

            Dim hasDiscount As Boolean = ColumnExists("tbl_products", "discount")

            ' SQL query to get all products, with low-stock items first (including out of stock items)
            Dim selectCore As String
            If hasDiscount Then
                selectCore = _
                    "SELECT p.productID, p.productName, p.category, p.stockQuantity, p.description, " & _
                    "p.unitPrice, CONCAT(ROUND(p.discount * 100, 2), '%') AS discount, " & _
                    "CASE WHEN p.discount > 0 THEN ROUND(p.unitPrice * (1 - p.discount), 2) ELSE NULL END AS discountedPrice, " & _
                    "p.reorderLevel, s.supplierName, p.dateAdded, p.expirationDate, " & _
                    "CASE WHEN p.stockQuantity = 0 OR (p.reorderLevel > 0 AND p.stockQuantity > 0 AND p.stockQuantity <= p.reorderLevel) THEN 1 ELSE 0 END AS isLowStock " & _
                    "FROM tbl_products p LEFT JOIN tbl_suppliers s ON s.supplierID = p.supplierID " & _
                    "ORDER BY isLowStock DESC, p.stockQuantity ASC, p.productName ASC"
            Else
                selectCore = _
                    "SELECT p.productID, p.productName, p.category, p.stockQuantity, p.description, " & _
                    "p.unitPrice, '0%' AS discount, NULL AS discountedPrice, " & _
                    "p.reorderLevel, s.supplierName, p.dateAdded, p.expirationDate, " & _
                    "CASE WHEN p.stockQuantity = 0 OR (p.reorderLevel > 0 AND p.stockQuantity > 0 AND p.stockQuantity <= p.reorderLevel) THEN 1 ELSE 0 END AS isLowStock " & _
                    "FROM tbl_products p LEFT JOIN tbl_suppliers s ON s.supplierID = p.supplierID " & _
                    "ORDER BY isLowStock DESC, p.stockQuantity ASC, p.productName ASC"
            End If

            productDGV.AutoGenerateColumns = True
            Call LoadDGV(selectCore, productDGV)

            ' Remove the isLowStock column from display
            If productDGV.Columns.Contains("isLowStock") Then
                productDGV.Columns("isLowStock").Visible = False
            End If

            ' Add event handler for row formatting (remove first to avoid duplicates)
            RemoveHandler productDGV.CellFormatting, AddressOf ProductDGV_CellFormatting
            AddHandler productDGV.CellFormatting, AddressOf ProductDGV_CellFormatting

            productDGV.AllowUserToOrderColumns = False

            ' Ensure proper column order
            Dim timer As New Timer()
            timer.Interval = 100
            AddHandler timer.Tick, Sub()
                                       FormatColumns()
                                       EnsureStableColumnOrder()
                                       timer.Stop()
                                       timer.Dispose()
                                   End Sub
            timer.Start()

            ' Force refresh to trigger RowPrePaint events for red highlighting
            productDGV.Refresh()

            ' Focus on the first low-stock item if exists
            If productDGV.Rows.Count > 0 Then
                productDGV.FirstDisplayedScrollingRowIndex = 0
                productDGV.Rows(0).Selected = True
                productDGV.Focus()
            End If

        Catch ex As Exception
            MsgBox("Error filtering low stock items: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    ' Returns True if a column exists on the given table; works under MySQL/MariaDB via ODBC
    Private Function ColumnExists(tableName As String, columnName As String) As Boolean
        Try
            ' Use SHOW COLUMNS to check existence in a DSN-agnostic way
            Dim sql As String = "SHOW COLUMNS FROM " & tableName & " LIKE ?"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", columnName)
                Dim obj = cmd.ExecuteScalar()
                Return obj IsNot Nothing
            End Using
        Catch
            Return False
        End Try
    End Function

    ' Safe method to load products with or without discount column
    Public Sub SafeLoadProducts(Optional whereClause As String = "", Optional searchText As String = "")
        Try
            Call dbConn()

            Dim hasDiscount As Boolean = ColumnExists("tbl_products", "discount")

            ' SQL query in exact order: productID, productName, category, stockQuantity, description, unitPrice, discount, discountedPrice, reorderLevel, supplierName, dateAdded, expirationDate
            Dim selectCore As String
            If hasDiscount Then
                selectCore = _
                    "SELECT p.productID, p.productName, p.category, p.stockQuantity, p.description, " & _
                    "p.unitPrice, CONCAT(ROUND(p.discount * 100, 2), '%') AS discount, " & _
                    "CASE WHEN p.discount > 0 THEN ROUND(p.unitPrice * (1 - p.discount), 2) ELSE NULL END AS discountedPrice, " & _
                    "p.reorderLevel, s.supplierName, p.dateAdded, p.expirationDate " & _
                    "FROM tbl_products p LEFT JOIN tbl_suppliers s ON s.supplierID = p.supplierID"
            Else
                selectCore = _
                    "SELECT p.productID, p.productName, p.category, p.stockQuantity, p.description, " & _
                    "p.unitPrice, '0%' AS discount, NULL AS discountedPrice, " & _
                    "p.reorderLevel, s.supplierName, p.dateAdded, p.expirationDate " & _
                    "FROM tbl_products p LEFT JOIN tbl_suppliers s ON s.supplierID = p.supplierID "
            End If

            Dim finalSql As String = selectCore & whereClause

            ' Enable auto-generation to show all columns from query
            productDGV.AutoGenerateColumns = True

            If String.IsNullOrEmpty(searchText) Then
                Call LoadDGV(finalSql, productDGV)
            Else
                Call LoadDGV(finalSql, productDGV, searchText)
            End If

            ' Add event handler for discounted price formatting (remove first to avoid duplicates)
            RemoveHandler productDGV.CellFormatting, AddressOf ProductDGV_CellFormatting
            AddHandler productDGV.CellFormatting, AddressOf ProductDGV_CellFormatting

            ' Do not allow user to reorder columns
            productDGV.AllowUserToOrderColumns = False

            ' Re-apply highlight whenever data binds or sorting changes
            RemoveHandler productDGV.DataBindingComplete, AddressOf OnProductGridUpdated
            AddHandler productDGV.DataBindingComplete, AddressOf OnProductGridUpdated
            RemoveHandler productDGV.Sorted, AddressOf OnProductGridUpdated
            AddHandler productDGV.Sorted, AddressOf OnProductGridUpdated

            ' Ensure proper column order (call this after everything is set up)
            ' Use a timer to delay the column ordering to ensure it happens after the grid is fully rendered
            Dim timer As New Timer()
            timer.Interval = 100 ' 100ms delay
            AddHandler timer.Tick, Sub()
                                       FormatColumns()
                                       EnsureStableColumnOrder()
                                       timer.Stop()
                                       timer.Dispose()
                                   End Sub
            timer.Start()

        Catch ex As Exception
            MsgBox("Error loading products: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    ' Event handler to highlight low-stock rows in red
    Private Sub ProductDGV_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles productDGV.RowPrePaint
        Try
            If e.RowIndex >= 0 AndAlso e.RowIndex < productDGV.Rows.Count Then
                Dim row As DataGridViewRow = productDGV.Rows(e.RowIndex)

                ' Check if this is a low-stock item
                Dim stockQuantity As Integer = 0
                Dim reorderLevel As Integer = 0

                ' Try to get values - check if columns exist first
                ' Check both auto-generated column names and designer column names
                If productDGV.Columns.Contains("stockQuantity") AndAlso row.Cells("stockQuantity").Value IsNot Nothing Then
                    Integer.TryParse(row.Cells("stockQuantity").Value.ToString(), stockQuantity)
                ElseIf productDGV.Columns.Contains("Column3") AndAlso row.Cells("Column3").Value IsNot Nothing Then
                    Integer.TryParse(row.Cells("Column3").Value.ToString(), stockQuantity)
                End If

                If productDGV.Columns.Contains("reorderLevel") AndAlso row.Cells("reorderLevel").Value IsNot Nothing Then
                    Integer.TryParse(row.Cells("reorderLevel").Value.ToString(), reorderLevel)
                ElseIf productDGV.Columns.Contains("Column8") AndAlso row.Cells("Column8").Value IsNot Nothing Then
                    Integer.TryParse(row.Cells("Column8").Value.ToString(), reorderLevel)
                End If

                ' Highlight row in red if stock is at or below reorder level
                If stockQuantity > 0 AndAlso reorderLevel > 0 AndAlso stockQuantity <= reorderLevel Then
                    'row.DefaultCellStyle.BackColor = Color.LightCoral
                    'row.DefaultCellStyle.ForeColor = Color.DarkRed
                    'row.DefaultCellStyle.SelectionBackColor = Color.IndianRed
                    row.DefaultCellStyle.SelectionForeColor = Color.White
                Else
                    ' Reset to default colors for non-low-stock items
                    If e.RowIndex Mod 2 = 0 Then
                        row.DefaultCellStyle.BackColor = Color.White
                    Else
                        row.DefaultCellStyle.BackColor = SystemColors.Control
                    End If
                    row.DefaultCellStyle.ForeColor = Color.Black
                    row.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
                    row.DefaultCellStyle.SelectionForeColor = Color.Black
                End If
            End If
        Catch ex As Exception
            ' Show error for debugging
            Console.WriteLine("RowPrePaint Error: " & ex.Message)
        End Try
    End Sub

    Private Sub OnProductGridUpdated(sender As Object, e As EventArgs)
        ' Refresh the grid to trigger RowPrePaint events
        productDGV.Refresh()
    End Sub

    ' Format columns with proper headers and styling
    Private Sub FormatColumns()
        Try
            ' Format column headers and styles
            If productDGV.Columns.Contains("productID") Then
                productDGV.Columns("productID").HeaderText = "ID"
                productDGV.Columns("productID").Width = 50
            End If

            If productDGV.Columns.Contains("productName") Then
                productDGV.Columns("productName").HeaderText = "Product Name"
                productDGV.Columns("productName").Width = 200
            End If

            If productDGV.Columns.Contains("category") Then
                productDGV.Columns("category").HeaderText = "Category"
                productDGV.Columns("category").Width = 100
            End If

            If productDGV.Columns.Contains("stockQuantity") Then
                productDGV.Columns("stockQuantity").HeaderText = "Quantity"
                productDGV.Columns("stockQuantity").Width = 80
            End If

            If productDGV.Columns.Contains("description") Then
                productDGV.Columns("description").HeaderText = "Description"
                productDGV.Columns("description").Width = 150
            End If

            ' Format Unit Price column (check both auto-generated and designer names)
            If productDGV.Columns.Contains("unitPrice") Then
                productDGV.Columns("unitPrice").HeaderText = "Unit Price"
                productDGV.Columns("unitPrice").DefaultCellStyle.Format = "₱#,##0.00"
                productDGV.Columns("unitPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                productDGV.Columns("unitPrice").Width = 100
            End If

            ' Also check for Column5 (designer name for unitPrice)
            If productDGV.Columns.Contains("Column5") Then
                productDGV.Columns("Column5").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            If productDGV.Columns.Contains("discount") Then
                productDGV.Columns("discount").HeaderText = "Discount"
                productDGV.Columns("discount").Width = 80
            End If

            ' Format Discounted Price column (check both auto-generated and designer names)
            If productDGV.Columns.Contains("discountedPrice") Then
                productDGV.Columns("discountedPrice").HeaderText = "Discounted Price"
                productDGV.Columns("discountedPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                productDGV.Columns("discountedPrice").DefaultCellStyle.NullValue = ""
                productDGV.Columns("discountedPrice").Width = 120
            End If

            ' Also check for Column12 (designer name for discountedPrice)
            If productDGV.Columns.Contains("Column12") Then
                productDGV.Columns("Column12").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                productDGV.Columns("Column12").DefaultCellStyle.NullValue = ""
            End If

            If productDGV.Columns.Contains("reorderLevel") Then
                productDGV.Columns("reorderLevel").HeaderText = "Re-order Level"
                productDGV.Columns("reorderLevel").Width = 100
                productDGV.Columns("reorderLevel").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            ' Also check for Column8 (designer name for reorderLevel)
            If productDGV.Columns.Contains("Column8") Then
                productDGV.Columns("Column8").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            If productDGV.Columns.Contains("supplierName") Then
                productDGV.Columns("supplierName").HeaderText = "Supplier"
                productDGV.Columns("supplierName").Width = 120
            End If

            If productDGV.Columns.Contains("dateAdded") Then
                productDGV.Columns("dateAdded").HeaderText = "Date Added"
                productDGV.Columns("dateAdded").DefaultCellStyle.Format = "MM/dd/yyyy"
                productDGV.Columns("dateAdded").Width = 100
            End If

            If productDGV.Columns.Contains("expirationDate") Then
                productDGV.Columns("expirationDate").HeaderText = "Expiration Date"
                productDGV.Columns("expirationDate").DefaultCellStyle.Format = "MM/dd/yyyy"
                productDGV.Columns("expirationDate").DefaultCellStyle.NullValue = ""
                productDGV.Columns("expirationDate").Width = 120
            End If

        Catch ex As Exception
            ' Ignore formatting errors
        End Try
    End Sub

    ' Keep columns in a fixed order to avoid UI rearrangements when schema toggles
    Private Sub EnsureStableColumnOrder()
        Try
            ' Order: productID, productName, category, stockQuantity, description, unitPrice, discount, discountedPrice, reorderLevel, supplierName, dateAdded, expirationDate
            Dim order As New List(Of String) From {
                "productID", "productName", "category", "stockQuantity", "description", "unitPrice", "discount", "discountedPrice",
                "reorderLevel", "supplierName", "dateAdded", "expirationDate"
            }

            ' Force the column order by setting DisplayIndex
            For i As Integer = 0 To order.Count - 1
                Dim colName As String = order(i)
                If productDGV.Columns.Contains(colName) Then
                    productDGV.Columns(colName).DisplayIndex = i
                End If
            Next

            ' Refresh the grid to apply changes
            productDGV.Refresh()

        Catch ex As Exception
            ' Log the error for debugging
            Console.WriteLine("Column ordering error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnStockIn_Click(sender As Object, e As EventArgs)
        Dim stockInForm As New stockIN()
        stockInForm.TopMost = True
        stockInForm.Show()
    End Sub

    Private Sub btnStockOut_Click(sender As Object, e As EventArgs)
        Dim stockOutForm As New stockOut()
        stockOutForm.TopMost = True
        stockOutForm.Show()
    End Sub

    Private Sub productDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            If e.RowIndex >= 0 Then

                productDGV.Rows(e.RowIndex).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        If productDGV.SelectedRows.Count > 0 Then

            Dim ProductID As Integer = Convert.ToInt32(productDGV.SelectedRows(0).Cells("Column1").Value)

            If MsgBox("Are you sure you want to edit this record?", vbYesNo + vbQuestion, "Edit") = vbYes Then

                Dim EditProduct As New addProduct()
                AddHandler EditProduct.FormClosed, AddressOf OnAddRecordClosed
                EditProduct.TopMost = True
                EditProduct.ShowDialog()
                EditProduct.pnlPrdct.Tag = ProductID
                EditProduct.loadRecord(ProductID)

            End If
        Else
            MessageBox.Show("Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        Dim productAdd As New addProduct()
        AddHandler productAdd.FormClosed, AddressOf OnAddRecordClosed
        productAdd.TopMost = True
        productAdd.ShowDialog()
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        SafeLoadProducts(" WHERE productName LIKE ?", txtSearch.Text)
    End Sub
    Public Sub LoadProductData()
        SafeLoadProducts()
        productDGV.ClearSelection()
    End Sub

    Private Sub OnAddRecordClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        SafeLoadProducts()
        productDGV.Refresh()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        Dim cmd As Odbc.OdbcCommand
        Dim sql As String
        Dim productname As String = ""
        Dim rowsAffected As Integer = 0 ' Declare rowsAffected at the method level



        If productDGV.SelectedRows.Count > 0 Then
            Dim productID As Integer = Convert.ToInt32(productDGV.SelectedRows(0).Cells("Column1").Value)


            If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, "Delete") = vbYes Then
                Try
                    Call dbConn()

                    sql = "SELECT productName FROM tbl_products WHERE productID = ?"
                    cmd = New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", productID)
                    Dim result As Object = cmd.ExecuteScalar()
                    productname = If(result IsNot Nothing, result.ToString(), "Unknown Product")

                    ' Delete from stock_out table
                    sql = "DELETE FROM tbl_stock_out WHERE ProductID = ?"
                    cmd = New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", productID)
                    cmd.ExecuteNonQuery()

                    ' Delete from stock_in table (if exists)
                    sql = "DELETE FROM tbl_stock_in WHERE ProductID = ?"
                    cmd = New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", productID)
                    cmd.ExecuteNonQuery()

                    sql = "DELETE FROM tbl_products WHERE productID = ?"
                    cmd = New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", productID)
                    cmd.ExecuteNonQuery()
                    rowsAffected = cmd.ExecuteNonQuery() ' Now this will work

                    'InsertAuditTrail(GlobalVariables.LoggedInUserID, "Delete Product", "Deleted product: " & productname)

                    'MsgBox("Product deleted successfully!", vbInformation, "Success")
                    'Call LoadDGV("SELECT * FROM tbl_products", productDGV)

                    If rowsAffected > 0 Then
                        InsertAuditTrail(GlobalVariables.LoggedInUserID, "Delete Product", "Deleted product: " & productname)
                        MsgBox("Product deleted successfully!", vbInformation, "Success")
                        SafeLoadProducts()
                    Else
                        MsgBox("No product was deleted. The product may have already been removed.", vbExclamation, "Delete Failed")
                    End If

                Catch ex As Exception
                    MsgBox("Error: " & ex.Message, vbCritical, "Delete Failed")
                Finally
                    conn.Close()
                    conn.Dispose()
                End Try
            End If
        Else
            MsgBox("Please select a record to delete.", vbExclamation, "No Row Selected")
        End If
    End Sub

    Sub InsertAuditTrail(UserID As Integer, ActionType As String, ActionDetails As String)
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

    Private Sub btnEdit_Click_1(sender As Object, e As EventArgs) Handles btnEdit.Click
        If productDGV.SelectedRows.Count > 0 Then

            Dim ProductID As Integer = Convert.ToInt32(productDGV.SelectedRows(0).Cells("Column1").Value)

            If MsgBox("Are you sure you want to edit this record?", vbYesNo + vbQuestion, "Edit") = vbYes Then

                Dim EditProduct As New addProduct()
                AddHandler EditProduct.FormClosed, AddressOf OnAddRecordClosed
                EditProduct.TopMost = True
                EditProduct.Show()
                EditProduct.pnlPrdct.Tag = ProductID
                EditProduct.lblhead.Text = "Edit Product"
                EditProduct.pbAdd.Visible = False
                EditProduct.pbEdit.Visible = True
                EditProduct.loadRecord(ProductID)

            End If
        Else
            MessageBox.Show("Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim productAdd As New addProduct()
        AddHandler productAdd.FormClosed, AddressOf OnAddRecordClosed
        productAdd.TopMost = True
        productAdd.Show()
    End Sub

    Private Sub btnDelete_Click_1(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim cmd As Odbc.OdbcCommand
        Dim sql As String
        Dim productname As String = ""

        If productDGV.SelectedRows.Count > 0 Then
            Dim productID As Integer = Convert.ToInt32(productDGV.SelectedRows(0).Cells("Column1").Value)

            If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, "Delete") = vbYes Then
                Try
                    Call dbConn()

                    ' Get Product Name (Optional, for logging)
                    sql = "SELECT productName FROM tbl_products WHERE productID = ?"
                    cmd = New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", productID)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        productname = result.ToString()
                    Else
                        productname = "Unknown Product"
                    End If


                    sql = "DELETE FROM tbl_stock_in WHERE ProductID = ?"
                    cmd = New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", productID)
                    cmd.ExecuteNonQuery()

                    sql = "DELETE FROM tbl_stock_out WHERE ProductID = ?"
                    cmd = New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", productID)
                    cmd.ExecuteNonQuery()


                    sql = "DELETE FROM tbl_products WHERE productID = ?"
                    cmd = New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", productID)
                    cmd.ExecuteNonQuery()

                    InsertAuditTrail(GlobalVariables.LoggedInUserID, "Delete Product", "Deleted product: " & productname)

                    MsgBox("Product deleted successfully!", vbInformation, "Success")
                    SafeLoadProducts()

                Catch ex As Exception
                    MsgBox("Error: " & ex.Message, vbCritical, "Delete Failed")
                Finally
                    conn.Close()
                    conn.Dispose()
                End Try
            End If
        Else
            MsgBox("Please select a record to delete.", vbExclamation, "No Row Selected")
        End If
    End Sub

    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        SafeLoadProducts(" WHERE productName LIKE ?", txtSearch.Text)
        If productDGV IsNot Nothing AndAlso productDGV.Rows.Count = 0 Then
            MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnSupplier.Click
        ' Get the parent MainForm
        Dim mainForm As MainForm = Nothing
        For Each form As Form In Application.OpenForms
            If TypeOf form Is MainForm Then
                mainForm = DirectCast(form, MainForm)
                Exit For
            End If
        Next

        If mainForm IsNot Nothing Then
            Dim supply As New Supplier()

            ' When Supplier closes, show MainForm again
            AddHandler supply.FormClosed, Sub(s, ev)
                                              ' Refresh inventory if needed
                                              Dim inv As inventory = Nothing
                                              For Each ctrl As Control In mainForm.pnlContainer.Controls
                                                  If TypeOf ctrl Is inventory Then
                                                      inv = DirectCast(ctrl, inventory)
                                                      Exit For
                                                  End If
                                              Next
                                              If inv IsNot Nothing Then
                                                  inv.SafeLoadProducts()
                                              End If
                                          End Sub

            supply.TopMost = True
            supply.ShowDialog()
        End If
    End Sub

    ' Event handler to format price columns with peso sign
    Private Sub ProductDGV_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        Try
            Dim colName As String = productDGV.Columns(e.ColumnIndex).Name
            Dim pesoSign As String = ChrW(&H20B1) ' Unicode character for Peso sign

            ' Format Unit Price column (both auto-generated and designer names)
            If colName = "unitPrice" OrElse colName = "Column5" Then
                If e.Value IsNot Nothing AndAlso Not IsDBNull(e.Value) AndAlso IsNumeric(e.Value) Then
                    Dim price As Decimal = Convert.ToDecimal(e.Value)
                    e.Value = pesoSign & price.ToString("#,##0.00")
                    e.FormattingApplied = True
                End If
            End If

            ' Format Discounted Price column (both auto-generated and designer names)
            If colName = "discountedPrice" OrElse colName = "Column12" Then
                ' Handle NULL values (no discount) by showing empty string
                If e.Value Is Nothing OrElse IsDBNull(e.Value) Then
                    e.Value = ""
                    e.FormattingApplied = True
                ElseIf IsNumeric(e.Value) Then
                    Dim discountedPrice As Decimal = Convert.ToDecimal(e.Value)
                    If discountedPrice = 0 Then
                        e.Value = ""
                        e.FormattingApplied = True
                    Else
                        e.Value = pesoSign & discountedPrice.ToString("#,##0.00")
                        e.FormattingApplied = True
                    End If
                End If
            End If
        Catch ex As Exception
            ' Ignore formatting errors
        End Try
    End Sub

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        If txtSearch.Text = "Search by product name" Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Search by product name"
            txtSearch.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub productDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles productDGV.CellContentClick

    End Sub

End Class