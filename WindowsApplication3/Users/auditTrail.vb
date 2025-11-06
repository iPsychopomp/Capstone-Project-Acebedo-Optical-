Public Class auditTrail
    Private currentPage As Integer = 0
    Private pageSize As Integer = 20
    Private totalCount As Integer = 0

    Private Sub productDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles AuditDGV.CellContentClick
        Try
            If e.RowIndex >= 0 Then

                AuditDGV.Rows(e.RowIndex).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call dbConn()
        Call LoadDGV("SELECT * FROM tbl_audit_trail WHERE username LIKE ? ORDER BY auditID DESC", AuditDGV, txtSearch.Text)
        ' Show info if no records matched
        If AuditDGV.Rows.Count = 0 Then
            MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        ' Disable paging while showing search results
        txtPage.Text = "Search results"
        btnBack.Enabled = False
        btnNext.Enabled = False
    End Sub

    Private Sub auditTrail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentPage = 0
        LoadPage()
        DgvStyle(AuditDGV)
        txtSearch.Text = "Search by username"
        txtSearch.ForeColor = Color.Gray
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Me.Close()
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
        Try
            AuditDGV.AutoGenerateColumns = False

            Dim countSql As String = "SELECT COUNT(*) FROM tbl_audit_trail"
            Dim dataSql As String = _
                "SELECT * FROM tbl_audit_trail " & _
                "ORDER BY auditID DESC " & _
                "LIMIT ? OFFSET ?"

            Using cn As New Odbc.OdbcConnection(myDSN)
                cn.Open()
                Using cmdCount As New Odbc.OdbcCommand(countSql, cn)
                    Dim obj = cmdCount.ExecuteScalar()
                    totalCount = 0
                    If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                        Integer.TryParse(obj.ToString(), totalCount)
                    End If
                End Using

                Using cmd As New Odbc.OdbcCommand(dataSql, cn)
                    cmd.Parameters.AddWithValue("?", pageSize)
                    cmd.Parameters.AddWithValue("?", currentPage * pageSize)
                    Dim da As New Odbc.OdbcDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    AuditDGV.DataSource = dt
                    AuditDGV.ClearSelection()
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Failed to load audit logs: " & ex.Message, vbCritical, "Error")
        End Try

        ' Update page indicators
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