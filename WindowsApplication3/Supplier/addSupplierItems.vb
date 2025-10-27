Public Class addSupplierItems
    ' When opened from supplierItems, this will be set so new item links to that supplier
    Public Property SupplierIdFromCaller As Integer = 0
    ' When greater than 0, the form is in edit mode for this sProductID
    Public Property EditingSProductID As Integer = 0
    Private Sub addSupplierItemsvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        WireUpEvents()
        ' If editing, load the existing item details
        If EditingSProductID > 0 Then
            Try
                LoadItemForEdit(EditingSProductID)
            Catch ex As Exception
                MessageBox.Show("Error loading item for edit: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub WireUpEvents()
        ' Dynamically wire up button events if buttons exist
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = DirectCast(ctrl, Button)
                If btn.Name.ToLower().Contains("save") Then
                    AddHandler btn.Click, AddressOf SaveButton_Click
                ElseIf btn.Name.ToLower().Contains("cancel") Then
                    AddHandler btn.Click, AddressOf CancelButton_Click
                ElseIf btn.Name.ToLower().Contains("search") Then
                    AddHandler btn.Click, AddressOf SearchButton_Click
                End If
            End If
        Next
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs)
        SaveSupplierItem()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs)
        CancelForm()
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs)
        PerformProductSearch()
    End Sub

    Private Sub LoadCategories()
        Try
            Call dbConn()

            ' Load categories for dropdown (assuming there's a category combobox)
            Dim categoryQuery As String = "SELECT DISTINCT category FROM tbl_products WHERE category IS NOT NULL AND category <> '' ORDER BY category"
            Dim cmd As New Odbc.OdbcCommand(categoryQuery, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            ' Try to find category combobox
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is ComboBox AndAlso ctrl.Name.ToLower().Contains("category") Then
                    Dim cmbCategory As ComboBox = DirectCast(ctrl, ComboBox)
                    cmbCategory.Items.Clear()
                    While reader.Read()
                        cmbCategory.Items.Add(reader("category").ToString())
                    End While
                    Exit For
                End If
            Next

            reader.Close()

            ' Load suppliers for dropdown
            Dim supplierQuery As String = "SELECT supplierID, supplierName FROM tbl_suppliers ORDER BY supplierName"
            cmd = New Odbc.OdbcCommand(supplierQuery, conn)
            reader = cmd.ExecuteReader()

            ' Try to find supplier combobox
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is ComboBox AndAlso ctrl.Name.ToLower().Contains("supplier") Then
                    Dim cmbSupplier As ComboBox = DirectCast(ctrl, ComboBox)
                    cmbSupplier.Items.Clear()
                    cmbSupplier.DisplayMember = "supplierName"
                    cmbSupplier.ValueMember = "supplierID"

                    Dim dt As New DataTable()
                    dt.Load(reader)
                    cmbSupplier.DataSource = dt
                    Exit For
                End If
            Next

            reader.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Public Sub SaveSupplierItem()
        Try
            ' Read values directly from named controls (they are inside GroupBox/Panel)
            Dim productName As String = txtPrdctName.Text.Trim()
            Dim category As String = If(cmbCategory.SelectedItem IsNot Nothing, cmbCategory.SelectedItem.ToString(), cmbCategory.Text.Trim())
            Dim description As String = txtDescription.Text.Trim()
            Dim productPrice As Decimal = 0D
            Decimal.TryParse(txtUnitPrice.Text, productPrice)

            ' Get supplier ID from caller or from supplier combobox
            Dim supplierID As Integer = If(SupplierIdFromCaller > 0, SupplierIdFromCaller, 0)

            ' If not set from caller, try to get from supplier combobox
            If supplierID = 0 Then
                For Each ctrl As Control In Me.Controls
                    If TypeOf ctrl Is ComboBox AndAlso ctrl.Name.ToLower().Contains("supplier") Then
                        Dim cmbSupplier As ComboBox = DirectCast(ctrl, ComboBox)
                        If cmbSupplier.SelectedValue IsNot Nothing Then
                            Integer.TryParse(cmbSupplier.SelectedValue.ToString(), supplierID)
                        End If
                        Exit For
                    End If
                Next
            End If

            ' Validate required fields
            If String.IsNullOrWhiteSpace(productName) Then
                MessageBox.Show("Please enter a product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrWhiteSpace(category) Then
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If productPrice <= 0D Then
                MessageBox.Show("Please enter a valid product price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate supplier ID is required
            ' If no supplier is selected, try to get the first available supplier as default
            If supplierID <= 0 Then
                Try
                    Call dbConn()
                    Dim getSupplierCmd As New Odbc.OdbcCommand("SELECT supplierID FROM tbl_suppliers ORDER BY supplierID LIMIT 1", conn)
                    Dim result = getSupplierCmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Integer.TryParse(result.ToString(), supplierID)
                    End If
                    conn.Close()
                Catch
                    ' Ignore error
                End Try

                ' If still no supplier, show error
                If supplierID <= 0 Then
                    MessageBox.Show("No suppliers found in the system. Please add a supplier first before adding products.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If

            ' Insert or Update into tbl_supplier_products
            Call dbConn()

            Dim cmd As Odbc.OdbcCommand
            If EditingSProductID > 0 Then
                ' UPDATE existing supplier product
                Dim upd As String = "UPDATE tbl_supplier_products SET product_name = ?, category = ?, product_price = ?, description = ?, supplierID = ?, status = ? WHERE sProductID = ?"
                cmd = New Odbc.OdbcCommand(upd, conn)

                ' Add parameters with proper types
                cmd.Parameters.Add("?", Odbc.OdbcType.VarChar, 150).Value = productName
                cmd.Parameters.Add("?", Odbc.OdbcType.VarChar, 100).Value = category
                cmd.Parameters.Add("?", Odbc.OdbcType.Double).Value = CDbl(productPrice)
                cmd.Parameters.Add("?", Odbc.OdbcType.Text).Value = If(String.IsNullOrEmpty(description), "", description)
                cmd.Parameters.Add("?", Odbc.OdbcType.Int).Value = supplierID
                cmd.Parameters.Add("?", Odbc.OdbcType.VarChar, 20).Value = "Active"
                cmd.Parameters.Add("?", Odbc.OdbcType.Int).Value = EditingSProductID

                cmd.ExecuteNonQuery()
                conn.Close()
                MessageBox.Show("Supplier item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' INSERT new supplier product
                Dim ins As String = "INSERT INTO tbl_supplier_products (product_name, category, product_price, description, supplierID, status) VALUES (?, ?, ?, ?, ?, ?)"
                cmd = New Odbc.OdbcCommand(ins, conn)

                ' Add parameters with proper types
                cmd.Parameters.Add("?", Odbc.OdbcType.VarChar, 150).Value = productName
                cmd.Parameters.Add("?", Odbc.OdbcType.VarChar, 100).Value = category
                cmd.Parameters.Add("?", Odbc.OdbcType.Double).Value = CDbl(productPrice)
                cmd.Parameters.Add("?", Odbc.OdbcType.Text).Value = If(String.IsNullOrEmpty(description), "", description)
                cmd.Parameters.Add("?", Odbc.OdbcType.Int).Value = supplierID
                cmd.Parameters.Add("?", Odbc.OdbcType.VarChar, 20).Value = "Active"

                cmd.ExecuteNonQuery()
                conn.Close()
                MessageBox.Show("Supplier item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Set dialog result to OK to indicate successful save
            Me.DialogResult = DialogResult.OK

            ' Navigate to supplier items DataGridView
            NavigateToSupplierItemsGrid()

            ' Clear form for next entry
            ClearForm()

        Catch ex As Exception
            MessageBox.Show("Error saving supplier item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub LoadItemForEdit(id As Integer)
        Call dbConn()
        Dim sql As String = "SELECT sProductID, product_name, category, product_price, description, supplierID FROM tbl_supplier_products WHERE sProductID = ?"
        Using cmd As New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", id)
            Using r = cmd.ExecuteReader()
                If r.Read() Then
                    txtPrdctName.Text = r("product_name").ToString()
                    cmbCategory.Text = r("category").ToString()
                    txtDescription.Text = r("description").ToString()
                    txtUnitPrice.Text = If(IsDBNull(r("product_price")), "0", Convert.ToDecimal(r("product_price")).ToString())
                    ' Try select supplier in any supplier combobox present
                    Dim supId As Integer = If(IsDBNull(r("supplierID")), 0, Convert.ToInt32(r("supplierID")))
                    For Each ctrl As Control In Me.Controls
                        If TypeOf ctrl Is ComboBox AndAlso ctrl.Name.ToLower().Contains("supplier") Then
                            Dim cmbSupplier As ComboBox = DirectCast(ctrl, ComboBox)
                            If supId > 0 Then
                                cmbSupplier.SelectedValue = supId
                            Else
                                cmbSupplier.SelectedIndex = -1
                            End If
                            Exit For
                        End If
                    Next
                End If
            End Using
        End Using
        conn.Close()
    End Sub

    Private Sub NavigateToSupplierItemsGrid()
        Try
            ' Check if supplier items form is already open
            Dim existingForm As supplierItems = Nothing
            For Each form As Form In Application.OpenForms
                If TypeOf form Is supplierItems Then
                    existingForm = DirectCast(form, supplierItems)
                    Exit For
                End If
            Next

            If existingForm IsNot Nothing Then
                ' If form is already open, just refresh it and bring to front
                existingForm.RefreshSupplierItemsGrid()
                existingForm.BringToFront()
                existingForm.Focus()
            Else
                ' Open new supplier items form with DataGridView
                Dim supplierItemsForm As New supplierItems()
                supplierItemsForm.Show()
            End If

            ' Don't close the add form immediately - let the user decide
            ' Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error opening supplier items list: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CancelForm()
        Me.Close()
    End Sub

    Private Sub ClearForm()
        ' Clear all form controls
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBox Then
                DirectCast(ctrl, TextBox).Clear()
            ElseIf TypeOf ctrl Is ComboBox Then
                DirectCast(ctrl, ComboBox).SelectedIndex = -1
            End If
        Next
    End Sub

    Public Sub PerformProductSearch()
        SearchProducts()
    End Sub

    Private Sub SearchProducts()
        Try
            ' Get search text
            Dim searchText As String = ""

            ' Find search textbox
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is TextBox AndAlso (ctrl.Name.ToLower().Contains("search") OrElse ctrl.Name.ToLower().Contains("find")) Then
                    searchText = ctrl.Text.Trim()
                    Exit For
                End If
            Next

            If String.IsNullOrEmpty(searchText) Then
                searchText = InputBox("Enter product name to search:", "Search Product", "")
                If String.IsNullOrEmpty(searchText) Then Return
            End If

            Call dbConn()

            ' Search for existing supplier products
            Dim query As String = "SELECT sp.sProductID, sp.product_name, sp.category, sp.product_price, sp.description, s.supplierName FROM tbl_supplier_products sp LEFT JOIN tbl_suppliers s ON sp.supplierID = s.supplierID WHERE sp.product_name LIKE ? ORDER BY sp.product_name"
            Dim cmd As New Odbc.OdbcCommand(query, conn)
            cmd.Parameters.AddWithValue("?", "%" & searchText & "%")

            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                Dim results As String = "Found supplier products:" & vbCrLf & vbCrLf
                While reader.Read()
                    results &= "Name: " & reader("product_name").ToString() & vbCrLf
                    results &= "Category: " & reader("category").ToString() & vbCrLf
                    results &= "Price: " & Convert.ToDecimal(reader("product_price")).ToString("C2") & vbCrLf
                    results &= "Description: " & reader("description").ToString() & vbCrLf
                    results &= "Supplier: " & If(IsDBNull(reader("supplierName")), "N/A", reader("supplierName").ToString()) & vbCrLf & vbCrLf
                End While

                MessageBox.Show(results, "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No supplier products found matching '" & searchText & "'", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            reader.Close()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error searching products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Invoke the save routine which inserts into tbl_supplier_products
        SaveSupplierItem()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Close the form without saving
        CancelForm()
    End Sub

End Class