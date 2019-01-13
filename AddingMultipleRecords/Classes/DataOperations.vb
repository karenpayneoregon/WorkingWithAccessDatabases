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
        DefaultCatalog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
    End Sub
    ''' <summary>
    ''' Used to setup parameters for the method AddNewCustomerRecords
    ''' </summary>
    ''' <param name="cn">A OleDbConnection that has been created as in AddNewCustomerRecords</param>
    ''' <returns>Fully prepared command object</returns>
    Private Function AddRecordCommand(cn As OleDbConnection) As OleDbCommand
        Dim cmd As New OleDbCommand With {.Connection = cn}

        cmd.CommandText =
            <SQL>
                INSERT INTO Customer 
                (
                    CompanyName,
                    ContactName,
                    EstablishedYear,
                    Incorporated
                ) 
                VALUES 
                (
                    @CompanyName,
                    @ContactName,
                    @EstablishedYear,
                    @Incorporated
                )
            </SQL>.Value

        cmd.Parameters.Add(New OleDbParameter With {.ParameterName = "@CompanyName", .DbType = DbType.String})
        cmd.Parameters.Add(New OleDbParameter With {.ParameterName = "@ContactName", .DbType = DbType.String})
        cmd.Parameters.Add(New OleDbParameter With {.ParameterName = "@EstablishedYear", .OleDbType = OleDbType.Integer})
        cmd.Parameters.Add(New OleDbParameter With {.ParameterName = "@Incorporated", .OleDbType = OleDbType.Date})

        Return cmd

    End Function
    ''' <summary>
    ''' Add many customer records
    ''' </summary>
    ''' <param name="customersList">List of new customers to add to the Customer table</param>
    ''' <returns>True if successful, false on error</returns>
    Public Function AddNewCustomerRecords(customersList As List(Of Customer)) As Boolean
        mHasException = False
        Dim affected As Integer = 0

        Try
            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                cn.Open()

                For Each customer As Customer In customersList
                    '
                    ' Create a command for adding a new record. This must
                    ' be done each iteration as in the code to get the new primary
                    ' key the command is altered.
                    '
                    Dim cmdAdd = AddRecordCommand(cn)

                    cmdAdd.Parameters("@CompanyName").Value = customer.CompanyName
                    cmdAdd.Parameters("@ContactName").Value = customer.ContactName
                    cmdAdd.Parameters("@EstablishedYear").Value = customer.EstablishedYear
                    cmdAdd.Parameters("@Incorporated").Value = customer.Incorporated

                    '
                    ' Add record
                    '
                    affected = cmdAdd.ExecuteNonQuery()

                    '
                    ' If affected equals 1, this means the record was added,
                    ' in turn get the new primary key by changing the command text.
                    ' No need to clear parameters.
                    '
                    If affected = 1 Then
                        cmdAdd.CommandText = "Select @@Identity"
                        customer.Id = CInt(cmdAdd.ExecuteScalar)
                    End If

                Next

            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
            '
            ' Exit on the first exception.
            '
            Return False
        End Try

        Return IsSuccessFul

    End Function
    Public Function ReadCustomerTable() As List(Of Customer)
        Dim customersList As New List(Of Customer)

        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                        SELECT Id, CompanyName, ContactName, EstablishedYear, Incorporated 
                        FROM Customer;
                    </SQL>.Value

                Dim dt As New DataTable

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    customersList = ConvertDataTable(Of Customer)(dt)

                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try
            End Using
        End Using

        Return customersList

    End Function
End Class
