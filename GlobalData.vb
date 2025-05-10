Public Module GlobalData
    ' Existing properties from your code
    Public GlobalOuterArray As New List(Of Object())()
    Public PremiumCarsArray As New List(Of Object())()
    Public RegisteredUsers As New List(Of Tuple(Of String, String))()
    Public Transactions As New List(Of Dictionary(Of String, Object))() ' List to store transactions
    Public CarsList As New List(Of Object())()
    Public Event DataChanged()
    Public UsersList As New List(Of Object())()


    ' New properties for user session management
    Public CurrentUserEmail As String = ""
    Public CurrentUserPassword As String = ""
    Public IsLoggedIn As Boolean = False
    Public UserRole As String = ""
    Public UserFullName As String = ""

    ' Existing methods from your code
    Public Sub NotifyDataChanged()
        RaiseEvent DataChanged()
    End Sub

    Public Sub AddTransaction(transaction As Dictionary(Of String, Object))
        Transactions.Add(transaction)
        NotifyDataChanged()
    End Sub

    ' New methods for user management
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