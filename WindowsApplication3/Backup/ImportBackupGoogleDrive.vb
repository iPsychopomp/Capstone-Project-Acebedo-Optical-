Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Drive.v3
Imports Google.Apis.Services
Imports System.Threading
Imports System.IO
Imports System.Collections.Generic
Imports Google.Apis.Upload

Module ImportBackupGoogleDrive

    'AIzaSyBofCRnWQhO-S5fV1jYk1-xF7hCf-Nm1VE 'Key API

    'credentials nang google drive api
    Private ReadOnly ClientId As String = "1038322871366-6rvgjb9hcdbhco6522rkor5vmsr4j4mr.apps.googleusercontent.com"
    Private ReadOnly ClientSecret As String = "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"

    'description nang format
    Private ReadOnly BackupDescriptionFormat As String = "MyDriveBackup - {0:yyyy-MM-dd HH:mm}"

    Public Async Function AuthorizeAsync() As Task(Of DriveService)
        Dim credential = Await GoogleWebAuthorizationBroker.AuthorizeAsync(
            New ClientSecrets With {
                .ClientId = ClientId,
                .ClientSecret = ClientSecret
            },
            {"https://www.googleapis.com/auth/drive"},
            "user",
            CancellationToken.None
        )

        Return New DriveService(New BaseClientService.Initializer With {
            .HttpClientInitializer = credential,
            .ApplicationName = "MyDriveBackup"
        })
    End Function

    Public Async Function UploadBackupToDriveAsync(
          backupPath As String,
          Optional statusCallback As Action(Of Integer, String) = Nothing,
          Optional parentFolderId As String = "root") As Task(Of Boolean)

        Try
            UpdateStatus(statusCallback, 45, "Connecting to Google Drive...")
            Dim driveService = Await AuthorizeAsync()

            If driveService Is Nothing Then
                Throw New Exception("Failed to connect to Google Drive")
            End If

            UpdateStatus(statusCallback, 50, "Preparing upload...")
            Dim fileMetadata = New Google.Apis.Drive.v3.Data.File() With {
                .Name = Path.GetFileName(backupPath),
                .Description = "Acebedo Optical Backup " & DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                .Parents = New List(Of String) From {parentFolderId}
            }

            Using fs As New FileStream(backupPath, FileMode.Open)
                Dim request = driveService.Files.Create(fileMetadata, fs, "application/sql")
                Dim fileSizeKB As Long = New FileInfo(backupPath).Length \ 1024

                UpdateStatus(statusCallback, 55, "Starting upload...")

                AddHandler request.ProgressChanged,
    Sub(progress)
        If progress IsNot Nothing Then
            Dim currentKB = progress.BytesSent \ 1024
            UpdateStatus(statusCallback, 60 + (currentKB * 30 / fileSizeKB),
                        "Uploading: " & currentKB & " KB of " & fileSizeKB & " KB")
        End If
    End Sub

                Dim result = Await request.UploadAsync()

                If result.Status = Google.Apis.Upload.UploadStatus.Completed Then
                    UpdateStatus(statusCallback, 100, "Backup uploaded successfully")
                    Return True
                Else
                    Throw New Exception("Upload failed: " & If(result.Exception IsNot Nothing, result.Exception.Message, "Unknown error"))
                End If
            End Using
        Catch ex As Exception
            UpdateStatus(statusCallback, 0, "Upload failed: " & ex.Message)
            Throw
        End Try
    End Function

    Private Function CreateMySQLBackup() As String
        Try
            Dim backupDir As String = "C:\Backups"
            Dim backupFile As String = "AcebedoOptical_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".sql"
            Dim backupPath As String = Path.Combine(backupDir, backupFile)

            ' Ensure directory exists
            If Not Directory.Exists(backupDir) Then
                Directory.CreateDirectory(backupDir)
            End If

            ' MySQL dump command
            Dim mysqldumpPath As String = "C:\mysql-5.6.51-winx64\bin\mysqldump.exe"
            If Not File.Exists(mysqldumpPath) Then
                Throw New FileNotFoundException("mysqldump.exe not found at: " & mysqldumpPath)
            End If

            ' Build command (no password in this example)
            Dim arguments As String = "-h localhost -u root acebedo --result-file=""" & backupPath & """"

            ' Execute backup
            Using process As New Process()
                process.StartInfo.FileName = mysqldumpPath
                process.StartInfo.Arguments = arguments
                process.StartInfo.UseShellExecute = False
                process.StartInfo.CreateNoWindow = True
                process.Start()
                process.WaitForExit()

                If process.ExitCode <> 0 Then
                    Throw New Exception("MySQL dump failed with exit code: " & process.ExitCode)
                End If
            End Using

            ' Verify backup was created
            If Not File.Exists(backupPath) Then
                Throw New Exception("Backup file was not created")
            End If

            Return backupPath
        Catch ex As Exception
            Throw New Exception("Failed to create MySQL backup: " & ex.Message)
        End Try
    End Function

    Private Sub UpdateStatus(statusCallback As Action(Of Integer, String), progress As Integer, message As String)
        If statusCallback IsNot Nothing Then
            statusCallback(progress, message)
        End If
    End Sub

    Public Async Function DownloadFileAsync(service As DriveService, fileId As String, savePath As String) As Task
        Dim request = service.Files.Get(fileId)
        Using fs As New FileStream(savePath, FileMode.Create)
            Await request.DownloadAsync(fs)
        End Using
    End Function

    Public Class GoogleDriveFilePicker
        Private ReadOnly _service As DriveService

        Public Sub New(service As DriveService)
            _service = service
        End Sub

        Public Async Function PickFileAsync(fileExtension As String) As Task(Of Google.Apis.Drive.v3.Data.File)
            Dim fileList = Await ListFilesAsync(fileExtension)

            Using pickerForm As New Form()
                pickerForm.TopMost = True
                pickerForm.StartPosition = FormStartPosition.CenterScreen
                pickerForm.Text = "Select SQL Backup File"
                pickerForm.Width = 600
                pickerForm.Height = 400

                Dim listBox As New ListBox With {
                    .Dock = DockStyle.Fill,
                    .DisplayMember = "Name"
                }

                For Each file In fileList
                    listBox.Items.Add(file)
                Next

                Dim btnSelect As New Button With {
                    .Text = "Select",
                    .Dock = DockStyle.Bottom
                }

                AddHandler btnSelect.Click, Sub(s, e)
                                                pickerForm.DialogResult = DialogResult.OK
                                                pickerForm.Close()
                                            End Sub

                pickerForm.Controls.Add(listBox)
                pickerForm.Controls.Add(btnSelect)

                If pickerForm.ShowDialog() = DialogResult.OK AndAlso listBox.SelectedItem IsNot Nothing Then
                    Return CType(listBox.SelectedItem, Google.Apis.Drive.v3.Data.File)
                End If
            End Using

            Return Nothing
        End Function

        Private Async Function ListFilesAsync(fileExtension As String) As Task(Of IList(Of Google.Apis.Drive.v3.Data.File))
            Dim request = _service.Files.List()
            request.Q = String.Format("name contains '.{0}' and trashed = false", fileExtension)
            request.Fields = "files(id, name, size, modifiedTime)"

            Dim result = Await request.ExecuteAsync()
            Return result.Files
        End Function
    End Class

End Module
