Public Class OleDbHelpers
    ''' <summary>
    ''' Determine if OleDb data provider is installed from 2007 + products such as MS-Access, MS-Excel
    ''' </summary>
    ''' <returns>True if OleDb provider is installed, False if not installed</returns>
    Public Function IsOleDbProviderInstalled() As Boolean

        Dim providerInstalled = (New OleDb.OleDbEnumerator()).
                GetElements().AsEnumerable().
                FirstOrDefault(
                    Function(row)
                        Return row.Field(Of String)("SOURCES_NAME") = "Microsoft.ACE.OLEDB.12.0"
                    End Function)

        If providerInstalled IsNot Nothing Then
            Return True
        Else
            Return False
        End If

    End Function
End Class
