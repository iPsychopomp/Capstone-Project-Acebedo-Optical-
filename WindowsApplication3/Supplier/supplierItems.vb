Public Class supplierItems
    ' Optional filter: when set (>0), only show items for this supplier ID
    Public Property SupplierIdFilter As Integer = 0
    Private currentPage As Integer = 0
    Private pageSize As Integer = 20
    Private totalCount As Integer = 0

    Private dgvSupplierItems As DataGridView
    Private lblMessage As Label

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub supplierItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Find the DataGridView control on the form
            Dim dgv As DataGridView = FindDataGridView()
            If dgv IsNot Nothing Then
                Me.DgvStyle(dgv)
                currentPage = 0
                LoadPage()
            Else
                ' If no DataGridView found, just show a message and continue
                ' The form will still open, just without data loading
                Me.Text = "Supplier Items - No DataGridView Found"
            End If
            WireUpEvents()
        Catch ex As Exception
            ' Don't show error dialog, just log it and continue
            Me.Text = "Supplier Items - Error: " & ex.Message
        End Try
    End Sub

    Private Function FindDataGridView() As DataGridView
        ' Return the existing supplierItemDGV control from the designer
        Return supplierItemDGV
    End Function

    ' Local grid styling to avoid ambiguity with similarly named module methods
    Public Sub DgvStyle(ByRef supplierItemDGV As DataGridView)
        Try
            supplierItemDGV.AutoGenerateColumns = False
            supplierItemDGV.AllowUserToAddRows = False
            supplierItemDGV.AllowUserToDeleteRows = False
            supplierItemDGV.RowHeadersVisible = False
            supplierItemDGV.BorderStyle = BorderStyle.FixedSingle
            supplierItemDGV.BackgroundColor = Color.White
            supplierItemDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
            supplierItemDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
            supplierItemDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
            supplierItemDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            supplierItemDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
            supplierItemDGV.EnableHeadersVisualStyles = False
            supplierItemDGV.DefaultCellStyle.ForeColor = Color.Black
            supplierItemDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
            supplierItemDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
            supplierItemDGV.DefaultCellStyle.SelectionForeColor = Color.Black
            supplierItemDGV.GridColor = Color.Silver
            supplierItemDGV.DefaultCellStyle.Padding = New Padding(5)
            supplierItemDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            supplierItemDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            supplierItemDGV.ReadOnly = True
            supplierItemDGV.MultiSelect = False
            supplierItemDGV.AllowUserToResizeRows = False
            supplierItemDGV.RowTemplate.Height = 30
            supplierItemDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
            supplierItemDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Catch ex As Exception
            ' ignore styling errors
        End Try
    End Sub

    Private Sub WireUpEvents()
        ' Connect the existing btnAdd button directly
        Try
            ' Find and connect btnAdd specifically
            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is Button AndAlso ctrl.Name = "btnAdd" Then
                    Dim btnAdd As Button = DirectCast(ctrl, Button)
                    AddHandler btnAdd.Click, AddressOf AddButton_Click
                    Exit For
                End If
            Next
        Catch ex As Exception
            ' If btnAdd connection fails, continue
        End Try

        '' Also wire up other buttons dynamically
        'For Each ctrl As Control In Me.Controls
        '    If TypeOf ctrl Is Button Then
        '        Dim btn As Button = DirectCast(ctrl, Button)
        '        If btn.Name.ToLower().Contains("search") OrElse btn.Text.ToLower().Contains("search") Then
        '            AddHandler btn.Click, AddressOf SearchButton_Click
        '        ElseIf btn.Name.ToLower().Contains("refresh") OrElse btn.Text.ToLower().Contains("refresh") Then
        '            AddHandler btn.Click, AddressOf RefreshButton_Click
        '        End If
        '    End If
        'Next

        '' Add Enter key search for txtSearch
        'AddHandler txtSearch.KeyDown, AddressOf txtSearch_KeyDown
    End Sub

    'Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs)
    '    ' Enter key to search
    '    If e.KeyCode = Keys.Enter Then
    '        PerformSearch()
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs)
        OpenAddForm()
    End Sub

    ' Direct event handler for btnAdd button (if it exists with WithEvents)
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        OpenAddForm()
    End Sub

    Private Sub RefreshButton_Click(sender As Object, e As EventArgs)
        RefreshData()
    End Sub

    ' Direct event handler for btnEdit button (open edit form and bind selected row)
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Dim dgv As DataGridView = FindDataGridView()
            If dgv Is Nothing OrElse dgv.CurrentRow Is Nothing Then
                MessageBox.Show("Please select a supplier item to edit.", "Edit Item", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim row As DataGridViewRow = dgv.CurrentRow
            If row Is Nothing OrElse row.IsNewRow Then
                MessageBox.Show("Invalid selection.", "Edit Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Try to get sProductID from the grid column first
            Dim sProductID As Integer = 0
            If dgv.Columns.Contains("sProductID") AndAlso row.Cells("sProductID").Value IsNot Nothing Then
                Integer.TryParse(row.Cells("sProductID").Value.ToString(), sProductID)
            End If

            ' Fallback: read from the bound DataRowView
            If sProductID <= 0 AndAlso row.DataBoundItem IsNot Nothing Then
                Dim drv = TryCast(row.DataBoundItem, DataRowView)
                If drv IsNot Nothing AndAlso drv.Row.Table.Columns.Contains("sProductID") Then
                    Integer.TryParse(Convert.ToString(drv("sProductID")), sProductID)
                End If
            End If

            If sProductID <= 0 Then
                MessageBox.Show("Could not determine the selected item's ID. Please refresh and try again.", "Edit Item", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim productName As String = If(dgv.Columns.Contains("product_name"), Convert.ToString(row.Cells("product_name").Value), "")
            Dim category As String = If(dgv.Columns.Contains("category"), Convert.ToString(row.Cells("category").Value), "")
            Dim description As String = If(dgv.Columns.Contains("description"), Convert.ToString(row.Cells("description").Value), "")
            Dim price As Decimal = 0D
            If dgv.Columns.Contains("product_price") Then
                Dim priceObj = row.Cells("product_price").Value
                If priceObj IsNot Nothing Then Decimal.TryParse(priceObj.ToString(), price)
            End If

            Dim editForm As New addSupplierItems()
            editForm.TopMost = True
            editForm.SupplierIdFromCaller = Me.SupplierIdFilter
            editForm.EditingSProductID = sProductID
            editForm.Text = "Edit Supplier Item"

            ' Prefill controls for UX; the form will also load from DB using the ID
            editForm.txtPrdctName.Text = productName
            editForm.cmbCategory.Text = category
            editForm.txtDescription.Text = description
            editForm.txtUnitPrice.Text = price.ToString()

            Dim dr As DialogResult = editForm.ShowDialog()
            If dr = DialogResult.OK Then
                LoadSupplierItems()
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening edit form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub OpenAddForm()
        Try
            Dim addForm As New addSupplierItems()
            addForm.TopMost = True
            ' Pass current supplier filter so new item links correctly
            addForm.SupplierIdFromCaller = Me.SupplierIdFilter
            Dim result As DialogResult = addForm.ShowDialog()
            If result = DialogResult.OK Then
                LoadSupplierItems()
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening add supplier items form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Public Sub PerformSearch()
    '    ' SearchByProductName()
    'End Sub

    Private Sub LoadSupplierItems()
        Try
            ' Delegate to paginated loader
            LoadPage()

        Catch ex As Exception
            ' Don't show error message, just fail silently
            Try
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            Catch
                ' Ignore connection close errors
            End Try
        End Try
    End Sub

    Public Sub RefreshData()
        LoadSupplierItems()
    End Sub

    ' Public method to refresh the supplier items DataGridView from external calls
    Public Sub RefreshSupplierItemsGrid()
        Try
            LoadSupplierItems()
            Me.BringToFront()
            Me.Focus()
        Catch ex As Exception
            MessageBox.Show("Error refreshing supplier items: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim term As String = txtSearch.Text.Trim()
            If String.IsNullOrWhiteSpace(term) Then
                ' Reset to paginated list
                currentPage = 0
                LoadPage()
            Else
                ' Search by product name only (partial match)
                Dim dgv As DataGridView = FindDataGridView()
                If dgv Is Nothing Then Return

                Dim sb As New System.Text.StringBuilder()

                sb.Append("SELECT sp.sProductID, sp.product_name, sp.category, sp.description, sp.product_price, ")
                sb.Append("CASE ")
                sb.Append("  WHEN p.productID IS NULL THEN 'Inactive' ")
                sb.Append("  WHEN p.stockQuantity <= 0 THEN 'Inactive' ")
                sb.Append("  ELSE COALESCE(sp.status, 'Active') ")
                sb.Append("END AS status ")
                sb.Append("FROM tbl_supplier_products sp ")
                sb.Append("LEFT JOIN tbl_products p ON UPPER(TRIM(p.productName)) = UPPER(TRIM(sp.product_name)) ")
                sb.Append("WHERE sp.product_name LIKE ? ")
                If SupplierIdFilter > 0 Then
                    sb.Append("AND sp.supplierID = ? ")
                End If
                sb.Append("ORDER BY sp.product_name")

                Call dbConn()
                Using cmd As New Odbc.OdbcCommand(sb.ToString(), conn)
                    cmd.Parameters.AddWithValue("?", "%" & term & "%")
                    If SupplierIdFilter > 0 Then
                        cmd.Parameters.AddWithValue("?", SupplierIdFilter)
                    End If

                    Using adapter As New Odbc.OdbcDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgv.DataSource = dt
                        If dgv.Columns.Contains("sProductID") Then dgv.Columns("sProductID").Visible = False
                        If dgv.Columns.Contains("product_price") Then
                            dgv.Columns("product_price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        End If
                    End Using
                End Using
            End If
            Dim dgvForSelection As DataGridView = FindDataGridView()
            If dgvForSelection IsNot Nothing Then
                dgvForSelection.ClearSelection()
                ' Notify when no matches found
                If dgvForSelection.Rows.Count = 0 Then
                    MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("Search failed: " & ex.Message, vbCritical, "Error")
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
        ' When filtered, disable paging controls
        txtPage.Text = "Search results"
        btnBack.Enabled = False
        btnNext.Enabled = False
        DgvStyle(FindDataGridView())
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            currentPage = 0
            LoadPage()
        End If
    End Sub

    ' Event handler to format product price column with peso sign and status column with colors
    Private Sub supplierItemDGV_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles supplierItemDGV.CellFormatting
        Try
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)
            Dim colName As String = dgv.Columns(e.ColumnIndex).Name

            ' Format product price with peso sign
            If colName = "product_price" OrElse colName = "Column3" Then
                If e.Value IsNot Nothing AndAlso Not IsDBNull(e.Value) AndAlso IsNumeric(e.Value) Then
                    Dim price As Decimal = Convert.ToDecimal(e.Value)
                    Dim pesoSign As String = ChrW(&H20B1) ' Unicode character for Peso sign
                    e.Value = pesoSign & price.ToString("#,##0.00")
                    e.FormattingApplied = True
                End If
            End If

            ' Format status column with colors
            If colName = "status" Then
                If e.Value IsNot Nothing AndAlso Not IsDBNull(e.Value) Then
                    Dim statusText As String = e.Value.ToString().Trim()

                    ' Color coding based on status
                    If statusText.Equals("Inactive", StringComparison.OrdinalIgnoreCase) Then
                        e.CellStyle.BackColor = Color.LightCoral
                        e.CellStyle.ForeColor = Color.DarkRed
                        e.CellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
                    ElseIf statusText.Equals("Active", StringComparison.OrdinalIgnoreCase) Then
                        e.CellStyle.BackColor = Color.LightGreen
                        e.CellStyle.ForeColor = Color.DarkGreen
                        e.CellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
                    End If
                End If
            End If
        Catch ex As Exception
            ' Ignore formatting errors
        End Try
    End Sub

    Private Sub LoadPage()
        Try
            Dim hasFilter As Boolean = SupplierIdFilter > 0
            Dim countSql As String = "SELECT COUNT(*) FROM tbl_supplier_products" & If(hasFilter, " WHERE supplierID = ?", "")

            Dim dataSql As New System.Text.StringBuilder()
            dataSql.Append("SELECT sp.sProductID, sp.product_name, sp.category, sp.description, sp.product_price, ")
            dataSql.Append("CASE ")
            dataSql.Append("  WHEN p.productID IS NULL THEN 'Inactive' ")
            dataSql.Append("  WHEN p.stockQuantity <= 0 THEN 'Inactive' ")
            dataSql.Append("  ELSE COALESCE(sp.status, 'Active') ")
            dataSql.Append("END AS status ")
            dataSql.Append("FROM tbl_supplier_products sp ")
            dataSql.Append("LEFT JOIN tbl_products p ON UPPER(TRIM(p.productName)) = UPPER(TRIM(sp.product_name)) ")
            If hasFilter Then dataSql.Append("WHERE sp.supplierID = ? ")
            dataSql.Append("ORDER BY sp.product_name LIMIT ? OFFSET ?")

            Using cn As New Odbc.OdbcConnection(myDSN)
                cn.Open()
                Using cmdCount As New Odbc.OdbcCommand(countSql, cn)
                    If hasFilter Then cmdCount.Parameters.AddWithValue("?", SupplierIdFilter)
                    Dim obj = cmdCount.ExecuteScalar()
                    totalCount = 0
                    If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                        Integer.TryParse(obj.ToString(), totalCount)
                    End If
                End Using

                Using cmd As New Odbc.OdbcCommand(dataSql.ToString(), cn)
                    If hasFilter Then cmd.Parameters.AddWithValue("?", SupplierIdFilter)
                    cmd.Parameters.AddWithValue("?", pageSize)
                    cmd.Parameters.AddWithValue("?", currentPage * pageSize)
                    Dim da As New Odbc.OdbcDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    supplierItemDGV.AutoGenerateColumns = True
                    supplierItemDGV.DataSource = dt
                End Using
            End Using

            Dim totalPages As Integer = If(pageSize > 0, If(totalCount Mod pageSize = 0, totalCount \ pageSize, (totalCount \ pageSize) + 1), 1)
            If totalPages <= 0 Then totalPages = 1
            txtPage.Text = "Page " & (currentPage + 1).ToString() & " of " & totalPages.ToString()
            btnBack.Enabled = currentPage > 0
            btnNext.Enabled = currentPage < (totalPages - 1)
        Catch ex As Exception
            ' non-blocking
        End Try
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
End Class