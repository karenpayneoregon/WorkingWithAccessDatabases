Imports DataGridViewAutoFilter

Public Class Form1
    Private bsCustomers As New BindingSource
    ''' <summary>
    ''' Load BindingSource from MS-Access via a DataTable,
    ''' set BindingSource as the DataSource for DataGridView`
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim ops As New DatabaseOperations

        If ops.IsSuccessFul Then
            bsCustomers.DataSource = ops.LoadCustomers
            DataGridView1.DataSource = bsCustomers
        Else
            MessageBox.Show(ops.LastExceptionMessage)
        End If

    End Sub
    ''' <summary>
    ''' Get current row customer id (hidden) and company name
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub currentCompanyIdentifier_Click(sender As Object, e As EventArgs) Handles currentCompanyIdentifier.Click
        Dim currentRow = CType(bsCustomers.Current, DataRowView).Row
        Dim currentCustomerIdentifier = currentRow.Field(Of Integer)("Identifier")
        Dim currentCustomerName = currentRow.Field(Of String)("CompanyName")

        MessageBox.Show($"{currentCustomerIdentifier}: {currentCustomerName}")
    End Sub
    ''' <summary>
    ''' Remove all column filters
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub removeAlFiltersButton_Click(sender As Object, e As EventArgs) Handles removeAlFiltersButton.Click
        DataGridViewAutoFilterColumnHeaderCell.RemoveFilter(DataGridView1)
    End Sub
    ''' <summary>
    ''' Show status of filter or if no filter hide the filter label.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_DataBindingComplete(
        sender As Object,
        e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete

        Dim filterStatus As String = DataGridViewAutoFilterColumnHeaderCell.
                GetFilterStatus(DataGridView1)

        If String.IsNullOrWhiteSpace(filterStatus) Then
            filterStatusLabel.Visible = False
        Else
            filterStatusLabel.Visible = True
            filterStatusLabel.Text = filterStatus
        End If
    End Sub
End Class
