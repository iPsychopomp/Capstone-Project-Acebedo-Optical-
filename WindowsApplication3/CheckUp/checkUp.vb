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
    Public Sub LoadPage()
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
        checkUpDGV.RowTemplate.Height = 25
        checkUpDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        checkUpDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None

        ' Disable sorting on the DataGridView itself
        checkUpDGV.AllowUserToOrderColumns = False

        ' Hide checkup ID column (Column1) and patientID column
        For Each col As DataGridViewColumn In checkUpDGV.Columns
            If col.Name = "Column1" OrElse col.Name = "patientID" Then
                col.Visible = False
            End If
            ' Disable sorting to remove sort arrows
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        ' Clear any existing sort
        If checkUpDGV.SortedColumn IsNot Nothing Then
            checkUpDGV.DataSource = checkUpDGV.DataSource
        End If

        checkUpDGV.Refresh()
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

    'Private Sub checkUpDGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles checkUpDGV.CellDoubleClick
    '    If e.RowIndex >= 0 Then
    '        ' Check if viewCheckUp form is already open
    '        For Each frm As Form In Application.OpenForms
    '            If TypeOf frm Is viewCheckUp Then
    '                ' Form is already open, bring it to front
    '                frm.BringToFront()
    '                frm.Focus()
    '                Return
    '            End If
    '        Next

    '        Dim patientID As String = checkUpDGV.Rows(e.RowIndex).Cells("patientID").Value.ToString()
    '        Dim patientName As String = String.Empty
    '        Try
    '            patientName = checkUpDGV.Rows(e.RowIndex).Cells("PatientName").Value.ToString()
    '        Catch
    '            ' Fallback: ignore if column not present
    '        End Try

    '        Dim viewCheckUpForm As New viewCheckUp()
    '        ' Bind the selected patient name to the label on the view form
    '        Try
    '            viewCheckUpForm.lblPatientName.Text = patientName
    '        Catch
    '            ' If label is not accessible, ignore
    '        End Try

    '        viewCheckUpForm.ViewCheckup(patientID)
    '        viewCheckUpForm.Show()
    '    End If
    'End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try
            ' Require explicit row selection
            If checkUpDGV.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a record to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim row As DataGridViewRow = checkUpDGV.SelectedRows(0)

            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is viewCheckUp Then
                    frm.BringToFront()
                    frm.Focus()
                    Return
                End If
            Next

            Dim patientID As String = ""
            Try
                patientID = row.Cells("patientID").Value.ToString()
            Catch
                MessageBox.Show("Unable to determine Patient ID from the selected row.", "View", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End Try

            Dim patientName As String = String.Empty
            Try
                patientName = row.Cells("PatientName").Value.ToString()
            Catch
            End Try

            Dim viewCheckUpForm As New viewCheckUp()
            Try
                viewCheckUpForm.lblPatientName.Text = patientName
            Catch
            End Try

            viewCheckUpForm.ViewCheckup(patientID)
            viewCheckUpForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        End Try
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

    Private Sub btnAppointment_Click(sender As Object, e As EventArgs) Handles btnAppointment.Click
        If checkUpDGV.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a patient record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = checkUpDGV.SelectedRows(0)
        Dim patientID As Integer = 0

        Try
            patientID = Convert.ToInt32(selectedRow.Cells("patientID").Value)
        Catch
            MessageBox.Show("Invalid Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If patientID = 0 Then
            MessageBox.Show("Invalid Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim latestCheckupID As Integer = 0
        Dim patientName As String = ""

        Try
            Call dbConn()
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening database connection: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        ' REMOVED: No longer requiring checkup on same day as appointment scheduling

        ' Fetch the patient name and the latest check-up ID for the patient
        Dim sql As String = "SELECT CONCAT(p.fname, ' ', p.mname, ' ', p.lname) AS fullName, c.checkupID " & _
                    "FROM patient_data p " & _
                    "LEFT JOIN tbl_checkup c ON p.patientID = c.patientID " & _
                    "WHERE p.patientID = ? " & _
                    "ORDER BY c.checkupDate DESC LIMIT 1"

        Try
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", patientID)
                Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

                If reader.Read() Then
                    patientName = reader("fullName").ToString()
                    latestCheckupID = If(IsDBNull(reader("checkupID")), 0, Convert.ToInt32(reader("checkupID")))
                Else
                    MessageBox.Show("No record found for this patient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                reader.Close()
            End Using

            ' Now open the PatientNextAppointment form and pass the patient info
            Dim queue As New PatientNextAppointment()
            queue.selectedPatientID = patientID
            queue.latestCheckupID = latestCheckupID
            queue.PatientName = patientName
            queue.ParentCheckUpForm = Me
            queue.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error fetching patient or checkup data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub btnResched_Click(sender As Object, e As EventArgs) Handles btnResched.Click
        If checkUpDGV.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a patient record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim selectedRow As DataGridViewRow = checkUpDGV.SelectedRows(0)
        Dim patientID As Integer = 0

        Try
            patientID = Convert.ToInt32(selectedRow.Cells("patientID").Value)
        Catch
            MessageBox.Show("Invalid Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If patientID = 0 Then
            MessageBox.Show("Invalid Patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Check if patient has an existing appointment
        Try
            Call dbConn()
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim checkSql As String = "SELECT COUNT(*) FROM tbl_appointments WHERE patientID = ?"
            Using checkCmd As New Odbc.OdbcCommand(checkSql, conn)
                checkCmd.Parameters.AddWithValue("?", patientID)
                Dim appointmentCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If appointmentCount = 0 Then
                    MessageBox.Show("This patient has no existing appointment to reschedule.", "No Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                    Exit Sub
                End If
            End Using

            conn.Close()

            ' Open the Reschedule form
            Dim reschedForm As New Reschedule()
            reschedForm.selectedPatientID = patientID
            reschedForm.ParentCheckUpForm = Me
            reschedForm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

End Class
