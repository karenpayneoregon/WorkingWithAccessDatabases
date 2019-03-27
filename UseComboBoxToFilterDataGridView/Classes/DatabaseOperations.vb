Imports System.Data.OleDb
Imports System.IO
Imports KarensBaseClasses

Namespace Classes
    Public Class DatabaseOperations
        Inherits AccessConnection
        ''' <summary>
        ''' Setup ConnectionString which is in KarensBaseClasses project.
        ''' </summary>
        Public Sub New()
            DefaultCatalog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NorthWind_1.accdb")
        End Sub
        ''' <summary>
        ''' Get a list of categories along with the first category setup to use 
        ''' in a ComboBox to permit users to select categories from.
        ''' </summary>
        ''' <returns></returns>
        Public Function LoadCategories() As List(Of Category)
            Dim catList As New List(Of Category)
            catList.Add(New Category() With {.CategoryID = -1, .CategoryName = "Select"})

            Dim selectStatement = "SELECT CategoryID, CategoryName FROM Categories;"

            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.CommandText = selectStatement, .Connection = cn}
                    cn.Open()
                    Dim reader = cmd.ExecuteReader()
                    While reader.Read()
                        catList.Add(New Category() With {.CategoryID = reader.GetInt32(0), .CategoryName = reader.GetString(1)})
                    End While
                End Using
            End Using

            Return catList
        End Function
        ''' <summary>
        ''' Load partial list of products and supplier data by category identifier
        ''' </summary>
        ''' <param name="pCategoryIdentifier"></param>
        ''' <returns></returns>
        Public Function LoadProductsByCategory(pCategoryIdentifier As Integer) As DataTable

            Dim dt As New DataTable
            Dim selectStatement =
                    <SQL>
                        SELECT 
                            Products.ProductID, 
                            Products.ProductName, 
                            Suppliers.CompanyName, 
                            Suppliers.Phone, 
                            Products.CategoryID 
                        FROM Suppliers INNER JOIN Products ON Suppliers.SupplierID = Products.SupplierID 
                        WHERE Products.CategoryID=@CategoryIdentifier;
                    </SQL>.Value

            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.CommandText = selectStatement, .Connection = cn}
                    cn.Open()

                    cmd.Parameters.AddWithValue("@CategoryIdentifier", pCategoryIdentifier)
                    dt.Load(cmd.ExecuteReader())
                    dt.Columns("ProductID").ColumnMapping = MappingType.Hidden
                    dt.Columns("CategoryID").ColumnMapping = MappingType.Hidden
                End Using
            End Using

            Return dt

        End Function
    End Class
End Namespace