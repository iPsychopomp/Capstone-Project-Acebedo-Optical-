<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class selectGrade
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(selectGrade))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOD = New System.Windows.Forms.TextBox()
        Me.txtODPrice = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtOS = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOSPrice = New System.Windows.Forms.TextBox()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label4.Location = New System.Drawing.Point(250, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 28)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "OS (Left Eye)"
        '
        'txtOD
        '
        Me.txtOD.Location = New System.Drawing.Point(297, 48)
        Me.txtOD.Name = "txtOD"
        Me.txtOD.Size = New System.Drawing.Size(100, 34)
        Me.txtOD.TabIndex = 3
        '
        'txtODPrice
        '
        Me.txtODPrice.Location = New System.Drawing.Point(297, 88)
        Me.txtODPrice.Name = "txtODPrice"
        Me.txtODPrice.Size = New System.Drawing.Size(100, 34)
        Me.txtODPrice.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtOS)
        Me.Panel1.Controls.Add(Me.txtODPrice)
        Me.Panel1.Controls.Add(Me.txtOD)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtOSPrice)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(414, 134)
        Me.Panel1.TabIndex = 13
        '
        'txtOS
        '
        Me.txtOS.Location = New System.Drawing.Point(83, 50)
        Me.txtOS.Name = "txtOS"
        Me.txtOS.Size = New System.Drawing.Size(100, 34)
        Me.txtOS.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label2.Location = New System.Drawing.Point(26, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 28)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "OD (Right Eye)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Grade:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 28)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Price:"
        '
        'txtOSPrice
        '
        Me.txtOSPrice.Location = New System.Drawing.Point(83, 90)
        Me.txtOSPrice.Name = "txtOSPrice"
        Me.txtOSPrice.Size = New System.Drawing.Size(100, 34)
        Me.txtOSPrice.TabIndex = 5
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(309, 150)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(100, 35)
        Me.btnConfirm.TabIndex = 12
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(231, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 28)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Price:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(215, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 28)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Grade:"
        '
        'selectGrade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 190)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnConfirm)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "selectGrade"
        Me.Text = "Set Grade & Price"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOD As System.Windows.Forms.TextBox
    Friend WithEvents txtODPrice As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtOS As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOSPrice As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
