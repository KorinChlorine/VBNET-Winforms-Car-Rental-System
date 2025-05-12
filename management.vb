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

    Private selectedPanel As Panel = Nothing
    Private selectedImage As Image
    Private selectedImage2 As Image

    Public Sub New()
        InitializeComponent()
        Restart()
    End Sub

    Private Sub Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = My.Resources.arrow
        PictureBox2.Image = My.Resources.arrow
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        RadioButton1.Checked = True
        LoadAllCarsToUI()
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

    Private Sub LoadAllCarsToUI()
        Panel3.Controls.Clear()
        For Each carDict In GlobalData.CarsDict.Values
            AddCarPanelToUI(carDict)
        Next
    End Sub

    Private Sub AddCarPanelToUI(carDict As Dictionary(Of String, Object))
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
            .Image = TryCast(carDict("PrimaryImage"), Image),
            .SizeMode = PictureBoxSizeMode.StretchImage
        }
        panel1.Controls.Add(newPictureBox)
        AddHandler newPictureBox.Click, Sub(s, eArgs) Panel_Click(panel1, New EventArgs())

        Dim newLabel As New Label With {
            .Text = carDict("CarName")?.ToString(),
            .Size = New Size(220, 50),
            .Location = New Point(40, 0),
            .BackColor = Color.White,
            .TextAlign = ContentAlignment.MiddleCenter,
            .Tag = "MainLabel"
        }
        panel1.Controls.Add(newLabel)
        AddHandler newLabel.Click, Sub(s, eArgs) Panel_Click(panel1, New EventArgs())

        panel1.Tag = carDict("CarID").ToString()
        Panel3.Controls.Add(panel1)
    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles RoundedButton3.Click
        Try
            Dim priceInd As Int64
            If Not Int64.TryParse(RichTextBox8.Text, priceInd) Then Throw New Exception()
            If priceInd >= 10000 Then
                Label11.Text = "Premium"
            Else
                Label11.Text = "Non-Premium"
            End If
        Catch
            MessageBox.Show("Fill up missing details!", "Notice")
            Return
        End Try

        Dim carID As String = RichTextBox4.Text.Trim()
        If String.IsNullOrEmpty(carID) Then
            MessageBox.Show("Car ID is required.")
            Return
        End If

        Dim carDict As New Dictionary(Of String, Object) From {
            {"CarID", carID},
            {"CarName", RichTextBox3.Text},
            {"PrimaryImage", selectedImage},
            {"SecondaryImage", selectedImage2},
            {"CarType", RichTextBox6.Text},
            {"Capacity", RichTextBox5.Text},
            {"Color", RichTextBox10.Text},
            {"BriefDetails", RichTextBox1.Text},
            {"Details", RichTextBox2.Text},
            {"BodyNumber", RichTextBox7.Text},
            {"PlateNumber", RichTextBox9.Text},
            {"DailyPrice", RichTextBox8.Text},
            {"IsAvailable", RadioButton1.Checked}
        }

        GlobalData.CarsDict(carID) = carDict
        GlobalData.NotifyDataChanged()
        AddCarPanelToUI(carDict)
        MessageBox.Show("Car added/updated successfully!")
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
        Dim carID As String = TryCast(selectedPanel.Tag, String)
        If String.IsNullOrEmpty(carID) OrElse Not GlobalData.CarsDict.ContainsKey(carID) Then
            MessageBox.Show("No car data found.")
            Return
        End If
        Dim carDict = GlobalData.CarsDict(carID)

        Dim overlay As New Panel With {
            .Size = selectedPanel.Size,
            .Location = New Point(0, 0),
            .BackColor = Color.FromArgb(100, Color.LightBlue),
            .Tag = "Overlay"
        }
        selectedPanel.Controls.Add(overlay)
        overlay.BringToFront()

        Dim selectedLabel As New Label With {
            .Text = carDict("CarName")?.ToString(),
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

        Try
            RichTextBox3.Text = carDict("CarName")?.ToString()
            PictureBox1.Image = TryCast(carDict("PrimaryImage"), Image)
            PictureBox2.Image = TryCast(carDict("SecondaryImage"), Image)
            RichTextBox6.Text = carDict("CarType")?.ToString()
            RichTextBox5.Text = carDict("Capacity")?.ToString()
            RichTextBox10.Text = carDict("Color")?.ToString()
            RichTextBox1.Text = carDict("BriefDetails")?.ToString()
            RichTextBox2.Text = carDict("Details")?.ToString()
            RichTextBox4.Text = carDict("CarID")?.ToString()
            RichTextBox7.Text = carDict("BodyNumber")?.ToString()
            RichTextBox9.Text = carDict("PlateNumber")?.ToString()
            RichTextBox8.Text = carDict("DailyPrice")?.ToString()
            RadioButton1.Checked = Convert.ToBoolean(carDict("IsAvailable"))
            RadioButton2.Checked = Not RadioButton1.Checked
        Catch
            MessageBox.Show("Fill up missing details!")
            Return
        End Try

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
            Dim carID As String = TryCast(selectedPanel.Tag, String)
            If String.IsNullOrEmpty(carID) OrElse Not GlobalData.CarsDict.ContainsKey(carID) Then
                MessageBox.Show("No car selected for deletion.")
                Return
            End If

            Dim result = MessageBox.Show($"Do you want to delete the selected car with ID '{carID}'?", "Delete Car", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Try
                    Panel3.Controls.Remove(selectedPanel)
                    GlobalData.CarsDict.Remove(carID)
                    GlobalData.NotifyDataChanged()
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

                    MessageBox.Show("Car deleted successfully!")
                Catch ex As Exception
                    MessageBox.Show($"Error deleting car: {ex.Message}")
                End Try
            End If
        Else
            MessageBox.Show("No car selected for deletion.")
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

        Dim carID As String = RichTextBox4.Text.Trim()
        If String.IsNullOrEmpty(carID) OrElse Not GlobalData.CarsDict.ContainsKey(carID) Then
            MessageBox.Show("No data found for the selected car.")
            Return
        End If

        Dim carDict = GlobalData.CarsDict(carID)
        carDict("CarName") = RichTextBox3.Text
        carDict("PrimaryImage") = PictureBox1.Image
        carDict("SecondaryImage") = PictureBox2.Image
        carDict("CarType") = RichTextBox6.Text
        carDict("Capacity") = RichTextBox5.Text
        carDict("Color") = RichTextBox10.Text
        carDict("BriefDetails") = RichTextBox1.Text
        carDict("Details") = RichTextBox2.Text
        carDict("CarID") = RichTextBox4.Text
        carDict("BodyNumber") = RichTextBox7.Text
        carDict("PlateNumber") = RichTextBox9.Text
        carDict("DailyPrice") = RichTextBox8.Text
        carDict("IsAvailable") = RadioButton1.Checked

        Dim nameLabel = selectedPanel.Controls.OfType(Of Label).FirstOrDefault(Function(lbl) lbl.Tag?.ToString() = "MainLabel")
        If nameLabel IsNot Nothing Then
            nameLabel.Text = RichTextBox3.Text
        End If

        Dim pictureBox = selectedPanel.Controls.OfType(Of PictureBox).FirstOrDefault()
        If pictureBox IsNot Nothing Then
            pictureBox.Image = PictureBox1.Image
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        GlobalData.NotifyDataChanged()
        MessageBox.Show("Details updated successfully!")
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        ' Update PremiumCarsArray with CarIDs of premium cars
        GlobalData.PremiumCarsArray = GlobalData.CarsDict.Values.
            Where(Function(car)
                      Dim price As Int64
                      Return Int64.TryParse(car("DailyPrice")?.ToString(), price) AndAlso price >= 10000
                  End Function).
            Select(Function(car) car("CarID").ToString()).ToList()
        Me.Hide()
        LoginForm.Show()
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles RoundedButton2.Click
        Dim random As New Random()

        RichTextBox3.Text = "Car " & random.Next(1, 1000)
        Dim carTypes As String() = {"Sedan", "SUV", "Hatchback", "Convertible", "Truck"}
        RichTextBox6.Text = carTypes(random.Next(carTypes.Length))
        RichTextBox5.Text = random.Next(2, 8).ToString() & " Seats"
        Dim carColors As String() = {"Red", "Blue", "Black", "White", "Silver", "Green"}
        RichTextBox10.Text = carColors(random.Next(carColors.Length))
        RichTextBox1.Text = "This is a " & RichTextBox6.Text & " with " & RichTextBox5.Text & " capacity."
        RichTextBox2.Text = "The " & RichTextBox3.Text & " is a " & RichTextBox6.Text & " available in " & RichTextBox10.Text & " color. It is perfect for your needs."
        RichTextBox4.Text = "ID-" & random.Next(1000, 9999)
        RichTextBox7.Text = "BN-" & random.Next(10000, 99999)
        RichTextBox9.Text = "PLT-" & random.Next(1000, 9999)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        CarsManagement.Show()
    End Sub
End Class
