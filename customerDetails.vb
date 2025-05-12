Public Class customerDetails

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        homeForm.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        VerifyCustomerDetails()
    End Sub

    Private Sub customerDetails_Activated(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Refresh()
        DateTimePicker1.Value = Date.Today

    End Sub

    Private Sub customerDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Today

    End Sub

    Private Sub VerifyCustomerDetails()
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

        Dim gender As String = "Other"
        If RadioButton1.Checked Then
            gender = "Male"
        ElseIf RadioButton2.Checked Then
            gender = "Female"
        ElseIf Not RadioButton3.Checked Then
            MessageBox.Show("Please select a gender!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DateTimePicker1.Value.Date = Date.Today Then
            MessageBox.Show("Birthdate cannot be today's date!", "Incorrect Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        SaveCustomerDetails()
    End Sub

    Private Sub SaveCustomerDetails()
        Dim gender As String = "Other"
        If RadioButton1.Checked Then
            gender = "Male"
        ElseIf RadioButton2.Checked Then
            gender = "Female"
        End If

        Dim email As String = GlobalData.CurrentUserEmail
        If String.IsNullOrEmpty(email) Then
            MessageBox.Show("No user is currently logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Prepare user dictionary
        Dim userDict As New Dictionary(Of String, Object) From {
            {"Email", email},
            {"FullName", TextBox1.Text.Trim()},
            {"Password", GlobalData.CurrentUserPassword},
            {"Age", Integer.Parse(TextBox2.Text)},
            {"Address", TextBox3.Text.Trim()},
            {"Birthday", DateTimePicker1.Value},
            {"Gender", gender},
            {"IsGoodRecord", True},
            {"IsBooked", False},
            {"Wallet", GlobalData.Wallet},
            {"UserRole", "user"}
        }

        ' Save or update in UsersDict
        GlobalData.UsersDict(email) = userDict
        GlobalData.UserFullName = userDict("FullName").ToString()
        GlobalData.Age = CInt(userDict("Age"))
        GlobalData.Address = userDict("Address").ToString()
        GlobalData.Birthday = CType(userDict("Birthday"), Date)
        GlobalData.Gender = userDict("Gender").ToString()
        GlobalData.Wallet = CDbl(userDict("Wallet"))

        GlobalData.NotifyDataChanged()

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
