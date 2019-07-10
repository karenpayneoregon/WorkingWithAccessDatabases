<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CompanyTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CountryTextBox = New System.Windows.Forms.TextBox()
        Me.CurrentIndexButton = New System.Windows.Forms.Button()
        Me.MoveLastButton = New System.Windows.Forms.Button()
        Me.MoveNextButton = New System.Windows.Forms.Button()
        Me.MovePriorButton = New System.Windows.Forms.Button()
        Me.MoveFirstButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company"
        '
        'CompanyTextBox
        '
        Me.CompanyTextBox.Location = New System.Drawing.Point(79, 42)
        Me.CompanyTextBox.Name = "CompanyTextBox"
        Me.CompanyTextBox.Size = New System.Drawing.Size(228, 20)
        Me.CompanyTextBox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Country"
        '
        'CountryTextBox
        '
        Me.CountryTextBox.Location = New System.Drawing.Point(79, 78)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(228, 20)
        Me.CountryTextBox.TabIndex = 3
        '
        'CurrentIndexButton
        '
        Me.CurrentIndexButton.Location = New System.Drawing.Point(203, 127)
        Me.CurrentIndexButton.Name = "CurrentIndexButton"
        Me.CurrentIndexButton.Size = New System.Drawing.Size(104, 23)
        Me.CurrentIndexButton.TabIndex = 8
        Me.CurrentIndexButton.Text = "Current Index"
        Me.CurrentIndexButton.UseVisualStyleBackColor = True
        '
        'MoveLastButton
        '
        Me.MoveLastButton.Image = Global.RowIndexExampleSpecial.My.Resources.Resources.Last1
        Me.MoveLastButton.Location = New System.Drawing.Point(172, 127)
        Me.MoveLastButton.Name = "MoveLastButton"
        Me.MoveLastButton.Size = New System.Drawing.Size(25, 23)
        Me.MoveLastButton.TabIndex = 7
        Me.MoveLastButton.UseVisualStyleBackColor = True
        '
        'MoveNextButton
        '
        Me.MoveNextButton.Image = Global.RowIndexExampleSpecial.My.Resources.Resources._Next
        Me.MoveNextButton.Location = New System.Drawing.Point(141, 127)
        Me.MoveNextButton.Name = "MoveNextButton"
        Me.MoveNextButton.Size = New System.Drawing.Size(25, 23)
        Me.MoveNextButton.TabIndex = 6
        Me.MoveNextButton.Text = ">"
        Me.MoveNextButton.UseVisualStyleBackColor = True
        '
        'MovePriorButton
        '
        Me.MovePriorButton.Image = Global.RowIndexExampleSpecial.My.Resources.Resources.p1
        Me.MovePriorButton.Location = New System.Drawing.Point(110, 127)
        Me.MovePriorButton.Name = "MovePriorButton"
        Me.MovePriorButton.Size = New System.Drawing.Size(25, 23)
        Me.MovePriorButton.TabIndex = 5
        Me.MovePriorButton.UseVisualStyleBackColor = True
        '
        'MoveFirstButton
        '
        Me.MoveFirstButton.Image = Global.RowIndexExampleSpecial.My.Resources.Resources.First
        Me.MoveFirstButton.Location = New System.Drawing.Point(79, 127)
        Me.MoveFirstButton.Name = "MoveFirstButton"
        Me.MoveFirstButton.Size = New System.Drawing.Size(25, 23)
        Me.MoveFirstButton.TabIndex = 4
        Me.MoveFirstButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 186)
        Me.Controls.Add(Me.CurrentIndexButton)
        Me.Controls.Add(Me.MoveLastButton)
        Me.Controls.Add(Me.MoveNextButton)
        Me.Controls.Add(Me.MovePriorButton)
        Me.Controls.Add(Me.MoveFirstButton)
        Me.Controls.Add(Me.CountryTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CompanyTextBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Get Row Index for DataRow"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents CompanyTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CountryTextBox As TextBox
    Friend WithEvents MoveFirstButton As Button
    Friend WithEvents MovePriorButton As Button
    Friend WithEvents MoveNextButton As Button
    Friend WithEvents MoveLastButton As Button
    Friend WithEvents CurrentIndexButton As Button
End Class
