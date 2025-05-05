Imports System.Diagnostics.Contracts
Imports System.IO
Imports System.Windows.Input
Imports MySql.Data.MySqlClient
Imports System.Data


Public Class LoginForm
    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand

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

        ' Add default users if none exist
        If GlobalData.RegisteredUsers.Count = 0 Then
            GlobalData.RegisterUser("admin", "admin")
            GlobalData.RegisterUser("test", "test")
        End If
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

        ' Admin login bypass
        If ((emailLogin = "admin") Or (emailLogin = "1")) And ((passLogin = "admin") Or (passLogin = "1")) Then
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
            GlobalData.LoginUser(emailLogin, passLogin)
            GlobalData.UserRole = "admin"
            Me.Hide()
            Management.Show()
            Return
        End If

        ' Test login bypass
        If ((emailLogin = "test") Or (emailLogin = "2")) And ((passLogin = "test") Or (passLogin = "2")) Then
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
            GlobalData.LoginUser(emailLogin, passLogin)
            GlobalData.UserRole = "user"
            Me.Hide()
            homeForm.Show()
            Return
        End If

        Try
            ' Try to log in using database
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
                        GlobalData.LoginUser(emailLogin, passLogin)
                        GlobalData.UserRole = "user"
                        Me.Hide()
                        homeForm.Show()
                    Else
                        ' Try to log in using GlobalData
                        If GlobalData.LoginUser(emailLogin, passLogin) Then
                            AxWindowsMediaPlayer1.Ctlcontrols.stop()
                            GlobalData.UserRole = "user"
                            Me.Hide()
                            homeForm.Show()
                        Else
                            MessageBox.Show("Wrong Email/Password, Please Try Again!")
                        End If
                    End If

                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            ' If database connection fails, try using GlobalData
            If GlobalData.LoginUser(emailLogin, passLogin) Then
                AxWindowsMediaPlayer1.Ctlcontrols.stop()
                GlobalData.UserRole = "user"
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
                ' Check if user already exists in GlobalData
                If GlobalData.IsUserRegistered(emailRegister) Then
                    MessageBox.Show("User already exists!")
                    Return
                End If

                ' Try registering in database
                Dim connectionString As String = "server=127.0.0.1;userid=root;password='';database=user information"
                Dim query As String = "INSERT INTO `user info` (email, password) VALUES (@Email, @Password)"

                Using con As New MySqlConnection(connectionString)
                    Using cmd As New MySqlCommand(query, con)
                        cmd.Parameters.AddWithValue("@Email", emailRegister)
                        cmd.Parameters.AddWithValue("@Password", passRegister)

                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        ' Also register in GlobalData
                        GlobalData.RegisterUser(emailRegister, passRegister)
                        GlobalData.UsersList.Add(New Object() {emailRegister, passRegister})
                        MessageBox.Show("Registration successful!")
                    End Using
                End Using
            Catch ex As Exception
                ' If database fails, just register in GlobalData
                If GlobalData.RegisterUser(emailRegister, passRegister) Then
                    GlobalData.UsersList.Add(New Object() {emailRegister, passRegister})
                    MessageBox.Show("Registration successful!")
                Else
                    MessageBox.Show("User already exists!")
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