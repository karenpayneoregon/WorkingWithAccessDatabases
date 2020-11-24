Public Class Form2
    Private Sub IterateButton_Click(sender As Object, e As EventArgs) Handles IterateButton.Click

        Dim customersDataTable As Database1DataSet.CustomersDataTable = Database1DataSet.Customers
        Dim rows As DataRowCollection = customersDataTable.Rows

        For Each row as DataRow In rows.Cast(of DataRow)
            Console.WriteLine($"ID: {row.Field(of Integer)("Identifier")} Name: {row.Field(of string)("CompanyName")}")
        Next

    End Sub
End Class