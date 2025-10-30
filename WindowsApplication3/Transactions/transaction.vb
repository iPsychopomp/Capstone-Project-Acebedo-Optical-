Public Class Transaction
    Private lastCheckedRadio As RadioButton = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub Transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTransactions()
        Call DgvStyle(transactionDGV)

        ' Hide Settle Balance and Edit buttons for Admin/Administrator (but NOT for Super Admin)
        If (LoggedInRole = "Admin" OrElse LoggedInRole = "Administrator") AndAlso LoggedInRole <> "Super Admin" Then
            btnSettle.Visible = False
            btnEdit.Visible = False
        End If
    End Sub
    Public Sub DgvStyle(ByRef transactionDGV As DataGridView)
        ' Basic Grid Setup
        transactionDGV.AutoGenerateColumns = False
        transactionDGV.AllowUserToAddRows = False
        transactionDGV.AllowUserToDeleteRows = False
        transactionDGV.RowHeadersVisible = False
        transactionDGV.BorderStyle = BorderStyle.FixedSingle
        transactionDGV.BackgroundColor = Color.White
        transactionDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        transactionDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        transactionDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        transactionDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        transactionDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        transactionDGV.EnableHeadersVisualStyles = False
        transactionDGV.DefaultCellStyle.ForeColor = Color.Black
        transactionDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        transactionDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        transactionDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        transactionDGV.GridColor = Color.Silver
        transactionDGV.DefaultCellStyle.Padding = New Padding(5)
        transactionDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        transactionDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        transactionDGV.ReadOnly = True
        transactionDGV.MultiSelect = False
        transactionDGV.AllowUserToResizeRows = False
        transactionDGV.RowTemplate.Height = 30
        transactionDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        transactionDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

    End Sub



    Private Sub transactionDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles transactionDGV.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                transactionDGV.Rows(e.RowIndex).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        If transactionDGV.SelectedRows.Count > 0 Then
            Try
                Dim transactionID As Integer = Convert.ToInt32(transactionDGV.SelectedRows(0).Cells("Column0").Value)
                Dim newTransaction As New addPatientTransaction()

                ' Set the form to edit mode
                newTransaction.IsEditMode = True
                newTransaction.TransactionID = transactionID

                newTransaction.Text = "Edit Transactions"
                newTransaction.TopMost = True
                newTransaction.ShowDialog()

                ' Refresh the transactions after editing
                LoadTransactions()
            Catch ex As Exception
                MessageBox.Show("Error editing transaction: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub LoadTransactionsData()
        Try
            Call dbConn()
            Dim query As String = _
                "SELECT " & _
                " t.transactionID, " & _
                " t.patientID, " & _
                " COALESCE(p.fullname, t.patientName) AS patientName, " & _
                " t.paymentType AS typeOfPayment, " & _
                " t.transactionDate AS date, " & _
                " t.pendingBalance, " & _
                " t.settlementDate, " & _
                " t.amountPaid, " & _
                " t.totalAmount AS totalPayment, " & _
                " CASE WHEN t.pendingBalance <= 0 THEN 'Paid' ELSE 'Pending' END AS paymentStatus " & _
                "FROM tbl_transactions t " & _
                "LEFT JOIN db_viewpatient p ON p.patientID = t.patientID " & _
                "ORDER BY t.transactionID DESC"

            Call LoadDGV(query, transactionDGV)
            transactionDGV.ClearSelection()
        Catch ex As Exception
            MsgBox("Failed to load data: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub
    Private Sub transactionDGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles transactionDGV.CellDoubleClick
        If e.RowIndex >= 0 Then
            ' Open the transaction viewer by PATIENT ID (Column1)
            Dim patientID As Integer = Convert.ToInt32(transactionDGV.Rows(e.RowIndex).Cells("Column1").Value)
            Dim viewtransaction As New viewTransactions()
            viewtransaction.LoadViewTransaction(patientID)
            viewtransaction.Show()
        End If
    End Sub
    Public Sub LoadTransactions(Optional statusFilter As String = "")
        dbConn()
        Dim query As String = _
            "SELECT " & _
            " t.transactionID, " & _
            " t.patientID, " & _
            " COALESCE(p.fullname, t.patientName) AS patientName, " & _
            " t.paymentType AS typeOfPayment, " & _
            " t.transactionDate AS date, " & _
            " t.pendingBalance, " & _
            " t.settlementDate, " & _
            " t.amountPaid, " & _
            " t.totalAmount AS totalPayment, " & _
            " CASE WHEN t.pendingBalance <= 0 THEN 'Paid' ELSE 'Pending' END AS paymentStatus " & _
            "FROM tbl_transactions t " & _
            "LEFT JOIN db_viewpatient p ON p.patientID = t.patientID"

        ' Check if a filter is applied, and add WHERE or AND accordingly
        If statusFilter <> "" Then
            Dim statusExpr As String = "CASE WHEN t.pendingBalance <= 0 THEN 'Paid' ELSE 'Pending' END"
            If query.Contains("WHERE") Then
                query &= " AND " & statusExpr & " = '" & statusFilter & "'"
            Else
                query &= " WHERE " & statusExpr & " = '" & statusFilter & "'"
            End If
        End If

        query &= " ORDER BY t.transactionID DESC;"

        ' Load the data into DataGridView
        LoadDGV(query, transactionDGV)
        transactionDGV.ClearSelection()
        conn.Close()

        ComputeTransactionTotals()
        DgvStyle(transactionDGV)

        ' UI adjustments based on user role
        If LoggedInRole = "Receptionist" OrElse LoggedInRole = "Doctor" Then
            transactionDGV.Dock = DockStyle.Fill
            Label1.Visible = False
            Total.Visible = False
            txtAmountTotal.Visible = False
            txtPending.Visible = False
        Else
            transactionDGV.Dock = DockStyle.None
            Label1.Visible = True
            Total.Visible = True
            txtAmountTotal.Visible = True
            txtPending.Visible = True
        End If
        Me.PerformLayout() ' Forces a layout refresh
    End Sub
    Private Sub ComputeTransactionTotals()
        Dim totalPending As Decimal = 0
        Dim totalAmount As Decimal = 0
        Dim pesoSign As String = ChrW(&H20B1) ' Unicode character for Peso sign

        For Each row As DataGridViewRow In transactionDGV.Rows
            If Not row.IsNewRow Then
                Dim pendingVal As Decimal = 0
                Dim totalVal As Decimal = 0

                Dim pendingStr As String = row.Cells("Column9").Value.ToString()
                Dim totalStr As String = row.Cells("Column3").Value.ToString()
                
                ' Remove peso sign if present before parsing
                pendingStr = pendingStr.Replace(pesoSign, "").Replace(",", "").Trim()
                totalStr = totalStr.Replace(pesoSign, "").Replace(",", "").Trim()

                Decimal.TryParse(pendingStr, pendingVal)
                Decimal.TryParse(totalStr, totalVal)

                totalPending += pendingVal
                totalAmount += totalVal
            End If
        Next

        txtPending.Text = pesoSign & totalPending.ToString("#,##0.00")
        txtAmountTotal.Text = pesoSign & totalAmount.ToString("#,##0.00")
    End Sub
    Private Sub rbPending_Click(sender As Object, e As EventArgs) Handles rbPending.Click
        HandleRadioButtonFilter(rbPending, "Pending")
    End Sub

    Private Sub rbPaid_Click(sender As Object, e As EventArgs) Handles rbPaid.Click
        HandleRadioButtonFilter(rbPaid, "Paid")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim searchText As String = txtSearch.Text.Trim()

            dbConn()
            Dim query As String = _
                "SELECT " & _
                " t.transactionID, " & _
                " t.patientID, " & _
                " COALESCE(p.fullname, t.patientName) AS patientName, " & _
                " t.paymentType AS typeOfPayment, " & _
                " t.transactionDate AS date, " & _
                " t.pendingBalance, " & _
                " t.settlementDate, " & _
                " t.amountPaid, " & _
                " t.totalAmount AS totalPayment, " & _
                " CASE WHEN t.pendingBalance <= 0 THEN 'Paid' ELSE 'Pending' END AS paymentStatus " & _
                "FROM tbl_transactions t " & _
                "LEFT JOIN db_viewpatient p ON p.patientID = t.patientID "

            Dim whereParts As New List(Of String)()
            If searchText <> "" Then
                whereParts.Add("LOWER(COALESCE(p.fullname, t.patientName)) LIKE LOWER(?)")
            End If
            Dim statusExpr As String = "CASE WHEN t.pendingBalance <= 0 THEN 'Paid' ELSE 'Pending' END"
            If rbPaid.Checked Then
                whereParts.Add(statusExpr & " = 'Paid'")
            ElseIf rbPending.Checked Then
                whereParts.Add(statusExpr & " = 'Pending'")
            End If

            If whereParts.Count > 0 Then
                query &= " WHERE " & String.Join(" AND ", whereParts)
            End If

            query &= " ORDER BY t.transactionID DESC"

            If searchText <> "" Then
                LoadDGV(query, transactionDGV, searchText)
            Else
                LoadDGV(query, transactionDGV)
            End If

            ' Show message if no results found
            If transactionDGV.RowCount <= 0 Then
                MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            transactionDGV.ClearSelection()
            conn.Close()
            ComputeTransactionTotals()
        Catch ex As Exception
            MsgBox("Failed to search: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Private Sub HandleRadioButtonFilter(rb As RadioButton, filterValue As String)
        Dim hasSearch As Boolean = txtSearch.Text.Trim() <> ""

        If lastCheckedRadio Is rb AndAlso rb.Checked Then
            rb.Checked = False
            lastCheckedRadio = Nothing
            If hasSearch Then
                ' Apply search across all statuses
                btnSearch_Click(Nothing, EventArgs.Empty)
            Else
                LoadTransactions() ' Load all
            End If
        Else
            lastCheckedRadio = rb
            If hasSearch Then
                ' Apply search with the newly selected status filter
                btnSearch_Click(Nothing, EventArgs.Empty)
            Else
                LoadTransactions(filterValue)
            End If
        End If
    End Sub

    Private Sub btnSettle_Click(sender As Object, e As EventArgs) Handles btnSettle.Click
        If transactionDGV.SelectedRows.Count > 0 Then
            Dim transactionID As Integer = Convert.ToInt32(transactionDGV.SelectedRows(0).Cells("Column0").Value)
            Dim patientName As String = transactionDGV.SelectedRows(0).Cells("Column2").Value.ToString()
            Dim totalAmount As Decimal = Convert.ToDecimal(transactionDGV.SelectedRows(0).Cells("Column3").Value)
            Dim pendingBalance As Decimal = Convert.ToDecimal(transactionDGV.SelectedRows(0).Cells("Column9").Value)

            ' Block settlement if already PAID
            If pendingBalance <= 0D Then
                MessageBox.Show("This transaction is already Paid and cannot be Settled.", "Paid", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Check payment count limit
            Dim paymentCount As Integer = GetTransactionPaymentCount(transactionID)
            If paymentCount >= 2 Then
                MessageBox.Show("This transaction has already reached the maximum of 2 payments and cannot be settled further.", "Payment Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Ensure Type of Payment is set before allowing settlement
            Try
                Call dbConn()
                Dim paymentType As String = ""
                Dim query As String = "SELECT paymentType FROM tbl_transactions WHERE transactionID = ?"
                Using cmd As New Odbc.OdbcCommand(query, conn)
                    cmd.Parameters.AddWithValue("?", transactionID)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        paymentType = result.ToString().Trim()
                    End If
                End Using
                conn.Close()

                If String.IsNullOrWhiteSpace(paymentType) Then
                    MessageBox.Show("Type of Payment is not set for this transaction. Please set it before settling.", _
                                    "Cannot Settle", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            Catch ex As Exception
                MessageBox.Show("Failed to validate Type of Payment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            Dim payme As New Payment(transactionID, patientName, totalAmount, pendingBalance)
            payme.ShowDialog()

            LoadTransactions()
        Else
            MessageBox.Show("Please select a transaction first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnEdit_Click_1(sender As Object, e As EventArgs) Handles btnEdit.Click
        If transactionDGV.SelectedRows.Count > 0 Then
            Try
                Dim transactionID As Integer = Convert.ToInt32(transactionDGV.SelectedRows(0).Cells("Column0").Value)
                Call dbConn()

                ' Determine Paid status using pendingBalance from DB (more reliable)
                Dim pendingBalance As Decimal = 0D
                Dim query As String = "SELECT pendingBalance FROM tbl_transactions WHERE transactionID = ?"
                Using cmd As New Odbc.OdbcCommand(query, conn)
                    cmd.Parameters.AddWithValue("?", transactionID)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        Decimal.TryParse(result.ToString(), pendingBalance)
                    End If
                End Using

                If pendingBalance <= 0D Then
                    MessageBox.Show("This transaction has already been paid and cannot be edited.", "Edit Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim newTransaction As New addPatientTransaction()
                newTransaction.IsEditMode = True
                newTransaction.TransactionID = transactionID


                newTransaction.TopMost = True
                newTransaction.ShowDialog()

                LoadTransactions()

            Catch ex As Exception
                MessageBox.Show("Error editing transaction: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function GetTransactionPaymentCount(transactionID As Integer) As Integer
        Try
            Call dbConn()

            ' Check if payment history table exists
            Dim checkTableSql As String = "SELECT 1 FROM information_schema.tables WHERE table_name = 'tbl_payment_history'"
            Using checkCmd As New Odbc.OdbcCommand(checkTableSql, conn)
                Dim tableExists = checkCmd.ExecuteScalar()

                If tableExists Is Nothing Then
                    ' Table doesn't exist, return 0 (no payments recorded yet)
                    Return 0
                End If
            End Using

            ' Count payments for this transaction
            Dim countSql As String = "SELECT COUNT(*) FROM tbl_payment_history WHERE transactionID = ?"
            Using cmd As New Odbc.OdbcCommand(countSql, conn)
                cmd.Parameters.AddWithValue("?", transactionID)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using

        Catch ex As Exception
            ' If error occurs, return 0 to allow payment attempt
            Return 0
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

    Private Sub pnlTrans_Paint(sender As Object, e As PaintEventArgs) Handles pnlTrans.Paint

    End Sub

    ' Event handler to format amount columns with peso sign
    Private Sub transactionDGV_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles transactionDGV.CellFormatting
        Try
            Dim colName As String = transactionDGV.Columns(e.ColumnIndex).Name
            Dim pesoSign As String = ChrW(&H20B1) ' Unicode character for Peso sign

            ' Format Amount Paid column (Column6)
            If colName = "Column6" OrElse colName = "amountPaid" Then
                If e.Value IsNot Nothing AndAlso Not IsDBNull(e.Value) AndAlso IsNumeric(e.Value) Then
                    Dim amount As Decimal = Convert.ToDecimal(e.Value)
                    e.Value = pesoSign & amount.ToString("#,##0.00")
                    e.FormattingApplied = True
                End If
            End If

            ' Format Balance column (Column9)
            If colName = "Column9" OrElse colName = "pendingBalance" Then
                If e.Value IsNot Nothing AndAlso Not IsDBNull(e.Value) AndAlso IsNumeric(e.Value) Then
                    Dim balance As Decimal = Convert.ToDecimal(e.Value)
                    e.Value = pesoSign & balance.ToString("#,##0.00")
                    e.FormattingApplied = True
                End If
            End If

            ' Format Total Amount column (Column3)
            If colName = "Column3" OrElse colName = "totalPayment" Then
                If e.Value IsNot Nothing AndAlso Not IsDBNull(e.Value) AndAlso IsNumeric(e.Value) Then
                    Dim total As Decimal = Convert.ToDecimal(e.Value)
                    e.Value = pesoSign & total.ToString("#,##0.00")
                    e.FormattingApplied = True
                End If
            End If
        Catch ex As Exception
            ' Ignore formatting errors
        End Try
    End Sub
End Class
