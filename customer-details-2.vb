Imports System.Text.RegularExpressions

Public Class customer_details_2

    Public Property mainForm As customer_details 'To link this form to the customer_details esp the database

    Private Function IsValidPassword(password As String) As Boolean
        'Combination of all possible passwords of user
        ' ^                 : start of string
        ' (?=.*[A-Za-z])   : at least one letter
        ' (?=.*\d)         : at least one digit
        ' (?=.*[@$!%*?&])  : at least one special character
        ' .{8,}            : minimum 8 characters
        ' $                : end of string

        Dim pattern As String = "^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"
        Return Regex.IsMatch(password, pattern)
    End Function

    Public Property listSecondDatabase As New List(Of List(Of String)) From {  'Secondary database for overriding credentials
        New List(Of String)(),
        New List(Of String)(),
        New List(Of String)()
    }
    Public Property listNewEmail As New List(Of String)
    Public Property listNewPassword As New List(Of String)
    Public Property listConfPassword As New List(Of String)

    Private Sub btnConfChanges_Click(sender As Object, e As EventArgs) Handles btnConfChanges.Click
        Dim newEmail As String = txtNewEmail.Text.Trim()
        Dim newPassword As String = txtNewPass.Text.Trim()
        Dim confPassword As String = txtConfPass.Text.Trim()

        'Check if fields are empty
        If String.IsNullOrWhiteSpace(newEmail) AndAlso
           String.IsNullOrWhiteSpace(newPassword) AndAlso
           String.IsNullOrWhiteSpace(confPassword) Then

            MessageBox.Show("There are no changes made.", "No Changes!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If newPassword <> confPassword Then
            MessageBox.Show("Passwords do not match.", "Mismatch!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        If Not IsValidPassword(newPassword) Then
            MessageBox.Show("Password must be at least 8 characters long and include a mix of letters, numbers, and special characters.",
                    "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'Confirm exit
        Dim result = MessageBox.Show("Are you sure you want to apply changes?", "Confirm Changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If result = DialogResult.Cancel Then
            Exit Sub
        End If


        'Save the new data
        listNewEmail.Add(newEmail)
        listNewPassword.Add(newPassword)
        listConfPassword.Add(confPassword)

        listSecondDatabase(0).Add(newEmail)
        listSecondDatabase(1).Add(newPassword)
        listSecondDatabase(2).Add(confPassword)

        'Show confirmation
        MessageBox.Show("Changes have been applied!", "Successfully Changed!", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Show the stored info inside database on ListBox
        ListBox1.Items.Clear()

        If listSecondDatabase IsNot Nothing Then
            Dim entryCount As Integer = listSecondDatabase(0).Count

            For i As Integer = 0 To entryCount - 1
                ' Combine each field into one line (row)
                Dim email = listSecondDatabase(0)(i).ToString()
                Dim password = listSecondDatabase(1)(i).ToString()

                Dim fullEntry As String = $"Email: {email} | Password: {password}"
                ListBox1.Items.Add(fullEntry)
            Next
        End If


    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        customer_details.Show()
        Me.Close()
    End Sub

    Private Sub btnTogglePass_Click(sender As Object, e As EventArgs) Handles btnTogglePass.Click 'Show/Hide Password on runtime
        If txtNewPass.PasswordChar = "*"c Then
            txtNewPass.PasswordChar = ControlChars.NullChar
            txtConfPass.PasswordChar = ControlChars.NullChar
            btnTogglePass.Text = "Hide Password"
        Else
            txtNewPass.PasswordChar = "*"c
            txtConfPass.PasswordChar = "*"c
            btnTogglePass.Text = "Show Password"
        End If
    End Sub


End Class