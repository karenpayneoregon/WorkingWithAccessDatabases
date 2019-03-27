Namespace Classes
    Public Class Category
        Public Property CategoryID() As Integer
        Public Property CategoryName() As String

        Public Overrides Function ToString() As String
            Return CategoryName
        End Function
    End Class
End Namespace