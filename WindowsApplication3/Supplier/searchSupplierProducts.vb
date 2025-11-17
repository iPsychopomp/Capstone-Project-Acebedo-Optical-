Public Class searchSupplierProducts

    ' Optional filter passed from OrderProduct (supplier name)
    Public Property SupplierNameFilter As String = String.Empty

    Private Sub searchSupplierProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadSupplierProducts()
        Catch
        End Try
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
            Dim quantity As Integer = 1

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

            Try
                If numQty IsNot Nothing Then
                    Dim q As Integer = Convert.ToInt32(numQty.Value)
                    If q > 0 Then quantity = q
                End If
            Catch
            End Try

            If String.IsNullOrWhiteSpace(productName) OrElse unitPrice <= 0D Then Exit Sub

            Dim ownerForm As OrderProduct = TryCast(Me.Owner, OrderProduct)
            If ownerForm IsNot Nothing Then
                ownerForm.AddOrUpdateProductFromSupplier(productID, productName, category, unitPrice, supplierName, quantity)
            End If

            Me.Close()
        Catch
        End Try
    End Sub

End Class