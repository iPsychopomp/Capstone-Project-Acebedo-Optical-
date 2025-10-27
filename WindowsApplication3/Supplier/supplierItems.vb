Public Class supplierItems
    ' Optional filter: when set (>0), only show items for this supplier ID
    Public Property SupplierIdFilter As Integer = 0

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
                LoadSupplierItems()
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
            Dim dgv As DataGridView = FindDataGridView()
            If dgv Is Nothing Then
                ' No DataGridView found, just return silently
                Return
            End If

            Call dbConn()

            ' Prepare unified table schema
            Dim dt As New DataTable()
            dt.Columns.Add("sProductID", GetType(Integer))
            dt.Columns.Add("product_name", GetType(String))
            dt.Columns.Add("category", GetType(String))
            dt.Columns.Add("description", GetType(String))
            dt.Columns.Add("product_price", GetType(Decimal))
            dt.Columns.Add("status", GetType(String))
            'dt.Columns.Add("supplierName", GetType(String))

            ' 1) Load from tbl_supplier_products
            Dim q1 As String = "SELECT sp.sProductID, sp.product_name, sp.category, sp.description, sp.product_price, sp.status " & _
                               "FROM tbl_supplier_products sp " & _
                               If(SupplierIdFilter > 0, "WHERE sp.supplierID = ? ", "") & _
                               "ORDER BY sp.product_name"

            Using cmd1 As New Odbc.OdbcCommand(q1, conn)
                If SupplierIdFilter > 0 Then cmd1.Parameters.AddWithValue("?", SupplierIdFilter)
                Using r1 = cmd1.ExecuteReader()
                    While r1.Read()
                        Dim row = dt.NewRow()
                        row("sProductID") = If(IsDBNull(r1("sProductID")), 0, Convert.ToInt32(r1("sProductID")))
                        row("product_name") = r1("product_name").ToString()
                        row("category") = r1("category").ToString()
                        row("description") = r1("description").ToString()
                        row("product_price") = If(IsDBNull(r1("product_price")), 0D, Convert.ToDecimal(r1("product_price")))
                        row("status") = If(IsDBNull(r1("status")), "", r1("status").ToString())
                        'row("supplierName") = If(IsDBNull(r1("supplierName")), "", r1("supplierName").ToString())
                        dt.Rows.Add(row)
                    End While
                End Using
            End Using

            ' Do NOT load from inventory tbl_products here. This view is strictly for supplier catalog items.

            ' Bind merged results
            dgv.AutoGenerateColumns = True
            dgv.DataSource = dt

            ' Format columns
            If dgv.Columns.Contains("sProductID") Then dgv.Columns("sProductID").HeaderText = "Product ID"
            If dgv.Columns.Contains("product_name") Then dgv.Columns("product_name").HeaderText = "Product Name"
            If dgv.Columns.Contains("product_price") Then dgv.Columns("product_price").DefaultCellStyle.Format = "C2"

            If conn.State = ConnectionState.Open Then conn.Close()

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
            Call dbConn()
            If String.IsNullOrWhiteSpace(term) Then
                ' Load all when search is empty
                LoadSupplierItems()
            Else
                ' Search by product name only (partial match)
                Dim dgv As DataGridView = FindDataGridView()
                If dgv Is Nothing Then Return

                Dim sb As New System.Text.StringBuilder()
                sb.Append("SELECT sp.sProductID, sp.product_name, sp.category, sp.description, sp.product_price, sp.status ")
                sb.Append("FROM tbl_supplier_products sp ")
                sb.Append("WHERE sp.product_name LIKE ? ")
                If SupplierIdFilter > 0 Then
                    sb.Append("AND sp.supplierID = ? ")
                End If
                sb.Append("ORDER BY sp.product_name")

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
                        If dgv.Columns.Contains("product_price") Then dgv.Columns("product_price").DefaultCellStyle.Format = "C2"
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
        DgvStyle(FindDataGridView())
    End Sub

End Class