Imports System.Text.RegularExpressions
Public Class Form1
    Private bsCustomers As New BindingSource
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        '
        ' We are not concerned with CRUD
        '
        DataGridView1.AllowUserToAddRows = False

        '
        ' Get data from two tables into a single DataTable
        '
        Dim ops As New DatabaseOperations
        bsCustomers.DataSource = ops.LoadCustomers

        contactTitlesComboBox.DataSource = ops.LoadContactTitles

        '
        ' Remainder presents data to the user
        '
        BindingNavigator1.BindingSource = bsCustomers
        DataGridView1.DataSource = bsCustomers
        DataGridView1.ExpandColumns()

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.HeaderText = String.Join(" ", Regex.Matches(column.Name, "([A-Z][a-z]+)").Cast(Of Match)().Select(Function(m) m.Value))
        Next

    End Sub
    ''' <summary>
    ''' Get current contact title in ComboBox, filter DataGridView.
    ''' First contact title is "Select all"
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub contactTitleFilter_Click(sender As Object, e As EventArgs) Handles contactTitleFilter.Click
        Dim contactTitle As ContactTitle = CType(contactTitlesComboBox.SelectedItem, ContactTitle)
        If contactTitle.ContactTitleId = 0 Then
            bsCustomers.Filter = ""
        Else
            bsCustomers.Filter = $"Title = '{contactTitle.Title}' "
        End If
    End Sub

    Private Sub currentRowPrimaryKeys_Click(sender As Object, e As EventArgs) Handles currentRowPrimaryKeys.Click
        currentCustomerPrimaryKey.Text = bsCustomers.CurrentCustomerIdentifier.ToString()
        currentContactPrimaryKey.Text = bsCustomers.CurrentContactIdentifier().ToString()
    End Sub
End Class
