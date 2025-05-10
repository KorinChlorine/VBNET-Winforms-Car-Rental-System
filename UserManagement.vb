Public Class UserManagement
    Private Sub UserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
        AddHandler GlobalData.DataChanged, AddressOf LoadUsers
    End Sub

    Private Sub LoadUsers()
        FlowLayoutPanel1.Controls.Clear()

        ' Updated titles array with new headers
        Dim titles As String() = {"Index", "Name", "Age", "Address", "Birthday", "Gender", "Email", "Password", "Good Record", "Status", "Car ID", "Car Name", "Start Date", "End Date", "Date Returned", "Current Wallet"}
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
        If GlobalData.UsersList.Count = 0 Then
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
            For Each userData As Object() In GlobalData.UsersList
                Dim rowPanel As New Panel With {
                    .Height = rowHeight,
                    .Width = totalWidth,
                    .BackColor = Color.Transparent,
                    .Margin = New Padding(0),
                    .ForeColor = Color.White
                }

                ' Add index column
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

                ' Add other user details
                For i As Integer = 0 To titles.Length - 2 ' Skip the index column
                    Dim label As New Label With {
                        .Text = GetUserDetail(userData, i),
                        .Font = detailFont,
                        .ForeColor = Color.White,
                        .Size = New Size(columnWidth, rowHeight),
                        .TextAlign = ContentAlignment.MiddleCenter,
                        .BorderStyle = BorderStyle.FixedSingle,
                        .BackColor = Color.Transparent,
                        .Location = New Point((i + 1) * columnWidth, 0), ' Shift by 1 for the index column
                        .Margin = New Padding(0)
                    }
                    rowPanel.Controls.Add(label)
                Next

                FlowLayoutPanel1.Controls.Add(rowPanel)
                index += 1
            Next
        End If
    End Sub

    Private Function GetUserDetail(userData As Object(), index As Integer) As String
        If userData Is Nothing OrElse index >= userData.Length Then
            Return "N/A"
        End If

        Try
            Select Case index
                Case 0 : Return If(userData(0)?.ToString(), "")
                Case 1 : Return If(userData(1)?.ToString(), "")
                Case 2 : Return If(userData(2)?.ToString(), "")
                Case 3 : Return If(userData(3)?.ToString(), "")
                Case 4 : Return If(userData(4)?.ToString(), "")
                Case 5 : Return If(userData(5)?.ToString(), "")
                Case 6 : Return If(userData(6)?.ToString(), "•••••")
                Case 7 : Return If(Convert.ToBoolean(userData(7)), "✓", "✗")
                Case 8 : Return If(Convert.ToBoolean(userData(8)), "Rented", "Free")
                Case 9 : Return If(userData(9)?.ToString(), "")
                Case 10 : Return If(userData(10)?.ToString(), "") ' Car Name - You'll need to fetch this from car data
                Case 11 : Return If(userData(11) IsNot Nothing AndAlso Not String.IsNullOrEmpty(userData(11).ToString()), Convert.ToDateTime(userData(11)).ToShortDateString(), "")
                Case 12 : Return If(userData(12) IsNot Nothing AndAlso Not String.IsNullOrEmpty(userData(12).ToString()), Convert.ToDateTime(userData(12)).ToShortDateString(), "")
                ' New fields for Date Returned and Current Wallet
                Case 13 : Return If(userData(13) IsNot Nothing, Convert.ToDateTime(userData(13)).ToShortDateString(), "")
                Case 14 : Return If(userData(14) IsNot Nothing, userData(14).ToString(), "0")
                Case Else : Return ""
            End Select
        Catch ex As Exception
            Return "Error"
        End Try
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Management.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        CarsManagement.Show()
    End Sub

    Public Sub AddNewUser(user As Object())
        GlobalData.UsersList.Add(user)
        GlobalData.NotifyDataChanged()
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        RemoveHandler GlobalData.DataChanged, AddressOf LoadUsers
        MyBase.OnFormClosing(e)
    End Sub
End Class