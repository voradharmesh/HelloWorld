
/*
Create Table DepartmentsMaxEmp
(
     DepartmentID int primary key,
     DepartmentName nvarchar(50)
)
GO

Create Table EmployeesMaxEmp
(
     EmployeeID int primary key,
     EmployeeName nvarchar(50),
     DepartmentID int foreign key references DepartmentsMaxEmp(DepartmentID)
)
GO

Insert into DepartmentsMaxEmp values (1, 'IT')
Insert into DepartmentsMaxEmp values (2, 'HR')
Insert into DepartmentsMaxEmp values (3, 'Payroll')
GO

Insert into EmployeesMaxEmp values (1, 'Mark', 1)
Insert into EmployeesMaxEmp values (2, 'John', 1)
Insert into EmployeesMaxEmp values (3, 'Mike', 1)
Insert into EmployeesMaxEmp values (4, 'Mary', 2)
Insert into EmployeesMaxEmp values (5, 'Stacy', 3)
GO

*/


SELECT TOP 1 D.DepartmentName 
FROM  DepartmentsMaxEmp D
JOIN EmployeesMaxEmp E
ON D.DepartmentID = E.DepartmentID
Group By D.DepartmentName
Order by count(E.EmployeeID) Desc

