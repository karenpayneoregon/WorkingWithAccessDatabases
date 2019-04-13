Imports System.IO
Imports UsingAccess_2007_BinaryField.Classes

Namespace Forms

    Public Class DemoFlowForm
        Private Sub DemoFlow_Load(sender As Object, e As EventArgs) _
            Handles MyBase.Load

            Dim ops As New Operations
            ops.LoadImages()

            Dim dt As DataTable = ops.PictureDataTable

            For Each row As DataRow In dt.Rows

                Dim pictureBox = New PictureBox With {
                        .Image = Image.FromStream(
                            New MemoryStream(row.Field(Of Byte())("Picture"))),
                        .Height = 200,
                        .Width = 200,
                        .SizeMode = PictureBoxSizeMode.Zoom
                        }


                FlowLayoutPanel1.Controls.Add(pictureBox)

            Next
        End Sub
    End Class
End Namespace