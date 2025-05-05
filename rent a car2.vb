Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Xml

Public Class rent_a_car2

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
            PictureBox1.Image = TryCast(SelectedCar(1), Image)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Label1.Text = SelectedCar(6)?.ToString()
            Label1.TextAlign = ContentAlignment.MiddleCenter
            Label3.Text = SelectedCar(0)?.ToString()

            Dim isAvailable As Boolean = False
            If SelectedCar.Length > 12 Then
                Boolean.TryParse(SelectedCar(12)?.ToString(), isAvailable)
            End If

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
        Label1.Text = SelectedCar(6)?.ToString()
        Label2.Text = "Brief Description"
    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles RoundedButton3.Click
        UpdateButtonStyles(RoundedButton3)
        Label1.Text = "Price per day: "
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles RoundedButton2.Click
        UpdateButtonStyles(RoundedButton2)
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        UpdateButtonStyles(RoundedButton1)
        Label1.Text = SelectedCar(7)?.ToString()
        PictureBox1.Image = TryCast(SelectedCar(2), Image)
    End Sub

    Private Sub RoundedButton5_Click(sender As Object, e As EventArgs) Handles RoundedButton5.Click
        Dim selectedStartDate As DateTime = startBook.Value
        Dim selectedEndDate As DateTime = endBook.Value
        Dim differenceInDays As Integer = (selectedEndDate - selectedStartDate).Days

        If selectedStartDate > selectedEndDate Then
            MessageBox.Show("Start date cannot be later than the end date.", "Invalid Dates")
            Return
        End If

        Dim dailyPrice As Decimal = Convert.ToDecimal(SelectedCar(11))
        Dim totalPrice As Decimal = dailyPrice * differenceInDays

        If RadioButton1.Checked Then
            MessageBox.Show($"Car booked successfully! Duration: {differenceInDays} days. Total Price: {totalPrice:C}", "Booking Confirmation")
            SelectedCar(12) = False
            UpdateRoundedButton5State(False)

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
    End Sub

    Private Sub UpdateCarDetails()
        SelectedCar(0) = "Updated Car Name"
        SelectedCar(12) = False
        GlobalData.NotifyDataChanged()
    End Sub

End Class
