<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Survey
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'Survey
        '
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Name = "Survey"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents surveyQ1 As GroupBox
    Friend WithEvents surveyQ1btn1 As RadioButton
    Friend WithEvents surveyQ1btn4 As RadioButton
    Friend WithEvents surveyQ1btn3 As RadioButton
    Friend WithEvents surveyQ1btn5 As RadioButton
    Friend WithEvents surveyQ1btn2 As RadioButton
    Friend WithEvents surveyQ2 As GroupBox
    Friend WithEvents surveyQ2btn4 As RadioButton
    Friend WithEvents surveyQ2btn3 As RadioButton
    Friend WithEvents surveyQ2btn5 As RadioButton
    Friend WithEvents surveyQ2btn2 As RadioButton
    Friend WithEvents surveyQ2btn1 As RadioButton
    Friend WithEvents surveyQ3 As GroupBox
    Friend WithEvents surveyQ3btn4 As RadioButton
    Friend WithEvents surveyQ3btn3 As RadioButton
    Friend WithEvents surveyQ3btn5 As RadioButton
    Friend WithEvents surveyQ3btn2 As RadioButton
    Friend WithEvents surveyQ3btn1 As RadioButton
    Friend WithEvents surveyQ4 As GroupBox
    Friend WithEvents surveyQ4btn4 As RadioButton
    Friend WithEvents surveyQ4btn3 As RadioButton
    Friend WithEvents surveyQ4btn5 As RadioButton
    Friend WithEvents surveyQ4btn2 As RadioButton
    Friend WithEvents surveyQ4btn1 As RadioButton
    Friend WithEvents surveyQ5 As GroupBox
    Friend WithEvents surveyQ5btn4 As RadioButton
    Friend WithEvents surveyQ5btn3 As RadioButton
    Friend WithEvents surveyQ5btn5 As RadioButton
    Friend WithEvents surveyQ5btn2 As RadioButton
    Friend WithEvents surveyQ5btn1 As RadioButton
    Friend WithEvents ButtonSubmit As Button
    Friend WithEvents ButtonBack As Button
End Class
