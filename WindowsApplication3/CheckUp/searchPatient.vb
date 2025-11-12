Imports System.Data.Odbc

Public Class searchPatient

    ' Pagination state
    Private currentPage As Integer = 1
    Private ReadOnly pageSize As Integer = 20
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 1
    Private currentSearchTerm As String = ""

    Private Sub searchPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPatientSearch()
        DgvStyle(searchPatientDGV)
        txtSearch.Text = "Search by patient name"
        txtSearch.ForeColor = Color.Gray
    End Sub

    Private Sub LoadPatientSearch()
        Dim dt As New DataTable()
        Try
            ' Normalize search term (ignore placeholder styling)
            Dim term As String = currentSearchTerm

            ' Count total records for pagination
            dbConn()
            Using countCmd As New OdbcCommand("SELECT COUNT(*) FROM db_viewpatientsearch WHERE fullname LIKE ?", conn)
                countCmd.Parameters.AddWithValue("?", If(String.IsNullOrEmpty(term), "%", "%" & term & "%"))
                totalRecords = Convert.ToInt32(countCmd.ExecuteScalar())
            End Using

            ' Compute total pages (at least 1)
            totalPages = Math.Max(1, CInt(Math.Ceiling(totalRecords / CDbl(pageSize))))
            ' Clamp current page to bounds
            If currentPage < 1 Then currentPage = 1
            If currentPage > totalPages Then currentPage = totalPages

            ' Fetch current page records
            Dim offset As Integer = (currentPage - 1) * pageSize
            Using cmd As New OdbcCommand("SELECT * FROM db_viewpatientsearch WHERE fullname LIKE ? ORDER BY fullname ASC LIMIT ? OFFSET ?", conn)
                cmd.Parameters.AddWithValue("?", If(String.IsNullOrEmpty(term), "%", "%" & term & "%"))
                cmd.Parameters.AddWithValue("?", pageSize)
                cmd.Parameters.AddWithValue("?", offset)
                Using da As New OdbcDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            searchPatientDGV.AutoGenerateColumns = False
            searchPatientDGV.DataSource = dt

            UpdatePageLabel()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        Finally
            Try
                If conn IsNot Nothing Then
                    conn.Close()
                    conn.Dispose()
                End If
            Catch
            End Try
            GC.Collect()
        End Try
    End Sub

    Private Sub UpdatePageLabel()
        Try
            If txtPage IsNot Nothing Then
                txtPage.Text = String.Format("Page {0} of {1}", currentPage, totalPages)
            End If
        Catch
        End Try
        ' Optionally enable/disable buttons
        Try
            If btnBack IsNot Nothing Then btnBack.Enabled = (currentPage > 1)
            If btnNext IsNot Nothing Then btnNext.Enabled = (currentPage < totalPages)
        Catch
        End Try
    End Sub

    Private Sub searchPatientDGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles searchPatientDGV.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Return

            Dim row As DataGridViewRow = searchPatientDGV.Rows(e.RowIndex)

            Dim patientID As String = ""
            Dim fullname As String = ""
            Dim bdayStr As String = ""

            Try
                patientID = row.Cells("Column1").Value.ToString()
            Catch
            End Try
            Try
                fullname = row.Cells("Column2").Value.ToString()
            Catch
            End Try
            Try
                bdayStr = row.Cells("Column4").Value.ToString()
            Catch
            End Try

            Dim targetForm As CreateCheckUp = Nothing
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is CreateCheckUp Then
                    targetForm = DirectCast(frm, CreateCheckUp)
                    Exit For
                End If
            Next

            If targetForm Is Nothing Then
                Me.Close()
                Return
            End If

            Try
                targetForm.txtPName.Text = fullname
                targetForm.txtPName.Tag = If(String.IsNullOrEmpty(patientID), Nothing, patientID)
            Catch
            End Try

            Try
                Dim parsed As DateTime
                If DateTime.TryParse(bdayStr, parsed) Then
                    targetForm.dtpBday.Value = parsed
                End If
            Catch
            End Try

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim term As String = txtSearch.Text.Trim()
        ' Respect placeholder
        If txtSearch.ForeColor = Color.Gray Then term = ""
        currentSearchTerm = term
        currentPage = 1
        LoadPatientSearch()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If currentPage > 1 Then
            currentPage -= 1
            LoadPatientSearch()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentPage < totalPages Then
            currentPage += 1
            LoadPatientSearch()
        End If
    End Sub

    Private Sub btnAddP_Click(sender As Object, e As EventArgs) Handles btnAddP.Click
        Try
            Using frm As New addPatient()
                Dim result As DialogResult = frm.ShowDialog()
                If result = DialogResult.OK Then
                    LoadPatientSearch()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        End Try
    End Sub

    Public Sub DgvStyle(ByRef patientDGV As DataGridView)
        ' Basic Grid Setup
        patientDGV.AutoGenerateColumns = False
        patientDGV.AllowUserToAddRows = False
        patientDGV.AllowUserToDeleteRows = False
        patientDGV.BorderStyle = BorderStyle.FixedSingle
        patientDGV.BackgroundColor = Color.White
        patientDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        patientDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        patientDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        patientDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        patientDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        patientDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        patientDGV.EnableHeadersVisualStyles = False
        patientDGV.DefaultCellStyle.ForeColor = Color.Black
        patientDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        patientDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        patientDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        patientDGV.GridColor = Color.Silver
        patientDGV.DefaultCellStyle.Padding = New Padding(5)
        patientDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        patientDGV.ReadOnly = True
        patientDGV.MultiSelect = False
        patientDGV.AllowUserToResizeRows = False
        patientDGV.RowTemplate.Height = 30
        patientDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        patientDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        ' Center align all column headers and disable sort mode to hide sort arrows
        For Each col As DataGridViewColumn In patientDGV.Columns
            If col.HeaderCell.Style Is Nothing Then
                col.HeaderCell.Style = New DataGridViewCellStyle()
            End If
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' Disable sorting completely to remove sort arrows
            col.SortMode = DataGridViewColumnSortMode.NotSortable

            ' Center align the ID and Age column data
            If col.Name = "Column1" OrElse col.HeaderText = "ID" OrElse col.Name = "Column4" OrElse col.HeaderText = "Age" Then
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next

        ' Force refresh to apply changes
        patientDGV.Refresh()
    End Sub
    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        If txtSearch.ForeColor = Color.Gray Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Search by patient name"
            txtSearch.ForeColor = Color.Gray
        End If
    End Sub

End Class