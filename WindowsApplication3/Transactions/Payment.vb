Imports System.Data.Odbc

Public Class Payment
    Dim transactionID As Integer
    Dim patientName As String
    Dim totalAmount As Decimal
    Dim pendingBalance As Decimal
    Public Sub New(ByVal transactionID As Integer, ByVal patientName As String, ByVal totalAmount As Decimal, ByVal pendingBalance As Decimal)
        InitializeComponent()
        Me.transactionID = transactionID
        Me.patientName = patientName
        Me.totalAmount = totalAmount
        Me.pendingBalance = pendingBalance
    End Sub
    Private Sub SettleBalanceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPatientName.Text = patientName
        txtTotalAmount.Text = totalAmount.ToString("N2")
        txtPendingBalance.Text = pendingBalance.ToString("N2")
        
        ' Check payment count and adjust UI accordingly
        CheckPaymentCount()
    End Sub

    Private Sub btnSettle_Click(sender As Object, e As EventArgs) Handles btnSettle.Click
        Dim paymentAmount As Decimal
        If Decimal.TryParse(txtPayment.Text, paymentAmount) AndAlso paymentAmount > 0 Then
            ' Check if this is a settlement (meaning there was already an initial payment)
            ' If totalAmount != pendingBalance, it means there was already a downpayment
            Dim hasDownpayment As Boolean = (totalAmount <> pendingBalance)

            If hasDownpayment Then
                ' This is the FINAL payment (2nd payment) - must be FULL BALANCE
                If paymentAmount <> pendingBalance Then
                    MessageBox.Show("You must pay the full remaining balance of " & pendingBalance.ToString("C2"), "Full Balance Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtPayment.Focus()
                    txtPayment.SelectAll()
                    Return
                End If
            Else
                ' This is the initial payment - can be partial
                If paymentAmount > pendingBalance Then
                    MessageBox.Show("Payment amount cannot exceed the pending balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            UpdatePayment(paymentAmount)
            If Application.OpenForms().OfType(Of Transaction).Any() Then
                Dim transForm = Application.OpenForms().OfType(Of Transaction).First()
                transForm.LoadTransactions()
            End If
        Else
            MessageBox.Show("Please enter a valid payment amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub UpdatePayment(paymentAmount As Decimal)
        ' Double-check: If there was already a downpayment, this must be full balance
        Dim hasDownpayment As Boolean = (totalAmount <> pendingBalance)
        If hasDownpayment AndAlso paymentAmount <> pendingBalance Then
            MessageBox.Show("VALIDATION ERROR: Cannot process partial payment. This is the final payment and must be the full balance of " & pendingBalance.ToString("C2"), "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim newAmountPaid As Decimal = totalAmount - pendingBalance + paymentAmount
        Dim newPendingBalance As Decimal = pendingBalance - paymentAmount
        Dim newStatus As String = If(newPendingBalance = 0D, "Paid", "Pending")
        Dim settlementDate As Date = DateTime.Now.Date

        Try
            Call dbConn()
            If conn.State <> ConnectionState.Open Then conn.Open()

            Dim query As String =
                "UPDATE tbl_transactions " &
                "SET amountPaid     = ?, " &
                    "pendingBalance = ?, " &
                    "paymentStatus  = ?, " &
                    "settlementDate = ? " &
                "WHERE transactionID = ?"

            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.Add("?", OdbcType.Double).Value = CType(newAmountPaid, Double)
                cmd.Parameters.Add("?", OdbcType.Double).Value = CType(newPendingBalance, Double)
                cmd.Parameters.Add("?", OdbcType.VarChar, 10).Value = newStatus
                cmd.Parameters.Add("?", OdbcType.Date).Value = settlementDate
                cmd.Parameters.Add("?", OdbcType.Int).Value = transactionID

                cmd.ExecuteNonQuery()

            End Using



            ' Only show success message when payment is fully completed
            If newPendingBalance = 0D Then
                MessageBox.Show("Payment completed! Transaction is now fully paid.", "Payment Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            ' No message for partial payments - silent processing
            If Application.OpenForms().OfType(Of Transaction).Any() Then
                Dim transForm = Application.OpenForms().OfType(Of Transaction).First()
                transForm.LoadTransactions()
            End If
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error while updating the payment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
        End Try

        ' Record payment in history and audit trail after main transaction is complete
        Try
            RecordPaymentHistory(paymentAmount)
            InsertAuditTrail("Settle", "Settled payment of " & paymentAmount.ToString("C2") & " for patient: " & txtPatientName.Text & ". Remaining balance: " & newPendingBalance.ToString("C2"), "tbl_transactions, tbl_transaction_items", transactionID)
        Catch ex As Exception
            ' Don't fail the payment if audit/history recording fails
        End Try
    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged

    End Sub
    Private Sub CheckPaymentCount()
        Try
            ' No message box or auto-fill
            ' User will manually enter the payment amount
            ' Validation will happen when they click Settle button
        Catch ex As Exception
            ' Silently handle errors
        End Try
    End Sub

    Private Function GetPaymentCount() As Integer
        Try
            Call dbConn()
            EnsurePaymentHistoryTable()

            Dim countSql As String = "SELECT COUNT(*) FROM tbl_payment_history WHERE transactionID = ?"
            Using cmd As New OdbcCommand(countSql, conn)
                cmd.Parameters.AddWithValue("?", transactionID)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using

        Catch ex As Exception
            ' If table doesn't exist or error occurs, return 0 to allow first payment
            Return 0
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

    Private Sub EnsurePaymentHistoryTable()
        Try
            ' Check if payment history table exists, create if not
            Dim checkTableSql As String = "SELECT 1 FROM information_schema.tables WHERE table_name = 'tbl_payment_history'"
            Using checkCmd As New OdbcCommand(checkTableSql, conn)
                Dim tableExists = checkCmd.ExecuteScalar()

                If tableExists Is Nothing Then
                    ' Create payment history table
                    Dim createTableSql As String = "CREATE TABLE tbl_payment_history (" &
                        "paymentID INT AUTO_INCREMENT PRIMARY KEY, " &
                        "transactionID INT NOT NULL, " &
                        "paymentAmount DECIMAL(10,2) NOT NULL, " &
                        "paymentDate DATE NOT NULL, " &
                        "paymentTime TIME NOT NULL, " &
                        "processedBy VARCHAR(100), " &
                        "remarks TEXT, " &
                        "INDEX idx_transaction (transactionID))"

                    Using createCmd As New OdbcCommand(createTableSql, conn)
                        createCmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

        Catch ex As Exception
            ' Ignore table creation errors - system will work without detailed history
        End Try
    End Sub

    Private Sub RecordPaymentHistory(paymentAmount As Decimal)
        Try
            Call dbConn()
            EnsurePaymentHistoryTable()

            Dim insertSql As String = "INSERT INTO tbl_payment_history (transactionID, paymentAmount, paymentDate, paymentTime, processedBy, remarks) VALUES (?, ?, ?, ?, ?, ?)"
            Using cmd As New OdbcCommand(insertSql, conn)
                cmd.Parameters.AddWithValue("?", transactionID)
                cmd.Parameters.AddWithValue("?", paymentAmount)
                cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                cmd.Parameters.AddWithValue("?", DateTime.Now.TimeOfDay)
                cmd.Parameters.AddWithValue("?", LoggedInUser)
                cmd.Parameters.AddWithValue("?", "Payment settlement")
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            ' Don't fail the payment if history recording fails
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub InsertAuditTrail(actionType As String, actionDetails As String, tableName As String, recordID As Integer)
        Try
            ' Use a separate connection for audit trail to avoid connection conflicts
            Call dbConn()
            If conn.State <> ConnectionState.Open Then conn.Open()

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
        Catch ex As Exception
            ' Don't show error message for audit trail failures to avoid interrupting user workflow
            ' Just log it silently or ignore
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtPendingBalance_Click(sender As Object, e As EventArgs)

    End Sub
End Class