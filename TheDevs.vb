Public Class TheDevs
    Private Sub TheDevs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Close()
        homeForm.Show()
    End Sub


    Private Sub closeForm_Click(sender As Object, e As EventArgs) Handles closeForm.Click
        Close()
    End Sub

    Private Sub minimize_Click(sender As Object, e As EventArgs) Handles minimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class