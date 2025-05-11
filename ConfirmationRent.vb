Imports System.IO
Imports MySql.Data.MySqlClient

Public Class ConfirmationRent
    ' Properties to store transaction data
    Public Property TransactionType As String
    Public Property CarName As String
    Public Property CarID As String
    Public Property Duration As Integer
    Public Property TotalPrice As Decimal
    Public Property StartDate As DateTime?
    Public Property EndDate As DateTime?
    Public Property DailyPrice As Decimal
    Public Property Customer As String

    Private Sub ConfirmationRent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AxWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, "confirm.mp4")
            AxWindowsMediaPlayer1.settings.setMode("loop", True)
            AxWindowsMediaPlayer1.Ctlcontrols.play()


        ' Load the most recent transaction data
        LoadTransactionData()

        ' Display transaction data in the form controls
        PopulateReceipt()
    End Sub

    Private Sub LoadTransactionData()
        ' Get the most recent transaction from GlobalData
        If GlobalData.Transactions.Count > 0 Then
            Dim lastTransaction As Dictionary(Of String, Object) = GlobalData.Transactions.Last()

            ' Load values from the transaction dictionary
            TransactionType = lastTransaction("TransactionType").ToString()
            CarName = lastTransaction("CarName").ToString()
            CarID = lastTransaction("CarID").ToString()
            Duration = Convert.ToInt32(lastTransaction("Duration"))
            TotalPrice = Convert.ToDecimal(lastTransaction("TotalPrice"))
            DailyPrice = TotalPrice / Duration

            ' Handle optional date values
            If lastTransaction.ContainsKey("StartDate") AndAlso lastTransaction("StartDate") IsNot Nothing Then
                StartDate = CType(lastTransaction("StartDate"), DateTime)
            End If

            If lastTransaction.ContainsKey("EndDate") AndAlso lastTransaction("EndDate") IsNot Nothing Then
                EndDate = CType(lastTransaction("EndDate"), DateTime)
            End If

            ' Get customer info from GlobalData
            If GlobalData.IsLoggedIn Then
                Customer = GlobalData.UserFullName
            Else
                Customer = "Guest Customer" ' Default value if not logged in
            End If
        End If
    End Sub

    Private Sub PopulateReceipt()
        ' Update UI based on the type of transaction (BOOK or RENT)
        If TransactionType = "BOOK" Then
            lblTransactionType.Text = "Book"
        Else
            lblTransactionType.Text = "Rent"
        End If

        ' Update car information
        lblCarName.Text = CarName

        ' Format and display dates or rental days based on transaction type
        If TransactionType = "BOOK" AndAlso StartDate.HasValue AndAlso EndDate.HasValue Then
            lblRentedStarted.Text = StartDate.Value.ToString("MMMM dd, yyyy")
            lblRentedEnded.Text = EndDate.Value.ToString("MMMM dd, yyyy")
            lblDaysToBeRented.Text = Duration.ToString()
        Else
            lblRentedStarted.Text = DateTime.Now.ToString("MMMM dd, yyyy")
            lblRentedEnded.Text = DateTime.Now.AddDays(Duration).ToString("MMMM dd, yyyy")
            lblDaysToBeRented.Text = Duration.ToString()
        End If

        ' Display payment information
        lblPaymentPerDay.Text = String.Format("₱{0:N2}", DailyPrice)
        lblTotalPayment.Text = String.Format("₱{0:N2}", TotalPrice)
        lblCurrentBalance.Text = String.Format("₱{0:N2}", TotalPrice) ' Assuming full payment is due

        ' Display customer information
        lblCustomer.Text = Customer

        ' Display car ID
        lblCarID.Text = CarID

        ' Update GlobalData with the rental information
        GlobalData.CarRented = CarID
        If StartDate.HasValue Then
            GlobalData.RentalStartDate = StartDate
        End If
        If EndDate.HasValue Then
            GlobalData.RentalEndDate = EndDate
        End If
        GlobalData.IsBooked = True
    End Sub

    Private Sub btnConfirmPayment_Click(sender As Object, e As EventArgs) Handles btnConfirmPayment.Click
        ' Process payment confirmation
        Dim walletBalance As Double = GlobalData.Wallet
        Dim paymentAmount As Double = TotalPrice

        ' Check if user has enough balance in wallet
        If walletBalance >= paymentAmount Then
            ' Deduct payment from wallet
            GlobalData.Wallet -= paymentAmount

            MessageBox.Show($"Payment of {lblTotalPayment.Text} has been confirmed for {CarName}. Your remaining wallet balance is ₱{GlobalData.Wallet:N2}", "Payment Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Update GlobalData
            GlobalData.RentedCars += 1
            GlobalData.NotifyDataChanged()

            ' Close this form
            Me.Close()
        Else
            ' Not enough balance
            MessageBox.Show($"Insufficient funds. Your current wallet balance is ₱{walletBalance:N2}. Please add funds to your wallet.", "Payment Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            ' Optionally open wallet topup form
            ' Dim topUpForm As New WalletTopUp()
            ' topUpForm.ShowDialog()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Handle cancellation
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel this transaction?", "Cancel Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            ' Revert the car availability status in your car list
            For Each car In GlobalData.CarsList
                If car IsNot Nothing AndAlso car.Length > 8 AndAlso car(8)?.ToString() = CarID Then
                    car(12) = True ' Set car as available again
                    Exit For
                End If
            Next

            ' Remove the transaction from GlobalData
            If GlobalData.Transactions.Count > 0 Then
                GlobalData.Transactions.RemoveAt(GlobalData.Transactions.Count - 1)
            End If

            ' Reset booking status
            GlobalData.IsBooked = False
            GlobalData.CarRented = ""
            GlobalData.RentalStartDate = Nothing
            GlobalData.RentalEndDate = Nothing

            GlobalData.NotifyDataChanged()
            Me.Close()
        End If
    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles RoundedButton3.Click
        Me.Close()
        Billing.Show()

    End Sub
End Class