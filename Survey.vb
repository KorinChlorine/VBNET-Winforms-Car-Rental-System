Public Class Survey
    Private Sub Survey_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Assign values to radio buttons using the Tag property
            For Each btn In {surveyQ1btn1, surveyQ1btn2, surveyQ1btn3, surveyQ1btn4, surveyQ1btn5}
                btn.Tag = Array.IndexOf({surveyQ1btn1, surveyQ1btn2, surveyQ1btn3, surveyQ1btn4, surveyQ1btn5}, btn) + 1
            Next
            For Each btn In {surveyQ2btn1, surveyQ2btn2, surveyQ2btn3, surveyQ2btn4, surveyQ2btn5}
                btn.Tag = Array.IndexOf({surveyQ2btn1, surveyQ2btn2, surveyQ2btn3, surveyQ2btn4, surveyQ2btn5}, btn) + 1
            Next
            For Each btn In {surveyQ3btn1, surveyQ3btn2, surveyQ3btn3, surveyQ3btn4, surveyQ3btn5}
                btn.Tag = Array.IndexOf({surveyQ3btn1, surveyQ3btn2, surveyQ3btn3, surveyQ3btn4, surveyQ3btn5}, btn) + 1
            Next
            For Each btn In {surveyQ4btn1, surveyQ4btn2, surveyQ4btn3, surveyQ4btn4, surveyQ4btn5}
                btn.Tag = Array.IndexOf({surveyQ4btn1, surveyQ4btn2, surveyQ4btn3, surveyQ4btn4, surveyQ4btn5}, btn) + 1
            Next
            For Each btn In {surveyQ5btn1, surveyQ5btn2, surveyQ5btn3, surveyQ5btn4, surveyQ5btn5}
                btn.Tag = Array.IndexOf({surveyQ5btn1, surveyQ5btn2, surveyQ5btn3, surveyQ5btn4, surveyQ5btn5}, btn) + 1
            Next
        Catch
            Return
        End Try
    End Sub

    Private Function GetSelectedValue(groupBox As GroupBox) As Integer
        For Each control As Control In groupBox.Controls
            If TypeOf control Is RadioButton Then
                Dim radioButton As RadioButton = CType(control, RadioButton)
                If radioButton.Checked Then
                    Return CInt(radioButton.Tag)
                End If
            End If
        Next
        Return -1
    End Function

    Private Sub ResetSurvey()
        For Each control As Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each innerControl As Control In control.Controls
                    If TypeOf innerControl Is RadioButton Then
                        CType(innerControl, RadioButton).Checked = False
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub SubmitSurvey()
        customerDetails.Close()
        Dim q1Value As Integer = GetSelectedValue(surveyQ1)
        Dim q2Value As Integer = GetSelectedValue(surveyQ2)
        Dim q3Value As Integer = GetSelectedValue(surveyQ3)
        Dim q4Value As Integer = GetSelectedValue(surveyQ4)
        Dim q5Value As Integer = GetSelectedValue(surveyQ5)

        If q1Value = -1 Or q2Value = -1 Or q3Value = -1 Or q4Value = -1 Or q5Value = -1 Then
            MessageBox.Show("You did not answer all the questions. The survey will reset.", "Incomplete Survey", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ResetSurvey()
            Return
        End If

        Dim totalScore As Integer = q1Value + q2Value + q3Value + q4Value + q5Value
        Dim maxScore As Integer = 5 * 5
        Dim percentage As Double = (totalScore / maxScore) * 100

        Dim email As String = GlobalData.CurrentUserEmail
        If String.IsNullOrEmpty(email) OrElse Not GlobalData.UsersDict.ContainsKey(email) Then
            MessageBox.Show("User not found or not logged in.", "Error")
            Return
        End If

        Dim userDict = GlobalData.UsersDict(email)

        If percentage >= 60 Then
            MessageBox.Show("You are allowed to rent a car.", "Survey Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GlobalData.SetVarForCurrentUser("Allowed")
            userDict("IsGoodRecord") = True
            userDict("SurveyScore") = percentage
            homeForm.RefreshUI()
            homeForm.Show()
            Me.Close()
        Else
            MessageBox.Show("You are not allowed to rent a car.", "Survey Result", MessageBoxButtons.OK, MessageBoxIcon.Error)
            GlobalData.SetVarForCurrentUser("!Allowed")
            userDict("IsGoodRecord") = False
            userDict("SurveyScore") = percentage
            homeForm.RefreshUI()
            Me.Close()
            homeForm.Show()
        End If

        GlobalData.NotifyDataChanged()
        ResetSurvey()
    End Sub

    Private Sub ButtonSubmit_Click(sender As Object, e As EventArgs) Handles ButtonSubmit.Click
        SubmitSurvey()
        MessageBox.Show("User Details Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ButtonBack_Click(sender As Object, e As EventArgs) Handles ButtonBack.Click
        Me.Close()
        customerDetails.Show()
    End Sub

    Private Sub closeForm_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub minimize_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
