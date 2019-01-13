Imports ConfigurationLibrary_vb
Imports LoginLibrary

Public Class LoginForm
    Private Retries As Integer = 0
    Private operations As New ConnectionProtection(Application.ExecutablePath)
    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        '
        ' Set Retried to what suits you for failed login
        '
        If Retries = 2 Then
            MessageBox.Show("Contact an admin")
            Application.ExitThread()
        End If

        If Not operations.IsProtected() Then
            operations.EncryptFile()
        End If

        operations.DecryptFile()
        Dim connectionString = My.Settings.CustomersConnection
        operations.EncryptFile()
        Dim appLogin As New ApplicatioLogin(connectionString) With
            {
                .UserName = txtUserName.Text,
                .UserPassword = txtPassword.Text
            }

        If appLogin.Login Then
            Retries = 0
            Hide()
            Dim f As New Form1(appLogin.UserIdentifier)
            f.ShowDialog()
        Else
            Retries += 1
            MessageBox.Show("Login failed")
        End If
    End Sub

End Class
