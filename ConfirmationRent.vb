Imports System.IO
Imports MySql.Data.MySqlClient

Public Class ConfirmationRent

    Private Sub ConfirmationRent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, "confirm.mp4")
        AxWindowsMediaPlayer1.settings.setMode("loop", True)
        AxWindowsMediaPlayer1.Ctlcontrols.play()


    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)

    End Sub
End Class