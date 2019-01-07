Public Class frmMainForm
    WithEvents bsCustomers As New BindingSource
    Private contactTitles As List(Of String)

    ''' <summary>
    ''' Load data from Customers table.
    ''' If an exception is thrown it's available in
    ''' ops.HasException and checked via ops.IsSuccessFul
    ''' 
    ''' We don't show a message on failure until the form
    ''' is shown in the Shown event (below this event) as doing
    ''' so prior to the form being shown does not look good.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        ' See the following
        ' https://github.com/karenpayneoregon/SecureConnectionStringsVisualBasic
        '
        If Not operations.IsProtected() Then
            operations.EncryptFile()
        End If

        operations.DecryptFile()
        ops.ConnectionStringWithPassword = My.Settings.CustomersConnection
        operations.EncryptFile()

        If ops.TestConnection() Then
            bsCustomers.DataSource = ops.LoadCustomers()

            If ops.IsSuccessFul Then
                contactTitles = ops.LoadContactTitles()
                BindingNavigator1.BindingSource = bsCustomers

                DataGridView1.AllowUserToAddRows = False
                DataGridView1.DataSource = bsCustomers


                DataGridView1.Columns("CompanyName").HeaderText = "Company"
                DataGridView1.Columns("ContactName").HeaderText = "Contact"

                DataGridView1.ExpandColumns()

                bsCustomers.Sort = "CompanyName"
            End If
        Else
            '
            ' See Shown event.
            '
        End If

    End Sub
    ''' <summary>
    ''' If there was an exception thrown in the data class on loading
    ''' data in form load we respond by showing the exception message.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Not ops.IsSuccessFul Then
            MessageBox.Show($"Failed to load data: {ops.LastExceptionMessage}")
        End If
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Close()
    End Sub
End Class

