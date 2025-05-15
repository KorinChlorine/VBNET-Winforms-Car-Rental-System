Public Class History
    Private Sub LoadUserHistoryPanels()
        FlowLayoutPanel1.Controls.Clear()

        Dim userEmail As String = GlobalData.CurrentUserEmail
        Dim userTransactions = GlobalData.GetCustomerTransactions(userEmail)

        For Each t In userTransactions
            Dim carID As String = t("CarID").ToString()
            Dim carDict As Dictionary(Of String, Object) = Nothing
            If GlobalData.CarsDict.ContainsKey(carID) Then
                carDict = GlobalData.CarsDict(carID)
            End If

            Dim panel As New Panel With {
                .Size = New Size(350, 70),
                .BackColor = Color.DarkSlateBlue,
                .Margin = New Padding(8),
                .Tag = t ' Store transaction for click event
            }
            AddHandler panel.Paint, AddressOf Panel1_Paint
            AddHandler panel.Click, AddressOf HistoryPanel_Click

            ' PictureBox1 - Primary Image
            Dim pb As New PictureBox With {
                .Size = New Size(85, 60),
                .Location = New Point(5, 5),
                .SizeMode = PictureBoxSizeMode.StretchImage,
                .Image = If(carDict IsNot Nothing AndAlso carDict.ContainsKey("PrimaryImage"), TryCast(carDict("PrimaryImage"), Image), My.Resources.PLACEHOLDER_Car)
            }
            panel.Controls.Add(pb)
            AddHandler pb.Click, AddressOf HistoryPanel_Click

            ' Label1 - Car Name (inside panel)
            Dim lblCarName As New Label With {
                .Text = If(carDict IsNot Nothing AndAlso carDict.ContainsKey("CarName"), carDict("CarName").ToString(), "Unknown Car"),
                .Font = New Font("Segoe UI", 11, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.Transparent,
                .Location = New Point(100, 5),
                .Size = New Size(240, 22)
            }
            panel.Controls.Add(lblCarName)
            AddHandler lblCarName.Click, AddressOf HistoryPanel_Click

            FlowLayoutPanel1.Controls.Add(panel)
        Next
    End Sub

    ' When a panel or its child is clicked, show details in Label2
    Private Sub HistoryPanel_Click(sender As Object, e As EventArgs)
        Dim panel As Panel = Nothing
        If TypeOf sender Is Panel Then
            panel = CType(sender, Panel)
        ElseIf TypeOf sender Is PictureBox OrElse TypeOf sender Is Label Then
            panel = CType(CType(sender, Control).Parent, Panel)
        End If
        If panel Is Nothing OrElse panel.Tag Is Nothing Then Exit Sub

        Dim t = CType(panel.Tag, Dictionary(Of String, Object))
        ' Build details string
        Dim details As String =
            $"Rent ID: {GetValueOrDefault(t, "TransactionID", "N/A")} | Plate: {GetValueOrDefault(t, "PlateNumber", "N/A")} | " &
            $"Body: {GetValueOrDefault(t, "BodyNumber", "N/A")} | Color: {GetValueOrDefault(t, "Color", "N/A")} | " &
            $"Type: {GetValueOrDefault(t, "Type", "N/A")} | Capacity: {GetValueOrDefault(t, "Capacity", "N/A")} | " &
            $"Daily: {GetValueOrDefault(t, "DailyPrice", "N/A")} | Total: {GetValueOrDefault(t, "TotalPrice", "N/A")} | " &
            $"Status: {GetValueOrDefault(t, "Status", "N/A")} | Start: {FormatDate(GetValueOrDefault(t, "StartDate", Nothing))} | " &
            $"End: {FormatDate(GetValueOrDefault(t, "EndDate", Nothing))} | Returned: {FormatDate(GetValueOrDefault(t, "DateReturned", Nothing))}"

        Label2.Text = details
        ' Optionally, update Label1 with car name
        If panel.Controls.OfType(Of Label).Any() Then
            label1.Text = panel.Controls.OfType(Of Label).First().Text
        End If
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = CType(sender, Panel)
        Dim graphics As Graphics = e.Graphics
        Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)
        Dim path As New Drawing2D.GraphicsPath()
        Dim cornerRadius As Integer = 20
        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseFigure()
        panel.Region = New Region(path)
    End Sub
    Private Function GetValueOrDefault(dict As Dictionary(Of String, Object), key As String, defaultValue As Object) As Object
        If dict IsNot Nothing AndAlso dict.ContainsKey(key) AndAlso dict(key) IsNot Nothing Then
            Return dict(key)
        End If
        Return defaultValue
    End Function
    Private Function FormatDate(obj As Object) As String
        If obj Is Nothing OrElse obj.ToString() = "" Then Return "N/A"
        Dim dt As DateTime
        If DateTime.TryParse(obj.ToString(), dt) Then
            Return dt.ToString("g")
        End If
        Return obj.ToString()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        GlobalData.LogoutUser()
        LoginForm.Show()
    End Sub

    Private Sub closeForm_Click(sender As Object, e As EventArgs) Handles closeForm.Click
        Close()
    End Sub

    Private Sub minimize_Click(sender As Object, e As EventArgs) Handles minimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
