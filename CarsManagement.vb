Public Class CarsManagement
    Private Sub CarsManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCars()
        AddHandler GlobalData.DataChanged, AddressOf LoadCars
    End Sub

    Private Sub LoadCars()
        FlowLayoutPanel1.Controls.Clear()

        If GlobalData.CarsList Is Nothing OrElse GlobalData.CarsList.Count = 0 Then
            MessageBox.Show("No car data available to display.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim titles As String() = {"Index", "Car Name", "Car ID", "Car Type", "Capacity", "Color", "Daily Price", "Availability", "Body Number", "Plate Number", "Premium"}
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

        ' === CARS DATA ROWS ===
        Dim index As Integer = 1 ' Initialize the index for the first car
        For Each carData As Object() In GlobalData.CarsList
            Dim rowPanel As New Panel With {
                .Height = rowHeight,
                .Width = totalWidth,
                .BackColor = Color.Transparent,
                .Margin = New Padding(0),
                .ForeColor = Color.White
            }

            ' Add the index as the first column
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

            ' Add the rest of the car details
            For i As Integer = 0 To titles.Length - 2 ' Start from index 1 (skipping the Index column)
                Dim label As New Label With {
                    .Text = GetCarDetail(carData, i),
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

            index += 1 ' Increment the index for the next car
        Next
    End Sub

    Private Function GetCarDetail(carData As Object(), index As Integer) As String
        Select Case index
            Case 0 : Return carData(0)?.ToString()
            Case 1 : Return carData(8)?.ToString()
            Case 2 : Return carData(3)?.ToString()
            Case 3 : Return carData(4)?.ToString()
            Case 4 : Return carData(5)?.ToString()
            Case 5 : Return $"P{carData(11)?.ToString()}"
            Case 6 : Return If(Convert.ToBoolean(carData(12)), "Available", "Not Available")
            Case 7 : Return carData(9)?.ToString()
            Case 8 : Return carData(10)?.ToString()
            Case 9
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
