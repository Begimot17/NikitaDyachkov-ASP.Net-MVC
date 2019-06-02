SELECT RegionDescription
FROM Employees   
RIGHT JOIN Region   
ON ReportsTo = RegionID
Where Title is null
