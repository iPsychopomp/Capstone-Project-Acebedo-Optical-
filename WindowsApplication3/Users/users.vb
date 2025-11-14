Public Class users
    Private currentPage As Integer = 0
    Private pageSize As Integer = 20
    Private totalCount As Integer = 0
    Private Sub users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentPage = 0
        LoadPage()
        txtSearch.Text = "Search by username"
        txtSearch.ForeColor = Color.Gray
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        usersModule.btnClose_Click(Me)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            ' Store the current form's visibility state
            Dim wasVisible As Boolean = Me.Visible

            ' Hide this users form
            Me.Visible = False

            ' Call the module method which will show the addUsers form
            usersModule.btnAdd_Click(UserDGV, AddressOf OnAddRecordClosed)

            ' Restore this form's visibility
            Me.Visible = wasVisible
        Catch ex As Exception
            ' Ensure this form is shown even if there's an error
            Me.Visible = True
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            ' Store the current form's visibility state
            Dim wasVisible As Boolean = Me.Visible

            ' Hide this users form
            Me.Visible = False

            ' Call the module method which will show the addUsers form
            usersModule.btnEdit_Click(UserDGV, AddressOf OnAddRecordClosed)

            ' Restore this form's visibility
            Me.Visible = wasVisible
        Catch ex As Exception
            ' Ensure this form is shown even if there's an error
            Me.Visible = True
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        usersModule.btnSearch_Click(UserDGV, txtSearch)
        ' Show info if no records matched
        If UserDGV.Rows.Count = 0 Then
            MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        ' Disable paging while showing search results
        txtPage.Text = "Search results"
        btnBack.Enabled = False
        btnNext.Enabled = False
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

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            currentPage = 0
            LoadPage()
        End If
    End Sub

    Private Sub LoadPage()
        usersModule.LoadUsersPage(UserDGV, currentPage, pageSize, totalCount)
        Dim totalPages As Integer = 0
        If pageSize > 0 Then
            totalPages = If(totalCount Mod pageSize = 0, totalCount \ pageSize, (totalCount \ pageSize) + 1)
        End If
        If totalPages <= 0 Then totalPages = 1
        txtPage.Text = "Page " & (currentPage + 1).ToString() & " of " & totalPages.ToString()
        btnBack.Enabled = currentPage > 0
        btnNext.Enabled = currentPage < (totalPages - 1)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If currentPage > 0 Then
            currentPage -= 1
            LoadPage()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim totalPages As Integer = If(pageSize > 0, If(totalCount Mod pageSize = 0, totalCount \ pageSize, (totalCount \ pageSize) + 1), 1)
        If currentPage < (totalPages - 1) Then
            currentPage += 1
            LoadPage()
        End If
    End Sub
End Class