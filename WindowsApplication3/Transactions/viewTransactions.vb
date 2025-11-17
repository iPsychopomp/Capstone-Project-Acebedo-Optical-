Public Class viewTransactions
    Private isFormOpen As Boolean = False

    Public Sub LoadViewTransaction(patientID As Integer)
        pnlViewTransactions.Controls.Clear()
        pnlViewTransactions.AutoScroll = True

        Call dbConn()
        Dim cmd As New Odbc.OdbcCommand(
            "SELECT t.transactionID, COALESCE(p.fullname, t.patientName) AS patientName, t.transactionDate, t.discount, t.lensDiscount, t.totalAmount, t.amountPaid, t.paymentType, t.referenceNum, t.paymentStatus, t.isCheckUp " & _
            "FROM tbl_transactions t LEFT JOIN db_viewpatient p ON p.patientID = t.patientID WHERE t.patientID = ? ORDER BY t.transactionID DESC", conn)
        cmd.Parameters.Add(New Odbc.OdbcParameter("?", Odbc.OdbcType.Int)).Value = patientID

        Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()
        Dim labelFont As New Font("Segoe UI", 11, FontStyle.Regular)
        Dim labelBoldFont As New Font("Segoe UI", 11, FontStyle.Regular)
        Dim yOffset As Integer = 10

        While reader.Read()
            lblPatientName.Text = reader("patientName").ToString()

            Dim card As New Panel
            card.Size = New Size(pnlViewTransactions.Width - 30, 400)
            card.Location = New Point(10, yOffset)
            card.BackColor = Color.White
            card.BorderStyle = BorderStyle.FixedSingle
            pnlViewTransactions.Controls.Add(card)

            Dim costX As Integer = card.Width - 220
            Dim valueX As Integer = card.Width - 120
            Dim top As Integer = 10

            ' Per-transaction Payment History button inside the card
            Dim transactionID As Integer = Convert.ToInt32(reader("transactionID"))
            Dim btnCardPaymentHistory As New Button()
            btnCardPaymentHistory.Text = "Payment History"
            btnCardPaymentHistory.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular)
            btnCardPaymentHistory.Size = New Size(130, 26)
            btnCardPaymentHistory.Location = New Point(card.Width - btnCardPaymentHistory.Width - 10, 10)
            btnCardPaymentHistory.Tag = transactionID
            AddHandler btnCardPaymentHistory.Click, AddressOf CardPaymentHistory_Click
            card.Controls.Add(btnCardPaymentHistory)

            top += 30

            ' Patient Name: [value]
            Dim lblPatientNameLabel As New Label
            lblPatientNameLabel.Text = "Patient Name:"
            lblPatientNameLabel.Location = New Point(10, top)
            lblPatientNameLabel.Font = labelBoldFont
            lblPatientNameLabel.AutoSize = True
            card.Controls.Add(lblPatientNameLabel)

            Dim lblPatientNameValue As New Label
            lblPatientNameValue.Text = " " & reader("patientName").ToString()
            lblPatientNameValue.Location = New Point(lblPatientNameLabel.Right, top)
            lblPatientNameValue.Font = labelFont
            lblPatientNameValue.AutoSize = True
            card.Controls.Add(lblPatientNameValue)
            top += 30

            ' Date
            Dim lblDate As New Label
            Dim dateText As String = ""
            If Not IsDBNull(reader("transactionDate")) Then
                dateText = Convert.ToDateTime(reader("transactionDate")).ToShortDateString()
            End If
            lblDate.Text = "Date: " & dateText
            lblDate.Location = New Point(10, top)
            lblDate.Font = labelFont
            lblDate.AutoSize = True
            card.Controls.Add(lblDate)
            top += 30

            ' Products Header
            Dim lblProdH As New Label
            lblProdH.Text = "Products:"
            lblProdH.Location = New Point(10, top)
            lblProdH.Font = labelBoldFont
            lblProdH.AutoSize = True
            card.Controls.Add(lblProdH)

            Dim lblPriceH As New Label
            lblPriceH.Text = "Price:"
            lblPriceH.Location = New Point(costX, top)
            lblPriceH.Font = labelBoldFont
            lblPriceH.AutoSize = True
            card.Controls.Add(lblPriceH)
            top += 30

            ' Load transaction items
            Dim cmdItems As New Odbc.OdbcCommand(
                "SELECT productName, category, quantity, unitPrice, priceOD, priceOS, odGrade, osGrade, totalPrice, isCheckUpItem " &
                "FROM tbl_transaction_items WHERE transactionID = ?", conn)
            cmdItems.Parameters.Add(New Odbc.OdbcParameter("?", Odbc.OdbcType.Int)).Value = transactionID

            Dim itemReader As Odbc.OdbcDataReader = cmdItems.ExecuteReader()

            ' Variables to store the OD/OS grades and prices
            Dim odGrade As String = String.Empty
            Dim osGrade As String = String.Empty
            Dim priceOD As Decimal = 0D
            Dim priceOS As Decimal = 0D
            ' Lens items subtotal (pre-discount) to compute lens discount total later
            Dim lensSubtotal As Decimal = 0D
            ' Frame items subtotal (pre-discount) to compute frame discount total later
            Dim frameSubtotal As Decimal = 0D

            While itemReader.Read()
                ' Debug: Output item data for troubleshooting
                Console.WriteLine("Product: " & itemReader("productName").ToString())
                Console.WriteLine("isCheckUpItem: " & itemReader("isCheckUpItem").ToString())

                Dim productName As String = itemReader("productName").ToString()
                Dim category As String = itemReader("category").ToString()
                Dim quantity As Integer = Convert.ToInt32(itemReader("quantity"))
                Dim unitPrice As Decimal = If(IsDBNull(itemReader("unitPrice")), 0D, Convert.ToDecimal(itemReader("unitPrice")))
                Dim totalPrice As Decimal = If(IsDBNull(itemReader("totalPrice")), 0D, Convert.ToDecimal(itemReader("totalPrice")))
                Dim isCheckUpItem As Boolean = Convert.ToBoolean(itemReader("isCheckUpItem"))



                ' Product Name & Quantity with text wrapping
                Dim lblItem As New Label
                lblItem.Text = quantity.ToString() & " x " & productName
                lblItem.Location = New Point(10, top)
                lblItem.Font = labelFont
                lblItem.AutoSize = False
                lblItem.Width = costX - 20
                lblItem.Height = 60 ' Allow space for wrapping
                card.Controls.Add(lblItem)

                ' Calculate actual height needed after text is set
                Using g As Graphics = lblItem.CreateGraphics()
                    Dim textSize As SizeF = g.MeasureString(lblItem.Text, lblItem.Font, lblItem.Width)
                    lblItem.Height = CInt(Math.Ceiling(textSize.Height)) + 5
                End Using

                ' Product Price
                Dim lblItemPrice As New Label
                lblItemPrice.Text = "₱" & totalPrice.ToString("F2")
                lblItemPrice.Location = New Point(costX, top)
                lblItemPrice.Font = labelFont
                lblItemPrice.AutoSize = True
                card.Controls.Add(lblItemPrice)

                ' Adjust top based on the taller of the two labels
                Dim itemHeight As Integer = Math.Max(lblItem.Height, lblItemPrice.Height)
                top += itemHeight + 5

                ' Store OD and OS Grades and Prices (Only set them once)
                If String.IsNullOrEmpty(odGrade) Then
                    odGrade = itemReader("odGrade").ToString()
                    osGrade = itemReader("osGrade").ToString()
                    priceOD = Convert.ToDecimal(itemReader("priceOD"))
                    priceOS = Convert.ToDecimal(itemReader("priceOS"))
                End If

                ' Accumulate subtotals for discount computation
                If category.Equals("Lens", StringComparison.OrdinalIgnoreCase) Then
                    lensSubtotal += (quantity * unitPrice)
                ElseIf category.Equals("Frame", StringComparison.OrdinalIgnoreCase) Then
                    frameSubtotal += (quantity * unitPrice)
                End If
            End While
            itemReader.Close()

            ' After listing all products, show the OD/OS grades and prices as separate rows
            If Not String.IsNullOrEmpty(odGrade) OrElse Not String.IsNullOrEmpty(osGrade) Then
                ' OD row
                Dim lblODGrade As New Label
                lblODGrade.Text = "OD: " & odGrade
                lblODGrade.Location = New Point(10, top)
                lblODGrade.Font = labelFont
                lblODGrade.AutoSize = True
                card.Controls.Add(lblODGrade)

                Dim lblODPrice As New Label
                lblODPrice.Text = "₱" & priceOD.ToString("F2")
                lblODPrice.Location = New Point(costX, top)
                lblODPrice.Font = labelFont
                lblODPrice.AutoSize = True
                card.Controls.Add(lblODPrice)
                top += 25

                ' OS row
                Dim lblOSGrade As New Label
                lblOSGrade.Text = "OS: " & osGrade
                lblOSGrade.Location = New Point(10, top)
                lblOSGrade.Font = labelFont
                lblOSGrade.AutoSize = True
                card.Controls.Add(lblOSGrade)

                Dim lblOSPrice As New Label
                lblOSPrice.Text = "₱" & priceOS.ToString("F2")
                lblOSPrice.Location = New Point(costX, top)
                lblOSPrice.Font = labelFont
                lblOSPrice.AutoSize = True
                card.Controls.Add(lblOSPrice)
                top += 30
            End If

            ' Discounts
            Dim discount As Decimal = 0D
            If Not IsDBNull(reader("discount")) Then
                discount = Convert.ToDecimal(reader("discount"))
            End If

            Dim lensDiscount As Decimal = 0D
            If Not IsDBNull(reader("lensDiscount")) Then
                lensDiscount = Convert.ToDecimal(reader("lensDiscount"))
            End If

            ' Calculate discount totals
            Dim frameDiscountTotal As Decimal = frameSubtotal * discount
            Dim lensDiscountTotal As Decimal = lensSubtotal * lensDiscount

            ' Display Frame Discount in card
            Dim lblFrameDiscountCard As New Label
            'lblFrameDiscountCard.Text = "Frame Discount: (" & (discount * 100).ToString("F0") & "%)"
            lblFrameDiscountCard.Text = "Frame Discount: " & (discount * 100).ToString("F0") & "%"
            lblFrameDiscountCard.Location = New Point(10, top)
            lblFrameDiscountCard.Font = labelFont
            lblFrameDiscountCard.AutoSize = True
            card.Controls.Add(lblFrameDiscountCard)

            Dim lblFrameDiscountAmount As New Label
            lblFrameDiscountAmount.Text = "₱" & frameDiscountTotal.ToString("F2")
            lblFrameDiscountAmount.Location = New Point(costX, top)
            lblFrameDiscountAmount.Font = labelFont
            lblFrameDiscountAmount.AutoSize = True
            card.Controls.Add(lblFrameDiscountAmount)
            top += 30

            ' Display Lens Discount in card
            Dim lblLensDiscountCard As New Label
            'lblLensDiscountCard.Text = "Lens Discount: (" & (lensDiscount * 100).ToString("F0") & "%)"
            lblLensDiscountCard.Text = "Lens Discount: " & (lensDiscount * 100).ToString("F0") & "%"
            lblLensDiscountCard.Location = New Point(10, top)
            lblLensDiscountCard.Font = labelFont
            lblLensDiscountCard.AutoSize = True
            card.Controls.Add(lblLensDiscountCard)

            Dim lblLensDiscountAmount As New Label
            lblLensDiscountAmount.Text = "₱" & lensDiscountTotal.ToString("F2")
            lblLensDiscountAmount.Location = New Point(costX, top)
            lblLensDiscountAmount.Font = labelFont
            lblLensDiscountAmount.AutoSize = True
            card.Controls.Add(lblLensDiscountAmount)
            top += 30

            ' Update fixed labels for frame discount (percent and total)
            Me.lblFrameDiscount.Text = (discount * 100).ToString("F0") & "%"
            Me.lblFrameTotal.Text = "₱" & frameDiscountTotal.ToString("F2")

            ' Update fixed labels for lens discount (percent and total)
            Me.lblLensDiscount.Text = (lensDiscount * 100).ToString("F0") & "%"
            Me.lblLensTotal.Text = "₱" & lensDiscountTotal.ToString("F2")

            ' Calculate Check-up Fee
            ' In addPatientTransaction, totalAmount includes:
            '   - discounted item totals (frames, lenses, etc.)
            '   - OD and OS prices (priceOD, priceOS)
            '   - check-up fee (if any)
            ' tbl_transaction_items.totalPrice already contains the discounted item totals,
            ' but not the OD/OS costs separately. We stored priceOD/priceOS above when
            ' reading items, so we subtract them as part of the item side.

            Dim totalAmount As Decimal = Convert.ToDecimal(reader("totalAmount"))

            ' Calculate sum of all items (already includes discount in totalPrice from DB)
            Dim itemsTotal As Decimal = 0D
            Dim cmdSumItems As New Odbc.OdbcCommand(
                "SELECT SUM(totalPrice) FROM tbl_transaction_items WHERE transactionID = ?", conn)
            cmdSumItems.Parameters.Add(New Odbc.OdbcParameter("?", Odbc.OdbcType.Int)).Value = transactionID
            Dim sumResult = cmdSumItems.ExecuteScalar()
            If sumResult IsNot Nothing AndAlso Not IsDBNull(sumResult) Then
                itemsTotal = Convert.ToDecimal(sumResult)
            End If

            ' Treat OD/OS prices as part of items, not check-up fee
            Dim itemsPlusODOS As Decimal = itemsTotal + priceOD + priceOS

            ' Check-up fee is the remaining amount after removing all item-related amounts
            Dim checkupFeeTotal As Decimal = totalAmount - itemsPlusODOS
            If checkupFeeTotal < 0D Then checkupFeeTotal = 0D

            ' Only display check-up fee if there is one (and it's positive)
            If checkupFeeTotal > 0D Then
                Dim lblCheckupFee As New Label
                lblCheckupFee.Text = "Check-up Fee:"
                lblCheckupFee.Location = New Point(10, top)
                lblCheckupFee.Font = labelFont
                lblCheckupFee.AutoSize = True
                card.Controls.Add(lblCheckupFee)

                Dim lblCheckupFeeAmount As New Label
                lblCheckupFeeAmount.Text = "₱" & checkupFeeTotal.ToString("F2")
                lblCheckupFeeAmount.Location = New Point(costX, top)
                lblCheckupFeeAmount.Font = labelFont
                lblCheckupFeeAmount.AutoSize = True
                card.Controls.Add(lblCheckupFeeAmount)
                top += 30
            End If

            ' Determine transaction type based on numeric isCheckUp code and presence of items
            ' Codes: 0 = Check-up Only, 1 = With Check-up, 3 = Items Only
            Dim isCheckUpCode As Integer = 3
            Try
                If Not IsDBNull(reader("isCheckUp")) Then
                    Integer.TryParse(reader("isCheckUp").ToString(), isCheckUpCode)
                End If
            Catch
            End Try

            Dim hasItems As Boolean = False

            ' Check if there are any product items (excluding empty product names)
            Dim cmdCheckItems As New Odbc.OdbcCommand(
                "SELECT COUNT(*) FROM tbl_transaction_items WHERE transactionID = ? AND productName IS NOT NULL AND productName <> ''", conn)
            cmdCheckItems.Parameters.Add(New Odbc.OdbcParameter("?", Odbc.OdbcType.Int)).Value = transactionID
            Dim itemCount As Integer = Convert.ToInt32(cmdCheckItems.ExecuteScalar())
            hasItems = (itemCount > 0)

            ' Divider
            Dim divider As New Panel
            divider.BackColor = Color.Black
            divider.Size = New Size(card.Width - 20, 1)
            divider.Location = New Point(10, top)
            card.Controls.Add(divider)
            top += 20

            ' Display transaction type based on code and items, below the divider
            Dim transactionTypeText As String = String.Empty
            Select Case isCheckUpCode
                Case 0
                    transactionTypeText = "Check-up Only"
                Case 1
                    If hasItems Then
                        transactionTypeText = "With Check-up"
                    Else
                        ' With check-up but no items saved; treat as Check-up only
                        transactionTypeText = "Check-up Only"
                    End If
                Case 3
                    If hasItems Then
                        transactionTypeText = "Items Only"
                    Else
                        transactionTypeText = String.Empty ' No items at all
                    End If
                Case Else
                    transactionTypeText = String.Empty ' Unknown code
            End Select

            If Not String.IsNullOrEmpty(transactionTypeText) Then
                ' Left label: "Transaction type:"
                Dim lblTransactionTypeLabel As New Label
                lblTransactionTypeLabel.Text = "Transaction type:"
                lblTransactionTypeLabel.Location = New Point(10, top)
                lblTransactionTypeLabel.Font = labelBoldFont
                lblTransactionTypeLabel.AutoSize = True
                card.Controls.Add(lblTransactionTypeLabel)

                ' Right value: e.g. "With Check-up" aligned with other right-column values
                Dim lblTransactionTypeVal As New Label
                lblTransactionTypeVal.Text = transactionTypeText
                lblTransactionTypeVal.Location = New Point(costX, top)
                lblTransactionTypeVal.Font = labelFont
                lblTransactionTypeVal.AutoSize = True
                card.Controls.Add(lblTransactionTypeVal)

                top += 30
            End If

            ' Payment Type
            Dim lblPaymentType As New Label
            lblPaymentType.Text = "Payment Type:"
            lblPaymentType.Location = New Point(10, top)
            lblPaymentType.Font = labelBoldFont
            lblPaymentType.AutoSize = True
            card.Controls.Add(lblPaymentType)

            Dim paymentType As String = reader("paymentType").ToString()
            Dim lblPaymentTypeVal As New Label
            lblPaymentTypeVal.Text = paymentType
            lblPaymentTypeVal.Location = New Point(costX, top)
            lblPaymentTypeVal.Font = labelFont
            lblPaymentTypeVal.AutoSize = True
            card.Controls.Add(lblPaymentTypeVal)
            top += 30

            ' Reference Number (only for G-cash)
            Dim referenceNum As String = ""
            If Not IsDBNull(reader("referenceNum")) Then
                referenceNum = reader("referenceNum").ToString()
            End If

            If paymentType.Equals("G-cash", StringComparison.OrdinalIgnoreCase) AndAlso referenceNum <> "" Then
                Dim lblRefLabel As New Label
                lblRefLabel.Text = "Reference Number:"
                lblRefLabel.Location = New Point(10, top)
                lblRefLabel.Font = labelBoldFont
                lblRefLabel.AutoSize = True
                card.Controls.Add(lblRefLabel)

                Dim lblRefVal As New Label
                lblRefVal.Text = referenceNum
                lblRefVal.Location = New Point(costX, top)
                lblRefVal.Font = labelFont
                lblRefVal.AutoSize = True
                card.Controls.Add(lblRefVal)
                top += 30
            End If

            ' Total Amount
            Dim lblTotalAmount As New Label
            lblTotalAmount.Text = "Total:"
            lblTotalAmount.Location = New Point(10, top)
            lblTotalAmount.Font = labelBoldFont
            lblTotalAmount.AutoSize = True
            card.Controls.Add(lblTotalAmount)

            Dim lblTotalAmountVal As New Label
            lblTotalAmountVal.Text = "₱" & Convert.ToDecimal(reader("totalAmount")).ToString("F2")
            lblTotalAmountVal.Location = New Point(costX, top)
            lblTotalAmountVal.Font = labelFont
            lblTotalAmountVal.AutoSize = True
            card.Controls.Add(lblTotalAmountVal)
            top += 30

            ' Pending Balance
            Dim lblPendingBalance As New Label
            lblPendingBalance.Text = "Pending Balance:"
            lblPendingBalance.Location = New Point(10, top)
            lblPendingBalance.Font = labelBoldFont
            lblPendingBalance.AutoSize = True
            card.Controls.Add(lblPendingBalance)

            Dim lblPendingBalanceVal As New Label
            lblPendingBalanceVal.Text = "₱" & (Convert.ToDecimal(reader("totalAmount")) - Convert.ToDecimal(reader("amountPaid"))).ToString("F2")
            lblPendingBalanceVal.Location = New Point(costX, top)
            lblPendingBalanceVal.Font = labelFont
            lblPendingBalanceVal.AutoSize = True
            card.Controls.Add(lblPendingBalanceVal)

            ' Auto-expand card height based on content
            card.Height = top + Math.Max(lblPendingBalanceVal.Height, 20) + 20

            yOffset += card.Height + 10
        End While

        reader.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    ' Click handler for per-card Payment History buttons
    Private Sub CardPaymentHistory_Click(sender As Object, e As EventArgs)
        Try
            Dim btn As Button = TryCast(sender, Button)
            If btn Is Nothing Then Exit Sub
            Dim transactionID As Integer = 0
            If btn.Tag IsNot Nothing Then
                Integer.TryParse(btn.Tag.ToString(), transactionID)
            End If
            If transactionID <= 0 Then Exit Sub
            ' Open payment history form for this transaction
            Dim frm As New viewPaymentHistory()
            frm.TransactionID = transactionID
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.ShowDialog(Me)
        Catch
        End Try
    End Sub

    Private Sub viewTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Prevent multiple instances
        isFormOpen = True
    End Sub

    Private Sub viewTransactions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        isFormOpen = False
    End Sub

    ' Public method to check if form is already open
    Public Shared Function IsInstanceOpen() As Boolean
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is viewTransactions Then
                frm.BringToFront()
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            Dim rpt As New Reports()
            rpt.ShowStaffTransactionMode()   ' switch UI to staff transaction (cmbStaffSelect)
            rpt.StartPosition = FormStartPosition.CenterScreen
            rpt.ShowDialog(Me)
        Catch
        End Try
    End Sub
End Class