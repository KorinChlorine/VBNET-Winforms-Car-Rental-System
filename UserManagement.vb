Public Class UserManagement
    Private Sub UserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadUsers()
        AddHandler GlobalData.DataChanged, AddressOf LoadUsers
    End Sub

    Private Sub LoadUsers()
        Panel1.Controls.Clear()
        Panel1.AutoScroll = True ' Enable AutoScroll

        Dim titles As String() = {"Name", "Age", "Address", "Birthday", "Gender", "Email", "Password", "Good Record", "Status", "Car Rented", "Start Date", "End Date"}
        Dim titleFont As New Font("Arial", 10, FontStyle.Bold)
        Dim detailFont As New Font("Arial", 9, FontStyle.Regular)

        Dim padding As Integer = 10
        Dim totalWidth As Integer = Panel1.Width - (2 * padding)
        Dim columnWidth As Integer = totalWidth \ titles.Length
        Dim rowHeight As Integer = 30

        ' Header row
        For i As Integer = 0 To titles.Length - 1
            Dim titleLabel As New Label With {
            .Text = titles(i),
            .Size = New Size(columnWidth, rowHeight),
            .Location = New Point(padding + (i * columnWidth), padding),
            .Font = titleFont,
            .BackColor = Color.LightGray,
            .TextAlign = ContentAlignment.MiddleCenter,
            .BorderStyle = BorderStyle.FixedSingle
        }
            Panel1.Controls.Add(titleLabel)
        Next

        ' User details
        Dim currentY As Integer = rowHeight + padding
        For Each userData As Object() In GlobalData.UsersList
            For i As Integer = 0 To titles.Length - 1
                Dim detailText As String = GetUserDetail(userData, i)

                Dim detailLabel As New Label With {
                .Text = detailText,
                .Size = New Size(columnWidth, rowHeight),
                .Location = New Point(padding + (i * columnWidth), currentY),
                .Font = detailFont,
                .BackColor = Color.White,
                .TextAlign = ContentAlignment.MiddleCenter,
                .BorderStyle = BorderStyle.FixedSingle
            }
                Panel1.Controls.Add(detailLabel)
            Next
            currentY += rowHeight
        Next

        ' Update AutoScrollMinSize to ensure scrollbars appear
        Panel1.AutoScrollMinSize = New Size(0, currentY)
    End Sub

    Private Function GetUserDetail(userData As Object(), index As Integer) As String
        If index >= userData.Length Then
            Return "N/A" ' or ""
        End If

        Try
            Select Case index
                Case 0 : Return userData(0)?.ToString() ' Name
                Case 1 : Return userData(1)?.ToString() ' Age
                Case 2 : Return userData(2)?.ToString() ' Address
                Case 3 : Return userData(3)?.ToString() ' Birthday
                Case 4 : Return userData(4)?.ToString() ' Gender
                Case 5 : Return userData(5)?.ToString() ' Email
                Case 6 : Return userData(6)?.ToString() ' Password
                Case 7 : Return If(Convert.ToBoolean(userData(7)), "✔", "✘") ' Good Record
                Case 8 : Return If(Convert.ToBoolean(userData(8)), "Booked", "Free") ' Status
                Case 9 : Return userData(9)?.ToString() ' Car Rented
                Case 10 : Return If(userData(10) IsNot Nothing, CDate(userData(10)).ToShortDateString(), "") ' Start Date
                Case 11 : Return If(userData(11) IsNot Nothing, CDate(userData(11)).ToShortDateString(), "") ' End Date
                Case Else : Return String.Empty
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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
