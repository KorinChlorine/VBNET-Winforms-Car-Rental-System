<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TheDevs
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DraggablePanel1 = New VBNET_Car_Rental_System.DraggablePanel()
        Me.minimize = New System.Windows.Forms.Button()
        Me.closeForm = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(1080, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(158, 36)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DraggablePanel1
        '
        Me.DraggablePanel1.BackColor = System.Drawing.Color.Transparent
        Me.DraggablePanel1.Location = New System.Drawing.Point(-1, 2)
        Me.DraggablePanel1.Name = "DraggablePanel1"
        Me.DraggablePanel1.Size = New System.Drawing.Size(1220, 34)
        Me.DraggablePanel1.TabIndex = 1
        '
        'minimize
        '
        Me.minimize.BackColor = System.Drawing.Color.Transparent
        Me.minimize.FlatAppearance.BorderSize = 0
        Me.minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.minimize.Location = New System.Drawing.Point(1234, 3)
        Me.minimize.Name = "minimize"
        Me.minimize.Size = New System.Drawing.Size(22, 27)
        Me.minimize.TabIndex = 58
        Me.minimize.UseVisualStyleBackColor = False
        '
        'closeForm
        '
        Me.closeForm.BackColor = System.Drawing.Color.Transparent
        Me.closeForm.FlatAppearance.BorderSize = 0
        Me.closeForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.closeForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeForm.Location = New System.Drawing.Point(1254, 3)
        Me.closeForm.Name = "closeForm"
        Me.closeForm.Size = New System.Drawing.Size(22, 27)
        Me.closeForm.TabIndex = 57
        Me.closeForm.UseVisualStyleBackColor = False
        '
        'TheDevs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.VBNET_Car_Rental_System.My.Resources.Resources.The_Devs
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1280, 720)
        Me.Controls.Add(Me.minimize)
        Me.Controls.Add(Me.closeForm)
        Me.Controls.Add(Me.DraggablePanel1)
        Me.Controls.Add(Me.Button1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TheDevs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "TheDevs"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents DraggablePanel1 As DraggablePanel
    Friend WithEvents minimize As Button
    Friend WithEvents closeForm As Button
End Class
