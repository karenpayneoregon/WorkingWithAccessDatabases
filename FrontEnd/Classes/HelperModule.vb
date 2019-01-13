Public Module HelperModule
    Public Function IsAccessInstalled() As Boolean
        Dim officeType As Type = Type.GetTypeFromProgID("Access.Application")
        If officeType Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function IsAccessInstalled1() As Boolean

        Return (New OleDb.OleDbEnumerator()).
            GetElements().AsEnumerable().
            Any(Function(x) x.Field(Of String)("SOURCES_NAME") = "Microsoft.ACE.OLEDB.12.0")

    End Function
    Public Function OleDbEnumerator() As List(Of String)

        Dim providerList As New List(Of String)

        Dim oledb12Installed = (New OleDb.OleDbEnumerator()).
                GetElements().AsEnumerable()

        For Each row As DataRow In oledb12Installed
            providerList.Add(row.Field(Of String)("SOURCES_NAME"))
        Next

        Return providerList

    End Function
End Module
