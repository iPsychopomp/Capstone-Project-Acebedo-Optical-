Imports System.Data.Odbc

Public Class searchProducts

    ' Pagination state
    Private currentPage As Integer = 1
    Private ReadOnly pageSize As Integer = 20
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 1
    Private currentCategory As String = ""

    Private Sub searchProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadCategories()
            LoadProducts()
            DgvStyle(searchProductDGV)
        Catch
        End Try
    End Sub

    Private Sub LoadCategories()
        Try
            dbConn()
            Dim sql As String = "SELECT DISTINCT category FROM db_viewproductsearch WHERE category IS NOT NULL AND TRIM(category) <> '' ORDER BY category"
            Using cmd As New OdbcCommand(sql, conn)
                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    Dim items As New List(Of String)()
                    While reader.Read()
                        items.Add(reader("category").ToString())
                    End While
                    cmbCategories.Items.Clear()
                    ' Insert synthetic "All Products" option as default (no filter)
                    cmbCategories.Items.Add("All Products")
                    If items.Count > 0 Then
                        cmbCategories.Items.AddRange(items.ToArray())
                    End If
                    cmbCategories.SelectedIndex = 0
                    currentCategory = "" ' All Products => no category filter
                End Using
            End Using
        Catch
        Finally
            Try
                If conn IsNot Nothing Then
                    conn.Close()
                    conn.Dispose()
                End If
            Catch
            End Try
            GC.Collect()
        End Try
    End Sub

    Private Sub LoadProducts()
        Dim dt As New DataTable()
        Try
            Dim selectedCat As String = currentCategory

            dbConn()

            ' Count total records
            Dim countSql As String = "SELECT COUNT(*) FROM db_viewproductsearch" & If(String.IsNullOrEmpty(selectedCat), "", " WHERE category = ?")
            Using countCmd As New OdbcCommand(countSql, conn)
                If Not String.IsNullOrEmpty(selectedCat) Then
                    countCmd.Parameters.AddWithValue("?", selectedCat)
                End If
                Dim obj As Object = countCmd.ExecuteScalar()
                totalRecords = 0
                If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                    Integer.TryParse(Convert.ToString(obj), totalRecords)
                End If
            End Using

            ' Compute total pages
            totalPages = Math.Max(1, CInt(Math.Ceiling(totalRecords / CDbl(pageSize))))
            If currentPage < 1 Then currentPage = 1
            If currentPage > totalPages Then currentPage = totalPages

            ' Fetch current page
            Dim offset As Integer = (currentPage - 1) * pageSize
            Dim dataSql As String = "SELECT * FROM db_viewproductsearch" & _
                                    If(String.IsNullOrEmpty(selectedCat), "", " WHERE category = ?") & _
                                    " ORDER BY productName ASC LIMIT ? OFFSET ?"

            Using cmd As New OdbcCommand(dataSql, conn)
                If Not String.IsNullOrEmpty(selectedCat) Then
                    cmd.Parameters.AddWithValue("?", selectedCat)
                End If
                cmd.Parameters.AddWithValue("?", pageSize)
                cmd.Parameters.AddWithValue("?", offset)
                Using da As New OdbcDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            searchProductDGV.AutoGenerateColumns = False
            searchProductDGV.DataSource = dt

            UpdatePageLabel()
        Catch ex As Exception
            MsgBox("Failed to load products: " & ex.Message, vbCritical, "Error")
        Finally
            Try
                If conn IsNot Nothing Then
                    conn.Close()
                    conn.Dispose()
                End If
            Catch
            End Try
            GC.Collect()
        End Try
    End Sub

    Private Sub UpdatePageLabel()
        Try
            If txtPage IsNot Nothing Then
                txtPage.Text = String.Format("Page {0} of {1}", currentPage, totalPages)
            End If
            If btnBack IsNot Nothing Then btnBack.Enabled = (currentPage > 1)
            If btnNext IsNot Nothing Then btnNext.Enabled = (currentPage < totalPages)
        Catch
        End Try
    End Sub

    Private Sub cmbCategories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategories.SelectedIndexChanged
        Try
            If cmbCategories.SelectedIndex >= 0 Then
                Dim sel As String = cmbCategories.SelectedItem.ToString()
                ' "All Products" means no category filter
                If String.Equals(sel, "All Products", StringComparison.OrdinalIgnoreCase) Then
                    currentCategory = ""
                Else
                    currentCategory = sel
                End If
            Else
                currentCategory = ""
            End If
            currentPage = 1
            LoadProducts()
        Catch
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadProducts()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentPage < totalPages Then
            currentPage += 1
            LoadProducts()
        End If
    End Sub

    Public Sub DgvStyle(ByRef dgv As DataGridView)
        Try
            dgv.AutoGenerateColumns = False
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False
            dgv.BorderStyle = BorderStyle.FixedSingle
            dgv.BackgroundColor = Color.White
            dgv.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.EnableHeadersVisualStyles = False
            dgv.DefaultCellStyle.ForeColor = Color.Black
            dgv.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
            dgv.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black
            dgv.GridColor = Color.Silver
            dgv.DefaultCellStyle.Padding = New Padding(5)
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgv.ReadOnly = True
            dgv.MultiSelect = False
            dgv.AllowUserToResizeRows = False
            dgv.RowTemplate.Height = 30
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            For Each col As DataGridViewColumn In dgv.Columns
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            dgv.Refresh()
        Catch
        End Try
    End Sub

    Private Function GetColumnIndexByKeys(dgv As DataGridView, ParamArray keys() As String) As Integer
        Try
            For Each col As DataGridViewColumn In dgv.Columns
                Dim name As String = If(col.Name, "")
                Dim header As String = If(col.HeaderText, "")
                For Each k In keys
                    If String.Equals(name, k, StringComparison.OrdinalIgnoreCase) _
                        OrElse String.Equals(header, k, StringComparison.OrdinalIgnoreCase) Then
                        Return col.Index
                    End If
                Next
            Next
        Catch
        End Try
        Return -1
    End Function

    Private Sub searchProductDGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles searchProductDGV.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Return

            Dim row As DataGridViewRow = searchProductDGV.Rows(e.RowIndex)

            ' Read fields safely from the bound DataRowView when possible
            Dim productID As String = ""
            Dim productName As String = ""
            Dim category As String = ""
            Dim unitPrice As Decimal = 0D

            Try
                Dim drv = TryCast(row.DataBoundItem, DataRowView)
                If drv IsNot Nothing Then
                    If drv.Row.Table.Columns.Contains("productID") Then productID = Convert.ToString(drv("productID"))
                    If drv.Row.Table.Columns.Contains("productName") Then productName = Convert.ToString(drv("productName"))
                    If drv.Row.Table.Columns.Contains("category") Then category = Convert.ToString(drv("category"))
                    If drv.Row.Table.Columns.Contains("unitPrice") Then Decimal.TryParse(Convert.ToString(drv("unitPrice")), unitPrice)
                    If unitPrice = 0D AndAlso drv.Row.Table.Columns.Contains("price") Then Decimal.TryParse(Convert.ToString(drv("price")), unitPrice)
                Else
                    ' Fallback to named columns present in the grid
                    If searchProductDGV.Columns.Contains("productID") AndAlso row.Cells("productID").Value IsNot Nothing Then
                        productID = Convert.ToString(row.Cells("productID").Value)
                    End If
                    If searchProductDGV.Columns.Contains("productName") AndAlso row.Cells("productName").Value IsNot Nothing Then
                        productName = Convert.ToString(row.Cells("productName").Value)
                    End If
                    If searchProductDGV.Columns.Contains("category") AndAlso row.Cells("category").Value IsNot Nothing Then
                        category = Convert.ToString(row.Cells("category").Value)
                    End If
                    If searchProductDGV.Columns.Contains("unitPrice") AndAlso row.Cells("unitPrice").Value IsNot Nothing Then
                        Decimal.TryParse(Convert.ToString(row.Cells("unitPrice").Value), unitPrice)
                    End If
                End If
            Catch
            End Try

            ' If this is a Lens product, open selectGrade and let it handle
            ' adding the Lens product plus OS/OD rows into the transaction grid.
            If String.Equals(category, "Lens", StringComparison.OrdinalIgnoreCase) Then
                Dim gradeForm As New selectGrade()
                gradeForm.LensProductID = productID
                gradeForm.LensProductName = productName
                gradeForm.LensCategory = category
                gradeForm.LensUnitPrice = unitPrice

                ' Position selectGrade centered over this form
                gradeForm.StartPosition = FormStartPosition.Manual
                Dim screenArea = Screen.FromControl(Me).WorkingArea

                ' Center selectGrade relative to searchProducts
                Dim desiredX As Integer = Me.Left + (Me.Width - gradeForm.Width) \ 2
                Dim desiredY As Integer = Me.Top + (Me.Height - gradeForm.Height) \ 2

                ' Clamp within screen horizontally
                If desiredX + gradeForm.Width > screenArea.Right Then
                    desiredX = screenArea.Right - gradeForm.Width
                End If
                If desiredX < screenArea.Left Then
                    desiredX = screenArea.Left
                End If

                ' Clamp within screen vertically
                If desiredY + gradeForm.Height > screenArea.Bottom Then
                    desiredY = screenArea.Bottom - gradeForm.Height
                End If
                If desiredY < screenArea.Top Then
                    desiredY = screenArea.Top
                End If

                gradeForm.Location = New Point(desiredX, desiredY)

                gradeForm.ShowDialog(Me)
                Return
            End If

            ' Locate open addPatientTransaction form
            Dim target As addPatientTransaction = Nothing
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is addPatientTransaction Then
                    target = DirectCast(frm, addPatientTransaction)
                    Exit For
                End If
            Next

            If target Is Nothing Then
                Me.Close()
                Return
            End If

            Dim dgv As DataGridView = target.dgvSelectedProducts

            ' If bound to a DataSource, detach to allow programmatic row adds
            Try
                If dgv.DataSource IsNot Nothing Then
                    dgv.DataSource = Nothing
                End If
            Catch
            End Try

            ' Ensure required columns exist if Load event was disabled
            If dgv.Columns.Count = 0 Then
                With dgv.Columns
                    .Add("productID", "Product ID")
                    .Add("ProductName", "Product Name")
                    .Add("Category", "Category")
                    .Add("Quantity", "Quantity")
                    .Add("unitPrice", "Price")
                    .Add("Total", "Total")
                End With
                Try
                    dgv.Columns("productID").Visible = False
                    dgv.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgv.Columns("unitPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgv.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Catch
                End Try
            End If

            ' Map by Name/HeaderText (case-insensitive) and support minor variants
            Dim idxProductID As Integer = GetColumnIndexByKeys(dgv, "productID", "Product ID", "ID")
            Dim idxProductName As Integer = GetColumnIndexByKeys(dgv, "ProductName", "Product Name", "productName", "Product")
            Dim idxCategory As Integer = GetColumnIndexByKeys(dgv, "Category", "category")
            Dim idxQuantity As Integer = GetColumnIndexByKeys(dgv, "Quantity", "Quatity")
            Dim idxUnitPrice As Integer = GetColumnIndexByKeys(dgv, "unitPrice", "Price")
            Dim idxTotal As Integer = GetColumnIndexByKeys(dgv, "Total")

            ' If same product exists, increment quantity; else add a new row with qty = 1
            Dim existingRow As DataGridViewRow = Nothing
            Dim keyID As String = If(productID, "").Trim()
            Dim keyName As String = If(productName, "").Trim()

            For Each r As DataGridViewRow In dgv.Rows
                If r.IsNewRow Then Continue For
                Dim matches As Boolean = False
                ' Prefer matching on productID when available
                If idxProductID >= 0 AndAlso keyID <> "" Then
                    Dim cellID As String = If(r.Cells(idxProductID).Value, "").ToString().Trim()
                    If String.Equals(cellID, keyID, StringComparison.OrdinalIgnoreCase) Then
                        matches = True
                    End If
                End If
                ' Fallback: match on product name when ID is missing
                If Not matches AndAlso idxProductName >= 0 AndAlso keyName <> "" Then
                    Dim cellName As String = If(r.Cells(idxProductName).Value, "").ToString().Trim()
                    If String.Equals(cellName, keyName, StringComparison.OrdinalIgnoreCase) Then
                        matches = True
                    End If
                End If
                If matches Then
                    existingRow = r
                    Exit For
                End If
            Next

            Dim qty As Integer = 1
            Dim targetRow As DataGridViewRow = Nothing
            Dim rowIndex As Integer = -1

            If existingRow IsNot Nothing AndAlso idxQuantity >= 0 Then
                Dim currentQty As Integer = 0
                Integer.TryParse(If(existingRow.Cells(idxQuantity).Value, "1").ToString(), currentQty)
                Dim newQty As Integer = currentQty + 1
                existingRow.Cells(idxQuantity).Value = newQty
                ' Ensure price cell has current unitPrice
                If idxUnitPrice >= 0 Then existingRow.Cells(idxUnitPrice).Value = unitPrice.ToString("0.00")
                If idxTotal >= 0 Then existingRow.Cells(idxTotal).Value = (unitPrice * newQty).ToString("0.00")
                targetRow = existingRow
                rowIndex = existingRow.Index
            Else
                rowIndex = dgv.Rows.Add()
                targetRow = dgv.Rows(rowIndex)
                If idxProductID >= 0 Then targetRow.Cells(idxProductID).Value = productID
                If idxProductName >= 0 Then targetRow.Cells(idxProductName).Value = productName
                If idxCategory >= 0 Then targetRow.Cells(idxCategory).Value = category
                If idxQuantity >= 0 Then targetRow.Cells(idxQuantity).Value = qty
                If idxUnitPrice >= 0 Then targetRow.Cells(idxUnitPrice).Value = unitPrice.ToString("0.00")
                If idxTotal >= 0 Then targetRow.Cells(idxTotal).Value = (unitPrice * qty).ToString("0.00")
            End If

            ' Highlight and scroll to the affected row so user sees it
            Try
                dgv.ClearSelection()
                If targetRow IsNot Nothing Then
                    targetRow.Selected = True
                    If rowIndex >= 0 Then
                        dgv.FirstDisplayedScrollingRowIndex = Math.Max(0, rowIndex)
                    End If
                End If
                dgv.Refresh()
            Catch
            End Try
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        End Try
    End Sub

End Class