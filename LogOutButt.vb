Imports System.Linq

Public Class TransparentButton
    Inherits Button

    Public Sub New()

        Me.FlatStyle = FlatStyle.Flat
        Me.FlatAppearance.BorderSize = 0
        Me.BackColor = Color.Transparent
        Me.ForeColor = Color.Black
        Me.Text = "Logout"
        Me.Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)

        Me.Parent?.Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)


        GlobalData.LogoutUser()

        MessageBox.Show("You have been logged out successfully.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim formsToClose = Application.OpenForms.Cast(Of Form)().Where(Function(f) Not TypeOf f Is LoginForm).ToList()
        For Each form As Form In formsToClose
            form.Close()
        Next

        Dim loginForm = Application.OpenForms.OfType(Of LoginForm)().FirstOrDefault()
        If loginForm Is Nothing Then
            loginForm = New LoginForm()
            loginForm.Show()
        End If
    End Sub
End Class
