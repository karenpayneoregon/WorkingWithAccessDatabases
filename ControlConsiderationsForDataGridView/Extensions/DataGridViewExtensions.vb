Public Module DataGridViewExtensions
    <System.Runtime.CompilerServices.Extension>
    Public Sub ExpandColumns(sender As DataGridView)
        For Each column As DataGridViewColumn In sender.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
    <Runtime.CompilerServices.Extension>
    Public Function IsComboBoxCell(ByVal sender As DataGridViewCell) As Boolean
        Dim Result As Boolean = False
        If sender.EditType IsNot Nothing Then
            If sender.EditType Is GetType(DataGridViewComboBoxEditingControl) Then
                Result = True
            End If
        End If
        Return Result
    End Function
End Module