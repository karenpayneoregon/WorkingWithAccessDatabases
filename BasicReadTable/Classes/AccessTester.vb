Option Strict On
Option Infer On

Imports System.Data.OleDb
Imports System.IO

Namespace Classes

    Public Class AccessTester
        ''' <summary>
        ''' Simple method to test a connection
        ''' </summary>
        ''' <returns></returns>
        Public Shared Async Function TestConnection() As Task(Of Boolean)
            Dim ConnectionString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb"

            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Try
                    Await cn.OpenAsync()
                    Return True
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    Return False
                End Try
            End Using

        End Function
    End Class
End Namespace