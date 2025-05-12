Public Class UserManagement
    Private Sub UserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
        AddHandler GlobalData.DataChanged, AddressOf LoadUsers
    End Sub

    Private Sub LoadUsers()
        FlowLayoutPanel1.Controls.Clear()

        ' Updated titles array with new headers
        Dim titles As String() = {"Index", "Name", "Age", "Address", "Birthday", "Gender", "Email", "Password", "Good Record", "Status", "Current Wallet"}

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

        For i As Integer = 0 To 10 ' 0-based index for 11 columns (excluding Index)
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
                Case 0 : Return If(userData(0)?.ToString(), "")         ' Name
                Case 1 : Return If(userData(1)?.ToString(), "")         ' Age
                Case 2 : Return If(userData(2)?.ToString(), "")         ' Address
                Case 3 : Return If(userData(3)?.ToString(), "")         ' Birthday
                Case 4 : Return If(userData(4)?.ToString(), "")         ' Gender
                Case 5 : Return If(userData(5)?.ToString(), "")         ' Email
                Case 6 : Return If(userData(6)?.ToString(), "•••••")    ' Password
                Case 7 : Return If(Convert.ToBoolean(userData(7)), "✓", "✗") ' Good Record
                Case 8 : Return If(Convert.ToBoolean(userData(8)), "Rented", "Free") ' Status
                Case 9 : Return If(userData(14) IsNot Nothing, userData(14).ToString(), "0") ' Current Wallet
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        ManagementRent.Show()
    End Sub
End Class