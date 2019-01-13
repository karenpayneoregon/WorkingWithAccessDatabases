Namespace DataHelpers
    Public Module CommandPeeker
        ''' <summary>
        ''' Provides the ability to view a parameterized query values when using parameter names
        ''' such as @CompanyName but will not work with a parameter simply named ?.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="token">Alternate parameter start token</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Runtime.CompilerServices.Extension()>
        Public Function ActualCommandTextByNames(ByVal sender As IDbCommand, Optional token As String = "@") As String
            Dim sb As New System.Text.StringBuilder(sender.CommandText)
            Dim emptyParameterNames = (From T In sender.Parameters.Cast(Of IDataParameter)() Where String.IsNullOrWhiteSpace(T.ParameterName)).FirstOrDefault

            If emptyParameterNames IsNot Nothing Then
                Return sender.CommandText
            End If

            For Each p As IDataParameter In sender.Parameters

                Select Case p.DbType
                    Case DbType.AnsiString, DbType.AnsiStringFixedLength, DbType.Date, DbType.DateTime, DbType.DateTime2, DbType.Guid, DbType.String, DbType.StringFixedLength, DbType.Time, DbType.Xml
                        If p.ParameterName(0) = token Then
                            If p.Value Is Nothing Then
                                Throw New Exception("no value given for parameter '" & p.ParameterName & "'")
                            End If
                            sb = sb.Replace(p.ParameterName, $"'{p.Value.ToString.Replace("'", "''")}'")
                        Else
                            sb = sb.Replace(String.Concat(token, p.ParameterName), $"'{p.Value.ToString.Replace("'", "''")}'")
                        End If
                    Case Else
                        sb = sb.Replace(p.ParameterName, p.Value.ToString)
                End Select
            Next
            Return sb.ToString
        End Function

    End Module
End Namespace