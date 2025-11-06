Imports System.Data.SqlClient
Imports System.IO
Imports Google.Apis.Drive.v3
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.Data.Odbc
Imports System.Text  ' Required for StringBuilder
Imports System.Text.RegularExpressions

Public Class ImportData
    ' Declare OpenFileDialog at class level
    Private WithEvents OpenFileDialog1 As New OpenFileDialog()

    Private Sub btnILocal_Click(sender As Object, e As EventArgs) Handles btnILocal.Click
        OpenFileDialog1.Filter = "SQL Backup Files (*.sql)|*.sql|All Files (*.*)|*.*"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ImportSQLBackup(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Async Sub btnIgDrive_Click(sender As Object, e As EventArgs) Handles btnIgDrive.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            UpdateStatus("Connecting to Google Drive...")

            Dim driveService = Await ImportBackupGoogleDrive.AuthorizeAsync()
            Dim filePicker As New GoogleDriveFilePicker(driveService)
            Dim selectedFile = Await filePicker.PickFileAsync("sql")


            If selectedFile IsNot Nothing Then
                UpdateStatus("Downloading backup from Google Drive...")
                Dim tempPath = Path.Combine(Path.GetTempPath(), selectedFile.Name)
                Await ImportBackupGoogleDrive.DownloadFileAsync(driveService, selectedFile.Id, tempPath)

                ImportSQLBackup(tempPath)

                ' Clean up
                File.Delete(tempPath)
            End If
        Catch ex As Exception
            Me.TopMost = True
            MessageBox.Show("Error importing from Google Drive: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.TopMost = False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImportSQLBackup(filePath As String)
        Dim connectionString As String = "Server=localhost;Database=acebedo;Uid=root;Pwd=;"
        Dim errorCount As Integer = 0
        Dim successCount As Integer = 0

        Try
            ' Initialize UI with new control names
            tspBar.Value = 0
            TSPLabel.Text = "Starting import..."
            Application.DoEvents()

            ' Count total lines for progress
            Dim totalLines As Integer = File.ReadLines(filePath).Count()
            If totalLines = 0 Then
                Me.TopMost = True
                MessageBox.Show("SQL file is empty")
                Me.TopMost = False
                Return
            End If

            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Using cmd As New MySqlCommand("", conn)
                    Dim currentCommand As New StringBuilder()
                    Dim lineNumber As Integer = 0

                    For Each line As String In File.ReadLines(filePath)
                        lineNumber += 1

                        ' Update progress every 100 lines
                        If lineNumber Mod 100 = 0 Then
                            Dim progress As Integer = CInt((lineNumber / totalLines) * 100)
                            tspBar.Value = Math.Min(progress, 100)
                            TSPLabel.Text = String.Format("Processing line {0}/{1}",
                                                         lineNumber, totalLines, errorCount)
                            Application.DoEvents()
                        End If

                        ' Skip comments and empty lines
                        If line.Trim().StartsWith("--") OrElse String.IsNullOrWhiteSpace(line) Then
                            Continue For
                        End If

                        currentCommand.AppendLine(line)

                        ' Execute when statement ends with semicolon
                        If line.Trim().EndsWith(";") Then
                            cmd.CommandText = currentCommand.ToString()

                            Try
                                cmd.ExecuteNonQuery()
                                successCount += 1
                            Catch ex As MySqlException
                                errorCount += 1
                                LogError(currentCommand.ToString(), ex, lineNumber)
                            End Try

                            currentCommand.Clear()
                        End If
                    Next
                End Using
            End Using

            ' Final status update
            tspBar.Value = 100
            TSPLabel.Text = String.Format("Completed")
            'TSPLabel.Text = String.Format("Completed with {0} errors", errorCount)
            'MessageBox.Show(String.Format("Import finished!{0}Successful commands: {1}{0}Failed commands: {2}",
            '                            vbCrLf, successCount, errorCount))

        Catch
            '    tspBar.Value = 0
            '    TSPLabel.Text = "Import failed"
            '    MessageBox.Show("Fatal import error: " & ex.Message)
        End Try
    End Sub

    Private Sub LogError(commandText As String, ex As MySqlException, lineNumber As Integer)
        ' Write to debug output
        Debug.WriteLine("ERROR at line " & lineNumber & ": " & ex.Message)
        Debug.WriteLine("Failed command: " & commandText)

        ' Optional: Write to error log file
        Try
            File.AppendAllText("import_errors.log",
                             DateTime.Now.ToString() & vbCrLf &
                             "Line " & lineNumber & vbCrLf &
                             "Error: " & ex.Message & vbCrLf &
                             "Command: " & commandText & vbCrLf &
                             New String("-"c, 50) & vbCrLf)

        Catch 'ex As Exception
            'tspBar.Value = 0
            'TSPLabel.Text = "Import failed"
            'MessageBox.Show("Import failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateStatus(message As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() UpdateStatus(message))
        Else
            TSPLabel.Text = message
            Application.DoEvents()
        End If
    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Function CleanSqlFile(filePath As String) As String
        Dim sqlContent As String = File.ReadAllText(filePath)

        ' Remove problematic comment syntax
        sqlContent = Regex.Replace(sqlContent, "/\*!\d+", "/* ", RegexOptions.Multiline)
        sqlContent = Regex.Replace(sqlContent, "\*/", " */", RegexOptions.Multiline)

        ' Remove control characters
        sqlContent = Regex.Replace(sqlContent, "[\x00-\x1F]", " ")

        Return sqlContent
    End Function

    Private Function SplitSqlCommands(sqlContent As String) As List(Of String)
        Dim commands As New List(Of String)()
        Dim currentCommand As New StringBuilder()
        Dim inProcedure As Boolean = False

        For Each line As String In sqlContent.Split(vbCrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            Dim trimmedLine As String = line.Trim()

            ' Handle procedure/function declarations
            If trimmedLine.StartsWith("CREATE PROCEDURE", StringComparison.OrdinalIgnoreCase) OrElse
               trimmedLine.StartsWith("CREATE FUNCTION", StringComparison.OrdinalIgnoreCase) Then
                inProcedure = True
            ElseIf (trimmedLine.StartsWith("END$$", StringComparison.OrdinalIgnoreCase) OrElse
                   trimmedLine.StartsWith("END;", StringComparison.OrdinalIgnoreCase)) AndAlso inProcedure Then
                inProcedure = False
            End If

            currentCommand.AppendLine(line)

            ' Split at semicolons when not in procedure
            If trimmedLine.EndsWith(";") AndAlso Not inProcedure Then
                commands.Add(currentCommand.ToString())
                currentCommand.Clear()
            End If
        Next

        ' Add any remaining content
        If currentCommand.Length > 0 Then
            commands.Add(currentCommand.ToString())
        End If

        Return commands
    End Function

    Private Sub LogError(command As String, ex As MySqlException)
        ' Implement your error logging here
        errorCount += 1
    End Sub

    Private errorCount As Integer = 0


    Private Sub RestoreData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tspBar.Visible = True
        tspBar.Minimum = 0
        tspBar.Maximum = 100
    End Sub

    Private Sub ImportFromGoogleDrive(fileId As String)
        TSPLabel.Text = "Downloading from Google Drive..."
        tspBar.Style = ProgressBarStyle.Marquee
        Application.DoEvents()

        Try
            ' Your Google Drive download code here
            Dim tempFile As String = Path.GetTempFileName()

            ' Switch to determinate progress
            tspBar.Style = ProgressBarStyle.Continuous
            ImportSQLBackup(tempFile)

        Catch ex As Exception
            TSPLabel.Text = "Google Drive download failed"
            tspBar.Value = 0
            Me.TopMost = True
            MessageBox.Show("Download failed: " & ex.Message,
                           "Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error)
            Me.TopMost = False
        End Try
    End Sub
End Class