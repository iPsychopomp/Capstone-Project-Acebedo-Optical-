<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewTransactions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewTransactions))
        Me.pnlViewTransactions = New System.Windows.Forms.Panel()
        Me.lblFrameTotal = New System.Windows.Forms.Label()
        Me.lblLensDiscount = New System.Windows.Forms.Label()
        Me.lblLensTotal = New System.Windows.Forms.Label()
        Me.lblPaymentStatus = New System.Windows.Forms.Label()
        Me.lblModeOfPayment = New System.Windows.Forms.Label()
        Me.lblAmountPaid = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblCheckUpCost = New System.Windows.Forms.Label()
        Me.lblFrameDiscount = New System.Windows.Forms.Label()
        Me.lblAddOnCost = New System.Windows.Forms.Label()
        Me.lblAddOns = New System.Windows.Forms.Label()
        Me.lblOSCost = New System.Windows.Forms.Label()
        Me.lblODCost = New System.Windows.Forms.Label()
        Me.lblLensesCost = New System.Windows.Forms.Label()
        Me.lblLenses = New System.Windows.Forms.Label()
        Me.lblFrameCost = New System.Windows.Forms.Label()
        Me.lblOSGrade = New System.Windows.Forms.Label()
        Me.lblODGrade = New System.Windows.Forms.Label()
        Me.lblFrame = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblPatientName = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.pnlViewTransactions.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlViewTransactions
        '
        Me.pnlViewTransactions.BackColor = System.Drawing.Color.White
        Me.pnlViewTransactions.Controls.Add(Me.lblPatientName)
        Me.pnlViewTransactions.Controls.Add(Me.lblFrameTotal)
        Me.pnlViewTransactions.Controls.Add(Me.lblLensDiscount)
        Me.pnlViewTransactions.Controls.Add(Me.lblLensTotal)
        Me.pnlViewTransactions.Controls.Add(Me.lblPaymentStatus)
        Me.pnlViewTransactions.Controls.Add(Me.lblModeOfPayment)
        Me.pnlViewTransactions.Controls.Add(Me.lblAmountPaid)
        Me.pnlViewTransactions.Controls.Add(Me.lblTotal)
        Me.pnlViewTransactions.Controls.Add(Me.lblCheckUpCost)
        Me.pnlViewTransactions.Controls.Add(Me.lblFrameDiscount)
        Me.pnlViewTransactions.Controls.Add(Me.lblAddOnCost)
        Me.pnlViewTransactions.Controls.Add(Me.lblAddOns)
        Me.pnlViewTransactions.Controls.Add(Me.lblOSCost)
        Me.pnlViewTransactions.Controls.Add(Me.lblODCost)
        Me.pnlViewTransactions.Controls.Add(Me.lblLensesCost)
        Me.pnlViewTransactions.Controls.Add(Me.lblLenses)
        Me.pnlViewTransactions.Controls.Add(Me.lblFrameCost)
        Me.pnlViewTransactions.Controls.Add(Me.lblOSGrade)
        Me.pnlViewTransactions.Controls.Add(Me.lblODGrade)
        Me.pnlViewTransactions.Controls.Add(Me.lblFrame)
        Me.pnlViewTransactions.Controls.Add(Me.lblDate)
        Me.pnlViewTransactions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlViewTransactions.Location = New System.Drawing.Point(0, 42)
        Me.pnlViewTransactions.Name = "pnlViewTransactions"
        Me.pnlViewTransactions.Size = New System.Drawing.Size(635, 466)
        Me.pnlViewTransactions.TabIndex = 24
        '
        'lblFrameTotal
        '
        Me.lblFrameTotal.AutoSize = True
        Me.lblFrameTotal.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrameTotal.Location = New System.Drawing.Point(272, 207)
        Me.lblFrameTotal.Name = "lblFrameTotal"
        Me.lblFrameTotal.Size = New System.Drawing.Size(35, 32)
        Me.lblFrameTotal.TabIndex = 31
        Me.lblFrameTotal.Text = "--"
        '
        'lblLensDiscount
        '
        Me.lblLensDiscount.AutoSize = True
        Me.lblLensDiscount.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLensDiscount.Location = New System.Drawing.Point(12, 264)
        Me.lblLensDiscount.Name = "lblLensDiscount"
        Me.lblLensDiscount.Size = New System.Drawing.Size(172, 32)
        Me.lblLensDiscount.TabIndex = 29
        Me.lblLensDiscount.Text = "Lens Discount:"
        '
        'lblLensTotal
        '
        Me.lblLensTotal.AutoSize = True
        Me.lblLensTotal.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLensTotal.Location = New System.Drawing.Point(272, 264)
        Me.lblLensTotal.Name = "lblLensTotal"
        Me.lblLensTotal.Size = New System.Drawing.Size(35, 32)
        Me.lblLensTotal.TabIndex = 30
        Me.lblLensTotal.Text = "--"
        '
        'lblPaymentStatus
        '
        Me.lblPaymentStatus.AutoSize = True
        Me.lblPaymentStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentStatus.Location = New System.Drawing.Point(272, 409)
        Me.lblPaymentStatus.Name = "lblPaymentStatus"
        Me.lblPaymentStatus.Size = New System.Drawing.Size(190, 32)
        Me.lblPaymentStatus.TabIndex = 28
        Me.lblPaymentStatus.Text = "Payment Status:"
        '
        'lblModeOfPayment
        '
        Me.lblModeOfPayment.AutoSize = True
        Me.lblModeOfPayment.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModeOfPayment.Location = New System.Drawing.Point(12, 316)
        Me.lblModeOfPayment.Name = "lblModeOfPayment"
        Me.lblModeOfPayment.Size = New System.Drawing.Size(215, 32)
        Me.lblModeOfPayment.TabIndex = 27
        Me.lblModeOfPayment.Text = "Mode of Payment:"
        '
        'lblAmountPaid
        '
        Me.lblAmountPaid.AutoSize = True
        Me.lblAmountPaid.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountPaid.Location = New System.Drawing.Point(11, 409)
        Me.lblAmountPaid.Name = "lblAmountPaid"
        Me.lblAmountPaid.Size = New System.Drawing.Size(162, 32)
        Me.lblAmountPaid.TabIndex = 26
        Me.lblAmountPaid.Text = "Amount Paid:"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(272, 316)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(74, 32)
        Me.lblTotal.TabIndex = 25
        Me.lblTotal.Text = "Total:"
        '
        'lblCheckUpCost
        '
        Me.lblCheckUpCost.AutoSize = True
        Me.lblCheckUpCost.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckUpCost.Location = New System.Drawing.Point(434, 186)
        Me.lblCheckUpCost.Name = "lblCheckUpCost"
        Me.lblCheckUpCost.Size = New System.Drawing.Size(69, 32)
        Me.lblCheckUpCost.TabIndex = 24
        Me.lblCheckUpCost.Text = "Cost:"
        '
        'lblFrameDiscount
        '
        Me.lblFrameDiscount.AutoSize = True
        Me.lblFrameDiscount.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrameDiscount.Location = New System.Drawing.Point(12, 207)
        Me.lblFrameDiscount.Name = "lblFrameDiscount"
        Me.lblFrameDiscount.Size = New System.Drawing.Size(191, 32)
        Me.lblFrameDiscount.TabIndex = 22
        Me.lblFrameDiscount.Text = "Frame Discount:"
        '
        'lblAddOnCost
        '
        Me.lblAddOnCost.AutoSize = True
        Me.lblAddOnCost.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddOnCost.Location = New System.Drawing.Point(434, 154)
        Me.lblAddOnCost.Name = "lblAddOnCost"
        Me.lblAddOnCost.Size = New System.Drawing.Size(69, 32)
        Me.lblAddOnCost.TabIndex = 21
        Me.lblAddOnCost.Text = "Cost:"
        '
        'lblAddOns
        '
        Me.lblAddOns.AutoSize = True
        Me.lblAddOns.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddOns.Location = New System.Drawing.Point(11, 154)
        Me.lblAddOns.Name = "lblAddOns"
        Me.lblAddOns.Size = New System.Drawing.Size(114, 32)
        Me.lblAddOns.TabIndex = 20
        Me.lblAddOns.Text = "Add Ons:"
        '
        'lblOSCost
        '
        Me.lblOSCost.AutoSize = True
        Me.lblOSCost.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOSCost.Location = New System.Drawing.Point(434, 129)
        Me.lblOSCost.Name = "lblOSCost"
        Me.lblOSCost.Size = New System.Drawing.Size(69, 32)
        Me.lblOSCost.TabIndex = 19
        Me.lblOSCost.Text = "Cost:"
        '
        'lblODCost
        '
        Me.lblODCost.AutoSize = True
        Me.lblODCost.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblODCost.Location = New System.Drawing.Point(434, 104)
        Me.lblODCost.Name = "lblODCost"
        Me.lblODCost.Size = New System.Drawing.Size(69, 32)
        Me.lblODCost.TabIndex = 18
        Me.lblODCost.Text = "Cost:"
        '
        'lblLensesCost
        '
        Me.lblLensesCost.AutoSize = True
        Me.lblLensesCost.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLensesCost.Location = New System.Drawing.Point(434, 79)
        Me.lblLensesCost.Name = "lblLensesCost"
        Me.lblLensesCost.Size = New System.Drawing.Size(69, 32)
        Me.lblLensesCost.TabIndex = 17
        Me.lblLensesCost.Text = "Cost:"
        '
        'lblLenses
        '
        Me.lblLenses.AutoSize = True
        Me.lblLenses.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLenses.Location = New System.Drawing.Point(11, 79)
        Me.lblLenses.Name = "lblLenses"
        Me.lblLenses.Size = New System.Drawing.Size(93, 32)
        Me.lblLenses.TabIndex = 16
        Me.lblLenses.Text = "Lenses:"
        '
        'lblFrameCost
        '
        Me.lblFrameCost.AutoSize = True
        Me.lblFrameCost.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrameCost.Location = New System.Drawing.Point(434, 54)
        Me.lblFrameCost.Name = "lblFrameCost"
        Me.lblFrameCost.Size = New System.Drawing.Size(69, 32)
        Me.lblFrameCost.TabIndex = 4
        Me.lblFrameCost.Text = "Cost:"
        '
        'lblOSGrade
        '
        Me.lblOSGrade.AutoSize = True
        Me.lblOSGrade.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOSGrade.Location = New System.Drawing.Point(12, 129)
        Me.lblOSGrade.Name = "lblOSGrade"
        Me.lblOSGrade.Size = New System.Drawing.Size(203, 32)
        Me.lblOSGrade.TabIndex = 3
        Me.lblOSGrade.Text = "Added OS Grade:"
        '
        'lblODGrade
        '
        Me.lblODGrade.AutoSize = True
        Me.lblODGrade.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblODGrade.Location = New System.Drawing.Point(12, 104)
        Me.lblODGrade.Name = "lblODGrade"
        Me.lblODGrade.Size = New System.Drawing.Size(207, 32)
        Me.lblODGrade.TabIndex = 2
        Me.lblODGrade.Text = "Added OD Grade:"
        '
        'lblFrame
        '
        Me.lblFrame.AutoSize = True
        Me.lblFrame.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrame.Location = New System.Drawing.Point(11, 54)
        Me.lblFrame.Name = "lblFrame"
        Me.lblFrame.Size = New System.Drawing.Size(89, 32)
        Me.lblFrame.TabIndex = 1
        Me.lblFrame.Text = "Frame:"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(12, 10)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(73, 32)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Date:"
        '
        'lblPatientName
        '
        Me.lblPatientName.AutoSize = True
        Me.lblPatientName.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatientName.Location = New System.Drawing.Point(606, 10)
        Me.lblPatientName.Name = "lblPatientName"
        Me.lblPatientName.Size = New System.Drawing.Size(17, 25)
        Me.lblPatientName.TabIndex = 25
        Me.lblPatientName.Text = " "
        Me.lblPatientName.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(49, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(186, 28)
        Me.Label10.TabIndex = 116
        Me.Label10.Text = "Transaction History"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 37)
        Me.PictureBox1.TabIndex = 117
        Me.PictureBox1.TabStop = False
        '
        'btnReport
        '
        Me.btnReport.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.Location = New System.Drawing.Point(523, 9)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(100, 27)
        Me.btnReport.TabIndex = 118
        Me.btnReport.Text = "Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'viewTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(635, 508)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.pnlViewTransactions)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "viewTransactions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        Me.pnlViewTransactions.ResumeLayout(False)
        Me.pnlViewTransactions.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlViewTransactions As System.Windows.Forms.Panel
    Friend WithEvents lblFrameCost As System.Windows.Forms.Label
    Friend WithEvents lblOSGrade As System.Windows.Forms.Label
    Friend WithEvents lblODGrade As System.Windows.Forms.Label
    Friend WithEvents lblFrame As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblPatientName As System.Windows.Forms.Label
    Friend WithEvents lblLensesCost As System.Windows.Forms.Label
    Friend WithEvents lblLenses As System.Windows.Forms.Label
    Friend WithEvents lblOSCost As System.Windows.Forms.Label
    Friend WithEvents lblODCost As System.Windows.Forms.Label
    Friend WithEvents lblAddOnCost As System.Windows.Forms.Label
    Friend WithEvents lblAddOns As System.Windows.Forms.Label
    Friend WithEvents lblFrameDiscount As System.Windows.Forms.Label
    Friend WithEvents lblAmountPaid As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblCheckUpCost As System.Windows.Forms.Label
    Friend WithEvents lblPaymentStatus As System.Windows.Forms.Label
    Friend WithEvents lblModeOfPayment As System.Windows.Forms.Label
    Friend WithEvents lblLensDiscount As System.Windows.Forms.Label
    Friend WithEvents lblLensTotal As System.Windows.Forms.Label
    Friend WithEvents lblFrameTotal As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnReport As System.Windows.Forms.Button
End Class
