Imports System.Data.OleDb

Public Class TableNamesForm
    Private Sub TableNamesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ConnectionString As String =
                "Provider=Microsoft.ACE.OLEDB.12.0;" &
                "Data Source=C:\Dotnet_Development\VS2017\" &
                "MSDN_Access1\BasicReadTable\bin\Debug\Database1.accdb"

        Using cn As New OleDbConnection(ConnectionString)

            cn.Open()

            Dim dtNames As DataTable =
                    cn.GetSchema("Tables", New String() _
                                    {Nothing, Nothing, Nothing, "TABLE"})

            TitleListBox.DataSource = dtNames
            TitleListBox.DisplayMember = "TABLE_NAME"
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TitleListBox.DataSource = Nothing

        MessageBox.Show("About to change")

        Dim ConnectionString As String =
                "Provider=Microsoft.ACE.OLEDB.12.0;" &
                "Data Source=C:\Dotnet_Development\VS2017\" &
                "MSDN_Access1\BasicReadTable\bin\Debug\Database1.accdb"

        Using cn As New OleDbConnection(ConnectionString)

            cn.Open()

            Dim dtNames As DataTable =
                    cn.GetSchema("Tables", New String() _
                                    {Nothing, Nothing, Nothing, "TABLE"})

            TitleListBox.DataSource = dtNames
            TitleListBox.DisplayMember = "TABLE_NAME"
        End Using
    End Sub
End Class