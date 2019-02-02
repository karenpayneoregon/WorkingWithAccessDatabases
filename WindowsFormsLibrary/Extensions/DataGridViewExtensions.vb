Imports System.Windows.Forms

Namespace Extensions

    Public Module DataGridViewExtensions
        ''' <summary>
        ''' Copies a DataGridViewRow from one DataGridView to another DataGridView where both have matching DataGridViewColumns.
        ''' </summary>
        ''' <param name="copyFromDataGridViewRow">Row to copy</param>
        ''' <param name="targetDataGridView">Copy row to this DataGridView</param>
        ''' <param name="moveRow">True will remove copyFromDataGridViewRow, False simple copies.</param>
        <DebuggerStepThrough()>
        <Runtime.CompilerServices.Extension()>
        Public Sub CloneRowWithValues(copyFromDataGridViewRow As DataGridViewRow, targetDataGridView As DataGridView, moveRow As Boolean)

            Dim resultRow As DataGridViewRow = CType(copyFromDataGridViewRow.Clone(), DataGridViewRow)

            For row As Integer = 0 To copyFromDataGridViewRow.Cells.Count - 1
                resultRow.Cells(row).Value = copyFromDataGridViewRow.Cells(row).Value
            Next

            targetDataGridView.Rows.Add(resultRow)

            If moveRow Then
                copyFromDataGridViewRow.DataGridView.Rows.Remove(copyFromDataGridViewRow)
            End If

        End Sub
        ''' <summary>
        ''' Clones all visible columns of a DataGridView to another DataGridView. 
        ''' An exception is thrown if the column already exists.
        ''' </summary>
        ''' <param name="receivingDataGridView">DataGridView to receive clone columns</param>
        ''' <param name="cloneFrom">DataGridView to clone columns from</param>
        <Runtime.CompilerServices.Extension()>
        Public Sub CloneColumns(receivingDataGridView As DataGridView, cloneFrom As DataGridView)

            If receivingDataGridView.ColumnCount = 0 Then
                For Each c As DataGridViewColumn In cloneFrom.Columns
                    receivingDataGridView.Columns.Add(CType(c.Clone, DataGridViewColumn))
                Next
            End If
        End Sub

    End Module
End Namespace