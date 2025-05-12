Imports Org.BouncyCastle.Asn1.Cmp

Public Class customerDetails

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        homeForm.Show()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validate customer details
        VerifyCustomerDetails()
    End Sub

    Private Sub customerDetails_Activated(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Refresh()
        DateTimePicker1.Value = Date.Today ' Assuming you have a DateTimePicker for birthday
        MessageBox.Show(GlobalData.CurrentUserEmail)

        ' Only populate fields if Var is "!Allowed" or "Allowed"
        If GlobalData.var = "!Allowed" Or GlobalData.var = "Allowed" Then
            TextBox1.Text = GlobalData.UserFullName
            TextBox2.Text = GlobalData.Age.ToString()
            TextBox3.Text = GlobalData.Address
        End If
    End Sub

    Private Sub customerDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Today ' Assuming you have a DateTimePicker for birthday
        MessageBox.Show(GlobalData.CurrentUserEmail)

        ' Only populate fields if Var is "!Allowed" or "Allowed"
        If GlobalData.var = "!Allowed" Or GlobalData.var = "Allowed" Then
            TextBox1.Text = GlobalData.UserFullName
            TextBox2.Text = GlobalData.Age.ToString()
            TextBox3.Text = GlobalData.Address
        End If
    End Sub
    Private Sub VerifyCustomerDetails()
        ' Validate required fields
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Please enter your name.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim age As Integer
        If Not Integer.TryParse(TextBox2.Text, age) Then
            MessageBox.Show("Age must be a numerical value!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(TextBox3.Text) Then
            MessageBox.Show("Please enter your address.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if at least one radio button is selected
        Dim gender As String = "Other"
        If RadioButton1.Checked Then
            gender = "Male"
        ElseIf RadioButton2.Checked Then
            gender = "Female"
        ElseIf Not RadioButton3.Checked Then
            MessageBox.Show("Please select a gender!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate the birthdate (example: ensure it's not today's date)
        If DateTimePicker1.Value.Date = Date.Today Then
            MessageBox.Show("Birthdate cannot be today's date!", "Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' If all validations pass, save customer details
        SaveCustomerDetails()
    End Sub

    Private Sub SaveCustomerDetails()
        ' Retrieve gender selection
        Dim gender As String = "Other"
        If RadioButton1.Checked Then
            gender = "Male"
        ElseIf RadioButton2.Checked Then
            gender = "Female"
        End If

        ' Prepare user data
        Dim userData(14) As Object ' 0 to 14
        userData(0) = TextBox1.Text.Trim() ' Name
        userData(1) = Integer.Parse(TextBox2.Text) ' Age
        userData(2) = TextBox3.Text.Trim() ' Address
        userData(3) = DateTimePicker1.Value.ToShortDateString() ' Birthday
        userData(4) = gender ' Gender
        userData(5) = GlobalData.CurrentUserEmail ' Email
        userData(6) = GlobalData.CurrentUserPassword ' Password
        userData(7) = True ' Good Record
        userData(8) = "N/A" ' Status
        userData(9) = "" ' Car ID
        userData(10) = "" ' Car Name
        userData(11) = Nothing ' Start Date
        userData(12) = Nothing ' End Date
        userData(13) = Nothing ' Date Returned
        userData(14) = GlobalData.Wallet ' Current Wallet

        ' Add to global users list
        GlobalData.UsersList.Add(userData)

        ' Notify that data has changed to update any listening forms
        GlobalData.NotifyDataChanged()

        ' Close the form and show the survey
        Me.Hide()
        Survey.Show()
        MessageBox.Show("Customer details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        If GlobalData.var = "!Allowed" Then
            MessageBox.Show("Please complete the survey to proceed.", "Survey Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
    End Sub
End Class
