<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class customer_details_2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(customer_details_2))
        Me.btnConfChanges = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.txtNewEmail = New System.Windows.Forms.TextBox()
        Me.txtNewPass = New System.Windows.Forms.TextBox()
        Me.txtConfPass = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnConfChanges
        '
        Me.btnConfChanges.BackColor = System.Drawing.Color.Transparent
        Me.btnConfChanges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnConfChanges.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnConfChanges.FlatAppearance.BorderSize = 0
        Me.btnConfChanges.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnConfChanges.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnConfChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfChanges.Location = New System.Drawing.Point(73, 514)
        Me.btnConfChanges.Name = "btnConfChanges"
        Me.btnConfChanges.Size = New System.Drawing.Size(346, 44)
        Me.btnConfChanges.TabIndex = 0
        Me.btnConfChanges.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.Transparent
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnBack.FlatAppearance.BorderSize = 0
        Me.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Location = New System.Drawing.Point(374, 34)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(84, 37)
        Me.btnBack.TabIndex = 1
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'txtNewEmail
        '
        Me.txtNewEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNewEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewEmail.Location = New System.Drawing.Point(140, 118)
        Me.txtNewEmail.Name = "txtNewEmail"
        Me.txtNewEmail.Size = New System.Drawing.Size(305, 33)
        Me.txtNewEmail.TabIndex = 2
        '
        'txtNewPass
        '
        Me.txtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNewPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!)
        Me.txtNewPass.Location = New System.Drawing.Point(140, 184)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.Size = New System.Drawing.Size(305, 33)
        Me.txtNewPass.TabIndex = 3
        '
        'txtConfPass
        '
        Me.txtConfPass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtConfPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!)
        Me.txtConfPass.Location = New System.Drawing.Point(140, 254)
        Me.txtConfPass.Name = "txtConfPass"
        Me.txtConfPass.Size = New System.Drawing.Size(305, 33)
        Me.txtConfPass.TabIndex = 4
        '
        'customer_details_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(491, 594)
        Me.Controls.Add(Me.txtConfPass)
        Me.Controls.Add(Me.txtNewPass)
        Me.Controls.Add(Me.txtNewEmail)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnConfChanges)
        Me.DoubleBuffered = True
        Me.Name = "customer_details_2"
        Me.Text = "customer-details-2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConfChanges As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents txtNewEmail As TextBox
    Friend WithEvents txtNewPass As TextBox
    Friend WithEvents txtConfPass As TextBox
End Class
