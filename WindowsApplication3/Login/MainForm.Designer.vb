<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderProductToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderHistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupplierProductsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataBackupRestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateBackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddUserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemLogsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsButtons = New System.Windows.Forms.ToolStrip()
        Me.btnDashboard = New System.Windows.Forms.ToolStripButton()
        Me.btnPatientRecord = New System.Windows.Forms.ToolStripButton()
        Me.btnCheckUp = New System.Windows.Forms.ToolStripButton()
        Me.btnTransactions = New System.Windows.Forms.ToolStripButton()
        Me.btnInventory = New System.Windows.Forms.ToolStripButton()
        Me.btnDoctors = New System.Windows.Forms.ToolStripButton()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.MaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiscountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlFooter.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.tsButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFooter.Controls.Add(Me.lblDate)
        Me.pnlFooter.Controls.Add(Me.lblTime)
        Me.pnlFooter.Controls.Add(Me.lblUser)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 754)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(1207, 40)
        Me.pnlFooter.TabIndex = 8
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(922, 9)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(36, 25)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "---"
        '
        'lblTime
        '
        Me.lblTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.Black
        Me.lblTime.Location = New System.Drawing.Point(1093, 9)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(36, 25)
        Me.lblTime.TabIndex = 2
        Me.lblTime.Text = "---"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Location = New System.Drawing.Point(26, 9)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(36, 25)
        Me.lblUser.TabIndex = 1
        Me.lblUser.Text = "---"
        '
        'Timer1
        '
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MenuStrip.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ManageInventoryToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.UserToolStripMenuItem, Me.MaintenanceToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1207, 33)
        Me.MenuStrip.TabIndex = 1
        Me.MenuStrip.Text = "MenuStrip2"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoutToolStripMenuItem, Me.ProfileToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(53, 29)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(149, 30)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'ProfileToolStripMenuItem
        '
        Me.ProfileToolStripMenuItem.Name = "ProfileToolStripMenuItem"
        Me.ProfileToolStripMenuItem.Size = New System.Drawing.Size(149, 30)
        Me.ProfileToolStripMenuItem.Text = "Profile"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(149, 30)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ManageInventoryToolStripMenuItem
        '
        Me.ManageInventoryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StockInToolStripMenuItem, Me.StockOutToolStripMenuItem, Me.SupplierToolStripMenuItem})
        Me.ManageInventoryToolStripMenuItem.Name = "ManageInventoryToolStripMenuItem"
        Me.ManageInventoryToolStripMenuItem.Size = New System.Drawing.Size(177, 29)
        Me.ManageInventoryToolStripMenuItem.Text = "Manage Inventory"
        '
        'StockInToolStripMenuItem
        '
        Me.StockInToolStripMenuItem.Image = CType(resources.GetObject("StockInToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StockInToolStripMenuItem.Name = "StockInToolStripMenuItem"
        Me.StockInToolStripMenuItem.Size = New System.Drawing.Size(170, 30)
        Me.StockInToolStripMenuItem.Text = "Stock In"
        '
        'StockOutToolStripMenuItem
        '
        Me.StockOutToolStripMenuItem.Image = CType(resources.GetObject("StockOutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.StockOutToolStripMenuItem.Name = "StockOutToolStripMenuItem"
        Me.StockOutToolStripMenuItem.Size = New System.Drawing.Size(170, 30)
        Me.StockOutToolStripMenuItem.Text = "Stock Out"
        '
        'SupplierToolStripMenuItem
        '
        Me.SupplierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrderProductToolStripMenuItem, Me.OrderHistoryToolStripMenuItem, Me.SupplierProductsToolStripMenuItem})
        Me.SupplierToolStripMenuItem.Name = "SupplierToolStripMenuItem"
        Me.SupplierToolStripMenuItem.Size = New System.Drawing.Size(170, 30)
        Me.SupplierToolStripMenuItem.Text = "Supplier"
        '
        'OrderProductToolStripMenuItem
        '
        Me.OrderProductToolStripMenuItem.Image = CType(resources.GetObject("OrderProductToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OrderProductToolStripMenuItem.Name = "OrderProductToolStripMenuItem"
        Me.OrderProductToolStripMenuItem.Size = New System.Drawing.Size(239, 30)
        Me.OrderProductToolStripMenuItem.Text = "Order Products"
        '
        'OrderHistoryToolStripMenuItem
        '
        Me.OrderHistoryToolStripMenuItem.Image = CType(resources.GetObject("OrderHistoryToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OrderHistoryToolStripMenuItem.Name = "OrderHistoryToolStripMenuItem"
        Me.OrderHistoryToolStripMenuItem.Size = New System.Drawing.Size(239, 30)
        Me.OrderHistoryToolStripMenuItem.Text = "Order History"
        '
        'SupplierProductsToolStripMenuItem
        '
        Me.SupplierProductsToolStripMenuItem.Image = CType(resources.GetObject("SupplierProductsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SupplierProductsToolStripMenuItem.Name = "SupplierProductsToolStripMenuItem"
        Me.SupplierProductsToolStripMenuItem.Size = New System.Drawing.Size(239, 30)
        Me.SupplierProductsToolStripMenuItem.Text = "Supplier Products"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataBackupRestoreToolStripMenuItem, Me.ReportsToolStripMenuItem1})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(67, 29)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'DataBackupRestoreToolStripMenuItem
        '
        Me.DataBackupRestoreToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateBackupToolStripMenuItem, Me.RestoreDataToolStripMenuItem})
        Me.DataBackupRestoreToolStripMenuItem.Name = "DataBackupRestoreToolStripMenuItem"
        Me.DataBackupRestoreToolStripMenuItem.Size = New System.Drawing.Size(299, 30)
        Me.DataBackupRestoreToolStripMenuItem.Text = "Data Backup and Restore"
        '
        'CreateBackupToolStripMenuItem
        '
        Me.CreateBackupToolStripMenuItem.Name = "CreateBackupToolStripMenuItem"
        Me.CreateBackupToolStripMenuItem.Size = New System.Drawing.Size(211, 30)
        Me.CreateBackupToolStripMenuItem.Text = "Create Backup"
        '
        'RestoreDataToolStripMenuItem
        '
        Me.RestoreDataToolStripMenuItem.Name = "RestoreDataToolStripMenuItem"
        Me.RestoreDataToolStripMenuItem.Size = New System.Drawing.Size(211, 30)
        Me.RestoreDataToolStripMenuItem.Text = "Restore Data"
        '
        'ReportsToolStripMenuItem1
        '
        Me.ReportsToolStripMenuItem1.Name = "ReportsToolStripMenuItem1"
        Me.ReportsToolStripMenuItem1.Size = New System.Drawing.Size(299, 30)
        Me.ReportsToolStripMenuItem1.Text = "Reports"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManageUsersToolStripMenuItem, Me.SystemLogsToolStripMenuItem})
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(179, 29)
        Me.UserToolStripMenuItem.Text = "User Management"
        '
        'ManageUsersToolStripMenuItem
        '
        Me.ManageUsersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddUserToolStripMenuItem})
        Me.ManageUsersToolStripMenuItem.Image = CType(resources.GetObject("ManageUsersToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ManageUsersToolStripMenuItem.Name = "ManageUsersToolStripMenuItem"
        Me.ManageUsersToolStripMenuItem.Size = New System.Drawing.Size(210, 30)
        Me.ManageUsersToolStripMenuItem.Text = "Manage Users"
        '
        'AddUserToolStripMenuItem
        '
        Me.AddUserToolStripMenuItem.Image = CType(resources.GetObject("AddUserToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem"
        Me.AddUserToolStripMenuItem.Size = New System.Drawing.Size(167, 30)
        Me.AddUserToolStripMenuItem.Text = "Add User"
        '
        'SystemLogsToolStripMenuItem
        '
        Me.SystemLogsToolStripMenuItem.Image = CType(resources.GetObject("SystemLogsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SystemLogsToolStripMenuItem.Name = "SystemLogsToolStripMenuItem"
        Me.SystemLogsToolStripMenuItem.Size = New System.Drawing.Size(210, 30)
        Me.SystemLogsToolStripMenuItem.Text = "System Logs"
        '
        'tsButtons
        '
        Me.tsButtons.AutoSize = False
        Me.tsButtons.BackColor = System.Drawing.Color.White
        Me.tsButtons.GripMargin = New System.Windows.Forms.Padding(0)
        Me.tsButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsButtons.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDashboard, Me.btnPatientRecord, Me.btnCheckUp, Me.btnTransactions, Me.btnInventory, Me.btnDoctors})
        Me.tsButtons.Location = New System.Drawing.Point(0, 33)
        Me.tsButtons.Name = "tsButtons"
        Me.tsButtons.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsButtons.Size = New System.Drawing.Size(1207, 58)
        Me.tsButtons.Stretch = True
        Me.tsButtons.TabIndex = 12
        Me.tsButtons.Text = "Dashboard"
        '
        'btnDashboard
        '
        Me.btnDashboard.AutoSize = False
        Me.btnDashboard.Checked = True
        Me.btnDashboard.CheckOnClick = True
        Me.btnDashboard.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnDashboard.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDashboard.Image = CType(resources.GetObject("btnDashboard.Image"), System.Drawing.Image)
        Me.btnDashboard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDashboard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDashboard.MergeIndex = 0
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Size = New System.Drawing.Size(110, 110)
        Me.btnDashboard.Text = "Dashboard"
        Me.btnDashboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnPatientRecord
        '
        Me.btnPatientRecord.AutoSize = False
        Me.btnPatientRecord.CheckOnClick = True
        Me.btnPatientRecord.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPatientRecord.Image = CType(resources.GetObject("btnPatientRecord.Image"), System.Drawing.Image)
        Me.btnPatientRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPatientRecord.ImageTransparentColor = System.Drawing.Color.Linen
        Me.btnPatientRecord.MergeIndex = 0
        Me.btnPatientRecord.Name = "btnPatientRecord"
        Me.btnPatientRecord.Size = New System.Drawing.Size(110, 110)
        Me.btnPatientRecord.Text = "Patient Record"
        Me.btnPatientRecord.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPatientRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCheckUp
        '
        Me.btnCheckUp.AutoSize = False
        Me.btnCheckUp.CheckOnClick = True
        Me.btnCheckUp.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckUp.Image = CType(resources.GetObject("btnCheckUp.Image"), System.Drawing.Image)
        Me.btnCheckUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCheckUp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCheckUp.MergeIndex = 0
        Me.btnCheckUp.Name = "btnCheckUp"
        Me.btnCheckUp.Size = New System.Drawing.Size(110, 110)
        Me.btnCheckUp.Text = "Check Up"
        Me.btnCheckUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCheckUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnTransactions
        '
        Me.btnTransactions.AutoSize = False
        Me.btnTransactions.CheckOnClick = True
        Me.btnTransactions.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransactions.Image = CType(resources.GetObject("btnTransactions.Image"), System.Drawing.Image)
        Me.btnTransactions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnTransactions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTransactions.MergeIndex = 0
        Me.btnTransactions.Name = "btnTransactions"
        Me.btnTransactions.Size = New System.Drawing.Size(110, 110)
        Me.btnTransactions.Text = "Transactions"
        Me.btnTransactions.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTransactions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnInventory
        '
        Me.btnInventory.AutoSize = False
        Me.btnInventory.CheckOnClick = True
        Me.btnInventory.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventory.Image = CType(resources.GetObject("btnInventory.Image"), System.Drawing.Image)
        Me.btnInventory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnInventory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnInventory.MergeIndex = 0
        Me.btnInventory.Name = "btnInventory"
        Me.btnInventory.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.btnInventory.Size = New System.Drawing.Size(110, 110)
        Me.btnInventory.Text = "Inventory"
        Me.btnInventory.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDoctors
        '
        Me.btnDoctors.AutoSize = False
        Me.btnDoctors.CheckOnClick = True
        Me.btnDoctors.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDoctors.Image = CType(resources.GetObject("btnDoctors.Image"), System.Drawing.Image)
        Me.btnDoctors.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDoctors.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDoctors.MergeIndex = 0
        Me.btnDoctors.Name = "btnDoctors"
        Me.btnDoctors.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.btnDoctors.Size = New System.Drawing.Size(110, 110)
        Me.btnDoctors.Text = "Doctors"
        Me.btnDoctors.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDoctors.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'pnlContainer
        '
        Me.pnlContainer.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(0, 91)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(1207, 663)
        Me.pnlContainer.TabIndex = 13
        '
        'MaintenanceToolStripMenuItem
        '
        Me.MaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TransactionToolStripMenuItem, Me.ProductsToolStripMenuItem, Me.DiscountsToolStripMenuItem})
        Me.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem"
        Me.MaintenanceToolStripMenuItem.Size = New System.Drawing.Size(134, 29)
        Me.MaintenanceToolStripMenuItem.Text = "Maintenance"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(186, 30)
        Me.TransactionToolStripMenuItem.Text = "Transaction"
        '
        'ProductsToolStripMenuItem
        '
        Me.ProductsToolStripMenuItem.Name = "ProductsToolStripMenuItem"
        Me.ProductsToolStripMenuItem.Size = New System.Drawing.Size(186, 30)
        Me.ProductsToolStripMenuItem.Text = "Products"
        '
        'DiscountsToolStripMenuItem
        '
        Me.DiscountsToolStripMenuItem.Name = "DiscountsToolStripMenuItem"
        Me.DiscountsToolStripMenuItem.Size = New System.Drawing.Size(186, 30)
        Me.DiscountsToolStripMenuItem.Text = "Discounts"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1207, 794)
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.tsButtons)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.pnlFooter)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acebedo Optical"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlFooter.ResumeLayout(False)
        Me.pnlFooter.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.tsButtons.ResumeLayout(False)
        Me.tsButtons.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlFooter As System.Windows.Forms.Panel
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsButtons As System.Windows.Forms.ToolStrip
    Friend WithEvents btnDashboard As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPatientRecord As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCheckUp As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnTransactions As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlContainer As System.Windows.Forms.Panel
    Friend WithEvents SystemLogsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnInventory As System.Windows.Forms.ToolStripButton
    Friend WithEvents ManageInventoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataBackupRestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateBackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDoctors As System.Windows.Forms.ToolStripButton
    Friend WithEvents SupplierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrderProductToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrderHistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageUsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddUserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SupplierProductsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProfileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiscountsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
