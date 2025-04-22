Public Class Management

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
        OpenFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"

        PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class