Imports System.Data.OleDb
Imports System.IO
Imports KarensBaseClasses

Public Class DataOperations
    Inherits AccessConnection

    ''' <summary>
    ''' Default our connection to a database in the executable folder when not using a password
    ''' </summary>
    ''' <remarks>
    ''' Not used in the code sample but this is how to do a connection not encrypted.
    ''' </remarks>
    Public Sub New()
        DefaultCatalog = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
    End Sub
    Public Function IsBlackListed(userName As String, fullName As String) As Boolean

        Using cn As New OleDbConnection(ConnectionString)

            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText =
                    <SQL>
                        SELECT ID
                        FROM 
                            tbl_BlackList
                        WHERE 
                            User_Name=@UserName OR Full_Name=@FullName;
                    </SQL>.Value
                cn.Open()

                cmd.Parameters.AddWithValue("@UserName", userName)
                cmd.Parameters.AddWithValue("@FullName", fullName)

                Dim reader = cmd.ExecuteReader()

                Return reader.HasRows

            End Using
        End Using

    End Function
    Public Function IsBlackListedByUserName(userName As String) As String

        Dim result As String = ""

        Using cn As New OleDbConnection(ConnectionString)

            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText =
                    <SQL>
                        SELECT Full_Name
                        FROM 
                            tbl_BlackList
                        WHERE 
                            User_Name=@UserName
                    </SQL>.Value
                cn.Open()

                cmd.Parameters.AddWithValue("@UserName", userName)

                Dim reader = cmd.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    result = reader.GetString(0)
                End If

            End Using
        End Using

        Return result
    End Function
    Public Function IsBlackListedByFullName(fullName As String) As String

        Dim result As String = ""

        Using cn As New OleDbConnection(ConnectionString)

            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText =
                    <SQL>
                        SELECT  User_Name
                        FROM 
                            tbl_BlackList
                        WHERE 
                            Full_Name=@FullName
                    </SQL>.Value
                cn.Open()

                cmd.Parameters.AddWithValue("@FullName", fullName)

                Dim reader = cmd.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    result = reader.GetString(0)
                End If

            End Using
        End Using

        Return result
    End Function
End Class
