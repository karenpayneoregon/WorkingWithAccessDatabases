Imports System.Data.OleDb
Imports System.IO

Public Class DataOperations
    Private mHasException As Boolean = False
    Public ReadOnly Property IsSuccessful() As Boolean
        Get
            Return mHasException = False
        End Get
    End Property
    Private mException As Exception
    Public ReadOnly Property LastException() As Exception
        Get
            Return mException
        End Get
    End Property
    Private mRowCount As Integer
    Public ReadOnly Property RowCount() As Integer
        Get
            Return mRowCount
        End Get
    End Property
    Private ReadOnly Property ConnectionString As String
        Get
            Return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb"
        End Get
    End Property
    Public Function ReadBarCodes(pBarCode As String) As BarCode
        Dim result = New BarCode

        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = "SELECT Id, BarCode, Description, Cost " &
                                  "FROM Barcodes WHERE BarCode=@barCode"

                cmd.Parameters.AddWithValue("@barCode", pBarCode)
                cn.Open()
                Dim reader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    result.Id = reader.GetInt32(0)
                    result.BarCode = pBarCode
                    result.Description = reader.GetString(2)
                    result.Cost = reader.GetDecimal(3)
                End If
            End Using
        End Using

        Return result
    End Function

End Class