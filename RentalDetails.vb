Public Class RentalDetail
    Private selectedPanel As Panel = Nothing

    Private Sub RentalDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserRentedPanels()
    End Sub

    Private Sub LoadUserRentedPanels()
        FlowLayoutPanel1.Controls.Clear()
        Dim transactions = GlobalData.GetCustomerTransactions(GlobalData.CurrentUserEmail)
        ' Only show active (not returned) rentals/bookings
        Dim activeTransactions = transactions.Where(Function(t) Not t.ContainsKey("Status") OrElse t("Status").ToString() <> "Returned")
        For Each trans In activeTransactions
            AddRentalPanelToUI(trans)
        Next
    End Sub

    Private Sub AddRentalPanelToUI(transDict As Dictionary(Of String, Object))
        Dim panel1 As New Panel With {
            .Width = 220,
            .Height = 40,
            .BackColor = Color.DarkSlateBlue,
            .ForeColor = Color.White,
            .Cursor = Cursors.Hand,
            .Margin = New Padding(5)
        }

        Dim carName As String = If(transDict.ContainsKey("CarName"), transDict("CarName").ToString(),
                              If(GlobalData.CarsDict.ContainsKey(transDict("CarID").ToString()),
                                 GlobalData.CarsDict(transDict("CarID").ToString())("CarName").ToString(), "Unknown Car"))

        Dim lbl As New Label With {
            .Text = carName,
            .AutoSize = True,
            .Font = New Font("Segoe UI", 16, FontStyle.Bold)
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

        ' Set Label1 - Car Name
        If carDict IsNot Nothing AndAlso carDict.ContainsKey("CarName") Then
            Label1.Text = carDict("CarName").ToString()
        ElseIf details.ContainsKey("CarName") Then
            Label1.Text = details("CarName").ToString()
        Else
            Label1.Text = "Unknown Car"
        End If

        ' Set PictureBox1 - Primary Image
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
    End Sub

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
End Class
