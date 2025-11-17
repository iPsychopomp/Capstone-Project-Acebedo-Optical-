<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class doctors
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(doctors))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlPatientRecord = New System.Windows.Forms.Panel()
        Me.txtPage = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.doctorsDGV = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlBar = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlPatientRecord.SuspendLayout()
        CType(Me.doctorsDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPatientRecord
        '
        Me.pnlPatientRecord.BackColor = System.Drawing.Color.White
        Me.pnlPatientRecord.Controls.Add(Me.txtPage)
        Me.pnlPatientRecord.Controls.Add(Me.btnNext)
        Me.pnlPatientRecord.Controls.Add(Me.btnBack)
        Me.pnlPatientRecord.Controls.Add(Me.doctorsDGV)
        Me.pnlPatientRecord.Controls.Add(Me.pnlBar)
        Me.pnlPatientRecord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPatientRecord.Location = New System.Drawing.Point(0, 0)
        Me.pnlPatientRecord.Name = "pnlPatientRecord"
        Me.pnlPatientRecord.Size = New System.Drawing.Size(1191, 596)
        Me.pnlPatientRecord.TabIndex = 12
        '
        'txtPage
        '
        Me.txtPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtPage.AutoSize = True
        Me.txtPage.Location = New System.Drawing.Point(546, 568)
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Size = New System.Drawing.Size(70, 28)
        Me.txtPage.TabIndex = 132
        Me.txtPage.Text = "Page 1"
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNext.BackColor = System.Drawing.Color.Transparent
        Me.btnNext.FlatAppearance.BorderSize = 0
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.ForeColor = System.Drawing.Color.Black
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNext.Location = New System.Drawing.Point(653, 565)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(37, 31)
        Me.btnNext.TabIndex = 131
        Me.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnNext, "Next Page")
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.FlatAppearance.BorderSize = 0
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.Black
        Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
        Me.btnBack.Location = New System.Drawing.Point(503, 565)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(37, 31)
        Me.btnBack.TabIndex = 130
        Me.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBack, "Previous Page")
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'doctorsDGV
        '
        Me.doctorsDGV.AllowUserToAddRows = False
        Me.doctorsDGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.doctorsDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.doctorsDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.doctorsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.doctorsDGV.BackgroundColor = System.Drawing.Color.White
        Me.doctorsDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.doctorsDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.doctorsDGV.ColumnHeadersHeight = 50
        Me.doctorsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.doctorsDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column4, Me.Column6, Me.Column3, Me.Column5})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.doctorsDGV.DefaultCellStyle = DataGridViewCellStyle5
        Me.doctorsDGV.GridColor = System.Drawing.Color.Black
        Me.doctorsDGV.Location = New System.Drawing.Point(0, 57)
        Me.doctorsDGV.MultiSelect = False
        Me.doctorsDGV.Name = "doctorsDGV"
        Me.doctorsDGV.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.doctorsDGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.doctorsDGV.RowHeadersVisible = False
        Me.doctorsDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.doctorsDGV.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.doctorsDGV.RowTemplate.Height = 30
        Me.doctorsDGV.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.doctorsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.doctorsDGV.Size = New System.Drawing.Size(1191, 508)
        Me.doctorsDGV.TabIndex = 9
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.DataPropertyName = "doctorID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.FillWeight = 74.61929!
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 40
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.DataPropertyName = "fullname"
        Me.Column2.FillWeight = 281.0131!
        Me.Column2.HeaderText = "Doctor's Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 436
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column4.DataPropertyName = "dob"
        Me.Column4.HeaderText = "Date of Birth"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 120
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "contactNumber"
        Me.Column6.FillWeight = 50.0!
        Me.Column6.HeaderText = "Mobile Number"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "email"
        Me.Column3.HeaderText = "Email"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.DataPropertyName = "dateAdded"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "Date Added"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'pnlBar
        '
        Me.pnlBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlBar.Controls.Add(Me.btnSearch)
        Me.pnlBar.Controls.Add(Me.btnEdit)
        Me.pnlBar.Controls.Add(Me.btnNew)
        Me.pnlBar.Controls.Add(Me.txtSearch)
        Me.pnlBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlBar.Name = "pnlBar"
        Me.pnlBar.Size = New System.Drawing.Size(1191, 57)
        Me.pnlBar.TabIndex = 8
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(1082, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(97, 35)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSearch, "Search")
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.Black
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(99, 11)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(81, 35)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEdit, "Edit Doctor's Details")
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.White
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNew.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ForeColor = System.Drawing.Color.Black
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(12, 11)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(81, 35)
        Me.btnNew.TabIndex = 8
        Me.btnNew.Tag = ""
        Me.btnNew.Text = "Add"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnNew, "Add Doctor")
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(893, 15)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(183, 32)
        Me.txtSearch.TabIndex = 7
        '
        'doctors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 596)
        Me.Controls.Add(Me.pnlPatientRecord)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "doctors"
        Me.Text = "doctors"
        Me.pnlPatientRecord.ResumeLayout(False)
        Me.pnlPatientRecord.PerformLayout()
        CType(Me.doctorsDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBar.ResumeLayout(False)
        Me.pnlBar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlPatientRecord As System.Windows.Forms.Panel
    Friend WithEvents doctorsDGV As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBar As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtPage As System.Windows.Forms.Label
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
