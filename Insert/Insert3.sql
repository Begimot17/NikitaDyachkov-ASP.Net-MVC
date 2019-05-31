CREATE TABLE Product_T
(
	[Name] nvarchar (50) Not null ,
	[Type] nvarchar (50),
	[Price] int
);
INSERT INTO Product_T
SELECT [Name],[Type],[Price] 
FROM Product 
WHERE [Type] = 'Smartphone';
Select*From Product_T;


