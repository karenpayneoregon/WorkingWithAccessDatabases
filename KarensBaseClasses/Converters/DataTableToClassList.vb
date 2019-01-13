Imports System.Reflection

Public Module DataTableToClassList

    ''' <summary>
    ''' Convert DataTable to a List of a concrete class list.
    ''' </summary>
    ''' <typeparam name="T">Class type</typeparam>
    ''' <param name="dt">Populated DataTable with field names matching property names in T</param>
    ''' <returns>List(Of T)</returns>
    Public Function ConvertDataTable(Of T)(dt As DataTable) As List(Of T)
        Dim data As New List(Of T)()
        For Each row As DataRow In dt.Rows
            Dim item As T = GetItem(Of T)(row)
            data.Add(item)
        Next
        Return data
    End Function
    ''' <summary>
    ''' Get data for a DataRow. Column names in the DataRow must match those
    ''' in the class property names.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="dr"></param>
    ''' <returns></returns>
    Private Function GetItem(Of T)(ByVal dr As DataRow) As T
        Dim temp As Type = GetType(T)
        Dim obj As T = Activator.CreateInstance(Of T)()

        For Each column As DataColumn In dr.Table.Columns
            For Each pro As PropertyInfo In temp.GetProperties()
                If pro.Name = column.ColumnName Then
                    pro.SetValue(obj, dr(column.ColumnName), Nothing)
                Else
                    '
                    ' No match for property name against a DataColumn name.
                    '
                    Continue For
                End If
            Next
        Next
        Return obj
    End Function

End Module
