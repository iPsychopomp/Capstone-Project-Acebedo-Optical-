Public Class viewCheckUp

    Public Sub ViewCheckup(patientID As String)
        pnlViewCheck.Controls.Clear()
        pnlViewCheck.AutoScroll = True

        Dim yOffset As Integer = 10
        Dim cmd As New Odbc.OdbcCommand()
        Dim sql As String = "SELECT * FROM db_viewcheckupdetails WHERE PatientID = ? ORDER BY checkupID DESC"
        Call dbConn()
        cmd.Connection = conn
        cmd.CommandText = sql
        cmd.Parameters.AddWithValue("", patientID)

        Dim reader As Odbc.OdbcDataReader = cmd.ExecuteReader()
        Dim labelFontBold As New Font("Segoe UI", 11, FontStyle.Regular)
        Dim labelFontRegular As New Font("Segoe UI", 11, FontStyle.Regular)

        While reader.Read()
            Dim card As New Panel()
            card.Size = New Size(pnlViewCheck.Width - 30, 350)
            card.Location = New Point(10, yOffset)
            card.BackColor = Color.White
            card.BorderStyle = BorderStyle.FixedSingle

            ' Patient Name
            Dim lblPatientTitle As New Label()
            lblPatientTitle.Text = "Patient Name:"
            lblPatientTitle.Location = New Point(10, 10)
            lblPatientTitle.AutoSize = True
            lblPatientTitle.Font = labelFontBold
            card.Controls.Add(lblPatientTitle)

            Dim lblPatientValue As New Label()
            lblPatientValue.Text = reader("PatientName").ToString()
            lblPatientValue.Location = New Point(lblPatientTitle.Right + 5, 10)
            lblPatientValue.AutoSize = True
            lblPatientValue.Font = labelFontRegular
            card.Controls.Add(lblPatientValue)

            ' Date
            Dim lblDateTitle As New Label()
            lblDateTitle.Text = "Date:"
            lblDateTitle.Location = New Point(10, 45)
            lblDateTitle.AutoSize = True
            lblDateTitle.Font = labelFontBold
            card.Controls.Add(lblDateTitle)

            Dim lblDateValue As New Label()
            lblDateValue.Text = Convert.ToDateTime(reader("CheckupDate")).ToShortDateString()
            lblDateValue.Location = New Point(lblDateTitle.Right + 5, 45)
            lblDateValue.AutoSize = True
            lblDateValue.Font = labelFontRegular
            card.Controls.Add(lblDateValue)

            ' Line below date
            Dim dateLine As New Panel()
            dateLine.BackColor = Color.Black
            dateLine.Size = New Size(card.Width - 20, 2)
            dateLine.Location = New Point(10, 80)
            card.Controls.Add(dateLine)

            ' Headers
            Dim colWidth As Integer = (card.Width - 20) \ 4
            Dim headerTop As Integer = 90
            Dim rowTop1 As Integer = 125
            Dim rowTop2 As Integer = 155
            Dim leftMargin As Integer = 10

            Dim headers() As String = {"Sphere:", "Cylinder:", "Axis:", "Add:"}
            For i As Integer = 0 To 3
                Dim lblHeader As New Label()
                lblHeader.Text = headers(i)
                lblHeader.Font = labelFontBold
                lblHeader.Location = New Point(leftMargin + (i * colWidth), headerTop)
                lblHeader.AutoSize = True
                card.Controls.Add(lblHeader)

                Dim underline As New Panel()
                underline.BackColor = Color.Black
                underline.Size = New Size(colWidth, 2)
                underline.Location = New Point(leftMargin + (i * colWidth), headerTop + 30)
                card.Controls.Add(underline)
            Next

            ' Sphere OD/OS
            Dim lblSphereOD As New Label()
            lblSphereOD.Text = "OD:"
            lblSphereOD.Location = New Point(leftMargin, rowTop1)
            lblSphereOD.AutoSize = True
            lblSphereOD.Font = labelFontBold
            card.Controls.Add(lblSphereOD)

            Dim valSphereOD As New Label()
            valSphereOD.Text = reader("sphereOD").ToString()
            valSphereOD.Location = New Point(lblSphereOD.Right + 5, rowTop1)
            valSphereOD.AutoSize = True
            valSphereOD.Font = labelFontRegular
            card.Controls.Add(valSphereOD)

            Dim lblSphereOS As New Label()
            lblSphereOS.Text = "OS:"
            lblSphereOS.Location = New Point(leftMargin, rowTop2)
            lblSphereOS.AutoSize = True
            lblSphereOS.Font = labelFontBold
            card.Controls.Add(lblSphereOS)

            Dim valSphereOS As New Label()
            valSphereOS.Text = reader("sphereOS").ToString()
            valSphereOS.Location = New Point(lblSphereOS.Right + 5, rowTop2)
            valSphereOS.AutoSize = True
            valSphereOS.Font = labelFontRegular
            card.Controls.Add(valSphereOS)

            ' Cylinder OD/OS
            Dim lblCylinderOD As New Label()
            lblCylinderOD.Text = "OD:"
            lblCylinderOD.Location = New Point(leftMargin + colWidth, rowTop1)
            lblCylinderOD.AutoSize = True
            lblCylinderOD.Font = labelFontBold
            card.Controls.Add(lblCylinderOD)

            Dim valCylinderOD As New Label()
            valCylinderOD.Text = reader("cylinderOD").ToString()
            valCylinderOD.Location = New Point(lblCylinderOD.Right + 5, rowTop1)
            valCylinderOD.AutoSize = True
            valCylinderOD.Font = labelFontRegular
            card.Controls.Add(valCylinderOD)

            Dim lblCylinderOS As New Label()
            lblCylinderOS.Text = "OS:"
            lblCylinderOS.Location = New Point(leftMargin + colWidth, rowTop2)
            lblCylinderOS.AutoSize = True
            lblCylinderOS.Font = labelFontBold
            card.Controls.Add(lblCylinderOS)

            Dim valCylinderOS As New Label()
            valCylinderOS.Text = reader("cylinderOS").ToString()
            valCylinderOS.Location = New Point(lblCylinderOS.Right + 5, rowTop2)
            valCylinderOS.AutoSize = True
            valCylinderOS.Font = labelFontRegular
            card.Controls.Add(valCylinderOS)

            ' Axis OD/OS
            Dim lblAxisOD As New Label()
            lblAxisOD.Text = "OD:"
            lblAxisOD.Location = New Point(leftMargin + (colWidth * 2), rowTop1)
            lblAxisOD.AutoSize = True
            lblAxisOD.Font = labelFontBold
            card.Controls.Add(lblAxisOD)

            Dim valAxisOD As New Label()
            valAxisOD.Text = reader("axisOD").ToString()
            valAxisOD.Location = New Point(lblAxisOD.Right + 5, rowTop1)
            valAxisOD.AutoSize = True
            valAxisOD.Font = labelFontRegular
            card.Controls.Add(valAxisOD)

            Dim lblAxisOS As New Label()
            lblAxisOS.Text = "OS:"
            lblAxisOS.Location = New Point(leftMargin + (colWidth * 2), rowTop2)
            lblAxisOS.AutoSize = True
            lblAxisOS.Font = labelFontBold
            card.Controls.Add(lblAxisOS)

            Dim valAxisOS As New Label()
            valAxisOS.Text = reader("axisOS").ToString()
            valAxisOS.Location = New Point(lblAxisOS.Right + 5, rowTop2)
            valAxisOS.AutoSize = True
            valAxisOS.Font = labelFontRegular
            card.Controls.Add(valAxisOS)

            ' Add OD/OS
            Dim lblAddOD As New Label()
            lblAddOD.Text = "OD:"
            lblAddOD.Location = New Point(leftMargin + (colWidth * 3), rowTop1)
            lblAddOD.AutoSize = True
            lblAddOD.Font = labelFontBold
            card.Controls.Add(lblAddOD)

            Dim valAddOD As New Label()
            valAddOD.Text = reader("addOD").ToString()
            valAddOD.Location = New Point(lblAddOD.Right + 5, rowTop1)
            valAddOD.AutoSize = True
            valAddOD.Font = labelFontRegular
            card.Controls.Add(valAddOD)

            Dim lblAddOS As New Label()
            lblAddOS.Text = "OS:"
            lblAddOS.Location = New Point(leftMargin + (colWidth * 3), rowTop2)
            lblAddOS.AutoSize = True
            lblAddOS.Font = labelFontBold
            card.Controls.Add(lblAddOS)

            Dim valAddOS As New Label()
            valAddOS.Text = reader("addOS").ToString()
            valAddOS.Location = New Point(lblAddOS.Right + 5, rowTop2)
            valAddOS.AutoSize = True
            valAddOS.Font = labelFontRegular
            card.Controls.Add(valAddOS)

            ' Remarks line
            Dim remarksLine As New Panel()
            remarksLine.BackColor = Color.Black
            remarksLine.Size = New Size(card.Width - 20, 2)
            remarksLine.Location = New Point(10, 190)
            card.Controls.Add(remarksLine)

            ' Remarks
            Dim lblRemarksTitle As New Label()
            lblRemarksTitle.Text = "Remarks:"
            lblRemarksTitle.Location = New Point(leftMargin, 200)
            lblRemarksTitle.AutoSize = True
            lblRemarksTitle.Font = labelFontBold
            card.Controls.Add(lblRemarksTitle)

            Dim lblRemarksValue As New Label()
            lblRemarksValue.Text = reader("remarks").ToString()
            lblRemarksValue.Location = New Point(lblRemarksTitle.Right + 5, 200)
            lblRemarksValue.AutoSize = True
            lblRemarksValue.Font = labelFontRegular
            card.Controls.Add(lblRemarksValue)

            ' Doctor line
            Dim doctorline As New Panel()
            doctorline.BackColor = Color.Black
            doctorline.Size = New Size(card.Width - 20, 2)
            doctorline.Location = New Point(leftMargin, 250)
            card.Controls.Add(doctorline)

            ' Doctor Name
            Dim lblDoctorTitle As New Label()
            lblDoctorTitle.Text = "Doctor Name:"
            lblDoctorTitle.Location = New Point(leftMargin, 260)
            lblDoctorTitle.AutoSize = True
            lblDoctorTitle.Font = labelFontBold
            card.Controls.Add(lblDoctorTitle)

            Dim lblDoctorValue As New Label()
            lblDoctorValue.Text = reader("DoctorName").ToString()
            lblDoctorValue.Location = New Point(lblDoctorTitle.Right + 5, 260)
            lblDoctorValue.AutoSize = True
            lblDoctorValue.Font = labelFontRegular
            card.Controls.Add(lblDoctorValue)

            ' Add card to panel
            pnlViewCheck.Controls.Add(card)
            yOffset += card.Height + 10
        End While

        reader.Close()
    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub lblPatientName_Click(sender As Object, e As EventArgs) Handles lblPatientName.Click

    End Sub

    Private Sub viewCheckUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
