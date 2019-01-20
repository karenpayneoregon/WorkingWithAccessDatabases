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
        DefaultCatalog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
    End Sub
    ''' <summary>
    ''' Test the connection before attempting to interact with the ms-access database.
    ''' </summary>
    ''' <returns></returns>
    Public Function TestConnection() As Boolean
        mHasException = False

        Using cn As New OleDbConnection(ConnectionString)
            Try
                cn.Open()
                Return True
            Catch ex As Exception
                mHasException = True
                mLastException = ex
            End Try
        End Using

        Return IsSuccessFul

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
                        cust.Identifier,
                        cust.CompanyName, 
                        cust.ContactName, 
                        cust.ContactTitleId,
                        ct.Title
                    FROM ContactTitle as ct INNER JOIN Customers as cust ON ct.ContactTitleId = cust.ContactTitleId
                    ORDER BY cust.CompanyName;
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
    Public Function LoadContactTitles() As List(Of ContactTitle)
        Dim contactTitleList As New List(Of ContactTitle) From {New ContactTitle() With {.ContactTitleId = 0, .Title = "Select all"}}

        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    SELECT 
                        ContactTitleId, 
                        Title
                    FROM 
                        ContactTitle
                    ORDER BY 
                        TItle
                    </SQL>.Value

                Try
                    cn.Open()

                    Dim reader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        While reader.Read()
                            contactTitleList.Add(New ContactTitle() With {.ContactTitleId = reader.GetInt32(0), .Title = reader.GetString(1)})
                        End While
                    End If

                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try
            End Using
        End Using

        Return contactTitleList

    End Function
End Class
