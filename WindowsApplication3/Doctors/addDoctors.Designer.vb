<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addDoctors
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addDoctors))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDOB = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLname = New System.Windows.Forms.TextBox()
        Me.txtMname = New System.Windows.Forms.TextBox()
        Me.txtFirst = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbEdit = New System.Windows.Forms.PictureBox()
        Me.pbAdd = New System.Windows.Forms.PictureBox()
        Me.lblhead = New System.Windows.Forms.Label()
        Me.pnlPI = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPI.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(67, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 28)
        Me.Label7.TabIndex = 148
        Me.Label7.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(659, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 28)
        Me.Label6.TabIndex = 147
        Me.Label6.Text = "*"
        '
        'dtpDOB
        '
        Me.dtpDOB.CustomFormat = "yyyy-MM-dd"
        Me.dtpDOB.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDOB.Location = New System.Drawing.Point(23, 115)
        Me.dtpDOB.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpDOB.Name = "dtpDOB"
        Me.dtpDOB.Size = New System.Drawing.Size(228, 34)
        Me.dtpDOB.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(18, 89)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(126, 28)
        Me.Label17.TabIndex = 145
        Me.Label17.Text = "Date of Birth:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 28)
        Me.Label5.TabIndex = 144
        Me.Label5.Text = "Email:"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(23, 180)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(229, 34)
        Me.txtEmail.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(541, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(155, 28)
        Me.Label18.TabIndex = 142
        Me.Label18.Text = "Mobile Number:"
        '
        'txtMobile
        '
        Me.txtMobile.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobile.Location = New System.Drawing.Point(546, 118)
        Me.txtMobile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(229, 34)
        Me.txtMobile.TabIndex = 5
        Me.txtMobile.Text = "+63"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(641, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(20, 28)
        Me.Label15.TabIndex = 140
        Me.Label15.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(103, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 28)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(541, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 28)
        Me.Label4.TabIndex = 134
        Me.Label4.Text = "Last Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(276, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 28)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Middle Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 28)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "First Name:"
        '
        'txtLname
        '
        Me.txtLname.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLname.Location = New System.Drawing.Point(546, 53)
        Me.txtLname.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLname.Name = "txtLname"
        Me.txtLname.Size = New System.Drawing.Size(229, 34)
        Me.txtLname.TabIndex = 3
        '
        'txtMname
        '
        Me.txtMname.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMname.Location = New System.Drawing.Point(281, 53)
        Me.txtMname.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMname.Name = "txtMname"
        Me.txtMname.Size = New System.Drawing.Size(229, 34)
        Me.txtMname.TabIndex = 2
        '
        'txtFirst
        '
        Me.txtFirst.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirst.Location = New System.Drawing.Point(22, 55)
        Me.txtFirst.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(229, 34)
        Me.txtFirst.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(687, 278)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 35)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
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
        Me.Panel1.TabIndex = 130
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
        Me.lblhead.Size = New System.Drawing.Size(116, 28)
        Me.lblhead.TabIndex = 113
        Me.lblhead.Text = "Add Doctor"
        '
        'pnlPI
        '
        Me.pnlPI.BackColor = System.Drawing.SystemColors.Window
        Me.pnlPI.Controls.Add(Me.Label10)
        Me.pnlPI.Controls.Add(Me.Label9)
        Me.pnlPI.Controls.Add(Me.txtAge)
        Me.pnlPI.Controls.Add(Me.Label7)
        Me.pnlPI.Controls.Add(Me.Label8)
        Me.pnlPI.Controls.Add(Me.Label2)
        Me.pnlPI.Controls.Add(Me.Label6)
        Me.pnlPI.Controls.Add(Me.txtFirst)
        Me.pnlPI.Controls.Add(Me.Label1)
        Me.pnlPI.Controls.Add(Me.dtpDOB)
        Me.pnlPI.Controls.Add(Me.Label3)
        Me.pnlPI.Controls.Add(Me.txtMname)
        Me.pnlPI.Controls.Add(Me.Label17)
        Me.pnlPI.Controls.Add(Me.Label4)
        Me.pnlPI.Controls.Add(Me.txtLname)
        Me.pnlPI.Controls.Add(Me.Label5)
        Me.pnlPI.Controls.Add(Me.Label15)
        Me.pnlPI.Controls.Add(Me.txtEmail)
        Me.pnlPI.Controls.Add(Me.Label18)
        Me.pnlPI.Controls.Add(Me.txtMobile)
        Me.pnlPI.Location = New System.Drawing.Point(12, 55)
        Me.pnlPI.Name = "pnlPI"
        Me.pnlPI.Size = New System.Drawing.Size(791, 218)
        Me.pnlPI.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(130, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 28)
        Me.Label10.TabIndex = 151
        Me.Label10.Text = "*"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(276, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 28)
        Me.Label9.TabIndex = 150
        Me.Label9.Text = "Age:"
        '
        'txtAge
        '
        Me.txtAge.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAge.Location = New System.Drawing.Point(281, 118)
        Me.txtAge.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ReadOnly = True
        Me.txtAge.Size = New System.Drawing.Size(229, 34)
        Me.txtAge.TabIndex = 149
        Me.txtAge.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label8.Location = New System.Drawing.Point(18, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(203, 28)
        Me.Label8.TabIndex = 133
        Me.Label8.Text = "Personal Information"
        '
        'addDoctors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 323)
        Me.Controls.Add(Me.pnlPI)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "addDoctors"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPI.ResumeLayout(False)
        Me.pnlPI.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLname As System.Windows.Forms.TextBox
    Friend WithEvents txtMname As System.Windows.Forms.TextBox
    Friend WithEvents txtFirst As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents dtpDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbEdit As System.Windows.Forms.PictureBox
    Friend WithEvents pbAdd As System.Windows.Forms.PictureBox
    Friend WithEvents lblhead As System.Windows.Forms.Label
    Friend WithEvents pnlPI As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
