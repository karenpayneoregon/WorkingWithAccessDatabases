Imports System.IO
Imports ForumQuestion.Classes
Imports ForumQuestion.ExtensionMethods

Public Class Form1
    Private bsData As New BindingSource
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim eops As New ExcelOperations
        Dim excelFileName As String =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PeopleData.xlsx")

        Dim dt = eops.Read(excelFileName, "People1$")

        If eops.IsSuccessful Then

            bsData.DataSource = dt
            DataGridView1.DataSource = bsData

            For Each column As DataGridViewColumn In DataGridView1.Columns
                column.HeaderText = column.HeaderText.SplitCamelCase
            Next

        End If

    End Sub

    Private Sub exportButton_Click(sender As Object, e As EventArgs) Handles exportButton.Click
        Dim ops As New DataOperations
        Dim dt = CType(bsData.DataSource, DataTable)

        ops.InsertRows(dt)

        If ops.IsSuccessful Then
            MessageBox.Show($"Inserted {ops.RowCount}")
        Else
            MessageBox.Show($"Failure '{ops.LastException.Message}'")
        End If
    End Sub
End Class
