Public Class patientActions

    Private Sub btnCheckupHistory_Click(sender As Object, e As EventArgs) Handles btnCheckupHistory.Click
        btnCheckupHistory.BackColor = SystemColors.GradientActiveCaption
        btnCheckupHistory.ForeColor = Color.Black

        ' Deactivate the other button
        btnTransactionHistory.BackColor = SystemColors.Control
        btnTransactionHistory.ForeColor = Color.Black
        pnlcheckUp.Visible = True
        pnlTransactions.Visible = False
    End Sub

    Private Sub btnTransactionHistory_Click(sender As Object, e As EventArgs) Handles btnTransactionHistory.Click
        btnTransactionHistory.BackColor = SystemColors.GradientActiveCaption
        btnTransactionHistory.ForeColor = Color.Black

        btnCheckupHistory.BackColor = SystemColors.Control
        btnCheckupHistory.ForeColor = Color.Black
        pnlcheckUp.Visible = False
        pnlTransactions.Visible = True
    End Sub
    Public Sub ViewPatientRecord(patientID As String)
        Call dbConn()

        Dim cmd As New Odbc.OdbcCommand("SELECT * FROM patient_data WHERE patientID = ?", conn)
        cmd.Parameters.AddWithValue("?", patientID)

        Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

        If reader.Read() Then


            ' Assign values to labels
            lblFname.Text = reader("fname").ToString()
            lblMname.Text = reader("mname").ToString()
            lblLname.Text = reader("lname").ToString()
            lblDOB.Text = Convert.ToDateTime(reader("bday")).ToShortDateString()
            
            ' Compute age from birthday
            Dim birthDate As Date = Convert.ToDateTime(reader("bday"))
            Dim today As Date = Date.Today
            Dim age As Integer = today.Year - birthDate.Year
            If (birthDate > today.AddYears(-age)) Then
                age -= 1
            End If
            lblAge.Text = age.ToString()
            
            lblGender.Text = reader("gender").ToString()
            lblContact.Text = reader("mobilenum").ToString()
            lblOccupation.Text = reader("occupation").ToString()
            lblRegion.Text = reader("region").ToString()
            lblProvince.Text = reader("province").ToString()
            lblCity.Text = reader("city").ToString()
            lblBrgy.Text = reader("brgy").ToString()
            ' Normalize boolean-like fields to match addPatient.vb bindings
            Dim hbVal As String = reader("highblood").ToString().Trim().ToLower()
            Dim dbVal As String = reader("diabetic").ToString().Trim().ToLower()
            Dim isHB As Boolean = (hbVal = "yes" Or hbVal = "true" Or hbVal = "1" Or hbVal = "y")
            Dim isDB As Boolean = (dbVal = "yes" Or dbVal = "true" Or dbVal = "1" Or dbVal = "y")
            lblHB.Text = If(isHB, "Yes", "No")
            lblDB.Text = If(isDB, "Yes", "No")
            lblSports.Text = reader("sports").ToString()
            lblHobbies.Text = reader("hobbies").ToString()
        End If

        reader.Close()
    End Sub

    Public Sub ViewCheckup(patientID As String)
        pnlcheckUp.Controls.Clear()
        pnlcheckUp.AutoScroll = True

        Dim yOffset As Integer = 10
        Dim cmd As New Odbc.OdbcCommand()
        ' Updated query to include PD fields from tbl_checkup
        Dim sql As String = "SELECT c.checkupID AS CheckupID, p.fullname AS PatientName, p.patientID AS PatientID, " & _
                            "d.fullname AS DoctorName, c.checkupDate AS CheckupDate, " & _
                            "c.sphereOD, c.sphereOS, c.cylinderOD, c.cylinderOS, c.axisOD, c.axisOS, " & _
                            "c.addOD, c.addOS, c.pdOD, c.pdOS, c.pdOU, c.remarks " & _
                            "FROM tbl_checkup c " & _
                            "JOIN db_viewpatient p ON c.patientID = p.patientID " & _
                            "JOIN db_viewdoctors d ON c.doctorID = d.doctorID " & _
                            "WHERE c.patientID = ? ORDER BY c.checkupID DESC"
        Call dbConn()
        cmd.Connection = conn
        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("", patientID)

        Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()
        Dim labelFontBold As New Font("Segoe UI", 11, FontStyle.Regular)
        Dim labelFontRegular As New Font("Segoe UI", 11, FontStyle.Regular)

        While reader.Read()
            Dim card As New Panel()
            card.Size = New Size(pnlcheckUp.Width - 30, 350)
            card.Location = New Point(10, yOffset)
            card.BackColor = Color.White
            card.BorderStyle = BorderStyle.FixedSingle

            ' Patient Name
            Dim lblPatientTitle As New Label()
            lblPatientTitle.Text = "Patient Name:"
            lblPatientTitle.Location = New Point(10, 10)
            lblPatientTitle.AutoSize = True
            lblPatientTitle.Font = labelFontBold
            card.Controls.Add(lblPatientTitle)

            Dim lblPatientValue As New Label()
            lblPatientValue.Text = reader("PatientName").ToString()
            lblPatientValue.Location = New Point(lblPatientTitle.Right + 5, 10)
            lblPatientValue.AutoSize = True
            lblPatientValue.Font = labelFontRegular
            card.Controls.Add(lblPatientValue)

            ' Date
            Dim lblDateTitle As New Label()
            lblDateTitle.Text = "Date:"
            lblDateTitle.Location = New Point(10, 45)
            lblDateTitle.AutoSize = True
            lblDateTitle.Font = labelFontBold
            card.Controls.Add(lblDateTitle)

            Dim lblDateValue As New Label()
            lblDateValue.Text = Convert.ToDateTime(reader("CheckupDate")).ToShortDateString()
            lblDateValue.Location = New Point(lblDateTitle.Right + 5, 45)
            lblDateValue.AutoSize = True
            lblDateValue.Font = labelFontRegular
            card.Controls.Add(lblDateValue)

            ' Line below date
            Dim dateLine As New Panel()
            dateLine.BackColor = Color.Black
            dateLine.Size = New Size(card.Width - 20, 2)
            dateLine.Location = New Point(10, 80)
            card.Controls.Add(dateLine)

            ' Headers
            Dim colWidth As Integer = (card.Width - 20) \ 5
            Dim headerTop As Integer = 90
            Dim rowTop1 As Integer = 125
            Dim rowTop2 As Integer = 155
            Dim leftMargin As Integer = 10

            Dim headers() As String = {"Sphere:", "Cylinder:", "Axis:", "Add:", "PD:"}
            For i As Integer = 0 To 4
                Dim lblHeader As New Label()
                lblHeader.Text = headers(i)
                lblHeader.Font = labelFontBold
                lblHeader.Location = New Point(leftMargin + (i * colWidth), headerTop)
                lblHeader.AutoSize = True
                card.Controls.Add(lblHeader)

                Dim underline As New Panel()
                underline.BackColor = Color.Black
                underline.Size = New Size(colWidth, 2)
                underline.Location = New Point(leftMargin + (i * colWidth), headerTop + 30)
                card.Controls.Add(underline)
            Next

            ' Sphere OD/OS
            Dim lblSphereOD As New Label()
            lblSphereOD.Text = "OD:"
            lblSphereOD.Location = New Point(leftMargin, rowTop1)
            lblSphereOD.AutoSize = True
            lblSphereOD.Font = labelFontBold
            card.Controls.Add(lblSphereOD)

            Dim valSphereOD As New Label()
            valSphereOD.Text = reader("sphereOD").ToString()
            valSphereOD.Location = New Point(lblSphereOD.Right + 5, rowTop1)
            valSphereOD.AutoSize = True
            valSphereOD.Font = labelFontRegular
            card.Controls.Add(valSphereOD)

            Dim lblSphereOS As New Label()
            lblSphereOS.Text = "OS:"
            lblSphereOS.Location = New Point(leftMargin, rowTop2)
            lblSphereOS.AutoSize = True
            lblSphereOS.Font = labelFontBold
            card.Controls.Add(lblSphereOS)

            Dim valSphereOS As New Label()
            valSphereOS.Text = reader("sphereOS").ToString()
            valSphereOS.Location = New Point(lblSphereOS.Right + 5, rowTop2)
            valSphereOS.AutoSize = True
            valSphereOS.Font = labelFontRegular
            card.Controls.Add(valSphereOS)

            ' Cylinder OD/OS
            Dim lblCylinderOD As New Label()
            lblCylinderOD.Text = "OD:"
            lblCylinderOD.Location = New Point(leftMargin + colWidth, rowTop1)
            lblCylinderOD.AutoSize = True
            lblCylinderOD.Font = labelFontBold
            card.Controls.Add(lblCylinderOD)

            Dim valCylinderOD As New Label()
            valCylinderOD.Text = reader("cylinderOD").ToString()
            valCylinderOD.Location = New Point(lblCylinderOD.Right + 5, rowTop1)
            valCylinderOD.AutoSize = True
            valCylinderOD.Font = labelFontRegular
            card.Controls.Add(valCylinderOD)

            Dim lblCylinderOS As New Label()
            lblCylinderOS.Text = "OS:"
            lblCylinderOS.Location = New Point(leftMargin + colWidth, rowTop2)
            lblCylinderOS.AutoSize = True
            lblCylinderOS.Font = labelFontBold
            card.Controls.Add(lblCylinderOS)

            Dim valCylinderOS As New Label()
            valCylinderOS.Text = reader("cylinderOS").ToString()
            valCylinderOS.Location = New Point(lblCylinderOS.Right + 5, rowTop2)
            valCylinderOS.AutoSize = True
            valCylinderOS.Font = labelFontRegular
            card.Controls.Add(valCylinderOS)

            ' Axis OD/OS
            Dim lblAxisOD As New Label()
            lblAxisOD.Text = "OD:"
            lblAxisOD.Location = New Point(leftMargin + (colWidth * 2), rowTop1)
            lblAxisOD.AutoSize = True
            lblAxisOD.Font = labelFontBold
            card.Controls.Add(lblAxisOD)

            Dim valAxisOD As New Label()
            valAxisOD.Text = reader("axisOD").ToString()
            valAxisOD.Location = New Point(lblAxisOD.Right + 5, rowTop1)
            valAxisOD.AutoSize = True
            valAxisOD.Font = labelFontRegular
            card.Controls.Add(valAxisOD)

            Dim lblAxisOS As New Label()
            lblAxisOS.Text = "OS:"
            lblAxisOS.Location = New Point(leftMargin + (colWidth * 2), rowTop2)
            lblAxisOS.AutoSize = True
            lblAxisOS.Font = labelFontBold
            card.Controls.Add(lblAxisOS)

            Dim valAxisOS As New Label()
            valAxisOS.Text = reader("axisOS").ToString()
            valAxisOS.Location = New Point(lblAxisOS.Right + 5, rowTop2)
            valAxisOS.AutoSize = True
            valAxisOS.Font = labelFontRegular
            card.Controls.Add(valAxisOS)

            ' Add OD/OS
            Dim lblAddOD As New Label()
            lblAddOD.Text = "OD:"
            lblAddOD.Location = New Point(leftMargin + (colWidth * 3), rowTop1)
            lblAddOD.AutoSize = True
            lblAddOD.Font = labelFontBold
            card.Controls.Add(lblAddOD)

            Dim valAddOD As New Label()
            valAddOD.Text = reader("addOD").ToString()
            valAddOD.Location = New Point(lblAddOD.Right + 5, rowTop1)
            valAddOD.AutoSize = True
            valAddOD.Font = labelFontRegular
            card.Controls.Add(valAddOD)

            Dim lblAddOS As New Label()
            lblAddOS.Text = "OS:"
            lblAddOS.Location = New Point(leftMargin + (colWidth * 3), rowTop2)
            lblAddOS.AutoSize = True
            lblAddOS.Font = labelFontBold
            card.Controls.Add(lblAddOS)

            Dim valAddOS As New Label()
            valAddOS.Text = reader("addOS").ToString()
            valAddOS.Location = New Point(lblAddOS.Right + 5, rowTop2)
            valAddOS.AutoSize = True
            valAddOS.Font = labelFontRegular
            card.Controls.Add(valAddOS)

            ' PD OD/OS/OU (5th column)
            Dim lblPDOD As New Label()
            lblPDOD.Text = "OD:"
            lblPDOD.Location = New Point(leftMargin + (colWidth * 4), rowTop1)
            lblPDOD.AutoSize = True
            lblPDOD.Font = labelFontBold
            card.Controls.Add(lblPDOD)

            Dim valPDOD As New Label()
            valPDOD.Text = If(IsDBNull(reader("pdOD")), "N/A", reader("pdOD").ToString())
            valPDOD.Location = New Point(lblPDOD.Right + 5, rowTop1)
            valPDOD.AutoSize = True
            valPDOD.Font = labelFontRegular
            card.Controls.Add(valPDOD)

            Dim lblPDOS As New Label()
            lblPDOS.Text = "OS:"
            lblPDOS.Location = New Point(leftMargin + (colWidth * 4), rowTop2)
            lblPDOS.AutoSize = True
            lblPDOS.Font = labelFontBold
            card.Controls.Add(lblPDOS)

            Dim valPDOS As New Label()
            valPDOS.Text = If(IsDBNull(reader("pdOS")), "N/A", reader("pdOS").ToString())
            valPDOS.Location = New Point(lblPDOS.Right + 5, rowTop2)
            valPDOS.AutoSize = True
            valPDOS.Font = labelFontRegular
            card.Controls.Add(valPDOS)

            ' PD OU (3rd row in PD column)
            Dim rowTop3 As Integer = 185
            Dim lblPDOU As New Label()
            lblPDOU.Text = "OU:"
            lblPDOU.Location = New Point(leftMargin + (colWidth * 4), rowTop3)
            lblPDOU.AutoSize = True
            lblPDOU.Font = labelFontBold
            card.Controls.Add(lblPDOU)

            Dim valPDOU As New Label()
            valPDOU.Text = If(IsDBNull(reader("pdOU")), "N/A", reader("pdOU").ToString())
            valPDOU.Location = New Point(lblPDOU.Right + 5, rowTop3)
            valPDOU.AutoSize = True
            valPDOU.Font = labelFontRegular
            card.Controls.Add(valPDOU)

            ' Remarks line
            Dim remarksLine As New Panel()
            remarksLine.BackColor = Color.Black
            remarksLine.Size = New Size(card.Width - 20, 2)
            remarksLine.Location = New Point(10, 220)
            card.Controls.Add(remarksLine)

            ' Remarks
            Dim lblRemarksTitle As New Label()
            lblRemarksTitle.Text = "Remarks:"
            lblRemarksTitle.Location = New Point(leftMargin, 230)
            lblRemarksTitle.AutoSize = True
            lblRemarksTitle.Font = labelFontBold
            card.Controls.Add(lblRemarksTitle)

            Dim lblRemarksValue As New Label()
            lblRemarksValue.Text = reader("remarks").ToString()
            lblRemarksValue.Location = New Point(lblRemarksTitle.Right + 5, 230)
            lblRemarksValue.AutoSize = True
            lblRemarksValue.Font = labelFontRegular
            card.Controls.Add(lblRemarksValue)

            ' Doctor line
            Dim doctorline As New Panel()
            doctorline.BackColor = Color.Black
            doctorline.Size = New Size(card.Width - 20, 2)
            doctorline.Location = New Point(leftMargin, 280)
            card.Controls.Add(doctorline)

            ' Doctor Name
            Dim lblDoctorTitle As New Label()
            lblDoctorTitle.Text = "Doctor Name:"
            lblDoctorTitle.Location = New Point(leftMargin, 290)
            lblDoctorTitle.AutoSize = True
            lblDoctorTitle.Font = labelFontBold
            card.Controls.Add(lblDoctorTitle)

            Dim lblDoctorValue As New Label()
            lblDoctorValue.Text = reader("DoctorName").ToString()
            lblDoctorValue.Location = New Point(lblDoctorTitle.Right + 5, 290)
            lblDoctorValue.AutoSize = True
            lblDoctorValue.Font = labelFontRegular
            card.Controls.Add(lblDoctorValue)

            ' Add card to panel
            pnlcheckUp.Controls.Add(card)
            yOffset += card.Height + 10
        End While

        reader.Close()
    End Sub
    Public Sub LoadViewTransaction(patientID As Integer)
        pnlTransactions.Controls.Clear()
        pnlTransactions.AutoScroll = True

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
            card.Size = New Size(pnlTransactions.Width - 30, 400)
            card.Location = New Point(10, yOffset)
            card.BackColor = Color.White
            card.BorderStyle = BorderStyle.FixedSingle
            pnlTransactions.Controls.Add(card)

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

            ' Check-up Only flag (show when isCheckUp = True)
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


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub
    Public _currentPatientID As Integer
    Public Sub InitializeForPatient(patientID As Integer)
        _currentPatientID = patientID
        ViewPatientRecord(patientID)
        ViewCheckup(patientID)
        LoadViewTransaction(patientID)
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If _currentPatientID <= 0 Then
            MessageBox.Show("No patient selected to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("Are you sure you want to edit this patient?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Create the form
            Dim editForm As New addPatient()

            ' Pre-bind address based on currently viewed patient labels
            editForm.SelectedAddress = String.Format("{0}, {1}, {2}", lblProvince.Text, lblCity.Text, lblBrgy.Text)

            ' Store the original title so we can restore it if the form changes it
            Dim originalTitle As String = editForm.Text

            ' Show the form
            editForm.Show()

            ' Change the label text
            editForm.lblHead.Text = "Edit Patient Information"
            editForm.pbAdd.Visible = False
            editForm.pbEdit.Visible = True

            ' 🔒 Keep overriding the form's title until it's closed
            Dim titleFixer As New Timer() With {.Interval = 100}
            AddHandler titleFixer.Tick,
                Sub()
                    If editForm.IsDisposed OrElse Not editForm.Visible Then
                        titleFixer.Stop()
                        titleFixer.Dispose()
                    ElseIf editForm.Text <> originalTitle Then
                        editForm.Text = originalTitle
                    End If
                End Sub
            titleFixer.Start()

            ' Load the record asynchronously
            editForm.pnlDataEntry.Tag = _currentPatientID
            editForm.BeginInvoke(CType(Sub()
                                           editForm.loadRecord(_currentPatientID)
                                       End Sub, Action))

            editForm.Activate()
            editForm.TopMost = True
            editForm.TopMost = False

            ' After closing, refresh this view
            AddHandler editForm.FormClosed,
                Sub(sender2, e2)
                    titleFixer.Stop()
                    titleFixer.Dispose()
                    ViewPatientRecord(_currentPatientID)



                End Sub
        End If

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub


    Private Sub btnCheckup_Click(sender As Object, e As EventArgs) Handles btnCheckup.Click
        If _currentPatientID = 0 Then
            MessageBox.Show("Invalid Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        ' Allow check-up without requiring the patient to be in the queue
        Dim checkupForm As New patientCheckUp()
        checkupForm.SelectedPatientID = _currentPatientID
        checkupForm.ParentFormRef = Me
        checkupForm.ShowDialog()

    End Sub

    Private Sub btnCreateTransactions_Click(sender As Object, e As EventArgs) Handles btnCreateTransactions.Click
        If _currentPatientID = 0 Then
            MessageBox.Show("Invalid Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Check if patient has pending balance
        Try
            Call dbConn()

            Dim sql As String = "SELECT SUM(pendingBalance) AS totalPending FROM tbl_transactions WHERE patientID = ? AND paymentStatus = 'Pending'"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", _currentPatientID)

            Dim result = cmd.ExecuteScalar()
            Dim pendingBalance As Decimal = 0D

            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                pendingBalance = Convert.ToDecimal(result)
            End If

            conn.Close()

            If pendingBalance > 0 Then
                MessageBox.Show("This patient has a pending balance of ₱" & pendingBalance.ToString("F2") & vbCrLf & vbCrLf & _
                               "Please settle the pending balance first before creating a new transaction.", _
                               "Pending Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ' Do not open the form - exit the sub
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show("Error checking pending balance: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' Open create transactions form with lens control logic
        Dim createNewTransactions As New createTransactions()
        createNewTransactions.SelectedPatientID = _currentPatientID
        createNewTransactions.RefreshViewTransactions = Me
        createNewTransactions.ShowDialog()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSetAppointment.Click
        If _currentPatientID = 0 Then
            MessageBox.Show("Invalid Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim latestCheckupID As Integer = 0
        Dim patientName As String = ""

        Try
            Call dbConn()
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening database connection: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' Fetch the patient name and the latest check-up ID for the patient
        Dim sql As String = "SELECT CONCAT(p.fname, ' ', p.mname, ' ', p.lname) AS fullName, c.checkupID " & _
                    "FROM patient_data p " & _
                    "LEFT JOIN tbl_checkup c ON p.patientID = c.patientID " & _
                    "WHERE p.patientID = ? " & _
                    "ORDER BY c.checkupDate DESC LIMIT 1"

        Try
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", _currentPatientID)
                Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    patientName = reader("fullName").ToString()
                    latestCheckupID = If(IsDBNull(reader("checkupID")), 0, Convert.ToInt32(reader("checkupID")))
                Else
                    MessageBox.Show("No record found for this patient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                reader.Close()
            End Using

            ' Now open the PatientNextAppointment form and pass the patient info
            Dim queue As New PatientNextAppointment()
            queue.selectedPatientID = _currentPatientID
            queue.latestCheckupID = latestCheckupID
            queue.PatientName = patientName
            queue.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error fetching patient or checkup data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    'Private Sub btnQueue_Click(sender As Object, e As EventArgs) Handles btnQueue.Click
    '    If _currentPatientID = 0 Then
    '        MessageBox.Show("Invalid Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Exit Sub
    '    End If
    '    Dim queue As New PatientQueue()
    '    queue.SelectedPatientID = _currentPatientID
    '    queue.ShowDialog()
    'End Sub

    Private Sub patientActions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class