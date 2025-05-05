Public Class CarsManagement
    Private Sub CarsManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCars()
        AddHandler GlobalData.DataChanged, AddressOf LoadCars ' Listen for data changes
    End Sub

    Private Sub LoadCars()
        Panel1.Controls.Clear() ' Clear existing panels

        For Each carData As Object() In GlobalData.CarsList
            Dim panel As New Panel With {
                .Size = New Size(220, 50),
                .BackColor = Color.Transparent
            }

            Dim pictureBox As New PictureBox With {
                .Size = New Size(85, 50),
                .Image = TryCast(carData(1), Image),
                .SizeMode = PictureBoxSizeMode.StretchImage
            }
            panel.Controls.Add(pictureBox)

            Dim label As New Label With {
                .Text = carData(0)?.ToString(),
                .Size = New Size(220, 50),
                .BackColor = Color.White,
                .TextAlign = ContentAlignment.MiddleCenter
            }
            panel.Controls.Add(label)

            Panel1.Controls.Add(panel)
        Next
    End Sub

End Class