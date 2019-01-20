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
    Public Function CurrentEmployeeTitleIdentifier(sender As BindingSource) As Integer
        Return sender.CurrentRow().Field(Of Integer)("EmployeeTitleIdentifier")
    End Function
End Module
