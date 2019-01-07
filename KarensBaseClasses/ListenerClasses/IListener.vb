Public Interface IListener
    Sub OnListen(Message As String)
    Sub OnListen(ClassName As String, Message As String)
End Interface
