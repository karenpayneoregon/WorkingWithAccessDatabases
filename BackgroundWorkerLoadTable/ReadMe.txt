This is a very basic example for loading a DataGridView with a BackGroundWorker component where in this case 
there are three fields, 9,000 records, not enough to need a BackGroundWorker but the point here is to demonstrate
how to load via a BackGroundWorker.

* Refer to the project LoadDataGridView_Iterator for alternate method for loading a large table.

Thoughts:
Rather than use a BackGroundWorker consider loading a subset of data as when the point is reached the idea for
using a BackGroundWorker is consider most likely this is more data than a user can work with unless methods
are made to permit filtering the large data set.