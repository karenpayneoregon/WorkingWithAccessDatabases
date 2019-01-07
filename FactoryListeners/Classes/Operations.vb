Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports KarensBaseClasses

Public Class Operations
    Implements IListener
    Public Sub New(<CallerMemberName> Optional memberName As String = Nothing)

        Broadcaster.AddListener(Me)
        Broadcaster().Broadcast(memberName, $"Created {Me.GetType().Name}")

    End Sub
    Public Sub BlowUp(sender As Object, <CallerMemberName> Optional memberName As String = Nothing)
        Dim m As MethodBase = MethodBase.GetCurrentMethod()
        Try
            Dim OhSnap = CType(sender, Boolean)
        Catch ex As Exception
            Broadcaster().Broadcast($"{Me.GetType().Name}.{m.Name}", $"OhSnap: {ex.Message}")
        End Try
    End Sub
    Public Sub OnListen(Message As String) Implements IListener.OnListen
        ' Not used, here to show possibilities for simply sending a message
        ' while below who sent the message is broadcast along with the message.
    End Sub
    ''' <summary>
    ''' In this case only Form2 is the interested receiver, ignore all other forms.
    ''' </summary>
    ''' <param name="ClassName">Class or form name</param>
    ''' <param name="Message">Message to receive</param>
    Public Sub OnListen(ClassName As String, Message As String) Implements IListener.OnListen
        If ClassName = "Form2" Then
            Console.WriteLine($"From {ClassName} Text {Message} Listening in Operations instance")
        End If
    End Sub
End Class
