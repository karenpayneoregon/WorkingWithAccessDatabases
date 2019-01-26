Imports System.IO
Imports KarensBaseClasses
Imports System.Threading

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


    Public Function RowCount() As Integer

        Dim Count As Integer = 0

        Using cn As New OleDb.OleDbConnection With {.ConnectionString = ConnectionString}
            Using cmd As New OleDb.OleDbCommand With {.CommandText = "SELECT COUNT(Identifier) As RowCount FROM People;", .Connection = cn}
                cn.Open()
                Count = CInt(cmd.ExecuteScalar)
            End Using
        End Using

        Return Count

    End Function
    Public Iterator Function LoadCustomers(ct As CancellationToken) As IEnumerable(Of Object())
        Dim recordCount As Integer = Me.RowCount

        Dim selectStatement As String = "SELECT Identifier, FirstName, LastName FROM People;"

        Using cn As New OleDb.OleDbConnection With {.ConnectionString = ConnectionString}
            Using cmd As New OleDb.OleDbCommand With {.CommandText = selectStatement, .Connection = cn}

                cn.Open()

                Dim identifier As Integer = 0
                Dim firstName As String = ""
                Dim lastName As String = ""
                Dim itemArray As Object() = {}

                Dim Reader = cmd.ExecuteReader

                If Reader.HasRows Then

                    While Reader.Read
                        identifier = Reader.GetFieldValue(Of Integer)(0)
                        firstName = Reader.GetFieldValue(Of String)(1)
                        lastName = Reader.GetFieldValue(Of String)(2)

                        Yield itemArray

                        CustomersForm.UpDateDataTable({identifier, firstName, lastName}, $"Loading {identifier} of {recordCount}")

                    End While

                End If

            End Using
        End Using
    End Function
End Class
