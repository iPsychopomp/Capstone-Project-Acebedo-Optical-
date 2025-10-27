Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Imports System.IO  'For FileStream
Imports Google.Apis.Drive.v3
Imports Google.Apis.Auth.OAuth2
Imports System.Threading
Imports System.Threading.Tasks
Imports Google.Apis.Upload
Imports System.Configuration
Imports System.Diagnostics
Imports System.Data.Odbc

Public Class MainForm
    Public Class CustomToolStripRenderer
        Inherits ToolStripProfessionalRenderer

        Protected Overrides Sub OnRenderButtonBackground(e As ToolStripItemRenderEventArgs)
            MyBase.OnRenderButtonBackground(e)

            Dim button As ToolStripButton = TryCast(e.Item, ToolStripButton)
            If button IsNot Nothing Then
                Dim g As Graphics = e.Graphics
                Dim bounds As Rectangle = New Rectangle(Point.Empty, button.Size)

                If button.Checked Then
                    g.FillRectangle(New SolidBrush(Color.Gainsboro), bounds)
                ElseIf button.Selected Then
                    g.FillRectangle(New SolidBrush(Color.FromArgb(220, 220, 220)), bounds)
                    ControlPaint.DrawBorder(g, bounds, Color.Gray, ButtonBorderStyle.Solid)
                End If
            End If
        End Sub
    End Class

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal
        Me.Bounds = Screen.PrimaryScreen.Bounds
        Me.KeyPreview = True
        tsButtons.Renderer = New CustomToolStripRenderer()
        lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy")
        Timer1.Interval = 1000
        Timer1.Enabled = True
        Timer1.Start()

        lblUser.Text = "User: " & GlobalVariables.LoggedInRole

        Dim dash As New dashboard()
        ShowFormControls(dash)

        Dim totalPatients As Integer = GetTotalPatients()

        If LoggedInRole = "Receptionist" OrElse LoggedInRole = "Doctor" Then
            UserToolStripMenuItem.Visible = False
            ToolsToolStripMenuItem.Visible = False
            btnDashboard.Visible = False
            dashboard.Hide()

            'ReportsToolStripMenuItem.Visible = False
        End If

        ' Hide for Receptionist and Doctor/Optometrist roles
        If LoggedInRole = "Receptionist" OrElse LoggedInRole = "Doctor" OrElse LoggedInRole = "Optometrist" Then
            btnDoctors.Visible = False
            ManageInventoryToolStripMenuItem.Visible = False
        End If

        ' Hide Patient Record and Check Up for Admin/Administrator (but NOT for Super Admin)
        If (LoggedInRole = "Admin" OrElse LoggedInRole = "Administrator") AndAlso LoggedInRole <> "Super Admin" Then
            btnPatientRecord.Visible = False
            btnCheckUp.Visible = False
        End If
        
        ' Super Admin has full access - no restrictions

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub ResetButtons(exceptButton As ToolStripButton)
        Dim buttons(5) As ToolStripButton
        buttons(0) = btnPatientRecord
        buttons(1) = btnInventory
        buttons(2) = btnCheckUp
        buttons(3) = btnTransactions
        buttons(4) = btnDashboard
        buttons(5) = btnDoctors

        For Each btn In buttons
            If btn IsNot exceptButton Then btn.Checked = False
        Next

    End Sub

    Public Sub ShowFormControls(form As Form)
        pnlContainer.Controls.Clear()

        ' Set the form as a child form and embed it in the container
        form.TopLevel = False
        form.FormBorderStyle = FormBorderStyle.None
        form.Dock = DockStyle.Fill
        form.Parent = pnlContainer
        pnlContainer.Controls.Add(form)
        form.Show()
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        btnDashboard.Checked = True
        ResetButtons(btnDashboard)

        Dim dash As New dashboard()
        ShowFormControls(dash)
    End Sub

    Private Sub btnPatientRecord_Click(sender As Object, e As EventArgs) Handles btnPatientRecord.Click
        btnPatientRecord.Checked = True
        ResetButtons(btnPatientRecord)

        Dim Patientform As New patientRecord()
        ShowFormControls(Patientform)
        patientMod.LoadPatientData(Patientform.patientDGV)
    End Sub

    Private Sub btnCheckUp_Click(sender As Object, e As EventArgs) Handles btnCheckUp.Click
        btnCheckUp.Checked = True
        ResetButtons(btnCheckUp)

        Dim check As New checkUp
        ShowFormControls(check)
        modCheckUp.LoadCheckUpData(check.checkUpDGV)
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        btnInventory.Checked = True
        ResetButtons(btnInventory)

        Dim invenform As New inventory()
        ShowFormControls(invenform)
        invenform.LoadProductData()
    End Sub

    Private Sub btnTransactions_Click(sender As Object, e As EventArgs) Handles btnTransactions.Click
        btnTransactions.Checked = True
        ResetButtons(btnTransactions)

        Dim transac As New transaction
        ShowFormControls(transac)
        transac.LoadTransactions()
    End Sub

    Private Sub ManageUsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageUsersToolStripMenuItem.Click
        ' Reset all toolbar buttons
        ResetButtons(Nothing)

        Dim usersform As New users()
        usersform.TopMost = True
        usersform.ShowDialog()

    End Sub

    Private Sub SystemLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemLogsToolStripMenuItem.Click
        Dim auditLogs As New auditTrail()
        auditLogs.TopMost = True
        auditLogs.ShowDialog()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            InsertAuditTrail(GlobalVariables.LoggedInUserID, "Logout", "User logged out")

            GlobalVariables.LoggedInUser = ""
            GlobalVariables.LoggedInRole = ""
            GlobalVariables.LoggedInUserID = 0
            GlobalVariables.LoggedInFullName = ""

            Dim loginForm As New Login()
            loginForm.Show()

            Me.Close()
        End If
    End Sub

    Sub InsertAuditTrail(UserID As Integer, ActionType As String, ActionDetails As String)
        Dim connectionString As String = "DSN=dsnsystem"
        Using conn As New Odbc.OdbcConnection(connectionString)
            Try
                conn.Open()
                Dim query As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?)"
                Using cmd As New Odbc.OdbcCommand(query, conn)
                    cmd.Parameters.AddWithValue("?", UserID)
                    cmd.Parameters.AddWithValue("?", GlobalVariables.LoggedInUser)
                    cmd.Parameters.AddWithValue("?", ActionType)
                    cmd.Parameters.AddWithValue("?", ActionDetails)
                    cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
                    cmd.Parameters.AddWithValue("?", DateTime.Now.Date)
                End Using
            Catch ex As Exception
                MessageBox.Show("Audit Trail Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub StockInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockInToolStripMenuItem.Click
        Dim Restock As New stockIN()

        ' Refresh inventory when stock in form closes
        AddHandler Restock.FormClosed, Sub(s, ev)
                                           RefreshInventoryIfOpen()
                                       End Sub

        Restock.TopMost = True
        Restock.ShowDialog()
    End Sub

    Private Sub StockOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockOutToolStripMenuItem.Click
        Dim OutStock As New stockOut()

        ' Refresh inventory when stock out form closes
        AddHandler OutStock.FormClosed, Sub(s, ev)
                                            RefreshInventoryIfOpen()
                                        End Sub

        OutStock.TopMost = True
        OutStock.ShowDialog()
    End Sub

    Private Sub RefreshInventoryIfOpen()
        ' Find and refresh inventory form if it's open in the container
        For Each ctrl As Control In pnlContainer.Controls
            If TypeOf ctrl Is inventory Then
                Dim inv As inventory = DirectCast(ctrl, inventory)
                inv.SafeLoadProducts()
                inv.productDGV.Refresh()
                Exit For
            End If
        Next
    End Sub

    Private Sub ReorderLevelToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim ReorderLevel As New reOrder()
        ReorderLevel.TopMost = True
        ReorderLevel.ShowDialog()
    End Sub
    Private Function GetTotalPatients() As Integer
        Dim totalPatients As Integer = 0
        Try
            Call dbConn()

            Dim sql As String = "SELECT COUNT(*) FROM patient_data"
            Using cmd As New Odbc.OdbcCommand(sql, conn)
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso IsNumeric(result) Then
                    totalPatients = Convert.ToInt32(result)
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error fetching total patients: " & ex.Message, vbCritical, "Database Error")
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Return totalPatients
    End Function

    Private Sub CreateBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateBackupToolStripMenuItem.Click
        Dim iBackup As New CreateBackup()
        iBackup.TopMost = True
        iBackup.ShowDialog()

    End Sub

    Private Sub RestoreDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreDataToolStripMenuItem.Click
        Dim rBackups As New ImportData
        rBackups.TopMost = True
        rBackups.ShowDialog()
    End Sub

    Private Sub btnDoctors_Click(sender As Object, e As EventArgs) Handles btnDoctors.Click
        btnDoctors.Checked = True
        ResetButtons(btnDoctors)

        Dim doc As New doctors
        ShowFormControls(doc)
        doc.LoadDoctors()
    End Sub

    'Private Sub GenerateReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateReportsToolStripMenuItem.Click
    '    Dim gReports As New Reports
    '    gReports.TopMost = True
    '    gReports.ShowDialog()
    'End Sub

    Private Sub SupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierToolStripMenuItem.Click
        ' Reset all toolbar buttons
        ResetButtons(Nothing)

        Dim showsupp As New Supplier()
        showsupp.TopMost = True
        showsupp.ShowDialog()
    End Sub

    Private Sub AddUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddUserToolStripMenuItem.Click
        Dim newadd As New addUsers()
        newadd.TopMost = True
        newadd.ShowDialog()
    End Sub

    Private Sub OrderProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderProductToolStripMenuItem.Click
        Dim orderProd As New OrderProduct()
        orderProd.TopMost = True
        orderProd.ShowDialog()
    End Sub

    Private Sub SupplierProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupplierProductsToolStripMenuItem.Click
        Dim suppProd As New supplierItems()
        suppProd.TopMost = True
        suppProd.ShowDialog()
    End Sub

    Private Sub OrderHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderHistoryToolStripMenuItem.Click
        Dim orderProd As New OrderProduct()
        orderProd.TabControl1.SelectedTab = orderProd.TabPage2
        orderProd.TopMost = True
        orderProd.ShowDialog()

    End Sub

    Private Sub pnlContainer_Paint(sender As Object, e As PaintEventArgs) Handles pnlContainer.Paint

    End Sub

    Private Sub MenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub ToolsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolsToolStripMenuItem.Click

    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click

    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ReportsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem1.Click
        Dim gReports As New Reports
        gReports.TopMost = True
        gReports.ShowDialog()
    End Sub
End Class
