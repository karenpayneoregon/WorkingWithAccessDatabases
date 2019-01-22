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
        Me.userNameTextBox = New System.Windows.Forms.TextBox()
        Me.fullNameTextBox = New System.Windows.Forms.TextBox()
        Me.isBlackListedExecuteButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'userNameTextBox
        '
        Me.userNameTextBox.Location = New System.Drawing.Point(30, 25)
        Me.userNameTextBox.Name = "userNameTextBox"
        Me.userNameTextBox.Size = New System.Drawing.Size(181, 20)
        Me.userNameTextBox.TabIndex = 0
        Me.userNameTextBox.Text = "karenp"
        '
        'fullNameTextBox
        '
        Me.fullNameTextBox.Location = New System.Drawing.Point(30, 51)
        Me.fullNameTextBox.Name = "fullNameTextBox"
        Me.fullNameTextBox.Size = New System.Drawing.Size(181, 20)
        Me.fullNameTextBox.TabIndex = 1
        Me.fullNameTextBox.Text = "Karen Payne"
        '
        'isBlackListedExecuteButton
        '
        Me.isBlackListedExecuteButton.Location = New System.Drawing.Point(30, 77)
        Me.isBlackListedExecuteButton.Name = "isBlackListedExecuteButton"
        Me.isBlackListedExecuteButton.Size = New System.Drawing.Size(181, 23)
        Me.isBlackListedExecuteButton.TabIndex = 2
        Me.isBlackListedExecuteButton.Text = "Test"
        Me.isBlackListedExecuteButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(235, 148)
        Me.Controls.Add(Me.isBlackListedExecuteButton)
        Me.Controls.Add(Me.fullNameTextBox)
        Me.Controls.Add(Me.userNameTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simple search"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents userNameTextBox As TextBox
    Friend WithEvents fullNameTextBox As TextBox
    Friend WithEvents isBlackListedExecuteButton As Button
End Class
