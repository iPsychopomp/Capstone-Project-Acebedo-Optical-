Public Class productCount

    ' Reference to the OrderProduct form where items will be added
    Public Property TargetOrderForm As OrderProduct

    ' Selected product details passed from searchSupplierProducts
    Public Property SelectedProductID As Integer
    Public Property SelectedProductName As String
    Public Property SelectedCategory As String
    Public Property SelectedUnitPrice As Decimal
    Public Property SelectedSupplierName As String

    Private Sub productCount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If numQty.Minimum < 1D Then
                numQty.Minimum = 1D
            End If
            If numQty.Value < 1D Then
                numQty.Value = 1D
            End If
        Catch
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim qty As Integer = 1
        Try
            qty = Convert.ToInt32(numQty.Value)
        Catch
            qty = 1
        End Try

        If qty <= 0 Then
            MsgBox("Please enter a quantity greater than 0.", vbExclamation, "Invalid Quantity")
            Exit Sub
        End If

        If TargetOrderForm IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(SelectedProductName) AndAlso SelectedUnitPrice > 0D Then
            TargetOrderForm.AddOrUpdateProductFromSupplier(
                SelectedProductID,
                SelectedProductName,
                SelectedCategory,
                SelectedUnitPrice,
                SelectedSupplierName,
                qty)
        End If

        ' Close the search form if this form was opened from it
        Try
            Dim parentSearch As searchSupplierProducts = TryCast(Me.Owner, searchSupplierProducts)
            If parentSearch IsNot Nothing Then
                parentSearch.Close()
            End If
        Catch
        End Try

        Me.Close()
    End Sub

End Class