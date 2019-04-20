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
        Me.getDateButton = New System.Windows.Forms.Button()
        Me.dateValueTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'getDateButton
        '
        Me.getDateButton.Location = New System.Drawing.Point(95, 77)
        Me.getDateButton.Name = "getDateButton"
        Me.getDateButton.Size = New System.Drawing.Size(121, 23)
        Me.getDateButton.TabIndex = 0
        Me.getDateButton.Text = "Get Date"
        Me.getDateButton.UseVisualStyleBackColor = True
        '
        'dateValueTextBox
        '
        Me.dateValueTextBox.Location = New System.Drawing.Point(95, 116)
        Me.dateValueTextBox.Name = "dateValueTextBox"
        Me.dateValueTextBox.Size = New System.Drawing.Size(121, 20)
        Me.dateValueTextBox.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 176)
        Me.Controls.Add(Me.dateValueTextBox)
        Me.Controls.Add(Me.getDateButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents getDateButton As Button
    Friend WithEvents dateValueTextBox As TextBox
End Class
