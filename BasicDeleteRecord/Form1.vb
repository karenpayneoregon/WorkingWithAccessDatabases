Imports System.ComponentModel
Imports BasicDeleteRecord.Classes

Public Class Form1
    Private _categoryBindingList As New BindingList(Of Category)()

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        _categoryBindingList = New BindingList(Of Category)(DataOperations.ReadCategories())
        CategoryComboBox.DataSource = _categoryBindingList
    End Sub
    Private Sub DeleteSelectedButton_Click(sender As Object, e As EventArgs) Handles DeleteSelectedButton.Click
        If DataOperations.RemoveCategory(_categoryBindingList.Item(CategoryComboBox.SelectedIndex).CategoryID) Then
            _categoryBindingList.RemoveAt(CategoryComboBox.SelectedIndex)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _categoryBindingList.Item(CategoryComboBox.SelectedIndex).CategoryName = "Karen"
        _categoryBindingList.Insert(0, New Category() With {.CategoryName = "add"})
        _categoryBindingList.RemoveAt(CategoryComboBox.SelectedIndex)
    End Sub
End Class
