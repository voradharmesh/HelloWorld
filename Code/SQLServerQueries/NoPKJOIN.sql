/*
--http://csharp-video-tutorials.blogspot.com/2014/09/part-12-can-we-join-two-tables-without.html
Create table DepartmentsNoPKJOIN
(
     ID int not null,
     Name nvarchar(50),
     Location nvarchar(50)
)
GO

Create table EmployeesNoPKJOIN
(
     ID int,
     Name nvarchar(50),
     Gender nvarchar(50),
     Salary int,
     DepartmentId int
)
GO

Insert into DepartmentsNoPKJOIN values (1, 'IT', 'New York')
Insert into DepartmentsNoPKJOIN values (2, 'HR', 'London')
Insert into DepartmentsNoPKJOIN values (3, 'Payroll', 'Sydney')
GO

Insert into EmployeesNoPKJOIN values (1, 'Mark', 'Male', 60000, 1)
Insert into EmployeesNoPKJOIN values (2, 'Steve', 'Male', 45000, 3)
Insert into EmployeesNoPKJOIN values (3, 'Ben', 'Male', 70000, 1)
Insert into EmployeesNoPKJOIN values (4, 'Philip', 'Male', 45000, 2)
Insert into EmployeesNoPKJOIN values (5, 'Mary', 'Female', 30000, 2)
Insert into EmployeesNoPKJOIN values (6, 'Valarie', 'Female', 35000, 3)
Insert into EmployeesNoPKJOIN values (7, 'John', 'Male', 80000, 1)
GO
*/

SELECT * FROM EmployeesNoPKJOIN E
JOIN DepartmentsNoPKJOIN D
ON E.DepartmentID = D.ID
