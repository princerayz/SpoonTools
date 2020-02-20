Imports Newtonsoft.Json
Imports System.Drawing.Imaging
Imports System.Threading
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Text

Public Class Form1

    Public UserAgent As String = "AppleWebKit/537.36 Mozilla"
    Dim selection As Rectangle
    Dim selectionColour As Color = Color.Black
    Dim Server As String = "https://id-api.spooncast.net"
    Dim LType As String = "/lives/"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label6.Parent = PictureBox3
        Label7.Parent = PictureBox3
        Label8.Parent = PictureBox3
        Label9.Parent = PictureBox3
        Label10.Parent = PictureBox3
        Label11.Parent = PictureBox3
        Label11.Parent = PictureBox3
        PictureBox3.Parent = PictureBox1
        ComboBox1.SelectedIndex = 1
        ComboBox2.SelectedIndex = 1
        Impression.SelectedIndex = 0
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Dim STLhread As New Thread(AddressOf SendTapLove)

    Public Sub SendTapLove()
        CheckForIllegalCrossThreadCalls = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Button2.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button11.Enabled = False
        Button12.Enabled = False
        Button13.Enabled = False
        Button14.Enabled = False
        Button15.Enabled = False
        Dim CurTotal As Integer = 1
        For Each strtoken As String In ListBox1.Items
            Try
                Dim WC As New System.Net.WebClient
                WC.Headers.Add("user-agent", UserAgent)
                WC.Headers.Add("Authorization", "Token " & strtoken)

                Dim reqparam As New Specialized.NameValueCollection
                reqparam.Add("cv", "heimdallr")

                Dim responsebytesJOIN = WC.UploadValues(Server + LType + TextBox1.Text + "/join/", "POST", reqparam) '
                Dim responsebodyJOIN = (New Text.UTF8Encoding).GetString(responsebytesJOIN)

                Dim responsebytes = WC.UploadValues(Server + LType + TextBox1.Text + "/like/", "POST", reqparam) '
                Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)

                If (AutoLeaveCheck.Checked) Then
                    Thread.Sleep(10)
                    Dim responsebytesLeave = WC.UploadValues(Server + LType + TextBox1.Text + "/leave/", "POST", reqparam) '
                    Dim responsebodyLeave = (New Text.UTF8Encoding).GetString(responsebytesLeave)
                End If

                TextBox2.AppendText("SENDLOVE::SUCCESS [" & CurTotal & "]" & vbNewLine)
                Thread.Sleep(50)
                If (CurTotal Mod 50 = 0) Then
                    TextBox2.AppendText("SENDLOVE::REST FOR 3 SECONDS" & vbNewLine)
                    Thread.Sleep(3000)
                End If
                PBar.Increment(1)
                CurTotal += 1
            Catch ex As Exception
                TextBox2.AppendText("SENDLOVE::ERROR = " & " FAIL " & strtoken & ex.Message & vbNewLine)
            End Try
        Next
        STLhread = New Thread(AddressOf SendTapLove)
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button2.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True
        Button14.Enabled = True
        Button15.Enabled = True
        Button1.Text = "TAP LOVE"
        CheckForIllegalCrossThreadCalls = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("PLEASE INPUT LIVE ID", MsgBoxStyle.Critical, "NO LIVE ID PROVIDED")
        ElseIf ComboBox2.SelectedIndex = 2 Then
            MsgBox("TAPLOVE DOESNT SUPPORT FOR USER TYPE", MsgBoxStyle.Critical, "SEND TAP LOVE")
        ElseIf ListBox1.Items.Count > 0 Then
            If Button1.Text = "TAP LOVE" Then
                TextBox2.Clear()
                Button1.Text = "STOP"
                PBar.Maximum = ListBox1.Items.Count
                PBar.Value = 0
                STLhread.Start()
            Else
                STLhread.Abort()
                STLhread = New Thread(AddressOf SendTapLove)
                Button1.Text = "TAP LOVE"
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                Button2.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button7.Enabled = True
                Button8.Enabled = True
                Button9.Enabled = True
                Button10.Enabled = True
                Button11.Enabled = True
                Button12.Enabled = True
                Button13.Enabled = True
                Button14.Enabled = True
                Button15.Enabled = True
                PBar.Value = 0
            End If
        Else
            MsgBox("No BOT Provided", MsgBoxStyle.Critical, "SEND TAP LOVE")
        End If
    End Sub
    Dim STFThread As New Thread(AddressOf SendTapFans)

    Public Sub SendTapFans()
        CheckForIllegalCrossThreadCalls = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button11.Enabled = False
        Button12.Enabled = False
        Button13.Enabled = False
        Button14.Enabled = False
        Dim CurTotal As Integer = 1
        For Each strtoken As String In ListBox1.Items
            Try
                Dim WC As New System.Net.WebClient
                WC.Headers.Add("user-agent", UserAgent)
                WC.Headers.Add("Authorization", "Token " & strtoken)

                Dim reqparam As New Specialized.NameValueCollection
                reqparam.Add("cv", "heimdallr")
                Dim responsebytes = WC.UploadValues(Server + LType + TextBox1.Text + "/follow/", "POST", reqparam) '
                Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)
                TextBox2.AppendText("ADDFANS::SUCCESS [" & CurTotal & "]" & vbNewLine)
                PBar.Increment(1)
                CurTotal += 1
            Catch ex As Exception
                TextBox2.AppendText("ADDFANS::ERROR = " & " FAIL " & strtoken & ex.Message & vbNewLine)
            End Try
        Next
        STFThread = New Thread(AddressOf SendTapFans)
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True
        Button14.Enabled = True
        Button15.Text = "FANS"
        CheckForIllegalCrossThreadCalls = True
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If TextBox1.Text = "" Then
            MsgBox("PLEASE INPUT USER ID", MsgBoxStyle.Critical, "NO USER ID PROVIDED")
        ElseIf ComboBox2.SelectedIndex <> 2 Then
            MsgBox("PLEASE SELECT A CORRECT TYPE", MsgBoxStyle.Critical, "SPAM FANS")
        ElseIf ListBox1.Items.Count > 0 Then
            If Button15.Text = "FANS" Then
                TextBox2.Clear()
                Button15.Text = "STOP"
                PBar.Maximum = ListBox1.Items.Count
                PBar.Value = 0
                STFThread.Start()
            Else
                STFThread.Abort()
                STFThread = New Thread(AddressOf SendTapFans)
                Button15.Text = "FANS"
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                Button1.Enabled = True
                Button2.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button7.Enabled = True
                Button8.Enabled = True
                Button9.Enabled = True
                Button10.Enabled = True
                Button11.Enabled = True
                Button12.Enabled = True
                Button13.Enabled = True
                Button14.Enabled = True
                PBar.Value = 0
            End If
        Else
            MsgBox("No BOT Provided", MsgBoxStyle.Critical, "SPAM FANS")
        End If
    End Sub


    Dim GMAThread As New Thread(AddressOf GetMemberAuth)
    Public Sub GetMemberAuth()
        CheckForIllegalCrossThreadCalls = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Button1.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button12.Enabled = False
        Button13.Enabled = False
        Button14.Enabled = False
        Button15.Enabled = False
        For Each strtoken As String In ListBox4.Items
            Dim words As String() = strtoken.Split(New Char() {","c})

            Try
                Dim reqparam() As Byte
                Dim WC As New System.Net.WebClient
                WC.Headers.Add("user-agent", UserAgent)
                WC.Headers.Add("content-type", "application/json")
                Dim dictData As New Dictionary(Of String, Object)
                dictData.Add("sns_type", "phone")
                dictData.Add("sns_id", words(0))
                dictData.Add("password", words(1))
                reqparam = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented))

                Dim responsebytes = WC.UploadData(Server & "/signin/", "POST", reqparam)
                'Dim responsebytes = WC.UploadValues(Server + LType + TextBox1.Text, "POST", reqparam) '+ "/like/"
                Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)
                'TextBox2.Text = responsebody

                Dim jstr As String = responsebody
                Dim SpoonUserStruct As New SpoonUserStruct
                SpoonUserStruct = JsonConvert.DeserializeObject(Of SpoonUserStruct)(jstr)
                Dim Kambeng As String = SpoonUserStruct.status_code
                ' Dim mySpells = JsonHelper.ToClass(Of SpoonStruct)(jstr)
                ListBox2.Items.Add(SpoonUserStruct.results(0).id & "," & SpoonUserStruct.results(0).token & "," & SpoonUserStruct.results(0).nickname)
                ListBox1.Items.Add(SpoonUserStruct.results(0).token)
                PBar.Increment(1)
                'ListBox3.Items.Add(SpoonUserStruct.results(0).token)
                Label15.Text = "Total Bot's : " & Convert.ToString(ListBox1.Items.Count)
            Catch ex As Exception
                TextBox2.AppendText("BOTADD::ERROR = [" & words(0) & "] " & ex.Message & " FAIL " & vbNewLine)
            End Try

        Next
        GMAThread = New Thread(AddressOf GetMemberAuth)
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True
        Button14.Enabled = True
        Button15.Enabled = True
        Button11.Text = "GET ID"
        CheckForIllegalCrossThreadCalls = True
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ListBox2.Items.Clear()
        If ListBox4.Items.Count > 0 Then
            If Button11.Text = "GET ID" Then
                TextBox2.Clear()
                Button11.Text = "STOP"
                PBar.Maximum = ListBox4.Items.Count
                ListBox1.Items.Clear()
                ListBox2.Items.Clear()
                TextBox2.Clear()

                GMAThread.Start()
            Else
                GMAThread.Abort()
                GMAThread = New Thread(AddressOf GetMemberAuth)
                Button11.Text = "GET ID"
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                Button1.Enabled = True
                Button2.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button7.Enabled = True
                Button8.Enabled = True
                Button9.Enabled = True
                Button10.Enabled = True
                Button12.Enabled = True
                Button13.Enabled = True
                Button14.Enabled = True
                Button15.Enabled = True
                PBar.Value = 0
            End If
        Else
            MsgBox("No BOT Provided", MsgBoxStyle.Critical, "GET MEMBER AUTH")
        End If
    End Sub
    Dim SReportThread As New Thread(AddressOf SpamReportHere)

    Public Sub SpamReportHere()
        CheckForIllegalCrossThreadCalls = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Button1.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button8.Enabled = False
        Button7.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button11.Enabled = False
        Button12.Enabled = False
        Button13.Enabled = False
        Button14.Enabled = False
        Button15.Enabled = False
        Button15.Enabled = False
        Dim CurTotal As Integer = 1
        For Each strtoken As String In ListBox1.Items
            Try
                Dim reqparam() As Byte
                Dim WC As New System.Net.WebClient

                WC.Headers.Add("user-agent", UserAgent)
                WC.Headers.Add("Authorization", "Token " & strtoken)
                WC.Headers.Add("content-type", "application/json;charset=utf-8")
                Dim dictData As New Dictionary(Of String, Object)
                dictData.Add("report_type", "1")
                reqparam = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented))


                ''JoinLeave
                Dim WCJL As New System.Net.WebClient
                WCJL.Headers.Add("user-agent", UserAgent)
                WCJL.Headers.Add("Authorization", "Token " & strtoken)
                Dim WCJLParam As New Specialized.NameValueCollection
                WCJLParam.Add("cv", "heimdallr")

                Dim responsebytesJoin = WCJL.UploadValues(Server + LType + TextBox1.Text + "/join/", "POST", WCJLParam) '
                Dim responsebodyJoin = (New Text.UTF8Encoding).GetString(responsebytesJoin)

                Dim responsebytes = WC.UploadData(Server + LType + TextBox1.Text + "/report/", "POST", reqparam) '
                Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)

                Thread.Sleep(10)
                Dim responsebytesLeave = WCJL.UploadValues(Server + LType + TextBox1.Text + "/leave/", "POST", WCJLParam) '
                Dim responsebodyLeave = (New Text.UTF8Encoding).GetString(responsebytesLeave)

                TextBox2.AppendText("SPAMREPORT::SUCCESS [" & CurTotal & "]" & vbNewLine)
                If (CurTotal Mod 50 = 0) Then
                    TextBox2.AppendText("SPAMREPORT::REST FOR 3 SECONDS" & vbNewLine)
                    Thread.Sleep(3000)
                End If
                PBar.Increment(1)
                CurTotal += 1
            Catch ex As Exception
                TextBox2.AppendText("SPAMREPORT::ERROR = " & " FAIL " & strtoken & ex.Message & vbNewLine)
            End Try
        Next
        SReportThread = New Thread(AddressOf SpamReportHere)
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button1.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True
        Button14.Enabled = True
        Button15.Enabled = True
        Button2.Text = "REPORT"
        CheckForIllegalCrossThreadCalls = True
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("PLEASE INPUT LIVE ID", MsgBoxStyle.Critical, "NO LIVE ID PROVIDED")
            ''ElseIf ComboBox2.SelectedIndex = 2 Then
            ''  MsgBox("TAPLOVE DOESNT SUPPORT FOR USER TYPE", MsgBoxStyle.Critical, "SEND TAP LOVE")
        ElseIf ListBox1.Items.Count > 0 Then
            If Button2.Text = "REPORT" Then
                TextBox2.Clear()
                Button2.Text = "STOP"
                PBar.Maximum = ListBox1.Items.Count
                PBar.Value = 0
                SReportThread.Start()
            Else
                SReportThread.Abort()
                SReportThread = New Thread(AddressOf SpamReportHere)
                Button2.Text = "REPORT"
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                Button1.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button7.Enabled = True
                Button8.Enabled = True
                Button9.Enabled = True
                Button10.Enabled = True
                Button11.Enabled = True
                Button12.Enabled = True
                Button13.Enabled = True
                Button14.Enabled = True
                Button15.Enabled = True
                PBar.Value = 0
            End If
        Else
            MsgBox("No BOT Provided", MsgBoxStyle.Critical, "SEND TAP LOVE")
        End If
        'MsgBox("Currently Disabled due too much Toxic People", MsgBoxStyle.Critical, "About")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim userMsg As String
        userMsg = InputBox("Format Input : AuthorizationID Token", "Add New BOT", "AuthorizationID")
        If userMsg <> "" Then
            MsgBox("Bot Successfully Add", MsgBoxStyle.Information, "Add BOT Success")
            ListBox1.Items.Add(userMsg)
            Label15.Text = "Total Bot's : " & Convert.ToString(ListBox1.Items.Count)
        Else
            MsgBox("Wrong Auth ID", MsgBoxStyle.Critical, "Add BOT Failure")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (ListBox1.SelectedItem Is Nothing) Then
            MsgBox("Please Select BOT !", MsgBoxStyle.Exclamation, "Failure to Remove BOT")
        Else
            If (MessageBox.Show("Are You Sure Want To Remove Selected BOT ?", "Remove BOT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            End If
            Label15.Text = "Total Bot's : " & Convert.ToString(ListBox1.Items.Count)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox1.Text = "" Then
            MsgBox("PLEASE INPUT LIVE / CAST / USER ID", MsgBoxStyle.Critical, "CHECKER::NOIDPROVIDED")
        Else
            Try
                Dim WC As New System.Net.WebClient
                WC.Headers.Add("user-agent", UserAgent)

                Dim reqparam As New Specialized.NameValueCollection
                reqparam.Add("cv", "heimdallr")
                Dim responsebytes = WC.UploadValues(Server + LType + TextBox1.Text, "POST", reqparam) '+ "/like/"
                Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)
                'TextBox2.Text = responsebody

                Dim jstr As String = responsebody
                ' Dim mySpells = JsonHelper.ToClass(Of SpoonStruct)(jstr)
                Dim Info1, Info2, Info3, Info4, Info5, Info6, Info7, Info8, Info9 As String
                If ComboBox2.SelectedIndex = 0 Then
                    Dim SpoonCastStrut As New SpoonCastStrut
                    SpoonCastStrut = JsonConvert.DeserializeObject(Of SpoonCastStrut)(jstr)
                    Dim Kambeng As String = SpoonCastStrut.status_code
                    Dim IsStaff As String = "User"
                    If SpoonCastStrut.results(0).author.is_staff Then
                        IsStaff = "Staff"
                    End If
                    Info1 = SpoonCastStrut.results(0).author.nickname
                    Info2 = "UserID" & SpoonCastStrut.results(0).id & " (" & SpoonCastStrut.results(0).author.tag & ") [" & IsStaff & "]"
                    Info3 = SpoonCastStrut.results(0).title
                    Info4 = "Total Play : " & SpoonCastStrut.results(0).play_count
                    Info5 = "Total Like : " & SpoonCastStrut.results(0).like_count
                    Info6 = "Total Spoon Received : " & SpoonCastStrut.results(0).spoon_count
                    Info7 = SpoonCastStrut.results(0).img_url
                    Info8 = SpoonCastStrut.results(0).author.profile_url
                    Info9 = SpoonCastStrut.results(0).voice_url
                ElseIf ComboBox2.SelectedIndex = 1 Then
                    Dim SpoonStruct As New SpoonStruct
                    SpoonStruct = JsonConvert.DeserializeObject(Of SpoonStruct)(jstr)
                    Dim Kambeng As String = SpoonStruct.status_code
                    Info1 = SpoonStruct.results(0).author.nickname
                    Info2 = SpoonStruct.results(0).title
                    Info3 = SpoonStruct.results(0).welcome_message
                    Info4 = "Followers : " & SpoonStruct.results(0).author.follower_count
                    Info5 = "Following : " & SpoonStruct.results(0).author.following_count
                    Info6 = "Join Date : " & SpoonStruct.results(0).author.date_joined
                    Info7 = SpoonStruct.results(0).img_url
                    Info8 = SpoonStruct.results(0).author.profile_url
                    Info9 = SpoonStruct.results(0).img_url
                ElseIf ComboBox2.SelectedIndex = 2 Then
                    Dim SpoonUserStruct As New SpoonUserStruct
                    SpoonUserStruct = JsonConvert.DeserializeObject(Of SpoonUserStruct)(jstr)
                    Dim Kambeng As String = SpoonUserStruct.status_code
                    Dim IsStaff As String = "User"
                    If SpoonUserStruct.results(0).is_staff Then
                        IsStaff = "Staff"
                    End If
                    Info1 = SpoonUserStruct.results(0).nickname
                    Info2 = "UserID" & SpoonUserStruct.results(0).id & " (" & SpoonUserStruct.results(0).tag & ") [" & IsStaff & "]"
                    Info3 = SpoonUserStruct.results(0).description
                    Info4 = "Followers : " & SpoonUserStruct.results(0).follower_count
                    Info5 = "Following : " & SpoonUserStruct.results(0).following_count
                    Info6 = "Join Date : " & SpoonUserStruct.results(0).date_joined
                    Info7 = SpoonUserStruct.results(0).profile_url
                    Info8 = SpoonUserStruct.results(0).profile_url
                    Info9 = SpoonUserStruct.results(0).profile_url
                End If
                Label6.Text = Info1
                Label7.Text = Info2
                Label8.Text = Info3
                Label9.Text = Info4
                Label10.Text = Info5
                Label11.Text = Info6
                PictureBox1.Load(Info7)
                PictureBox2.Load(Info8)
                TextBox3.Text = (Info9)

            Catch ex As Exception
                TextBox2.AppendText("CHECKER::ERROR = " & ex.Message & " FAIL " & vbNewLine)
            End Try
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim openfile = New OpenFileDialog()
        openfile.Title = "Open BOT List"
        openfile.Filter = "Text (*.txt)|*.txt"
        If (openfile.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            Dim myfile As String = openfile.FileName
            Dim allLines As String() = File.ReadAllLines(myfile)

            ListBox1.Items.Clear()
            For Each line As String In allLines
                ListBox1.Items.Add(line)
            Next
            Label15.Text = "Total Bot's : " & Convert.ToString(ListBox1.Items.Count)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ListBox1.Items.Clear()

        Label15.Text = "Total Bot's : " & Convert.ToString(ListBox1.Items.Count)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If ListBox1.Items.Count > 0 Then
            Dim SetSave As SaveFileDialog = New SaveFileDialog
            Dim i As Integer
            SetSave.Title = "Save BOT List"
            SetSave.Filter = "Text (*.txt)|*.txt"

            If SetSave.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As New IO.StreamWriter(SetSave.FileName, True)
                For i = 0 To ListBox1.Items.Count - 1
                    s.WriteLine(ListBox1.Items.Item(i))
                Next
                s.Close()
            End If

        Else
            MsgBox("Nothing to Save", MsgBoxStyle.Exclamation, "SAVE BOT Failure")
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        If ListBox1.Items.Count > 0 Then
            Button5.Enabled = True
            Button6.Enabled = True
        Else
            Button5.Enabled = False
            Button6.Enabled = False
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (ListBox1.SelectedItem Is Nothing) Then
            MsgBox("Please Select BOT!", MsgBoxStyle.Exclamation, "Failure to Edit BOT")
        Else
            Dim userMsg As String
            userMsg = InputBox("Format Input : AuthorizationID Token", "Add New BOT", ListBox1.Items(ListBox1.SelectedIndex))
            If userMsg <> "" Then
                MsgBox("User Successfully Changed", MsgBoxStyle.Information, "Edit BOT Success")
                ListBox1.Items(ListBox1.SelectedIndex) = userMsg
                Button6.Enabled = False
            Else
                MsgBox("Wrong Auth ID", MsgBoxStyle.Critical, "Edit BOT Failure")
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            Server = "https://api.spooncast.net"
        ElseIf ComboBox1.SelectedIndex = 1 Then
            Server = "https://id-api.spooncast.net"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            Server = "https://jp-api.spooncast.net"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            Server = "https://vn-api.spooncast.net"
        ElseIf ComboBox1.SelectedIndex = 4 Then
            Server = "https://ar-api.spooncast.net"
        ElseIf ComboBox1.SelectedIndex = 5 Then
            Server = "https://us-api.spooncast.net"
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex = 0 Then
            LType = "/casts/"
        ElseIf ComboBox2.SelectedIndex = 1 Then
            LType = "/lives/"
        ElseIf ComboBox2.SelectedIndex = 2 Then
            LType = "/users/"
        End If
    End Sub


    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim openfile = New OpenFileDialog()
        openfile.Title = "Open BOT List"
        openfile.Filter = "Text (*.txt)|*.txt"
        If (openfile.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            Dim myfile As String = openfile.FileName
            Dim allLines As String() = File.ReadAllLines(myfile)

            ListBox4.Items.Clear()
            ListBox2.Items.Clear()

            For Each line As String In allLines
                ListBox4.Items.Add(line)
            Next
        End If
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
    Dim CUSThread As New Thread(AddressOf ChangeUserInfo)
    Public Sub ChangeUserInfo()
        CheckForIllegalCrossThreadCalls = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button11.Enabled = False
        Button12.Enabled = False
        Button14.Enabled = False
        Button15.Enabled = False
        BotChangerAdd.Enabled = False
        BotChangerDelete.Enabled = False
        BotChangerLoad.Enabled = False
        BotChangerEdit.Enabled = False
        BotCounter.Enabled = False
        BotChangePWCheck.Enabled = False
        BotAddNumberCheck.Enabled = False
        BotNewPassword.Enabled = False
        BotNamer.Enabled = False
        Dim Brebek As Integer = 1
        Dim PictsOfBOT() As String = {"bg/1.png"}
        For Each strtoken As String In ListBox2.Items
            Dim words As String() = strtoken.Split(New Char() {","c})

            Try
                Dim reqparam() As Byte
                Dim WC As New System.Net.WebClient
                WC.Headers.Add("user-agent", UserAgent)
                WC.Headers.Add("Authorization", "Token " & words(1))
                WC.Headers.Add("content-type", "application/json;charset=utf-8")
                Dim CHangeType As String = "/users/"
                Dim dictData As New Dictionary(Of String, Object)
                If (BotChangePWCheck.Checked) Then
                    dictData.Add("new_password", BotNewPassword.Text)
                    CHangeType = "/password/"
                Else
                    If (BotChangePictCheck.Checked) Then
                        dictData.Add("profile_key", BotNewPict.Text)
                    End If
                    If (BotAddNumberCheck.Checked) Then
                        dictData.Add("nickname", BotNamer.Text & " " & BotCounter.Value)
                        BotCounter.Value += 1

                    End If
                    CHangeType = "/users/" & words(0)
                End If
                reqparam = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented))
                Dim responsebytes = WC.UploadData(Server & CHangeType & "/", "PUT", reqparam)
                'Dim responsebytes = WC.UploadValues(Server + LType + TextBox1.Text, "POST", reqparam) '+ "/like/"
                Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)
                'TextBox2.Text = responsebody
                TextBox2.AppendText("BOTCHANGER::SUCCESS " & words(0) & " [" & Brebek & "]" & vbNewLine)
                Brebek += 1
                Dim jstr As String = responsebody
            Catch ex As Exception
                TextBox2.AppendText("BOTCHANGER::ERROR = " & words(0) & " " & ex.Message & " FAIL " & vbNewLine)
            End Try

        Next
        CUSThread = New Thread(AddressOf ChangeUserInfo)
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        Button14.Enabled = True
        Button15.Enabled = True
        BotChangerAdd.Enabled = True
        BotChangerDelete.Enabled = True
        BotChangerLoad.Enabled = True
        BotChangerEdit.Enabled = True
        BotCounter.Enabled = True
        BotChangePWCheck.Enabled = True
        BotAddNumberCheck.Enabled = True
        BotNewPassword.Enabled = True
        BotNamer.Enabled = True
        Button13.Text = "UPDATE USER"
        CheckForIllegalCrossThreadCalls = True
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If ListBox2.Items.Count > 0 Then
            If Button13.Text = "UPDATE USER" Then
                TextBox2.Clear()
                Button13.Text = "STOP"
                PBar.Maximum = ListBox2.Items.Count
                CUSThread.Start()
            Else
                CUSThread.Abort()
                CUSThread = New Thread(AddressOf ChangeUserInfo)
                Button13.Text = "UPDATE USER"
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                Button1.Enabled = True
                Button2.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button7.Enabled = True
                Button8.Enabled = True
                Button9.Enabled = True
                Button10.Enabled = True
                Button11.Enabled = True
                Button12.Enabled = True
                Button14.Enabled = True
                Button15.Enabled = True
                BotChangerAdd.Enabled = True
                BotChangerDelete.Enabled = True
                BotChangerLoad.Enabled = True
                BotChangerEdit.Enabled = True
                BotCounter.Enabled = True
                BotChangePWCheck.Enabled = True
                BotAddNumberCheck.Enabled = True
                BotNewPassword.Enabled = True
                BotNamer.Enabled = True
                PBar.Value = 0
            End If
        Else
            MsgBox("No BOT Provided", MsgBoxStyle.Critical, "BOTCHANGER")
        End If
    End Sub

    Private Sub ListBox1_DataSourceChanged(sender As Object, e As EventArgs) Handles ListBox1.DataSourceChanged
        Label15.Text = "Total Bot's : " & Convert.ToString(ListBox1.Items.Count)
    End Sub

    Private Sub ListBox1_DisplayMemberChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If ListBox2.Items.Count > 0 Then
            Dim SetSave As SaveFileDialog = New SaveFileDialog
            Dim i As Integer
            SetSave.Title = "Save BOT ID AND AUTH List"
            SetSave.Filter = "Text (*.txt)|*.txt"

            If SetSave.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As New IO.StreamWriter(SetSave.FileName, True)
                For i = 0 To ListBox2.Items.Count - 1
                    s.WriteLine(ListBox2.Items.Item(i))
                Next
                s.Close()
            End If

        Else
            MsgBox("Nothing to Save", MsgBoxStyle.Exclamation, "SAVE USERID Failure")
        End If
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub BotNewPassword_Click(sender As Object, e As EventArgs) Handles BotNewPassword.Click
        BotNewPassword.Text = ""
    End Sub


    Private Sub BotChangerAdd_Click(sender As Object, e As EventArgs) Handles BotChangerAdd.Click
        Dim userMsg As String
        userMsg = InputBox("Format Input : IDUser,AuthorizationID Token", "BOTChanger:ADD", "IDUser,AuthorizationID")
        If userMsg <> "" Then
            MsgBox("Bot Successfully Add", MsgBoxStyle.Information, "BOTChanger::Add BOT Success")
            ListBox2.Items.Add(userMsg)
        Else
            MsgBox("Wrong Input", MsgBoxStyle.Critical, "BOTChanger::Add BOT Failure")
        End If
    End Sub

    Private Sub BotChangerDelete_Click(sender As Object, e As EventArgs) Handles BotChangerDelete.Click
        If (ListBox2.SelectedItem Is Nothing) Then
            MsgBox("Please Select BOT before Remove", MsgBoxStyle.Exclamation, "BOTChanger::Fail to Remove")
        Else
            If (MessageBox.Show("Are You Sure Want To Remove Selected BOT ?", "BOTChanger::RemoveBOT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
                BotChangerDelete.Enabled = False
            End If
        End If
    End Sub

    Private Sub BotChangerLoad_Click(sender As Object, e As EventArgs) Handles BotChangerLoad.Click
        Dim openfile = New OpenFileDialog()
        openfile.Title = "BOTChanger::Open BOT List (Format UserID,AuthIDToken)"
        openfile.Filter = "Text (*.txt)|*.txt"
        If (openfile.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            Dim myfile As String = openfile.FileName
            Dim allLines As String() = File.ReadAllLines(myfile)
            ListBox2.Items.Clear()
            For Each line As String In allLines
                ListBox2.Items.Add(line)
            Next
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.Items.Count > 0 Then
            BotChangerEdit.Enabled = True
            BotChangerDelete.Enabled = True
        Else
            BotChangerEdit.Enabled = False
            BotChangerDelete.Enabled = False
        End If
    End Sub

    Private Sub BotChangerEdit_Click(sender As Object, e As EventArgs) Handles BotChangerEdit.Click
        If (ListBox2.SelectedItem Is Nothing) Then
            MsgBox("Please Select BOT!", MsgBoxStyle.Exclamation, "Failure to Edit BOT")
        Else
            Dim userMsg As String
            userMsg = InputBox("Format Input : IDUser,AuthorizationID Token", "BOTChanger::EDIT", ListBox2.Items(ListBox2.SelectedIndex))
            If userMsg <> "" Then
                MsgBox("User Successfully Changed", MsgBoxStyle.Information, "Edit BOT Success")
                ListBox2.Items(ListBox2.SelectedIndex) = userMsg
                BotChangerEdit.Enabled = False
            Else
                MsgBox("Wrong Auth ID", MsgBoxStyle.Critical, "Edit BOT Failure")
            End If
        End If

    End Sub
    Dim SListThread As New Thread(AddressOf SpamListenerHere)

    Public Sub SpamListenerHere()
        CheckForIllegalCrossThreadCalls = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button8.Enabled = False
        Button7.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button11.Enabled = False
        Button12.Enabled = False
        Button13.Enabled = False
        Button14.Enabled = False
        Button15.Enabled = False
        Button15.Enabled = False
        Dim CurTotal As Integer = 1

        For Value As Integer = 1 To numListener.Value
            Try
                Dim WC As New System.Net.WebClient
                WC.Headers.Add("user-agent", UserAgent)

                Dim reqparam As New Specialized.NameValueCollection
                'reqparam.Add("cv", "heimdallr")
                Dim responsebytes = WC.UploadValues(Server + LType + TextBox1.Text + "/play/", "POST", reqparam) '+ "/like/"
                Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)
                'TextBox2.Text = responsebody

                Dim jstr As String = responsebody
                TextBox2.AppendText("LISTENER::SUCCESS [" & CurTotal & "]" & vbNewLine)
                CurTotal += 1
            Catch ex As Exception
                TextBox2.AppendText("LISTENER::ERROR = " & " FAIL " & ex.Message & vbNewLine)
            End Try
        Next
        SListThread = New Thread(AddressOf SpamListenerHere)
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True
        Button14.Enabled = True
        Button15.Enabled = True
        btnListener.Text = "LISTENER"
        CheckForIllegalCrossThreadCalls = True
    End Sub

    Private Sub btnListener_Click(sender As Object, e As EventArgs) Handles btnListener.Click
        If TextBox1.Text = "" Then
            MsgBox("PLEASE INPUT CAST ID", MsgBoxStyle.Critical, "LISTENER::NO CAST ID PROVIDED")
        ElseIf ComboBox2.SelectedIndex <> 0 Then
            MsgBox("PLEASE SELECT A CORRECT TYPE", MsgBoxStyle.Critical, "LISTENER::INCORRECT TYPE")
        ElseIf numListener.Value > 0 Then
            If btnListener.Text = "LISTENER" Then
                TextBox2.Clear()
                btnListener.Text = "STOP"
                PBar.Maximum = numListener.Value
                PBar.Value = 0
                SListThread.Start()
            Else
                SListThread.Abort()
                SListThread = New Thread(AddressOf SpamListenerHere)
                btnListener.Text = "LISTENER"
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                Button1.Enabled = True
                Button2.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button7.Enabled = True
                Button8.Enabled = True
                Button9.Enabled = True
                Button10.Enabled = True
                Button11.Enabled = True
                Button12.Enabled = True
                Button13.Enabled = True
                Button14.Enabled = True
                Button15.Enabled = True
                PBar.Value = 0
            End If
        Else
            MsgBox("Minimum Value is 1 !", MsgBoxStyle.Critical, "LISTENER::INVALID VALUE")
        End If
    End Sub

    Private Sub BotAddNumberCheck_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox2.Clear()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Dim SIThread As New Thread(AddressOf SendImpression)

    Public Sub SendImpression()
        CheckForIllegalCrossThreadCalls = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
        Button11.Enabled = False
        Button12.Enabled = False
        Button13.Enabled = False
        Button14.Enabled = False
        Button15.Enabled = False
        Dim CurTotal As Integer = 1
        For Each strtoken As String In ListBox1.Items
            Try
                Dim reqparam() As Byte
                Dim WC As New System.Net.WebClient
                WC.Headers.Add("user-agent", UserAgent)
                WC.Headers.Add("Authorization", "Token " & strtoken)
                WC.Headers.Add("content-type", "application/json;charset=utf-8")

                Dim dictData As New Dictionary(Of String, Object)
                dictData.Add("new_impression_ids", Impression.SelectedIndex + 1) ' Not Start from 0
                reqparam = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented))
                Dim responsebytes = WC.UploadData(Server + LType + TextBox1.Text + "/impression/", "POST", reqparam) '
                Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)
                TextBox2.AppendText("IMPRESSION::SUCCESS [" & CurTotal & "]" & vbNewLine)
                PBar.Increment(1)
                CurTotal += 1
            Catch ex As Exception
                TextBox2.AppendText("IMPRESSION::ERROR = " & " FAIL " & strtoken & ex.Message & vbNewLine)
            End Try
        Next
        SIThread = New Thread(AddressOf SendImpression)
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True
        Button14.Enabled = True
        Button15.Enabled = True
        Button16.Text = "Set"
        CheckForIllegalCrossThreadCalls = True
    End Sub


    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If TextBox1.Text = "" Then
            MsgBox("PLEASE INPUT USER ID", MsgBoxStyle.Critical, "NO USER ID PROVIDED")
        ElseIf ComboBox2.SelectedIndex <> 2 Then
            MsgBox("PLEASE SELECT A CORRECT TYPE", MsgBoxStyle.Critical, "SPAM FANS")
        ElseIf ListBox1.Items.Count > 0 Then
            If Button16.Text = "Set" Then
                TextBox2.Clear()
                Button16.Text = "Stop"
                PBar.Maximum = ListBox1.Items.Count
                PBar.Value = 0
                SIThread.Start()
            Else
                SIThread.Abort()
                SIThread = New Thread(AddressOf SendImpression)
                Button16.Text = "Set"
                ComboBox1.Enabled = True
                ComboBox2.Enabled = True
                Button1.Enabled = True
                Button2.Enabled = True
                Button4.Enabled = True
                Button5.Enabled = True
                Button7.Enabled = True
                Button8.Enabled = True
                Button9.Enabled = True
                Button10.Enabled = True
                Button11.Enabled = True
                Button12.Enabled = True
                Button13.Enabled = True
                Button14.Enabled = True
                Button15.Enabled = True
                PBar.Value = 0
            End If
        Else
            MsgBox("No BOT Provided", MsgBoxStyle.Critical, "SPAM FANS")
        End If
    End Sub
End Class
