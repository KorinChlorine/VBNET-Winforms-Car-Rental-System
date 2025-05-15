<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class History
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DraggablePanel1 = New VBNET_Car_Rental_System.DraggablePanel()
        Me.minimize = New System.Windows.Forms.Button()
        Me.closeForm = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Location = New System.Drawing.Point(12, 573)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(64, 47)
        Me.Button9.TabIndex = 11
        Me.Button9.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(439, 125)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(351, 217)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(121, 125)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(254, 518)
        Me.FlowLayoutPanel1.TabIndex = 13
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("League Spartan ExtraBold", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(439, 360)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(351, 250)
        Me.label1.TabIndex = 14
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("League Spartan ExtraBold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(869, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(353, 495)
        Me.Label2.TabIndex = 15
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(19, 590)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 51)
        Me.Button1.TabIndex = 11
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DraggablePanel1
        '
        Me.DraggablePanel1.BackColor = System.Drawing.Color.Transparent
        Me.DraggablePanel1.Location = New System.Drawing.Point(0, 0)
        Me.DraggablePanel1.Name = "DraggablePanel1"
        Me.DraggablePanel1.Size = New System.Drawing.Size(1203, 26)
        Me.DraggablePanel1.TabIndex = 54
        '
        'minimize
        '
        Me.minimize.BackColor = System.Drawing.Color.Transparent
        Me.minimize.FlatAppearance.BorderSize = 0
        Me.minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.minimize.Location = New System.Drawing.Point(1217, 3)
        Me.minimize.Name = "minimize"
        Me.minimize.Size = New System.Drawing.Size(22, 27)
        Me.minimize.TabIndex = 56
        Me.minimize.UseVisualStyleBackColor = False
        '
        'closeForm
        '
        Me.closeForm.BackColor = System.Drawing.Color.Transparent
        Me.closeForm.FlatAppearance.BorderSize = 0
        Me.closeForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.closeForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeForm.Location = New System.Drawing.Point(1237, 3)
        Me.closeForm.Name = "closeForm"
        Me.closeForm.Size = New System.Drawing.Size(22, 27)
        Me.closeForm.TabIndex = 55
        Me.closeForm.UseVisualStyleBackColor = False
        '
        'History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.VBNET_Car_Rental_System.My.Resources.Resources.Rental_HIstory1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.ControlBox = False
        Me.Controls.Add(Me.minimize)
        Me.Controls.Add(Me.closeForm)
        Me.Controls.Add(Me.DraggablePanel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button9)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "History"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "History"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button9 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents DraggablePanel1 As DraggablePanel
    Friend WithEvents minimize As Button
    Friend WithEvents closeForm As Button
End Class
