Namespace Extensions
    ''' <summary>
    ''' Helper extensions for BindingSource component.
    ''' </summary>
    Public Module BindingSourceExtensions
        ''' <summary>
        ''' Return underlying DataTable
        ''' </summary>
        ''' <param name="sender">BindingSource with a DataTable as it's DataSource</param>
        ''' <returns>DataTable</returns>
        <Runtime.CompilerServices.Extension>
        Public Function DataTable(sender As BindingSource) As DataTable
            Return CType(sender.DataSource, DataTable)
        End Function
        ''' <summary>
        ''' Current current DataRow
        ''' </summary>
        ''' <param name="sender">BindingSource with a DataTable as it's DataSource</param>
        ''' <returns>DataRow</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function CurrentRow(sender As BindingSource) As DataRow
            Return CType(sender.Current, DataRowView).Row
        End Function
        ''' <summary>
        ''' Return current customer primary key
        ''' </summary>
        ''' <param name="sender">BindingSource using a DataTable representing customer table</param>
        ''' <returns>Primary key as integer</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function CurrentCustomerIdentifier(sender As BindingSource) As Integer
            Return sender.CurrentRow().Field(Of Integer)("Identifier")
        End Function
        ''' <summary>
        ''' Return current customer contact key
        ''' </summary>
        ''' <param name="sender">BindingSource using a DataTable representing customer table</param>
        ''' <returns>Primary key as integer</returns>
        <Runtime.CompilerServices.Extension()>
        Public Function CurrentContactIdentifier(sender As BindingSource) As Integer
            Return sender.CurrentRow().Field(Of Integer)("ContactTitleId")
        End Function
        ''' <summary>
        ''' Return DefaultView underlying the BindingSource DataTable
        ''' </summary>
        ''' <param name="sender">BindingSource with a DataTable as it's DataSource</param>
        ''' <returns></returns>
        <Runtime.CompilerServices.Extension>
        Public Function DataView(sender As BindingSource) As DataView
            Return CType(sender.DataSource, DataTable).DefaultView
        End Function
        ''' <summary>
        ''' Get current child row's parent row when DataSource is a DataTable.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="pRelationshipName">DataSet relationship</param>
        ''' <returns>Current DataRow</returns>
        <Runtime.CompilerServices.Extension>
        Public Function ParentRow(sender As BindingSource, pRelationshipName As String) As DataRow
            Return (CType(sender.Current, DataRowView))?.Row.GetParentRow(pRelationshipName)
        End Function
    End Module
End Namespace