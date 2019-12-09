Use InterviewDB
GO

/*

Create table DeleteDupEmployees
(
ID int,
FirstName nvarchar(50),
LastName nvarchar(50),
Gender nvarchar(50),
Salary int
)
GO

Insert into DeleteDupEmployees values (1, 'Mark', 'Hastings', 'Male', 60000)
Insert into DeleteDupEmployees values (1, 'Mark', 'Hastings', 'Male', 60000)
Insert into DeleteDupEmployees values (1, 'Mark', 'Hastings', 'Male', 60000)
Insert into DeleteDupEmployees values (2, 'Mary', 'Lambeth', 'Female', 30000)
Insert into DeleteDupEmployees values (2, 'Mary', 'Lambeth', 'Female', 30000)
Insert into DeleteDupEmployees values (3, 'Ben', 'Hoskins', 'Male', 70000)
Insert into DeleteDupEmployees values (3, 'Ben', 'Hoskins', 'Male', 70000)
Insert into DeleteDupEmployees values (3, 'Ben', 'Hoskins', 'Male', 70000)

*/

WITH EmployeeCTE AS
(
SELECT *, ROW_NUMBER() OVER (Partition by id Order By FirstName, LastName) as RowNum
FROM DeleteDupEmployees
)
SELECT * FROM EmployeeCTE --You can DELETE instead of SELECT
WHERE RowNum <> 1
