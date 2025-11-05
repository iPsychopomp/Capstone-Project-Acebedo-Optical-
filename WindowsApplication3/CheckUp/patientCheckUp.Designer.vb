<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class patientCheckUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(patientCheckUp))
        Me.txtPName = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtRemarks = New System.Windows.Forms.RichTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAddOS = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtAddOD = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnlCheckUp = New System.Windows.Forms.Panel()
        Me.txtDName = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbAdd = New System.Windows.Forms.PictureBox()
        Me.lblhead = New System.Windows.Forms.Label()
        Me.btnDSearch = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPSearch = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpCheckUp = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.pdOU = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pdOS = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.pdOD = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAXOS = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtAXOD = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCYOS = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCYOD = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOSSP = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtODSP = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlCheckUp.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCheckUp.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPName
        '
        Me.txtPName.BackColor = System.Drawing.Color.White
        Me.txtPName.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPName.Location = New System.Drawing.Point(35, 93)
        Me.txtPName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPName.Name = "txtPName"
        Me.txtPName.ReadOnly = True
        Me.txtPName.Size = New System.Drawing.Size(306, 32)
        Me.txtPName.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(935, 67)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 25)
        Me.Label17.TabIndex = 141
        Me.Label17.Text = "Date:"
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(940, 90)
        Me.dtpDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(151, 32)
        Me.dtpDate.TabIndex = 140
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(24, 169)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(1066, 97)
        Me.txtRemarks.TabIndex = 16
        Me.txtRemarks.Text = ""
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(20, 141)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 25)
        Me.Label16.TabIndex = 138
        Me.Label16.Text = "Remarks:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(683, 92)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 25)
        Me.Label13.TabIndex = 137
        Me.Label13.Text = "OS:"
        '
        'txtAddOS
        '
        Me.txtAddOS.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddOS.Location = New System.Drawing.Point(735, 89)
        Me.txtAddOS.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAddOS.Name = "txtAddOS"
        Me.txtAddOS.Size = New System.Drawing.Size(138, 32)
        Me.txtAddOS.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(683, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 25)
        Me.Label14.TabIndex = 135
        Me.Label14.Text = "OD:"
        '
        'txtAddOD
        '
        Me.txtAddOD.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddOD.Location = New System.Drawing.Point(735, 58)
        Me.txtAddOD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAddOD.Name = "txtAddOD"
        Me.txtAddOD.Size = New System.Drawing.Size(138, 32)
        Me.txtAddOD.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(683, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 25)
        Me.Label15.TabIndex = 133
        Me.Label15.Text = "Add:"
        '
        'pnlCheckUp
        '
        Me.pnlCheckUp.BackColor = System.Drawing.SystemColors.MenuBar
        Me.pnlCheckUp.Controls.Add(Me.txtDName)
        Me.pnlCheckUp.Controls.Add(Me.Panel1)
        Me.pnlCheckUp.Controls.Add(Me.Label17)
        Me.pnlCheckUp.Controls.Add(Me.dtpDate)
        Me.pnlCheckUp.Controls.Add(Me.btnDSearch)
        Me.pnlCheckUp.Controls.Add(Me.btnCancel)
        Me.pnlCheckUp.Controls.Add(Me.btnPSearch)
        Me.pnlCheckUp.Controls.Add(Me.btnClear)
        Me.pnlCheckUp.Controls.Add(Me.btnSave)
        Me.pnlCheckUp.Controls.Add(Me.grpCheckUp)
        Me.pnlCheckUp.Controls.Add(Me.txtPName)
        Me.pnlCheckUp.Controls.Add(Me.Label2)
        Me.pnlCheckUp.Controls.Add(Me.Label3)
        Me.pnlCheckUp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCheckUp.Location = New System.Drawing.Point(0, 0)
        Me.pnlCheckUp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlCheckUp.Name = "pnlCheckUp"
        Me.pnlCheckUp.Size = New System.Drawing.Size(1137, 465)
        Me.pnlCheckUp.TabIndex = 24
        '
        'txtDName
        '
        Me.txtDName.BackColor = System.Drawing.Color.White
        Me.txtDName.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDName.Location = New System.Drawing.Point(480, 93)
        Me.txtDName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDName.Name = "txtDName"
        Me.txtDName.Size = New System.Drawing.Size(306, 32)
        Me.txtDName.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.pbAdd)
        Me.Panel1.Controls.Add(Me.lblhead)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1137, 49)
        Me.Panel1.TabIndex = 132
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
        Me.lblhead.Size = New System.Drawing.Size(134, 28)
        Me.lblhead.TabIndex = 113
        Me.lblhead.Text = "Add Checkup"
        '
        'btnDSearch
        '
        Me.btnDSearch.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnDSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDSearch.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDSearch.ForeColor = System.Drawing.Color.Black
        Me.btnDSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDSearch.Location = New System.Drawing.Point(792, 95)
        Me.btnDSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDSearch.Name = "btnDSearch"
        Me.btnDSearch.Size = New System.Drawing.Size(87, 27)
        Me.btnDSearch.TabIndex = 4
        Me.btnDSearch.Text = "&Search"
        Me.btnDSearch.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(991, 418)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 27)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnPSearch
        '
        Me.btnPSearch.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnPSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPSearch.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPSearch.ForeColor = System.Drawing.Color.Black
        Me.btnPSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPSearch.Location = New System.Drawing.Point(347, 95)
        Me.btnPSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPSearch.Name = "btnPSearch"
        Me.btnPSearch.Size = New System.Drawing.Size(87, 27)
        Me.btnPSearch.TabIndex = 2
        Me.btnPSearch.Text = "&Search"
        Me.btnPSearch.UseVisualStyleBackColor = False
        Me.btnPSearch.Visible = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(156, 418)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 27)
        Me.btnClear.TabIndex = 18
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        Me.btnClear.Visible = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(51, 418)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 27)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'grpCheckUp
        '
        Me.grpCheckUp.Controls.Add(Me.Label21)
        Me.grpCheckUp.Controls.Add(Me.pdOU)
        Me.grpCheckUp.Controls.Add(Me.Label16)
        Me.grpCheckUp.Controls.Add(Me.Label1)
        Me.grpCheckUp.Controls.Add(Me.txtRemarks)
        Me.grpCheckUp.Controls.Add(Me.pdOS)
        Me.grpCheckUp.Controls.Add(Me.Label19)
        Me.grpCheckUp.Controls.Add(Me.pdOD)
        Me.grpCheckUp.Controls.Add(Me.Label20)
        Me.grpCheckUp.Controls.Add(Me.Label13)
        Me.grpCheckUp.Controls.Add(Me.txtAddOS)
        Me.grpCheckUp.Controls.Add(Me.Label14)
        Me.grpCheckUp.Controls.Add(Me.txtAddOD)
        Me.grpCheckUp.Controls.Add(Me.Label15)
        Me.grpCheckUp.Controls.Add(Me.Label10)
        Me.grpCheckUp.Controls.Add(Me.txtAXOS)
        Me.grpCheckUp.Controls.Add(Me.Label11)
        Me.grpCheckUp.Controls.Add(Me.txtAXOD)
        Me.grpCheckUp.Controls.Add(Me.Label12)
        Me.grpCheckUp.Controls.Add(Me.Label7)
        Me.grpCheckUp.Controls.Add(Me.txtCYOS)
        Me.grpCheckUp.Controls.Add(Me.Label8)
        Me.grpCheckUp.Controls.Add(Me.txtCYOD)
        Me.grpCheckUp.Controls.Add(Me.Label9)
        Me.grpCheckUp.Controls.Add(Me.Label6)
        Me.grpCheckUp.Controls.Add(Me.txtOSSP)
        Me.grpCheckUp.Controls.Add(Me.Label5)
        Me.grpCheckUp.Controls.Add(Me.txtODSP)
        Me.grpCheckUp.Controls.Add(Me.Label4)
        Me.grpCheckUp.Location = New System.Drawing.Point(11, 123)
        Me.grpCheckUp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpCheckUp.Name = "grpCheckUp"
        Me.grpCheckUp.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grpCheckUp.Size = New System.Drawing.Size(1114, 291)
        Me.grpCheckUp.TabIndex = 0
        Me.grpCheckUp.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(900, 121)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 25)
        Me.Label21.TabIndex = 156
        Me.Label21.Text = "OU:"
        '
        'pdOU
        '
        Me.pdOU.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pdOU.Location = New System.Drawing.Point(952, 120)
        Me.pdOU.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pdOU.Name = "pdOU"
        Me.pdOU.Size = New System.Drawing.Size(138, 32)
        Me.pdOU.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(900, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 25)
        Me.Label1.TabIndex = 154
        Me.Label1.Text = "OS:"
        '
        'pdOS
        '
        Me.pdOS.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pdOS.Location = New System.Drawing.Point(952, 88)
        Me.pdOS.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pdOS.Name = "pdOS"
        Me.pdOS.Size = New System.Drawing.Size(138, 32)
        Me.pdOS.TabIndex = 14
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(900, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 25)
        Me.Label19.TabIndex = 152
        Me.Label19.Text = "OD:"
        '
        'pdOD
        '
        Me.pdOD.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pdOD.Location = New System.Drawing.Point(952, 57)
        Me.pdOD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pdOD.Name = "pdOD"
        Me.pdOD.Size = New System.Drawing.Size(138, 32)
        Me.pdOD.TabIndex = 13
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(900, 29)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 25)
        Me.Label20.TabIndex = 150
        Me.Label20.Text = "PD:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(464, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 25)
        Me.Label10.TabIndex = 132
        Me.Label10.Text = "OS:"
        '
        'txtAXOS
        '
        Me.txtAXOS.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAXOS.Location = New System.Drawing.Point(516, 88)
        Me.txtAXOS.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAXOS.Name = "txtAXOS"
        Me.txtAXOS.Size = New System.Drawing.Size(138, 32)
        Me.txtAXOS.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(464, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 25)
        Me.Label11.TabIndex = 130
        Me.Label11.Text = "OD:"
        '
        'txtAXOD
        '
        Me.txtAXOD.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAXOD.Location = New System.Drawing.Point(516, 57)
        Me.txtAXOD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAXOD.Name = "txtAXOD"
        Me.txtAXOD.Size = New System.Drawing.Size(138, 32)
        Me.txtAXOD.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(464, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 25)
        Me.Label12.TabIndex = 128
        Me.Label12.Text = "Axis:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(245, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 25)
        Me.Label7.TabIndex = 127
        Me.Label7.Text = "OS:"
        '
        'txtCYOS
        '
        Me.txtCYOS.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCYOS.Location = New System.Drawing.Point(297, 88)
        Me.txtCYOS.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCYOS.Name = "txtCYOS"
        Me.txtCYOS.Size = New System.Drawing.Size(138, 32)
        Me.txtCYOS.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(245, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 25)
        Me.Label8.TabIndex = 125
        Me.Label8.Text = "OD:"
        '
        'txtCYOD
        '
        Me.txtCYOD.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCYOD.Location = New System.Drawing.Point(297, 57)
        Me.txtCYOD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCYOD.Name = "txtCYOD"
        Me.txtCYOD.Size = New System.Drawing.Size(138, 32)
        Me.txtCYOD.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(245, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 25)
        Me.Label9.TabIndex = 123
        Me.Label9.Text = "Cylinder:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 25)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = "OS:"
        '
        'txtOSSP
        '
        Me.txtOSSP.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOSSP.Location = New System.Drawing.Point(72, 88)
        Me.txtOSSP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOSSP.Name = "txtOSSP"
        Me.txtOSSP.Size = New System.Drawing.Size(138, 32)
        Me.txtOSSP.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 25)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "OD:"
        '
        'txtODSP
        '
        Me.txtODSP.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtODSP.Location = New System.Drawing.Point(72, 57)
        Me.txtODSP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtODSP.Name = "txtODSP"
        Me.txtODSP.Size = New System.Drawing.Size(138, 32)
        Me.txtODSP.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 25)
        Me.Label4.TabIndex = 118
        Me.Label4.Text = "Sphere:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 25)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Patient's Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(475, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 25)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "Doctor's Name:"
        '
        'patientCheckUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1137, 465)
        Me.Controls.Add(Me.pnlCheckUp)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "patientCheckUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        Me.pnlCheckUp.ResumeLayout(False)
        Me.pnlCheckUp.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCheckUp.ResumeLayout(False)
        Me.grpCheckUp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPName As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRemarks As System.Windows.Forms.RichTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAddOS As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtAddOD As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pnlCheckUp As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents grpCheckUp As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAXOS As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAXOD As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCYOS As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCYOD As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtOSSP As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtODSP As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDName As System.Windows.Forms.TextBox
    Friend WithEvents btnDSearch As System.Windows.Forms.Button
    Friend WithEvents btnPSearch As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbAdd As System.Windows.Forms.PictureBox
    Friend WithEvents lblhead As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pdOS As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents pdOD As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents pdOU As System.Windows.Forms.TextBox
End Class
