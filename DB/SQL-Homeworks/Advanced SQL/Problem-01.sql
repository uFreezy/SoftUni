SELECT firstname,
       lastname,
       salary
FROM   employees
WHERE  salary = (SELECT Min(salary)
                 FROM   employees) 