Public Class ExcelOperations
    Private mException As Boolean = False
    Public ReadOnly Property IsSuccessful() As Boolean
        Get
            Return mException = False
        End Get
    End Property
    Public Function Read(fileName As String, sheetName As String) As DataTable
        Dim dt As New DataTable

        Using cn As New OleDb.OleDbConnection With
            {
            .ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;" &
                $"Data Source={fileName};" &
                "Extended Properties=""Excel 12.0;IMEX=1;HDR=No;"""}

            Using cmd As New OleDb.OleDbCommand With
                {
                .CommandText =
                    "SELECT F1 As FirstName, F2 As MiddleName, F3 As LastName, " &
                    "F4 As Street, F5 As City, F6 As State, F7 As Postal, " &
                    $"F8 As EmailAddress FROM [{sheetName}]",
                .Connection = cn}

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    mException = False
                Catch ex As Exception
                    mException = True
                End Try

            End Using
        End Using

        Return dt

    End Function

End Class
