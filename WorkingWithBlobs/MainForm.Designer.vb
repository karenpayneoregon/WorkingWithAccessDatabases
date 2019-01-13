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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PanelDockBottom1 = New WorkingWithBinaryData.PanelDockBottom()
        Me.openExtractFolder = New System.Windows.Forms.Button()
        Me.extractCurrentButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.selectFileButton = New System.Windows.Forms.Button()
        Me.CueTextBox1 = New WorkingWithBinaryData.CueTextBox()
        Me.addSingleFileButton = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDockBottom1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(523, 230)
        Me.DataGridView1.TabIndex = 1
        '
        'PanelDockBottom1
        '
        Me.PanelDockBottom1.Controls.Add(Me.openExtractFolder)
        Me.PanelDockBottom1.Controls.Add(Me.extractCurrentButton)
        Me.PanelDockBottom1.Controls.Add(Me.GroupBox1)
        Me.PanelDockBottom1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelDockBottom1.Location = New System.Drawing.Point(0, 230)
        Me.PanelDockBottom1.Name = "PanelDockBottom1"
        Me.PanelDockBottom1.Size = New System.Drawing.Size(523, 138)
        Me.PanelDockBottom1.TabIndex = 0
        '
        'openExtractFolder
        '
        Me.openExtractFolder.Location = New System.Drawing.Point(143, 103)
        Me.openExtractFolder.Name = "openExtractFolder"
        Me.openExtractFolder.Size = New System.Drawing.Size(95, 23)
        Me.openExtractFolder.TabIndex = 6
        Me.openExtractFolder.Text = "Extract folder"
        Me.openExtractFolder.UseVisualStyleBackColor = True
        '
        'extractCurrentButton
        '
        Me.extractCurrentButton.Location = New System.Drawing.Point(37, 103)
        Me.extractCurrentButton.Name = "extractCurrentButton"
        Me.extractCurrentButton.Size = New System.Drawing.Size(95, 23)
        Me.extractCurrentButton.TabIndex = 5
        Me.extractCurrentButton.Text = "Extract current"
        Me.extractCurrentButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblFileName)
        Me.GroupBox1.Controls.Add(Me.selectFileButton)
        Me.GroupBox1.Controls.Add(Me.CueTextBox1)
        Me.GroupBox1.Controls.Add(Me.addSingleFileButton)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 83)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Insert record"
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(128, 54)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(52, 13)
        Me.lblFileName.TabIndex = 3
        Me.lblFileName.Text = "File name"
        '
        'selectFileButton
        '
        Me.selectFileButton.Location = New System.Drawing.Point(25, 24)
        Me.selectFileButton.Name = "selectFileButton"
        Me.selectFileButton.Size = New System.Drawing.Size(75, 23)
        Me.selectFileButton.TabIndex = 2
        Me.selectFileButton.Text = "Select file"
        Me.selectFileButton.UseVisualStyleBackColor = True
        '
        'CueTextBox1
        '
        Me.CueTextBox1.Cue = "Enter comment here"
        Me.CueTextBox1.Location = New System.Drawing.Point(124, 26)
        Me.CueTextBox1.Name = "CueTextBox1"
        Me.CueTextBox1.Size = New System.Drawing.Size(192, 20)
        Me.CueTextBox1.TabIndex = 1
        Me.CueTextBox1.WaterMarkOption = WorkingWithBinaryData.WaterMark.Hide
        '
        'addSingleFileButton
        '
        Me.addSingleFileButton.Location = New System.Drawing.Point(338, 24)
        Me.addSingleFileButton.Name = "addSingleFileButton"
        Me.addSingleFileButton.Size = New System.Drawing.Size(75, 23)
        Me.addSingleFileButton.TabIndex = 0
        Me.addSingleFileButton.Text = "Add file"
        Me.addSingleFileButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 368)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.PanelDockBottom1)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainForm"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDockBottom1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelDockBottom1 As PanelDockBottom
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents addSingleFileButton As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents CueTextBox1 As CueTextBox
    Friend WithEvents lblFileName As Label
    Friend WithEvents selectFileButton As Button
    Friend WithEvents extractCurrentButton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents openExtractFolder As Button
End Class
