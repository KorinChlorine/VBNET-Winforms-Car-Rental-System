Public Class Management
    Dim selectedImage As Image
    Class Cars
        Dim Name As String
        Dim Price As Integer
        Dim Details As String




        Function HondaCivic() As (Name As String, Price As Integer, Details As String)
            Return ("Honda Civic", 100000, "Placeholder")
        End Function






    End Class

    Private Sub Management_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

        ' Dim openFileDialog As New OpenFileDialog()
        'OpenFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
        ' If openFileDialog.ShowDialog() = DialogResult.OK Then
        'selectedImage = Image.FromFile(openFileDialog.FileName)
        'PictureBox1.Image = SelectedImage ' Display image preview
        ' End If

        'PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim openFileDialog As New OpenFileDialog()
        OpenFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            selectedImage = Image.FromFile(openFileDialog.FileName)
            PictureBox1.Image = selectedImage
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

        End If

    End Sub
End Class