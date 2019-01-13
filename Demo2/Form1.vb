Public Class Form1
    Private operations As New DatabaseOperations
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        computerAssetListBox.DataSource = operations.GetComputerNames()
    End Sub
    Private Sub HandleSelectionChanged()
        Dim compUser = CType(computerAssetListBox.SelectedItem, ComputerAsset)
        userListBox.DataSource = compUser.FormerUsers
        assetIdentifierLabel.Text = $"Asset id: {compUser.AssetId}"
    End Sub
    Private Sub computerAssetListBox_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles computerAssetListBox.SelectedIndexChanged

        If computerAssetListBox.DataSource IsNot Nothing Then
            HandleSelectionChanged()
        End If
    End Sub
    Private Sub userListBox_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles userListBox.SelectedIndexChanged

        Dim currentUser = CType(userListBox.SelectedItem, User)
        userIdentifierLabel.Text = $"User id: {currentUser.UserId}"
    End Sub
End Class
