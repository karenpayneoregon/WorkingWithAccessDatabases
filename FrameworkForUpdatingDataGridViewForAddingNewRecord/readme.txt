Project purpose
To show data can be added to a table in a database table using TextBox controls, if successful then add them to a DataGridView.

Notes
* New developers try and add a new row to a table from TextBox controls and then attempt to add a new row using DataGridView.Rows.Add
  which wil throw a runtime exception as a data bound DataGridView requires data to be added from the DataSouce, in this case a 
  DataTable which is demonstrated here in this project.