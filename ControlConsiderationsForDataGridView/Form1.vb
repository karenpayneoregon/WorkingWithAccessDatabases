Imports ControlConsiderationsForDataGridView.Classes
Imports ControlConsiderationsForDataGridView.Extensions

Public Class Form1
    Private bsCustomers As New BindingSource
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim ops As New DatabaseOperations

        '
        ' Load partial columns from Customers table
        '
        bsCustomers.DataSource = ops.LoadCustomers


        '
        ' Setup DataGridViewComboBox column for displaying contact title using the
        ' key ContactTitleId
        '
        ContactTitleDataGridViewColumn.DisplayMember = "Title"
        ContactTitleDataGridViewColumn.ValueMember = "ContactTitleId"
        ContactTitleDataGridViewColumn.DataPropertyName = "ContactTitleId"
        ContactTitleDataGridViewColumn.DataSource = ops.LoadContactTitles
        ContactTitleDataGridViewColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing

        '
        ' Setup DataGridView
        '
        DataGridView1.AutoGenerateColumns = False
        DataGridView1.DataSource = bsCustomers
        DataGridView1.ExpandColumns()

    End Sub
    ''' <summary>
    ''' This event is triggered when a cell content changes in relation to it's contents.
    ''' Note the remove/add handler, this prevents reentry which can cause a stack overflow.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If TypeOf DataGridView1.CurrentCell Is DataGridViewCheckBoxCell Then

            RemoveHandler DataGridView1.CurrentCellDirtyStateChanged, AddressOf DataGridView1_CurrentCellDirtyStateChanged
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            AddHandler DataGridView1.CurrentCellDirtyStateChanged, AddressOf DataGridView1_CurrentCellDirtyStateChanged

        End If
    End Sub
    ''' <summary>
    ''' Provides access to the current item in the currently in-edit mode contact title.
    ''' * If the column name changes for the contact title then as coded this will fail. 
    '''   Another option is to simply test for a ComboBox but what if there are several of them?
    '''   Our first assertion is to see if the current cell is a DataGridViewComboBoxCell yet that is only
    '''   part of the assertion. If there are more than one then the logic becomes more complex as in
    '''   a need to check for more than one column.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If DataGridView1.CurrentCell.IsComboBoxCell() Then
            If DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name = "ContactTitleDataGridViewColumn" Then

                Dim comboBox = CType(e.Control, ComboBox)

                RemoveHandler comboBox.SelectionChangeCommitted, AddressOf _SelectionChangeCommittedForColorColumn
                AddHandler comboBox.SelectionChangeCommitted, AddressOf _SelectionChangeCommittedForColorColumn

            End If
        End If
    End Sub
    ''' <summary>
    ''' In this event both customer and contact title keys are exposed. With this
    ''' if a update is desired to the database table or validation is needed the keys
    ''' provide this knowledge.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub _SelectionChangeCommittedForColorColumn(sender As Object, e As EventArgs)
        Dim customerIdentifier = bsCustomers.CurrentCustomerIdentifier
        Dim contactTitleIdentifier = CType(CType(sender, DataGridViewComboBoxEditingControl).SelectedItem, DataRowView).Row.Field(Of Integer)("ContactTitleId")
        Console.WriteLine($"{customerIdentifier} -- {contactTitleIdentifier}")
    End Sub
End Class
