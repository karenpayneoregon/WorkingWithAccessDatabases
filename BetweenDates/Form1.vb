Imports BetweenDates.Classes

Public Class Form1
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim ops As New DatabaseOperations
        Dim dt = ops.LoadOrders("Around the Horn", #12/18/1995#, #4/2/1996#)
        DataGridView1.DataSource = dt
    End Sub
End Class
