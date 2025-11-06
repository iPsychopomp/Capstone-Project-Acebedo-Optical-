Public Class Supplier
    Private currentPage As Integer = 0
    Private pageSize As Integer = 20
    Private totalCount As Integer = 0

    Private Sub Supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentPage = 0
        LoadPage()
        DgvStyle(SupplierDGV)
    End Sub
    Public Sub DgvStyle(ByRef SupplierDGV As DataGridView)
        ' Basic Grid Setup with guards to avoid NullReference on disposed/not-yet-created grids
        If SupplierDGV Is Nothing OrElse SupplierDGV.IsDisposed Then Exit Sub
        Try
            SupplierDGV.AutoGenerateColumns = False
            SupplierDGV.AllowUserToAddRows = False
            SupplierDGV.AllowUserToDeleteRows = False
            SupplierDGV.RowHeadersVisible = False
            SupplierDGV.BorderStyle = BorderStyle.FixedSingle
            SupplierDGV.BackgroundColor = Color.White
            SupplierDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
            SupplierDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
            SupplierDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
            SupplierDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            SupplierDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
            SupplierDGV.EnableHeadersVisualStyles = False
            SupplierDGV.DefaultCellStyle.ForeColor = Color.Black
            SupplierDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
            SupplierDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
            SupplierDGV.DefaultCellStyle.SelectionForeColor = Color.Black
            SupplierDGV.GridColor = Color.Silver
            SupplierDGV.DefaultCellStyle.Padding = New Padding(5)
            SupplierDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            SupplierDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            SupplierDGV.ReadOnly = True
            SupplierDGV.MultiSelect = False
            SupplierDGV.AllowUserToResizeRows = False
            SupplierDGV.RowTemplate.Height = 30
            SupplierDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
            SupplierDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Catch
            ' swallow styling-time exceptions to avoid crashing UI
        End Try
    End Sub
    Public Sub LoadSupplierData(SupplierDGV As DataGridView)
        Try
            LoadPage()
            SupplierDGV.ClearSelection()
        Catch ex As Exception
            MsgBox("Failed to load data: " & ex.Message, vbCritical, "Error")
        End Try
        DgvStyle(SupplierDGV)
    End Sub
    Private Sub OnAddRecordClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        OnAddRecordClosed(SupplierDGV)
        DgvStyle(SupplierDGV)
    End Sub
    Public Sub OnAddRecordClosed(SupplierDGV As DataGridView)
        LoadPage()
        SupplierDGV.Refresh()
        DgvStyle(SupplierDGV)
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim term As String = txtSearch.Text.Trim()
            If String.IsNullOrWhiteSpace(term) Then
                ' Reset to paginated list when search is empty
                currentPage = 0
                LoadPage()
                Return
            Else
                ' Search by supplier name only (partial match)
                Call dbConn()
                Call LoadDGV("SELECT * FROM tbl_suppliers WHERE supplierName LIKE ?", SupplierDGV, "%" & term & "%")
            End If
            SupplierDGV.ClearSelection()
            ' Notify when no matches found
            If SupplierDGV.Rows.Count = 0 Then
                MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Search failed: " & ex.Message, vbCritical, "Error")
        End Try
        ' When filtered, disable paging controls
        txtPage.Text = "Search results"
        btnBack.Enabled = False
        btnNext.Enabled = False
        DgvStyle(SupplierDGV)
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnSearch.PerformClick()
        End If
        DgvStyle(SupplierDGV)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            currentPage = 0
            LoadPage()
        End If
    End Sub

    Private Sub SupplierDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles SupplierDGV.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                SupplierDGV.Rows(e.RowIndex).Selected = True
            End If
        Catch ex As Exception
            MessageBox.Show("Select Record First" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        DgvStyle(SupplierDGV)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim newSupplier As New addSupplier()
        newSupplier.TopMost = True
        AddHandler newSupplier.FormClosed, AddressOf OnAddRecordClosed
        newSupplier.ShowDialog()
        newSupplier.BringToFront()
        newSupplier.Focus()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If SupplierDGV.SelectedRows.Count > 0 Then
            Dim supplierID As Integer = Convert.ToInt32(SupplierDGV.SelectedRows(0).Cells("Column1").Value)

            If MsgBox("Are you sure you want to edit this record?", vbYesNo + vbQuestion, "Edit") = vbYes Then

                Dim newSupplier As New addSupplier()

                ' Ensure that handler is defined
                AddHandler newSupplier.FormClosed, AddressOf OnAddRecordClosed

                newSupplier.TopMost = True
                newSupplier.Show()
                newSupplier.BringToFront()
                newSupplier.Focus()

                ' Pass supplierID to the new form
                newSupplier.pnlAddUser.Tag = supplierID
                newSupplier.lblhead.Text = "Edit Supplier Information" ' Adjust the title to match editing action
                newSupplier.pbAdd.Visible = False
                newSupplier.pbEdit.Visible = True
                newSupplier.loadRecord(supplierID)

            End If
        Else
            MessageBox.Show("Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click
        Dim order As New OrderProduct()
        Me.Hide()
        order.TopMost = True
        order.ShowDialog(Me)
        Me.Show()
    End Sub
    Private Sub SupplierDGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles SupplierDGV.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso SupplierDGV.Rows.Count > 0 Then
                Dim row = SupplierDGV.Rows(e.RowIndex)
                Dim supplierID As Integer = 0
                Dim supplierName As String = String.Empty

                ' Column1 is bound to supplierID in Designer
                If row.Cells("Column1") IsNot Nothing AndAlso row.Cells("Column1").Value IsNot Nothing Then
                    Integer.TryParse(row.Cells("Column1").Value.ToString(), supplierID)
                End If
                If row.Cells("Column2") IsNot Nothing AndAlso row.Cells("Column2").Value IsNot Nothing Then
                    supplierName = row.Cells("Column2").Value.ToString()
                End If

                Dim frm As New supplierItems()
                frm.SupplierIdFilter = supplierID
                If Not String.IsNullOrEmpty(supplierName) Then
                    frm.Text = "Supplier Products - " & supplierName
                End If
                frm.TopMost = True
                frm.ShowDialog()
                frm.BringToFront()
                frm.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to open supplier items: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub pnlUsers_Paint(sender As Object, e As PaintEventArgs) Handles pnlUsers.Paint

    End Sub

    Private Sub LoadPage()
        Try
            Dim countSql As String = "SELECT COUNT(*) FROM tbl_suppliers"
            Dim dataSql As String = "SELECT * FROM tbl_suppliers ORDER BY supplierID DESC LIMIT ? OFFSET ?"

            Using cn As New Odbc.OdbcConnection(myDSN)
                cn.Open()
                Using cmdCount As New Odbc.OdbcCommand(countSql, cn)
                    Dim obj = cmdCount.ExecuteScalar()
                    totalCount = 0
                    If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                        Integer.TryParse(obj.ToString(), totalCount)
                    End If
                End Using

                Using cmd As New Odbc.OdbcCommand(dataSql, cn)
                    cmd.Parameters.AddWithValue("?", pageSize)
                    cmd.Parameters.AddWithValue("?", currentPage * pageSize)
                    Dim da As New Odbc.OdbcDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    SupplierDGV.AutoGenerateColumns = True
                    SupplierDGV.DataSource = dt
                End Using
            End Using

            Dim totalPages As Integer = If(pageSize > 0, If(totalCount Mod pageSize = 0, totalCount \ pageSize, (totalCount \ pageSize) + 1), 1)
            If totalPages <= 0 Then totalPages = 1
            txtPage.Text = "Page " & (currentPage + 1).ToString() & " of " & totalPages.ToString()
            btnBack.Enabled = currentPage > 0
            btnNext.Enabled = currentPage < (totalPages - 1)
        Catch ex As Exception
            MsgBox("Failed to load suppliers: " & ex.Message, vbCritical, "Error")
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
