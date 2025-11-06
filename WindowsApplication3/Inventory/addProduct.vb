Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Data.Odbc
Public Class addProduct

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cmd As Odbc.OdbcCommand
        Dim sql As String

        ' Validate required fields and normalize optional ones before saving
        If Not ValidateRequiredFieldsAndAutofillOptional() Then
            Exit Sub
        End If

        If True Then
            If MsgBox("Do you want to save this record?", vbYesNo + vbQuestion, "Save") = vbYes Then
                Try
                    Call dbConn()

                    ' Parse numeric fields to pass correct types to ODBC
                    Dim priceVal As Decimal = 0D
                    Decimal.TryParse(txtUnitPrice.Text.Trim(), priceVal)

                    Dim reorderVal As Integer = 0
                    Integer.TryParse(txtReorder.Text.Trim(), reorderVal)

                    Dim dateVal As Date = Date.Now
                    Date.TryParse(dtpDate.Text, dateVal)

                    If Len(pnlPrdct.Tag) = 0 Then
                        ' Insert including discount, discount applied date, and expiration date
                        ' Stock quantity starts at 0, use stockIN form to add stock

                        sql = "INSERT INTO tbl_products (productName, category, stockQuantity, unitPrice, description, reorderLevel, dateAdded, supplierID, discount, discountAppliedDate, expirationDate) " & _
                              "VALUES (?,?,?,?,?,?,?,?,?,?,?)"
                        cmd = New Odbc.OdbcCommand(sql, conn)

                        cmd.Parameters.AddWithValue("?", StrConv(Trim(cmbPrdctName.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", cmbCategory.Text)
                        cmd.Parameters.AddWithValue("?", 0)
                        cmd.Parameters.AddWithValue("?", CDbl(priceVal))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtDescription.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", reorderVal)
                        cmd.Parameters.AddWithValue("?", dateVal)

                        ' Check if a supplier is selected and add supplierID
                        If cmbSuppliers.SelectedIndex >= 0 Then
                            cmd.Parameters.AddWithValue("?", CType(cmbSuppliers.SelectedValue, Integer))
                        Else
                            cmd.Parameters.AddWithValue("?", DBNull.Value)
                        End If

                        ' Discount: percentage input -> decimal storage
                        Dim discountPct As Decimal = 0D
                        Decimal.TryParse(txtDiscount.Text.Trim(), discountPct)
                        Dim discountDec As Decimal = discountPct / 100D
                        cmd.Parameters.AddWithValue("?", CDbl(discountDec))

                        ' Set discount applied date only if discount > 0
                        If discountDec > 0 Then
                            cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                        Else
                            cmd.Parameters.AddWithValue("?", DBNull.Value)
                        End If

                        ' Save expiration date from dtpEDate if visible (Contact Lens or Solution)
                        If dtpEDate.Visible Then
                            cmd.Parameters.AddWithValue("?", dtpEDate.Value.Date)
                        Else
                            cmd.Parameters.AddWithValue("?", DBNull.Value)
                        End If

                        cmd.ExecuteNonQuery()

                        ' Get the last inserted productID
                        Dim lastProductID As Integer
                        Dim cmd2 As New Odbc.OdbcCommand("SELECT LAST_INSERT_ID()", conn)
                        lastProductID = Convert.ToInt32(cmd2.ExecuteScalar())

                        InsertAuditTrail(GlobalVariables.LoggedInUserID, "Add Product", "Added product: " & cmbPrdctName.Text)

                        MsgBox("Product saved successfully!", vbInformation, "Success")
                    Else
                        ' Update including discount, discount applied date, and expiration date
                        ' Stock quantity is not updated here, use stockIN/stockOut forms

                        sql = "UPDATE tbl_products SET productName=?, category=?, unitPrice=?, description=?, reorderLevel=?, dateAdded=?, supplierID=?, discount=?, discountAppliedDate=?, expirationDate=? WHERE productID=?"
                        cmd = New Odbc.OdbcCommand(sql, conn)

                        cmd.Parameters.AddWithValue("?", StrConv(Trim(cmbPrdctName.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", cmbCategory.Text)
                        cmd.Parameters.AddWithValue("?", CDbl(priceVal))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtDescription.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", reorderVal)
                        cmd.Parameters.AddWithValue("?", dateVal)
                        cmd.Parameters.AddWithValue("?", If(cmbSuppliers.SelectedIndex >= 0, CType(cmbSuppliers.SelectedValue, Integer), DBNull.Value))

                        ' Discount: percentage input -> decimal storage
                        Dim discountPctU As Decimal = 0D
                        Decimal.TryParse(txtDiscount.Text.Trim(), discountPctU)
                        Dim discountDecU As Decimal = discountPctU / 100D
                        cmd.Parameters.AddWithValue("?", CDbl(discountDecU))

                        ' Update discount applied date only if discount > 0, otherwise set to NULL
                        If discountDecU > 0 Then
                            cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                        Else
                            cmd.Parameters.AddWithValue("?", DBNull.Value)
                        End If

                        ' Update expiration date from dtpEDate if visible (Contact Lens or Solution)
                        If dtpEDate.Visible Then
                            cmd.Parameters.AddWithValue("?", dtpEDate.Value.Date)
                        Else
                            cmd.Parameters.AddWithValue("?", DBNull.Value)
                        End If

                        cmd.Parameters.AddWithValue("?", pnlPrdct.Tag)

                        cmd.ExecuteNonQuery()

                        InsertAuditTrail(GlobalVariables.LoggedInUserID, "Update Product", "Updated product: " & cmbPrdctName.Text)

                        MsgBox("Product updated successfully!", vbInformation, "Success")
                    End If

                    ' Reload the DataGridView with discount and discounted price
                    Dim inventoryForm As inventory = CType(Application.OpenForms("inventory"), inventory)
                    If inventoryForm IsNot Nothing Then
                        inventoryForm.SafeLoadProducts()
                        inventoryForm.productDGV.Refresh()
                    End If

                    ' Update critical stock count on dashboard
                    UpdateDashboardCriticalCount()

                    cmd.Dispose()
                Catch ex As Exception
                    MsgBox("Error: " & ex.Message, vbCritical, "Database Error")
                Finally
                    GC.Collect()
                    conn.Close()
                    conn.Dispose()
                End Try
            End If
        End If
        Me.Close()
    End Sub

    Private Function GetSupplierNameByID(supplierID As Integer) As String
        ' Query the database to get the supplier name based on supplierID
        Dim supplierName As String = String.Empty
        Try
            ' Call the dbConn function to open the connection
            Call dbConn()

            ' Your SQL query to get the supplier name based on supplier ID
            Dim sql As String = "SELECT supplierName FROM tbl_suppliers WHERE supplierID = ?"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", supplierID)
                ' ExecuteScalar will return the first column of the first row in the result set
                supplierName = cmd.ExecuteScalar().ToString()
            End Using
        Catch ex As Exception
            MsgBox("Error fetching supplier name: " & ex.Message, vbCritical, "Error")
        Finally
            ' Ensure the connection is closed, even if an error occurred
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        Return supplierName
    End Function

    Private Sub LoadSupplierProducts(Optional supplierID As Integer = -1)
        Try
            Call dbConn()
            Dim dt As New DataTable()
            dt.Columns.Add("product_name", GetType(String))
            dt.Columns.Add("category", GetType(String))
            dt.Columns.Add("description", GetType(String))

            If supplierID >= 0 Then
                Using cmd As New Odbc.OdbcCommand("SELECT product_name, category, description FROM tbl_supplier_products WHERE supplierID = ? ORDER BY product_name", conn)
                    cmd.Parameters.AddWithValue("?", supplierID)
                    Using da As New Odbc.OdbcDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End If

            cmbPrdctName.DataSource = Nothing
            cmbPrdctName.Items.Clear()
            cmbPrdctName.DropDownStyle = ComboBoxStyle.DropDownList
            ' Set AutoCompleteSource BEFORE AutoCompleteMode to avoid runtime exception
            cmbPrdctName.AutoCompleteSource = AutoCompleteSource.ListItems
            cmbPrdctName.AutoCompleteMode = AutoCompleteMode.SuggestAppend

            If dt.Rows.Count > 0 Then
                cmbPrdctName.DataSource = dt
                cmbPrdctName.DisplayMember = "product_name"
                cmbPrdctName.ValueMember = "product_name"
            Else
                ' When there are no items, disable autocomplete to satisfy DropDownList constraint
                cmbPrdctName.AutoCompleteMode = AutoCompleteMode.None
            End If
            cmbPrdctName.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("Error loading supplier products: " & ex.Message, vbCritical, "Error")
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub ApplySelectedProductMeta()
        Try
            ' Lock category editing as it comes from supplier item
            cmbCategory.Enabled = False
            If cmbSuppliers.SelectedIndex < 0 OrElse cmbPrdctName.SelectedIndex < 0 Then
                Exit Sub
            End If

            Dim cat As String = ""
            Dim desc As String = ""

            ' Prefer reading from the bound DataRowView
            Dim drv As DataRowView = TryCast(cmbPrdctName.SelectedItem, DataRowView)
            If drv IsNot Nothing Then
                If drv.DataView.Table.Columns.Contains("category") Then
                    cat = Convert.ToString(drv("category"))
                End If
                If drv.DataView.Table.Columns.Contains("description") Then
                    desc = Convert.ToString(drv("description"))
                End If
            Else
                ' Fallback: query by supplier and product name
                Call dbConn()
                Using cmd As New Odbc.OdbcCommand("SELECT category, description FROM tbl_supplier_products WHERE supplierID=? AND product_name=? LIMIT 1", conn)
                    cmd.Parameters.AddWithValue("?", CType(cmbSuppliers.SelectedValue, Integer))
                    cmd.Parameters.AddWithValue("?", cmbPrdctName.Text)
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            cat = Convert.ToString(rdr("category"))
                            desc = Convert.ToString(rdr("description"))
                        End If
                    End Using
                End Using
            End If

            ' Apply category (ensure present in list)
            If Not String.IsNullOrWhiteSpace(cat) Then
                Dim found As Boolean = False
                For Each item In cmbCategory.Items
                    If String.Equals(item.ToString(), cat, StringComparison.OrdinalIgnoreCase) Then
                        found = True
                        Exit For
                    End If
                Next
                If Not found Then cmbCategory.Items.Add(cat)
                cmbCategory.Text = cat
            End If

            ' Apply description rules: always allow editing; bind supplier description if present
            If String.IsNullOrWhiteSpace(desc) Then
                txtDescription.Text = "N/A"
            Else
                txtDescription.Text = desc
            End If
            txtDescription.ReadOnly = False

            ' Show/hide expiration date based on category
            ToggleExpirationDateVisibility()
        Catch
            ' Non-fatal binding
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub ToggleExpirationDateVisibility()
        ' Show expiration date only for Contact Lens and Solution categories
        Dim category As String = cmbCategory.Text.Trim().ToLower()
        Dim showExpiration As Boolean = category.Contains("contact lens") OrElse category.Contains("solution")

        dtpEDate.Visible = showExpiration
        Label4.Visible = showExpiration
    End Sub
    Private Sub LoadSuppliers()
        Try
            Call dbConn()

            Dim sql As String = "SELECT supplierID, supplierName FROM tbl_suppliers"
            Dim adapter As New Odbc.OdbcDataAdapter(sql, conn)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            cmbSuppliers.DataSource = dt
            cmbSuppliers.DisplayMember = "supplierName"
            cmbSuppliers.ValueMember = "supplierID"
            cmbSuppliers.SelectedIndex = -1

            conn.Close()
        Catch ex As Exception
            MsgBox("Error loading suppliers: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Private Function ValidateRequiredFieldsAndAutofillOptional() As Boolean
        Dim missing As New List(Of String)
        Dim firstInvalid As Control = Nothing

        Dim assignFirst As Action(Of Control) = Sub(c As Control)
                                                    If firstInvalid Is Nothing Then firstInvalid = c
                                                End Sub

        ' Required: Product Name (*)    - ComboBox (supplier product)
        If cmbPrdctName Is Nothing OrElse cmbPrdctName.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(cmbPrdctName.Text) Then
            missing.Add("Product Name")
            assignFirst(cmbPrdctName)
        End If

        ' Required: Category (*)        - ComboBox (programmatically set; may not be in predefined list)
        If cmbCategory Is Nothing OrElse String.IsNullOrWhiteSpace(cmbCategory.Text) Then
            missing.Add("Category")
            assignFirst(cmbCategory)
        End If

        ' Required: Unit Price (*)      - numeric TextBox
        Dim price As Decimal
        If String.IsNullOrWhiteSpace(txtUnitPrice.Text) OrElse Not Decimal.TryParse(txtUnitPrice.Text.Trim(), price) Then
            missing.Add("Unit Price (numeric)")
            assignFirst(txtUnitPrice)
        End If

        ' Required: Reorder Level (*)   - numeric TextBox, must be >= 5
        Dim reorder As Integer
        If String.IsNullOrWhiteSpace(txtReorder.Text) OrElse Not Integer.TryParse(txtReorder.Text.Trim(), reorder) Then
            missing.Add("Reorder Level (numeric)")
            assignFirst(txtReorder)
        ElseIf reorder < 5 Then
            missing.Add("Reorder Level (must be at least 5)")
            assignFirst(txtReorder)
        End If

        ' Required: Supplier Name (*)   - ComboBox
        If cmbSuppliers Is Nothing OrElse cmbSuppliers.SelectedIndex < 0 Then
            missing.Add("Supplier Name")
            assignFirst(cmbSuppliers)
        End If

        ' Optional fields: auto-fill with N/A if left blank (no asterisk)
        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            txtDescription.Text = "N/A"
        End If

        ' Optional: Discount - validate if provided (percentage 0-100)
        If Not String.IsNullOrWhiteSpace(txtDiscount.Text) Then
            Dim discount As Decimal
            If Not Decimal.TryParse(txtDiscount.Text.Trim(), discount) OrElse discount < 0 OrElse discount > 100 Then
                missing.Add("Discount (percentage 0-100)")
                assignFirst(txtDiscount)
            End If
        Else
            txtDiscount.Text = "0"
        End If

        If missing.Count > 0 Then
            MessageBox.Show("Please complete the required fields marked with (*):" & vbCrLf &
                            " - " & String.Join(vbCrLf & " - ", missing),
                            "Fill the Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If firstInvalid IsNot Nothing Then firstInvalid.Focus()
            Return False
        End If

        Return True
    End Function

    Function checkData(ByVal gb As GroupBox) As Boolean
        For Each obj As Object In gb.Controls
            If TypeOf obj Is TextBox Then
                If Len(obj.text) = 0 Then
                    MsgBox("Please input data", vbCritical, "Save")
                    checkData = False
                    Exit Function
                End If
            End If
        Next
        Return True
    End Function

    Public Sub loadRecord(ByVal productID As Integer)
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Dim sql As String = "SELECT productID, productName, category, stockQuantity, unitPrice, description, reorderLevel, dateAdded, supplierID, discount, discountAppliedDate, expirationDate FROM tbl_products WHERE productID=?"

        Try
            Call dbConn()

            cmd = New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", productID)

            da.SelectCommand = cmd
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                ' Ensure supplier list populated before setting product name
                Dim supplierID As Integer = Convert.ToInt32(dt.Rows(0)("supplierID"))
                cmbSuppliers.SelectedValue = supplierID
                LoadSupplierProducts(supplierID)
                cmbPrdctName.Text = dt.Rows(0)("productName").ToString()
                cmbCategory.Text = dt.Rows(0)("category").ToString()
                txtUnitPrice.Text = dt.Rows(0)("unitPrice").ToString()
                txtDescription.Text = dt.Rows(0)("description").ToString()
                txtReorder.Text = dt.Rows(0)("reorderLevel").ToString()
                dtpDate.Text = dt.Rows(0)("dateAdded").ToString()

                ' Show discount as percentage if column exists (stored as decimal fraction)
                If dt.Columns.Contains("discount") Then
                    Dim discDec As Decimal = 0D
                    If Not IsDBNull(dt.Rows(0)("discount")) Then
                        Decimal.TryParse(dt.Rows(0)("discount").ToString(), discDec)
                    End If
                    txtDiscount.Text = (discDec * 100D).ToString("0.##")
                Else
                    txtDiscount.Text = "0"
                End If

                ' Load expiration date if exists
                If dt.Columns.Contains("expirationDate") AndAlso Not IsDBNull(dt.Rows(0)("expirationDate")) Then
                    dtpEDate.Value = Convert.ToDateTime(dt.Rows(0)("expirationDate"))
                End If

                ' Toggle expiration date visibility based on category
                ToggleExpirationDateVisibility()

                ' supplierID handled above
            Else
                MsgBox("No record found.", vbInformation, "Record Not Found")
            End If

            cmd.Dispose()
            da.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message.ToString(), vbCritical, "Error Loading Record")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        GC.Collect()
    End Sub

    Private Sub cleaner()
        For Each obj As Object In grpAddPrdct.Controls
            If TypeOf obj Is TextBox Then
                obj.text = ""
            End If
        Next
        inventory.productDGV.Tag = ""
    End Sub

    Private Sub grpAddPrdct_Enter(sender As Object, e As EventArgs) Handles grpAddPrdct.Enter
        cmbPrdctName.TabIndex = 0
        cmbCategory.TabIndex = 1
        txtUnitPrice.TabIndex = 2
        txtDiscount.TabIndex = 3
        txtDescription.TabIndex = 4
        txtReorder.TabIndex = 5
        dtpDate.TabIndex = 6
        cmbSuppliers.TabIndex = 7
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
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

    Private Sub addProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Discount column already exists; only load suppliers
        LoadSuppliers()
        ' Initialize product names list as empty until supplier selected
        LoadSupplierProducts(-1)
        cmbCategory.Enabled = False

        ' Hide expiration date by default
        dtpEDate.Visible = False
        Label4.Visible = False
    End Sub

    Private Sub cmbSuppliers_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbSuppliers.SelectionChangeCommitted
        If cmbSuppliers.SelectedIndex >= 0 AndAlso cmbSuppliers.SelectedValue IsNot Nothing Then
            Dim sid As Integer
            If Integer.TryParse(cmbSuppliers.SelectedValue.ToString(), sid) Then
                LoadSupplierProducts(sid)
                ' Reset downstream fields when supplier changes
                cmbPrdctName.SelectedIndex = -1
                cmbCategory.Text = ""
                txtDescription.ReadOnly = False
                ' Do not auto-set N/A on supplier selection; wait until a product is selected
                txtDescription.Text = ""
            End If
        Else
            LoadSupplierProducts(-1)
        End If
    End Sub

    Private Sub cmbSuppliers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSuppliers.SelectedIndexChanged
        If cmbSuppliers.Focused Then
            cmbSuppliers_SelectionChangeCommitted(sender, e)
        End If
    End Sub

    Private Sub cmbPrdctName_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbPrdctName.SelectionChangeCommitted
        ApplySelectedProductMeta()
    End Sub

    Private Sub cmbPrdctName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrdctName.SelectedIndexChanged
        If cmbPrdctName.Focused Then
            ApplySelectedProductMeta()
        End If
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        ToggleExpirationDateVisibility()
    End Sub

    Private Sub cmbCategory_TextChanged(sender As Object, e As EventArgs) Handles cmbCategory.TextChanged
        ToggleExpirationDateVisibility()
    End Sub

    ' Removed EnsureDiscountColumn and CheckDiscountColumnExists: DB schema already contains discount

    ' Remove EnsureDiscountColumn and CheckDiscountColumnExists: no discount column in database

    ' Numeric-only inputs for required numeric fields
    Private Sub txtReorder_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReorder.KeyPress
        ' Allow digits and control keys only
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUnitPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        ' Allow digits, one decimal point, and control keys
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
            Return
        End If

        ' Only one decimal point allowed
        If e.KeyChar = "."c Then
            Dim tb As TextBox = CType(sender, TextBox)
            If tb.Text.Contains(".") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDiscount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiscount.KeyPress
        ' Allow digits, one decimal point, and control keys
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
            Return
        End If

        ' Only one decimal point allowed
        If e.KeyChar = "."c Then
            Dim tb As TextBox = CType(sender, TextBox)
            If tb.Text.Contains(".") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub UpdateDashboardCriticalCount()
        ' Find dashboard form in MainForm container and update critical count
        Try
            Dim mainForm As MainForm = CType(Application.OpenForms("MainForm"), MainForm)
            If mainForm IsNot Nothing Then
                For Each ctrl As Control In mainForm.pnlContainer.Controls
                    If TypeOf ctrl Is dashboard Then
                        Dim dash As dashboard = DirectCast(ctrl, dashboard)
                        dash.UpdateCriticalStockCount()
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            ' Silently fail if dashboard is not open
        End Try
    End Sub
End Class
