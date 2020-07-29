Imports System.IO
''' <summary>
''' Simple extension method to export all checked rows,
''' all columns except for the first column which would be
''' the check box column
''' </summary>
Module DataGridViewExtensions
    ''' <summary>
    ''' Export to text file
    ''' </summary>
    ''' <param name="sender">DataGridView</param>
    ''' <param name="fileName">Write to this file</param>
    ''' <param name="processColumnName">Name of the DataGridViewCheckBox column</param>
    <Runtime.CompilerServices.Extension()>
    Public Sub ExportRows(sender As DataGridView, fileName As String, processColumnName As String)
        Dim sbHeader = New Text.StringBuilder()
        Dim headers = sender.Columns.Cast(Of DataGridViewColumn)()

        sbHeader.Append(String.Join(",", headers.Select(Function(column) column.HeaderText)))

        Dim lines =
                (
                From row In sender.Rows
                Where Not DirectCast(row, DataGridViewRow).IsNewRow AndAlso
                      CBool(DirectCast(row, DataGridViewRow).Cells(processColumnName).Value) = True
                Let rowItem = String.Join(",", Array.ConvertAll(
                    DirectCast(row, DataGridViewRow).Cells.Cast(Of DataGridViewCell).ToArray,
                    Function(c As DataGridViewCell) If(c.Value Is Nothing OrElse IsDBNull(c.Value), "",
                                                       CStr(c.Value).Trim)))
                Select rowItem
                ).ToList

        lines.Insert(0, sbHeader.ToString)

        ' remove check box column
        For index As Integer = 0 To lines.Count - 1
            Dim pos = lines(index).IndexOf(","c)
            lines(index) = lines(index).Substring(pos + 1)
        Next

        File.WriteAllLines(fileName, lines)

    End Sub
End Module