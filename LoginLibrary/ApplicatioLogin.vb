Public Class ApplicatioLogin
    Private ConnectionString As String
    Public Property UserName As String
    Public Property UserPassword As String
    Public Property Retries As Integer
    Private Userid As Integer
    Public ReadOnly Property UserIdentifier As Integer
        Get
            Return Userid
        End Get
    End Property
    ''' <summary>
    ''' From encrypted connection string in app.config
    ''' </summary>
    ''' <param name="pConnectionString">decrypted connection string</param>
    Public Sub New(pConnectionString As String)
        ConnectionString = pConnectionString
    End Sub
    ''' <summary>
    ''' Try to login a user based on proper user name and password.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' You should (as done here) keep it a mystery why a login failed as a hacker
    ''' may be attempting to hack your app
    ''' </remarks>
    Public Function Login() As Boolean

        If Not String.IsNullOrWhiteSpace(Me.UserName) AndAlso Not String.IsNullOrWhiteSpace(Me.UserPassword) Then
            Using cn As New OleDb.OleDbConnection With {.ConnectionString = ConnectionString}

                Using cmd As New OleDb.OleDbCommand With
                    {
                        .Connection = cn,
                        .CommandText =
                        "SELECT Identifer, UserName, UserPassword FROM Users " &
                        "WHERE UserName = @UserName AND UserPassword = @UserPassword"
                    }
                    cmd.Parameters.AddWithValue("@UserName", Me.UserName)
                    cmd.Parameters.AddWithValue("@UserPassword", Me.UserPassword)

                    Try
                        cn.Open()
                    Catch ex As Exception
                        If ex.Message.ToLower.Contains("not a valid password") Then
                            Return False
                        Else
                            Throw ex
                        End If
                    End Try


                    Dim reader = cmd.ExecuteScalar
                    If reader IsNot Nothing Then
                        Userid = CInt(reader)
                        Retries = 0

                        Return True
                    Else
                        Retries += 1
                        Return False
                    End If
                End Using
            End Using
        Else
            Return False
        End If
    End Function

End Class
