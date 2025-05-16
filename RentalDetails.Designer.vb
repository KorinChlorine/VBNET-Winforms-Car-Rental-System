<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RentalDetail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCarCapacity = New System.Windows.Forms.Label()
        Me.lblCarType = New System.Windows.Forms.Label()
        Me.lblCarColor = New System.Windows.Forms.Label()
        Me.lblPlateNumber = New System.Windows.Forms.Label()
        Me.lblBodyNumber = New System.Windows.Forms.Label()
        Me.lblCarID = New System.Windows.Forms.Label()
        Me.lblPaymentTotal = New System.Windows.Forms.Label()
        Me.lblRentStatus = New System.Windows.Forms.Label()
        Me.lblPaymentPerDay = New System.Windows.Forms.Label()
        Me.lblRentEnd = New System.Windows.Forms.Label()
        Me.lblRentStart = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblCustomerEmail = New System.Windows.Forms.Label()
        Me.lblCustomerName = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblCarDescription = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblTimeLeft = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblReturnedStatus = New System.Windows.Forms.Label()
        Me.DraggablePanel1 = New VBNET_Car_Rental_System.DraggablePanel()
        Me.minimize = New System.Windows.Forms.Button()
        Me.closeForm = New System.Windows.Forms.Button()
        Me.setting = New System.Windows.Forms.Button()
        Me.bills = New System.Windows.Forms.Button()
        Me.history = New System.Windows.Forms.Button()
        Me.details = New System.Windows.Forms.Button()
        Me.rent = New System.Windows.Forms.Button()
        Me.home = New System.Windows.Forms.Button()
        Me.logout = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(127, 165)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(204, 485)
        Me.FlowLayoutPanel1.TabIndex = 13
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(364, 103)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(248, 144)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(638, 103)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(598, 144)
        Me.Panel1.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("League Spartan ExtraBold", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(15, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 120)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("League Spartan ExtraBold", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(431, 298)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Rent Info"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("League Spartan ExtraBold", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(703, 298)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 32)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Customer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("League Spartan ExtraBold", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1020, 298)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 32)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Description"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.lblCarCapacity)
        Me.Panel2.Controls.Add(Me.lblCarType)
        Me.Panel2.Controls.Add(Me.lblCarColor)
        Me.Panel2.Controls.Add(Me.lblPlateNumber)
        Me.Panel2.Controls.Add(Me.lblBodyNumber)
        Me.Panel2.Controls.Add(Me.lblCarID)
        Me.Panel2.Controls.Add(Me.lblPaymentTotal)
        Me.Panel2.Controls.Add(Me.lblRentStatus)
        Me.Panel2.Controls.Add(Me.lblPaymentPerDay)
        Me.Panel2.Controls.Add(Me.lblRentEnd)
        Me.Panel2.Controls.Add(Me.lblRentStart)
        Me.Panel2.Location = New System.Drawing.Point(373, 333)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(226, 302)
        Me.Panel2.TabIndex = 18
        '
        'lblCarCapacity
        '
        Me.lblCarCapacity.AutoSize = True
        Me.lblCarCapacity.BackColor = System.Drawing.Color.Transparent
        Me.lblCarCapacity.Font = New System.Drawing.Font("League Spartan", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarCapacity.ForeColor = System.Drawing.Color.White
        Me.lblCarCapacity.Location = New System.Drawing.Point(3, 132)
        Me.lblCarCapacity.Name = "lblCarCapacity"
        Me.lblCarCapacity.Size = New System.Drawing.Size(10, 44)
        Me.lblCarCapacity.TabIndex = 31
        Me.lblCarCapacity.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblCarType
        '
        Me.lblCarType.AutoSize = True
        Me.lblCarType.BackColor = System.Drawing.Color.Transparent
        Me.lblCarType.Font = New System.Drawing.Font("League Spartan", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarType.ForeColor = System.Drawing.Color.White
        Me.lblCarType.Location = New System.Drawing.Point(3, 106)
        Me.lblCarType.Name = "lblCarType"
        Me.lblCarType.Size = New System.Drawing.Size(10, 44)
        Me.lblCarType.TabIndex = 30
        Me.lblCarType.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblCarColor
        '
        Me.lblCarColor.AutoSize = True
        Me.lblCarColor.BackColor = System.Drawing.Color.Transparent
        Me.lblCarColor.Font = New System.Drawing.Font("League Spartan", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarColor.ForeColor = System.Drawing.Color.White
        Me.lblCarColor.Location = New System.Drawing.Point(3, 78)
        Me.lblCarColor.Name = "lblCarColor"
        Me.lblCarColor.Size = New System.Drawing.Size(10, 44)
        Me.lblCarColor.TabIndex = 29
        Me.lblCarColor.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblPlateNumber
        '
        Me.lblPlateNumber.AutoSize = True
        Me.lblPlateNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblPlateNumber.Font = New System.Drawing.Font("League Spartan", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlateNumber.ForeColor = System.Drawing.Color.White
        Me.lblPlateNumber.Location = New System.Drawing.Point(3, 54)
        Me.lblPlateNumber.Name = "lblPlateNumber"
        Me.lblPlateNumber.Size = New System.Drawing.Size(10, 44)
        Me.lblPlateNumber.TabIndex = 28
        Me.lblPlateNumber.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblBodyNumber
        '
        Me.lblBodyNumber.AutoSize = True
        Me.lblBodyNumber.BackColor = System.Drawing.Color.Transparent
        Me.lblBodyNumber.Font = New System.Drawing.Font("League Spartan", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBodyNumber.ForeColor = System.Drawing.Color.White
        Me.lblBodyNumber.Location = New System.Drawing.Point(3, 28)
        Me.lblBodyNumber.Name = "lblBodyNumber"
        Me.lblBodyNumber.Size = New System.Drawing.Size(10, 44)
        Me.lblBodyNumber.TabIndex = 27
        Me.lblBodyNumber.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblCarID
        '
        Me.lblCarID.AutoSize = True
        Me.lblCarID.BackColor = System.Drawing.Color.Transparent
        Me.lblCarID.Font = New System.Drawing.Font("League Spartan", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarID.ForeColor = System.Drawing.Color.White
        Me.lblCarID.Location = New System.Drawing.Point(3, 0)
        Me.lblCarID.Name = "lblCarID"
        Me.lblCarID.Size = New System.Drawing.Size(10, 44)
        Me.lblCarID.TabIndex = 26
        Me.lblCarID.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblPaymentTotal
        '
        Me.lblPaymentTotal.AutoSize = True
        Me.lblPaymentTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblPaymentTotal.Font = New System.Drawing.Font("League Spartan", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentTotal.ForeColor = System.Drawing.Color.White
        Me.lblPaymentTotal.Location = New System.Drawing.Point(3, 239)
        Me.lblPaymentTotal.Name = "lblPaymentTotal"
        Me.lblPaymentTotal.Size = New System.Drawing.Size(10, 44)
        Me.lblPaymentTotal.TabIndex = 25
        Me.lblPaymentTotal.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblRentStatus
        '
        Me.lblRentStatus.AutoSize = True
        Me.lblRentStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblRentStatus.Font = New System.Drawing.Font("League Spartan", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRentStatus.ForeColor = System.Drawing.Color.White
        Me.lblRentStatus.Location = New System.Drawing.Point(3, 267)
        Me.lblRentStatus.Name = "lblRentStatus"
        Me.lblRentStatus.Size = New System.Drawing.Size(10, 44)
        Me.lblRentStatus.TabIndex = 24
        Me.lblRentStatus.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblPaymentPerDay
        '
        Me.lblPaymentPerDay.AutoSize = True
        Me.lblPaymentPerDay.BackColor = System.Drawing.Color.Transparent
        Me.lblPaymentPerDay.Font = New System.Drawing.Font("League Spartan", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaymentPerDay.ForeColor = System.Drawing.Color.White
        Me.lblPaymentPerDay.Location = New System.Drawing.Point(3, 211)
        Me.lblPaymentPerDay.Name = "lblPaymentPerDay"
        Me.lblPaymentPerDay.Size = New System.Drawing.Size(10, 44)
        Me.lblPaymentPerDay.TabIndex = 23
        Me.lblPaymentPerDay.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblRentEnd
        '
        Me.lblRentEnd.AutoSize = True
        Me.lblRentEnd.BackColor = System.Drawing.Color.Transparent
        Me.lblRentEnd.Font = New System.Drawing.Font("League Spartan", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRentEnd.ForeColor = System.Drawing.Color.White
        Me.lblRentEnd.Location = New System.Drawing.Point(3, 183)
        Me.lblRentEnd.Name = "lblRentEnd"
        Me.lblRentEnd.Size = New System.Drawing.Size(10, 44)
        Me.lblRentEnd.TabIndex = 22
        Me.lblRentEnd.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblRentStart
        '
        Me.lblRentStart.AutoSize = True
        Me.lblRentStart.BackColor = System.Drawing.Color.Transparent
        Me.lblRentStart.Font = New System.Drawing.Font("League Spartan", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRentStart.ForeColor = System.Drawing.Color.White
        Me.lblRentStart.Location = New System.Drawing.Point(3, 155)
        Me.lblRentStart.Name = "lblRentStart"
        Me.lblRentStart.Size = New System.Drawing.Size(10, 44)
        Me.lblRentStart.TabIndex = 21
        Me.lblRentStart.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.lblCustomerEmail)
        Me.Panel3.Controls.Add(Me.lblCustomerName)
        Me.Panel3.Location = New System.Drawing.Point(645, 325)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(226, 99)
        Me.Panel3.TabIndex = 19
        '
        'lblCustomerEmail
        '
        Me.lblCustomerEmail.AutoSize = True
        Me.lblCustomerEmail.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomerEmail.Font = New System.Drawing.Font("League Spartan ExtraBold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerEmail.ForeColor = System.Drawing.Color.White
        Me.lblCustomerEmail.Location = New System.Drawing.Point(14, 41)
        Me.lblCustomerEmail.Name = "lblCustomerEmail"
        Me.lblCustomerEmail.Size = New System.Drawing.Size(10, 44)
        Me.lblCustomerEmail.TabIndex = 27
        Me.lblCustomerEmail.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblCustomerName
        '
        Me.lblCustomerName.AutoSize = True
        Me.lblCustomerName.BackColor = System.Drawing.Color.Transparent
        Me.lblCustomerName.Font = New System.Drawing.Font("League Spartan ExtraBold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerName.ForeColor = System.Drawing.Color.White
        Me.lblCustomerName.Location = New System.Drawing.Point(14, 8)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(10, 44)
        Me.lblCustomerName.TabIndex = 26
        Me.lblCustomerName.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.AutoScroll = True
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.lblCarDescription)
        Me.Panel4.Location = New System.Drawing.Point(916, 333)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(320, 317)
        Me.Panel4.TabIndex = 20
        '
        'lblCarDescription
        '
        Me.lblCarDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCarDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblCarDescription.Font = New System.Drawing.Font("League Spartan Medium", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarDescription.ForeColor = System.Drawing.Color.White
        Me.lblCarDescription.Location = New System.Drawing.Point(0, 0)
        Me.lblCarDescription.Name = "lblCarDescription"
        Me.lblCarDescription.Size = New System.Drawing.Size(317, 317)
        Me.lblCarDescription.TabIndex = 28
        Me.lblCarDescription.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(1154, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 34)
        Me.Button1.TabIndex = 21
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblTimeLeft
        '
        Me.lblTimeLeft.BackColor = System.Drawing.Color.Transparent
        Me.lblTimeLeft.Font = New System.Drawing.Font("League Spartan Black", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeLeft.ForeColor = System.Drawing.Color.White
        Me.lblTimeLeft.Location = New System.Drawing.Point(617, 516)
        Me.lblTimeLeft.Name = "lblTimeLeft"
        Me.lblTimeLeft.Size = New System.Drawing.Size(288, 74)
        Me.lblTimeLeft.TabIndex = 22
        Me.lblTimeLeft.Text = "00:00:00:00"
        Me.lblTimeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("League Spartan ExtraBold", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(162, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 32)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Rented Cars"
        '
        'lblReturnedStatus
        '
        Me.lblReturnedStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblReturnedStatus.Font = New System.Drawing.Font("League Spartan ExtraBold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReturnedStatus.ForeColor = System.Drawing.Color.White
        Me.lblReturnedStatus.Location = New System.Drawing.Point(638, 590)
        Me.lblReturnedStatus.Name = "lblReturnedStatus"
        Me.lblReturnedStatus.Size = New System.Drawing.Size(241, 28)
        Me.lblReturnedStatus.TabIndex = 24
        Me.lblReturnedStatus.Text = "Not returned yet"
        Me.lblReturnedStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DraggablePanel1
        '
        Me.DraggablePanel1.BackColor = System.Drawing.Color.Transparent
        Me.DraggablePanel1.Location = New System.Drawing.Point(1, 3)
        Me.DraggablePanel1.Name = "DraggablePanel1"
        Me.DraggablePanel1.Size = New System.Drawing.Size(1203, 26)
        Me.DraggablePanel1.TabIndex = 53
        '
        'minimize
        '
        Me.minimize.BackColor = System.Drawing.Color.Transparent
        Me.minimize.FlatAppearance.BorderSize = 0
        Me.minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.minimize.Location = New System.Drawing.Point(1219, 3)
        Me.minimize.Name = "minimize"
        Me.minimize.Size = New System.Drawing.Size(22, 27)
        Me.minimize.TabIndex = 58
        Me.minimize.UseVisualStyleBackColor = False
        '
        'closeForm
        '
        Me.closeForm.BackColor = System.Drawing.Color.Transparent
        Me.closeForm.FlatAppearance.BorderSize = 0
        Me.closeForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.closeForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeForm.Location = New System.Drawing.Point(1239, 3)
        Me.closeForm.Name = "closeForm"
        Me.closeForm.Size = New System.Drawing.Size(22, 27)
        Me.closeForm.TabIndex = 57
        Me.closeForm.UseVisualStyleBackColor = False
        '
        'setting
        '
        Me.setting.BackColor = System.Drawing.Color.Transparent
        Me.setting.FlatAppearance.BorderSize = 0
        Me.setting.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.setting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.setting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.setting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.setting.Location = New System.Drawing.Point(22, 529)
        Me.setting.Name = "setting"
        Me.setting.Size = New System.Drawing.Size(64, 40)
        Me.setting.TabIndex = 65
        Me.setting.UseVisualStyleBackColor = False
        '
        'bills
        '
        Me.bills.BackColor = System.Drawing.Color.Transparent
        Me.bills.FlatAppearance.BorderSize = 0
        Me.bills.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.bills.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.bills.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.bills.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bills.Location = New System.Drawing.Point(20, 294)
        Me.bills.Name = "bills"
        Me.bills.Size = New System.Drawing.Size(64, 40)
        Me.bills.TabIndex = 64
        Me.bills.UseVisualStyleBackColor = False
        '
        'history
        '
        Me.history.BackColor = System.Drawing.Color.Transparent
        Me.history.FlatAppearance.BorderSize = 0
        Me.history.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.history.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.history.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.history.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.history.Location = New System.Drawing.Point(21, 238)
        Me.history.Name = "history"
        Me.history.Size = New System.Drawing.Size(64, 40)
        Me.history.TabIndex = 63
        Me.history.UseVisualStyleBackColor = False
        '
        'details
        '
        Me.details.BackColor = System.Drawing.Color.Transparent
        Me.details.FlatAppearance.BorderSize = 0
        Me.details.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.details.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.details.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.details.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.details.Location = New System.Drawing.Point(20, 177)
        Me.details.Name = "details"
        Me.details.Size = New System.Drawing.Size(64, 41)
        Me.details.TabIndex = 62
        Me.details.UseVisualStyleBackColor = False
        '
        'rent
        '
        Me.rent.BackColor = System.Drawing.Color.Transparent
        Me.rent.FlatAppearance.BorderSize = 0
        Me.rent.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.rent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.rent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.rent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rent.Location = New System.Drawing.Point(19, 113)
        Me.rent.Name = "rent"
        Me.rent.Size = New System.Drawing.Size(64, 52)
        Me.rent.TabIndex = 61
        Me.rent.UseVisualStyleBackColor = False
        '
        'home
        '
        Me.home.BackColor = System.Drawing.Color.Transparent
        Me.home.FlatAppearance.BorderSize = 0
        Me.home.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.home.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.home.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.home.ForeColor = System.Drawing.Color.Transparent
        Me.home.Location = New System.Drawing.Point(22, 59)
        Me.home.Name = "home"
        Me.home.Size = New System.Drawing.Size(64, 39)
        Me.home.TabIndex = 60
        Me.home.UseVisualStyleBackColor = False
        '
        'logout
        '
        Me.logout.BackColor = System.Drawing.Color.Transparent
        Me.logout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.logout.FlatAppearance.BorderSize = 0
        Me.logout.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.logout.Location = New System.Drawing.Point(21, 583)
        Me.logout.Name = "logout"
        Me.logout.Size = New System.Drawing.Size(64, 47)
        Me.logout.TabIndex = 59
        Me.logout.UseVisualStyleBackColor = False
        '
        'RentalDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.VBNET_Car_Rental_System.My.Resources.Resources.Rental_Details1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.ControlBox = False
        Me.Controls.Add(Me.setting)
        Me.Controls.Add(Me.bills)
        Me.Controls.Add(Me.history)
        Me.Controls.Add(Me.details)
        Me.Controls.Add(Me.rent)
        Me.Controls.Add(Me.home)
        Me.Controls.Add(Me.logout)
        Me.Controls.Add(Me.minimize)
        Me.Controls.Add(Me.closeForm)
        Me.Controls.Add(Me.DraggablePanel1)
        Me.Controls.Add(Me.lblReturnedStatus)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblTimeLeft)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RentalDetail"
        Me.Text = "RentalDetails"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblRentStart As Label
    Friend WithEvents lblCarID As Label
    Friend WithEvents lblPaymentTotal As Label
    Friend WithEvents lblRentStatus As Label
    Friend WithEvents lblPaymentPerDay As Label
    Friend WithEvents lblRentEnd As Label
    Friend WithEvents lblCustomerEmail As Label
    Friend WithEvents lblCustomerName As Label
    Friend WithEvents lblCarDescription As Label
    Friend WithEvents lblCarCapacity As Label
    Friend WithEvents lblCarType As Label
    Friend WithEvents lblCarColor As Label
    Friend WithEvents lblPlateNumber As Label
    Friend WithEvents lblBodyNumber As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblTimeLeft As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblReturnedStatus As Label
    Friend WithEvents DraggablePanel1 As DraggablePanel
    Friend WithEvents minimize As Button
    Friend WithEvents closeForm As Button
    Friend WithEvents setting As Button
    Friend WithEvents bills As Button
    Friend WithEvents history As Button
    Friend WithEvents details As Button
    Friend WithEvents rent As Button
    Friend WithEvents home As Button
    Friend WithEvents logout As Button
End Class
