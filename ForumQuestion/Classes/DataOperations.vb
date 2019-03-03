Imports System.Data.OleDb
Imports System.IO

Namespace Classes
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
                Return $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db1.mdb")};"
            End Get
        End Property
        ''' <summary>
        ''' Inserts all rows in DataTable to Access database table
        ''' </summary>
        ''' <param name="dataTable"></param>
        Public Sub InsertRows(dataTable As DataTable)

            mHasException = False

            Using cn As New OleDbConnection(ConnectionString)
                Using cmd As New OleDbCommand With {.Connection = cn}

                    '
                    ' Here each column in the table is being setup for parameters
                    ' for the command object. A full solution would be to have
                    ' a method that takes care of all data types not just string and double
                    '
                    For Each column As DataColumn In dataTable.Columns

                        If column.DataType = GetType(String) Then
                            cmd.Parameters.Add($"@{column.ColumnName}", OleDbType.LongVarChar)
                        End If

                        If column.DataType = GetType(Double) Then
                            cmd.Parameters.Add($"@{column.ColumnName}", OleDbType.Double)
                        End If

                    Next

                    ' create field list for insert statement
                    Dim fieldNames = String.Join(",", dataTable.Columns.Cast(Of DataColumn).
                                                    Select(Function(col) col.ColumnName).ToArray())

                    ' create parameter list for insert statement
                    Dim paramNames = String.Join(",", dataTable.Columns.Cast(Of DataColumn).
                                                    Select(Function(col) "@" & col.ColumnName).ToArray())

                    Dim insertStatement = $"INSERT INTO People ({fieldNames}) VALUES ({paramNames})"
                    cmd.CommandText = insertStatement

                    Dim result = 0

                    Try
                        cn.Open()

                        For rowIndex = 0 To dataTable.Rows.Count - 1

                            For columnIndex As Integer = 0 To dataTable.Columns.Count - 1
                                cmd.Parameters(columnIndex).Value = dataTable.Rows(rowIndex).Item(columnIndex)
                            Next

                            result = cmd.ExecuteNonQuery()
                            mRowCount += result

                        Next
                    Catch ex As Exception
                        mHasException = True
                        mException = ex
                    End Try

                End Using
            End Using
        End Sub
    End Class
End Namespace