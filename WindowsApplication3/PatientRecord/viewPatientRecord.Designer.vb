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
        Me.lblPatientName = New System.Windows.Forms.Label()
        Me.pnlViewPatientRecord = New System.Windows.Forms.Panel()
        Me.lblHobbies = New System.Windows.Forms.Label()
        Me.lblDB = New System.Windows.Forms.Label()
        Me.lblSports = New System.Windows.Forms.Label()
        Me.lblHB = New System.Windows.Forms.Label()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblOccupation = New System.Windows.Forms.Label()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.pnlViewPatientRecord.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPatientName
        '
        Me.lblPatientName.AutoSize = True
        Me.lblPatientName.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatientName.Location = New System.Drawing.Point(10, 9)
        Me.lblPatientName.Name = "lblPatientName"
        Me.lblPatientName.Size = New System.Drawing.Size(164, 32)
        Me.lblPatientName.TabIndex = 26
        Me.lblPatientName.Text = "Patient Name:"
        '
        'pnlViewPatientRecord
        '
        Me.pnlViewPatientRecord.BackColor = System.Drawing.Color.White
        Me.pnlViewPatientRecord.Controls.Add(Me.lblHobbies)
        Me.pnlViewPatientRecord.Controls.Add(Me.lblDB)
        Me.pnlViewPatientRecord.Controls.Add(Me.lblSports)
        Me.pnlViewPatientRecord.Controls.Add(Me.lblHB)
        Me.pnlViewPatientRecord.Controls.Add(Me.lblDOB)
        Me.pnlViewPatientRecord.Controls.Add(Me.lblAddress)
        Me.pnlViewPatientRecord.Controls.Add(Me.lblOccupation)
        Me.pnlViewPatientRecord.Controls.Add(Me.lblContact)
        Me.pnlViewPatientRecord.Controls.Add(Me.lblGender)
        Me.pnlViewPatientRecord.Controls.Add(Me.lblAge)
        Me.pnlViewPatientRecord.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlViewPatientRecord.Location = New System.Drawing.Point(0, 44)
        Me.pnlViewPatientRecord.Name = "pnlViewPatientRecord"
        Me.pnlViewPatientRecord.Size = New System.Drawing.Size(589, 205)
        Me.pnlViewPatientRecord.TabIndex = 27
        '
        'lblHobbies
        '
        Me.lblHobbies.AutoSize = True
        Me.lblHobbies.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHobbies.Location = New System.Drawing.Point(358, 161)
        Me.lblHobbies.Name = "lblHobbies"
        Me.lblHobbies.Size = New System.Drawing.Size(110, 32)
        Me.lblHobbies.TabIndex = 28
        Me.lblHobbies.Text = "Hobbies:"
        '
        'lblDB
        '
        Me.lblDB.AutoSize = True
        Me.lblDB.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDB.Location = New System.Drawing.Point(346, 54)
        Me.lblDB.Name = "lblDB"
        Me.lblDB.Size = New System.Drawing.Size(110, 32)
        Me.lblDB.TabIndex = 27
        Me.lblDB.Text = "Diabetic:"
        '
        'lblSports
        '
        Me.lblSports.AutoSize = True
        Me.lblSports.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSports.Location = New System.Drawing.Point(355, 104)
        Me.lblSports.Name = "lblSports"
        Me.lblSports.Size = New System.Drawing.Size(91, 32)
        Me.lblSports.TabIndex = 26
        Me.lblSports.Text = "Sports:"
        '
        'lblHB
        '
        Me.lblHB.AutoSize = True
        Me.lblHB.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHB.Location = New System.Drawing.Point(333, 10)
        Me.lblHB.Name = "lblHB"
        Me.lblHB.Size = New System.Drawing.Size(135, 32)
        Me.lblHB.TabIndex = 22
        Me.lblHB.Text = "Highblood:"
        '
        'lblDOB
        '
        Me.lblDOB.AutoSize = True
        Me.lblDOB.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDOB.Location = New System.Drawing.Point(12, 161)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(163, 32)
        Me.lblDOB.TabIndex = 20
        Me.lblDOB.Text = "Date of Birth:"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.Location = New System.Drawing.Point(11, 79)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(107, 32)
        Me.lblAddress.TabIndex = 16
        Me.lblAddress.Text = "Address:"
        '
        'lblOccupation
        '
        Me.lblOccupation.AutoSize = True
        Me.lblOccupation.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOccupation.Location = New System.Drawing.Point(12, 129)
        Me.lblOccupation.Name = "lblOccupation"
        Me.lblOccupation.Size = New System.Drawing.Size(145, 32)
        Me.lblOccupation.TabIndex = 3
        Me.lblOccupation.Text = "Occupation:"
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContact.Location = New System.Drawing.Point(12, 104)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(203, 32)
        Me.lblContact.TabIndex = 2
        Me.lblContact.Text = "Contact Number:"
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.Location = New System.Drawing.Point(11, 54)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(102, 32)
        Me.lblGender.TabIndex = 1
        Me.lblGender.Text = "Gender:"
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAge.Location = New System.Drawing.Point(12, 10)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(64, 32)
        Me.lblAge.TabIndex = 0
        Me.lblAge.Text = "Age:"
        '
        'viewPatientRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(589, 249)
        Me.Controls.Add(Me.pnlViewPatientRecord)
        Me.Controls.Add(Me.lblPatientName)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "viewPatientRecord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patient Information"
        Me.pnlViewPatientRecord.ResumeLayout(False)
        Me.pnlViewPatientRecord.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPatientName As System.Windows.Forms.Label
    Friend WithEvents pnlViewPatientRecord As System.Windows.Forms.Panel
    Friend WithEvents lblHobbies As System.Windows.Forms.Label
    Friend WithEvents lblDB As System.Windows.Forms.Label
    Friend WithEvents lblSports As System.Windows.Forms.Label
    Friend WithEvents lblHB As System.Windows.Forms.Label
    Friend WithEvents lblDOB As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblOccupation As System.Windows.Forms.Label
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
End Class
