Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim tdy As DateTime
    Dim thistime As String
    Dim TimeWrong As Boolean
    Dim DateWrong As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If tdy = Nothing Then
                tdy = Now()
                'TextBox1.Text = tdy
                txttdy.Text = _dateConvertor(tdy.Date, DateWrong)
                txttdytod.Text = _timeConvertor((tdy.TimeOfDay.ToString), thistime, FmtWrong, TimeWrong)
                txtMgrNotifyDt.Text = txttdy.Text + " " + txttdytod.Text
            End If
        End If
    End Sub

    Protected Sub TimeValidator()
        Dim mytdy, mytod, thistod3, mytod3, thistdy, thistod As String
        Dim Future As Boolean = False
        userMessage = ""
        Master._printMessage(userMessage, False)
        'cvldTime.Enabled = False
        Try
            Me.txttemptod.Text = _timeConvertor(txtTOD.Text, thistime, FmtWrong, TimeWrong)
            mytdy = _dateConvertor(Format(Now(), "short Date"), DateWrong)
            mytod = (Format(Now(), "hh:mm"))
            mytod = _timeConvertor(mytod, thistime, FmtWrong, TimeWrong)

            txttdy.Text = mytdy
            thistdy = _dateConvertor(Me.txtDOS.Text, DateWrong)
            thistod = txttemptod.Text
            thistod = _timeConvertor(thistod, thistime, FmtWrong, TimeWrong)
            Dim thistod2 As DateTime = CDate(txttemptod.Text)
            Dim mytod2 As DateTime = CDate(Now())
            thistod3 = Format(thistod2, "HH:mm")
            mytod3 = Format(mytod2, "HH:mm")

            txtTOD.Text = txttemptod.Text
            TimeWrong = False
            Dim a, b As Date
            a = CDate(txtDOS.Text)
            b = CDate(txttdy.Text)
            If b < a Then
                Future = True
                TimeWrong = True
                ' ElseIf thistdy = mytdy Then
            ElseIf a = b Then
                If thistod3 > mytod3 Then
                    Future = True
                    TimeWrong = True
                End If
            ElseIf b > a Then
                TimeWrong = False
            End If
        Catch ex As Exception
            If HidTimeFMTWrong.Value = "True" Or txtDOS.Text = "__/__/____" Then
                userMessage = "Time is invalid, please put in hh:mm format."
                Master._printMessage(userMessage, True, True)
                HidTimeFMTWrong.Value = "False"
                MEtime.Enabled = True
                Exit Sub
            End If
        End Try

        If HidTimeFMTWrong.Value = "True" Or txtDOS.Text = "__/__/____" Then
            If Future = True Then
                userMessage = "Time is in the future, please re-enter time or change the date."
            Else
                userMessage = "Time is invalid, please put in hh:mm format."
            End If
            Master._printMessage(userMessage, True, True)
            HidTimeFMTWrong.Value = "False"
            MEtime.Enabled = True
            Exit Sub
        End If

    End Sub

    Public Sub CheckDates()

        Dim tdy As DateTime
        If txttdy.Text = Nothing Or txttdytod.Text = Nothing Then
            tdy = Now()
            'TextBox1.Text = tdy
            txttdy.Text = _dateConvertor(tdy.Date, DateWrong)
            txttdytod.Text = _timeConvertor((tdy.TimeOfDay.ToString), thistime, FmtWrong, TimeWrong)
            txtMgrNotifyDt.Text = txttdy.Text + " " + txttdytod.Text
        End If
        txtDOS.Text = _dateConvertor(txtDOS.Text, DateWrong)
        txttdy.Text = _dateConvertor(txttdy.Text, DateWrong)
        tdy = txtDOS.Text
        'removed this code in place of checkdates on 1/09/09
        If CDate(txttdy.Text) < CDate(txtDOS.Text) Then
            causeexit = True
            userMessage = "Date cannot be in the future. Please re-enter date."
            Master._printMessage(userMessage, True, True)
            Exit Sub
        ElseIf txttdy.Text = txtDOS.Text Then
            If txtTOD.Text <> Nothing And txtTOD.Text <> " " And txtTOD.Text <> "00:00 AM" And txtTOD.Text <> "00:00 PM" And txtTOD.Text <> "__:__ AM" Then

                If txttdytod.Text < txtTOD.Text Then
                    causeexit = True
                    userMessage = "Time cannot be in the future for today. Please re-enter date or time."
                    Master._printMessage(userMessage, True, True)
                    Exit Sub
                End If
                'cvldDate.Enabled = True
                Dim a, b As Date
                a = CDate(txtDOS.Text)
                b = CDate(txttdy.Text)
                If b <= a Then
                    If txttdytod.Text < txtTOD.Text Then
                        CompareValidator1.Enabled = True
                        Session("TimeWrong") = True
                    End If
                Else
                    CompareValidator1.Enabled = False
                End If
                TimeValidator()
                If Session("TimeFMTWrong") = True Then
                    userMessage = "Time is invalid, please put in hh:mm format, using a valid time."
                    Master._printMessage(userMessage, True, True)
                    Session("TimeFMTWrong") = Nothing
                    Exit Sub
                End If
                If Session("TimeWrong") = True Then
                    userMessage = "You cannot enter future times.  Please enter a valid time and/or change the date."
                    Master._printMessage(userMessage, True, True)
                    '  Me.txtTOD.Text = Nothing
                    Me.txtTOD.Focus()
                    Session("TimeWrong") = Nothing
                End If
            Else
                userMessage = "Time is invalid, please put in hh:mm format, using a valid time."
                Master._printMessage(userMessage, True, True)
                Session("TimeFMTWrong") = Nothing
                txtTOD.Text = Nothing
                Exit Sub
            End If
        ElseIf txttdy.Text >= txtDOS.Text Then
            If txtTOD.Text = Nothing Or txtTOD.Text = " " Or txtTOD.Text = "00:00 AM" Or txtTOD.Text = "00:00 PM" Or txtTOD.Text = "__:__ AM" Then
                userMessage = "Time is invalid, please put in hh:mm format, using a valid time."
                Master._printMessage(userMessage, True, True)
                txtTOD.Text = Nothing
                Session("TimeFMTWrong") = Nothing
                Exit Sub
            End If
        End If
    End Sub

    Public Sub SaveRecord()
        tdy = Now()
        If txttdy.Text = Nothing Or txttdytod.Text = Nothing Then
            tdy = Now()
            txttdy.Text = _dateConvertor(tdy.Date, DateWrong)
            txttdytod.Text = _timeConvertor((tdy.TimeOfDay.ToString), thistime, FmtWrong, TimeWrong)
            txtMgrNotifyDt.Text = txttdy.Text + " " + txttdytod.Text
        End If
        CheckDates()

        If txttdy.Text = Nothing Or _
    txtTOD.Text = Nothing Or _
    txtManager.Text = Nothing Or _
    txtAnyCheck.Text = Nothing Then
            causeexit = True
            If causeexit = True Then
                userMessage = "You are missing required information, please check asterisk(s) for missing data."
                Master._printMessage(userMessage, True)
                ' ASPNET_MsgBox(userMessage)
                Exit Sub

            End If
        End If

        'Taken some liberties here to help you out...
        Dim Dosdate As DateTime 'Date you will actually save
        Dosdate = CDate(txtDOS.Text + " " + txtTOD.Text)
    End Sub

    Protected Sub txtDOS_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDOS.TextChanged
        'Dim mydt As Date
        ' mydt = CDate(txtDOS.Text)
        userMessage = ""
        Master._printMessage(userMessage, False)
        If txtDOS.Text <> "__/__/____" And txtDOS.Text <> "" Then
            txtDOS2.Text = txtDOS.Text
            MaskedEditExtender1.Enabled = False
            lblDoi.Visible = False
        Else
            txtDOS2.Text = Nothing
            lblDoi.Visible = True
        End If
        txtDOS.Text = _dateConvertor(txtDOS.Text, DateWrong)
        If txtDOS.Text = Nothing Then
            userMessage = "Please enter a valid date using this format mm/dd/yyyy."
            Master._printMessage(userMessage, True, True)
            Me.txtDOS.Text = ""
            DateWrong = Nothing
            Exit Sub
        End If
        If tdy = Nothing Then
            tdy = Now()
            txttdy.Text = _dateConvertor(tdy.Date, DateWrong)
            txttdytod.Text = _timeConvertor((tdy.TimeOfDay.ToString), thistime, FmtWrong, TimeWrong)
        End If
        If CDate(txttdy.Text) < CDate(txtDOS.Text) Then
            DateWrong = True
            userMessage = "Date cannot be in the future. Please re-enter date."
            Master._printMessage(userMessage, True, True)
            Me.txtDOS.Text = ""
            MaskedEditExtender1.Enabled = True
            DateWrong = Nothing
        End If

        'Dim isvalid1 As Boolean
        'isvalid1 = _dateValidation(txtDOS)

    End Sub

    Protected Sub txtTOD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTOD.TextChanged
        If tdy = Nothing Then
            tdy = Now()
            'TextBox1.Text = tdy
            txttdy.Text = _dateConvertor(tdy.Date, DateWrong)
            txttdytod.Text = _timeConvertor((tdy.TimeOfDay.ToString), thistime, FmtWrong, TimeWrong)
            txtMgrNotifyDt.Text = txttdy.Text + " " + txttdytod.Text
        End If
        If txtTOD.Text <> Nothing And txtTOD.Text <> " " And txtTOD.Text <> "00:00 AM" And txtTOD.Text <> "00:00 PM" And txtTOD.Text <> "__:__ AM" Then
            txtTOD.Text = _timeConvertor(txtTOD.Text, thistime, FmtWrong, TimeWrong)
            TimeValidator()

            If HidTimeFMTWrong.Value = "True" Then
                userMessage = "Time is invalid, please put in hh:mm format."
                Master._printMessage(userMessage, True, True)
                HidTimeFMTWrong.Value = Nothing
                MEtime.Enabled = True
                Exit Sub
            End If

            If TimeWrong = True Then
                TimeWrong = Nothing
                MEtime.Enabled = True
                lbltod.Visible = True
                userMessage = "You cannot enter future times.  Please enter a valid time and/or change the date."
                Master._printMessage(userMessage, True, True)
                ' Me.txtTOD.Text = Nothing
                Exit Sub
            End If

            If txtTOD.Text = "" Or txtTOD.Text = " " Then
                MEtime.Enabled = True
                lbltod.Visible = True
            Else
                lbltod.Visible = False
            End If
        ElseIf txttdy.Text >= txtDOS.Text Then
            If txtTOD.Text = Nothing Or txtTOD.Text = " " Or txtTOD.Text = "00:00 AM" Or txtTOD.Text = "00:00 PM" Or txtTOD.Text = "__:__ AM" Then
                Session("TimeFMTWrong") = Nothing
                userMessage = "Time is invalid, please put in hh:mm format, using a valid time."
                Master._printMessage(userMessage, True, True)
                ' txtTOD.Text = Nothing
                Session("TimeFMTWrong") = Nothing
                Exit Sub
            End If
        End If
    End Sub

    Dim DateString As String
    Dim NewDateString As String
    Dim TimeString As String
    Dim NewTimeString As String = ""
    Dim d1 As String
    Public Function _dateConvertor(ByVal txt As String, ByVal DateWrong As Boolean)
        '||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        'This function will return a consistant SQL friendly date from a date that contains slashes, dashes, or dots as seperators.
        'It converts "1-1-2000" or "1.1.2000" or "1/1/2000" to "01/01/2000". Pass the function the textbox containing the date. This works well with client side validation.
        '
        '!!!IMPORTANT!!! - Date Validation must take place before being converted!
        '
        'To Use:
        '           label1.text = u._dateConvertor(me.textbox1)
        '||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        DateString = txt
        Try


            If DateString.Contains("-") Then
                DateString = DateString.Replace("-", "/")
            End If
            If DateString.Contains(".") Then
                DateString = DateString.Replace(".", "/")
            End If

            Dim DateParts() As String = DateString.Split("/"c)
            Dim d1 As String = DateParts(0)
            Dim m As String = DateParts(0)
            Dim d As String = DateParts(1)
            Dim y As String = DateParts(2)
            If y.Length = 2 Then
                y = Year(DateString)
            End If
            If y < "1900" Then
                y = "2" + Mid(y, 2, 3)
            End If
            y = Mid(y, 1, 4)

            If d.Length = 1 Then
                d = "0" + d
            End If
            If m.Length = 1 Then
                m = "0" + m
            End If
            NewDateString = m + "/" + d + "/" + y
        Catch ex As Exception
            If d1 = Nothing Then DateWrong = True
        End Try
        Return NewDateString
    End Function
    Public Function _timeConvertor(ByVal txt As String, ByVal thistime As String, ByVal FmtWrong As Boolean, ByVal TimeWrong As Boolean)
        '||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
        'This function will return a consistant SQL friendly date from a date that contains slashes, dashes, or dots as seperators.
        'It converts "1-1-2000" or "1.1.2000" or "1/1/2000" to "01/01/2000". Pass the function the textbox containing the date. This works well with client side validation.
        '
        '!!!IMPORTANT!!! - Date Validation must take place before being converted!
        '
        'To Use:
        '           label1.text = u._dateConvertor(me.textbox1)
        '||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

        TimeString = txt
        Try

            If TimeString = "" Then TimeString = Format(Now(), "hh:mm:TT")

            If TimeString.Length < 3 Then
                FmtWrong = True
                NewTimeString = ""
                Return NewTimeString
                Exit Function
            End If
            Dim int1 As Integer = InStr(TimeString, ":")
            If TimeString.Contains("-") Then
                TimeString = TimeString.Replace("-", ":")
            End If
            If TimeString.Contains(".") Then
                TimeString = TimeString.Replace(".", "")
            End If
            If TimeString.Contains(";") Then
                TimeString = TimeString.Replace(";", ":")
            End If
            If int1 = 0 Then
                If TimeString.Length = 3 Then
                    TimeString = Mid(TimeString, 1, 1) & ":" & Mid(TimeString, 2, 2)
                ElseIf TimeString.Length = 4 Then
                    TimeString = Mid(TimeString, 1, 2) & ":" & Mid(TimeString, 3, 2)
                Else
                    TimeWrong = True
                    NewTimeString = ""
                    Return NewTimeString
                    Exit Function
                End If
            End If


            Dim TimeParts() As String = TimeString.Split(":"c)
            Dim hh As String = TimeParts(0)
            Dim HH2 As String = TimeParts(0)
            Dim mm As String = TimeParts(1)
            'Dim l = Session("LOC")
            'If (Session("LOC") = "ESCANABA" And Session("Clocked") = True) Then
            '    hh = hh + 1
            'End If
            Dim ampm As String
            If hh.Length = 1 Then
                hh = "0" + hh
            End If
            If mm.Length = 1 Then
                mm = "0" + mm
            End If
            mm = Mid(LTrim(mm), 1, 2)
            If TimeString.Contains("A") Or TimeString.Contains("a") Then
                ampm = "AM"

            ElseIf TimeString.Contains("P") Or TimeString.Contains("p") Then
                ampm = "PM"
            ElseIf hh >= "07" And hh <= "11" Then
                ampm = "AM"
            ElseIf hh = "12" Or hh <= "06" Then
                ampm = "PM"
            Else
                ampm = "PM"
            End If
            If ampm = "PM" And hh < 7 Then
                HH2 = hh + 12
            End If
            If ampm = "PM" And hh > 12 Then
                hh = hh - 12
            End If
            If ampm = "AM" And hh > 12 Then
                hh = hh - 12
                ampm = "PM"
            End If

            thistime = HH2 + ":" + mm
            NewTimeString = hh + ":" + mm + " " + ampm
        Catch ex As Exception

        End Try
        Return NewTimeString
    End Function
End Class