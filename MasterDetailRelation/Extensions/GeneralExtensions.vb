Module GeneralExtensions
    <Runtime.CompilerServices.Extension()>
    <DebuggerStepThrough()>
    Function IsCalendarCell(ByVal sender As DataGridView, ByVal e As DataGridViewCellEventArgs) As Boolean
        Return TypeOf sender.Columns(e.ColumnIndex) Is CalendarColumn AndAlso Not e.RowIndex = -1
    End Function
End Module
