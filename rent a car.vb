Public Class rent_a_car
    Private scrollingTimers As New List(Of Timer) ' List to hold timers for scrolling labels

    Private Sub rent_a_car_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Clear existing controls in FlowLayoutPanel1
        FlowLayoutPanel1.Controls.Clear()
        scrollingTimers.Clear() ' Clear any existing timers

        ' Adjust FlowLayoutPanel settings for better layout
        FlowLayoutPanel1.WrapContents = True
        FlowLayoutPanel1.AutoScroll = True
        FlowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight

        ' Iterate through all cars in GlobalData.GlobalOuterArray
        For Each car In GlobalData.GlobalOuterArray
            ' Create a new panel for the car
            Dim carPanel As New Panel With {
            .Size = New Size(190, 220), ' Increased horizontal size
            .BackColor = Color.DarkSlateBlue,
            .Margin = New Padding(12), ' Reduced margin for tighter spacing
            .Tag = car ' Store the car data in the panel's Tag property
        }
            AddHandler carPanel.Click, AddressOf CarPanel_Click ' Add Click event handler
            AddHandler carPanel.Paint, AddressOf Panel_Paint ' Add Paint event for rounded corners

            ' Add a Label for the "Premium" tag (if applicable)
            Dim isPremium As Boolean = False
            Dim dailyPrice As Decimal
            If Decimal.TryParse(car(11)?.ToString(), dailyPrice) Then
                isPremium = dailyPrice >= 10000 ' Example: Premium if daily price is 10,000 or more
            End If

            Dim premiumLabel As New Label With {
            .Text = If(isPremium, "PREMIUM", ""), ' Set "PREMIUM" only if the car is premium
            .Size = New Size(55, 15),
            .Location = New Point(5, 5),
            .BackColor = Color.Transparent,
            .ForeColor = Color.White,
            .Font = New Font("Arial", 7, FontStyle.Bold)
        }
            carPanel.Controls.Add(premiumLabel)

            ' Add a PictureBox for the car image
            Dim carPictureBox As New PictureBox With {
            .Size = New Size(170, 130), ' Adjusted size to fit larger panel
            .Location = New Point(10, 25),
            .Image = TryCast(car(1), Image), ' PrimaryImage
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .BackColor = Color.Black
        }
            carPanel.Controls.Add(carPictureBox)

            ' Add a Label for the car name
            Dim carNameLabel As New Label With {
            .Text = car(0)?.ToString(), ' CarName
            .AutoSize = True, ' Allow the label to expand for long text
            .Location = New Point(10, 160),
            .BackColor = Color.Transparent,
            .ForeColor = Color.White,
            .Font = New Font("Arial", 9, FontStyle.Bold)
        }
            carPanel.Controls.Add(carNameLabel)

            ' Add a Label for the car price
            Dim carPriceLabel As New Label With {
            .Text = "P" & car(11)?.ToString() & "/day", ' DailyPrice
            .Size = New Size(160, 20),
            .Location = New Point(10, 185),
            .BackColor = Color.Transparent,
            .ForeColor = Color.White,
            .Font = New Font("Arial", 9, FontStyle.Bold),
            .TextAlign = ContentAlignment.MiddleRight
        }
            carPanel.Controls.Add(carPriceLabel)

            ' Add the car panel to FlowLayoutPanel1
            FlowLayoutPanel1.Controls.Add(carPanel)
        Next
    End Sub

    Private Sub CarPanel_Click(sender As Object, e As EventArgs)
        Dim selectedPanel As Panel = CType(sender, Panel)
        Dim selectedCar As Object() = CType(selectedPanel.Tag, Object()) ' Retrieve the car data from the Tag property

        ' Pass the selected car data to rent a car2
        Dim rentCar2Form As New rent_a_car2()
        rentCar2Form.SelectedCar = selectedCar ' Assuming rent_a_car2 has a SelectedCar property
        rentCar2Form.Show()

        ' Hide the current form
        Me.Hide()
    End Sub


    ' Method to enable horizontal scrolling for a label
    Private Sub EnableScrolling(label As Label, parentPanel As Panel)
        Dim timer As New Timer With {
            .Interval = 100 ' Adjust scrolling speed (lower = faster)
        }
        Dim originalText As String = label.Text
        Dim scrollText As String = originalText & "   " ' Add spacing for smooth scrolling
        Dim currentIndex As Integer = 0

        AddHandler timer.Tick, Sub()
                                   ' Update the text to create a scrolling effect
                                   currentIndex = (currentIndex + 1) Mod scrollText.Length
                                   label.Text = scrollText.Substring(currentIndex) & scrollText.Substring(0, currentIndex)
                               End Sub

        ' Start the timer
        timer.Start()
        scrollingTimers.Add(timer) ' Keep track of the timer to stop it later if needed
    End Sub

    ' Method to apply rounded corners to a panel
    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = CType(sender, Panel)
        Dim graphics As Graphics = e.Graphics
        Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)
        Dim path As New Drawing2D.GraphicsPath()

        ' Define the corner radius for slightly rounded corners
        Dim cornerRadius As Integer = 20 ' Reduced roundness for subtle effect
        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseFigure()

        ' Apply the rounded region to the panel
        panel.Region = New Region(path)
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class

