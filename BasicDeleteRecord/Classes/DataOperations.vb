Imports System.Data.OleDb

Namespace Classes
    Public Class DataOperations
        Public Shared ReadOnly Property ConnectionString() As String
            Get
                Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ForumQuestion.accdb"
            End Get
        End Property
        Public Shared Function RemoveCategory(key As Integer) As Boolean

            Using cn As New OleDbConnection(ConnectionString)
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText = "DELETE FROM Categories WHERE CategoryID = ?"
                    cmd.Parameters.AddWithValue("?", key)
                    cn.Open()
                    Return cmd.ExecuteNonQuery() = 1
                End Using
            End Using
        End Function

        Public Shared Function ReadCategories() As List(Of Category)
            Dim categoryList As New List(Of Category)
            Using cn As New OleDbConnection(ConnectionString)
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText = "SELECT CategoryID, CategoryName FROM Categories;"

                    cn.Open()
                    Dim reader = cmd.ExecuteReader()
                    While reader.Read()
                        categoryList.Add(New Category() With {
                                            .CategoryID = reader.GetInt32(0),
                                            .CategoryName = reader.GetString(1)})
                    End While
                End Using
            End Using

            Return categoryList

        End Function
    End Class
End Namespace