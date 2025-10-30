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
        Me.txtOSCost = New System.Windows.Forms.TextBox()
        Me.txtODCost = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbOS = New System.Windows.Forms.ComboBox()
        Me.cmbOD = New System.Windows.Forms.ComboBox()
        Me.numQuantity = New System.Windows.Forms.NumericUpDown()
        Me.cmbProducts = New System.Windows.Forms.ComboBox()
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
        Me.rbonly = New System.Windows.Forms.RadioButton()
        Me.rbwith = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvSelectedProducts = New System.Windows.Forms.DataGridView()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPatientName = New System.Windows.Forms.Label()
        Me.lblPatientID = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbLensDisc = New System.Windows.Forms.ComboBox()
        Me.rbItems = New System.Windows.Forms.RadioButton()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSelectedProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtOSCost
        '
        Me.txtOSCost.BackColor = System.Drawing.Color.White
        Me.txtOSCost.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOSCost.Location = New System.Drawing.Point(493, 493)
        Me.txtOSCost.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOSCost.Name = "txtOSCost"
        Me.txtOSCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtOSCost.Size = New System.Drawing.Size(151, 32)
        Me.txtOSCost.TabIndex = 228
        '
        'txtODCost
        '
        Me.txtODCost.BackColor = System.Drawing.Color.White
        Me.txtODCost.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtODCost.Location = New System.Drawing.Point(493, 459)
        Me.txtODCost.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtODCost.Name = "txtODCost"
        Me.txtODCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtODCost.Size = New System.Drawing.Size(151, 32)
        Me.txtODCost.TabIndex = 227
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 497)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 25)
        Me.Label6.TabIndex = 226
        Me.Label6.Text = "OS Grade:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(32, 463)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 25)
        Me.Label5.TabIndex = 225
        Me.Label5.Text = "OD Grade:"
        '
        'cmbOS
        '
        Me.cmbOS.BackColor = System.Drawing.Color.White
        Me.cmbOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOS.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOS.FormattingEnabled = True
        Me.cmbOS.Items.AddRange(New Object() {"-5.00", "-4.00", "-3.00", "-2.00", "-1.00", "+1.00", "+2.00", "+3.00", "+4.00", "+5.00"})
        Me.cmbOS.Location = New System.Drawing.Point(134, 494)
        Me.cmbOS.Name = "cmbOS"
        Me.cmbOS.Size = New System.Drawing.Size(168, 33)
        Me.cmbOS.TabIndex = 224
        '
        'cmbOD
        '
        Me.cmbOD.BackColor = System.Drawing.Color.White
        Me.cmbOD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOD.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOD.FormattingEnabled = True
        Me.cmbOD.Items.AddRange(New Object() {"-5.00", "-4.00", "-3.00", "-2.00", "-1.00", "+1.00", "+2.00", "+3.00", "+4.00", "+5.00"})
        Me.cmbOD.Location = New System.Drawing.Point(134, 459)
        Me.cmbOD.Name = "cmbOD"
        Me.cmbOD.Size = New System.Drawing.Size(168, 33)
        Me.cmbOD.TabIndex = 223
        '
        'numQuantity
        '
        Me.numQuantity.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numQuantity.Location = New System.Drawing.Point(273, 144)
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(120, 32)
        Me.numQuantity.TabIndex = 222
        '
        'cmbProducts
        '
        Me.cmbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProducts.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProducts.FormattingEnabled = True
        Me.cmbProducts.Location = New System.Drawing.Point(26, 143)
        Me.cmbProducts.Name = "cmbProducts"
        Me.cmbProducts.Size = New System.Drawing.Size(241, 33)
        Me.cmbProducts.TabIndex = 221
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(544, 759)
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
        Me.btnSave.Location = New System.Drawing.Point(36, 759)
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
        Me.txtTotal.Location = New System.Drawing.Point(493, 665)
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
        Me.Label4.Location = New System.Drawing.Point(454, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 25)
        Me.Label4.TabIndex = 217
        Me.Label4.Text = "Date:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(489, 530)
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
        Me.cmbDiscount.Location = New System.Drawing.Point(493, 553)
        Me.cmbDiscount.Name = "cmbDiscount"
        Me.cmbDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbDiscount.Size = New System.Drawing.Size(151, 33)
        Me.cmbDiscount.TabIndex = 214
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(489, 699)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 25)
        Me.Label13.TabIndex = 213
        Me.Label13.Text = "Amount Paid:"
        '
        'txtAmountPaid
        '
        Me.txtAmountPaid.BackColor = System.Drawing.Color.White
        Me.txtAmountPaid.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountPaid.Location = New System.Drawing.Point(493, 723)
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
        Me.cmbMode.Location = New System.Drawing.Point(36, 679)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.Size = New System.Drawing.Size(266, 33)
        Me.cmbMode.TabIndex = 211
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(32, 656)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(164, 25)
        Me.Label12.TabIndex = 210
        Me.Label12.Text = "Mode of Payment:"
        '
        'rbonly
        '
        Me.rbonly.AutoSize = True
        Me.rbonly.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbonly.Location = New System.Drawing.Point(37, 577)
        Me.rbonly.Name = "rbonly"
        Me.rbonly.Size = New System.Drawing.Size(152, 29)
        Me.rbonly.TabIndex = 209
        Me.rbonly.TabStop = True
        Me.rbonly.Text = "check-up only"
        Me.rbonly.UseVisualStyleBackColor = True
        '
        'rbwith
        '
        Me.rbwith.AutoSize = True
        Me.rbwith.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbwith.Location = New System.Drawing.Point(36, 542)
        Me.rbwith.Name = "rbwith"
        Me.rbwith.Size = New System.Drawing.Size(152, 29)
        Me.rbwith.TabIndex = 208
        Me.rbwith.TabStop = True
        Me.rbwith.Text = "with check-up"
        Me.rbwith.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(489, 641)
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
        Me.dtpDate.Location = New System.Drawing.Point(458, 97)
        Me.dtpDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(215, 32)
        Me.dtpDate.TabIndex = 205
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRemove.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.Black
        Me.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove.Location = New System.Drawing.Point(573, 143)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(100, 27)
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
        Me.btnAdd.Location = New System.Drawing.Point(458, 143)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 27)
        Me.btnAdd.TabIndex = 203
        Me.btnAdd.Text = "Add"
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
        Me.dgvSelectedProducts.Location = New System.Drawing.Point(-3, 194)
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
        Me.dgvSelectedProducts.Size = New System.Drawing.Size(692, 248)
        Me.dgvSelectedProducts.TabIndex = 202
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(22, 74)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 25)
        Me.Label18.TabIndex = 200
        Me.Label18.Text = "ID:"
        Me.Label18.Visible = False
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
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(687, 49)
        Me.Panel1.TabIndex = 230
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 37)
        Me.PictureBox1.TabIndex = 114
        Me.PictureBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(44, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 28)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "Edit Transaction"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(490, 586)
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
        Me.cmbLensDisc.Location = New System.Drawing.Point(493, 610)
        Me.cmbLensDisc.Name = "cmbLensDisc"
        Me.cmbLensDisc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmbLensDisc.Size = New System.Drawing.Size(151, 33)
        Me.cmbLensDisc.TabIndex = 231
        '
        'rbItems
        '
        Me.rbItems.AutoSize = True
        Me.rbItems.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbItems.Location = New System.Drawing.Point(36, 612)
        Me.rbItems.Name = "rbItems"
        Me.rbItems.Size = New System.Drawing.Size(119, 29)
        Me.rbItems.TabIndex = 233
        Me.rbItems.TabStop = True
        Me.rbItems.Text = "Items only"
        Me.rbItems.UseVisualStyleBackColor = True
        '
        'addPatientTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 789)
        Me.Controls.Add(Me.rbItems)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbLensDisc)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtPatientName)
        Me.Controls.Add(Me.txtOSCost)
        Me.Controls.Add(Me.txtODCost)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbOS)
        Me.Controls.Add(Me.cmbOD)
        Me.Controls.Add(Me.numQuantity)
        Me.Controls.Add(Me.cmbProducts)
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
        Me.Controls.Add(Me.rbonly)
        Me.Controls.Add(Me.rbwith)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgvSelectedProducts)
        Me.Controls.Add(Me.lblPatientID)
        Me.Controls.Add(Me.Label18)
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
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSelectedProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOSCost As System.Windows.Forms.TextBox
    Friend WithEvents txtODCost As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbOS As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOD As System.Windows.Forms.ComboBox
    Friend WithEvents numQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbProducts As System.Windows.Forms.ComboBox
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
    Friend WithEvents rbonly As System.Windows.Forms.RadioButton
    Friend WithEvents rbwith As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgvSelectedProducts As System.Windows.Forms.DataGridView
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPatientName As System.Windows.Forms.Label
    Friend WithEvents lblPatientID As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbLensDisc As System.Windows.Forms.ComboBox
    Friend WithEvents rbItems As System.Windows.Forms.RadioButton
End Class
