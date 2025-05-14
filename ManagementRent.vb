Public Class ManagementRent
    ' Timer for updating countdowns
    Private WithEvents countdownTimer As New Timer() With {.Interval = 1000}
    ' Maps TransactionID to its timer Label
    Private timerLabels As New Dictionary(Of Integer, Label)
    ' Maps TransactionID to its editable TextBox
    Private editTimeTextBoxes As New Dictionary(Of Integer, TextBox)

    Private Sub ManagementRent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTransactions()
        AddHandler GlobalData.DataChanged, AddressOf LoadTransactions
        countdownTimer.Start()
    End Sub

    Private Sub LoadTransactions()
        FlowLayoutPanel1.Controls.Clear()
        timerLabels.Clear()
        editTimeTextBoxes.Clear()

        ' Header row (Customer Name removed)
        Dim titles As String() = {
            "Rent ID", "Car ID", "Plate Number", "Body Number", "Color", "Type", "Capacity", "Daily Price",
            "Total Price", "Status", "Rent Start", "Rent End", "Date Returned", "Customer Email",
            "Time Left", "Set Time", "Return"
        }
        Dim titleFont As New Font("Arial", 10, FontStyle.Bold)
        Dim detailFont As New Font("Arial", 9, FontStyle.Regular)

        Dim rowHeight As Integer = 30
        Dim totalWidth As Integer = FlowLayoutPanel1.Width - 25
        Dim columnWidth As Integer = totalWidth \ titles.Length

        Dim headerPanel As New Panel With {
            .Height = rowHeight,
            .Width = totalWidth,
            .BackColor = Color.White,
            .Margin = New Padding(0),
            .ForeColor = Color.Black
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

        ' Data rows
        If GlobalData.TransactionsDict.Count = 0 Then
            Dim noDataLabel As New Label With {
                .Text = "No rental transactions found.",
                .Size = New Size(totalWidth, rowHeight),
                .Font = detailFont,
                .BackColor = Color.LightYellow,
                .ForeColor = Color.Black,
                .TextAlign = ContentAlignment.MiddleCenter,
                .BorderStyle = BorderStyle.FixedSingle
            }
            FlowLayoutPanel1.Controls.Add(noDataLabel)
        Else
            For Each t As Dictionary(Of String, Object) In GlobalData.TransactionsDict.Values
                Dim rowPanel As New Panel With {
                    .Height = rowHeight,
                    .Width = totalWidth,
                    .BackColor = Color.Transparent,
                    .ForeColor = Color.White,
                    .Margin = New Padding(0, 0, 0, 0)
                }

                ' Determine status text
                Dim statusText As String = "Rented"
                If t.ContainsKey("Status") AndAlso t("Status") IsNot Nothing Then
                    statusText = t("Status").ToString()
                ElseIf t.ContainsKey("IsBooked") AndAlso t("IsBooked") IsNot Nothing Then
                    If Convert.ToBoolean(t("IsBooked")) Then
                        statusText = "Booked"
                    End If
                End If

                Dim values As String() = New String(17) {} ' 17 columns now
                Try
                    values(0) = SafeStr(t, "TransactionID")
                    values(1) = SafeStr(t, "CarID")
                    values(2) = SafeStr(t, "PlateNumber")
                    values(3) = SafeStr(t, "BodyNumber")
                    values(4) = SafeStr(t, "Color")
                    values(5) = SafeStr(t, "Type")
                    values(6) = SafeStr(t, "Capacity")
                    values(7) = SafeStr(t, "DailyPrice")
                    values(8) = SafeStr(t, "TotalPrice")
                    values(9) = statusText
                    values(10) = SafeDate(t, "StartDate")
                    values(11) = SafeDate(t, "EndDate")
                    values(12) = SafeDate(t, "DateReturned")
                    values(13) = SafeStr(t, "CustomerEmail")
                    ' 14: Time Left label, 15: Set Time textbox, 16: Return button
                Catch
                    For i As Integer = 0 To values.Length - 1
                        If values(i) Is Nothing Then values(i) = "N/A"
                    Next
                End Try

                For i As Integer = 0 To 13 ' up to Customer Email
                    Dim label As New Label With {
                        .Text = values(i),
                        .Font = detailFont,
                        .ForeColor = Color.White,
                        .Size = New Size(columnWidth, rowHeight),
                        .TextAlign = ContentAlignment.MiddleCenter,
                        .BorderStyle = BorderStyle.FixedSingle,
                        .BackColor = Color.Transparent,
                        .Location = New Point(i * columnWidth, 0),
                        .Margin = New Padding(0)
                    }
                    rowPanel.Controls.Add(label)
                Next

                ' Timer label
                Dim timerLabel As New Label With {
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Size = New Size(columnWidth, rowHeight),
                    .Location = New Point(columnWidth * 14, 0),
                    .Font = detailFont,
                    .BackColor = Color.Transparent,
                    .ForeColor = Color.White,
                    .BorderStyle = BorderStyle.FixedSingle
                }
                Dim transactionId As Integer = 0
                Integer.TryParse(SafeStr(t, "TransactionID"), transactionId)
                If transactionId > 0 Then
                    timerLabels(transactionId) = timerLabel
                End If
                timerLabel.Text = GetTimeLeftString(t, statusText)
                rowPanel.Controls.Add(timerLabel)

                ' Set Time textbox (refactored)
                Dim editTimeTextBox = CreateSetTimeTextBox(transactionId, statusText, t, columnWidth, detailFont)
                editTimeTextBox.Location = New Point(columnWidth * 15, 0)
                rowPanel.Controls.Add(editTimeTextBox)

                ' Return button (refactored)
                Dim returnButton = CreateReturnButton(transactionId, statusText, columnWidth)
                returnButton.Location = New Point(columnWidth * 16, 4)
                rowPanel.Controls.Add(returnButton)

                FlowLayoutPanel1.Controls.Add(rowPanel)
            Next
        End If
    End Sub

    Private Function CreateSetTimeTextBox(transactionId As Integer, statusText As String, t As Dictionary(Of String, Object), columnWidth As Integer, detailFont As Font) As TextBox
        Dim editTimeTextBox As New TextBox With {
            .TextAlign = HorizontalAlignment.Center,
            .Size = New Size(columnWidth, 30),
            .Font = detailFont,
            .ForeColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle,
            .TabStop = True
        }
        If transactionId > 0 Then
            editTimeTextBoxes(transactionId) = editTimeTextBox
        End If

        If statusText.ToLower() = "returned" Then
            editTimeTextBox.Text = "00:00:00"
            editTimeTextBox.ReadOnly = True
            editTimeTextBox.BackColor = Color.Gray
        Else
            editTimeTextBox.Text = GetTimeLeftString(t, statusText)
            editTimeTextBox.ReadOnly = False
            editTimeTextBox.BackColor = Color.DarkSlateBlue
            AddHandler editTimeTextBox.Leave, Sub(sender2, e2) SaveTimerEdit(transactionId, editTimeTextBox.Text)
            AddHandler editTimeTextBox.KeyDown, Sub(sender2, e2)
                                                    Dim tb = DirectCast(sender2, TextBox)
                                                    Dim ke = DirectCast(e2, KeyEventArgs)
                                                    If ke.KeyCode = Keys.Enter Then
                                                        SaveTimerEdit(transactionId, tb.Text)
                                                        ke.SuppressKeyPress = True
                                                    End If
                                                End Sub
        End If
        Return editTimeTextBox
    End Function

    Private Function CreateReturnButton(transactionId As Integer, statusText As String, columnWidth As Integer) As Button
        Dim returnButton As New Button With {
            .Text = "Return",
            .Size = New Size(columnWidth, 22),
            .BackColor = If(statusText.ToLower() = "returned", Color.Gray, Color.Green),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Tag = transactionId,
            .Location = New Point(0, 4),
            .Enabled = Not (statusText.ToLower() = "returned")
        }
        If Not returnButton.Enabled Then
            returnButton.BackColor = Color.Gray
        End If
        AddHandler returnButton.Click, AddressOf ReturnCar_Click
        Return returnButton
    End Function

    ' Timer tick: update all countdowns (labels only)
    Private Sub countdownTimer_Tick(sender As Object, e As EventArgs) Handles countdownTimer.Tick
        For Each t As Dictionary(Of String, Object) In GlobalData.TransactionsDict.Values
            Dim statusText As String = "Rented"
            If t.ContainsKey("Status") AndAlso t("Status") IsNot Nothing Then
                statusText = t("Status").ToString()
            ElseIf t.ContainsKey("IsBooked") AndAlso t("IsBooked") IsNot Nothing Then
                If Convert.ToBoolean(t("IsBooked")) Then
                    statusText = "Booked"
                End If
            End If

            Dim transactionId As Integer = 0
            Integer.TryParse(SafeStr(t, "TransactionID"), transactionId)
            If transactionId > 0 AndAlso timerLabels.ContainsKey(transactionId) Then
                timerLabels(transactionId).Text = GetTimeLeftString(t, statusText)
            End If
        Next
    End Sub

    ' Returns the countdown string for a transaction, including days
    Private Function GetTimeLeftString(t As Dictionary(Of String, Object), statusText As String) As String
        If statusText.ToLower() = "returned" Then
            Return "00:00:00"
        End If

        Dim endDate As DateTime
        If t.ContainsKey("EndDate") AndAlso DateTime.TryParse(t("EndDate")?.ToString(), endDate) Then
            Dim remaining As TimeSpan = endDate - DateTime.Now
            If remaining.TotalSeconds > 0 Then
                ' Format as d:hh:mm:ss, always show at least 2 digits for hours/minutes/seconds
                Return String.Format("{0}:{1:D2}:{2:D2}:{3:D2}",
                                 Math.Floor(remaining.TotalDays),
                                 remaining.Hours,
                                 remaining.Minutes,
                                 remaining.Seconds)
            End If
        End If
        Return "00:00:00"
    End Function

    ' Save admin-edited timer (from the editTimeTextBox)
    Private Sub SaveTimerEdit(transactionId As Integer, newTime As String)
        If Not editTimeTextBoxes.ContainsKey(transactionId) Then Return
        Dim t = GlobalData.TransactionsDict.Values.FirstOrDefault(Function(x) SafeStr(x, "TransactionID") = transactionId.ToString())
        If t Is Nothing Then Return

        ' Parse newTime as hh:mm:ss
        Dim ts As TimeSpan
        If TimeSpan.TryParse(newTime, ts) Then
            ' Set EndDate to Now + newTime
            Dim newEndDate = DateTime.Now.Add(ts)
            t("EndDate") = newEndDate

            ' Also update in user's SavedBillingPanels
            Dim user = GlobalData.GetLoggedInUser()
            If user IsNot Nothing AndAlso user.ContainsKey("SavedBillingPanels") Then
                Dim panels = CType(user("SavedBillingPanels"), List(Of Dictionary(Of String, Object)))
                For Each panel In panels
                    If panel.ContainsKey("TransactionID") AndAlso panel("TransactionID").ToString() = transactionId.ToString() Then
                        panel("ReturnDeadline") = newEndDate
                    End If
                Next
            End If

            GlobalData.NotifyDataChanged()
        Else
            MessageBox.Show("Invalid time format. Use hh:mm:ss.", "Invalid Input")
            editTimeTextBoxes(transactionId).Text = GetTimeLeftString(t, SafeStr(t, "Status"))
        End If
    End Sub


    Private Sub ReturnCar_Click(sender As Object, e As EventArgs)
        Try
            Dim button = DirectCast(sender, Button)
            Dim transactionID As Integer = 0

            If button.Tag IsNot Nothing Then
                If Not Integer.TryParse(button.Tag.ToString(), transactionID) Then
                    MessageBox.Show("Error: Invalid transaction ID.", "Error")
                    Return
                End If
            Else
                MessageBox.Show("Error: Missing transaction ID.", "Error")
                Return
            End If

            If MessageBox.Show("Are you sure you want to mark this car as returned?", "Confirm Return",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                ' Mark as returned in TransactionsDict
                If GlobalData.ReturnCar(transactionID) Then
                    ' Remove from user's SavedBillingPanels
                    Dim user = GlobalData.GetLoggedInUser()
                    If user IsNot Nothing AndAlso user.ContainsKey("SavedBillingPanels") Then
                        Dim panels = CType(user("SavedBillingPanels"), List(Of Dictionary(Of String, Object)))
                        panels.RemoveAll(Function(panel)
                                             Return panel.ContainsKey("TransactionID") AndAlso panel("TransactionID").ToString() = transactionID.ToString()
                                         End Function)

                    End If


                    Billing.DeleteSelectedPanel()
                    Billing.UpdateBillingDetails()

                    GlobalData.NotifyDataChanged()
                    MessageBox.Show("Car marked as returned successfully.", "Success")
                    LoadTransactions()
                Else
                    MessageBox.Show("Failed to mark car as returned.", "Error")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error processing return: " & ex.Message, "Error")
        End Try
    End Sub


    Private Function SafeStr(dict As Dictionary(Of String, Object), key As String) As String
        If dict.ContainsKey(key) AndAlso dict(key) IsNot Nothing Then
            Return dict(key).ToString()
        End If
        Return "N/A"
    End Function

    Private Function SafeDate(dict As Dictionary(Of String, Object), key As String) As String
        If dict.ContainsKey(key) AndAlso dict(key) IsNot Nothing Then
            Dim val = dict(key)
            If TypeOf val Is Date Then
                Return CType(val, Date).ToString("g")
            ElseIf val.ToString() <> "" Then
                Dim result As Date
                If Date.TryParse(val.ToString(), result) Then
                    Return result.ToString("g")
                End If
            End If
        End If
        Return "N/A"
    End Function

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        RemoveHandler GlobalData.DataChanged, AddressOf LoadTransactions
        countdownTimer.Stop()
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        UserManagement.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        CarsManagement.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Management.Show()
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class
