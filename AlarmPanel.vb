Public Class AlarmPanel
    Inherits UserControl

    ' Declare the components
    Private timePanel As TimePanel
    Private listBoxSounds As ListBox
    Public chkTurnOn As CheckBox ' Make this public so it can be accessed from Form1
    Private rbAM As RadioButton
    Private rbPM As RadioButton
    Private btnReset As Button
    Private setBtn As Button ' Declare setBtn
    Private WithEvents ok As Button
    Private WithEvents cancel As Button

    ' Add an event to signal when the checkbox is changed
    Public Event AlarmCheckboxChanged(alarmOn As Boolean)

    ' Initialize the AlarmPanel
    Public Sub New()
        SetupAlarmPanel()
    End Sub

    ' Set up the AlarmPanel layout and components
    Private Sub SetupAlarmPanel()
        ' Create the AM and PM RadioButtons
        rbAM = New RadioButton With {
            .Text = "AM",
            .Location = New Point(556, 73)
        }
        rbPM = New RadioButton With {
            .Text = "PM",
            .Location = New Point(556, 108)
        }

        ' Create the Reset Button
        btnReset = New Button With {
            .Text = "Reset",
            .Location = New Point(579, 287),
            .Size = New Size(130, 59)
        }

        ' Create the Set Button
        setBtn = New Button With {
            .Text = "Set",
            .Location = New Point(420, 287), ' Adjust as necessary
            .Size = New Size(130, 59)
        }

        ' Add the RadioButtons, Reset Button, and Set Button to the panel
        Controls.Add(rbAM)
        Controls.Add(rbPM)
        Controls.Add(btnReset)
        Controls.Add(setBtn)

        ' Create and set up the TimePanel
        timePanel = New TimePanel(rbAM, rbPM, btnReset, setBtn, False) ' Pass setBtn to TimePanel
        timePanel.Location = New Point(10, 10)
        timePanel.Size = New Size(500, 200) ' Adjust the size to fix display issue
        Controls.Add(timePanel)

        ' Create and set up the ListBox for selecting sound effects
        listBoxSounds = New ListBox With {
            .Location = New Point(65, 220),
            .Size = New Size(200, 100)
        }
        listBoxSounds.Items.AddRange(New String() {"Crickets", "Bird", "Cow", "Drum Roll", "Boat Horn"})
        Controls.Add(listBoxSounds)

        ' Create and set up the "Turn On" Checkbox
        chkTurnOn = New CheckBox With {
            .Text = "Turn On",
            .Location = New Point(560, 180),
            .AutoSize = True
        }
        Controls.Add(chkTurnOn)

        ' Add the reset button event handler
        AddHandler btnReset.Click, AddressOf btnReset_Click

        ' Add the set button event handler (to show the keypad)
        AddHandler setBtn.Click, AddressOf SetButton_Click

        ' Add handler for the checkbox change to raise the event
        AddHandler chkTurnOn.CheckedChanged, AddressOf OnCheckboxChanged
    End Sub

    ' Raise the event when the checkbox is changed
    Private Sub OnCheckboxChanged(sender As Object, e As EventArgs)
        RaiseEvent AlarmCheckboxChanged(chkTurnOn.Checked)
    End Sub

    ' Reset button click event to update time to 00:00 AM
    Private Sub btnReset_Click(sender As Object, e As EventArgs)
        timePanel.UpdateTimeToZero()
        rbAM.Checked = True ' Reset to AM
    End Sub

    ' Set button click event to show keypad
    Private Sub SetButton_Click(sender As Object, e As EventArgs)
        Dim parentForm As Form = Me.FindForm()
        If parentForm IsNot Nothing Then
            parentForm.Height += 500 ' Increase the form height by 500
        End If
    End Sub

    ' Method to reset time to 00:00
    Public Sub ResetToZero()
        timePanel.UpdateTimeToZero()
    End Sub

    ' Forward methods to the internal timePanel
    Public Sub EnterDigit(digit As Integer)
        timePanel.EnterDigit(digit)
    End Sub

    Public Function GetHour() As Integer
        Return timePanel.GetHour()
    End Function

    Public Function GetMinute() As Integer
        Return timePanel.GetMinute()
    End Function

    Public Function IsPM() As Boolean
        Return timePanel.IsPM()
    End Function

    Public Function GetTimePanel() As TimePanel
        Return timePanel
    End Function

    Public Sub SetTime(hour As Integer, minute As Integer)
        timePanel.SetTime(hour, minute)
    End Sub

    Public Sub SelectAM()
        rbAM.Checked = True
    End Sub

    Public Sub SelectPM()
        rbPM.Checked = True
    End Sub

End Class
