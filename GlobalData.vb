Public Module GlobalData

    Public Property var As String

    ' Users: Key = Email, Value = Dictionary of user details
    Public UsersDict As New Dictionary(Of String, Dictionary(Of String, Object))()

    ' Cars: Key = CarID, Value = Dictionary of car details
    Public CarsDict As New Dictionary(Of String, Dictionary(Of String, Object))()

    ' Transactions: Key = TransactionID (Integer), Value = Dictionary of transaction details
    Public TransactionsDict As New Dictionary(Of Integer, Dictionary(Of String, Object))()

    ' Registered users for quick login check (email, password)
    Public RegisteredUsers As New List(Of Tuple(Of String, String))()

    ' Premium cars (for display, can be a list of CarIDs or car dictionaries)
    Public PremiumCarsArray As New List(Of String)() ' List of CarIDs

    ' Events
    Public Event DataChanged()
    Public HasReturnedCarThisSession As Boolean = False


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

    ' Get the currently logged-in user's dictionary
    Public Function GetLoggedInUser() As Dictionary(Of String, Object)
        If String.IsNullOrEmpty(CurrentUserEmail) Then Return Nothing
        If UsersDict.ContainsKey(CurrentUserEmail) Then
            Return UsersDict(CurrentUserEmail)
        End If
        Return Nothing
    End Function

    ' Add a new user
    Public Function RegisterUser(email As String, password As String, fullName As String,
                                Optional age As Integer = 0, Optional address As String = "",
                                Optional birthday As Date = Nothing, Optional gender As String = "",
                                Optional isGoodRecord As Boolean = True, Optional wallet As Double = 0.0,
                                Optional userRole As String = "user") As Boolean
        If IsUserRegistered(email) Then
            Return False
        Else
            RegisteredUsers.Add(Tuple.Create(email, password))
            Dim userDict As New Dictionary(Of String, Object) From {
                {"Email", email},
                {"FullName", fullName},
                {"Password", password},
                {"Age", age},
                {"Address", address},
                {"Birthday", birthday},
                {"Gender", gender},
                {"IsGoodRecord", isGoodRecord},
                {"Wallet", wallet},
                {"UserRole", userRole},
                {"SavedBillingPanels", New List(Of Dictionary(Of String, Object))()},
                {"var", var}
            }
            UsersDict.Add(email, userDict)
            NotifyDataChanged()
            Return True
        End If
    End Function

    ' Check if a user is registered
    Public Function IsUserRegistered(email As String) As Boolean
        Return UsersDict.ContainsKey(email)
    End Function

    Public Sub SetVarForCurrentUser(value As String)
        var = value
        Dim user = GetLoggedInUser()
        If user IsNot Nothing Then
            user("var") = value
        End If
    End Sub

    ' User login
    Public Function LoginUser(email As String, password As String) As Boolean
        Dim user = RegisteredUsers.FirstOrDefault(Function(u) u.Item1 = email AndAlso u.Item2 = password)
        If user IsNot Nothing AndAlso UsersDict.ContainsKey(email) Then
            CurrentUserEmail = email
            CurrentUserPassword = password
            IsLoggedIn = True
            Dim userDict = UsersDict(email)
            UserFullName = userDict("FullName")?.ToString()
            UserRole = userDict("UserRole")?.ToString()
            Wallet = If(userDict.ContainsKey("Wallet"), CDbl(userDict("Wallet")), 0.0)
            Age = If(userDict.ContainsKey("Age"), CInt(userDict("Age")), Nothing)
            Address = If(userDict.ContainsKey("Address"), userDict("Address")?.ToString(), "")
            Birthday = If(userDict.ContainsKey("Birthday") AndAlso TypeOf userDict("Birthday") Is Date, CType(userDict("Birthday"), Date), Nothing)
            Gender = If(userDict.ContainsKey("Gender"), userDict("Gender")?.ToString(), "")
            IsGoodRecord = If(userDict.ContainsKey("IsGoodRecord"), CBool(userDict("IsGoodRecord")), Nothing)
            IsBooked = If(userDict.ContainsKey("IsBooked"), CBool(userDict("IsBooked")), False)
            CarRented = If(userDict.ContainsKey("CarRented"), userDict("CarRented")?.ToString(), "")
            RentedCars = If(userDict.ContainsKey("RentedCars"), CInt(userDict("RentedCars")), 0)
            var = If(userDict.ContainsKey("var"), userDict("var")?.ToString(), Nothing)


            If userDict.ContainsKey("RentedCarsList") AndAlso userDict("RentedCarsList") IsNot Nothing Then
                GlobalData.RentedCars = CType(userDict("RentedCarsList"), List(Of Dictionary(Of String, Object))).Count
            Else
                GlobalData.RentedCars = 0
            End If

            ' Ensure SavedBillingPanels exists for old users
            If Not userDict.ContainsKey("SavedBillingPanels") Then
                userDict("SavedBillingPanels") = New List(Of Dictionary(Of String, Object))()
            End If

            MessageBox.Show(email + ": Logged in successfully!")
            Return True
        Else
            Return False
        End If
    End Function

    ' User logout
    Public Sub LogoutUser()
        CurrentUserEmail = ""
        CurrentUserPassword = ""
        IsLoggedIn = False
        UserRole = ""
        UserFullName = ""
        Age = 0
        Address = ""
        Birthday = Date.MinValue
        Gender = ""
        IsGoodRecord = True
        IsBooked = False
        CarRented = ""
        RentalStartDate = Nothing
        RentalEndDate = Nothing
        RentedCars = 0
        Wallet = 0.0
        var = Nothing
    End Sub

    ' Add a new car
    Public Function AddCar(carID As String, carName As String, plateNumber As String, bodyNumber As String,
                           color As String, type As String, capacity As Integer, dailyPrice As Double,
                           Optional isAvailable As Boolean = True) As Boolean
        If CarsDict.ContainsKey(carID) Then
            Return False
        Else
            Dim carDict As New Dictionary(Of String, Object) From {
                {"CarID", carID},
                {"CarName", carName},
                {"PlateNumber", plateNumber},
                {"BodyNumber", bodyNumber},
                {"Color", color},
                {"Type", type},
                {"Capacity", capacity},
                {"DailyPrice", dailyPrice},
                {"IsAvailable", isAvailable}
            }
            CarsDict.Add(carID, carDict)
            NotifyDataChanged()
            Return True
        End If
    End Function

    ' Get car details by CarID
    Public Function GetCar(carID As String) As Dictionary(Of String, Object)
        If CarsDict.ContainsKey(carID) Then
            Return CarsDict(carID)
        End If
        Return Nothing
    End Function

    ' Add a new transaction
    Public Function AddTransaction(carID As String, customerEmail As String, startDate As Date, endDate As Date,
                              totalPrice As Double, Optional status As String = "Booked") As Integer
        Dim transactionID As Integer = If(TransactionsDict.Count = 0, 1, TransactionsDict.Keys.Max() + 1)

        ' Get car details
        Dim carDict As Dictionary(Of String, Object) = Nothing
        If CarsDict.ContainsKey(carID) Then
            carDict = CarsDict(carID)
        End If

        ' Get user details
        Dim userDict As Dictionary(Of String, Object) = Nothing
        If UsersDict.ContainsKey(customerEmail) Then
            userDict = UsersDict(customerEmail)
        End If

        Dim transactionDict As New Dictionary(Of String, Object) From {
        {"TransactionID", transactionID},
        {"CarID", carID},
        {"CustomerEmail", customerEmail},
        {"StartDate", startDate},
        {"EndDate", endDate},
        {"TotalPrice", totalPrice},
        {"Status", status}
    }

        ' Add car details if available
        If carDict IsNot Nothing Then
            If carDict.ContainsKey("PlateNumber") Then transactionDict("PlateNumber") = carDict("PlateNumber")
            If carDict.ContainsKey("BodyNumber") Then transactionDict("BodyNumber") = carDict("BodyNumber")
            If carDict.ContainsKey("Color") Then transactionDict("Color") = carDict("Color")
            If carDict.ContainsKey("Type") Then transactionDict("Type") = carDict("Type")
            If carDict.ContainsKey("Capacity") Then transactionDict("Capacity") = carDict("Capacity")
            If carDict.ContainsKey("DailyPrice") Then transactionDict("DailyPrice") = carDict("DailyPrice")
        End If

        ' Add user details if available
        If userDict IsNot Nothing Then
            If userDict.ContainsKey("FullName") Then transactionDict("CustomerName") = userDict("FullName")
            If userDict.ContainsKey("Address") Then transactionDict("CustomerAddress") = userDict("Address")
        End If

        TransactionsDict.Add(transactionID, transactionDict)
        NotifyDataChanged()
        Return transactionID
    End Function

    ' Get transaction by ID
    Public Function GetTransaction(transactionID As Integer) As Dictionary(Of String, Object)
        If TransactionsDict.ContainsKey(transactionID) Then
            Return TransactionsDict(transactionID)
        End If
        Return Nothing
    End Function

    ' Get all transactions for a specific customer
    Public Function GetCustomerTransactions(customerEmail As String) As List(Of Dictionary(Of String, Object))
        Return TransactionsDict.Values.Where(Function(t) t("CustomerEmail").ToString() = customerEmail).ToList()
    End Function

    ' Get all transactions for a specific car
    Public Function GetCarTransactions(carID As String) As List(Of Dictionary(Of String, Object))
        Return TransactionsDict.Values.Where(Function(t) t("CarID").ToString() = carID).ToList()
    End Function

    ' Mark a car as returned
    Public Function ReturnCar(transactionID As Integer) As Boolean
        If TransactionsDict.ContainsKey(transactionID) Then
            Dim transaction = TransactionsDict(transactionID)
            transaction("Status") = "Returned"
            transaction("DateReturned") = DateTime.Now
            ' Set car as available
            Dim carID = transaction("CarID").ToString()
            If CarsDict.ContainsKey(carID) Then
                CarsDict(carID)("IsAvailable") = True
            End If
            NotifyDataChanged()
            Return True
        End If
        Return False
    End Function

    ' Call this to ensure the "test" user is fully set up and 10 cars are generated
    ' Call this to ensure the "test" user is fully set up and 10 cars are generated
    Public Sub SetupTestUserAndCars()
        ' --- Complete test user profile ---
        Dim email As String = "test"
        Dim password As String = "test"
        If Not UsersDict.ContainsKey(email) Then
            RegisterUser(email, password, "Test User", 25, "123 Test St", #1/1/2000#, "Other", True, 10000, "user")
        End If
        Dim user = UsersDict(email)
        user("FullName") = "Test User"
        user("Age") = 25
        user("Address") = "123 Test St"
        user("Birthday") = #1/1/2000#
        user("Gender") = "Other"
        user("IsGoodRecord") = True
        user("Wallet") = 10000.0
        user("UserRole") = "user"
        user("IsBooked") = False
        user("CarRented") = ""
        user("RentedCars") = 0
        user("var") = ""
        If Not user.ContainsKey("RentedCarsList") Then user("RentedCarsList") = New List(Of Dictionary(Of String, Object))()
        If Not user.ContainsKey("SavedBillingPanels") Then user("SavedBillingPanels") = New List(Of Dictionary(Of String, Object))()

        ' --- Generate 10 cars if not already present ---
        For i As Integer = 1 To 10
            Dim carId As String = $"CAR{i:000}"
            If Not CarsDict.ContainsKey(carId) Then
                Dim carDict As New Dictionary(Of String, Object) From {
                    {"CarID", carId},
                    {"CarName", $"Test Car {i}"},
                    {"PlateNumber", $"PLT{i:000}"},
                    {"BodyNumber", $"BDY{i:000}"},
                    {"Color", "Red"},
                    {"Type", "Sedan"},
                    {"Capacity", 5},
                    {"DailyPrice", 1000 + i * 100},
                    {"IsAvailable", True},
                    {"PrimaryImage", My.Resources.PLACEHOLDER_Car},
                    {"SecondaryImage", My.Resources.PLACEHOLDER_Car},
                    {"BriefDetails", $"This is a test car number {i}."},
                    {"Details", $"Test Car {i} is a demo vehicle for testing purposes."}
                }
                CarsDict.Add(carId, carDict)
            Else
                ' If car already exists, ensure it has the image keys
                Dim carDict = CarsDict(carId)
                If Not carDict.ContainsKey("PrimaryImage") Then carDict("PrimaryImage") = My.Resources.PLACEHOLDER_Car
                If Not carDict.ContainsKey("SecondaryImage") Then carDict("SecondaryImage") = My.Resources.PLACEHOLDER_Car
                If Not carDict.ContainsKey("BriefDetails") Then carDict("BriefDetails") = $"This is a test car number {i}."
                If Not carDict.ContainsKey("Details") Then carDict("Details") = $"Test Car {i} is a demo vehicle for testing purposes."
            End If
        Next

        NotifyDataChanged()
    End Sub



End Module
