Imports ConfigurationLibrary_vb

Public Class Form1
    Private operations As New ConnectionProtection(Application.ExecutablePath)
    ''' <summary>
    ''' User identifier came from the database when successfully performing a login.
    ''' This is the primary key to identifier the user. The user table currently
    ''' has user name and password but can have fields for whatever is needed. To expand
    ''' on this the user table could be in another database if on a shared network.
    ''' </summary>
    Private UserIdentifier As Integer = 0
    Public Sub New(pUserIdentifier As Integer)
        InitializeComponent()
        UserIdentifier = pUserIdentifier
    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.ExitThread()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dt As New DataTable

        Using cn As New OleDb.OleDbConnection

            operations.DecryptFile()
            cn.ConnectionString = My.Settings.CustomersConnection
            operations.EncryptFile()

            Using cmd As New OleDb.OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = "SELECT TOP 6 CompanyName FROM Customers;"
                }

                cn.Open()

                dt.Load(cmd.ExecuteReader)
                ListBox1.DisplayMember = "CompanyName"
                ListBox1.DataSource = dt

                Text = $"User Id: {UserIdentifier}"
            End Using
        End Using

    End Sub
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Close()
    End Sub
End Class