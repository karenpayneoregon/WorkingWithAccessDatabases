Namespace ExtensionMethods
    Module ExtensionMethods
        <DebuggerHidden()>
        <Runtime.CompilerServices.Extension()>
        Public Sub ExpandColumns(sender As DataGridView)
            For Each column As DataGridViewColumn In sender.Columns
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        End Sub
    End Module
End Namespace