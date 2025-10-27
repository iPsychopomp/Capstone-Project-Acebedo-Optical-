Module dashboardMod
    Private currentQueueNumber As Integer = 0

    Public Sub LoadProductNames(ByRef cmbProducts As ComboBox)
        Try
            Call dbConn()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim sql As String = "SELECT DISTINCT productName FROM tbl_products"
            Dim cmd As New Odbc.OdbcCommand(sql, conn)
            Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()

            cmbProducts.Items.Clear()
            Dim count As Integer = 0

            While reader.Read()
                Dim productName As String = reader("productName").ToString().Trim()
                cmbProducts.Items.Add(productName)
                count += 1
            End While

            reader.Close()
            cmbProducts.Refresh()

        Catch ex As Exception
            MsgBox("Error loading products: " & ex.Message, vbCritical, "Database Error")
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    'Public Sub GetCurrentQueueNumber(ByRef lblQueueNumber As Label)
    '    Try
    '        Call dbConn()
    '        If conn.State = ConnectionState.Closed Then conn.Open()

    '        Dim today As String = DateTime.Now.ToString("yyyy-MM-dd")
    '        Dim sql As String = "SELECT MIN(queuePosition) FROM tbl_queue WHERE queueDate = ?"
    '        Dim firstQueueNumber As Integer = 0

    '        Using cmd As New Odbc.OdbcCommand(sql, conn)
    '            cmd.Parameters.AddWithValue("?", today)
    '            Dim result As Object = cmd.ExecuteScalar()
    '            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
    '                firstQueueNumber = Convert.ToInt32(result)
    '            End If
    '        End Using

    '        If firstQueueNumber > 0 Then
    '            lblQueueNumber.Text = firstQueueNumber.ToString()
    '        Else
    '            lblQueueNumber.Text = "No Queue"
    '            lblQueueNumber.Font = New Font(lblQueueNumber.Font.FontFamily, 16, FontStyle.Bold)
    '            lblQueueNumber.Location = New Point(100, 94)

    '        End If
    '        lblQueueNumber.Refresh()

    '    Catch ex As Exception
    '        MsgBox("Error getting current queue number: " & ex.Message, vbCritical)
    '    Finally
    '        If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
    '    End Try
    'End Sub



    Public Sub GetTotalPatients(ByRef lblTotalPatients As Label)
        Try
            Call dbConn()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim sql As String = "SELECT COUNT(*) FROM patient_data"

            Using cmd As New Odbc.OdbcCommand(sql, conn)
                Dim result As Object = cmd.ExecuteScalar()

                If result Is Nothing OrElse IsDBNull(result) Then
                    lblTotalPatients.Text = "0"
                Else
                    Dim totalPatients As Integer = Convert.ToInt32(result)
                    lblTotalPatients.Text = totalPatients.ToString()
                    lblTotalPatients.Refresh()
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error fetching total patients: " & ex.Message, vbCritical, "Database Error")
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub
    Public Sub LoadTodayAppointmentsCount(lblAppointments As Label)
        Dim countSql As String = "SELECT COUNT(*) FROM tbl_checkup WHERE DATE(appointmentDate) = ?"
        Dim cmd As Odbc.OdbcCommand

        Try
            dbConn()
            cmd = New Odbc.OdbcCommand(countSql, conn)
            cmd.Parameters.AddWithValue("?", Date.Today.ToString("yyyy-MM-dd"))
            Dim total As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            If total > 0 Then
                lblAppointments.Text = total.ToString()
            Else
                lblAppointments.Text = "0"
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading appointment count: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Clean up
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub


    Public Sub ShowProductStockQuantity(ByRef cmbProducts As ComboBox, ByRef lblTotalProducts As Label)
        Try
            Call dbConn()
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim productName As String = cmbProducts.Text
            Dim sql As String = "SELECT stockQuantity FROM tbl_products WHERE productName = ?"

            Using cmd As New Odbc.OdbcCommand(sql, conn)
                cmd.Parameters.Add("?", Odbc.OdbcType.VarChar).Value = productName
                Dim result As Object = cmd.ExecuteScalar()

                lblTotalProducts.Text = If(IsDBNull(result) OrElse result Is Nothing, "0", result.ToString())
            End Using

        Catch ex As Exception
            MsgBox("Error fetching product stock quantity: " & ex.Message, vbCritical, "Database Error")
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub
End Module
