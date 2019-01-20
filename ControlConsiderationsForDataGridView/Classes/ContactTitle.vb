Public Class ContactTitle
    Public Property ContactTitleId() As Integer
    Public Property Title() As String

    Public Overrides Function ToString() As String
        Return Title
    End Function
End Class
