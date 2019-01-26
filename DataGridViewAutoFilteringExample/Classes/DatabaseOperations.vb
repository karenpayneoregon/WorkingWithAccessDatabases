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
    End Sub
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
End Class
