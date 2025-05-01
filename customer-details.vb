Imports MySql.Data.MySqlClient

Public Class customer_details
    Public Property listMainDatabase As New List(Of List(Of Object)) From { 'Main database for each customer details
    New List(Of Object)(), 'Name
    New List(Of Object)(), 'Age
    New List(Of Object)(), 'Address
    New List(Of Object)(), 'Birthday
    New List(Of Object)()  'Gender
    }

    Public Property customerName As List(Of String) = New List(Of String)
    Public Property customerAge As List(Of Integer) = New List(Of Integer)
    Public Property customerAddress As List(Of String) = New List(Of String)
    Public Property customerBday As List(Of Object) = New List(Of Object)
    Public Property customerGender As List(Of String) = New List(Of String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpBirthday.Format = DateTimePickerFormat.Custom
        dtpBirthday.CustomFormat = " "
    End Sub

    Private Sub dtpBirthday_ValueChanged(sender As Object, e As EventArgs) Handles dtpBirthday.ValueChanged
        dtpBirthday.Format = DateTimePickerFormat.Short
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConfChan.Click 'Show results

        'Validate required fields
        If String.IsNullOrWhiteSpace(txtboxName.Text) OrElse
           String.IsNullOrWhiteSpace(txtboxAge.Text) OrElse
           String.IsNullOrWhiteSpace(txtboxAddress.Text) Then

            MessageBox.Show("❗ Please fill out all required fields: Name, Age, and Address.",
                            "Missing Info!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtboxName.Focus()
            txtboxAge.Focus()
            txtboxAddress.Focus()
            Exit Sub
        End If


        Dim ageValue As Integer
        If Not Integer.TryParse(txtboxAge.Text.Trim(), ageValue) Then
            MessageBox.Show("❗ Age must be a number.", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Determine gender
        Dim selectedGender As String = "Not Specified"
        If rbMale.Checked Then
            selectedGender = "Male"
        ElseIf rbFemale.Checked Then
            selectedGender = "Female"
        ElseIf rbOthers.Checked Then
            selectedGender = "Others"
        End If

        'Store values in individual lists
        customerName.Add(txtboxName.Text.Trim())
        customerAge.Add(ageValue)
        customerAddress.Add(txtboxAddress.Text.Trim())
        customerBday.Add(dtpBirthday.Value)
        customerGender.Add(selectedGender)

        'Store values in main database (each column is a sublist)
        listMainDatabase(0).Add(txtboxName.Text.Trim())
        listMainDatabase(1).Add(ageValue)
        listMainDatabase(2).Add(txtboxAddress.Text.Trim())
        listMainDatabase(3).Add(dtpBirthday.Value)
        listMainDatabase(4).Add(selectedGender)

        'Clear and show all in ListBox1
        ListBox1.Items.Clear()
        For i As Integer = 0 To customerName.Count - 1
            ListBox1.Items.Add($"Name: {customerName(i)} | Age: {customerAge(i)} | Address: {customerAddress(i)} | Birthday: {CDate(customerBday(i)).ToShortDateString()} | Gender: {customerGender(i)}")
        Next
    End Sub



    Private Sub btnVerifyRecords_Click(sender As Object, e As EventArgs) Handles btnVerifyRecords.Click
        Me.Close()
    End Sub

    Private Sub btnChangeCredentials_Click(sender As Object, e As EventArgs) Handles btnChanCredent.Click


        customer_details_2.Show()
        Me.Hide()
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Me.Hide()
    End Sub
End Class
