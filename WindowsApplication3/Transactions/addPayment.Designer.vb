<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(addPayment))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMode = New System.Windows.Forms.ComboBox()
        Me.lblCash = New System.Windows.Forms.Label()
        Me.lblGcash = New System.Windows.Forms.Label()
        Me.txtCash = New System.Windows.Forms.TextBox()
        Me.txtGcash = New System.Windows.Forms.TextBox()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.lblRef = New System.Windows.Forms.Label()
        Me.pnlPayment = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlPayment.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mode of Payment:"
        '
        'cmbMode
        '
        Me.cmbMode.BackColor = System.Drawing.Color.White
        Me.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMode.Enabled = False
        Me.cmbMode.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMode.FormattingEnabled = True
        Me.cmbMode.Items.AddRange(New Object() {"G-cash", "Cash"})
        Me.cmbMode.Location = New System.Drawing.Point(38, 50)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.Size = New System.Drawing.Size(256, 36)
        Me.cmbMode.TabIndex = 212
        '
        'lblCash
        '
        Me.lblCash.AutoSize = True
        Me.lblCash.Location = New System.Drawing.Point(33, 89)
        Me.lblCash.Name = "lblCash"
        Me.lblCash.Size = New System.Drawing.Size(57, 28)
        Me.lblCash.TabIndex = 213
        Me.lblCash.Text = "Cash:"
        '
        'lblGcash
        '
        Me.lblGcash.AutoSize = True
        Me.lblGcash.Location = New System.Drawing.Point(33, 207)
        Me.lblGcash.Name = "lblGcash"
        Me.lblGcash.Size = New System.Drawing.Size(76, 28)
        Me.lblGcash.TabIndex = 214
        Me.lblGcash.Text = "G-cash:"
        Me.lblGcash.Visible = False
        '
        'txtCash
        '
        Me.txtCash.Location = New System.Drawing.Point(38, 111)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.Size = New System.Drawing.Size(256, 34)
        Me.txtCash.TabIndex = 215
        Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGcash
        '
        Me.txtGcash.Location = New System.Drawing.Point(38, 229)
        Me.txtGcash.Name = "txtGcash"
        Me.txtGcash.Size = New System.Drawing.Size(256, 34)
        Me.txtGcash.TabIndex = 216
        Me.txtGcash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtGcash.Visible = False
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(197, 303)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(139, 27)
        Me.btnConfirm.TabIndex = 217
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'txtRef
        '
        Me.txtRef.Location = New System.Drawing.Point(38, 170)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(256, 34)
        Me.txtRef.TabIndex = 218
        Me.txtRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtRef.Visible = False
        '
        'lblRef
        '
        Me.lblRef.AutoSize = True
        Me.lblRef.Location = New System.Drawing.Point(33, 148)
        Me.lblRef.Name = "lblRef"
        Me.lblRef.Size = New System.Drawing.Size(177, 28)
        Me.lblRef.TabIndex = 219
        Me.lblRef.Text = "Reference Number:"
        Me.lblRef.Visible = False
        '
        'pnlPayment
        '
        Me.pnlPayment.BackColor = System.Drawing.Color.White
        Me.pnlPayment.Controls.Add(Me.Label5)
        Me.pnlPayment.Controls.Add(Me.txtGcash)
        Me.pnlPayment.Controls.Add(Me.lblRef)
        Me.pnlPayment.Controls.Add(Me.Label1)
        Me.pnlPayment.Controls.Add(Me.lblGcash)
        Me.pnlPayment.Controls.Add(Me.txtCash)
        Me.pnlPayment.Controls.Add(Me.txtRef)
        Me.pnlPayment.Controls.Add(Me.cmbMode)
        Me.pnlPayment.Controls.Add(Me.lblCash)
        Me.pnlPayment.Location = New System.Drawing.Point(8, 12)
        Me.pnlPayment.Name = "pnlPayment"
        Me.pnlPayment.Size = New System.Drawing.Size(332, 285)
        Me.pnlPayment.TabIndex = 220
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label5.Location = New System.Drawing.Point(24, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 28)
        Me.Label5.TabIndex = 216
        Me.Label5.Text = "Payment Details"
        '
        'addPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 314)
        Me.Controls.Add(Me.pnlPayment)
        Me.Controls.Add(Me.btnConfirm)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "addPayment"
        Me.Text = "Add payment"
        Me.pnlPayment.ResumeLayout(False)
        Me.pnlPayment.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblCash As System.Windows.Forms.Label
    Friend WithEvents lblGcash As System.Windows.Forms.Label
    Friend WithEvents txtCash As System.Windows.Forms.TextBox
    Friend WithEvents txtGcash As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents lblRef As System.Windows.Forms.Label
    Friend WithEvents pnlPayment As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
