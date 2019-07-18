Public Class BarCode
    Public Property Id() As Integer
    Public Property BarCode() As String
    Public Property Description() As String
    Public Property Cost() As Decimal

    Public Overrides Function ToString() As String
        Return $"Id {Id} Barcode {BarCode} Description {Description} Code {Cost}"
    End Function
End Class