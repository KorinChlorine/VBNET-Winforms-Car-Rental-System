Public Class rent_a_car
    Private scrollingTimers As New List(Of Timer)

    Private Sub rent_a_car_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FlowLayoutPanel1.Controls.Clear()
        scrollingTimers.Clear()

        FlowLayoutPanel1.WrapContents = True
        FlowLayoutPanel1.AutoScroll = True
        FlowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight

        For Each car In GlobalData.GlobalOuterArray
            Dim carPanel As New Panel With {
                .Size = New Size(180, 220),
                .BackColor = Color.LightGray,
                .Margin = New Padding(8)
            }
            AddHandler carPanel.Paint, AddressOf Panel_Paint

            Dim premiumLabel As New Label With {
                .Text = If(Convert.ToBoolean(car(12)), "PREMIUM", ""),
                .Size = New Size(50, 15),
                .Location = New Point(5, 5),
                .BackColor = Color.Transparent,
                .ForeColor = Color.White,
                .Font = New Font("Arial", 7, FontStyle.Bold)
            }
            carPanel.Controls.Add(premiumLabel)
            Dim carPictureBox As New PictureBox With {
                .Size = New Size(160, 130),
                .Location = New Point(10, 25),
                .Image = TryCast(car(1), Image),
                .SizeMode = PictureBoxSizeMode.StretchImage,
                .BackColor = Color.Black
            }
            carPanel.Controls.Add(carPictureBox)

            Dim carNameLabel As New Label With {
                .Text = car(0)?.ToString(),
                .AutoSize = True,
                .Location = New Point(10, 160),
                .BackColor = Color.Transparent,
                .ForeColor = Color.Black,
                .Font = New Font("Arial", 9, FontStyle.Bold)
            }
            carPanel.Controls.Add(carNameLabel)

            Dim carPriceLabel As New Label With {
                .Text = "P" & car(11)?.ToString() & "/day",
                .Size = New Size(160, 20),
                .Location = New Point(10, 185),
                .BackColor = Color.Transparent,
                .ForeColor = Color.Black,
                .Font = New Font("Arial", 9, FontStyle.Bold),
                .TextAlign = ContentAlignment.MiddleRight
            }
            carPanel.Controls.Add(carPriceLabel)

            If TextRenderer.MeasureText(carNameLabel.Text, carNameLabel.Font).Width > carNameLabel.Width Then
                EnableScrolling(carNameLabel, carPanel)
            End If

            FlowLayoutPanel1.Controls.Add(carPanel)
        Next
    End Sub

    Private Sub EnableScrolling(label As Label, parentPanel As Panel)
        Dim timer As New Timer With {
            .Interval = 100
        }
        Dim originalText As String = label.Text
        Dim scrollText As String = originalText & "   "
        Dim currentIndex As Integer = 0

        AddHandler timer.Tick, Sub()

                                   currentIndex = (currentIndex + 1) Mod scrollText.Length
                                   label.Text = scrollText.Substring(currentIndex) & scrollText.Substring(0, currentIndex)
                               End Sub

        timer.Start()
        scrollingTimers.Add(timer)
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = CType(sender, Panel)
        Dim graphics As Graphics = e.Graphics
        Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)
        Dim path As New Drawing2D.GraphicsPath()

        Dim cornerRadius As Integer = 10
        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseFigure()

        panel.Region = New Region(path)
    End Sub
End Class

