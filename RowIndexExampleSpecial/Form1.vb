Public Class Form1
    Private bs As New BindingSource
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim ops As New DatabaseOperations
        bs.DataSource = ops.LoadCustomers

        CompanyTextBox.DataBindings.Add("Text", bs, "CompanyName")
        CountryTextBox.DataBindings.Add("Text", bs, "Country")
    End Sub
    Private Sub MoveFirstButton_Click(sender As Object, e As EventArgs) Handles MoveFirstButton.Click
        bs.MoveFirst()
    End Sub
    Private Sub MovePriorButton_Click(sender As Object, e As EventArgs) Handles MovePriorButton.Click
        bs.MovePrevious()
    End Sub
    Private Sub MoveNextButton_Click(sender As Object, e As EventArgs) Handles MoveNextButton.Click
        bs.MoveNext()
    End Sub
    Private Sub MoveLastButton_Click(sender As Object, e As EventArgs) Handles MoveLastButton.Click
        bs.MoveLast()
    End Sub
    Private Function GetRowIndex() As Integer
        If bs.Current IsNot Nothing Then
            Dim row As DataRow = CType(bs.Current, DataRowView).Row
            Dim index As Integer = CType(bs.DataSource, DataTable).Rows.IndexOf(row)
            Return index
        Else
            Return -1
        End If
    End Function

    Private Sub CurrentIndexButton_Click(sender As Object, e As EventArgs) Handles CurrentIndexButton.Click
        MessageBox.Show($"Current DataRow Index is {GetRowIndex()}")
    End Sub
End Class
