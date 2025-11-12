Imports System.Data.Odbc
Public Class patientRecord
    Private Const PatientIDColumnName As String = "Column1"
    Private currentPage As Integer = 0
    Private pageSize As Integer = 20
    Private totalCount As Integer = 0

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim searchValue As String = txtSearch.Text.Trim()

            ' If search is empty, go back to paginated list
            If String.IsNullOrWhiteSpace(searchValue) Then
                currentPage = 0
                LoadPage()
                Return
            End If

            ' Search by First Name or Full Name
            SearchPatients(searchValue, patientDGV)

        Catch ex As Exception
            MsgBox("Search Error: " & ex.Message, vbCritical, "Error")
        End Try
        ' When filtered, disable paging controls and show status
        txtPage.Text = "Search results"
        btnBack.Enabled = False
        btnNext.Enabled = False
        DgvStyle(patientDGV)
    End Sub

    Public Sub SearchPatients(searchValue As String, dgv As DataGridView)
        Try
            ' Search by Full Name only
            Dim sql As String = "SELECT * FROM db_viewpatient WHERE fullname LIKE ? ORDER BY fullname"

            ' Clear previous data
            dgv.DataSource = Nothing

            Using conn As New OdbcConnection(myDSN)
                Using cmd As New OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", "%" & searchValue & "%")

                    Dim da As New OdbcDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    dgv.DataSource = dt

                    If dgv.Columns.Contains("patientID") Then
                        dgv.Columns("patientID").Visible = False
                    End If
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("Search failed: " & ex.Message)
        End Try
        DgvStyle(patientDGV)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Using NewPatient As New addPatient()
            If NewPatient.ShowDialog() = DialogResult.OK Then
                ' Refresh the grid after adding new patient
                ReloadPatientData()

                ' Select the newly added patient if Tag contains the ID
                If NewPatient.Tag IsNot Nothing Then
                    Dim newPatientID As Integer
                    If Integer.TryParse(NewPatient.Tag.ToString(), newPatientID) Then
                        SelectPatientInGrid(newPatientID)
                    End If
                End If
            End If
        End Using
        DgvStyle(patientDGV)
    End Sub

    Private Sub SelectPatientInGrid(patientID As Integer)
        Try
            ' Verify the column exists
            If Not patientDGV.Columns.Contains(PatientIDColumnName) Then
                MessageBox.Show("Column '" & PatientIDColumnName & "' not found in DataGridView",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            For Each row As DataGridViewRow In patientDGV.Rows
                ' Skip new row if present
                If row.IsNewRow Then Continue For

                Dim cellValue As Object = row.Cells(PatientIDColumnName).Value
                If cellValue IsNot Nothing AndAlso cellValue IsNot DBNull.Value AndAlso
                   cellValue.ToString() = patientID.ToString() Then
                    row.Selected = True
                    patientDGV.FirstDisplayedScrollingRowIndex = row.Index
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error selecting patient: " & ex.Message,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        DgvStyle(patientDGV)
    End Sub

    Private Sub patientDGV_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles patientDGV.CellContentClick
        patientMod.HandleRowSelection(patientDGV, e)
        DgvStyle(patientDGV)
    End Sub

    Private Sub patientRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Remove cmbSearch functionality - direct search by name only
            btnSearch.Enabled = True
            currentPage = 0
            LoadPage()
            ' Default placeholder
            txtSearch.Text = "Search by patient name"
            txtSearch.ForeColor = Color.Gray

            ' Configure column visibility if needed
            'If patientDGV.Columns.Contains(PatientIDColumnName) Then
            '    patientDGV.Columns(PatientIDColumnName).Visible = False ' Hide ID column
            'End If

            ' Apply styling after data is loaded
            DgvStyle(patientDGV)

            ' Age will display as stored in DB
        Catch ex As Exception
            MessageBox.Show("Error loading patient data: " & ex.Message,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub patientDGV_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles patientDGV.CellDoubleClick
        Try
            ' Validate row index
            If e.RowIndex < 0 OrElse e.RowIndex >= patientDGV.Rows.Count OrElse
               patientDGV.Rows(e.RowIndex).IsNewRow Then
                Return
            End If

            ' Get patient ID from the correct column
            Dim cellValue As Object = patientDGV.Rows(e.RowIndex).Cells(PatientIDColumnName).Value
            Dim patientID As Integer

            If cellValue Is Nothing OrElse Not Integer.TryParse(cellValue.ToString(), patientID) Then
                MessageBox.Show("Invalid patient record selected.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Open patient details
            Using actionsForm As New patientActions()
                actionsForm.InitializeForPatient(patientID)
                actionsForm.ShowDialog()
                ReloadPatientData() ' Refresh after closing
            End Using
        Catch ex As Exception
            MessageBox.Show("Error opening record: " & ex.Message,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        DgvStyle(patientDGV)
    End Sub

    Public Sub ReloadPatientData()
        Try
            dbConn()
            LoadPage()
            patientDGV.ClearSelection()
            ' Apply styling after data is reloaded
            DgvStyle(patientDGV)
        Catch ex As Exception
            MsgBox("Failed to load patient data: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub

    Private Sub LoadPage()
        Try
            Dim countSql As String = "SELECT COUNT(*) FROM db_viewpatient"
            Dim dataSql As String = "SELECT * FROM db_viewpatient ORDER BY patientID DESC LIMIT ? OFFSET ?"

            Using cn As New OdbcConnection(myDSN)
                cn.Open()
                Using cmdCount As New OdbcCommand(countSql, cn)
                    Dim obj = cmdCount.ExecuteScalar()
                    totalCount = 0
                    If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                        Integer.TryParse(obj.ToString(), totalCount)
                    End If
                End Using

                Using cmd As New OdbcCommand(dataSql, cn)
                    cmd.Parameters.AddWithValue("?", pageSize)
                    cmd.Parameters.AddWithValue("?", currentPage * pageSize)
                    Dim da As New OdbcDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    patientDGV.DataSource = dt
                End Using
            End Using

            Dim totalPages As Integer = If(pageSize > 0, If(totalCount Mod pageSize = 0, totalCount \ pageSize, (totalCount \ pageSize) + 1), 1)
            If totalPages <= 0 Then totalPages = 1
            txtPage.Text = "Page " & (currentPage + 1).ToString() & " of " & totalPages.ToString()
            btnBack.Enabled = currentPage > 0
            btnNext.Enabled = currentPage < (totalPages - 1)
        Catch ex As Exception
            MsgBox("Failed to load patients: " & ex.Message, vbCritical, "Error")
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

    Private Sub pnlPatientRecord_Paint(sender As Object, e As PaintEventArgs) Handles pnlPatientRecord.Paint

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

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub pnlBar_Paint(sender As Object, e As PaintEventArgs) Handles pnlBar.Paint

    End Sub

    Private Sub txtPage_Click(sender As Object, e As EventArgs) Handles txtPage.Click

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try
            ' Check if a row is selected
            If patientDGV.SelectedRows.Count = 0 Then
                MessageBox.Show("Please select a patient record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Get the selected patient ID
            Dim selectedRow As DataGridViewRow = patientDGV.SelectedRows(0)
            Dim cellValue As Object = selectedRow.Cells(PatientIDColumnName).Value

            If cellValue Is Nothing OrElse cellValue Is DBNull.Value Then
                MessageBox.Show("Invalid patient record selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim patientID As Integer
            If Not Integer.TryParse(cellValue.ToString(), patientID) Then
                MessageBox.Show("Invalid patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Open the view form with the selected patient ID
            Dim viewForm As New viewPatientRecord()
            viewForm.LoadPatientData(patientID)
            viewForm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error opening patient record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class



