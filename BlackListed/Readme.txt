When writting code the author was asked in a forum question
about finding by user name or full name, if found alert the user this person is black listed.

Points of interest:
1. Same methods used in other code samples used here e.g. creating a connection, creating SQL SELECT statement.
2. The SELECT statement only need to check if any rows were returned to determine if values passed in (user and full name)
   had been entered and found.
3. No casing of text/string values is needed. In figure 1 below the SELECT is case insensitive while figure 2 is case sensitive

Figure 1
	SELECT ID
	FROM 
		tbl_BlackList
	WHERE 
		User_Name=@UserName OR Full_Name=@FullName;

Figure 2
	SELECT ID
	FROM 
		tbl_BlackList
	WHERE        
		(StrComp(User_Name,@UserName, 0) = 0) OR (StrComp(Full_Name,@FullName, 0) = 0)
