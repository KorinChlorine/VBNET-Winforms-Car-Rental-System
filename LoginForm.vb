Imports System.Diagnostics.Contracts
Imports System.IO
Imports System.Windows.Input
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class LoginForm
    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim users As New List(Of Tuple(Of String, String)) ' Email, Password for fallback

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

        conn = New MySqlConnection
        conn.ConnectionString = "server=127.0.0.1;userid=root;password='';database=test"

        Try
            conn.Open()
            MessageBox.Show("Connection to MySQL Successful")
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub
    Private Sub LoginForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        AxWindowsMediaPlayer1.settings.setMode("loop", True)
        If AxWindowsMediaPlayer1.playState <> WMPLib.WMPPlayState.wmppsPlaying Then
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.BackgroundImage = My.Resources.Register1
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = True
        TextBox4.Visible = True
        TextBox5.Visible = True
        CheckBox1.Visible = False
        Button4.Visible = True
        Button3.Visible = False
        Button5.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim emailLogin As String = TextBox1.Text
        Dim passLogin As String = TextBox2.Text

        If (TextBox1.Text = "admin") And (TextBox2.Text = "admin") Then
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
            Me.Hide()
            Management.Show()
            Return
        End If

        If (TextBox1.Text = "test") And (TextBox2.Text = "test") Then
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
            Me.Hide()
            homeForm.Show()
            Return
        End If

        Try

            Dim connectionString As String = "server=127.0.0.1;userid=root;password='';database=user information"
            Dim query As String = "SELECT email FROM `user info` WHERE email = @Email AND password = @Password"

            Using con As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Email", emailLogin)
                    cmd.Parameters.AddWithValue("@Password", passLogin)

                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()

                    If result IsNot Nothing Then
                        AxWindowsMediaPlayer1.Ctlcontrols.stop()
                        Me.Hide()
                        homeForm.Show()
                    Else
                        MessageBox.Show("Wrong Email/Password, Please Try Again!")
                    End If

                    con.Close()
                End Using
            End Using
        Catch ex As Exception

            Dim user = users.FirstOrDefault(Function(u) u.Item1 = emailLogin AndAlso u.Item2 = passLogin)
            If user IsNot Nothing Then
                AxWindowsMediaPlayer1.Ctlcontrols.stop()
                Me.Hide()
                homeForm.Show()
            Else
                MessageBox.Show("Wrong Email/Password, Please Try Again!")
            End If
        End Try


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Register
        Dim emailRegister As String = TextBox3.Text
        Dim passRegister As String = TextBox4.Text
        Dim confirmPass As String = TextBox5.Text

        If passRegister = confirmPass Then
            Try

                Dim connectionString As String = "server=127.0.0.1;userid=root;password='';database=user information"
                Dim query As String = "INSERT INTO `user info` (email, password) VALUES (@Email, @Password)"

                Using con As New MySqlConnection(connectionString)
                    Using cmd As New MySqlCommand(query, con)
                        cmd.Parameters.AddWithValue("@Email", emailRegister)
                        cmd.Parameters.AddWithValue("@Password", passRegister)

                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        MessageBox.Show("Registration successful!")
                    End Using
                End Using
            Catch ex As Exception

                If users.Any(Function(u) u.Item1 = emailRegister) Then
                    MessageBox.Show("User already exists!")
                Else
                    users.Add(Tuple.Create(emailRegister, passRegister))
                    MessageBox.Show("Registration successful!")
                End If
            End Try
        Else
            MessageBox.Show("Passwords do not match!")
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
        Button3.Visible = True
        Button4.Visible = False
        CheckBox1.Visible = True
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
