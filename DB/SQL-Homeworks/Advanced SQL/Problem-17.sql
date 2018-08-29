CREATE TABLE groups
  (
     id   INT IDENTITY,
     NAME NVARCHAR(30) NOT NULL,
     CONSTRAINT pk_groups PRIMARY KEY(id),
     UNIQUE(NAME)
  ) 