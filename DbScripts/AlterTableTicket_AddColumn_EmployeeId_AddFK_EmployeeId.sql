Alter Table Ticket
DROP CONSTRAINT FK_Ticket_AspNetUsers;

GO 

Alter Table Ticket
DROP COLUMN  UserId

GO

Alter Table Ticket
ADD EmployeeId int 

GO

Alter Table Ticket
ADD CONSTRAINT FK_Ticket_Employee --FK_ForeignKeyTable_PrimaryKeyTable
FOREIGN KEY (EmployeeId) --ForeignKeyColumn
REFERENCES Employee(EmployeeId) --PrimaryKeyTable(PrimaryKeyColumn)