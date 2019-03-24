Imports System.Data.OleDb
Imports System.IO
Imports BaseConnectionLibrary.ConnectionClasses

Namespace Classes

    ''' <summary>
    ''' Responsible for obtain data from a MS-Access database table,
    ''' create a customer object, push it back to the caller using
    ''' an Iterator routine that pushes data back using Yield statement.
    ''' 
    ''' In the above process we are popping information to a Splash screen
    ''' via a delegate. We could do this in the caller but I see no reason
    ''' why for this simple demonstration.
    ''' </summary>
    ''' <remarks>
    ''' Since there are not many records Threading.Thread.Sleep(25) is used
    ''' to slow things down to see the results in the splash screen.
    ''' </remarks>
    Public Class DataAccess
        Inherits AccessConnection

        Private SplashScreenDelay As Integer = 0

        Public Sub New(SplashScreenDelay As Integer)

            DefaultCatalog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")

            CurrentIndex = 1

            Me.SplashScreenDelay = SplashScreenDelay

            GetRecordCount()

        End Sub
        Private _mRecordCount As Integer
        Public ReadOnly Property RecordCount As Integer
            Get
                Return _mRecordCount
            End Get
        End Property
        ''' <summary>
        ''' Get total records to be used with ProgressBar on SplashScreen
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub GetRecordCount()
            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}
                Using cmd As New OleDbCommand With {.Connection = cn}
                    cmd.CommandText = "SELECT Count(Identifier) FROM Customer"
                    cn.Open()
                    _mRecordCount = CInt(cmd.ExecuteScalar)
                End Using
            End Using
        End Sub
        Public Property CurrentIndex As Integer
        ''' <summary>
        ''' used to return customer data
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Iterator Function Retrieve() As IEnumerable(Of Customer)

            CurrentIndex = 0

            Dim customerIdentifierPosition As Integer = 0
            Dim customerNamePosition As Integer = 1
            Dim contactNamePosition As Integer = 2

            Using cn As New OleDbConnection With {.ConnectionString = ConnectionString}

                Using cmd As New OleDbCommand With
                    {
                    .Connection = cn,
                    .CommandText = "SELECT Identifier, CompanyName, ContactName FROM Customer;"
                    }

                    cn.Open()

                    Dim reader As OleDbDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        Dim companyName As String = ""

                        While reader.Read

                            companyName = reader.GetFieldValue(Of String)(customerNamePosition)

                            Yield New Customer With
                                {
                                .Identifier = reader.GetFieldValue(Of Integer)(customerIdentifierPosition),
                                .Company = companyName,
                                .ContactName = reader.GetFieldValue(Of String)(contactNamePosition)
                                }

                            Dim percentDone = CInt((CurrentIndex / RecordCount) * 100)
                            SplashScreen1.ShowRecordProgress(percentDone)
                            '
                            ' Only for working with a small amount of data
                            '
                            Threading.Thread.Sleep(SplashScreenDelay)

                            CurrentIndex += 1

                        End While

                    End If

                    reader.Close()

                End Using
            End Using

        End Function
    End Class
End Namespace