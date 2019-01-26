Public Class Form1
    Delegate Sub SetDataTable(ByVal dt As DataTable)
    Private dataOperations As New DatabaseOperations
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) _
        Handles BackgroundWorker1.DoWork

        LoadDataTable(dataOperations.LoadPeople())

    End Sub
    Private Sub LoadDataTable(dt As DataTable)
        If DataGridView1.InvokeRequired Then 'Invoke if required...
            Dim d As New SetDataTable(AddressOf LoadDataTable)
            Invoke(d, New Object() {dt})
        Else
            DataGridView1.DataSource = dt
            DataGridView1.ClearSelection()
            Console.WriteLine(Now)
        End If
    End Sub
End Class
