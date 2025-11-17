Public Class addPatientTransaction
    Dim patientDict As New Dictionary(Of String, Integer)

    Public Property IsEditMode As Boolean = False

    Public Property TransactionID As Integer = -1
    Private isInitializing As Boolean = False
    Private hasCheckupBaseApplied As Boolean = False
    ' Track and control mode change confirmations during edit
    Private suppressModePrompt As Boolean = False
    Private lastModeIsCheckUpOnly As Boolean = True
    ' Store lens discount value to set after form initialization
    Private loadedLensDiscount As String = ""
    ' Store the patient ID for the transaction
    Private currentPatientID As Integer = 0



    Private Sub btnPSearch_Click(sender As Object, e As EventArgs) Handles btnPSearch.Click
        Try


            ' Show the search patient form with this form as owner
            Using frm As New searchPatient()
                frm.StartPosition = FormStartPosition.CenterScreen
                frm.ShowDialog(Me)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
            ' Ensure this form is shown even if there's an error
            Me.Visible = True
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            ' Position addPatientTransaction and searchProducts so both fit on screen,
            ' centered as a pair horizontally.
            Dim screenArea = Screen.FromControl(Me).WorkingArea
            Dim gap As Integer = 10

            Using prodct As New searchProducts()
                prodct.StartPosition = FormStartPosition.Manual

                ' Compute combined width of the two forms plus gap
                Dim totalWidth As Integer = Me.Width + gap + prodct.Width

                ' Compute left X so the pair is centered on the screen
                Dim pairLeftX As Integer = screenArea.Left + (screenArea.Width - totalWidth) \ 2
                If pairLeftX < screenArea.Left Then
                    pairLeftX = screenArea.Left
                End If

                ' Vertical position: keep current Y but clamp to screen
                Dim topY As Integer = Me.Top
                If topY < screenArea.Top Then
                    topY = screenArea.Top + 5
                End If
                If topY + Me.Height > screenArea.Bottom Then
                    topY = screenArea.Bottom - Me.Height - 5
                End If

                ' Place this form on the left of the pair
                Me.StartPosition = FormStartPosition.Manual
                Me.Location = New Point(pairLeftX, topY)

                ' Place searchProducts to the right of this form
                Dim prodX As Integer = pairLeftX + Me.Width + gap
                Dim prodY As Integer = topY

                ' Clamp searchProducts vertically within screen
                If prodY + prodct.Height > screenArea.Bottom Then
                    prodY = screenArea.Bottom - prodct.Height - 5
                End If
                If prodY < screenArea.Top Then
                    prodY = screenArea.Top
                End If

                prodct.Location = New Point(prodX, prodY)

                prodct.ShowDialog(Me)
            End Using

            ' After closing searchProducts, return this form to the center of the screen
            Me.StartPosition = FormStartPosition.Manual
            Dim centerX As Integer = screenArea.Left + (screenArea.Width - Me.Width) \ 2
            Dim centerY As Integer = screenArea.Top + (screenArea.Height - Me.Height) \ 2
            Me.Location = New Point(centerX, centerY)
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            Dim dgv As DataGridView = dgvSelectedProducts
            If dgv Is Nothing Then Exit Sub

            ' Unbind if needed to allow row removal
            Try
                If dgv.DataSource IsNot Nothing Then dgv.DataSource = Nothing
            Catch
            End Try

            ' Remove selected rows (from bottom to top)
            For i As Integer = dgv.SelectedRows.Count - 1 To 0 Step -1
                Dim r As DataGridViewRow = dgv.SelectedRows(i)
                If r IsNot Nothing AndAlso Not r.IsNewRow Then
                    Try
                        dgv.Rows.Remove(r)
                    Catch
                    End Try
                End If
            Next

            Try
                dgv.ClearSelection()
            Catch
            End Try

            ' Refresh discounts and totals after removal
            Try
                RefreshDiscountEnableState()
                RecomputeGridTotals()
            Catch
            End Try

        Catch
        End Try
    End Sub

    Private Function GetColumnIndexByKeys(dgv As DataGridView, ParamArray keys() As String) As Integer
        Try
            For Each col As DataGridViewColumn In dgv.Columns
                Dim n As String = If(col.Name, "")
                Dim h As String = If(col.HeaderText, "")
                For Each k In keys
                    If String.Equals(n, k, StringComparison.OrdinalIgnoreCase) OrElse _
                       String.Equals(h, k, StringComparison.OrdinalIgnoreCase) Then
                        Return col.Index
                    End If
                Next
            Next
        Catch
        End Try
        Return -1
    End Function

    Private Sub ApplyCheckUpRow(checkupOnly As Boolean)
        Dim dgv As DataGridView = dgvSelectedProducts

        ' Detach DataSource to allow direct row manipulation
        Try
            If dgv.DataSource IsNot Nothing Then dgv.DataSource = Nothing
        Catch
        End Try

        ' Ensure columns exist (add if missing)
        If dgv.Columns.Count = 0 Then
            With dgv.Columns
                .Add("productID", "Product ID")
                .Add("ProductName", "Product Name")
                .Add("Category", "Category")
                .Add("Quantity", "Quantity")
                .Add("unitPrice", "Price")
                .Add("Total", "Total")
            End With
        Else
            ' Add any missing expected columns
            If GetColumnIndexByKeys(dgv, "productID", "Product ID", "ID") = -1 Then dgv.Columns.Add("productID", "Product ID")
            If GetColumnIndexByKeys(dgv, "ProductName", "Product Name", "productName") = -1 Then dgv.Columns.Add("ProductName", "Product Name")
            If GetColumnIndexByKeys(dgv, "Category", "category") = -1 Then dgv.Columns.Add("Category", "Category")
            If GetColumnIndexByKeys(dgv, "Quantity", "Quatity") = -1 Then dgv.Columns.Add("Quantity", "Quantity")
            If GetColumnIndexByKeys(dgv, "unitPrice", "Price") = -1 Then dgv.Columns.Add("unitPrice", "Price")
            If GetColumnIndexByKeys(dgv, "Total") = -1 Then dgv.Columns.Add("Total", "Total")
        End If
        Try
            Dim idxTmp = GetColumnIndexByKeys(dgv, "productID", "Product ID", "ID")
            If idxTmp >= 0 Then dgv.Columns(idxTmp).Visible = False
            idxTmp = GetColumnIndexByKeys(dgv, "Quantity", "Quatity")
            If idxTmp >= 0 Then dgv.Columns(idxTmp).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            idxTmp = GetColumnIndexByKeys(dgv, "unitPrice", "Price")
            If idxTmp >= 0 Then dgv.Columns(idxTmp).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            idxTmp = GetColumnIndexByKeys(dgv, "Total")
            If idxTmp >= 0 Then dgv.Columns(idxTmp).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch
        End Try

        ' Find existing "Check-up" row by Product Name
        Dim checkRow As DataGridViewRow = Nothing
        For Each r As DataGridViewRow In dgv.Rows
            If r.IsNewRow Then Continue For
            Dim nameVal As String = ""
            Try
                nameVal = If(r.Cells("ProductName").Value, "").ToString()
            Catch
                Try
                    nameVal = If(r.Cells("Product Name").Value, "").ToString()
                Catch
                End Try
            End Try
            If String.Equals(nameVal, "Check-up", StringComparison.OrdinalIgnoreCase) Then
                checkRow = r
                Exit For
            End If
        Next

        Dim qty As Integer = 1
        Dim price As Decimal = 300D
        Dim total As Decimal = price * qty

        If checkRow Is Nothing Then
            Dim idx As Integer = dgv.Rows.Add()
            checkRow = dgv.Rows(idx)
        End If

        ' Resolve column indices and write values
        Dim idxID As Integer = GetColumnIndexByKeys(dgv, "productID", "Product ID", "ID")
        Dim idxName As Integer = GetColumnIndexByKeys(dgv, "ProductName", "Product Name", "productName")
        Dim idxCat As Integer = GetColumnIndexByKeys(dgv, "Category", "category")
        Dim idxQty As Integer = GetColumnIndexByKeys(dgv, "Quantity", "Quatity")
        Dim idxPrice As Integer = GetColumnIndexByKeys(dgv, "unitPrice", "Price")
        Dim idxTotal As Integer = GetColumnIndexByKeys(dgv, "Total")

        If idxID >= 0 Then checkRow.Cells(idxID).Value = ""
        If idxName >= 0 Then checkRow.Cells(idxName).Value = "Check-up"
        If idxCat >= 0 Then checkRow.Cells(idxCat).Value = "Service"
        If idxQty >= 0 Then checkRow.Cells(idxQty).Value = qty
        If idxPrice >= 0 Then checkRow.Cells(idxPrice).Value = price.ToString("0.00")
        If idxTotal >= 0 Then checkRow.Cells(idxTotal).Value = total.ToString("0.00")

        ' Select and scroll to the check-up row
        Try
            dgv.ClearSelection()
            checkRow.Selected = True
            dgv.Refresh()
        Catch
        End Try
    End Sub

    Private Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        Dim sel As String = ""
        Try
            sel = If(cmbType.SelectedItem, "").ToString().Trim()
        Catch
        End Try

        ' Clear grid on any re-selection as requested
        Try
            ' Safely clear current items in the grid when type changes
            Try
                If dgvSelectedProducts IsNot Nothing Then
                    Try
                        If dgvSelectedProducts.DataSource IsNot Nothing Then
                            dgvSelectedProducts.DataSource = Nothing
                        End If
                    Catch
                    End Try
                    Try
                        dgvSelectedProducts.Rows.Clear()
                    Catch
                    End Try
                End If
            Catch
            End Try

            If sel.Equals("With check-up", StringComparison.OrdinalIgnoreCase) Then
                ApplyCheckUpRow(False)
            ElseIf sel.Equals("Check-up only", StringComparison.OrdinalIgnoreCase) Then
                ApplyCheckUpRow(True)
            End If

            ' After changing type, refresh discounts/totals
            Try
                RefreshDiscountEnableState()
                RecomputeGridTotals()
            Catch
            End Try

            UpdateControls()
        Catch
        End Try
    End Sub

    ' ===================== Discounts, Totals, and Mode Visibility =====================
    Private Function ParsePercentFromCombo(cmb As ComboBox) As Decimal
        Try
            If cmb Is Nothing OrElse cmb.SelectedItem Is Nothing Then Return 0D
            Dim txt As String = cmb.SelectedItem.ToString().Trim()
            If txt.EndsWith("%") Then txt = txt.Substring(0, txt.Length - 1)
            Dim v As Decimal = 0D
            If Decimal.TryParse(txt, v) Then
                If v < 0D Then v = 0D
                If v > 100D Then v = 100D
                Return v / 100D
            End If
        Catch
        End Try
        Return 0D
    End Function

    Private Function HasCategoryInGrid(cat As String) As Boolean
        Try
            Dim idxCat As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "Category", "category")
            If idxCat = -1 Then Return False
            For Each r As DataGridViewRow In dgvSelectedProducts.Rows
                If r.IsNewRow Then Continue For
                Dim v As String = If(r.Cells(idxCat).Value, "").ToString()
                If String.Equals(v, cat, StringComparison.OrdinalIgnoreCase) Then Return True
            Next
        Catch
        End Try
        Return False
    End Function

    Private Sub RefreshDiscountEnableState()
        Try
            If cmbDiscount IsNot Nothing Then cmbDiscount.Enabled = HasCategoryInGrid("Frame")
        Catch
        End Try
        Try
            If cmbLensDisc IsNot Nothing Then cmbLensDisc.Enabled = HasCategoryInGrid("Lens")
        Catch
        End Try
    End Sub

    Private Function HasItemsInGrid() As Boolean
        Try
            For Each r As DataGridViewRow In dgvSelectedProducts.Rows
                If Not r.IsNewRow Then Return True
            Next
        Catch
        End Try
        Return False
    End Function

    Private Sub UpdateControls()
        Dim hasPatient As Boolean = False
        Dim hasType As Boolean = False
        Dim hasItems As Boolean = False

        Try
            ' Use txtPname as the patient name source for enabling cmbType
            Dim name1 As String = ""
            Try
                name1 = If(txtPname.Text, "")
            Catch
            End Try
            hasPatient = Not String.IsNullOrWhiteSpace(name1)
        Catch
        End Try

        Try
            hasType = (cmbType IsNot Nothing AndAlso cmbType.SelectedItem IsNot Nothing AndAlso _
                       Not String.IsNullOrWhiteSpace(cmbType.SelectedItem.ToString()))
        Catch
        End Try

        hasItems = HasItemsInGrid()

        ' 1) cmbType enabled only when a patient name exists
        Try
            If cmbType IsNot Nothing Then cmbType.Enabled = hasPatient
        Catch
        End Try

        ' 2) btnAdd enabled only when patient exists and a type is selected (but not "Check-up only")
        Try
            Dim isCheckupOnly As Boolean = False
            If hasType AndAlso cmbType IsNot Nothing AndAlso cmbType.SelectedItem IsNot Nothing Then
                isCheckupOnly = String.Equals(cmbType.SelectedItem.ToString().Trim(), "Check-up only", StringComparison.OrdinalIgnoreCase)
            End If
            If btnAdd IsNot Nothing Then btnAdd.Enabled = (hasPatient AndAlso hasType AndAlso Not isCheckupOnly)
        Catch
        End Try

        ' 3) Controls that depend on items in the grid
        Try
            If btnRemove IsNot Nothing Then btnRemove.Enabled = hasItems
        Catch
        End Try

        Try
            If hasItems Then
                ' Enable/disable discounts based on categories present
                RefreshDiscountEnableState()
            Else
                If cmbDiscount IsNot Nothing Then cmbDiscount.Enabled = False
                If cmbLensDisc IsNot Nothing Then cmbLensDisc.Enabled = False
            End If
        Catch
        End Try


        Try
            If txtAmountPaid IsNot Nothing Then txtAmountPaid.Enabled = hasItems
        Catch
        End Try

        Try
            If btnPayment IsNot Nothing Then btnPayment.Enabled = hasItems
        Catch
        End Try
    End Sub

    Private Sub RecomputeGridTotals()
        Dim sumTotal As Decimal = 0D
        Dim subTotal As Decimal = 0D
        Try
            Dim idxQty As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "Quantity", "Quatity")
            Dim idxPrice As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "unitPrice", "Price")
            Dim idxTotal As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "Total")
            Dim idxCat As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "Category", "category")
            Dim idxOrig As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "origPrice", "OriginalPrice", "Original Price")

            If idxQty = -1 OrElse idxPrice = -1 OrElse idxTotal = -1 Then GoTo AfterLoop

            ' Ensure original price column exists to avoid discount compounding
            If idxOrig = -1 Then
                idxOrig = dgvSelectedProducts.Columns.Add("origPrice", "origPrice")
                Try
                    dgvSelectedProducts.Columns(idxOrig).Visible = False
                Catch
                End Try
            End If

            Dim frameDisc As Decimal = ParsePercentFromCombo(cmbDiscount)
            Dim lensDisc As Decimal = ParsePercentFromCombo(cmbLensDisc)

            For Each r As DataGridViewRow In dgvSelectedProducts.Rows
                If r.IsNewRow Then Continue For

                Dim qty As Decimal = 0D
                Dim effPrice As Decimal = 0D
                Dim orig As Decimal = 0D
                Dim cat As String = ""
                Try : Decimal.TryParse(If(r.Cells(idxQty).Value, "0").ToString(), qty) : Catch : End Try
                ' Get original price, initialize if needed from current price
                Try : Decimal.TryParse(If(r.Cells(idxOrig).Value, "0").ToString(), orig) : Catch : End Try
                If orig <= 0D Then
                    Try
                        Decimal.TryParse(If(r.Cells(idxPrice).Value, "0").ToString(), orig)
                    Catch
                    End Try
                    Try
                        r.Cells(idxOrig).Value = orig.ToString("0.00")
                    Catch
                    End Try
                End If
                Try
                    If idxCat >= 0 Then cat = If(r.Cells(idxCat).Value, "").ToString()
                Catch
                End Try

                ' Compute effective unit price based on category-specific discounts
                effPrice = orig
                If idxCat >= 0 Then
                    If String.Equals(cat, "Frame", StringComparison.OrdinalIgnoreCase) AndAlso frameDisc > 0D Then
                        effPrice = orig * (1D - frameDisc)
                    ElseIf String.Equals(cat, "Lens", StringComparison.OrdinalIgnoreCase) AndAlso lensDisc > 0D Then
                        effPrice = orig * (1D - lensDisc)
                    End If
                End If

                ' Write back discounted price to the Price cell
                Try
                    r.Cells(idxPrice).Value = effPrice.ToString("0.00")
                Catch
                End Try

                ' Subtotal (before discount) uses original price
                Dim originalLine As Decimal = qty * orig
                Dim line As Decimal = qty * effPrice
                If idxCat >= 0 Then
                    ' line already reflects category-specific discount via effPrice
                End If

                Try
                    r.Cells(idxTotal).Value = line.ToString("0.00")
                Catch
                End Try
                sumTotal += line
                subTotal += originalLine
            Next

