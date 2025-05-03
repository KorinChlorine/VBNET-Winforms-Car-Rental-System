Imports System.Drawing
Imports AxWMPLib


Public Class Management
    Public Property CarName As String
    Public Property PrimaryImage As Image
    Public Property SecondaryImage As Image
    Public Property CarType As String
    Public Property Capacity As String
    Public Property carColor As String
    Public Property BriefDetails As String
    Public Property Details As String
    Public Property CarID As String
    Public Property BodyNumber As String
    Public Property PlateNumber As String
    Public Property DailyPrice As String
    Public Property IsAvailable As Boolean

    Private Sub Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PictureBox1.Image = My.Resources.arrow
        PictureBox2.Image = My.Resources.arrow
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        RadioButton1.Checked = True

    End Sub

    Private Shared outerArray As New List(Of Object())()
    Public Sub New()
        InitializeComponent()
        Restart()
    End Sub
    Private Sub ClearForm()
        RichTextBox3.Clear()
        RichTextBox6.Clear()
        RichTextBox5.Clear()
        RichTextBox10.Clear()
        RichTextBox1.Clear()
        RichTextBox2.Clear()
        RichTextBox4.Clear()
        RichTextBox7.Clear()
        RichTextBox9.Clear()
        RichTextBox8.Clear()
        PictureBox1.Image = My.Resources.arrow
        PictureBox2.Image = My.Resources.arrow
        RadioButton1.Checked = False
        RadioButton2.Checked = False

    End Sub
    Public Sub Restart()
        CarName = ""
        PrimaryImage = Nothing
        SecondaryImage = Nothing
        CarType = ""
        Capacity = ""
        carColor = ""
        BriefDetails = ""
        Details = ""
        CarID = ""
        BodyNumber = ""
        PlateNumber = ""
        DailyPrice = ""
        IsAvailable = False

    End Sub
    Public Sub LoadFromForm()
        CarName = RichTextBox3.Text
        PrimaryImage = PictureBox1.Image
        SecondaryImage = PictureBox2.Image
        CarType = RichTextBox6.Text
        Capacity = RichTextBox5.Text
        carColor = RichTextBox10.Text
        BriefDetails = RichTextBox1.Text
        Details = RichTextBox2.Text
        CarID = RichTextBox4.Text
        BodyNumber = RichTextBox7.Text
        PlateNumber = RichTextBox9.Text
        DailyPrice = RichTextBox8.Text
        IsAvailable = RadioButton1.Checked
    End Sub

    Public Sub SaveToForm()
        RichTextBox3.Text = CarName
        PictureBox1.Image = PrimaryImage
        PictureBox2.Image = SecondaryImage
        RichTextBox6.Text = CarType
        RichTextBox5.Text = Capacity
        RichTextBox10.Text = carColor
        RichTextBox1.Text = BriefDetails
        RichTextBox2.Text = Details
        RichTextBox4.Text = CarID
        RichTextBox7.Text = BodyNumber
        RichTextBox9.Text = PlateNumber
        RichTextBox8.Text = DailyPrice
        RadioButton1.Checked = IsAvailable
        RadioButton2.Checked = Not IsAvailable
    End Sub


    Private selectedPanel As Panel = Nothing
    Private selectedImage As Image
    Private selectedImage2 As Image



    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles RoundedButton3.Click
        Dim priceInd = RichTextBox8.Text
        priceInd.Cast(Of Int64)()
        If priceInd >= 10000 Then
            Label11.Text = "Premium"
        Else
            Label11.Text = "Non-Premium"
        End If


        If selectedPanel IsNot Nothing Then
            Dim previousOverlay = selectedPanel.Controls.OfType(Of Panel).FirstOrDefault(Function(p) p.Tag?.ToString() = "Overlay")
            If previousOverlay IsNot Nothing Then selectedPanel.Controls.Remove(previousOverlay)

            Dim previousSelectedLabel = selectedPanel.Controls.OfType(Of Label).FirstOrDefault(Function(lbl) lbl.Tag?.ToString() = "SelectedLabel")
            If previousSelectedLabel IsNot Nothing Then selectedPanel.Controls.Remove(previousSelectedLabel)
        End If

        If String.IsNullOrWhiteSpace(RichTextBox3.Text) OrElse selectedImage Is Nothing Then
            MessageBox.Show("Please select an image and provide a name before adding a panel.")
            Return
        End If

        Dim panelYPosition As Integer = Panel3.Controls.Count * 60
        Dim panel1 As New Panel With {
        .Size = New Size(220, 50),
        .Location = New Point(10, panelYPosition),
        .BackColor = Color.Transparent
    }
        AddHandler panel1.Click, AddressOf Panel_Click
        AddHandler panel1.Paint, AddressOf Panel1_Paint

        Dim newPictureBox As New PictureBox With {
        .Size = New Size(85, 50),
        .Image = selectedImage,
        .SizeMode = PictureBoxSizeMode.StretchImage
    }
        panel1.Controls.Add(newPictureBox)
        AddHandler newPictureBox.Click, Sub(s, eArgs) Panel_Click(panel1, New EventArgs())

        Dim newLabel As New Label With {
        .Text = RichTextBox3.Text.Trim(),
        .Size = New Size(220, 50),
        .Location = New Point(40, 0),
        .BackColor = Color.White,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Tag = "MainLabel"
    }
        panel1.Controls.Add(newLabel)
        AddHandler newLabel.Click, Sub(s, eArgs) Panel_Click(panel1, New EventArgs())

        Dim propertiesArray As Object() = {
        RichTextBox3.Text, selectedImage, selectedImage2, RichTextBox6.Text, RichTextBox5.Text,
        RichTextBox10.Text, RichTextBox1.Text, RichTextBox2.Text, RichTextBox4.Text,
        RichTextBox7.Text, RichTextBox9.Text, RichTextBox8.Text, RadioButton1.Checked
    }

        outerArray.Add(propertiesArray)

        panel1.Tag = propertiesArray

        Panel3.Controls.Add(panel1)

        Panel_Click(panel1, New EventArgs())
    End Sub

    Private Sub Panel_Click(sender As Object, e As EventArgs)
        Dim clickedPanel As Panel = CType(sender, Panel)
        If selectedPanel IsNot Nothing AndAlso selectedPanel IsNot clickedPanel Then
            Dim previousOverlay = selectedPanel.Controls.OfType(Of Panel).FirstOrDefault(Function(p) p.Tag?.ToString() = "Overlay")
            If previousOverlay IsNot Nothing Then selectedPanel.Controls.Remove(previousOverlay)

            Dim previousSelectedLabel = selectedPanel.Controls.OfType(Of Label).FirstOrDefault(Function(lbl) lbl.Tag?.ToString() = "SelectedLabel")
            If previousSelectedLabel IsNot Nothing Then selectedPanel.Controls.Remove(previousSelectedLabel)
        End If

        selectedPanel = clickedPanel
        Dim carData As Object() = TryCast(selectedPanel.Tag, Object())
        Dim overlay As New Panel With {
        .Size = selectedPanel.Size,
        .Location = New Point(0, 0),
        .BackColor = Color.FromArgb(100, Color.LightBlue),
        .Tag = "Overlay"
    }
        selectedPanel.Controls.Add(overlay)
        overlay.BringToFront()

        Dim selectedLabel As New Label With {
        .Text = (carData(0)?.ToString()),
        .AutoSize = False,
        .Size = selectedPanel.Size,
        .TextAlign = ContentAlignment.MiddleCenter,
        .ForeColor = Color.White,
        .Font = New Font("Arial", 12, FontStyle.Bold),
        .BackColor = Color.SlateBlue,
        .Tag = "SelectedLabel"
    }
        selectedPanel.Controls.Add(selectedLabel)
        selectedLabel.BringToFront()

        If carData Is Nothing Then
            MessageBox.Show("No panel data found.")
            Return
        End If

        ' Set the car name in RichTextBox3
        RichTextBox3.Text = carData(0)?.ToString()

        ' Set the primary image in PictureBox1
        PictureBox1.Image = TryCast(carData(1), Image)

        ' Set the secondary image in PictureBox2
        PictureBox2.Image = TryCast(carData(2), Image)

        ' Set the car type in RichTextBox6
        RichTextBox6.Text = carData(3)?.ToString()

        ' Set the car capacity in RichTextBox5
        RichTextBox5.Text = carData(4)?.ToString()

        ' Set the car color in RichTextBox10
        RichTextBox10.Text = carData(5)?.ToString()

        ' Set the brief details in RichTextBox1
        RichTextBox1.Text = carData(6)?.ToString()

        ' Set the detailed description in RichTextBox2
        RichTextBox2.Text = carData(7)?.ToString()

        ' Set the car ID in RichTextBox4
        RichTextBox4.Text = carData(8)?.ToString()

        ' Set the body number in RichTextBox7
        RichTextBox7.Text = carData(9)?.ToString()

        ' Set the plate number in RichTextBox9
        RichTextBox9.Text = carData(10)?.ToString()

        ' Set the daily price in RichTextBox8
        RichTextBox8.Text = carData(11)?.ToString()

        ' Set the availability status in RadioButton1 (True for available)
        RadioButton1.Checked = Convert.ToBoolean(carData(12))

        ' Set the opposite availability status in RadioButton2 (False for unavailable)
        RadioButton2.Checked = Not RadioButton1.Checked


        ' Added code to determine Premium or Non-Premium
        Dim priceInd As Int64
        If Int64.TryParse(RichTextBox8.Text, priceInd) Then
            If priceInd >= 10000 Then
                Label11.Text = "Premium"
            Else
                Label11.Text = "Non-Premium"
            End If
        Else
            Label11.Text = "Invalid Price"
        End If
    End Sub



    Private Sub RoundedButton4_Click(sender As Object, e As EventArgs) Handles RoundedButton4.Click
        If selectedPanel IsNot Nothing Then
            Dim result = MessageBox.Show($"Do you want to delete the selected panel with text '{selectedPanel.Controls.OfType(Of Label).FirstOrDefault()?.Text}'?", "Delete Panel", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Panel3.Controls.Remove(selectedPanel)
                selectedPanel = Nothing

                Dim currentYPosition As Integer = 0
                For Each control As Control In Panel3.Controls
                    If TypeOf control Is Panel Then
                        Dim panel As Panel = CType(control, Panel)
                        panel.Location = New Point(panel.Location.X, currentYPosition)
                        currentYPosition += panel.Height + 10
                        panel.Invalidate()
                    End If
                Next

            End If
        Else
            MessageBox.Show("No panel selected for deletion.")
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = CType(sender, Panel)
        Dim graphics As Graphics = e.Graphics
        Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)
        Dim path As New Drawing2D.GraphicsPath()

        Dim cornerRadius As Integer = 20
        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseFigure()

        panel.Region = New Region(path)
    End Sub


    Private Sub RoundedButton5_Click(sender As Object, e As EventArgs) Handles RoundedButton5.Click
        ClearForm()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            selectedImage = Image.FromFile(openFileDialog.FileName)
            Try
                PictureBox1.Image = selectedImage
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
                MessageBox.Show("Invalid Image")
            End Try
        End If
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            selectedImage2 = Image.FromFile(openFileDialog.FileName)
            Try
                PictureBox2.Image = selectedImage2
                PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
                MessageBox.Show("Invalid Image")
            End Try
        End If
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        If selectedPanel Is Nothing Then
            MessageBox.Show("No panel selected for editing.")
            Return
        End If

        Dim storedCarProperties As Object() = TryCast(selectedPanel.Tag, Object())
        If storedCarProperties Is Nothing Then
            MessageBox.Show("No data found for the selected panel.")
            Return
        End If

        storedCarProperties(0) = RichTextBox3.Text
        storedCarProperties(1) = PictureBox1.Image
        storedCarProperties(2) = PictureBox2.Image
        storedCarProperties(3) = RichTextBox6.Text
        storedCarProperties(4) = RichTextBox5.Text
        storedCarProperties(5) = RichTextBox10.Text
        storedCarProperties(6) = RichTextBox1.Text
        storedCarProperties(7) = RichTextBox2.Text
        storedCarProperties(8) = RichTextBox4.Text
        storedCarProperties(9) = RichTextBox7.Text
        storedCarProperties(10) = RichTextBox9.Text
        storedCarProperties(11) = RichTextBox8.Text
        storedCarProperties(12) = RadioButton1.Checked

        Dim nameLabel = selectedPanel.Controls.OfType(Of Label).FirstOrDefault(Function(lbl) lbl.Tag?.ToString() = "MainLabel")
        If nameLabel IsNot Nothing Then
            nameLabel.Text = RichTextBox3.Text
        End If

        Dim pictureBox = selectedPanel.Controls.OfType(Of PictureBox).FirstOrDefault()
        If pictureBox IsNot Nothing Then
            pictureBox.Image = PictureBox1.Image
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        MessageBox.Show("Panel updated successfully!")
    End Sub

    Private Sub SyncTagsWithOuterArray()
        For i As Integer = 0 To Panel3.Controls.Count - 1
            Dim p As Panel = TryCast(Panel3.Controls(i), Panel)
            If p IsNot Nothing AndAlso i < outerArray.Count Then
                p.Tag = outerArray(i)
            End If
        Next
    End Sub

    Private Sub RichTextBox8_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox8.TextChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        GlobalData.GlobalOuterArray = New List(Of Object())(outerArray)
        GlobalData.PremiumCarsArray = outerArray.Where(Function(car)
                                                           Dim price As Int64
                                                           If Int64.TryParse(car(11)?.ToString(), price) Then
                                                               Return price >= 10000
                                                           End If
                                                           Return False
                                                       End Function).ToList()
        Me.Hide()
        LoginForm.Show()
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles RoundedButton2.Click
        Dim random As New Random()

        ' Generate random car name
        RichTextBox3.Text = "Car " & random.Next(1, 1000)

        ' Generate random car type
        Dim carTypes As String() = {"Sedan", "SUV", "Hatchback", "Convertible", "Truck"}
        RichTextBox6.Text = carTypes(random.Next(carTypes.Length))

        ' Generate random capacity
        RichTextBox5.Text = random.Next(2, 8).ToString() & " Seats"

        ' Generate random car color
        Dim carColors As String() = {"Red", "Blue", "Black", "White", "Silver", "Green"}
        RichTextBox10.Text = carColors(random.Next(carColors.Length))

        ' Generate random brief details
        RichTextBox1.Text = "This is a " & RichTextBox6.Text & " with " & RichTextBox5.Text & " capacity."

        ' Generate random detailed description
        RichTextBox2.Text = "The " & RichTextBox3.Text & " is a " & RichTextBox6.Text & " available in " & RichTextBox10.Text & " color. It is perfect for your needs."

        ' Generate random car ID
        RichTextBox4.Text = "ID-" & random.Next(1000, 9999)

        ' Generate random body number
        RichTextBox7.Text = "BN-" & random.Next(10000, 99999)

        ' Generate random plate number
        RichTextBox9.Text = "PLT-" & random.Next(1000, 9999)

        ' Generate random daily price
        RichTextBox8.Text = random.Next(5000, 15000).ToString()
        If Convert.ToInt32(RichTextBox8.Text) >= 10000 Then
            Label11.Text = "Premium"
        Else
            Label11.Text = "Non-Premium"
        End If

        Dim isAvailable As Boolean = random.Next(0, 2) = 1
        RadioButton1.Checked = isAvailable
        RadioButton2.Checked = Not isAvailable

        selectedImage = My.Resources.PLACEHOLDER_Car
        selectedImage2 = My.Resources.PLACEHOLDER_Car
        PictureBox1.Image = My.Resources.PLACEHOLDER_Car
        PictureBox2.Image = My.Resources.PLACEHOLDER_Car

        MessageBox.Show("Random details have been filled!")
    End Sub


End Class
