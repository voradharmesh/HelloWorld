/*
--https://www.youtube.com/watch?v=Kd3HTph0Mds

Create table OrgChartByEmpID
(
EmployeeID int primary key identity,
EmployeeName nvarchar(50),
ManagerID int foreign key references OrgChartByEmpID(EmployeeID)
)
GO

Insert into OrgChartByEmpID values ('John', NULL)
Insert into OrgChartByEmpID values ('Mark', NULL)
Insert into OrgChartByEmpID values ('Steve', NULL)
Insert into OrgChartByEmpID values ('Tom', NULL)
Insert into OrgChartByEmpID values ('Lara', NULL)
Insert into OrgChartByEmpID values ('Simon', NULL)
Insert into OrgChartByEmpID values ('David', NULL)
Insert into OrgChartByEmpID values ('Ben', NULL)
Insert into OrgChartByEmpID values ('Stacy', NULL)
Insert into OrgChartByEmpID values ('Sam', NULL)
GO
Update OrgChartByEmpID Set ManagerID = 8 Where EmployeeName IN ('Mark', 'Steve', 'Lara')
Update OrgChartByEmpID Set ManagerID = 2 Where EmployeeName IN ('Stacy', 'Simon')
Update OrgChartByEmpID Set ManagerID = 3 Where EmployeeName IN ('Tom')
Update OrgChartByEmpID Set ManagerID = 5 Where EmployeeName IN ('John', 'Sam')
Update OrgChartByEmpID Set ManagerID = 4 Where EmployeeName IN ('David')
GO

*/
SELECT * FROM OrgChartByEmpID
DECLARE @ID INT  = 7;
WITH EmpCTE as 
(
	SELECT EmployeeID, EmployeeName, ManagerID 
	FROM OrgChartByEmpID A
	WHERE EmployeeID = @ID

	UNION ALL

	SELECT B.EmployeeID, B.EmployeeName, B.ManagerID
	From OrgChartByEmpID B
	Join EmpCTE C ON 
	B.EmployeeID = C.ManagerID

) 
SELECT 
--CTE.EmployeeID, 
CTE.EmployeeName, 
--CTE.ManagerID, 
IsNULL(A.EmployeeName, 'NO-MANAGER') as ManagerName
FROM EmpCTE CTE
LEFT JOIN OrgChartByEmpID A
ON CTE.ManagerID = A.EmployeeID
