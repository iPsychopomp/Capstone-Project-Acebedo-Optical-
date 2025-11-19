Public Class transactionMainte

    Private Sub transactionMainte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPaymentMethods()
        LoadCurrentCheckupPrice()
        DgvStyle(dgvPayment)

    End Sub

    Public Sub DgvStyle(ByRef doctorsDGV As DataGridView)
        ' Basic Grid Setup
        doctorsDGV.AutoGenerateColumns = False
        doctorsDGV.AllowUserToAddRows = False
        doctorsDGV.AllowUserToDeleteRows = False
        doctorsDGV.RowHeadersVisible = False
        doctorsDGV.BorderStyle = BorderStyle.FixedSingle
        doctorsDGV.BackgroundColor = Color.White
        doctorsDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        doctorsDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        doctorsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        doctorsDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        doctorsDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        doctorsDGV.EnableHeadersVisualStyles = False
        doctorsDGV.DefaultCellStyle.ForeColor = Color.Black
        doctorsDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        doctorsDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        doctorsDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        doctorsDGV.GridColor = Color.Silver
        doctorsDGV.DefaultCellStyle.Padding = New Padding(5)
        doctorsDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        doctorsDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        doctorsDGV.ReadOnly = True
        doctorsDGV.MultiSelect = False
        doctorsDGV.AllowUserToResizeRows = False
        doctorsDGV.RowTemplate.Height = 30
        doctorsDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        doctorsDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        ' Center align all column headers
        For Each col As DataGridViewColumn In doctorsDGV.Columns
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub

    Private Sub LoadCurrentCheckupPrice()
        Try
            Call dbConn()

            Dim sql As String = "SELECT price FROM tbl_checkup_price ORDER BY checkupPriceID DESC LIMIT 1"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                Dim obj = cmd.ExecuteScalar()
                If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                    Dim p As Decimal
                    If Decimal.TryParse(obj.ToString(), p) Then
                        txtCurrent.Text = p.ToString("0.00")
                    Else
                        txtCurrent.Text = "---"
                    End If
                Else
                    txtCurrent.Text = "---"
                End If
            End Using

        Catch ex As Exception
            txtCurrent.Text = "---"
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
    End Sub

    Private Sub LoadPaymentMethods()
        Try
            Call dbConn()

            Dim dt As New DataTable()
            Dim sql As String = "SELECT paymentMethodID, typeOfPayment FROM tbl_payment_method ORDER BY typeOfPayment"

            Using da As New Odbc.OdbcDataAdapter(sql, conn)
                da.Fill(dt)
            End Using

            dgvPayment.AutoGenerateColumns = False
            dgvPayment.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error loading payment methods: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim method As String = txtMethod.Text.Trim()

        If String.IsNullOrWhiteSpace(method) Then
            MessageBox.Show("Please enter a payment method.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMethod.Focus()
            Return
        End If

        If MessageBox.Show("Are you sure you want to add this payment method?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Try
            Call dbConn()

            Dim sql As String = "INSERT INTO tbl_payment_method (typeOfPayment) VALUES (?)"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", method)
                cmd.ExecuteNonQuery()
            End Using

            ' Audit trail (Action: Add)
            Try
                InsertAuditTrail(GlobalVariables.LoggedInUserID, "Add", "Added payment method: " & method)
            Catch
            End Try

            MessageBox.Show("Payment method added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMethod.Clear()
            LoadPaymentMethods()

        Catch ex As Exception
            MessageBox.Show("Error adding payment method: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvPayment.CurrentRow Is Nothing OrElse dgvPayment.CurrentRow.IsNewRow Then
            MessageBox.Show("Please select a payment method to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim id As Integer = 0
        Dim methodName As String = ""

        Try
            Dim cellValue = dgvPayment.CurrentRow.Cells("Column1").Value
            If cellValue Is Nothing OrElse Not Integer.TryParse(cellValue.ToString(), id) OrElse id <= 0 Then
                MessageBox.Show("Unable to determine the selected payment method ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            ' Get the payment method text (Column2) for audit trail
            Try
                Dim nameCell = dgvPayment.CurrentRow.Cells("Column2").Value
                If nameCell IsNot Nothing Then
                    methodName = nameCell.ToString()
                End If
            Catch
            End Try

        Catch
            MessageBox.Show("Unable to determine the selected payment method ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If MessageBox.Show("Are you sure you want to delete this payment method?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Try
            Call dbConn()

            Dim sql As String = "DELETE FROM tbl_payment_method WHERE paymentMethodID = ?"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", id)
                cmd.ExecuteNonQuery()
            End Using

            ' Audit trail (Action: Delete)
            Try
                Dim desc As String = If(String.IsNullOrWhiteSpace(methodName), "Deleted payment method.", "Deleted payment method: " & methodName)
                InsertAuditTrail(GlobalVariables.LoggedInUserID, "Delete", desc)
            Catch
            End Try

            MessageBox.Show("Payment method deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadPaymentMethods()

        Catch ex As Exception
            MessageBox.Show("Error deleting payment method: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
    End Sub

    Private Sub txtCheckUpPrice_TextChanged(sender As Object, e As EventArgs) Handles txtCheckUpPrice.TextChanged

        Dim cursorPos As Integer = txtCheckUpPrice.SelectionStart
        Dim text As String = txtCheckUpPrice.Text

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

        If txtCheckUpPrice.Text <> validText Then
            txtCheckUpPrice.Text = validText
            txtCheckUpPrice.SelectionStart = Math.Min(cursorPos, validText.Length)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim newPriceText As String = txtCheckUpPrice.Text.Trim()
        If String.IsNullOrWhiteSpace(newPriceText) Then
            MessageBox.Show("Please enter a new check-up price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCheckUpPrice.Focus()
            Return
        End If

        Dim newPrice As Decimal
        If Not Decimal.TryParse(newPriceText, newPrice) OrElse newPrice <= 0D Then
            MessageBox.Show("Please enter a valid price greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCheckUpPrice.Focus()
            Return
        End If

        If MessageBox.Show("Are you sure you want to update the check-up price?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Try
            Call dbConn()

            ' Insert a new price record; the latest row is treated as the current price
            Dim sql As String = "INSERT INTO tbl_checkup_price(price) VALUES (?)"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                ' Use Double to avoid SQL_C_NUMERIC issues with older MySQL ODBC drivers
                Dim p As Odbc.OdbcParameter = cmd.Parameters.Add("?", Odbc.OdbcType.Double)
                p.Value = CDbl(newPrice)
                cmd.ExecuteNonQuery()
            End Using

            ' Audit trail (Action: Update)
            Try
                InsertAuditTrail(GlobalVariables.LoggedInUserID, "Update", "Updated check-up price to " & newPrice.ToString("0.00"))
            Catch
            End Try

            MessageBox.Show("Check-up price updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCheckUpPrice.Clear()
            LoadCurrentCheckupPrice()

        Catch ex As Exception
            MessageBox.Show("Error updating check-up price: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Try
                If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
            Catch
            End Try
        End Try
    End Sub

    Private Sub InsertAuditTrail(userID As Integer, actionType As String, actionDetails As String)
        Dim connectionString As String = "DSN=dsnsystem"
        Using c As New Odbc.OdbcConnection(connectionString)
            Try
                c.Open()
                Dim q As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?)"
                Using cmd As New Odbc.OdbcCommand(q, c)
                    cmd.Parameters.AddWithValue("?", userID)
                    cmd.Parameters.AddWithValue("?", GlobalVariables.LoggedInUser)
                    cmd.Parameters.AddWithValue("?", actionType)
                    cmd.Parameters.AddWithValue("?", actionDetails)
                    cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                    cmd.ExecuteNonQuery()
                End Using
            Catch
                ' ignore audit failure here
            End Try
        End Using
    End Sub

End Class