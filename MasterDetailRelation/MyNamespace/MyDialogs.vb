Namespace My
    <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> _
    Partial Friend Class _Dialogs
        ''' <summary>
        ''' Ask question with NO as the default button
        ''' </summary>
        ''' <param name="Text"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Question(Text As String) As Boolean
            Return (MessageBox.Show(Text, My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes)
        End Function
        Public Function Question(Text As String, Title As String) As Boolean
            Return (MessageBox.Show(Text, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes)
        End Function
        ''' <summary>
        ''' Ask question
        ''' </summary>
        ''' <param name="Text">Question to ask</param>
        ''' <param name="Title">Text for dialog caption</param>
        ''' <param name="DefaultButton">Which button is the default</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Question(Text As String, Title As String, DefaultButton As MsgBoxResult) As Boolean
            Dim db As MessageBoxDefaultButton
            If DefaultButton = MsgBoxResult.No Then
                db = MessageBoxDefaultButton.Button2
            End If
            Return (MessageBox.Show(Text, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, db) = MsgBoxResult.Yes)
        End Function
        ''' <summary>
        ''' Shows text in dialog with information icon
        ''' </summary>
        ''' <param name="Text">Message to display</param>
        ''' <remarks></remarks>
        Public Sub InformationDialog(Text As String)
            MessageBox.Show(Text, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        ''' <summary>
        ''' Shows text in dialog with information icon
        ''' </summary>
        ''' <param name="Text">Message to display</param>
        ''' <param name="Title"></param>
        ''' <remarks></remarks>
        Public Sub InformationDialog(Text As String, Title As String)
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        Public Sub WarningDialog(Text As String)
            MessageBox.Show(Text, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub
        Public Sub WarningDialog(Text As String, Title As String)
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub
        ''' <summary>
        ''' For displaying error/exception text with Error icon
        ''' </summary>
        ''' <param name="Text"></param>
        ''' <remarks></remarks>
        Public Sub ExceptionDialog(Text As String)
            MessageBox.Show(Text, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
        ''' <summary>
        ''' For displaying error/exception text with Error icon
        ''' </summary>
        ''' <param name="Text"></param>
        ''' <param name="Title"></param>
        ''' <remarks></remarks>
        Public Sub ExceptionDialog(Text As String, Title As String)
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
        Public Sub ExceptionDialog(Text As String, Title As String, ex As Exception)
            Dim Message As String = String.Concat(Text, Environment.NewLine, ex.Message)
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ex"></param>
        ''' <param name="Text"></param>
        ''' <param name="Title"></param>
        ''' <remarks>
        ''' </remarks>
        Public Sub ExceptionDialog(ex As Exception, Text As String, Title As String)
            MessageBox.Show($"{Text }{Environment.NewLine }{ex.Message }", Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub

    End Class
    <HideModuleName()>
    Friend Module KarenPayneDialogs
        Private instance As New ThreadSafeObjectProvider(Of _Dialogs)
        ReadOnly Property Dialogs() As _Dialogs
            Get
                Return instance.GetInstance()
            End Get
        End Property
    End Module
End Namespace
