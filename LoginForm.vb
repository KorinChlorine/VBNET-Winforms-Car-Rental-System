Imports System.Diagnostics.Contracts
Imports System.IO
Imports System.Windows.Input
Imports MySql.Data.MySqlClient
Imports System.Data



'notes:
'emailLogin = textbox1.text
'passLogin = textbox2.text
'emailRegister = textbox3.text
'passRegister = textbox4.text



Public Class LoginForm
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, "video.mp4")
        AxWindowsMediaPlayer1.settings.setMode("loop", True)
        AxWindowsMediaPlayer1.Ctlcontrols.play()

        Panel1.BackgroundImage = My.Resources.Login
        Button5.Visible = False
        Button2.Visible = True
        TextBox3.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = False
        Button4.Visible = False
        CheckBox1.Visible = True

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Panel1.BackgroundImage = My.Resources.Register1
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = True
        TextBox4.Visible = True
        TextBox5.Visible = True
        CheckBox1.Visible = False
        Button3.Visible = False
        Button5.Visible = True

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'login

        'userTrial
        'If (textbox1.text = "user") and (textbox2.text = "user" then
        'AxWindowsMediaPlayer1.Ctlcontrols.stop()
        'Me.hide()
        'homePage.show()

        'admin
        'If (textbox1.text = "admin") and (textbox2.text = "admin" then
        'AxWindowsMediaPlayer1.Ctlcontrols.stop()
        'Me.hide()
        'management.show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'register

        'email
        Dim emailRegister As String = TextBox3.Text

        'pass + confirm
        If TextBox4.Text = TextBox5.Text Then
            Dim passRegister As String = TextBox4.Text
        End If



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel1.BackgroundImage = My.Resources.Login
        Button5.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox5.Visible = False
        Button4.Visible = True
        CheckBox1.Visible = True
        TextBox5.Visible = False

    End Sub
End Class
