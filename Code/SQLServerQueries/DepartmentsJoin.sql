
/*
Create Table DepartmentsJoin
(
     DepartmentID int primary key,
     DepartmentName nvarchar(50)
)
GO

Create Table EmployeesJoin
(
     EmployeeID int primary key,
     EmployeeName nvarchar(50),
     DepartmentID int foreign key references DepartmentsJoin(DepartmentID)
)
GO

Insert into DepartmentsJoin values (1, 'IT')
Insert into DepartmentsJoin values (2, 'HR')
Insert into DepartmentsJoin values (3, 'Payroll')
Insert into DepartmentsJoin values (4, 'Admin')
GO

Insert into EmployeesJoin values (1, 'Mark', 1)
Insert into EmployeesJoin values (2, 'John', 1)
Insert into EmployeesJoin values (3, 'Mike', 1)
Insert into EmployeesJoin values (4, 'Mary', 2)
Insert into EmployeesJoin values (5, 'Stacy', 3)
Insert into EmployeesJoin values (6, 'Pam', NULL)
GO

*/

SELECT EmployeeName, DepartmentName
From EmployeesJoin E 
JOIN DepartmentsJoin D
ON E.DepartmentID = D.DepartmentID


SELECT EmployeeName, DepartmentName
From EmployeesJoin E 
LEFT JOIN DepartmentsJoin D
ON E.DepartmentID = D.DepartmentID

SELECT EmployeeName, DepartmentName
From EmployeesJoin E 
RIGHT JOIN DepartmentsJoin D
ON E.DepartmentID = D.DepartmentID

SELECT EmployeeName, DepartmentName
From EmployeesJoin E 
FULl JOIN DepartmentsJoin D
ON E.DepartmentID = D.DepartmentID

--CROSS JOIN
SELECT EmployeeName, DepartmentName
From EmployeesJoin E 
, DepartmentsJoin D

