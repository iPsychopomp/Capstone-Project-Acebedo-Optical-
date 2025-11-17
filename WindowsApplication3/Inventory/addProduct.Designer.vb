<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addProduct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addProduct))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlPrdct = New System.Windows.Forms.Panel()
        Me.pnlIM = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpEDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtReorder = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pnlPI = New System.Windows.Forms.Panel()
        Me.txtDescription = New System.Windows.Forms.RichTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.cmbPrdctName = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSuppliers = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbEdit = New System.Windows.Forms.PictureBox()
        Me.pbAdd = New System.Windows.Forms.PictureBox()
        Me.lblhead = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlPrdct.SuspendLayout()
        Me.pnlIM.SuspendLayout()
        Me.pnlPI.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(1307, 573)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 27)
        Me.btnCancel.TabIndex = 107
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(679, 444)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 34)
        Me.btnSave.TabIndex = 106
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlPrdct
        '
        Me.pnlPrdct.BackColor = System.Drawing.SystemColors.MenuBar
        Me.pnlPrdct.Controls.Add(Me.pnlIM)
        Me.pnlPrdct.Controls.Add(Me.pnlPI)
        Me.pnlPrdct.Controls.Add(Me.Panel1)
        Me.pnlPrdct.Controls.Add(Me.dtpDate)
        Me.pnlPrdct.Controls.Add(Me.btnCancel)
        Me.pnlPrdct.Controls.Add(Me.btnSave)
        Me.pnlPrdct.Controls.Add(Me.Label7)
        Me.pnlPrdct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrdct.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrdct.Name = "pnlPrdct"
        Me.pnlPrdct.Size = New System.Drawing.Size(815, 484)
        Me.pnlPrdct.TabIndex = 18
        '
        'pnlIM
        '
        Me.pnlIM.BackColor = System.Drawing.SystemColors.Window
        Me.pnlIM.Controls.Add(Me.Label15)
        Me.pnlIM.Controls.Add(Me.dtpEDate)
        Me.pnlIM.Controls.Add(Me.Label14)
        Me.pnlIM.Controls.Add(Me.txtDiscount)
        Me.pnlIM.Controls.Add(Me.Label8)
        Me.pnlIM.Controls.Add(Me.txtReorder)
        Me.pnlIM.Controls.Add(Me.Label16)
        Me.pnlIM.Controls.Add(Me.Label12)
        Me.pnlIM.Controls.Add(Me.Label5)
        Me.pnlIM.Controls.Add(Me.Label4)
        Me.pnlIM.Controls.Add(Me.txtUnitPrice)
        Me.pnlIM.Location = New System.Drawing.Point(12, 275)
        Me.pnlIM.Name = "pnlIM"
        Me.pnlIM.Size = New System.Drawing.Size(793, 165)
        Me.pnlIM.TabIndex = 137
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(132, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 28)
        Me.Label14.TabIndex = 131
        Me.Label14.Text = "*"
        '
        'dtpEDate
        '
        Me.dtpEDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpEDate.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEDate.Location = New System.Drawing.Point(409, 127)
        Me.dtpEDate.Name = "dtpEDate"
        Me.dtpEDate.Size = New System.Drawing.Size(352, 34)
        Me.dtpEDate.TabIndex = 136
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 28)
        Me.Label8.TabIndex = 120
        Me.Label8.Text = "Reorder Level:"
        '
        'txtReorder
        '
        Me.txtReorder.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReorder.Location = New System.Drawing.Point(28, 127)
        Me.txtReorder.Name = "txtReorder"
        Me.txtReorder.Size = New System.Drawing.Size(341, 34)
        Me.txtReorder.TabIndex = 121
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(404, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 28)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Expiration Date:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label16.Location = New System.Drawing.Point(14, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(297, 28)
        Me.Label16.TabIndex = 132
        Me.Label16.Text = "Price && Inventory Management"
        '
        'pnlPI
        '
        Me.pnlPI.BackColor = System.Drawing.SystemColors.Window
        Me.pnlPI.Controls.Add(Me.txtDescription)
        Me.pnlPI.Controls.Add(Me.Label11)
        Me.pnlPI.Controls.Add(Me.Label13)
        Me.pnlPI.Controls.Add(Me.cmbPrdctName)
        Me.pnlPI.Controls.Add(Me.Label1)
        Me.pnlPI.Controls.Add(Me.cmbSuppliers)
        Me.pnlPI.Controls.Add(Me.Label2)
        Me.pnlPI.Controls.Add(Me.Label10)
        Me.pnlPI.Controls.Add(Me.Label6)
        Me.pnlPI.Controls.Add(Me.Label9)
        Me.pnlPI.Controls.Add(Me.Label3)
        Me.pnlPI.Controls.Add(Me.cmbCategory)
        Me.pnlPI.Location = New System.Drawing.Point(12, 55)
        Me.pnlPI.Name = "pnlPI"
        Me.pnlPI.Size = New System.Drawing.Size(793, 214)
        Me.pnlPI.TabIndex = 124
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(34, 123)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(733, 87)
        Me.txtDescription.TabIndex = 135
        Me.txtDescription.Text = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label11.Location = New System.Drawing.Point(14, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(197, 28)
        Me.Label11.TabIndex = 131
        Me.Label11.Text = "Product Information"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(140, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 28)
        Me.Label13.TabIndex = 130
        Me.Label13.Text = "*"
        '
        'txtDiscount
        '
        Me.txtDiscount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscount.Location = New System.Drawing.Point(409, 55)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.Size = New System.Drawing.Size(352, 34)
        Me.txtDiscount.TabIndex = 133
        '
        'cmbPrdctName
        '
        Me.cmbPrdctName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPrdctName.FormattingEnabled = True
        Me.cmbPrdctName.Location = New System.Drawing.Point(285, 56)
        Me.cmbPrdctName.Name = "cmbPrdctName"
        Me.cmbPrdctName.Size = New System.Drawing.Size(233, 36)
        Me.cmbPrdctName.TabIndex = 134
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(404, 32)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 28)
        Me.Label15.TabIndex = 132
        Me.Label15.Text = "Discount:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 28)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Supplier Name:"
        '
        'cmbSuppliers
        '
        Me.cmbSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSuppliers.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSuppliers.FormattingEnabled = True
        Me.cmbSuppliers.Location = New System.Drawing.Point(34, 56)
        Me.cmbSuppliers.Name = "cmbSuppliers"
        Me.cmbSuppliers.Size = New System.Drawing.Size(233, 36)
        Me.cmbSuppliers.TabIndex = 125
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(103, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 28)
        Me.Label12.TabIndex = 129
        Me.Label12.Text = "*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(280, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 28)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "Product Name:"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitPrice.Location = New System.Drawing.Point(28, 55)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(341, 34)
        Me.txtUnitPrice.TabIndex = 123
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(589, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 28)
        Me.Label10.TabIndex = 127
        Me.Label10.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 28)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Unit Price:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 28)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Description:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(393, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 28)
        Me.Label9.TabIndex = 126
        Me.Label9.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(529, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 28)
        Me.Label3.TabIndex = 111
        Me.Label3.Text = "Category:"
        '
        'cmbCategory
        '
        Me.cmbCategory.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Items.AddRange(New Object() {"Frame", "Contact Lenses & Solution", "Accesories", "Lens"})
        Me.cmbCategory.Location = New System.Drawing.Point(534, 57)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(233, 36)
        Me.cmbCategory.TabIndex = 113
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.pbEdit)
        Me.Panel1.Controls.Add(Me.pbAdd)
        Me.Panel1.Controls.Add(Me.lblhead)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(815, 49)
        Me.Panel1.TabIndex = 123
        '
        'pbEdit
        '
        Me.pbEdit.Image = CType(resources.GetObject("pbEdit.Image"), System.Drawing.Image)
        Me.pbEdit.Location = New System.Drawing.Point(18, 6)
        Me.pbEdit.Name = "pbEdit"
        Me.pbEdit.Size = New System.Drawing.Size(34, 37)
        Me.pbEdit.TabIndex = 115
        Me.pbEdit.TabStop = False
        Me.pbEdit.Visible = False
        '
        'pbAdd
        '
        Me.pbAdd.Image = CType(resources.GetObject("pbAdd.Image"), System.Drawing.Image)
        Me.pbAdd.Location = New System.Drawing.Point(12, 6)
        Me.pbAdd.Name = "pbAdd"
        Me.pbAdd.Size = New System.Drawing.Size(34, 37)
        Me.pbAdd.TabIndex = 114
        Me.pbAdd.TabStop = False
        '
        'lblhead
        '
        Me.lblhead.AutoSize = True
        Me.lblhead.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhead.Location = New System.Drawing.Point(51, 12)
        Me.lblhead.Name = "lblhead"
        Me.lblhead.Size = New System.Drawing.Size(126, 28)
        Me.lblhead.TabIndex = 113
        Me.lblhead.Text = "Add Product"
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(943, 438)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(150, 32)
        Me.dtpDate.TabIndex = 119
        Me.dtpDate.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(939, 415)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 25)
        Me.Label7.TabIndex = 118
        Me.Label7.Text = "Date Added:"
        Me.Label7.Visible = False
        '
        'addProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(815, 484)
        Me.Controls.Add(Me.pnlPrdct)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "addProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        Me.pnlPrdct.ResumeLayout(False)
        Me.pnlPrdct.PerformLayout()
        Me.pnlIM.ResumeLayout(False)
        Me.pnlIM.PerformLayout()
        Me.pnlPI.ResumeLayout(False)
        Me.pnlPI.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlPrdct As System.Windows.Forms.Panel
    Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtReorder As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSuppliers As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbEdit As System.Windows.Forms.PictureBox
    Friend WithEvents pbAdd As System.Windows.Forms.PictureBox
    Friend WithEvents lblhead As System.Windows.Forms.Label
    Friend WithEvents cmbPrdctName As System.Windows.Forms.ComboBox
    Friend WithEvents dtpEDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlIM As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pnlPI As System.Windows.Forms.Panel
    Friend WithEvents txtDescription As System.Windows.Forms.RichTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
