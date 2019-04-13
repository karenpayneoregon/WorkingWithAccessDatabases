Imports System.IO

Namespace Classes
    Public Module ConversionModule
        ''' <summary>
        ''' Saves bytes to a new image file
        ''' </summary>
        ''' <param name="pImageData"></param>
        ''' <param name="pFilePath"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConvertBytesToImageFile(pImageData As Byte(), pFilePath As String) As Boolean
            Try
                Dim fileStream = New FileStream(pFilePath, FileMode.OpenOrCreate, FileAccess.Write)
                Dim binaryWriter = New BinaryWriter(fileStream)

                binaryWriter.Write(pImageData)
                binaryWriter.Flush()
                binaryWriter.Close()
                fileStream.Close()
                binaryWriter = Nothing
                fileStream.Dispose()

                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function
        ''' <summary>
        ''' Return a byte array for a file, in this demo a image file
        ''' used in the DataAccess.vb file to add new records to the database
        ''' </summary>
        ''' <param name="pFileName">Physical file to get bytes from for image operations</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FileImageBytes(pFileName As String) As Byte()
            Dim fileStream = New FileStream(pFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim imageStream = New StreamReader(fileStream)
            Dim byteArray(CInt(fileStream.Length - 1)) As Byte

            fileStream.Read(byteArray, 0, CInt(fileStream.Length))

            Return byteArray

        End Function
    End Module
End Namespace