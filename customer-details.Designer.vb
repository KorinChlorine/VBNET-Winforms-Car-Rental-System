<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class customerDetails
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtboxName = New System.Windows.Forms.TextBox()
        Me.txtboxAge = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtboxAddress = New System.Windows.Forms.TextBox()
        Me.txtboxCarID = New System.Windows.Forms.TextBox()
        Me.txtboxDays = New System.Windows.Forms.TextBox()
        Me.txtboxRecords = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rbMale = New System.Windows.Forms.RadioButton()
        Me.rbFemale = New System.Windows.Forms.RadioButton()
        Me.rbOthers = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtpBirthday = New System.Windows.Forms.DateTimePicker()
        Me.txtRes = New System.Windows.Forms.Label()
        Me.lblBirthday = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(74, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Age:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(74, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Birthday:"
        '
        'txtboxName
        '
        Me.txtboxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxName.Location = New System.Drawing.Point(158, 72)
        Me.txtboxName.Name = "txtboxName"
        Me.txtboxName.Size = New System.Drawing.Size(162, 29)
        Me.txtboxName.TabIndex = 3
        '
        'txtboxAge
        '
        Me.txtboxAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxAge.Location = New System.Drawing.Point(158, 140)
        Me.txtboxAge.Name = "txtboxAge"
        Me.txtboxAge.Size = New System.Drawing.Size(162, 29)
        Me.txtboxAge.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(76, 313)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Sex:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(385, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 24)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Address:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(385, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(196, 24)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Car ID number rented:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(385, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(340, 24)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Remaining Days for currently rented car"
        '
        'txtboxAddress
        '
        Me.txtboxAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxAddress.Location = New System.Drawing.Point(755, 67)
        Me.txtboxAddress.Name = "txtboxAddress"
        Me.txtboxAddress.Size = New System.Drawing.Size(142, 29)
        Me.txtboxAddress.TabIndex = 11
        '
        'txtboxCarID
        '
        Me.txtboxCarID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxCarID.Location = New System.Drawing.Point(755, 132)
        Me.txtboxCarID.Name = "txtboxCarID"
        Me.txtboxCarID.Size = New System.Drawing.Size(142, 29)
        Me.txtboxCarID.TabIndex = 12
        '
        'txtboxDays
        '
        Me.txtboxDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxDays.Location = New System.Drawing.Point(755, 208)
        Me.txtboxDays.Name = "txtboxDays"
        Me.txtboxDays.Size = New System.Drawing.Size(142, 29)
        Me.txtboxDays.TabIndex = 13
        '
        'txtboxRecords
        '
        Me.txtboxRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxRecords.Location = New System.Drawing.Point(755, 313)
        Me.txtboxRecords.Name = "txtboxRecords"
        Me.txtboxRecords.Size = New System.Drawing.Size(142, 29)
        Me.txtboxRecords.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(385, 313)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(241, 24)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Good Records:(True/False)"
        '
        'rbMale
        '
        Me.rbMale.AutoSize = True
        Me.rbMale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMale.Location = New System.Drawing.Point(78, 340)
        Me.rbMale.Name = "rbMale"
        Me.rbMale.Size = New System.Drawing.Size(61, 24)
        Me.rbMale.TabIndex = 17
        Me.rbMale.TabStop = True
        Me.rbMale.Text = "Male"
        Me.rbMale.UseVisualStyleBackColor = True
        '
        'rbFemale
        '
        Me.rbFemale.AutoSize = True
        Me.rbFemale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFemale.Location = New System.Drawing.Point(78, 376)
        Me.rbFemale.Name = "rbFemale"
        Me.rbFemale.Size = New System.Drawing.Size(80, 24)
        Me.rbFemale.TabIndex = 18
        Me.rbFemale.TabStop = True
        Me.rbFemale.Text = "Female"
        Me.rbFemale.UseVisualStyleBackColor = True
        '
        'rbOthers
        '
        Me.rbOthers.AutoSize = True
        Me.rbOthers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOthers.Location = New System.Drawing.Point(78, 411)
        Me.rbOthers.Name = "rbOthers"
        Me.rbOthers.Size = New System.Drawing.Size(195, 24)
        Me.rbOthers.TabIndex = 19
        Me.rbOthers.TabStop = True
        Me.rbOthers.Text = "Prefer not to say/Others"
        Me.rbOthers.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(427, 398)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 37)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Result:"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtpBirthday
        '
        Me.dtpBirthday.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBirthday.Location = New System.Drawing.Point(162, 203)
        Me.dtpBirthday.Name = "dtpBirthday"
        Me.dtpBirthday.Size = New System.Drawing.Size(158, 29)
        Me.dtpBirthday.TabIndex = 16
        '
        'txtRes
        '
        Me.txtRes.AutoSize = True
        Me.txtRes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRes.Location = New System.Drawing.Point(557, 407)
        Me.txtRes.Name = "txtRes"
        Me.txtRes.Size = New System.Drawing.Size(57, 20)
        Me.txtRes.TabIndex = 21
        Me.txtRes.Text = "Label9"
        '
        'lblBirthday
        '
        Me.lblBirthday.AutoSize = True
        Me.lblBirthday.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBirthday.Location = New System.Drawing.Point(255, 511)
        Me.lblBirthday.Name = "lblBirthday"
        Me.lblBirthday.Size = New System.Drawing.Size(13, 20)
        Me.lblBirthday.TabIndex = 22
        Me.lblBirthday.Text = "."
        '
        'customerDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 594)
        Me.Controls.Add(Me.lblBirthday)
        Me.Controls.Add(Me.txtRes)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rbOthers)
        Me.Controls.Add(Me.rbFemale)
        Me.Controls.Add(Me.rbMale)
        Me.Controls.Add(Me.dtpBirthday)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtboxRecords)
        Me.Controls.Add(Me.txtboxDays)
        Me.Controls.Add(Me.txtboxCarID)
        Me.Controls.Add(Me.txtboxAddress)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtboxAge)
        Me.Controls.Add(Me.txtboxName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "customerDetails"
        Me.Text = "customerDetails"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtboxName As TextBox
    Friend WithEvents txtboxAge As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtboxAddress As TextBox
    Friend WithEvents txtboxCarID As TextBox
    Friend WithEvents txtboxDays As TextBox
    Friend WithEvents txtboxRecords As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents rbMale As RadioButton
    Friend WithEvents rbFemale As RadioButton
    Friend WithEvents rbOthers As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents dtpBirthday As DateTimePicker
    Friend WithEvents txtRes As Label
    Friend WithEvents lblBirthday As Label
End Class
