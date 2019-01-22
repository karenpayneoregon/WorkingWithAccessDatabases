Public Class FilterForm
    Private nameList As List(Of String)

    Private Sub FilterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ops As New DatabaseOperations
        nameList = ops.LoadCompanyNames()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim result = nameList.FirstOrDefault(
            Function(item) item.IndexOf(TextBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0)

        If result IsNot Nothing Then
            Label1.Text = "Found"
        Else
            Label1.Text = ""
        End If
    End Sub
End Class
