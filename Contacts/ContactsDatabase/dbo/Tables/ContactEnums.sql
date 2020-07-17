CREATE TABLE [dbo].[ContactEnums]
(
	[EnumId] INT NOT NULL PRIMARY KEY, 
    [EnumName] NVARCHAR(100) NOT NULL, 
    [EnumCategory] NVARCHAR(50) NOT NULL DEFAULT 'ContactsEnum', 
    [EnumDescription] NVARCHAR(250) NULL
)
