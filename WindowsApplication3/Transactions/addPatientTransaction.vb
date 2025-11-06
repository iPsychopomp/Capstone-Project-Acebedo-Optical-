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

    Private Sub addPatientTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isInitializing = True
        If dgvSelectedProducts.Columns.Count = 0 Then
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
        End If

        LoadProductSuggestions()

        dtpDate.Value = DateTime.Now
        cmbDiscount.SelectedItem = "N/A"
        cmbLensDisc.SelectedItem = "N/A"
        numQuantity.Value = 1
        txtTotal.Text = "0.00"
        txtAmountPaid.Text = "0.00"
        txtODCost.Text = "0.00"
        txtOSCost.Text = "0.00"

        ' Defaults for NEW transaction: check-up only, and no payment mode preselected
        If Not IsEditMode Then
            rbonly.Checked = True
            rbwith.Checked = False
            cmbMode.SelectedIndex = -1
            cmbMode.Text = String.Empty
        End If

        If IsEditMode AndAlso TransactionID > 0 Then
            LoadTransactionData(TransactionID)
        End If

        UpdateControls()
        UpdateTotalLabel()

        ' Reapply lens discount after UpdateControls (in case it was cleared or reset)
        If Not String.IsNullOrEmpty(loadedLensDiscount) Then
            ' Find and select the loaded lens discount value
            Dim foundIndex As Integer = -1
            For i As Integer = 0 To cmbLensDisc.Items.Count - 1
                If cmbLensDisc.Items(i).ToString() = loadedLensDiscount Then
                    foundIndex = i
                    Exit For
                End If
            Next

            If foundIndex >= 0 Then
                cmbLensDisc.SelectedIndex = foundIndex
                Debug.WriteLine("Reapplied lens discount: " & loadedLensDiscount)
            Else
                ' If not found, add it again
                cmbLensDisc.Items.Add(loadedLensDiscount)
                cmbLensDisc.SelectedItem = loadedLensDiscount
                Debug.WriteLine("Re-added and selected lens discount: " & loadedLensDiscount)
            End If
        End If

        ' Initialize last mode after UI reflects loaded state
        lastModeIsCheckUpOnly = rbonly.Checked
        isInitializing = False
    End Sub
    Private Sub LoadTransactionData(transactionID As Integer)
        Try
            Call dbConn()
            Dim columnQuery As String = "SELECT * FROM tbl_transactions WHERE 1=0"
            Dim columnCmd As New Odbc.OdbcCommand(columnQuery, conn)
            Dim columnReader As Odbc.OdbcDataReader = columnCmd.ExecuteReader()
            Dim columnSchema As DataTable = columnReader.GetSchemaTable()
            columnReader.Close()

            ' Build query with only existing columns
            Dim query As String = "SELECT "
            Dim columns As New List(Of String)

            For Each row As DataRow In columnSchema.Rows
                Dim colName As String = row("ColumnName").ToString()
                columns.Add(colName)
                Debug.WriteLine("Available column: " & colName)
            Next

            ' Check if lensDiscount column exists
            Debug.WriteLine("lensDiscount column exists: " & columns.Contains("lensDiscount").ToString())

            query &= String.Join(", ", columns) & " FROM tbl_transactions WHERE transactionID = ?"

            Dim cmd As New Odbc.OdbcCommand(query, conn)
            cmd.Parameters.AddWithValue("?", transactionID)

            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                ' Load basic transaction details
                lblPatientID.Text = If(reader("patientID") Is DBNull.Value, "", reader("patientID").ToString())
                txtPatientName.Text = If(reader("patientName") Is DBNull.Value, "", reader("patientName").ToString())
                txtTotal.Text = If(reader("totalAmount") Is DBNull.Value, "0.00", Convert.ToDecimal(reader("totalAmount")).ToString("N2"))
                txtAmountPaid.Text = If(reader("amountPaid") Is DBNull.Value, "0.00", Convert.ToDecimal(reader("amountPaid")).ToString("N2"))
                ' Select payment mode by matching against items (case-insensitive and trim whitespace)
                Dim pt As String = If(reader("paymentType") Is DBNull.Value, String.Empty, reader("paymentType").ToString().Trim())
                Debug.WriteLine("Loading payment type: '" & pt & "'")

                If String.IsNullOrWhiteSpace(pt) Then
                    cmbMode.SelectedIndex = -1
                    Debug.WriteLine("Payment type is empty, setting SelectedIndex to -1")
                Else
                    Dim foundIndex As Integer = -1
                    For i As Integer = 0 To cmbMode.Items.Count - 1
                        Dim itemText As String = cmbMode.Items(i).ToString().Trim()
                        Debug.WriteLine("Comparing '" & pt & "' with '" & itemText & "'")
                        If String.Equals(itemText, pt, StringComparison.OrdinalIgnoreCase) Then
                            foundIndex = i
                            Exit For
                        End If
                    Next

                    If foundIndex >= 0 Then
                        cmbMode.SelectedIndex = foundIndex
                        Debug.WriteLine("Found payment type at index: " & foundIndex.ToString())
                    Else
                        ' Try partial match (e.g., "Gcash" matches "G-cash")
                        For i As Integer = 0 To cmbMode.Items.Count - 1
                            Dim itemText As String = cmbMode.Items(i).ToString().Trim().Replace("-", "").Replace(" ", "")
                            Dim ptNormalized As String = pt.Replace("-", "").Replace(" ", "")
                            If String.Equals(itemText, ptNormalized, StringComparison.OrdinalIgnoreCase) Then
                                foundIndex = i
                                Exit For
                            End If
                        Next

                        If foundIndex >= 0 Then
                            cmbMode.SelectedIndex = foundIndex
                            Debug.WriteLine("Found payment type with partial match at index: " & foundIndex.ToString())
                        Else
                            ' Fallback: set to first item if available
                            If cmbMode.Items.Count > 0 Then
                                cmbMode.SelectedIndex = 0
                                Debug.WriteLine("Payment type not found, defaulting to first item")
                            Else
                                cmbMode.SelectedIndex = -1
                                Debug.WriteLine("Payment type not found and no items available")
                            End If
                        End If
                    End If
                End If
                dtpDate.Value = If(reader("transactionDate") Is DBNull.Value, DateTime.Now, Convert.ToDateTime(reader("transactionDate")))

                ' Handle discount
                If columns.Contains("discount") Then
                    Dim disc As Decimal = 0D
                    If Not (reader("discount") Is DBNull.Value) Then
                        Decimal.TryParse(reader("discount").ToString(), disc)
                    End If

                    Debug.WriteLine("Loading discount: " & disc.ToString())

                    If disc <= 0D Then
                        ' Set to N/A
                        For i As Integer = 0 To cmbDiscount.Items.Count - 1
                            If cmbDiscount.Items(i).ToString().Trim() = "N/A" Then
                                cmbDiscount.SelectedIndex = i
                                Debug.WriteLine("Set discount to N/A at index: " & i.ToString())
                                Exit For
                            End If
                        Next
                    Else
                        Dim percText As String = (disc * 100D).ToString("0") & "%"
                        Debug.WriteLine("Looking for discount: " & percText)

                        Dim foundDisc As Boolean = False
                        For i As Integer = 0 To cmbDiscount.Items.Count - 1
                            If cmbDiscount.Items(i).ToString().Trim() = percText Then
                                cmbDiscount.SelectedIndex = i
                                foundDisc = True
                                Debug.WriteLine("Found discount at index: " & i.ToString())
                                Exit For
                            End If
                        Next

                        If Not foundDisc Then
                            ' If exact match not found, default to N/A
                            For i As Integer = 0 To cmbDiscount.Items.Count - 1
                                If cmbDiscount.Items(i).ToString().Trim() = "N/A" Then
                                    cmbDiscount.SelectedIndex = i
                                    Debug.WriteLine("Discount not found, defaulting to N/A at index: " & i.ToString())
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                End If

                ' Handle lens discount - simplified approach
                Try
                    Dim lensDisc As Decimal = 0D

                    ' Try to read lensDiscount column
                    If columns.Contains("lensDiscount") Then
                        If Not IsDBNull(reader("lensDiscount")) Then
                            lensDisc = Convert.ToDecimal(reader("lensDiscount"))
                        End If
                    End If

                    Debug.WriteLine("=== LENS DISCOUNT DEBUG ===")
                    Debug.WriteLine("Raw value from DB: " & lensDisc.ToString())
                    Debug.WriteLine("Columns contains lensDiscount: " & columns.Contains("lensDiscount").ToString())

                    If lensDisc > 0D Then
                        ' Convert to percentage text (e.g., 0.10 -> "10%", 0.20 -> "20%")
                        Dim lensPercText As String = (lensDisc * 100D).ToString("0") & "%"
                        Debug.WriteLine("Converted to percentage: " & lensPercText)

                        ' Store the value to set after form initialization
                        loadedLensDiscount = lensPercText
                        Debug.WriteLine("Stored loadedLensDiscount: " & loadedLensDiscount)
                    Else
                        ' No discount or zero - set to N/A
                        loadedLensDiscount = "N/A"
                        Debug.WriteLine("No lens discount, setting to N/A")
                    End If
                    Debug.WriteLine("=== END LENS DISCOUNT DEBUG ===")
                Catch ex As Exception
                    Debug.WriteLine("ERROR loading lens discount: " & ex.Message)
                    loadedLensDiscount = "N/A"
                End Try

                ' Handle transaction type: determine if it's checkup only, with checkup, or items only
                If columns.Contains("isCheckUp") Then
                    Dim isCheckUp As Boolean = If(reader("isCheckUp") Is DBNull.Value, False, Convert.ToBoolean(reader("isCheckUp")))

                    ' Initially set based on isCheckUp flag
                    rbonly.Checked = isCheckUp
                    rbwith.Checked = Not isCheckUp
                    rbItems.Checked = False

                    ' Remember base fee if this was originally check-up only
                    If isCheckUp Then
                        hasCheckupBaseApplied = True
                    End If
                End If
            End If

            reader.Close()

            ' Load OD/OS grades and prices from tbl_transaction_items
            Dim itemQuery As String = "SELECT odGrade, osGrade, priceOD, priceOS FROM tbl_transaction_items WHERE transactionID = ?"
            Dim itemCmd As New Odbc.OdbcCommand(itemQuery, conn)
            itemCmd.Parameters.AddWithValue("?", transactionID)

            Dim itemReader As Odbc.OdbcDataReader = itemCmd.ExecuteReader()

            If itemReader.HasRows Then
                While itemReader.Read()

                    ' Load OD and OS grades
                    cmbOD.Text = If(itemReader("odGrade") Is DBNull.Value, "", itemReader("odGrade").ToString())
                    cmbOS.Text = If(itemReader("osGrade") Is DBNull.Value, "", itemReader("osGrade").ToString())

                    ' Load OD and OS prices
                    txtODCost.Text = If(itemReader("priceOD") Is DBNull.Value, "0.00", Convert.ToDecimal(itemReader("priceOD")).ToString("N2"))
                    txtOSCost.Text = If(itemReader("priceOS") Is DBNull.Value, "0.00", Convert.ToDecimal(itemReader("priceOS")).ToString("N2"))
                End While

            End If

            itemReader.Close()

            ' Load transaction items if needed
            LoadTransactionItems(transactionID)

            ' Infer proper mode for edited transactions based on loaded items, OD/OS costs, and isCheckUp flag
            Dim hasItems As Boolean = False
            For Each row As DataGridViewRow In dgvSelectedProducts.Rows
                If Not row.IsNewRow Then
                    hasItems = True
                    Exit For
                End If
            Next

            ' Check if there are OD/OS costs or grades
            Dim odCost As Decimal = 0D
            Dim osCost As Decimal = 0D
            Decimal.TryParse(txtODCost.Text, odCost)
            Decimal.TryParse(txtOSCost.Text, osCost)
            Dim hasODOSCosts As Boolean = (odCost > 0D OrElse osCost > 0D)
            Dim hasODOSGrades As Boolean = (Not String.IsNullOrWhiteSpace(cmbOD.Text) OrElse Not String.IsNullOrWhiteSpace(cmbOS.Text))

            ' Get the isCheckUp flag that was loaded from database
            Dim wasCheckUpTransaction As Boolean = rbonly.Checked OrElse rbwith.Checked

            ' Determine transaction type with improved logic:
            ' Priority 1: Check-up only - no items AND isCheckUp = True
            ' Priority 2: With check-up - has items AND isCheckUp = True
            ' Priority 3: Items only - has items AND isCheckUp = False

            Debug.WriteLine("=== DETERMINING TRANSACTION TYPE ===")
            Debug.WriteLine("hasItems: " & hasItems.ToString())
            Debug.WriteLine("hasODOSCosts: " & hasODOSCosts.ToString())
            Debug.WriteLine("hasODOSGrades: " & hasODOSGrades.ToString())
            Debug.WriteLine("wasCheckUpTransaction (from DB): " & wasCheckUpTransaction.ToString())

            If Not hasItems AndAlso wasCheckUpTransaction Then
                ' Check-up only mode: no items but isCheckUp flag is true
                rbonly.Checked = True
                rbwith.Checked = False
                rbItems.Checked = False
                Debug.WriteLine("Edit Mode: Detected Check-up Only")
            ElseIf hasItems AndAlso wasCheckUpTransaction Then
                ' With check-up mode: has items AND isCheckUp flag is true
                rbwith.Checked = True
                rbonly.Checked = False
                rbItems.Checked = False
                Debug.WriteLine("Edit Mode: Detected With Check-up")
            ElseIf hasItems AndAlso Not wasCheckUpTransaction Then
                ' Items only mode: has items AND isCheckUp flag is false
                rbItems.Checked = True
                rbwith.Checked = False
                rbonly.Checked = False
                Debug.WriteLine("Edit Mode: Detected Items Only")
            Else
                ' Fallback: default to check-up only if unclear
                rbonly.Checked = True
                rbwith.Checked = False
                rbItems.Checked = False
                Debug.WriteLine("Edit Mode: Fallback to Check-up Only")
            End If
            Debug.WriteLine("====================================")

            ' Allow radio buttons to be changed in edit mode
            rbonly.Enabled = True
            rbwith.Enabled = True
            rbItems.Enabled = True

            ' Ensure UI state and totals reflect the correct mode
            UpdateControls()
            UpdateTotalLabel()

            ' Check if patient has OTHER pending balance (excluding current transaction)
            CheckPendingBalanceForEdit(transactionID)

        Catch ex As Exception
            MessageBox.Show("Error loading transaction data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub CheckPendingBalanceForEdit(currentTransactionID As Integer)
        Try
            Call dbConn()

            ' Check for pending balance in OTHER transactions (not the current one being edited)
            Dim sql As String = "SELECT SUM(pendingBalance) AS totalPending FROM tbl_transactions WHERE patientID = ? AND paymentStatus = 'Pending' AND transactionID != ?"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", CInt(lblPatientID.Text))
            cmd.Parameters.AddWithValue("?", currentTransactionID)

            Dim result = cmd.ExecuteScalar()
            Dim pendingBalance As Decimal = 0D

            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                pendingBalance = Convert.ToDecimal(result)
            End If

            conn.Close()

            If pendingBalance > 0 Then
                MessageBox.Show("This patient has a pending balance of ₱" & pendingBalance.ToString("F2") & " from other transactions." & vbCrLf & vbCrLf & _
                               "Cannot add items to this transaction. Only check-up details can be modified.", _
                               "Pending Balance", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                ' Disable adding items - force check-up only mode
                rbwith.Enabled = False
                If Not rbonly.Checked Then
                    ' If currently "with check-up", force to check-up only
                    rbonly.Checked = True
                End If

                ' Disable product selection
                cmbProducts.Enabled = False
                btnAdd.Enabled = False
                btnRemove.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error checking pending balance: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadTransactionItems(transactionID As Integer)
        Try
            Call dbConn()

            ' First check if the table exists and has the expected columns
            Dim checkTableQuery As String = "SELECT 1 FROM information_schema.tables WHERE table_name = 'tbl_transaction_items'"
            Dim checkCmd As New Odbc.OdbcCommand(checkTableQuery, conn)
            Dim tableExists As Object = checkCmd.ExecuteScalar()

            If tableExists IsNot Nothing AndAlso Convert.ToInt32(tableExists) = 1 Then
                ' Table exists, proceed with loading items
                Dim query As String = "SELECT productID, productName, category, quantity, unitPrice, totalPrice " &
                                   "FROM tbl_transaction_items WHERE transactionID = ?"

                Dim cmd As New Odbc.OdbcCommand(query, conn)
                cmd.Parameters.AddWithValue("?", transactionID)

                Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

                dgvSelectedProducts.Rows.Clear()

                While reader.Read()
                    dgvSelectedProducts.Rows.Add(
                        reader("productID").ToString(),
                        reader("productName").ToString(),
                        reader("category").ToString(),
                        reader("quantity").ToString(),
                        Convert.ToDecimal(reader("unitPrice")).ToString("0.00"),
                        Convert.ToDecimal(reader("totalPrice")).ToString("0.00")
                    )
                End While

                reader.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading transaction items: " & ex.Message, "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
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
            MsgBox("Error loading product suggestions: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cmbProducts.SelectedItem Is Nothing Then
            MsgBox("Please select a product.")
            Exit Sub
        End If
        If numQuantity.Value <= 0 Then
            MsgBox("Please set Quantity greater than 0.")
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

                ' Apply inventory discount based on transaction date vs discount applied date
                ' The price should reflect what was available at the time of the transaction
                ' This ensures historical accuracy - past transactions keep their original pricing
                If discountDecimal > 0 AndAlso discountAppliedDate.HasValue Then
                    ' Check if the discount was active on the transaction date
                    If dtpDate.Value.Date >= discountAppliedDate.Value.Date Then
                        ' Discount was active on transaction date, apply it
                        effectivePrice = originalPrice * (1D - discountDecimal)
                    End If
                    ' If discount was not yet active on transaction date, use original price
                    ' This preserves historical pricing integrity
                End If

                ' Check if product already exists in the grid
                Dim existingRow As DataGridViewRow = Nothing
                For Each row As DataGridViewRow In dgvSelectedProducts.Rows
                    If Not row.IsNewRow AndAlso row.Cells("productID").Value IsNot Nothing Then
                        If row.Cells("productID").Value.ToString() = productID Then
                            existingRow = row
                            Exit For
                        End If
                    End If
                Next

                If existingRow IsNot Nothing Then
                    ' Product already exists - update quantity and total
                    Dim currentQty As Integer = Convert.ToInt32(existingRow.Cells("Quantity").Value)
                    Dim newQty As Integer = currentQty + qty

                    ' Check if new quantity exceeds stock
                    If newQty > stockQuantity Then
                        reader.Close()
                        conn.Close()
                        MsgBox("Cannot add more. Total quantity (" & newQty.ToString() & ") would exceed available stock (" & stockQuantity.ToString() & ").", vbExclamation, "Insufficient Stock")
                        Exit Sub
                    End If

                    ' Update existing row
                    existingRow.Cells("Quantity").Value = newQty
                    existingRow.Cells("Total").Value = (effectivePrice * newQty).ToString("0.00")
                Else
                    ' Product doesn't exist - add new row
                    Dim rowTotal = effectivePrice * qty
                    dgvSelectedProducts.Rows.Add(productID, productName, category, qty, effectivePrice.ToString("0.00"), rowTotal.ToString("0.00"))
                End If

            Else
                MsgBox("Product not found.", vbExclamation)
            End If

            reader.Close()
            conn.Close()

            numQuantity.Value = 0
            cmbProducts.SelectedIndex = -1

            ' Update the total label
            UpdateTotalLabel()
            ' Re-evaluate discount availability based on current items
            UpdateControls()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
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
            MsgBox("Error fetching price: " & ex.Message)
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
            MsgBox("Please select a product to remove.", MsgBoxStyle.OkOnly, "Caution")
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

    Private Sub txtODCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtODCost.KeyPress
        Dim isControl As Boolean = Char.IsControl(e.KeyChar)
        Dim isDigit As Boolean = Char.IsDigit(e.KeyChar)
        Dim isDot As Boolean = (e.KeyChar = "."c)

        If isControl OrElse isDigit Then
            Return
        End If

        If isDot Then
            ' Allow only a single decimal point
            If txtODCost.Text.Contains(".") Then
                e.Handled = True
            End If
            Return
        End If

        ' Block any other characters (letters, signs, etc.)
        e.Handled = True
    End Sub

    Private Sub txtOSCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOSCost.KeyPress
        Dim isControl As Boolean = Char.IsControl(e.KeyChar)
        Dim isDigit As Boolean = Char.IsDigit(e.KeyChar)
        Dim isDot As Boolean = (e.KeyChar = "."c)

        If isControl OrElse isDigit Then
            Return
        End If

        If isDot Then
            ' Allow only a single decimal point
            If txtOSCost.Text.Contains(".") Then
                e.Handled = True
            End If
            Return
        End If

        ' Block any other characters (letters, signs, etc.)
        e.Handled = True
    End Sub

    Private Sub rbwith_CheckedChanged(sender As Object, e As EventArgs) Handles rbwith.CheckedChanged
        If suppressModePrompt OrElse isInitializing Then
            UpdateTotalLabel()
            UpdateControls()
            Return
        End If

        If rbwith.Checked Then
            ' Confirm only when switching modes in edit mode
            If IsEditMode AndAlso lastModeIsCheckUpOnly Then
                Dim res = MessageBox.Show("Are you sure you want to change the mode of check-up?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If res = DialogResult.No Then
                    suppressModePrompt = True
                    rbonly.Checked = True
                    suppressModePrompt = False
                    Return
                End If
            End If
            lastModeIsCheckUpOnly = False
        End If

        UpdateTotalLabel()
        UpdateControls()
    End Sub

    Private Sub rbonly_CheckedChanged(sender As Object, e As EventArgs) Handles rbonly.CheckedChanged
        If suppressModePrompt OrElse isInitializing Then
            If rbonly.Checked Then
                UpdateTotalLabel()
                UpdateControls()
            End If
            Return
        End If

        If rbonly.Checked Then
            ' Confirm only when switching modes in edit mode
            If IsEditMode AndAlso Not lastModeIsCheckUpOnly Then
                Dim res = MessageBox.Show("Are you sure you want to change the mode of check-up?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If res = DialogResult.No Then
                    suppressModePrompt = True
                    rbwith.Checked = True
                    suppressModePrompt = False
                    Return
                End If
            End If

            If Not isInitializing Then
                dgvSelectedProducts.Rows.Clear()
                txtODCost.Text = "0.00"
                txtOSCost.Text = "0.00"
                ' Clear OD/OS grade selections and discounts when switching to checkup only
                cmbOD.SelectedIndex = -1
                cmbOS.SelectedIndex = -1
                cmbOD.Text = String.Empty
                cmbOS.Text = String.Empty
                cmbDiscount.SelectedIndex = -1
                cmbDiscount.Text = String.Empty
                cmbLensDisc.SelectedIndex = -1
                cmbLensDisc.Text = String.Empty
                ' Remember that base check-up fee has been applied
                hasCheckupBaseApplied = True
            End If

            lastModeIsCheckUpOnly = True
        End If

        UpdateTotalLabel()
        UpdateControls()
    End Sub
    Private Sub UpdateControls()
        If rbonly.Checked Then
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
        ElseIf rbwith.Checked Then
            cmbProducts.Enabled = True
            numQuantity.Enabled = True
            cmbOD.Enabled = True
            cmbOS.Enabled = True
            ' Discount is only enabled when there is at least one Frame item
            Dim hasFrame As Boolean = HasFrameItem()
            cmbDiscount.Enabled = hasFrame
            ' Preserve selection even when disabled so edit mode reflects saved value
            ' Lens discount is only enabled when there is at least one Lens item
            Dim hasLens As Boolean = HasLensItem()
            cmbLensDisc.Enabled = hasLens
            ' Preserve selection even when disabled so edit mode reflects saved value
            btnAdd.Enabled = True
            btnRemove.Enabled = True
            txtODCost.Enabled = True
            txtOSCost.Enabled = True
            dgvSelectedProducts.Enabled = True
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
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Debug.WriteLine("=== SAVE BUTTON CLICKED ===")
        Debug.WriteLine("IsEditMode: " & IsEditMode.ToString())
        Debug.WriteLine("TransactionID: " & TransactionID.ToString())

        Dim totalAmount As Double
        Dim amountPaid As Double
        Dim pendingBalance As Double
        Dim discount As Double
        ' Set isCheckUp based on radio button state:
        ' - rbonly.Checked = True → isCheckUp = 1 (check-up only)
        ' - rbwith.Checked = True → isCheckUp = 1 (with check-up, has items + checkup)
        ' - rbItems.Checked = True → isCheckUp = 0 (items only, no checkup)
        Dim isCheckUp As Integer = If(rbonly.Checked OrElse rbwith.Checked, 1, 0)
        Dim paymentStatus As String

        Debug.WriteLine("=== SAVING TRANSACTION ===")
        Debug.WriteLine("rbonly.Checked: " & rbonly.Checked.ToString())
        Debug.WriteLine("rbwith.Checked: " & rbwith.Checked.ToString())
        Debug.WriteLine("rbItems.Checked: " & rbItems.Checked.ToString())
        Debug.WriteLine("isCheckUp value: " & isCheckUp.ToString())
        Debug.WriteLine("==========================")

        ' Required selections
        If String.IsNullOrWhiteSpace(cmbMode.Text) Then
            MsgBox("Please select a Mode of Payment.", vbExclamation, "Caution")
            Debug.WriteLine("EXIT: No payment mode selected")
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
                MsgBox("For 'With check up', add at least one item or provide OD/OS prices and grades.", vbExclamation, "Caution")
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
        ' Prevent negative balances (treat any overpayment as change returned)
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

        ' Debug output for lens discount
        Debug.WriteLine("=== SAVING LENS DISCOUNT ===")
        Debug.WriteLine("cmbLensDisc.Text: '" & cmbLensDisc.Text & "'")
        Debug.WriteLine("cmbLensDisc.SelectedIndex: " & cmbLensDisc.SelectedIndex.ToString())
        Debug.WriteLine("cmbLensDisc.SelectedItem: " & If(cmbLensDisc.SelectedItem IsNot Nothing, cmbLensDisc.SelectedItem.ToString(), "NULL"))
        Debug.WriteLine("lensDiscText (after trim): '" & lensDiscText & "'")

        ' Only parse if not N/A
        If Not String.IsNullOrEmpty(lensDiscText) AndAlso lensDiscText <> "N/A" Then
            Double.TryParse(lensDiscText, lensDiscount)
            If cmbLensDisc.Text.Contains("%") Then lensDiscount = lensDiscount / 100
        End If

        Debug.WriteLine("lensDiscount (final value): " & lensDiscount.ToString())
        Debug.WriteLine("=== END SAVING LENS DISCOUNT ===")

        If MsgBox("Save this transaction?", vbYesNo + vbQuestion, "Confirm") = vbNo Then
            Exit Sub
        End If

        Try
            Call dbConn()

            If IsEditMode AndAlso TransactionID > 0 Then
                ' Update existing transaction
                Dim updateTrans As String =
                    "UPDATE tbl_transactions " &
                    "SET patientID = ?, patientName = ?, totalAmount = ?, amountPaid = ?, pendingBalance = ?, settlementDate = ?, paymentType = ?, transactionDate = ?, paymentStatus = ?, isCheckUp = ?, discount = ?, lensDiscount = ? " &
                    "WHERE transactionID = ?"
                Using cmd As New Odbc.OdbcCommand(updateTrans, conn)
                    cmd.Parameters.AddWithValue("?", CInt(lblPatientID.Text))
                    cmd.Parameters.AddWithValue("?", txtPatientName.Text)
                    cmd.Parameters.AddWithValue("?", totalAmount)
                    cmd.Parameters.AddWithValue("?", amountPaid)
                    cmd.Parameters.AddWithValue("?", pendingBalance)
                    Dim pSettleU As Odbc.OdbcParameter = cmd.Parameters.Add("?", Odbc.OdbcType.Date)
                    If paymentStatus = "Paid" Then
                        pSettleU.Value = dtpDate.Value.Date
                    Else
                        pSettleU.Value = DBNull.Value
                    End If
                    cmd.Parameters.AddWithValue("?", cmbMode.Text)
                    cmd.Parameters.AddWithValue("?", dtpDate.Value.Date)
                    cmd.Parameters.AddWithValue("?", paymentStatus)
                    cmd.Parameters.AddWithValue("?", isCheckUp)
                    cmd.Parameters.AddWithValue("?", discount)
                    cmd.Parameters.AddWithValue("?", lensDiscount)
                    cmd.Parameters.AddWithValue("?", TransactionID)
                    cmd.ExecuteNonQuery()
                End Using

                ' Restock previous items for this transaction (refund inventory)
                Using getItemsCmd As New Odbc.OdbcCommand("SELECT productID, quantity FROM tbl_transaction_items WHERE transactionID = ?", conn)
                    getItemsCmd.Parameters.AddWithValue("?", TransactionID)
                    Using itemsRdr = getItemsCmd.ExecuteReader()
                        While itemsRdr.Read()
                            Dim prevProductID As Integer = Convert.ToInt32(itemsRdr("productID"))
                            Dim prevQty As Integer = Convert.ToInt32(itemsRdr("quantity"))
                            Using restockCmd As New Odbc.OdbcCommand("UPDATE tbl_products SET stockQuantity = stockQuantity + ? WHERE productID = ?", conn)
                                restockCmd.Parameters.AddWithValue("?", prevQty)
                                restockCmd.Parameters.AddWithValue("?", prevProductID)
                                restockCmd.ExecuteNonQuery()
                            End Using
                        End While
                    End Using
                End Using

                ' Delete existing transaction items after refunding stock
                Using cmd As New Odbc.OdbcCommand("DELETE FROM tbl_transaction_items WHERE transactionID = ?", conn)
                    cmd.Parameters.AddWithValue("?", TransactionID)
                    cmd.ExecuteNonQuery()
                End Using

                ' Insert new transaction items
                SaveTransactionItems(TransactionID)

                InsertAuditTrail("Update", "Updated transaction for " & txtPatientName.Text & " with total of " & txtTotal.Text & " and paid" & txtAmountPaid.Text, "tbl_transactions" & "tbl_transaction_items", lblPatientID.Text)

            Else
                ' Insert new transaction
                Dim insertTrans As String =
                    "INSERT INTO tbl_transactions " &
                    "(patientID, patientName, totalAmount, amountPaid, pendingBalance, settlementDate, paymentType, transactionDate, paymentStatus, isCheckUp, discount, lensDiscount) " &
                    "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
                Using cmd As New Odbc.OdbcCommand(insertTrans, conn)
                    cmd.Parameters.AddWithValue("?", CInt(lblPatientID.Text))
                    cmd.Parameters.AddWithValue("?", txtPatientName.Text)
                    cmd.Parameters.AddWithValue("?", totalAmount)
                    cmd.Parameters.AddWithValue("?", amountPaid)
                    cmd.Parameters.AddWithValue("?", pendingBalance)
                    Dim pSettleI As Odbc.OdbcParameter = cmd.Parameters.Add("?", Odbc.OdbcType.Date)
                    If paymentStatus = "Paid" Then
                        pSettleI.Value = dtpDate.Value.Date
                    Else
                        pSettleI.Value = DBNull.Value
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
                    TransactionID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
                SaveTransactionItems(TransactionID)

                InsertAuditTrail("Insert", "Added new transaction for " & txtPatientName.Text & " with total of " & txtTotal.Text & " and paid ₱" & txtAmountPaid.Text, "tbl_transactions" & "tbl_transaction_items", lblPatientID.Text)
            End If

            ' Show success message for all transactions
            If IsEditMode Then
                If paymentStatus = "Paid" Then
                    MsgBox("Transaction updated successfully! Payment fully settled.", vbInformation, "Update Complete")
                Else
                    MsgBox("Transaction updated successfully! Pending balance: ₱" & pendingBalance.ToString("F2"), vbInformation, "Update Complete")
                End If
            Else
                If paymentStatus = "Paid" Then
                    MsgBox("Transaction saved successfully! Payment fully settled.", vbInformation, "Save Complete")
                Else
                    MsgBox("Transaction saved successfully! Pending balance: ₱" & pendingBalance.ToString("F2"), vbInformation, "Save Complete")
                End If
            End If

            conn.Close()
            If Application.OpenForms().OfType(Of Transaction).Any() Then
                Dim transForm = Application.OpenForms().OfType(Of Transaction).First()
                transForm.LoadTransactions()
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
                ' Use the discounted total from the dgv Total column instead of recalculating
                Dim totalPrice As Double = 0
                Double.TryParse(row.Cells("Total").Value.ToString(), totalPrice)
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
