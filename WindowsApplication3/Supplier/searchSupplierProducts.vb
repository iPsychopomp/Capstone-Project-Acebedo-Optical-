Public Class searchSupplierProducts

    ' Optional filter passed from OrderProduct (supplier name)
    Public Property SupplierNameFilter As String = String.Empty

    Private Sub searchSupplierProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadSupplierProducts()
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

    Private Sub LoadSupplierProducts()
        Try
            Call dbConn()

            Dim sql As String = "SELECT * FROM db_viewsupplierproductsearch"

            Dim useFilter As Boolean = Not String.IsNullOrWhiteSpace(SupplierNameFilter)
            If useFilter Then
                sql &= " WHERE supplierName = ?"
            End If

            Using cmd As New Odbc.OdbcCommand(sql, conn)
                If useFilter Then
                    cmd.Parameters.AddWithValue("?", SupplierNameFilter)
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

    Private Sub searchProductDGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles searchProductDGV.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Sub

            Dim row As DataGridViewRow = searchProductDGV.Rows(e.RowIndex)

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

End Class