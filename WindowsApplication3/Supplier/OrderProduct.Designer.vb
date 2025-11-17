<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderProduct
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
        Dim DataGridViewCellStyle81 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle82 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle89 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle90 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle91 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle83 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle84 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle85 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle86 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle87 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle88 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle92 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle93 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle98 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle99 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle100 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle94 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle95 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle96 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle97 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrderProduct))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOrderedBy = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPlaceOrder = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSuppliers = New System.Windows.Forms.ComboBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgvSelectedProducts = New System.Windows.Forms.DataGridView()
        Me.productID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.productName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCancelOrder = New System.Windows.Forms.Button()
        Me.btnReceived = New System.Windows.Forms.Button()
        Me.dgvOrders = New System.Windows.Forms.DataGridView()
        Me.orderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.supplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.orderDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlBar = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvSelectedProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 55)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(930, 650)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtOrderedBy)
        Me.TabPage1.Controls.Add(Me.txtTotal)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.btnCancel)
        Me.TabPage1.Controls.Add(Me.btnPlaceOrder)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cmbSuppliers)
        Me.TabPage1.Controls.Add(Me.btnRemove)
        Me.TabPage1.Controls.Add(Me.btnAdd)
        Me.TabPage1.Controls.Add(Me.dgvSelectedProducts)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(922, 612)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Order Product"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 465)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 25)
        Me.Label3.TabIndex = 237
        Me.Label3.Text = "Ordered By:"
        '
        'txtOrderedBy
        '
        Me.txtOrderedBy.BackColor = System.Drawing.Color.White
        Me.txtOrderedBy.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderedBy.Location = New System.Drawing.Point(37, 487)
        Me.txtOrderedBy.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOrderedBy.Name = "txtOrderedBy"
        Me.txtOrderedBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtOrderedBy.Size = New System.Drawing.Size(241, 32)
        Me.txtOrderedBy.TabIndex = 236
        Me.txtOrderedBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(741, 487)
        Me.txtTotal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(151, 32)
        Me.txtTotal.TabIndex = 235
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(737, 465)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 25)
        Me.Label2.TabIndex = 234
        Me.Label2.Text = "Total:"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(791, 555)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 27)
        Me.btnCancel.TabIndex = 233
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnPlaceOrder
        '
        Me.btnPlaceOrder.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnPlaceOrder.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPlaceOrder.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlaceOrder.ForeColor = System.Drawing.Color.Black
        Me.btnPlaceOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPlaceOrder.Location = New System.Drawing.Point(36, 555)
        Me.btnPlaceOrder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnPlaceOrder.Name = "btnPlaceOrder"
        Me.btnPlaceOrder.Size = New System.Drawing.Size(100, 27)
        Me.btnPlaceOrder.TabIndex = 232
        Me.btnPlaceOrder.Text = "Order"
        Me.btnPlaceOrder.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 25)
        Me.Label1.TabIndex = 231
        Me.Label1.Text = "Supplier Name:"
        '
        'cmbSuppliers
        '
        Me.cmbSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSuppliers.FormattingEnabled = True
        Me.cmbSuppliers.Location = New System.Drawing.Point(180, 16)
        Me.cmbSuppliers.Name = "cmbSuppliers"
        Me.cmbSuppliers.Size = New System.Drawing.Size(375, 33)
        Me.cmbSuppliers.TabIndex = 228
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRemove.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.Black
        Me.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove.Location = New System.Drawing.Point(775, 17)
        Me.btnRemove.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(139, 27)
        Me.btnRemove.TabIndex = 225
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(622, 16)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(147, 27)
        Me.btnAdd.TabIndex = 224
        Me.btnAdd.Text = "Select Products"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'dgvSelectedProducts
        '
        Me.dgvSelectedProducts.AllowUserToAddRows = False
        Me.dgvSelectedProducts.AllowUserToDeleteRows = False
        DataGridViewCellStyle81.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvSelectedProducts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle81
        Me.dgvSelectedProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSelectedProducts.BackgroundColor = System.Drawing.Color.White
        Me.dgvSelectedProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle82.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle82.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle82.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle82.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle82.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvSelectedProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle82
        Me.dgvSelectedProducts.ColumnHeadersHeight = 50
        Me.dgvSelectedProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSelectedProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.productID, Me.productName, Me.category, Me.product_price, Me.Quantity, Me.Supplier, Me.Total})
        DataGridViewCellStyle89.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle89.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle89.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle89.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle89.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle89.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle89.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSelectedProducts.DefaultCellStyle = DataGridViewCellStyle89
        Me.dgvSelectedProducts.GridColor = System.Drawing.Color.Black
        Me.dgvSelectedProducts.Location = New System.Drawing.Point(-4, 70)
        Me.dgvSelectedProducts.MultiSelect = False
        Me.dgvSelectedProducts.Name = "dgvSelectedProducts"
        Me.dgvSelectedProducts.ReadOnly = True
        DataGridViewCellStyle90.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle90.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle90.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle90.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle90.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle90.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvSelectedProducts.RowHeadersDefaultCellStyle = DataGridViewCellStyle90
        Me.dgvSelectedProducts.RowHeadersVisible = False
        Me.dgvSelectedProducts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle91.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvSelectedProducts.RowsDefaultCellStyle = DataGridViewCellStyle91
        Me.dgvSelectedProducts.RowTemplate.Height = 30
        Me.dgvSelectedProducts.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSelectedProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSelectedProducts.Size = New System.Drawing.Size(930, 385)
        Me.dgvSelectedProducts.TabIndex = 223
        '
        'productID
        '
        DataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.productID.DefaultCellStyle = DataGridViewCellStyle83
        Me.productID.FillWeight = 70.0!
        Me.productID.HeaderText = "Product ID"
        Me.productID.Name = "productID"
        Me.productID.ReadOnly = True
        '
        'productName
        '
        DataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.productName.DefaultCellStyle = DataGridViewCellStyle84
        Me.productName.FillWeight = 120.0!
        Me.productName.HeaderText = "Product Name"
        Me.productName.Name = "productName"
        Me.productName.ReadOnly = True
        '
        'category
        '
        DataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.category.DefaultCellStyle = DataGridViewCellStyle85
        Me.category.FillWeight = 70.0!
        Me.category.HeaderText = "Category"
        Me.category.Name = "category"
        Me.category.ReadOnly = True
        '
        'product_price
        '
        DataGridViewCellStyle86.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.product_price.DefaultCellStyle = DataGridViewCellStyle86
        Me.product_price.FillWeight = 60.0!
        Me.product_price.HeaderText = "Unit Price"
        Me.product_price.Name = "product_price"
        Me.product_price.ReadOnly = True
        '
        'Quantity
        '
        DataGridViewCellStyle87.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Quantity.DefaultCellStyle = DataGridViewCellStyle87
        Me.Quantity.FillWeight = 60.0!
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        '
        'Supplier
        '
        Me.Supplier.FillWeight = 120.0!
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.Name = "Supplier"
        Me.Supplier.ReadOnly = True
        '
        'Total
        '
        DataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle88
        Me.Total.FillWeight = 80.0!
        Me.Total.HeaderText = "Total Price"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.btnClose)
        Me.TabPage2.Controls.Add(Me.btnCancelOrder)
        Me.TabPage2.Controls.Add(Me.btnReceived)
        Me.TabPage2.Controls.Add(Me.dgvOrders)
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(922, 612)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Order History"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(786, 547)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 27)
        Me.btnClose.TabIndex = 236
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnCancelOrder
        '
        Me.btnCancelOrder.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnCancelOrder.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancelOrder.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelOrder.ForeColor = System.Drawing.Color.Black
        Me.btnCancelOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelOrder.Location = New System.Drawing.Point(191, 547)
        Me.btnCancelOrder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCancelOrder.Name = "btnCancelOrder"
        Me.btnCancelOrder.Size = New System.Drawing.Size(150, 27)
        Me.btnCancelOrder.TabIndex = 234
        Me.btnCancelOrder.Text = "Cancel Order"
        Me.btnCancelOrder.UseVisualStyleBackColor = False
        '
        'btnReceived
        '
        Me.btnReceived.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnReceived.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReceived.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceived.ForeColor = System.Drawing.Color.Black
        Me.btnReceived.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReceived.Location = New System.Drawing.Point(35, 547)
        Me.btnReceived.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnReceived.Name = "btnReceived"
        Me.btnReceived.Size = New System.Drawing.Size(150, 27)
        Me.btnReceived.TabIndex = 233
        Me.btnReceived.Text = "Check Products"
        Me.btnReceived.UseVisualStyleBackColor = False
        '
        'dgvOrders
        '
        Me.dgvOrders.AllowUserToAddRows = False
        Me.dgvOrders.AllowUserToDeleteRows = False
        DataGridViewCellStyle92.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvOrders.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle92
        Me.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvOrders.BackgroundColor = System.Drawing.Color.White
        Me.dgvOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle93.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle93.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle93.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle93.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle93.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle93.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvOrders.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle93
        Me.dgvOrders.ColumnHeadersHeight = 50
        Me.dgvOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.orderID, Me.supplierName, Me.orderDate, Me.totalAmount, Me.Column1, Me.Status})
        DataGridViewCellStyle98.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle98.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle98.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle98.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle98.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle98.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle98.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOrders.DefaultCellStyle = DataGridViewCellStyle98
        Me.dgvOrders.GridColor = System.Drawing.Color.Black
        Me.dgvOrders.Location = New System.Drawing.Point(-4, 0)
        Me.dgvOrders.MultiSelect = False
        Me.dgvOrders.Name = "dgvOrders"
        Me.dgvOrders.ReadOnly = True
        DataGridViewCellStyle99.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle99.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle99.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle99.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle99.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle99.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvOrders.RowHeadersDefaultCellStyle = DataGridViewCellStyle99
        Me.dgvOrders.RowHeadersVisible = False
        DataGridViewCellStyle100.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvOrders.RowsDefaultCellStyle = DataGridViewCellStyle100
        Me.dgvOrders.RowTemplate.Height = 40
        Me.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrders.Size = New System.Drawing.Size(930, 525)
        Me.dgvOrders.TabIndex = 224
        '
        'orderID
        '
        Me.orderID.DataPropertyName = "orderID"
        DataGridViewCellStyle94.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.orderID.DefaultCellStyle = DataGridViewCellStyle94
        Me.orderID.FillWeight = 60.0!
        Me.orderID.HeaderText = "Order ID"
        Me.orderID.Name = "orderID"
        Me.orderID.ReadOnly = True
        '
        'supplierName
        '
        Me.supplierName.DataPropertyName = "supplierName"
        Me.supplierName.FillWeight = 120.0!
        Me.supplierName.HeaderText = "Supplier Name"
        Me.supplierName.Name = "supplierName"
        Me.supplierName.ReadOnly = True
        '
        'orderDate
        '
        Me.orderDate.DataPropertyName = "orderDate"
        Me.orderDate.HeaderText = "Order Date"
        Me.orderDate.Name = "orderDate"
        Me.orderDate.ReadOnly = True
        '
        'totalAmount
        '
        Me.totalAmount.DataPropertyName = "totalAmount"
        DataGridViewCellStyle95.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.totalAmount.DefaultCellStyle = DataGridViewCellStyle95
        Me.totalAmount.FillWeight = 70.0!
        Me.totalAmount.HeaderText = "Total Amount"
        Me.totalAmount.Name = "totalAmount"
        Me.totalAmount.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "orderedBy"
        DataGridViewCellStyle96.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle96
        Me.Column1.FillWeight = 80.0!
        Me.Column1.HeaderText = "Ordered By"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Status
        '
        Me.Status.DataPropertyName = "status"
        DataGridViewCellStyle97.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Status.DefaultCellStyle = DataGridViewCellStyle97
        Me.Status.FillWeight = 70.0!
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'pnlBar
        '
        Me.pnlBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlBar.Controls.Add(Me.PictureBox1)
        Me.pnlBar.Controls.Add(Me.Label6)
        Me.pnlBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlBar.Name = "pnlBar"
        Me.pnlBar.Size = New System.Drawing.Size(930, 49)
        Me.pnlBar.TabIndex = 121
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(50, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 28)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "Orders"
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
        'OrderProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 682)
        Me.Controls.Add(Me.pnlBar)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OrderProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvSelectedProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBar.ResumeLayout(False)
        Me.pnlBar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgvSelectedProducts As System.Windows.Forms.DataGridView
    Friend WithEvents cmbSuppliers As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnPlaceOrder As System.Windows.Forms.Button
    Friend WithEvents btnCancelOrder As System.Windows.Forms.Button
    Friend WithEvents btnReceived As System.Windows.Forms.Button
    Friend WithEvents dgvOrders As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOrderedBy As System.Windows.Forms.TextBox
    Friend WithEvents orderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents supplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents orderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlBar As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents productID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend Shadows WithEvents productName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents category As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents product_price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Supplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
