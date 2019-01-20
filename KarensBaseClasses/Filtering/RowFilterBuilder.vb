Public Module RowFilterBuilder
    Public Function BuildMultiColumnFilter(filterExpression As String, columns As DataColumnCollection) As String
        Dim columnNames As New Specialized.StringCollection()

        For Each column As DataColumn In columns
            columnNames.Add(column.ColumnName)
        Next

        Return BuildMultiColumnFilter(filterExpression, columnNames)

    End Function
    Public Function BuildMultiColumnFilter(filterExpression As String, columns As Specialized.StringCollection) As String
        Dim columnNames(columns.Count - 1) As String
        columns.CopyTo(columnNames, 0)

        Return BuildMultiColumnFilter(filterExpression, columnNames)

    End Function
    ''' <summary>
    ''' Builds a string that can be used for DataViews as Row filter.
    ''' You might pass 2 arguments: a string that represents the expression for the filter, separated by blanks
    ''' and an array of column names
    ''' </summary>
    ''' <param name="filterExpression"></param>
    ''' An Expression that might be used for filter. for Example: "Karen Payne"
    ''' <param name="columns"></param>
    ''' An String Array with the Name of Columns
    ''' for Example "FirstName, MiddleName"
    ''' <returns></returns>
    Public Function BuildMultiColumnFilter(filterExpression As String, columns() As String) As String
        filterExpression = filterExpression.Replace("'", "''")

        Dim result = ""
        Dim filters() As String = filterExpression.Split(" ".ToCharArray())


        For index As Integer = 0 To filters.Length - 1
            If index <> 0 Then
                result &= " AND "
            End If

            result &= "("

            Dim filter As String = filters(index)

            For colIndex As Integer = 0 To columns.Length - 1
                Dim column As String = columns(colIndex)

                'we need an prefix "OR" for every operator excluding the first token
                If colIndex <> 0 Then
                    result &= " OR "
                End If

                result &= " (CONVERT( [" & column & "], 'System.String') like '%" & filter & "%' )"
            Next

            result &= ")"

        Next

        Return result

    End Function
End Module
