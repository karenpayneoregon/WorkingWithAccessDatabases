Imports System.Data.OleDb
Imports System.IO
Imports KarensBaseClasses

Public Class DataOperations
    Inherits AccessConnection

    Public Sub New()
        DefaultCatalog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.accdb")
    End Sub
    ''' <summary>
    ''' Return all rows, hide primary key
    ''' </summary>
    ''' <returns></returns>
    Public Function ReadAll() As DataTable
        Dim dt As New DataTable
        Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = "SELECT Identifier, FileName, Comment FROM Table1"

                cn.Open()

                dt.Load(cmd.ExecuteReader)

            End Using
        End Using

        dt.Columns("Identifier").ColumnMapping = MappingType.Hidden

        Return dt

    End Function
    ''' <summary>
    ''' Change comment for a record
    ''' </summary>
    ''' <param name="pRow"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' An empty comment is allow.
    ''' </remarks>
    Public Function UpdateRecord(pRow As DataRow) As Boolean
        Dim success As Boolean = False

        Try
            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText = "UPDATE Table1 SET FileName = @FileName, Comment = @Comment WHERE Identifier = @id"
                    cmd.Parameters.AddWithValue("@FileName", pRow.Field(Of String)("FileName"))
                    cmd.Parameters.AddWithValue("@Comment", pRow.Field(Of String)("Comment"))
                    cmd.Parameters.AddWithValue("@id", pRow.Field(Of Integer)("Identifier"))

                    cn.Open()

                    success = cmd.ExecuteNonQuery = 1

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
    ''' Remove a record by primary key
    ''' </summary>
    ''' <param name="pIdentifier">Primary key</param>
    ''' <returns></returns>
    Public Function RemoveRecord(pIdentifier As Integer) As Boolean
        Dim success As Boolean = False

        Try
            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText = "DELETE FROM Table1 WHERE  Identifier = @id"
                    cmd.Parameters.AddWithValue("@Id", pIdentifier)

                    cn.Open()

                    success = cmd.ExecuteNonQuery = 1

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
    ''' Insert an array of files into the database
    ''' Done synchronize
    ''' </summary>
    ''' <param name="pFiles">Files to insert with full path</param>
    ''' <param name="pCount">Used to give a count of inserted files back to the caller</param>
    ''' <returns></returns>
    Public Function InsertFilesBatch(pFiles As IEnumerable(Of String), ByRef pCount As Integer) As Boolean
        Dim success As Boolean = False

        Try

            Dim fileStream As FileStream = Nothing
            Dim reader As BinaryReader = Nothing
            Dim contentBytes() As Byte = Nothing

            Dim insertStatement = "INSERT INTO Table1 (FileName, Contents,Comment) " &
                                  "VALUES(@FileName,@Contents,@Comment)"

            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn, .CommandText = insertStatement}

                    cmd.Parameters.Add("@FileName", OleDbType.WChar)
                    cmd.Parameters.Add("@Contents", OleDbType.LongVarBinary)
                    cmd.Parameters.Add("@Comment", OleDbType.WChar)

                    cn.Open()

                    For Each file In pFiles
                        fileStream = New FileStream(file, IO.FileMode.Open, IO.FileAccess.Read)
                        reader = New BinaryReader(fileStream)
                        contentBytes = reader.ReadBytes(CInt(fileStream.Length))

                        cmd.Parameters("@FileName").Value = IO.Path.GetFileName(file)
                        cmd.Parameters("@Contents").Value = contentBytes
                        cmd.Parameters("@Comment").Value = $"Just added {file}"
                        cmd.ExecuteNonQuery()

                        reader = Nothing
                        fileStream.Close()

                        pCount += 1

                    Next

                    success = True

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
    ''' Insert an existing file
    ''' Asynchronously
    ''' </summary>
    ''' <param name="pFileName">full path and file name</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' I tried some very large files and had failures that did not throw any exception so 
    ''' in the caller in MainForm there is a check for file size, if over a specific size
    ''' we never call this method.
    ''' </remarks>
    Public Async Function InsertFile(pFileName As String, Optional pComment As String = "Added by app") As Task(Of Integer)
        Dim result As Integer = -1
        Dim newIdentifier As Integer = -1

        Try
            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn}
                    Dim dr As OleDbDataReader = Nothing

                    Dim fileStream As FileStream
                    Dim reader As BinaryReader = Nothing
                    Dim contentBytes() As Byte = Nothing

                    fileStream = New FileStream(pFileName, FileMode.Open, FileAccess.Read)
                    reader = New BinaryReader(fileStream)
                    contentBytes = reader.ReadBytes(CInt(fileStream.Length))

                    cn.Open()

                    Dim insertStatement = "INSERT INTO Table1 (FileName, Contents,Comment) " &
                                          "VALUES(@FileName,@Contents,@Comment)"

                    cmd.CommandText = insertStatement
                    cmd.Connection = cn

                    cmd.Parameters.Add("@FileName", OleDbType.WChar)
                    cmd.Parameters(0).Value = Path.GetFileName(IO.Path.GetFileName(pFileName))
                    cmd.Parameters.Add("@Contents", OleDbType.LongVarBinary)
                    cmd.Parameters.AddWithValue("@Comment", pComment)
                    cmd.Parameters(1).Value = contentBytes

                    '
                    ' insert record
                    '
                    Await Task.Run(Sub()
                                       result = cmd.ExecuteNonQuery
                                   End Sub)

                    '
                    ' get newly added record's primary key
                    '
                    If result = 1 Then
                        cmd.CommandText = "Select @@Identity"
                        newIdentifier = CInt(cmd.ExecuteScalar)
                        result = newIdentifier
                    End If

                End Using
            End Using
        Catch ex As AggregateException
            mHasException = True
            mLastException = ex
            result = -1
        End Try

        Return result

    End Function
    ''' <summary>
    ''' Extract file by primary key
    ''' </summary>
    ''' <param name="pIdentifier">Primary key to locate record by</param>
    ''' <param name="pFileName">Full path and file name to extract binary data too</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Common method to know the primary key is from first reading data and returning 
    ''' at least the primary key
    ''' Example
    ''' SELECT Identifier FROM Table1 WHERE FileName = @FileName
    ''' Where @FileName contains the name of the file w/o the path
    ''' 
    ''' * As coded, the extracted file will have a date-time of the extraction.
    ''' * The caller in this code sample has the output folder hard-coded.
    ''' </remarks>
    Public Function ExtractSingleFile(pIdentifier As Integer, pFileName As String) As Boolean
        Dim success As Boolean = False

        Try
            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn}

                    cmd.CommandText = "SELECT Contents FROM Table1 Where Identifier=@Identifier"
                    cmd.Parameters.AddWithValue("@Identifier", pIdentifier)
                    Dim dr As OleDbDataReader = Nothing

                    Dim fileStream As IO.FileStream
                    Dim reader As OleDbDataReader
                    Dim writer As BinaryWriter = Nothing
                    Dim bufferSize As Integer = 1000

                    Dim buffer(bufferSize - 1) As Byte

                    Dim startIndex As Long = 0
                    Dim numberOfBytes As Long = 0

                    cn.Open()

                    reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
                    reader.Read()

                    fileStream = New FileStream(pFileName, FileMode.OpenOrCreate, FileAccess.Write)

                    writer = New IO.BinaryWriter(fileStream)

                    Do
                        numberOfBytes = reader.GetBytes(0, startIndex, buffer, 0, bufferSize)
                        If numberOfBytes = 0 Then
                            Exit Do
                        End If
                        writer.Write(buffer, 0, CInt(Fix(numberOfBytes)))
                        startIndex += numberOfBytes
                    Loop While True

                    writer.Flush()

                    If writer IsNot Nothing Then
                        writer.Close()
                    End If

                    If fileStream IsNot Nothing Then
                        fileStream.Close()
                    End If

                    If reader IsNot Nothing Then
                        reader.Close()
                    End If

                    success = True

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
    ''' Used to determine for this code sample if the batch insert was performed in
    ''' MainForm.Load
    ''' </summary>
    ''' <returns></returns>
    Public Function RowCount() As Integer
        Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
            Using cmd As New OleDbCommand With {.Connection = cn, .CommandText = "SELECT Count(FileName) FROM Table1"}
                cn.Open()
                Return CInt(cmd.ExecuteScalar)
            End Using
        End Using
    End Function

End Class
