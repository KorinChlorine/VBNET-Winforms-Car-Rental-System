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


        If IsNumeric(TextBox1.Text.Trim()) Then
            MessageBox.Show("Name cannot be a number.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim age As Integer
        If Not Integer.TryParse(TextBox2.Text, age) Then
            MessageBox.Show("Age must be a numerical value!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        If age <= 18 Then
            MessageBox.Show("You must be older than 18 to proceed.", "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim age As Integer
        If Integer.TryParse(TextBox2.Text, age) AndAlso age > 0 Then
            Dim today As Date = Date.Today
            Dim newYear As Integer = today.Year - age

            Dim newDate As Date
            Try
                newDate = New Date(newYear, today.Month, today.Day)
            Catch ex As ArgumentOutOfRangeException

                newDate = New Date(newYear, today.Month, Date.DaysInMonth(newYear, today.Month))
            End Try
            DateTimePicker1.Value = newDate
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Dim age As Integer
        If Integer.TryParse(TextBox2.Text, age) AndAlso age > 0 Then
            Dim today As Date = Date.Today
            Dim birthDate As Date = DateTimePicker1.Value
            Dim calculatedAge As Integer = today.Year - birthDate.Year
            If today < birthDate.AddYears(calculatedAge) Then
                calculatedAge -= 1
            End If
            If calculatedAge > age Then
                MessageBox.Show("The selected birth year does not match the entered age.", "Age Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Dim newYear As Integer = today.Year - age
                Try
                    DateTimePicker1.Value = New Date(newYear, today.Month, today.Day)
                Catch ex As ArgumentOutOfRangeException
                    DateTimePicker1.Value = New Date(newYear, today.Month, Date.DaysInMonth(newYear, today.Month))
                End Try
            End If
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs)
        If GlobalData.var = "!Allowed" Then
            MessageBox.Show("Please complete the survey to proceed.", "Survey Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
    End Sub
End Class
