Imports System.Data.Odbc
Imports Microsoft.Reporting.WinForms
Imports System.Linq

Public Class Reports
    Private connectionString As String = "Dsn=dsnsystem;Uid=root;Pwd=;"

    Private Sub Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboReportType.SelectedIndex = 0
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.PageWidth
        ReportViewer1.ZoomPercent = 100
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            ReportViewer1.Reset()
            ReportViewer1.LocalReport.DataSources.Clear()

            LoadSelectedReport()

            With ReportViewer1
                .SetDisplayMode(DisplayMode.PrintLayout)
                .ZoomMode = ZoomMode.Percent
                .ZoomPercent = 100
            End With
        Catch ex As LocalProcessingException
            MessageBox.Show("Report processing error: " & ex.Message, "Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Unexpected error: " & ex.Message, "Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub LoadSelectedReport()
        Try
            Select Case cboReportType.SelectedItem.ToString()
                Case "Patient Information"
                    ShowPatientReport()
                Case "Inventory"
                    ShowInventoryReport()
                Case "Sales Overview"
                    ShowSalesReport()
                Case "Critical Stocks"
                    ShowCriticalStocks()
                Case "Annual Sales"
                    ShowAnnualSalesReport()
                Case "Order Products"
                    ShowPrintOrderProducts()
                Case "Orders Report"
                    ShowOrderReports()
                Case Else
                    MessageBox.Show("Please select a valid report type.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select
        Catch ex As Exception
            MessageBox.Show("Error loading report: " & ex.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' -----------------------------
    '       REPORT LOADERS
    ' -----------------------------

    Private Sub ShowPatientReport()
        Dim data = GetPatientData(connectionString)
        If data.Rows.Count = 0 Then
            MessageBox.Show("No patient data found.", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim reportPath As String = IO.Path.Combine(Application.StartupPath, "RDLC", "PatientInfo.rdlc")
        SetupSingleReport(reportPath, "DataSet1", data)
    End Sub

    Private Sub ShowInventoryReport()
        Dim data = GetInventoryData(connectionString)
        If data.Rows.Count = 0 Then
            MessageBox.Show("No inventory data found.", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim reportPath As String = IO.Path.Combine(Application.StartupPath, "RDLC", "InventoryReport.rdlc")
        SetupSingleReport(reportPath, "DataSet2", data)
    End Sub

    Private Sub ShowSalesReport()
        Dim fromDate As Date = dtpFROM.Value.Date
        Dim toDate As Date = dtpTO.Value.Date.AddDays(1).AddSeconds(-1)
        Dim data = GetSalesOverviewData(connectionString, fromDate, toDate)

        If data.Rows.Count = 0 Then
            MessageBox.Show("No sales data found for the selected date range.", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim reportPath As String = IO.Path.Combine(Application.StartupPath, "RDLC", "salesReport.rdlc")
        SetupSingleReport(reportPath, "DataSet3", data)
    End Sub

    Private Sub ShowAnnualSalesReport()
        Dim selectedYear As Integer = dtpYear.Value.Year
        Dim data = GetAnnualSales(connectionString, selectedYear)

        If data.Rows.Count = 0 Then
            MessageBox.Show("No sales data found for year " & selectedYear, "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim reportPath As String = IO.Path.Combine(Application.StartupPath, "RDLC", "annualSales.rdlc")
        SetupSingleReport(reportPath, "DataSet5", data)
    End Sub

    Private Sub ShowCriticalStocks()
        Dim data = GetCriticalStocksData(connectionString)
        If data.Rows.Count = 0 Then
            MessageBox.Show("No critical stock data found.", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim reportPath As String = IO.Path.Combine(Application.StartupPath, "RDLC", "criticalStockReport.rdlc")
        SetupSingleReport(reportPath, "DataSet4", data)
    End Sub

    Private Sub ShowPrintOrderProducts()
        ' You can replace this with the actual DateTime from your Order Form
        Dim latestOrderTime As DateTime = DateTime.Now  ' Example, replace as needed
        Dim data = GetPrintOrderProducts(connectionString, latestOrderTime)

        If data.Rows.Count = 0 Then
            MessageBox.Show("No order products found for the selected time.", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Path to your RDLC file for ordered products
        Dim reportPath As String = IO.Path.Combine(Application.StartupPath, "RDLC", "orderProducts.rdlc")
        SetupSingleReport(reportPath, "DataSet6", data)
    End Sub

    Private Sub ShowOrderReports()
        Dim data = GetOrderProductsAll(connectionString)
        If data.Rows.Count = 0 Then
            MessageBox.Show("No order products found.", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim reportPath As String = IO.Path.Combine(Application.StartupPath, "RDLC", "printOrders.rdlc")
        SetupSingleReport(reportPath, "DataSet7", data)
    End Sub


    ' -----------------------------
    '       SETUP REPORT
    ' -----------------------------
    Private Sub SetupSingleReport(reportPath As String, dataSetName As String, data As DataTable)
        If Not IO.File.Exists(reportPath) Then
            MessageBox.Show("Report file not found: " & reportPath, "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' Ensure the viewer is in a clean state
            ReportViewer1.Reset()

            With ReportViewer1.LocalReport
                .ReportPath = reportPath
                .DataSources.Clear()
                .DataSources.Add(New ReportDataSource(dataSetName, data))

                Try
                    Dim paramsInfo = .GetParameters()
                    If paramsInfo IsNot Nothing AndAlso paramsInfo.Count > 0 Then
                        Dim paramList As New List(Of ReportParameter)()
                        For Each p In paramsInfo
                            Dim val As String = String.Empty
                            Dim name As String = p.Name
                            Select Case name
                                Case "PreparedBy"
                                    Try
                                        Dim prepared As String = GlobalVariables.LoggedInFullName
                                        val = If(String.IsNullOrWhiteSpace(prepared), "N/A", prepared)
                                    Catch
                                        val = "N/A"
                                    End Try
                                Case "FromDate", "From", "DateFrom"
                                    If dtpFROM IsNot Nothing Then val = dtpFROM.Value.ToString("yyyy-MM-dd")
                                Case "ToDate", "To", "DateTo"
                                    If dtpTO IsNot Nothing Then val = dtpTO.Value.ToString("yyyy-MM-dd")
                                Case "Year"
                                    If dtpYear IsNot Nothing Then val = dtpYear.Value.Year.ToString()
                                Case Else
                                    val = "N/A"
                            End Select
                            paramList.Add(New ReportParameter(name, val))
                        Next
                        If paramList.Count > 0 Then .SetParameters(paramList)
                    End If
                Catch
                End Try
            End With

            With ReportViewer1
                .SetDisplayMode(DisplayMode.PrintLayout)
                .ZoomMode = ZoomMode.Percent
                .ZoomPercent = 100
                Try
                    .RefreshReport()
                Catch ex As LocalProcessingException
                    MessageBox.Show("Report rendering error: " & ex.Message, "Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("Unexpected report error: " & ex.Message, "Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End With
        Catch ex As LocalProcessingException
            MessageBox.Show("Report rendering error: " & ex.Message, "Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Unexpected report error: " & ex.Message, "Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    ' -----------------------------
    '       DATABASE FUNCTIONS
    ' -----------------------------
    Private Function GetPatientData(connString As String) As DataTable
        Dim dt As New DataTable()
        Using conn As New OdbcConnection(connString)
            Using cmd As New OdbcCommand("SELECT * FROM db_viewpatient", conn)
                conn.Open()
                Dim da As New OdbcDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Private Function GetInventoryData(connString As String) As DataTable
        Dim dt As New DataTable()
        Using conn As New OdbcConnection(connString)
            Using cmd As New OdbcCommand("SELECT * FROM db_viewinventory", conn)
                conn.Open()
                Dim da As New OdbcDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Private Function GetCriticalStocksData(connString As String) As DataTable
        Dim dt As New DataTable()
        Using conn As New OdbcConnection(connString)
            Using cmd As New OdbcCommand("SELECT * FROM db_viewcriticalstocks", conn)
                conn.Open()
                Dim da As New OdbcDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Private Function GetOrderProductsAll(connString As String) As DataTable
        Dim dt As New DataTable()
        Using conn As New OdbcConnection(connString)
            Using cmd As New OdbcCommand("SELECT * FROM db_vieworderproducts", conn)
                conn.Open()
                Dim da As New OdbcDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Private Function GetAnnualSales(connString As String, selectedYear As Integer) As DataTable
        Dim dt As New DataTable()
        Using conn As New OdbcConnection(connString)
            Dim query As String = "SELECT * FROM db_viewannualsales WHERE Year = ?"
            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.Add("?", OdbcType.Int).Value = selectedYear
                conn.Open()
                Dim da As New OdbcDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Private Function GetPrintOrderProducts(connString As String, orderDateTime As DateTime) As DataTable
        Dim dt As New DataTable()
        Using conn As New OdbcConnection(connString)
            Dim query As String = "SELECT * FROM view_printorderproducts WHERE orderDate = ?"
            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.Add("?", OdbcType.DateTime).Value = orderDateTime
                conn.Open()
                Dim da As New OdbcDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Private Function GetSalesOverviewData(connString As String, fromDate As Date, toDate As Date) As DataTable
        Dim dt As New DataTable()
        Using conn As New OdbcConnection(connString)
            Dim query As String = "SELECT * FROM db_viewsalesreport WHERE TransactionDate BETWEEN ? AND ?"
            Using cmd As New OdbcCommand(query, conn)
                cmd.Parameters.Add(New OdbcParameter("?", OdbcType.Date)).Value = fromDate
                cmd.Parameters.Add(New OdbcParameter("?", OdbcType.Date)).Value = toDate
                conn.Open()
                Dim da As New OdbcDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ' -----------------------------
    '   CONTROL VISIBILITY HANDLER
    ' -----------------------------
    Private Sub cboReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReportType.SelectedIndexChanged
        dtpFROM.Visible = (cboReportType.SelectedItem.ToString() = "Sales Overview")
        dtpTO.Visible = (cboReportType.SelectedItem.ToString() = "Sales Overview")
        dtpYear.Visible = (cboReportType.SelectedItem.ToString() = "Annual Sales")
    End Sub
    ' === Public method for external call from Order Form ===
    Public Sub GenerateOrderProductReport(orderDateTime As DateTime)
        Try
            ' Retrieve order product data for the specific orderDateTime
            Dim data = GetPrintOrderProducts(connectionString, orderDateTime)

            If data Is Nothing OrElse data.Rows.Count = 0 Then
                MessageBox.Show("No data found for the selected order.", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Path to your RDLC report file
            Dim reportPath As String = IO.Path.Combine(Application.StartupPath, "RDLC", "orderProducts.rdlc")

            ' Use DataSet name that matches your RDLC (e.g., DataSet6)
            SetupSingleReport(reportPath, "DataSet6", data)
        Catch ex As Exception
            MessageBox.Show("Error generating order product report: " & ex.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
