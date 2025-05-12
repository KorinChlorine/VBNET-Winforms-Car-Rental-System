Imports System.Linq

Public Class TransparentButton
    Inherits Button

    Public Sub New()
        ' Set button properties for transparency
        Me.FlatStyle = FlatStyle.Flat
        Me.FlatAppearance.BorderSize = 0
        Me.BackColor = Color.Transparent
        Me.ForeColor = Color.Black
        Me.Text = "Logout"
        Me.Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        ' Ensure the button is drawn with transparency
        MyBase.OnPaint(pevent)
        Me.Parent?.Invalidate() ' Redraw parent to maintain transparency
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)

        ' Log out the user
        GlobalData.LogoutUser()

        ' Notify the user
        MessageBox.Show("You have been logged out successfully.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Close all forms except the current one
        Dim formsToClose = Application.OpenForms.Cast(Of Form)().Where(Function(f) Not TypeOf f Is LoginForm).ToList()
        For Each form As Form In formsToClose
            form.Close()
        Next

        ' Reopen the login form if it's not already open
        Dim loginForm = Application.OpenForms.OfType(Of LoginForm)().FirstOrDefault()
        If loginForm Is Nothing Then
            loginForm = New LoginForm()
            loginForm.Show()
        End If
    End Sub
End Class
