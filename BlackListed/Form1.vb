''' <summary>
''' In this example Database1.accdb resides in the bin\debug folder
''' </summary>
Public Class Form1
    ''' <summary>
    ''' Press button check (see leave check below)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub isBlackListedExecuteButton_Click(sender As Object, e As EventArgs) _
        Handles isBlackListedExecuteButton.Click

        IsBlackListCheck()

    End Sub
    ''' <summary>
    ''' On leave one of these TextBox controls check for black list
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub fullNameTextBox_Leave(sender As Object, e As EventArgs) _
        Handles fullNameTextBox.Leave, userNameTextBox.Leave

        IsBlackListCheck()

    End Sub
    Private Sub IsBlackListCheck()
        Dim ops = New DataOperations
        If ops.IsBlackListed(userNameTextBox.Text, fullNameTextBox.Text) Then
            MessageBox.Show("Black listed")
        End If
    End Sub
End Class
