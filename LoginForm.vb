Imports System.IO

Public Class LoginForm
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'play video
        Dim videoPath As String = Path.Combine(Application.StartupPath, "video.mp4")

        If Not File.Exists(videoPath) Then
            File.WriteAllBytes(videoPath, My.Resources.video)
        End If

        AxWindowsMediaPlayer1.URL = videoPath
        AxWindowsMediaPlayer1.settings.setMode("loop", True)
        AxWindowsMediaPlayer1.Ctlcontrols.play()


    End Sub
End Class
