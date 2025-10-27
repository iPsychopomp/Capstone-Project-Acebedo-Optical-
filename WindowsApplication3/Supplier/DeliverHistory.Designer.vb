<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DeliverHistory
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeliverHistory))
        Me.dgvDeliveryHistory = New System.Windows.Forms.DataGridView()
        Me.deliveryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.orderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.productID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.productName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantityReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantityDefective = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deliveryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.receivedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlBar = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvDeliveryHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDeliveryHistory
        '
        Me.dgvDeliveryHistory.AllowUserToAddRows = False
        Me.dgvDeliveryHistory.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvDeliveryHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDeliveryHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDeliveryHistory.BackgroundColor = System.Drawing.Color.White
        Me.dgvDeliveryHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDeliveryHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDeliveryHistory.ColumnHeadersHeight = 50
        Me.dgvDeliveryHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDeliveryHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.deliveryID, Me.orderID, Me.itemID, Me.productID, Me.productName, Me.quantityReceived, Me.quantityDefective, Me.remarks, Me.deliveryDate, Me.receivedBy})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDeliveryHistory.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDeliveryHistory.GridColor = System.Drawing.Color.Black
        Me.dgvDeliveryHistory.Location = New System.Drawing.Point(-3, 49)
        Me.dgvDeliveryHistory.MultiSelect = False
        Me.dgvDeliveryHistory.Name = "dgvDeliveryHistory"
        Me.dgvDeliveryHistory.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDeliveryHistory.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvDeliveryHistory.RowHeadersVisible = False
        Me.dgvDeliveryHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDeliveryHistory.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvDeliveryHistory.RowTemplate.Height = 30
        Me.dgvDeliveryHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDeliveryHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDeliveryHistory.Size = New System.Drawing.Size(1093, 424)
        Me.dgvDeliveryHistory.TabIndex = 226
        '
        'deliveryID
        '
        Me.deliveryID.DataPropertyName = "deliveryID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.deliveryID.DefaultCellStyle = DataGridViewCellStyle3
        Me.deliveryID.HeaderText = "Delivery ID"
        Me.deliveryID.Name = "deliveryID"
        Me.deliveryID.ReadOnly = True
        Me.deliveryID.Visible = False
        '
        'orderID
        '
        Me.orderID.DataPropertyName = "orderID"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.orderID.DefaultCellStyle = DataGridViewCellStyle4
        Me.orderID.FillWeight = 60.0!
        Me.orderID.HeaderText = "Order ID"
        Me.orderID.Name = "orderID"
        Me.orderID.ReadOnly = True
        '
        'itemID
        '
        Me.itemID.DataPropertyName = "itemID"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.itemID.DefaultCellStyle = DataGridViewCellStyle5
        Me.itemID.FillWeight = 60.0!
        Me.itemID.HeaderText = "Item ID"
        Me.itemID.Name = "itemID"
        Me.itemID.ReadOnly = True
        Me.itemID.Visible = False
        '
        'productID
        '
        Me.productID.DataPropertyName = "productID"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.productID.DefaultCellStyle = DataGridViewCellStyle6
        Me.productID.FillWeight = 80.0!
        Me.productID.HeaderText = "Product ID"
        Me.productID.Name = "productID"
        Me.productID.ReadOnly = True
        '
        'productName
        '
        Me.productName.DataPropertyName = "productName"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.productName.DefaultCellStyle = DataGridViewCellStyle7
        Me.productName.HeaderText = "Product Name"
        Me.productName.Name = "productName"
        Me.productName.ReadOnly = True
        '
        'quantityReceived
        '
        Me.quantityReceived.DataPropertyName = "quantityReceived"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.quantityReceived.DefaultCellStyle = DataGridViewCellStyle8
        Me.quantityReceived.FillWeight = 90.0!
        Me.quantityReceived.HeaderText = "Quantity Received"
        Me.quantityReceived.Name = "quantityReceived"
        Me.quantityReceived.ReadOnly = True
        '
        'quantityDefective
        '
        Me.quantityDefective.DataPropertyName = "quantityDefective"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.quantityDefective.DefaultCellStyle = DataGridViewCellStyle9
        Me.quantityDefective.FillWeight = 95.0!
        Me.quantityDefective.HeaderText = "Quantity Defective"
        Me.quantityDefective.Name = "quantityDefective"
        Me.quantityDefective.ReadOnly = True
        '
        'remarks
        '
        Me.remarks.DataPropertyName = "remarks"
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.Name = "remarks"
        Me.remarks.ReadOnly = True
        '
        'deliveryDate
        '
        Me.deliveryDate.DataPropertyName = "deliveryDate"
        Me.deliveryDate.HeaderText = "Delivery Date"
        Me.deliveryDate.Name = "deliveryDate"
        Me.deliveryDate.ReadOnly = True
        '
        'receivedBy
        '
        Me.receivedBy.DataPropertyName = "receivedBy"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.receivedBy.DefaultCellStyle = DataGridViewCellStyle10
        Me.receivedBy.HeaderText = "Received By"
        Me.receivedBy.Name = "receivedBy"
        Me.receivedBy.ReadOnly = True
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(977, 499)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 27)
        Me.btnClose.TabIndex = 240
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'pnlBar
        '
        Me.pnlBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlBar.Controls.Add(Me.PictureBox1)
        Me.pnlBar.Controls.Add(Me.Label1)
        Me.pnlBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlBar.Name = "pnlBar"
        Me.pnlBar.Size = New System.Drawing.Size(1089, 49)
        Me.pnlBar.TabIndex = 241
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 41)
        Me.PictureBox1.TabIndex = 114
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(158, 28)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Delivery History"
        '
        'DeliverHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 547)
        Me.Controls.Add(Me.pnlBar)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvDeliveryHistory)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DeliverHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        CType(Me.dgvDeliveryHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBar.ResumeLayout(False)
        Me.pnlBar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDeliveryHistory As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents deliveryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents orderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents productID As System.Windows.Forms.DataGridViewTextBoxColumn
    Private Shadows WithEvents productName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantityReceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantityDefective As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents deliveryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents receivedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlBar As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
