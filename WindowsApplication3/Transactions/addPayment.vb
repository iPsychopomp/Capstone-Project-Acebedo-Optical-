Public Class addPayment

    Public Property TransactionID As Integer = 0

    Private Sub addPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbMode.Enabled = True

        ' Load available payment methods from tbl_payment_method
        Try
            cmbMode.Items.Clear()

            Call dbConn()
            Dim q As String = "SELECT typeOfPayment FROM tbl_payment_method ORDER BY typeOfPayment"
            Using cmd As New Odbc.OdbcCommand(q, conn)
                Using rdr As Odbc.OdbcDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim t As String = rdr("typeOfPayment").ToString().Trim()
                        If t <> "" AndAlso Not cmbMode.Items.Contains(t) Then
                            cmbMode.Items.Add(t)
                        End If
                    End While
                End Using
            End Using
        Catch
            ' If anything fails, keep whatever is already configured in the designer
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try

        ' Insert placeholder at the top
        Const placeholder As String = "--Select payment method--"
        cmbMode.Items.Insert(0, placeholder)

        ' Select placeholder by default
        cmbMode.SelectedIndex = 0

        ' Initial state: hide G-cash / reference controls
        lblGcash.Visible = False
        txtGcash.Visible = False
        lblRef.Visible = False
        txtRef.Visible = False
        lblCash.Visible = False
        txtCash.Visible = False

        ' Default compact size while no method is chosen
        Me.ClientSize = New Size(366, 241)
        pnlPayment.Size = New Size(332, 130)
        CenterPanelHorizontally()
        btnConfirm.Top = pnlPayment.Bottom + 10
    End Sub

    Private Sub cmbMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMode.SelectedIndexChanged
        If cmbMode.SelectedItem Is Nothing Then
            Return
        End If

        Dim mode As String = cmbMode.SelectedItem.ToString().Trim()

        Const placeholder As String = "--Select payment method--"
        If String.Equals(mode, placeholder, StringComparison.OrdinalIgnoreCase) Then
            ' No specific mode selected yet: hide all amount/reference inputs
            lblCash.Visible = False
            txtCash.Visible = False
            lblGcash.Visible = False
            txtGcash.Visible = False
            lblRef.Visible = False
            txtRef.Visible = False

            pnlPayment.Size = New Size(332, 130)
            Me.ClientSize = New Size(366, 241)
            CenterPanelHorizontally()
            btnConfirm.Top = pnlPayment.Bottom + 10
            Return
        End If

        ' Cash only
        If String.Equals(mode, "Cash", StringComparison.OrdinalIgnoreCase) Then
            ApplyCashMode()
            Return
        End If

        ' Combined modes: "Cash and X" (X can be G-cash, Bank Transfer, Credit Card, Maya, etc.)
        Dim prefix As String = "Cash and"
        If mode.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) Then
            Dim other As String = mode.Substring(prefix.Length).Trim()
            If String.IsNullOrWhiteSpace(other) Then
                other = "Non-cash"
            End If

            ' Label the non-cash part clearly
            lblGcash.Text = other & " Amount:"
            ApplyCashAndGcashMode()
            Return
        End If

        ' Any other value is treated as a pure non-cash method (G-cash, Bank Transfer, Credit Card, Maya, etc.)
        ApplyNonCashMode(mode)
    End Sub

    Private Sub ApplyCashMode()
        lblCash.Visible = True
        txtCash.Visible = True

        lblGcash.Visible = False
        txtGcash.Visible = False
        lblRef.Visible = False
        txtRef.Visible = False

        ' Exact positions for Cash mode
        lblCash.Location = New Point(33, 89)
        txtCash.Location = New Point(38, 111)

        ' Panel size for Cash mode
        pnlPayment.Size = New Size(332, 174)

        ' Form size for Cash mode
        Me.ClientSize = New Size(366, 241)

        CenterPanelHorizontally()

        ' Place Confirm button under panel
        btnConfirm.Top = pnlPayment.Bottom + 10
    End Sub

    Private Sub ApplyGcashMode()
        ' Backwards-compatible wrapper for legacy calls; treat as non-cash G-cash mode
        ApplyNonCashMode("G-cash")
    End Sub

    Private Sub ApplyNonCashMode(modeLabel As String)
        ' Hide cash-only fields
        lblCash.Visible = False
        txtCash.Visible = False

        ' Show non-cash amount and reference
        lblGcash.Visible = True
        txtGcash.Visible = True
        lblRef.Visible = True
        txtRef.Visible = True

        ' Update label based on selected payment method
        If String.IsNullOrWhiteSpace(modeLabel) Then
            lblGcash.Text = "Amount:"
        Else
            lblGcash.Text = modeLabel & " Amount:"
        End If

        ' Exact positions for pure non-cash mode (same as original G-cash layout)
        lblGcash.Location = New Point(33, 89)
        txtGcash.Location = New Point(38, 111)
        lblRef.Location = New Point(33, 148)
        txtRef.Location = New Point(38, 170)

        ' Panel size for non-cash mode
        pnlPayment.Size = New Size(332, 232)

        ' Form size for non-cash mode
        Me.ClientSize = New Size(366, 300)

        CenterPanelHorizontally()

        ' Keep Confirm button just below the panel
        btnConfirm.Top = pnlPayment.Bottom + 10
    End Sub

    Private Sub ApplyCashAndGcashMode()
        lblCash.Visible = True
        txtCash.Visible = True

        lblGcash.Visible = True
        txtGcash.Visible = True
        lblRef.Visible = True
        txtRef.Visible = True

        ' Cash stays with its Cash positions; set G-cash and Ref below it
        lblCash.Location = New Point(33, 89)
        txtCash.Location = New Point(38, 111)

        lblGcash.Location = New Point(33, 148)
        txtGcash.Location = New Point(38, 170)
        lblRef.Location = New Point(33, 207)
        txtRef.Location = New Point(38, 229)

        ' Panel size for Cash and G-cash mode
        pnlPayment.Size = New Size(332, 289)

        ' Form size for Cash and G-cash mode
        Me.ClientSize = New Size(366, 361)

        CenterPanelHorizontally()

        ' Keep Confirm button just below the panel
        btnConfirm.Top = pnlPayment.Bottom + 10
    End Sub

    Private Sub CenterPanelHorizontally()
        ' Center pnlPayment horizontally within the current client width
        Dim newLeft As Integer = (Me.ClientSize.Width - pnlPayment.Width) \ 2
        If newLeft < 0 Then newLeft = 0
        pnlPayment.Left = newLeft
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim mode As String = ""
        If cmbMode.SelectedItem IsNot Nothing Then
            mode = cmbMode.SelectedItem.ToString()
        End If

        Dim cashText As String = txtCash.Text
        Dim gcashText As String = txtGcash.Text
        Dim refText As String = txtRef.Text

        Dim cashAmount As Decimal = 0D
        Dim gcashAmount As Decimal = 0D
        Decimal.TryParse(cashText, cashAmount)
        Decimal.TryParse(gcashText, gcashAmount)

        Dim totalPaid As Decimal = cashAmount + gcashAmount

        ' If opened from Payment.vb, update only Payment and skip addPatientTransaction
        Dim paymentForm As Payment = TryCast(Me.Owner, Payment)
        If paymentForm IsNot Nothing Then
            Try
                paymentForm.lblMode.Text = mode
            Catch
            End Try

            Try
                paymentForm.lblCash.Text = cashAmount.ToString("0.00")
            Catch
            End Try

            Try
                paymentForm.lblGcash.Text = gcashAmount.ToString("0.00")
            Catch
            End Try

            Try
                paymentForm.txtPayment.Text = totalPaid.ToString("0.00")
            Catch
            End Try

            Try
                If paymentForm.txtRef IsNot Nothing Then
                    paymentForm.txtRef.Text = refText
                End If
            Catch
            End Try

        Else
            Dim parent As addPatientTransaction = TryCast(Me.Owner, addPatientTransaction)
            If parent IsNot Nothing Then

                ' Validate against final total in addPatientTransaction
                Dim finalTotal As Decimal = 0D
                Try
                    Decimal.TryParse(parent.txtTotal.Text, finalTotal)
                Catch
                End Try

                If totalPaid > finalTotal AndAlso finalTotal > 0D Then
                    MsgBox("Payment should not exceed the final total.", vbExclamation, "Invalid Payment")
                    Exit Sub
                End If

                ' Push values back to parent form
                Try
                    parent.lblMode.Text = mode
                Catch
                End Try

                Try
                    parent.lblCash.Text = cashAmount.ToString("0.00")
                Catch
                End Try

                Try
                    parent.lblGcash.Text = gcashAmount.ToString("0.00")
                Catch
                End Try

                Try
                    If parent.txtReference IsNot Nothing Then
                        parent.txtReference.Text = refText
                    End If
                Catch
                End Try

                Try
                    If parent.txtAmountPaid IsNot Nothing Then
                        parent.txtAmountPaid.Text = totalPaid.ToString("0.00")
                    End If
                Catch
                End Try
            End If
        End If

        Me.Close()
    End Sub

    ' Numeric-only validation for payment textboxes
    Private Sub txtCash_TextChanged(sender As Object, e As EventArgs) Handles txtCash.TextChanged
        Dim cursorPos As Integer = txtCash.SelectionStart
        Dim text As String = txtCash.Text

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
        If txtCash.Text <> validText Then
            txtCash.Text = validText
            txtCash.SelectionStart = Math.Min(cursorPos, validText.Length)
        End If
    End Sub

    Private Sub txtGcash_TextChanged(sender As Object, e As EventArgs) Handles txtGcash.TextChanged
        Dim cursorPos As Integer = txtGcash.SelectionStart
        Dim text As String = txtGcash.Text

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
        If txtGcash.Text <> validText Then
            txtGcash.Text = validText
            txtGcash.SelectionStart = Math.Min(cursorPos, validText.Length)
        End If
    End Sub

    Private Sub txtRef_TextChanged(sender As Object, e As EventArgs) Handles txtRef.TextChanged
        Dim cursorPos As Integer = txtRef.SelectionStart
        Dim text As String = txtRef.Text

        ' Allow only numbers (no decimal for reference numbers)
        Dim validText As String = ""
        For Each ch As Char In text
            If Char.IsDigit(ch) Then
                validText &= ch
            End If
        Next

        ' Limit to 13 characters
        If validText.Length > 13 Then
            validText = validText.Substring(0, 13)
        End If

        ' Update text if changed
        If txtRef.Text <> validText Then
            txtRef.Text = validText
            txtRef.SelectionStart = Math.Min(cursorPos, validText.Length)
        End If
    End Sub

End Class