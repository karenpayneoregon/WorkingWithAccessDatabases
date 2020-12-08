# Simple removal from ComboBox

Simple example for removal of a selected item from a ComboBox loaded from a database table. Note absense of a DataTable, instead all we need is a list.

Altough a ComboBox is used with a list the underlying code can be adapted to a DataTable and other controls like a DataGridView.

> Also shows [INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netcore-3.1) which permits updating for instance in the ComboBox from a [BindingList](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.bindinglist-1?view=netcore-3.1)