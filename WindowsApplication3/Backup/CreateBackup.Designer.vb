<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateBackup
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
        Me.btnBgDrive = New System.Windows.Forms.Button()
        Me.btnBLocal = New System.Windows.Forms.Button()
        Me.TSPLabel = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.tspBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBgDrive
        '
        Me.btnBgDrive.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnBgDrive.FlatAppearance.BorderSize = 0
        Me.btnBgDrive.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBgDrive.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBgDrive.Location = New System.Drawing.Point(62, 45)
        Me.btnBgDrive.Name = "btnBgDrive"
        Me.btnBgDrive.Size = New System.Drawing.Size(321, 27)
        Me.btnBgDrive.TabIndex = 3
        Me.btnBgDrive.Text = "Create Google Drive Backup"
        Me.btnBgDrive.UseVisualStyleBackColor = False
        '
        'btnBLocal
        '
        Me.btnBLocal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnBLocal.FlatAppearance.BorderSize = 0
        Me.btnBLocal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBLocal.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBLocal.Location = New System.Drawing.Point(62, 94)
        Me.btnBLocal.Name = "btnBLocal"
        Me.btnBLocal.Size = New System.Drawing.Size(321, 27)
        Me.btnBLocal.TabIndex = 2
        Me.btnBLocal.Text = "Create Local Backup"
        Me.btnBLocal.UseVisualStyleBackColor = False
        '
        'TSPLabel
        '
        Me.TSPLabel.Name = "TSPLabel"
        Me.TSPLabel.Size = New System.Drawing.Size(445, 15)
        Me.TSPLabel.Text = "---"
        '
        'ToolStrip
        '
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSPLabel, Me.tspBar})
        Me.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip.Location = New System.Drawing.Point(0, 185)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(447, 54)
        Me.ToolStrip.TabIndex = 0
        '
        'tspBar
        '
        Me.tspBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.tspBar.Name = "tspBar"
        Me.tspBar.Size = New System.Drawing.Size(443, 22)
        '
        'CreateBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(447, 239)
        Me.Controls.Add(Me.btnBLocal)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.btnBgDrive)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateBackup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Backup"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBgDrive As System.Windows.Forms.Button
    Friend WithEvents btnBLocal As System.Windows.Forms.Button
    Friend WithEvents TSPLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tspBar As System.Windows.Forms.ToolStripProgressBar
End Class
