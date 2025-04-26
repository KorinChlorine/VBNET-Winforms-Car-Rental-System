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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
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
        Me.txtRes = New System.Windows.Forms.Label()
        Me.lblBirthday = New System.Windows.Forms.Label()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.btnVerifyRecords = New System.Windows.Forms.Button()
        Me.btnChanCredent = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtboxName
        '
        Me.txtboxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxName.Location = New System.Drawing.Point(132, 117)
        Me.txtboxName.Name = "txtboxName"
        Me.txtboxName.Size = New System.Drawing.Size(320, 29)
        Me.txtboxName.TabIndex = 3
        '
        'txtboxAge
        '
        Me.txtboxAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxAge.Location = New System.Drawing.Point(132, 183)
        Me.txtboxAge.Name = "txtboxAge"
        Me.txtboxAge.Size = New System.Drawing.Size(320, 29)
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
        Me.txtboxAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtboxAddress.Location = New System.Drawing.Point(132, 252)
        Me.txtboxAddress.Name = "txtboxAddress"
        Me.txtboxAddress.Size = New System.Drawing.Size(320, 29)
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
        Me.rbMale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbMale.Location = New System.Drawing.Point(131, 314)
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
        Me.rbFemale.Location = New System.Drawing.Point(198, 314)
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
        Me.rbOthers.Location = New System.Drawing.Point(284, 314)
        Me.rbOthers.Name = "rbOthers"
        Me.rbOthers.Size = New System.Drawing.Size(195, 24)
        Me.rbOthers.TabIndex = 19
        Me.rbOthers.TabStop = True
        Me.rbOthers.Text = "Prefer not to say/Others"
        Me.rbOthers.UseVisualStyleBackColor = True
        '
        'btnConfChan
        '
        Me.btnConfChan.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfChan.Location = New System.Drawing.Point(77, 513)
        Me.btnConfChan.Name = "btnConfChan"
        Me.btnConfChan.Size = New System.Drawing.Size(333, 37)
        Me.btnConfChan.TabIndex = 20
        Me.btnConfChan.Text = "Confirm Changes"
        Me.btnConfChan.UseVisualStyleBackColor = True
        '
        'dtpBirthday
        '
        Me.dtpBirthday.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBirthday.Location = New System.Drawing.Point(-6, 565)
        Me.dtpBirthday.Name = "dtpBirthday"
        Me.dtpBirthday.Size = New System.Drawing.Size(158, 29)
        Me.dtpBirthday.TabIndex = 16
        '
        'txtRes
        '
        Me.txtRes.AutoSize = True
        Me.txtRes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRes.Location = New System.Drawing.Point(2, 530)
        Me.txtRes.Name = "txtRes"
        Me.txtRes.Size = New System.Drawing.Size(57, 20)
        Me.txtRes.TabIndex = 21
        Me.txtRes.Text = "Label9"
        '
        'lblBirthday
        '
        Me.lblBirthday.AutoSize = True
        Me.lblBirthday.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBirthday.Location = New System.Drawing.Point(12, 510)
        Me.lblBirthday.Name = "lblBirthday"
        Me.lblBirthday.Size = New System.Drawing.Size(13, 20)
        Me.lblBirthday.TabIndex = 22
        Me.lblBirthday.Text = "."
        '
        'btnReturn
        '
        Me.btnReturn.Location = New System.Drawing.Point(377, 53)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(75, 23)
        Me.btnReturn.TabIndex = 23
        Me.btnReturn.Text = "Return"
        Me.btnReturn.UseVisualStyleBackColor = True
        '
        'btnVerifyRecords
        '
        Me.btnVerifyRecords.Location = New System.Drawing.Point(107, 367)
        Me.btnVerifyRecords.Name = "btnVerifyRecords"
        Me.btnVerifyRecords.Size = New System.Drawing.Size(277, 23)
        Me.btnVerifyRecords.TabIndex = 24
        Me.btnVerifyRecords.Text = "Verify Records"
        Me.btnVerifyRecords.UseVisualStyleBackColor = True
        '
        'btnChanCredent
        '
        Me.btnChanCredent.Location = New System.Drawing.Point(162, 435)
        Me.btnChanCredent.Name = "btnChanCredent"
        Me.btnChanCredent.Size = New System.Drawing.Size(163, 23)
        Me.btnChanCredent.TabIndex = 25
        Me.btnChanCredent.Text = "Change Credentials"
        Me.btnChanCredent.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(491, 594)
        Me.Controls.Add(Me.btnChanCredent)
        Me.Controls.Add(Me.btnVerifyRecords)
        Me.Controls.Add(Me.btnReturn)
        Me.Controls.Add(Me.lblBirthday)
        Me.Controls.Add(Me.txtRes)
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
        Me.Name = "Form1"
        Me.Text = "Form1"
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
    Friend WithEvents txtRes As Label
    Friend WithEvents lblBirthday As Label
    Friend WithEvents btnReturn As Button
    Friend WithEvents btnVerifyRecords As Button
    Friend WithEvents btnChanCredent As Button
End Class
