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
        Me.cmdAddRecord = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdAddRecord
        '
        Me.cmdAddRecord.Location = New System.Drawing.Point(12, 12)
        Me.cmdAddRecord.Name = "cmdAddRecord"
        Me.cmdAddRecord.Size = New System.Drawing.Size(143, 23)
        Me.cmdAddRecord.TabIndex = 0
        Me.cmdAddRecord.Text = "Add new record"
        Me.cmdAddRecord.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 185)
        Me.Controls.Add(Me.cmdAddRecord)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OleDb Transation basic"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdAddRecord As Button
End Class
