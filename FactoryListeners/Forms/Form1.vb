Imports KarensBaseClasses

Public Class Form1
    Implements IListener
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Broadcaster.AddListener(Me)
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim f4 As New FormAllListener
        f4.Show()
        f4.Top = Top
        f4.Left = (Left - f4.Width) - 10

        Broadcaster().Broadcast(Name, "Opened the all form")

        Dim ops As New Operations
        ops.BlowUp("Karen")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim f2 As New Form2
        f2.Show()
        f2.Left = (Left + Width) + 10
        f2.Top = Top

        Broadcaster().Broadcast(Name, "Opened the form2")

        Dim f3 = New Form3
        f3.Show()
        f3.Left = (Left + Width) + 10
        f3.Top = (f2.Top + f2.Height) + 10

        Broadcaster().Broadcast(Name, "Opened the form3")
        Broadcaster().Broadcast(Name, "All set!!!")

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            Broadcaster().Broadcast(Name, Now.ToShortDateString())
        Else
            Broadcaster().Broadcast(Name, TextBox1.Text)
        End If
    End Sub

    Public Sub OnListen(Message As String) Implements IListener.OnListen
        Console.WriteLine($"Form1: '{Message}'")
    End Sub
    Public Sub OnListen(ClassName As String, Message As String) Implements IListener.OnListen
        If ClassName = "Form2" Then
            TextBox1.Text = Message
        ElseIf ClassName = "Form3" Then
            MessageBox.Show(Message)
        End If
    End Sub
    Protected Overrides Sub Finalize()
        Broadcaster.RemoveListener(Me)
        MyBase.Finalize()
    End Sub

End Class
