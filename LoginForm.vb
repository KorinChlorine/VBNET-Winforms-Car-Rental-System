Imports System.IO

Public Class LoginForm


    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Play video
        AxWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, "video.mp4")
        AxWindowsMediaPlayer1.settings.setMode("loop", True)
        AxWindowsMediaPlayer1.Ctlcontrols.play()

    End Sub

End Class