AfterLoop:
            Try
                ' Final total (after discount)
                If txtTotal IsNot Nothing Then txtTotal.Text = sumTotal.ToString("0.00")
            Catch
            End Try

            Try
                ' Sub total (before discount)
                If txtSubTotal IsNot Nothing Then txtSubTotal.Text = subTotal.ToString("0.00")
            Catch
            End Try

            Try
                ' Total discount = SubTotal - FinalTotal (never negative)
                Dim disc As Decimal = subTotal - sumTotal
                If disc < 0D Then disc = 0D
                If txtTotalDiscount IsNot Nothing Then txtTotalDiscount.Text = disc.ToString("0.00")
            Catch
            End Try

            ' Keep discount enable state in sync
            RefreshDiscountEnableState()
        Catch
            Try
                If txtTotal IsNot Nothing Then txtTotal.Text = sumTotal.ToString("0.00")
            Catch
            End Try
        End Try
    End Sub

    ' Event wiring for recalculation and UI sync
    Private Sub dgvSelectedProducts_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvSelectedProducts.RowsAdded
        Try
            RefreshDiscountEnableState()
            RecomputeGridTotals()
            UpdateControls()
        Catch
        End Try
    End Sub

    Private Sub dgvSelectedProducts_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvSelectedProducts.RowsRemoved
        Try
            RefreshDiscountEnableState()
            RecomputeGridTotals()
            UpdateControls()
        Catch
        End Try
    End Sub

    Private Sub dgvSelectedProducts_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSelectedProducts.CellValueChanged
        Try
            If e.RowIndex >= 0 Then
                RecomputeGridTotals()
                UpdateControls()
            End If
        Catch
        End Try
    End Sub

    Private Sub cmbDiscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscount.SelectedIndexChanged
        Try
            RecomputeGridTotals()
        Catch
        End Try
    End Sub

    Private Sub cmbLensDisc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLensDisc.SelectedIndexChanged
        Try
            RecomputeGridTotals()
        Catch
        End Try
    End Sub

    

    ' ===================== NEW ACTIVE SAVE FLOW (outside #If False) =====================
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveTransactionNew()
    End Sub

    Private Sub SaveTransactionNew()
        Dim totalAmount As Double
        Dim amountPaid As Double
        Dim pendingBalance As Double
        Dim discount As Double

        ' Derive isCheckUp code from cmbType:
        ' 0 = Check-up only
        ' 1 = With check-up
        ' 3 = Items only
        Dim isCheckUp As Integer = 3 ' default to Items only
        Try
            If cmbType IsNot Nothing AndAlso cmbType.SelectedItem IsNot Nothing Then
                Dim t As String = cmbType.SelectedItem.ToString().Trim()
                If String.Equals(t, "Check-up only", StringComparison.OrdinalIgnoreCase) Then
                    isCheckUp = 0
                ElseIf String.Equals(t, "With check-up", StringComparison.OrdinalIgnoreCase) Then
                    isCheckUp = 1
                ElseIf String.Equals(t, "Items only", StringComparison.OrdinalIgnoreCase) Then
                    isCheckUp = 3
                End If
            End If
        Catch
        End Try

        Dim paymentStatus As String

        ' Validate that a patient has been selected using the currentPatientID field
        Dim patientID As Integer = currentPatientID
        If patientID <= 0 Then
            MsgBox("Please select a patient before saving this transaction.", vbExclamation, "Patient Required")
            Exit Sub
        End If


        

        If Not Double.TryParse(txtTotal.Text, totalAmount) OrElse totalAmount <= 0 Then
            MsgBox("Total must be greater than 0.", vbCritical, "Error")
            Exit Sub
        End If

        If Not Double.TryParse(txtAmountPaid.Text, amountPaid) Then
            MsgBox("Amount Paid invalid. Please enter a valid number.", vbCritical, "Error")
            txtAmountPaid.Focus()
            Exit Sub
        End If
        If amountPaid < 0 Then amountPaid = 0

        If amountPaid > totalAmount Then
            MsgBox("Amount Paid cannot be greater than Total.", vbExclamation, "Invalid Payment")
            txtAmountPaid.Focus()
            Exit Sub
        End If

        pendingBalance = totalAmount - amountPaid
        If pendingBalance < 0 Then pendingBalance = 0
        paymentStatus = If(amountPaid >= totalAmount, "Paid", "Pending")

        Dim discText As String = cmbDiscount.Text.Replace("%", "").Trim()
        Double.TryParse(discText, discount)
        If cmbDiscount.Text.Contains("%") Then discount = discount / 100

        Dim lensDiscount As Double = 0
        Dim lensDiscText As String = cmbLensDisc.Text.Replace("%", "").Trim()
        If Not String.IsNullOrEmpty(lensDiscText) AndAlso lensDiscText <> "N/A" Then
            Double.TryParse(lensDiscText, lensDiscount)
            If cmbLensDisc.Text.Contains("%") Then lensDiscount = lensDiscount / 100
        End If

        If MsgBox("Save this transaction?", vbYesNo + vbQuestion, "Confirm") = vbNo Then Exit Sub

        Try
            Call dbConn()

            If IsEditMode AndAlso TransactionID > 0 Then
                Dim updateTrans As String = _
                    "UPDATE tbl_transactions SET patientID = ?, patientName = ?, totalAmount = ?, amountPaid = ?, pendingBalance = ?, settlementDate = ?, paymentType = ?, referenceNum = ?, transactionDate = ?, paymentStatus = ?, isCheckUp = ?, discount = ?, lensDiscount = ? WHERE transactionID = ?"
                Using cmd As New Odbc.OdbcCommand(updateTrans, conn)

                    cmd.Parameters.AddWithValue("?", patientID)          ' patientID
                    cmd.Parameters.AddWithValue("?", txtPatientName.Text) ' patientName
                    cmd.Parameters.AddWithValue("?", totalAmount)
                    cmd.Parameters.AddWithValue("?", amountPaid)
                    cmd.Parameters.AddWithValue("?", pendingBalance)
                    Dim pSettle As Odbc.OdbcParameter = cmd.Parameters.Add("?", Odbc.OdbcType.Date)
                    pSettle.Value = If(paymentStatus = "Paid" OrElse amountPaid > 0, DateTime.Now.Date, CType(DBNull.Value, Object))
                    cmd.Parameters.AddWithValue("?", lblMode.Text)
                    cmd.Parameters.AddWithValue("?", If(txtReference IsNot Nothing, txtReference.Text, ""))
                    cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                    cmd.Parameters.AddWithValue("?", paymentStatus)
                    cmd.Parameters.AddWithValue("?", isCheckUp)
                    cmd.Parameters.AddWithValue("?", discount)
                    cmd.Parameters.AddWithValue("?", lensDiscount)
                    cmd.Parameters.AddWithValue("?", TransactionID)
                    cmd.ExecuteNonQuery()
                End Using

                Using getItemsCmd As New Odbc.OdbcCommand("SELECT productID, quantity FROM tbl_transaction_items WHERE transactionID = ?", conn)
                    getItemsCmd.Parameters.AddWithValue("?", TransactionID)
                    Using itemsRdr = getItemsCmd.ExecuteReader()
                        While itemsRdr.Read()
                            Using restockCmd As New Odbc.OdbcCommand("UPDATE tbl_products SET stockQuantity = stockQuantity + ? WHERE productID = ?", conn)
                                restockCmd.Parameters.AddWithValue("?", Convert.ToInt32(itemsRdr("quantity")))
                                restockCmd.Parameters.AddWithValue("?", Convert.ToInt32(itemsRdr("productID")))
                                restockCmd.ExecuteNonQuery()
                            End Using
                        End While
                    End Using
                End Using

                Using delCmd As New Odbc.OdbcCommand("DELETE FROM tbl_transaction_items WHERE transactionID = ?", conn)
                    delCmd.Parameters.AddWithValue("?", TransactionID)
                    delCmd.ExecuteNonQuery()
                End Using

                SaveItemsNew(TransactionID)
                SavePaymentRecords(TransactionID)
            Else
                Dim insertTrans As String = _
                    "INSERT INTO tbl_transactions (patientID, patientName, totalAmount, amountPaid, pendingBalance, settlementDate, paymentType, referenceNum, transactionDate, paymentStatus, isCheckUp, discount, lensDiscount) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
                Using cmd As New Odbc.OdbcCommand(insertTrans, conn)

                    cmd.Parameters.AddWithValue("?", patientID)          ' patientID
                    cmd.Parameters.AddWithValue("?", txtPatientName.Text) ' patientName
                    cmd.Parameters.AddWithValue("?", totalAmount)
                    cmd.Parameters.AddWithValue("?", amountPaid)
                    cmd.Parameters.AddWithValue("?", pendingBalance)
                    Dim pSettleI As Odbc.OdbcParameter = cmd.Parameters.Add("?", Odbc.OdbcType.Date)
                    pSettleI.Value = If(paymentStatus = "Paid" OrElse amountPaid > 0, DateTime.Now.Date, CType(DBNull.Value, Object))
                    cmd.Parameters.AddWithValue("?", lblMode.Text)
                    cmd.Parameters.AddWithValue("?", If(txtReference IsNot Nothing, txtReference.Text, ""))
                    cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                    cmd.Parameters.AddWithValue("?", paymentStatus)
                    cmd.Parameters.AddWithValue("?", isCheckUp)
                    cmd.Parameters.AddWithValue("?", discount)
                    cmd.Parameters.AddWithValue("?", lensDiscount)
                    cmd.ExecuteNonQuery()
                End Using

                Using cmd As New Odbc.OdbcCommand("SELECT LAST_INSERT_ID()", conn)
                    TransactionID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                SaveItemsNew(TransactionID)
                SavePaymentRecords(TransactionID)
            End If

            ' Show success message
            MsgBox("Transaction saved successfully!", vbInformation, "Success")

            ' Refresh parent form's DataGridView if it exists
            Try
                Dim parentForm As Form = Me.Owner
                If parentForm IsNot Nothing Then
                    ' Try to find and call a refresh method on the parent form
                    Dim refreshMethod = parentForm.GetType().GetMethod("LoadTransactions")
                    If refreshMethod IsNot Nothing Then
                        refreshMethod.Invoke(parentForm, Nothing)
                    End If

                    ' Alternative: try to find a DataGridView and refresh it
                    For Each ctrl As Control In parentForm.Controls
                        If TypeOf ctrl Is DataGridView Then
                            Dim dgv As DataGridView = CType(ctrl, DataGridView)
                            dgv.Refresh()
                        End If
                    Next
                End If
            Catch
                ' Silently ignore if parent refresh fails
            End Try

            ' Close the form
            Me.Close()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Save Failed")
        End Try
    End Sub

    Private Sub SavePaymentRecords(transactionID As Integer)

        If transactionID <= 0 Then Exit Sub

        ' --------------------------------------------
        ' Read payment mode
        ' --------------------------------------------
        Dim mode As String = ""
        If lblMode IsNot Nothing Then
            mode = lblMode.Text.Trim()
        End If
        If mode = "" Then Exit Sub

        ' --------------------------------------------
        ' Read cash and gcash amounts
        ' --------------------------------------------
        Dim cashAmount As Decimal = 0D
        Dim gcashAmount As Decimal = 0D

        Decimal.TryParse(lblCash.Text, cashAmount)
        Decimal.TryParse(lblGcash.Text, gcashAmount)

        ' --------------------------------------------
        ' Read reference number (for Gcash)
        ' --------------------------------------------
        Dim reference As String = ""
        If txtReference IsNot Nothing Then
            reference = txtReference.Text.Trim()
        End If

        Dim paymentDate As Date = Date.Now

        ' --------------------------------------------
        ' Open connection if needed
        ' --------------------------------------------
        If conn Is Nothing OrElse conn.State <> ConnectionState.Open Then
            dbConn()
        End If

        ' --------------------------------------------
        ' SQL Insert
        ' --------------------------------------------
        Dim insertSql As String =
            "INSERT INTO tbl_payments (transactionID, paymentDate, paymentType, amountPaid, referenceNumber, remarks) " &
            "VALUES (?, ?, ?, ?, ?, ?)"

        ' --------------------------------------------
        ' Determine modes
        ' --------------------------------------------
        Dim isCash As Boolean = False
        Dim isGcash As Boolean = False

        Select Case mode
            Case "Cash"
                isCash = True
            Case "G-cash"
                isGcash = True
            Case "Cash and G-cash"
                isCash = True
                isGcash = True
        End Select

        ' --------------------------------------------
        ' Insert CASH payment if needed
        ' --------------------------------------------
        If isCash AndAlso cashAmount > 0 Then
            Using cmd As New Odbc.OdbcCommand(insertSql, conn)
                cmd.Parameters.AddWithValue("?", transactionID)
                cmd.Parameters.AddWithValue("?", paymentDate)
                cmd.Parameters.AddWithValue("?", "Cash")
                cmd.Parameters.AddWithValue("?", CDbl(cashAmount))
                cmd.Parameters.AddWithValue("?", DBNull.Value) ' no reference
                cmd.Parameters.AddWithValue("?", DBNull.Value) ' remarks
                cmd.ExecuteNonQuery()
            End Using
        End If

        ' --------------------------------------------
        ' Insert GCASH payment if needed
        ' --------------------------------------------
        If isGcash AndAlso gcashAmount > 0 Then
            Using cmd As New Odbc.OdbcCommand(insertSql, conn)
                cmd.Parameters.AddWithValue("?", transactionID)
                cmd.Parameters.AddWithValue("?", paymentDate)
                cmd.Parameters.AddWithValue("?", "G-cash")
                cmd.Parameters.AddWithValue("?", CDbl(gcashAmount))
                cmd.Parameters.AddWithValue("?", reference) ' gcash ref number
                cmd.Parameters.AddWithValue("?", DBNull.Value)
                cmd.ExecuteNonQuery()
            End Using
        End If

    End Sub


    Private Sub SaveItemsNew(transactionID As Integer)
        If conn.State <> ConnectionState.Open Then conn.Open()

        Dim idxProdId As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "productID", "Product ID", "ID")
        Dim idxQty As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "Quantity", "quantity", "Quatity")
        Dim idxUnit As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "unitPrice", "Price")
        Dim idxName As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "ProductName", "Product Name", "productName")
        Dim idxCat As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "Category", "category")
        Dim idxTotal As Integer = GetColumnIndexByKeys(dgvSelectedProducts, "Total")

        Dim servicePresent As Boolean = HasCategoryInGrid("Service")

        ' First, scan the grid once to capture OD/OS grades and prices from the
        ' special rows inserted by selectGrade ("OD Grade: ...", "OS Grade: ...").
        Dim odGradeFromGrid As String = ""
        Dim osGradeFromGrid As String = ""
        Dim priceODFromGrid As Double = 0
        Dim priceOSFromGrid As Double = 0

        For Each r As DataGridViewRow In dgvSelectedProducts.Rows
            If r.IsNewRow Then Continue For
            If idxName = -1 OrElse idxUnit = -1 Then Continue For

            Dim name As String = ""
            Try
                name = If(r.Cells(idxName).Value, "").ToString()
            Catch
            End Try

            Dim rowUnitPrice As Double = 0
            Try
                Double.TryParse(If(r.Cells(idxUnit).Value, "0").ToString(), rowUnitPrice)
            Catch
            End Try

            If name.StartsWith("OD Grade", StringComparison.OrdinalIgnoreCase) Then
                Dim idx As Integer = name.IndexOf(":"c)
                If idx >= 0 AndAlso idx < name.Length - 1 Then
                    odGradeFromGrid = name.Substring(idx + 1).Trim()
                Else
                    odGradeFromGrid = name.Trim()
                End If
                priceODFromGrid = rowUnitPrice
            ElseIf name.StartsWith("OS Grade", StringComparison.OrdinalIgnoreCase) Then
                Dim idx As Integer = name.IndexOf(":"c)
                If idx >= 0 AndAlso idx < name.Length - 1 Then
                    osGradeFromGrid = name.Substring(idx + 1).Trim()
                Else
                    osGradeFromGrid = name.Trim()
                End If
                priceOSFromGrid = rowUnitPrice
            End If
        Next

        For Each r As DataGridViewRow In dgvSelectedProducts.Rows
            If r.IsNewRow Then Continue For
            If idxProdId = -1 OrElse idxQty = -1 OrElse idxUnit = -1 Then Continue For

            Dim productID As Integer = 0, quantity As Integer = 0
            Dim unitPrice As Double = 0, totalPrice As Double = 0
            Dim productName As String = "", category As String = ""

            Try
                Integer.TryParse(If(r.Cells(idxProdId).Value, "0").ToString(), productID)
            Catch
            End Try
            Try
                Integer.TryParse(If(r.Cells(idxQty).Value, "0").ToString(), quantity)
            Catch
            End Try
            Try
                Double.TryParse(If(r.Cells(idxUnit).Value, "0").ToString(), unitPrice)
            Catch
            End Try
            If idxName <> -1 Then
                Try
                    productName = If(r.Cells(idxName).Value, "").ToString()
                Catch
                End Try
            End If
            If idxCat <> -1 Then
                Try
                    category = If(r.Cells(idxCat).Value, "").ToString()
                Catch
                End Try
            End If
            If idxTotal <> -1 Then
                Try
                    Double.TryParse(If(r.Cells(idxTotal).Value, "0").ToString(), totalPrice)
                Catch
                End Try
            End If

            If String.Equals(category, "Service", StringComparison.OrdinalIgnoreCase) _
               OrElse String.Equals(productName, "Check-up", StringComparison.OrdinalIgnoreCase) Then
                Continue For
            End If

            Dim availableStock As Integer = 0
            Using checkCmd As New Odbc.OdbcCommand("SELECT stockQuantity FROM tbl_products WHERE productID = ?", conn)
                checkCmd.Parameters.AddWithValue("?", productID)
                Dim res = checkCmd.ExecuteScalar()
                If res Is Nothing OrElse Not IsNumeric(res) Then Continue For
                availableStock = CInt(res)
            End Using
            If availableStock < quantity Then
                MsgBox("Insufficient stock for product ID " & productID & ". Available: " & availableStock, vbCritical, "Stock Error")
                Exit Sub
            End If

            ' Persist OD/OS grades and prices for Lens items, using values
            ' captured from the grid (selectGrade OS/OD rows).
            Dim odGrade As String = ""
            Dim osGrade As String = ""
            Dim priceOD As Double = 0
            Dim priceOS As Double = 0

            If String.Equals(category, "Lens", StringComparison.OrdinalIgnoreCase) Then
                odGrade = odGradeFromGrid
                osGrade = osGradeFromGrid
                priceOD = priceODFromGrid
                priceOS = priceOSFromGrid
            End If
            Dim isCheckUpItem As Integer = If(servicePresent, 1, 0)
            Dim createdAt As DateTime = DateTime.Now

            Dim insertItemSql As String = _
                "INSERT INTO tbl_transaction_items (transactionID, productID, productName, category, quantity, unitPrice, priceOD, priceOS, odGrade, osGrade, totalPrice, isCheckUpItem, createdAt) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            Using cmd As New Odbc.OdbcCommand(insertItemSql, conn)
                cmd.Parameters.AddWithValue("?", transactionID)
                cmd.Parameters.AddWithValue("?", productID)
                cmd.Parameters.AddWithValue("?", productName)
                cmd.Parameters.AddWithValue("?", category)
                cmd.Parameters.AddWithValue("?", quantity)
                cmd.Parameters.AddWithValue("?", unitPrice)
                cmd.Parameters.AddWithValue("?", priceOD)
                cmd.Parameters.AddWithValue("?", priceOS)
                cmd.Parameters.AddWithValue("?", odGrade)
                cmd.Parameters.AddWithValue("?", osGrade)
                cmd.Parameters.AddWithValue("?", totalPrice)
                cmd.Parameters.AddWithValue("?", isCheckUpItem)
                cmd.Parameters.AddWithValue("?", createdAt)
                cmd.ExecuteNonQuery()
            End Using

            Using stockCmd As New Odbc.OdbcCommand("UPDATE tbl_products SET stockQuantity = stockQuantity - ? WHERE productID = ?", conn)
                stockCmd.Parameters.AddWithValue("?", quantity)
                stockCmd.Parameters.AddWithValue("?", productID)
                stockCmd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub InsertAuditTrail(actionType As String, actionDetails As String, tableName As String, recordID As Integer)
        Try
            Dim auditSql As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, TableName, RecordID, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
            Using auditCmd As New Odbc.OdbcCommand(auditSql, conn)
                auditCmd.Parameters.AddWithValue("?", LoggedInUserID)
                auditCmd.Parameters.AddWithValue("?", LoggedInUser)
                auditCmd.Parameters.AddWithValue("?", actionType)
                auditCmd.Parameters.AddWithValue("?", actionDetails)
                auditCmd.Parameters.AddWithValue("?", tableName)
                auditCmd.Parameters.AddWithValue("?", recordID)
                auditCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
                auditCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd"))
                auditCmd.ExecuteNonQuery()
            End Using
        Catch
        End Try
    End Sub

    ' Full loader for edit mode: restores header fields and items (including OD/OS) from DB
    Private Sub LoadTransactionForEdit(transactionID As Integer)
        Try
            Call dbConn()

            ' -------- Header: tbl_transactions --------
            Dim sql As String = "SELECT patientID, patientName, totalAmount, amountPaid, paymentType, referenceNum, transactionDate, discount, lensDiscount, isCheckUp " & _
                                "FROM tbl_transactions WHERE transactionID = ?"
            Dim loadedPatientName As String = ""
            Dim loadedIsCheckCode As Integer = 3

            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", transactionID)
                Using rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        lblPatientID.Text = If(rdr("patientID") Is DBNull.Value, "", rdr("patientID").ToString())

                        ' Store patient name and populate both txtPatientName (if present) and txtPname
                        loadedPatientName = If(rdr("patientName") Is DBNull.Value, "", rdr("patientName").ToString())
                        Try
                            txtPatientName.Text = loadedPatientName
                        Catch
                        End Try
                        Try
                            txtPname.Text = loadedPatientName
                        Catch
                        End Try

                        txtTotal.Text = If(IsDBNull(rdr("totalAmount")), "0.00", Convert.ToDecimal(rdr("totalAmount")).ToString("N2"))
                        txtAmountPaid.Text = If(IsDBNull(rdr("amountPaid")), "0.00", Convert.ToDecimal(rdr("amountPaid")).ToString("N2"))

                        ' Reference number
                        Try
                            If txtReference IsNot Nothing Then
                                txtReference.Text = If(IsDBNull(rdr("referenceNum")), "", rdr("referenceNum").ToString())
                            End If
                        Catch
                        End Try


                        ' Date


                        ' Frame discount -> cmbDiscount
                        Dim disc As Decimal = 0D
                        If Not IsDBNull(rdr("discount")) Then Decimal.TryParse(rdr("discount").ToString(), disc)
                        cmbDiscount.Text = If(disc <= 0D, "N/A", (disc * 100D).ToString("0") & "%")

                        ' Lens discount -> cmbLensDisc
                        Dim lensDisc As Decimal = 0D
                        If Not IsDBNull(rdr("lensDiscount")) Then Decimal.TryParse(rdr("lensDiscount").ToString(), lensDisc)
                        cmbLensDisc.Text = If(lensDisc <= 0D, "N/A", (lensDisc * 100D).ToString("0") & "%")

                        ' Transaction type: numeric isCheckUp (0/1/3) -> cmbType
                        loadedIsCheckCode = 3
                        If Not IsDBNull(rdr("isCheckUp")) Then Integer.TryParse(rdr("isCheckUp").ToString(), loadedIsCheckCode)
                        Select Case loadedIsCheckCode
                            Case 0 : cmbType.Text = "Check-up only"
                            Case 1 : cmbType.Text = "With check-up"
                            Case 3 : cmbType.Text = "Items only"
                            Case Else : cmbType.SelectedIndex = -1
                        End Select
                    End If
                End Using
            End Using

            ' -------- Items grid: tbl_transaction_items --------
            ' Load product rows (Lens, Frame, etc.) directly
            dgvSelectedProducts.Rows.Clear()

            Dim itemsSql As String = "SELECT productID, productName, category, quantity, unitPrice, totalPrice, odGrade, osGrade, priceOD, priceOS " & _
                                     "FROM tbl_transaction_items WHERE transactionID = ?"
            Using cmdItems As New Odbc.OdbcCommand(itemsSql, conn)
                cmdItems.Parameters.AddWithValue("?", transactionID)
                Using rdrItems = cmdItems.ExecuteReader()
                    Dim odGrade As String = ""
                    Dim osGrade As String = ""
                    Dim priceOD As Decimal = 0D
                    Dim priceOS As Decimal = 0D

                    While rdrItems.Read()
                        ' Add base product row (skip any stored synthetic check-up/service rows if present)
                        Dim pid As String = If(rdrItems("productID") Is DBNull.Value, "", rdrItems("productID").ToString())
                        Dim pname As String = If(rdrItems("productName") Is DBNull.Value, "", rdrItems("productName").ToString())
                        Dim cat As String = If(rdrItems("category") Is DBNull.Value, "", rdrItems("category").ToString())

                        ' In DB we only store real items; service row is synthetic in grid. Keep this guard anyway.
                        If String.Equals(cat, "Service", StringComparison.OrdinalIgnoreCase) OrElse
                           String.Equals(pname, "Check-up", StringComparison.OrdinalIgnoreCase) Then
                            Continue While
                        End If

                        Dim qty As Integer = If(IsDBNull(rdrItems("quantity")), 0, Convert.ToInt32(rdrItems("quantity")))
                        Dim unit As Decimal = If(IsDBNull(rdrItems("unitPrice")), 0D, Convert.ToDecimal(rdrItems("unitPrice")))
                        Dim total As Decimal = If(IsDBNull(rdrItems("totalPrice")), 0D, Convert.ToDecimal(rdrItems("totalPrice")))

                        dgvSelectedProducts.Rows.Add(pid, pname, cat, qty,
                                                     unit.ToString("0.00"), total.ToString("0.00"))

                        ' Capture OD/OS data (if present) from any row
                        Dim tmpOd As String = If(rdrItems("odGrade") Is DBNull.Value, "", rdrItems("odGrade").ToString())
                        Dim tmpOs As String = If(rdrItems("osGrade") Is DBNull.Value, "", rdrItems("osGrade").ToString())
                        Dim tmpPriceOd As Decimal = If(IsDBNull(rdrItems("priceOD")), 0D, Convert.ToDecimal(rdrItems("priceOD")))
                        Dim tmpPriceOs As Decimal = If(IsDBNull(rdrItems("priceOS")), 0D, Convert.ToDecimal(rdrItems("priceOS")))

                        If odGrade = "" AndAlso osGrade = "" AndAlso priceOD = 0D AndAlso priceOS = 0D Then
                            If Not String.IsNullOrWhiteSpace(tmpOd) OrElse Not String.IsNullOrWhiteSpace(tmpOs) _
                               OrElse tmpPriceOd > 0D OrElse tmpPriceOs > 0D Then
                                odGrade = tmpOd
                                osGrade = tmpOs
                                priceOD = tmpPriceOd
                                priceOS = tmpPriceOs
                            End If
                        End If
                    End While

                    ' Recreate synthetic OS/OD rows in dgvSelectedProducts to match selectGrade behavior
                    If Not String.IsNullOrWhiteSpace(osGrade) OrElse priceOS > 0D Then
                        Dim osQty As Integer = 1
                        Dim osName As String = "OS Grade: " & osGrade
                        dgvSelectedProducts.Rows.Add("", osName, "", osQty,
                                                     priceOS.ToString("0.00"), (priceOS * osQty).ToString("0.00"))
                    End If

                    If Not String.IsNullOrWhiteSpace(odGrade) OrElse priceOD > 0D Then
                        Dim odQty As Integer = 1
                        Dim odName As String = "OD Grade: " & odGrade
                        dgvSelectedProducts.Rows.Add("", odName, "", odQty,
                                                     priceOD.ToString("0.00"), (priceOD * odQty).ToString("0.00"))
                    End If

                End Using
            End Using

            ' Ensure a synthetic "Check-up" row exists in the grid for check-up transactions
            Try
                If loadedIsCheckCode = 0 Then
                    ' Check-up only
                    ApplyCheckUpRow(True)
                ElseIf loadedIsCheckCode = 1 Then
                    ' With check-up
                    ApplyCheckUpRow(False)
                End If
            Catch
            End Try

        Catch ex As Exception
            MessageBox.Show("Error loading transaction: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub addPatientTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvStyle(dgvSelectedProducts)

        ' When opened from Transaction.btnEdit, restore full header + items from DB
        If IsEditMode AndAlso TransactionID > 0 Then
            LoadTransactionForEdit(TransactionID)
        End If

        ' Initialize control enabled state based on current patient/text/grid
        Try
            UpdateControls()
        Catch
        End Try
    End Sub

    Private Sub txtPname_TextChanged(sender As Object, e As EventArgs) Handles txtPname.TextChanged
        Try
            UpdateControls()
        Catch
        End Try
    End Sub

    Private Sub txtPatientName_TextChanged(sender As Object, e As EventArgs) Handles txtPatientName.TextChanged
        Try
            UpdateControls()
        Catch
        End Try
    End Sub

    Public Sub DgvStyle(ByRef dgv As DataGridView)
        Try
            dgv.AutoGenerateColumns = False
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False
            dgv.BorderStyle = BorderStyle.None
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


    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        Using pyment As New addPayment()
            pyment.StartPosition = FormStartPosition.CenterScreen
            pyment.ShowDialog(Me)
        End Using
    End Sub
End Class