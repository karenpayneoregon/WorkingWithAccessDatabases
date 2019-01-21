Public Class Form1
    Private bsCustomers As New BindingSource
    Private Sub Form1_Shown(sender As Object, e As EventArgs) _
    Handles Me.Shown

        Dim ops As New DatabaseOperations

        If ops.IsSuccessFul Then
            bsCustomers.DataSource = ops.LoadCustomers
            DataGridView1.DataSource = bsCustomers
            BindingNavigator1.BindingSource = bsCustomers
        Else
            MessageBox.Show(ops.LastExceptionMessage)
        End If

    End Sub
End Class
