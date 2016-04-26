ALTER TABLE inquiry ALTER COLUMN userid nvarchar(128);

ALTER TABLE inquiry
ADD CONSTRAINT FK_Inquiry_AspNetUsers --FK_ForeignKeyTable_PrimaryKeyTable
FOREIGN KEY (UserId) --ForeignKeyColumn
REFERENCES AspNetUsers(Id) --PrimaryKeyTable(PrimaryKeyColumn)

ALTER TABLE inquiry
ADD CONSTRAINT FK_Inquiry_Contact --FK_ForeignKeyTable_PrimaryKeyTable
FOREIGN KEY (ContactId) --ForeignKeyColumn
REFERENCES Contact(ContactId) --PrimaryKeyTable(PrimaryKeyColumn)

ALTER TABLE inquirydetail
ADD CONSTRAINT FK_inquirydetail_product --FK_ForeignKeyTable_PrimaryKeyTable
FOREIGN KEY (productid) --ForeignKeyColumn
REFERENCES product(productid) --PrimaryKeyTable(PrimaryKeyColumn)