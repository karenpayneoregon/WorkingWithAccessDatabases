<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.addRecordButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.readAllCustomerRecordsButton = New System.Windows.Forms.Button()
        Me.idColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CompanyNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContactNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstablishedYearColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IncorporatedColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'addRecordButton
        '
        Me.addRecordButton.Location = New System.Drawing.Point(26, 16)
        Me.addRecordButton.Name = "addRecordButton"
        Me.addRecordButton.Size = New System.Drawing.Size(75, 23)
        Me.addRecordButton.TabIndex = 0
        Me.addRecordButton.Text = "Add list"
        Me.addRecordButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idColumn, Me.CompanyNameColumn, Me.ContactNameColumn, Me.EstablishedYearColumn, Me.IncorporatedColumn})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(670, 397)
        Me.DataGridView1.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.readAllCustomerRecordsButton)
        Me.Panel1.Controls.Add(Me.addRecordButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 397)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(670, 53)
        Me.Panel1.TabIndex = 2
        '
        'readAllCustomerRecordsButton
        '
        Me.readAllCustomerRecordsButton.Location = New System.Drawing.Point(107, 16)
        Me.readAllCustomerRecordsButton.Name = "readAllCustomerRecordsButton"
        Me.readAllCustomerRecordsButton.Size = New System.Drawing.Size(75, 23)
        Me.readAllCustomerRecordsButton.TabIndex = 1
        Me.readAllCustomerRecordsButton.Text = "Read all"
        Me.readAllCustomerRecordsButton.UseVisualStyleBackColor = True
        '
        'idColumn
        '
        Me.idColumn.DataPropertyName = "id"
        Me.idColumn.HeaderText = "Id"
        Me.idColumn.Name = "idColumn"
        '
        'CompanyNameColumn
        '
        Me.CompanyNameColumn.DataPropertyName = "CompanyName"
        Me.CompanyNameColumn.HeaderText = "Company"
        Me.CompanyNameColumn.Name = "CompanyNameColumn"
        '
        'ContactNameColumn
        '
        Me.ContactNameColumn.DataPropertyName = "ContactName"
        Me.ContactNameColumn.HeaderText = "Contact"
        Me.ContactNameColumn.Name = "ContactNameColumn"
        '
        'EstablishedYearColumn
        '
        Me.EstablishedYearColumn.DataPropertyName = "EstablishedYear"
        Me.EstablishedYearColumn.HeaderText = "Established"
        Me.EstablishedYearColumn.Name = "EstablishedYearColumn"
        '
        'IncorporatedColumn
        '
        Me.IncorporatedColumn.DataPropertyName = "Incorporated"
        Me.IncorporatedColumn.HeaderText = "Incorporated"
        Me.IncorporatedColumn.Name = "IncorporatedColumn"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add multiple customer records example"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents addRecordButton As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents readAllCustomerRecordsButton As Button
    Friend WithEvents idColumn As DataGridViewTextBoxColumn
    Friend WithEvents CompanyNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents ContactNameColumn As DataGridViewTextBoxColumn
    Friend WithEvents EstablishedYearColumn As DataGridViewTextBoxColumn
    Friend WithEvents IncorporatedColumn As DataGridViewTextBoxColumn
End Class
