Module modAuditTrail
    Public Sub LogAuditTrail(UserID As Integer, Username As String, ActionType As String, ActionDetails As String, TableName As String, RecordID As Integer)
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Dim sql As String

        sql = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, TableName, RecordID, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"

        cmd = New Odbc.OdbcCommand(sql, conn)

        cmd.Parameters.AddWithValue("?", LoggedInUserID)
        cmd.Parameters.AddWithValue("?", LoggedInUser)
        cmd.Parameters.AddWithValue("?", ActionType)
        cmd.Parameters.AddWithValue("?", ActionDetails)
        cmd.Parameters.AddWithValue("?", TableName)
        cmd.Parameters.AddWithValue("?", RecordID)
        cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
        cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd"))

        cmd.ExecuteNonQuery()

        Dim lastIDCmd As New Odbc.OdbcCommand("SELECT LAST_INSERT_ID()", conn)
        Dim lastAuditID As Integer = Convert.ToInt32(lastIDCmd.ExecuteScalar())
    End Sub
End Module
