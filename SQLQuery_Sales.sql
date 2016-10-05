
WITH sales_group AS (
    SELECT sl.Id, 
           sl.CustomerId, 
           sl.ProductId, 
		   sl.DateCreated,
           ROW_NUMBER() OVER(PARTITION BY sl.CustomerId 
                                 ORDER BY sl.DateCreated asc) AS rk
      FROM Sales sl)
SELECT s.ProductId, COUNT(*) as NumberOfCustomers
  FROM sales_group s
WHERE s.rk = 1
 group by s.ProductId



