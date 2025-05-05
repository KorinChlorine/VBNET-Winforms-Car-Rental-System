Public Class CarsManagement
    Private Sub CarsManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCars()
        AddHandler GlobalData.DataChanged, AddressOf LoadCars ' Listen for data changes
    End Sub

    Private Sub LoadCars()
        ' Clear existing controls in Panel1
        Panel1.Controls.Clear()

        ' Debug: Check if GlobalData.CarsList has data
        If GlobalData.CarsList Is Nothing OrElse GlobalData.CarsList.Count = 0 Then
            MessageBox.Show("No car data available to display.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Define the titles for the car details
        Dim titles As String() = {"Car Name", "Car ID", "Car Type", "Capacity", "Color", "Daily Price", "Availability", "Body Number", "Plate Number", "Premium"}
        Dim titleFont As New Font("Arial", 10, FontStyle.Bold)
        Dim detailFont As New Font("Arial", 9, FontStyle.Regular)

        ' Define padding to prevent labels from touching the borders
        Dim padding As Integer = 10
        Dim totalWidth As Integer = Panel1.Width - (2 * padding) ' Adjust for left and right padding
        Dim columnWidth As Integer = totalWidth \ titles.Length
        Dim rowHeight As Integer = 30

        ' Create title labels
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

        ' Create labels for each car's details
        Dim currentY As Integer = rowHeight + padding
        For Each carData As Object() In GlobalData.CarsList
            For i As Integer = 0 To titles.Length - 1
                Dim detailLabel As New Label With {
                .Text = GetCarDetail(carData, i),
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
    End Sub


    Private Function GetCarDetail(carData As Object(), index As Integer) As String
        Select Case index
            Case 0 : Return carData(0)?.ToString() ' Car Name
            Case 1 : Return carData(8)?.ToString() ' Car ID
            Case 2 : Return carData(3)?.ToString() ' Car Type
            Case 3 : Return carData(4)?.ToString() ' Capacity
            Case 4 : Return carData(5)?.ToString() ' Color
            Case 5 : Return $"P{carData(11)?.ToString()}" ' Daily Price
            Case 6 : Return If(Convert.ToBoolean(carData(12)), "Available", "Not Available") ' Availability
            Case 7 : Return carData(9)?.ToString() ' Body Number
            Case 8 : Return carData(10)?.ToString() ' Plate Number
            Case 9  ' Determine if the car is Premium
                Dim dailyPrice As Decimal
                If Decimal.TryParse(carData(11)?.ToString(), dailyPrice) AndAlso dailyPrice >= 10000 Then
                    Return "Premium"
                Else
                    Return "Non-Premium"
                End If
            Case Else : Return String.Empty
        End Select
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Management.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        UserManagement.Show()
    End Sub
End Class