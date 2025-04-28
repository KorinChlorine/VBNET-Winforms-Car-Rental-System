Imports System.IO

Public Class LoginForm


    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, "video.mp4")
        AxWindowsMediaPlayer1.settings.setMode("loop", True)
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (TextBox1.Text = "admin") And (TextBox2.Text = "admin") Then
            Me.Hide()
            Management.Show()
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
        End If
    End Sub
End Class
