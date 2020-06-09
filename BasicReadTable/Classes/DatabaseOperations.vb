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
        DefaultCatalog = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")

        Console.WriteLine(ConnectionString)
    End Sub
    Public Function LoadCompanyNames() As List(Of String)
        Dim nameList As New List(Of String)
        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                Console.WriteLine(ConnectionString)
                cmd.CommandText = "SELECT  CompanyName FROM Customers"
                cn.Open()
                Dim reader = cmd.ExecuteReader()
                While reader.Read()
                    nameList.Add(reader.GetString(0))
                End While
            End Using
        End Using
        Return nameList
    End Function
    ''' <summary>
    ''' Read customers from database into a DataTable
    ''' </summary>
    ''' <returns>Populated DataTable of Customers</returns>
    ''' <remarks>
    ''' XML Literals allow a developer to write clean SQL with no string concatenation.
    ''' </remarks>
    Public Function LoadCustomers() As DataTable

        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    SELECT 
                        C.Identifier, 
                        C.CompanyName, 
                        CT.ContactTitleId, 
                        CT.Title, C.Address, 
                        C.City, C.PostalCode, 
                        C.Country
                    FROM 
                        ContactTitle AS CT 
                    INNER JOIN 
                        Customers AS C ON CT.ContactTitleId = C.ContactTitleId
                    ORDER BY 
                        CompanyName;
                    </SQL>.Value

                Dim dt As New DataTable With {.TableName = "Customer"}

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)

                    '
                    ' Hide primary keys
                    '
                    dt.Columns("Identifier").ColumnMapping = MappingType.Hidden
                    dt.Columns("ContactTitleId").ColumnMapping = MappingType.Hidden

                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try

                Return dt

            End Using
        End Using
    End Function

    Public Sub RemoveCustomer(customerKey As Integer)

        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = "DELETE FROM Customers WHERE Identifier = ?"
                cmd.Parameters.AddWithValue("?", customerKey)
                Try
                    cn.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try

            End Using
        End Using

    End Sub
End Class
