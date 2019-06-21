SELECT ContactName,Country, City , Region FROM Customers
Where Region='SP'
Union 
SELECT  ContactName,Country, City , Region FROM Customers
Where City='Portland'
