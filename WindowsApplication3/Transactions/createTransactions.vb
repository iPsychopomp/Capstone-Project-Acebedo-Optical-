Public Class createTransactions
    Public Property SelectedPatientID As Integer
    Public Property SelectedPatientName As String
    Public RefreshViewTransactions As patientActions
    Private hasCheckupBaseApplied As Boolean = False
    Public Property IsCheckupPayment As Boolean = False
    
    ' Checkup data properties
    Public Property CheckupRemarks As String = ""
    Public Property CheckupDoctorID As String = ""
    Public Property CheckupSphereOD As String = ""
    Public Property CheckupSphereOS As String = ""
    Public Property CheckupCylinderOD As String = ""
    Public Property CheckupCylinderOS As String = ""
    Public Property CheckupAxisOD As String = ""
    Public Property CheckupAxisOS As String = ""
    Public Property CheckupAddOD As String = ""
    Public Property CheckupAddOS As String = ""
    Public Property CheckupDate As DateTime = DateTime.Now
    Public Property CheckupODCost As String = "0.00"
    Public Property CheckupOSCost As String = "0.00"

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub createTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPatientID.Text = SelectedPatientID.ToString()
        lblPatientName.Text = SelectedPatientName

        ' Set combo box suggestion behavior
        cmbProducts.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbProducts.AutoCompleteSource = AutoCompleteSource.ListItems

        LoadProductSuggestions()
        With dgvSelectedProducts.Columns
            .Add("productID", "Product ID")
            .Add("ProductName", "Product Name")
            .Add("Category", "Category")
            .Add("Quantity", "Quantity")
            .Add("unitPrice", "Price")
            .Add("Total", "Total")
        End With
        dgvSelectedProducts.Columns("productID").Visible = False
        dgvSelectedProducts.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvSelectedProducts.Columns("unitPrice").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvSelectedProducts.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        If SelectedPatientID <> 0 Then
            LoadPatientName(SelectedPatientID)
        Else
            MessageBox.Show("Invalid Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
        ' Set default discounts to N/A so they don't auto-apply a percentage
        cmbDiscount.SelectedItem = "N/A"
        cmbLensDisc.SelectedItem = "N/A"

        ' Allow manual edits on Total if needed
        txtTotal.ReadOnly = False
        txtTotal.TabStop = True

        ' Handle checkup payment mode
        If IsCheckupPayment Then
            ' For checkup payments, automatically select "Check up only" and disable mode selection
            rbonly.Checked = True
            rbwith.Checked = False
            rbonly.Enabled = False
            rbwith.Enabled = False
            hasCheckupBaseApplied = True
            
            ' Bind checkup data to form fields
            BindCheckupDataToForm()
            
            ' Show checkup information on the form
            DisplayCheckupInfo()
        Else
            ' Start with all options disabled until user selects a radio button
            rbwith.Checked = False
            rbonly.Checked = False

            ' Check if patient has pending balance
            CheckPendingBalance()
        End If

        ' Ensure controls reflect current radio selection on load
        UpdateControls()

    End Sub

    Private Sub CheckPendingBalance()
        Try
            Call dbConn()

            Dim sql As String = "SELECT SUM(pendingBalance) AS totalPending FROM tbl_transactions WHERE patientID = ? AND paymentStatus = 'Pending'"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", SelectedPatientID)

            Dim result = cmd.ExecuteScalar()
            Dim pendingBalance As Decimal = 0D

            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                pendingBalance = Convert.ToDecimal(result)
            End If

            conn.Close()

            If pendingBalance > 0 Then
                MessageBox.Show("This patient has a pending balance of ₱" & pendingBalance.ToString("F2") & vbCrLf & vbCrLf & _
                               "Patient can only do check-up. Please settle the pending balance first before purchasing items.", _
                               "Pending Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                ' Force check-up only mode
                rbonly.Checked = True
                rbwith.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error checking pending balance: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LoadPatientName(patientID As Integer)
        Try
            Call dbConn()

            Dim sql As String = "SELECT CONCAT(fname, ' ', CASE WHEN mname = 'N/A' THEN '' ELSE mname END, ' ', lname) AS fullName FROM patient_data WHERE patientID = ?"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.Add(New Odbc.OdbcParameter("?", Odbc.OdbcType.Int)).Value = patientID

            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                lblPatientName.Text = reader("fullName").ToString()
            Else
                MessageBox.Show("Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading patient name: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BindCheckupDataToForm()
        Try
            ' Format and display OD/OS grades from checkup data
            If Not String.IsNullOrEmpty(CheckupSphereOD) AndAlso CheckupSphereOD <> "0" Then
                Dim odGrade As String = FormatVisionGrade(CheckupSphereOD, CheckupCylinderOD, CheckupAxisOD, CheckupAddOD)
                cmbOD.Text = odGrade
            End If
            
            If Not String.IsNullOrEmpty(CheckupSphereOS) AndAlso CheckupSphereOS <> "0" Then
                Dim osGrade As String = FormatVisionGrade(CheckupSphereOS, CheckupCylinderOS, CheckupAxisOS, CheckupAddOS)
                cmbOS.Text = osGrade
            End If
            
            ' Set OD/OS costs from checkup data (can be modified by user)
            txtODCost.Text = If(String.IsNullOrEmpty(CheckupODCost), "0.00", CheckupODCost)
            txtOSCost.Text = If(String.IsNullOrEmpty(CheckupOSCost), "0.00", CheckupOSCost)
            
            ' Update total to reflect checkup fee
            UpdateTotalLabel()
            
        Catch ex As Exception
            ' If there's an error binding data, just continue - user can enter manually
            Debug.WriteLine("Error binding checkup data: " & ex.Message)
        End Try
    End Sub

    Private Function FormatVisionGrade(sphere As String, cylinder As String, axis As String, add As String) As String
        Dim grade As String = ""
        
        ' Add sphere
        If Not String.IsNullOrEmpty(sphere) AndAlso sphere <> "0" Then
            If Not sphere.StartsWith("+") AndAlso Not sphere.StartsWith("-") Then
                If Convert.ToDecimal(sphere) > 0 Then
                    grade = "+" & sphere
                Else
                    grade = sphere
                End If
            Else
                grade = sphere
            End If
        End If
        
        ' Add cylinder
        If Not String.IsNullOrEmpty(cylinder) AndAlso cylinder <> "0" Then
            If Not String.IsNullOrEmpty(grade) Then grade &= " "
            If Not cylinder.StartsWith("+") AndAlso Not cylinder.StartsWith("-") Then
                If Convert.ToDecimal(cylinder) > 0 Then
                    grade &= "+" & cylinder
                Else
                    grade &= cylinder
                End If
            Else
                grade &= cylinder
            End If
            
            ' Add axis if cylinder exists
            If Not String.IsNullOrEmpty(axis) AndAlso axis <> "0" Then
                grade &= " x " & axis
            End If
        End If
        
        ' Add addition
        If Not String.IsNullOrEmpty(add) AndAlso add <> "0" Then
            If Not String.IsNullOrEmpty(grade) Then grade &= " "
            grade &= "Add "
            If Not add.StartsWith("+") AndAlso Not add.StartsWith("-") Then
                If Convert.ToDecimal(add) > 0 Then
                    grade &= "+" & add
                Else
                    grade &= add
                End If
            Else
                grade &= add
            End If
        End If
        
        Return grade.Trim()
    End Function

    Private Sub DisplayCheckupInfo()
        Try
            ' You can add code here to display checkup information in labels or other controls
            ' For example, if you have labels for showing checkup details:
            
            ' Example: If you have a label to show checkup date
            ' lblCheckupDate.Text = "Checkup Date: " & CheckupDate.ToString("yyyy-MM-dd")
            
            ' Example: If you have a label to show doctor
            ' lblDoctor.Text = "Doctor: " & CheckupDoctorID
            
            ' Example: If you have a label to show remarks
            ' lblRemarks.Text = "Remarks: " & CheckupRemarks
            
            ' Removed checkup payment text from title
            
        Catch ex As Exception
            Debug.WriteLine("Error displaying checkup info: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadProductSuggestions()
        Try
            Call dbConn()

            ' Only load products with stock quantity greater than 0
            Dim sql As String = "SELECT productName FROM tbl_products WHERE stockQuantity > 0 ORDER BY productName"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            cmbProducts.Items.Clear()

            While reader.Read()
                cmbProducts.Items.Add(reader("productName").ToString())
            End While

            reader.Close()
            conn.Close()

        Catch ex As Exception
            MsgBox("Error loading product suggestions: " & ex.Message, "Error")
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) _
    Handles btnAdd.Click

        If cmbProducts.SelectedItem Is Nothing Then
            MsgBox("Select a Product First.", MsgBoxStyle.OkOnly, "Caution")
            Exit Sub
        End If
        If numQuantity.Value <= 0 Then
            MsgBox("Set Quantity greater than 0.", MsgBoxStyle.OkOnly, "Caution")
            Exit Sub
        End If

        Dim productName = cmbProducts.SelectedItem.ToString()
        Dim qty = CInt(numQuantity.Value)

        Try
            Call dbConn()

            ' Get product details including discount information and stock
            Dim sql As String = "SELECT productID, unitPrice, category, discount, discountAppliedDate, stockQuantity FROM tbl_products WHERE productName = ?"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", productName)

            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                Dim productID = reader("productID").ToString()
                Dim originalPrice = Convert.ToDecimal(reader("unitPrice"))
                Dim category = reader("category").ToString()
                Dim stockQuantity As Integer = Convert.ToInt32(reader("stockQuantity"))
                Dim discountDecimal As Decimal = 0D
                Dim discountAppliedDate As DateTime? = Nothing

                ' Check if product has unit price set
                If originalPrice <= 0 Then
                    reader.Close()
                    conn.Close()
                    MsgBox("This product does not have a unit price set. Please update the product price in inventory before adding to transaction.", vbExclamation, "No Price Set")
                    Exit Sub
                End If

                ' Check if product has sufficient stock
                If stockQuantity <= 0 Then
                    reader.Close()
                    conn.Close()
                    MsgBox("This product is out of stock.", vbExclamation, "Out of Stock")
                    ' Reload products to remove out of stock items
                    LoadProductSuggestions()
                    Exit Sub
                End If

                If qty > stockQuantity Then
                    reader.Close()
                    conn.Close()
                    MsgBox("Insufficient stock. Available: " & stockQuantity.ToString(), vbExclamation, "Insufficient Stock")
                    Exit Sub
                End If

                ' Get discount if available
                If Not IsDBNull(reader("discount")) Then
                    discountDecimal = Convert.ToDecimal(reader("discount"))
                End If

                ' Get discount applied date if available
                If Not IsDBNull(reader("discountAppliedDate")) Then
                    discountAppliedDate = Convert.ToDateTime(reader("discountAppliedDate"))
                End If

                ' Calculate the effective price to use
                Dim effectivePrice As Decimal = originalPrice

                ' For new transactions, apply inventory discount based on current date vs discount applied date
                ' This ensures that only discounts that are currently active get applied to new transactions
                If discountDecimal > 0 AndAlso discountAppliedDate.HasValue Then
                    ' Check if the discount is active on the current transaction date (use current date for new transactions)
                    If DateTime.Now.Date >= discountAppliedDate.Value.Date Then
                        ' Discount is active, apply it
                        effectivePrice = originalPrice * (1D - discountDecimal)
                    End If
                    ' If discount is not yet active, use original price
                    ' This maintains pricing accuracy based on when discounts become effective
                End If

                Dim rowTotal = effectivePrice * qty

                dgvSelectedProducts.Rows.Add(productID, productName, category, qty, effectivePrice.ToString("0.00"), rowTotal.ToString("0.00"))

            Else
                MsgBox("Product not found.", vbExclamation, "Error")
            End If

            reader.Close()
            conn.Close()

            ' Reset the input controls
            numQuantity.Value = 0
            cmbProducts.SelectedIndex = -1

            ' Update the total label
            UpdateTotalLabel()
            ' Re-evaluate control states (e.g., discount availability)
            UpdateControls()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, "Error")
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub



    Private Function GetProductPrice(productName As String) As Decimal
        Try
            Call dbConn()
            Dim sql As String = "SELECT unitPrice FROM tbl_products WHERE productName = ?"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("@productName", productName)
            Dim price As Decimal = Convert.ToDecimal(cmd.ExecuteScalar())
            conn.Close()
            Return price
        Catch ex As Exception
            MsgBox("Error fetching price: " & ex.Message, "Error")
            Return 0
        End Try
    End Function
    Private Sub UpdateTotalLabel()
        Dim total As Decimal = 0D

        ' Parse discount selection once
        Dim discFactor As Decimal = 0D
        Dim txt = cmbDiscount.Text.Trim()

        ' Check if the discount text ends with "%" to indicate percentage
        If txt.EndsWith("%") Then
            If Decimal.TryParse(txt.TrimEnd("%"c), discFactor) Then
                discFactor = discFactor / 100D ' Convert percentage to decimal
            Else
                discFactor = 0D ' If parsing fails, set discount factor to 0
            End If
        Else
            Decimal.TryParse(txt, discFactor)
        End If

        ' Parse lens discount selection
        Dim lensDiscFactor As Decimal = 0D
        Dim lensTxt = cmbLensDisc.Text.Trim()

        ' Check if the lens discount text ends with "%" to indicate percentage
        If lensTxt.EndsWith("%") Then
            If Decimal.TryParse(lensTxt.TrimEnd("%"c), lensDiscFactor) Then
                lensDiscFactor = lensDiscFactor / 100D ' Convert percentage to decimal
            Else
                lensDiscFactor = 0D ' If parsing fails, set discount factor to 0
            End If
        Else
            Decimal.TryParse(lensTxt, lensDiscFactor)
        End If

        ' Sum up each row, applying discounts to respective categories
        For Each row As DataGridViewRow In dgvSelectedProducts.Rows
            If row.IsNewRow Then Continue For

            Dim rowQty = Convert.ToDecimal(row.Cells("Quantity").Value)
            Dim rowPrice = Convert.ToDecimal(row.Cells("unitPrice").Value)
            Dim rowCat = row.Cells("Category").Value.ToString()

            ' Calculate subtotal for the row (without discount)
            Dim subTotal = rowQty * rowPrice

            ' Apply discount if the product is a Frame
            If rowCat.Equals("Frame", StringComparison.OrdinalIgnoreCase) Then
                subTotal = subTotal * (1D - discFactor)
            ElseIf rowCat.Equals("Lens", StringComparison.OrdinalIgnoreCase) Then
                ' Apply lens discount if the product is a Lens
                subTotal = subTotal * (1D - lensDiscFactor)
            End If

            ' Add the subtotal to the total amount
            total += subTotal
        Next

        ' Add OD and OS costs if they are valid
        Dim odCost As Decimal = 0D
        Dim osCost As Decimal = 0D

        Decimal.TryParse(txtODCost.Text, odCost)
        Decimal.TryParse(txtOSCost.Text, osCost)

        total += odCost + osCost

        ' Display the total amount in the total label
        txtTotal.Text = total.ToString("F2")
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgvSelectedProducts.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In dgvSelectedProducts.SelectedRows
                dgvSelectedProducts.Rows.Remove(row)
            Next
            UpdateTotalLabel()
            UpdateControls()
            numQuantity.Value = 0
        Else
            MsgBox("Please select a product to remove.", MsgBoxStyle.Exclamation, "Caution")
        End If
    End Sub

    Private Sub txtAmountPaid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountPaid.KeyPress
        Dim isControl As Boolean = Char.IsControl(e.KeyChar)
        Dim isDigit As Boolean = Char.IsDigit(e.KeyChar)
        Dim isDot As Boolean = (e.KeyChar = "."c)

        If isControl OrElse isDigit Then
            Return
        End If

        If isDot Then
            ' Allow only a single decimal point
            If txtAmountPaid.Text.Contains(".") Then
                e.Handled = True
            End If
            Return
        End If

        ' Block any other characters (letters, signs, etc.)
        e.Handled = True
    End Sub

    Private Sub rbwith_CheckedChanged(sender As Object, e As EventArgs) Handles rbwith.CheckedChanged
        UpdateTotalLabel()
        UpdateControls()
    End Sub

    Private Sub rbonly_CheckedChanged(sender As Object, e As EventArgs) Handles rbonly.CheckedChanged
        If rbonly.Checked Then
            ' Only clear data if this is NOT a checkup payment (preserve checkup data)
            If Not IsCheckupPayment Then
                ' Clear OD/OS prices
                txtODCost.Text = "0.00"
                txtOSCost.Text = "0.00"

                ' Clear OD/OS grades
                cmbOD.SelectedIndex = -1
                cmbOS.SelectedIndex = -1
                cmbOD.Text = String.Empty
                cmbOS.Text = String.Empty
            End If

            ' Clear discount selections
            cmbDiscount.SelectedIndex = -1
            cmbDiscount.Text = String.Empty
            cmbLensDisc.SelectedIndex = -1
            cmbLensDisc.Text = String.Empty
            ' Remember that base check-up fee has been applied
            hasCheckupBaseApplied = True
        End If
        UpdateTotalLabel()
        UpdateControls()
    End Sub
    Private Sub UpdateControls()
        If rbonly.Checked Then
            cmbProducts.Enabled = False
            numQuantity.Enabled = False
            cmbDiscount.Enabled = False
            cmbLensDisc.Enabled = False

            dgvSelectedProducts.Rows.Clear()
            btnAdd.Enabled = False
            btnRemove.Enabled = False
            dgvSelectedProducts.Enabled = False

            ' For checkup payments, keep OD/OS controls enabled so user can see/modify checkup data
            If IsCheckupPayment Then
                cmbOD.Enabled = True
                cmbOS.Enabled = True
                txtODCost.Enabled = True
                txtOSCost.Enabled = True
            Else
                cmbOD.Enabled = False
                cmbOS.Enabled = False
                txtODCost.Enabled = False
                txtOSCost.Enabled = False
            End If

            ' Enable payment-related inputs when a radio option is selected
            cmbMode.Enabled = True
            txtAmountPaid.Enabled = True
            txtTotal.Enabled = True ' stays ReadOnly; just visible/active
        ElseIf rbwith.Checked Then
            cmbProducts.Enabled = True
            numQuantity.Enabled = True

            ' Enable discount only if there is at least one Frame item
            Dim hasFrame As Boolean = HasFrameItem()
            cmbDiscount.Enabled = hasFrame
            If Not hasFrame Then
                cmbDiscount.SelectedIndex = -1
                cmbDiscount.Text = String.Empty
            End If

            ' Enable lens discount only if there is at least one Lens item
            Dim hasLens As Boolean = HasLensItem()
            cmbLensDisc.Enabled = hasLens
            If Not hasLens Then
                cmbLensDisc.SelectedIndex = -1
                cmbLensDisc.Text = String.Empty
            End If

            ' Enable OD/OS controls only if there is at least one Lens item
            cmbOD.Enabled = hasLens
            cmbOS.Enabled = hasLens
            txtODCost.Enabled = hasLens
            txtOSCost.Enabled = hasLens

            btnAdd.Enabled = True
            btnRemove.Enabled = True
            dgvSelectedProducts.Enabled = True

            ' Enable payment-related inputs when a radio option is selected
            cmbMode.Enabled = True
            txtAmountPaid.Enabled = True
            txtTotal.Enabled = True ' stays ReadOnly; just visible/active
        Else
            ' No radio selection: disable everything by default
            cmbProducts.Enabled = False
            numQuantity.Enabled = False
            cmbOD.Enabled = False
            cmbOS.Enabled = False
            cmbDiscount.Enabled = False
            cmbLensDisc.Enabled = False
            btnAdd.Enabled = False
            btnRemove.Enabled = False
            txtODCost.Enabled = False
            txtOSCost.Enabled = False
            dgvSelectedProducts.Enabled = False

            ' Also disable payment-related inputs when no radio is selected
            cmbMode.Enabled = False
            txtAmountPaid.Enabled = False
            txtTotal.Enabled = False
        End If
    End Sub

    Private Function HasFrameItem() As Boolean
        For Each row As DataGridViewRow In dgvSelectedProducts.Rows
            If row.IsNewRow Then Continue For
            Dim categoryCell = row.Cells("Category").Value
            If categoryCell IsNot Nothing AndAlso categoryCell.ToString().Equals("Frame", StringComparison.OrdinalIgnoreCase) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function HasLensItem() As Boolean
        For Each row As DataGridViewRow In dgvSelectedProducts.Rows
            If row.IsNewRow Then Continue For
            Dim categoryCell = row.Cells("Category").Value
            If categoryCell IsNot Nothing Then
                Dim category As String = categoryCell.ToString()
                If category.Equals("Lens", StringComparison.OrdinalIgnoreCase) OrElse category.Equals("Lenses", StringComparison.OrdinalIgnoreCase) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub cmbDiscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscount.SelectedIndexChanged
        RecalculateGridTotals()
        UpdateTotalLabel()
    End Sub

    Private Sub cmbLensDisc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLensDisc.SelectedIndexChanged
        RecalculateGridTotals()
        UpdateTotalLabel()
    End Sub
    Private Sub RecalculateGridTotals()
        ' parse current discount factor
        Dim discFactor As Decimal = 0D
        Dim txt = cmbDiscount.Text.Trim()
        If txt.EndsWith("%") Then
            Decimal.TryParse(txt.TrimEnd("%"c), discFactor)
            discFactor /= 100D
        Else
            Decimal.TryParse(txt, discFactor)
        End If

        ' parse lens discount factor
        Dim lensDiscFactor As Decimal = 0D
        Dim lensTxt = cmbLensDisc.Text.Trim()
        If lensTxt.EndsWith("%") Then
            Decimal.TryParse(lensTxt.TrimEnd("%"c), lensDiscFactor)
            lensDiscFactor /= 100D
        Else
            Decimal.TryParse(lensTxt, lensDiscFactor)
        End If

        For Each row As DataGridViewRow In dgvSelectedProducts.Rows
            If row.IsNewRow Then Continue For

            Dim qty = Convert.ToDecimal(row.Cells("Quantity").Value)
            Dim price = Convert.ToDecimal(row.Cells("unitPrice").Value)
            Dim cat = row.Cells("Category").Value.ToString()

            Dim subTotal = qty * price
            If cat.Equals("Frame", StringComparison.OrdinalIgnoreCase) Then
                subTotal = subTotal * (1D - discFactor)
            ElseIf cat.Equals("Lens", StringComparison.OrdinalIgnoreCase) Then
                subTotal = subTotal * (1D - lensDiscFactor)
            End If

            row.Cells("Total").Value = subTotal.ToString("0.00")
        Next
    End Sub

    Private Sub txtODCost_TextChanged(sender As Object, e As EventArgs) Handles txtODCost.TextChanged
        UpdateTotalLabel()
    End Sub

    Private Sub txtOSCost_TextChanged(sender As Object, e As EventArgs) Handles txtOSCost.TextChanged
        UpdateTotalLabel()
    End Sub

    Private Sub txtAmountPaid_TextChanged(sender As Object, e As EventArgs) Handles txtAmountPaid.TextChanged
        Dim totalAmount As Decimal
        Dim amountPaid As Decimal

        Decimal.TryParse(txtTotal.Text, totalAmount)
        Decimal.TryParse(txtAmountPaid.Text, amountPaid)

        If amountPaid > totalAmount Then
            MsgBox("Amount Paid cannot be greater than the Total Amount.", vbExclamation, "Caution")
            txtAmountPaid.Text = totalAmount.ToString("F2")
            txtAmountPaid.Focus()
        End If
    End Sub

  Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim transactionID As Integer
        Dim totalAmount As Double
        Dim amountPaid As Double
        Dim pendingBalance As Double
        Dim discount As Double
        Dim isCheckUp As Integer = If(rbonly.Checked, 1, 0)
        Dim paymentStatus As String

        ' Required selections
        If String.IsNullOrWhiteSpace(cmbMode.Text) Then
            MsgBox("Please select a Mode of Payment.", vbExclamation, "Caution")
            Exit Sub
        End If
        If Not (rbwith.Checked OrElse rbonly.Checked) Then
            MsgBox("Please select either 'With check up' or 'Check up only'.", vbExclamation, "Caution")
            Exit Sub
        End If

        ' Additional validation for "With check up": must have items OR OD/OS prices and grades
        If rbwith.Checked Then
            Dim hasItems As Boolean = False
            For Each row As DataGridViewRow In dgvSelectedProducts.Rows
                If Not row.IsNewRow Then
                    hasItems = True
                    Exit For
                End If
            Next
            Dim odCostVal As Decimal = 0D
            Dim osCostVal As Decimal = 0D
            Decimal.TryParse(txtODCost.Text, odCostVal)
            Decimal.TryParse(txtOSCost.Text, osCostVal)
            Dim hasGrades As Boolean = Not String.IsNullOrWhiteSpace(cmbOD.Text) AndAlso Not String.IsNullOrWhiteSpace(cmbOS.Text)
            If Not (hasItems OrElse ((odCostVal > 0D) AndAlso (osCostVal > 0D) AndAlso hasGrades)) Then
                MsgBox("For 'With check up', add at least one item or provide OD/OS prices and grades.", vbExclamation, "Validation")
                Exit Sub
            End If
        End If

        ' Validate totals
        If Not Double.TryParse(txtTotal.Text, totalAmount) OrElse totalAmount <= 0 Then
            MsgBox("Total must be greater than 0.", vbCritical, "Error")
            Exit Sub
        End If
        
        ' Validate Amount Paid is not empty or "0.00"
        If String.IsNullOrWhiteSpace(txtAmountPaid.Text) Then
            MsgBox("Amount Paid cannot be empty. Please enter the payment amount.", vbExclamation, "Amount Paid Required")
            txtAmountPaid.Focus()
            Exit Sub
        End If
        
        If Not Double.TryParse(txtAmountPaid.Text, amountPaid) Then
            MsgBox("Amount Paid invalid. Please enter a valid number.", vbCritical, "Error")
            txtAmountPaid.Focus()
            Exit Sub
        End If
        
        If amountPaid <= 0 Then
            MsgBox("Amount Paid must be greater than 0.00. Please enter a valid payment amount.", vbExclamation, "Amount Paid Required")
            txtAmountPaid.Focus()
            Exit Sub
        End If

        ' Cap amountPaid at total to avoid negative balances
        If amountPaid > totalAmount Then
            amountPaid = totalAmount
        End If

        ' Compute balance & status
        pendingBalance = totalAmount - amountPaid
        If pendingBalance < 0 Then
            pendingBalance = 0
        End If
        If amountPaid >= totalAmount Then
            paymentStatus = "Paid"
        Else
            paymentStatus = "Pending"
        End If

        ' Discount
        Dim discText As String = cmbDiscount.Text.Replace("%", "").Trim()
        Double.TryParse(discText, discount)
        If cmbDiscount.Text.Contains("%") Then discount = discount / 100

        ' Lens Discount
        Dim lensDiscount As Double = 0
        Dim lensDiscText As String = cmbLensDisc.Text.Replace("%", "").Trim()
        If Not String.IsNullOrEmpty(lensDiscText) AndAlso lensDiscText <> "N/A" Then
            Double.TryParse(lensDiscText, lensDiscount)
            If cmbLensDisc.Text.Contains("%") Then lensDiscount = lensDiscount / 100
        End If

        If MsgBox("Save this transaction?", vbYesNo + vbQuestion, "Confirm") = vbNo Then
            Exit Sub
        End If

        Try
            Call dbConn()

            ' 1) Insert master record (auto-set settlementDate when fully paid)
            Dim insertTrans As String = _
                "INSERT INTO tbl_transactions " & _
                "(patientID, patientName, totalAmount, amountPaid, pendingBalance, settlementDate, paymentType, transactionDate, paymentStatus, isCheckUp, discount, lensDiscount) " & _
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            Using cmd As New Odbc.OdbcCommand(insertTrans, conn)
                cmd.Parameters.AddWithValue("?", lblPatientID.Text)
                cmd.Parameters.AddWithValue("?", lblPatientName.Text)
                cmd.Parameters.AddWithValue("?", totalAmount)
                cmd.Parameters.AddWithValue("?", amountPaid)
                cmd.Parameters.AddWithValue("?", pendingBalance)
                Dim pSettle As Odbc.OdbcParameter = cmd.Parameters.Add("?", Odbc.OdbcType.Date)
                If paymentStatus = "Paid" Then
                    pSettle.Value = dtpDate.Value.Date
                Else
                    pSettle.Value = DBNull.Value
                End If
                cmd.Parameters.AddWithValue("?", cmbMode.Text)
                cmd.Parameters.AddWithValue("?", dtpDate.Value.Date)
                cmd.Parameters.AddWithValue("?", paymentStatus)
                cmd.Parameters.AddWithValue("?", isCheckUp)
                cmd.Parameters.AddWithValue("?", discount)
                cmd.Parameters.AddWithValue("?", lensDiscount)
                cmd.ExecuteNonQuery()
            End Using

            Using cmd As New Odbc.OdbcCommand("SELECT LAST_INSERT_ID()", conn)
                transactionID = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
            SaveTransactionItems(transactionID)


            ' Save checkup data if this is a checkup payment
            If IsCheckupPayment Then
                SaveCheckupData()
            End If

            InsertAuditTrail("Insert", "Added new transaction for " & lblPatientName.Text & " with total of " & txtTotal.Text & " and paid ₱" & txtAmountPaid.Text, "tbl_transactions" & "tbl_transaction_items", lblPatientID.Text)

            If RefreshViewTransactions IsNot Nothing Then
                RefreshViewTransactions.LoadViewTransaction(SelectedPatientID)
            End If

            ' Refresh dashboard patient count
            Try
                Dim dashboardForm As dashboard = Nothing
                For Each frm As Form In Application.OpenForms
                    If TypeOf frm Is dashboard Then
                        dashboardForm = DirectCast(frm, dashboard)
                        Exit For
                    End If
                Next
                If dashboardForm IsNot Nothing Then
                    dashboardForm.Invoke(Sub() dashboardForm.UpdatePatientCount())
                End If
            Catch ex As Exception
                ' Silently fail if dashboard is not open
                Debug.WriteLine("Could not refresh dashboard: " & ex.Message)
            End Try

            ' Show success message for all transactions
            If paymentStatus = "Paid" Then
                If IsCheckupPayment Then
                    MsgBox("Checkup completed! Payment fully settled.", vbInformation, "Payment Complete")
                Else
                    MsgBox("Transaction saved successfully! Payment fully settled.", vbInformation, "Success")
                End If
            Else
                ' For pending payments
                If IsCheckupPayment Then
                    MsgBox("Checkup saved successfully! Pending balance: ₱" & pendingBalance.ToString("F2"), vbInformation, "Success")
                Else
                    MsgBox("Transaction saved successfully! Pending balance: ₱" & pendingBalance.ToString("F2"), vbInformation, "Success")
                End If
            End If

            conn.Close()
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Save Failed")
        End Try
    End Sub


    Private Sub SaveTransactionItems(transactionID As Integer)
        Try
            ' Make sure connection is open
            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            For Each row As DataGridViewRow In dgvSelectedProducts.Rows
                If row.IsNewRow Then Continue For

                ' Validate required cells
                If row.Cells("productID").Value Is Nothing OrElse
                   row.Cells("quantity").Value Is Nothing OrElse
                   row.Cells("unitPrice").Value Is Nothing Then
                    Continue For
                End If

                Dim productID As Integer = 0
                Dim quantity As Integer = 0
                Dim unitPrice As Double = 0

                Integer.TryParse(row.Cells("productID").Value.ToString(), productID)
                Integer.TryParse(row.Cells("quantity").Value.ToString(), quantity)
                Double.TryParse(row.Cells("unitPrice").Value.ToString(), unitPrice)

                ' Step 1: Check available stock
                Dim availableStock As Integer = 0
                Dim checkStockSql As String = "SELECT stockQuantity FROM tbl_products WHERE productID = ?"
                Using checkCmd As New Odbc.OdbcCommand(checkStockSql, conn)
                    checkCmd.Parameters.AddWithValue("?", productID)
                    Dim result = checkCmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso IsNumeric(result) Then
                        availableStock = CInt(result)
                    Else
                        MsgBox("Failed to get stock for product ID " & productID, vbCritical, "Stock Check Error")
                        Continue For
                    End If
                End Using

                If availableStock < quantity Then
                    MsgBox("Insufficient stock for product ID " & productID & ". Available: " & availableStock, vbCritical, "Stock Error")
                    Exit Sub
                End If

                ' Step 2: Insert transaction item
                Dim productName As String = row.Cells("productName").Value.ToString()
                Dim category As String = row.Cells("category").Value.ToString()
                Dim odGrade As String = cmbOD.Text
                Dim osGrade As String = cmbOS.Text
                Dim priceOD As Double = 0
                Dim priceOS As Double = 0
                Double.TryParse(txtODCost.Text, priceOD)
                Double.TryParse(txtOSCost.Text, priceOS)
                Dim totalPrice As Double = quantity * unitPrice
                Dim isCheckUpItem As Integer = If(rbwith.Checked, 1, 0)
                Dim createdAt As DateTime = DateTime.Now

                Dim insertItemSql As String =
                    "INSERT INTO tbl_transaction_items " &
                    "(transactionID, productID, productName, category, quantity, unitPrice, priceOD, priceOS, odGrade, osGrade, totalPrice, isCheckUpItem, createdAt) " &
                    "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"

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

                ' Step 3: Update stock quantity
                Dim updateStockSql As String = "UPDATE tbl_products SET stockQuantity = stockQuantity - ? WHERE productID = ?"
                Using stockCmd As New Odbc.OdbcCommand(updateStockSql, conn)
                    stockCmd.Parameters.AddWithValue("?", quantity)
                    stockCmd.Parameters.AddWithValue("?", productID)
                    Dim rowsAffected As Integer = stockCmd.ExecuteNonQuery()
                    Debug.WriteLine("Stock updated for productID " & productID & ", rows affected: " & rowsAffected)

                    If rowsAffected = 0 Then
                        MsgBox("Stock update failed for productID " & productID, MsgBoxStyle.Exclamation, "Update Error")
                    End If
                End Using
            Next

        Catch ex As Exception
            MsgBox("Error saving transaction items: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub



    Private Sub SaveCheckupData()
        Try
            ' Make sure connection is open
            If conn.State <> ConnectionState.Open Then
                Call dbConn()
            End If

            ' === Insert into tbl_checkup ===
            Dim sql As String = "INSERT INTO tbl_checkup (patientID, remarks, doctorID, sphereOD, sphereOS, cylinderOD, cylinderOS, axisOD, axisOS, addOD, addOS, checkupDate) " &
                                "VALUES (?,?,?,?,?,?,?,?,?,?,?,?)"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", SelectedPatientID)
                cmd.Parameters.AddWithValue("?", CheckupRemarks)
                cmd.Parameters.AddWithValue("?", CheckupDoctorID)
                cmd.Parameters.AddWithValue("?", CheckupSphereOD)
                cmd.Parameters.AddWithValue("?", CheckupSphereOS)
                cmd.Parameters.AddWithValue("?", CheckupCylinderOD)
                cmd.Parameters.AddWithValue("?", CheckupCylinderOS)
                cmd.Parameters.AddWithValue("?", CheckupAxisOD)
                cmd.Parameters.AddWithValue("?", CheckupAxisOS)
                cmd.Parameters.AddWithValue("?", CheckupAddOD)
                cmd.Parameters.AddWithValue("?", CheckupAddOS)
                cmd.Parameters.AddWithValue("?", CheckupDate.ToString("yyyy-MM-dd HH:mm:ss"))
                cmd.ExecuteNonQuery()
            End Using

            ' === Get last inserted checkup ID ===
            Dim lastCheckupID As Integer = 0
            Using getIDCmd As New Odbc.OdbcCommand("SELECT LAST_INSERT_ID()", conn)
                Dim dbResult As Object = getIDCmd.ExecuteScalar()
                If dbResult IsNot Nothing Then lastCheckupID = Convert.ToInt32(dbResult)
            End Using

            ' === Audit Trail for checkup ===
            InsertAuditTrail("Insert", "Added checkup record for " & SelectedPatientName, "tbl_checkup", lastCheckupID)

        Catch ex As Exception
            MsgBox("Error saving checkup data: " & ex.Message, vbCritical, "Checkup Save Error")
        End Try
    End Sub

    Private Sub InsertAuditTrail(actionType As String, actionDetails As String, tableName As String, recordID As Integer)
        Try
            Dim auditSql As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, TableName, RecordID, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
            Dim auditCmd As New Odbc.OdbcCommand(auditSql, conn)

            auditCmd.Parameters.AddWithValue("?", LoggedInUserID)
            auditCmd.Parameters.AddWithValue("?", LoggedInUser)
            auditCmd.Parameters.AddWithValue("?", actionType)
            auditCmd.Parameters.AddWithValue("?", actionDetails)
            auditCmd.Parameters.AddWithValue("?", tableName)
            auditCmd.Parameters.AddWithValue("?", recordID)
            auditCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
            auditCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd"))

            auditCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Audit Trail Error: " & ex.Message, vbCritical, "Audit Error")
        End Try
    End Sub
End Class
