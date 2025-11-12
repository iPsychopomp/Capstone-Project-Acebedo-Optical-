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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addPatientTransaction))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbDiscount = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAmountPaid = New System.Windows.Forms.TextBox()
        Me.cmbMode = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvSelectedProducts = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPatientName = New System.Windows.Forms.Label()
        Me.lblPatientID = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbAdd = New System.Windows.Forms.PictureBox()
        Me.pbEdit = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbLensDisc = New System.Windows.Forms.ComboBox()
        Me.txtPname = New System.Windows.Forms.TextBox()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.btnPSearch = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgvSelectedProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(536, 821)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 27)
        Me.btnCancel.TabIndex = 220
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(40, 806)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 27)
        Me.btnSave.TabIndex = 219
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(522, 670)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(151, 32)
        Me.txtTotal.TabIndex = 218
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(752, 254)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 25)
        Me.Label4.TabIndex = 217
        Me.Label4.Text = "Date:"
        Me.Label4.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(517, 506)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(147, 25)
        Me.Label11.TabIndex = 215
        Me.Label11.Text = "Frame Discount:"
        '
        'cmbDiscount
        '
        Me.cmbDiscount.BackColor = System.Drawing.Color.White
        Me.cmbDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiscount.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDiscount.FormattingEnabled = True
        Me.cmbDiscount.Items.AddRange(New Object() {"10%", "20%", "30%", "40%", "50%", "N/A"})
        Me.cmbDiscount.Location = New System.Drawing.Point(522, 534)
        Me.cmbDiscount.Name = "cmbDiscount"
        Me.cmbDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbDiscount.Size = New System.Drawing.Size(151, 33)
        Me.cmbDiscount.TabIndex = 214
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(517, 713)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 25)
        Me.Label13.TabIndex = 213
        Me.Label13.Text = "Amount Paid:"
        '
        'txtAmountPaid
        '
        Me.txtAmountPaid.BackColor = System.Drawing.Color.White
        Me.txtAmountPaid.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountPaid.Location = New System.Drawing.Point(522, 740)
        Me.txtAmountPaid.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAmountPaid.Name = "txtAmountPaid"
        Me.txtAmountPaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAmountPaid.Size = New System.Drawing.Size(151, 32)
        Me.txtAmountPaid.TabIndex = 212
        Me.txtAmountPaid.Text = "0.00"
        '
        'cmbMode
        '
        Me.cmbMode.BackColor = System.Drawing.Color.White
        Me.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMode.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMode.FormattingEnabled = True
        Me.cmbMode.Items.AddRange(New Object() {"G-cash", "Cash"})
        Me.cmbMode.Location = New System.Drawing.Point(26, 534)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.Size = New System.Drawing.Size(266, 33)
        Me.cmbMode.TabIndex = 211
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(21, 506)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(164, 25)
        Me.Label12.TabIndex = 210
        Me.Label12.Text = "Mode of Payment:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(521, 643)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 25)
        Me.Label1.TabIndex = 207
        Me.Label1.Text = "Total:"
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(756, 276)
        Me.dtpDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(215, 32)
        Me.dtpDate.TabIndex = 205
        Me.dtpDate.Visible = False
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRemove.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.Black
        Me.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove.Location = New System.Drawing.Point(515, 171)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(158, 27)
        Me.btnRemove.TabIndex = 204
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(357, 171)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(152, 27)
        Me.btnAdd.TabIndex = 203
        Me.btnAdd.Text = "Select Products"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'dgvSelectedProducts
        '
        Me.dgvSelectedProducts.AllowUserToAddRows = False
        Me.dgvSelectedProducts.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvSelectedProducts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSelectedProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSelectedProducts.BackgroundColor = System.Drawing.Color.White
        Me.dgvSelectedProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvSelectedProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSelectedProducts.ColumnHeadersHeight = 50
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSelectedProducts.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSelectedProducts.GridColor = System.Drawing.Color.Black
        Me.dgvSelectedProducts.Location = New System.Drawing.Point(-3, 210)
        Me.dgvSelectedProducts.MultiSelect = False
        Me.dgvSelectedProducts.Name = "dgvSelectedProducts"
        Me.dgvSelectedProducts.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvSelectedProducts.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSelectedProducts.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSelectedProducts.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSelectedProducts.RowTemplate.Height = 40
        Me.dgvSelectedProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSelectedProducts.Size = New System.Drawing.Size(699, 248)
        Me.dgvSelectedProducts.TabIndex = 202
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 25)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "Patient's Name:"
        '
        'txtPatientName
        '
        Me.txtPatientName.AutoSize = True
        Me.txtPatientName.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatientName.Location = New System.Drawing.Point(22, 102)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.Size = New System.Drawing.Size(141, 25)
        Me.txtPatientName.TabIndex = 229
        Me.txtPatientName.Text = "Patient's Name:"
        '
        'lblPatientID
        '
        Me.lblPatientID.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatientID.Location = New System.Drawing.Point(26, 97)
        Me.lblPatientID.Name = "lblPatientID"
        Me.lblPatientID.Size = New System.Drawing.Size(76, 32)
        Me.lblPatientID.TabIndex = 201
        Me.lblPatientID.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.pbAdd)
        Me.Panel1.Controls.Add(Me.pbEdit)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(696, 49)
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(517, 576)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 25)
        Me.Label3.TabIndex = 232
        Me.Label3.Text = "Lens Discount:"
        '
        'cmbLensDisc
        '
        Me.cmbLensDisc.BackColor = System.Drawing.Color.White
        Me.cmbLensDisc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLensDisc.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLensDisc.FormattingEnabled = True
        Me.cmbLensDisc.Items.AddRange(New Object() {"10%", "20%", "30%", "40%", "50%", "N/A"})
        Me.cmbLensDisc.Location = New System.Drawing.Point(522, 607)
        Me.cmbLensDisc.Name = "cmbLensDisc"
        Me.cmbLensDisc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbLensDisc.Size = New System.Drawing.Size(151, 33)
        Me.cmbLensDisc.TabIndex = 231
        '
        'txtPname
        '
        Me.txtPname.Location = New System.Drawing.Point(26, 102)
        Me.txtPname.Name = "txtPname"
        Me.txtPname.Size = New System.Drawing.Size(494, 34)
        Me.txtPname.TabIndex = 234
        '
        'cmbType
        '
        Me.cmbType.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(27, 171)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(308, 33)
        Me.cmbType.TabIndex = 237
        '
        'btnPSearch
        '
        Me.btnPSearch.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnPSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPSearch.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPSearch.ForeColor = System.Drawing.Color.Black
        Me.btnPSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPSearch.Location = New System.Drawing.Point(526, 102)
        Me.btnPSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPSearch.Name = "btnPSearch"
        Me.btnPSearch.Size = New System.Drawing.Size(147, 27)
        Me.btnPSearch.TabIndex = 238
        Me.btnPSearch.Text = "Select patient"
        Me.btnPSearch.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(153, 25)
        Me.Label8.TabIndex = 239
        Me.Label8.Text = "Transaction type:"
        '
        'txtReference
        '
        Me.txtReference.Location = New System.Drawing.Point(26, 604)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(266, 34)
        Me.txtReference.TabIndex = 240
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 576)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 25)
        Me.Label5.TabIndex = 241
        Me.Label5.Text = "Reference number:"
        '
        'addPatientTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 855)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtReference)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnPSearch)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.txtPname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbLensDisc)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtPatientName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbDiscount)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtAmountPaid)
        Me.Controls.Add(Me.cmbMode)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgvSelectedProducts)
        Me.Controls.Add(Me.lblPatientID)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "addPatientTransaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        CType(Me.dgvSelectedProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbDiscount As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAmountPaid As System.Windows.Forms.TextBox
    Friend WithEvents cmbMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgvSelectedProducts As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPatientName As System.Windows.Forms.Label
    Friend WithEvents lblPatientID As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbEdit As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbLensDisc As System.Windows.Forms.ComboBox
    Friend WithEvents pbAdd As System.Windows.Forms.PictureBox
    Friend WithEvents txtPname As System.Windows.Forms.TextBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents btnPSearch As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
