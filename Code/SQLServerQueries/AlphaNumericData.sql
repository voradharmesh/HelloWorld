/*
Create Table AlphaNumericData
(
ID int identity primary key,
Value nvarchar(50)
)

Insert into AlphaNumericData values ('123')
Insert into AlphaNumericData values ('ABC')
Insert into AlphaNumericData values ('DEF')
Insert into AlphaNumericData values ('901')
Insert into AlphaNumericData values ('JKL')

*/

SELECT Value FROM AlphaNumericData WHERE ISNUMERIC(Value) = 1

