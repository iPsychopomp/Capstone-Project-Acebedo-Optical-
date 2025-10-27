<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportData
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnILocal = New System.Windows.Forms.Button()
        Me.btnIgDrive = New System.Windows.Forms.Button()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.TSPLabel = New System.Windows.Forms.ToolStripLabel()
        Me.tspBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnILocal)
        Me.Panel1.Controls.Add(Me.btnIgDrive)
        Me.Panel1.Controls.Add(Me.ToolStrip)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(447, 239)
        Me.Panel1.TabIndex = 1
        '
        'btnILocal
        '
        Me.btnILocal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnILocal.FlatAppearance.BorderSize = 0
        Me.btnILocal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnILocal.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnILocal.Location = New System.Drawing.Point(62, 45)
        Me.btnILocal.Name = "btnILocal"
        Me.btnILocal.Size = New System.Drawing.Size(321, 27)
        Me.btnILocal.TabIndex = 6
        Me.btnILocal.Text = "Import from Local Backup"
        Me.btnILocal.UseVisualStyleBackColor = False
        '
        'btnIgDrive
        '
        Me.btnIgDrive.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnIgDrive.FlatAppearance.BorderSize = 0
        Me.btnIgDrive.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnIgDrive.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIgDrive.Location = New System.Drawing.Point(62, 94)
        Me.btnIgDrive.Name = "btnIgDrive"
        Me.btnIgDrive.Size = New System.Drawing.Size(321, 27)
        Me.btnIgDrive.TabIndex = 7
        Me.btnIgDrive.Text = "Import from Google Drive Backup"
        Me.btnIgDrive.UseVisualStyleBackColor = False
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
        Me.ToolStrip.TabIndex = 4
        '
        'TSPLabel
        '
        Me.TSPLabel.Name = "TSPLabel"
        Me.TSPLabel.Size = New System.Drawing.Size(445, 15)
        Me.TSPLabel.Text = "---"
        '
        'tspBar
        '
        Me.tspBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.tspBar.Name = "tspBar"
        Me.tspBar.Size = New System.Drawing.Size(443, 22)
        '
        'ImportData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 239)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImportData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Data"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnILocal As System.Windows.Forms.Button
    Friend WithEvents btnIgDrive As System.Windows.Forms.Button
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents TSPLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tspBar As System.Windows.Forms.ToolStripProgressBar
End Class
