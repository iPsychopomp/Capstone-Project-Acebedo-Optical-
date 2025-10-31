Public Class users
    Private Sub users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        usersModule.users_Load(UserDGV)
        txtSearch.Text = "Search by username"
        txtSearch.ForeColor = Color.Gray
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        usersModule.btnClose_Click(Me)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        usersModule.btnAdd_Click(UserDGV, AddressOf OnAddRecordClosed)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        usersModule.btnEdit_Click(UserDGV, AddressOf OnAddRecordClosed)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        usersModule.btnSearch_Click(UserDGV, txtSearch)
        ' Show info if no records matched
        If UserDGV.Rows.Count = 0 Then
            MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        usersModule.btnDelete_Click(UserDGV)
    End Sub

    Private Sub OnAddRecordClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        usersModule.OnAddRecordClosed(UserDGV)
    End Sub
    Public Sub DgvStyle(ByRef AuditDGV As DataGridView)
        ' Basic Grid Setup
        AuditDGV.AutoGenerateColumns = False
        AuditDGV.AllowUserToAddRows = False
        AuditDGV.AllowUserToDeleteRows = False
        AuditDGV.RowHeadersVisible = False
        AuditDGV.BorderStyle = BorderStyle.FixedSingle
        AuditDGV.BackgroundColor = Color.White
        AuditDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        AuditDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        AuditDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        AuditDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        AuditDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        AuditDGV.EnableHeadersVisualStyles = False
        AuditDGV.DefaultCellStyle.ForeColor = Color.Black
        AuditDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        AuditDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        AuditDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        AuditDGV.GridColor = Color.Silver
        AuditDGV.DefaultCellStyle.Padding = New Padding(5)
        AuditDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        AuditDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        AuditDGV.ReadOnly = True
        AuditDGV.MultiSelect = False
        AuditDGV.AllowUserToResizeRows = False
        AuditDGV.RowTemplate.Height = 30
        AuditDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        AuditDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        If txtSearch.Text = "Search by username" Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Search by username"
            txtSearch.ForeColor = Color.Gray
        End If
    End Sub
End Class