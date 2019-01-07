Imports KarensBaseClasses

Public Class Form2
    Implements IListener
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Broadcaster.AddListener(Me)
    End Sub
    Public Sub OnListen(Message As String) Implements IListener.OnListen
        '
    End Sub
    Private ReadOnly ExcludeName As List(Of String) = New List(Of String) From {"Form1", "Form2"}
    Public Sub OnListen(ClassName As String, Message As String) Implements IListener.OnListen
        If Not ExcludeName.Contains(Name) Then
            Console.WriteLine($"From {ClassName} Text {Message} Listening in {Name}")
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not String.IsNullOrWhiteSpace(TextBox1.Text) Then
            Broadcaster().Broadcast(Name, TextBox1.Text)
        End If
    End Sub
    Protected Overrides Sub Finalize()
        Broadcaster.RemoveListener(Me)
        MyBase.Finalize()
    End Sub
End Class