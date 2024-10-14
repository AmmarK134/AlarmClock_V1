Public Class DigitLED
    Inherits Label

    Private _maxDigit As Integer ' The maximum allowed digit
    Private _currentDigit As Integer ' The current displayed digit

    ' Property for MaxDigit
    Public Property MaxDigit As Integer
        Get
            Return _maxDigit
        End Get
        Set(value As Integer)
            _maxDigit = value
        End Set
    End Property

    ' Method to Set the Digit
    Public Sub SetDigit(value As Integer)
        ' Ensure the value is within the allowed range without throwing any errors
        If value >= 0 AndAlso value <= _maxDigit Then
            ' Store the digit in _currentDigit
            _currentDigit = value

            ' Display the digit
            Me.Text = value.ToString()

            ' Optionally, force a UI update
            Me.Invalidate() ' Force control to refresh and display the updated digit
        End If
        ' If the value is out of range, do nothing
    End Sub

    ' Method to Get the Current Digit
    Public Function GetDigit() As Integer
        Return _currentDigit
    End Function

    ' Constructor to initialize the control
    Public Sub New()
        Me.AutoSize = False ' Prevent automatic resizing
        Me.Font = New Font("Arial", 48, FontStyle.Bold) ' Fixed large font size
        Me.Size = New Size(80, 100) ' Size for each digit
        Me.TextAlign = ContentAlignment.MiddleCenter ' Center the digit
        Me.BackColor = Color.Transparent ' LED-style background color
        Me.ForeColor = Color.Green ' LED-style text color
        Me.Text = "0" ' Default initial value
        _maxDigit = 9 ' Set a default max digit value
        _currentDigit = 0 ' Initialize current digit to 0
    End Sub

    ' Property for accessing the current digit directly
    Public ReadOnly Property Digit As Integer
        Get
            Return _currentDigit
        End Get
    End Property
End Class
