﻿Imports System.Data.Odbc
Public Class stockOUT

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Call dbConn()
            If conn.State <> ConnectionState.Open Then
                MsgBox("Database connection is not open. Please check your connection.", vbCritical, "Connection Error")
                Exit Sub
            End If

            Dim productID As Integer
            If cmbPrdctName.SelectedValue IsNot Nothing AndAlso Integer.TryParse(cmbPrdctName.SelectedValue.ToString(), productID) Then

                Dim currentStock As Integer = GetCurrentStock(productID)
                If NumQuantity.Value > currentStock Then
                    MsgBox("Insufficient stock for this transaction!", vbExclamation, "Stock Error")
                    Exit Sub
                End If

                Dim sql As String = "INSERT INTO tbl_stock_out (productID, quantityIssued, reason, dateIssued, issuedBy) VALUES (?,?,?,?,?)"
                Using cmdInsert As New Odbc.OdbcCommand(sql, conn)
                    cmdInsert.Parameters.Add("?", Odbc.OdbcType.Int).Value = productID
                    cmdInsert.Parameters.Add("?", Odbc.OdbcType.Int).Value = NumQuantity.Value
                    cmdInsert.Parameters.Add("?", Odbc.OdbcType.VarChar, 100).Value = cmbReason.Text
                    cmdInsert.Parameters.Add("?", Odbc.OdbcType.Date).Value = dtpDate.Value
                    cmdInsert.Parameters.Add("?", Odbc.OdbcType.VarChar, 100).Value = StrConv(Trim(txtIssuedBy.Text), VbStrConv.ProperCase)

                    cmdInsert.ExecuteNonQuery()
                End Using

                sql = "UPDATE tbl_products SET stockQuantity = stockQuantity - ? WHERE productID = ?"
                Using cmdUpdate As New Odbc.OdbcCommand(sql, conn)
                    cmdUpdate.Parameters.Add("?", Odbc.OdbcType.Int).Value = NumQuantity.Value
                    cmdUpdate.Parameters.Add("?", Odbc.OdbcType.Int).Value = productID
                    cmdUpdate.ExecuteNonQuery()
                End Using

                ' Para sa Audit Trail
                InsertAuditTrail(GlobalVariables.LoggedInUserID, "Stock Out", String.Format("Issued {0} of {1} for {2}", NumQuantity.Value, cmbPrdctName.Text, cmbReason.Text))

                MsgBox("Stock-out recorded successfully!", vbInformation, "Success")

                ' Reload the stock out DGV
                LoadDGV("SELECT * FROM db_viewstockout", Me.StockOutDGV)
                
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
            Else
                MsgBox("Please select a valid product.", vbExclamation, "Invalid Selection")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Database Error")
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        DgvStyle(StockOutDGV)
    End Sub



    Private Function GetCurrentStock(productID As Integer) As Integer
        Dim cmd As New Odbc.OdbcCommand("SELECT stockQuantity FROM tbl_products WHERE productID=?", conn)
        cmd.Parameters.AddWithValue("?", productID)

        Try
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                Return Convert.ToInt32(result)
            End If
        Catch ex As Exception
            MsgBox("Error fetching stock quantity: " & ex.Message, vbCritical, "Error")
        End Try

        Return 0
        DgvStyle(StockOutDGV)
    End Function

    Private Sub LoadProducts()
        Try
            Call dbConn()

            If conn.State <> ConnectionState.Open Then
                MsgBox("Database connection failed to open.", vbCritical, "Connection Error")
                Exit Sub
            End If

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
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        DgvStyle(StockOutDGV)
    End Sub

    Sub InsertAuditTrail(UserID As Integer, ActionType As String, ActionDetails As String)
        Dim connectionString As String = "DSN=dsnsystem"
        Using conn As New Odbc.OdbcConnection(connectionString)
            Try
                conn.Open()
                Dim query As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?)"
                Using cmd As New Odbc.OdbcCommand(query, conn)
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
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub stockOUT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
        Call LoadDGV("SELECT * FROM db_viewstockout", StockOutDGV)
        DgvStyle(StockOutDGV)
        
        ' Set issued by to logged in user's full name
        txtIssuedBy.Text = GlobalVariables.LoggedInFullName
        txtIssuedBy.ReadOnly = True
    End Sub

    Private Sub StockOutDGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles StockOutDGV.CellContentClick

    End Sub
    Public Sub DgvStyle(ByRef StockOutDGV As DataGridView)
        ' Basic Grid Setup
        StockOutDGV.AutoGenerateColumns = False
        StockOutDGV.AllowUserToAddRows = False
        StockOutDGV.AllowUserToDeleteRows = False
        StockOutDGV.RowHeadersVisible = False
        StockOutDGV.BorderStyle = BorderStyle.FixedSingle
        StockOutDGV.BackgroundColor = Color.White
        StockOutDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        StockOutDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        StockOutDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        StockOutDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        StockOutDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        StockOutDGV.EnableHeadersVisualStyles = False
        StockOutDGV.DefaultCellStyle.ForeColor = Color.Black
        StockOutDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        StockOutDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        StockOutDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        StockOutDGV.GridColor = Color.Silver
        StockOutDGV.DefaultCellStyle.Padding = New Padding(5)
        StockOutDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        StockOutDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        StockOutDGV.ReadOnly = True
        StockOutDGV.MultiSelect = False
        StockOutDGV.AllowUserToResizeRows = False
        StockOutDGV.RowTemplate.Height = 30
        StockOutDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        StockOutDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub
End Class
