Imports System.IO


Public Class LoginForm

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = FormBorderStyle.None

        Panel1.BackgroundImage = My.Resources.Login
        TextBox1.Visible = True  ' Login Email
        TextBox2.Visible = True  ' Login Password
        Button3.Visible = True   ' Login Button
        CheckBox1.Visible = True ' Show Password


        TextBox3.Visible = False ' Register Email
        TextBox4.Visible = False ' Register Password
        TextBox5.Visible = False ' Confirm Password
        Button4.Visible = False  ' Register Submit
        Button5.Visible = False  ' Back to Login


        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "video.mp4")
        If Not File.Exists(tempPath) Then
            File.WriteAllBytes(tempPath, My.Resources.video)
        End If
        AxWindowsMediaPlayer1.URL = tempPath
        AxWindowsMediaPlayer1.settings.setMode("loop", True)
        AxWindowsMediaPlayer1.Ctlcontrols.play()


        TextBox1.Text = "Enter Email"
        TextBox1.ForeColor = Color.Black

        TextBox3.Text = "Enter Email"
        TextBox3.ForeColor = Color.Black

        TextBox5.Text = "Confirm Password"
        TextBox5.ForeColor = Color.Black

        TextBox2.Text = "Enter Password"
        TextBox2.ForeColor = Color.Black

        TextBox4.Text = "Enter Password"
        TextBox4.ForeColor = Color.Black
    End Sub


    Private Sub LoginForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Not Me.Visible OrElse Me.IsDisposed Then Exit Sub
        If Not AxWindowsMediaPlayer1.Created OrElse AxWindowsMediaPlayer1.IsDisposed Then Exit Sub
        AxWindowsMediaPlayer1.settings.setMode("loop", True)
        If AxWindowsMediaPlayer1.playState <> WMPLib.WMPPlayState.wmppsPlaying Then
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        End If
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.BackgroundImage = My.Resources.NEWRegister
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

    Private Sub StopAndDisposeVideo()
        Try
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
            AxWindowsMediaPlayer1.close()
        Catch
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim emailLogin As String = TextBox1.Text.Trim()
        Dim passLogin As String = TextBox2.Text

        If String.IsNullOrWhiteSpace(emailLogin) OrElse emailLogin = "Enter Email" OrElse
           String.IsNullOrWhiteSpace(passLogin) OrElse passLogin = "Enter Password" Then
            MessageBox.Show("Please enter both email and password.", "Missing Information")
            Return
        End If


        If Not (emailLogin = "admin" Or emailLogin = "1" Or emailLogin = "test") Then
            If Not emailLogin.Contains("@") Then
                MessageBox.Show("Please enter a valid email address!", "Invalid Email")
                Return
            End If
        End If

        If ((emailLogin = "admin") Or (emailLogin = "1")) And ((passLogin = "admin") Or (passLogin = "1")) Then
            StopAndDisposeVideo()
            GlobalData.LoginUser(emailLogin, passLogin)
            GlobalData.UserRole = "admin"
            Me.Hide()
            Management.Show()
            Return
        End If

        If ((emailLogin = "test") Or (emailLogin = "2")) And ((passLogin = "test") Or (passLogin = "2")) Then
            StopAndDisposeVideo()
            GlobalData.SetupTestUserAndCars()
            GlobalData.LoginUser(emailLogin, passLogin)
            GlobalData.UserRole = "user"
            Me.Hide()
            homeForm.Show()
            Return
        End If


        If GlobalData.LoginUser(emailLogin, passLogin) Then
                            StopAndDisposeVideo()
                            GlobalData.UserRole = "user"
                            Me.Hide()
                            homeForm.Show()
                        Else
                            MessageBox.Show("Wrong Email/Password, Please Try Again!")
                        End If


        If GlobalData.LoginUser(emailLogin, passLogin) Then
                StopAndDisposeVideo()
                GlobalData.UserRole = "user"
                Me.Hide()
                homeForm.Show()
            Else
                MessageBox.Show("Wrong Email/Password, Please Try Again!")
            End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim emailRegister As String = TextBox3.Text.Trim()
            Dim passRegister As String = TextBox4.Text
            Dim confirmPass As String = TextBox5.Text


            If String.IsNullOrWhiteSpace(emailRegister) OrElse emailRegister = "Enter Email" OrElse
           String.IsNullOrWhiteSpace(passRegister) OrElse passRegister = "Enter Password" OrElse
           String.IsNullOrWhiteSpace(confirmPass) OrElse confirmPass = "Confirm Password" Then
                MessageBox.Show("Please fill in registration form.", "Missing Information")
                Return
            End If


            If Not (emailRegister = "admin" Or emailRegister = "1") Then
                If Not emailRegister.Contains("@") Then
                    MessageBox.Show("Please enter a valid email address", "Invalid Email")
                    Return
                End If
            End If

            If passRegister = confirmPass Then

                If GlobalData.IsUserRegistered(emailRegister) Then
                    MessageBox.Show("User already exists!")
                    Return
                End If


                If GlobalData.RegisterUser(emailRegister, passRegister, "") Then
                    MessageBox.Show("Registration successful!")
                Else
                    MessageBox.Show("Registration failed. Please try again.")
                End If
            Else
                MessageBox.Show("Passwords do not match!")
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred during registration: " & ex.Message)
        End Try
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Panel1.BackgroundImage = My.Resources.NEWLogin
        Button5.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False  'password
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox5.Visible = False
        Button3.Visible = True
        Button4.Visible = False
        CheckBox1.Visible = True

        If CheckBox1.Checked = False Then
            TextBox2.PasswordChar = Char.MinValue
            TextBox1.Text = "Enter Email"
            TextBox1.ForeColor = Color.Black
            TextBox2.Text = "Enter Password"
            TextBox2.ForeColor = Color.Black
        End If
        TextBox5.PasswordChar = Char.MinValue
        TextBox4.PasswordChar = Char.MinValue
        TextBox4.Text = "Enter Password"
        TextBox4.ForeColor = Color.Black
        TextBox3.Text = "Enter Email"
        TextBox3.ForeColor = Color.Black
        TextBox5.Text = "Confirm Password"
        TextBox5.ForeColor = Color.Black
    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.Enter

    End Sub

    Private isDragging As Boolean = False
    Private dragStartPoint As Point

    Private Sub Panel5_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel5.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            dragStartPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub Panel5_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel5.MouseMove
        If isDragging Then
            Dim currentScreenPos As Point = PointToScreen(e.Location)
            Me.Location = New Point(currentScreenPos.X - dragStartPoint.X, currentScreenPos.Y - dragStartPoint.Y)
        End If
    End Sub

    Private Sub Panel5_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel5.MouseUp
        isDragging = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        If TextBox1.Text = "Enter Email" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        If TextBox2.Text = "Enter Password" Then
            TextBox2.Text = ""
            TextBox2.ForeColor = Color.Black
            TextBox2.PasswordChar = "*"c
        End If
    End Sub

    Private Sub TextBox3_Click(sender As Object, e As EventArgs) Handles TextBox3.Click
        If TextBox3.Text = "Enter Email" Then
            TextBox3.Text = ""
            TextBox3.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        If TextBox4.Text = "Enter Password" Then
            TextBox4.Text = ""
            TextBox4.ForeColor = Color.Black
            TextBox4.PasswordChar = "*"c
        End If
    End Sub

    Private Sub TextBox5_Click(sender As Object, e As EventArgs) Handles TextBox5.Click
        If TextBox5.Text = "Confirm Password" Then
            TextBox5.Text = ""
            TextBox5.ForeColor = Color.Black
            TextBox5.PasswordChar = "*"c
        End If
    End Sub


    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            TextBox1.Text = "Enter Email"
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If TextBox2.Text = "" Then
            TextBox2.Text = "Enter Password"
            TextBox2.ForeColor = Color.Black
            TextBox2.PasswordChar = Char.MinValue
        End If
    End Sub

    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        If TextBox3.Text = "" Then
            TextBox3.Text = "Enter Email"
            TextBox3.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        If TextBox4.Text = "" Then
            TextBox4.Text = "Enter Password"
            TextBox4.ForeColor = Color.Black
            TextBox4.PasswordChar = Char.MinValue
        End If
    End Sub

    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        If TextBox5.Text = "" Then
            TextBox5.Text = "Confirm Password"
            TextBox5.ForeColor = Color.Black
            TextBox5.PasswordChar = Char.MinValue
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub
End Class