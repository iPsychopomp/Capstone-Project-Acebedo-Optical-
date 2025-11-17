Imports System.Data.Odbc
Imports System.Windows.Forms.DataVisualization.Charting

Public Class dashboard
    Public Sub New()
        InitializeComponent()
        dashboard_Load(Nothing, Nothing)
    End Sub

    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Make pnlCritical clickable with hand cursor
        pnlCritical.Cursor = Cursors.Hand
        PictureBox1.Cursor = Cursors.Hand
        lblCritical.Cursor = Cursors.Hand
        Label5.Cursor = Cursors.Hand

        ' Make pnlPatients clickable with hand cursor
        pnlPatients.Cursor = Cursors.Hand
        PictureBox4.Cursor = Cursors.Hand
        txtPatientToday.Cursor = Cursors.Hand
        Label13.Cursor = Cursors.Hand

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd MMMM yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd MMMM yyyy"

        'SetupQueueListView()
        'LoadPatientsQueue()
        'dashboardMod.GetCurrentQueueNumber(lblQueue)



        If LoggedInRole = "Receptionist" OrElse LoggedInRole = "Doctor" Then
            pnlAnalytics.Visible = False
            pnlProductSold.Visible = False
            Label1.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            dtpFrom.Visible = False
            dtpTo.Visible = False



        Else
            pnlAnalytics.Visible = True
            pnlProductSold.Visible = True
            Label1.Visible = True
            Label2.Visible = True
            Label3.Visible = True
            Label4.Visible = True
            dtpFrom.Visible = True
            dtpTo.Visible = True
            UpdateProfit()

        End If

    End Sub

    Private Sub dashboard_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            ' Load dashboard normally
            UpdateDashboard(True)
            UpdateProductSold(True)

            ' Show all-time profit automatically on login
            UpdateProfit(True)
            lblDateRange.Text = "Showing: All-Time Data"

            ' Update critical stock count
            UpdateCriticalStockCount()

            ' Update patient count for today
            UpdatePatientCount()
        Catch ex As Exception
            MessageBox.Show("Error loading dashboard: " & ex.Message)

        End Try
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        UpdateDashboard()
        UpdateProfit()
        lblDateRange.Text = "Showing: " & dtpFrom.Value.ToString("dd MMM yyyy") & " - " & dtpTo.Value.ToString("dd MMM yyyy")
        UpdateProductSold()
        UpdatePatientCount()
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        UpdateDashboard()
        UpdateProfit()
        lblDateRange.Text = "Showing: " & dtpFrom.Value.ToString("dd MMM yyyy") & " - " & dtpTo.Value.ToString("dd MMM yyyy")
        UpdateProductSold()
        UpdatePatientCount()
    End Sub

    Private Sub UpdateDashboard(Optional showAll As Boolean = False)
        Dim fromDate As Date = Date.Now
        Dim toDate As Date = Date.Now
        Try
            fromDate = dtpFrom.Value.Date
            toDate = dtpTo.Value.Date
        Catch
            ' in case datepickers are not ready yet
        End Try


        If Not showAll AndAlso fromDate > toDate Then Return

        If showAll Then
            ' Show all-time sales and top products
            LoadSalesChart(Nothing, Nothing, True)
            LoadTopSellingProducts(Nothing, Nothing, True)
        Else
            LoadSalesChart(fromDate, toDate)
            LoadTopSellingProducts(fromDate, toDate)
        End If
    End Sub

    Private Sub LoadSalesChart(fromDate As Date, toDate As Date, Optional showAll As Boolean = False)
        chartSales.Series.Clear()
        chartSales.ChartAreas.Clear()

        Dim salesArea As New ChartArea("SalesArea")
        salesArea.AxisX.MajorGrid.Enabled = False
        salesArea.AxisY.MajorGrid.Enabled = False
        salesArea.BackColor = Color.White
        chartSales.ChartAreas.Add(salesArea)

        Dim series As New Series("Sales") With {
            .ChartType = SeriesChartType.Line,
            .BorderWidth = 3,
            .Color = Color.Goldenrod,
            .IsValueShownAsLabel = True,
            .LabelForeColor = Color.Black,
            .LabelFormat = "₱#,##0.00"
        }
        chartSales.Series.Add(series)

        Dim sql As String = "SELECT DATE(transactionDate) AS periodKey, SUM(totalAmount) AS totalSales FROM tbl_transactions"
        If Not showAll Then
            sql &= " WHERE transactionDate BETWEEN ? AND ?"
        End If
        sql &= " GROUP BY DATE(transactionDate) ORDER BY DATE(transactionDate)"

        Try
            dbConn()
            Using cmd As New OdbcCommand(sql, conn)
                If Not showAll Then
                    cmd.Parameters.AddWithValue("?", fromDate.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("?", toDate.ToString("yyyy-MM-dd"))
                End If
                Using rdr As OdbcDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim d As Date = Convert.ToDateTime(rdr("periodKey"))
                        Dim amt As Decimal = Convert.ToDecimal(rdr("totalSales"))
                        series.Points.AddXY(d.ToString("dd/MM/yyyy"), amt)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Sales Chart Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub LoadTopSellingProducts(fromDate As Date, toDate As Date, Optional showAll As Boolean = False)
        chartTopProducts.Series.Clear()
        chartTopProducts.ChartAreas.Clear()

        Dim chartArea As New ChartArea("TopProductsArea")
        With chartArea.AxisX
            .MajorGrid.Enabled = False
            .LabelStyle.Angle = 0
            .LabelStyle.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            .IsLabelAutoFit = False
        End With
        chartArea.AxisY.MajorGrid.Enabled = False
        chartArea.BackColor = Color.White
        chartTopProducts.ChartAreas.Add(chartArea)

        Dim series As New Series("Top Products") With {
            .ChartType = SeriesChartType.Column,
            .Color = Color.SeaGreen,
            .BorderWidth = 2
        }
        chartTopProducts.Series.Add(series)

        Dim sql As String = "SELECT ti.productName, SUM(ti.quantity) AS totalSold " &
                            "FROM tbl_transaction_items ti " &
                            "INNER JOIN tbl_transactions t ON ti.transactionID = t.transactionID"
        If Not showAll Then
            sql &= " WHERE t.transactionDate BETWEEN ? AND ?"
        End If
        sql &= " GROUP BY ti.productName ORDER BY totalSold DESC LIMIT 5"

        Try
            dbConn()
            Using cmd As New OdbcCommand(sql, conn)
                If Not showAll Then
                    cmd.Parameters.AddWithValue("?", fromDate.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("?", toDate.ToString("yyyy-MM-dd"))
                End If
                Using rdr As OdbcDataReader = cmd.ExecuteReader()
                    While rdr.Read()
                        series.Points.AddXY(rdr("productName").ToString(), Convert.ToInt32(rdr("totalSold")))
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Top Products Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub lvwTodayAppointments_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs)
        Using headerFont As New Font("Segoe UI", 9, FontStyle.Bold)
            e.Graphics.FillRectangle(New SolidBrush(SystemColors.Control), e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.Header.Text, headerFont, e.Bounds, Color.Black)
        End Using
    End Sub

    Private Sub lvwTodayAppointments_DrawItem(sender As Object, e As DrawListViewItemEventArgs)
        e.DrawDefault = True
    End Sub

    Private Sub lvwTodayAppointments_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs)
        e.DrawDefault = True
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles txtProfit.Click

    End Sub
    Private Function GetProfit(fromDate As Date, toDate As Date, Optional showAll As Boolean = False) As Decimal
        Dim profit As Decimal = 0D

        Dim query As String
        If showAll Then
            ' Show ALL profits (no date filter)
            query = "SELECT ti.unitPrice, ti.quantity, sp.product_price " &
                    "FROM tbl_transaction_items ti " &
                    "INNER JOIN tbl_products p ON ti.productID = p.productID " &
                    "INNER JOIN tbl_supplier_products sp ON p.productID = sp.sProductID " &
                    "INNER JOIN tbl_transactions tr ON ti.transactionID = tr.transactionID"
        Else
            ' Filter by selected dates
            query = "SELECT ti.unitPrice, ti.quantity, sp.product_price " &
                    "FROM tbl_transaction_items ti " &
                    "INNER JOIN tbl_products p ON ti.productID = p.productID " &
                    "INNER JOIN tbl_supplier_products sp ON p.productID = sp.sProductID " &
                    "INNER JOIN tbl_transactions tr ON ti.transactionID = tr.transactionID " &
                    "WHERE tr.transactionDate BETWEEN ? AND ?"
        End If

        Try
            dbConn()

            Using cmd As New OdbcCommand(query, conn)
                If Not showAll Then
                    cmd.Parameters.AddWithValue("@fromDate", fromDate.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@toDate", toDate.ToString("yyyy-MM-dd"))
                End If

                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim sellingPrice As Decimal = If(IsDBNull(reader("unitPrice")), 0D, Convert.ToDecimal(reader("unitPrice")))
                        Dim supplierPrice As Decimal = If(IsDBNull(reader("product_price")), 0D, Convert.ToDecimal(reader("product_price")))
                        Dim quantity As Integer = If(IsDBNull(reader("quantity")), 0, Convert.ToInt32(reader("quantity")))

                        profit += (sellingPrice - supplierPrice) * quantity
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Profit Calculation Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

        Return profit
    End Function

    Private Sub UpdateProfit(Optional showAll As Boolean = False)
        Try
            Dim totalProfit As Decimal

            If showAll Then
                totalProfit = GetProfit(Nothing, Nothing, True)
            Else
                Dim fromDate As Date = dtpFrom.Value
                Dim toDate As Date = dtpTo.Value
                totalProfit = GetProfit(fromDate, toDate)
            End If

            ' Display ₱ sign and handle empty
            txtProfit.Text = "₱ " & Format(totalProfit, "N2")

        Catch ex As Exception
            txtProfit.Text = "₱ 0.00"
        End Try
    End Sub


    Private Sub btnResestFilter_Click(sender As Object, e As EventArgs) Handles btnResestFilter.Click
        ' Reset filters to today's date
        dtpFrom.Value = DateTime.Today
        dtpTo.Value = DateTime.Today

        ' Update dashboard components - charts show all-time, counts show today
        UpdateDashboard(True)  ' Show all-time data for charts
        UpdateProductSold(False)  ' Show today's products sold
        UpdatePatientCount()  ' Show today's patient count

        ' Keep profit as overall/all-time
        UpdateProfit(True)

        lblDateRange.Text = "Showing: All-Time Data"
    End Sub
    Private Function GetTotalProductsSold(Optional fromDate As Date? = Nothing, Optional toDate As Date? = Nothing, Optional showAll As Boolean = False) As Integer
        Dim totalSold As Integer = 0
        Dim query As String

        If showAll OrElse fromDate Is Nothing OrElse toDate Is Nothing Then
            ' Show all-time sales
            query = "SELECT SUM(ti.quantity) AS totalSold " &
                    "FROM tbl_transaction_items ti " &
                    "INNER JOIN tbl_transactions tr ON ti.transactionID = tr.transactionID"
        Else
            ' Filtered by selected dates
            query = "SELECT SUM(ti.quantity) AS totalSold " &
                    "FROM tbl_transaction_items ti " &
                    "INNER JOIN tbl_transactions tr ON ti.transactionID = tr.transactionID " &
                    "WHERE tr.transactionDate BETWEEN ? AND ?"
        End If

        Try
            dbConn()
            Using cmd As New OdbcCommand(query, conn)
                If Not showAll AndAlso fromDate IsNot Nothing AndAlso toDate IsNot Nothing Then
                    cmd.Parameters.AddWithValue("?", fromDate.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("?", toDate.Value.ToString("yyyy-MM-dd"))
                End If

                Dim result = cmd.ExecuteScalar()
                If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                    totalSold = Convert.ToInt32(result)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error calculating total products sold: " & ex.Message)
        Finally
            conn.Close()
        End Try

        Return totalSold
    End Function


    Private Sub UpdateProductSold(Optional showAll As Boolean = False)
        Try
            Dim totalSold As Integer
            If showAll Then
                totalSold = GetTotalProductsSold(showAll:=True)
            Else
                totalSold = GetTotalProductsSold(dtpFrom.Value, dtpTo.Value, False)
            End If

            ' If nothing was sold in that range, show 0
            txtProductSold.Text = totalSold.ToString("N0")

        Catch ex As Exception
            txtProductSold.Text = "0"
        End Try
    End Sub

    Private Sub pnlProductSolds_Click(sender As Object, e As EventArgs) Handles pnlProductSolds.Click
        productsSold.ShowDialog()
    End Sub
    Private Sub pnlProductSolds_MouseEnter(sender As Object, e As EventArgs) Handles pnlProductSolds.MouseEnter
        pnlProductSolds.BackColor = Color.LightGray
    End Sub

    Private Sub pnlProductSolds_MouseLeave(sender As Object, e As EventArgs) Handles pnlProductSolds.MouseLeave
        pnlProductSolds.BackColor = Color.White
    End Sub

    Private Sub pnlCritical_Click(sender As Object, e As EventArgs) Handles pnlCritical.Click
        ' Find the MainForm instance
        Dim mainForm As MainForm = Nothing
        For Each form As Form In Application.OpenForms
            If TypeOf form Is MainForm Then
                mainForm = DirectCast(form, MainForm)
                Exit For
            End If
        Next

        If mainForm IsNot Nothing Then
            ' Trigger the inventory button click to load inventory in container
            mainForm.btnInventory.PerformClick()

            ' Find the embedded inventory form inside the container and apply low-stock sort/highlight
            Dim inv As inventory = Nothing
            For Each ctrl As Control In mainForm.pnlContainer.Controls
                If TypeOf ctrl Is inventory Then
                    inv = DirectCast(ctrl, inventory)
                    Exit For
                End If
            Next
            If inv IsNot Nothing Then
                inv.ShowLowStockItems()
            End If
        End If
    End Sub

    Public Sub UpdateCriticalStockCount()
        Try
            Call dbConn()
            ' Count items where:
            ' 1. Stock is 0 (out of stock), OR
            ' 2. reorderLevel > 0 AND stock is at/below reorder level
            Dim sql As String = "SELECT COUNT(*) FROM tbl_products WHERE stockQuantity = 0 OR (reorderLevel > 0 AND stockQuantity > 0 AND stockQuantity <= reorderLevel)"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                Dim count As Object = cmd.ExecuteScalar()
                If count IsNot Nothing Then
                    lblCritical.Text = count.ToString()
                Else
                    lblCritical.Text = "0"
                End If
            End Using
        Catch ex As Exception
            lblCritical.Text = "--"
            ' Log error for debugging
            Console.WriteLine("UpdateCriticalStockCount Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' Make child controls in pnlCritical also trigger the click event
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        pnlCritical_Click(sender, e)
    End Sub

    Private Sub lblCritical_Click(sender As Object, e As EventArgs) Handles lblCritical.Click
        pnlCritical_Click(sender, e)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        pnlCritical_Click(sender, e)
    End Sub

    Private Sub pnlCritical_Paint(sender As Object, e As PaintEventArgs) Handles pnlCritical.Paint

    End Sub

    ' pnlCritical hover effects
    Private Sub pnlCritical_MouseEnter(sender As Object, e As EventArgs) Handles pnlCritical.MouseEnter
        pnlCritical.BackColor = Color.LightGray
    End Sub

    Private Sub pnlCritical_MouseLeave(sender As Object, e As EventArgs) Handles pnlCritical.MouseLeave
        pnlCritical.BackColor = Color.White
    End Sub

    ' pnlPatients click event
    Private Sub pnlPatients_Click(sender As Object, e As EventArgs) Handles pnlPatients.Click
        Dim patientTodayForm As New PatientToday()
        patientTodayForm.ShowDialog()
    End Sub

    ' pnlPatients hover effects
    Private Sub pnlPatients_MouseEnter(sender As Object, e As EventArgs) Handles pnlPatients.MouseEnter
        pnlPatients.BackColor = Color.LightGray
    End Sub

    Private Sub pnlPatients_MouseLeave(sender As Object, e As EventArgs) Handles pnlPatients.MouseLeave
        pnlPatients.BackColor = Color.White
    End Sub

    ' Make child controls in pnlPatients also trigger the click event
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        pnlPatients_Click(sender, e)
    End Sub

    Private Sub txtPatientToday_Click(sender As Object, e As EventArgs) Handles txtPatientToday.Click
        pnlPatients_Click(sender, e)
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        pnlPatients_Click(sender, e)
    End Sub

    Public Sub UpdatePatientCount()
        Try
            Call dbConn()

            ' Get date range - default to today if date pickers are not visible
            Dim fromDate As String
            Dim toDate As String

            If dtpFrom.Visible AndAlso dtpTo.Visible Then
                fromDate = dtpFrom.Value.ToString("yyyy-MM-dd")
                toDate = dtpTo.Value.ToString("yyyy-MM-dd")
            Else
                ' For Receptionist/Doctor roles, use today's date
                fromDate = DateTime.Today.ToString("yyyy-MM-dd")
                toDate = DateTime.Today.ToString("yyyy-MM-dd")
            End If

            ' SQL to count patients who either:
            ' 1. Were created within the date range (new patients)
            ' 2. Have checkup records within the date range
            ' 3. Have transaction records within the date range
            Dim sql As String = _
                "SELECT COUNT(DISTINCT patientID) AS patientCount FROM ( " & _
                "  SELECT p.patientID " & _
                "  FROM db_viewpatient p " & _
                "  WHERE DATE(p.date) BETWEEN ? AND ? " & _
                "  UNION " & _
                "  SELECT c.patientID " & _
                "  FROM db_viewcheckup c " & _
                "  WHERE DATE(c.checkupDate) BETWEEN ? AND ? " & _
                "  UNION " & _
                "  SELECT t.patientID " & _
                "  FROM tbl_transactions t " & _
                "  WHERE DATE(t.transactionDate) BETWEEN ? AND ? " & _
                ") AS combined"

            Using cmd As New OdbcCommand(sql, conn)
                ' Add parameters for all three date ranges
                cmd.Parameters.AddWithValue("?", fromDate)
                cmd.Parameters.AddWithValue("?", toDate)
                cmd.Parameters.AddWithValue("?", fromDate)
                cmd.Parameters.AddWithValue("?", toDate)
                cmd.Parameters.AddWithValue("?", fromDate)
                cmd.Parameters.AddWithValue("?", toDate)

                Dim count As Object = cmd.ExecuteScalar()
                If count IsNot Nothing Then
                    txtPatientToday.Text = count.ToString()
                Else
                    txtPatientToday.Text = "0"
                End If
            End Using

        Catch ex As Exception
            txtPatientToday.Text = "--"
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub pnlPatients_Paint(sender As Object, e As PaintEventArgs) Handles pnlPatients.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub lblDateRange_Click(sender As Object, e As EventArgs) Handles lblDateRange.Click

    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub pnlBar_Paint(sender As Object, e As PaintEventArgs) Handles pnlBar.Paint

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub pnlProfits_Paint(sender As Object, e As PaintEventArgs) Handles pnlProfits.Paint

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub txtProductSold_Click(sender As Object, e As EventArgs) Handles txtProductSold.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub pnlProductSolds_Paint(sender As Object, e As PaintEventArgs) Handles pnlProductSolds.Paint

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub chartTopProducts_Click(sender As Object, e As EventArgs) Handles chartTopProducts.Click

    End Sub

    Private Sub pnlProductSold_Paint(sender As Object, e As PaintEventArgs) Handles pnlProductSold.Paint

    End Sub

    Private Sub chartSales_Click(sender As Object, e As EventArgs) Handles chartSales.Click

    End Sub

    Private Sub pnlAnalytics_Paint(sender As Object, e As PaintEventArgs) Handles pnlAnalytics.Paint

    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub pnlDash_Paint(sender As Object, e As PaintEventArgs) Handles pnlDash.Paint

    End Sub
End Class
