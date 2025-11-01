Imports System.Data.Odbc
Public Class patientRecord
    Private Const PatientIDColumnName As String = "Column1"

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            ' Require a filter selection first
            If cmbSearch.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(cmbSearch.Text) Then
                MessageBox.Show("Please select a filter in the dropdown first.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbSearch.Focus()
                cmbSearch.DroppedDown = True
                Return
            End If

            Dim filter As String = cmbSearch.Text
            Dim searchValue As String = txtSearch.Text.Trim()

            If filter = "Date Added" OrElse filter = "Birthday" Then

                Dim searchDate As Date
                If Not Date.TryParse(searchValue, searchDate) Then
                    MsgBox("Please enter a valid date format (MM/DD/YYYY)", vbExclamation, "Invalid Date")
                    Return
                End If

                ' Format date for SQL (MariaDB format)
                searchValue = searchDate.ToString("yyyy-MM-dd")

                ' For date fields, we'll do exact match in the SearchPatients method
                patientMod.SearchPatients(filter, searchValue, patientDGV, True)
            Else
                ' For text fields, use regular search
                patientMod.SearchPatients(filter, searchValue, patientDGV, False)
            End If

        Catch ex As Exception
            MsgBox("Search Error: " & ex.Message, vbCritical, "Error")
        End Try
        DgvStyle(patientDGV)
    End Sub

    Public Sub SearchPatients(filter As String, searchValue As String, dgv As DataGridView, isDateSearch As Boolean)
        Try
            Dim sql As String = "SELECT * FROM db_viewpatient WHERE "
            Dim paramValue As Object = searchValue

            Select Case filter
                Case "Patient Name"
                    sql += "fullname LIKE ?"
                    paramValue = "%" & searchValue & "%"

                Case "Date Added"
                    If isDateSearch Then
                        sql += "DATE(date) = ?"  ' Exact date match
                    Else
                        sql += "DATE_FORMAT(date, '%Y-%m-%d') LIKE ?"
                        paramValue = "%" & searchValue & "%"
                    End If

                Case "Birthday"
                    If isDateSearch Then
                        sql += "DATE(bday) = ?"  ' Exact date match
                    Else
                        sql += "DATE_FORMAT(bday, '%Y-%m-%d') LIKE ?"
                        paramValue = "%" & searchValue & "%"
                    End If

                Case Else ' Default search (by name)
                    sql += "fullname LIKE ?"
                    paramValue = "%" & searchValue & "%"
            End Select

            sql += " ORDER BY fullname"

            ' Clear previous data
            dgv.DataSource = Nothing

            Using conn As New OdbcConnection(myDSN)
                Using cmd As New OdbcCommand(sql, conn)
                    cmd.Parameters.AddWithValue("?", paramValue)

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
            patientMod.LoadPatientData(patientDGV)
            ' Configure column visibility if needed
            If patientDGV.Columns.Contains(PatientIDColumnName) Then
                patientDGV.Columns(PatientIDColumnName).Visible = False ' Hide ID column
            End If

            ' Initialize search filter ComboBox (no default selection)
            cmbSearch.Items.Clear()
            cmbSearch.Items.Add("Patient Name")
            cmbSearch.Items.Add("Date Added")
            cmbSearch.Items.Add("Birthday")
            cmbSearch.SelectedIndex = -1
            btnSearch.Enabled = False

            ' Age will display as stored in DB
        Catch ex As Exception
            MessageBox.Show("Error loading patient data: " & ex.Message,
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        DgvStyle(patientDGV)
    End Sub

    ' Enable Search only when a filter is selected
    Private Sub cmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch.SelectedIndexChanged
        btnSearch.Enabled = (cmbSearch.SelectedIndex <> -1)
        DgvStyle(patientDGV)
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
            LoadDGV("SELECT * FROM db_viewpatient", patientDGV)
            patientDGV.ClearSelection()
        Catch ex As Exception
            MsgBox("Failed to load patient data: " & ex.Message, vbCritical, "Error")
        End Try
        DgvStyle(patientDGV)
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
        patientDGV.EnableHeadersVisualStyles = False
        patientDGV.DefaultCellStyle.ForeColor = Color.Black
        patientDGV.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Control
        patientDGV.DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption
        patientDGV.DefaultCellStyle.SelectionForeColor = Color.Black
        patientDGV.GridColor = Color.Silver
        patientDGV.DefaultCellStyle.Padding = New Padding(5)
        patientDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        patientDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        patientDGV.ReadOnly = True
        patientDGV.MultiSelect = False
        patientDGV.AllowUserToResizeRows = False
        patientDGV.RowTemplate.Height = 30
        patientDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.False
        patientDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        ' Center align all column headers
        For Each col As DataGridViewColumn In patientDGV.Columns
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next
    End Sub
End Class



