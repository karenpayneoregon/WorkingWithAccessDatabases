Public Class BroadcasterClass
    Private FListeners As New Collection()
    ''' <summary>
    ''' Send message
    ''' </summary>
    ''' <param name="Message">Message</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> Sub Broadcast(Message As String)
        Dim listener As IListener
        For Each listener In FListeners
            listener.OnListen(Message)
        Next
    End Sub
    ''' <summary>
    ''' Sender is FormName and a message
    ''' </summary>
    ''' <param name="ClassName">Class or form name</param>
    ''' <param name="Message">Message to broadcast</param>
    ''' <remarks></remarks>
    <DebuggerStepThrough()> Sub Broadcast(ClassName As String, Message As String)
        Dim listener As IListener
        For Each listener In FListeners
            listener.OnListen(ClassName, Message)
        Next
    End Sub
    ''' <summary>
    ''' Add a Listener to the Collection of Listeners
    ''' </summary>
    ''' <param name="Listener"></param>
    <DebuggerStepThrough()> Sub AddListener(Listener As IListener)
        FListeners.Add(Listener)
    End Sub
    ''' <summary>
    ''' Remove a Listener from the collection
    ''' </summary>
    ''' <param name="Listener"></param>
    <DebuggerStepThrough()> Sub RemoveListener(Listener As IListener)
        For index = 1 To FListeners.Count
            If (FListeners(index).Equals(Listener)) Then
                FListeners.Remove(index)
                Exit For
            End If
        Next
    End Sub
End Class
