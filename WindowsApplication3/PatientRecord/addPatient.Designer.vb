<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addPatient
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
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addPatient))
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpPatient = New System.Windows.Forms.GroupBox()
        Me.grpHighblood = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.hbNo = New System.Windows.Forms.RadioButton()
        Me.hbYes = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.grpDiabetic = New System.Windows.Forms.GroupBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dbNo = New System.Windows.Forms.RadioButton()
        Me.dbYes = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.cmbCity = New System.Windows.Forms.ComboBox()
        Me.cmbBgy = New System.Windows.Forms.ComboBox()
        Me.cmbProvince = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHobbies = New System.Windows.Forms.RichTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtSports = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOccu = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbRegion = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpBday = New System.Windows.Forms.DateTimePicker()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.txtLname = New System.Windows.Forms.TextBox()
        Me.txtMname = New System.Windows.Forms.TextBox()
        Me.txtFirst = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlDataEntry = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbEdit = New System.Windows.Forms.PictureBox()
        Me.pbAdd = New System.Windows.Forms.PictureBox()
        Me.lblHead = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPatient.SuspendLayout()
        Me.grpHighblood.SuspendLayout()
        Me.grpDiabetic.SuspendLayout()
        Me.pnlDataEntry.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'grpPatient
        '
        Me.grpPatient.Controls.Add(Me.grpHighblood)
        Me.grpPatient.Controls.Add(Me.grpDiabetic)
        Me.grpPatient.Controls.Add(Me.Label26)
        Me.grpPatient.Controls.Add(Me.Label25)
        Me.grpPatient.Controls.Add(Me.Label24)
        Me.grpPatient.Controls.Add(Me.Label23)
        Me.grpPatient.Controls.Add(Me.Label22)
        Me.grpPatient.Controls.Add(Me.Label21)
        Me.grpPatient.Controls.Add(Me.Label20)
        Me.grpPatient.Controls.Add(Me.Label15)
        Me.grpPatient.Controls.Add(Me.Label1)
        Me.grpPatient.Controls.Add(Me.Label19)
        Me.grpPatient.Controls.Add(Me.dtpDate)
        Me.grpPatient.Controls.Add(Me.cmbCity)
        Me.grpPatient.Controls.Add(Me.cmbBgy)
        Me.grpPatient.Controls.Add(Me.cmbProvince)
        Me.grpPatient.Controls.Add(Me.Label17)
        Me.grpPatient.Controls.Add(Me.Label16)
        Me.grpPatient.Controls.Add(Me.Label9)
        Me.grpPatient.Controls.Add(Me.txtHobbies)
        Me.grpPatient.Controls.Add(Me.Label8)
        Me.grpPatient.Controls.Add(Me.cmbGender)
        Me.grpPatient.Controls.Add(Me.Label18)
        Me.grpPatient.Controls.Add(Me.txtSports)
        Me.grpPatient.Controls.Add(Me.Label7)
        Me.grpPatient.Controls.Add(Me.Label13)
        Me.grpPatient.Controls.Add(Me.txtMobile)
        Me.grpPatient.Controls.Add(Me.Label12)
        Me.grpPatient.Controls.Add(Me.txtOccu)
        Me.grpPatient.Controls.Add(Me.Label14)
        Me.grpPatient.Controls.Add(Me.cmbRegion)
        Me.grpPatient.Controls.Add(Me.Label6)
        Me.grpPatient.Controls.Add(Me.Label5)
        Me.grpPatient.Controls.Add(Me.Label4)
        Me.grpPatient.Controls.Add(Me.Label3)
        Me.grpPatient.Controls.Add(Me.Label2)
        Me.grpPatient.Controls.Add(Me.dtpBday)
        Me.grpPatient.Controls.Add(Me.txtAge)
        Me.grpPatient.Controls.Add(Me.txtLname)
        Me.grpPatient.Controls.Add(Me.txtMname)
        Me.grpPatient.Controls.Add(Me.txtFirst)
        Me.grpPatient.Location = New System.Drawing.Point(11, 52)
        Me.grpPatient.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpPatient.Name = "grpPatient"
        Me.grpPatient.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpPatient.Size = New System.Drawing.Size(979, 476)
        Me.grpPatient.TabIndex = 0
        Me.grpPatient.TabStop = False
        '
        'grpHighblood
        '
        Me.grpHighblood.Controls.Add(Me.Label28)
        Me.grpHighblood.Controls.Add(Me.hbNo)
        Me.grpHighblood.Controls.Add(Me.hbYes)
        Me.grpHighblood.Controls.Add(Me.Label11)
        Me.grpHighblood.Location = New System.Drawing.Point(365, 377)
        Me.grpHighblood.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpHighblood.Name = "grpHighblood"
        Me.grpHighblood.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpHighblood.Size = New System.Drawing.Size(257, 79)
        Me.grpHighblood.TabIndex = 121
        Me.grpHighblood.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(233, 9)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(20, 25)
        Me.Label28.TabIndex = 126
        Me.Label28.Text = "*"
        '
        'hbNo
        '
        Me.hbNo.AutoSize = True
        Me.hbNo.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hbNo.Location = New System.Drawing.Point(133, 42)
        Me.hbNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.hbNo.Name = "hbNo"
        Me.hbNo.Size = New System.Drawing.Size(58, 29)
        Me.hbNo.TabIndex = 123
        Me.hbNo.TabStop = True
        Me.hbNo.Text = "No"
        Me.hbNo.UseVisualStyleBackColor = True
        '
        'hbYes
        '
        Me.hbYes.AutoSize = True
        Me.hbYes.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hbYes.Location = New System.Drawing.Point(49, 42)
        Me.hbYes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.hbYes.Name = "hbYes"
        Me.hbYes.Size = New System.Drawing.Size(60, 29)
        Me.hbYes.TabIndex = 124
        Me.hbYes.TabStop = True
        Me.hbYes.Text = "Yes"
        Me.hbYes.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(21, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(190, 25)
        Me.Label11.TabIndex = 89
        Me.Label11.Text = "is patient highblood?"
        '
        'grpDiabetic
        '
        Me.grpDiabetic.Controls.Add(Me.Label27)
        Me.grpDiabetic.Controls.Add(Me.dbNo)
        Me.grpDiabetic.Controls.Add(Me.dbYes)
        Me.grpDiabetic.Controls.Add(Me.Label10)
        Me.grpDiabetic.Location = New System.Drawing.Point(365, 295)
        Me.grpDiabetic.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpDiabetic.Name = "grpDiabetic"
        Me.grpDiabetic.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpDiabetic.Size = New System.Drawing.Size(257, 79)
        Me.grpDiabetic.TabIndex = 120
        Me.grpDiabetic.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(233, 10)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(20, 25)
        Me.Label27.TabIndex = 122
        Me.Label27.Text = "*"
        '
        'dbNo
        '
        Me.dbNo.AutoSize = True
        Me.dbNo.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbNo.Location = New System.Drawing.Point(133, 42)
        Me.dbNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dbNo.Name = "dbNo"
        Me.dbNo.Size = New System.Drawing.Size(58, 29)
        Me.dbNo.TabIndex = 125
        Me.dbNo.TabStop = True
        Me.dbNo.Text = "No"
        Me.dbNo.UseVisualStyleBackColor = True
        '
        'dbYes
        '
        Me.dbYes.AutoSize = True
        Me.dbYes.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbYes.Location = New System.Drawing.Point(49, 42)
        Me.dbYes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dbYes.Name = "dbYes"
        Me.dbYes.Size = New System.Drawing.Size(60, 29)
        Me.dbYes.TabIndex = 118
        Me.dbYes.TabStop = True
        Me.dbYes.Text = "Yes"
        Me.dbYes.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(44, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(170, 25)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "is patient diabetic?"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(840, 86)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(20, 25)
        Me.Label26.TabIndex = 115
        Me.Label26.Text = "*"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(471, 223)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(17, 23)
        Me.Label25.TabIndex = 114
        Me.Label25.Text = "*"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(409, 154)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(20, 25)
        Me.Label24.TabIndex = 113
        Me.Label24.Text = "*"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(451, 86)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(20, 25)
        Me.Label23.TabIndex = 112
        Me.Label23.Text = "*"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(439, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(20, 25)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "*"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(125, 361)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(20, 25)
        Me.Label21.TabIndex = 110
        Me.Label21.Text = "*"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(135, 222)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(20, 25)
        Me.Label20.TabIndex = 109
        Me.Label20.Text = "*"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(155, 154)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(20, 25)
        Me.Label15.TabIndex = 108
        Me.Label15.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(156, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 25)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "*"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(40, 361)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 25)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "Gender:"
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(675, 249)
        Me.dtpDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(151, 32)
        Me.dtpDate.TabIndex = 102
        '
        'cmbCity
        '
        Me.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCity.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCity.FormattingEnabled = True
        Me.cmbCity.Location = New System.Drawing.Point(360, 181)
        Me.cmbCity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Size = New System.Drawing.Size(257, 33)
        Me.cmbCity.TabIndex = 77
        '
        'cmbBgy
        '
        Me.cmbBgy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBgy.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBgy.FormattingEnabled = True
        Me.cmbBgy.Location = New System.Drawing.Point(360, 249)
        Me.cmbBgy.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbBgy.Name = "cmbBgy"
        Me.cmbBgy.Size = New System.Drawing.Size(257, 33)
        Me.cmbBgy.TabIndex = 78
        '
        'cmbProvince
        '
        Me.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvince.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProvince.FormattingEnabled = True
        Me.cmbProvince.Location = New System.Drawing.Point(360, 113)
        Me.cmbProvince.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbProvince.Name = "cmbProvince"
        Me.cmbProvince.Size = New System.Drawing.Size(257, 33)
        Me.cmbProvince.TabIndex = 76
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(668, 222)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 25)
        Me.Label17.TabIndex = 101
        Me.Label17.Text = "Date:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(355, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 25)
        Me.Label16.TabIndex = 99
        Me.Label16.Text = "Region:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(355, 222)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 25)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Baranggay:"
        '
        'txtHobbies
        '
        Me.txtHobbies.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHobbies.Location = New System.Drawing.Point(675, 320)
        Me.txtHobbies.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtHobbies.Name = "txtHobbies"
        Me.txtHobbies.Size = New System.Drawing.Size(253, 127)
        Me.txtHobbies.TabIndex = 98
        Me.txtHobbies.Text = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(355, 154)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 25)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "City:"
        '
        'cmbGender
        '
        Me.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGender.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Items.AddRange(New Object() {"Male", "Female", "Other"})
        Me.cmbGender.Location = New System.Drawing.Point(45, 388)
        Me.cmbGender.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(151, 33)
        Me.cmbGender.TabIndex = 105
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(668, 86)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(149, 25)
        Me.Label18.TabIndex = 104
        Me.Label18.Text = "Mobile Number:"
        '
        'txtSports
        '
        Me.txtSports.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSports.Location = New System.Drawing.Point(673, 181)
        Me.txtSports.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSports.Name = "txtSports"
        Me.txtSports.Size = New System.Drawing.Size(253, 32)
        Me.txtSports.TabIndex = 91
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(355, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 25)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "Province:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(669, 290)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 25)
        Me.Label13.TabIndex = 93
        Me.Label13.Text = "Hobbies:"
        '
        'txtMobile
        '
        Me.txtMobile.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobile.Location = New System.Drawing.Point(673, 113)
        Me.txtMobile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(253, 32)
        Me.txtMobile.TabIndex = 103
        Me.txtMobile.Text = "+63"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(669, 154)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 25)
        Me.Label12.TabIndex = 92
        Me.Label12.Text = "Sports:"
        '
        'txtOccu
        '
        Me.txtOccu.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOccu.Location = New System.Drawing.Point(675, 46)
        Me.txtOccu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOccu.Name = "txtOccu"
        Me.txtOccu.Size = New System.Drawing.Size(253, 32)
        Me.txtOccu.TabIndex = 95
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(669, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 25)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Occupation:"
        '
        'cmbRegion
        '
        Me.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRegion.FormattingEnabled = True
        Me.cmbRegion.Location = New System.Drawing.Point(360, 46)
        Me.cmbRegion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbRegion.Name = "cmbRegion"
        Me.cmbRegion.Size = New System.Drawing.Size(257, 33)
        Me.cmbRegion.TabIndex = 100
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 25)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Birthday:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 290)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 25)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Age:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 25)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Last Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 25)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Middle Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 25)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "First Name:"
        '
        'dtpBday
        '
        Me.dtpBday.CustomFormat = "yyyy-MM-dd"
        Me.dtpBday.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBday.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBday.Location = New System.Drawing.Point(45, 247)
        Me.dtpBday.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpBday.Name = "dtpBday"
        Me.dtpBday.Size = New System.Drawing.Size(151, 32)
        Me.dtpBday.TabIndex = 75
        Me.dtpBday.Value = New Date(2025, 2, 20, 0, 0, 0, 0)
        '
        'txtAge
        '
        Me.txtAge.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAge.Location = New System.Drawing.Point(45, 318)
        Me.txtAge.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ReadOnly = True
        Me.txtAge.Size = New System.Drawing.Size(97, 32)
        Me.txtAge.TabIndex = 74
        '
        'txtLname
        '
        Me.txtLname.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLname.Location = New System.Drawing.Point(45, 181)
        Me.txtLname.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLname.Name = "txtLname"
        Me.txtLname.Size = New System.Drawing.Size(257, 32)
        Me.txtLname.TabIndex = 73
        '
        'txtMname
        '
        Me.txtMname.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMname.Location = New System.Drawing.Point(45, 113)
        Me.txtMname.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMname.Name = "txtMname"
        Me.txtMname.Size = New System.Drawing.Size(257, 32)
        Me.txtMname.TabIndex = 72
        '
        'txtFirst
        '
        Me.txtFirst.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirst.Location = New System.Drawing.Point(45, 46)
        Me.txtFirst.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(257, 32)
        Me.txtFirst.TabIndex = 71
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(806, 548)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(133, 33)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(660, 548)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(133, 33)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(56, 548)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(133, 33)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'pnlDataEntry
        '
        Me.pnlDataEntry.BackColor = System.Drawing.SystemColors.MenuBar
        Me.pnlDataEntry.Controls.Add(Me.Panel1)
        Me.pnlDataEntry.Controls.Add(Me.btnCancel)
        Me.pnlDataEntry.Controls.Add(Me.btnClear)
        Me.pnlDataEntry.Controls.Add(Me.btnSave)
        Me.pnlDataEntry.Controls.Add(Me.grpPatient)
        Me.pnlDataEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDataEntry.Location = New System.Drawing.Point(0, 0)
        Me.pnlDataEntry.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlDataEntry.Name = "pnlDataEntry"
        Me.pnlDataEntry.Size = New System.Drawing.Size(1001, 604)
        Me.pnlDataEntry.TabIndex = 21
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.pbEdit)
        Me.Panel1.Controls.Add(Me.pbAdd)
        Me.Panel1.Controls.Add(Me.lblHead)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1001, 49)
        Me.Panel1.TabIndex = 201
        '
        'pbEdit
        '
        Me.pbEdit.Image = CType(resources.GetObject("pbEdit.Image"), System.Drawing.Image)
        Me.pbEdit.Location = New System.Drawing.Point(21, 4)
        Me.pbEdit.Name = "pbEdit"
        Me.pbEdit.Size = New System.Drawing.Size(47, 43)
        Me.pbEdit.TabIndex = 115
        Me.pbEdit.TabStop = False
        Me.pbEdit.Visible = False
        '
        'pbAdd
        '
        Me.pbAdd.Image = CType(resources.GetObject("pbAdd.Image"), System.Drawing.Image)
        Me.pbAdd.Location = New System.Drawing.Point(12, 4)
        Me.pbAdd.Name = "pbAdd"
        Me.pbAdd.Size = New System.Drawing.Size(47, 43)
        Me.pbAdd.TabIndex = 114
        Me.pbAdd.TabStop = False
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.Location = New System.Drawing.Point(62, 12)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(186, 28)
        Me.lblHead.TabIndex = 113
        Me.lblHead.Text = "Add Patient Record"
        '
        'addPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 604)
        Me.Controls.Add(Me.pnlDataEntry)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "addPatient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        Me.TopMost = True
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPatient.ResumeLayout(False)
        Me.grpPatient.PerformLayout()
        Me.grpHighblood.ResumeLayout(False)
        Me.grpHighblood.PerformLayout()
        Me.grpDiabetic.ResumeLayout(False)
        Me.grpDiabetic.PerformLayout()
        Me.pnlDataEntry.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpPatient As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbCity As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBgy As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProvince As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHobbies As System.Windows.Forms.RichTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSports As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtOccu As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbRegion As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpBday As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents txtLname As System.Windows.Forms.TextBox
    Friend WithEvents txtMname As System.Windows.Forms.TextBox
    Friend WithEvents txtFirst As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnlDataEntry As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents grpHighblood As System.Windows.Forms.GroupBox
    Friend WithEvents hbNo As System.Windows.Forms.RadioButton
    Friend WithEvents hbYes As System.Windows.Forms.RadioButton
    Friend WithEvents grpDiabetic As System.Windows.Forms.GroupBox
    Friend WithEvents dbNo As System.Windows.Forms.RadioButton
    Friend WithEvents dbYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbAdd As System.Windows.Forms.PictureBox
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents pbEdit As System.Windows.Forms.PictureBox
End Class
