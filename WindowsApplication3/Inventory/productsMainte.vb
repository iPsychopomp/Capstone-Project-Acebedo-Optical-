Imports System.Data.Odbc

Public Class productsMainte

    Private currentProductID As Integer = 0

    Private Sub productsMainte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
        ConfigureGridBinding()
        DgvStyle(dgvProducts)
    End Sub

    Public Sub DgvStyle(ByRef doctorsDGV As DataGridView)
        ' Basic Grid Setup
        doctorsDGV.AutoGenerateColumns = False
        doctorsDGV.AllowUserToAddRows = False
        doctorsDGV.AllowUserToDeleteRows = False
        doctorsDGV.RowHeadersVisible = False
        doctorsDGV.BorderStyle = BorderStyle.None
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

    Private Sub ConfigureGridBinding()
        Try
            If dgvProducts.Columns.Count >= 4 Then
                dgvProducts.Columns("Column1").DataPropertyName = "allProductID"
                dgvProducts.Columns("Column2").DataPropertyName = "productName"
                dgvProducts.Columns("Column3").DataPropertyName = "category"
                dgvProducts.Columns("Column4").DataPropertyName = "description"
            End If
        Catch
        End Try
    End Sub

    Private Sub LoadProducts(Optional category As String = "", Optional searchText As String = "")
        Try
            Call dbConn()

            Dim dt As New DataTable()
            Dim sql As String = "SELECT allProductID, productName, category, description FROM tbl_all_products"

            Dim hasCategory As Boolean = Not String.IsNullOrWhiteSpace(category)
            Dim hasSearch As Boolean = Not String.IsNullOrWhiteSpace(searchText)

            If hasCategory OrElse hasSearch Then
                sql &= " WHERE "
                Dim first As Boolean = True

                If hasCategory Then
                    sql &= "category = ?"
                    first = False
                End If

                If hasSearch Then
                    If Not first Then sql &= " AND "
                    sql &= "productName LIKE ?"
                End If
            End If

            sql &= " ORDER BY productName"

            Using cmd As New OdbcCommand(sql, conn)
                If hasCategory Then
                    cmd.Parameters.AddWithValue("?", category)
                End If

                If hasSearch Then
                    Dim pattern As String = "%" & searchText & "%"
                    cmd.Parameters.AddWithValue("?", pattern)
                End If

                Using da As New OdbcDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            dgvProducts.AutoGenerateColumns = False
            dgvProducts.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim term As String = ""
        Dim selectedCategory As String = ""

        Try
            term = txtSearch.Text.Trim()
        Catch
        End Try

        Try
            If cmbCategory IsNot Nothing AndAlso cmbCategory.SelectedIndex >= 0 AndAlso Not String.IsNullOrWhiteSpace(cmbCategory.Text) Then
                selectedCategory = cmbCategory.Text.Trim()
            End If
        Catch
        End Try

        If String.IsNullOrWhiteSpace(term) AndAlso String.IsNullOrWhiteSpace(selectedCategory) Then
            LoadProducts()
        Else
            LoadProducts(selectedCategory, term)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' When search box is cleared, reload products for current category (if any)
        Try
            If String.IsNullOrWhiteSpace(txtSearch.Text) Then
                Dim selectedCategory As String = ""
                Try
                    If cmbCategory IsNot Nothing AndAlso cmbCategory.SelectedIndex >= 0 AndAlso Not String.IsNullOrWhiteSpace(cmbCategory.Text) Then
                        selectedCategory = cmbCategory.Text.Trim()
                    End If
                Catch
                End Try

                LoadProducts(selectedCategory)
            End If
        Catch
        End Try
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        ' When category changes, reload products limited to that category and current search text
        Dim selectedCategory As String = ""
        Dim term As String = ""

        Try
            If cmbCategory IsNot Nothing AndAlso cmbCategory.SelectedIndex >= 0 AndAlso Not String.IsNullOrWhiteSpace(cmbCategory.Text) Then
                selectedCategory = cmbCategory.Text.Trim()
            End If
        Catch
        End Try

        Try
            term = txtSearch.Text.Trim()
        Catch
        End Try

        LoadProducts(selectedCategory, term)
    End Sub

    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(txtProductName.Text) Then
            MessageBox.Show("Please enter a product name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtProductName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtCategory.Text) Then
            MessageBox.Show("Please enter a category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCategory.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            MessageBox.Show("Please enter a description.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDescription.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ClearFields()
        txtProductName.Clear()
        txtCategory.Clear()
        txtDescription.Clear()
        currentProductID = 0
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateFields() Then Exit Sub

        If MessageBox.Show("Are you sure you want to add this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Call dbConn()

            Dim sql As String = "INSERT INTO tbl_all_products (productName, category, description) VALUES (?, ?, ?)"
            Using cmd As New OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", txtProductName.Text.Trim())
                cmd.Parameters.AddWithValue("?", txtCategory.Text.Trim())
                cmd.Parameters.AddWithValue("?", txtDescription.Text.Trim())
                cmd.ExecuteNonQuery()
            End Using

            ' Audit trail (Action: Add)
            Try
                InsertAuditTrail(GlobalVariables.LoggedInUserID, "Add", "Added product: " & txtProductName.Text.Trim())
            Catch
            End Try

            MessageBox.Show("Product added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadProducts()

        Catch ex As Exception
            MessageBox.Show("Error adding product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
    End Sub

    Private Sub dgvProducts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellClick
        If e.RowIndex < 0 OrElse dgvProducts.CurrentRow Is Nothing Then Return

        Try
            Dim row As DataGridViewRow = dgvProducts.Rows(e.RowIndex)

            Dim idObj = row.Cells("Column1").Value
            If idObj IsNot Nothing AndAlso Integer.TryParse(idObj.ToString(), currentProductID) Then
                txtProductName.Text = If(row.Cells("Column2").Value, "").ToString()
                txtCategory.Text = If(row.Cells("Column3").Value, "").ToString()
                txtDescription.Text = If(row.Cells("Column4").Value, "").ToString()
            Else
                currentProductID = 0
            End If
        Catch
            currentProductID = 0
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If currentProductID <= 0 Then
            MessageBox.Show("Please select a product to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not ValidateFields() Then Exit Sub

        If MessageBox.Show("Are you sure you want to edit this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Call dbConn()

            Dim sql As String = "UPDATE tbl_all_products SET productName = ?, category = ?, description = ? WHERE allProductID = ?"
            Using cmd As New OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", txtProductName.Text.Trim())
                cmd.Parameters.AddWithValue("?", txtCategory.Text.Trim())
                cmd.Parameters.AddWithValue("?", txtDescription.Text.Trim())
                cmd.Parameters.AddWithValue("?", currentProductID)
                cmd.ExecuteNonQuery()
            End Using

            ' Audit trail (Action: Update)
            Try
                InsertAuditTrail(GlobalVariables.LoggedInUserID, "Update", "Updated product: " & txtProductName.Text.Trim())
            Catch
            End Try

            MessageBox.Show("Product updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadProducts()

        Catch ex As Exception
            MessageBox.Show("Error updating product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProducts.CurrentRow Is Nothing OrElse dgvProducts.CurrentRow.IsNewRow Then
            MessageBox.Show("Please select a product to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim id As Integer = 0
        Dim prodName As String = ""

        Try
            Dim cellValue = dgvProducts.CurrentRow.Cells("Column1").Value
            If cellValue Is Nothing OrElse Not Integer.TryParse(cellValue.ToString(), id) OrElse id <= 0 Then
                MessageBox.Show("Unable to determine the selected product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Get product name for audit trail (Column2)
            Try
                Dim nameCell = dgvProducts.CurrentRow.Cells("Column2").Value
                If nameCell IsNot Nothing Then
                    prodName = nameCell.ToString()
                End If
            Catch
            End Try
        Catch
            MessageBox.Show("Unable to determine the selected product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        If MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Call dbConn()

            Dim sql As String = "DELETE FROM tbl_all_products WHERE allProductID = ?"
            Using cmd As New OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", id)
                cmd.ExecuteNonQuery()
            End Using

            ' Audit trail (Action: Delete)
            Try
                Dim desc As String = If(String.IsNullOrWhiteSpace(prodName), "Deleted product.", "Deleted product: " & prodName)
                InsertAuditTrail(GlobalVariables.LoggedInUserID, "Delete", desc)
            Catch
            End Try

            MessageBox.Show("Product deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearFields()
            LoadProducts()

        Catch ex As Exception
            MessageBox.Show("Error deleting product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub InsertAuditTrail(userID As Integer, actionType As String, actionDetails As String)
        Dim connectionString As String = "DSN=dsnsystem"
        Using c As New OdbcConnection(connectionString)
            Try
                c.Open()
                Dim q As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?)"
                Using cmd As New OdbcCommand(q, c)
                    cmd.Parameters.AddWithValue("?", userID)
                    cmd.Parameters.AddWithValue("?", GlobalVariables.LoggedInUser)
                    cmd.Parameters.AddWithValue("?", actionType)
                    cmd.Parameters.AddWithValue("?", actionDetails)
                    cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                    cmd.ExecuteNonQuery()
                End Using
            Catch
                ' ignore audit failure here
            End Try
        End Using
    End Sub

End Class