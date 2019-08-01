# Working with MS-Access in VB.NET

Although code samples provided here are performed with Microsoft Access databases by using patterns shown they provide a upscale to moving on to Microsoft SQL-Server databases.
> These patterns will go against what a novice developer believes to be the correct path for interacting with data as they are not a simple approach to working with a database. Patterns presented in the code samples are intended for both best practices along with providing 
reusability between forms in one project or between similar projects that work with data centric solutions.

Currently there are three articles in the series which will expand shortly to include more common solutions working with Microsoft Access databases and upscaling to SQL-Server.

[Part 1](https://social.technet.microsoft.com/wiki/contents/articles/52452.best-practices-working-with-ms-access-with-vb-net-part-1.aspx), [Part 2](https://social.technet.microsoft.com/wiki/contents/articles/52453.best-practices-working-with-ms-access-with-vb-net-part-2.aspx) and [Part 3](https://social.technet.microsoft.com/wiki/contents/articles/52454.best-practices-working-with-ms-access-with-vb-net-part-3.aspx).

- Interfaces.
- Factory listeners.
- Base connection classes.
- Base exceptions class.
- Secure connections [repository](https://github.com/karenpayneoregon/SecureConnectionStringsVisualBasic).
- Adding records in batch.
- Utilizing transactions.
- Interacting with blob fields.
- Working with data readers.
- Master/Details relations.
- CRUD operations.
- DataGridView control considerations.
- Data binding control considerations.
- Database design.
- Loading with BackGrounderWorker component.
- Loading with Iterators and Async.
- Searching.
- Auto filtering component for DataGridView.
- Query optimization for specific task.
- Upscaling to SQL-Server.

### Requires
- Microsoft [Visual Studio](https://visualstudio.microsoft.com/) (written in 2017)
- Microsoft Access [data providers](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/data-providers).

### Encryption notes
In this code sample MS-Access databases are encrypted. When working with your own database and connections fail, make sure to try the following.
- Open Access in exclusive mode.
- Under the file menu, options.
- Find client settings.
- At the bottom of settings.
- Change  Encryption Method at the bottom. Change to selection to Use Legacy Encryption.

Also there have been reports of encryption failing with passwords longer than 14 characters.

### Special note
There are a few projects marked as for answering forum questions, these were added as they may be of assistance to others.

This [one](https://github.com/karenpayneoregon/WorkingWithAccessDatabases/tree/master/RetrieveAutoIncrementingIdentifier) is not a code sample to follow as it's fragile, only good for a single user environment.