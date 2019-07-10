Imports System.Data.OleDb

Public Class DatabaseOperations
    '
    Private ConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;" &
                                         $"Data Source={AppDomain.CurrentDomain.BaseDirectory}\Database1.accdb"
    Public Function LoadCustomers() As DataTable

        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    SELECT 
                        C.Identifier, 
                        C.CompanyName, 
                        CT.ContactTitleId, 
                        CT.Title, 
                        C.Country
                    FROM 
                        ContactTitle AS CT 
                    INNER JOIN 
                        Customers AS C ON CT.ContactTitleId = C.ContactTitleId
                    ORDER BY 
                        CompanyName;
                    </SQL>.Value

                Dim dt As New DataTable With {.TableName = "Customer"}


                cn.Open()
                dt.Load(cmd.ExecuteReader)
                Return dt

            End Using
        End Using
    End Function
End Class
