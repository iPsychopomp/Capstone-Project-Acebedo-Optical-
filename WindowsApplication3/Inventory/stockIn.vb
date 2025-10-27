Public Class stockIN
    Private Sub stockIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
        ComputeTotalCost()
        Call LoadDGV("SELECT * FROM db_viewstock", StockInDGV)
        DgvStyle(StockInDGV)

        ' Set received by to logged in user's full name
        txtReceivedBy.Text = GlobalVariables.LoggedInFullName
        txtReceivedBy.ReadOnly = True
    End Sub
    Public Sub DgvStyle(ByRef StockInDGV As DataGridView)
        ' Basic Grid Setup
        StockInDGV.AutoGenerateColumns = False
        StockInDGV.AllowUserToAddRows = False
        StockInDGV.AllowUserToDeleteRows = False
        StockInDGV.RowHeadersVisible = False
        StockInDGV.BorderStyle = BorderStyle.FixedSingle
        StockInDGV.BackgroundColor = Color.White
        StockInDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        StockInDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        StockInDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        StockInDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        StockInDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        StockInDGV.EnableHeadersVisualStyles = False
        StockInDGV.DefaultCellStyle.ForeColor = Color.Black
        StockInDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        StockInDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        StockInDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        StockInDGV.GridColor = Color.Silver
        StockInDGV.DefaultCellStyle.Padding = New Padding(5)
        StockInDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        StockInDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        StockInDGV.ReadOnly = True
        StockInDGV.MultiSelect = False
        StockInDGV.AllowUserToResizeRows = False
        StockInDGV.RowTemplate.Height = 30
        StockInDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        StockInDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

    Private Sub ComputeTotalCost()
        Dim costPerItem As Decimal
        Dim quantity As Integer

        If Decimal.TryParse(txtCostPerItem.Text, costPerItem) AndAlso Integer.TryParse(NumQuantiy.Value.ToString(), quantity) Then
            Dim totalCost As Decimal = costPerItem * quantity
            txtCost.Text = totalCost.ToString("N2")
        Else
            txtCost.Text = "0.00"
        End If
        DgvStyle(StockInDGV)
    End Sub

    Private Sub txtCostPerItem_TextChanged(sender As Object, e As EventArgs) Handles txtCostPerItem.TextChanged
        ComputeTotalCost()
        DgvStyle(StockInDGV)
    End Sub

    Private Sub NumQuantiy_ValueChanged(sender As Object, e As EventArgs) Handles NumQuantiy.ValueChanged
        ComputeTotalCost()
        DgvStyle(StockInDGV)
    End Sub

    Private Sub LoadProducts()
        Try
            Call dbConn()

            Dim dt As New DataTable
            Dim da As New Odbc.OdbcDataAdapter("SELECT productID, productName FROM tbl_products", conn)

            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                cmbPrdctName.DataSource = dt
                cmbPrdctName.DisplayMember = "productName"
                cmbPrdctName.ValueMember = "productID"
            Else
                MsgBox("No products found.", vbExclamation, "Warning")
            End If

        Catch ex As Exception
            MsgBox("Error loading products: " & ex.Message, vbCritical, "Database Error")
        Finally
            conn.Close()
        End Try
        DgvStyle(StockInDGV)
    End Sub
    Public Sub loadRecord(ByVal productID As Integer)
        Try
            Call dbConn()

            Dim dt As New DataTable
            Dim cmd As New Odbc.OdbcCommand("SELECT * FROM tbl_products WHERE productID=?", conn)
            cmd.Parameters.AddWithValue("?", productID)

            Dim da As New Odbc.OdbcDataAdapter(cmd)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                cmbPrdctName.Text = dt.Rows(0)("productName").ToString()
                txtCostPerItem.Text = dt.Rows(0)("unitPrice").ToString()
                txtCost.Text = "0.00"
            Else
                MsgBox("No record found.", vbInformation, "Record Not Found")
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString(), vbCritical, "Error Loading Record")
        Finally
            conn.Close()
        End Try
        DgvStyle(StockInDGV)
    End Sub

    Private Sub InsertAuditTrail(UserID As Integer, ActionType As String, ActionDetails As String)
        Try
            Using conn As New Odbc.OdbcConnection("DSN=dsnsystem")
                conn.Open()
                Dim cmd As New Odbc.OdbcCommand("INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?)", conn)

                cmd.Parameters.AddWithValue("?", UserID)
                cmd.Parameters.AddWithValue("?", GlobalVariables.LoggedInUser)
                cmd.Parameters.AddWithValue("?", ActionType)
                cmd.Parameters.AddWithValue("?", ActionDetails)
                cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
                cmd.Parameters.AddWithValue("?", DateTime.Now.Date)

                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox("Audit Trail Error: " & ex.Message, vbCritical, "Error")
        End Try
        DgvStyle(StockInDGV)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ComputeTotalCost()
        Try
            Call dbConn()

            Dim productID As Integer
            If cmbPrdctName.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbPrdctName.SelectedValue.ToString(), productID) Then

                Dim totalCost As Decimal
                If Not Decimal.TryParse(txtCost.Text, totalCost) Then
                    MsgBox("Invalid total cost value.", vbExclamation, "Error")
                    Exit Sub
                End If

                Dim sql As String = "INSERT INTO tbl_stock_in (productID, quantityReceived, costPerItem, totalCost, dateReceived, receivedBy) VALUES (?,?,?,?,?,?)"
                Using cmd As New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.Add("?", Odbc.OdbcType.Int).Value = productID
                    cmd.Parameters.Add("?", Odbc.OdbcType.Int).Value = NumQuantiy.Value
                    cmd.Parameters.Add("?", Odbc.OdbcType.Double).Value = Convert.ToDouble(txtCostPerItem.Text)
                    cmd.Parameters.Add("?", Odbc.OdbcType.Double).Value = Convert.ToDouble(totalCost)
                    cmd.Parameters.Add("?", Odbc.OdbcType.Date).Value = dtpDate.Value

                    cmd.Parameters.Add("?", Odbc.OdbcType.VarChar, 100).Value = StrConv(Trim(txtReceivedBy.Text), VbStrConv.ProperCase)

                    cmd.ExecuteNonQuery()
                End Using

                sql = "UPDATE tbl_products SET stockQuantity = stockQuantity + ? WHERE productID = ?"
                Using cmd As New Odbc.OdbcCommand(sql, conn)
                    cmd.Parameters.Add("?", Odbc.OdbcType.Int).Value = NumQuantiy.Value
                    cmd.Parameters.Add("?", Odbc.OdbcType.Int).Value = productID
                    cmd.ExecuteNonQuery()
                End Using

                InsertAuditTrail(GlobalVariables.LoggedInUserID, "Stock In", "Received " & NumQuantiy.Value & " of " & cmbPrdctName.Text)

                MsgBox("Stock-in recorded successfully!", vbInformation, "Success")

                ' Reload the stock in DGV
                LoadDGV("SELECT * FROM db_viewstock", Me.StockInDGV)
                
                ' Refresh the inventory form if it's open
                For Each frm As Form In Application.OpenForms
                    If TypeOf frm Is inventory Then
                        Dim invForm As inventory = DirectCast(frm, inventory)
                        Try
                            If invForm.InvokeRequired Then
                                invForm.Invoke(Sub() invForm.SafeLoadProducts())
                            Else
                                invForm.SafeLoadProducts()
                            End If
                        Catch ex As Exception
                            ' Ignore invoke errors
                        End Try
                        Exit For
                    End If
                Next

                ' Ask if user wants to add more items, but don't close automatically
                If MsgBox("Do you want to add more item?", vbQuestion + vbYesNo, "Stock In") = vbYes Then
                    ' User wants to add more, just clear the form
                    cleaner()
                End If
                ' If No, just leave the form open so user can manually close it

            Else
                MsgBox("Please select a valid product.", vbExclamation, "Invalid Selection")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Database Error")
        Finally
            conn.Close()
        End Try
        cleaner()
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub StockInDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles StockInDGV.CellContentClick

    End Sub

    Private Sub cleaner()
        For Each obj As Control In grpStockIn.Controls
            If TypeOf obj Is TextBox Then
                Dim txt As TextBox = CType(obj, TextBox)
                txt.Text = "" ' Clear the textbox
            ElseIf TypeOf obj Is ComboBox Then
                Dim cmb As ComboBox = CType(obj, ComboBox)
                If cmb.DataSource Is Nothing Then
                    cmb.Text = ""
                Else
                    cmb.SelectedIndex = -1
                End If
            ElseIf TypeOf obj Is DateTimePicker Then
                Dim dtp As DateTimePicker = CType(obj, DateTimePicker)
                dtp.Value = Date.Today
            ElseIf TypeOf obj Is NumericUpDown Then
                Dim numUpDown As NumericUpDown = CType(obj, NumericUpDown)
                numUpDown.Value = numUpDown.Minimum
            End If
        Next

        '' Reset the DataGridView tag
        'If patientRecord IsNot Nothing AndAlso patientRecord.patientDGV IsNot Nothing Then
        '    patientRecord.patientDGV.Tag = ""
        'End If
    End Sub

    Private Sub cmbPrdctName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrdctName.SelectedIndexChanged
        If cmbPrdctName.SelectedValue Is Nothing OrElse Not IsNumeric(cmbPrdctName.SelectedValue) Then Exit Sub

        Dim selectedProductID As Integer = Convert.ToInt32(cmbPrdctName.SelectedValue)

        Try
            Call dbConn()

            Dim cmd As New Odbc.OdbcCommand("SELECT unitPrice FROM tbl_products WHERE productID = ?", conn)
            cmd.Parameters.AddWithValue("?", selectedProductID)

            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                txtCostPerItem.Text = reader("unitPrice").ToString()
            Else
                txtCostPerItem.Text = "0.00"
            End If

            reader.Close()
        Catch ex As Exception
            MsgBox("Error retrieving unit price: " & ex.Message, vbCritical, "Error")
        Finally
            conn.Close()
        End Try
    End Sub

End Class
