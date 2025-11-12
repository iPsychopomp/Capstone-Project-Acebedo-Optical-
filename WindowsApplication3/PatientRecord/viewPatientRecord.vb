Imports System.Data.Odbc

Public Class viewPatientRecord
    Private patientID As Integer = 0

    Public Sub LoadPatientData(pID As Integer)
        Try
            patientID = pID
            Call dbConn()

            Dim sql As String = "SELECT * FROM patient_data WHERE patientID = ?"
            Using cmd As New OdbcCommand(sql, conn)
                cmd.Parameters.AddWithValue("?", patientID)

                Using reader As OdbcDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Personal Information
                        lblFN.Text = reader("fname").ToString().Trim() & " " &
                                    If(String.IsNullOrEmpty(reader("mname").ToString().Trim()), "", reader("mname").ToString().Trim() & ". ") &
                                    reader("lname").ToString().Trim()

                        ' Birthday
                        If Not IsDBNull(reader("bday")) Then
                            Dim birthDate As Date = Convert.ToDateTime(reader("bday"))
                            lblBday.Text = birthDate.ToString("MMMM dd, yyyy")

                            ' Calculate Age
                            Dim today As Date = Date.Today
                            Dim age As Integer = today.Year - birthDate.Year
                            If birthDate > today.AddYears(-age) Then
                                age -= 1
                            End If
                            lblAge.Text = age.ToString() & " years old"
                        Else
                            lblBday.Text = "--"
                            lblAge.Text = "--"
                        End If

                        ' Gender
                        lblGender.Text = If(String.IsNullOrEmpty(reader("gender").ToString()), "--", reader("gender").ToString())

                        ' Contact & Address Information
                        Dim address As String = ""
                        If Not String.IsNullOrEmpty(reader("street").ToString()) Then address &= reader("street").ToString().Trim()
                        If Not String.IsNullOrEmpty(reader("brgy").ToString()) Then
                            If address <> "" Then address &= ", "
                            address &= reader("brgy").ToString().Trim()
                        End If
                        If Not String.IsNullOrEmpty(reader("city").ToString()) Then
                            If address <> "" Then address &= ", "
                            address &= reader("city").ToString().Trim()
                        End If
                        If Not String.IsNullOrEmpty(reader("province").ToString()) Then
                            If address <> "" Then address &= ", "
                            address &= reader("province").ToString().Trim()
                        End If
                        If Not String.IsNullOrEmpty(reader("region").ToString()) Then
                            If address <> "" Then address &= ", "
                            address &= reader("region").ToString().Trim()
                        End If
                        lblCA.Text = If(String.IsNullOrEmpty(address), "--", address)

                        ' Mobile Number
                        lblMN.Text = If(String.IsNullOrEmpty(reader("mobilenum").ToString()), "--", reader("mobilenum").ToString())

                        ' Lifestyle & Activities
                        lblOccu.Text = If(String.IsNullOrEmpty(reader("occupation").ToString()), "--", reader("occupation").ToString())
                        lblHobb.Text = If(String.IsNullOrEmpty(reader("hobbies").ToString()), "--", reader("hobbies").ToString())
                        lblSports.Text = If(String.IsNullOrEmpty(reader("sports").ToString()), "--", reader("sports").ToString())

                        ' Medical Information
                        Dim diabeticValue As String = reader("diabetic").ToString()
                        If diabeticValue = "1" Or diabeticValue.ToLower() = "yes" Then
                            lblDB.Text = "☑ Yes    ☐ No"
                        Else
                            lblDB.Text = "☐ Yes    ☑ No"
                        End If

                        Dim highbloodValue As String = reader("highblood").ToString()
                        If highbloodValue = "1" Or highbloodValue.ToLower() = "yes" Then
                            lblHB.Text = "☑ Yes    ☐ No"
                        Else
                            lblHB.Text = "☐ Yes    ☑ No"
                        End If

                        lblOthers.Text = If(String.IsNullOrEmpty(reader("others").ToString()), "--", reader("others").ToString())

                    Else
                        MessageBox.Show("Patient record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Close()
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading patient data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub
End Class
