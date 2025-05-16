Public Class History

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
        GlobalData.LogoutUser()
        LoginForm.Show()
    End Sub

    Private Sub closeForm_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub minimize_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub History_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub home_Click(sender As Object, e As EventArgs) Handles home.Click
        Me.Close()
        homeForm.Show()
    End Sub

    Private Sub rent_Click(sender As Object, e As EventArgs) Handles rent.Click
        Me.Close()
        rent_a_car.Show()
    End Sub

    Private Sub details_Click(sender As Object, e As EventArgs) Handles details.Click
        Me.Close()
        RentalDetail.Show()
    End Sub

    Private Sub setting_Click(sender As Object, e As EventArgs) Handles setting.Click
        Me.Close()
        TheDevs.Show()
    End Sub

    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        Me.Close()
        LoginForm.Show()
    End Sub

    Private Sub bills_Click(sender As Object, e As EventArgs) Handles bills.Click
        Me.Close()
        bills.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        homeForm.Show()
    End Sub
End Class
