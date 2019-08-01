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

    Private Sub SetCurrentButton_Click(sender As Object, e As EventArgs) Handles SetCurrentButton.Click
        Dim newIdentifier = operations.Increment(NewCurrentTextBox.Text)
        If newIdentifier > 0 Then
            CurrentTextBox.Text = newIdentifier.ToString()
        End If
    End Sub
End Class
