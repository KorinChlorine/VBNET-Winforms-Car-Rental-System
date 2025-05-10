Public Class CarsManagement
    Private Sub CarsManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCars()
        AddHandler GlobalData.DataChanged, AddressOf LoadCars ' Listen for data changes
    End Sub

    Private Sub LoadCars()
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel2.Controls.Clear() ' Clear previous headers

        If GlobalData.CarsList Is Nothing OrElse GlobalData.CarsList.Count = 0 Then
            MessageBox.Show("No car data available to display.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim titles As String() = {"Car Name", "Car ID", "Car Type", "Capacity", "Color", "Daily Price", "Availability", "Body Number", "Plate Number", "Premium"}
        Dim titleFont As New Font("Arial", 10, FontStyle.Bold)
        Dim detailFont As New Font("Arial", 9, FontStyle.Regular)

        ' Calculate column width based on FlowLayoutPanel2
        Dim columnWidth As Integer = (FlowLayoutPanel2.Width - 20) \ titles.Length

        ' Add header to FlowLayoutPanel2
        Dim headerPanel As New Panel With {
        .Height = 30,
        .Width = FlowLayoutPanel2.Width - 20,
        .BackColor = Color.LightGray
    }

        For i As Integer = 0 To titles.Length - 1
            Dim label As New Label With {
            .Text = titles(i),
            .Font = titleFont,
            .Size = New Size(columnWidth, 30),
            .TextAlign = ContentAlignment.MiddleCenter,
            .BorderStyle = BorderStyle.FixedSingle,
            .Location = New Point(i * columnWidth, 0)
        }
            headerPanel.Controls.Add(label)
        Next

        FlowLayoutPanel2.Controls.Add(headerPanel)

        ' Create one row per car in FlowLayoutPanel1
        For Each carData As Object() In GlobalData.CarsList
            Dim rowPanel As New Panel With {
            .Height = 30,
            .Width = FlowLayoutPanel1.Width - 20,
            .BackColor = Color.White
        }

            For i As Integer = 0 To titles.Length - 1
                Dim label As New Label With {
                .Text = GetCarDetail(carData, i),
                .Font = detailFont,
                .Size = New Size(columnWidth, 30),
                .TextAlign = ContentAlignment.MiddleCenter,
                .BorderStyle = BorderStyle.FixedSingle,
                .Location = New Point(i * columnWidth, 0)
            }
                rowPanel.Controls.Add(label)
            Next

            FlowLayoutPanel1.Controls.Add(rowPanel)
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