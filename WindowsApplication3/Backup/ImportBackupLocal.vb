Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Diagnostics

Public Module ImportBackupLocal
    Public ReadOnly Property ConnectionString As String
        Get
            Return "Server=localhost;Database=acebedo;Uid=root;Pwd=;"
        End Get
    End Property

    'related backup properties tas methods
    Public Const BackupDirectory As String = "C:\Backups"
    Public Const MySqlDumpPath As String = "C:\mysql-5.6.51-winx64\mysql-5.6.51-winx64\bin\mysqldump.exe"

    Public Function TableExists(tableName As String) As Boolean
        Try
            Using conn As New MySqlConnection(ConnectionString)
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT COUNT(*) FROM information_schema.tables " &
                    "WHERE table_schema = DATABASE() AND table_name = @table", conn)
                    cmd.Parameters.AddWithValue("@table", tableName)
                    Return CInt(cmd.ExecuteScalar()) > 0
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function


    Public Function CreateLocalBackup(Optional ByRef statusCallback As Action(Of Integer, String) = Nothing) As String 'local backup
        Try
            UpdateStatus(statusCallback, 10, "Initializing backup process...")

            Dim backupFile As String = "AcebedoOptical_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".sql"
            Dim backupPath As String = Path.Combine(BackupDirectory, backupFile)

            ' Verify mysqldump exists
            If Not File.Exists(MySqlDumpPath) Then
                Throw New FileNotFoundException("mysqldump.exe not found. Check the path!")
            End If

            ' Create backup directory if it doesn't exist
            UpdateStatus(statusCallback, 20, "Creating backup directory...")
            If Not Directory.Exists(BackupDirectory) Then
                Directory.CreateDirectory(BackupDirectory)
            End If

            ' Build arguments for mysqldump
            UpdateStatus(statusCallback, 30, "Preparing backup command...")
            Dim arguments As String = "-h localhost -u root acebedo --result-file=""" & backupPath & """"

            ' Configure and start the process
            UpdateStatus(statusCallback, 50, "Starting backup process...")
            Using process As New Process()
                process.StartInfo.FileName = MySqlDumpPath
                process.StartInfo.Arguments = arguments
                process.StartInfo.RedirectStandardError = True
                process.StartInfo.RedirectStandardOutput = True
                process.StartInfo.UseShellExecute = False
                process.StartInfo.CreateNoWindow = True

                AddHandler process.OutputDataReceived, Sub(senderObj, eObj) Debug.WriteLine(eObj.Data)
                AddHandler process.ErrorDataReceived, Sub(senderObj, eObj) Debug.WriteLine(eObj.Data)

                UpdateStatus(statusCallback, 70, "Running backup...")
                process.Start()
                process.BeginOutputReadLine()
                process.BeginErrorReadLine()
                process.WaitForExit()

                If process.ExitCode <> 0 Then
                    Throw New Exception("Backup process failed with exit code: " & process.ExitCode)
                End If
            End Using

            UpdateStatus(statusCallback, 100, "Backup completed successfully")
            Return True
        Catch ex As Exception
            UpdateStatus(statusCallback, 0, "Backup failed: " & ex.Message)
            Throw ' Re-throw the exception to let the caller handle it
        End Try
    End Function

    Private Sub UpdateStatus(statusCallback As Action(Of Integer, String), progress As Integer, message As String)
        If statusCallback IsNot Nothing Then
            statusCallback.Invoke(progress, message)
        End If
    End Sub

End Module

