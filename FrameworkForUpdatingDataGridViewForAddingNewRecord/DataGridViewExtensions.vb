Module DataGridViewExtensions

    <DebuggerStepThrough()>
    <Runtime.CompilerServices.Extension()>
    Public Sub CloneRowWithValues(
        copyFromRow As DataGridViewRow,
        targetDataGridView As DataGridView,
        moveRow As Boolean)

        Dim resultRow As DataGridViewRow = CType(copyFromRow.Clone(), DataGridViewRow)

        For row As Integer = 0 To copyFromRow.Cells.Count - 1
            resultRow.Cells(row).Value = copyFromRow.Cells(row).Value
        Next

        targetDataGridView.Rows.Add(resultRow)
        If moveRow Then
            copyFromRow.DataGridView.Rows.Remove(copyFromRow)
        End If


    End Sub
    <Runtime.CompilerServices.Extension()>
    Public Sub CloneColumns(self As DataGridView, cloneFrom As DataGridView)

        If self.ColumnCount = 0 Then
            For Each c As DataGridViewColumn In cloneFrom.Columns
                self.Columns.Add(CType(c.Clone, DataGridViewColumn))
            Next
        End If
    End Sub

End Module
