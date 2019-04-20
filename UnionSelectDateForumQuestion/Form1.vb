Public Class Form1
    Private Sub getDateButton_Click(sender As Object, e As EventArgs) _
        Handles getDateButton.Click

        Dim ops As New DatabaseOperations

        dateValueTextBox.Text = ops.GetDate().ToShortDateString()

    End Sub
End Class
