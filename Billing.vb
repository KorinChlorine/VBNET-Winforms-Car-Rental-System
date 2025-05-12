Public Class Billing
    Public Property SelectedCar As Dictionary(Of String, Object)
    Public Property TransactionType As String
    Public Property StartDate As DateTime?
    Public Property EndDate As DateTime?
    Public Property Duration As Integer

    Private SelectedPanel As Panel = Nothing

    Private Sub Billing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateBillingDetails()
        LoadSavedPanels()
    End Sub

    Private Sub UpdateBillingDetails()
        If SelectedCar IsNot Nothing Then
            lblCarName.Text = "Car Name: " + SelectedCar("CarName")?.ToString()
            lblPaymentPerDay.Text = $"Payment/day: ₱{Convert.ToDecimal(SelectedCar("DailyPrice")):N2}"
            lblCarID.Text = "Car ID: " + (SelectedCar("CarID")?.ToString())
            lblBodyNumber.Text = "Body Number: " + (SelectedCar("BodyNumber")?.ToString())
            lblPlateNumber.Text = "Plate Number: " + (SelectedCar("PlateNumber")?.ToString())
            lblColor.Text = "Color: " + (SelectedCar("Color")?.ToString())
            lblCapacity.Text = "Capacity: " + (SelectedCar("Capacity")?.ToString())
            lblType.Text = "Type: " + (SelectedCar("CarType")?.ToString())

            Dim dailyPrice As Decimal = Convert.ToDecimal(SelectedCar("DailyPrice"))
            Dim rentalDays As Integer = (GlobalData.RentalEndDate?.Subtract(GlobalData.RentalStartDate).Days).GetValueOrDefault(0)
            lblTotalPayment.Text = $"Total Payment: ₱{(dailyPrice * rentalDays):N2}"
            lblRentedStarted.Text = "Rented Start Date: " + (GlobalData.RentalStartDate?.ToString("MMMM dd, yyyy"))
            lblRentedEnded.Text = "Rented End Date: " + (GlobalData.RentalEndDate?.ToString("MMMM dd, yyyy"))
            lblDaysToBeRented.Text = "Days to be Rented: " + (rentalDays.ToString())
        Else
            lblCarName.Text = "No car selected"
        End If

        lblCustomer.Text = "Customer Name: " + GlobalData.UserFullName
        lblAddress.Text = "Address: " + GlobalData.Address
        lblEmail.Text = "Email: " + GlobalData.CurrentUserEmail
        lblAge.Text = "Age: " + GlobalData.Age.ToString()
        lblUserStatus.Text = "User Status: " + If(GlobalData.IsLoggedIn, "Logged In", "Guest")
        lblBalance.Text = $"Wallet Balance: ₱{GlobalData.Wallet:N2}"

        ' Enable the confirm button by default
        RoundedButton1.Enabled = True
        RoundedButton1.BackColor = Color.FromArgb(0, 120, 215) ' Or your normal color
    End Sub

    Private Sub LoadSavedPanels()
        FlowLayoutPanel1.Controls.Clear()
        Dim loggedInUser = GlobalData.GetLoggedInUser()
        If loggedInUser IsNot Nothing AndAlso loggedInUser.ContainsKey("SavedBillingPanels") Then
            Dim savedPanels = CType(loggedInUser("SavedBillingPanels"), List(Of Dictionary(Of String, Object)))
            For Each transactionDetails In savedPanels
                CreateTransactionPanel(transactionDetails)
            Next
        End If
    End Sub

    Private Sub CreateTransactionPanel(transactionDetails As Dictionary(Of String, Object))
        Dim transPanel As New Panel With {
            .Width = 250,
            .Height = 60,
            .BackColor = Color.LightGray,
            .Cursor = Cursors.Hand,
            .Margin = New Padding(5)
        }
        Dim lbl As New Label With {
            .Text = transactionDetails("CarName") & " | " & transactionDetails("TotalPayment"),
            .AutoSize = True,
            .Location = New Point(10, 20)
        }
        transPanel.Controls.Add(lbl)
        transPanel.Tag = transactionDetails
        AddHandler transPanel.Click, AddressOf TransactionPanel_Click
        AddHandler lbl.Click, Sub(s, ev) TransactionPanel_Click(transPanel, ev)
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
                lblBalance.Text = $"₱{GlobalData.Wallet:N2}"

                Dim loggedInUser = GlobalData.GetLoggedInUser()
                If loggedInUser IsNot Nothing Then
                    If Not loggedInUser.ContainsKey("RentedCarsList") OrElse loggedInUser("RentedCarsList") Is Nothing Then
                        loggedInUser("RentedCarsList") = New List(Of Dictionary(Of String, Object))()
                    End If
                    Dim rentedCars = CType(loggedInUser("RentedCarsList"), List(Of Dictionary(Of String, Object)))
                    If Not rentedCars.Any(Function(car) car("CarID")?.ToString() = SelectedCar("CarID")?.ToString()) Then
                        rentedCars.Add(SelectedCar)
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
                        {"Age", lblAge.Text}
                    }

                    ' Save to user's SavedBillingPanels
                    If Not loggedInUser.ContainsKey("SavedBillingPanels") OrElse loggedInUser("SavedBillingPanels") Is Nothing Then
                        loggedInUser("SavedBillingPanels") = New List(Of Dictionary(Of String, Object))()
                    End If
                    Dim savedPanels = CType(loggedInUser("SavedBillingPanels"), List(Of Dictionary(Of String, Object)))
                    savedPanels.Add(transactionDetails)

                    ' Create the panel in the UI
                    CreateTransactionPanel(transactionDetails)
                End If

                MessageBox.Show("Payment successful and car data saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        For Each ctrl As Control In FlowLayoutPanel1.Controls
            If TypeOf ctrl Is Panel Then
                ctrl.BackColor = Color.LightGray
            End If
        Next
        panel.BackColor = Color.LightBlue
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
        lblAge.Text = details("Age")

        ' Grey out and disable RoundedButton1
        RoundedButton1.Enabled = False
        RoundedButton1.BackColor = Color.Gray
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        WalletAdd.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        WalletAdd.Show()
    End Sub
End Class
