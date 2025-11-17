<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reschedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reschedule))
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAppointmentType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPatientName = New System.Windows.Forms.Label()
        Me.cmbDoctors = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbAdd = New System.Windows.Forms.PictureBox()
        Me.lblhead = New System.Windows.Forms.Label()
        Me.pnlAppointment = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.RichTextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAppointment.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(503, 350)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(97, 36)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(179, 28)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Appointment Type:"
        '
        'cmbAppointmentType
        '
        Me.cmbAppointmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAppointmentType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAppointmentType.FormattingEnabled = True
        Me.cmbAppointmentType.Items.AddRange(New Object() {"Check-up", "Follow-up", "Consultation Only"})
        Me.cmbAppointmentType.Location = New System.Drawing.Point(17, 107)
        Me.cmbAppointmentType.Name = "cmbAppointmentType"
        Me.cmbAppointmentType.Size = New System.Drawing.Size(273, 36)
        Me.cmbAppointmentType.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 28)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Patient Name:"
        '
        'lblPatientName
        '
        Me.lblPatientName.AutoSize = True
        Me.lblPatientName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatientName.Location = New System.Drawing.Point(12, 49)
        Me.lblPatientName.Name = "lblPatientName"
        Me.lblPatientName.Size = New System.Drawing.Size(36, 28)
        Me.lblPatientName.TabIndex = 20
        Me.lblPatientName.Text = "---"
        '
        'cmbDoctors
        '
        Me.cmbDoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDoctors.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDoctors.FormattingEnabled = True
        Me.cmbDoctors.Location = New System.Drawing.Point(316, 46)
        Me.cmbDoctors.Name = "cmbDoctors"
        Me.cmbDoctors.Size = New System.Drawing.Size(272, 36)
        Me.cmbDoctors.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(311, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 28)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Doctor:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(311, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 28)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Date:"
        '
        'dtpDate
        '
        Me.dtpDate.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Location = New System.Drawing.Point(315, 109)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(273, 34)
        Me.dtpDate.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.pbAdd)
        Me.Panel1.Controls.Add(Me.lblhead)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(628, 49)
        Me.Panel1.TabIndex = 133
        '
        'pbAdd
        '
        Me.pbAdd.Image = Global.WindowsApplication3.My.Resources.Resources.appointment__1_
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
        Me.lblhead.Size = New System.Drawing.Size(217, 28)
        Me.lblhead.TabIndex = 113
        Me.lblhead.Text = "Reschedule Appointment"
        '
        'pnlAppointment
        '
        Me.pnlAppointment.BackColor = System.Drawing.SystemColors.Window
        Me.pnlAppointment.Controls.Add(Me.Label5)
        Me.pnlAppointment.Controls.Add(Me.txtReason)
        Me.pnlAppointment.Controls.Add(Me.Label4)
        Me.pnlAppointment.Controls.Add(Me.Label3)
        Me.pnlAppointment.Controls.Add(Me.Label1)
        Me.pnlAppointment.Controls.Add(Me.dtpDate)
        Me.pnlAppointment.Controls.Add(Me.cmbAppointmentType)
        Me.pnlAppointment.Controls.Add(Me.lblPatientName)
        Me.pnlAppointment.Controls.Add(Me.Label2)
        Me.pnlAppointment.Controls.Add(Me.cmbDoctors)
        Me.pnlAppointment.Location = New System.Drawing.Point(12, 55)
        Me.pnlAppointment.Name = "pnlAppointment"
        Me.pnlAppointment.Size = New System.Drawing.Size(604, 287)
        Me.pnlAppointment.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 28)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Reason / Notes:"
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(17, 180)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(571, 103)
        Me.txtReason.TabIndex = 4
        Me.txtReason.Text = ""
        '
        'Reschedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 392)
        Me.Controls.Add(Me.pnlAppointment)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnUpdate)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Reschedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAppointment.ResumeLayout(False)
        Me.pnlAppointment.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbAppointmentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPatientName As System.Windows.Forms.Label
    Friend WithEvents cmbDoctors As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbAdd As System.Windows.Forms.PictureBox
    Friend WithEvents lblhead As System.Windows.Forms.Label
    Friend WithEvents pnlAppointment As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.RichTextBox
End Class
