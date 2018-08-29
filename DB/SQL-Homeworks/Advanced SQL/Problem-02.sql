SELECT firstname,
       lastname,
       salary
FROM   employees
WHERE  salary BETWEEN (SELECT Min(salary)
                 FROM  employees)
				 AND (Select Min(Salary) + ((Min(Salary) / 100) * 10) from Employees)