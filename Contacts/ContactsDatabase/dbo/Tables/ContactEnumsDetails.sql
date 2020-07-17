CREATE TABLE [dbo].[ContactEnumsDetails]
(
	[EnumId] INT NOT NULL , 
    [EnumDetailId] INT NOT NULL, 
    [EnumItemName] NVARCHAR(100) NOT NULL, 
    [EnumItemValue] NVARCHAR(50) NOT NULL, 
    [EnumItemType] NVARCHAR(50) NOT NULL DEFAULT 'int', 
    CONSTRAINT [FK_ContactEnumsDetails_ToContactEnums] FOREIGN KEY (EnumId) REFERENCES [ContactEnums]([EnumId]), 
    PRIMARY KEY ([EnumId], [EnumDetailId])
)
