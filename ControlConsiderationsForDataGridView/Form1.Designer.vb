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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CompanyNameDataGridViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactNameDataGridViewColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactTitleDataGridViewColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 392)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(560, 58)
        Me.Panel1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CompanyNameDataGridViewColumn, Me.ContactNameDataGridViewColumn, Me.ContactTitleDataGridViewColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(560, 392)
        Me.DataGridView1.TabIndex = 1
        '
        'CompanyNameDataGridViewColumn
        '
        Me.CompanyNameDataGridViewColumn.DataPropertyName = "CompanyName"
        Me.CompanyNameDataGridViewColumn.HeaderText = "Company"
        Me.CompanyNameDataGridViewColumn.Name = "CompanyNameDataGridViewColumn"
        '
        'ContactNameDataGridViewColumn
        '
        Me.ContactNameDataGridViewColumn.DataPropertyName = "ContactName"
        Me.ContactNameDataGridViewColumn.HeaderText = "Contact"
        Me.ContactNameDataGridViewColumn.Name = "ContactNameDataGridViewColumn"
        '
        'ContactTitleDataGridViewColumn
        '
        Me.ContactTitleDataGridViewColumn.HeaderText = "Title"
        Me.ContactTitleDataGridViewColumn.Name = "ContactTitleDataGridViewColumn"
        Me.ContactTitleDataGridViewColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ContactTitleDataGridViewColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Working with suitable columns"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CompanyNameDataGridViewColumn As DataGridViewTextBoxColumn
    Friend WithEvents ContactNameDataGridViewColumn As DataGridViewTextBoxColumn
    Friend WithEvents ContactTitleDataGridViewColumn As DataGridViewComboBoxColumn
End Class
