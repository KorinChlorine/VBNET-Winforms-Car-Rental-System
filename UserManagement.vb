Public Class UserManagement
    Private Sub UserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
        AddHandler GlobalData.DataChanged, AddressOf LoadUsers
    End Sub

    Private Sub LoadUsers()
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel2.Controls.Clear()

        Dim titles As String() = {"Name", "Age", "Address", "Birthday", "Gender", "Email", "Password", "Good Record", "Status", "Car Rented", "Start Date", "End Date"}
        Dim titleFont As New Font("Arial", 10, FontStyle.Bold)
        Dim detailFont As New Font("Arial", 9, FontStyle.Regular)

        Dim padding As Integer = 10
        Dim totalWidth As Integer = FlowLayoutPanel2.Width - 20 ' For scrollbar margin
        Dim columnWidth As Integer = totalWidth \ titles.Length
        Dim rowHeight As Integer = 30

        ' === HEADER ROW ===
        Dim headerPanel As New Panel With {
            .Height = rowHeight,
            .Width = totalWidth,
            .BackColor = Color.LightGray
        }

        For i As Integer = 0 To titles.Length - 1
            Dim label As New Label With {
                .Text = titles(i),
                .Font = titleFont,
                .Size = New Size(columnWidth, rowHeight),
                .TextAlign = ContentAlignment.MiddleCenter,
                .BorderStyle = BorderStyle.FixedSingle,
                .Location = New Point(i * columnWidth, 0)
            }
            headerPanel.Controls.Add(label)
        Next

        FlowLayoutPanel2.Controls.Add(headerPanel)

        ' === USER DATA ROWS ===
        If GlobalData.UsersList.Count = 0 Then
            Dim noDataLabel As New Label With {
                .Text = "No verified users found. Customers must be verified first.",
                .Size = New Size(totalWidth, rowHeight),
                .Font = detailFont,
                .BackColor = Color.LightYellow,
                .TextAlign = ContentAlignment.MiddleCenter,
                .BorderStyle = BorderStyle.FixedSingle
            }
            FlowLayoutPanel1.Controls.Add(noDataLabel)
        Else
            For Each userData As Object() In GlobalData.UsersList
                Dim rowPanel As New Panel With {
                    .Height = rowHeight,
                    .Width = totalWidth,
                    .BackColor = Color.White
                }

                For i As Integer = 0 To titles.Length - 1
                    Dim detailLabel As New Label With {
                        .Text = GetUserDetail(userData, i),
                        .Font = detailFont,
                        .Size = New Size(columnWidth, rowHeight),
                        .TextAlign = ContentAlignment.MiddleCenter,
                        .BorderStyle = BorderStyle.FixedSingle,
                        .Location = New Point(i * columnWidth, 0)
                    }
                    rowPanel.Controls.Add(detailLabel)
                Next

                FlowLayoutPanel1.Controls.Add(rowPanel)
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
                Case 8 : Return If(Convert.ToBoolean(userData(8)), "Booked", "Free")
                Case 9 : Return If(userData(9)?.ToString(), "")
                Case 10 : Return If(userData(10) IsNot Nothing AndAlso Not String.IsNullOrEmpty(userData(10).ToString()), Convert.ToDateTime(userData(10)).ToShortDateString(), "")
                Case 11 : Return If(userData(11) IsNot Nothing AndAlso Not String.IsNullOrEmpty(userData(11).ToString()), Convert.ToDateTime(userData(11)).ToShortDateString(), "")
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
