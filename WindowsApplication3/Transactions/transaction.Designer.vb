﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transaction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Transaction))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.pnlBar = New System.Windows.Forms.Panel()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSettle = New System.Windows.Forms.Button()
        Me.rbPaid = New System.Windows.Forms.RadioButton()
        Me.rbPending = New System.Windows.Forms.RadioButton()
        Me.pnlTrans = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPending = New System.Windows.Forms.TextBox()
        Me.Total = New System.Windows.Forms.Label()
        Me.txtAmountTotal = New System.Windows.Forms.TextBox()
        Me.transactionDGV = New System.Windows.Forms.DataGridView()
        Me.Column0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlBar.SuspendLayout()
        Me.pnlTrans.SuspendLayout()
        CType(Me.transactionDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(1338, 11)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(97, 35)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSearch, "Search")
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(1175, 17)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(157, 32)
        Me.txtSearch.TabIndex = 7
        '
        'pnlBar
        '
        Me.pnlBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlBar.Controls.Add(Me.btnEdit)
        Me.pnlBar.Controls.Add(Me.btnSettle)
        Me.pnlBar.Controls.Add(Me.rbPaid)
        Me.pnlBar.Controls.Add(Me.rbPending)
        Me.pnlBar.Controls.Add(Me.btnSearch)
        Me.pnlBar.Controls.Add(Me.txtSearch)
        Me.pnlBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlBar.Name = "pnlBar"
        Me.pnlBar.Size = New System.Drawing.Size(1447, 57)
        Me.pnlBar.TabIndex = 9
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.Black
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(172, 11)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(81, 35)
        Me.btnEdit.TabIndex = 11
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEdit, "Edit Transaction")
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnSettle
        '
        Me.btnSettle.BackColor = System.Drawing.Color.White
        Me.btnSettle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettle.ForeColor = System.Drawing.Color.Black
        Me.btnSettle.Image = CType(resources.GetObject("btnSettle.Image"), System.Drawing.Image)
        Me.btnSettle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSettle.Location = New System.Drawing.Point(12, 11)
        Me.btnSettle.Name = "btnSettle"
        Me.btnSettle.Size = New System.Drawing.Size(154, 35)
        Me.btnSettle.TabIndex = 10
        Me.btnSettle.Text = "Settle Balance"
        Me.btnSettle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSettle, "Settle remaining balance")
        Me.btnSettle.UseVisualStyleBackColor = False
        '
        'rbPaid
        '
        Me.rbPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbPaid.AutoSize = True
        Me.rbPaid.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPaid.Location = New System.Drawing.Point(1100, 19)
        Me.rbPaid.Name = "rbPaid"
        Me.rbPaid.Size = New System.Drawing.Size(69, 29)
        Me.rbPaid.TabIndex = 9
        Me.rbPaid.TabStop = True
        Me.rbPaid.Text = "Paid"
        Me.ToolTip1.SetToolTip(Me.rbPaid, "Sort by paid payment")
        Me.rbPaid.UseVisualStyleBackColor = True
        '
        'rbPending
        '
        Me.rbPending.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbPending.AutoSize = True
        Me.rbPending.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPending.Location = New System.Drawing.Point(1004, 18)
        Me.rbPending.Name = "rbPending"
        Me.rbPending.Size = New System.Drawing.Size(102, 29)
        Me.rbPending.TabIndex = 8
        Me.rbPending.TabStop = True
        Me.rbPending.Text = "Pending"
        Me.ToolTip1.SetToolTip(Me.rbPending, "Sort by pending payment")
        Me.rbPending.UseVisualStyleBackColor = True
        '
        'pnlTrans
        '
        Me.pnlTrans.Controls.Add(Me.Label1)
        Me.pnlTrans.Controls.Add(Me.txtPending)
        Me.pnlTrans.Controls.Add(Me.Total)
        Me.pnlTrans.Controls.Add(Me.txtAmountTotal)
        Me.pnlTrans.Controls.Add(Me.transactionDGV)
        Me.pnlTrans.Controls.Add(Me.pnlBar)
        Me.pnlTrans.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTrans.Location = New System.Drawing.Point(0, 0)
        Me.pnlTrans.Name = "pnlTrans"
        Me.pnlTrans.Size = New System.Drawing.Size(1447, 678)
        Me.pnlTrans.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(787, 655)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 25)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Total:"
        '
        'txtPending
        '
        Me.txtPending.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPending.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPending.Location = New System.Drawing.Point(838, 651)
        Me.txtPending.Name = "txtPending"
        Me.txtPending.Size = New System.Drawing.Size(151, 32)
        Me.txtPending.TabIndex = 13
        Me.txtPending.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Total
        '
        Me.Total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Total.AutoSize = True
        Me.Total.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total.Location = New System.Drawing.Point(1088, 655)
        Me.Total.Name = "Total"
        Me.Total.Size = New System.Drawing.Size(56, 25)
        Me.Total.TabIndex = 12
        Me.Total.Text = "Total:"
        '
        'txtAmountTotal
        '
        Me.txtAmountTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAmountTotal.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountTotal.Location = New System.Drawing.Point(1138, 651)
        Me.txtAmountTotal.Name = "txtAmountTotal"
        Me.txtAmountTotal.Size = New System.Drawing.Size(151, 32)
        Me.txtAmountTotal.TabIndex = 11
        Me.txtAmountTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'transactionDGV
        '
        Me.transactionDGV.AllowUserToAddRows = False
        Me.transactionDGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.transactionDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.transactionDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.transactionDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.transactionDGV.BackgroundColor = System.Drawing.Color.White
        Me.transactionDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.transactionDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.transactionDGV.ColumnHeadersHeight = 50
        Me.transactionDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.transactionDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column0, Me.Column1, Me.Column2, Me.Column7, Me.Column6, Me.Column5, Me.Column9, Me.Column8, Me.Column3, Me.Column4})
        Me.transactionDGV.GridColor = System.Drawing.Color.Black
        Me.transactionDGV.Location = New System.Drawing.Point(0, 58)
        Me.transactionDGV.MultiSelect = False
        Me.transactionDGV.Name = "transactionDGV"
        Me.transactionDGV.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.transactionDGV.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.transactionDGV.RowHeadersVisible = False
        Me.transactionDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.transactionDGV.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.transactionDGV.RowTemplate.Height = 30
        Me.transactionDGV.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.transactionDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.transactionDGV.Size = New System.Drawing.Size(1447, 594)
        Me.transactionDGV.TabIndex = 10
        '
        'Column0
        '
        Me.Column0.DataPropertyName = "transactionID"
        Me.Column0.HeaderText = "Transaction ID"
        Me.Column0.Name = "Column0"
        Me.Column0.ReadOnly = True
        Me.Column0.Visible = False
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.DataPropertyName = "patientID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.FillWeight = 74.61929!
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 40
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.DataPropertyName = "patientName"
        Me.Column2.FillWeight = 281.0131!
        Me.Column2.HeaderText = "Patient Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 420
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column7.DataPropertyName = "typeOfPayment"
        Me.Column7.FillWeight = 56.20261!
        Me.Column7.HeaderText = "Type of Payment"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 150
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column6.DataPropertyName = "amountPaid"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column6.FillWeight = 50.0!
        Me.Column6.HeaderText = "Amount Paid"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 150
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column5.DataPropertyName = "date"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column5.FillWeight = 80.0!
        Me.Column5.HeaderText = "Date"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 150
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column9.DataPropertyName = "pendingBalance"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column9.FillWeight = 140.0!
        Me.Column9.HeaderText = "Balance"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 150
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column8.DataPropertyName = "settlementDate"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column8.HeaderText = "Settlement Date"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 150
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column3.DataPropertyName = "totalPayment"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column3.FillWeight = 42.15196!
        Me.Column3.HeaderText = "Total Amount"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 150
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column4.DataPropertyName = "paymentStatus"
        Me.Column4.HeaderText = "Payment Status"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 140
        '
        'Transaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1447, 678)
        Me.Controls.Add(Me.pnlTrans)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Transaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "transaction"
        Me.pnlBar.ResumeLayout(False)
        Me.pnlBar.PerformLayout()
        Me.pnlTrans.ResumeLayout(False)
        Me.pnlTrans.PerformLayout()
        CType(Me.transactionDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents pnlBar As System.Windows.Forms.Panel
    Friend WithEvents pnlTrans As System.Windows.Forms.Panel
    Friend WithEvents transactionDGV As System.Windows.Forms.DataGridView
    Friend WithEvents txtAmountTotal As System.Windows.Forms.TextBox
    Friend WithEvents Total As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPending As System.Windows.Forms.TextBox
    Friend WithEvents rbPaid As System.Windows.Forms.RadioButton
    Friend WithEvents rbPending As System.Windows.Forms.RadioButton
    Friend WithEvents btnSettle As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Column0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
