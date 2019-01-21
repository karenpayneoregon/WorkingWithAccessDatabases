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
End Module
