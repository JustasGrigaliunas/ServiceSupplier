select * from Users

select * from Orders

SELECT  
	ISNULL(CAST(u.ClientId AS nvarchar(20)),'n/a') as client,
	SUM(ISNULL(o.Total,0)) as total
FROM Orders o
FULL JOIN Users u ON u.UserId = o.UserId
GROUP BY u.ClientId

SELECT TOP 2
	ISNULL(CAST(u.ClientId AS nvarchar(20)),'n/a') as client,
	SUM(ISNULL(o.Total,0)) as total
FROM Orders o
FULL JOIN Users u ON u.UserId = o.UserId
GROUP BY u.ClientId
ORDER BY total DESC

