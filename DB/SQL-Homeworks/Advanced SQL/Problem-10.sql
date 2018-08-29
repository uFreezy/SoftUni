SELECT t.Name as Town,
	   d.Name as Department,
	   COUNT(*) as [Count]
FROM   employees e
       INNER JOIN addresses a
               ON e.addressid = a.addressid
       INNER JOIN towns t
               ON a.townid = t.townid,
			   Departments d
GROUP BY t.Name, d.Name
ORDER By Count DESC