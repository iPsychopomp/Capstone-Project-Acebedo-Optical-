Imports System.Configuration
Imports System.Data.Odbc
Imports System.IO
Imports System.Diagnostics
Imports Google.Apis.Drive.v3
Imports Google.Apis.Auth.OAuth2
Imports System.Threading
Imports System.Threading.Tasks
Imports Google.Apis.Upload

Public Class CreateBackup
    Public Event ProgressUpdate(message As String)
    Friend WithEvents StatusStrip As StatusStrip

    Public Property StatusLabel As ToolStripStatusLabel

    Private lastUpdateTime As DateTime = DateTime.Now
    Private updateInterval As TimeSpan = TimeSpan.FromMilliseconds(100)
    Private smoothKB As Double = 0

    'LOCAL STORAGE
    Public Function CreateMySQLBackup() As String
        Try
            RaiseEvent ProgressUpdate("Initializing backup...")

            Dim backupDir = ConfigurationManager.AppSettings("BackupPath")
            Directory.CreateDirectory(backupDir)
            RaiseEvent ProgressUpdate("Created backup directory...")

            Dim backupFile = Path.Combine(backupDir, String.Format("backup_{0:yyyyMMdd_HHmmss}.sql", DateTime.Now))
            Dim mysqldumpPath As String = "C:\mysql-5.6.51-winx64\mysql-5.6.51-winx64\bin\mysqldump.exe"
            'Dim mysqldumpPath As String = "C:\mysql-5.6.51-winx64\bin\mysqldump.exe"
            'C:\mysql-5.6.51-winx64\bin\mysqldump.exe
            'C:\mysql-5.6.51-winx64\bin

            Dim connString As String = ConfigurationManager.AppSettings("ODBC_ConnectionString")
            Dim builder As New OdbcConnectionStringBuilder(connString)
            Dim connParams As Dictionary(Of String, String) = connString.Split(";"c) _
                .Where(Function(p) p.Contains("=")) _
                .Select(Function(p) p.Split("="c)) _
                .ToDictionary(Function(p) p(0).Trim().ToUpper(), Function(p) p(1).Trim())
            Dim server As String = If(builder.ContainsKey("SERVER"), builder("SERVER").ToString(), "")
            Dim user As String = If(builder.ContainsKey("USER"), builder("USER").ToString(), "")
            Dim database As String = If(builder.ContainsKey("DATABASE"), builder("DATABASE").ToString(), "")
            Dim password As String = If(builder.ContainsKey("PASSWORD"), builder("PASSWORD").ToString().Trim(), "")

            If String.IsNullOrEmpty(server) OrElse String.IsNullOrEmpty(user) OrElse String.IsNullOrEmpty(database) Then
                Throw New Exception("Missing required database connection details in ODBC connection string.")
            End If

            Dim passwordArg As String = If(String.IsNullOrEmpty(password), "--skip-password", "-p" & password)

            RaiseEvent ProgressUpdate("Starting database dump...")
            Dim psi As New ProcessStartInfo With {
     .FileName = mysqldumpPath,
     .Arguments = String.Format("-h {0} -u {1} {2} {3} -r ""{4}""",
         server, user, passwordArg, database, backupFile),
     .UseShellExecute = False,
     .CreateNoWindow = True,
     .RedirectStandardError = True
 }

            Using process As New Process()
                process.StartInfo = psi
                process.Start()

                Dim errors = process.StandardError.ReadToEnd()
                process.WaitForExit(30000)

                If process.ExitCode <> 0 Then
                    Throw New Exception(String.Format("mysqldump failed: {0}", errors))
                End If

                If Not File.Exists(backupFile) Then
                    Throw New Exception("Backup file was not created")
                End If

                RaiseEvent ProgressUpdate("Database backup created successfully")
                Return backupFile
            End Using

        Catch ex As Exception
            RaiseEvent ProgressUpdate("Backup failed: " & ex.Message)
            Throw
        End Try
    End Function

    Private Sub UpdateLoadingStatus(value As Integer, msg As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() UpdateLoadingStatus(value, msg))
        Else
            tspBar.Value = value
            TSPLabel.Text = msg
        End If
    End Sub

    'GOOGLE DRIVE
    Private Async Sub btnBgDrive_Click(sender As Object, e As EventArgs) Handles btnBgDrive.Click
        Me.Cursor = Cursors.WaitCursor
        Dim backupPath As String = String.Empty

        Try
            ' Initialize backup process
            UpdateLoadingStatus(10, "Initializing backup process...")

            ' Step 1: Create local backup
            UpdateLoadingStatus(20, "Creating database backup...")
            backupPath = CreateMySQLBackup()
            UpdateLoadingStatus(40, "Backup file created successfully")

            ' Verify backup file exists
            If Not File.Exists(backupPath) Then
                Throw New FileNotFoundException("Backup file not found", backupPath)
            End If

            ' Step 2: Connect to Google Drive
            UpdateLoadingStatus(45, "Connecting to Google Drive...")
            Dim driveService = Await ImportBackupGoogleDrive.AuthorizeAsync()

            If driveService Is Nothing Then
                Throw New Exception("Google Drive authentication failed")
            End If

            ' Step 3: Prepare upload metadata
            UpdateLoadingStatus(50, "Preparing upload...")
            Dim fileMetadata As New Google.Apis.Drive.v3.Data.File() With {
                .Name = Path.GetFileName(backupPath),
                .Description = "Acebedo Optical Backup " & DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                .Parents = New List(Of String) From {"root"}
            }

            ' Step 4: Upload the file with progress tracking
            UpdateLoadingStatus(55, "Starting upload...")
            Using fs As New FileStream(backupPath, FileMode.Open)
                Dim fileSizeKB As Long = New FileInfo(backupPath).Length \ 1024
                Dim request = driveService.Files.Create(fileMetadata, fs, "application/sql")

                ' Progress handler
                AddHandler request.ProgressChanged,
                    Sub(progress)
                        If progress IsNot Nothing Then
                            Dim currentKB = progress.BytesSent \ 1024
                            Dim percentComplete = 60 + (currentKB * 30 / fileSizeKB)
                            UpdateLoadingStatus(percentComplete,
                                             String.Format("Uploading: {0} KB of {1} KB", currentKB, fileSizeKB))
                        End If
                    End Sub

                ' Execute upload
                Dim result = Await request.UploadAsync()

                ' Verify result
                If result.Status = Google.Apis.Upload.UploadStatus.Completed Then
                    UpdateLoadingStatus(100, "Backup uploaded successfully!")
                    MsgBox("Backup uploaded to Google Drive successfully!" & vbCrLf &
                          "File ID: " & request.ResponseBody.Id,
                          MsgBoxStyle.Information, "Backup Complete")
                Else
                    Throw New Exception("Upload failed: " &
                                      If(result.Exception IsNot Nothing, result.Exception.Message, "Unknown error"))
                End If
            End Using

        Catch ex As Exception
            UpdateLoadingStatus(0, "Backup failed!")
            MsgBox("Backup Error:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Backup Failed")
        Finally
            ' Clean up
            If Not String.IsNullOrEmpty(backupPath) AndAlso File.Exists(backupPath) Then
                Try
                    File.Delete(backupPath)
                Catch
                    ' Ignore cleanup errors
                End Try
            End If

            Me.Cursor = Cursors.Default
            UpdateLoadingStatus(0, "Ready")
        End Try
    End Sub

    'LOCAL BACKUP
    Private Sub btnBLocal_Click(sender As Object, e As EventArgs) Handles btnBLocal.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If ImportBackupLocal.CreateLocalBackup(AddressOf UpdateLoadingStatus) Then
                MsgBox("Backup created successfully in " & ImportBackupLocal.BackupDirectory, MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox("Backup Error: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
            UpdateLoadingStatus(0, "Ready")
        End Try
    End Sub


    Private Sub CreateBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class