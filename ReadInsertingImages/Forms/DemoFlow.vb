Imports System.IO
Imports UsingAccess_2007_BinaryField.Classes

Namespace Forms

    Public Class DemoFlowForm
        Private Sub DemoFlow_Load(sender As Object, e As EventArgs) _
            Handles MyBase.Load

            Dim myParent As frmMainForm = CType(Me.Owner, frmMainForm)
            AddHandler myParent.OnIterate, AddressOf Notifier


            Dim ops As New Operations
            ops.LoadImages()

            Dim dt As DataTable = ops.PictureDataTable

            For Each row As DataRow In dt.Rows
                Console.WriteLine(row.Field(Of Integer)("Identifier"))
                Dim pictureBox = New PictureBox With {
                        .Image = Image.FromStream(
                            New MemoryStream(row.Field(Of Byte())("Picture"))),
                        .Height = 200,
                        .Width = 200,
                        .Tag = row.Field(Of Integer)("Identifier"),
                        .SizeMode = PictureBoxSizeMode.Zoom
                        }


                FlowLayoutPanel1.Controls.Add(pictureBox)

            Next
        End Sub

        Private Sub Notifier(args As MonitorProgressArgs)
            Dim pictureBox = FlowLayoutPanel1.Controls.OfType(Of PictureBox).
                    FirstOrDefault(Function(pb) CInt(pb.Tag) = args.PictureIdentifier)

            If pictureBox IsNot Nothing Then
                Byte2Image(pictureBox.Image, args.ByteArray)
            End If
        End Sub
        Public Function ImageToByte(img As Image) As Byte()
            Dim converter As New ImageConverter()
            Return CType(converter.ConvertTo(img, GetType(Byte())), Byte())
        End Function
        Public Sub Byte2Image(ByRef NewImage As Image, ByteArray() As Byte)
            '
            Dim ImageStream As MemoryStream

            Try
                If ByteArray.GetUpperBound(0) > 0 Then
                    ImageStream = New MemoryStream(ByteArray)
                    NewImage = Image.FromStream(ImageStream)
                Else
                    NewImage = Nothing
                End If
            Catch ex As Exception
                NewImage = Nothing
            End Try
        End Sub
    End Class
End Namespace