<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reports))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataTableTableAdapter = New WindowsApplication3.DataSet1TableAdapters.DataTableTableAdapter()
        Me.DataTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New WindowsApplication3.DataSet1()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.cboReportType = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpYear = New System.Windows.Forms.DateTimePicker()
        Me.dtpFROM = New System.Windows.Forms.DateTimePicker()
        Me.dtpTO = New System.Windows.Forms.DateTimePicker()
        CType(Me.DataTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 65)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1069, 990)
        Me.ReportViewer1.TabIndex = 0
        Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
        '
        'DataTableTableAdapter
        '
        Me.DataTableTableAdapter.ClearBeforeFill = True
        '
        'DataTableBindingSource
        '
        Me.DataTableBindingSource.DataMember = "DataTable"
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnGenerate
        '
        Me.btnGenerate.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(343, 12)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(122, 37)
        Me.btnGenerate.TabIndex = 2
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'cboReportType
        '
        Me.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReportType.FormattingEnabled = True
        Me.cboReportType.Items.AddRange(New Object() {"Critical Stocks", "Inventory", "Sales Overview", "Annual Sales", "Orders Report"})
        Me.cboReportType.Location = New System.Drawing.Point(12, 12)
        Me.cboReportType.Name = "cboReportType"
        Me.cboReportType.Size = New System.Drawing.Size(325, 36)
        Me.cboReportType.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtpYear)
        Me.Panel1.Controls.Add(Me.dtpFROM)
        Me.Panel1.Controls.Add(Me.dtpTO)
        Me.Panel1.Controls.Add(Me.cboReportType)
        Me.Panel1.Controls.Add(Me.btnGenerate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1069, 65)
        Me.Panel1.TabIndex = 3
        '
        'dtpYear
        '
        Me.dtpYear.CustomFormat = "yyyy"
        Me.dtpYear.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpYear.Location = New System.Drawing.Point(471, 14)
        Me.dtpYear.Name = "dtpYear"
        Me.dtpYear.ShowUpDown = True
        Me.dtpYear.Size = New System.Drawing.Size(201, 34)
        Me.dtpYear.TabIndex = 5
        Me.dtpYear.Visible = False
        '
        'dtpFROM
        '
        Me.dtpFROM.CustomFormat = "yyyy-MM-dd"
        Me.dtpFROM.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFROM.Location = New System.Drawing.Point(471, 14)
        Me.dtpFROM.Name = "dtpFROM"
        Me.dtpFROM.Size = New System.Drawing.Size(201, 34)
        Me.dtpFROM.TabIndex = 4
        Me.dtpFROM.Visible = False
        '
        'dtpTO
        '
        Me.dtpTO.CustomFormat = "yyyy-MM-dd"
        Me.dtpTO.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTO.Location = New System.Drawing.Point(678, 14)
        Me.dtpTO.Name = "dtpTO"
        Me.dtpTO.Size = New System.Drawing.Size(201, 34)
        Me.dtpTO.TabIndex = 3
        Me.dtpTO.Visible = False
        '
        'Reports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1069, 1055)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Reports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        CType(Me.DataTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DataTableTableAdapter As WindowsApplication3.DataSet1TableAdapters.DataTableTableAdapter
    Friend WithEvents DataTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet1 As WindowsApplication3.DataSet1
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents cboReportType As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtpFROM As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTO As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpYear As System.Windows.Forms.DateTimePicker
End Class
