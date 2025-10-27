Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Module modData
    Public conn As Odbc.OdbcConnection
    Public myDSN As String = "DSN=dsnsystem"

    Public Sub dbConn()
        conn = New Odbc.OdbcConnection(myDSN)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                'MsgBox("Succesfully Connected to the Server!")

            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error in Connection!")
        Finally
            GC.Collect()
        End Try
    End Sub
    Public Sub LoadDGV(ByVal sql As String, ByVal dgv As DataGridView, Optional ByVal str As String = "")
        Dim cmd As Odbc.OdbcCommand
        Dim da As New Odbc.OdbcDataAdapter
        Dim dt As New DataTable
        Try
            Call dbConn()
            cmd = New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", Trim(str) & "%")
            da.SelectCommand = cmd
            da.Fill(dt)
            dgv.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message.ToString, vbCritical, "Error")
        Finally
            GC.Collect()
            conn.Close()
            conn.Dispose()
        End Try
    End Sub


End Module