Public Class Billing
    Public Property SelectedCar As Object()
    Public Property TransactionType As String
    Public Property StartDate As DateTime?
    Public Property EndDate As DateTime?
    Public Property Duration As Integer
    Private Sub Billing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate the form with data from the selected car
        UpdateBillingDetails()
    End Sub

    Private Sub UpdateBillingDetails()
        If SelectedCar IsNot Nothing Then
            ' Update car details
            lblCarName.Text = "Car Name: " + SelectedCar(0)?.ToString()
            lblPaymentPerDay.Text = $"Payment/day: ₱{Convert.ToDecimal(SelectedCar(11)):N2}"
            lblCarID.Text = "Car ID: " + (SelectedCar(8)?.ToString())
            lblBodyNumber.Text = "Body Number: " + (SelectedCar(9)?.ToString())
            lblPlateNumber.Text = "Plate Number: " + (SelectedCar(10)?.ToString())
            lblColor.Text = "Color: " + (SelectedCar(5)?.ToString())
            lblCapacity.Text = "Capacity: " + (SelectedCar(4)?.ToString())
            lblType.Text = "Type: " + (SelectedCar(3)?.ToString())

            ' Calculate total payment and rental duration
            Dim dailyPrice As Decimal = Convert.ToDecimal(SelectedCar(11))
            Dim rentalDays As Integer = (GlobalData.RentalEndDate?.Subtract(GlobalData.RentalStartDate).Days).GetValueOrDefault(0)
            lblTotalPayment.Text = $"Total Payment: ₱{(dailyPrice * rentalDays):N2}"
            lblRentedStarted.Text = "Rented Start Date: " + (GlobalData.RentalStartDate?.ToString("MMMM dd, yyyy"))
            lblRentedEnded.Text = "Rented End Date: " + (GlobalData.RentalEndDate?.ToString("MMMM dd, yyyy"))
            lblDaysToBeRented.Text = "Days to be Rented: " + (rentalDays.ToString())
        Else
            lblCarName.Text = "No car selected"
        End If

        ' Update customer details
        lblCustomer.Text = "Customer Name: " + GlobalData.UserFullName
        lblAddress.Text = "Address: " + GlobalData.Address
        lblEmail.Text = "Email: " + GlobalData.CurrentUserEmail
        lblAge.Text = "Age: " + GlobalData.Age.ToString()

        ' Update wallet details
        lblUserStatus.Text = "User Status: " + If(GlobalData.IsLoggedIn, "Logged In", "Guest")
        lblBalance.Text = $"Wallet Balance: ₱{GlobalData.Wallet:N2}"
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        homeForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        rent_a_car.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RentalDetail.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ViewCars.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'meet_the_devs
        Me.Hide()
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Hide()
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click

        GlobalData.Wallet = 1000000000
        ' Ensure the user is logged in
        If Not GlobalData.IsLoggedIn Then
            MessageBox.Show("You must be logged in to confirm the transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if the user has enough balance
        Dim totalPaymentText As String = lblTotalPayment.Text.Replace("Total Payment: ₱", "").Replace(",", "").Trim()
        Dim totalPayment As Decimal

        If Decimal.TryParse(totalPaymentText, totalPayment) Then
            Dim walletBalance As Decimal = GlobalData.Wallet
            If walletBalance >= totalPayment Then
                ' Deduct the payment from the wallet
                GlobalData.Wallet -= totalPayment
                lblBalance.Text = $"₱{GlobalData.Wallet:N2}"

                ' Save the selected car data to the logged-in user's record
                Dim loggedInUser = GlobalData.GetLoggedInUser()
                If loggedInUser IsNot Nothing Then
                    ' Ensure the RentedCars list exists
                    If loggedInUser.Length < 4 OrElse loggedInUser(3) Is Nothing Then
                        loggedInUser = loggedInUser.Concat({New List(Of Object())()}).ToArray()
                        GlobalData.UsersList(GlobalData.UsersList.IndexOf(loggedInUser)) = loggedInUser
                    End If

                    Dim rentedCars = CType(loggedInUser(3), List(Of Object()))
                    ' Prevent duplicate entries
                    If Not rentedCars.Any(Function(car) car(8)?.ToString() = SelectedCar(8)?.ToString()) Then
                        rentedCars.Add(SelectedCar)
                    End If
                End If

                ' Show success message
                MessageBox.Show("Payment successful and car data saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Insufficient balance in wallet.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Invalid total payment format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class