Public Class homeForm
    Private WithEvents latestRentedTimer As New Timer() With {.Interval = 1000}
    Private latestRentedEndDate As DateTime = DateTime.MinValue

    Private ongoingRentedList As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
    Private currentRentedIndex As Integer = 0

    Private Async Sub homeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

            If String.IsNullOrEmpty(GlobalData.UserFullName) Then
                Label1.Text = "Guest"
            Else
                Label1.Text = GlobalData.UserFullName
            End If
        End If

        Panel1.Controls.Clear()
        Dim panelYPosition As Integer = 10
        Dim recentPremiumCars = GlobalData.PremiumCarsArray.Take(5).ToList()

        Dim userEmail = GlobalData.CurrentUserEmail
        ongoingRentedList = GlobalData.TransactionsDict.Values.
        Where(Function(t) t.ContainsKey("CustomerEmail") AndAlso
                              t("CustomerEmail").ToString() = userEmail AndAlso
                              t.ContainsKey("Status") AndAlso
                              t("Status").ToString().ToLower() = "rented").
        OrderByDescending(Function(t)
                              Dim dt As DateTime
                              If t.ContainsKey("StartDate") AndAlso DateTime.TryParse(t("StartDate").ToString(), dt) Then
                                  Return dt
                              Else
                                  Return Date.MinValue
                              End If
                          End Function).
        ToList()

        If ongoingRentedList.Count = 0 Then
            Label4.Text = "No active rental"
            Label7.Text = "N/A"
            Label5.Text = "00:00:00:00"
            Label8.Text = "Currently renting no cars"
            latestRentedTimer.Stop()
            latestRentedEndDate = DateTime.MinValue
        Else

            currentRentedIndex = 0
            ShowRentedCarAtIndex(currentRentedIndex)
        End If


        ShowAllTransactionsInLabel6()

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
        If GlobalData.var = "!Allowed" OrElse GlobalData.var Is Nothing Then
            MessageBox.Show("Complete your profile first!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Me.Close()
            RentalDetail.Show()
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If GlobalData.var = "!Allowed" OrElse GlobalData.var Is Nothing Then
            MessageBox.Show("Complete your profile first!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Me.Close()
            History.Show()
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        Me.Close()
        Billing.Show()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Me.Hide()
        TheDevs.Show()

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

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub ShowAllTransactionsInLabel6()
        Dim sb As New System.Text.StringBuilder()
        Dim allTransactions = GlobalData.TransactionsDict.Values.OrderBy(Function(t)
                                                                             Dim dt As DateTime
                                                                             If t.ContainsKey("StartDate") AndAlso DateTime.TryParse(t("StartDate").ToString(), dt) Then
                                                                                 Return dt
                                                                             Else
                                                                                 Return Date.MinValue
                                                                             End If
                                                                         End Function).ToList()

        If allTransactions.Count = 0 Then
            sb.AppendLine("No transactions found.")
        Else
            For Each t In allTransactions
                Dim carId = If(t.ContainsKey("CarID"), t("CarID").ToString(), "N/A")
                Dim carName = If(GlobalData.CarsDict.ContainsKey(carId) AndAlso GlobalData.CarsDict(carId).ContainsKey("CarName"),
                             GlobalData.CarsDict(carId)("CarName").ToString(), "N/A")
                Dim rentStart = If(t.ContainsKey("StartDate"), TryFormatDate(t("StartDate")), "N/A")
                Dim rentEnd = If(t.ContainsKey("EndDate"), TryFormatDate(t("EndDate")), "N/A")
                sb.AppendLine($"Car ID: {carId}")
                sb.AppendLine($"Car Name: {carName}")
                sb.AppendLine($"Date Start: {rentStart}")
                sb.AppendLine($"Date End: {rentEnd}")
                sb.AppendLine("------")
            Next
        End If

        Label6.Text = sb.ToString().TrimEnd("-"c)
    End Sub
    Private Function TryFormatDate(obj As Object) As String
        Dim dt As DateTime
        If obj IsNot Nothing AndAlso DateTime.TryParse(obj.ToString(), dt) Then
            Return dt.ToString("yyyy-MM-dd")
        End If
        Return "N/A"
    End Function


    Private Sub UpdateLatestRentedCarInfo()

        Dim userEmail = GlobalData.CurrentUserEmail
        Dim latestRented = GlobalData.TransactionsDict.Values.
        Where(Function(t) t.ContainsKey("CustomerEmail") AndAlso
                          t("CustomerEmail").ToString() = userEmail AndAlso
                          t.ContainsKey("Status") AndAlso
                          t("Status").ToString().ToLower() = "rented").
        OrderByDescending(Function(t)
                              Dim dt As DateTime
                              If t.ContainsKey("StartDate") AndAlso DateTime.TryParse(t("StartDate").ToString(), dt) Then
                                  Return dt
                              Else
                                  Return Date.MinValue
                              End If
                          End Function).
        FirstOrDefault()

        If latestRented Is Nothing Then
            Label4.Text = "No active rental"
            Label7.Text = "N/A"
            Label5.Text = "00:00:00:00"
            latestRentedTimer.Stop()
            latestRentedEndDate = DateTime.MinValue
            If latestRentedEndDate = DateTime.MinValue Then
                Label8.Text = "Currently renting no cars"
            Else
                Dim remaining As TimeSpan = latestRentedEndDate - GlobalData.Now()
                If remaining.TotalSeconds > 0 Then
                    Label8.Text = "Currently Renting"
                Else
                    Label8.Text = "Rent Overdue"
                End If
            End If

            Return
        End If

        ' Car Name
        Dim carId = If(latestRented.ContainsKey("CarID"), latestRented("CarID").ToString(), "N/A")
        Dim carName = If(GlobalData.CarsDict.ContainsKey(carId) AndAlso GlobalData.CarsDict(carId).ContainsKey("CarName"),
                     GlobalData.CarsDict(carId)("CarName").ToString(), "N/A")
        Label4.Text = carName

        ' Rent End
        Dim rentEndStr = If(latestRented.ContainsKey("EndDate"), latestRented("EndDate").ToString(), "")
        Dim rentEndDate As DateTime
        If DateTime.TryParse(rentEndStr, rentEndDate) Then
            Label7.Text = rentEndDate.ToString("yyyy-MM-dd HH:mm:ss")
            latestRentedEndDate = rentEndDate
            latestRentedTimer.Start()
            UpdateLatestRentedTimerLabel()
        Else
            Label7.Text = "N/A"
            Label5.Text = "00:00:00:00"
            latestRentedTimer.Stop()
            latestRentedEndDate = DateTime.MinValue
        End If
    End Sub

    Private Sub latestRentedTimer_Tick(sender As Object, e As EventArgs) Handles latestRentedTimer.Tick
        UpdateLatestRentedTimerLabel()
    End Sub

    Private Sub UpdateLatestRentedTimerLabel()
        If latestRentedEndDate = DateTime.MinValue Then
            Label5.Text = "00:00:00:00"
            Label8.Text = "Currently renting no cars"
            latestRentedTimer.Stop()
            Return
        End If

        Dim remaining As TimeSpan = latestRentedEndDate - GlobalData.Now()
        If remaining.TotalSeconds > 0 Then
            Label5.Text = String.Format("{0}:{1:D2}:{2:D2}:{3:D2}",
                                        Math.Floor(remaining.TotalDays),
                                        remaining.Hours,
                                        remaining.Minutes,
                                        remaining.Seconds)
            Label8.Text = "Currently Renting"
        Else
            Label5.Text = "00:00:00"
            Label8.Text = "Rent Overdue"
            latestRentedTimer.Stop()
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If ongoingRentedList Is Nothing OrElse ongoingRentedList.Count = 0 Then
            Label4.Text = "No active rental"
            Label7.Text = "N/A"
            Label5.Text = "00:00:00:00"
            latestRentedTimer.Stop()
            latestRentedEndDate = DateTime.MinValue
            Return
        End If

        currentRentedIndex = (currentRentedIndex + 1) Mod ongoingRentedList.Count
        ShowRentedCarAtIndex(currentRentedIndex)
    End Sub


    Private Sub ShowRentedCarAtIndex(idx As Integer)
        If ongoingRentedList Is Nothing OrElse ongoingRentedList.Count = 0 Then
            Label4.Text = "No active rental"
            Label7.Text = "N/A"
            Label5.Text = "00:00:00:00"
            latestRentedTimer.Stop()
            latestRentedEndDate = DateTime.MinValue
            Return
        End If

        Dim rented = ongoingRentedList(idx)
        Dim carId = If(rented.ContainsKey("CarID"), rented("CarID").ToString(), "N/A")
        Dim carName = If(GlobalData.CarsDict.ContainsKey(carId) AndAlso GlobalData.CarsDict(carId).ContainsKey("CarName"),
                     GlobalData.CarsDict(carId)("CarName").ToString(), "N/A")
        Label4.Text = carName

        Dim rentEndStr = If(rented.ContainsKey("EndDate"), rented("EndDate").ToString(), "")
        Dim rentEndDate As DateTime
        If DateTime.TryParse(rentEndStr, rentEndDate) Then
            Label7.Text = rentEndDate.ToString("yyyy-MM-dd HH:mm:ss")
            latestRentedEndDate = rentEndDate
            latestRentedTimer.Start()
            UpdateLatestRentedTimerLabel()
        Else
            Label7.Text = "N/A"
            Label5.Text = "00:00:00:00"
            latestRentedTimer.Stop()
            latestRentedEndDate = DateTime.MinValue
        End If
    End Sub

    Private Sub DraggablePanel1_Paint(sender As Object, e As PaintEventArgs) Handles DraggablePanel1.Paint

    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()
        TheDevs.Show()
    End Sub
End Class
