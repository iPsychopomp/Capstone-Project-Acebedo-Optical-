Module patientMod
    Public Sub LoadPatientData(ByRef patientDGV As DataGridView)
        ' Update ages in database for all patients first
        UpdateAllPatientAges()

        Call dbConn()
        ' Load patient data with updated ages from existing age column
        Call LoadDGV("SELECT * FROM db_viewpatient", patientDGV)
        patientDGV.ClearSelection()
        DgvStyle(patientDGV)
    End Sub

    ' Function to calculate age from birthdate
    Public Function CalculateAge(birthDate As Date) As Integer
        Dim today As Date = Date.Today
        Dim age As Integer = today.Year - birthDate.Year

        ' Adjust if birthday hasn't occurred this year yet
        If birthDate.Date > today.AddYears(-age) Then
            age -= 1
        End If

        Return age
    End Function

    ' Update all patient ages in the database
    Public Sub UpdateAllPatientAges()
        Try
            Call dbConn()
            ' Update ages for all patients based on their birthdate
            Dim sql As String = "UPDATE patient_data SET age = TIMESTAMPDIFF(YEAR, bday, CURDATE())"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ' Silently handle - age update is not critical
            Debug.WriteLine("Age update error: " & ex.Message)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Public Sub SearchPatients(filter As String, searchValue As String, ByRef patientDGV As DataGridView, Optional isDateSearch As Boolean = False)
        ' Validate inputs
        If patientDGV Is Nothing Then
            Throw New ArgumentNullException("patientDGV", "DataGridView cannot be null")
        End If

        ' Trim and validate search value
        searchValue = If(searchValue, String.Empty).Trim()
        If String.IsNullOrEmpty(searchValue) Then
            LoadPatientData(patientDGV) ' Reload all data if search is empty
            Return
        End If

        ' Validate filter
        Dim validFilters As New List(Of String) From {"Patient Name", "Birthday", "Date Added"}
        If Not validFilters.Contains(filter) Then
            MessageBox.Show("Please select a valid search filter.", "Invalid Filter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Try
            ' Update ages first before searching
            UpdateAllPatientAges()

            ' Build the SQL query based on the filter
            Dim sql As String = ""
            Select Case filter
                Case "Patient Name"
                    sql = "SELECT * FROM db_viewpatient WHERE fullname LIKE ?"
                    searchValue = "%" & searchValue & "%"
                Case "Birthday"
                    ' Validate date format if it's a date search
                    If Not DateTime.TryParse(searchValue, Nothing) Then
                        MessageBox.Show("Please enter a valid date format for birthday search.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                    sql = "SELECT * FROM db_viewpatient WHERE DATE_FORMAT(bday, '%Y-%m-%d') LIKE ?"
                    searchValue = "%" & searchValue & "%"
                Case "Date Added"
                    ' Validate date format if it's a date search
                    If Not DateTime.TryParse(searchValue, Nothing) Then
                        MessageBox.Show("Please enter a valid date format for date search.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End If
                    sql = "SELECT * FROM db_viewpatient WHERE DATE_FORMAT(date, '%Y-%m-%d') LIKE ?"
                    searchValue = "%" & searchValue & "%"
            End Select

            ' Execute the search
            Call dbConn()
            Call LoadDGV(sql, patientDGV, searchValue)

            ' Show message if no results found
            If patientDGV.RowCount <= 0 Then
                MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As System.Data.Odbc.OdbcException
            MessageBox.Show("Database error while searching: " & ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Consider logging the error
            ' LogError("SearchPatients", ex)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' LogError("SearchPatients_General", ex)
        End Try
    End Sub

    Public Sub CreateNewPatient()
        Dim newPatient As New addPatient()
        AddHandler newPatient.FormClosed, AddressOf RefreshPatientDGV
        newPatient.ShowDialog()
    End Sub


    Public Sub HandleRowSelection(ByRef patientDGV As DataGridView, ByVal e As DataGridViewCellEventArgs)
        Try
            If e.RowIndex >= 0 Then
                patientDGV.Rows(e.RowIndex).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        End Try
    End Sub

    Public Sub RefreshPatientDGV()
        For Each f As Form In Application.OpenForms
            If TypeOf f Is patientRecord Then
                Try
                    CType(f, patientRecord).ReloadPatientData()
                Catch ex As Exception
                    MsgBox("Failed to refresh patient records: " & ex.Message, vbCritical, "Error")
                End Try
                Exit For
            End If
        Next

		' Also refresh Transactions list if it's open so name updates reflect immediately
		For Each f As Form In Application.OpenForms
			If TypeOf f Is Transaction Then
				Try
					CType(f, Transaction).LoadTransactions()
				Catch ex As Exception
					' Non-blocking
				End Try
			End If
		Next
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
    End Sub

End Module
