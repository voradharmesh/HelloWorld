/*
Create Table Countries
(
Country nvarchar(50),
City nvarchar(50)
)
GO

Insert into Countries values ('USA','New York')
Insert into Countries values ('USA','Houston')
Insert into Countries values ('USA','Dallas')

Insert into Countries values ('India','Hyderabad')
Insert into Countries values ('India','Bangalore')
Insert into Countries values ('India','New Delhi')

Insert into Countries values ('UK','London')
Insert into Countries values ('UK','Birmingham')
Insert into Countries values ('UK','Manchester')
*/

--Write a sql query to transpose rows to columns. 
--Using PIVOT operator we can very easily transform rows to columns.

SELECT * from Countries

SELECT Country, City, Row_Number() over (PARTITION BY COUNTRY Order by COUNTRY) 
FROM COUNTRIES 

SELECT Country, City1, City2, City3
FROM
(
SELECT Country, City, 'City' + CAST(Row_Number() over (PARTITION BY COUNTRY Order by COUNTRY) as VARCHAR(10)) ColumnSequence
FROM COUNTRIES
) TEMP
PIVOT
( MAX (City) FOR ColumnSequence in (City1, City2, City3) )
Piv