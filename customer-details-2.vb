Imports ZstdSharp.Unsafe

Public Class customer_details_2
    Public Property listDatabase As New List(Of List(Of Object)) From {  'main database for overriding credentials
        New List(Of Object)(),
        New List(Of Object)(),
        New List(Of Object)()
    }
    Public Property listNewEmail As List(Of Object) = New List(Of Object)
    Public Property listNewPassword As List(Of Object) = New List(Of Object)
    Public Property listConfPassword As List(Of Object) = New List(Of Object)
    Private Sub btnConfChanges_Click(sender As Object, e As EventArgs) Handles btnConfChanges.Click
        Dim newEmail As Object = txtNewEmail.Text.Trim
        Dim newPassword As Object = txtNewPass.Text.Trim
        Dim confPassword As Object = txtConfPass.Text.Trim

        For Each email In listNewEmail
            If email Is txtNewEmail Then
                listNewEmail = newEmail
            End If
        Next

        For Each pass In listNewPassword
            If pass Is txtNewPass Then
                listNewPassword = newPassword
            End If
        Next

        For Each confpass In listConfPassword
            If confPassword Is txtConfPass Then
                listConfPassword = confPassword
            End If
        Next

        MessageBox.Show("Changes have been applied!", "Successfully Changed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        customer_details.Show()
        Me.Close()

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        customer_details.Show()
        Me.Close()
    End Sub
End Class