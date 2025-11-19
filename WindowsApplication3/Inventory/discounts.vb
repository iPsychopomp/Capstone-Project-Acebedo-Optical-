Imports System.Data.Odbc

Partial Class discounts

    Private Sub discounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductsForDiscounts()
        DgvStyle(dgvProductsDiscounts)
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

    Private Sub LoadProductsForDiscounts(Optional category As String = "", Optional searchText As String = "")
        Try
            Call dbConn()

            Dim dt As New DataTable()
            Dim sql As String = "SELECT p.productID, p.productName, p.category, p.description, " & _
                                "p.unitPrice, CONCAT(ROUND(p.discount * 100, 2), '%') AS discount, " & _
                                "CASE WHEN p.discount > 0 THEN ROUND(p.unitPrice * (1 - p.discount), 2) ELSE NULL END AS discountedPrice " & _
                                "FROM tbl_products p"

            Dim hasCategory As Boolean = Not String.IsNullOrWhiteSpace(category)
            Dim hasSearch As Boolean = Not String.IsNullOrWhiteSpace(searchText)

            If hasCategory OrElse hasSearch Then
                sql &= " WHERE "
                Dim first As Boolean = True

                If hasCategory Then
                    sql &= "p.category = ?"
                    first = False
                End If

                If hasSearch Then
                    If Not first Then sql &= " AND "
                    sql &= "p.productName LIKE ?"
                End If
            End If

            sql &= " ORDER BY p.productName"

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

            dgvProductsDiscounts.AutoGenerateColumns = False
            dgvProductsDiscounts.DataSource = dt

            ' Ensure columns are bound correctly
            Try
                If dgvProductsDiscounts.Columns.Count >= 7 Then
                    dgvProductsDiscounts.Columns("Column1").DataPropertyName = "productID"
                    dgvProductsDiscounts.Columns("Column2").DataPropertyName = "productName"
                    dgvProductsDiscounts.Columns("Column3").DataPropertyName = "category"
                    dgvProductsDiscounts.Columns("Column4").DataPropertyName = "description"
                    dgvProductsDiscounts.Columns("Column5").DataPropertyName = "unitPrice"
                    dgvProductsDiscounts.Columns("Column6").DataPropertyName = "discount"
                    dgvProductsDiscounts.Columns("Column7").DataPropertyName = "discountedPrice"
                End If
            Catch
            End Try

        Catch ex As Exception
            MessageBox.Show("Error loading products for discounts: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        ' If no search and no category, show all
        If String.IsNullOrWhiteSpace(term) AndAlso String.IsNullOrWhiteSpace(selectedCategory) Then
            LoadProductsForDiscounts()
        Else
            LoadProductsForDiscounts(selectedCategory, term)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' When search box is cleared, reload list for current category
        Try
            If String.IsNullOrWhiteSpace(txtSearch.Text) Then
                Dim selectedCategory As String = ""
                Try
                    If cmbCategory IsNot Nothing AndAlso cmbCategory.SelectedIndex >= 0 AndAlso Not String.IsNullOrWhiteSpace(cmbCategory.Text) Then
                        selectedCategory = cmbCategory.Text.Trim()
                    End If
                Catch
                End Try

                LoadProductsForDiscounts(selectedCategory)
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

        LoadProductsForDiscounts(selectedCategory, term)
    End Sub

    Private Sub dgvProductsDiscounts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductsDiscounts.CellClick
        If e.RowIndex < 0 OrElse dgvProductsDiscounts.CurrentRow Is Nothing Then
            Exit Sub
        End If

        Try
            Dim row As DataGridViewRow = dgvProductsDiscounts.Rows(e.RowIndex)
            Dim discObj = row.Cells("Column6").Value

            If discObj Is Nothing OrElse IsDBNull(discObj) Then
                txtDiscount.Clear()
                Exit Sub
            End If

            Dim discText As String = discObj.ToString().Trim()
            If String.IsNullOrEmpty(discText) Then
                txtDiscount.Clear()
                Exit Sub
            End If

            ' Values come like "10%"; strip % and whitespace
            discText = discText.Replace("%", "").Trim()
            txtDiscount.Text = discText

        Catch
            txtDiscount.Clear()
        End Try
    End Sub

    Private Sub btnAddDiscount_Click(sender As Object, e As EventArgs) Handles btnAddDiscount.Click
        ' Validate selection
        If dgvProductsDiscounts.CurrentRow Is Nothing OrElse dgvProductsDiscounts.CurrentRow.IsNewRow Then
            MessageBox.Show("Please select a product to apply a discount.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' Validate discount input
        Dim discText As String = txtDiscount.Text.Trim()

        If String.IsNullOrWhiteSpace(discText) Then
            MessageBox.Show("Please enter a discount percentage.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDiscount.Focus()
            Exit Sub
        End If

        Dim discValue As Decimal
        If Not Decimal.TryParse(discText, discValue) Then
            MessageBox.Show("Please enter a valid numeric discount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDiscount.Focus()
            Exit Sub
        End If

        If discValue < 0D OrElse discValue > 100D Then
            MessageBox.Show("Discount must be between 0 and 100.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDiscount.Focus()
            Exit Sub
        End If

        ' Get selected product ID and name
        Dim productID As Integer = 0
        Dim productName As String = ""

        Try
            Dim idObj = dgvProductsDiscounts.CurrentRow.Cells("Column1").Value
            If idObj Is Nothing OrElse Not Integer.TryParse(idObj.ToString(), productID) OrElse productID <= 0 Then
                MessageBox.Show("Unable to determine the selected product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Try
                Dim nameCell = dgvProductsDiscounts.CurrentRow.Cells("Column2").Value
                If nameCell IsNot Nothing Then
                    productName = nameCell.ToString()
                End If
            Catch
            End Try

        Catch
            MessageBox.Show("Unable to determine the selected product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' Confirm
        If MessageBox.Show("Are you sure you want to apply this discount?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        ' Convert percentage to decimal (e.g. 10 -> 0.10)
        Dim discDecimal As Decimal = discValue / 100D

        Try
            Call dbConn()

            Dim sql As String = "UPDATE tbl_products SET discount = ?, discountAppliedDate = ? WHERE productID = ?"
            Using cmd As New OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", CDbl(discDecimal))

                If discDecimal > 0D Then
                    cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                Else
                    cmd.Parameters.AddWithValue("?", DBNull.Value)
                End If

                cmd.Parameters.AddWithValue("?", productID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Discount updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Audit trail (Action: Update)
            Try
                Dim detail As String = "Updated discount for product: " & productName & " to " & discValue.ToString("0.##") & "%"
                InsertAuditTrail(GlobalVariables.LoggedInUserID, "Update", detail)
            Catch
            End Try

            ' Refresh grid to reflect new discount and discounted price
            LoadProductsForDiscounts()

        Catch ex As Exception
            MessageBox.Show("Error updating discount: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        ' Validate selection
        If dgvProductsDiscounts.CurrentRow Is Nothing OrElse dgvProductsDiscounts.CurrentRow.IsNewRow Then
            MessageBox.Show("Please select a product to remove the discount.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim productID As Integer = 0
        Dim productName As String = ""

        Try
            Dim idObj = dgvProductsDiscounts.CurrentRow.Cells("Column1").Value
            If idObj Is Nothing OrElse Not Integer.TryParse(idObj.ToString(), productID) OrElse productID <= 0 Then
                MessageBox.Show("Unable to determine the selected product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Try
                Dim nameCell = dgvProductsDiscounts.CurrentRow.Cells("Column2").Value
                If nameCell IsNot Nothing Then
                    productName = nameCell.ToString()
                End If
            Catch
            End Try

        Catch
            MessageBox.Show("Unable to determine the selected product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        If MessageBox.Show("Are you sure you want to remove the discount for this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            Call dbConn()

            Dim sql As String = "UPDATE tbl_products SET discount = 0, discountAppliedDate = NULL WHERE productID = ?"
            Using cmd As New OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", productID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Discount removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Audit trail (Action: Update)
            Try
                Dim detail As String = "Removed discount for product: " & productName
                InsertAuditTrail(GlobalVariables.LoggedInUserID, "Update", detail)
            Catch
            End Try

            txtDiscount.Clear()
            LoadProductsForDiscounts()

        Catch ex As Exception
            MessageBox.Show("Error removing discount: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
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