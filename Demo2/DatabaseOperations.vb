Imports System.Data.OleDb

Public Class DatabaseOperations
    Inherits AccessConnection

    Public Sub New()
        DefaultCatalog = IO.Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb")
    End Sub

    Public Function GetComputerNames() As List(Of ComputerAsset)

        Dim results = New List(Of ComputerAsset)

        mHasException = False

        Dim selectComputerStatement = "SELECT AssetId, UserName, ComputerName, ServiceTag FROM ComputerAsset;"
        Dim selectUserStatement = "SELECT UserId, AssetId, UserName FROM [User] WHERE AssetId = @AssetId;"

        Dim assetId As Integer = 0

        Using cn As New OleDbConnection(ConnectionString)
            Using cmdComputer As New OleDbCommand With {.Connection = cn}

                cmdComputer.CommandText = selectComputerStatement

                Try

                    cn.Open()

                    Dim readerComputer = cmdComputer.ExecuteReader()

                    While readerComputer.Read()

                        assetId = readerComputer.GetInt32(0)

                        Dim currentComputer = New ComputerAsset() With
                                {
                                    .AssetId = assetId,
                                    .UserName = readerComputer.GetString(1),
                                    .ComputerName = readerComputer.GetString(2),
                                    .ServiceTag = readerComputer.GetString(3)
                                }

                        results.Add(currentComputer)

                        Using cmdUser As New OleDbCommand With {.Connection = cn}

                            cmdUser.CommandText = selectUserStatement
                            cmdUser.Parameters.AddWithValue("@AssetId", assetId)

                            Dim readerUser = cmdUser.ExecuteReader()

                            While readerUser.Read()

                                currentComputer.FormerUsers.Add(New User() With
                                        {
                                           .AssetId = assetId,
                                           .UserId = readerUser.GetInt32(0),
                                           .Name = readerUser.GetString(2)
                                        })

                            End While

                        End Using
                    End While
                Catch ex As Exception
                    mHasException = True
                    mLastException = ex
                End Try
            End Using
        End Using


        Return results

    End Function

End Class
