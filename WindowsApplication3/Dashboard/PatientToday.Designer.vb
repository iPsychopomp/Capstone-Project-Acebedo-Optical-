﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PatientToday
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PatientToday))
        Me.patientTDGV = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.lblhead = New System.Windows.Forms.Label()
        Me.pnlBar = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        CType(Me.patientTDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'patientTDGV
        '
        Me.patientTDGV.AllowUserToAddRows = False
        Me.patientTDGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.patientTDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.patientTDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.patientTDGV.BackgroundColor = System.Drawing.Color.White
        Me.patientTDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.patientTDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.patientTDGV.ColumnHeadersHeight = 50
        Me.patientTDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.patientTDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.patientTDGV.DefaultCellStyle = DataGridViewCellStyle3
        Me.patientTDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.patientTDGV.GridColor = System.Drawing.Color.Black
        Me.patientTDGV.Location = New System.Drawing.Point(0, 106)
        Me.patientTDGV.MultiSelect = False
        Me.patientTDGV.Name = "patientTDGV"
        Me.patientTDGV.ReadOnly = True
        Me.patientTDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.patientTDGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.patientTDGV.RowHeadersVisible = False
        Me.patientTDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.patientTDGV.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.patientTDGV.RowTemplate.Height = 30
        Me.patientTDGV.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.patientTDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.patientTDGV.Size = New System.Drawing.Size(752, 488)
        Me.patientTDGV.TabIndex = 137
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "fullname"
        Me.Column2.FillWeight = 21.2766!
        Me.Column2.HeaderText = "Patient Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.lblhead)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(752, 49)
        Me.Panel1.TabIndex = 135
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(17, 11)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(29, 38)
        Me.PictureBox4.TabIndex = 141
        Me.PictureBox4.TabStop = False
        '
        'lblhead
        '
        Me.lblhead.AutoSize = True
        Me.lblhead.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhead.Location = New System.Drawing.Point(51, 12)
        Me.lblhead.Name = "lblhead"
        Me.lblhead.Size = New System.Drawing.Size(134, 28)
        Me.lblhead.TabIndex = 113
        Me.lblhead.Text = "Patient Today"
        '
        'pnlBar
        '
        Me.pnlBar.BackColor = System.Drawing.SystemColors.Control
        Me.pnlBar.Controls.Add(Me.Label4)
        Me.pnlBar.Controls.Add(Me.Label1)
        Me.pnlBar.Controls.Add(Me.dtpFrom)
        Me.pnlBar.Controls.Add(Me.dtpTo)
        Me.pnlBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBar.Location = New System.Drawing.Point(0, 49)
        Me.pnlBar.Name = "pnlBar"
        Me.pnlBar.Size = New System.Drawing.Size(752, 57)
        Me.pnlBar.TabIndex = 136
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(236, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 28)
        Me.Label4.TabIndex = 154
        Me.Label4.Text = "To:"
        Me.Label4.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 28)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "From:"
        Me.Label1.Visible = False
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd-MMMM-yyyy"
        Me.dtpFrom.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(81, 11)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(150, 34)
        Me.dtpFrom.TabIndex = 152
        Me.dtpFrom.Visible = False
        '
        'dtpTo
        '
        Me.dtpTo.CalendarFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.CustomFormat = "dd-MMMM-yyyy"
        Me.dtpTo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(281, 11)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(150, 34)
        Me.dtpTo.TabIndex = 151
        Me.dtpTo.Visible = False
        '
        'PatientToday
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 594)
        Me.Controls.Add(Me.patientTDGV)
        Me.Controls.Add(Me.pnlBar)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PatientToday"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PatientToday"
        CType(Me.patientTDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBar.ResumeLayout(False)
        Me.pnlBar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents patientTDGV As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblhead As System.Windows.Forms.Label
    Friend WithEvents pnlBar As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
