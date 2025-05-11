Imports Org.BouncyCastle.Asn1.Cmp

Public Class customerDetails

    Public Var As String

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        homeForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        customerDetailsCredentials.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Survey.Show()
    End Sub

    Private Sub customerDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Today ' Assuming you have a DateTimePicker for birthday
        MessageBox.Show(GlobalData.CurrentUserEmail)
    End Sub

    Private Sub SaveCustomerDetails()
        ' Validate required fields
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please enter your name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate age
        Dim age As Integer
        If Not Integer.TryParse(TextBox2.Text, age) Then
            MessageBox.Show("Age must be a numerical value!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get gender selection
        Dim gender As String = "Other"
        If RadioButton1.Checked Then
            gender = "Male"
        ElseIf RadioButton2.Checked Then
            gender = "Female"
        End If

        ' Create user data array
        Dim userData(11) As Object
        userData(0) = TextBox1.Text.Trim() ' Name
        userData(1) = age ' Age
        userData(2) = TextBox3.Text.Trim() ' Address
        userData(3) = DateTimePicker1.Value.ToShortDateString() ' Birthday (assuming DateTimePicker1 exists)
        userData(4) = gender ' Gender
        userData(5) = GlobalData.CurrentUserEmail ' Email from logged in user
        userData(6) = GlobalData.CurrentUserPassword ' Password from logged in user
        userData(7) = Nothing ' Good Record (default to true for new customers)
        userData(8) = False ' Status (not booked by default)
        userData(9) = "" ' No car rented yet
        userData(10) = Nothing ' No start date yet
        userData(11) = Nothing ' No end date yet

        ' Add to global users list
        GlobalData.UsersList.Add(userData)

        ' Notify that data has changed to update any listening forms
        GlobalData.NotifyDataChanged()

        MessageBox.Show("Customer details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If Var Is Nothing Then
            MessageBox.Show("Please complete the survey to proceed.", "Survey Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        Else
            SaveCustomerDetails()
        End If

    End Sub
End Class