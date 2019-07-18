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
        Me.BarCodeTextBox = New System.Windows.Forms.TextBox()
        Me.FindButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BarCodeTextBox
        '
        Me.BarCodeTextBox.Location = New System.Drawing.Point(52, 24)
        Me.BarCodeTextBox.Name = "BarCodeTextBox"
        Me.BarCodeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.BarCodeTextBox.TabIndex = 0
        Me.BarCodeTextBox.Text = "2222"
        '
        'FindButton
        '
        Me.FindButton.Location = New System.Drawing.Point(158, 24)
        Me.FindButton.Name = "FindButton"
        Me.FindButton.Size = New System.Drawing.Size(75, 23)
        Me.FindButton.TabIndex = 1
        Me.FindButton.Text = "Find"
        Me.FindButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 105)
        Me.Controls.Add(Me.FindButton)
        Me.Controls.Add(Me.BarCodeTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarCodeTextBox As TextBox
    Friend WithEvents FindButton As Button
End Class
