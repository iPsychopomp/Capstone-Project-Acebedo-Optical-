Public Class selectGrade

    Public Property LensProductID As String
    Public Property LensProductName As String
    Public Property LensCategory As String
    Public Property LensUnitPrice As Decimal

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Try
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

            ' Ensure the grid has the expected columns in the same order
            ' as defined in addPatientTransaction.Designer:
            ' Column4(product ID), Column1(Product Name), Column3(Category),
            ' Column5(Quantity), Column2(Price), Column6(Total)

            ' Add Lens row
            Dim lensQty As Integer = 1
            Dim lensTotal As Decimal = LensUnitPrice * lensQty
            dgv.Rows.Add(LensProductID, LensProductName, LensCategory, lensQty, _
                         LensUnitPrice.ToString("0.00"), lensTotal.ToString("0.00"))

            ' Parse OS/OD prices
            Dim osPrice As Decimal = 0D
            Dim odPrice As Decimal = 0D
            Decimal.TryParse(txtOSPrice.Text, osPrice)
            Decimal.TryParse(txtODPrice.Text, odPrice)

            ' Add OS row (Category left blank as requested)
            If Not String.IsNullOrWhiteSpace(txtOD.Text) Then
                Dim osQty As Integer = 1
                Dim osName As String = "OS Grade: " & txtOD.Text
                dgv.Rows.Add("", osName, "", osQty, _
                             osPrice.ToString("0.00"), (osPrice * osQty).ToString("0.00"))
            End If

            ' Add OD row (Category left blank as requested)
            If Not String.IsNullOrWhiteSpace(txtOS.Text) Then
                Dim odQty As Integer = 1
                Dim odName As String = "OD Grade: " & txtOS.Text
                dgv.Rows.Add("", odName, "", odQty, _
                             odPrice.ToString("0.00"), (odPrice * odQty).ToString("0.00"))
            End If



            Me.Close()
        Catch
            Me.Close()
        End Try
    End Sub

    Private Sub txtOS_TextChanged(sender As Object, e As EventArgs) Handles txtOS.TextChanged
        ' Allow only numeric input with decimal and minus sign, limit to -50.00 to +50.00
        Dim cursorPos As Integer = txtOS.SelectionStart
        Dim text As String = txtOS.Text

        ' Allow only numbers, decimal point, and minus sign
        Dim validText As String = ""
        For Each ch As Char In text
            If Char.IsDigit(ch) OrElse ch = "."c OrElse ch = "-"c Then
                validText &= ch
            End If
        Next

        ' Only allow minus at the beginning
        If validText.IndexOf("-") > 0 Then
            validText = validText.Replace("-", "")
            If validText.Length > 0 Then
                validText = "-" & validText
            End If
        End If

        ' Only allow one decimal point
        Dim dotCount As Integer = validText.Split("."c).Length - 1
        If dotCount > 1 Then
            Dim parts As String() = validText.Split("."c)
            validText = parts(0)
            For i As Integer = 1 To parts.Length - 1
                If i = 1 Then validText &= "."
                validText &= parts(i)
            Next
        End If

        ' Limit to 2 decimal places
        If validText.Contains(".") Then
            Dim parts As String() = validText.Split("."c)
            If parts.Length > 1 AndAlso parts(1).Length > 2 Then
                parts(1) = parts(1).Substring(0, 2)
                validText = parts(0) & "." & parts(1)
            End If
        End If

        ' Validate range (-50.00 to +50.00)
        If Not String.IsNullOrEmpty(validText) AndAlso validText <> "-" Then
            Dim value As Decimal
            If Decimal.TryParse(validText, value) Then
                If value < -50D Then
                    validText = "-50.00"
                ElseIf value > 50D Then
                    validText = "50.00"
                End If
            End If
        End If

        ' Update text if changed
        If txtOS.Text <> validText Then
            txtOS.Text = validText
            txtOS.SelectionStart = Math.Min(cursorPos, validText.Length)
        End If
    End Sub

    Private Sub txtOD_TextChanged(sender As Object, e As EventArgs) Handles txtOD.TextChanged
        ' Allow only numeric input with decimal and minus sign, limit to -50.00 to +50.00
        Dim cursorPos As Integer = txtOD.SelectionStart
        Dim text As String = txtOD.Text

        ' Allow only numbers, decimal point, and minus sign
        Dim validText As String = ""
        For Each ch As Char In text
            If Char.IsDigit(ch) OrElse ch = "."c OrElse ch = "-"c Then
                validText &= ch
            End If
        Next

        ' Only allow minus at the beginning
        If validText.IndexOf("-") > 0 Then
            validText = validText.Replace("-", "")
            If validText.Length > 0 Then
                validText = "-" & validText
            End If
        End If

        ' Only allow one decimal point
        Dim dotCount As Integer = validText.Split("."c).Length - 1
        If dotCount > 1 Then
            Dim parts As String() = validText.Split("."c)
            validText = parts(0)
            For i As Integer = 1 To parts.Length - 1
                If i = 1 Then validText &= "."
                validText &= parts(i)
            Next
        End If

        ' Limit to 2 decimal places
        If validText.Contains(".") Then
            Dim parts As String() = validText.Split("."c)
            If parts.Length > 1 AndAlso parts(1).Length > 2 Then
                parts(1) = parts(1).Substring(0, 2)
                validText = parts(0) & "." & parts(1)
            End If
        End If

        ' Validate range (-50.00 to +50.00)
        If Not String.IsNullOrEmpty(validText) AndAlso validText <> "-" Then
            Dim value As Decimal
            If Decimal.TryParse(validText, value) Then
                If value < -50D Then
                    validText = "-50.00"
                ElseIf value > 50D Then
                    validText = "50.00"
                End If
            End If
        End If

        ' Update text if changed
        If txtOD.Text <> validText Then
            txtOD.Text = validText
            txtOD.SelectionStart = Math.Min(cursorPos, validText.Length)
        End If
    End Sub

    Private Sub txtOSPrice_TextChanged(sender As Object, e As EventArgs) Handles txtOSPrice.TextChanged
        ' Allow only numbers and decimal point for price
        Dim cursorPos As Integer = txtOSPrice.SelectionStart
        Dim text As String = txtOSPrice.Text

        ' Allow only numbers and decimal point
        Dim validText As String = ""
        For Each ch As Char In text
            If Char.IsDigit(ch) OrElse ch = "."c Then
                validText &= ch
            End If
        Next

        ' Only allow one decimal point
        Dim dotCount As Integer = validText.Split("."c).Length - 1
        If dotCount > 1 Then
            Dim parts As String() = validText.Split("."c)
            validText = parts(0)
            For i As Integer = 1 To parts.Length - 1
                If i = 1 Then validText &= "."
                validText &= parts(i)
            Next
        End If

        ' Limit to 2 decimal places
        If validText.Contains(".") Then
            Dim parts As String() = validText.Split("."c)
            If parts.Length > 1 AndAlso parts(1).Length > 2 Then
                parts(1) = parts(1).Substring(0, 2)
                validText = parts(0) & "." & parts(1)
            End If
        End If

        ' Update text if changed
        If txtOSPrice.Text <> validText Then
            txtOSPrice.Text = validText
            txtOSPrice.SelectionStart = Math.Min(cursorPos, validText.Length)
        End If
    End Sub

    Private Sub txtODPrice_TextChanged(sender As Object, e As EventArgs) Handles txtODPrice.TextChanged
        ' Allow only numbers and decimal point for price
        Dim cursorPos As Integer = txtODPrice.SelectionStart
        Dim text As String = txtODPrice.Text

        ' Allow only numbers and decimal point
        Dim validText As String = ""
        For Each ch As Char In text
            If Char.IsDigit(ch) OrElse ch = "."c Then
                validText &= ch
            End If
        Next

        ' Only allow one decimal point
        Dim dotCount As Integer = validText.Split("."c).Length - 1
        If dotCount > 1 Then
            Dim parts As String() = validText.Split("."c)
            validText = parts(0)
            For i As Integer = 1 To parts.Length - 1
                If i = 1 Then validText &= "."
                validText &= parts(i)
            Next
        End If

        ' Limit to 2 decimal places
        If validText.Contains(".") Then
            Dim parts As String() = validText.Split("."c)
            If parts.Length > 1 AndAlso parts(1).Length > 2 Then
                parts(1) = parts(1).Substring(0, 2)
                validText = parts(0) & "." & parts(1)
            End If
        End If

        ' Update text if changed
        If txtODPrice.Text <> validText Then
            txtODPrice.Text = validText
            txtODPrice.SelectionStart = Math.Min(cursorPos, validText.Length)
        End If
    End Sub

End Class