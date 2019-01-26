Imports System.Data.OleDb
Imports System.IO
Imports KarensBaseClasses

Public Class DatabaseOperations
    Inherits AccessConnection

    ''' <summary>
    ''' Default our connection to a database in the executable folder when not using a password
    ''' </summary>
    ''' <remarks>
    ''' Not used in the code sample but this is how to do a connection not encrypted.
    ''' </remarks>
    Public Sub New()
        DefaultCatalog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PeopleDatabase.accdb")
    End Sub

    Public Function LoadPeople() As DataTable

        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    SELECT 
                        Identifier, 
                        FirstName, 
                        LastName
                    FROM People;
                    </SQL>.Value

                Dim dt As New DataTable With {.TableName = "People"}

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    dt.Columns("Identifier").ColumnMapping = MappingType.Hidden
                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try

                Return dt

            End Using
        End Using
    End Function

End Class
