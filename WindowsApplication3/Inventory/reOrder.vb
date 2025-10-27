Public Class reOrder

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Private Sub reOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        '    Call dbConn()

        '    Dim sql As String = "SELECT productID, productName, stockQuantity, reorderLevel FROM tbl_products WHERE stockQuantity <= reorderLevel"
        '    Dim dt As New DataTable
        '    Dim da As New Odbc.OdbcDataAdapter(sql, conn)

        '    da.Fill(dt)

        '    ' Check if there are products below the reorder level
        '    If dt.Rows.Count > 0 Then
        '        ReorderDGV.DataSource = dt
        '    Else
        '        MsgBox("No products are below or at the reorder level.", vbInformation, "Stock Check")
        '        ReorderDGV.DataSource = Nothing ' Clear DGV if no products match
        '    End If

        'Catch ex As Exception
        '    MsgBox("Error loading reorder level products: " & ex.Message, vbCritical, "Database Error")
        'Finally
        '    If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
        '        conn.Close()
        '    End If
        'End Try
    End Sub

    Private Sub ReorderDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ReorderDGV.CellContentClick

    End Sub
End Class