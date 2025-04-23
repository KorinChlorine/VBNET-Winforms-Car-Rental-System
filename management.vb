Public Class Management
    Class Cars
        Dim Name As String
        Dim Price As Integer
        Dim Details As String
    End Class

    Private selectedPanel As Panel = Nothing
    Private selectedImage As Image

    Private Sub Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
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

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles RoundedButton3.Click
        Dim panelYPosition As Integer = Panel3.Controls.Count * 60

        Dim panel1 As New Panel()
        panel1.Size = New Size(242, 50)
        panel1.Location = New Point(10, panelYPosition)
        panel1.BackColor = Color.Transparent
        AddHandler panel1.Paint, AddressOf Panel1_Paint

        If String.IsNullOrWhiteSpace(RichTextBox3.Text) OrElse selectedImage Is Nothing Then
            MessageBox.Show("Please select an image and provide a name before adding a panel.")
            Return
        End If

        AddHandler panel1.Click, AddressOf Panel_Click

        Dim newPictureBox As New PictureBox()
        newPictureBox.Size = New Size(85, 50)
        newPictureBox.Image = selectedImage
        newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage
        panel1.Controls.Add(newPictureBox)

        AddHandler newPictureBox.Click, Sub(s, eArgs) Panel_Click(panel1, eArgs)

        Dim newLabel As New Label()
        newLabel.Text = RichTextBox3.Text
        newLabel.Size = New Size(159, 44)
        newLabel.Location = New Point(90, 3)
        newLabel.BackColor = Color.White
        newLabel.TextAlign = ContentAlignment.MiddleCenter
        panel1.Controls.Add(newLabel)

        AddHandler newLabel.Click, Sub(s, eArgs) Panel_Click(panel1, eArgs)

        Panel3.Controls.Add(panel1)
    End Sub

    Private Sub Panel_Click(sender As Object, e As EventArgs)
        selectedPanel = CType(sender, Panel)
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
        selectedImage = Nothing
        RichTextBox3.Text = ""
        RichTextBox2.Text = ""
        MessageBox.Show("Restarted selected items successfully!")
    End Sub
End Class
