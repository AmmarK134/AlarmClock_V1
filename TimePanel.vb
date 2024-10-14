Public Class TimePanel
    Inherits UserControl

    ' Existing controls for the time display
    Private hour1 As DigitLED
    Private hour2 As DigitLED
    Private minute1 As DigitLED
    Private minute2 As DigitLED
    Private colonLabel As Label

    ' Existing buttons (AM, PM, Reset)
    Private rbAM As RadioButton
    Private rbPM As RadioButton
    Private btnReset As Button
    Private setBtn As Button

    ' Timer for updating time every minute
    Private clockTimer As Timer
    Private enableRealTimeUpdates As Boolean ' To track if real-time updates are enabled

    ' Enum to represent the input position
    Private Enum InputPosition
        Hour1
        Hour2
        Minute1
        Minute2
        Finished
    End Enum
    Private currentInputPosition As InputPosition = InputPosition.Hour1

    ' Initialize the TimePanel control
    Public Sub New(existingAM As RadioButton, existingPM As RadioButton, existingReset As Button, existingSetBtn As Button, enableRealTimeUpdates As Boolean)
        ' Initialize controls
        rbAM = existingAM
        rbPM = existingPM
        btnReset = existingReset
        setBtn = existingSetBtn

        ' Initialize time panel components
        SetupClockDisplay()

        ' Enable real-time updates if requested
        If enableRealTimeUpdates Then
            SetupClockTimer()
        End If
    End Sub

    ' Setup the clock display
    Private Sub SetupClockDisplay()
        ' Create the first hour digit
        hour1 = New DigitLED()
        hour1.Location = New Point(50, 50)
        hour1.Size = New Size(80, 120)
        Controls.Add(hour1)

        ' Create the second hour digit
        hour2 = New DigitLED()
        hour2.Location = New Point(130, 50)
        hour2.Size = New Size(80, 120)
        Controls.Add(hour2)

        ' Colon (":")
        colonLabel = New Label With {
            .Text = ":",
            .Font = New Font("Arial", 60, FontStyle.Bold),
            .Location = New Point(220, 30),
            .Size = New Size(80, 120),
            .ForeColor = Color.Green
        }
        Controls.Add(colonLabel)

        ' Create the first minute digit
        minute1 = New DigitLED()
        minute1.Location = New Point(310, 50)
        minute1.Size = New Size(80, 120)
        Controls.Add(minute1)

        ' Create the second minute digit
        minute2 = New DigitLED()
        minute2.Location = New Point(390, 50)
        minute2.Size = New Size(80, 120)
        Controls.Add(minute2)
    End Sub

    ' Timer setup
    Private Sub SetupClockTimer()
        clockTimer = New Timer()
        clockTimer.Interval = 60000 ' 60 seconds
        AddHandler clockTimer.Tick, AddressOf UpdateTime
        clockTimer.Start()
    End Sub

    ' Update time every minute or on reset in the Clock tab
    Public Sub UpdateTime()
        Dim currentTime As DateTime = DateTime.Now
        Dim hour As Integer = currentTime.Hour
        Dim minute As Integer = currentTime.Minute

        If hour >= 12 Then
            rbPM.Checked = True
            If hour > 12 Then hour -= 12
        Else
            rbAM.Checked = True
            If hour = 0 Then hour = 12
        End If

        hour1.SetDigit(hour \ 10)
        hour2.SetDigit(hour Mod 10)
        minute1.SetDigit(minute \ 10)
        minute2.SetDigit(minute Mod 10)
    End Sub

    ' Update time to 00:00 AM for reset in Alarm tabs
    Public Sub UpdateTimeToZero()
        hour1.SetDigit(0)
        hour2.SetDigit(0)
        minute1.SetDigit(0)
        minute2.SetDigit(0)

        rbAM.Checked = True
        rbPM.Checked = False
    End Sub

    ' Enter a digit based on the current input position
    Public Sub EnterDigit(digit As Integer)
        Select Case currentInputPosition
            Case InputPosition.Hour1
                If digit > 1 Then Return ' First hour digit can only be 0 or 1
                hour1.SetDigit(digit)
                currentInputPosition = InputPosition.Hour2 ' Move to next digit

            Case InputPosition.Hour2
                If hour1.GetDigit() = 1 AndAlso digit > 2 Then Return ' If hour1 is 1, hour2 can only be 0-2
                hour2.SetDigit(digit)
                currentInputPosition = InputPosition.Minute1 ' Move to minute1

            Case InputPosition.Minute1
                If digit > 5 Then Return ' Minute1 can only be 0-5
                minute1.SetDigit(digit)
                currentInputPosition = InputPosition.Minute2 ' Move to minute2

            Case InputPosition.Minute2
                minute2.SetDigit(digit)
                currentInputPosition = InputPosition.Finished ' Complete input

        End Select
    End Sub

    ' Get the entered hour
    Public Function GetHour() As Integer
        Return hour1.GetDigit() * 10 + hour2.GetDigit()
    End Function

    ' Get the entered minute
    Public Function GetMinute() As Integer
        Return minute1.GetDigit() * 10 + minute2.GetDigit()
    End Function

    ' Check if PM is selected
    Public Function IsPM() As Boolean
        Return rbPM.Checked
    End Function

    ' Set the time (optional for updating)
    Public Sub SetTime(hour As Integer, minute As Integer)
        hour1.SetDigit(hour \ 10)
        hour2.SetDigit(hour Mod 10)
        minute1.SetDigit(minute \ 10)
        minute2.SetDigit(minute Mod 10)
    End Sub

    Public Sub ResetInputPosition()
        currentInputPosition = 0 ' Reset the input position to the first digit (Hour1)
    End Sub


    ' Get the first hour digit
    Public Function GetHour1() As Integer
        Return hour1.GetDigit()
    End Function

    ' Get the second hour digit
    Public Function GetHour2() As Integer
        Return hour2.GetDigit()
    End Function

    ' Get the first minute digit
    Public Function GetMinute1() As Integer
        Return minute1.GetDigit()
    End Function

    ' Get the second minute digit
    Public Function GetMinute2() As Integer
        Return minute2.GetDigit()
    End Function

    Public Sub SetHour1Digit(value As Integer)
        hour1.SetDigit(value)
    End Sub

    Public Sub SetHour2Digit(value As Integer)
        hour2.SetDigit(value)
    End Sub

    Public Sub SetMinute1Digit(value As Integer)
        minute1.SetDigit(value)
    End Sub

    Public Sub SetMinute2Digit(value As Integer)
        minute2.SetDigit(value)
    End Sub
End Class
