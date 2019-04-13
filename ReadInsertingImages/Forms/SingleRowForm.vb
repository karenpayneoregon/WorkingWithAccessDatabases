Imports UsingAccess_2007_BinaryField.Classes

Namespace Forms

    ''' <summary>
    ''' Done for Social forum post
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SingleRowForm
        Private Sub SingleRowForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

            Dim ops As New Operations
            Dim result = ops.LoadSingleImage(10)

            Label1.Text = result.Item1
            PictureBox1.Image = Image.FromStream(New IO.MemoryStream(result.Item2))

        End Sub
    End Class
End Namespace