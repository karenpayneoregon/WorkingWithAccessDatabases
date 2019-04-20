Imports System.Data.OleDb
Imports System.IO
Imports KarensBaseClasses

Public Class DatabaseOperations
    Inherits AccessConnection

    Public Sub New()
        DefaultCatalog = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
    End Sub
    Public Function GetDate() As Date
        Dim resultDate As Date
        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}

                cmd.CommandText = "SELECT SomeDate FROM Table1 " &
                                  "UNION SELECT SomeDate " &
                                  "FROM Table2 ORDER BY SomeDate;"

                cn.Open()
                Dim reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    resultDate = reader.GetDateTime(0)
                End If
            End Using
        End Using

        Return resultDate
    End Function

End Class
