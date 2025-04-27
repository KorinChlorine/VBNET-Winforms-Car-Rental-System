Imports System.IO

Public Class LoginForm


    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Play video
        AxWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, "video.mp4")
        AxWindowsMediaPlayer1.settings.setMode("loop", True)
        AxWindowsMediaPlayer1.Ctlcontrols.play()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        homepage.Show()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Hide()


    End Sub
End Class
