Public Module ComboBoxExtensions
    <Runtime.CompilerServices.Extension()>
    Public Function EmployeeTitles(sender As ComboBox) As List(Of EmployeeTitle)
        Return CType(sender.DataSource, List(Of EmployeeTitle))
    End Function
End Module
