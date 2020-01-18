Imports System.Data.OleDb
Imports System.IO
Imports KarensBaseClasses

Public Class DataOperations
    Inherits AccessConnection

    Public Sub New()
        DefaultCatalog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
    End Sub
    Public Function GetCategories() As List(Of Category)
        Dim list As New List(Of Category)
        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}

                cmd.CommandText = "SELECT CategoryID, CategoryName FROM Categories;"

                cn.Open()

                Dim reader = cmd.ExecuteReader()

                While reader.Read()
                    list.Add(New Category() With {.Id = reader.GetInt32(0), .Name = reader.GetString(1)})
                End While

            End Using
        End Using

        Return list

    End Function
    Public Function GetProducts() As DataTable
        Dim table As New DataTable
        Using cn As New OleDbConnection(ConnectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}

                cmd.CommandText = "SELECT ProductID, ProductName, CategoryID, UnitPrice FROM Products;"

                cn.Open()

                table.Load(cmd.ExecuteReader())
                table.Columns("CategoryID").ColumnMapping = MappingType.Hidden
                table.Columns("ProductID").ColumnMapping = MappingType.Hidden


            End Using
        End Using

        Return table

    End Function
End Class
