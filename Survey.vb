Public Class Survey
    Private Sub Survey_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Assign values to radio buttons using the Tag property
        ' Question 1
        surveyQ1btn1.Tag = 1
        surveyQ1btn2.Tag = 2
        surveyQ1btn3.Tag = 3
        surveyQ1btn4.Tag = 4
        surveyQ1btn5.Tag = 5

        ' Question 2
        surveyQ2btn1.Tag = 1
        surveyQ2btn2.Tag = 2
        surveyQ2btn3.Tag = 3
        surveyQ2btn4.Tag = 4
        surveyQ2btn5.Tag = 5

        ' Question 3
        surveyQ3btn1.Tag = 1
        surveyQ3btn2.Tag = 2
        surveyQ3btn3.Tag = 3
        surveyQ3btn4.Tag = 4
        surveyQ3btn5.Tag = 5

        ' Question 4
        surveyQ4btn1.Tag = 1
        surveyQ4btn2.Tag = 2
        surveyQ4btn3.Tag = 3
        surveyQ4btn4.Tag = 4
        surveyQ4btn5.Tag = 5

        ' Question 5
        surveyQ5btn1.Tag = 1
        surveyQ5btn2.Tag = 2
        surveyQ5btn3.Tag = 3
        surveyQ5btn4.Tag = 4
        surveyQ5btn5.Tag = 5
    End Sub

    Private Function GetSelectedValue(groupBox As GroupBox) As Integer
        ' Loop through all radio buttons in the group box
        For Each control As Control In groupBox.Controls
            If TypeOf control Is RadioButton Then
                Dim radioButton As RadioButton = CType(control, RadioButton)
                If radioButton.Checked Then
                    Return CInt(radioButton.Tag) ' Return the value stored in the Tag property
                End If
            End If
        Next
        Return -1 ' Return -1 if no radio button is selected
    End Function

    Private Sub ResetSurvey()
        ' Uncheck all radio buttons
        For Each control As Control In Me.Controls
            If TypeOf control Is GroupBox Then
                For Each innerControl As Control In control.Controls
                    If TypeOf innerControl Is RadioButton Then
                        Dim radioButton As RadioButton = CType(innerControl, RadioButton)
                        radioButton.Checked = False
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub SubmitSurvey()
        ' Retrieve selected values for each question
        Dim q1Value As Integer = GetSelectedValue(surveyQ1)
        Dim q2Value As Integer = GetSelectedValue(surveyQ2)
        Dim q3Value As Integer = GetSelectedValue(surveyQ3)
        Dim q4Value As Integer = GetSelectedValue(surveyQ4)
        Dim q5Value As Integer = GetSelectedValue(surveyQ5)

        ' Check if all questions are answered
        If q1Value = -1 Or q2Value = -1 Or q3Value = -1 Or q4Value = -1 Or q5Value = -1 Then
            MessageBox.Show("You did not answer all the questions. The survey will reset.", "Incomplete Survey", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ResetSurvey()
            Return
        End If

        ' Calculate the total score
        Dim totalScore As Integer = q1Value + q2Value + q3Value + q4Value + q5Value
        Dim maxScore As Integer = 5 * 5 ' 5 questions, each with a max score of 5
        Dim percentage As Double = (totalScore / maxScore) * 100

        ' Display the appropriate message
        If percentage >= 60 Then
            MessageBox.Show("You are allowed to rent a car.", "Survey Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("You are not allowed to rent a car.", "Survey Result", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' Reset the survey after submission
        ResetSurvey()
    End Sub

    Private Sub ButtonSubmit_Click(sender As Object, e As EventArgs) Handles ButtonSubmit.Click
        SubmitSurvey()
    End Sub

    Private Sub ButtonBack_Click(sender As Object, e As EventArgs) Handles ButtonBack.Click
        Me.Close()
        customerDetails.Show()
    End Sub
End Class
