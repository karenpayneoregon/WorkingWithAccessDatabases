Public Module Factory
    <DebuggerStepThrough()> Public Function Broadcaster() As BroadcasterClass
        Static _Broadcaster As BroadcasterClass
        If (_Broadcaster Is Nothing) Then
            _Broadcaster = New BroadcasterClass()
        End If

        Return _Broadcaster
    End Function
End Module

