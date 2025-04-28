Public Class homeForm
    Private Sub homeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        rent_a_car.Show()
    End Sub

End Class