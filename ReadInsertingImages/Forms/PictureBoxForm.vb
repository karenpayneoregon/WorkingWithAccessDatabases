
Imports System.IO
Imports UsingAccess_2007_BinaryField.Classes

Namespace Forms

    Public Class frmPictureBoxForm
        WithEvents bsData As New BindingSource
        ''' <summary>
        ''' Current position of record in main/calling form.
        ''' </summary>
        Private currentPosition As Integer
        Public Sub New()
            InitializeComponent()
        End Sub
        ''' <summary>
        ''' Initialize with current record position from calling form.
        ''' </summary>
        ''' <param name="pPosition"></param>
        Public Sub New(pPosition As Integer)

            InitializeComponent()

            currentPosition = pPosition

        End Sub
        Private Sub PictureBoxForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim ops As New Operations
            '
            ' This DataTable is the same as the one on the main form
            '
            Dim dt = ops.PictureDataTable
            bsData.DataSource = dt
            bsData.Position = currentPosition
            BindingNavigator1.BindingSource = bsData
        End Sub
        Private Sub bsData_PositionChanged(sender As Object, e As EventArgs) Handles bsData.PositionChanged
            If bsData.Current IsNot Nothing Then
                PictureBox1.Image = Image.FromStream(
                    New MemoryStream(CType(bsData.Current, DataRowView).Row.Field(Of Byte())("Picture")))
            End If
        End Sub
        ''' <summary>
        ''' Insert image displayed in the PictureBox to the backend
        ''' database table.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub insertImageButton_Click(sender As Object, e As EventArgs) Handles insertImageButton.Click
            Dim row = CType(bsData.Current, DataRowView).Row

            Dim ops = New Operations

            ops.AddImageFromPictureBoxForm(
                row.Field(Of Byte())("Picture"),
                row.Field(Of Integer)("Category"),
                row.Field(Of String)("Description"),
                row.Field(Of String)("BaseName"),
                row.Field(Of String)("FileExtension"))

        End Sub
    End Class
End Namespace