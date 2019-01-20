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

        Using cn As New OleDbConnection(ConnectionStringWithPassword)
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

        Using cn As New OleDbConnection(ConnectionStringWithPassword)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                        SELECT 
                            Process,
                            Identifier, 
                            CompanyName, 
                            ContactName, 
                            ContactTitle
                        FROM Customer 
                        ORDER BY CompanyName;
                    </SQL>.Value

                Dim dt As New DataTable With {.TableName = "Customer"}

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    dt.Columns("Identifier").ColumnMapping = MappingType.Hidden
                    dt.Columns("Process").ColumnMapping = MappingType.Hidden

                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try

                Return dt

            End Using
        End Using
    End Function

    ''' <summary>
    ''' Load a list of contact titles.
    ''' </summary>
    ''' <returns>List of contact titles</returns>
    ''' <remarks>
    ''' In a well normalized database we would have a contact tile
    ''' table and the customer table would have a integer field that
    ''' would join to the contact title table.
    ''' 
    ''' XML Literals allow a developer to write clean SQL with no string concatenation.
    ''' 
    ''' </remarks>
    Public Function LoadContactTitles() As List(Of String)

        Dim titleList As New List(Of String)

        Using cn As New OleDbConnection(ConnectionStringWithPassword)
            Using cmd As New OleDbCommand With {.Connection = cn}

                cmd.CommandText = <SQL>
                        SELECT DISTINCT ContactTitle
                        FROM Customer
                    </SQL>.Value

                Try

                    cn.Open()

                    Dim reader As OleDbDataReader = cmd.ExecuteReader

                    While reader.Read
                        titleList.Add(reader.GetString(0))
                    End While

                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try

            End Using
        End Using

        Return titleList
    End Function
    ''' <summary>
    ''' Remove a customer by primary key
    ''' </summary>
    ''' <param name="pIdentfier">Identifier to the customer record to remove</param>
    ''' <returns></returns>
    Public Function RemoveCurrentCustomer(pIdentfier As Integer) As Boolean
        Try
            Using cn As New OleDbConnection(ConnectionStringWithPassword)
                Using cmd As New OleDbCommand With {.Connection = cn}

                    cmd.CommandText = "DELETE FROM Customer WHERE Identifier = @Identifier"

                    Dim identifierParameter As New OleDbParameter With
                            {
                                .DbType = DbType.Int32,
                                .ParameterName = "@Identifier",
                                .Value = pIdentfier
                            }

                    cmd.Parameters.Add(identifierParameter)

                    Try
                        cn.Open()

                        Dim affected = cmd.ExecuteNonQuery
                        Return affected = 1

                    Catch ex As Exception
                        mHasException = True
                        mLastException = ex
                        Return False
                    End Try
                End Using
            End Using

        Catch ex As Exception
            mHasException = True
            mLastException = ex
            Return IsSuccessFul
        End Try
    End Function

    ''' <summary>
    ''' Add a new customer to the database table
    ''' </summary>
    ''' <param name="pName">Company name</param>
    ''' <param name="pContact">Contact name</param>
    ''' <param name="pContactTitle">Contact title</param>
    ''' <param name="pIdentfier">Returning new primary key</param>
    ''' <returns>True if successful and pIdentifier will hold the new record's primary key</returns>
    ''' <remarks>
    ''' XML Literals allow a developer to write clean SQL with no string concatenation.
    ''' </remarks>
    Public Function AddNewRow(pName As String, pContact As String, pContactTitle As String, ByRef pIdentfier As Integer) As Boolean

        Dim success As Boolean = True

        Try
            Using cn As New OleDbConnection(ConnectionStringWithPassword)
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText = <SQL>
                            INSERT INTO Customer 
                                (
                                    CompanyName,
                                    ContactName,
                                    ContactTitle
                                ) 
                            Values
                                (
                                    @CompanyName,
                                    @ContactName,
                                    @ContactTitle
                                )
                        </SQL>.Value

                    cmd.Parameters.AddWithValue("@CompanyName", pName)
                    cmd.Parameters.AddWithValue("@ContactName", pContact)
                    cmd.Parameters.AddWithValue("@ContactTitle", pContactTitle)

                    cn.Open()

                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Select @@Identity"
                    pIdentfier = CInt(cmd.ExecuteScalar)

                End Using
            End Using

        Catch ex As Exception
            mHasException = True
            mLastException = ex
            success = False
        End Try

        Return success
    End Function

    ''' <summary>
    ''' Update a row
    ''' </summary>
    ''' <param name="pRow"></param>
    ''' <returns>True if update was successful, false if unsuccessful</returns>
    ''' <remarks>
    ''' Parameters.Add instead of Parameters.AddWithValue
    ''' where Parameters.AddWithValue is usually best yet wanted to
    ''' show Parameters.Add as many don't realize this is a viable
    ''' way to add parameters and really shines when doing multiple
    ''' adds or updates in say a for-each or for-next.
    ''' </remarks>
    Public Function UpdateRow(pRow As DataRow) As Boolean

        Try
            Using cn As New OleDbConnection(ConnectionStringWithPassword)

                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText = <SQL>
                            UPDATE 
                                Customer 
                            SET 
                                Process = @Process,
                                CompanyName = @CompanyName, 
                                ContactName = @ContactName,
                                ContactTitle = @ContactTitle
                            WHERE Identifier = @Identifier
                        </SQL>.Value

                    Dim processParameter As New OleDbParameter With
                            {
                                .DbType = DbType.Boolean,
                                .ParameterName = "@Process",
                                .Value = pRow.Field(Of Boolean)("Process")
                            }

                    cmd.Parameters.Add(processParameter)

                    Dim companyNameParameter As New OleDbParameter With
                            {
                                .DbType = DbType.String,
                                .ParameterName = "@CompanyName",
                                .Value = pRow.Field(Of String)("CompanyName")
                            }

                    cmd.Parameters.Add(companyNameParameter)

                    Dim contactNameParameter As New OleDbParameter With
                            {
                                .DbType = DbType.String,
                                .ParameterName = "@ContactName",
                                .Value = pRow.Field(Of String)("ContactName")
                            }

                    cmd.Parameters.Add(contactNameParameter)

                    Dim contactTitleParameter As New OleDbParameter With
                            {
                                .DbType = DbType.String,
                                .ParameterName = "@ContactTitle",
                                .Value = pRow.Field(Of String)("ContactTitle")
                            }

                    cmd.Parameters.Add(contactTitleParameter)

                    Dim identifierParameter As New OleDbParameter With
                            {
                                .DbType = DbType.Int32,
                                .ParameterName = "@Identifier",
                                .Value = pRow.Field(Of Integer)("Identifier")
                            }

                    cmd.Parameters.Add(identifierParameter)

                    Try
                        cn.Open()

                        Dim affected = cmd.ExecuteNonQuery
                        Return affected = 1

                    Catch ex As Exception

                        mHasException = True
                        mLastException = ex

                        Return IsSuccessFul

                    End Try
                End Using
            End Using

        Catch ex As Exception

            mHasException = True
            mLastException = ex

            Return IsSuccessFul

        End Try
    End Function
End Class
