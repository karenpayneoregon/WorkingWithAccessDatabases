Namespace My
    <ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)>
    Partial Friend Class Dialogs
        Public Function Question(text As String) As Boolean
            Return (MessageBox.Show(text, My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes)
        End Function
        Public Function RemoveCurrentRecord() As Boolean
            Return Question("Remove current record?")
        End Function
    End Class

    <HideModuleName()>
    Friend Module KarensDialogs
        Private instance As New ThreadSafeObjectProvider(Of Dialogs)
        ReadOnly Property Dialogs() As Dialogs
            Get
                Return instance.GetInstance()
            End Get
        End Property
    End Module
End Namespace
