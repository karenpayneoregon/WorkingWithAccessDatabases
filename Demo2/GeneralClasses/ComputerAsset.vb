Public Class ComputerAsset
    Public Property AssetId() As Integer
    Public Property UserName() As String
    Public Property ComputerName() As String
    Public Property ServiceTag() As String
    Public Property FormerUsers() As List(Of User)

    Public Sub New()
        FormerUsers = New List(Of User)
    End Sub

    Public Overrides Function ToString() As String
        Return ComputerName
    End Function
End Class
Public Class User
    Public Property UserId() As Integer
    Public Property AssetId() As Integer
    Public Property Name() As String

    Public Overrides Function ToString() As String
        Return $"{Name}"
    End Function
End Class
