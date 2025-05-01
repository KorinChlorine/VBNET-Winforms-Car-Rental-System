Public Class homeForm
    Private Sub homeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Controls.Clear()
        Dim panelYPosition As Integer = 10
        Dim recentPremiumCars = GlobalData.PremiumCarsArray.Take(5).ToList()

        For Each car In recentPremiumCars
            Dim carPanel As New Panel With {
                .Size = New Size(240, 65),
                .Location = New Point(10, panelYPosition),
                .BackColor = Color.Transparent
            }

            Dim carPictureBox As New PictureBox With {
                .Size = New Size(60, 60),
                .Location = New Point(5, 4),
                .Image = TryCast(car(1), Image),
                .SizeMode = PictureBoxSizeMode.StretchImage
            }
            AddHandler carPictureBox.Paint, AddressOf PictureBox_Paint
            carPanel.Controls.Add(carPictureBox)

            Dim carLabel As New Label With {
                .Text = car(0)?.ToString(),
                .Size = New Size(150, 25),
                .Location = New Point(75, 5),
                .BackColor = Color.Transparent,
                .ForeColor = Color.White,
                .TextAlign = ContentAlignment.MiddleLeft,
                .Font = New Font("Arial", 10, FontStyle.Bold)
            }
            carPanel.Controls.Add(carLabel)

            Dim carPriceLabel As New Label With {
                .Text = "Price per day: " & car(11)?.ToString(),
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        LoginForm.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        rent_a_car.Show()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        rent_a_car.Show()

    End Sub
End Class