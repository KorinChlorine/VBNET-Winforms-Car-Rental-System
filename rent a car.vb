Public Class rent_a_car
    Private scrollingTimers As New List(Of Timer)

    Private Sub rent_a_car_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler GlobalData.DataChanged, AddressOf RefreshUI
        RefreshUI()
    End Sub

    Private Sub rent_a_car_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveHandler GlobalData.DataChanged, AddressOf RefreshUI
        For Each timer In scrollingTimers
            timer.Stop()
            timer.Dispose()
        Next
        scrollingTimers.Clear()
    End Sub

    Public Sub CloseCurrentForm()
        Me.Close()
    End Sub

    Public Sub RefreshUI()
        FlowLayoutPanel1.Controls.Clear()

        For Each carDict As Dictionary(Of String, Object) In GlobalData.CarsDict.Values
            ' Defensive: check for required fields
            If carDict Is Nothing OrElse Not carDict.ContainsKey("CarID") Then Continue For

            Dim carPanel As New Panel With {
                .Size = New Size(190, 220),
                .BackColor = Color.DarkSlateBlue,
                .Margin = New Padding(10),
                .Tag = carDict
            }
            AddHandler carPanel.Click, AddressOf CarPanel_Click
            AddHandler carPanel.Paint, AddressOf Panel_Paint

            Dim carPictureBox As New PictureBox With {
                .Size = New Size(170, 130),
                .Location = New Point(10, 30),
                .Image = If(carDict.ContainsKey("PrimaryImage"), TryCast(carDict("PrimaryImage"), Image), Nothing),
                .SizeMode = PictureBoxSizeMode.StretchImage
            }
            AddHandler carPictureBox.Click, Sub(picSender, picE) CarPanel_Click(carPanel, picE)
            carPanel.Controls.Add(carPictureBox)

            Dim isAvailable As Boolean = False
            If carDict.ContainsKey("IsAvailable") Then
                Boolean.TryParse(carDict("IsAvailable")?.ToString(), isAvailable)
            End If
            If Not isAvailable Then
                Dim notAvailableLabel As New Label With {
                    .Text = "NOT AVAILABLE",
                    .Size = New Size(carPictureBox.Width, 30),
                    .BackColor = Color.Red,
                    .ForeColor = Color.White,
                    .Font = New Font("Arial", 10, FontStyle.Bold),
                    .TextAlign = ContentAlignment.MiddleCenter
                }
                notAvailableLabel.Location = New Point(0, carPictureBox.Height - notAvailableLabel.Height)
                carPictureBox.Controls.Add(notAvailableLabel)
                notAvailableLabel.BringToFront()
            End If

            Dim carNameLabel As New Label With {
                .Text = carDict("CarName")?.ToString(),
                .AutoSize = True,
                .Location = New Point(10, 170),
                .BackColor = Color.Transparent,
                .ForeColor = Color.White,
                .Font = New Font("Arial", 9, FontStyle.Bold)
            }
            AddHandler carNameLabel.Click, Sub(lblSender, lblE) CarPanel_Click(carPanel, lblE)
            carPanel.Controls.Add(carNameLabel)

            Dim carPriceLabel As New Label With {
                .Text = "P" & carDict("DailyPrice")?.ToString() & "/day",
                .Size = New Size(160, 20),
                .Location = New Point(10, 190),
                .BackColor = Color.Transparent,
                .ForeColor = Color.White,
                .Font = New Font("Arial", 9, FontStyle.Bold),
                .TextAlign = ContentAlignment.MiddleRight
            }
            AddHandler carPriceLabel.Click, Sub(lblSender, lblE) CarPanel_Click(carPanel, lblE)
            carPanel.Controls.Add(carPriceLabel)

            FlowLayoutPanel1.Controls.Add(carPanel)

            Dim isPremium As Boolean = False
            Dim dailyPrice As Decimal
            If carDict.ContainsKey("DailyPrice") AndAlso Decimal.TryParse(carDict("DailyPrice")?.ToString(), dailyPrice) Then
                isPremium = dailyPrice >= 10000
            End If

            If isPremium Then
                Dim premiumLabel As New Label With {
                    .Text = "PREMIUM",
                    .Size = New Size(170, 20),
                    .Location = New Point(10, 5),
                    .BackColor = Color.Transparent,
                    .ForeColor = Color.Gold,
                    .Font = New Font("Arial", 8, FontStyle.Bold),
                    .TextAlign = ContentAlignment.MiddleCenter
                }
                carPanel.Controls.Add(premiumLabel)
            End If
        Next
    End Sub

    Private Sub CarPanel_Click(sender As Object, e As EventArgs)
        Dim selectedPanel As Panel = CType(sender, Panel)
        Dim selectedCar As Dictionary(Of String, Object) = CType(selectedPanel.Tag, Dictionary(Of String, Object))

        Dim rentCarForm As New rent_a_car2()
        rentCarForm.SelectedCar = selectedCar
        rentCarForm.Show()

        CloseCurrentForm()
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

        Dim cornerRadius As Integer = 20
        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseFigure()

        panel.Region = New Region(path)
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CloseCurrentForm()
        homeForm.Show()
    End Sub

    Private Sub minimize_Click(sender As Object, e As EventArgs) Handles minimize.Click
        Close()
    End Sub

    Private Sub closeForm_Click(sender As Object, e As EventArgs) Handles closeForm.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
