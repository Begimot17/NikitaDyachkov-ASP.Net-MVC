UPDATE Product 
SET [Type] = 'Autocar'
Where [Type]='Car';

Select *From Product

UPDATE Product  
SET price = price*0.8;

Select *From Product

UPDATE Product
SET Description = Description+' call'
Select *
FROM Product pr LEFT JOIN 
 Manufacturer man ON pr.Id_manufact=man.Id_country
 Where pr.[Type]='SmartPhone';


