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
        Me.GetCurrentButton = New System.Windows.Forms.Button()
        Me.GetNextButton = New System.Windows.Forms.Button()
        Me.CurrentTextBox = New System.Windows.Forms.TextBox()
        Me.NextTextBox = New System.Windows.Forms.TextBox()
        Me.SetCurrentButton = New System.Windows.Forms.Button()
        Me.NewCurrentTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'GetCurrentButton
        '
        Me.GetCurrentButton.Location = New System.Drawing.Point(20, 18)
        Me.GetCurrentButton.Name = "GetCurrentButton"
        Me.GetCurrentButton.Size = New System.Drawing.Size(75, 23)
        Me.GetCurrentButton.TabIndex = 0
        Me.GetCurrentButton.Text = "Get current"
        Me.GetCurrentButton.UseVisualStyleBackColor = True
        '
        'GetNextButton
        '
        Me.GetNextButton.Location = New System.Drawing.Point(20, 58)
        Me.GetNextButton.Name = "GetNextButton"
        Me.GetNextButton.Size = New System.Drawing.Size(75, 23)
        Me.GetNextButton.TabIndex = 1
        Me.GetNextButton.Text = "Get next"
        Me.GetNextButton.UseVisualStyleBackColor = True
        '
        'CurrentTextBox
        '
        Me.CurrentTextBox.Location = New System.Drawing.Point(114, 21)
        Me.CurrentTextBox.Name = "CurrentTextBox"
        Me.CurrentTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CurrentTextBox.TabIndex = 2
        '
        'NextTextBox
        '
        Me.NextTextBox.Location = New System.Drawing.Point(114, 61)
        Me.NextTextBox.Name = "NextTextBox"
        Me.NextTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NextTextBox.TabIndex = 3
        '
        'SetCurrentButton
        '
        Me.SetCurrentButton.Location = New System.Drawing.Point(20, 96)
        Me.SetCurrentButton.Name = "SetCurrentButton"
        Me.SetCurrentButton.Size = New System.Drawing.Size(75, 23)
        Me.SetCurrentButton.TabIndex = 4
        Me.SetCurrentButton.Text = "Set current"
        Me.SetCurrentButton.UseVisualStyleBackColor = True
        '
        'NewCurrentTextBox
        '
        Me.NewCurrentTextBox.Location = New System.Drawing.Point(114, 98)
        Me.NewCurrentTextBox.Name = "NewCurrentTextBox"
        Me.NewCurrentTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NewCurrentTextBox.TabIndex = 5
        Me.NewCurrentTextBox.Text = "New record"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(246, 142)
        Me.Controls.Add(Me.NewCurrentTextBox)
        Me.Controls.Add(Me.SetCurrentButton)
        Me.Controls.Add(Me.NextTextBox)
        Me.Controls.Add(Me.CurrentTextBox)
        Me.Controls.Add(Me.GetNextButton)
        Me.Controls.Add(Me.GetCurrentButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GetCurrentButton As Button
    Friend WithEvents GetNextButton As Button
    Friend WithEvents CurrentTextBox As TextBox
    Friend WithEvents NextTextBox As TextBox
    Friend WithEvents SetCurrentButton As Button
    Friend WithEvents NewCurrentTextBox As TextBox
End Class
