SELECT CategoryID, MAX(UnitPrice) As'Price'
    FROM Products
    GROUP BY CategoryID