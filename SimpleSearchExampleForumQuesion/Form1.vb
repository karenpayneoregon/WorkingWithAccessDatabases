

Public Class Form1
    Private Sub FindButton_Click(sender As Object, e As EventArgs) Handles FindButton.Click
        If Not String.IsNullOrWhiteSpace(BarCodeTextBox.Text) Then
            Dim ops As New DataOperations
            Dim barCode = ops.ReadBarCodes(BarCodeTextBox.Text)
            If barCode.Id > 0 Then
                MessageBox.Show(barCode.ToString())
            End If
        End If
    End Sub
End Class