Imports UsingAccess_2007_BinaryField.Classes

Namespace Forms
    Public Class frmMainForm
        Public Event OnIterate As DelegatesModule.OnIterate
        WithEvents _bsData As New BindingSource
        ''' <summary>
        ''' Read data from backend database via DataAccess project,
        ''' setup cboCategories ComboBox with categories from database
        ''' for filtering records. Finally populate are DataGridView with
        ''' rows in the Pictures table.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub frmMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim ops As New Operations

            _bsData.DataSource = ops.PictureDataTable

            cboCategories.DisplayMember = "Category"
            cboCategories.ValueMember = "Identifier"
            cboCategories.DataSource = ops.CategoriesDataTable

            '
            ' Columns have been setup in the DataGridView smart editor on this form
            '
            DataGridView1.AutoGenerateColumns = False
            DataGridView1.DataSource = _bsData

            SetupDataGridViewColumns()

        End Sub
        ''' <summary>
        ''' Provide interface for user to add images to the database
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub cmdAddPicture_Click(sender As Object, e As EventArgs) Handles cmdAddPicture.Click
            Dim f As New frmAddPictureForm

            Try
                ' Use a copy so not to disturb the current table
                Dim dtCopy As DataTable = CType(cboCategories.DataSource, DataTable).Copy
                dtCopy.Rows(0).SetField("Category", "Select")

                f.cboCategories.DisplayMember = "Category"
                f.cboCategories.ValueMember = "Identifier"
                f.cboCategories.DataSource = dtCopy

                If f.ShowDialog = DialogResult.OK Then
                    Dim ops As New Operations

                    ' Add image to backend database and reload data from database 
                    ' (we could also simple add a new DataRow instead of a reload)
                    If ops.AddImage(f.FileName, CInt(f.cboCategories.SelectedValue), f.txtDescription.Text) Then
                        ops.LoadImages()
                        DataGridView1.DataSource = Nothing
                        _bsData.DataSource = Nothing
                        _bsData.DataSource = ops.PictureDataTable
                        DataGridView1.DataSource = _bsData
                        SetupDataGridViewColumns()
                    Else
                        MessageBox.Show("Failed to add image to database")
                    End If
                End If
            Finally
                f.Dispose()
            End Try

        End Sub
        Private Sub cmdFilterByCategory_Click(sender As Object, e As EventArgs) Handles cmdFilterByCategory.Click
            If _bsData.Count = 0 Then
                Exit Sub
            End If

            If CInt(cboCategories.SelectedValue) = 0 Then
                _bsData.Filter = ""
            Else
                _bsData.Filter = "Category = " & CStr(cboCategories.SelectedValue)
            End If
        End Sub
        Private Sub SetupDataGridViewColumns()
            If _bsData.Count = 0 Then
                Exit Sub
            End If

            DataGridView1.Columns("DescriptionColumn").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridView1.Columns("FileNameColumn").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End Sub
        ''' <summary>
        ''' Writes the current image to disk
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub cmdExportCurrentImage_Click(sender As Object, e As EventArgs) Handles cmdExportCurrentImage.Click
            If _bsData.Current IsNot Nothing Then

                Dim fileName As String = IO.Path.Combine(
                    Application.StartupPath,
                    "Images",
                    "Exported",
                    CType(_bsData.Current, DataRowView).Row.Field(Of String)("FullFileName"))

                Dim bytes = CType(_bsData.Current, DataRowView).Row.Field(Of Byte())("Picture")
                ConvertBytesToImageFile(bytes, fileName)
            End If
        End Sub
        Private Sub cmdPictureBoxDemo_Click(sender As Object, e As EventArgs) Handles cmdPictureBoxDemo.Click
            '
            ' Place the current row position so when the
            ' child form is shown the current record in this
            ' for is the current row in the child form.
            '
            Dim f As New frmPictureBoxForm(_bsData.Position)
            Try
                f.ShowDialog()
            Finally
                f.Dispose()
            End Try
        End Sub
        Dim somePictureBox As New PictureBox
        Private Sub cmdFlowLayout_Click(sender As Object, e As EventArgs) Handles cmdFlowLayout.Click

            'Dim converter As New ImageConverter
            'Dim pBytes = CType(converter.ConvertTo(somePictureBox.Image, GetType(Byte())), Byte())

            Dim f As New DemoFlowForm With {.Owner = Me}
            Try
                f.Show()
                'OnIterateEvent?.Invoke(New MonitorProgressArgs(6, pBytes))
                OnIterateEvent?.Invoke(New MonitorProgressArgs(6, CType(_bsData.Current, DataRowView).Row.Field(Of Byte())("Picture")))
            Finally
                'f.Dispose()
            End Try



        End Sub

    End Class
End Namespace