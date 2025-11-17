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
        Dim DataGridViewCellStyle136 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle137 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle138 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle139 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle140 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle141 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle142 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle143 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle144 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle145 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle146 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle147 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle148 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle149 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle150 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea19 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend19 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series28 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series29 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea20 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend20 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series30 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.pnlDash = New System.Windows.Forms.Panel()
        Me.pnlStaff = New System.Windows.Forms.Panel()
        Me.dtpAppointment = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvAppointment = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDemand = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvProductAvail = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlCritical2 = New System.Windows.Forms.Panel()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.lblCritical2 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pnlPatients2 = New System.Windows.Forms.Panel()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.lblTodayPatient = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.txtAppoint = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.pnlStaff.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.dgvAppointment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDemand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProductAvail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.pnlCritical2.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPatients2.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'BackgroundWorker1
        '
        '
        'pnlDash
        '
        Me.pnlDash.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlDash.Controls.Add(Me.pnlStaff)
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
        'pnlStaff
        '
        Me.pnlStaff.Controls.Add(Me.dtpAppointment)
        Me.pnlStaff.Controls.Add(Me.btnSearch)
        Me.pnlStaff.Controls.Add(Me.txtSearch)
        Me.pnlStaff.Controls.Add(Me.Label17)
        Me.pnlStaff.Controls.Add(Me.Label10)
        Me.pnlStaff.Controls.Add(Me.Label8)
        Me.pnlStaff.Controls.Add(Me.TableLayoutPanel4)
        Me.pnlStaff.Controls.Add(Me.TableLayoutPanel3)
        Me.pnlStaff.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlStaff.Location = New System.Drawing.Point(0, 10)
        Me.pnlStaff.Name = "pnlStaff"
        Me.pnlStaff.Size = New System.Drawing.Size(1449, 686)
        Me.pnlStaff.TabIndex = 153
        Me.pnlStaff.Visible = False
        '
        'dtpAppointment
        '
        Me.dtpAppointment.CustomFormat = "yyyy-MM-dd"
        Me.dtpAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAppointment.Location = New System.Drawing.Point(1340, 232)
        Me.dtpAppointment.Name = "dtpAppointment"
        Me.dtpAppointment.Size = New System.Drawing.Size(133, 34)
        Me.dtpAppointment.TabIndex = 153
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(472, 234)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(32, 32)
        Me.btnSearch.TabIndex = 152
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(283, 237)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(183, 32)
        Me.txtSearch.TabIndex = 151
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(1026, 237)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(133, 28)
        Me.Label17.TabIndex = 150
        Me.Label17.Text = "Appointment"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(542, 237)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(166, 28)
        Me.Label10.TabIndex = 149
        Me.Label10.Text = "Product Demand"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(55, 237)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(186, 28)
        Me.Label8.TabIndex = 148
        Me.Label8.Text = "Product Availability"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.dgvAppointment, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.dgvDemand, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.dgvProductAvail, 0, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(40, 268)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 363.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1368, 403)
        Me.TableLayoutPanel4.TabIndex = 147
        '
        'dgvAppointment
        '
        Me.dgvAppointment.AllowUserToAddRows = False
        Me.dgvAppointment.AllowUserToDeleteRows = False
        DataGridViewCellStyle136.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvAppointment.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle136
        Me.dgvAppointment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAppointment.BackgroundColor = System.Drawing.Color.White
        Me.dgvAppointment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle137.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle137.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle137.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle137.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle137.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle137.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvAppointment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle137
        Me.dgvAppointment.ColumnHeadersHeight = 50
        Me.dgvAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvAppointment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        DataGridViewCellStyle138.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle138.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle138.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle138.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle138.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle138.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle138.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAppointment.DefaultCellStyle = DataGridViewCellStyle138
        Me.dgvAppointment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAppointment.GridColor = System.Drawing.Color.Black
        Me.dgvAppointment.Location = New System.Drawing.Point(932, 5)
        Me.dgvAppointment.Margin = New System.Windows.Forms.Padding(20, 5, 20, 5)
        Me.dgvAppointment.MultiSelect = False
        Me.dgvAppointment.Name = "dgvAppointment"
        Me.dgvAppointment.ReadOnly = True
        DataGridViewCellStyle139.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle139.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle139.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle139.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle139.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle139.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvAppointment.RowHeadersDefaultCellStyle = DataGridViewCellStyle139
        Me.dgvAppointment.RowHeadersVisible = False
        Me.dgvAppointment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle140.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAppointment.RowsDefaultCellStyle = DataGridViewCellStyle140
        Me.dgvAppointment.RowTemplate.Height = 30
        Me.dgvAppointment.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAppointment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAppointment.Size = New System.Drawing.Size(416, 393)
        Me.dgvAppointment.TabIndex = 12
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "patientName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Patient Name"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "appointmentDate"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Appointment Date"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 160
        '
        'dgvDemand
        '
        Me.dgvDemand.AllowUserToAddRows = False
        Me.dgvDemand.AllowUserToDeleteRows = False
        DataGridViewCellStyle141.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvDemand.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle141
        Me.dgvDemand.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDemand.BackgroundColor = System.Drawing.Color.White
        Me.dgvDemand.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle142.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle142.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle142.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle142.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle142.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle142.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDemand.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle142
        Me.dgvDemand.ColumnHeadersHeight = 50
        Me.dgvDemand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDemand.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column4})
        DataGridViewCellStyle143.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle143.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle143.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle143.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle143.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle143.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle143.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDemand.DefaultCellStyle = DataGridViewCellStyle143
        Me.dgvDemand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDemand.GridColor = System.Drawing.Color.Black
        Me.dgvDemand.Location = New System.Drawing.Point(476, 5)
        Me.dgvDemand.Margin = New System.Windows.Forms.Padding(20, 5, 20, 5)
        Me.dgvDemand.MultiSelect = False
        Me.dgvDemand.Name = "dgvDemand"
        Me.dgvDemand.ReadOnly = True
        DataGridViewCellStyle144.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle144.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle144.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle144.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle144.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle144.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDemand.RowHeadersDefaultCellStyle = DataGridViewCellStyle144
        Me.dgvDemand.RowHeadersVisible = False
        Me.dgvDemand.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle145.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDemand.RowsDefaultCellStyle = DataGridViewCellStyle145
        Me.dgvDemand.RowTemplate.Height = 30
        Me.dgvDemand.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDemand.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDemand.Size = New System.Drawing.Size(416, 393)
        Me.dgvDemand.TabIndex = 11
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "productID"
        Me.Column3.HeaderText = "ID"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "productName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Product Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "totalSold"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Total Sold"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 90
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "category"
        Me.Column4.HeaderText = "Category"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'dgvProductAvail
        '
        Me.dgvProductAvail.AllowUserToAddRows = False
        Me.dgvProductAvail.AllowUserToDeleteRows = False
        DataGridViewCellStyle146.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvProductAvail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle146
        Me.dgvProductAvail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProductAvail.BackgroundColor = System.Drawing.Color.White
        Me.dgvProductAvail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle147.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle147.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle147.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle147.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle147.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle147.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvProductAvail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle147
        Me.dgvProductAvail.ColumnHeadersHeight = 50
        Me.dgvProductAvail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProductAvail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        DataGridViewCellStyle148.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle148.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle148.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle148.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle148.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle148.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle148.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductAvail.DefaultCellStyle = DataGridViewCellStyle148
        Me.dgvProductAvail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductAvail.GridColor = System.Drawing.Color.Black
        Me.dgvProductAvail.Location = New System.Drawing.Point(20, 5)
        Me.dgvProductAvail.Margin = New System.Windows.Forms.Padding(20, 5, 20, 5)
        Me.dgvProductAvail.MultiSelect = False
        Me.dgvProductAvail.Name = "dgvProductAvail"
        Me.dgvProductAvail.ReadOnly = True
        DataGridViewCellStyle149.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle149.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle149.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle149.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle149.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle149.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvProductAvail.RowHeadersDefaultCellStyle = DataGridViewCellStyle149
        Me.dgvProductAvail.RowHeadersVisible = False
        Me.dgvProductAvail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle150.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvProductAvail.RowsDefaultCellStyle = DataGridViewCellStyle150
        Me.dgvProductAvail.RowTemplate.Height = 30
        Me.dgvProductAvail.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductAvail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductAvail.Size = New System.Drawing.Size(416, 393)
        Me.dgvProductAvail.TabIndex = 10
        '
        'Column1
        '
        Me.Column1.HeaderText = "Product Name"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.HeaderText = "Quantity"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 85
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.pnlCritical2, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.pnlPatients2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(40, 38)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1368, 136)
        Me.TableLayoutPanel3.TabIndex = 146
        '
        'pnlCritical2
        '
        Me.pnlCritical2.BackColor = System.Drawing.Color.White
        Me.pnlCritical2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCritical2.Controls.Add(Me.PictureBox8)
        Me.pnlCritical2.Controls.Add(Me.lblCritical2)
        Me.pnlCritical2.Controls.Add(Me.Label16)
        Me.pnlCritical2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCritical2.Location = New System.Drawing.Point(952, 5)
        Me.pnlCritical2.Margin = New System.Windows.Forms.Padding(40, 5, 40, 5)
        Me.pnlCritical2.Name = "pnlCritical2"
        Me.pnlCritical2.Size = New System.Drawing.Size(376, 126)
        Me.pnlCritical2.TabIndex = 139
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(134, 20)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(25, 38)
        Me.PictureBox8.TabIndex = 139
        Me.PictureBox8.TabStop = False
        '
        'lblCritical2
        '
        Me.lblCritical2.AutoSize = True
        Me.lblCritical2.BackColor = System.Drawing.Color.Transparent
        Me.lblCritical2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCritical2.Location = New System.Drawing.Point(189, 61)
        Me.lblCritical2.Name = "lblCritical2"
        Me.lblCritical2.Size = New System.Drawing.Size(28, 28)
        Me.lblCritical2.TabIndex = 138
        Me.lblCritical2.Text = "--"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(161, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(136, 28)
        Me.Label16.TabIndex = 137
        Me.Label16.Text = "Critical Stocks"
        '
        'pnlPatients2
        '
        Me.pnlPatients2.BackColor = System.Drawing.Color.White
        Me.pnlPatients2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPatients2.Controls.Add(Me.PictureBox7)
        Me.pnlPatients2.Controls.Add(Me.lblTodayPatient)
        Me.pnlPatients2.Controls.Add(Me.Label14)
        Me.pnlPatients2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPatients2.Location = New System.Drawing.Point(40, 5)
        Me.pnlPatients2.Margin = New System.Windows.Forms.Padding(40, 5, 40, 5)
        Me.pnlPatients2.Name = "pnlPatients2"
        Me.pnlPatients2.Size = New System.Drawing.Size(376, 126)
        Me.pnlPatients2.TabIndex = 142
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(135, 20)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(29, 38)
        Me.PictureBox7.TabIndex = 140
        Me.PictureBox7.TabStop = False
        '
        'lblTodayPatient
        '
        Me.lblTodayPatient.AutoSize = True
        Me.lblTodayPatient.BackColor = System.Drawing.Color.Transparent
        Me.lblTodayPatient.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTodayPatient.Location = New System.Drawing.Point(186, 58)
        Me.lblTodayPatient.Name = "lblTodayPatient"
        Me.lblTodayPatient.Size = New System.Drawing.Size(28, 28)
        Me.lblTodayPatient.TabIndex = 138
        Me.lblTodayPatient.Text = "--"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(163, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(143, 28)
        Me.Label14.TabIndex = 137
        Me.Label14.Text = "Patients Today"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.txtAppoint)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(496, 5)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(40, 5, 40, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(376, 126)
        Me.Panel1.TabIndex = 141
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(98, 19)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(33, 32)
        Me.PictureBox5.TabIndex = 140
        Me.PictureBox5.TabStop = False
        '
        'txtAppoint
        '
        Me.txtAppoint.AutoSize = True
        Me.txtAppoint.BackColor = System.Drawing.Color.Transparent
        Me.txtAppoint.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAppoint.Location = New System.Drawing.Point(192, 58)
        Me.txtAppoint.Name = "txtAppoint"
        Me.txtAppoint.Size = New System.Drawing.Size(28, 28)
        Me.txtAppoint.TabIndex = 138
        Me.txtAppoint.Text = "--"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(135, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(199, 28)
        Me.Label7.TabIndex = 137
        Me.Label7.Text = "Appointments today"
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
        ChartArea19.Name = "ChartArea1"
        Me.chartSales.ChartAreas.Add(ChartArea19)
        Me.chartSales.Dock = System.Windows.Forms.DockStyle.Fill
        Legend19.Name = "Legend1"
        Me.chartSales.Legends.Add(Legend19)
        Me.chartSales.Location = New System.Drawing.Point(0, 0)
        Me.chartSales.Name = "chartSales"
        Me.chartSales.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series28.ChartArea = "ChartArea1"
        Series28.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series28.Legend = "Legend1"
        Series28.Name = "Series1"
        Series29.ChartArea = "ChartArea1"
        Series29.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series29.Legend = "Legend1"
        Series29.Name = "Series2"
        Me.chartSales.Series.Add(Series28)
        Me.chartSales.Series.Add(Series29)
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
        ChartArea20.Name = "ChartArea1"
        Me.chartTopProducts.ChartAreas.Add(ChartArea20)
        Me.chartTopProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chartTopProducts.Enabled = False
        Legend20.Name = "Legend1"
        Me.chartTopProducts.Legends.Add(Legend20)
        Me.chartTopProducts.Location = New System.Drawing.Point(0, 0)
        Me.chartTopProducts.Name = "chartTopProducts"
        Me.chartTopProducts.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series30.ChartArea = "ChartArea1"
        Series30.Legend = "Legend1"
        Series30.Name = "Series1"
        Me.chartTopProducts.Series.Add(Series30)
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
        'ToolTip1
        '
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
        Me.pnlStaff.ResumeLayout(False)
        Me.pnlStaff.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.dgvAppointment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDemand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProductAvail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.pnlCritical2.ResumeLayout(False)
        Me.pnlCritical2.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPatients2.ResumeLayout(False)
        Me.pnlPatients2.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pnlStaff As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlCritical2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCritical2 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pnlPatients2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTodayPatient As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents txtAppoint As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents dtpAppointment As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvAppointment As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDemand As System.Windows.Forms.DataGridView
    Friend WithEvents dgvProductAvail As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
