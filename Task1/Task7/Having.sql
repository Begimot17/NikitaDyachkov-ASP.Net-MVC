SELECT City,Region, COUNT(*) AS CountPost
FROM [northwind].[dbo].[Customers]
WHERE Country ='Brazil'
GROUP BY City, Region
HAVING COUNT(*) > 1;
