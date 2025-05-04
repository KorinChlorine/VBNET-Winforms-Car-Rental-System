<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class customer_details
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
        Me.txtboxName = New System.Windows.Forms.TextBox()
        Me.txtboxAge = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtboxAddress = New System.Windows.Forms.TextBox()
        Me.txtboxCarID = New System.Windows.Forms.TextBox()
        Me.txtboxDays = New System.Windows.Forms.TextBox()
        Me.txtboxRecords = New System.Windows.Forms.TextBox()
        Me.rbMale = New System.Windows.Forms.RadioButton()
        Me.rbFemale = New System.Windows.Forms.RadioButton()
        Me.rbOthers = New System.Windows.Forms.RadioButton()
        Me.btnConfChan = New System.Windows.Forms.Button()
        Me.dtpBirthday = New System.Windows.Forms.DateTimePicker()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.btnVerifyRecords = New System.Windows.Forms.Button()
        Me.btnChanCredent = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtboxName
        '
        Me.txtboxName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtboxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxName.Location = New System.Drawing.Point(132, 120)
        Me.txtboxName.Name = "txtboxName"
        Me.txtboxName.Size = New System.Drawing.Size(320, 28)
        Me.txtboxName.TabIndex = 3
        '
        'txtboxAge
        '
        Me.txtboxAge.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtboxAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxAge.Location = New System.Drawing.Point(132, 179)
        Me.txtboxAge.Name = "txtboxAge"
        Me.txtboxAge.Size = New System.Drawing.Size(320, 28)
        Me.txtboxAge.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(972, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 24)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Address:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(864, 179)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(196, 24)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Car ID number rented:"
        '
        'txtboxAddress
        '
        Me.txtboxAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtboxAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxAddress.Location = New System.Drawing.Point(132, 240)
        Me.txtboxAddress.Name = "txtboxAddress"
        Me.txtboxAddress.Size = New System.Drawing.Size(320, 28)
        Me.txtboxAddress.TabIndex = 11
        '
        'txtboxCarID
        '
        Me.txtboxCarID.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxCarID.Location = New System.Drawing.Point(1016, 164)
        Me.txtboxCarID.Name = "txtboxCarID"
        Me.txtboxCarID.Size = New System.Drawing.Size(142, 29)
        Me.txtboxCarID.TabIndex = 12
        '
        'txtboxDays
        '
        Me.txtboxDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxDays.Location = New System.Drawing.Point(991, 335)
        Me.txtboxDays.Name = "txtboxDays"
        Me.txtboxDays.Size = New System.Drawing.Size(142, 29)
        Me.txtboxDays.TabIndex = 13
        '
        'txtboxRecords
        '
        Me.txtboxRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxRecords.Location = New System.Drawing.Point(1063, 505)
        Me.txtboxRecords.Name = "txtboxRecords"
        Me.txtboxRecords.Size = New System.Drawing.Size(142, 29)
        Me.txtboxRecords.TabIndex = 14
        '
        'rbMale
        '
        Me.rbMale.AutoSize = True
        Me.rbMale.BackColor = System.Drawing.Color.Transparent
        Me.rbMale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMale.ForeColor = System.Drawing.Color.White
        Me.rbMale.Location = New System.Drawing.Point(132, 360)
        Me.rbMale.Name = "rbMale"
        Me.rbMale.Size = New System.Drawing.Size(61, 24)
        Me.rbMale.TabIndex = 17
        Me.rbMale.TabStop = True
        Me.rbMale.Text = "Male"
        Me.rbMale.UseVisualStyleBackColor = False
        '
        'rbFemale
        '
        Me.rbFemale.AutoSize = True
        Me.rbFemale.BackColor = System.Drawing.Color.Transparent
        Me.rbFemale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFemale.ForeColor = System.Drawing.Color.White
        Me.rbFemale.Location = New System.Drawing.Point(199, 360)
        Me.rbFemale.Name = "rbFemale"
        Me.rbFemale.Size = New System.Drawing.Size(80, 24)
        Me.rbFemale.TabIndex = 18
        Me.rbFemale.TabStop = True
        Me.rbFemale.Text = "Female"
        Me.rbFemale.UseVisualStyleBackColor = False
        '
        'rbOthers
        '
        Me.rbOthers.AutoSize = True
        Me.rbOthers.BackColor = System.Drawing.Color.Transparent
        Me.rbOthers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOthers.ForeColor = System.Drawing.Color.White
        Me.rbOthers.Location = New System.Drawing.Point(284, 360)
        Me.rbOthers.Name = "rbOthers"
        Me.rbOthers.Size = New System.Drawing.Size(75, 24)
        Me.rbOthers.TabIndex = 19
        Me.rbOthers.TabStop = True
        Me.rbOthers.Text = "Others"
        Me.rbOthers.UseVisualStyleBackColor = False
        '
        'btnConfChan
        '
        Me.btnConfChan.BackColor = System.Drawing.Color.Transparent
        Me.btnConfChan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnConfChan.FlatAppearance.BorderSize = 0
        Me.btnConfChan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnConfChan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnConfChan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfChan.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfChan.Location = New System.Drawing.Point(73, 526)
        Me.btnConfChan.Name = "btnConfChan"
        Me.btnConfChan.Size = New System.Drawing.Size(350, 37)
        Me.btnConfChan.TabIndex = 20
        Me.btnConfChan.UseVisualStyleBackColor = False
        '
        'dtpBirthday
        '
        Me.dtpBirthday.CalendarMonthBackground = System.Drawing.Color.Transparent
        Me.dtpBirthday.CalendarTitleBackColor = System.Drawing.Color.Transparent
        Me.dtpBirthday.CalendarTitleForeColor = System.Drawing.Color.Transparent
        Me.dtpBirthday.CalendarTrailingForeColor = System.Drawing.Color.Transparent
        Me.dtpBirthday.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBirthday.Location = New System.Drawing.Point(125, 294)
        Me.dtpBirthday.Name = "dtpBirthday"
        Me.dtpBirthday.Size = New System.Drawing.Size(333, 29)
        Me.dtpBirthday.TabIndex = 16
        '
        'btnReturn
        '
        Me.btnReturn.BackColor = System.Drawing.Color.Transparent
        Me.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnReturn.FlatAppearance.BorderSize = 0
        Me.btnReturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnReturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturn.Location = New System.Drawing.Point(378, 39)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(74, 26)
        Me.btnReturn.TabIndex = 23
        Me.btnReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReturn.UseVisualStyleBackColor = False
        '
        'btnVerifyRecords
        '
        Me.btnVerifyRecords.BackColor = System.Drawing.Color.Transparent
        Me.btnVerifyRecords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnVerifyRecords.FlatAppearance.BorderSize = 0
        Me.btnVerifyRecords.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnVerifyRecords.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnVerifyRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerifyRecords.Location = New System.Drawing.Point(107, 423)
        Me.btnVerifyRecords.Name = "btnVerifyRecords"
        Me.btnVerifyRecords.Size = New System.Drawing.Size(275, 46)
        Me.btnVerifyRecords.TabIndex = 24
        Me.btnVerifyRecords.UseVisualStyleBackColor = False
        '
        'btnChanCredent
        '
        Me.btnChanCredent.BackColor = System.Drawing.Color.Transparent
        Me.btnChanCredent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnChanCredent.FlatAppearance.BorderSize = 0
        Me.btnChanCredent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnChanCredent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnChanCredent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChanCredent.Location = New System.Drawing.Point(163, 469)
        Me.btnChanCredent.Name = "btnChanCredent"
        Me.btnChanCredent.Size = New System.Drawing.Size(167, 38)
        Me.btnChanCredent.TabIndex = 25
        Me.btnChanCredent.UseVisualStyleBackColor = False
        '
        'customer_details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.VBNET_Car_Rental_System.My.Resources.Resources.Customer_Deets
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(491, 594)
        Me.Controls.Add(Me.btnChanCredent)
        Me.Controls.Add(Me.btnVerifyRecords)
        Me.Controls.Add(Me.btnReturn)
        Me.Controls.Add(Me.btnConfChan)
        Me.Controls.Add(Me.rbOthers)
        Me.Controls.Add(Me.rbFemale)
        Me.Controls.Add(Me.rbMale)
        Me.Controls.Add(Me.dtpBirthday)
        Me.Controls.Add(Me.txtboxRecords)
        Me.Controls.Add(Me.txtboxDays)
        Me.Controls.Add(Me.txtboxCarID)
        Me.Controls.Add(Me.txtboxAddress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtboxAge)
        Me.Controls.Add(Me.txtboxName)
        Me.DoubleBuffered = True
        Me.Name = "customer_details"
        Me.Text = "customer-details"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtboxName As TextBox
    Friend WithEvents txtboxAge As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtboxAddress As TextBox
    Friend WithEvents txtboxCarID As TextBox
    Friend WithEvents txtboxDays As TextBox
    Friend WithEvents txtboxRecords As TextBox
    Friend WithEvents rbMale As RadioButton
    Friend WithEvents rbFemale As RadioButton
    Friend WithEvents rbOthers As RadioButton
    Friend WithEvents btnConfChan As Button
    Friend WithEvents dtpBirthday As DateTimePicker
    Friend WithEvents btnReturn As Button
    Friend WithEvents btnVerifyRecords As Button
    Friend WithEvents btnChanCredent As Button
End Class
