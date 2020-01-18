Public Class Form1
    Private bsProducts As New BindingSource
    Private operations As DataOperations = New DataOperations
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CategoryListBox.DataSource = operations.GetCategories
        bsProducts.DataSource = operations.GetProducts()
        DataGridView1.DataSource = bsProducts
        DataGridView1.Columns("ProductName").HeaderText = "Name"
        DataGridView1.Columns("UnitPrice").HeaderText = "Price"
        ProductIdTextBox.DataBindings.Add("Text", bsProducts, "ProductID")
        MovePosition()
    End Sub

    Private Sub CategoryListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CategoryListBox.SelectedIndexChanged
        MovePosition()
    End Sub
    Private Sub MovePosition()
        Dim categoryIdentifier = CType(CategoryListBox.SelectedItem, Category).Id
        bsProducts.Filter = $"CategoryID = {categoryIdentifier}"
        Console.WriteLine(bsProducts.Count)
    End Sub
End Class
