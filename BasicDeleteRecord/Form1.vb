Imports System.ComponentModel

Public Class Form1
    Private _customersBindingList As New BindingList(Of Category)()

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _customersBindingList = New BindingList(Of Category)(DataOperations.ReadCategories())
        CategoryComboBox.DataSource = _customersBindingList
    End Sub
    Private Sub DeleteSelectedButton_Click(sender As Object, e As EventArgs) Handles DeleteSelectedButton.Click
        If DataOperations.RemoveCategory(_customersBindingList.Item(CategoryComboBox.SelectedIndex).CategoryID) Then
            _customersBindingList.RemoveAt(CategoryComboBox.SelectedIndex)
        End If
    End Sub
End Class
