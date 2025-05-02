Public Class rent_a_car2
    Public Property SelectedCar As Object()
    Private Sub rent_a_car2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Clear existing controls in FlowLayoutPanel1
        FlowLayoutPanel1.Controls.Clear()

        ' Iterate through all cars in GlobalData.GlobalOuterArray
        For Each car In GlobalData.GlobalOuterArray
            ' Create a new panel for the car
            Dim carPanel As New Panel With {
                .Size = New Size(190, 220),
                .BackColor = Color.DarkSlateBlue,
                .Margin = New Padding(12),
                .Tag = car ' Store the car data in the panel's Tag property
            }
            AddHandler carPanel.Click, AddressOf CarPanel_Click ' Add Click event handler

            ' Add a Label for the car name
            Dim carNameLabel As New Label With {
                .Text = car(0)?.ToString(), ' CarName
                .AutoSize = True,
                .Location = New Point(10, 10),
                .BackColor = Color.Transparent,
                .ForeColor = Color.White,
                .Font = New Font("Arial", 9, FontStyle.Bold)
            }
            carPanel.Controls.Add(carNameLabel)

            ' Add a PictureBox for the car image
            Dim carPictureBox As New PictureBox With {
                .Size = New Size(170, 130),
                .Location = New Point(10, 40),
                .Image = TryCast(car(1), Image), ' PrimaryImage
                .SizeMode = PictureBoxSizeMode.StretchImage,
                .BackColor = Color.Black
            }
            carPanel.Controls.Add(carPictureBox)

            ' Add the car panel to FlowLayoutPanel1
            FlowLayoutPanel1.Controls.Add(carPanel)
        Next
    End Sub
    Private Sub CarPanel_Click(sender As Object, e As EventArgs)
        Dim selectedPanel As Panel = CType(sender, Panel)
        Dim selectedCar As Object() = CType(selectedPanel.Tag, Object()) ' Retrieve the car data from the Tag property

        ' Display the selected car details (or perform any other action)
        MessageBox.Show("Selected Car: " & selectedCar(0)?.ToString())
    End Sub

End Class