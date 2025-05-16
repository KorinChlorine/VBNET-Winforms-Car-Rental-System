Public Class Billing
    Public Property SelectedCar As Dictionary(Of String, Object)
    Public Property TransactionType As String
    Public Property StartDate As DateTime?
    Public Property EndDate As DateTime?
    Public Property Duration As Integer
    Public Property TotalPrice As Decimal
    Private SelectedPanel As Panel = Nothing

    Private panelTimers As New Dictionary(Of Panel, Timer)()
    Public Shared BillingInstance As Billing

    Private WithEvents globalPanelCheckTimer As New Timer() With {.Interval = 1000}


    Private Sub Billing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BillingInstance = Me
        globalPanelCheckTimer.Start()


        LoadSavedPanels()
        UpdateBillingDetails()
        lblCustomer.Text = "Customer Name: " & GlobalData.UserFullName
        lblAddress.Text = "Address: " & GlobalData.Address
        lblEmail.Text = "Email: " & GlobalData.CurrentUserEmail
        paneling.Text = "Age: " & GlobalData.Age.ToString()
        lblUserStatus.Text = "User Status: " & If(GlobalData.IsLoggedIn, "Logged In", "Guest")
        lblBalance.Text = $"Balance: ₱{GlobalData.Wallet:N2}"
        lblAge.Text = "Age: " & GlobalData.Age.ToString()
        lblAge.ForeColor = Color.White
        UpdateBalance()
    End Sub
    Public Shared Sub RemovePanelAndStopTimerByCarID(carId As String)
        If BillingInstance IsNot Nothing Then
            BillingInstance.DeletePanelByCarID(carId)
        End If
    End Sub
    Protected Overrides Sub OnActivated(e As EventArgs)
        MyBase.OnActivated(e)
    End Sub

    Public Sub UpdateBillingDetails()
        If SelectedCar IsNot Nothing Then
            lblCarName.Text = If(SelectedCar.ContainsKey("CarName"), SelectedCar("CarName").ToString(), "N/A")
            lblPaymentPerDay.Text = If(SelectedCar.ContainsKey("DailyPrice"), $"Payment/day: ₱{Convert.ToDecimal(SelectedCar("DailyPrice")):N2}", "Payment/day: N/A")
            lblCarID.Text = "Car ID: " & If(SelectedCar.ContainsKey("CarID"), SelectedCar("CarID").ToString(), "N/A")
            lblBodyNumber.Text = "Body Number: " & If(SelectedCar.ContainsKey("BodyNumber"), SelectedCar("BodyNumber").ToString(), "N/A")
            lblPlateNumber.Text = "Plate Number: " & If(SelectedCar.ContainsKey("PlateNumber"), SelectedCar("PlateNumber").ToString(), "N/A")
            lblColor.Text = "Color: " & If(SelectedCar.ContainsKey("Color"), SelectedCar("Color").ToString(), "N/A")
            lblCapacity.Text = "Capacity: " & If(SelectedCar.ContainsKey("Capacity"), SelectedCar("Capacity").ToString(), "N/A")
            If SelectedCar.ContainsKey("CarType") Then
                lblType.Text = "Type: " & SelectedCar("CarType").ToString()
            Else
                lblType.Text = "Type: N/A"
            End If

            Dim dailyPrice As Decimal = If(SelectedCar.ContainsKey("DailyPrice"), Convert.ToDecimal(SelectedCar("DailyPrice")), 0)
            Dim rentalDays As Integer
            If TransactionType = "RENT" Then
                rentalDays = Math.Max(1, Duration)
            ElseIf TransactionType = "BOOK" AndAlso StartDate.HasValue AndAlso EndDate.HasValue Then
                rentalDays = Math.Max(1, (EndDate.Value - StartDate.Value).Days)
            Else
                rentalDays = 0
            End If

            lblTotalPayment.Text = $"Total Payment: ₱{(dailyPrice * rentalDays):N2}"
            lblRentedStarted.Text = "Rented Start Date: " & (If(GlobalData.RentalStartDate.HasValue, GlobalData.RentalStartDate.Value.ToString("MMMM dd, yyyy"), "N/A"))
            lblRentedEnded.Text = "Rented End Date: " & (If(GlobalData.RentalEndDate.HasValue, GlobalData.RentalEndDate.Value.ToString("MMMM dd, yyyy"), "N/A"))
            lblDaysToBeRented.Text = "Days to be Rented: " & rentalDays.ToString()
        Else
            lblCarName.Text = "No car selected"
        End If


        RoundedButton1.Enabled = True
        RoundedButton1.BackColor = Color.DarkSlateBlue
        RoundedButton1.ForeColor = Color.White
    End Sub

    Private Sub LoadSavedPanels()
        For Each tmr In panelTimers.Values
            tmr.Stop()
            tmr.Dispose()
        Next
        panelTimers.Clear()
        FlowLayoutPanel1.Controls.Clear()

        Dim loggedInUser = GlobalData.GetLoggedInUser()
        If loggedInUser IsNot Nothing AndAlso loggedInUser.ContainsKey("SavedBillingPanels") Then
            Dim savedPanels = CType(loggedInUser("SavedBillingPanels"), List(Of Dictionary(Of String, Object)))
            For Each transactionDetails In savedPanels
                If Not transactionDetails.ContainsKey("Status") OrElse
                   Not String.Equals(transactionDetails("Status").ToString(), "Returned", StringComparison.OrdinalIgnoreCase) Then
                    CreateTransactionPanel(transactionDetails)
                End If
            Next
        End If
    End Sub

    Private Sub ApplyRoundedCornersToPanel(panel As Panel, cornerRadius As Integer)
        If panel.Width > 0 AndAlso panel.Height > 0 AndAlso cornerRadius > 0 Then
            Dim radius As Integer = Math.Min(cornerRadius, Math.Min(panel.Width, panel.Height) \ 2)
            If radius > 0 AndAlso panel.Width >= radius * 2 AndAlso panel.Height >= radius * 2 Then
                Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)
                Dim path As New Drawing2D.GraphicsPath()

                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
                path.CloseFigure()

                If path.PointCount > 0 Then
                    panel.Region = New Region(path)
                End If
            End If
        End If
    End Sub
    Private Sub TransactionPanel_Click(sender As Object, e As EventArgs)
        Dim panel As Panel = TryCast(sender, Panel)
        If panel Is Nothing AndAlso TypeOf sender Is Label Then
            panel = TryCast(DirectCast(sender, Label).Parent, Panel)
        End If
        If panel Is Nothing Then Return


        For Each ctrl As Control In FlowLayoutPanel1.Controls
            If TypeOf ctrl Is Panel Then
                ctrl.BackColor = Color.DarkSlateBlue
                For Each lbl In ctrl.Controls.OfType(Of Label)()
                    lbl.ForeColor = Color.White
                Next
            End If
        Next

        panel.BackColor = Color.White
        For Each lbl In panel.Controls.OfType(Of Label)()
            lbl.ForeColor = Color.Black
        Next

        SelectedPanel = panel

        Dim details = TryCast(panel.Tag, Dictionary(Of String, Object))
        If details Is Nothing Then Return

        lblCarName.Text = details("CarName")
        lblPaymentPerDay.Text = If(details.ContainsKey("PaymentPerDay"), details("PaymentPerDay").ToString(), "N/A")
        lblCarID.Text = details("CarID")
        lblBodyNumber.Text = details("BodyNumber")
        lblPlateNumber.Text = details("PlateNumber")
        lblColor.Text = details("Color")
        lblCapacity.Text = details("Capacity")
        lblType.Text = details("Type")
        lblTotalPayment.Text = details("TotalPayment")
        lblRentedStarted.Text = details("RentedStarted")
        lblRentedEnded.Text = details("RentedEnded")
        lblDaysToBeRented.Text = details("DaysToBeRented")
        lblCustomer.Text = details("Customer")
        lblAddress.Text = details("Address")
        lblEmail.Text = details("Email")
        lblAge.Text = details("Age")

        Dim isReturned As Boolean = False
        If details.ContainsKey("Status") AndAlso details("Status") IsNot Nothing Then
            isReturned = details("Status").ToString().ToLower() = "returned"
        End If

        If isReturned OrElse GlobalData.HasReturnedCarThisSession Then
            RoundedButton1.Enabled = False
            RoundedButton1.BackColor = Color.Gray
        Else
            RoundedButton1.Enabled = False
            RoundedButton1.BackColor = Color.Gray
        End If
    End Sub

    Private Sub CreateTransactionPanel(transactionDetails As Dictionary(Of String, Object))

        If Not transactionDetails.ContainsKey("Status") Then
            transactionDetails("Status") = "Active"
        End If
        If Not transactionDetails.ContainsKey("CarName") Then
            transactionDetails("CarName") = "N/A"
        End If

        Dim transPanel As New Panel With {
        .Width = 240,
        .Height = 40,
        .BackColor = Color.DarkSlateBlue,
        .ForeColor = Color.White,
        .Cursor = Cursors.Hand,
        .Margin = New Padding(5)
    }
        Dim lbl As New Label With {
        .AutoSize = False,
        .Font = New Font("Segoe UI", 12, FontStyle.Bold),
        .Size = New Size(transPanel.Width, transPanel.Height),
        .TextAlign = ContentAlignment.MiddleCenter
    }
        lbl.Location = New Point(0, 0)

        Dim timerText As String = "00:00:00:00"
        If transactionDetails.ContainsKey("ReturnDeadline") Then
            Dim deadline As DateTime
            If DateTime.TryParse(transactionDetails("ReturnDeadline").ToString(), deadline) Then
                Dim now As DateTime = GlobalData.Now()
                Dim remaining As TimeSpan = deadline - now
                If remaining.TotalSeconds > 0 Then
                    timerText = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D2}",
                    CInt(Math.Floor(remaining.TotalDays)),
                    remaining.Hours,
                    remaining.Minutes,
                    remaining.Seconds)
                End If
            End If
        End If

        lbl.Text = transactionDetails("CarName") & vbCrLf & timerText

        transPanel.Controls.Add(lbl)
        transPanel.Tag = transactionDetails
        AddHandler transPanel.Click, AddressOf TransactionPanel_Click
        AddHandler lbl.Click, Sub(s, ev) TransactionPanel_Click(transPanel, ev)

        transPanel.PerformLayout()
        ApplyRoundedCornersToPanel(transPanel, 20)
        FlowLayoutPanel1.Controls.Add(transPanel)

        ' Timer logic
        If transactionDetails.ContainsKey("ReturnDeadline") Then
            Dim deadline As DateTime
            If DateTime.TryParse(transactionDetails("ReturnDeadline").ToString(), deadline) Then
                Dim hasStartDate As Boolean = transactionDetails.ContainsKey("StartDate") AndAlso DateTime.TryParse(transactionDetails("StartDate").ToString(), Nothing)
                Dim startDate As DateTime = DateTime.MinValue
                If hasStartDate Then DateTime.TryParse(transactionDetails("StartDate").ToString(), startDate)

                Dim tmr As New Timer()
                tmr.Interval = 1000

                Dim updateLabel As Action = Sub()
                                                Dim now As DateTime = GlobalData.Now()
                                                Dim remaining As TimeSpan = deadline - now

                                                If hasStartDate AndAlso startDate.Date > now.Date Then
                                                    lbl.Text = transactionDetails("CarName") & vbCrLf & "Booking not started"

                                                    If panelTimers.ContainsKey(transPanel) Then
                                                        panelTimers(transPanel).Stop()
                                                        panelTimers(transPanel).Dispose()
                                                        panelTimers.Remove(transPanel)
                                                    End If
                                                    Return
                                                End If

                                                If transactionDetails.ContainsKey("Status") AndAlso
                                                   transactionDetails("Status").ToString().ToLower() = "returned" Then

                                                    DeletePanelByCarID(transactionDetails("CarID").ToString())
                                                    Return
                                                End If


                                                If remaining.TotalSeconds > 0 Then
                                                    lbl.Text = transactionDetails("CarName") & vbCrLf &
                                                        String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D2}",
                                                            CInt(Math.Floor(remaining.TotalDays)),
                                                            remaining.Hours,
                                                            remaining.Minutes,
                                                            remaining.Seconds)
                                                Else
                                                    lbl.Text = transactionDetails("CarName") & vbCrLf & "Time's up!"

                                                    DeletePanelByCarID(transactionDetails("CarID").ToString())
                                                End If
                                            End Sub


                If Not (hasStartDate AndAlso startDate.Date > GlobalData.Now().Date) Then
                    tmr.Start()
                    panelTimers(transPanel) = tmr
                End If
                updateLabel()
            End If
        End If


    End Sub

    Private Function SafeGet(dict As Dictionary(Of String, Object), key As String) As Object
        If dict IsNot Nothing AndAlso dict.ContainsKey(key) AndAlso dict(key) IsNot Nothing Then
            Return dict(key)
        End If
        Return ""
    End Function

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click

        If Not GlobalData.IsLoggedIn Then
            MessageBox.Show("You must be logged in to confirm the transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim totalPaymentText As String = lblTotalPayment.Text.Replace("Total Payment: ₱", "").Replace(",", "").Trim()
        Dim totalPayment As Decimal

        If Decimal.TryParse(totalPaymentText, totalPayment) Then
            Dim walletBalance As Decimal = GlobalData.Wallet
            If walletBalance >= totalPayment Then
                GlobalData.Wallet -= totalPayment
                lblBalance.Text = $"Balance: ₱{GlobalData.Wallet:N2}"

                Dim loggedInUser = GlobalData.GetLoggedInUser()
                If loggedInUser IsNot Nothing Then

                    If Not loggedInUser.ContainsKey("RentedCarsList") OrElse loggedInUser("RentedCarsList") Is Nothing Then
                        loggedInUser("RentedCarsList") = New List(Of Dictionary(Of String, Object))()
                    End If
                    Dim rentedCars = CType(loggedInUser("RentedCarsList"), List(Of Dictionary(Of String, Object)))
                    If Not rentedCars.Any(Function(car) car("CarID")?.ToString() = SelectedCar("CarID")?.ToString()) Then
                        Dim rentedCarInfo As New Dictionary(Of String, Object)(SelectedCar)
                        Dim returnEndTime As DateTime
                        If TransactionType = "RENT" Then
                            returnEndTime = GlobalData.Now().AddDays(Duration)
                        ElseIf TransactionType = "BOOK" AndAlso EndDate.HasValue Then
                            returnEndTime = EndDate.Value
                        Else
                            returnEndTime = GlobalData.Now()
                        End If
                        rentedCarInfo("ReturnDeadline") = returnEndTime
                        rentedCars.Add(rentedCarInfo)
                    End If

                    Dim panelReturnEndTime As DateTime
                    Dim panelStartDate As DateTime = If(StartDate.HasValue, StartDate.Value, GlobalData.Now())
                    If TransactionType = "RENT" Then
                        panelReturnEndTime = GlobalData.Now().AddDays(Duration)
                    ElseIf TransactionType = "BOOK" AndAlso EndDate.HasValue Then
                        panelReturnEndTime = EndDate.Value
                    Else
                        panelReturnEndTime = GlobalData.Now()
                    End If
                    GlobalData.RentalStartDate = panelStartDate
                    GlobalData.RentalEndDate = panelReturnEndTime


                    Dim transactionDetails As New Dictionary(Of String, Object) From {
                    {"CarName", If(SelectedCar.ContainsKey("CarName"), SelectedCar("CarName").ToString(), "N/A")},
                    {"CarID", If(SelectedCar.ContainsKey("CarID"), SelectedCar("CarID").ToString(), "N/A")},
                    {"BodyNumber", If(SelectedCar.ContainsKey("BodyNumber"), SelectedCar("BodyNumber").ToString(), "N/A")},
                    {"PlateNumber", If(SelectedCar.ContainsKey("PlateNumber"), SelectedCar("PlateNumber").ToString(), "N/A")},
                    {"Color", If(SelectedCar.ContainsKey("Color"), SelectedCar("Color").ToString(), "N/A")},
                    {"Type", If(SelectedCar.ContainsKey("CarType"), SelectedCar("CarType").ToString(), "N/A")},
                    {"Capacity", If(SelectedCar.ContainsKey("Capacity"), SelectedCar("Capacity").ToString(), "N/A")},
                    {"ReturnDeadline", panelReturnEndTime},
                    {"StartDate", panelStartDate},
                    {"Status", If(TransactionType = "BOOK", "Booked", "Rented")},
                    {"TotalPayment", lblTotalPayment.Text},
                    {"PaymentPerDay", lblPaymentPerDay.Text},
                    {"RentedStarted", lblRentedStarted.Text},
                    {"RentedEnded", lblRentedEnded.Text},
                    {"DaysToBeRented", lblDaysToBeRented.Text},
                    {"Customer", lblCustomer.Text},
                    {"Address", lblAddress.Text},
                    {"Email", lblEmail.Text},
                    {"Age", paneling.Text}
                }


                    If Not loggedInUser.ContainsKey("SavedBillingPanels") OrElse loggedInUser("SavedBillingPanels") Is Nothing Then
                        loggedInUser("SavedBillingPanels") = New List(Of Dictionary(Of String, Object))()
                    End If
                    Dim savedPanels = CType(loggedInUser("SavedBillingPanels"), List(Of Dictionary(Of String, Object)))
                    savedPanels.Add(transactionDetails)


                    Dim carIdKey As String = If(SelectedCar.ContainsKey("CarID"), SelectedCar("CarID").ToString(), "").Trim()
                    GlobalData.BillingPanelsDict(carIdKey) = transactionDetails
                    GlobalData.ToggleCarAvailability(carIdKey)


                    For Each tmr In panelTimers.Values
                        tmr.Stop()
                        tmr.Dispose()
                    Next
                    panelTimers.Clear()
                    FlowLayoutPanel1.Controls.Clear()
                    LoadSavedPanels()

                    RoundedButton1.Enabled = False
                    RoundedButton1.ForeColor = Color.Black
                    RoundedButton1.BackColor = Color.Gray
                End If

                MessageBox.Show("Payment successful and car data saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Dim newTransactionId As Integer = 1
                If GlobalData.TransactionsDict.Count > 0 Then
                    newTransactionId = GlobalData.TransactionsDict.Keys.Max() + 1
                End If

                Dim transactionDict As New Dictionary(Of String, Object) From {
                {"TransactionID", newTransactionId},
                {"CarID", If(SelectedCar.ContainsKey("CarID"), SelectedCar("CarID").ToString(), "N/A")},
                {"PlateNumber", If(SelectedCar.ContainsKey("PlateNumber"), SelectedCar("PlateNumber").ToString(), "N/A")},
                {"BodyNumber", If(SelectedCar.ContainsKey("BodyNumber"), SelectedCar("BodyNumber").ToString(), "N/A")},
                {"Color", If(SelectedCar.ContainsKey("Color"), SelectedCar("Color").ToString(), "N/A")},
                {"Type", If(SelectedCar.ContainsKey("CarType"), SelectedCar("CarType").ToString(), "N/A")},
                {"Capacity", If(SelectedCar.ContainsKey("Capacity"), SelectedCar("Capacity").ToString(), "N/A")},
                {"DailyPrice", If(SelectedCar.ContainsKey("DailyPrice"), SelectedCar("DailyPrice").ToString(), "N/A")},
                {"TotalPrice", lblTotalPayment.Text.Replace("Total Payment: ₱", "").Replace(",", "").Trim()},
                {"Status", If(TransactionType = "BOOK", "Booked", "Rented")},
                {"StartDate", If(TransactionType = "BOOK" AndAlso StartDate.HasValue, StartDate.Value, GlobalData.Now())},
                {"EndDate", If(TransactionType = "BOOK" AndAlso EndDate.HasValue, EndDate.Value, GlobalData.Now().AddDays(Duration))},
                {"DateReturned", Nothing},
                {"CustomerEmail", GlobalData.CurrentUserEmail}
            }

                GlobalData.TransactionsDict(newTransactionId) = transactionDict
                GlobalData.NotifyDataChanged()

                GlobalData.RentedCars += 1
                Dim user = GlobalData.GetLoggedInUser()
                If user IsNot Nothing Then
                    user("RentedCars") = GlobalData.RentedCars
                End If
                GlobalData.NotifyDataChanged()
            Else
                MessageBox.Show("Insufficient balance in wallet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Invalid total payment format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Public Sub DeletePanelByCarID(carId As String)

        Dim panelToRemove As Panel = Nothing
        For Each ctrl As Control In FlowLayoutPanel1.Controls
            If TypeOf ctrl Is Panel Then
                Dim details = TryCast(ctrl.Tag, Dictionary(Of String, Object))
                If details IsNot Nothing AndAlso details.ContainsKey("CarID") AndAlso
                   details("CarID").ToString().Trim() = carId.Trim() Then
                    panelToRemove = DirectCast(ctrl, Panel)
                    Exit For
                End If

            End If
        Next

        If panelToRemove IsNot Nothing Then
            If panelTimers.ContainsKey(panelToRemove) Then
                panelTimers(panelToRemove).Stop()
                panelTimers(panelToRemove).Dispose()
                panelTimers.Remove(panelToRemove)
            End If
            FlowLayoutPanel1.Controls.Remove(panelToRemove)
        End If



        Dim user = GlobalData.GetLoggedInUser()
        If user IsNot Nothing AndAlso user.ContainsKey("SavedBillingPanels") Then
            Dim panels = CType(user("SavedBillingPanels"), List(Of Dictionary(Of String, Object)))
            panels.RemoveAll(Function(panel)
                                 Return panel.ContainsKey("CarID") AndAlso panel("CarID").ToString() = carId
                             End Function)
        End If


        If GlobalData.BillingPanelsDict.ContainsKey(carId) Then
            GlobalData.BillingPanelsDict.Remove(carId)
        End If

        GlobalData.NotifyDataChanged()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        WalletAdd.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        WalletAdd.Show()
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Me.Close()
        homeForm.Show()
    End Sub

    Private Sub DisablePostReturnButtons()
        RoundedButton1.Enabled = False
        RoundedButton1.BackColor = Color.Gray
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles closeForm.Click
        Close()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles minimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Public Sub UpdateBalance()
        lblBalance.Text = $"Balance: ₱{GlobalData.Wallet:N2}"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles history.Click
        Me.Close()
        history.Show()
    End Sub

    Private Sub home_Click(sender As Object, e As EventArgs) Handles home.Click
        Me.Close()
        homeForm.Show()
    End Sub

    Private Sub rent_Click(sender As Object, e As EventArgs) Handles rent.Click
        Me.Close()
        rent_a_car.Show()
    End Sub

    Private Sub details_Click(sender As Object, e As EventArgs) Handles details.Click
        Me.Close()
        RentalDetail.Show()
    End Sub

    Private Sub setting_Click(sender As Object, e As EventArgs)
        Me.Close()
        TheDevs.Show()
    End Sub

    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        Me.Close()
        LoginForm.Show()
    End Sub

    Private Sub bills_Click(sender As Object, e As EventArgs) Handles bills.Click
        Me.Close()
        bills.Show()
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles RoundedButton2.Click
        lblBalance.Text = $"Balance: ₱{GlobalData.Wallet:N2}"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        TheDevs.Show()
    End Sub
End Class
