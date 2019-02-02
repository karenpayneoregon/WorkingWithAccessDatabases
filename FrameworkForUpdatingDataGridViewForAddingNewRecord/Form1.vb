Imports BackEnd

Public Class Form1
    Private bsData As New BindingSource
    Private ReadOnly ops As New DatabaseOperations

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        bsData.DataSource = ops.LoadCustomersWithoutPassword()
        DataGridView1.DataSource = bsData
        BindingNavigator1.BindingSource = bsData
    End Sub

    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        Dim items = Panel1.Controls.OfType(Of TextBox).Any(Function(textBox) String.IsNullOrWhiteSpace(textBox.Text))

        If Panel1.Controls.OfType(Of TextBox).Any(Function(textBox) String.IsNullOrWhiteSpace(textBox.Text)) Then
            MessageBox.Show("Please populate all TextBoxes")
            Exit Sub
        End If

        If Not String.IsNullOrWhiteSpace(CompanyNameTextBox.Text) Then
            Dim identifier As Integer = 0
            If ops.AddNewRowWithoutPassword(CompanyNameTextBox.Text, ContactNameTextBox.Text, contactTitleTextBox.Text, identifier) Then
                CType(bsData.DataSource, DataTable).Rows.Add(New Object() {identifier, CompanyNameTextBox.Text, ContactNameTextBox.Text, contactTitleTextBox.Text})
                bsData.MoveLast()
            End If

        End If
    End Sub
End Class
