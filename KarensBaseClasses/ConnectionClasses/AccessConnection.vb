Imports System.Data.OleDb

Public Class AccessConnection
    Inherits BaseExceptionProperties
    Implements IConnection

    Private ReadOnly _builder As New OleDbConnectionStringBuilder With
        {
            .Provider = "Microsoft.ACE.OLEDB.12.0"
        }
    ''' <summary>
    ''' Database name and path
    ''' </summary>
    Protected DefaultCatalog As String = ""
    Public ReadOnly Property ConnectionString As String Implements IConnection.ConnectionString
        Get

            If String.IsNullOrWhiteSpace(DefaultCatalog) Then
                Throw New Exception("Database name and path not provided.")
            End If

            _builder.DataSource = DefaultCatalog

            Return _builder.ConnectionString

        End Get
    End Property
    Public Property ConnectionStringWithPassword() As String
End Class
