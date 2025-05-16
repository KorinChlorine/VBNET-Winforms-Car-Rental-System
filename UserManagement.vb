Public Class UserManagement
    Private Sub UserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel1.WrapContents = False
        FlowLayoutPanel1.AutoScroll = True

        LoadUsers()
        AddHandler TextBox1.KeyDown, AddressOf TextBox1_KeyDown
        AddHandler GlobalData.DataChanged, AddressOf LoadUsers
    End Sub

    Private Sub LoadUsers(Optional search As String = "")
        FlowLayoutPanel1.Controls.Clear()

        If GlobalData.UsersDict Is Nothing OrElse GlobalData.UsersDict.Count = 0 Then
            MessageBox.Show("No user data available to display.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim searchLower = search.ToLower()
        Dim filteredUsers = GlobalData.UsersDict.Values.AsEnumerable()

        If Not String.IsNullOrEmpty(search) Then
            filteredUsers = filteredUsers.Where(Function(user) _
        (If(user.ContainsKey("FullName"), user("FullName")?.ToString().ToLower(), "")).Contains(searchLower) OrElse
        (If(user.ContainsKey("Age"), user("Age")?.ToString().ToLower(), "")).Contains(searchLower) OrElse
        (If(user.ContainsKey("Address"), user("Address")?.ToString().ToLower(), "")).Contains(searchLower) OrElse
        (If(user.ContainsKey("Birthday") AndAlso user("Birthday") IsNot Nothing AndAlso TypeOf user("Birthday") Is Date, CType(user("Birthday"), Date).ToShortDateString().ToLower(), "")).Contains(searchLower) OrElse
        (If(user.ContainsKey("Gender"), user("Gender")?.ToString().ToLower(), "")).Contains(searchLower) OrElse
        (If(user.ContainsKey("Email"), user("Email")?.ToString().ToLower(), "")).Contains(searchLower) OrElse
        (If(user.ContainsKey("Password"), user("Password")?.ToString().ToLower(), "")).Contains(searchLower) OrElse
        (If(user.ContainsKey("IsGoodRecord"), If(Convert.ToBoolean(user("IsGoodRecord")), "good", "bad"), "").ToLower().Contains(searchLower)) OrElse
        (If(user.ContainsKey("IsBooked"), If(Convert.ToBoolean(user("IsBooked")), "rented", "free"), "").ToLower().Contains(searchLower)) OrElse
        (If(user.ContainsKey("Wallet"), user("Wallet")?.ToString().ToLower(), "").Contains(searchLower))
    )
        End If



        For Each userDict As Dictionary(Of String, Object) In filteredUsers

            Dim rowPanel As New Panel()
            FlowLayoutPanel1.Controls.Add(rowPanel)
        Next


        Dim titles As String() = {"Index", "Name", "Age", "Address", "Birthday", "Gender", "Email", "Password", "Good Record", "Current Wallet"}
        Dim titleFont As New Font("Arial", 10, FontStyle.Bold)
        Dim detailFont As New Font("Arial", 9, FontStyle.Regular)

        Dim rowHeight As Integer = 30
        Dim totalWidth As Integer = FlowLayoutPanel1.Width - 1
        Dim columnWidth As Integer = totalWidth \ titles.Length

        ' === HEADER ROW ===
        Dim headerPanel As New Panel With {
            .Height = rowHeight,
            .Width = totalWidth,
            .BackColor = Color.White,
            .Margin = New Padding(0)
        }

        For i As Integer = 0 To titles.Length - 1
            Dim label As New Label With {
                .Text = titles(i),
                .Font = titleFont,
                .ForeColor = Color.Black,
                .Size = New Size(columnWidth, rowHeight),
                .TextAlign = ContentAlignment.MiddleCenter,
                .BorderStyle = BorderStyle.FixedSingle,
                .BackColor = Color.White,
                .Location = New Point(i * columnWidth, 0),
                .Margin = New Padding(0)
            }
            headerPanel.Controls.Add(label)
        Next

        FlowLayoutPanel1.Controls.Add(headerPanel)

        ' === USER DATA ROWS ===
        If GlobalData.UsersDict.Count = 0 Then
            Dim noDataLabel As New Label With {
                .Text = "No verified users found. Customers must be verified first.",
                .Size = New Size(totalWidth, rowHeight),
                .Font = detailFont,
                .BackColor = Color.LightYellow,
                .TextAlign = ContentAlignment.MiddleCenter,
                .BorderStyle = BorderStyle.FixedSingle,
                .MinimumSize = New Size(100, rowHeight),
                .AutoSize = False
            }
            FlowLayoutPanel1.Controls.Add(noDataLabel)
        Else
            Dim index As Integer = 1
            For Each userDict As Dictionary(Of String, Object) In GlobalData.UsersDict.Values
                Dim rowPanel As New Panel With {
                    .Height = rowHeight,
                    .Width = totalWidth,
                    .BackColor = Color.Transparent,
                    .Margin = New Padding(0),
                    .ForeColor = Color.White
                }


                Dim indexLabel As New Label With {
                    .Text = index.ToString(),
                    .Font = detailFont,
                    .ForeColor = Color.White,
                    .Size = New Size(columnWidth, rowHeight),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .BorderStyle = BorderStyle.FixedSingle,
                    .BackColor = Color.Transparent,
                    .Location = New Point(0, 0),
                    .Margin = New Padding(0)
                }
                rowPanel.Controls.Add(indexLabel)


                Dim userDetails As String() = GetUserDetails(userDict)
                For i As Integer = 0 To userDetails.Length - 1
                    Dim label As New Label With {
                        .Text = userDetails(i),
                        .Font = detailFont,
                        .ForeColor = Color.White,
                        .Size = New Size(columnWidth, rowHeight),
                        .TextAlign = ContentAlignment.MiddleCenter,
                        .BorderStyle = BorderStyle.FixedSingle,
                        .BackColor = Color.Transparent,
                        .Location = New Point((i + 1) * columnWidth, 0),
                        .Margin = New Padding(0)
                    }
                    rowPanel.Controls.Add(label)
                Next

                FlowLayoutPanel1.Controls.Add(rowPanel)
                index += 1
            Next
        End If
    End Sub

    Private Function GetUserDetails(userDict As Dictionary(Of String, Object)) As String()
        Dim details(8) As String
        details(0) = If(userDict.ContainsKey("FullName"), userDict("FullName")?.ToString(), "")
        details(1) = If(userDict.ContainsKey("Age"), userDict("Age")?.ToString(), "")
        details(2) = If(userDict.ContainsKey("Address"), userDict("Address")?.ToString(), "")
        details(3) = If(userDict.ContainsKey("Birthday") AndAlso userDict("Birthday") IsNot Nothing AndAlso TypeOf userDict("Birthday") Is Date, CType(userDict("Birthday"), Date).ToShortDateString(), "")
        details(4) = If(userDict.ContainsKey("Gender"), userDict("Gender")?.ToString(), "")
        details(5) = If(userDict.ContainsKey("Email"), userDict("Email")?.ToString(), "")
        details(6) = If(userDict.ContainsKey("Password"), "•••••", "")
        details(7) = If(userDict.ContainsKey("IsGoodRecord") AndAlso Convert.ToBoolean(userDict("IsGoodRecord")), "✓", "✗")
        details(8) = If(userDict.ContainsKey("Wallet"), userDict("Wallet")?.ToString(), "0")
        Return details
    End Function


    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            LoadUsers(TextBox1.Text.Trim())
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Management.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        CarsManagement.Show()
    End Sub


    Public Sub AddNewUser(userDict As Dictionary(Of String, Object))
        If userDict.ContainsKey("Email") Then
            GlobalData.UsersDict(userDict("Email").ToString()) = userDict
            GlobalData.NotifyDataChanged()
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        RemoveHandler GlobalData.DataChanged, AddressOf LoadUsers
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        ManagementRent.Show()
    End Sub

    Private Sub closeForm_Click(sender As Object, e As EventArgs) Handles closeForm.Click
        Close()
    End Sub

    Private Sub minimize_Click(sender As Object, e As EventArgs) Handles minimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class
