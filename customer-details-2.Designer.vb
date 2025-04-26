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
        Me.btnConfChanges.Location = New System.Drawing.Point(65, 385)
        Me.btnConfChanges.Name = "btnConfChanges"
        Me.btnConfChanges.Size = New System.Drawing.Size(256, 23)
        Me.btnConfChanges.TabIndex = 0
        Me.btnConfChanges.Text = "Confirm Changes"
        Me.btnConfChanges.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(284, 26)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(56, 23)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'txtNewEmail
        '
        Me.txtNewEmail.Location = New System.Drawing.Point(103, 94)
        Me.txtNewEmail.Name = "txtNewEmail"
        Me.txtNewEmail.Size = New System.Drawing.Size(237, 20)
        Me.txtNewEmail.TabIndex = 2
        '
        'txtNewPass
        '
        Me.txtNewPass.Location = New System.Drawing.Point(103, 143)
        Me.txtNewPass.Name = "txtNewPass"
        Me.txtNewPass.Size = New System.Drawing.Size(237, 20)
        Me.txtNewPass.TabIndex = 3
        '
        'txtConfPass
        '
        Me.txtConfPass.Location = New System.Drawing.Point(103, 194)
        Me.txtConfPass.Name = "txtConfPass"
        Me.txtConfPass.Size = New System.Drawing.Size(237, 20)
        Me.txtConfPass.TabIndex = 4
        '
        'customer_details_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(371, 450)
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
