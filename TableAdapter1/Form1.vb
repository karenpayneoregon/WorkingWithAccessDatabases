Public Class Form1
    Private Sub EmployeesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles EmployeesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.EmployeesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Database1DataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet.Employees' table. You can move, or remove it, as needed.
        Me.EmployeesTableAdapter.Fill(Me.Database1DataSet.Employees)

    End Sub

    Private Sub DeleteAllButton_Click(sender As Object, e As EventArgs) Handles DeleteAllButton.Click
        Dim results = EmployeesTableAdapter.DeleteQuery()

        If results > 0 Then
            MessageBox.Show($"{results} records delete")
        End If
    End Sub
End Class
