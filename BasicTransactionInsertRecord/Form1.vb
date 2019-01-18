Public Class Form1
    ''' <summary>
    ''' In this example the field Company name does not allow duplicate values. This means
    ''' the first record will be inserted and a new key returned while the second record 
    ''' will fail to insert and no record will be added.
    ''' 
    ''' A more real life example would be to add a new customer record, get the new key then
    ''' insert an order into the order table where the order fails the customer record would
    ''' be rolled back. 
    ''' 
    ''' This example has been kept simple to learn how a transaction is created and used.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdAddRecord_Click(sender As Object, e As EventArgs) Handles cmdAddRecord.Click

        Dim ops = New DataOperations
        Dim newPrimaryKey As Integer = 0

        ops.AddNewRow("ABC", "Karen", 2019, Now, newPrimaryKey)
        If ops.IsSuccessFul Then
            MessageBox.Show($"New id is {newPrimaryKey}")
        Else
            MessageBox.Show("Failed")
        End If

        ops.AddNewRow("ABC", "Karen", 2019, Now, newPrimaryKey)
        If ops.IsSuccessFul Then
            MessageBox.Show($"New id is {newPrimaryKey}")
        Else
            '
            ' In this case both messages are the same but that will not always be true.
            '
            If ops.HasOleDbException Then
                MessageBox.Show($"Failed{Environment.NewLine}{ops.OleDbException.Message}")
            Else
                MessageBox.Show($"Failed{Environment.NewLine}{ops.LastExceptionMessage}")
            End If

        End If
    End Sub
End Class
