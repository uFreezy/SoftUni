CREATE TABLE Workhours
  (
     Id         INT IDENTITY,
     Date       DATETIME,
     Task       NVARCHAR(50),
     Hours      INT,
     Comments   NVARCHAR(50),
     Employeeid INT
     CONSTRAINT pk_workhours PRIMARY KEY(Id)
     CONSTRAINT fk_employeeid_employeeid FOREIGN KEY (Employeeid) REFERENCES
     Employees(Employeeid)
  ) 