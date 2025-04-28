Imports System.IO
Imports System.Windows.Input

Public Class LoginForm


    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Play video
        AxWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, "video.mp4")
        AxWindowsMediaPlayer1.settings.setMode("loop", True)
        AxWindowsMediaPlayer1.Ctlcontrols.play()

        Panel1.BackgroundImage = My.Resources.Login
        Button5.Visible = False
        Button2.Visible = True
        TextBox4.Visible = False
        TextBox5.Visible = False
        Button4.Visible = False
        CheckBox1.Visible = False

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Panel1.BackgroundImage = My.Resources.Register
            TextBox1.Visible = False
            TextBox2.Visible = False
            CheckBox1.Visible = False
            Button3.Visible = False
            Button5.Visible = True

        MessageBox.Show("Switched to else")
            Panel1.BackgroundImage = My.Resources.Login
            Button5.Visible = False
            TextBox4.Visible = True
            TextBox5.Visible = True
            Button4.Visible = True
            CheckBox1.Visible = True



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MessageBox.Show("Switched to else")
        Panel1.BackgroundImage = My.Resources.Login
        Button5.Visible = False
        TextBox4.Visible = True
        TextBox5.Visible = True
        Button4.Visible = True
        CheckBox1.Visible = True

    End Sub
End Class
