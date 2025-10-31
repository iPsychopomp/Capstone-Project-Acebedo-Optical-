Public Class checkUp
    Private isEditing As Boolean = False
    Private currentCheckupID As Integer = 0
    Public DataSaved As Boolean = False


    Private Sub checkUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure we always use the designed columns (headers/order) and not auto-generated ones
        DgvStyle(checkUpDGV)
        checkUpDGV.AutoGenerateColumns = False
        modCheckUp.LoadCheckUpData(checkUpDGV)

        ' Initialize the ComboBox items (no default selection)
        cmbFilter.Items.Clear()
        cmbFilter.Items.Add("Patient Name")
        cmbFilter.Items.Add("Doctor Name")
        cmbFilter.Items.Add("All Records")
        cmbFilter.SelectedIndex = -1
        btnSearch.Enabled = False
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

    ' Enable the Search button only when a filter is selected
    Private Sub cmbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilter.SelectedIndexChanged
        btnSearch.Enabled = (cmbFilter.SelectedIndex <> -1)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Using check As New CreateCheckUp
            If check.ShowDialog() = DialogResult.OK AndAlso check.DataSaved Then
                modCheckUp.LoadCheckUpData(checkUpDGV)
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
                        modCheckUp.LoadCheckUpData(checkUpDGV)
                    End If
                End Using
            End If
        Else
            MessageBox.Show("Please select a row first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            ' Require a filter selection first
            If cmbFilter.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(cmbFilter.Text) Then
                MessageBox.Show("Please select a filter in the dropdown first.", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbFilter.Focus()
                cmbFilter.DroppedDown = True
                Return
            End If

            Dim filter As String = cmbFilter.Text
            Dim searchValue As String = txtSearch.Text.Trim()

            If String.IsNullOrEmpty(searchValue) OrElse filter = "All Records" Then
                modCheckUp.LoadCheckUpData(checkUpDGV)
                Return
            End If

            ' Call the search method
            modCheckUp.SearchCheckUps(filter, searchValue, checkUpDGV)

        Catch ex As Exception
            MsgBox("Search Error: " & ex.Message, vbCritical, "Error")
        End Try
    End Sub
End Class
