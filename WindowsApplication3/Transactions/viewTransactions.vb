Public Class viewTransactions
    Public Sub LoadViewTransaction(patientID As Integer)
        pnlViewTransactions.Controls.Clear()
        pnlViewTransactions.AutoScroll = True

        Call dbConn()
        Dim cmd As New Odbc.OdbcCommand(
            "SELECT t.transactionID, COALESCE(p.fullname, t.patientName) AS patientName, t.transactionDate, t.discount, t.lensDiscount, t.totalAmount, t.amountPaid, t.paymentType, t.paymentStatus, t.isCheckUp " & _
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
            lblDate.Text = "Date: " & (reader("transactionDate")).ToShortDateString()
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
            Dim transactionID As Integer = Convert.ToInt32(reader("transactionID"))
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



                ' Product Name & Quantity
                Dim lblItem As New Label
                lblItem.Text = quantity.ToString() & " x " & productName
                lblItem.Location = New Point(10, top)
                lblItem.Font = labelFont
                lblItem.AutoSize = True
                card.Controls.Add(lblItem)

                ' Product Price
                Dim lblItemPrice As New Label
                lblItemPrice.Text = "₱" & totalPrice.ToString("F2")
                lblItemPrice.Location = New Point(costX, top)
                lblItemPrice.Font = labelFont
                lblItemPrice.AutoSize = True
                card.Controls.Add(lblItemPrice)
                top += 30

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

            ' After listing all products, show the OD/OS grades and prices only once
            If Not String.IsNullOrEmpty(odGrade) Then
                ' OD and OS Grades
                Dim lblODGrade As New Label
                lblODGrade.Text = "OD: " & odGrade & " / OS: " & osGrade
                lblODGrade.Location = New Point(10, top)
                lblODGrade.Font = New Font("Segoe UI", 12, FontStyle.Italic)
                lblODGrade.AutoSize = True
                card.Controls.Add(lblODGrade)

                ' OD and OS Prices
                Dim lblODPrice As New Label
                lblODPrice.Text = "₱" & priceOD.ToString("F2") & " / ₱" & priceOS.ToString("F2")
                lblODPrice.Location = New Point(costX, top)
                lblODPrice.Font = New Font("Segoe UI", 12, FontStyle.Italic)
                lblODPrice.AutoSize = True
                card.Controls.Add(lblODPrice)
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

            ' Check-up Fee
            Dim lblCheckupFee As New Label
            lblCheckupFee.Text = "Check-up Fee:"
            lblCheckupFee.Location = New Point(10, top)
            lblCheckupFee.Font = labelFont
            lblCheckupFee.AutoSize = True
            card.Controls.Add(lblCheckupFee)

            Dim lblCheckupFeeAmount As New Label
            lblCheckupFeeAmount.Text = "₱300.00"
            lblCheckupFeeAmount.Location = New Point(costX, top)
            lblCheckupFeeAmount.Font = labelFont
            lblCheckupFeeAmount.AutoSize = True
            card.Controls.Add(lblCheckupFeeAmount)
            top += 30

            ' Check-up Only flag
            If Convert.ToBoolean(reader("isCheckUp")) Then
                Dim lblCheckupOnly As New Label
                lblCheckupOnly.Text = "Check-up Only"
                lblCheckupOnly.Location = New Point(10, top)
                lblCheckupOnly.Font = labelFont
                lblCheckupOnly.AutoSize = True
                card.Controls.Add(lblCheckupOnly)
                top += 30
            End If

            ' Divider
            Dim divider As New Panel
            divider.BackColor = Color.Black
            divider.Size = New Size(card.Width - 20, 1)
            divider.Location = New Point(10, top)
            card.Controls.Add(divider)
            top += 20

            ' Payment Type
            Dim lblPaymentType As New Label
            lblPaymentType.Text = "Payment Type:"
            lblPaymentType.Location = New Point(10, top)
            lblPaymentType.Font = labelBoldFont
            lblPaymentType.AutoSize = True
            card.Controls.Add(lblPaymentType)

            Dim lblPaymentTypeVal As New Label
            lblPaymentTypeVal.Text = reader("paymentType").ToString()
            lblPaymentTypeVal.Location = New Point(costX, top)
            lblPaymentTypeVal.Font = labelFont
            lblPaymentTypeVal.AutoSize = True
            card.Controls.Add(lblPaymentTypeVal)
            top += 30

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

            yOffset += card.Height + 10
        End While

        reader.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub

    Private Sub viewTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class