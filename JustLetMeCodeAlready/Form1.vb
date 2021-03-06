﻿Imports System.Data.OleDb

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Dotnet_Development\VS2017\MSDN_Access1\JustLetMeCodeAlready\bin\Debug\Database1.accdb"

        Using cn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = "SELECT Employees.EmployeeID, Employees.FirstName, Employees.LastName, Employees.Title, Employees.HireDate FROM Employees;"
                Dim dt As New DataTable With {.TableName = "Employees"}
                Try
                    cn.Open()
                    Dim ds As New DataSet
                    Dim employeeTable As New DataTable With {.TableName = "Employees"}
                    ds.Tables.Add(employeeTable)
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, employeeTable)
                    DataGridView1.DataSource = ds.Tables("Employees")
                    DataGridView1.Columns("EmployeeID").Visible = False
                Catch ex As Exception
                    ' very common for a developer to simply ignore errors, unwise.
                End Try
            End Using
        End Using
    End Sub
    ''' <summary>
    ''' This code is not mentioned in the TechNet article. This was to answer a
    ''' question in the Microsoft developer's forum where the person asking a question
    ''' about a WHERE condition not working. They were using string concatenation for 
    ''' dates and were attempting to format the DateTimePicker.Value which will cause
    ''' a query to return unexpected results or throw an exception.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub LoadButton_Click(sender As Object, e As EventArgs) Handles LoadButton.Click
        Dim connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" &
                               "Data Source=Database1.accdb"

        Using cn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = "SELECT EmployeeID,FirstName,LastName,Title,HireDate " &
                                  "FROM Employees " &
                                  "WHERE HireDate >= @StartDate AND HireDate <= @EndDate AND Title = @Title"

                cmd.Parameters.AddWithValue("@StartDate", StartDateTimePicker.Value)
                cmd.Parameters.AddWithValue("@EndDate", EndDateTimePicker.Value)
                cmd.Parameters.AddWithValue("@Title", TitleTextBox.Text)

                Dim dt As New DataTable With {.TableName = "Employees"}

                Try
                    cn.Open()
                    Dim ds As New DataSet
                    Dim employeeTable As New DataTable With {.TableName = "Employees"}
                    ds.Tables.Add(employeeTable)
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, employeeTable)
                    DataGridView1.DataSource = ds.Tables("Employees")
                    DataGridView1.Columns("EmployeeID").Visible = False
                Catch ex As Exception
                    ' very common for a developer to simply ignore errors, unwise.
                End Try
            End Using
        End Using
    End Sub
    ''' <summary>
    ''' Common code to find a record but may not bite until down the road
    ''' An unescaped apostrophe will cause an exception to be thrown.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Dotnet_Development\VS2017\MSDN_Access1\JustLetMeCodeAlready\bin\Debug\Database1.accdb"

        Using cn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = "SELECT Employees.EmployeeID, Employees.LastName, Employees.FirstName, Employees.Title, Employees.TitleOfCourtesy, Employees.BirthDate, Employees.HireDate FROM Employees WHERE (((Employees.LastName)='" & firstNameFindBadTextBox.Text & "'));"

                Dim dt As New DataTable With {.TableName = "Employees"}
                Try
                    cn.Open()
                    Dim ds As New DataSet
                    Dim employeeTable As New DataTable With {.TableName = "Employees"}
                    ds.Tables.Add(employeeTable)
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, employeeTable)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Dotnet_Development\VS2017\MSDN_Access1\JustLetMeCodeAlready\bin\Debug\Database1.accdb"

        Using cn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand With {.Connection = cn}
                cmd.CommandText = "SELECT Employees.EmployeeID, Employees.LastName, Employees.FirstName, Employees.Title, Employees.TitleOfCourtesy, Employees.BirthDate, Employees.HireDate FROM Employees WHERE (((Employees.LastName)=?));"
                cmd.Parameters.AddWithValue("?", employeeLastNameFindTextBox.Text)
                Dim dt As New DataTable With {.TableName = "Employees"}
                Try
                    cn.Open()
                    Dim ds As New DataSet
                    Dim employeeTable As New DataTable With {.TableName = "Employees"}
                    ds.Tables.Add(employeeTable)
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, employeeTable)
                    MessageBox.Show(ds.Tables(0).Rows.Count.ToString())
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        Close()
    End Sub


End Class
