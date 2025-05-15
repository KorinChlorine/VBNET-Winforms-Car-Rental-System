Public Class homeForm

    Private Async Sub homeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Check user access
        If GlobalData.var = "!Allowed" OrElse GlobalData.var Is Nothing Or GlobalData.IsGoodRecord = False Then
            Label1.Visible = False
            Label2.Visible = False
            Button3.Visible = True
            Button3.Enabled = True
        Else
            Label1.Visible = True
            Label2.Visible = True
            Button3.Visible = False
            Button3.Enabled = False

            ' Ensure UserFullName is displayed
            If String.IsNullOrEmpty(GlobalData.UserFullName) Then
                Label1.Text = "Guest"
            Else
                Label1.Text = GlobalData.UserFullName
            End If
        End If

        ' Clear and load recent premium cars
        Panel1.Controls.Clear()
        Dim panelYPosition As Integer = 10
        Dim recentPremiumCars = GlobalData.PremiumCarsArray.Take(5).ToList()

        For Each carId In recentPremiumCars
            If Not GlobalData.CarsDict.ContainsKey(carId) Then Continue For
            Dim carDict = GlobalData.CarsDict(carId)

            Dim carPanel As New Panel With {
                .Size = New Size(240, 65),
                .Location = New Point(10, panelYPosition),
                .BackColor = Color.Transparent
            }

            Dim carPictureBox As New PictureBox With {
                .Size = New Size(60, 60),
                .Location = New Point(5, 4),
                .SizeMode = PictureBoxSizeMode.StretchImage
            }

            ' Load image asynchronously
            Dim carImage = Await Task.Run(Function() TryCast(carDict("PrimaryImage"), Image))
            If carImage IsNot Nothing Then
                carPictureBox.Image = carImage
            End If

            AddHandler carPictureBox.Paint, AddressOf PictureBox_Paint
            carPanel.Controls.Add(carPictureBox)

            Dim carLabel As New Label With {
                .Text = carDict("CarName").ToString(),
                .Size = New Size(150, 25),
                .Location = New Point(75, 5),
                .BackColor = Color.Transparent,
                .ForeColor = Color.White,
                .TextAlign = ContentAlignment.MiddleLeft,
                .Font = New Font("Arial", 10, FontStyle.Bold)
            }
            carPanel.Controls.Add(carLabel)

            Dim carPriceLabel As New Label With {
                .Text = "Price per day: " & carDict("DailyPrice").ToString(),
                .Size = New Size(150, 25),
                .Location = New Point(75, 35),
                .BackColor = Color.Transparent,
                .ForeColor = Color.White,
                .TextAlign = ContentAlignment.MiddleLeft,
                .Font = New Font("Arial", 9, FontStyle.Regular)
            }
            carPanel.Controls.Add(carPriceLabel)

            AddHandler carPanel.Paint, AddressOf Panel_Paint

            Panel1.Controls.Add(carPanel)
            panelYPosition += carPanel.Height + 15
        Next

    End Sub



    Private Sub PictureBox_Paint(sender As Object, e As PaintEventArgs)
        Dim pictureBox As PictureBox = CType(sender, PictureBox)
        Dim graphics As Graphics = e.Graphics
        Dim rect As New Rectangle(5, 5, pictureBox.Width - 10, pictureBox.Height - 10)
        Dim path As New Drawing2D.GraphicsPath()

        path.AddEllipse(rect)
        pictureBox.Region = New Region(path)
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = CType(sender, Panel)
        Dim graphics As Graphics = e.Graphics
        Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)
        Dim path As New Drawing2D.GraphicsPath()

        Dim cornerRadius As Integer = 25
        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseFigure()

        panel.Region = New Region(path)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Me.Close()
        GlobalData.LogoutUser()
        LoginForm.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If GlobalData.var = "!Allowed" OrElse GlobalData.var Is Nothing Then
            MessageBox.Show("Complete your profile first!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Me.Close()
            rent_a_car.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If GlobalData.var = "!Allowed" OrElse GlobalData.var Is Nothing Then
            MessageBox.Show("Complete your profile first!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Me.Close()
            rent_a_car.Show()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        customerDetails.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
        RentalDetail.Show()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Me.Close()
        History.Show()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        Me.Close()
        Billing.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If GlobalData.var = "!Allowed" OrElse GlobalData.var Is Nothing Then
            MessageBox.Show("Complete your profile first!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Me.Close()
            RentalDetail.Show()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If GlobalData.var = "!Allowed" OrElse GlobalData.var Is Nothing Then
            MessageBox.Show("Complete your profile first!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Me.Close()
            History.Show()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If GlobalData.var = "!Allowed" OrElse GlobalData.var Is Nothing Then
            MessageBox.Show("Complete your profile first!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Me.Close()
            Billing.Show()
        End If
    End Sub

    Public Sub RefreshUI()
        Me.Refresh()
    End Sub

    Private Sub RoundedPanel1_Paint(sender As Object, e As PaintEventArgs) Handles RoundedPanel1.Paint

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        RefreshUI()
        GlobalData.LogoutUser()
        GlobalData.HasReturnedCarThisSession = False
        Me.Close()
        LoginForm.Show()

    End Sub

    Private Sub closeForm_Click(sender As Object, e As EventArgs) Handles closeForm.Click
        Close()
    End Sub

    Private Sub minimize_Click(sender As Object, e As EventArgs) Handles minimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
