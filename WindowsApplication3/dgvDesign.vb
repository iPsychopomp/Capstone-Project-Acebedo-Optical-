Module dgvDesign
    Public Sub DgvStyle(ByRef dgv As DataGridView)
        ' Basic Grid Setup
        dgv.AutoGenerateColumns = False
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.RowHeadersVisible = False
        dgv.BorderStyle = BorderStyle.FixedSingle
        dgv.BackgroundColor = Color.White
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single

        ' Header Styling (gray)
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(119, 136, 153) ' Gray
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        dgv.EnableHeadersVisualStyles = False

        ' Alternating Rows (Light Green & White)
        dgv.DefaultCellStyle.BackColor = Color.White
        dgv.DefaultCellStyle.ForeColor = Color.Pink
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro


        ' Selection Style
        dgv.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        dgv.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Custom Borders & Padding
        dgv.GridColor = Color.FromArgb(220, 220, 220)
        dgv.DefaultCellStyle.Padding = New Padding(5)
        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Interaction Restrictions
        dgv.ReadOnly = True
        dgv.MultiSelect = False
        dgv.AllowUserToResizeRows = False
        dgv.RowTemplate.Height = 28
        dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

    End Sub

End Module
