Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Xml

Public Class rent_a_car2

    Public Property TransactionType As String
    Public Property CarName As String
    Public Property CarID As String
    Public Property Duration As Integer
    Public Property TotalPrice As Decimal
    Public Property StartDate As DateTime?
    Public Property EndDate As DateTime?
    Public Property DailyPrice As Decimal
    Public Property Customer As String

    Public Property SelectedCar As Object()
    Private SelectedPanel As Panel
    Private WithEvents Timer1 As New Timer()

    Private Sub ResetForm()
        PictureBox1.Image = Nothing
        Label1.Text = String.Empty
        Label3.Text = String.Empty
        SelectedCar = Nothing
        SelectedPanel = Nothing
    End Sub

    Private Sub rent_a_car2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyRoundedCornersToPictureBox(PictureBox1, 20)
        PopulateForm()
        Timer1.Interval = 1000
        Timer1.Start()
        UpdateButtonStyles(RoundedButton4)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LabelTime.Text = DateTime.Now.ToString("hh:mm:ss tt")
        LabelDate.Text = DateTime.Now.ToString("MMMM dd, yyyy")
    End Sub

    Private Sub PopulateForm()
        If SelectedCar IsNot Nothing Then
            ' Determine if the car is PREMIUM
            Dim dailyPrice As Decimal
            Dim isPremium As Boolean = Decimal.TryParse(SelectedCar(11)?.ToString(), dailyPrice) AndAlso dailyPrice >= 10000

            ' Update Label8.Text with PREMIUM status and price per day
            Label8.Text = If(isPremium, "PREMIUM", "STANDARD") & $" - Price per day: P{dailyPrice:N2}"

            ' Set the car image
            PictureBox1.Image = TryCast(SelectedCar(1), Image)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

            ' Set the car details
            Label1.Text = SelectedCar(6)?.ToString()
            Label1.TextAlign = ContentAlignment.MiddleCenter
            Label3.Text = SelectedCar(0)?.ToString()

            ' Check if the car is unavailable
            Dim isAvailable As Boolean = False
            If SelectedCar.Length > 12 Then
                Boolean.TryParse(SelectedCar(12)?.ToString(), isAvailable)
            End If

            ' Add "NOT AVAILABLE" label if the car is unavailable
            If Not isAvailable Then
                Dim notAvailableLabel As New Label With {
                .Text = "NOT AVAILABLE",
                .AutoSize = False,
                .Size = New Size(PictureBox1.Width, 30),
                .BackColor = Color.Red,
                .ForeColor = Color.White,
                .Font = New Font("Arial", 10, FontStyle.Bold),
                .TextAlign = ContentAlignment.MiddleCenter
            }
                notAvailableLabel.Location = New Point(0, PictureBox1.Height - notAvailableLabel.Height)
                PictureBox1.Controls.Add(notAvailableLabel)
                notAvailableLabel.BringToFront()
            End If

            ' Enable or disable RoundedButton5 based on availability and radio button state
            UpdateRoundedButton5State(isAvailable)
        End If
    End Sub


    Private Sub UpdateRoundedButton5State(isAvailable As Boolean)
        If isAvailable AndAlso RadioButton1.Checked Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
            RoundedButton5.Enabled = True
            RoundedButton5.Text = "BOOK"
            RoundedButton5.BackColor = Color.White
            RoundedButton5.ForeColor = Color.DarkSlateBlue
            RoundedButton5.Font = New Font("League Spartan", 30, FontStyle.Bold)
        ElseIf isAvailable AndAlso RadioButton2.Checked Then
            RadioButton2.Checked = True
            RadioButton1.Checked = False
            RoundedButton5.Enabled = True
            RoundedButton5.Text = "RENT"
            RoundedButton5.BackColor = Color.White
            RoundedButton5.ForeColor = Color.DarkSlateBlue
            RoundedButton5.Font = New Font("League Spartan", 30, FontStyle.Bold)
        Else
            RoundedButton5.Enabled = False
            RoundedButton5.Text = "NOT AVAILABLE"
            RoundedButton5.BackColor = Color.Gray
            RoundedButton5.ForeColor = Color.LightGray
            RoundedButton5.Font = New Font("League Spartan", 20, FontStyle.Bold)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        rent_a_car.Show()
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        PopulateForm()
    End Sub

    Private Sub DrawRoundedPanel(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = CType(sender, Panel)
        Dim graphics As Graphics = e.Graphics
        Dim rect As Rectangle = panel.ClientRectangle
        Dim radius As Integer = 20

        Using path As New Drawing2D.GraphicsPath()
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
            path.CloseFigure()

            panel.Region = New Region(path)
            graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Using brush As New SolidBrush(panel.BackColor)
                graphics.FillPath(brush, path)
            End Using
        End Using
    End Sub

    Private Sub ApplyRoundedCornersToPictureBox(pictureBox As PictureBox, cornerRadius As Integer)
        Dim rect As New Rectangle(0, 0, pictureBox.Width, pictureBox.Height)
        Dim path As New Drawing2D.GraphicsPath()

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseFigure()

        pictureBox.Region = New Region(path)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Dim isAvailable As Boolean = False
        If SelectedCar IsNot Nothing AndAlso SelectedCar.Length > 12 Then
            Boolean.TryParse(SelectedCar(12)?.ToString(), isAvailable)
        End If
        UpdateRoundedButton5State(isAvailable)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Dim isAvailable As Boolean = False
        If SelectedCar IsNot Nothing AndAlso SelectedCar.Length > 12 Then
            Boolean.TryParse(SelectedCar(12)?.ToString(), isAvailable)
        End If
        UpdateRoundedButton5State(isAvailable)
    End Sub

    Private selectedButton As Button = Nothing

    Private Sub UpdateButtonStyles(clickedButton As Button)
        If selectedButton IsNot Nothing Then
            selectedButton.BackColor = Color.DarkSlateBlue
            selectedButton.ForeColor = Color.White
        End If

        clickedButton.BackColor = Color.White
        clickedButton.ForeColor = Color.DarkSlateBlue
        selectedButton = clickedButton
    End Sub

    Private Sub RoundedButton4_Click(sender As Object, e As EventArgs) Handles RoundedButton4.Click
        UpdateButtonStyles(RoundedButton4)
        Label1.Font = New Font(Label1.Font.FontFamily, 14)
        Label1.Text = SelectedCar(6)?.ToString()
        Label2.Text = "Brief Description"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        Label1.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles RoundedButton3.Click
        UpdateButtonStyles(RoundedButton3)
        Label2.Text = "Pricing"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        Label1.Font = New Font(Label1.Font.FontFamily, 20)
        Label1.TextAlign = ContentAlignment.MiddleCenter
        Dim dailyPrice As Decimal
        If Not Decimal.TryParse(SelectedCar(11)?.ToString(), dailyPrice) Then
            Label1.Text = "Invalid daily price"
            Return
        End If

        Dim numberOfDays As Integer

        If RadioButton1.Checked Then
            Dim selectedStartDate As DateTime = startBook.Value
            Dim selectedEndDate As DateTime = endBook.Value
            numberOfDays = (selectedEndDate - selectedStartDate).Days

            If numberOfDays <= 0 Then
                Label1.Text = "Invalid booking duration"
                Return
            End If
        ElseIf RadioButton2.Checked Then
            If Not Integer.TryParse(TextBox1.Text, numberOfDays) OrElse numberOfDays <= 0 Then
                Label1.Text = "Invalid number of days"
                Return
            End If
        Else
            Label1.Text = "Please select a booking or rent option"
            Return
        End If

        Dim totalPrice As Decimal = dailyPrice * numberOfDays
        Label1.Text = $"The total price for {numberOfDays} days is P{totalPrice:N2}"
    End Sub


    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles RoundedButton2.Click
        UpdateButtonStyles(RoundedButton2)
        Label2.Text = "Specifications"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        Label1.Font = New Font(Label1.Font.FontFamily, 18)
        Label1.TextAlign = ContentAlignment.MiddleLeft
        If SelectedCar IsNot Nothing Then
            Dim specifications As String = $"Car Name: {SelectedCar(0)?.ToString()}" & Environment.NewLine &
                                       $"Car Type: {SelectedCar(3)?.ToString()}" & Environment.NewLine &
                                       $"Capacity: {SelectedCar(4)?.ToString()}" & Environment.NewLine &
                                       $"Color: {SelectedCar(5)?.ToString()}" & Environment.NewLine &
                                       $"Car ID: {SelectedCar(8)?.ToString()}" & Environment.NewLine &
                                       $"Body Number: {SelectedCar(9)?.ToString()}" & Environment.NewLine &
                                       $"Plate Number: {SelectedCar(10)?.ToString()}" & Environment.NewLine &
                                       $"Daily Price: P{SelectedCar(11)?.ToString()}" & Environment.NewLine &
                                       $"Availability: {(If(Convert.ToBoolean(SelectedCar(12)), "Available", "Not Available"))}"
            Label1.Text = specifications
        Else
            Label1.Text = "No car selected."
        End If
    End Sub


    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        UpdateButtonStyles(RoundedButton1)
        Label2.Text = "Background"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        Label1.Text = SelectedCar(7)?.ToString()
        Label1.TextAlign = ContentAlignment.MiddleLeft
        PictureBox1.Image = TryCast(SelectedCar(2), Image)
        Label1.Font = New Font(Label1.Font.FontFamily, 12)
    End Sub

    Private Sub RoundedButton5_Click(sender As Object, e As EventArgs) Handles RoundedButton5.Click
        Dim selectedStartDate As DateTime = startBook.Value
        Dim selectedEndDate As DateTime = endBook.Value
        Dim differenceInDays As Integer = (selectedEndDate - selectedStartDate).Days

        If GlobalData.RentedCars < 3 Then
            If RadioButton1.Checked Then ' BOOK option selected
                If selectedStartDate > selectedEndDate Then
                    MessageBox.Show("Start date cannot be later than the end date.", "Invalid Dates")
                    Return
                End If

                If selectedStartDate = selectedEndDate Then
                    MessageBox.Show("Start date cannot be equal to the end date.", "Invalid Dates")
                    Return
                End If

                Dim dailyPrice As Decimal = Convert.ToDecimal(SelectedCar(11))
                Dim totalPrice As Decimal = dailyPrice * differenceInDays

                ' Store booking information
                StoreCarTransaction("BOOK", differenceInDays, totalPrice, selectedStartDate, selectedEndDate)

                ' Open the Billing form and pass the selected car and transaction details
                Dim billingForm As New Billing()
                billingForm.SelectedCar = SelectedCar
                billingForm.TransactionType = "BOOK"
                billingForm.StartDate = selectedStartDate
                billingForm.EndDate = selectedEndDate
                billingForm.Show()
            End If

            If RadioButton2.Checked Then ' RENT option selected
                Dim numberOfDays As Integer
                If Not Integer.TryParse(TextBox1.Text, numberOfDays) OrElse numberOfDays <= 0 Then
                    MessageBox.Show("Please enter a valid number of days.", "Invalid Input")
                    Return
                End If

                Dim dailyPrice As Decimal = Convert.ToDecimal(SelectedCar(11))
                Dim totalPrice As Decimal = dailyPrice * numberOfDays

                ' Store rental information
                StoreCarTransaction("RENT", numberOfDays, totalPrice)

                ' Open the Billing form and pass the selected car and transaction details
                Dim billingForm As New Billing()
                billingForm.SelectedCar = SelectedCar
                billingForm.TransactionType = "RENT"
                billingForm.StartDate = DateTime.Now
                billingForm.Duration = numberOfDays
                billingForm.Show()
            End If
        Else
            MessageBox.Show("You have reached the maximum number of rented cars (3).", "Limit Reached")
            Return
        End If
    End Sub


    Private Sub StoreCarTransaction(transactionType As String, duration As Integer, totalPrice As Decimal, Optional startDate As Date? = Nothing, Optional endDate As Date? = Nothing)
        Dim CarId As String = "Unknown ID"
        Try
            ' Default dates if not provided for RENT option
            If transactionType = "RENT" Then
                If Not startDate.HasValue Then startDate = DateTime.Now
                If Not endDate.HasValue Then endDate = DateTime.Now.AddDays(duration)
            End If

            ' Ensure startDate and endDate have values before accessing .Value
            If Not startDate.HasValue OrElse Not endDate.HasValue Then
                Throw New InvalidOperationException("Start date or end date is not properly initialized.")
            End If

            ' Prepare individual values with null checks
            Dim carName As String = If(SelectedCar(0)?.ToString(), "Unknown Car")
            CarId = If(SelectedCar(8)?.ToString(), "Unknown ID")
            Dim plateNumber As String = If(SelectedCar(10)?.ToString(), "Unknown Plate")
            Dim bodyNumber As String = If(SelectedCar(9)?.ToString(), "Unknown Body")
            Dim color As String = If(SelectedCar(5)?.ToString(), "Unknown Color")
            Dim type As String = If(SelectedCar(3)?.ToString(), "Unknown Type")
            Dim capacity As String = If(SelectedCar(4)?.ToString(), "Unknown Capacity")
            Dim dailyPrice As Decimal = If(Decimal.TryParse(SelectedCar(11)?.ToString(), dailyPrice), dailyPrice, 0)

            Dim customerName As String = If(GlobalData.IsLoggedIn AndAlso Not String.IsNullOrEmpty(GlobalData.UserFullName), GlobalData.UserFullName, "Guest")
            Dim customerEmail As String = If(GlobalData.IsLoggedIn AndAlso Not String.IsNullOrEmpty(GlobalData.CurrentUserEmail), GlobalData.CurrentUserEmail, "guest@example.com")
            Dim customerAddress As String = If(GlobalData.IsLoggedIn AndAlso Not String.IsNullOrEmpty(GlobalData.Address), GlobalData.Address, "Unknown Address")
            Dim customer As String = customerName ' Use customerName as the value for the 'customer' parameter

            Dim isBooked As Boolean = (transactionType = "BOOK")

            ' Add the transaction to the GlobalData module
            GlobalData.AddTransaction(
            carName,
            CarId,
            plateNumber,
            bodyNumber,
            color,
            type,
            capacity,
            dailyPrice,
            totalPrice,
            customerName,
            customerEmail,
            customerAddress,
            customer,
            isBooked,
            startDate.Value,
            endDate.Value,
            Nothing ' dateReturned set to Nothing since car is newly rented
        )
        Catch ex As Exception
            MessageBox.Show("Error storing transaction: " & ex.Message, "Transaction Error")
        End Try

        ' Update global state
        If transactionType = "BOOK" Then
            GlobalData.IsBooked = True
            GlobalData.RentalStartDate = startDate
            GlobalData.RentalEndDate = endDate
        End If

        GlobalData.CarRented = CarId

        ' Mark car as unavailable in CarsList
        For i As Integer = 0 To GlobalData.CarsList.Count - 1
            If GlobalData.CarsList(i)(8)?.ToString() = CarId Then
                GlobalData.CarsList(i)(12) = False ' Assuming index 12 is availability
                Exit For
            End If
        Next

        GlobalData.NotifyDataChanged()
    End Sub


End Class