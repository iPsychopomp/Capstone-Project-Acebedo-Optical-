<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addPatientTransaction
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
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addPatientTransaction))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbDiscount = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAmountPaid = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvSelectedProducts = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbAdd = New System.Windows.Forms.PictureBox()
        Me.pbEdit = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtPatientName = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbLensDisc = New System.Windows.Forms.ComboBox()
        Me.txtPname = New System.Windows.Forms.TextBox()
        Me.btnPSearch = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.txtRefNum = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.Label()
        Me.txtTotalDiscount = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.lblGcash = New System.Windows.Forms.Label()
        Me.lblCash = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnPayment = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblPatientID = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlPPS = New System.Windows.Forms.Panel()
        Me.txtFN = New System.Windows.Forms.Label()
        Me.txtTT = New System.Windows.Forms.Label()
        Me.txtSP = New System.Windows.Forms.Label()
        Me.txtFD = New System.Windows.Forms.Label()
        Me.txtLD = New System.Windows.Forms.Label()
        Me.txtMOP = New System.Windows.Forms.Label()
        Me.txtC = New System.Windows.Forms.Label()
        Me.txtGC = New System.Windows.Forms.Label()
        Me.txtAP = New System.Windows.Forms.Label()
        Me.txtTP = New System.Windows.Forms.Label()
        Me.txtTD = New System.Windows.Forms.Label()
        Me.txtRef = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtST = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        CType(Me.dgvSelectedProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlPPS.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(1423, 675)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 34)
        Me.btnSave.TabIndex = 219
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(28, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(152, 28)
        Me.Label11.TabIndex = 215
        Me.Label11.Text = "Frame Discount:"
        '
        'cmbDiscount
        '
        Me.cmbDiscount.BackColor = System.Drawing.Color.White
        Me.cmbDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiscount.Enabled = False
        Me.cmbDiscount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDiscount.FormattingEnabled = True
        Me.cmbDiscount.Items.AddRange(New Object() {"10%", "20%", "30%", "40%", "50%", "N/A"})
        Me.cmbDiscount.Location = New System.Drawing.Point(33, 69)
        Me.cmbDiscount.Name = "cmbDiscount"
        Me.cmbDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbDiscount.Size = New System.Drawing.Size(203, 36)
        Me.cmbDiscount.TabIndex = 214
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(383, 90)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(138, 28)
        Me.Label13.TabIndex = 213
        Me.Label13.Text = "Total Payment:"
        '
        'txtAmountPaid
        '
        Me.txtAmountPaid.BackColor = System.Drawing.Color.White
        Me.txtAmountPaid.Enabled = False
        Me.txtAmountPaid.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountPaid.Location = New System.Drawing.Point(388, 117)
        Me.txtAmountPaid.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAmountPaid.Name = "txtAmountPaid"
        Me.txtAmountPaid.ReadOnly = True
        Me.txtAmountPaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAmountPaid.Size = New System.Drawing.Size(296, 34)
        Me.txtAmountPaid.TabIndex = 212
        Me.txtAmountPaid.Text = "0.00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(28, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(166, 28)
        Me.Label12.TabIndex = 210
        Me.Label12.Text = "Payment Method:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(383, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 28)
        Me.Label1.TabIndex = 207
        Me.Label1.Text = "Final Total:"
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnRemove.Enabled = False
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRemove.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.Black
        Me.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove.Location = New System.Drawing.Point(570, 136)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(129, 34)
        Me.btnRemove.TabIndex = 204
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAdd.Enabled = False
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(388, 135)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(165, 34)
        Me.btnAdd.TabIndex = 203
        Me.btnAdd.Text = "Select Products"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'dgvSelectedProducts
        '
        Me.dgvSelectedProducts.AllowUserToAddRows = False
        Me.dgvSelectedProducts.AllowUserToDeleteRows = False
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvSelectedProducts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle26
        Me.dgvSelectedProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSelectedProducts.BackgroundColor = System.Drawing.Color.White
        Me.dgvSelectedProducts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSelectedProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvSelectedProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgvSelectedProducts.ColumnHeadersHeight = 50
        Me.dgvSelectedProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column3, Me.Column5, Me.Column2, Me.Column6})
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSelectedProducts.DefaultCellStyle = DataGridViewCellStyle28
        Me.dgvSelectedProducts.GridColor = System.Drawing.Color.Black
        Me.dgvSelectedProducts.Location = New System.Drawing.Point(745, 55)
        Me.dgvSelectedProducts.MultiSelect = False
        Me.dgvSelectedProducts.Name = "dgvSelectedProducts"
        Me.dgvSelectedProducts.ReadOnly = True
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvSelectedProducts.RowHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.dgvSelectedProducts.RowHeadersVisible = False
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSelectedProducts.RowsDefaultCellStyle = DataGridViewCellStyle30
        Me.dgvSelectedProducts.RowTemplate.Height = 40
        Me.dgvSelectedProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSelectedProducts.Size = New System.Drawing.Size(773, 611)
        Me.dgvSelectedProducts.TabIndex = 202
        '
        'Column4
        '
        Me.Column4.HeaderText = "product ID"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Product Name"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Category"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column5.HeaderText = "Quantity"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.HeaderText = "Price"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 120
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column6.HeaderText = "Total"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 120
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.pbAdd)
        Me.Panel1.Controls.Add(Me.pbEdit)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Controls.Add(Me.txtPatientName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1530, 40)
        Me.Panel1.TabIndex = 230
        '
        'pbAdd
        '
        Me.pbAdd.Image = CType(resources.GetObject("pbAdd.Image"), System.Drawing.Image)
        Me.pbAdd.Location = New System.Drawing.Point(9, 8)
        Me.pbAdd.Name = "pbAdd"
        Me.pbAdd.Size = New System.Drawing.Size(34, 37)
        Me.pbAdd.TabIndex = 234
        Me.pbAdd.TabStop = False
        Me.pbAdd.Visible = False
        '
        'pbEdit
        '
        Me.pbEdit.Image = CType(resources.GetObject("pbEdit.Image"), System.Drawing.Image)
        Me.pbEdit.Location = New System.Drawing.Point(12, 8)
        Me.pbEdit.Name = "pbEdit"
        Me.pbEdit.Size = New System.Drawing.Size(31, 37)
        Me.pbEdit.TabIndex = 114
        Me.pbEdit.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(44, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(154, 28)
        Me.lblTitle.TabIndex = 113
        Me.lblTitle.Text = "Edit Transaction"
        '
        'txtPatientName
        '
        Me.txtPatientName.AutoSize = True
        Me.txtPatientName.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientName.Location = New System.Drawing.Point(435, 15)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.Size = New System.Drawing.Size(141, 25)
        Me.txtPatientName.TabIndex = 229
        Me.txtPatientName.Text = "Patient's Name:"
        Me.txtPatientName.Visible = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnBack.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.Black
        Me.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBack.Location = New System.Drawing.Point(1322, 675)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(95, 34)
        Me.btnBack.TabIndex = 253
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(394, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 28)
        Me.Label3.TabIndex = 232
        Me.Label3.Text = "Lens Discount:"
        '
        'cmbLensDisc
        '
        Me.cmbLensDisc.BackColor = System.Drawing.Color.White
        Me.cmbLensDisc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLensDisc.Enabled = False
        Me.cmbLensDisc.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLensDisc.FormattingEnabled = True
        Me.cmbLensDisc.Items.AddRange(New Object() {"10%", "20%", "30%", "40%", "50%", "N/A"})
        Me.cmbLensDisc.Location = New System.Drawing.Point(399, 69)
        Me.cmbLensDisc.Name = "cmbLensDisc"
        Me.cmbLensDisc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbLensDisc.Size = New System.Drawing.Size(300, 36)
        Me.cmbLensDisc.TabIndex = 231
        '
        'txtPname
        '
        Me.txtPname.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPname.Location = New System.Drawing.Point(33, 68)
        Me.txtPname.Name = "txtPname"
        Me.txtPname.ReadOnly = True
        Me.txtPname.Size = New System.Drawing.Size(335, 34)
        Me.txtPname.TabIndex = 234
        '
        'btnPSearch
        '
        Me.btnPSearch.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnPSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPSearch.ForeColor = System.Drawing.Color.Black
        Me.btnPSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPSearch.Location = New System.Drawing.Point(388, 67)
        Me.btnPSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPSearch.Name = "btnPSearch"
        Me.btnPSearch.Size = New System.Drawing.Size(311, 34)
        Me.btnPSearch.TabIndex = 238
        Me.btnPSearch.Text = "Select Patient"
        Me.btnPSearch.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(158, 28)
        Me.Label8.TabIndex = 239
        Me.Label8.Text = "Transaction type:"
        '
        'txtReference
        '
        Me.txtReference.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReference.Location = New System.Drawing.Point(399, 198)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.ReadOnly = True
        Me.txtReference.Size = New System.Drawing.Size(300, 34)
        Me.txtReference.TabIndex = 240
        Me.txtReference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRefNum
        '
        Me.txtRefNum.AutoSize = True
        Me.txtRefNum.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNum.Location = New System.Drawing.Point(394, 170)
        Me.txtRefNum.Name = "txtRefNum"
        Me.txtRefNum.Size = New System.Drawing.Size(173, 28)
        Me.txtRefNum.TabIndex = 241
        Me.txtRefNum.Text = "Reference number:"
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.Enabled = False
        Me.cmbType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Check-up only", "With check-up", "Items only"})
        Me.cmbType.Location = New System.Drawing.Point(33, 136)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(335, 36)
        Me.cmbType.TabIndex = 242
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 28)
        Me.Label5.TabIndex = 245
        Me.Label5.Text = "Total Discount:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 28)
        Me.Label6.TabIndex = 243
        Me.Label6.Text = "Sub Total:"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.AutoSize = True
        Me.txtSubTotal.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.Location = New System.Drawing.Point(28, 64)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(28, 28)
        Me.txtSubTotal.TabIndex = 246
        Me.txtSubTotal.Text = "--"
        '
        'txtTotalDiscount
        '
        Me.txtTotalDiscount.AutoSize = True
        Me.txtTotalDiscount.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDiscount.Location = New System.Drawing.Point(28, 120)
        Me.txtTotalDiscount.Name = "txtTotalDiscount"
        Me.txtTotalDiscount.Size = New System.Drawing.Size(28, 28)
        Me.txtTotalDiscount.TabIndex = 247
        Me.txtTotalDiscount.Text = "--"
        '
        'txtTotal
        '
        Me.txtTotal.AutoSize = True
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(383, 46)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(28, 28)
        Me.txtTotal.TabIndex = 248
        Me.txtTotal.Text = "--"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtTotal)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtTotalDiscount)
        Me.Panel2.Controls.Add(Me.txtAmountPaid)
        Me.Panel2.Controls.Add(Me.txtSubTotal)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(9, 504)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(730, 162)
        Me.Panel2.TabIndex = 249
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label4.Location = New System.Drawing.Point(14, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 28)
        Me.Label4.TabIndex = 249
        Me.Label4.Text = "Summary"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Window
        Me.Panel3.Controls.Add(Me.lblMode)
        Me.Panel3.Controls.Add(Me.lblGcash)
        Me.Panel3.Controls.Add(Me.lblCash)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.btnPayment)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.txtReference)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtRefNum)
        Me.Panel3.Controls.Add(Me.cmbLensDisc)
        Me.Panel3.Controls.Add(Me.cmbDiscount)
        Me.Panel3.Location = New System.Drawing.Point(9, 246)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(730, 252)
        Me.Panel3.TabIndex = 250
        '
        'lblMode
        '
        Me.lblMode.AutoSize = True
        Me.lblMode.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMode.Location = New System.Drawing.Point(28, 136)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(36, 28)
        Me.lblMode.TabIndex = 256
        Me.lblMode.Text = "---"
        '
        'lblGcash
        '
        Me.lblGcash.AutoSize = True
        Me.lblGcash.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGcash.Location = New System.Drawing.Point(218, 201)
        Me.lblGcash.Name = "lblGcash"
        Me.lblGcash.Size = New System.Drawing.Size(36, 28)
        Me.lblGcash.TabIndex = 255
        Me.lblGcash.Text = "---"
        '
        'lblCash
        '
        Me.lblCash.AutoSize = True
        Me.lblCash.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCash.Location = New System.Drawing.Point(28, 201)
        Me.lblCash.Name = "lblCash"
        Me.lblCash.Size = New System.Drawing.Size(36, 28)
        Me.lblCash.TabIndex = 254
        Me.lblCash.Text = "---"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(218, 170)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 28)
        Me.Label14.TabIndex = 253
        Me.Label14.Text = "G-cash:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(28, 170)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 28)
        Me.Label10.TabIndex = 252
        Me.Label10.Text = "Cash:"
        '
        'btnPayment
        '
        Me.btnPayment.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPayment.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayment.ForeColor = System.Drawing.Color.Black
        Me.btnPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPayment.Location = New System.Drawing.Point(399, 119)
        Me.btnPayment.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(300, 34)
        Me.btnPayment.TabIndex = 251
        Me.btnPayment.Text = "Add payment"
        Me.btnPayment.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label7.Location = New System.Drawing.Point(14, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(264, 28)
        Me.Label7.TabIndex = 250
        Me.Label7.Text = "Discount && Payment Details"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.Controls.Add(Me.lblPatientID)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.btnAdd)
        Me.Panel4.Controls.Add(Me.txtPname)
        Me.Panel4.Controls.Add(Me.btnPSearch)
        Me.Panel4.Controls.Add(Me.btnRemove)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.cmbType)
        Me.Panel4.Location = New System.Drawing.Point(9, 55)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(730, 185)
        Me.Panel4.TabIndex = 251
        '
        'lblPatientID
        '
        Me.lblPatientID.AutoSize = True
        Me.lblPatientID.Location = New System.Drawing.Point(218, 11)
        Me.lblPatientID.Name = "lblPatientID"
        Me.lblPatientID.Size = New System.Drawing.Size(0, 28)
        Me.lblPatientID.TabIndex = 253
        Me.lblPatientID.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 28)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Patient's Name:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label9.Location = New System.Drawing.Point(14, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(181, 28)
        Me.Label9.TabIndex = 251
        Me.Label9.Text = "Transaction Details"
        '
        'pnlPPS
        '
        Me.pnlPPS.BackColor = System.Drawing.SystemColors.Window
        Me.pnlPPS.Controls.Add(Me.txtFN)
        Me.pnlPPS.Controls.Add(Me.txtTT)
        Me.pnlPPS.Controls.Add(Me.txtSP)
        Me.pnlPPS.Controls.Add(Me.txtFD)
        Me.pnlPPS.Controls.Add(Me.txtLD)
        Me.pnlPPS.Controls.Add(Me.txtMOP)
        Me.pnlPPS.Controls.Add(Me.txtC)
        Me.pnlPPS.Controls.Add(Me.txtGC)
        Me.pnlPPS.Controls.Add(Me.txtAP)
        Me.pnlPPS.Controls.Add(Me.txtTP)
        Me.pnlPPS.Controls.Add(Me.txtTD)
        Me.pnlPPS.Controls.Add(Me.txtRef)
        Me.pnlPPS.Controls.Add(Me.Label28)
        Me.pnlPPS.Controls.Add(Me.txtST)
        Me.pnlPPS.Controls.Add(Me.Label27)
        Me.pnlPPS.Controls.Add(Me.Label26)
        Me.pnlPPS.Controls.Add(Me.Label25)
        Me.pnlPPS.Controls.Add(Me.Label24)
        Me.pnlPPS.Controls.Add(Me.Label23)
        Me.pnlPPS.Controls.Add(Me.Label22)
        Me.pnlPPS.Controls.Add(Me.Label21)
        Me.pnlPPS.Controls.Add(Me.Label20)
        Me.pnlPPS.Controls.Add(Me.Label19)
        Me.pnlPPS.Controls.Add(Me.Label18)
        Me.pnlPPS.Controls.Add(Me.Label17)
        Me.pnlPPS.Controls.Add(Me.Label16)
        Me.pnlPPS.Controls.Add(Me.Label15)
        Me.pnlPPS.Location = New System.Drawing.Point(339, 693)
        Me.pnlPPS.Name = "pnlPPS"
        Me.pnlPPS.Size = New System.Drawing.Size(600, 641)
        Me.pnlPPS.TabIndex = 252
        Me.pnlPPS.Visible = False
        '
        'txtFN
        '
        Me.txtFN.AutoSize = True
        Me.txtFN.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFN.Location = New System.Drawing.Point(296, 37)
        Me.txtFN.Name = "txtFN"
        Me.txtFN.Size = New System.Drawing.Size(28, 28)
        Me.txtFN.TabIndex = 280
        Me.txtFN.Text = "--"
        '
        'txtTT
        '
        Me.txtTT.AutoSize = True
        Me.txtTT.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTT.Location = New System.Drawing.Point(296, 73)
        Me.txtTT.Name = "txtTT"
        Me.txtTT.Size = New System.Drawing.Size(28, 28)
        Me.txtTT.TabIndex = 279
        Me.txtTT.Text = "--"
        '
        'txtSP
        '
        Me.txtSP.AutoSize = True
        Me.txtSP.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSP.Location = New System.Drawing.Point(296, 107)
        Me.txtSP.Name = "txtSP"
        Me.txtSP.Size = New System.Drawing.Size(28, 28)
        Me.txtSP.TabIndex = 278
        Me.txtSP.Text = "--"
        '
        'txtFD
        '
        Me.txtFD.AutoSize = True
        Me.txtFD.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFD.Location = New System.Drawing.Point(296, 130)
        Me.txtFD.Name = "txtFD"
        Me.txtFD.Size = New System.Drawing.Size(28, 28)
        Me.txtFD.TabIndex = 277
        Me.txtFD.Text = "--"
        '
        'txtLD
        '
        Me.txtLD.AutoSize = True
        Me.txtLD.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLD.Location = New System.Drawing.Point(296, 155)
        Me.txtLD.Name = "txtLD"
        Me.txtLD.Size = New System.Drawing.Size(28, 28)
        Me.txtLD.TabIndex = 276
        Me.txtLD.Text = "--"
        '
        'txtMOP
        '
        Me.txtMOP.AutoSize = True
        Me.txtMOP.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMOP.Location = New System.Drawing.Point(296, 179)
        Me.txtMOP.Name = "txtMOP"
        Me.txtMOP.Size = New System.Drawing.Size(28, 28)
        Me.txtMOP.TabIndex = 275
        Me.txtMOP.Text = "--"
        '
        'txtC
        '
        Me.txtC.AutoSize = True
        Me.txtC.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtC.Location = New System.Drawing.Point(296, 202)
        Me.txtC.Name = "txtC"
        Me.txtC.Size = New System.Drawing.Size(28, 28)
        Me.txtC.TabIndex = 274
        Me.txtC.Text = "--"
        '
        'txtGC
        '
        Me.txtGC.AutoSize = True
        Me.txtGC.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGC.Location = New System.Drawing.Point(296, 230)
        Me.txtGC.Name = "txtGC"
        Me.txtGC.Size = New System.Drawing.Size(28, 28)
        Me.txtGC.TabIndex = 273
        Me.txtGC.Text = "--"
        '
        'txtAP
        '
        Me.txtAP.AutoSize = True
        Me.txtAP.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAP.Location = New System.Drawing.Point(296, 366)
        Me.txtAP.Name = "txtAP"
        Me.txtAP.Size = New System.Drawing.Size(28, 28)
        Me.txtAP.TabIndex = 272
        Me.txtAP.Text = "--"
        '
        'txtTP
        '
        Me.txtTP.AutoSize = True
        Me.txtTP.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTP.Location = New System.Drawing.Point(296, 338)
        Me.txtTP.Name = "txtTP"
        Me.txtTP.Size = New System.Drawing.Size(28, 28)
        Me.txtTP.TabIndex = 271
        Me.txtTP.Text = "--"
        '
        'txtTD
        '
        Me.txtTD.AutoSize = True
        Me.txtTD.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTD.Location = New System.Drawing.Point(296, 310)
        Me.txtTD.Name = "txtTD"
        Me.txtTD.Size = New System.Drawing.Size(28, 28)
        Me.txtTD.TabIndex = 270
        Me.txtTD.Text = "--"
        '
        'txtRef
        '
        Me.txtRef.AutoSize = True
        Me.txtRef.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRef.Location = New System.Drawing.Point(296, 254)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(28, 28)
        Me.txtRef.TabIndex = 269
        Me.txtRef.Text = "--"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(19, 280)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(97, 28)
        Me.Label28.TabIndex = 267
        Me.Label28.Text = "Sub Total:"
        '
        'txtST
        '
        Me.txtST.AutoSize = True
        Me.txtST.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtST.Location = New System.Drawing.Point(296, 280)
        Me.txtST.Name = "txtST"
        Me.txtST.Size = New System.Drawing.Size(28, 28)
        Me.txtST.TabIndex = 268
        Me.txtST.Text = "--"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(19, 366)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(129, 28)
        Me.Label27.TabIndex = 266
        Me.Label27.Text = "Amount Paid:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(19, 338)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(105, 28)
        Me.Label26.TabIndex = 265
        Me.Label26.Text = "Total Price:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(19, 310)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(140, 28)
        Me.Label25.TabIndex = 264
        Me.Label25.Text = "Total Discount:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(19, 254)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(177, 28)
        Me.Label24.TabIndex = 263
        Me.Label24.Text = "Reference Number:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(19, 230)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(76, 28)
        Me.Label23.TabIndex = 262
        Me.Label23.Text = "G-cash:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(19, 202)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(57, 28)
        Me.Label22.TabIndex = 261
        Me.Label22.Text = "Cash:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(19, 179)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(171, 28)
        Me.Label21.TabIndex = 260
        Me.Label21.Text = "Mode of Payment:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(19, 155)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(136, 28)
        Me.Label20.TabIndex = 259
        Me.Label20.Text = "Lens Discount:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(19, 130)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(152, 28)
        Me.Label19.TabIndex = 258
        Me.Label19.Text = "Frame Discount:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(19, 107)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(180, 28)
        Me.Label18.TabIndex = 257
        Me.Label18.Text = "Selected Product/s:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(19, 73)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(160, 28)
        Me.Label17.TabIndex = 256
        Me.Label17.Text = "Transaction Type:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(19, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 28)
        Me.Label16.TabIndex = 255
        Me.Label16.Text = "Fullname:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label15.Location = New System.Drawing.Point(19, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(281, 28)
        Me.Label15.TabIndex = 254
        Me.Label15.Text = "Product && Payment Summary"
        '
        'addPatientTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1530, 701)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.pnlPPS)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvSelectedProducts)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "addPatientTransaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvSelectedProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlPPS.ResumeLayout(False)
        Me.pnlPPS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbDiscount As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAmountPaid As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgvSelectedProducts As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbEdit As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbLensDisc As System.Windows.Forms.ComboBox
    Friend WithEvents pbAdd As System.Windows.Forms.PictureBox
    Friend WithEvents txtPname As System.Windows.Forms.TextBox
    Friend WithEvents btnPSearch As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents txtRefNum As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.Label
    Friend WithEvents txtTotalDiscount As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPatientName As System.Windows.Forms.Label
    Friend WithEvents lblPatientID As System.Windows.Forms.Label
    Friend WithEvents lblGcash As System.Windows.Forms.Label
    Friend WithEvents lblCash As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnPayment As System.Windows.Forms.Button
    Friend WithEvents lblMode As System.Windows.Forms.Label
    Friend WithEvents pnlPPS As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtFN As System.Windows.Forms.Label
    Friend WithEvents txtTT As System.Windows.Forms.Label
    Friend WithEvents txtSP As System.Windows.Forms.Label
    Friend WithEvents txtFD As System.Windows.Forms.Label
    Friend WithEvents txtLD As System.Windows.Forms.Label
    Friend WithEvents txtMOP As System.Windows.Forms.Label
    Friend WithEvents txtC As System.Windows.Forms.Label
    Friend WithEvents txtGC As System.Windows.Forms.Label
    Friend WithEvents txtAP As System.Windows.Forms.Label
    Friend WithEvents txtTP As System.Windows.Forms.Label
    Friend WithEvents txtTD As System.Windows.Forms.Label
    Friend WithEvents txtRef As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtST As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
