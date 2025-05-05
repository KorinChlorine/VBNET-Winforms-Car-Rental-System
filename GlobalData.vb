Public Module GlobalData
    Public GlobalOuterArray As New List(Of Object())()
    Public PremiumCarsArray As New List(Of Object())()
    Public RegisteredUsers As New List(Of Tuple(Of String, String))()
    Public Transactions As New List(Of Dictionary(Of String, Object))() ' New list to store transactions
    Public CarsList As New List(Of Object())()

    Public Event DataChanged()
    Public Sub NotifyDataChanged()
        RaiseEvent DataChanged()
    End Sub

    Public Sub AddTransaction(transaction As Dictionary(Of String, Object))
        Transactions.Add(transaction)
        NotifyDataChanged()
    End Sub
End Module
