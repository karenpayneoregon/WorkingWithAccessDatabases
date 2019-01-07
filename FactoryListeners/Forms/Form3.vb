Imports KarensBaseClasses

Public Class Form3
    Implements IListener
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Broadcaster.AddListener(Me)
        ComboBox1.SelectedIndex = 0
    End Sub
    Public Sub OnListen(Message As String) Implements IListener.OnListen
        '
    End Sub
    Public Sub OnListen(ClassName As String, Message As String) Implements IListener.OnListen
        If Not ClassName.Equals(Name) Then
            Console.WriteLine($"From {ClassName} Text {Message} Listening in {Name}")
        End If
    End Sub
    Protected Overrides Sub Finalize()
        Broadcaster.RemoveListener(Me)
        MyBase.Finalize()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Broadcaster().Broadcast(Name, ComboBox1.Text)
    End Sub
End Class