Imports System.Data.OleDb
Imports System.IO
Imports BaseConnectionLibrary.ConnectionClasses

Namespace Classes

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

        Public Function LoadOrders(companyName As String, startDate As Date, endDate As Date) As DataTable


            Using cn As New OleDbConnection(ConnectionString)
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText = <SQL>
                        SELECT Orders.OrderID, Orders.Identifier, Orders.OrderDate, Customers.CompanyName
                        FROM Customers INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID_OLD
                        WHERE (((
                            Customers.CompanyName)=? AND Orders.OrderDate BETWEEN ? AND ?
                    ));
                    </SQL>.Value

                    cmd.Parameters.AddWithValue("?", companyName)
                    cmd.Parameters.AddWithValue("?", startDate)
                    cmd.Parameters.AddWithValue("?", endDate)

                    Dim dt As New DataTable With {.TableName = "Customer"}

                    dt.Columns.Add(New DataColumn() With {.ColumnName = "Process", .DataType = GetType(Boolean), .DefaultValue = False})
                    dt.Columns("Process").SetOrdinal(0)

                    Try
                        cn.Open()
                        dt.Load(cmd.ExecuteReader)


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