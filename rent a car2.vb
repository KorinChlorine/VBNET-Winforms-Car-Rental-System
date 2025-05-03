Imports System
Imports System.Runtime.CompilerServices
Imports System.Xml ' Explicitly include the System namespace

Public Class rent_a_car2

    Public Property SelectedCar As Object()
    Private SelectedPanel As Panel ' To track the currently selected panel
    Private WithEvents Timer1 As New Timer() ' Timer to update the system time and date

    ' Method to reset the form to its default state
    Private Sub ResetForm()
        ' Clear selected car details
        PictureBox1.Image = Nothing
        Label1.Text = String.Empty
        Label3.Text = String.Empty

        ' Reset any other properties or controls as needed
        SelectedCar = Nothing
        SelectedPanel = Nothing
    End Sub

    Private Sub rent_a_car2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Apply rounded corners to PictureBox1
        ApplyRoundedCornersToPictureBox(PictureBox1, 20)

        ' Populate the form with car details
        PopulateForm()

        ' Start the timer to update the time and date
        Timer1.Interval = 1000 ' Update every second
        Timer1.Start()

        ' Set RoundedButton4 as the default selected button
        UpdateButtonStyles(RoundedButton4)
    End Sub


    ' Timer Tick event to update the time and date
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Update the time in a label (e.g., LabelTime)
        LabelTime.Text = DateTime.Now.ToString("hh:mm:ss tt") ' Format: 12-hour clock with AM/PM

        ' Update the date in a label (e.g., LabelDate)
        LabelDate.Text = DateTime.Now.ToString("MMMM dd, yyyy") ' Format: Full month name, day, and year
    End Sub

    ' Method to populate the form
    Private Sub PopulateForm()
        ' Display selected car details
        If SelectedCar IsNot Nothing Then
            ' Set the car image
            PictureBox1.Image = TryCast(SelectedCar(1), Image)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

            ' Set the car details
            Label1.Text = SelectedCar(6)?.ToString()
            Label1.TextAlign = ContentAlignment.MiddleCenter
            Label3.Text = SelectedCar(0)?.ToString()

            If 
            Label8.Text = 

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
                .Size = New Size(PictureBox1.Width, 30), ' Match the width of the PictureBox
                .BackColor = Color.Red,
                .ForeColor = Color.White,
                .Font = New Font("Arial", 10, FontStyle.Bold),
                .TextAlign = ContentAlignment.MiddleCenter
            }

                    ' Center the label on the PictureBox
                    notAvailableLabel.Location = New Point(
                (PictureBox1.Width - notAvailableLabel.Width) \ 2,
                (PictureBox1.Height - notAvailableLabel.Height) \ 2
            )

                    ' Add the label to the PictureBox
                    PictureBox1.Controls.Add(notAvailableLabel)
                    notAvailableLabel.BringToFront()
                End If

                ' Enable or disable RoundedButton5 based on availability and radio button state
                UpdateRoundedButton5State(isAvailable)
            End If
    End Sub



    Private Sub UpdateRoundedButton5State(isAvailable As Boolean)
        ' Enable RoundedButton5 only if the car is available and a radio button is selected
        If isAvailable AndAlso (RadioButton1.Checked) Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
            RoundedButton5.Enabled = True
            RoundedButton5.Text = "BOOK" ' Default text when available
            RoundedButton5.BackColor = Color.White
            RoundedButton5.ForeColor = Color.DarkSlateBlue
            RoundedButton5.Font = New Font("League Spartan", 30, FontStyle.Bold)

        ElseIf isAvailable AndAlso (RadioButton2.Checked) Then
            RadioButton2.Checked = True
            RadioButton1.Checked = False
            RoundedButton5.Enabled = True
            RoundedButton5.Text = "RENT" ' Default text when available
            RoundedButton5.BackColor = Color.White
            RoundedButton5.ForeColor = Color.DarkSlateBlue
            RoundedButton5.Font = New Font("League Spartan", 30, FontStyle.Bold)
        Else
            RoundedButton5.Enabled = False
            RoundedButton5.Text = "NOT AVAILABLE" ' Text when unavailable
            RoundedButton5.BackColor = Color.Gray
            RoundedButton5.ForeColor = Color.LightGray
            RoundedButton5.Font = New Font("League Spartan", 20, FontStyle.Bold)
        End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        rent_a_car.Show()
    End Sub

    ' Override OnShown to reset the form when it is shown again
    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        PopulateForm()
    End Sub

    ' Draw rounded corners for the panel
    Private Sub DrawRoundedPanel(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = CType(sender, Panel)
        Dim graphics As Graphics = e.Graphics
        Dim rect As Rectangle = panel.ClientRectangle
        Dim radius As Integer = 20 ' Adjust for corner roundness

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


    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ' Update the state of RoundedButton5 based on the radio button and car availability
        Dim isAvailable As Boolean = False
        If SelectedCar IsNot Nothing AndAlso SelectedCar.Length > 12 Then
            Boolean.TryParse(SelectedCar(12)?.ToString(), isAvailable)
        End If
        UpdateRoundedButton5State(isAvailable)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ' Update the state of RoundedButton5 based on the radio button and car availability
        Dim isAvailable As Boolean = False
        If SelectedCar IsNot Nothing AndAlso SelectedCar.Length > 12 Then
            Boolean.TryParse(SelectedCar(12)?.ToString(), isAvailable)
        End If
        UpdateRoundedButton5State(isAvailable)
    End Sub


    ' Variable to track the currently selected button
    Private selectedButton As Button = Nothing

    ' Helper method to update button styles
    Private Sub UpdateButtonStyles(clickedButton As Button)
        ' Revert the style of the previously selected button
        If selectedButton IsNot Nothing Then
            selectedButton.BackColor = Color.DarkSlateBlue
            selectedButton.ForeColor = Color.White
        End If

        ' Update the style of the newly clicked button
        clickedButton.BackColor = Color.White
        clickedButton.ForeColor = Color.DarkSlateBlue

        ' Update the selected button reference
        selectedButton = clickedButton
    End Sub

    ' Event handler for RoundedButton4
    Private Sub RoundedButton4_Click(sender As Object, e As EventArgs) Handles RoundedButton4.Click
        UpdateButtonStyles(RoundedButton4)
        Label1.Text = SelectedCar(6)?.ToString()
        Label2.Text = "Brief Description"
    End Sub

    ' Event handler for RoundedButton3
    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles RoundedButton3.Click
        UpdateButtonStyles(RoundedButton3)
        Label1.Text = "Price per day: "



    End Sub

    ' Event handler for RoundedButton2
    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles RoundedButton2.Click
        UpdateButtonStyles(RoundedButton2)
        ' Add logic for data
    End Sub

    ' Event handler for RoundedButton1
    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        UpdateButtonStyles(RoundedButton1)
        Label1.Text = SelectedCar(7)?.ToString()
        PictureBox1.Image = TryCast(SelectedCar(2), Image)
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class
