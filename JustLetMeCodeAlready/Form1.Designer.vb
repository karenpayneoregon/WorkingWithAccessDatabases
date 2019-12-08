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
        Me.StartDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.EndDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.TitleTextBox = New System.Windows.Forms.TextBox()
        Me.LoadButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.closeButton)
        Me.Panel1.Controls.Add(Me.employeeLastNameFindTextBox)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.firstNameFindBadTextBox)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 249)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 139)
        Me.Panel1.TabIndex = 0
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(713, 93)
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
        Me.DataGridView1.Size = New System.Drawing.Size(800, 249)
        Me.DataGridView1.TabIndex = 1
        '
        'StartDateTimePicker
        '
        Me.StartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.StartDateTimePicker.Location = New System.Drawing.Point(12, 37)
        Me.StartDateTimePicker.Name = "StartDateTimePicker"
        Me.StartDateTimePicker.Size = New System.Drawing.Size(136, 20)
        Me.StartDateTimePicker.TabIndex = 5
        Me.StartDateTimePicker.Value = New Date(1992, 4, 1, 0, 0, 0, 0)
        '
        'EndDateTimePicker
        '
        Me.EndDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.EndDateTimePicker.Location = New System.Drawing.Point(159, 37)
        Me.EndDateTimePicker.Name = "EndDateTimePicker"
        Me.EndDateTimePicker.Size = New System.Drawing.Size(136, 20)
        Me.EndDateTimePicker.TabIndex = 6
        Me.EndDateTimePicker.Value = New Date(1992, 8, 14, 0, 0, 0, 0)
        '
        'TitleTextBox
        '
        Me.TitleTextBox.Location = New System.Drawing.Point(301, 37)
        Me.TitleTextBox.Name = "TitleTextBox"
        Me.TitleTextBox.Size = New System.Drawing.Size(130, 20)
        Me.TitleTextBox.TabIndex = 7
        Me.TitleTextBox.Text = "Sales Representative"
        '
        'LoadButton
        '
        Me.LoadButton.Location = New System.Drawing.Point(437, 34)
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.Size = New System.Drawing.Size(75, 23)
        Me.LoadButton.TabIndex = 8
        Me.LoadButton.Text = "Load"
        Me.LoadButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LoadButton)
        Me.GroupBox1.Controls.Add(Me.TitleTextBox)
        Me.GroupBox1.Controls.Add(Me.EndDateTimePicker)
        Me.GroupBox1.Controls.Add(Me.StartDateTimePicker)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(530, 72)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "HireDate >="
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(156, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "HireDate <="
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(303, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Title ="
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 388)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Just let me code (but not cool to write data operations in the form)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents firstNameFindBadTextBox As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents employeeLastNameFindTextBox As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents closeButton As Button
    Friend WithEvents StartDateTimePicker As DateTimePicker
    Friend WithEvents EndDateTimePicker As DateTimePicker
    Friend WithEvents TitleTextBox As TextBox
    Friend WithEvents LoadButton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
