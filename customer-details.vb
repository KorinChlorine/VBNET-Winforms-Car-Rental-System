Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub dtpBirthday_ValueChanged(sender As Object, e As EventArgs) Handles dtpBirthday.ValueChanged
        Dim res As Date = dtpBirthday.Value
        Label9.Text = "Birthday: " & res.ToString("MM-dd-yyyy")
    End Sub

    Private Sub txtboxCarID_TextChanged(sender As Object, e As EventArgs) Handles txtboxCarID.TextChanged

    End Sub
End Class
