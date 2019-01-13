Imports BackEnd
''' <summary>
''' To generate records I used insertFileName and extractFileName to do the work.
''' Currently Button1 is still setup for a file already inserted so if used again
''' without changing anything it will be inserted again.
''' </summary>
Public Class Form1
    WithEvents bsData As New BindingSource

    Private insertFileName As String = IO.Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, "Document.docx")

    Private extractFileName As String = IO.Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory, "Extracted", "Document.docx")

    Private documentPrimaryKey As Integer = 0
    Private Sub insertFile_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim ops As New Operations
        'Dim NewIndentfier As Integer = 0

        'If ops.InsertFile(insertFileName, NewIndentfier, "Justed added") Then
        '    Button1.Enabled = False
        '    documentPrimaryKey = NewIndentfier
        '    MessageBox.Show($"Inserted document, new key is {NewIndentfier}")
        'Else
        '    If ops.HasException Then
        '        MessageBox.Show($"{ops.Exception.Message}")
        '    End If
        'End If
    End Sub

    Private Sub extractFile_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If documentPrimaryKey < 1 Then
            MessageBox.Show("Please add the document!!!")
            Exit Sub
        End If
        Dim ops As New Operations
        If ops.ExtractSingleFile(documentPrimaryKey, extractFileName) Then
            MessageBox.Show($"{extractFileName} is ready")
            Button2.Enabled = False
        Else
            If ops.HasException Then
                MessageBox.Show($"{ops.Exception.Message}")
            End If
        End If
    End Sub
    ''' <summary>
    ''' Read in data
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If IO.File.Exists(extractFileName) Then
        '    IO.File.Delete(extractFileName)
        'End If

        Dim ops As New Operations
        bsData.DataSource = ops.ReadAll
        DataGridView1.DataSource = bsData

        Button3.Enabled = bsData.Count > 0

    End Sub
    Private Sub getCurrentRowInfo_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If bsData.Current IsNot Nothing Then
            Dim currentRow As DataRow = CType(bsData.Current, DataRowView).Row
            MessageBox.Show($"Use this id to get data {currentRow.Field(Of Integer)("Identifier")} FileName: {currentRow.Field(Of String)("FileName")}")
        End If
    End Sub
End Class
