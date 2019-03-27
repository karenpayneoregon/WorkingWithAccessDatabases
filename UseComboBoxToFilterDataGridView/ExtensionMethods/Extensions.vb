Imports System.Text.RegularExpressions
Namespace ExtensionMethods
    Public Module Extensions
        <Runtime.CompilerServices.Extension>
        Public Function SplitCamelCase(ByVal sender As String) As String
            Return Regex.Replace(Regex.Replace(sender, "(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), "(\p{Ll})(\P{Ll})", "$1 $2")
        End Function
        <Runtime.CompilerServices.Extension>
        Public Sub ExpandColumns(sender As DataGridView)
            For Each column As DataGridViewColumn In sender.Columns
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        End Sub
    End Module
End Namespace