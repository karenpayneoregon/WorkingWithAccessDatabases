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
        Me.CategoryListBox = New System.Windows.Forms.ListBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ProductIdTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CategoryListBox
        '
        Me.CategoryListBox.FormattingEnabled = True
        Me.CategoryListBox.Location = New System.Drawing.Point(15, 15)
        Me.CategoryListBox.Name = "CategoryListBox"
        Me.CategoryListBox.Size = New System.Drawing.Size(213, 199)
        Me.CategoryListBox.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(244, 17)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(287, 196)
        Me.DataGridView1.TabIndex = 1
        '
        'ProductIdTextBox
        '
        Me.ProductIdTextBox.BackColor = System.Drawing.Color.White
        Me.ProductIdTextBox.Location = New System.Drawing.Point(315, 225)
        Me.ProductIdTextBox.Name = "ProductIdTextBox"
        Me.ProductIdTextBox.ReadOnly = True
        Me.ProductIdTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ProductIdTextBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(254, 228)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Product id"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 257)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProductIdTextBox)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.CategoryListBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simple data binding"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CategoryListBox As ListBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ProductIdTextBox As TextBox
    Friend WithEvents Label1 As Label
End Class
