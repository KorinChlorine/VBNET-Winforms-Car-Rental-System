Public Class RentalDetail
    Private selectedPanel As Panel = Nothing
    Private selectedTransactionId As Integer = 0

    Private Sub RentalDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserRentedPanels()
    End Sub

    Private Sub LoadUserRentedPanels()
        FlowLayoutPanel1.Controls.Clear()
        Dim transactions = GlobalData.GetCustomerTransactions(GlobalData.CurrentUserEmail)
        For Each trans In transactions
            AddRentalPanelToUI(trans)
        Next
    End Sub

    Private Sub AddRentalPanelToUI(transDict As Dictionary(Of String, Object))
        Dim panel1 As New Panel With {
    .Width = 190,
    .Height = 33,
    .BackColor = Color.DarkSlateBlue,
    .ForeColor = Color.White,
    .Cursor = Cursors.Hand,
    .Margin = New Padding(3)
}


        Dim carName As String = If(transDict.ContainsKey("CarName"), transDict("CarName").ToString(),
                              If(GlobalData.CarsDict.ContainsKey(transDict("CarID").ToString()),
                                 GlobalData.CarsDict(transDict("CarID").ToString())("CarName").ToString(), "Unknown Car"))

        Dim lbl As New Label With {
            .Text = carName,
            .AutoSize = True,
            .Font = New Font("Arial", 10, FontStyle.Bold)
        }
        lbl.Location = New Point((panel1.Width - lbl.PreferredWidth) \ 2, (panel1.Height - lbl.PreferredHeight) \ 2)

        panel1.Controls.Add(lbl)
        panel1.Tag = transDict
        AddHandler panel1.Click, AddressOf Panel_Click
        AddHandler lbl.Click, Sub(s, ev) Panel_Click(panel1, ev)

        ApplyRoundedCornersToPanel(panel1, 20)
        FlowLayoutPanel1.Controls.Add(panel1)
    End Sub

    Private Sub Panel_Click(sender As Object, e As EventArgs)
        Dim panel As Panel = CType(sender, Panel)
        If selectedPanel IsNot Nothing Then
            selectedPanel.BackColor = Color.DarkSlateBlue
            For Each lbl In selectedPanel.Controls.OfType(Of Label)()
                lbl.ForeColor = Color.White
            Next
        End If

        panel.BackColor = Color.White
        For Each lbl In panel.Controls.OfType(Of Label)()
            lbl.ForeColor = Color.Black
        Next

        selectedPanel = panel

        ' Get transaction details
        Dim details = CType(panel.Tag, Dictionary(Of String, Object))

        ' Get car details
        Dim carDict As Dictionary(Of String, Object) = Nothing
        If details.ContainsKey("CarID") AndAlso GlobalData.CarsDict.ContainsKey(details("CarID").ToString()) Then
            carDict = GlobalData.CarsDict(details("CarID").ToString())
        End If

        ' Get user details
        Dim userDict As Dictionary(Of String, Object) = Nothing
        If details.ContainsKey("CustomerEmail") AndAlso GlobalData.UsersDict.ContainsKey(details("CustomerEmail").ToString()) Then
            userDict = GlobalData.UsersDict(details("CustomerEmail").ToString())
        End If


        If carDict IsNot Nothing AndAlso carDict.ContainsKey("CarName") Then
            Label1.Text = carDict("CarName").ToString()
        ElseIf details.ContainsKey("CarName") Then
            Label1.Text = details("CarName").ToString()
        Else
            Label1.Text = "Unknown Car"
        End If

      
        If carDict IsNot Nothing AndAlso carDict.ContainsKey("PrimaryImage") AndAlso carDict("PrimaryImage") IsNot Nothing Then
            PictureBox1.Image = TryCast(carDict("PrimaryImage"), Image)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Else
            PictureBox1.Image = Nothing
        End If

        ' Panel2 - Rent Info
        lblRentStart.Text = "Rent Start: " & If(details.ContainsKey("StartDate"), CDate(details("StartDate")).ToString("MMMM dd, yyyy"), "N/A")
        lblRentEnd.Text = "Rent End: " & If(details.ContainsKey("EndDate"), CDate(details("EndDate")).ToString("MMMM dd, yyyy"), "N/A")
        lblPaymentPerDay.Text = "Payment/Day: ₱" & If(carDict IsNot Nothing AndAlso carDict.ContainsKey("DailyPrice"),
        Convert.ToDecimal(carDict("DailyPrice")).ToString("N2"), "N/A")
        lblPaymentTotal.Text = "Total Payment: ₱" & If(details.ContainsKey("TotalPrice"),
        Convert.ToDecimal(details("TotalPrice")).ToString("N2"), "N/A")
        lblRentStatus.Text = "Status: " & If(details.ContainsKey("Status"), details("Status").ToString(), "N/A")

        ' Panel3 - Customer Info
        lblCustomerName.Text = "Customer Name: " & If(details.ContainsKey("CustomerName"), details("CustomerName").ToString(),
        If(userDict IsNot Nothing AndAlso userDict.ContainsKey("FullName"), userDict("FullName").ToString(), "N/A"))
        lblCustomerEmail.Text = "Customer Email: " & If(details.ContainsKey("CustomerEmail"), details("CustomerEmail").ToString(), "N/A")

        ' Panel4 - Car Description
        lblCarDescription.Text = "Description: " & If(carDict IsNot Nothing AndAlso carDict.ContainsKey("Details"),
        carDict("Details").ToString(), "N/A")

        ' Car Info
        lblCarID.Text = "Car ID: " & If(carDict IsNot Nothing AndAlso carDict.ContainsKey("CarID"), carDict("CarID").ToString(), "N/A")
        lblBodyNumber.Text = "Body Number: " & If(carDict IsNot Nothing AndAlso carDict.ContainsKey("BodyNumber"), carDict("BodyNumber").ToString(), "N/A")
        lblPlateNumber.Text = "Plate Number: " & If(carDict IsNot Nothing AndAlso carDict.ContainsKey("PlateNumber"), carDict("PlateNumber").ToString(), "N/A")
        lblCarColor.Text = "Color: " & If(carDict IsNot Nothing AndAlso carDict.ContainsKey("Color"), carDict("Color").ToString(), "N/A")
        lblCarType.Text = "Type: " & If(carDict IsNot Nothing AndAlso carDict.ContainsKey("Type"), carDict("Type").ToString(), "N/A")
        lblCarCapacity.Text = "Capacity: " & If(carDict IsNot Nothing AndAlso carDict.ContainsKey("Capacity"), carDict("Capacity").ToString(), "N/A")


        If details.ContainsKey("TransactionID") Then
            Dim transactionIdStr As String = details("TransactionID").ToString()
            Dim transactionId As Integer
            If Integer.TryParse(transactionIdStr, transactionId) AndAlso GlobalData.TransactionsDict.ContainsKey(transactionId) Then
                Dim latestTrans = GlobalData.TransactionsDict(transactionId)

                If details.ContainsKey("TransactionID") Then
                    Integer.TryParse(details("TransactionID").ToString(), selectedTransactionId)

                    Dim startDate1 As DateTime
                    If details.ContainsKey("StartDate") AndAlso DateTime.TryParse(details("StartDate").ToString(), startDate1) Then
                        If GlobalData.Now().Date < startDate1.Date Then
                            countdownTimer.Stop()
                            lblTimeLeft.Text = "Booking not started"
                        Else
                            countdownTimer.Start()
                        End If
                    Else
                        countdownTimer.Start()
                    End If
                Else
                    selectedTransactionId = 0
                    countdownTimer.Stop()
                    lblTimeLeft.Text = "Time Left: N/A"
                End If

                Dim statusText As String = If(latestTrans.ContainsKey("Status"), latestTrans("Status").ToString(), "Unknown")
                lblReturnedStatus.Text = "Returned Status: " & statusText


                Dim startDate As DateTime
                Dim endDate As DateTime
                If latestTrans.ContainsKey("StartDate") AndAlso DateTime.TryParse(latestTrans("StartDate")?.ToString(), startDate) AndAlso
                   latestTrans.ContainsKey("EndDate") AndAlso DateTime.TryParse(latestTrans("EndDate")?.ToString(), endDate) Then

                    If GlobalData.Now().Date < startDate.Date Then
                        lblTimeLeft.Text = "Booking not started"
                    Else
                        Dim remaining As TimeSpan = endDate - GlobalData.Now()
                        If statusText.ToLower() = "returned" OrElse remaining.TotalSeconds <= 0 Then
                            lblTimeLeft.Text = "Time Left: 00:00:00"
                        Else
                            lblTimeLeft.Text = String.Format("Time Left: {0}:{1:D2}:{2:D2}:{3:D2}", Math.Floor(remaining.TotalDays), remaining.Hours, remaining.Minutes, remaining.Seconds)
                        End If
                    End If
                Else
                    lblTimeLeft.Text = "Time Left: N/A"
                End If

            Else
                lblReturnedStatus.Text = "Returned Status: Unknown"
                lblTimeLeft.Text = "Time Left: N/A"
            End If
        Else
            lblReturnedStatus.Text = "Returned Status: Unknown"
            lblTimeLeft.Text = "Time Left: N/A"
        End If

    End Sub
    Private WithEvents countdownTimer As New Timer() With {.Interval = 1000}

    Private Sub countdownTimer_Tick(sender As Object, e As EventArgs) Handles countdownTimer.Tick
        If selectedTransactionId = 0 OrElse Not GlobalData.TransactionsDict.ContainsKey(selectedTransactionId) Then
            lblTimeLeft.Text = "Time Left: N/A"
            countdownTimer.Stop()
            Return
        End If

        Dim t = GlobalData.TransactionsDict(selectedTransactionId)
        Dim statusText As String = If(t.ContainsKey("Status") AndAlso t("Status") IsNot Nothing, t("Status").ToString(), "Rented")

        Dim startDate As DateTime
        If t.ContainsKey("StartDate") AndAlso DateTime.TryParse(t("StartDate").ToString(), startDate) Then
            If GlobalData.Now().Date < startDate.Date Then
                lblTimeLeft.Text = "Booking not started"
                countdownTimer.Stop()
                Return
            End If
        End If

        lblTimeLeft.Text = "Time Left: " & GetTimeLeftString(t, statusText)
    End Sub


    Private Function GetTimeLeftString(t As Dictionary(Of String, Object), statusText As String) As String
        If statusText.ToLower() = "returned" Then
            Return "00:00:00"
        End If

        Dim startDate As DateTime
        If t.ContainsKey("StartDate") AndAlso DateTime.TryParse(t("StartDate")?.ToString(), startDate) Then
            If GlobalData.Now().Date < startDate.Date Then
                Return "Booking not started"
            End If
        End If

        Dim endDate As DateTime
        If t.ContainsKey("EndDate") AndAlso DateTime.TryParse(t("EndDate")?.ToString(), endDate) Then
            Dim remaining As TimeSpan = endDate - GlobalData.Now()
            If remaining.TotalSeconds > 0 Then
                Return String.Format("{0}:{1:D2}:{2:D2}:{3:D2}",
                                 Math.Floor(remaining.TotalDays),
                                 remaining.Hours,
                                 remaining.Minutes,
                                 remaining.Seconds)
            End If
        End If
        Return "00:00:00"
    End Function


    Private Sub ApplyRoundedCornersToPanel(panel As Panel, cornerRadius As Integer)
        Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)
        Dim path As New Drawing2D.GraphicsPath()

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseFigure()

        panel.Region = New Region(path)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        homeForm.Show()
    End Sub

    Private Sub lblCarCapacity_Click(sender As Object, e As EventArgs) Handles lblCarCapacity.Click

    End Sub

    Private Sub lblCarType_Click(sender As Object, e As EventArgs) Handles lblCarType.Click

    End Sub

    Private Sub lblCarColor_Click(sender As Object, e As EventArgs) Handles lblCarColor.Click

    End Sub

    Private Sub lblPlateNumber_Click(sender As Object, e As EventArgs) Handles lblPlateNumber.Click

    End Sub

    Private Sub lblBodyNumber_Click(sender As Object, e As EventArgs) Handles lblBodyNumber.Click

    End Sub

    Private Sub lblCarID_Click(sender As Object, e As EventArgs) Handles lblCarID.Click

    End Sub

    Private Sub lblPaymentTotal_Click(sender As Object, e As EventArgs) Handles lblPaymentTotal.Click

    End Sub

    Private Sub lblRentStatus_Click(sender As Object, e As EventArgs) Handles lblRentStatus.Click

    End Sub

    Private Sub lblPaymentPerDay_Click(sender As Object, e As EventArgs) Handles lblPaymentPerDay.Click

    End Sub

    Private Sub lblRentEnd_Click(sender As Object, e As EventArgs) Handles lblRentEnd.Click

    End Sub

    Private Sub lblRentStart_Click(sender As Object, e As EventArgs) Handles lblRentStart.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub closeForm_Click(sender As Object, e As EventArgs) Handles closeForm.Click
        Close()
    End Sub

    Private Sub minimize_Click(sender As Object, e As EventArgs) Handles minimize.Click
        Me.WindowState = FormWindowState.Minimized
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

    Private Sub setting_Click(sender As Object, e As EventArgs) Handles setting.Click
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
End Class
