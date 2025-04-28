Imports ZstdSharp.Unsafe

Public Class customer_details_2
    Public Property newEmail As String
    Public Property newPassword As String
    Public Property confPassword As String
    Private Sub btnConfChanges_Click(sender As Object, e As EventArgs) Handles btnConfChanges.Click
        newEmail = txtNewEmail.Text
        newPassword = txtNewPass.Text
        confPassword = txtConfPass.Text
        MessageBox.Show("Changes have been applied!", "Successfully Changed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        customer_details.Show()
        Me.Close()

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        customer_details.Show()
        Me.Close()
    End Sub
End Class