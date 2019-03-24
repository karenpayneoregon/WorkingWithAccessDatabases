Imports DemoSplashScreen.Classes
Imports DemoSplashScreen.ExtensionMethods

Public Class Form1
    ''' <summary>
    ''' Here we populate a unbound DataGridView to keep it simple but with a 
    ''' little effort can be setup so that the DataGridView DataSource is
    ''' a List(Of Customer) or a DataTable.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim da As New DataAccess(100)

        For Each item In da.Retrieve
            DataGridView1.Rows.Add(item.ItemArray)
        Next

        ' optional
        DataGridView1.ExpandColumns()
    End Sub
End Class
