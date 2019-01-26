Imports System.Threading
Public Class CustomersForm

    Private tokenSource As New CancellationTokenSource()
    Private token As CancellationToken = tokenSource.Token
    Private CurrentlyRunning As Boolean = False

    Private dt As New DataTable With {.TableName = "MyTable"}

    Public Delegate Sub UpdateDataTableDelegate(value As Object(), Message As String)
    ''' <summary>
    ''' value contains an array of values representing field values from
    ''' the backend database pushed here from DataAccess.LoadCustomers
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks>
    ''' I check for a column count which is three unless the operation was 
    ''' inadvertently cancelled i.e. closed form while populating rows.
    ''' </remarks>
    Public Sub UpDateDataTable(sender As Object(), Message As String)

        If InvokeRequired Then
            Invoke(New UpdateDataTableDelegate(AddressOf UpDateDataTable), sender, Message)
        Else
            If dt.Columns.Count > 0 Then
                dt.Rows.Add(sender)
                Label1.Text = Message
            End If
        End If
    End Sub
    Private Async Sub cmdLoad_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click
        Label1.Text = ""
        CurrentlyRunning = True
        dt.Rows.Clear()
        CustomersGrid.DataSource = dt

        Dim da As New DatabaseOperations

        For Each item As Object() In da.LoadCustomers(token)

            If token.IsCancellationRequested Then
                Exit For
            End If

            Await Task.Factory.StartNew(Sub() Threading.Thread.Sleep(1), token)

        Next

        If token.IsCancellationRequested Then
            tokenSource = New CancellationTokenSource()
            token = tokenSource.Token

            If chkClearRows.Checked Then
                dt.Rows.Clear()
            End If

        End If
    End Sub
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        If My.Dialogs.Question("Cancel loading of data?") Then
            CurrentlyRunning = False
            tokenSource.Cancel()
        End If
    End Sub
    Private Sub CustomersForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If CurrentlyRunning Then
            If Not token.IsCancellationRequested Then
                tokenSource.Cancel()
            End If
        End If
    End Sub
    Private Sub CustomersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dt.Columns.Add(New DataColumn With {.ColumnName = "Identifier", .DataType = GetType(Integer)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "FirstName", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "LastName", .DataType = GetType(String)})

        Label1.Text = ""

    End Sub
End Class
