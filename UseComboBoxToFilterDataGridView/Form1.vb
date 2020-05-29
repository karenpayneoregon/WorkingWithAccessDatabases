Imports UseComboBoxToFilterDataGridView.Classes
Imports UseComboBoxToFilterDataGridView.ExtensionMethods

Public Class Form1
    Private ops As New DatabaseOperations
    Private bsProducts As New BindingSource
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        categoryComboBox.DataSource = ops.LoadCategories
        DataGridView1.DataSource = bsProducts

    End Sub

    Private Sub selectProductCategoryButton_Click(sender As Object, e As EventArgs) Handles selectProductCategoryButton.Click
        Dim category As Category = CType(categoryComboBox.SelectedItem, Category)

        If category.CategoryID > -1 Then
            bsProducts.DataSource = ops.LoadProductsByCategory(category.CategoryID)
            For Each column As DataGridViewColumn In DataGridView1.Columns
                column.HeaderText = column.HeaderText.SplitCamelCase()
            Next
            DataGridView1.ExpandColumns()
        Else
            MessageBox.Show("Please select a category")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not String.IsNullOrWhiteSpace(SearchForTextBox.Text) Then
            Dim product = DatabaseOperations.LoadProduct(SearchForTextBox.Text)
            MessageBox.Show(product.ToString())
        End If
    End Sub
End Class
