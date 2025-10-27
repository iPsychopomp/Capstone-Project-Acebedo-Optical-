<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class checkProducts
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(checkProducts))
        Me.dgvOrderItems = New System.Windows.Forms.DataGridView()
        Me.itemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.productID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.productName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantityReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QuantityDefective = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pendingQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnOrderReceived = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlBar = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.dgvOrderItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvOrderItems
        '
        Me.dgvOrderItems.AllowUserToAddRows = False
        Me.dgvOrderItems.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvOrderItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvOrderItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvOrderItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvOrderItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOrderItems.ColumnHeadersHeight = 50
        Me.dgvOrderItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemID, Me.Column1, Me.productID, Me.productName, Me.quantity, Me.QuantityReceived, Me.QuantityDefective, Me.pendingQuantity, Me.remarks})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOrderItems.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvOrderItems.GridColor = System.Drawing.Color.Black
        Me.dgvOrderItems.Location = New System.Drawing.Point(-3, 49)
        Me.dgvOrderItems.MultiSelect = False
        Me.dgvOrderItems.Name = "dgvOrderItems"
        Me.dgvOrderItems.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvOrderItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvOrderItems.RowHeadersVisible = False
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvOrderItems.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvOrderItems.RowTemplate.Height = 40
        Me.dgvOrderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrderItems.Size = New System.Drawing.Size(1023, 424)
        Me.dgvOrderItems.TabIndex = 225
        '
        'itemID
        '
        Me.itemID.DataPropertyName = "itemID"
        Me.itemID.HeaderText = "Item ID"
        Me.itemID.Name = "itemID"
        Me.itemID.ReadOnly = True
        Me.itemID.Visible = False
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "orderID"
        Me.Column1.HeaderText = "Order ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'productID
        '
        Me.productID.DataPropertyName = "productID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.productID.DefaultCellStyle = DataGridViewCellStyle3
        Me.productID.FillWeight = 60.0!
        Me.productID.HeaderText = "Product ID"
        Me.productID.Name = "productID"
        Me.productID.ReadOnly = True
        '
        'productName
        '
        Me.productName.DataPropertyName = "productName"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.productName.DefaultCellStyle = DataGridViewCellStyle4
        Me.productName.FillWeight = 120.0!
        Me.productName.HeaderText = "Product Name"
        Me.productName.Name = "productName"
        Me.productName.ReadOnly = True
        '
        'quantity
        '
        Me.quantity.DataPropertyName = "quantity"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.quantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.quantity.FillWeight = 90.0!
        Me.quantity.HeaderText = "Quantity Ordered"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        '
        'QuantityReceived
        '
        Me.QuantityReceived.DataPropertyName = "quantityReceived"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.QuantityReceived.DefaultCellStyle = DataGridViewCellStyle6
        Me.QuantityReceived.FillWeight = 90.0!
        Me.QuantityReceived.HeaderText = "Quantity Received"
        Me.QuantityReceived.Name = "QuantityReceived"
        Me.QuantityReceived.ReadOnly = True
        '
        'QuantityDefective
        '
        Me.QuantityDefective.DataPropertyName = "quantityDefective"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.QuantityDefective.DefaultCellStyle = DataGridViewCellStyle7
        Me.QuantityDefective.FillWeight = 90.0!
        Me.QuantityDefective.HeaderText = "Quantity Defective"
        Me.QuantityDefective.Name = "QuantityDefective"
        Me.QuantityDefective.ReadOnly = True
        '
        'pendingQuantity
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.pendingQuantity.DefaultCellStyle = DataGridViewCellStyle8
        Me.pendingQuantity.FillWeight = 90.0!
        Me.pendingQuantity.HeaderText = "Pending Quantity"
        Me.pendingQuantity.Name = "pendingQuantity"
        Me.pendingQuantity.ReadOnly = True
        '
        'remarks
        '
        Me.remarks.DataPropertyName = "remarks"
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.Name = "remarks"
        Me.remarks.ReadOnly = True
        '
        'btnOrderReceived
        '
        Me.btnOrderReceived.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnOrderReceived.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOrderReceived.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrderReceived.ForeColor = System.Drawing.Color.Black
        Me.btnOrderReceived.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOrderReceived.Location = New System.Drawing.Point(37, 495)
        Me.btnOrderReceived.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOrderReceived.Name = "btnOrderReceived"
        Me.btnOrderReceived.Size = New System.Drawing.Size(100, 27)
        Me.btnOrderReceived.TabIndex = 238
        Me.btnOrderReceived.Text = "Received"
        Me.btnOrderReceived.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(876, 495)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 27)
        Me.btnClose.TabIndex = 239
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'pnlBar
        '
        Me.pnlBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlBar.Controls.Add(Me.PictureBox1)
        Me.pnlBar.Controls.Add(Me.Label7)
        Me.pnlBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlBar.Name = "pnlBar"
        Me.pnlBar.Size = New System.Drawing.Size(1019, 49)
        Me.pnlBar.TabIndex = 243
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 41)
        Me.PictureBox1.TabIndex = 114
        Me.PictureBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(44, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 28)
        Me.Label7.TabIndex = 113
        Me.Label7.Text = "Check Products"
        '
        'checkProducts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 548)
        Me.Controls.Add(Me.pnlBar)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOrderReceived)
        Me.Controls.Add(Me.dgvOrderItems)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "checkProducts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        CType(Me.dgvOrderItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBar.ResumeLayout(False)
        Me.pnlBar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvOrderItems As System.Windows.Forms.DataGridView
    Friend WithEvents btnOrderReceived As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents itemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents productID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend Shadows WithEvents productName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityReceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityDefective As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pendingQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlBar As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
