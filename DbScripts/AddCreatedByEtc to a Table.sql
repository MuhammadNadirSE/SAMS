alter table Contact
add [CreatedBy] [nvarchar](128) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](128) NOT NULL,
	[UpdateDate] [datetime] NOT NULL

Alter Table Contact
ADD CONSTRAINT FK_ContactCreatedBy_AspNetUsers --FK_ForeignKeyTable_PrimaryKeyTable
FOREIGN KEY (CreatedBy) --ForeignKeyColumn
REFERENCES AspNetUsers(Id) --PrimaryKeyTable(PrimaryKeyColumn)

Alter Table Contact
ADD CONSTRAINT FK_ContactUpdatedBy_AspNetUsers --FK_ForeignKeyTable_PrimaryKeyTable
FOREIGN KEY (UpdatedBy) --ForeignKeyColumn
REFERENCES AspNetUsers(Id) --PrimaryKeyTable(PrimaryKeyColumn)