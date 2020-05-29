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
        Me.categoryComboBox = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.selectProductCategoryButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SearchForTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'categoryComboBox
        '
        Me.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.categoryComboBox.FormattingEnabled = True
        Me.categoryComboBox.Location = New System.Drawing.Point(12, 18)
        Me.categoryComboBox.Name = "categoryComboBox"
        Me.categoryComboBox.Size = New System.Drawing.Size(176, 21)
        Me.categoryComboBox.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.selectProductCategoryButton)
        Me.Panel1.Controls.Add(Me.categoryComboBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 346)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(495, 104)
        Me.Panel1.TabIndex = 1
        '
        'selectProductCategoryButton
        '
        Me.selectProductCategoryButton.Location = New System.Drawing.Point(194, 18)
        Me.selectProductCategoryButton.Name = "selectProductCategoryButton"
        Me.selectProductCategoryButton.Size = New System.Drawing.Size(139, 23)
        Me.selectProductCategoryButton.TabIndex = 1
        Me.selectProductCategoryButton.Text = "Select product category"
        Me.selectProductCategoryButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(495, 346)
        Me.DataGridView1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(121, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(116, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Find Single record"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SearchForTextBox
        '
        Me.SearchForTextBox.Location = New System.Drawing.Point(15, 13)
        Me.SearchForTextBox.Name = "SearchForTextBox"
        Me.SearchForTextBox.Size = New System.Drawing.Size(100, 20)
        Me.SearchForTextBox.TabIndex = 3
        Me.SearchForTextBox.Text = "Guaraná Fantástica"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SearchForTextBox)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 45)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Code sample"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents categoryComboBox As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents selectProductCategoryButton As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents SearchForTextBox As TextBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
