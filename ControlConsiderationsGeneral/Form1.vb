Public Class Form1
    Private ReadOnly bsEmployees As New BindingSource
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim ops As New DatabaseOperations

        '
        ' Load reference table for titles of employee
        '
        employeeTitleComboBox.DataSource = ops.LoadEmployeeTitles
        bsEmployees.DataSource = ops.LoadEmployees

        '
        ' Data bind first and last name to TextBox controls
        '
        firstNameTextBox.DataBindings.Add("Text", bsEmployees, "FirstName")
        lastNameTextBox.DataBindings.Add("Text", bsEmployees, "LastName")

        BindingNavigator1.BindingSource = bsEmployees

        '
        ' Setup logic to synchronize title of employee
        '
        AddHandler bsEmployees.PositionChanged, AddressOf EmployeesBindingSourcePositionChanged
        HandleTitleChanged()

    End Sub
    ''' <summary>
    ''' Synchronize employee title with employee record
    ''' </summary>
    Private Sub HandleTitleChanged()
        employeeTitleComboBox.SelectedIndex = employeeTitleComboBox.EmployeeTitles().
            FirstOrDefault(Function(data) data.EmployeeTitleId = bsEmployees.CurrentEmployeeTitleIdentifier).EmployeeTitleId - 1
    End Sub
    Private Sub EmployeesBindingSourcePositionChanged(sender As Object, e As EventArgs)
        HandleTitleChanged()
    End Sub
End Class
