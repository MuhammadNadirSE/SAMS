Alter Table Quote
ADD InquiryId int null

GO

Alter Table Quote
ADD ContactId int null

GO

ALTER TABLE Quote
ADD CONSTRAINT FK_Quote_Contact --FK_ForeignKeyTable_PrimaryKeyTable
FOREIGN KEY (ContactId) --ForeignKeyColumn
REFERENCES Contact(ContactID) --PrimaryKeyTable(PrimaryKeyColumn)

GO

ALTER TABLE Quote
ADD CONSTRAINT FK_Quote_Inquiry --FK_ForeignKeyTable_PrimaryKeyTable
FOREIGN KEY (InquiryId) --ForeignKeyColumn
REFERENCES Inquiry(InquiryID) --PrimaryKeyTable(PrimaryKeyColumn)