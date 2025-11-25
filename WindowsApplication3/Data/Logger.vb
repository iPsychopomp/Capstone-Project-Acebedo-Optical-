Imports System.IO

Public Class Logger
    Private Shared ReadOnly logFolder As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs")
    Private Shared ReadOnly lockObj As New Object()

    ''' <summary>
    ''' Initializes the logger by ensuring the logs folder exists
    ''' </summary>
    Public Shared Sub Initialize()
        Try
            If Not Directory.Exists(logFolder) Then
                Directory.CreateDirectory(logFolder)
            End If
        Catch ex As Exception
            ' Silently fail if we can't create the logs folder
            System.Diagnostics.Debug.WriteLine("Failed to create logs folder: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Writes a log entry to both Debug output and a daily log file
    ''' </summary>
    ''' <param name="message">The message to log</param>
    ''' <param name="logLevel">The log level (INFO, DEBUG, ERROR, WARNING)</param>
    ''' <param name="source">The source/class name where the log originated</param>
    Public Shared Sub Log(message As String, Optional logLevel As String = "INFO", Optional source As String = "")
        Try
            Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
            Dim sourceInfo As String = If(String.IsNullOrEmpty(source), "", "[" & source & "] ")
            Dim logEntry As String = "[" & timestamp & "] [" & logLevel & "] " & sourceInfo & message

            ' Write to Debug output
            System.Diagnostics.Debug.WriteLine(logEntry)

            ' Write to file
            WriteToFile(logEntry)
        Catch ex As Exception
            ' Fallback to Debug.WriteLine if file logging fails
            System.Diagnostics.Debug.WriteLine("Logger error: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Logs an informational message
    ''' </summary>
    Public Shared Sub Info(message As String, Optional source As String = "")
        Log(message, "INFO", source)
    End Sub

    ''' <summary>
    ''' Logs a debug message
    ''' </summary>
    Public Shared Sub Debug(message As String, Optional source As String = "")
        Log(message, "DEBUG", source)
    End Sub

    ''' <summary>
    ''' Logs an error message
    ''' </summary>
    Public Shared Sub [Error](message As String, Optional source As String = "")
        Log(message, "ERROR", source)
    End Sub

    ''' <summary>
    ''' Logs an error with exception details
    ''' </summary>
    Public Shared Sub [Error](message As String, ex As Exception, Optional source As String = "")
        Dim fullMessage As String = message & " | Exception: " & ex.GetType().Name & " - " & ex.Message
        If ex.StackTrace IsNot Nothing Then
            fullMessage &= vbCrLf & "StackTrace: " & ex.StackTrace
        End If
        Log(fullMessage, "ERROR", source)
    End Sub

    ''' <summary>
    ''' Logs a warning message
    ''' </summary>
    Public Shared Sub Warning(message As String, Optional source As String = "")
        Log(message, "WARNING", source)
    End Sub

    ''' <summary>
    ''' Writes the log entry to a daily log file
    ''' </summary>
    Private Shared Sub WriteToFile(logEntry As String)
        Try
            Initialize()

            Dim logFileName As String = "log_" & DateTime.Now.ToString("yyyy-MM-dd") & ".txt"
            Dim logFilePath As String = Path.Combine(logFolder, logFileName)

            ' Use lock to prevent concurrent write issues
            SyncLock lockObj
                File.AppendAllText(logFilePath, logEntry & Environment.NewLine)
            End SyncLock
        Catch ex As Exception
            ' Silently fail if we can't write to file
            System.Diagnostics.Debug.WriteLine("Failed to write to log file: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Cleans up old log files (keeps logs for specified number of days)
    ''' </summary>
    ''' <param name="daysToKeep">Number of days to keep log files</param>
    Public Shared Sub CleanupOldLogs(Optional daysToKeep As Integer = 30)
        Try
            Initialize()

            Dim cutoffDate As DateTime = DateTime.Now.AddDays(-daysToKeep)
            Dim logFiles As String() = Directory.GetFiles(logFolder, "log_*.txt")

            For Each logFile As String In logFiles
                Dim fileInfo As New FileInfo(logFile)
                If fileInfo.CreationTime < cutoffDate Then
                    File.Delete(logFile)
                    System.Diagnostics.Debug.WriteLine("Deleted old log file: " & fileInfo.Name)
                End If
            Next
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Failed to cleanup old logs: " & ex.Message)
        End Try
    End Sub
End Class
