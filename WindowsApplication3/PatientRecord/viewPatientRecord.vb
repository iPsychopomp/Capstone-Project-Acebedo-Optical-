Public Class viewPatientRecord

    Public Sub ViewPatientRecord(patientID As String)
        pnlViewPatientRecord.Controls.Clear()
        pnlViewPatientRecord.AutoScroll = True

        Dim yOffset As Integer = 10
        Call dbConn()

        Dim cmd As New Odbc.OdbcCommand("SELECT * FROM patient_data WHERE patientID = ?", conn)
        cmd.Parameters.AddWithValue("?", patientID)

        Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()
        Dim labelFont As New Font("Segoe UI", 12, FontStyle.Regular)

        While reader.Read()
            ' Set the form's patient name label
            lblPatientName.Text = "Patient Name: " &
                reader("fname").ToString().Trim() & " " &
                reader("mname").ToString().Trim() & ". " &
                reader("lname").ToString().Trim()

            ' Create the card panel
            Dim card As New Panel()
            card.Width = pnlViewPatientRecord.Width - 30
            card.Left = 10
            card.BackColor = Color.White
            card.BorderStyle = BorderStyle.FixedSingle

            ' Prepare the 10 fields
            Dim fields As New List(Of String) From {
                "Age: " & reader("age").ToString(),
                "Gender: " & reader("gender").ToString(),
                "Address: " & reader("region").ToString() & ", " &
                           reader("province").ToString() & ", " &
                           reader("city").ToString() & ", " &
                           reader("brgy").ToString(),
                "Contact: " & reader("mobilenum").ToString(),
                "Occupation: " & reader("occupation").ToString(),
                "Date of Birth: " & Convert.ToDateTime(reader("bday")).ToShortDateString(),
                "High Blood: " & If(reader("highblood").ToString() = "1", "Yes", "No"),
                "Diabetic: " & If(reader("diabetic").ToString() = "1", "Yes", "No"),
                "Sports: " & reader("sports").ToString(),
                "Hobbies: " & reader("hobbies").ToString()
            }

            ' Layout parameters
            Dim leftX As Integer = 10
            Dim rightX As Integer = (card.Width \ 2) + 10
            Dim startY As Integer = 10
            Dim spacing As Integer = labelFont.Height + 6

            ' Add first 5 fields in left column
            For i As Integer = 0 To 4
                Dim lbl As New Label()
                lbl.Text = fields(i)
                lbl.AutoSize = True
                lbl.Font = labelFont
                lbl.Location = New Point(leftX, startY + i * spacing)
                card.Controls.Add(lbl)
            Next

            ' Add next 5 fields in right column
            For i As Integer = 5 To 9
                Dim lbl As New Label()
                lbl.Text = fields(i)
                lbl.AutoSize = True
                lbl.Font = labelFont
                lbl.Location = New Point(rightX, startY + (i - 5) * spacing)
                card.Controls.Add(lbl)
            Next

            ' Set card's height and position on the form
            card.Height = startY + 5 * spacing + 10
            card.Top = yOffset

            ' Add to the containing panel
            pnlViewPatientRecord.Controls.Add(card)

            ' Move down for the next card (if any)
            yOffset += card.Height + 10
        End While

        reader.Close()
    End Sub


End Class
