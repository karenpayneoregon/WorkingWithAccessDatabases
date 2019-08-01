Imports System.Data.OleDb

Public Class Operations
    Public ReadOnly Property ConnectionString As String
        Get
            Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb"
        End Get
    End Property
    Public Function CurrentIdentifier() As Integer
        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = "SELECT TOP 1 ID FROM Admin ORDER BY ID DESC;"
                }

                cn.Open()
                Return CInt(cmd.ExecuteScalar())

            End Using
        End Using
    End Function
    Public Function NextIdentifier() As Integer
        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = "SELECT TOP 1 ID FROM Admin ORDER BY ID DESC;"
                }

                cn.Open()
                Return CInt(cmd.ExecuteScalar()) + 1

            End Using
        End Using
    End Function
End Class
