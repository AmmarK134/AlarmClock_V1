Public Class Form1
    Private clockTimePanel As TimePanel
    Private alarm1Panel As AlarmPanel
    Private alarm2Panel As AlarmPanel
    Private alarm3Panel As AlarmPanel
    Private originalHeight As Integer

    ' Variables to store previous time when Set button is pressed
    Private previousHour As Integer
    Private previousMinute As Integer
    Private previousIsPM As Boolean

    Private previousAlarm1Hour As Integer
    Private previousAlarm1Minute As Integer
    Private previousAlarm1IsPM As Boolean

    Private previousAlarm2Hour As Integer
    Private previousAlarm2Minute As Integer
    Private previousAlarm2IsPM As Boolean

    Private previousAlarm3Hour As Integer
    Private previousAlarm3Minute As Integer
    Private previousAlarm3IsPM As Boolean

    ' Form load event handler
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Save the original height of the form
        originalHeight = Me.Height

        ' Initialize Clock TimePanel with real-time updates enabled
        clockTimePanel = New TimePanel(rbAM, rbPM, btnReset, setBtn, True)
        Dim clockTab As TabPage = TabControl1.TabPages(0) ' Clock tab is index 0
        clockTimePanel.Location = New Point(10, 10)
        clockTimePanel.Size = New Size(500, 200) ' Adjust the size as needed
        clockTab.Controls.Add(clockTimePanel)

        ' Immediately update the time when the form loads only on the Clock Tab
        clockTimePanel.UpdateTime()

        ' Initialize Alarm 1, Alarm 2, and Alarm 3 panels, but no real-time updates
        InitializeAlarmTabs()

        ' Disable OK button initially
        ok.Enabled = False

        ' Add event handler for the Set button
        AddHandler setBtn.Click, AddressOf SetButton_Click

        ' Add event handler for the Reset button
        AddHandler btnReset.Click, AddressOf ResetButton_Click

        ' Add event handler for the alarm checkboxes in Clock tab
        AddHandler alarm1chk.CheckedChanged, AddressOf ClockPanelAlarmCheckbox_CheckedChanged
        AddHandler alarm2chk.CheckedChanged, AddressOf ClockPanelAlarmCheckbox_CheckedChanged
        AddHandler alarm3chk.CheckedChanged, AddressOf ClockPanelAlarmCheckbox_CheckedChanged

        ' Handle the OK and Cancel button events
        AddHandler ok.Click, AddressOf OkButton_Click
        AddHandler cancel.Click, AddressOf CancelButton_Click

        ' Handle number buttons click events with names one, two, etc.
        AddHandler one.Click, AddressOf NumberButton_Click
        AddHandler two.Click, AddressOf NumberButton_Click
        AddHandler three.Click, AddressOf NumberButton_Click
        AddHandler four.Click, AddressOf NumberButton_Click
        AddHandler five.Click, AddressOf NumberButton_Click
        AddHandler six.Click, AddressOf NumberButton_Click
        AddHandler seven.Click, AddressOf NumberButton_Click
        AddHandler eight.Click, AddressOf NumberButton_Click
        AddHandler nine.Click, AddressOf NumberButton_Click
        AddHandler zero.Click, AddressOf NumberButton_Click
    End Sub

    ' Initialize alarm tabs
    Private Sub InitializeAlarmTabs()
        ' Alarm 1 Tab
        alarm1Panel = New AlarmPanel()
        Dim alarm1Tab As TabPage = TabControl1.TabPages(1) ' Alarm 1 Tab
        alarm1Panel.Location = New Point(10, 10)
        alarm1Panel.Size = New Size(768, 388)
        alarm1Tab.Controls.Add(alarm1Panel)

        ' Select AM by default for Alarm 1
        alarm1Panel.SelectAM() ' Ensure AM is selected when the form loads

        ' Alarm 2 Tab
        alarm2Panel = New AlarmPanel()
        Dim alarm2Tab As TabPage = TabControl1.TabPages(2) ' Alarm 2 Tab
        alarm2Panel.Location = New Point(10, 10)
        alarm2Panel.Size = New Size(768, 388)
        alarm2Tab.Controls.Add(alarm2Panel)

        ' Select AM by default for Alarm 2
        alarm2Panel.SelectAM()

        ' Alarm 3 Tab
        alarm3Panel = New AlarmPanel()
        Dim alarm3Tab As TabPage = TabControl1.TabPages(3) ' Alarm 3 Tab
        alarm3Panel.Location = New Point(10, 10)
        alarm3Panel.Size = New Size(768, 388)
        alarm3Tab.Controls.Add(alarm3Panel)

        ' Select AM by default for Alarm 3
        alarm3Panel.SelectAM()

        ' Add event handlers for the alarm panel checkboxes
        AddHandler alarm1Panel.chkTurnOn.CheckedChanged, AddressOf AlarmTabCheckbox_CheckedChanged
        AddHandler alarm2Panel.chkTurnOn.CheckedChanged, AddressOf AlarmTabCheckbox_CheckedChanged
        AddHandler alarm3Panel.chkTurnOn.CheckedChanged, AddressOf AlarmTabCheckbox_CheckedChanged
    End Sub

    ' Event handler for the Reset button
    Private Sub ResetButton_Click(sender As Object, e As EventArgs)
        ' Get the active tab
        Dim activeTab As TabPage = TabControl1.SelectedTab

        ' If on Clock tab, reset to current time
        If activeTab.Text = "Clock" Then
            clockTimePanel.UpdateTime() ' Update to the current time
        ElseIf activeTab.Text = "Alarm 1" Then
            alarm1Panel.ResetToZero()
        ElseIf activeTab.Text = "Alarm 2" Then
            alarm2Panel.ResetToZero()
        ElseIf activeTab.Text = "Alarm 3" Then
            alarm3Panel.ResetToZero()
        End If
    End Sub

    ' Event handler for checkboxes in Clock tab
    Private Sub ClockPanelAlarmCheckbox_CheckedChanged(sender As Object, e As EventArgs)
        If sender Is alarm1chk Then
            alarm1Panel.chkTurnOn.Checked = alarm1chk.Checked
        ElseIf sender Is alarm2chk Then
            alarm2Panel.chkTurnOn.Checked = alarm2chk.Checked
        ElseIf sender Is alarm3chk Then
            alarm3Panel.chkTurnOn.Checked = alarm3chk.Checked
        End If
    End Sub

    ' Event handler for checkboxes in Alarm tabs
    Private Sub AlarmTabCheckbox_CheckedChanged(sender As Object, e As EventArgs)
        If sender Is alarm1Panel.chkTurnOn Then
            alarm1chk.Checked = alarm1Panel.chkTurnOn.Checked
        ElseIf sender Is alarm2Panel.chkTurnOn Then
            alarm2chk.Checked = alarm2Panel.chkTurnOn.Checked
        ElseIf sender Is alarm3Panel.chkTurnOn Then
            alarm3chk.Checked = alarm3Panel.chkTurnOn.Checked
        End If
    End Sub

    ' Handle OK and Cancel button click to reset form height
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles ok.Click
        ' Set the entered time and reset the form height
        SetEnteredTimeIn12HourFormat() ' Optional: Keep if needed
        SetEnteredTime() ' Set the time based on the input

        ' Save the entered time as the previous time for each alarm tab
        Dim activeTab As TabPage = TabControl1.SelectedTab
        If activeTab.Text = "Clock" Then
            ' Clock tab already handled
        ElseIf activeTab.Text = "Alarm 1" Then
            previousAlarm1Hour = alarm1Panel.GetHour()
            previousAlarm1Minute = alarm1Panel.GetMinute()
            previousAlarm1IsPM = alarm1Panel.IsPM()
        ElseIf activeTab.Text = "Alarm 2" Then
            previousAlarm2Hour = alarm2Panel.GetHour()
            previousAlarm2Minute = alarm2Panel.GetMinute()
            previousAlarm2IsPM = alarm2Panel.IsPM()
        ElseIf activeTab.Text = "Alarm 3" Then
            previousAlarm3Hour = alarm3Panel.GetHour()
            previousAlarm3Minute = alarm3Panel.GetMinute()
            previousAlarm3IsPM = alarm3Panel.IsPM()
        End If

        ' Reset the input position so that a new time entry can begin
        If activeTab.Text = "Clock" Then
            clockTimePanel.ResetInputPosition() ' Reset for Clock
        ElseIf activeTab.Text = "Alarm 1" Then
            alarm1Panel.GetTimePanel().ResetInputPosition() ' Reset for Alarm 1
        ElseIf activeTab.Text = "Alarm 2" Then
            alarm2Panel.GetTimePanel().ResetInputPosition() ' Reset for Alarm 2
        ElseIf activeTab.Text = "Alarm 3" Then
            alarm3Panel.GetTimePanel().ResetInputPosition() ' Reset for Alarm 3
        End If

        ' Reset the form height
        Me.Height = originalHeight
    End Sub

    ' Enable/Disable OK button based on valid time entry
    Private Sub ValidateTimeEntry(panel As TimePanel)
        Dim enteredHour As Integer = panel.GetHour()
        Dim enteredMinute As Integer = panel.GetMinute()

        ' Enable OK button only if both hour and minute are entered
        If enteredHour <> -1 AndAlso enteredMinute <> -1 Then
            ok.Enabled = True
        Else
            ok.Enabled = False
        End If
    End Sub

    ' Set button click event handler
    Private Sub SetButton_Click(sender As Object, e As EventArgs)
        ' Increase the form's height by 500 pixels
        Me.Height = originalHeight + 500

        ' Store the current time of the active panel
        Dim activeTab As TabPage = TabControl1.SelectedTab
        If activeTab.Text = "Clock" Then
            previousHour = clockTimePanel.GetHour()
            previousMinute = clockTimePanel.GetMinute()
            previousIsPM = clockTimePanel.IsPM()
        ElseIf activeTab.Text = "Alarm 1" Then
            previousHour = alarm1Panel.GetHour()
            previousMinute = alarm1Panel.GetMinute()
            previousIsPM = alarm1Panel.IsPM()
        ElseIf activeTab.Text = "Alarm 2" Then
            previousHour = alarm2Panel.GetHour()
            previousMinute = alarm2Panel.GetMinute()
            previousIsPM = alarm2Panel.IsPM()
        ElseIf activeTab.Text = "Alarm 3" Then
            previousHour = alarm3Panel.GetHour()
            previousMinute = alarm3Panel.GetMinute()
            previousIsPM = alarm3Panel.IsPM()
        End If

        ' Reset the input position so the user can re-enter time
        clockTimePanel.ResetInputPosition() ' Reset the position to Hour1

        ' Disable OK button until a valid time is entered
        ok.Enabled = False
    End Sub

    ' Cancel button event handler
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles cancel.Click
        ' Restore the previously stored time when cancel is clicked
        Dim activeTab As TabPage = TabControl1.SelectedTab

        If activeTab.Text = "Clock" Then
            clockTimePanel.SetTime(previousHour, previousMinute)
            If previousIsPM Then
                rbPM.Checked = True
            Else
                rbAM.Checked = True
            End If

        ElseIf activeTab.Text = "Alarm 1" Then
            alarm1Panel.SetTime(previousAlarm1Hour, previousAlarm1Minute)
            If previousAlarm1IsPM Then
                alarm1Panel.SelectPM()
            Else
                alarm1Panel.SelectAM()
            End If

        ElseIf activeTab.Text = "Alarm 2" Then
            alarm2Panel.SetTime(previousAlarm2Hour, previousAlarm2Minute)
            If previousAlarm2IsPM Then
                alarm2Panel.SelectPM()
            Else
                alarm2Panel.SelectAM()
            End If

        ElseIf activeTab.Text = "Alarm 3" Then
            alarm3Panel.SetTime(previousAlarm3Hour, previousAlarm3Minute)
            If previousAlarm3IsPM Then
                alarm3Panel.SelectPM()
            Else
                alarm3Panel.SelectAM()
            End If
        End If

        ' Reset the form height without saving
        Me.Height = originalHeight
    End Sub

    ' Number button click handler
    Private Sub NumberButton_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Button = DirectCast(sender, Button)
        Dim digit As Integer = Convert.ToInt32(clickedButton.Text)

        ' Handle the digit entry for both clock and alarm panels
        Dim activeTab As TabPage = TabControl1.SelectedTab
        If activeTab.Text = "Clock" Then
            clockTimePanel.EnterDigit(digit)
            ValidateTimeEntry(clockTimePanel)
        ElseIf activeTab.Text = "Alarm 1" Then
            alarm1Panel.EnterDigit(digit)
            ValidateTimeEntry(alarm1Panel.GetTimePanel())
        ElseIf activeTab.Text = "Alarm 2" Then
            alarm2Panel.EnterDigit(digit)
            ValidateTimeEntry(alarm2Panel.GetTimePanel())
        ElseIf activeTab.Text = "Alarm 3" Then
            alarm3Panel.EnterDigit(digit)
            ValidateTimeEntry(alarm3Panel.GetTimePanel())
        End If
    End Sub

    ' Function to set the entered time when OK is clicked
    Private Sub SetEnteredTime()
        ' Get the active tab and retrieve the entered time
        Dim activeTab As TabPage = TabControl1.SelectedTab
        Dim enteredHour As Integer
        Dim enteredMinute As Integer
        Dim isPM As Boolean

        If activeTab.Text = "Clock" Then
            enteredHour = clockTimePanel.GetHour()
            enteredMinute = clockTimePanel.GetMinute()
            isPM = clockTimePanel.IsPM()
        ElseIf activeTab.Text = "Alarm 1" Then
            enteredHour = alarm1Panel.GetHour()
            enteredMinute = alarm1Panel.GetMinute()
            isPM = alarm1Panel.IsPM()
        ElseIf activeTab.Text = "Alarm 2" Then
            enteredHour = alarm2Panel.GetHour()
            enteredMinute = alarm2Panel.GetMinute()
            isPM = alarm2Panel.IsPM()
        ElseIf activeTab.Text = "Alarm 3" Then
            enteredHour = alarm3Panel.GetHour()
            enteredMinute = alarm3Panel.GetMinute()
            isPM = alarm3Panel.IsPM()
        End If

        ' Convert the time to 24-hour format if necessary
        If isPM AndAlso enteredHour < 12 Then
            enteredHour += 12
        ElseIf Not isPM AndAlso enteredHour = 12 Then
            enteredHour = 0
        End If

        ' Set the time in the appropriate panel
        If activeTab.Text = "Clock" Then
            clockTimePanel.SetTime(enteredHour, enteredMinute)
        ElseIf activeTab.Text = "Alarm 1" Then
            alarm1Panel.SetTime(enteredHour, enteredMinute)
        ElseIf activeTab.Text = "Alarm 2" Then
            alarm2Panel.SetTime(enteredHour, enteredMinute)
        ElseIf activeTab.Text = "Alarm 3" Then
            alarm3Panel.SetTime(enteredHour, enteredMinute)
        End If
    End Sub

    ' Set the entered time in 12-hour format (existing method kept)
    Private Sub SetEnteredTimeIn12HourFormat()
        Dim enteredHour As Integer = (clockTimePanel.GetHour1() * 10) + clockTimePanel.GetHour2()
        Dim enteredMinute As Integer = (clockTimePanel.GetMinute1() * 10) + clockTimePanel.GetMinute2()

        ' Convert to 12-hour format
        If enteredHour >= 12 Then
            rbPM.Checked = True
            If enteredHour > 12 Then
                enteredHour -= 12
            End If
        Else
            rbAM.Checked = True
            If enteredHour = 0 Then
                enteredHour = 12 ' Treat midnight as 12 AM
            End If
        End If

        ' Update the displayed digits in the time panel
        clockTimePanel.SetHour1Digit(enteredHour \ 10)
        clockTimePanel.SetHour2Digit(enteredHour Mod 10)
        clockTimePanel.SetMinute1Digit(enteredMinute \ 10)
        clockTimePanel.SetMinute2Digit(enteredMinute Mod 10)
    End Sub
End Class
