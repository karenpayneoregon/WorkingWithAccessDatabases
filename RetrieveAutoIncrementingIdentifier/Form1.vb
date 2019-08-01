Public Class Form1
    Private operations As New Operations
    Private Sub GetCurrentButton_Click(sender As Object, e As EventArgs) _
        Handles GetCurrentButton.Click

        CurrentTextBox.Text = operations.CurrentIdentifier().ToString()

    End Sub

    Private Sub GetNextButton_Click(sender As Object, e As EventArgs) _
        Handles GetNextButton.Click

        NextTextBox.Text = operations.NextIdentifier().ToString()

    End Sub
End Class
