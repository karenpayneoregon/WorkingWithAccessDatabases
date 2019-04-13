Imports System.Data.OleDb
Imports KarensBaseClasses

Namespace Classes
    Public Class Operations
        Inherits AccessConnection
        Public Property PictureDataTable As DataTable
        Public Property CategoriesDataTable As DataTable
        Public Property ParkingDataTable As DataTable
        ''' <summary>
        ''' Add image to database table
        ''' </summary>
        ''' <param name="fileName">Full file name including path</param>
        ''' <param name="category">Key from Category table</param>
        ''' <param name="description">User description</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' Only option parameter is Description
        ''' </remarks>
        Public Function AddImage(fileName As String, category As Integer, description As String) As Boolean
            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText =
                        <SQL>
                    INSERT INTO Pictures 
                    (
                        Category,
                        Picture,
                        Description,
                        BaseName,
                        FileExtension
                    ) 
                    Values
                    (
                        @Category,
                        @Picture,
                        @Description,
                        @BaseName,
                        @FileExtension
                    )
                </SQL>.Value


                    cmd.Parameters.AddRange(
                        New OleDbParameter() {
                        New OleDbParameter With {.ParameterName = "@Category", .DbType = DbType.Int32, .Value = category},
                        New OleDbParameter With {.ParameterName = "@Picture", .OleDbType = OleDbType.Binary, .Value = FileImageBytes(fileName)},
                        New OleDbParameter With {.ParameterName = "@Description", .DbType = DbType.String, .Value = description},
                        New OleDbParameter With {.ParameterName = "@BaseName", .DbType = DbType.String, .Value = IO.Path.GetFileNameWithoutExtension(fileName).ToLower},
                        New OleDbParameter With {.ParameterName = "@FileExtension", .DbType = DbType.String, .Value = IO.Path.GetExtension(fileName).Replace(".", "").ToLower}
                               }
                        )

                    Try
                        cn.Open()
                        Dim affected As Integer = cmd.ExecuteNonQuery
                        If affected = 1 Then
                            Return True
                        Else
                            Return False
                        End If
                    Catch ex As Exception
                        Return False
                    End Try
                End Using
            End Using
        End Function

        Public Function AddImageFromPictureBoxForm(
           imageByteArray As Byte(),
           category As Integer,
           description As String,
           baseFileName As String,
           fileExtension As String) As Boolean

            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText =
                        <SQL>
                    INSERT INTO Pictures 
                    (
                        Category,
                        Picture,
                        Description,
                        BaseName,
                        FileExtension
                    ) 
                    Values
                    (
                        @Category,
                        @Picture,
                        @Description,
                        @BaseName,
                        @FileExtension
                    )
                </SQL>.Value


                    cmd.Parameters.AddRange(
                        New OleDbParameter() {New OleDbParameter With {.ParameterName = "@Category", .DbType = DbType.Int32, .Value = category},
                        New OleDbParameter With {.ParameterName = "@Picture", .OleDbType = OleDbType.Binary, .Value = imageByteArray},
                        New OleDbParameter With {.ParameterName = "@Description", .DbType = DbType.String, .Value = description},
                        New OleDbParameter With {.ParameterName = "@BaseName", .DbType = DbType.String, .Value = baseFileName},
                        New OleDbParameter With {.ParameterName = "@FileExtension", .DbType = DbType.String, .Value = fileExtension}
                            }
                        )

                    Try
                        cn.Open()
                        Dim affected As Integer = cmd.ExecuteNonQuery
                        If affected = 1 Then
                            Return True
                        Else
                            Return False
                        End If
                    Catch ex As Exception
                        Return False
                    End Try
                End Using
            End Using
        End Function
        Public Sub LoadImages()
            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText =
                        <SQL>
                    SELECT 
                        Identifier, 
                        Category
                    FROM 
                        Category
                    ORDER BY 
                        Category
                </SQL>.Value

                    CategoriesDataTable = New DataTable
                    cn.Open()
                    CategoriesDataTable.Load(cmd.ExecuteReader)

                    Dim dr As DataRow
                    dr = CategoriesDataTable.NewRow
                    dr("Identifier") = 0
                    dr("Category") = "ALL"
                    CategoriesDataTable.Rows.InsertAt(dr, 0)


                    cmd.CommandText =
                        <SQL>
                    SELECT 
                        Identifier, 
                        Category, 
                        Picture, 
                        Description, 
                        BaseName,
                        FileExtension,
                        BaseName + '.' + FileExtension As FullFileName
                    FROM 
                        Pictures;
                </SQL>.Value

                    PictureDataTable = New DataTable

                    PictureDataTable.Load(cmd.ExecuteReader)
                End Using
            End Using
        End Sub
        ''' <summary>
        ''' Quick example to get one row for a social forum post
        ''' </summary>
        ''' <param name="primarykey"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function LoadSingleImage(primarykey As Integer) As Tuple(Of String, Byte())

            Dim fileName As String = ""
            Dim imageBytes As Byte() = {}

            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText =
                        <SQL>
                    SELECT 
                        Identifier, 
                        Category, 
                        Picture, 
                        Description, 
                        BaseName,
                        FileExtension,
                        BaseName + '.' + FileExtension As FullFileName
                    FROM 
                        Pictures
                    WHERE Identifier = ?
                </SQL>.Value
                    cmd.Parameters.AddWithValue("?", primarykey)

                    Dim dt As New DataTable
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    imageBytes = dt.Rows(0).Field(Of Byte())("Picture")
                    fileName = dt.Rows(0).Field(Of String)("FullFileName")

                    Return New Tuple(Of String, Byte())(fileName, imageBytes)

                End Using
            End Using
        End Function
        Public Sub LoadParkingImages()

            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText =
                        <SQL>
                    SELECT 
                        Identifier, 
                        Category, 
                        Picture, 
                        Description, 
                        BaseName,
                        FileExtension,
                        BaseName + '.' + FileExtension As FullFileName
                    FROM 
                        Pictures
                    WHERE Category = 3
                </SQL>.Value

                    ParkingDataTable = New DataTable
                    cn.Open()
                    ParkingDataTable.Load(cmd.ExecuteReader)
                End Using
            End Using

        End Sub
        ''' <summary>
        ''' Set connection string and load images for main form's DataGridView
        ''' </summary>
        Public Sub New()
            DefaultCatalog = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Database1.accdb")
            LoadImages()
            'LoadParkingImages()
        End Sub
    End Class
End Namespace