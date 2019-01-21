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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.closeButton = New System.Windows.Forms.Button()
        Me.employeeLastNameFindTextBox = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.firstNameFindBadTextBox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.closeButton)
        Me.Panel1.Controls.Add(Me.employeeLastNameFindTextBox)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.firstNameFindBadTextBox)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 264)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 53)
        Me.Panel1.TabIndex = 0
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(713, 12)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 4
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'employeeLastNameFindTextBox
        '
        Me.employeeLastNameFindTextBox.Location = New System.Drawing.Point(477, 18)
        Me.employeeLastNameFindTextBox.Name = "employeeLastNameFindTextBox"
        Me.employeeLastNameFindTextBox.Size = New System.Drawing.Size(100, 20)
        Me.employeeLastNameFindTextBox.TabIndex = 3
        Me.employeeLastNameFindTextBox.Text = "O'Brian"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(330, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(141, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Find by last name (right)"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'firstNameFindBadTextBox
        '
        Me.firstNameFindBadTextBox.Location = New System.Drawing.Point(171, 15)
        Me.firstNameFindBadTextBox.Name = "firstNameFindBadTextBox"
        Me.firstNameFindBadTextBox.Size = New System.Drawing.Size(100, 20)
        Me.firstNameFindBadTextBox.TabIndex = 1
        Me.firstNameFindBadTextBox.Text = "O'Brian"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(141, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Find by last name (bad)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(800, 264)
        Me.DataGridView1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 317)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents firstNameFindBadTextBox As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents employeeLastNameFindTextBox As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents closeButton As Button
End Class
