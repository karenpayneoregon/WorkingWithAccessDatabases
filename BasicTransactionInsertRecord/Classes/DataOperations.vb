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

    Public Function AddNewRow(companyName As String, contactName As String, establishedYear As Integer, incorporated As Date, ByRef pIdentfier As Integer) As Boolean

        Using cn As New OleDbConnection(ConnectionString)
            Dim transaction As OleDbTransaction = Nothing
            Dim cmd = AddRecordCommand(cn)
            Try
                cn.Open()
                transaction = cn.BeginTransaction()
                cmd.Transaction = transaction

                cmd.Parameters("@CompanyName").Value = companyName
                cmd.Parameters("@ContactName").Value = contactName
                cmd.Parameters("@EstablishedYear").Value = establishedYear
                cmd.Parameters("@Incorporated").Value = incorporated

                cmd.ExecuteNonQuery()

                cmd.CommandText = "Select @@Identity"
                pIdentfier = CInt(cmd.ExecuteScalar)

                transaction.Commit()

            Catch oleDbException As OleDbException

                transaction.Rollback()

                mHasException = True
                mLastException = oleDbException
            Catch ex As Exception
                mHasException = True
                mLastException = ex
            End Try
        End Using


        Return IsSuccessFul

    End Function

End Class
