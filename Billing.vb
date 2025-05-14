Public Class Billing
    Public Property SelectedCar As Dictionary(Of String, Object)
    Public Property TransactionType As String
    Public Property StartDate As DateTime?
    Public Property EndDate As DateTime?
    Public Property Duration As Integer
    Public Property TotalPrice As Decimal
    Private SelectedPanel As Panel = Nothing
    ' Dictionary to keep a timer for each panel
    Private panelTimers As New Dictionary(Of Panel, Timer)()

    Private Sub Billing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        updateBalance()
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

        ' Always enable the confirm button, disable return by default
        RoundedButton1.Enabled = True
        RoundedButton1.BackColor = Color.DarkSlateBlue
        RoundedButton1.ForeColor = Color.White
    End Sub

    Private Sub LoadSavedPanels()
        ' Only clear timers and panels, do not stop timers unless returning or time's up
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
                ' Only show panels that are not returned
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

    Private Sub CreateTransactionPanel(transactionDetails As Dictionary(Of String, Object))
        If Not transactionDetails.ContainsKey("Status") Then
            transactionDetails("Status") = "Active"
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
            .Text = transactionDetails("CarName"),
            .AutoSize = False,
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Size = New Size(transPanel.Width, transPanel.Height),
            .TextAlign = ContentAlignment.MiddleCenter
        }
        lbl.Location = New Point(0, 0)

        transPanel.Controls.Add(lbl)
        transPanel.Tag = transactionDetails
        AddHandler transPanel.Click, AddressOf TransactionPanel_Click
        AddHandler lbl.Click, Sub(s, ev) TransactionPanel_Click(transPanel, ev)

        transPanel.PerformLayout()
        ApplyRoundedCornersToPanel(transPanel, 20)

        ' Setup countdown timer for this panel if ReturnDeadline exists
        If transactionDetails.ContainsKey("ReturnDeadline") Then
            Dim deadline As DateTime
            If DateTime.TryParse(transactionDetails("ReturnDeadline").ToString(), deadline) Then
                Dim tmr As New Timer()
                tmr.Interval = 1000

                Dim updateLabel As Action = Sub()
                                                Dim remaining As TimeSpan = deadline - DateTime.Now
                                                If remaining.TotalSeconds > 0 Then
                                                    lbl.Text = $"{transactionDetails("CarName")} : {remaining.ToString("hh\:mm\:ss")}"
                                                Else
                                                    lbl.Text = $"{transactionDetails("CarName")} : 00:00:00"
                                                    tmr.Stop()
                                                    tmr.Dispose()
                                                    panelTimers.Remove(transPanel)
                                                    MessageBox.Show($"Rental period for {transactionDetails("CarName")} has ended! Please return the car.", "Time's Up", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                    ' Mark user as bad record
                                                    GlobalData.IsGoodRecord = False
                                                    Dim user = GlobalData.GetLoggedInUser()
                                                    If user IsNot Nothing Then user("IsGoodRecord") = False
                                                    GlobalData.NotifyDataChanged()
                                                End If
                                            End Sub

                AddHandler tmr.Tick, Sub(sender As Object, e As EventArgs)
                                         updateLabel()
                                     End Sub

                tmr.Start()
                panelTimers(transPanel) = tmr

                updateLabel()
            End If
        End If

        FlowLayoutPanel1.Controls.Add(transPanel)
    End Sub

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
                        ' Set the return deadline
                        Dim returnEndTime As DateTime
                        If TransactionType = "RENT" Then
                            returnEndTime = DateTime.Now.AddDays(Duration)
                        ElseIf TransactionType = "BOOK" AndAlso EndDate.HasValue Then
                            returnEndTime = EndDate.Value
                        Else
                            returnEndTime = DateTime.Now
                        End If
                        rentedCarInfo("ReturnDeadline") = returnEndTime
                        rentedCars.Add(rentedCarInfo)
                    End If

                    ' Save all details for the panel
                    Dim transactionDetails As New Dictionary(Of String, Object) From {
                        {"CarName", lblCarName.Text},
                        {"PaymentPerDay", lblPaymentPerDay.Text},
                        {"CarID", lblCarID.Text},
                        {"BodyNumber", lblBodyNumber.Text},
                        {"PlateNumber", lblPlateNumber.Text},
                        {"Color", lblColor.Text},
                        {"Capacity", lblCapacity.Text},
                        {"Type", lblType.Text},
                        {"TotalPayment", lblTotalPayment.Text},
                        {"RentedStarted", lblRentedStarted.Text},
                        {"RentedEnded", lblRentedEnded.Text},
                        {"DaysToBeRented", lblDaysToBeRented.Text},
                        {"Customer", lblCustomer.Text},
                        {"Address", lblAddress.Text},
                        {"Email", lblEmail.Text},
                        {"Age", paneling.Text}
                    }

                    ' Set the return deadline for the panel
                    Dim panelReturnEndTime As DateTime
                    If TransactionType = "RENT" Then
                        panelReturnEndTime = DateTime.Now.AddDays(Duration)
                    ElseIf TransactionType = "BOOK" AndAlso EndDate.HasValue Then
                        panelReturnEndTime = EndDate.Value
                    Else
                        panelReturnEndTime = DateTime.Now
                    End If
                    transactionDetails("ReturnDeadline") = panelReturnEndTime

                    ' Save to user's SavedBillingPanels
                    If Not loggedInUser.ContainsKey("SavedBillingPanels") OrElse loggedInUser("SavedBillingPanels") Is Nothing Then
                        loggedInUser("SavedBillingPanels") = New List(Of Dictionary(Of String, Object))()
                    End If
                    Dim savedPanels = CType(loggedInUser("SavedBillingPanels"), List(Of Dictionary(Of String, Object)))
                    savedPanels.Add(transactionDetails)

                    ' Reset all panels and timers, then reload
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

    Private Sub TransactionPanel_Click(sender As Object, e As EventArgs)
        Dim panel As Panel = TryCast(sender, Panel)
        If panel Is Nothing Then Return

        ' Revert all panels' age label to white
        lblAge.ForeColor = Color.White

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

        ' Set selected panel's age label to black
        lblAge.ForeColor = Color.Black

        SelectedPanel = panel

        Dim details = CType(panel.Tag, Dictionary(Of String, Object))
        lblCarName.Text = details("CarName")
        lblPaymentPerDay.Text = details("PaymentPerDay")
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
        lblAge.Text = details("Age") ' This should be "Age: XX"

        ' Check return status
        Dim isReturned As Boolean = False
        If details.ContainsKey("Status") AndAlso details("Status") IsNot Nothing Then
            isReturned = details("Status").ToString().ToLower() = "returned"
        End If

        If isReturned OrElse GlobalData.HasReturnedCarThisSession Then
            ' Both buttons disabled
            RoundedButton1.Enabled = False
            RoundedButton1.BackColor = Color.Gray
        Else
            ' Only confirm disabled, return enabled
            RoundedButton1.Enabled = False
            RoundedButton1.BackColor = Color.Gray
        End If
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
        ' Add any other buttons you want to disable here
    End Sub


    ' Deletes the currently selected panel from the UI and SavedBillingPanels
    Public Sub DeleteSelectedPanel()
        If SelectedPanel Is Nothing Then
            MessageBox.Show("No panel is selected.", "Delete Panel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Remove from UI
        FlowLayoutPanel1.Controls.Remove(SelectedPanel)

        ' Remove from SavedBillingPanels if possible
        Dim user = GlobalData.GetLoggedInUser()
        If user IsNot Nothing AndAlso user.ContainsKey("SavedBillingPanels") Then
            Dim panels = CType(user("SavedBillingPanels"), List(Of Dictionary(Of String, Object)))
            Dim details = TryCast(SelectedPanel.Tag, Dictionary(Of String, Object))
            If details IsNot Nothing AndAlso details.ContainsKey("CarID") Then
                Dim carIdToRemove = details("CarID").ToString()
                panels.RemoveAll(Function(panel)
                                     Return panel.ContainsKey("CarID") AndAlso panel("CarID").ToString() = carIdToRemove
                                 End Function)
            End If
        End If
        MarkCarAsReturned(SelectedPanel.Tag)
        SelectedPanel = Nothing
        GlobalData.NotifyDataChanged()
    End Sub

    ' Selects a car panel by CarID, highlights it, and updates the details display
    Public Sub SelectCarPanel(carId As String)
        For Each ctrl As Control In FlowLayoutPanel1.Controls
            If TypeOf ctrl Is Panel Then
                Dim panel = DirectCast(ctrl, Panel)
                Dim details = TryCast(panel.Tag, Dictionary(Of String, Object))
                If details IsNot Nothing AndAlso details.ContainsKey("CarID") AndAlso details("CarID").ToString() = carId Then
                    ' Highlight this panel
                    panel.BackColor = Color.White
                    For Each lbl In panel.Controls.OfType(Of Label)()
                        lbl.ForeColor = Color.Black
                    Next
                    SelectedPanel = panel
                    ' Update details display
                    TransactionPanel_Click(panel, EventArgs.Empty)
                Else
                    ' Unhighlight other panels
                    panel.BackColor = Color.DarkSlateBlue
                    For Each lbl In panel.Controls.OfType(Of Label)()
                        lbl.ForeColor = Color.White
                    Next
                End If
            End If
        Next
    End Sub

    Public Sub MarkCarAsReturned(transactionDetails As Dictionary(Of String, Object))
        ' Mark car as available
        Dim carID As String = transactionDetails("CarID").ToString()
        If GlobalData.CarsDict.ContainsKey(carID) Then
            GlobalData.CarsDict(carID)("IsAvailable") = True
        End If

        ' Mark transaction as returned (if you have a transaction ID, update it in TransactionsDict)
        For Each t In GlobalData.TransactionsDict.Values
            If t.ContainsKey("CarID") AndAlso t("CarID").ToString() = carID AndAlso t.ContainsKey("Status") AndAlso t("Status").ToString() <> "Returned" Then
                t("Status") = "Returned"
                t("DateReturned") = DateTime.Now
            End If
        Next

        ' Remove from user's rented cars list and update RentedCars count
        Dim user = GlobalData.GetLoggedInUser()
        If user IsNot Nothing AndAlso user.ContainsKey("RentedCarsList") Then
            Dim rentedCars = CType(user("RentedCarsList"), List(Of Dictionary(Of String, Object)))
            Dim removedCount = rentedCars.RemoveAll(Function(car) car("CarID").ToString() = carID)
            If removedCount > 0 AndAlso GlobalData.RentedCars > 0 Then
                GlobalData.RentedCars -= 1
            End If
        End If

        ' Remove returned panels from SavedBillingPanels
        If user IsNot Nothing AndAlso user.ContainsKey("SavedBillingPanels") Then
            Dim panels = CType(user("SavedBillingPanels"), List(Of Dictionary(Of String, Object)))
            panels.RemoveAll(Function(panel) panel("CarID").ToString() = carID)
        End If

        GlobalData.NotifyDataChanged()
    End Sub

    Function updateBalance()
        lblBalance.Text = $"Balance: ₱{GlobalData.Wallet:N2}"
    End Function

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
    End Sub

    ' In Billing.vb
    Public Sub StoreCarTransaction(transactionType As String, duration As Integer, totalPrice As Decimal, Optional startDate As Date? = Nothing, Optional endDate As Date? = Nothing)
        Dim CarId As String = If(SelectedCar IsNot Nothing AndAlso SelectedCar.ContainsKey("CarID"), SelectedCar("CarID").ToString(), "Unknown ID")
        Try
            Dim customerEmail As String = If(GlobalData.IsLoggedIn AndAlso Not String.IsNullOrEmpty(GlobalData.CurrentUserEmail), GlobalData.CurrentUserEmail, "guest@example.com")
            Dim isBooked As Boolean = (transactionType = "BOOK")

            ' Store transaction
            GlobalData.AddTransaction(
                CarId,
                customerEmail,
                If(startDate.HasValue, startDate.Value, DateTime.Now),
                If(endDate.HasValue, endDate.Value, DateTime.Now),
                totalPrice,
                If(isBooked, "Booked", "Rented")
            )
        Catch ex As Exception
            MessageBox.Show("Error storing transaction: " & ex.Message, "Transaction Error")
        End Try

        If transactionType = "BOOK" Then
            GlobalData.IsBooked = True
            GlobalData.RentalStartDate = startDate
            GlobalData.RentalEndDate = endDate
        End If

        GlobalData.CarRented = CarId

        ' Mark car as unavailable
        If GlobalData.CarsDict.ContainsKey(CarId) Then
            GlobalData.CarsDict(CarId)("IsAvailable") = False
        End If

        GlobalData.NotifyDataChanged()
    End Sub
End Class
