Public Class WalletAdd
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Billing.UpdateBillingDetails()
        Me.Close()
    End Sub


    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        Dim amount As Double
        If Not Double.TryParse(TextBox1.Text, amount) OrElse amount <= 0 Then
            MessageBox.Show("Please enter a valid positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        GlobalData.Wallet += amount

        Dim user = GlobalData.GetLoggedInUser()
        If user IsNot Nothing Then
            user("Wallet") = GlobalData.Wallet
        End If

        MessageBox.Show($"Successfully added ₱{amount:N2} to your wallet!" & vbCrLf & $"New Balance: ₱{GlobalData.Wallet:N2}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        TextBox1.Clear()
        Billing.UpdateBalance()
        Billing.UpdateBillingDetails()
        Me.Close()


    End Sub

End Class
