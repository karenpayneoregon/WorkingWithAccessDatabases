Namespace My

    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
    Partial Friend Class _Dialogs
        ''' <summary>
        ''' Ask question with NO as the default button
        ''' </summary>
        ''' <param name="pQuestionText">Text for asking a question</param>
        ''' <returns>
        ''' True if yes button pressed, False if no button was selected 
        ''' or ESC pressed</returns>
        ''' <remarks></remarks>
        Public Function Question(pQuestionText As String) As Boolean

            Return (MessageBox.Show(
                pQuestionText,
                My.Application.Info.Title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes)

        End Function
    End Class

    <HideModuleName()>
    Friend Module KarensDialogs
        Private instance As New ThreadSafeObjectProvider(Of _Dialogs)
        ReadOnly Property Dialogs() As _Dialogs
            Get
                Return instance.GetInstance()
            End Get
        End Property
    End Module
End Namespace
