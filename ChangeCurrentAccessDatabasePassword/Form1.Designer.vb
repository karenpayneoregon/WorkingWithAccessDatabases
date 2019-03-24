<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.changePasswordButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'changePasswordButton
        '
        Me.changePasswordButton.Location = New System.Drawing.Point(26, 18)
        Me.changePasswordButton.Name = "changePasswordButton"
        Me.changePasswordButton.Size = New System.Drawing.Size(75, 23)
        Me.changePasswordButton.TabIndex = 0
        Me.changePasswordButton.Text = "Change"
        Me.changePasswordButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 185)
        Me.Controls.Add(Me.changePasswordButton)
        Me.Name = "Form1"
        Me.Text = "Change database password"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents changePasswordButton As Button
End Class
