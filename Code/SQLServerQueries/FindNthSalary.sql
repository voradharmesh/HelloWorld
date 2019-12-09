/*
--https://www.youtube.com/watch?v=fvPddKyHxpQ&list=PL6n9fhu94yhXcztdLO7i6mdyaegC8CJwR
Create table EmpSalary
(
ID int primary key identity,
FirstName nvarchar(50),
LastName nvarchar(50),
Gender nvarchar(50),
Salary int
)
GO

Insert into EmpSalary values ('Ben', 'Hoskins', 'Male', 70000)
Insert into EmpSalary values ('Mark', 'Hastings', 'Male', 60000)
Insert into EmpSalary values ('Steve', 'Pound', 'Male', 45000)
Insert into EmpSalary values ('Ben', 'Hoskins', 'Male', 70000)
Insert into EmpSalary values ('Philip', 'Hastings', 'Male', 45000)
Insert into EmpSalary values ('Mary', 'Lambeth', 'Female', 30000)
Insert into EmpSalary values ('Valarie', 'Vikings', 'Female', 35000)
Insert into EmpSalary values ('John', 'Stanmore', 'Male', 80000)
--Insert into EmpSalary values ('TEST', 'TEST1', 'Male', 80000)
GO
*/

SELECT * FROM [dbo].[EmpSalary]

SELECT MAX(Salary) From [dbo].[EmpSalary]


SELECT TOP 3 SALARY --, ROW_NUMBER() OVER (ORDER BY ID) as RowNum
FROM EmpSalary 
ORDER BY SALARY DESC

--INNER QUERY
SELECT TOP 1 SALARY
FROM (SELECT DISTINCT TOP 3 SALARY FROM EmpSalary ORDER BY SALARY DESC) RESULT
ORDER BY SALARY
GO
--WITH CTE, won't work for duplicate rows.
WITH RESULT AS (
	SELECT SALARY, ROW_NUMBER() OVER (ORDER BY SALARY DESC) AS ROWNUMBER FROM EmpSalary
)
SELECT SALARY FROM RESULT WHERE ROWNUMBER = 3


WITH temp as (
SELECT *, ROW_NUMBER() OVER (ORDER BY ID) AS RowNUM
FROM EmpSalary
)
SELECT * from temp WHERE RowNUM = 2
