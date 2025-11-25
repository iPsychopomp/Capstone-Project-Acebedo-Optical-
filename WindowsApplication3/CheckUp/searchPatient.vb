Imports System.Data.Odbc

' Delegate for patient selection callback (Industry Standard Pattern)
Public Delegate Sub PatientSelectedCallback(patientID As Integer, fullname As String)

Public Class searchPatient

    ' Pagination state
    Private currentPage As Integer = 1
    Private ReadOnly pageSize As Integer = 20
    Private totalRecords As Integer = 0
    Private totalPages As Integer = 1
    Private currentSearchTerm As String = ""

    ' Store reference to CreateCheckUp form if opened from btnAddP flow
    Public Property ParentCheckUpForm As CreateCheckUp = Nothing

    ' Callback pattern - Industry Standard approach for loose coupling
    Public Property OnPatientSelected As PatientSelectedCallback = Nothing

    ' Flag to indicate we are transitioning to Add Patient (so CreateCheckUp must stay hidden)
    Private openingAddPatient As Boolean = False

    Private Sub searchPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPatientSearch()
        DgvStyle(searchPatientDGV)
        txtSearch.Text = "Search by patient name"
        txtSearch.ForeColor = Color.Gray
    End Sub

    Private Sub searchPatient_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' When searchPatient is closing, update visibility flags on CreateCheckUp
        If ParentCheckUpForm IsNot Nothing AndAlso Not ParentCheckUpForm.IsDisposed Then
            If openingAddPatient Then
                ' Keep CreateCheckUp hidden ONLY if we're opening Add Patient next
                Try
                    Dim fieldInfo = GetType(CreateCheckUp).GetField("shouldStayHidden", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
                    If fieldInfo IsNot Nothing Then
                        fieldInfo.SetValue(ParentCheckUpForm, True)
                    End If
                Catch
                End Try
                Try
                    ParentCheckUpForm.KeepHiddenAfterSearchClose = True
                Catch
                End Try
                Try
                    ParentCheckUpForm.Visible = False
                    ParentCheckUpForm.Hide()
                    ParentCheckUpForm.SendToBack()
                Catch
                End Try
            Else
                ' NOT opening Add Patient - restore CreateCheckUp visibility
                Try
                    Dim fieldInfo = GetType(CreateCheckUp).GetField("shouldStayHidden", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
                    If fieldInfo IsNot Nothing Then
                        fieldInfo.SetValue(ParentCheckUpForm, False)
                    End If
                Catch
                End Try
                Try
                    ParentCheckUpForm.KeepHiddenAfterSearchClose = False
                Catch
                End Try
                ' Show CreateCheckUp form
                Try
                    ParentCheckUpForm.Visible = True
                    ParentCheckUpForm.Show()
                    ParentCheckUpForm.BringToFront()
                    ParentCheckUpForm.Focus()
                Catch
                End Try
            End If
        End If
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

            Dim pid As Integer = If(String.IsNullOrEmpty(patientID), 0, Convert.ToInt32(patientID))

            ' INDUSTRY STANDARD: Use callback pattern first (loose coupling)
            If OnPatientSelected IsNot Nothing Then
                Logger.Info("Using callback pattern to set patient - Name: " & fullname & ", ID: " & pid.ToString(), "searchPatient")
                Try
                    OnPatientSelected.Invoke(pid, fullname)
                    Logger.Info("Callback invoked successfully", "searchPatient")
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                    Return
                Catch ex As Exception
                    Logger.Error("Error invoking callback", ex, "searchPatient")
                End Try
            End If

            ' FALLBACK: Legacy form-finding approach
            Logger.Debug("No callback set, using legacy form-finding approach", "searchPatient")

            ' PRIORITY 1: Check for CreateCheckUp first (if ParentCheckUpForm is set or form exists)
            Dim targetForm As CreateCheckUp = Nothing

            ' First check if we have a stored parent form reference
            If ParentCheckUpForm IsNot Nothing Then
                targetForm = ParentCheckUpForm
                Logger.Info("Using stored ParentCheckUpForm reference", "searchPatient")
            Else
                ' Search in MainForm's container first (most reliable for embedded forms)
                Logger.Debug("Searching for CreateCheckUp in MainForm container...", "searchPatient")
                For Each frm As Form In Application.OpenForms
                    If TypeOf frm Is MainForm Then
                        Dim mainForm As MainForm = DirectCast(frm, MainForm)
                        Logger.Debug("Found MainForm, checking pnlContainer controls...", "searchPatient")
                        ' Search for CreateCheckUp in the pnlContainer
                        For Each ctrl As Control In mainForm.pnlContainer.Controls
                            Logger.Debug("  Control type: " & ctrl.GetType().Name, "searchPatient")
                            If TypeOf ctrl Is CreateCheckUp Then
                                targetForm = DirectCast(ctrl, CreateCheckUp)
                                Logger.Info("Found CreateCheckUp in container!", "searchPatient")
                                Exit For
                            End If
                        Next
                        If targetForm IsNot Nothing Then Exit For
                    End If
                Next

                ' If not found in container, check Application.OpenForms
                If targetForm Is Nothing Then
                    For Each frm As Form In Application.OpenForms
                        If TypeOf frm Is CreateCheckUp Then
                            targetForm = DirectCast(frm, CreateCheckUp)
                            Logger.Info("Found CreateCheckUp in OpenForms", "searchPatient")
                            Exit For
                        End If
                    Next
                End If
            End If

            ' If CreateCheckUp found, set patient info and exit
            If targetForm IsNot Nothing Then
                Try
                    Logger.Info("Setting patient in CreateCheckUp - Name: " & fullname & ", ID: " & patientID, "searchPatient")
                    ' Ensure the CreateCheckUp form can show again
                    Try
                        targetForm.KeepHiddenAfterSearchClose = False
                    Catch
                    End Try
                    Try
                        Dim fieldInfoShow = GetType(CreateCheckUp).GetField("shouldStayHidden", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
                        If fieldInfoShow IsNot Nothing Then
                            fieldInfoShow.SetValue(targetForm, False)
                        End If
                    Catch
                    End Try
                    targetForm.txtPName.Text = fullname
                    targetForm.txtPName.Tag = If(String.IsNullOrEmpty(patientID), Nothing, patientID)

                    ' Bring the form to front
                    Try
                        targetForm.BringToFront()
                        targetForm.Visible = True
                        targetForm.Focus()
                        Logger.Debug("CreateCheckUp form brought to front", "searchPatient")
                    Catch ex2 As Exception
                        Logger.Warning("Could not bring CreateCheckUp form to front: " & ex2.Message, "searchPatient")
                    End Try

                    Logger.Info("Patient info set successfully in CreateCheckUp", "searchPatient")
                Catch ex As Exception
                    Logger.Error("Error setting patient in CreateCheckUp", ex, "searchPatient")
                End Try

                Me.DialogResult = DialogResult.OK
                Me.Close()
                Return
            End If

            ' PRIORITY 2: If no CreateCheckUp, try addPatientTransaction
            Logger.Debug("CreateCheckUp NOT found, checking for addPatientTransaction", "searchPatient")
            Dim transForm As addPatientTransaction = Nothing

            ' Search in MainForm's container
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is MainForm Then
                    Dim mainForm As MainForm = DirectCast(frm, MainForm)
                    For Each ctrl As Control In mainForm.pnlContainer.Controls
                        If TypeOf ctrl Is addPatientTransaction Then
                            transForm = DirectCast(ctrl, addPatientTransaction)
                            Logger.Info("Found addPatientTransaction in container!", "searchPatient")
                            Exit For
                        End If
                    Next
                    If transForm IsNot Nothing Then Exit For
                End If
            Next

            ' Check if the Owner is addPatientTransaction
            If transForm Is Nothing AndAlso Me.Owner IsNot Nothing AndAlso TypeOf Me.Owner Is addPatientTransaction Then
                transForm = DirectCast(Me.Owner, addPatientTransaction)
                Logger.Info("Found addPatientTransaction as Owner", "searchPatient")
            End If

            ' Check Application.OpenForms
            If transForm Is Nothing Then
                For Each frm As Form In Application.OpenForms
                    If TypeOf frm Is addPatientTransaction Then
                        transForm = DirectCast(frm, addPatientTransaction)
                        Logger.Info("Found addPatientTransaction in OpenForms", "searchPatient")
                        Exit For
                    End If
                Next
            End If

            If transForm IsNot Nothing Then
                Try
                    If Not transForm.IsDisposed Then
                        Dim transPatientID As Integer = If(String.IsNullOrEmpty(patientID), 0, Convert.ToInt32(patientID))
                        Logger.Info("Setting patient info - Name: " & fullname & ", ID: " & transPatientID.ToString(), "searchPatient")
                        transForm.SetPatientInfo(transPatientID, fullname)
                        Logger.Info("Patient info set successfully", "searchPatient")

                        Try
                            transForm.BringToFront()
                            transForm.Visible = True
                            transForm.Focus()
                            Logger.Debug("Transaction form brought to front", "searchPatient")
                        Catch ex2 As Exception
                            Logger.Warning("Could not bring transaction form to front: " & ex2.Message, "searchPatient")
                        End Try
                    End If
                Catch ex As Exception
                    Logger.Error("Error calling SetPatientInfo", ex, "searchPatient")
                End Try
                Me.DialogResult = DialogResult.OK
                Me.Close()
                Return
            End If

            ' If no form found, just close
            Logger.Warning("No target form found (CreateCheckUp or addPatientTransaction)", "searchPatient")
            Me.Close()
        Catch ex As Exception
            Logger.Error("Error in searchPatientDGV_CellDoubleClick", ex, "searchPatient")
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
            ' Find the MainForm instance
            Dim mainForm As MainForm = Nothing
            For Each frm As Form In Application.OpenForms
                If TypeOf frm Is MainForm Then
                    mainForm = DirectCast(frm, MainForm)
                    Exit For
                End If
            Next

            If mainForm IsNot Nothing Then
                ' Check if we have a parent CreateCheckUp form reference (popup dialog scenario)
                If ParentCheckUpForm IsNot Nothing Then
                    ' Store reference to CreateCheckUp form
                    Dim createCheckUpRef As CreateCheckUp = ParentCheckUpForm

                    ' Find and store reference to checkUp form in pnlContainer BEFORE replacing it
                    Dim checkUpFormRef As checkUp = Nothing
                    For Each ctrl As Control In mainForm.pnlContainer.Controls
                        If TypeOf ctrl Is checkUp Then
                            checkUpFormRef = DirectCast(ctrl, checkUp)
                            Exit For
                        End If
                    Next

                    ' Set the shouldStayHidden flag on CreateCheckUp to prevent it from showing
                    Try
                        Dim fieldInfo = GetType(CreateCheckUp).GetField("shouldStayHidden", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
                        If fieldInfo IsNot Nothing Then
                            fieldInfo.SetValue(createCheckUpRef, True)
                        End If
                    Catch
                    End Try
                    Try
                        createCheckUpRef.KeepHiddenAfterSearchClose = True
                    Catch
                    End Try

                    ' We are opening Add Patient; mark the intent and hide dialogs
                    openingAddPatient = True
                    Try
                        createCheckUpRef.Visible = False
                        createCheckUpRef.Hide()
                        createCheckUpRef.SendToBack()
                    Catch
                    End Try
                    Me.Hide()

                    ' Prepare addPatient form
                    Dim addPatientFormCheckUp As New addPatient()

                    ' When addPatient closes, restore checkUp form and show searchPatient again
                    AddHandler addPatientFormCheckUp.FormClosed, Sub(s, ev)
                                                                     Try
                                                                         ' FIRST: Restore checkUp form to pnlContainer
                                                                         If checkUpFormRef IsNot Nothing AndAlso Not checkUpFormRef.IsDisposed Then
                                                                             mainForm.ShowFormControls(checkUpFormRef)
                                                                             checkUpFormRef.LoadPage()
                                                                         Else
                                                                             ' Create new checkUp form if original was disposed
                                                                             Dim newCheckUp As New checkUp()
                                                                             mainForm.ShowFormControls(newCheckUp)
                                                                         End If

                                                                         ' THEN: Re-open searchPatient as a fresh modal dialog
                                                                         Dim newSearch As New searchPatient()
                                                                         newSearch.ParentCheckUpForm = createCheckUpRef
                                                                         newSearch.StartPosition = FormStartPosition.CenterScreen
                                                                         newSearch.TopMost = True

                                                                         ' Pass the callback to the new search form
                                                                         newSearch.OnPatientSelected = Sub(patientID As Integer, fullname As String)
                                                                                                           Try
                                                                                                               If createCheckUpRef IsNot Nothing AndAlso Not createCheckUpRef.IsDisposed Then
                                                                                                                   createCheckUpRef.txtPName.Text = fullname
                                                                                                                   createCheckUpRef.txtPName.Tag = patientID
                                                                                                               End If
                                                                                                           Catch
                                                                                                           End Try
                                                                                                       End Sub

                                                                         newSearch.ShowDialog(mainForm)
                                                                     Catch ex As Exception
                                                                         Debug.WriteLine("Error in FormClosed handler: " & ex.Message)
                                                                     Finally
                                                                         ' After searchPatient closes, restore CreateCheckUp
                                                                         Try
                                                                             If createCheckUpRef IsNot Nothing AndAlso Not createCheckUpRef.IsDisposed Then
                                                                                 Dim fieldInfo = GetType(CreateCheckUp).GetField("shouldStayHidden", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
                                                                                 If fieldInfo IsNot Nothing Then
                                                                                     fieldInfo.SetValue(createCheckUpRef, False)
                                                                                 End If
                                                                                 createCheckUpRef.KeepHiddenAfterSearchClose = False
                                                                                 createCheckUpRef.Visible = True
                                                                                 createCheckUpRef.Show()
                                                                                 createCheckUpRef.BringToFront()
                                                                                 createCheckUpRef.Focus()
                                                                             End If
                                                                         Catch
                                                                         End Try
                                                                     End Try
                                                                 End Sub

                    ' Embed addPatient into pnlContainer then close this dialog
                    mainForm.ShowFormControls(addPatientFormCheckUp)
                    Me.Close()
                    Return
                End If

                ' Check for addPatientTransaction in container (transaction scenario)
                Dim callingTransactionForm As addPatientTransaction = Nothing

                ' Search in MainForm's container
                For Each ctrl As Control In mainForm.pnlContainer.Controls
                    If TypeOf ctrl Is addPatientTransaction Then
                        callingTransactionForm = DirectCast(ctrl, addPatientTransaction)
                        Exit For
                    End If
                Next

                ' If not found in container, check Application.OpenForms
                If callingTransactionForm Is Nothing Then
                    For Each frm As Form In Application.OpenForms
                        If TypeOf frm Is addPatientTransaction Then
                            callingTransactionForm = DirectCast(frm, addPatientTransaction)
                            Exit For
                        End If
                    Next
                End If

                ' Close this search form
                Me.Close()

                ' Show addPatient form in MainForm's container
                Dim addPatientFormTrans As New addPatient()
                mainForm.ShowFormControls(addPatientFormTrans)

                ' When addPatient closes, return to transaction form
                AddHandler addPatientFormTrans.FormClosed, Sub(s, ev)
                                                               If callingTransactionForm IsNot Nothing Then
                                                                   ' Return to addPatientTransaction
                                                                   mainForm.ShowFormControls(callingTransactionForm)

                                                                   ' Show searchPatient dialog on top
                                                                   Dim newSearchForm As New searchPatient()
                                                                   newSearchForm.StartPosition = FormStartPosition.CenterScreen
                                                                   newSearchForm.ShowDialog(mainForm)
                                                               End If
                                                           End Sub
            Else
                ' Fallback to old behavior if MainForm not found
                Using frm As New addPatient()
                    Dim result As DialogResult = frm.ShowDialog(Me)
                    If result = DialogResult.OK Then
                        LoadPatientSearch()
                    End If
                End Using
            End If

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