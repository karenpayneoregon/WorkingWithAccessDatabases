''' <summary>
''' Setup currently to show a progressbar.
''' To use the spinner or the label make them visible
''' and the progress bar set visible to false.
''' </summary>
Public Class SplashScreen1
    Public Delegate Sub UpdateRecordDelegate(value As Integer)
    Public Sub ShowRecordProgress(sender As Integer)
        If InvokeRequired Then
            Invoke(New UpdateRecordDelegate(AddressOf ShowRecordProgress), sender)
        Else
            'Label1.Text = sender.ToString & " percent complete"
            ProgressBar1.Value = sender + 1
        End If
    End Sub
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
End Class