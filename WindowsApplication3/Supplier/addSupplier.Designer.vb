<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addSupplier
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addSupplier))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtContactNumber = New System.Windows.Forms.TextBox()
        Me.txtContactPerson = New System.Windows.Forms.TextBox()
        Me.txtSupplierName = New System.Windows.Forms.TextBox()
        Me.pnlAddUser = New System.Windows.Forms.Panel()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.pnlAddSupp = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbEdit = New System.Windows.Forms.PictureBox()
        Me.pbAdd = New System.Windows.Forms.PictureBox()
        Me.lblhead = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlAddUser.SuspendLayout
        Me.pnlAddSupp.SuspendLayout
        Me.Panel1.SuspendLayout
        CType(Me.pbEdit,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pbAdd,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(690, 216)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 35)
        Me.btnSave.TabIndex = 46
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(584, 216)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 35)
        Me.btnClear.TabIndex = 47
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        Me.btnClear.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(401, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 28)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(669, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 28)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(145, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 28)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(547, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 28)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Contact Number:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(290, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 28)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Contact Person:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 28)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Supplier Name:"
        '
        'txtContactNumber
        '
        Me.txtContactNumber.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactNumber.Location = New System.Drawing.Point(551, 54)
        Me.txtContactNumber.Name = "txtContactNumber"
        Me.txtContactNumber.Size = New System.Drawing.Size(236, 34)
        Me.txtContactNumber.TabIndex = 41
        Me.txtContactNumber.Text = "+63"
        '
        'txtContactPerson
        '
        Me.txtContactPerson.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactPerson.Location = New System.Drawing.Point(294, 54)
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.Size = New System.Drawing.Size(236, 34)
        Me.txtContactPerson.TabIndex = 40
        '
        'txtSupplierName
        '
        Me.txtSupplierName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierName.Location = New System.Drawing.Point(38, 54)
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.Size = New System.Drawing.Size(236, 34)
        Me.txtSupplierName.TabIndex = 39
        '
        'pnlAddUser
        '
        Me.pnlAddUser.BackColor = System.Drawing.SystemColors.MenuBar
        Me.pnlAddUser.Controls.Add(Me.dtpDate)
        Me.pnlAddUser.Controls.Add(Me.pnlAddSupp)
        Me.pnlAddUser.Controls.Add(Me.Panel1)
        Me.pnlAddUser.Controls.Add(Me.btnSave)
        Me.pnlAddUser.Controls.Add(Me.Label7)
        Me.pnlAddUser.Controls.Add(Me.btnClear)
        Me.pnlAddUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAddUser.Location = New System.Drawing.Point(0, 0)
        Me.pnlAddUser.Name = "pnlAddUser"
        Me.pnlAddUser.Size = New System.Drawing.Size(817, 256)
        Me.pnlAddUser.TabIndex = 25
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(238, 438)
        Me.dtpDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(154, 32)
        Me.dtpDate.TabIndex = 45
        '
        'pnlAddSupp
        '
        Me.pnlAddSupp.BackColor = System.Drawing.SystemColors.Window
        Me.pnlAddSupp.Controls.Add(Me.Label8)
        Me.pnlAddSupp.Controls.Add(Me.Label1)
        Me.pnlAddSupp.Controls.Add(Me.Label2)
        Me.pnlAddSupp.Controls.Add(Me.txtEmail)
        Me.pnlAddSupp.Controls.Add(Me.Label13)
        Me.pnlAddSupp.Controls.Add(Me.Label10)
        Me.pnlAddSupp.Controls.Add(Me.txtSupplierName)
        Me.pnlAddSupp.Controls.Add(Me.Label11)
        Me.pnlAddSupp.Controls.Add(Me.Label3)
        Me.pnlAddSupp.Controls.Add(Me.Label12)
        Me.pnlAddSupp.Controls.Add(Me.Label6)
        Me.pnlAddSupp.Controls.Add(Me.txtAddress)
        Me.pnlAddSupp.Controls.Add(Me.txtContactPerson)
        Me.pnlAddSupp.Controls.Add(Me.Label4)
        Me.pnlAddSupp.Controls.Add(Me.txtContactNumber)
        Me.pnlAddSupp.Controls.Add(Me.Label5)
        Me.pnlAddSupp.Location = New System.Drawing.Point(3, 55)
        Me.pnlAddSupp.Name = "pnlAddSupp"
        Me.pnlAddSupp.Size = New System.Drawing.Size(810, 155)
        Me.pnlAddSupp.TabIndex = 123
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label8.Location = New System.Drawing.Point(21, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(201, 28)
        Me.Label8.TabIndex = 116
        Me.Label8.Text = "Supplier Information"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(293, 112)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(236, 34)
        Me.txtEmail.TabIndex = 42
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(99, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 28)
        Me.Label13.TabIndex = 60
        Me.Label13.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(340, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 28)
        Me.Label12.TabIndex = 59
        Me.Label12.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(33, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 28)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Address:"
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(36, 112)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(236, 34)
        Me.txtAddress.TabIndex = 43
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(289, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 28)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Email:"
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
        Me.Panel1.Size = New System.Drawing.Size(817, 49)
        Me.Panel1.TabIndex = 122
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
        Me.lblhead.Size = New System.Drawing.Size(130, 28)
        Me.lblhead.TabIndex = 113
        Me.lblhead.Text = "Add Supplier"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(235, 415)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 25)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Date:"
        '
        'addSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 256)
        Me.Controls.Add(Me.pnlAddUser)
        Me.Font = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "addSupplier"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        Me.pnlAddUser.ResumeLayout(false)
        Me.pnlAddUser.PerformLayout
        Me.pnlAddSupp.ResumeLayout(false)
        Me.pnlAddSupp.PerformLayout
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        CType(Me.pbEdit,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pbAdd,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtContactNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtContactPerson As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents pnlAddUser As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbAdd As System.Windows.Forms.PictureBox
    Friend WithEvents lblhead As System.Windows.Forms.Label
    Friend WithEvents pbEdit As System.Windows.Forms.PictureBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlAddSupp As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
