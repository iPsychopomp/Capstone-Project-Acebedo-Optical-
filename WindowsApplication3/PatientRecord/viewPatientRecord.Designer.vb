<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewPatientRecord
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewPatientRecord))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbEdit = New System.Windows.Forms.PictureBox()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.pnlPI = New System.Windows.Forms.Panel()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblBday = New System.Windows.Forms.Label()
        Me.lblFN = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlAI = New System.Windows.Forms.Panel()
        Me.lblMN = New System.Windows.Forms.Label()
        Me.lblCA = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlCAI = New System.Windows.Forms.Panel()
        Me.lblHobb = New System.Windows.Forms.Label()
        Me.lblSports = New System.Windows.Forms.Label()
        Me.lblOccu = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlMI = New System.Windows.Forms.Panel()
        Me.lblOthers = New System.Windows.Forms.Label()
        Me.lblHB = New System.Windows.Forms.Label()
        Me.lblDB = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPI.SuspendLayout()
        Me.pnlAI.SuspendLayout()
        Me.pnlCAI.SuspendLayout()
        Me.pnlMI.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.pbEdit)
        Me.Panel1.Controls.Add(Me.lblHead)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(912, 40)
        Me.Panel1.TabIndex = 202
        '
        'pbEdit
        '
        Me.pbEdit.Image = CType(resources.GetObject("pbEdit.Image"), System.Drawing.Image)
        Me.pbEdit.Location = New System.Drawing.Point(10, 5)
        Me.pbEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbEdit.Name = "pbEdit"
        Me.pbEdit.Size = New System.Drawing.Size(43, 30)
        Me.pbEdit.TabIndex = 116
        Me.pbEdit.TabStop = False
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.Location = New System.Drawing.Point(50, 9)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(226, 25)
        Me.lblHead.TabIndex = 113
        Me.lblHead.Text = "View Patient Information"
        '
        'pnlPI
        '
        Me.pnlPI.BackColor = System.Drawing.SystemColors.HighlightText
        Me.pnlPI.Controls.Add(Me.lblGender)
        Me.pnlPI.Controls.Add(Me.lblAge)
        Me.pnlPI.Controls.Add(Me.lblBday)
        Me.pnlPI.Controls.Add(Me.lblFN)
        Me.pnlPI.Controls.Add(Me.Label29)
        Me.pnlPI.Controls.Add(Me.Label2)
        Me.pnlPI.Controls.Add(Me.Label19)
        Me.pnlPI.Controls.Add(Me.Label6)
        Me.pnlPI.Controls.Add(Me.Label7)
        Me.pnlPI.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPI.Location = New System.Drawing.Point(12, 48)
        Me.pnlPI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlPI.Name = "pnlPI"
        Me.pnlPI.Size = New System.Drawing.Size(889, 169)
        Me.pnlPI.TabIndex = 205
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.Location = New System.Drawing.Point(348, 139)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(28, 28)
        Me.lblGender.TabIndex = 114
        Me.lblGender.Text = "--"
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAge.Location = New System.Drawing.Point(348, 106)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(28, 28)
        Me.lblAge.TabIndex = 113
        Me.lblAge.Text = "--"
        '
        'lblBday
        '
        Me.lblBday.AutoSize = True
        Me.lblBday.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBday.Location = New System.Drawing.Point(348, 73)
        Me.lblBday.Name = "lblBday"
        Me.lblBday.Size = New System.Drawing.Size(28, 28)
        Me.lblBday.TabIndex = 112
        Me.lblBday.Text = "--"
        '
        'lblFN
        '
        Me.lblFN.AutoSize = True
        Me.lblFN.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFN.Location = New System.Drawing.Point(348, 40)
        Me.lblFN.Name = "lblFN"
        Me.lblFN.Size = New System.Drawing.Size(28, 28)
        Me.lblFN.TabIndex = 109
        Me.lblFN.Text = "--"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 28)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Full Name:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(24, 139)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 28)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "Gender:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 28)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Birthday:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 28)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Age:"
        '
        'pnlAI
        '
        Me.pnlAI.BackColor = System.Drawing.SystemColors.HighlightText
        Me.pnlAI.Controls.Add(Me.lblMN)
        Me.pnlAI.Controls.Add(Me.lblCA)
        Me.pnlAI.Controls.Add(Me.Label30)
        Me.pnlAI.Controls.Add(Me.Label16)
        Me.pnlAI.Controls.Add(Me.Label9)
        Me.pnlAI.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlAI.Location = New System.Drawing.Point(12, 225)
        Me.pnlAI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlAI.Name = "pnlAI"
        Me.pnlAI.Size = New System.Drawing.Size(889, 128)
        Me.pnlAI.TabIndex = 206
        '
        'lblMN
        '
        Me.lblMN.AutoSize = True
        Me.lblMN.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMN.Location = New System.Drawing.Point(348, 89)
        Me.lblMN.Name = "lblMN"
        Me.lblMN.Size = New System.Drawing.Size(28, 28)
        Me.lblMN.TabIndex = 121
        Me.lblMN.Text = "--"
        '
        'lblCA
        '
        Me.lblCA.AutoSize = True
        Me.lblCA.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCA.Location = New System.Drawing.Point(348, 39)
        Me.lblCA.MaximumSize = New System.Drawing.Size(520, 0)
        Me.lblCA.Name = "lblCA"
        Me.lblCA.Size = New System.Drawing.Size(28, 28)
        Me.lblCA.TabIndex = 115
        Me.lblCA.Text = "--"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label30.Location = New System.Drawing.Point(22, 3)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(294, 28)
        Me.Label30.TabIndex = 111
        Me.Label30.Text = "Contact && Address Information"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(24, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(176, 28)
        Me.Label16.TabIndex = 99
        Me.Label16.Text = "Complete Address:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(24, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(155, 28)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Mobile Number:"
        '
        'pnlCAI
        '
        Me.pnlCAI.BackColor = System.Drawing.SystemColors.HighlightText
        Me.pnlCAI.Controls.Add(Me.lblHobb)
        Me.pnlCAI.Controls.Add(Me.lblSports)
        Me.pnlCAI.Controls.Add(Me.lblOccu)
        Me.pnlCAI.Controls.Add(Me.Label33)
        Me.pnlCAI.Controls.Add(Me.Label14)
        Me.pnlCAI.Controls.Add(Me.Label12)
        Me.pnlCAI.Controls.Add(Me.Label13)
        Me.pnlCAI.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCAI.Location = New System.Drawing.Point(12, 361)
        Me.pnlCAI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlCAI.Name = "pnlCAI"
        Me.pnlCAI.Size = New System.Drawing.Size(889, 149)
        Me.pnlCAI.TabIndex = 207
        '
        'lblHobb
        '
        Me.lblHobb.AutoSize = True
        Me.lblHobb.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHobb.Location = New System.Drawing.Point(348, 72)
        Me.lblHobb.Name = "lblHobb"
        Me.lblHobb.Size = New System.Drawing.Size(28, 28)
        Me.lblHobb.TabIndex = 125
        Me.lblHobb.Text = "--"
        '
        'lblSports
        '
        Me.lblSports.AutoSize = True
        Me.lblSports.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSports.Location = New System.Drawing.Point(348, 105)
        Me.lblSports.Name = "lblSports"
        Me.lblSports.Size = New System.Drawing.Size(28, 28)
        Me.lblSports.TabIndex = 124
        Me.lblSports.Text = "--"
        '
        'lblOccu
        '
        Me.lblOccu.AutoSize = True
        Me.lblOccu.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOccu.Location = New System.Drawing.Point(348, 39)
        Me.lblOccu.Name = "lblOccu"
        Me.lblOccu.Size = New System.Drawing.Size(28, 28)
        Me.lblOccu.TabIndex = 123
        Me.lblOccu.Text = "--"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label33.Location = New System.Drawing.Point(22, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(194, 28)
        Me.Label33.TabIndex = 118
        Me.Label33.Text = "Lifestyle && Activities"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(24, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 28)
        Me.Label14.TabIndex = 94
        Me.Label14.Text = "Occupation:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(24, 105)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 28)
        Me.Label12.TabIndex = 92
        Me.Label12.Text = "Sports:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(22, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 28)
        Me.Label13.TabIndex = 93
        Me.Label13.Text = "Hobbies:"
        '
        'pnlMI
        '
        Me.pnlMI.BackColor = System.Drawing.SystemColors.HighlightText
        Me.pnlMI.Controls.Add(Me.lblOthers)
        Me.pnlMI.Controls.Add(Me.lblHB)
        Me.pnlMI.Controls.Add(Me.lblDB)
        Me.pnlMI.Controls.Add(Me.Label35)
        Me.pnlMI.Controls.Add(Me.Label34)
        Me.pnlMI.Controls.Add(Me.Label11)
        Me.pnlMI.Controls.Add(Me.Label10)
        Me.pnlMI.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMI.Location = New System.Drawing.Point(12, 518)
        Me.pnlMI.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlMI.Name = "pnlMI"
        Me.pnlMI.Size = New System.Drawing.Size(889, 140)
        Me.pnlMI.TabIndex = 208
        '
        'lblOthers
        '
        Me.lblOthers.AutoSize = True
        Me.lblOthers.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOthers.Location = New System.Drawing.Point(348, 106)
        Me.lblOthers.Name = "lblOthers"
        Me.lblOthers.Size = New System.Drawing.Size(28, 28)
        Me.lblOthers.TabIndex = 130
        Me.lblOthers.Text = "--"
        '
        'lblHB
        '
        Me.lblHB.AutoSize = True
        Me.lblHB.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHB.Location = New System.Drawing.Point(348, 73)
        Me.lblHB.Name = "lblHB"
        Me.lblHB.Size = New System.Drawing.Size(28, 28)
        Me.lblHB.TabIndex = 129
        Me.lblHB.Text = "--"
        '
        'lblDB
        '
        Me.lblDB.AutoSize = True
        Me.lblDB.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDB.Location = New System.Drawing.Point(348, 40)
        Me.lblDB.Name = "lblDB"
        Me.lblDB.Size = New System.Drawing.Size(28, 28)
        Me.lblDB.TabIndex = 126
        Me.lblDB.Text = "--"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(28, 106)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(240, 28)
        Me.Label35.TabIndex = 128
        Me.Label35.Text = "Other Medical Conditions:"
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(25, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(198, 28)
        Me.Label11.TabIndex = 89
        Me.Label11.Text = "Is patient highblood?"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(176, 28)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "Is patient diabetic?"
        '
        'viewPatientRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(912, 666)
        Me.Controls.Add(Me.pnlMI)
        Me.Controls.Add(Me.pnlCAI)
        Me.Controls.Add(Me.pnlAI)
        Me.Controls.Add(Me.pnlPI)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "viewPatientRecord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPI.ResumeLayout(False)
        Me.pnlPI.PerformLayout()
        Me.pnlAI.ResumeLayout(False)
        Me.pnlAI.PerformLayout()
        Me.pnlCAI.ResumeLayout(False)
        Me.pnlCAI.PerformLayout()
        Me.pnlMI.ResumeLayout(False)
        Me.pnlMI.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblHead As System.Windows.Forms.Label
    Friend WithEvents pnlPI As System.Windows.Forms.Panel
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlAI As System.Windows.Forms.Panel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlCAI As System.Windows.Forms.Panel
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlMI As System.Windows.Forms.Panel
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblBday As System.Windows.Forms.Label
    Friend WithEvents lblFN As System.Windows.Forms.Label
    Friend WithEvents lblMN As System.Windows.Forms.Label
    Friend WithEvents lblCA As System.Windows.Forms.Label
    Friend WithEvents lblHobb As System.Windows.Forms.Label
    Friend WithEvents lblSports As System.Windows.Forms.Label
    Friend WithEvents lblOccu As System.Windows.Forms.Label
    Friend WithEvents lblOthers As System.Windows.Forms.Label
    Friend WithEvents lblHB As System.Windows.Forms.Label
    Friend WithEvents lblDB As System.Windows.Forms.Label
    Friend WithEvents pbEdit As System.Windows.Forms.PictureBox
End Class
