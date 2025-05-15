Public Class DraggablePanel
    Inherits Panel

    Private isDragging As Boolean = False
    Private dragStartPoint As Point

    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        AddHandler Me.MouseDown, AddressOf DraggablePanel_MouseDown
        AddHandler Me.MouseMove, AddressOf DraggablePanel_MouseMove
        AddHandler Me.MouseUp, AddressOf DraggablePanel_MouseUp
    End Sub

    Private Sub DraggablePanel_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            isDragging = True
            dragStartPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub DraggablePanel_MouseMove(sender As Object, e As MouseEventArgs)
        If isDragging Then
            Dim parentForm = Me.FindForm()
            If parentForm IsNot Nothing Then
                Dim currentScreenPos As Point = Me.PointToScreen(e.Location)
                parentForm.Location = New Point(currentScreenPos.X - dragStartPoint.X, currentScreenPos.Y - dragStartPoint.Y)
            End If
        End If
    End Sub

    Private Sub DraggablePanel_MouseUp(sender As Object, e As MouseEventArgs)
        isDragging = False
    End Sub
End Class
