Imports System.Data.OleDb

Public Class Form1
    'https://docs.microsoft.com/en-us/office/client-developer/access/desktop-database-reference/alter-user-or-database-statement-microsoft-access-sql
    'https://social.msdn.microsoft.com/Forums/en-US/8c513514-a588-4ef3-955b-9ea641070bb1/how-to-change-ms-access-database-password-in-c?forum=adodotnetdataproviders
    Private Sub changePasswordButton_Click(sender As Object, e As EventArgs) Handles changePasswordButton.Click
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb;Jet OLEDB:" &
                                         "Database Password=password;Mode=Share Exclusive;Persist Security Info=True;"

        Using cn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                Try
                    cn.Open()

                    cmd.CommandText =
                        <Statement>
                        ALTER DATABASE PASSWORD "password1" "[password]"
                        </Statement>.Value

                    cmd.ExecuteNonQuery()
                    Console.WriteLine("Done")
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
            End Using
        End Using
    End Sub
End Class
