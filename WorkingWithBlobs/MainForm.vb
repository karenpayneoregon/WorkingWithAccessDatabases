Imports System.IO
Imports BackendBlobs

Public Class MainForm
    Private bsData As New BindingSource
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim insertFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InsertFiles")
        Dim success As Boolean = True
        Dim ops As New DataOperations

        If ops.RowCount = 0 Then
            Dim insertedCount As Integer = 0
            success = ops.InsertFilesBatch(Directory.GetFiles(insertFilePath).Select(Function(file) file), insertedCount)
        End If

        If success Then
            Dim dt As DataTable = ops.ReadAll
            bsData.DataSource = dt
            DataGridView1.DataSource = bsData

            AddHandler dt.RowChanging, AddressOf RowChanged

            '
            ' Pick one or the other
            '
            OpenFileDialog1.InitialDirectory = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents")
            OpenFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory

        End If

    End Sub
    ''' <summary>
    ''' In place editing of string fields, update record
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RowChanged(sender As Object, e As DataRowChangeEventArgs)

        If e.Action = DataRowAction.Change Then
            Dim ops As New DataOperations
            If Not ops.UpdateRecord(e.Row) Then
                If ops.HasException Then
                    MessageBox.Show($"Failed to update{Environment.NewLine}{ops.LastExceptionMessage}")
                Else
                    MessageBox.Show($"Failed to update record with primary key {e.Row.Field(Of Integer)("Identifier")}")
                End If

            End If
        End If

    End Sub
    ''' <summary>
    ''' Intervene on removal of current row, ask if they are sure? 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        If My.Dialogs.RemoveCurrentRecord Then
            Dim ops As New DataOperations
            If Not ops.RemoveRecord(CType(bsData.Current, DataRowView).Row.Field(Of Integer)("Identifier")) Then
                MessageBox.Show("Failed to remove row.")
            End If
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub selectFileButton_Click(sender As Object, e As EventArgs) Handles selectFileButton.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            lblFileName.Text = OpenFileDialog1.FileName
        End If
    End Sub
    ''' <summary>
    ''' Add a file to the database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub addSingleFileButton_Click(sender As Object, e As EventArgs) Handles addSingleFileButton.Click

        If lblFileName.Text.Contains(".") Then
            Dim infoReader As FileInfo
            infoReader = My.Computer.FileSystem.GetFileInfo(lblFileName.Text)

            If infoReader.Length < 8000000 Then
                Dim ops As New DataOperations

                Dim identifier As Integer = Await ops.InsertFile(lblFileName.Text, CueTextBox1.Text)

                If identifier > 0 Then
                    CType(bsData.DataSource, DataTable).Rows.Add(New Object() {identifier, lblFileName.Text, CueTextBox1.Text})
                    lblFileName.Text = "Inserted"
                Else
                    MessageBox.Show("Failed adding file.")
                End If
            Else
                MessageBox.Show("File to large")
            End If

        End If
    End Sub
    ''' <summary>
    ''' Extract current file to a folder one level below the application folder
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub extractCurrentButton_Click(sender As Object, e As EventArgs) Handles extractCurrentButton.Click
        Dim ops As New DataOperations

        Dim row As DataRow = CType(bsData.Current, DataRowView).Row
        Dim fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Extracted", row.Field(Of String)("FileName"))
        Dim primaryKey As Integer = row.Field(Of Integer)("Identifier")

        If ops.ExtractSingleFile(primaryKey, fileName) Then
            MessageBox.Show("Extracted")
        Else
            If ops.HasException Then
                MessageBox.Show($"Failed with '{ops.LastExceptionMessage}'")
            End If
        End If
    End Sub
    ''' <summary>
    ''' Open extract folder via Windows Explorer.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub openExtractFolder_Click(sender As Object, e As EventArgs) Handles openExtractFolder.Click
        Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Extracted"))
    End Sub
End Class
