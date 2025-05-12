Public Module GlobalData
    ' Arrays
    Public GlobalOuterArray As New List(Of Object())()
    Public PremiumCarsArray As New List(Of Object())()
    Public RegisteredUsers As New List(Of Tuple(Of String, String))()
    Public Transactions As New List(Of Dictionary(Of String, Object))() ' List to store transactions
    Public CarsList As New List(Of Object())()
    Public UsersList As New List(Of Object())()

    ' Events
    Public Event DataChanged()

    ' Properties for user session management
    Public UserFullName As String = ""
    Public CurrentUserEmail As String = ""
    Public CurrentUserPassword As String = ""
    Public Age As Integer
    Public Address As String = ""
    Public Birthday As Date
    Public Gender As String = ""
    Public IsGoodRecord As Boolean = True
    Public IsBooked As Boolean = False
    Public CarRented As String = ""
    Public RentalStartDate As Date? = Nothing
    Public RentalEndDate As Date? = Nothing
    Public IsLoggedIn As Boolean = False
    Public UserRole As String = ""
    Public RentedCars As Integer = 0
    Public Wallet As Double = 0.0

    Public Sub NotifyDataChanged()
        RaiseEvent DataChanged()
    End Sub

    Public Function GetLoggedInUser() As Object()
        Return UsersList.FirstOrDefault(Function(user) user(0)?.ToString() = CurrentUserEmail)
    End Function

    ' Improved AddTransaction method with all required fields
    Public Function AddTransaction(
                              carName As String,
                              carID As String,
                              plateNumber As String,
                              bodyNumber As String,
                              color As String,
                              type As String,
                              capacity As String,
                              dailyPrice As Double,
                              totalPrice As Double,
                              customerName As String,
                              customerEmail As String,
                              customerAddress As String,
                              customer As String,
                              isBooked As Boolean,
                              startDate As Date,
                              endDate As Date,
                              Optional dateReturned As Date? = Nothing) As Boolean
        Try
            ' Validate dates
            If startDate >= endDate Then
                MessageBox.Show("Start date must be earlier than end date.", "Invalid Dates")
                Return False
            End If

            ' Create new transaction dictionary
            Dim transaction As New Dictionary(Of String, Object) From {
            {"Index", Transactions.Count + 1},
            {"CarName", If(carName IsNot Nothing, carName, "Unknown")},
            {"CarID", If(carID IsNot Nothing, carID, "Unknown")},
            {"PlateNumber", If(plateNumber IsNot Nothing, plateNumber, "Unknown")},
            {"BodyNumber", If(bodyNumber IsNot Nothing, bodyNumber, "Unknown")},
            {"Color", If(color IsNot Nothing, color, "Unknown")},
            {"Type", If(type IsNot Nothing, type, "Unknown")},
            {"Capacity", If(capacity IsNot Nothing, capacity, "Unknown")},
            {"DailyPrice", dailyPrice},
            {"TotalPrice", totalPrice},
            {"CustomerName", If(customerName IsNot Nothing, customerName, "Guest")},
            {"CustomerEmail", If(customerEmail IsNot Nothing, customerEmail, "guest@example.com")},
            {"CustomerAddress", If(customerAddress IsNot Nothing, customerAddress, "Unknown")},
            {"Customer", If(customer IsNot Nothing, customer, "Unknown")},
            {"IsBooked", isBooked},
            {"StartDate", startDate},
            {"EndDate", endDate},
            {"DateReturned", dateReturned},
            {"Status", If(isBooked, "Booked", "Rented")}
        }

            ' Add to transactions list
            Transactions.Add(transaction)

            ' Notify listeners
            NotifyDataChanged()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error adding transaction: " & ex.Message, "Transaction Error")
            Return False
        End Try
    End Function

    ' Get all transactions for a specific customer
    Public Function GetCustomerTransactions(customerEmail As String) As List(Of Dictionary(Of String, Object))
        Return Transactions.Where(Function(t) t("CustomerEmail").ToString() = customerEmail).ToList()
    End Function

    ' Get all transactions for a specific car
    Public Function GetCarTransactions(carID As String) As List(Of Dictionary(Of String, Object))
        Return Transactions.Where(Function(t) t("CarID").ToString() = carID).ToList()
    End Function

    ' Mark a car as returned
    Public Function ReturnCar(transactionIndex As Integer) As Boolean
        Try
            ' Find the transaction by index
            Dim foundTransaction As Dictionary(Of String, Object) = Nothing

            ' Safely search for the transaction
            For Each t As Dictionary(Of String, Object) In Transactions
                If t.ContainsKey("Index") AndAlso t("Index") IsNot Nothing Then
                    Dim indexValue As Integer
                    If Integer.TryParse(t("Index").ToString(), indexValue) AndAlso indexValue = transactionIndex Then
                        foundTransaction = t
                        Exit For
                    End If
                End If
            Next

            If foundTransaction IsNot Nothing Then
                ' Update the transaction
                foundTransaction("DateReturned") = DateTime.Now
                If foundTransaction.ContainsKey("IsBooked") Then
                    foundTransaction("IsBooked") = False ' No longer booked/rented
                End If
                If foundTransaction.ContainsKey("Status") Then
                    foundTransaction("Status") = "Returned"
                Else
                    foundTransaction.Add("Status", "Returned")
                End If

                ' Find and update the car's availability in CarsList
                Dim carID As String = "Unknown"
                If foundTransaction.ContainsKey("CarID") Then
                    carID = foundTransaction("CarID").ToString()
                End If

                For i As Integer = 0 To CarsList.Count - 1
                    If CarsList(i) IsNot Nothing AndAlso CarsList(i).Length > 8 AndAlso
                       CarsList(i)(8)?.ToString() = carID Then
                        If CarsList(i).Length > 12 Then
                            CarsList(i)(12) = True ' Set availability to true
                        End If
                        Exit For
                    End If
                Next

                RentedCars -= 1
                If RentedCars < 0 Then RentedCars = 0

                NotifyDataChanged()
                Return True
            End If

            Return False
        Catch ex As Exception
            MessageBox.Show("Error returning car: " & ex.Message, "Return Error")
            Return False
        End Try
    End Function

    ' User management methods
    Public Function LoginUser(email As String, password As String) As Boolean
        Dim user = RegisteredUsers.FirstOrDefault(Function(u) u.Item1 = email AndAlso u.Item2 = password)
        If user IsNot Nothing Then
            CurrentUserEmail = email
            CurrentUserPassword = password
            IsLoggedIn = True
            MessageBox.Show(email + ": Logged in successfully!")
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub LogoutUser()
        CurrentUserEmail = ""
        CurrentUserPassword = ""
        IsLoggedIn = False
        UserRole = ""
    End Sub

    Public Function IsUserRegistered(email As String) As Boolean
        Return RegisteredUsers.Any(Function(u) u.Item1 = email)
    End Function

    Public Function RegisterUser(email As String, password As String) As Boolean
        If IsUserRegistered(email) Then
            Return False
        Else
            RegisteredUsers.Add(Tuple.Create(email, password))
            NotifyDataChanged() ' Notify listeners that data has changed
            Return True
        End If
    End Function
End Module