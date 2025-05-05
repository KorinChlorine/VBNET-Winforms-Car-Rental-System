Public Module GlobalData
    Public GlobalOuterArray As New List(Of Object())()
    Public PremiumCarsArray As New List(Of Object())()
    Public RegisteredUsers As New List(Of Tuple(Of String, String))()

    Public Event DataChanged()
    Public Sub NotifyDataChanged()
        RaiseEvent DataChanged()
    End Sub
End Module
