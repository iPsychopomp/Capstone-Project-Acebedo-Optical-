Imports System.IO
Imports System.Linq
Imports System.Data.Odbc
Imports Newtonsoft.Json
Imports System.ComponentModel ' Import for CancelEventArgs
Imports System.Text.RegularExpressions

Public Class addPatient
    Public SelectedAddress As String ' Set this before showing the form
    Private addressDataLoaded As Boolean = False ' Track if address data is loaded

    ' Lists for address data
    Private regions As List(Of RegionInfo)
    Private provinces As List(Of ProvinceInfo)
    Private cities As List(Of CityInfo)
    Private barangays As List(Of BarangayInfo)

    ' Shared caches so JSON is loaded only once per app session
    Private Shared regionCache As List(Of RegionInfo)
    Private Shared provinceCache As List(Of ProvinceInfo)
    Private Shared cityCache As List(Of CityInfo)
    Private Shared barangayCache As List(Of BarangayInfo)
    Private Shared addressCacheLoaded As Boolean = False

    ' Address Data Classes
    Public Class RegionInfo
        Public Property id As Integer
        Public Property psgc_code As String
        Public Property region_name As String
        Public Property region_code As String
    End Class

    Public Class ProvinceInfo
        Public Property province_code As String
        Public Property province_name As String
        Public Property psgc_code As String
        Public Property region_code As String
    End Class

    Public Class CityInfo
        Public Property city_code As String
        Public Property city_name As String
        Public Property region_code As String
        Public Property province_code As String
        Public Property psgc_code As String
        Public Property region_desc As String
    End Class

    Public Class BarangayInfo
        Public Property brgy_code As String
        Public Property brgy_name As String
        Public Property city_code As String
        Public Property province_code As String
        Public Property region_code As String
    End Class

    Private Sub addPatient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadAddressData()
            Call dbConn()
            addressDataLoaded = True
            ' Only do address pre-fill if editing and SelectedAddress has value
            If Not String.IsNullOrEmpty(SelectedAddress) Then
                SelectAddressFromString(SelectedAddress)
                Dim parts = SelectedAddress.Split(","c).Select(Function(p) p.Trim()).ToArray()

                If parts.Length = 3 Then
                    Dim provinceName = parts(0)
                    Dim cityName = parts(1)
                    Dim barangayName = parts(2)

                    ' Find matching province
                    Dim provinceInfo = provinces.FirstOrDefault(Function(p) p.province_name = provinceName)
                    If provinceInfo Is Nothing Then Exit Sub

                    ' Set region first
                    Dim regionInfo = regions.FirstOrDefault(Function(r) r.region_code = provinceInfo.region_code)
                    If regionInfo IsNot Nothing Then
                        cmbRegion.SelectedItem = regionInfo
                    End If

                    ' Set province
                    cmbProvince.DataSource = provinces.Where(Function(p) p.region_code = provinceInfo.region_code).ToList()
                    cmbProvince.DisplayMember = "province_name"
                    cmbProvince.ValueMember = "province_code"
                    cmbProvince.SelectedItem = provinceInfo

                    ' Find matching city
                    Dim cityInfo = cities.FirstOrDefault(Function(c) c.city_name = cityName AndAlso c.province_code = provinceInfo.province_code)
                    If cityInfo IsNot Nothing Then
                        ' Set city
                        cmbCity.DataSource = cities.Where(Function(c) c.province_code = provinceInfo.province_code).ToList()
                        cmbCity.DisplayMember = "city_name"
                        cmbCity.ValueMember = "city_code"
                        cmbCity.SelectedItem = cityInfo

                        ' Find matching barangay
                        Dim barangayInfo = barangays.FirstOrDefault(Function(b) b.brgy_name = barangayName AndAlso b.city_code = cityInfo.city_code)
                        If barangayInfo IsNot Nothing Then
                            ' Set barangay
                            cmbBgy.DataSource = barangays.Where(Function(b) b.city_code = cityInfo.city_code).ToList()
                            cmbBgy.DisplayMember = "brgy_name"
                            cmbBgy.ValueMember = "brgy_code"
                            cmbBgy.SelectedItem = barangayInfo
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading patient data: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadAddressData()
        Try
            ' Clear existing data sources first
            cmbRegion.DataSource = Nothing
            cmbProvince.DataSource = Nothing
            cmbCity.DataSource = Nothing
            cmbBgy.DataSource = Nothing

            ' Load data from JSON files only once and cache
            If Not addressCacheLoaded OrElse regionCache Is Nothing OrElse provinceCache Is Nothing OrElse cityCache Is Nothing OrElse barangayCache Is Nothing Then
                Dim dataPath = Path.Combine(Application.StartupPath, "Data")
                If Not Directory.Exists(dataPath) Then
                    Throw New Exception("Data directory not found")
                End If

                regionCache = JsonConvert.DeserializeObject(Of List(Of RegionInfo))(File.ReadAllText(Path.Combine(dataPath, "region.json")))
                provinceCache = JsonConvert.DeserializeObject(Of List(Of ProvinceInfo))(File.ReadAllText(Path.Combine(dataPath, "province.json")))
                cityCache = JsonConvert.DeserializeObject(Of List(Of CityInfo))(File.ReadAllText(Path.Combine(dataPath, "city.json")))
                barangayCache = JsonConvert.DeserializeObject(Of List(Of BarangayInfo))(File.ReadAllText(Path.Combine(dataPath, "barangay.json")))
                addressCacheLoaded = True
            End If

            ' Point instance lists to the cached lists
            regions = regionCache
            provinces = provinceCache
            cities = cityCache
            barangays = barangayCache

            ' Create default "Select" items using the actual types
            Dim allRegions = New List(Of RegionInfo)()
            allRegions.Add(New RegionInfo With {
                .region_name = "-- Select Region --",
                .region_code = "",
                .id = 0,
                .psgc_code = ""
            })
            allRegions.AddRange(regions)

            Dim allProvinces = New List(Of ProvinceInfo)()
            allProvinces.Add(New ProvinceInfo With {
                .province_name = "-- Select Province --",
                .province_code = "",
                .psgc_code = "",
                .region_code = ""
            })
            allProvinces.AddRange(provinces)

            Dim allCities = New List(Of CityInfo)()
            allCities.Add(New CityInfo With {
                .city_name = "-- Select City --",
                .city_code = "",
                .psgc_code = "",
                .region_code = "",
                .province_code = "",
                .region_desc = ""
            })
            allCities.AddRange(cities)

            Dim allBarangays = New List(Of BarangayInfo)()
            allBarangays.Add(New BarangayInfo With {
                .brgy_name = "-- Select Barangay --",
                .brgy_code = "",
                .city_code = "",
                .province_code = "",
                .region_code = ""
            })
            allBarangays.AddRange(barangays)

            ' Bind combo boxes
            cmbRegion.DataSource = allRegions
            cmbRegion.DisplayMember = "region_name"
            cmbRegion.ValueMember = "region_code"
            cmbRegion.SelectedIndex = 0

            cmbProvince.DataSource = allProvinces
            cmbProvince.DisplayMember = "province_name"
            cmbProvince.ValueMember = "province_code"
            cmbProvince.SelectedIndex = 0

            cmbCity.DataSource = allCities
            cmbCity.DisplayMember = "city_name"
            cmbCity.ValueMember = "city_code"
            cmbCity.SelectedIndex = 0

            cmbBgy.DataSource = allBarangays
            cmbBgy.DisplayMember = "brgy_name"
            cmbBgy.ValueMember = "brgy_code"
            cmbBgy.SelectedIndex = 0

            addressDataLoaded = True

            ' If we have a selected address, load it now
            If Not String.IsNullOrEmpty(SelectedAddress) Then
                SelectAddressFromString(SelectedAddress)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading address data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Initialize empty collections if loading fails
            regions = New List(Of RegionInfo)()
            provinces = New List(Of ProvinceInfo)()
            cities = New List(Of CityInfo)()
            barangays = New List(Of BarangayInfo)()
        End Try
    End Sub

    Private Sub InitializeComboBoxes()
        ' Create default "Select" items
        Dim defaultRegion As New RegionInfo With {.region_name = "-- Select Region --", .region_code = ""}
        Dim defaultProvince As New ProvinceInfo With {.province_name = "-- Select Province --", .province_code = ""}
        Dim defaultCity As New CityInfo With {.city_name = "-- Select City --", .city_code = ""}
        Dim defaultBarangay As New BarangayInfo With {.brgy_name = "-- Select Barangay --", .brgy_code = ""}

        ' Combine defaults with actual data
        Dim allRegions = New List(Of RegionInfo)({defaultRegion})
        allRegions.AddRange(regions)

        Dim allProvinces = New List(Of ProvinceInfo)({defaultProvince})
        allProvinces.AddRange(provinces)

        Dim allCities = New List(Of CityInfo)({defaultCity})
        allCities.AddRange(cities)

        Dim allBarangays = New List(Of BarangayInfo)({defaultBarangay})
        allBarangays.AddRange(barangays)

        ' Set data sources
        cmbRegion.DataSource = allRegions
        cmbRegion.DisplayMember = "region_name"
        cmbRegion.ValueMember = "region_code"
        cmbRegion.SelectedIndex = 0

        cmbProvince.DataSource = allProvinces
        cmbProvince.DisplayMember = "province_name"
        cmbProvince.ValueMember = "province_code"
        cmbProvince.SelectedIndex = 0

        cmbCity.DataSource = allCities
        cmbCity.DisplayMember = "city_name"
        cmbCity.ValueMember = "city_code"
        cmbCity.SelectedIndex = 0

        cmbBgy.DataSource = allBarangays
        cmbBgy.DisplayMember = "brgy_name"
        cmbBgy.ValueMember = "brgy_code"
        cmbBgy.SelectedIndex = 0
    End Sub

    Private Sub cmbProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProvince.SelectedIndexChanged
        Try
            If cmbProvince.SelectedItem Is Nothing Then Return

            Dim selectedProvince As ProvinceInfo = DirectCast(cmbProvince.SelectedItem, ProvinceInfo)
            Dim filteredCities = cities.Where(Function(c) c.province_code = selectedProvince.province_code).ToList()

            cmbCity.DataSource = filteredCities
            cmbCity.DisplayMember = "city_name"
            cmbCity.ValueMember = "city_code"

            cmbBgy.DataSource = Nothing
        Catch ex As Exception
            MessageBox.Show("Error loading cities: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbCity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCity.SelectedIndexChanged
        Try
            If cmbCity.SelectedItem IsNot Nothing Then
                Dim selectedCity As CityInfo = DirectCast(cmbCity.SelectedItem, CityInfo)
                Dim filteredBarangays = barangays.Where(Function(b) b.city_code = selectedCity.city_code).ToList()

                cmbBgy.DataSource = filteredBarangays
                cmbBgy.DisplayMember = "brgy_name"
                cmbBgy.ValueMember = "brgy_code"
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading barangays: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmbRegion_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbRegion.SelectedIndexChanged
        Try
            If cmbRegion.SelectedItem IsNot Nothing Then
                Dim selectedRegion As RegionInfo = DirectCast(cmbRegion.SelectedItem, RegionInfo)
                Dim filteredProvinces = provinces.Where(Function(p) p.region_code = selectedRegion.region_code).ToList()

                cmbProvince.DataSource = filteredProvinces
                cmbProvince.DisplayMember = "province_name"
                cmbProvince.ValueMember = "province_code"

                cmbCity.DataSource = Nothing
                cmbBgy.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading provinces: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SelectAddressFromString(addressString As String)
        If Not addressDataLoaded Then Exit Sub
        If String.IsNullOrEmpty(addressString) Then Exit Sub

        Try
            Dim parts = addressString.Split(","c).Select(Function(p) p.Trim()).ToArray()
            If parts.Length <> 3 Then Exit Sub

            Dim provinceName = parts(0)
            Dim cityName = parts(1)
            Dim barangayName = parts(2)

            ' Skip if it's the default "Select" item
            If provinceName = "-- Select Province --" OrElse
               cityName = "-- Select City --" OrElse
               barangayName = "-- Select Barangay --" Then
                Exit Sub
            End If

            ' Find matching province first (skip the first item which is the default)
            Dim provinceInfo = provinces.FirstOrDefault(Function(p) p.province_name = provinceName)
            If provinceInfo Is Nothing Then Exit Sub

            ' Find matching region (skip the first item which is the default)
            Dim regionInfo = regions.FirstOrDefault(Function(r) r.region_code = provinceInfo.region_code)
            If regionInfo Is Nothing Then Exit Sub

            ' Select region
            cmbRegion.SelectedValue = regionInfo.region_code

            ' Filter and select province - Create a new list with default item and filtered provinces
            Dim filteredProvinces = provinces.Where(Function(p) p.region_code = regionInfo.region_code).ToList()
            Dim provinceList As New List(Of ProvinceInfo)()
            provinceList.Add(New ProvinceInfo With {
                .province_name = "-- Select Province --",
                .province_code = ""
            })
            provinceList.AddRange(filteredProvinces)
            cmbProvince.DataSource = provinceList
            cmbProvince.SelectedValue = provinceInfo.province_code

            ' Filter and select city - Create a new list with default item and filtered cities
            Dim filteredCities = cities.Where(Function(c) c.province_code = provinceInfo.province_code).ToList()
            Dim cityList As New List(Of CityInfo)()
            cityList.Add(New CityInfo With {
                .city_name = "-- Select City --",
                .city_code = ""
            })
            cityList.AddRange(filteredCities)
            cmbCity.DataSource = cityList

            Dim cityInfo = filteredCities.FirstOrDefault(Function(c) c.city_name = cityName)
            If cityInfo IsNot Nothing Then
                cmbCity.SelectedValue = cityInfo.city_code

                ' Filter and select barangay - Create a new list with default item and filtered barangays
                Dim filteredBarangays = barangays.Where(Function(b) b.city_code = cityInfo.city_code).ToList()
                Dim barangayList As New List(Of BarangayInfo)()
                barangayList.Add(New BarangayInfo With {
                    .brgy_name = "-- Select Barangay --",
                    .brgy_code = ""
                })
                barangayList.AddRange(filteredBarangays)
                cmbBgy.DataSource = barangayList

                Dim barangayInfo = filteredBarangays.FirstOrDefault(Function(b) b.brgy_name = barangayName)
                If barangayInfo IsNot Nothing Then
                    cmbBgy.SelectedValue = barangayInfo.brgy_code
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error selecting address: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Function LoadJsonAsync(Of T)(filePath As String) As Task(Of T)
        Dim json = Await Task.Run(Function() File.ReadAllText(filePath))
        Return JsonConvert.DeserializeObject(Of T)(json)
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Normalize optional fields to "N/A" if left blank before running validations
        If String.IsNullOrWhiteSpace(txtOccu.Text) Then txtOccu.Text = "N/A"
        If String.IsNullOrWhiteSpace(txtSports.Text) Then txtSports.Text = "N/A"
        If String.IsNullOrWhiteSpace(txtMname.Text) Then txtMname.Text = "N/A"
        If String.IsNullOrWhiteSpace(txtHobbies.Text) Then txtHobbies.Text = "N/A"

        ' Validate all required fields in order and focus the first missing one
        If Not ValidateAllRequiredFieldsAndFocusFirst() Then Exit Sub

        If Not ValidateRequiredFields() Then Exit Sub
        If Not checkData(grpPatient) Then Exit Sub
        If CheckForDuplicatePatient() Then Exit Sub ' duplicate check

        Dim cmd As Odbc.OdbcCommand
        Dim sql As String
        Dim patientID As Integer
        Dim ageValue As Integer

        ' Validate age
        If Not Integer.TryParse(txtAge.Text, ageValue) Then
            MsgBox("Invalid age format. Please check the age value.", vbCritical, "Error")
            Exit Sub
        End If

        ' Read Diabetic radios
        Dim diabeticVal As String
        If dbYes.Checked Then
            diabeticVal = "Yes"
        Else
            diabeticVal = "No"
        End If

        ' Read Highblood radios
        Dim highbloodVal As String
        If hbYes.Checked Then
            highbloodVal = "Yes"
        Else
            highbloodVal = "No"
        End If

        If checkData(grpPatient) = True Then
            If MsgBox("Do you want to save this record?", vbYesNo + vbQuestion, "Save") = vbYes Then
                Try
                    dbConn()

                    If Len(pnlDataEntry.Tag) = 0 Then
                        ' INSERT NEW PATIENT
                        sql = "INSERT INTO patient_data " & _
                              "(fname, mname, lname, bday, age, highblood, occupation, province, city, brgy, diabetic, sports, hobbies, mobilenum, gender, region, date) " & _
                              "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                        cmd = New Odbc.OdbcCommand(sql, conn)

                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtFirst.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtMname.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtLname.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", dtpBday.Text)
                        cmd.Parameters.AddWithValue("?", txtAge.Text)
                        cmd.Parameters.AddWithValue("?", highbloodVal)
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtOccu.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", cmbProvince.Text)
                        cmd.Parameters.AddWithValue("?", cmbCity.Text)
                        cmd.Parameters.AddWithValue("?", cmbBgy.Text)
                        cmd.Parameters.AddWithValue("?", diabeticVal)
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtSports.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtHobbies.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", txtMobile.Text)
                        cmd.Parameters.AddWithValue("?", cmbGender.Text)
                        cmd.Parameters.AddWithValue("?", cmbRegion.Text)
                        cmd.Parameters.AddWithValue("?", dtpDate.Text)

                        cmd.ExecuteNonQuery()

                        Dim lastIDCmd As New Odbc.OdbcCommand("SELECT LAST_INSERT_ID()", conn)
                        patientID = Convert.ToInt32(lastIDCmd.ExecuteScalar())

                        Me.DialogResult = DialogResult.OK
                        Me.Tag = patientID ' Store the ID in the form's Tag property

                        InsertAuditTrail("Insert", "Added new patient: " & txtFirst.Text & " " & txtLname.Text, "patient_data", patientID)
                        MessageBox.Show("The Data is Successfully Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        cleaner()
                        RefreshPatientDGV()
                    Else
                        ' UPDATE EXISTING PATIENT
                        Dim oldDataCmd As New Odbc.OdbcCommand("SELECT * FROM patient_data WHERE patientID = ?", conn)
                        oldDataCmd.Parameters.AddWithValue("?", pnlDataEntry.Tag)
                        Dim reader As Odbc.OdbcDataReader = oldDataCmd.ExecuteReader()

                        Dim changes As New List(Of String)()

                        If reader.Read() Then
                            If reader("fname").ToString() <> txtFirst.Text Then changes.Add("First Name: " & reader("fname") & " → " & txtFirst.Text)
                            If reader("mname").ToString() <> txtMname.Text Then changes.Add("Middle Name: " & reader("mname") & " → " & txtMname.Text)
                            If reader("lname").ToString() <> txtLname.Text Then changes.Add("Last Name: " & reader("lname") & " → " & txtLname.Text)
                            If reader("bday").ToString() <> dtpBday.Text Then changes.Add("Birthday: " & reader("bday") & " → " & dtpBday.Text)
                            If reader("age").ToString() <> txtAge.Text Then changes.Add("Age: " & reader("age") & " → " & txtAge.Text)
                            If reader("occupation").ToString() <> txtOccu.Text Then changes.Add("Occupation: " & reader("occupation") & " → " & txtOccu.Text)
                            If reader("province").ToString() <> cmbProvince.Text Then changes.Add("Province: " & reader("province") & " → " & cmbProvince.Text)
                            If reader("city").ToString() <> cmbCity.Text Then changes.Add("City: " & reader("city") & " → " & cmbCity.Text)
                            If reader("brgy").ToString() <> cmbBgy.Text Then changes.Add("Barangay: " & reader("brgy") & " → " & cmbBgy.Text)
                            If reader("highblood").ToString() <> highbloodVal Then changes.Add("Highblood: " & reader("highblood") & " → " & highbloodVal)
                            If reader("diabetic").ToString() <> diabeticVal Then changes.Add("Diabetic: " & reader("diabetic") & " → " & diabeticVal)
                            If reader("sports").ToString() <> txtSports.Text Then changes.Add("Sports: " & reader("sports") & " → " & txtSports.Text)
                            If reader("hobbies").ToString() <> txtHobbies.Text Then changes.Add("Hobbies: " & reader("hobbies") & " → " & txtHobbies.Text)
                            If reader("mobilenum").ToString() <> txtMobile.Text Then changes.Add("Mobile: " & reader("mobilenum") & " → " & txtMobile.Text)
                            If reader("gender").ToString() <> cmbGender.Text Then changes.Add("Gender: " & reader("gender") & " → " & cmbGender.Text)
                            If reader("region").ToString() <> cmbRegion.Text Then changes.Add("Region: " & reader("region") & " → " & cmbRegion.Text)
                        End If

                        reader.Close()

                        sql = "UPDATE patient_data SET fname=?, mname=?, lname=?, bday=?, age=?, highblood=?, occupation=?, province=?, city=?, brgy=?, diabetic=?, sports=?, hobbies=?, mobilenum=?, gender=?, region=?, date=? WHERE patientID=?"
                        cmd = New Odbc.OdbcCommand(sql, conn)

                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtFirst.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtMname.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtLname.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", dtpBday.Text)
                        cmd.Parameters.AddWithValue("?", txtAge.Text)
                        cmd.Parameters.AddWithValue("?", highbloodVal)
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtOccu.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", cmbProvince.Text)
                        cmd.Parameters.AddWithValue("?", cmbCity.Text)
                        cmd.Parameters.AddWithValue("?", cmbBgy.Text)
                        cmd.Parameters.AddWithValue("?", diabeticVal)
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtSports.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", StrConv(Trim(txtHobbies.Text), VbStrConv.ProperCase))
                        cmd.Parameters.AddWithValue("?", txtMobile.Text)
                        cmd.Parameters.AddWithValue("?", cmbGender.Text)
                        cmd.Parameters.AddWithValue("?", cmbRegion.Text)
                        cmd.Parameters.AddWithValue("?", dtpDate.Text)
                        cmd.Parameters.AddWithValue("?", pnlDataEntry.Tag)

                        cmd.ExecuteNonQuery()

                        If changes.Count > 0 Then
                            InsertAuditTrail("Update", "Updated patient record:" & vbNewLine & String.Join(vbNewLine, changes), "patient_data", pnlDataEntry.Tag)
                        End If

                        MessageBox.Show("The Data is Successfully Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        cleaner()
                        RefreshPatientDGV()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, vbCritical, "Save Error")
                Finally
                    conn.Close()
                End Try
            End If
        End If
        Me.Close()
    End Sub

    Private Sub InsertAuditTrail(actionType As String, actionDetails As String, tableName As String, recordID As Integer)
        Try
            Dim auditSql As String = "INSERT INTO tbl_audit_trail (UserID, Username, ActionType, ActionDetails, TableName, RecordID, ActivityTime, ActivityDate) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
            Dim auditCmd As New Odbc.OdbcCommand(auditSql, conn)

            auditCmd.Parameters.AddWithValue("?", LoggedInUserID)
            auditCmd.Parameters.AddWithValue("?", LoggedInUser)
            auditCmd.Parameters.AddWithValue("?", actionType)
            auditCmd.Parameters.AddWithValue("?", actionDetails)
            auditCmd.Parameters.AddWithValue("?", tableName)
            auditCmd.Parameters.AddWithValue("?", recordID)
            auditCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("HH:mm:ss"))
            auditCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd"))

            auditCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Audit Trail Error: " & ex.Message, vbCritical, "Audit Error")
        End Try
    End Sub

    Public Sub loadRecord(ByVal patientID As Integer)
        Dim cmd As Odbc.OdbcCommand = Nothing
        Dim da As Odbc.OdbcDataAdapter = Nothing
        Dim dt As New DataTable()
        'Dim sql As String = "SELECT patientID, fname, mname, lname, bday, age, occupation, " &
        '                   "sports, hobbies, mobilenum, gender, date, diabetic, highblood, " &
        '                   "region, province, city, brgy FROM patient_data WHERE patientID=?"
        Dim sql As String = "SELECT * FROM patient_data WHERE patientID=?"

        Try
            Call dbConn()

            ' Set the form state for editing
            pnlDataEntry.Tag = patientID
            Me.Text = "Edit Patient Record - ID: " & patientID

            cmd = New Odbc.OdbcCommand(sql, conn)
            cmd.Parameters.AddWithValue("?", patientID)

            da = New Odbc.OdbcDataAdapter(cmd)
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    ' Basic information
                    txtFirst.Text = .Item("fname").ToString()
                    txtMname.Text = .Item("mname").ToString()
                    txtLname.Text = .Item("lname").ToString()
                    dtpBday.Text = .Item("bday").ToString()
                    txtAge.Text = .Item("age").ToString()
                    txtOccu.Text = .Item("occupation").ToString()
                    txtSports.Text = .Item("sports").ToString()
                    txtHobbies.Text = .Item("hobbies").ToString()
                    ' Format mobile number when loading
                    Dim mobileNum As String = .Item("mobilenum").ToString()
                    If Not String.IsNullOrEmpty(mobileNum) Then
                        ' Remove any existing formatting
                        mobileNum = mobileNum.Replace("+", "").Replace(" ", "")
                        ' Add +63 prefix if not present and number is valid
                        If mobileNum.StartsWith("0") AndAlso mobileNum.Length > 1 Then
                            mobileNum = "+63" & mobileNum.Substring(1)
                        ElseIf Not mobileNum.StartsWith("63") AndAlso Not mobileNum.StartsWith("+") Then
                            mobileNum = "+63" & mobileNum
                        ElseIf mobileNum.StartsWith("63") Then
                            mobileNum = "+" & mobileNum
                        End If
                    End If
                    txtMobile.Text = mobileNum
                    cmbGender.Text = .Item("gender").ToString()
                    dtpDate.Text = .Item("date").ToString()

                    ' Radio buttons handling with proper null checking
                    Dim diabeticValue As String = .Item("diabetic").ToString().Trim().ToLower()
                    dbYes.Checked = (diabeticValue = "yes" Or diabeticValue = "true" Or diabeticValue = "1" Or diabeticValue = "y")
                    dbNo.Checked = Not dbYes.Checked

                    Dim highbloodValue As String = .Item("highblood").ToString().Trim().ToLower()
                    hbYes.Checked = (highbloodValue = "yes" Or highbloodValue = "true" Or highbloodValue = "1" Or highbloodValue = "y")
                    hbNo.Checked = Not hbYes.Checked

                    ' Extract address components from the database
                    Dim regionName As String = If(.Item("region") Is DBNull.Value, "", .Item("region").ToString())
                    Dim provinceName As String = If(.Item("province") Is DBNull.Value, "", .Item("province").ToString())
                    Dim cityName As String = If(.Item("city") Is DBNull.Value, "", .Item("city").ToString())
                    Dim barangayName As String = If(.Item("brgy") Is DBNull.Value, "", .Item("brgy").ToString())

                    ' Set the SelectedAddress property
                    SelectedAddress = String.Format("{0}, {1}, {2}", provinceName, cityName, barangayName)

                    ' Load address components
                    LoadAddressForEditing(regionName, provinceName, cityName, barangayName)

                End With
            Else
                ' Clear all fields if no record found
                txtFirst.Text = ""
                txtMname.Text = ""
                txtLname.Text = ""
                dtpBday.Text = ""
                txtAge.Text = ""
                txtOccu.Text = ""
                cmbProvince.Text = ""
                cmbCity.Text = ""
                cmbBgy.Text = ""
                txtSports.Text = ""
                txtHobbies.Text = ""
                txtMobile.Text = ""
                cmbGender.Text = ""
                cmbRegion.Text = ""
                dtpDate.Text = ""

                ' Reset radio buttons
                dbYes.Checked = False
                dbNo.Checked = False
                hbYes.Checked = False
                hbNo.Checked = False

                MsgBox("No record found.", vbInformation, "Record Not Found")
            End If

        Catch ex As Exception
            MsgBox("Error loading record: " & ex.Message.ToString(), vbCritical, "Error Loading Record")
        Finally
            ' Clean up resources
            If da IsNot Nothing Then da.Dispose()
            If cmd IsNot Nothing Then cmd.Dispose()
            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
            End If
        End Try
    End Sub

    Private Function IsAddressDataLoaded() As Boolean
        Return regions IsNot Nothing AndAlso regions.Count > 0 AndAlso
               provinces IsNot Nothing AndAlso provinces.Count > 0 AndAlso
               cities IsNot Nothing AndAlso cities.Count > 0 AndAlso
               barangays IsNot Nothing AndAlso barangays.Count > 0
    End Function

    Private Sub LoadAddressForEditing(regionName As String, provinceName As String, cityName As String, barangayName As String)
        Try
            ' Add null checks for all collections
            If regions Is Nothing OrElse provinces Is Nothing OrElse cities Is Nothing OrElse barangays Is Nothing Then
                Return
            End If

            ' First, find the region with null check
            Dim region = regions.FirstOrDefault(Function(r) r IsNot Nothing AndAlso r.region_name = regionName)
            If region IsNot Nothing Then
                ' Set the region
                cmbRegion.SelectedValue = region.region_code

                ' Find the province with null check
                Dim province = provinces.FirstOrDefault(Function(p) p IsNot Nothing AndAlso p.province_name = provinceName AndAlso p.region_code = region.region_code)
                If province IsNot Nothing Then
                    ' Set the province
                    cmbProvince.SelectedValue = province.province_code

                    ' Find the city with null check
                    Dim city = cities.FirstOrDefault(Function(c) c IsNot Nothing AndAlso c.city_name = cityName AndAlso c.province_code = province.province_code)
                    If city IsNot Nothing Then
                        ' Set the city
                        cmbCity.SelectedValue = city.city_code

                        ' Find the barangay with null check
                        Dim barangay = barangays.FirstOrDefault(Function(b) b IsNot Nothing AndAlso b.brgy_name = barangayName AndAlso b.city_code = city.city_code)
                        If barangay IsNot Nothing Then
                            ' Set the barangay
                            cmbBgy.SelectedValue = barangay.brgy_code
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading address: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pnlDataEntry_Paint(sender As Object, e As PaintEventArgs) Handles pnlDataEntry.Paint
        txtFirst.TabIndex = 0
        txtMname.TabIndex = 1
        txtLname.TabIndex = 2
        dtpBday.TabIndex = 3
        txtAge.TabIndex = 4
        cmbGender.TabIndex = 5
        cmbRegion.TabIndex = 6
        cmbProvince.TabIndex = 7
        cmbCity.TabIndex = 8
        cmbBgy.TabIndex = 9
        grpDiabetic.TabIndex = 10
        grpHighblood.TabIndex = 11
        txtOccu.TabIndex = 12
        txtMobile.TabIndex = 13
        txtSports.TabIndex = 14
        dtpDate.TabIndex = 15
        txtHobbies.TabIndex = 16
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Function checkData(ByVal gb As GroupBox) As Boolean
        For Each obj As Object In gb.Controls
            If TypeOf obj Is TextBox Then
                If Len(obj.Text) = 0 Then
                    MsgBox("Please input data", vbCritical, "Save")
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub cleaner()
        For Each obj As Control In grpPatient.Controls
            If TypeOf obj Is TextBox Then
                Dim txt As TextBox = CType(obj, TextBox)
                txt.Text = "" ' Clear nang textbox
            ElseIf TypeOf obj Is ComboBox Then
                Dim cmb As ComboBox = CType(obj, ComboBox)
                cmb.Text = ""
                cmb.SelectedIndex = -1
            ElseIf TypeOf obj Is RichTextBox Then
                Dim rtb As RichTextBox = CType(obj, RichTextBox)
                rtb.Clear()
            ElseIf TypeOf obj Is DateTimePicker Then
                Dim dtp As DateTimePicker = CType(obj, DateTimePicker)
                dtp.Value = Date.Today
            End If
        Next

        ' Reset nang age label
        txtAge.Text = "0"

        patientRecord.patientDGV.Tag = ""
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call cleaner()
    End Sub

    Private Function CheckForDuplicatePatient() As Boolean
        Dim cmd As New Odbc.OdbcCommand
        Dim sql As String
        Dim isDuplicate As Boolean = False

        Try
            Call dbConn()

            If Len(pnlDataEntry.Tag) = 0 Then
                ' For new records, check for duplicates
                sql = "SELECT COUNT(*) FROM patient_data WHERE UPPER(fname) = ? AND UPPER(lname) = ? AND bday = ?"
                cmd = New Odbc.OdbcCommand(sql, conn)

                cmd.Parameters.AddWithValue("?", Trim(txtFirst.Text).ToUpper())
                cmd.Parameters.AddWithValue("?", Trim(txtLname.Text).ToUpper())
                cmd.Parameters.AddWithValue("?", dtpBday.Text)

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    isDuplicate = True
                    MessageBox.Show("A patient with the same First Name, Last Name, and Birthdate already exists in the database.", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ' For existing records, check if another record with same data exists (excluding current record)
                sql = "SELECT COUNT(*) FROM patient_data WHERE UPPER(fname) = ? AND UPPER(lname) = ? AND bday = ? AND patientID <> ?"
                cmd = New Odbc.OdbcCommand(sql, conn)

                cmd.Parameters.AddWithValue("?", Trim(txtFirst.Text).ToUpper())
                cmd.Parameters.AddWithValue("?", Trim(txtLname.Text).ToUpper())
                cmd.Parameters.AddWithValue("?", dtpBday.Text)
                cmd.Parameters.AddWithValue("?", pnlDataEntry.Tag)

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    isDuplicate = True
                    MessageBox.Show("Another patient with the same First Name, Last Name, and Birthdate already exists in the database.", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error checking for duplicate patient: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cmd IsNot Nothing Then cmd.Dispose()
            conn.Close()
            conn.Dispose()
        End Try
        Return isDuplicate
    End Function

    Private Function ValidateRequiredFields(Optional skipValidation As Boolean = False) As Boolean
        If skipValidation Then Return True

        If String.IsNullOrWhiteSpace(txtFirst.Text) Then
            MsgBox("First Name is required.", vbExclamation, "Error")
            txtFirst.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtLname.Text) Then
            MsgBox("Last Name is required.", vbExclamation, "Error")
            txtLname.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function ValidateAllRequiredFieldsAndFocusFirst() As Boolean
        Dim missing As New List(Of String)
        Dim firstInvalidControl As Control = Nothing

        Dim assignFirst As Action(Of Control) = Sub(ctrl As Control)
                                                    If firstInvalidControl Is Nothing Then firstInvalidControl = ctrl
                                                End Sub

        ' Helpers to detect default/empty selection
        Dim isComboMissing As Func(Of ComboBox, Boolean) = Function(cb As ComboBox)
                                                               Return cb Is Nothing OrElse cb.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(cb.Text) OrElse cb.Text.Trim().StartsWith("--")
                                                           End Function

        ' 1. First Name
        If String.IsNullOrWhiteSpace(txtFirst.Text) Then
            missing.Add("First Name")
            assignFirst(txtFirst)
        End If

        ' 2. Last Name
        If String.IsNullOrWhiteSpace(txtLname.Text) Then
            missing.Add("Last Name")
            assignFirst(txtLname)
        End If

        ' 3. Birthday (ensure age computed and > 0)
        Dim ageVal As Integer = 0
        Integer.TryParse(txtAge.Text, ageVal)
        If ageVal <= 0 Then
            missing.Add("Birthday")
            assignFirst(dtpBday)
        End If

        ' 4. Gender
        If cmbGender Is Nothing OrElse cmbGender.SelectedIndex = -1 OrElse String.IsNullOrWhiteSpace(cmbGender.Text) Then
            missing.Add("Gender")
            assignFirst(cmbGender)
        End If

        ' 5. Region/Province/City/Barangay (not default selections)
        If isComboMissing(cmbRegion) Then
            missing.Add("Region")
            assignFirst(cmbRegion)
        End If
        If isComboMissing(cmbProvince) Then
            missing.Add("Province")
            assignFirst(cmbProvince)
        End If
        ' Special-case: some cities may include the word "City" (e.g., "Caloocan City"). Use SelectedValue when available
        If isComboMissing(cmbCity) Then
            missing.Add("City")
            assignFirst(cmbCity)
        End If
        If isComboMissing(cmbBgy) Then
            missing.Add("Barangay")
            assignFirst(cmbBgy)
        End If

        ' 6. Diabetic and Highblood radio selections
        If Not dbYes.Checked AndAlso Not dbNo.Checked Then
            missing.Add("is patient diabetic")
            assignFirst(dbYes)
        End If
        If Not hbYes.Checked AndAlso Not hbNo.Checked Then
            missing.Add("is patient highblood")
            assignFirst(hbYes)
        End If

        ' 7. Mobile Number (REQUIRED): must be provided and valid; "+63" is considered blank
        Dim mobileVal As String = If(txtMobile.Text, String.Empty).Trim()
        If mobileVal = String.Empty OrElse mobileVal = "+63" Then
            missing.Add("Mobile Number")
            assignFirst(txtMobile)
        Else
            If Not ValidatePhoneNumber() Then
                missing.Add("Valid Mobile Number")
                assignFirst(txtMobile)
            End If
        End If

        If missing.Count > 0 Then
            Dim message As String = "Please complete the required fields marked with (*):" & vbCrLf & " - " & String.Join(vbCrLf & " - ", missing)
            MessageBox.Show(message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If firstInvalidControl IsNot Nothing Then firstInvalidControl.Focus()
            Return False
        End If

        Return True
    End Function

    ' Removed hard requirement for Mobile Number on save. Validation happens only if provided.

    Private Sub TextBox_Validating(sender As Object, e As CancelEventArgs)
        Dim textControl As Control = DirectCast(sender, Control)

        ' Skip validation if focus is moving to certain buttons
        If ActiveControl Is btnCancel Or ActiveControl Is btnClear Then
            Exit Sub
        End If

        ' Custom validation for specific TextBox fields
        Select Case textControl.Name
            Case "txtFirst"
                If String.IsNullOrWhiteSpace(textControl.Text) Then
                    MsgBox("Don't leave the First Name field blank.", vbExclamation, "Error")
                End If
            Case "txtLname"
                If String.IsNullOrWhiteSpace(textControl.Text) Then
                    MsgBox("Don't leave the Last Name field blank.", vbExclamation, "Error")
                End If
            Case "txtMobile"
                ' Allow user to move past Mobile without blocking; saving enforces requirement
                If String.IsNullOrWhiteSpace(textControl.Text) Then
                    ' Show a gentle alert but do not cancel or force focus here
                    'MsgBox("Mobile Number is currently blank. You can continue, but it is required before saving.", vbInformation, "Notice")
                End If
            Case "txtOccu", "txtSports", "txtMname", "txtHobbies"
                ' Set N/A for these specific text boxes if empty
                If String.IsNullOrWhiteSpace(textControl.Text) Then
                    textControl.Text = "N/A"
                End If
        End Select
    End Sub

    Private Sub ComboBox_Validating(sender As Object, e As CancelEventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)

        ' Skip validation if focus is moving to certain buttons
        If ActiveControl Is btnCancel Or ActiveControl Is btnClear Then
            Exit Sub
        End If

        ' Custom validation for specific ComboBox fields
        Select Case cmb.Name
            Case "cmbGender"
                If String.IsNullOrWhiteSpace(cmb.Text) Then
                    MsgBox("Don't leave the Gender field blank.", vbExclamation, "Error")
                End If
            Case "cmbRegion"
                If String.IsNullOrWhiteSpace(cmb.Text) Then
                    MsgBox("Don't leave the Region field blank.", vbExclamation, "Error")
                End If
            Case "cmbProvince"
                If String.IsNullOrWhiteSpace(cmb.Text) Then
                    MsgBox("Don't leave the Province field blank.", vbExclamation, "Error")
                End If
            Case "cmbCity"
                If String.IsNullOrWhiteSpace(cmb.Text) Then
                    MsgBox("Don't leave the City field blank.", vbExclamation, "Error")
                End If
            Case "cmbBgy"
                If String.IsNullOrWhiteSpace(cmb.Text) Then
                    MsgBox("Don't leave the Barangay field blank.", vbExclamation, "Error")
                End If
        End Select
    End Sub

    Private Sub DateTimePicker_Validating(sender As Object, e As CancelEventArgs)
        Dim dtp As DateTimePicker = CType(sender, DateTimePicker)

        If ActiveControl Is btnCancel Or ActiveControl Is btnClear Then
            Exit Sub
        End If

        ' Custom validation for DateTimePicker fields
        If dtp.Name = "dtpBday" Then
            ' Check if the date is valid for a birthdate (not in the future)
            If dtp.Value > Date.Today Then
                MsgBox("Birth Date cannot be in the future.", vbExclamation, "Error")
            End If

            ' Check if age is 0
            Dim age As Integer
            If Integer.TryParse(txtAge.Text, age) AndAlso age = 0 Then
                MsgBox("Please Select a Birth Date", vbExclamation, "Error")
            End If

            ' Check if the birthdate is reasonable (not more than 120 years ago)
            Dim maxAge As Integer = 120
            If dtp.Value < Date.Today.AddYears(-maxAge) Then
                MsgBox("Please enter a Valid Birth Date.", vbExclamation, "Error")
            End If
        End If
    End Sub

    Private Sub dtpBday_ValueChanged(sender As Object, e As EventArgs) Handles dtpBday.ValueChanged
        Dim birthDate As Date = dtpBday.Value
        Dim today As Date = Date.Today
        Dim age As Integer = today.Year - birthDate.Year

        If (birthDate > today.AddYears(-age)) Then
            age -= 1
        End If
        txtAge.Text = age.ToString()
    End Sub

    Private Sub patientEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            ' Enable only the specific "N/A" auto-fill behavior on tab/skip for these text boxes
            AddHandler txtOccu.Validating, AddressOf TextBox_Validating
            AddHandler txtSports.Validating, AddressOf TextBox_Validating
            AddHandler txtMname.Validating, AddressOf TextBox_Validating
            AddHandler txtHobbies.Validating, AddressOf TextBox_Validating
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtMobile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMobile.KeyPress
        ' Allow control characters (backspace, delete, etc.)
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        ' Allow only digits
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            Return
        End If

        ' Prevent typing beyond 10 digits (after +63)
        Dim currentText = txtMobile.Text.Replace("+", "").Replace(" ", "")
        If currentText.Length >= 12 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs) Handles txtMobile.TextChanged
        ' Prevent recursive calls
        Static isUpdating As Boolean = False
        If isUpdating Then Return
        isUpdating = True

        Try
            ' Get current cursor position
            Dim selectionStart = txtMobile.SelectionStart

            ' Remove all non-digit characters
            Dim digitsOnly As String = New String(txtMobile.Text.Where(Function(c) Char.IsDigit(c)).ToArray())

            ' Format the number
            Dim formattedNumber As String = ""

            If digitsOnly.Length > 0 Then
                ' Handle different possible starting formats
                If digitsOnly.StartsWith("63") Then
                    digitsOnly = digitsOnly.Substring(2)
                ElseIf digitsOnly.StartsWith("0") Then
                    digitsOnly = digitsOnly.Substring(1)
                End If

                ' Take only the first 10 digits
                If digitsOnly.Length > 10 Then
                    digitsOnly = digitsOnly.Substring(0, 10)
                End If

                ' Format as +63XXXXXXXXXX
                formattedNumber = "+" & "63" & digitsOnly

                ' Update cursor position
                If selectionStart > 0 Then
                    ' If user is typing at the start, keep cursor at the end of the number part
                    If selectionStart <= 3 Then
                        selectionStart = 3 + digitsOnly.Length
                    Else
                        ' Adjust cursor position based on the new formatting
                        selectionStart = Math.Min(selectionStart, formattedNumber.Length)
                    End If
                End If
            End If

            ' Only update if different to prevent cursor jumping
            If txtMobile.Text <> formattedNumber Then
                txtMobile.Text = formattedNumber
                txtMobile.SelectionStart = selectionStart
            End If

            ' Validate the number
            ValidatePhoneNumber()

        Catch ex As Exception
            ' Log error if needed
            Debug.WriteLine("Error in phone number formatting: " & ex.Message)
        Finally
            isUpdating = False
        End Try
    End Sub

    Private Sub txtMobile_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtMobile.Validating
        ' Skip validation if moving to cancel/clear buttons
        If ActiveControl Is btnCancel Or ActiveControl Is btnClear Then
            ErrorProvider1.SetError(txtMobile, "")
            Exit Sub
        End If

        Dim mobile As String = If(txtMobile.Text, String.Empty).Trim()

        ' Show notice when leaving field blank or retaining only +63
        If mobile = String.Empty OrElse mobile = "+63" Then
            'ErrorProvider1.SetError(txtMobile, "Mobile Number is required before saving.")


            e.Cancel = False
            Exit Sub
        End If

        ' Validate input format (non-blocking for navigation)
        If Not ValidatePhoneNumber() Then
            ErrorProvider1.SetError(txtMobile, "Please enter a valid Philippine mobile number (e.g., 09123456789).")
            e.Cancel = False
        Else
            ErrorProvider1.SetError(txtMobile, "")
        End If
    End Sub

    Private Function ValidatePhoneNumber() As Boolean
        ' Get the current text
        Dim phoneNumber = txtMobile.Text.Trim()

        ' Skip validation if empty (making it optional)
        If String.IsNullOrEmpty(phoneNumber) OrElse phoneNumber = "+63" Then
            ErrorProvider1.SetError(txtMobile, "")
            Return True
        End If

        ' Remove any formatting
        Dim digitsOnly As String = New String(phoneNumber.Where(Function(c) Char.IsDigit(c)).ToArray())

        ' Check length (should be exactly 12 digits including country code)
        If digitsOnly.Length <> 12 OrElse Not digitsOnly.StartsWith("63") Then
            ErrorProvider1.SetError(txtMobile, "Please enter a valid Philippine mobile number (e.g., 09123456789).")
            Return False
        End If

        ' If we get here, the number is valid
        ErrorProvider1.SetError(txtMobile, "")
        Return True
    End Function

    Private Sub txtMobile_Enter(sender As Object, e As EventArgs) Handles txtMobile.Enter
        ' Only add +63 if the field is completely empty
        If String.IsNullOrWhiteSpace(txtMobile.Text) Then
            txtMobile.Text = "+63"
            txtMobile.SelectionStart = txtMobile.Text.Length
        End If
    End Sub
End Class
