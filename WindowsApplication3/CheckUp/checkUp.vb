Public Class checkUp
    Private isEditing As Boolean = False
    Private currentCheckupID As Integer = 0
    Public DataSaved As Boolean = False
    Private currentPage As Integer = 0
    Private pageSize As Integer = 20
    Private totalCount As Integer = 0


    Private Sub checkUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure we always use the designed columns (headers/order) and not auto-generated ones
        DgvStyle(checkUpDGV)
        checkUpDGV.AutoGenerateColumns = False
        currentPage = 0
        LoadPage()

        ' Remove cmbFilter functionality - direct search by patient name only
        btnSearch.Enabled = True
        ' Default placeholder
        txtSearch.Text = "Search by patient name"
        txtSearch.ForeColor = Color.Gray
    End Sub
    Private Sub LoadPage()
        modCheckUp.LoadCheckUpPage(checkUpDGV, currentPage, pageSize, totalCount)
        Dim totalPages As Integer = 0
        If pageSize > 0 Then
            totalPages = If(totalCount Mod pageSize = 0, totalCount \ pageSize, (totalCount \ pageSize) + 1)
        End If
        If totalPages <= 0 Then totalPages = 1
        txtPage.Text = "Page " & (currentPage + 1).ToString() & " of " & totalPages.ToString()
        btnBack.Enabled = currentPage > 0
        btnNext.Enabled = currentPage < (totalPages - 1)
    End Sub

    Public Sub DgvStyle(ByRef checkUpDGV As DataGridView)
        ' Basic Grid Setup
        checkUpDGV.AutoGenerateColumns = False
        checkUpDGV.AllowUserToAddRows = False
        checkUpDGV.AllowUserToDeleteRows = False
        checkUpDGV.RowHeadersVisible = False
        checkUpDGV.BorderStyle = BorderStyle.FixedSingle
        checkUpDGV.BackgroundColor = Color.White
        checkUpDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        checkUpDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        checkUpDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        checkUpDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        checkUpDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        checkUpDGV.EnableHeadersVisualStyles = False
        checkUpDGV.DefaultCellStyle.ForeColor = Color.Black
        checkUpDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        checkUpDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        checkUpDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        checkUpDGV.GridColor = Color.Silver
        checkUpDGV.DefaultCellStyle.Padding = New Padding(5)
        checkUpDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        checkUpDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        checkUpDGV.ReadOnly = True
        checkUpDGV.MultiSelect = False
        checkUpDGV.AllowUserToResizeRows = False
        checkUpDGV.RowTemplate.Height = 30
        checkUpDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        checkUpDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub



    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Using check As New CreateCheckUp
            If check.ShowDialog() = DialogResult.OK AndAlso check.DataSaved Then
                LoadPage()
            End If
        End Using

    End Sub

    Private Sub checkUpDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles checkUpDGV.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                checkUpDGV.Rows(e.RowIndex).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        End Try
    End Sub

    Private Sub checkUpDGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles checkUpDGV.CellDoubleClick
        If e.RowIndex >= 0 Then
            ' Check if viewCheckUp form is already open
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is viewCheckUp Then
                    ' Form is already open, bring it to front
                    frm.BringToFront()
                    frm.Focus()
                    Return
                End If
            Next

            Dim patientID As String = checkUpDGV.Rows(e.RowIndex).Cells("patientID").Value.ToString()
            Dim patientName As String = String.Empty
            Try
                patientName = checkUpDGV.Rows(e.RowIndex).Cells("PatientName").Value.ToString()
            Catch
                ' Fallback: ignore if column not present
            End Try

            Dim viewCheckUpForm As New viewCheckUp()
            ' Bind the selected patient name to the label on the view form
            Try
                viewCheckUpForm.lblPatientName.Text = patientName
            Catch
                ' If label is not accessible, ignore
            End Try

            viewCheckUpForm.ViewCheckup(patientID)
            viewCheckUpForm.Show()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If checkUpDGV.SelectedRows.Count > 0 Then
            Dim checkupID As Integer = Convert.ToInt32(checkUpDGV.SelectedRows(0).Cells("Column1").Value)

            If MsgBox("Are you sure you want to edit this record?", vbYesNo + vbQuestion, "Edit") = vbYes Then
                Using editCheckup As New CreateCheckUp()
                    editCheckup.TopMost = True
                    editCheckup.pnlCheckUp.Tag = checkupID
                    editCheckup.LoadCheckup(checkupID)

                    If editCheckup.ShowDialog() = DialogResult.OK AndAlso editCheckup.DataSaved Then
                        ' Refresh the DGV after successful update
                        LoadPage()
                    End If
                End Using
            End If
        Else
            MessageBox.Show("Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim searchValue As String = txtSearch.Text.Trim()

            If String.IsNullOrEmpty(searchValue) Then
                currentPage = 0
                LoadPage()
                Return
            End If

            ' Search by patient name only
            modCheckUp.SearchCheckUps(searchValue, checkUpDGV)
            ' Disable paging controls for filtered results
            txtPage.Text = "Search results"
            btnBack.Enabled = False
            btnNext.Enabled = False

        Catch ex As Exception
            MsgBox("Search Error: " & ex.Message, vbCritical, "Error")
        End Try
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
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            currentPage = 0
            LoadPage()
        End If
    End Sub
    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Search by patient name"
            txtSearch.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        If txtSearch.ForeColor = Color.Gray Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub

End Class
