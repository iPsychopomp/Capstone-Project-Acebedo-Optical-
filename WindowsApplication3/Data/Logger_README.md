# Logger Utility

A reusable logging utility for the Acebedo Optical application.

## Features

- **Automatic log folder creation** - Creates a `logs` folder in the application directory
- **Daily log files** - Separate log files for each day (format: `log_2025-11-24.txt`)
- **Multiple log levels** - INFO, DEBUG, ERROR, WARNING
- **Thread-safe** - Uses locking to prevent concurrent write issues
- **Dual output** - Writes to both Debug output and log files
- **Exception logging** - Special method to log exceptions with stack traces
- **Log cleanup** - Method to delete old log files

## Usage Examples

### Basic Logging

```vb
' Info logging
Logger.Info("Patient selected", "searchPatient")

' Debug logging
Logger.Debug("Checking form state", "searchPatient")

' Warning logging
Logger.Warning("Form not found", "searchPatient")

' Error logging
Logger.Error("Failed to load data", "searchPatient")
```

### Error Logging with Exception

```vb
Try
    ' your code here
    transForm.SetPatientInfo(pid, fullname)
Catch ex As Exception
    Logger.Error("Failed to set patient info", ex, "searchPatient")
End Try
```

### Cleanup Old Logs

Call this on application startup to keep only the last 30 days of logs:

```vb
' In your main form Load event or application startup
Logger.CleanupOldLogs(30) ' keeps last 30 days
```

## Log File Location

Logs are saved in: `[Application Directory]\logs\`

Example: `C:\Capstone (Acebedo Optical)\WindowsApplication3\bin\Debug\logs\`

## Log File Format

Each log entry includes:
- Timestamp (yyyy-MM-dd HH:mm:ss.fff)
- Log level (INFO, DEBUG, ERROR, WARNING)
- Source class name (optional)
- Message

Example:
```
[2025-11-24 14:30:45.123] [INFO] [searchPatient] Patient selected
[2025-11-24 14:30:45.456] [DEBUG] [searchPatient] Searching for addPatientTransaction in MainForm container...
[2025-11-24 14:30:45.789] [ERROR] [searchPatient] Failed to set patient info | Exception: NullReferenceException - Object reference not set to an instance of an object
```

## Implementation Notes

- The Logger class is thread-safe and can be called from multiple threads
- If the logs folder cannot be created, logging will silently fail but continue to write to Debug output
- Old log files can be cleaned up manually or automatically using `CleanupOldLogs()`
