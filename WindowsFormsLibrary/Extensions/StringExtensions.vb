Imports System.Windows.Forms

Public Module StringExtensions
    <Runtime.CompilerServices.Extension>
    Public Function EscapeApostrophe(ByVal pSender As String) As String
        Return pSender.Replace("'", "''")
    End Function
    ''' <summary>
    ''' Method base of the function
    ''' </summary>
    ''' <param name="pSender"></param>
    ''' <returns></returns>
    <Runtime.CompilerServices.Extension>
    Public Function IsNullOrWhiteSpace(ByVal pSender As TextBox) As Boolean
        Return String.IsNullOrWhiteSpace(pSender.Text)
    End Function

End Module
