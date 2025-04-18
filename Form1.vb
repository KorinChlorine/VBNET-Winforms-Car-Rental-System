Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim f As String = "I:\VB Net\Car Rental System\VBNET Car Rental System\BR86Z; Turbocharged Toyota 86 _ 4K.mp4"
        AxWindowsMediaPlayer1.URL = f
        AxWindowsMediaPlayer1.settings.setMode("loop", True)
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.Enter

    End Sub
End Class
