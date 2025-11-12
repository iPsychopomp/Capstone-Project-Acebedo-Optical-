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
        Me.Label28 = New System.Windows.Forms.Label()
        Me.hbNo = New System.Windows.Forms.RadioButton()
        Me.hbYes = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
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
        Me.cmbCity = New System.Windows.Forms.ComboBox()
        Me.cmbBgy = New System.Windows.Forms.ComboBox()
        Me.cmbProvince = New System.Windows.Forms.ComboBox()
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
        Me.pnlDataEntry = New System.Windows.Forms.Panel()
        Me.pnlMI = New System.Windows.Forms.Panel()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtOther = New System.Windows.Forms.RichTextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.pnlDB = New System.Windows.Forms.Panel()
        Me.pnlHB = New System.Windows.Forms.Panel()
        Me.pnlCAI = New System.Windows.Forms.Panel()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.pnlAI = New System.Windows.Forms.Panel()
        Me.txtStreet = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.pnlPI = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbEdit = New System.Windows.Forms.PictureBox()
        Me.pbAdd = New System.Windows.Forms.PictureBox()
        Me.lblHead = New System.Windows.Forms.Label()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDataEntry.SuspendLayout()
        Me.pnlMI.SuspendLayout()
        Me.pnlDB.SuspendLayout()
        Me.pnlHB.SuspendLayout()
        Me.pnlCAI.SuspendLayout()
        Me.pnlAI.SuspendLayout()
        Me.pnlPI.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(192, 11)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(20, 28)
        Me.Label28.TabIndex = 126
        Me.Label28.Text = "*"
        '
        'hbNo
        '
        Me.hbNo.AutoSize = True
        Me.hbNo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hbNo.Location = New System.Drawing.Point(108, 44)
        Me.hbNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.hbNo.Name = "hbNo"
        Me.hbNo.Size = New System.Drawing.Size(60, 32)
        Me.hbNo.TabIndex = 123
        Me.hbNo.TabStop = True
        Me.hbNo.Text = "No"
        Me.hbNo.UseVisualStyleBackColor = True
        '
        'hbYes
        '
        Me.hbYes.AutoSize = True
        Me.hbYes.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hbYes.Location = New System.Drawing.Point(47, 44)
        Me.hbYes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.hbYes.Name = "hbYes"
        Me.hbYes.Size = New System.Drawing.Size(60, 32)
        Me.hbYes.TabIndex = 124
        Me.hbYes.TabStop = True
        Me.hbYes.Text = "Yes"
        Me.hbYes.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(25, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(198, 28)
        Me.Label11.TabIndex = 89
        Me.Label11.Text = "Is patient highblood?"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(171, 11)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(20, 28)
        Me.Label27.TabIndex = 122
        Me.Label27.Text = "*"
        '
        'dbNo
        '
        Me.dbNo.AutoSize = True
        Me.dbNo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbNo.Location = New System.Drawing.Point(106, 44)
        Me.dbNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dbNo.Name = "dbNo"
        Me.dbNo.Size = New System.Drawing.Size(60, 32)
        Me.dbNo.TabIndex = 125
        Me.dbNo.TabStop = True
        Me.dbNo.Text = "No"
        Me.dbNo.UseVisualStyleBackColor = True
        '
        'dbYes
        '
        Me.dbYes.AutoSize = True
        Me.dbYes.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbYes.Location = New System.Drawing.Point(45, 44)
        Me.dbYes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dbYes.Name = "dbYes"
        Me.dbYes.Size = New System.Drawing.Size(60, 32)
        Me.dbYes.TabIndex = 118
        Me.dbYes.TabStop = True
        Me.dbYes.Text = "Yes"
        Me.dbYes.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(29, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(176, 28)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "Is patient diabetic?"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(220, 30)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(20, 28)
        Me.Label26.TabIndex = 115
        Me.Label26.Text = "*"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(115, 91)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(20, 28)
        Me.Label25.TabIndex = 114
        Me.Label25.Text = "*"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(661, 33)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(20, 28)
        Me.Label24.TabIndex = 113
        Me.Label24.Text = "*"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(405, 31)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(20, 28)
        Me.Label23.TabIndex = 112
        Me.Label23.Text = "*"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(97, 33)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(20, 28)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "*"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(736, 89)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(20, 28)
        Me.Label21.TabIndex = 110
        Me.Label21.Text = "*"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(131, 88)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(20, 28)
        Me.Label20.TabIndex = 109
        Me.Label20.Text = "*"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(726, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(20, 28)
        Me.Label15.TabIndex = 108
        Me.Label15.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(138, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 28)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "*"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(620, 88)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 28)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "Gender:"
        '
        'cmbCity
        '
        Me.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCity.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCity.FormattingEnabled = True
        Me.cmbCity.Location = New System.Drawing.Point(624, 56)
        Me.cmbCity.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Size = New System.Drawing.Size(242, 36)
        Me.cmbCity.TabIndex = 77
        '
        'cmbBgy
        '
        Me.cmbBgy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBgy.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBgy.FormattingEnabled = True
        Me.cmbBgy.Location = New System.Drawing.Point(27, 118)
        Me.cmbBgy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbBgy.Name = "cmbBgy"
        Me.cmbBgy.Size = New System.Drawing.Size(243, 36)
        Me.cmbBgy.TabIndex = 78
        '
        'cmbProvince
        '
        Me.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvince.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProvince.FormattingEnabled = True
        Me.cmbProvince.Location = New System.Drawing.Point(324, 56)
        Me.cmbProvince.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbProvince.Name = "cmbProvince"
        Me.cmbProvince.Size = New System.Drawing.Size(242, 36)
        Me.cmbProvince.TabIndex = 76
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(24, 33)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 28)
        Me.Label16.TabIndex = 99
        Me.Label16.Text = "Region:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(24, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 28)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Barangay:"
        '
        'txtHobbies
        '
        Me.txtHobbies.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHobbies.Location = New System.Drawing.Point(28, 116)
        Me.txtHobbies.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtHobbies.Name = "txtHobbies"
        Me.txtHobbies.Size = New System.Drawing.Size(838, 43)
        Me.txtHobbies.TabIndex = 98
        Me.txtHobbies.Text = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(620, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 28)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "City:"
        '
        'cmbGender
        '
        Me.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGender.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Items.AddRange(New Object() {"Male", "Female", "Other"})
        Me.cmbGender.Location = New System.Drawing.Point(624, 116)
        Me.cmbGender.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(242, 36)
        Me.cmbGender.TabIndex = 105
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(24, 31)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(155, 28)
        Me.Label18.TabIndex = 104
        Me.Label18.Text = "Mobile Number:"
        '
        'txtSports
        '
        Me.txtSports.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSports.Location = New System.Drawing.Point(624, 56)
        Me.txtSports.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSports.Name = "txtSports"
        Me.txtSports.Size = New System.Drawing.Size(242, 34)
        Me.txtSports.TabIndex = 91
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(320, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 28)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "Province:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(24, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 28)
        Me.Label13.TabIndex = 93
        Me.Label13.Text = "Hobbies:"
        '
        'txtMobile
        '
        Me.txtMobile.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobile.Location = New System.Drawing.Point(28, 56)
        Me.txtMobile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(242, 34)
        Me.txtMobile.TabIndex = 103
        Me.txtMobile.Text = "+63"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(620, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 28)
        Me.Label12.TabIndex = 92
        Me.Label12.Text = "Sports:"
        '
        'txtOccu
        '
        Me.txtOccu.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOccu.Location = New System.Drawing.Point(324, 56)
        Me.txtOccu.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtOccu.Name = "txtOccu"
        Me.txtOccu.Size = New System.Drawing.Size(242, 34)
        Me.txtOccu.TabIndex = 95
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(322, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 28)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Occupation:"
        '
        'cmbRegion
        '
        Me.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegion.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRegion.FormattingEnabled = True
        Me.cmbRegion.Location = New System.Drawing.Point(27, 56)
        Me.cmbRegion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbRegion.Name = "cmbRegion"
        Me.cmbRegion.Size = New System.Drawing.Size(243, 36)
        Me.cmbRegion.TabIndex = 100
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 28)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Birthday:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(322, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 28)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Age:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(620, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 28)
        Me.Label4.TabIndex = 81
        Me.Label4.Text = "Last Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(320, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 28)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Middle Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 28)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "First Name:"
        '
        'dtpBday
        '
        Me.dtpBday.CustomFormat = "yyyy-MM-dd"
        Me.dtpBday.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBday.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBday.Location = New System.Drawing.Point(28, 116)
        Me.dtpBday.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpBday.Name = "dtpBday"
        Me.dtpBday.Size = New System.Drawing.Size(242, 34)
        Me.dtpBday.TabIndex = 75
        Me.dtpBday.Value = New Date(2025, 2, 20, 0, 0, 0, 0)
        '
        'txtAge
        '
        Me.txtAge.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAge.Location = New System.Drawing.Point(324, 116)
        Me.txtAge.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ReadOnly = True
        Me.txtAge.Size = New System.Drawing.Size(242, 34)
        Me.txtAge.TabIndex = 74
        '
        'txtLname
        '
        Me.txtLname.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLname.Location = New System.Drawing.Point(624, 56)
        Me.txtLname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtLname.Name = "txtLname"
        Me.txtLname.Size = New System.Drawing.Size(242, 34)
        Me.txtLname.TabIndex = 73
        '
        'txtMname
        '
        Me.txtMname.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMname.Location = New System.Drawing.Point(324, 54)
        Me.txtMname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMname.Name = "txtMname"
        Me.txtMname.Size = New System.Drawing.Size(242, 34)
        Me.txtMname.TabIndex = 72
        '
        'txtFirst
        '
        Me.txtFirst.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirst.Location = New System.Drawing.Point(28, 56)
        Me.txtFirst.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(242, 34)
        Me.txtFirst.TabIndex = 71
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Window
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(778, 697)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 35)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlDataEntry
        '
        Me.pnlDataEntry.BackColor = System.Drawing.SystemColors.MenuBar
        Me.pnlDataEntry.Controls.Add(Me.pnlMI)
        Me.pnlDataEntry.Controls.Add(Me.pnlCAI)
        Me.pnlDataEntry.Controls.Add(Me.pnlAI)
        Me.pnlDataEntry.Controls.Add(Me.pnlPI)
        Me.pnlDataEntry.Controls.Add(Me.Panel1)
        Me.pnlDataEntry.Controls.Add(Me.btnSave)
        Me.pnlDataEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDataEntry.Location = New System.Drawing.Point(0, 0)
        Me.pnlDataEntry.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlDataEntry.Name = "pnlDataEntry"
        Me.pnlDataEntry.Size = New System.Drawing.Size(916, 740)
        Me.pnlDataEntry.TabIndex = 21
        '
        'pnlMI
        '
        Me.pnlMI.BackColor = System.Drawing.SystemColors.HighlightText
        Me.pnlMI.Controls.Add(Me.Label35)
        Me.pnlMI.Controls.Add(Me.txtOther)
        Me.pnlMI.Controls.Add(Me.Label34)
        Me.pnlMI.Controls.Add(Me.pnlDB)
        Me.pnlMI.Controls.Add(Me.pnlHB)
        Me.pnlMI.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMI.Location = New System.Drawing.Point(12, 561)
        Me.pnlMI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlMI.Name = "pnlMI"
        Me.pnlMI.Size = New System.Drawing.Size(889, 128)
        Me.pnlMI.TabIndex = 206
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(620, 44)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(162, 28)
        Me.Label35.TabIndex = 128
        Me.Label35.Text = "Other/s: (Specify)"
        '
        'txtOther
        '
        Me.txtOther.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOther.Location = New System.Drawing.Point(624, 68)
        Me.txtOther.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtOther.Name = "txtOther"
        Me.txtOther.Size = New System.Drawing.Size(242, 51)
        Me.txtOther.TabIndex = 127
        Me.txtOther.Text = ""
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label34.Location = New System.Drawing.Point(22, 3)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(196, 28)
        Me.Label34.TabIndex = 119
        Me.Label34.Text = "Medical Information"
        '
        'pnlDB
        '
        Me.pnlDB.Controls.Add(Me.Label27)
        Me.pnlDB.Controls.Add(Me.Label10)
        Me.pnlDB.Controls.Add(Me.dbYes)
        Me.pnlDB.Controls.Add(Me.dbNo)
        Me.pnlDB.Location = New System.Drawing.Point(24, 31)
        Me.pnlDB.Name = "pnlDB"
        Me.pnlDB.Size = New System.Drawing.Size(243, 85)
        Me.pnlDB.TabIndex = 207
        '
        'pnlHB
        '
        Me.pnlHB.Controls.Add(Me.Label28)
        Me.pnlHB.Controls.Add(Me.Label11)
        Me.pnlHB.Controls.Add(Me.hbYes)
        Me.pnlHB.Controls.Add(Me.hbNo)
        Me.pnlHB.Location = New System.Drawing.Point(325, 31)
        Me.pnlHB.Name = "pnlHB"
        Me.pnlHB.Size = New System.Drawing.Size(241, 85)
        Me.pnlHB.TabIndex = 207
        '
        'pnlCAI
        '
        Me.pnlCAI.BackColor = System.Drawing.SystemColors.HighlightText
        Me.pnlCAI.Controls.Add(Me.Label33)
        Me.pnlCAI.Controls.Add(Me.Label14)
        Me.pnlCAI.Controls.Add(Me.txtOccu)
        Me.pnlCAI.Controls.Add(Me.Label18)
        Me.pnlCAI.Controls.Add(Me.Label26)
        Me.pnlCAI.Controls.Add(Me.txtMobile)
        Me.pnlCAI.Controls.Add(Me.Label12)
        Me.pnlCAI.Controls.Add(Me.txtSports)
        Me.pnlCAI.Controls.Add(Me.Label13)
        Me.pnlCAI.Controls.Add(Me.txtHobbies)
        Me.pnlCAI.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCAI.Location = New System.Drawing.Point(12, 390)
        Me.pnlCAI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlCAI.Name = "pnlCAI"
        Me.pnlCAI.Size = New System.Drawing.Size(889, 163)
        Me.pnlCAI.TabIndex = 206
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label33.Location = New System.Drawing.Point(22, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(314, 28)
        Me.Label33.TabIndex = 118
        Me.Label33.Text = "Contact && Additional Information"
        '
        'pnlAI
        '
        Me.pnlAI.BackColor = System.Drawing.SystemColors.HighlightText
        Me.pnlAI.Controls.Add(Me.txtStreet)
        Me.pnlAI.Controls.Add(Me.Label30)
        Me.pnlAI.Controls.Add(Me.Label16)
        Me.pnlAI.Controls.Add(Me.Label22)
        Me.pnlAI.Controls.Add(Me.cmbRegion)
        Me.pnlAI.Controls.Add(Me.Label7)
        Me.pnlAI.Controls.Add(Me.cmbProvince)
        Me.pnlAI.Controls.Add(Me.Label23)
        Me.pnlAI.Controls.Add(Me.Label8)
        Me.pnlAI.Controls.Add(Me.cmbCity)
        Me.pnlAI.Controls.Add(Me.Label24)
        Me.pnlAI.Controls.Add(Me.Label9)
        Me.pnlAI.Controls.Add(Me.Label25)
        Me.pnlAI.Controls.Add(Me.cmbBgy)
        Me.pnlAI.Controls.Add(Me.Label31)
        Me.pnlAI.Controls.Add(Me.Label32)
        Me.pnlAI.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlAI.Location = New System.Drawing.Point(12, 219)
        Me.pnlAI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlAI.Name = "pnlAI"
        Me.pnlAI.Size = New System.Drawing.Size(889, 163)
        Me.pnlAI.TabIndex = 205
        '
        'txtStreet
        '
        Me.txtStreet.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStreet.Location = New System.Drawing.Point(324, 118)
        Me.txtStreet.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(542, 34)
        Me.txtStreet.TabIndex = 115
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label30.Location = New System.Drawing.Point(22, 3)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(199, 28)
        Me.Label30.TabIndex = 111
        Me.Label30.Text = "Address Information"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(320, 91)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(254, 28)
        Me.Label31.TabIndex = 116
        Me.Label31.Text = "House No./Blk/Lot && Street:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(544, 91)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(20, 28)
        Me.Label32.TabIndex = 117
        Me.Label32.Text = "*"
        '
        'pnlPI
        '
        Me.pnlPI.BackColor = System.Drawing.SystemColors.HighlightText
        Me.pnlPI.Controls.Add(Me.Label29)
        Me.pnlPI.Controls.Add(Me.Label21)
        Me.pnlPI.Controls.Add(Me.Label2)
        Me.pnlPI.Controls.Add(Me.txtFirst)
        Me.pnlPI.Controls.Add(Me.Label20)
        Me.pnlPI.Controls.Add(Me.Label1)
        Me.pnlPI.Controls.Add(Me.Label3)
        Me.pnlPI.Controls.Add(Me.Label19)
        Me.pnlPI.Controls.Add(Me.Label15)
        Me.pnlPI.Controls.Add(Me.cmbGender)
        Me.pnlPI.Controls.Add(Me.txtMname)
        Me.pnlPI.Controls.Add(Me.Label4)
        Me.pnlPI.Controls.Add(Me.txtLname)
        Me.pnlPI.Controls.Add(Me.Label6)
        Me.pnlPI.Controls.Add(Me.Label5)
        Me.pnlPI.Controls.Add(Me.dtpBday)
        Me.pnlPI.Controls.Add(Me.txtAge)
        Me.pnlPI.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPI.Location = New System.Drawing.Point(12, 48)
        Me.pnlPI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlPI.Name = "pnlPI"
        Me.pnlPI.Size = New System.Drawing.Size(889, 163)
        Me.pnlPI.TabIndex = 204
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label29.Location = New System.Drawing.Point(22, 3)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(203, 28)
        Me.Label29.TabIndex = 108
        Me.Label29.Text = "Personal Information"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.pbEdit)
        Me.Panel1.Controls.Add(Me.pbAdd)
        Me.Panel1.Controls.Add(Me.lblHead)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(916, 40)
        Me.Panel1.TabIndex = 201
        '
        'pbEdit
        '
        Me.pbEdit.Image = CType(resources.GetObject("pbEdit.Image"), System.Drawing.Image)
        Me.pbEdit.Location = New System.Drawing.Point(10, 5)
        Me.pbEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbEdit.Name = "pbEdit"
        Me.pbEdit.Size = New System.Drawing.Size(43, 30)
        Me.pbEdit.TabIndex = 115
        Me.pbEdit.TabStop = False
        Me.pbEdit.Visible = False
        '
        'pbAdd
        '
        Me.pbAdd.Image = CType(resources.GetObject("pbAdd.Image"), System.Drawing.Image)
        Me.pbAdd.Location = New System.Drawing.Point(10, 5)
        Me.pbAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbAdd.Name = "pbAdd"
        Me.pbAdd.Size = New System.Drawing.Size(43, 30)
        Me.pbAdd.TabIndex = 114
        Me.pbAdd.TabStop = False
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.Location = New System.Drawing.Point(50, 9)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(176, 25)
        Me.lblHead.TabIndex = 113
        Me.lblHead.Text = "Add Patient Record"
        '
        'addPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 740)
        Me.Controls.Add(Me.pnlDataEntry)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "addPatient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        Me.TopMost = True
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDataEntry.ResumeLayout(False)
        Me.pnlMI.ResumeLayout(False)
        Me.pnlMI.PerformLayout()
        Me.pnlDB.ResumeLayout(False)
        Me.pnlDB.PerformLayout()
        Me.pnlHB.ResumeLayout(False)
        Me.pnlHB.PerformLayout()
        Me.pnlCAI.ResumeLayout(False)
        Me.pnlCAI.PerformLayout()
        Me.pnlAI.ResumeLayout(False)
        Me.pnlAI.PerformLayout()
        Me.pnlPI.ResumeLayout(False)
        Me.pnlPI.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbCity As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBgy As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProvince As System.Windows.Forms.ComboBox
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
    Friend WithEvents hbNo As System.Windows.Forms.RadioButton
    Friend WithEvents hbYes As System.Windows.Forms.RadioButton
    Friend WithEvents dbNo As System.Windows.Forms.RadioButton
    Friend WithEvents dbYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbAdd As System.Windows.Forms.PictureBox
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents pbEdit As System.Windows.Forms.PictureBox
    Friend WithEvents pnlPI As System.Windows.Forms.Panel
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents pnlMI As System.Windows.Forms.Panel
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtOther As System.Windows.Forms.RichTextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents pnlCAI As System.Windows.Forms.Panel
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents pnlAI As System.Windows.Forms.Panel
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtStreet As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents pnlDB As System.Windows.Forms.Panel
    Friend WithEvents pnlHB As System.Windows.Forms.Panel
End Class
