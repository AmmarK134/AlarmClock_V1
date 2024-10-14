<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        TabControl1 = New TabControl()
        clock = New TabPage()
        alarm3chk = New CheckBox()
        alarm2chk = New CheckBox()
        alarm1chk = New CheckBox()
        setBtn = New Button()
        rbPM = New RadioButton()
        rbAM = New RadioButton()
        btnReset = New Button()
        alarm1 = New TabPage()
        alarm2 = New TabPage()
        alarm3 = New TabPage()
        Panel1 = New Panel()
        ok = New Button()
        zero = New Button()
        cancel = New Button()
        nine = New Button()
        eight = New Button()
        seven = New Button()
        six = New Button()
        five = New Button()
        four = New Button()
        three = New Button()
        two = New Button()
        one = New Button()
        TabControl1.SuspendLayout()
        clock.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(clock)
        TabControl1.Controls.Add(alarm1)
        TabControl1.Controls.Add(alarm2)
        TabControl1.Controls.Add(alarm3)
        TabControl1.Location = New Point(62, 52)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(776, 426)
        TabControl1.TabIndex = 0
        ' 
        ' clock
        ' 
        clock.Controls.Add(alarm3chk)
        clock.Controls.Add(alarm2chk)
        clock.Controls.Add(alarm1chk)
        clock.Controls.Add(setBtn)
        clock.Controls.Add(rbPM)
        clock.Controls.Add(rbAM)
        clock.Controls.Add(btnReset)
        clock.Location = New Point(4, 34)
        clock.Name = "clock"
        clock.Padding = New Padding(3)
        clock.Size = New Size(768, 388)
        clock.TabIndex = 0
        clock.Text = "Clock"
        clock.UseVisualStyleBackColor = True
        ' 
        ' alarm3chk
        ' 
        alarm3chk.AutoSize = True
        alarm3chk.Location = New Point(93, 307)
        alarm3chk.Name = "alarm3chk"
        alarm3chk.Size = New Size(129, 29)
        alarm3chk.TabIndex = 6
        alarm3chk.Text = "Alarm 3 On"
        alarm3chk.UseVisualStyleBackColor = True
        ' 
        ' alarm2chk
        ' 
        alarm2chk.AutoSize = True
        alarm2chk.Location = New Point(92, 272)
        alarm2chk.Name = "alarm2chk"
        alarm2chk.Size = New Size(129, 29)
        alarm2chk.TabIndex = 5
        alarm2chk.Text = "Alarm 2 On"
        alarm2chk.UseVisualStyleBackColor = True
        ' 
        ' alarm1chk
        ' 
        alarm1chk.AutoSize = True
        alarm1chk.Location = New Point(92, 237)
        alarm1chk.Name = "alarm1chk"
        alarm1chk.Size = New Size(129, 29)
        alarm1chk.TabIndex = 4
        alarm1chk.Text = "Alarm 1 On"
        alarm1chk.UseVisualStyleBackColor = True
        ' 
        ' setBtn
        ' 
        setBtn.Location = New Point(428, 287)
        setBtn.Name = "setBtn"
        setBtn.Size = New Size(135, 59)
        setBtn.TabIndex = 3
        setBtn.Text = "Set"
        setBtn.UseVisualStyleBackColor = True
        ' 
        ' rbPM
        ' 
        rbPM.AutoSize = True
        rbPM.Location = New Point(556, 108)
        rbPM.Name = "rbPM"
        rbPM.Size = New Size(63, 29)
        rbPM.TabIndex = 2
        rbPM.TabStop = True
        rbPM.Text = "PM"
        rbPM.UseVisualStyleBackColor = True
        ' 
        ' rbAM
        ' 
        rbAM.AutoSize = True
        rbAM.Location = New Point(556, 73)
        rbAM.Name = "rbAM"
        rbAM.Size = New Size(65, 29)
        rbAM.TabIndex = 1
        rbAM.TabStop = True
        rbAM.Text = "AM"
        rbAM.UseVisualStyleBackColor = True
        ' 
        ' btnReset
        ' 
        btnReset.Location = New Point(579, 287)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(130, 59)
        btnReset.TabIndex = 0
        btnReset.Text = "Reset"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' alarm1
        ' 
        alarm1.Location = New Point(4, 34)
        alarm1.Name = "alarm1"
        alarm1.Padding = New Padding(3)
        alarm1.Size = New Size(768, 388)
        alarm1.TabIndex = 1
        alarm1.Text = "Alarm 1"
        alarm1.UseVisualStyleBackColor = True
        ' 
        ' alarm2
        ' 
        alarm2.Location = New Point(4, 34)
        alarm2.Name = "alarm2"
        alarm2.Padding = New Padding(3)
        alarm2.Size = New Size(768, 388)
        alarm2.TabIndex = 2
        alarm2.Text = "Alarm 2"
        alarm2.UseVisualStyleBackColor = True
        ' 
        ' alarm3
        ' 
        alarm3.Location = New Point(4, 34)
        alarm3.Name = "alarm3"
        alarm3.Padding = New Padding(3)
        alarm3.Size = New Size(768, 388)
        alarm3.TabIndex = 3
        alarm3.Text = "Alarm 3"
        alarm3.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(ok)
        Panel1.Controls.Add(zero)
        Panel1.Controls.Add(cancel)
        Panel1.Controls.Add(nine)
        Panel1.Controls.Add(eight)
        Panel1.Controls.Add(seven)
        Panel1.Controls.Add(six)
        Panel1.Controls.Add(five)
        Panel1.Controls.Add(four)
        Panel1.Controls.Add(three)
        Panel1.Controls.Add(two)
        Panel1.Controls.Add(one)
        Panel1.Location = New Point(66, 495)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(772, 463)
        Panel1.TabIndex = 1
        ' 
        ' ok
        ' 
        ok.Location = New Point(486, 341)
        ok.Name = "ok"
        ok.Size = New Size(150, 100)
        ok.TabIndex = 11
        ok.Text = "OK"
        ok.UseVisualStyleBackColor = True
        ' 
        ' zero
        ' 
        zero.Location = New Point(310, 341)
        zero.Name = "zero"
        zero.Size = New Size(150, 100)
        zero.TabIndex = 10
        zero.Text = "0"
        zero.UseVisualStyleBackColor = True
        ' 
        ' cancel
        ' 
        cancel.Location = New Point(134, 341)
        cancel.Name = "cancel"
        cancel.Size = New Size(150, 100)
        cancel.TabIndex = 9
        cancel.Text = "Cancel"
        cancel.UseVisualStyleBackColor = True
        ' 
        ' nine
        ' 
        nine.Location = New Point(486, 235)
        nine.Name = "nine"
        nine.Size = New Size(150, 100)
        nine.TabIndex = 8
        nine.Text = "9"
        nine.UseVisualStyleBackColor = True
        ' 
        ' eight
        ' 
        eight.Location = New Point(310, 235)
        eight.Name = "eight"
        eight.Size = New Size(150, 100)
        eight.TabIndex = 7
        eight.Text = "8"
        eight.UseVisualStyleBackColor = True
        ' 
        ' seven
        ' 
        seven.Location = New Point(134, 235)
        seven.Name = "seven"
        seven.Size = New Size(150, 100)
        seven.TabIndex = 6
        seven.Text = "7"
        seven.UseVisualStyleBackColor = True
        ' 
        ' six
        ' 
        six.Location = New Point(486, 129)
        six.Name = "six"
        six.Size = New Size(150, 100)
        six.TabIndex = 5
        six.Text = "6"
        six.UseVisualStyleBackColor = True
        ' 
        ' five
        ' 
        five.Location = New Point(310, 129)
        five.Name = "five"
        five.Size = New Size(150, 100)
        five.TabIndex = 4
        five.Text = "5"
        five.UseVisualStyleBackColor = True
        ' 
        ' four
        ' 
        four.Location = New Point(134, 129)
        four.Name = "four"
        four.Size = New Size(150, 100)
        four.TabIndex = 3
        four.Text = "4"
        four.UseVisualStyleBackColor = True
        ' 
        ' three
        ' 
        three.Location = New Point(486, 23)
        three.Name = "three"
        three.Size = New Size(150, 100)
        three.TabIndex = 2
        three.Text = "3"
        three.UseVisualStyleBackColor = True
        ' 
        ' two
        ' 
        two.Location = New Point(310, 23)
        two.Name = "two"
        two.Size = New Size(150, 100)
        two.TabIndex = 1
        two.Text = "2"
        two.UseVisualStyleBackColor = True
        ' 
        ' one
        ' 
        one.Location = New Point(134, 23)
        one.Name = "one"
        one.Size = New Size(150, 100)
        one.TabIndex = 0
        one.Text = "1"
        one.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(900, 491)
        Controls.Add(Panel1)
        Controls.Add(TabControl1)
        Name = "Form1"
        Text = "Ammar's Alarm Clock"
        TabControl1.ResumeLayout(False)
        clock.ResumeLayout(False)
        clock.PerformLayout()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents clock As TabPage
    Friend WithEvents alarm1 As TabPage
    Friend WithEvents alarm2 As TabPage
    Friend WithEvents alarm3 As TabPage
    Friend WithEvents btnReset As Button
    Friend WithEvents rbPM As RadioButton
    Friend WithEvents rbAM As RadioButton
    Friend WithEvents setBtn As Button
    Friend WithEvents alarm1chk As CheckBox
    Friend WithEvents alarm3chk As CheckBox
    Friend WithEvents alarm2chk As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ok As Button
    Friend WithEvents zero As Button
    Friend WithEvents cancel As Button
    Friend WithEvents nine As Button
    Friend WithEvents eight As Button
    Friend WithEvents seven As Button
    Friend WithEvents six As Button
    Friend WithEvents five As Button
    Friend WithEvents four As Button
    Friend WithEvents three As Button
    Friend WithEvents two As Button
    Friend WithEvents one As Button

End Class
