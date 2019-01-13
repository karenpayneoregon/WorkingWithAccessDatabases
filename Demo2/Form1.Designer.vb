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
        Me.computerAssetListBox = New System.Windows.Forms.ListBox()
        Me.userListBox = New System.Windows.Forms.ListBox()
        Me.assetIdentifierLabel = New System.Windows.Forms.Label()
        Me.userIdentifierLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'computerAssetListBox
        '
        Me.computerAssetListBox.FormattingEnabled = True
        Me.computerAssetListBox.Location = New System.Drawing.Point(25, 12)
        Me.computerAssetListBox.Name = "computerAssetListBox"
        Me.computerAssetListBox.Size = New System.Drawing.Size(129, 121)
        Me.computerAssetListBox.TabIndex = 0
        '
        'userListBox
        '
        Me.userListBox.FormattingEnabled = True
        Me.userListBox.Location = New System.Drawing.Point(169, 12)
        Me.userListBox.Name = "userListBox"
        Me.userListBox.Size = New System.Drawing.Size(129, 121)
        Me.userListBox.TabIndex = 1
        '
        'assetIdentifierLabel
        '
        Me.assetIdentifierLabel.AutoSize = True
        Me.assetIdentifierLabel.Location = New System.Drawing.Point(22, 139)
        Me.assetIdentifierLabel.Name = "assetIdentifierLabel"
        Me.assetIdentifierLabel.Size = New System.Drawing.Size(39, 13)
        Me.assetIdentifierLabel.TabIndex = 2
        Me.assetIdentifierLabel.Text = "Label1"
        '
        'userIdentifierLabel
        '
        Me.userIdentifierLabel.AutoSize = True
        Me.userIdentifierLabel.Location = New System.Drawing.Point(173, 138)
        Me.userIdentifierLabel.Name = "userIdentifierLabel"
        Me.userIdentifierLabel.Size = New System.Drawing.Size(39, 13)
        Me.userIdentifierLabel.TabIndex = 3
        Me.userIdentifierLabel.Text = "Label1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 161)
        Me.Controls.Add(Me.userIdentifierLabel)
        Me.Controls.Add(Me.assetIdentifierLabel)
        Me.Controls.Add(Me.userListBox)
        Me.Controls.Add(Me.computerAssetListBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Karen's code sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents computerAssetListBox As ListBox
    Friend WithEvents userListBox As ListBox
    Friend WithEvents assetIdentifierLabel As Label
    Friend WithEvents userIdentifierLabel As Label
End Class
