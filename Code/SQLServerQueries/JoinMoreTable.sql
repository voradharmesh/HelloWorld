
/*
Create Table DepartmentsJoinMoreTable
(
     DepartmentID int primary key,
     DepartmentName nvarchar(50)
)
GO

Create Table GendersJoinMoreTable
(
     GenderID int primary key,
     Gender nvarchar(50)
)
GO

Create Table EmployeesJoinMoreTable
(
     EmployeeID int primary key,
     EmployeeName nvarchar(50),
     DepartmentID int foreign key references DepartmentsJoinMoreTable(DepartmentID),
     GenderID int foreign key references GendersJoinMoreTable(GenderID)
)
GO

Insert into DepartmentsJoinMoreTable values (1, 'IT')
Insert into DepartmentsJoinMoreTable values (2, 'HR')
Insert into DepartmentsJoinMoreTable values (3, 'Payroll')
GO

Insert into GendersJoinMoreTable values (1, 'Male')
Insert into GendersJoinMoreTable values (2, 'Female')
GO

Insert into EmployeesJoinMoreTable values (1, 'Mark', 1, 1)
Insert into EmployeesJoinMoreTable values (2, 'John', 1, 1)
Insert into EmployeesJoinMoreTable values (3, 'Mike', 2, 1)
Insert into EmployeesJoinMoreTable values (4, 'Mary', 2, 2)
Insert into EmployeesJoinMoreTable values (5, 'Stacy', 3, 2)
Insert into EmployeesJoinMoreTable values (6, 'Valarie', 3, 2)
GO

*/

SELECT EmployeeName, DepartmentName, Gender
FROM EmployeesJoinMoreTable E
JOIN DepartmentsJoinMoreTable D ON E.DepartmentID = D.DepartmentID
JOIN GendersJoinMoreTable G ON E.GenderID = G.GenderID

SELECT  DepartmentName, Gender, COUNT (*) TotalEmp
FROM EmployeesJoinMoreTable E
JOIN DepartmentsJoinMoreTable D ON E.DepartmentID = D.DepartmentID
JOIN GendersJoinMoreTable G ON E.GenderID = G.GenderID
GROUP BY D.DepartmentName, G.Gender
ORDER BY D.DepartmentName, G.Gender
