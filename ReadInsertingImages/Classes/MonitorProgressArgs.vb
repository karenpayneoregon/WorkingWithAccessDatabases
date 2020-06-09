Namespace Classes
    Public Class MonitorProgressArgs
        Inherits EventArgs

        Public Sub New(id As Integer, imageBytes As Byte())

            PictureIdentifier = id
            ByteArray = imageBytes
        End Sub
        Public ReadOnly Property PictureIdentifier() As Integer
        Public ReadOnly Property ByteArray() As Byte()
    End Class
End Namespace