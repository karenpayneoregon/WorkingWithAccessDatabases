Public Class MainForm
    Property customerBindingSource() As New BindingSource
    ''' <summary>
    ''' Add multiple records. Pressing this button multiple times will only show
    ''' the current batch added for confirmation rather than loading all records
    ''' which the next button does, loads all records.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub addRecordButton_Click(sender As Object, e As EventArgs) Handles addRecordButton.Click
        Dim ops As New DataOperations
        Dim mockedList As New CustomerData
        Dim newCustomersInDatabase = mockedList.CustomerList()
        ops.AddNewCustomerRecords(newCustomersInDatabase)
        If ops.IsSuccessFul Then
            customerBindingSource.DataSource = newCustomersInDatabase
            DataGridView1.AutoGenerateColumns = False
            DataGridView1.DataSource = customerBindingSource
        End If
    End Sub
    ''' <summary>
    ''' Load all customer records added using the button click event above.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub readAllCustomerRecordsButton_Click(sender As Object, e As EventArgs) Handles readAllCustomerRecordsButton.Click
        Dim ops As New DataOperations
        Dim customersList = ops.ReadCustomerTable()
        If customersList.Count > 0 Then
            customerBindingSource.DataSource = customersList
        Else
            MessageBox.Show("Please add some records first before reading the Customer table")
        End If
    End Sub
End Class