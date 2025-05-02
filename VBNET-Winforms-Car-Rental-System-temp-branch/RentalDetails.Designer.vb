<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RentalDetail
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
        Me.Button9 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Location = New System.Drawing.Point(12, 567)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 47)
        Me.Button9.TabIndex = 12
        Me.Button9.UseVisualStyleBackColor = False
        '
        'RentalDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.VBNET_Car_Rental_System.My.Resources.Resources.Rental_Details
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1292, 661)
        Me.Controls.Add(Me.Button9)
        Me.DoubleBuffered = True
        Me.Name = "RentalDetail"
        Me.Text = "RentalDetails"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button9 As Button
End Class
