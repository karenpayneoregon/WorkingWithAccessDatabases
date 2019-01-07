Imports KarensBaseClasses

Public Class FormAllListener
    Implements IListener
    Private Sub FormAllListener_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Broadcaster.AddListener(Me)
    End Sub
    Public Sub OnListen(Message As String) Implements IListener.OnListen

    End Sub
    Public Sub OnListen(ClassName As String, Message As String) Implements IListener.OnListen
        ListBox1.Items.Add($"{ClassName} Text {Message} Listening in {Name}")
        ListBox1.SelectedIndex = ListBox1.Items.Count - 1
    End Sub
    Protected Overrides Sub Finalize()
        Broadcaster.RemoveListener(Me)
        MyBase.Finalize()
    End Sub
End Class