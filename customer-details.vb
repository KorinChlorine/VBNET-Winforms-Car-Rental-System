Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpBirthday.Format = DateTimePickerFormat.Custom
        dtpBirthday.CustomFormat = " "
    End Sub
    Private Sub dtpBirthday_ValueChanged(sender As Object, e As EventArgs) Handles dtpBirthday.ValueChanged
        Dim res As Date = dtpBirthday.Value
        dtpBirthday.Format = DateTimePickerFormat.Short
        lblBirthday.Text = res.ToString("MMM-dd-yyyy")
    End Sub


    Private Sub txtboxCarID_TextChanged(sender As Object, e As EventArgs) Handles txtboxCarID.TextChanged

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(txtboxName.Text) OrElse
       String.IsNullOrWhiteSpace(txtboxAge.Text) OrElse
       dtpBirthday.CustomFormat = " " OrElse
       String.IsNullOrWhiteSpace(txtboxAddress.Text) OrElse
       String.IsNullOrWhiteSpace(txtboxCarID.Text) Then


            MessageBox.Show("❗ Please fill out all required fields: Name, Age, Birthday, and Address.",
                            "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedGender As String
        If rbMale.Checked Then
            selectedGender = "Male"
        ElseIf rbFemale.Checked Then
            selectedGender = "Female"
        Else
            rbOthers.Text = rbOthers.Checked
            selectedGender = "Prefer not to say/Others"
        End If

        txtRes.Text = "Name: " & txtboxName.Text & vbCrLf &
            "Age: " & txtboxAge.Text & vbCrLf &
            "Birthday: " & lblBirthday.Text & vbCrLf &
            "Gender: " & selectedGender & vbCrLf &
            "Address:" & txtboxAddress.Text & vbCrLf &
            "Car ID: " & txtboxCarID.Text & vbCrLf &
            "Days remaining: " & txtboxDays.Text & vbCrLf &
            "Records: " & txtboxRecords.Text

    End Sub


End Class
