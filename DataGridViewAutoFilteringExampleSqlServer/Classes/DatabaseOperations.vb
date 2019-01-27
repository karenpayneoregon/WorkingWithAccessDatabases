Imports System.Data.SqlClient
Imports KarensBaseClasses

Namespace Classes
    Public Class DatabaseOperations
        Inherits BaseSqlServerConnection

        Public Sub New()
            DefaultCatalog = "NorthWindAzure3"

        End Sub
        ''' <summary>
        ''' Read customers from database into a DataTable
        ''' </summary>
        ''' <returns>Populated DataTable of Customers</returns>
        ''' <remarks>
        ''' XML Literals allow a developer to write clean SQL with no string concatenation.
        ''' </remarks>
        Public Function LoadCustomers() As DataTable

            Using cn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand With {.Connection = cn}
                    cmd.CommandText = <SQL>
                        SELECT   C.CustomerIdentifier ,
                                 C.CompanyName ,
                                 C.ContactIdentifier ,
                                 C.ContactTypeIdentifier ,
                                 CT.ContactTitle ,
                                 Contact.FirstName ,
                                 Contact.LastName ,
                                 C.Street ,
                                 C.City ,
                                 C.PostalCode ,
                                 C.CountryIdentfier ,
                                 country.CountryName
                        FROM     dbo.Customers AS C
                                 INNER JOIN dbo.Contact ON C.ContactIdentifier = Contact.ContactIdentifier
                                 INNER JOIN dbo.ContactType AS CT ON C.ContactTypeIdentifier = CT.ContactTypeIdentifier
                                 INNER JOIN dbo.Countries AS country ON C.CountryIdentfier = country.id
                        ORDER BY C.CompanyName;
                    </SQL>.Value

                    Dim dt As New DataTable With {.TableName = "Customer"}

                    Try
                        cn.Open()
                        dt.Load(cmd.ExecuteReader)

                        '
                        ' Hide primary keys
                        '
                        dt.Columns("CustomerIdentifier").ColumnMapping = MappingType.Hidden
                        dt.Columns("ContactIdentifier").ColumnMapping = MappingType.Hidden
                        dt.Columns("ContactTypeIdentifier").ColumnMapping = MappingType.Hidden
                        dt.Columns("CountryIdentfier").ColumnMapping = MappingType.Hidden

                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                    End Try

                    Return dt

                End Using
            End Using
        End Function
    End Class
End Namespace