<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConfirmationRent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfirmationRent))
        Me.lblCarName = New System.Windows.Forms.Label()
        Me.lblCarID = New System.Windows.Forms.Label()
        Me.lblRentedStarted = New System.Windows.Forms.Label()
        Me.lblRentedEnded = New System.Windows.Forms.Label()
        Me.lblDaysToBeRented = New System.Windows.Forms.Label()
        Me.lblTransactionType = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPaymentPerDay = New System.Windows.Forms.Label()
        Me.lblTotalPayment = New System.Windows.Forms.Label()
        Me.lblCurrentBalance = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RoundedButton3 = New VBNET_Car_Rental_System.RoundedButton()
        Me.btnCancel = New VBNET_Car_Rental_System.RoundedButton()
        Me.btnConfirmPayment = New VBNET_Car_Rental_System.RoundedButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCarName
        '
        Me.lblCarName.AutoSize = True
        Me.lblCarName.BackColor = System.Drawing.Color.Transparent
        Me.lblCarName.Font = New System.Drawing.Font("League Spartan ExtraBold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarName.ForeColor = System.Drawing.Color.White
        Me.lblCarName.Location = New System.Drawing.Point(5, 16)
        Me.lblCarName.Name = "lblCarName"
        Me.lblCarName.Size = New System.Drawing.Size(126, 36)
        Me.lblCarName.TabIndex = 2
        Me.lblCarName.Text = "Car Name"
        '
        'lblCarID
        '
        Me.lblCarID.AutoSize = True
        Me.lblCarID.BackColor = System.Drawing.Color.Transparent
        Me.lblCarID.Font = New System.Drawing.Font("League Spartan ExtraBold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarID.ForeColor = System.Drawing.Color.White
        Me.lblCarID.Location = New System.Drawing.Point(13, 424)
        Me.lblCarID.Name = "lblCarID"
        Me.lblCarID.Size = New System.Drawing.Size(39, 17)
        Me.lblCarID.TabIndex = 3
        Me.lblCarID.Text = "Car ID"
        '
        'lblRentedStarted
        '
        Me.lblRentedStarted.AutoSize = True
        Me.lblRentedStarted.BackColor = System.Drawing.Color.Transparent
        Me.lblRentedStarted.Font = New System.Drawing.Font("League Spartan ExtraBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRentedStarted.ForeColor = System.Drawing.Color.White
        Me.lblRentedStarted.Location = New System.Drawing.Point(26, 148)
        Me.lblRentedStarted.Name = "lblRentedStarted"
        Me.lblRentedStarted.Size = New System.Drawing.Size(114, 23)
        Me.lblRentedStarted.TabIndex = 4
        Me.lblRentedStarted.Text = "RentedStarted"
        '
        'lblRentedEnded
        '
        Me.lblRentedEnded.AutoSize = True
        Me.lblRentedEnded.BackColor = System.Drawing.Color.Transparent
        Me.lblRentedEnded.Font = New System.Drawing.Font("League Spartan ExtraBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRentedEnded.ForeColor = System.Drawing.Color.White
        Me.lblRentedEnded.Location = New System.Drawing.Point(26, 171)
        Me.lblRentedEnded.Name = "lblRentedEnded"
        Me.lblRentedEnded.Size = New System.Drawing.Size(104, 23)
        Me.lblRentedEnded.TabIndex = 6
        Me.lblRentedEnded.Text = "RentedEnded"
        '
        'lblDaysToBeRented
        '
        Me.lblDaysToBeRented.AutoSize = True
        Me.lblDaysToBeRented.BackColor = System.Drawing.Color.Transparent
        Me.lblDaysToBeRented.Font = New System.Drawing.Font("League Spartan ExtraBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDaysToBeRented.ForeColor = System.Drawing.Color.White
        Me.lblDaysToBeRented.Location = New System.Drawing.Point(26, 194)
        Me.lblDaysToBeRented.Name = "lblDaysToBeRented"
        Me.lblDaysToBeRented.Size = New System.Drawing.Size(135, 23)
        Me.lblDaysToBeRented.TabIndex = 7
        Me.lblDaysToBeRented.Text = "Days to be rented"
        '
        'lblTransactionType
        '
        Me.lblTransactionType.AutoSize = True
        Me.lblTransactionType.BackColor = System.Drawing.Color.Transparent
        Me.lblTransactionType.Font = New System.Drawing.Font("League Spartan ExtraBold", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionType.ForeColor = System.Drawing.Color.Yellow
        Me.lblTransactionType.Location = New System.Drawing.Point(20, 14)
        Me.lblTransactionType.Name = "lblTransactionType"
        Me.lblTransactionType.Size = New System.Drawing.Size(214, 60)
        Me.lblTransactionType.TabIndex = 8
        Me.lblTransactionType.Text = "Rent/Book"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.lblCarName)
        Me.Panel1.Location = New System.Drawing.Point(16, 77)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(218, 68)
        Me.Panel1.TabIndex = 9
        '
        'lblPaymentPerDay
        '
        Me.lblPaymentPerDay.AutoSize = True
        Me.lblPaymentPerDay.BackColor = System.Drawing.Color.Transparent
        Me.lblPaymentPerDay.Font = New System.Drawing.Font("League Spartan ExtraBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentPerDay.ForeColor = System.Drawing.Color.White
        Me.lblPaymentPerDay.Location = New System.Drawing.Point(26, 232)
        Me.lblPaymentPerDay.Name = "lblPaymentPerDay"
        Me.lblPaymentPerDay.Size = New System.Drawing.Size(131, 23)
        Me.lblPaymentPerDay.TabIndex = 10
        Me.lblPaymentPerDay.Text = "Payment per day"
        '
        'lblTotalPayment
        '
        Me.lblTotalPayment.AutoSize = True
        Me.lblTotalPayment.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalPayment.Font = New System.Drawing.Font("League Spartan ExtraBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPayment.ForeColor = System.Drawing.Color.White
        Me.lblTotalPayment.Location = New System.Drawing.Point(26, 255)
        Me.lblTotalPayment.Name = "lblTotalPayment"
        Me.lblTotalPayment.Size = New System.Drawing.Size(110, 23)
        Me.lblTotalPayment.TabIndex = 11
        Me.lblTotalPayment.Text = "Total Payment"
        '
        'lblCurrentBalance
        '
        Me.lblCurrentBalance.AutoSize = True
        Me.lblCurrentBalance.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentBalance.Font = New System.Drawing.Font("League Spartan ExtraBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentBalance.ForeColor = System.Drawing.Color.White
        Me.lblCurrentBalance.Location = New System.Drawing.Point(26, 278)
        Me.lblCurrentBalance.Name = "lblCurrentBalance"
        Me.lblCurrentBalance.Size = New System.Drawing.Size(125, 23)
        Me.lblCurrentBalance.TabIndex = 12
        Me.lblCurrentBalance.Text = "Current Balance"
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomer.Font = New System.Drawing.Font("League Spartan ExtraBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.ForeColor = System.Drawing.Color.White
        Me.lblCustomer.Location = New System.Drawing.Point(3, 0)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(78, 23)
        Me.lblCustomer.TabIndex = 14
        Me.lblCustomer.Text = "Customer"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblCustomer)
        Me.Panel2.Location = New System.Drawing.Point(23, 304)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 62)
        Me.Panel2.TabIndex = 15
        '
        'RoundedButton3
        '
        Me.RoundedButton3.BackColor = System.Drawing.Color.White
        Me.RoundedButton3.FlatAppearance.BorderSize = 0
        Me.RoundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton3.Font = New System.Drawing.Font("League Spartan ExtraBold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RoundedButton3.Location = New System.Drawing.Point(28, 383)
        Me.RoundedButton3.Name = "RoundedButton3"
        Me.RoundedButton3.Size = New System.Drawing.Size(207, 35)
        Me.RoundedButton3.TabIndex = 13
        Me.RoundedButton3.Text = "Go to Billing"
        Me.RoundedButton3.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Crimson
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("League Spartan ExtraBold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(683, 383)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 56)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnConfirmPayment
        '
        Me.btnConfirmPayment.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.btnConfirmPayment.FlatAppearance.BorderSize = 0
        Me.btnConfirmPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfirmPayment.Font = New System.Drawing.Font("League Spartan ExtraBold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmPayment.ForeColor = System.Drawing.Color.White
        Me.btnConfirmPayment.Location = New System.Drawing.Point(421, 383)
        Me.btnConfirmPayment.Name = "btnConfirmPayment"
        Me.btnConfirmPayment.Size = New System.Drawing.Size(256, 56)
        Me.btnConfirmPayment.TabIndex = 1
        Me.btnConfirmPayment.Text = "Confirm Payment"
        Me.btnConfirmPayment.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.VBNET_Car_Rental_System.My.Resources.Resources.Logo_5
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(671, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(117, 108)
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(254, -8)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(552, 512)
        Me.AxWindowsMediaPlayer1.TabIndex = 0
        '
        'ConfirmationRent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.RoundedButton3)
        Me.Controls.Add(Me.lblCurrentBalance)
        Me.Controls.Add(Me.lblTotalPayment)
        Me.Controls.Add(Me.lblPaymentPerDay)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTransactionType)
        Me.Controls.Add(Me.lblDaysToBeRented)
        Me.Controls.Add(Me.lblRentedEnded)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblRentedStarted)
        Me.Controls.Add(Me.lblCarID)
        Me.Controls.Add(Me.btnConfirmPayment)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Name = "ConfirmationRent"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "ConfirmationRent"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents btnConfirmPayment As RoundedButton
    Friend WithEvents lblCarName As Label
    Friend WithEvents lblCarID As Label
    Friend WithEvents lblRentedStarted As Label
    Friend WithEvents btnCancel As RoundedButton
    Friend WithEvents lblRentedEnded As Label
    Friend WithEvents lblDaysToBeRented As Label
    Friend WithEvents lblTransactionType As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblPaymentPerDay As Label
    Friend WithEvents lblTotalPayment As Label
    Friend WithEvents lblCurrentBalance As Label
    Friend WithEvents RoundedButton3 As RoundedButton
    Friend WithEvents lblCustomer As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
