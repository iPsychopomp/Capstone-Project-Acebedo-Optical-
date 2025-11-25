Public Class searchSupplierProducts

    ' Optional filter passed from OrderProduct (supplier name)
    Public Property SupplierNameFilter As String = String.Empty

    Private Sub searchSupplierProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadSupplierProducts()
            LoadSupplierCategories()
            DgvStyle(searchProductDGV)
        Catch
        End Try
    End Sub

    Public Sub DgvStyle(ByRef doctorsDGV As DataGridView)
        ' Basic Grid Setup
        doctorsDGV.AutoGenerateColumns = False
        doctorsDGV.AllowUserToAddRows = False
        doctorsDGV.AllowUserToDeleteRows = False
        doctorsDGV.RowHeadersVisible = False
        doctorsDGV.BorderStyle = BorderStyle.FixedSingle
        doctorsDGV.BackgroundColor = Color.White
        doctorsDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        doctorsDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        doctorsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        doctorsDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        doctorsDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        doctorsDGV.EnableHeadersVisualStyles = False
        doctorsDGV.DefaultCellStyle.ForeColor = Color.Black
        doctorsDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        doctorsDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        doctorsDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        doctorsDGV.GridColor = Color.Silver
        doctorsDGV.DefaultCellStyle.Padding = New Padding(5)
        doctorsDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        doctorsDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        doctorsDGV.ReadOnly = True
        doctorsDGV.MultiSelect = False
        doctorsDGV.AllowUserToResizeRows = False
        doctorsDGV.RowTemplate.Height = 30
        doctorsDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        doctorsDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        ' Center align all column headers
        For Each col As DataGridViewColumn In doctorsDGV.Columns
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub

    Private Sub LoadSupplierProducts(Optional categoryFilter As String = "")
        Try
            Call dbConn()

            Dim sql As String = "SELECT * FROM db_viewsupplierproductsearch"

            Dim useSupplier As Boolean = Not String.IsNullOrWhiteSpace(SupplierNameFilter)
            Dim useCategory As Boolean = Not String.IsNullOrWhiteSpace(categoryFilter) AndAlso Not String.Equals(categoryFilter, "All Products", StringComparison.OrdinalIgnoreCase)

            If useSupplier OrElse useCategory Then
                sql &= " WHERE "
                Dim first As Boolean = True
                If useSupplier Then
                    sql &= "supplierName = ?"
                    first = False
                End If
                If useCategory Then
                    If Not first Then sql &= " AND "
                    sql &= "category = ?"
                End If
            End If

            Using cmd As New Odbc.OdbcCommand(sql, conn)
                If useSupplier Then
                    cmd.Parameters.AddWithValue("?", SupplierNameFilter)
                End If
                If useCategory Then
                    cmd.Parameters.AddWithValue("?", categoryFilter)
                End If

                Dim dt As New DataTable()
                Using da As New Odbc.OdbcDataAdapter(cmd)
                    da.Fill(dt)
                End Using

                Try
                    searchProductDGV.DataSource = dt
                Catch
                End Try
            End Using

        Catch ex As Exception
            MsgBox("Error loading supplier products: " & ex.Message, vbCritical, "Error")
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            Catch
            End Try
        End Try
    End Sub

    ' Load distinct categories into cmbCategories, including an "All Products" option
    Private Sub LoadSupplierCategories()
        Try
            If cmbCategories Is Nothing Then Return

            Call dbConn()

            Dim sql As String = "SELECT DISTINCT category FROM db_viewsupplierproductsearch"
            Dim useSupplier As Boolean = Not String.IsNullOrWhiteSpace(SupplierNameFilter)
            If useSupplier Then
                sql &= " WHERE supplierName = ?"
            End If
            sql &= " ORDER BY category"

            Dim dt As New DataTable()
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                If useSupplier Then
                    cmd.Parameters.AddWithValue("?", SupplierNameFilter)
                End If

                Using da As New Odbc.OdbcDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            Dim previous As String = String.Empty
            Try
                If cmbCategories.SelectedItem IsNot Nothing Then
                    previous = cmbCategories.SelectedItem.ToString().Trim()
                End If
            Catch
            End Try

            cmbCategories.Items.Clear()
            cmbCategories.Items.Add("All Products")

            For Each r As DataRow In dt.Rows
                Dim cat As String = ""
                Try
                    cat = Convert.ToString(r("category")).Trim()
                Catch
                End Try
                If Not String.IsNullOrWhiteSpace(cat) Then
                    cmbCategories.Items.Add(cat)
                End If
            Next

            If Not String.IsNullOrWhiteSpace(previous) Then
                Dim idx As Integer = -1
                Try
                    idx = cmbCategories.Items.IndexOf(previous)
                Catch
                End Try
                If idx >= 0 Then
                    cmbCategories.SelectedIndex = idx
                    Return
                End If
            End If

            If cmbCategories.Items.Count > 0 Then
                cmbCategories.SelectedIndex = 0
            End If

        Catch
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
    End Sub

    ' Centralized selection logic used by btnSelect (and can be reused if double-click is needed)
    Private Sub SelectProductFromRow(ByVal row As DataGridViewRow)
        If row Is Nothing Then Exit Sub

        Try
            Dim productID As Integer = 0
            Dim productName As String = ""
            Dim category As String = ""
            Dim unitPrice As Decimal = 0D
            Dim supplierName As String = ""

            Try
                Integer.TryParse(Convert.ToString(row.Cells("Column1").Value), productID)
            Catch
            End Try

            Try
                productName = Convert.ToString(row.Cells("Column2").Value)
            Catch
            End Try

            Try
                category = Convert.ToString(row.Cells("Column4").Value)
            Catch
            End Try

            Try
                Decimal.TryParse(Convert.ToString(row.Cells("Column5").Value), unitPrice)
            Catch
            End Try

            Try
                supplierName = Convert.ToString(row.Cells("Column7").Value)
            Catch
            End Try

            If String.IsNullOrWhiteSpace(productName) OrElse unitPrice <= 0D Then Exit Sub

            Dim ownerForm As OrderProduct = TryCast(Me.Owner, OrderProduct)
            If ownerForm Is Nothing Then Exit Sub

            ' Open the productCount dialog to let user choose quantity
            Using qtyForm As New productCount()
                qtyForm.Owner = Me
                qtyForm.TargetOrderForm = ownerForm
                qtyForm.SelectedProductID = productID
                qtyForm.SelectedProductName = productName
                qtyForm.SelectedCategory = category
                qtyForm.SelectedUnitPrice = unitPrice
                qtyForm.SelectedSupplierName = supplierName

                qtyForm.StartPosition = FormStartPosition.CenterScreen
                qtyForm.ShowDialog(Me)
            End Using

        Catch
        End Try
    End Sub

    ' New: select product via button instead of DataGridView double-click
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Try
            If searchProductDGV Is Nothing OrElse searchProductDGV.CurrentRow Is Nothing Then Exit Sub
            If searchProductDGV.CurrentRow.Index < 0 Then Exit Sub

            SelectProductFromRow(searchProductDGV.CurrentRow)
        Catch
        End Try
    End Sub

    ' Optional: keep method (without Handles) if you ever want to re-enable double-click
    Private Sub searchProductDGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            If e Is Nothing OrElse e.RowIndex < 0 Then Exit Sub
            If searchProductDGV Is Nothing OrElse e.RowIndex >= searchProductDGV.Rows.Count Then Exit Sub

            Dim row As DataGridViewRow = searchProductDGV.Rows(e.RowIndex)
            SelectProductFromRow(row)
        Catch
        End Try
    End Sub

    ' Filter by category when cmbCategories changes
    Private Sub cmbCategories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategories.SelectedIndexChanged
        Try
            If cmbCategories Is Nothing OrElse cmbCategories.SelectedIndex < 0 Then
                LoadSupplierProducts()
                Return
            End If

            Dim selectedCategory As String = cmbCategories.SelectedItem.ToString().Trim()

            If String.Equals(selectedCategory, "All Products", StringComparison.OrdinalIgnoreCase) Then
                LoadSupplierProducts()
            Else
                LoadSupplierProducts(selectedCategory)
            End If
        Catch
        End Try
    End Sub

End Class