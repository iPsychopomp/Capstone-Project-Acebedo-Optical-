Public Class doctors
    Private Sub doctors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call dbConn()
        Call LoadDGV("SELECT * FROM db_viewdoctors", doctorsDGV)
        NormalizeDoctorNames(doctorsDGV)
        DgvStyle(doctorsDGV)
        txtSearch.Text = "Search by doctor's name"
        txtSearch.ForeColor = Color.Gray
    End Sub
    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        If txtSearch.Text = "Search by doctor's name" Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Search by doctor's name"
            txtSearch.ForeColor = Color.Gray
        End If
    End Sub
    Public Sub DgvStyle(ByRef doctorsDGV As DataGridView)
        ' Basic Grid Setup
        doctorsDGV.AutoGenerateColumns = False
        doctorsDGV.AllowUserToAddRows = False
        doctorsDGV.AllowUserToDeleteRows = False
        doctorsDGV.RowHeadersVisible = False
        doctorsDGV.BorderStyle = BorderStyle.FixedSingle
        doctorsDGV.BackgroundColor = Color.White
        doctorsDGV.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single
        doctorsDGV.CellBorderStyle = DataGridViewCellBorderStyle.Single
        doctorsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro
        doctorsDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
        doctorsDGV.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        doctorsDGV.EnableHeadersVisualStyles = False
        doctorsDGV.DefaultCellStyle.ForeColor = Color.Black
        doctorsDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        doctorsDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        doctorsDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        doctorsDGV.GridColor = Color.Silver
        doctorsDGV.DefaultCellStyle.Padding = New Padding(5)
        doctorsDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        doctorsDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        doctorsDGV.ReadOnly = True
        doctorsDGV.MultiSelect = False
        doctorsDGV.AllowUserToResizeRows = False
        doctorsDGV.RowTemplate.Height = 30
        doctorsDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        doctorsDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub
    Public Sub LoadDoctors()
        Try
            Call dbConn()
            Call LoadDGV("SELECT * FROM db_viewdoctors", doctorsDGV)
            doctorsDGV.ClearSelection()
            NormalizeDoctorNames(doctorsDGV)
        Catch ex As Exception
            MsgBox("Failed to load data: " & ex.Message, vbCritical, "Error")
        End Try
        DgvStyle(doctorsDGV)

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        Call dbConn()
        Call LoadDGV("SELECT * FROM db_viewdoctors WHERE fullname LIKE ?", doctorsDGV, txtSearch.Text)
        NormalizeDoctorNames(doctorsDGV)
        If doctorsDGV IsNot Nothing AndAlso doctorsDGV.Rows.Count = 0 Then
            MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub doctorsDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles doctorsDGV.CellContentClick
        Try
            If e.RowIndex >= 0 Then

                doctorsDGV.Rows(e.RowIndex).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        End Try
    End Sub

    Private Sub NormalizeDoctorNames(ByRef dgv As DataGridView)
        Try
            If dgv Is Nothing OrElse dgv.Rows.Count = 0 Then Return

            Dim hasFull As Boolean = dgv.Columns.Contains("fullname")
            Dim hasF As Boolean = dgv.Columns.Contains("fname")
            Dim hasM As Boolean = dgv.Columns.Contains("mname")
            Dim hasL As Boolean = dgv.Columns.Contains("lname")

            For Each row As DataGridViewRow In dgv.Rows
                If row.IsNewRow Then Continue For

                Dim display As String = ""
                If hasF AndAlso hasL Then
                    Dim f As String = If(row.Cells("fname").Value, "").ToString().Trim()
                    Dim m As String = If(hasM, If(row.Cells("mname").Value, "").ToString().Trim(), "")
                    Dim l As String = If(row.Cells("lname").Value, "").ToString().Trim()
                    If String.Equals(m, "N/A", StringComparison.OrdinalIgnoreCase) OrElse m = "" Then
                        display = (f & " " & l).Trim()
                    Else
                        display = (f & " " & m & " " & l).Trim()
                    End If
                ElseIf hasFull Then
                    Dim full As String = If(row.Cells("fullname").Value, "").ToString()
                    ' Remove middle N/A tokens and normalize spaces
                    full = full.Replace(" N/A ", " ")
                    full = full.Replace(" N/A", " ")
                    full = full.Replace("N/A ", " ")
                    display = System.Text.RegularExpressions.Regex.Replace(full, "\s+", " ").Trim()
                End If

                If hasFull AndAlso display <> "" Then
                    row.Cells("fullname").Value = display
                End If
            Next
        Catch
            ' Non-blocking
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        If doctorsDGV.SelectedRows.Count = 0 Then
            MsgBox("Please select a record to edit.", vbExclamation, "Edit")
            Exit Sub
        End If

        Dim selectedRow As DataGridViewRow = doctorsDGV.SelectedRows(0)
        Dim doctorID As Integer = selectedRow.Cells("Column1").Value

        Dim editForm As New addDoctors()
        editForm.LoadDoctorData(doctorID)
        editForm.Text = "Edit Doctor"
        Dim dr As DialogResult = editForm.ShowDialog()
        ' Always reload after dialog closes (save or update)
        Try
            LoadDoctors()
            NormalizeDoctorNames(doctorsDGV)
        Catch
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs)
        Using dlg As New addDoctors()
            Dim dr As DialogResult = dlg.ShowDialog()
        End Using
        ' Always reload after dialog closes (save or cancel)
        Try
            LoadDoctors()
            NormalizeDoctorNames(doctorsDGV)
        Catch
        End Try
    End Sub

    Private Sub btnNew_Click_1(sender As Object, e As EventArgs) Handles btnNew.Click
        Using dlg As New addDoctors()
            Dim dr As DialogResult = dlg.ShowDialog()
        End Using
        ' Always reload after dialog closes (save or cancel)
        Try
            LoadDoctors()
            NormalizeDoctorNames(doctorsDGV)
        Catch
        End Try
    End Sub

    Private Sub btnEdit_Click_1(sender As Object, e As EventArgs) Handles btnEdit.Click
        If doctorsDGV.SelectedRows.Count = 0 Then
            MsgBox("Please select a record to edit.", vbExclamation, "Edit")
            Exit Sub
        End If

        Dim selectedRow As DataGridViewRow = doctorsDGV.SelectedRows(0)
        Dim doctorID As Integer = selectedRow.Cells("Column1").Value

        Dim editForm As New addDoctors()
        editForm.LoadDoctorData(doctorID)
        editForm.lblhead.Text = "Edit Doctor Information"
        editForm.pbAdd.Visible = False
        editForm.pbEdit.Visible = True
        Dim dr As DialogResult = editForm.ShowDialog()
        ' Always reload after dialog closes (save or update)
        Try
            LoadDoctors()
            NormalizeDoctorNames(doctorsDGV)
        Catch
        End Try
    End Sub

    Private Sub btnSearch_Click_1(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call dbConn()
        Call LoadDGV("SELECT * FROM db_viewdoctors WHERE fullname LIKE ?", doctorsDGV, txtSearch.Text)
        NormalizeDoctorNames(doctorsDGV)
        If doctorsDGV IsNot Nothing AndAlso doctorsDGV.Rows.Count = 0 Then
            MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class