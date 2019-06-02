SELECT LastName , TerritoryID ,RegionDescription
FROM Employees em
  JOIN EmployeeTerritories et ON em.EmployeeID = et.EmployeeID 
  Join Region On em.EmployeeID=RegionID;
 --Нет связей с Region вставил шопопало)))