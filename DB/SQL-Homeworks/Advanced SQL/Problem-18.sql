ALTER TABLE Users
  ADD Groupid INT FOREIGN KEY REFERENCES Groups(Id) 