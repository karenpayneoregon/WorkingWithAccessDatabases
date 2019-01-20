Public Class EmployeeTitle
    Public Property EmployeeTitleId() As Integer
    Public Property Title() As String

    Public Overrides Function ToString() As String
        Return Title
    End Function
End Class
