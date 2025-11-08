<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dashboard))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.pnlDash = New System.Windows.Forms.Panel()
        Me.lblDateRange = New System.Windows.Forms.Label()
        Me.btnResestFilter = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlAnalytics = New System.Windows.Forms.Panel()
        Me.chartSales = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.pnlProductSold = New System.Windows.Forms.Panel()
        Me.chartTopProducts = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlProductSolds = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtProductSold = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlProfits = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtProfit = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlPatients = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.txtPatientToday = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlCritical = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblCritical = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlBar = New System.Windows.Forms.Panel()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlDash.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnlAnalytics.SuspendLayout()
        CType(Me.chartSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProductSold.SuspendLayout()
        CType(Me.chartTopProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlProductSolds.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProfits.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPatients.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCritical.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDash
        '
        Me.pnlDash.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlDash.Controls.Add(Me.lblDateRange)
        Me.pnlDash.Controls.Add(Me.btnResestFilter)
        Me.pnlDash.Controls.Add(Me.Label4)
        Me.pnlDash.Controls.Add(Me.Label1)
        Me.pnlDash.Controls.Add(Me.Label3)
        Me.pnlDash.Controls.Add(Me.Label2)
        Me.pnlDash.Controls.Add(Me.TableLayoutPanel2)
        Me.pnlDash.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlDash.Controls.Add(Me.pnlBar)
        Me.pnlDash.Controls.Add(Me.dtpFrom)
        Me.pnlDash.Controls.Add(Me.dtpTo)
        Me.pnlDash.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDash.Location = New System.Drawing.Point(0, 0)
        Me.pnlDash.Name = "pnlDash"
        Me.pnlDash.Size = New System.Drawing.Size(1449, 696)
        Me.pnlDash.TabIndex = 0
        '
        'lblDateRange
        '
        Me.lblDateRange.AutoSize = True
        Me.lblDateRange.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateRange.Location = New System.Drawing.Point(1230, 34)
        Me.lblDateRange.Name = "lblDateRange"
        Me.lblDateRange.Size = New System.Drawing.Size(71, 28)
        Me.lblDateRange.TabIndex = 152
        Me.lblDateRange.Text = "Label6"
        '
        'btnResestFilter
        '
        Me.btnResestFilter.BackColor = System.Drawing.Color.Transparent
        Me.btnResestFilter.FlatAppearance.BorderSize = 0
        Me.btnResestFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResestFilter.Image = CType(resources.GetObject("btnResestFilter.Image"), System.Drawing.Image)
        Me.btnResestFilter.Location = New System.Drawing.Point(457, 14)
        Me.btnResestFilter.Name = "btnResestFilter"
        Me.btnResestFilter.Size = New System.Drawing.Size(48, 44)
        Me.btnResestFilter.TabIndex = 151
        Me.ToolTip1.SetToolTip(Me.btnResestFilter, "Reset date to all-time high")
        Me.btnResestFilter.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(262, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 28)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "To:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 28)
        Me.Label1.TabIndex = 149
        Me.Label1.Text = "From:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 215)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 28)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "Total Revenue"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(777, 215)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 28)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "Top Products Sold"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.pnlAnalytics, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.pnlProductSold, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 246)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1449, 435)
        Me.TableLayoutPanel2.TabIndex = 146
        '
        'pnlAnalytics
        '
        Me.pnlAnalytics.Controls.Add(Me.chartSales)
        Me.pnlAnalytics.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAnalytics.Location = New System.Drawing.Point(40, 5)
        Me.pnlAnalytics.Margin = New System.Windows.Forms.Padding(40, 5, 20, 5)
        Me.pnlAnalytics.Name = "pnlAnalytics"
        Me.pnlAnalytics.Size = New System.Drawing.Size(664, 425)
        Me.pnlAnalytics.TabIndex = 0
        '
        'chartSales
        '
        Me.chartSales.BorderlineColor = System.Drawing.Color.Black
        Me.chartSales.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.Name = "ChartArea1"
        Me.chartSales.ChartAreas.Add(ChartArea1)
        Me.chartSales.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.chartSales.Legends.Add(Legend1)
        Me.chartSales.Location = New System.Drawing.Point(0, 0)
        Me.chartSales.Name = "chartSales"
        Me.chartSales.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Legend = "Legend1"
        Series2.Name = "Series2"
        Me.chartSales.Series.Add(Series1)
        Me.chartSales.Series.Add(Series2)
        Me.chartSales.Size = New System.Drawing.Size(664, 425)
        Me.chartSales.TabIndex = 0
        Me.chartSales.Text = "Chart1"
        '
        'pnlProductSold
        '
        Me.pnlProductSold.Controls.Add(Me.chartTopProducts)
        Me.pnlProductSold.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProductSold.Location = New System.Drawing.Point(744, 5)
        Me.pnlProductSold.Margin = New System.Windows.Forms.Padding(20, 5, 40, 5)
        Me.pnlProductSold.Name = "pnlProductSold"
        Me.pnlProductSold.Size = New System.Drawing.Size(665, 425)
        Me.pnlProductSold.TabIndex = 127
        '
        'chartTopProducts
        '
        Me.chartTopProducts.BorderlineColor = System.Drawing.Color.Black
        Me.chartTopProducts.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea2.Name = "ChartArea1"
        Me.chartTopProducts.ChartAreas.Add(ChartArea2)
        Me.chartTopProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartTopProducts.Enabled = False
        Legend2.Name = "Legend1"
        Me.chartTopProducts.Legends.Add(Legend2)
        Me.chartTopProducts.Location = New System.Drawing.Point(0, 0)
        Me.chartTopProducts.Name = "chartTopProducts"
        Me.chartTopProducts.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.chartTopProducts.Series.Add(Series3)
        Me.chartTopProducts.Size = New System.Drawing.Size(665, 425)
        Me.chartTopProducts.TabIndex = 0
        Me.chartTopProducts.Text = "Chart1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.pnlProductSolds, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlProfits, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlPatients, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlCritical, 3, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(40, 69)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1368, 136)
        Me.TableLayoutPanel1.TabIndex = 145
        '
        'pnlProductSolds
        '
        Me.pnlProductSolds.BackColor = System.Drawing.Color.White
        Me.pnlProductSolds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProductSolds.Controls.Add(Me.PictureBox2)
        Me.pnlProductSolds.Controls.Add(Me.txtProductSold)
        Me.pnlProductSolds.Controls.Add(Me.Label11)
        Me.pnlProductSolds.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProductSolds.Location = New System.Drawing.Point(724, 5)
        Me.pnlProductSolds.Margin = New System.Windows.Forms.Padding(40, 5, 40, 5)
        Me.pnlProductSolds.Name = "pnlProductSolds"
        Me.pnlProductSolds.Size = New System.Drawing.Size(262, 126)
        Me.pnlProductSolds.TabIndex = 141
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(73, 22)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(33, 32)
        Me.PictureBox2.TabIndex = 140
        Me.PictureBox2.TabStop = False
        '
        'txtProductSold
        '
        Me.txtProductSold.AutoSize = True
        Me.txtProductSold.BackColor = System.Drawing.Color.Transparent
        Me.txtProductSold.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductSold.Location = New System.Drawing.Point(121, 61)
        Me.txtProductSold.Name = "txtProductSold"
        Me.txtProductSold.Size = New System.Drawing.Size(28, 28)
        Me.txtProductSold.TabIndex = 138
        Me.txtProductSold.Text = "--"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(101, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(138, 28)
        Me.Label11.TabIndex = 137
        Me.Label11.Text = "Products Sold"
        '
        'pnlProfits
        '
        Me.pnlProfits.BackColor = System.Drawing.Color.White
        Me.pnlProfits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProfits.Controls.Add(Me.PictureBox3)
        Me.pnlProfits.Controls.Add(Me.txtProfit)
        Me.pnlProfits.Controls.Add(Me.Label9)
        Me.pnlProfits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlProfits.Location = New System.Drawing.Point(40, 5)
        Me.pnlProfits.Margin = New System.Windows.Forms.Padding(40, 5, 40, 5)
        Me.pnlProfits.Name = "pnlProfits"
        Me.pnlProfits.Size = New System.Drawing.Size(262, 126)
        Me.pnlProfits.TabIndex = 140
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(103, 21)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(29, 34)
        Me.PictureBox3.TabIndex = 141
        Me.PictureBox3.TabStop = False
        '
        'txtProfit
        '
        Me.txtProfit.AutoSize = True
        Me.txtProfit.BackColor = System.Drawing.Color.Transparent
        Me.txtProfit.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProfit.Location = New System.Drawing.Point(100, 58)
        Me.txtProfit.Name = "txtProfit"
        Me.txtProfit.Size = New System.Drawing.Size(28, 28)
        Me.txtProfit.TabIndex = 138
        Me.txtProfit.Text = "--"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(129, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 28)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "Profit"
        '
        'pnlPatients
        '
        Me.pnlPatients.BackColor = System.Drawing.Color.White
        Me.pnlPatients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPatients.Controls.Add(Me.PictureBox4)
        Me.pnlPatients.Controls.Add(Me.txtPatientToday)
        Me.pnlPatients.Controls.Add(Me.Label13)
        Me.pnlPatients.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPatients.Location = New System.Drawing.Point(382, 5)
        Me.pnlPatients.Margin = New System.Windows.Forms.Padding(40, 5, 40, 5)
        Me.pnlPatients.Name = "pnlPatients"
        Me.pnlPatients.Size = New System.Drawing.Size(262, 126)
        Me.pnlPatients.TabIndex = 142
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(78, 20)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(29, 38)
        Me.PictureBox4.TabIndex = 140
        Me.PictureBox4.TabStop = False
        '
        'txtPatientToday
        '
        Me.txtPatientToday.AutoSize = True
        Me.txtPatientToday.BackColor = System.Drawing.Color.Transparent
        Me.txtPatientToday.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientToday.Location = New System.Drawing.Point(129, 58)
        Me.txtPatientToday.Name = "txtPatientToday"
        Me.txtPatientToday.Size = New System.Drawing.Size(28, 28)
        Me.txtPatientToday.TabIndex = 138
        Me.txtPatientToday.Text = "--"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(106, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(143, 28)
        Me.Label13.TabIndex = 137
        Me.Label13.Text = "Patients Today"
        '
        'pnlCritical
        '
        Me.pnlCritical.BackColor = System.Drawing.Color.White
        Me.pnlCritical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCritical.Controls.Add(Me.PictureBox1)
        Me.pnlCritical.Controls.Add(Me.lblCritical)
        Me.pnlCritical.Controls.Add(Me.Label5)
        Me.pnlCritical.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCritical.Location = New System.Drawing.Point(1066, 5)
        Me.pnlCritical.Margin = New System.Windows.Forms.Padding(40, 5, 40, 5)
        Me.pnlCritical.Name = "pnlCritical"
        Me.pnlCritical.Size = New System.Drawing.Size(262, 126)
        Me.pnlCritical.TabIndex = 139
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(75, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 38)
        Me.PictureBox1.TabIndex = 139
        Me.PictureBox1.TabStop = False
        '
        'lblCritical
        '
        Me.lblCritical.AutoSize = True
        Me.lblCritical.BackColor = System.Drawing.Color.Transparent
        Me.lblCritical.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCritical.Location = New System.Drawing.Point(130, 61)
        Me.lblCritical.Name = "lblCritical"
        Me.lblCritical.Size = New System.Drawing.Size(28, 28)
        Me.lblCritical.TabIndex = 138
        Me.lblCritical.Text = "--"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(102, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 28)
        Me.Label5.TabIndex = 137
        Me.Label5.Text = "Critical Stocks"
        '
        'pnlBar
        '
        Me.pnlBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlBar.Name = "pnlBar"
        Me.pnlBar.Size = New System.Drawing.Size(1449, 10)
        Me.pnlBar.TabIndex = 138
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd-MMMM-yyyy"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(103, 27)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(150, 34)
        Me.dtpFrom.TabIndex = 131
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd-MMMM-yyyy"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(301, 27)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(150, 34)
        Me.dtpTo.TabIndex = 120
        '
        'dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1449, 696)
        Me.Controls.Add(Me.pnlDash)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "dashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "`````````````````````````````````````````````````````````````````````````````````" & _
    "````````````````````````````````````````````````````````````````````````````````" & _
    "```````"
        Me.pnlDash.ResumeLayout(False)
        Me.pnlDash.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.pnlAnalytics.ResumeLayout(False)
        CType(Me.chartSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProductSold.ResumeLayout(False)
        CType(Me.chartTopProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlProductSolds.ResumeLayout(False)
        Me.pnlProductSolds.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProfits.ResumeLayout(False)
        Me.pnlProfits.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPatients.ResumeLayout(False)
        Me.pnlPatients.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCritical.ResumeLayout(False)
        Me.pnlCritical.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlDash As System.Windows.Forms.Panel
    Friend WithEvents pnlAnalytics As System.Windows.Forms.Panel
    Friend WithEvents chartSales As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlProductSold As System.Windows.Forms.Panel
    Friend WithEvents chartTopProducts As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlProductSolds As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtProductSold As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnlPatients As System.Windows.Forms.Panel
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents txtPatientToday As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlProfits As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents txtProfit As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlCritical As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCritical As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDateRange As System.Windows.Forms.Label
    Friend WithEvents btnResestFilter As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlBar As System.Windows.Forms.Panel
End Class
