Imports System.Data.OleDb

Public Class Operations
    Public ReadOnly Property ConnectionString As String
        Get
            Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb"
        End Get
    End Property
    ''' <summary>
    ''' Last identifier used
    ''' </summary>
    ''' <returns></returns>
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
    ''' <summary>
    ''' Next unused identifier
    ''' </summary>
    ''' <returns></returns>
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
    ''' <summary>
    ''' Get new identifier and commit
    ''' </summary>
    ''' <param name="pDescription"></param>
    ''' <returns></returns>
    Public Function Increment(pDescription As String) As Integer
        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = "INSERT INTO Admin (Description) VALUES (?)"
                }

                cmd.Parameters.AddWithValue("?", pDescription)

                cn.Open()

                Dim result = cmd.ExecuteNonQuery()

                If result = 1 Then
                    cmd.CommandText = "Select @@Identity"
                    Return CInt(cmd.ExecuteScalar())
                Else
                    Return 0
                End If

            End Using
        End Using

    End Function
End Class
