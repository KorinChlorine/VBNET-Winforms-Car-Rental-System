Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class RoundedPanel
    Inherits Panel

    ' Property to set the corner radius
    Private _cornerRadius As Integer = 20
    <Category("Appearance"), Description("The radius of the panel's corners.")>
    Public Property CornerRadius As Integer
        Get
            Return _cornerRadius
        End Get
        Set(value As Integer)
            _cornerRadius = value
            Me.Invalidate() ' Redraw the panel when the radius changes
        End Set
    End Property

    ' Override the OnPaint method to apply rounded corners
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Create a GraphicsPath for rounded corners
        Dim path As New GraphicsPath()
        Dim rect As Rectangle = Me.ClientRectangle
        Dim radius As Integer = CornerRadius

        ' Adjust the rectangle to account for borders
        rect.Width -= 1
        rect.Height -= 1

        ' Add arcs for rounded corners
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        ' Set the panel's region to the rounded path
        Me.Region = New Region(path)

        ' Optional: Draw a border
        Using pen As New Pen(Me.ForeColor, 1)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub
End Class
