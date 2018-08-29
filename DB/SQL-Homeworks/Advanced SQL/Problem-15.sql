CREATE TABLE users
  (
     id        INT IDENTITY,
     username  NVARCHAR(12) NOT NULL,
     password  NVARCHAR(12) NOT NULL,
     fullname  NVARCHAR(12) NOT NULL,
     lastlogin DATETIME NOT NULL,
     CONSTRAINT pk_users PRIMARY KEY(id),
     CHECK(Len(password) >= 5),
     UNIQUE(username)
  ) 
 