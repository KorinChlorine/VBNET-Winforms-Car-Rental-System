Public Class CarsManagement
    Private Sub CarsManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCars()
        AddHandler GlobalData.DataChanged, AddressOf LoadCars
    End Sub

    Private Sub LoadCars()
        FlowLayoutPanel1.Controls.Clear()

        If GlobalData.CarsDict Is Nothing OrElse GlobalData.CarsDict.Count = 0 Then
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
        Dim index As Integer = 1
        For Each carDict As Dictionary(Of String, Object) In GlobalData.CarsDict.Values
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
            Dim carDetails As String() = GetCarDetails(carDict)
            For i As Integer = 0 To carDetails.Length - 1
                Dim label As New Label With {
                    .Text = carDetails(i),
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
    End Sub

    Private Function GetCarDetails(carDict As Dictionary(Of String, Object)) As String()
        ' Order: Car Name, Car ID, Car Type, Capacity, Color, Daily Price, Availability, Body Number, Plate Number, Premium
        Dim details(9) As String
        details(0) = If(carDict.ContainsKey("CarName"), carDict("CarName")?.ToString(), "")
        details(1) = If(carDict.ContainsKey("CarID"), carDict("CarID")?.ToString(), "")
        details(2) = If(carDict.ContainsKey("CarType"), carDict("CarType")?.ToString(), "")
        details(3) = If(carDict.ContainsKey("Capacity"), carDict("Capacity")?.ToString(), "")
        details(4) = If(carDict.ContainsKey("Color"), carDict("Color")?.ToString(), "")
        details(5) = If(carDict.ContainsKey("DailyPrice"), $"P{carDict("DailyPrice")?.ToString()}", "")
        details(6) = If(carDict.ContainsKey("IsAvailable") AndAlso Convert.ToBoolean(carDict("IsAvailable")), "Available", "Not Available")
        details(7) = If(carDict.ContainsKey("BodyNumber"), carDict("BodyNumber")?.ToString(), "")
        details(8) = If(carDict.ContainsKey("PlateNumber"), carDict("PlateNumber")?.ToString(), "")
        ' Premium check
        Dim dailyPrice As Decimal
        If carDict.ContainsKey("DailyPrice") AndAlso Decimal.TryParse(carDict("DailyPrice")?.ToString(), dailyPrice) AndAlso dailyPrice >= 10000 Then
            details(9) = "Premium"
        Else
            details(9) = "Non-Premium"
        End If
        Return details
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Management.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        UserManagement.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        ManagementRent.Show()
    End Sub
End Class
