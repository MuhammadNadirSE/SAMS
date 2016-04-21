ALTER TABLE Employee
ADD CONSTRAINT FK_Employee_AspNetUsers --FK_ForeignKeyTable_PrimaryKeyTable
FOREIGN KEY (UserId) --ForeignKeyColumn
REFERENCES AspNetUsers(Id) --PrimaryKeyTable(PrimaryKeyColumn)