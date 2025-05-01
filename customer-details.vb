Imports MySql.Data.MySqlClient


Public Class customer_details
    Public Property customerName As List(Of String) = New List(Of String)
    Public Property customerAge As List(Of Integer) = New List(Of Integer)
    Public Property customerAddress As List(Of String) = New List(Of String)
    Public Property customerBday As List(Of String) = New List(Of String)
    Public Property customerGender As List(Of String) = New List(Of String)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpBirthday.Format = DateTimePickerFormat.Custom
        dtpBirthday.CustomFormat = " "
    End Sub
    Private Sub dtpBirthday_ValueChanged(sender As Object, e As EventArgs) Handles dtpBirthday.ValueChanged
        ' Dim res As Date = dtpBirthday.Value
        dtpBirthday.Format = DateTimePickerFormat.Short
        'lblBirthday.Text = res.ToString("MMM-dd-yyyy")'
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConfChan.Click 'show results

        ' Validate Required Fields
        If String.IsNullOrWhiteSpace(txtboxName.Text) OrElse
           String.IsNullOrWhiteSpace(txtboxAge.Text) OrElse
           dtpBirthday.CustomFormat = " " OrElse
           String.IsNullOrWhiteSpace(txtboxAddress.Text) OrElse
           String.IsNullOrWhiteSpace(txtboxAddress.Text) Then

            MessageBox.Show("❗ Please fill out all required fields: Name, Age, Birthday, and Address.",
                            "Missing Info!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        txtboxName.Text = txtboxName.Text.Trim()
        txtboxAge.Text = txtboxAge.Text.Trim()
        txtboxAddress.Text = txtboxAddress.Text.Trim()

        ' Show the selected Birthday properly
        dtpBirthday.Format = DateTimePickerFormat.Short

        ' Handle Gender separately
        If rbMale.Checked Then
            rbMale.Text = "Male"
            rbFemale.Text = "Female"
            rbOthers.Text = "Others"
        ElseIf rbFemale.Checked Then
            rbMale.Text = "Male"
            rbFemale.Text = "Female"
            rbOthers.Text = "Others"
        ElseIf rbOthers.Checked Then
            rbMale.Text = "Male"
            rbFemale.Text = "Female"
            rbOthers.Text = "Others"
        End If

    End Sub



    Private Sub btnVerifyRecords_Click(sender As Object, e As EventArgs) Handles btnVerifyRecords.Click
        'Dim changeInfo As New customer_details_2
        'customer_details_2.newEmail = txtboxName.Text
        'Customer_details_2.Show() '
        Me.Hide()
    End Sub

    Private Sub btnChangeCredentials_Click(sender As Object, e As EventArgs) Handles btnChanCredent.Click


        customer_details_2.Show()
        Me.Hide()
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Me.Close()
    End Sub
End Class
