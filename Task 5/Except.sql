SELECT ContactName,Country, City , Region FROM Customers
Where Region='SP'
Except 
SELECT  ContactName,Country, City , Region FROM Customers
Where City='Sao Paulo'
