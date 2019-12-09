/*
Create table EmpDateCalc
(
     ID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
     Salary int,
     HireDate DateTime
)
GO
Insert into EmpDateCalc values('Mark','Hastings','Male',60000,'5/10/2016')
Insert into EmpDateCalc values('Steve','Pound','Male',45000,'4/20/2016')
Insert into EmpDateCalc values('Ben','Hoskins','Male',70000,'4/5/2016')
Insert into EmpDateCalc values('Philip','Hastings','Male',45000,'3/11/2016')
Insert into EmpDateCalc values('Mary','Lambeth','Female',30000,'3/10/2016')
Insert into EmpDateCalc values('Valarie','Vikings','Female',35000,'2/9/2016')
Insert into EmpDateCalc values('John','Stanmore','Male',80000,'2/22/2016')
Insert into EmpDateCalc values('Able','Edward','Male',5000,'1/22/2016')
Insert into EmpDateCalc values('Emma','Nan','Female',5000,'1/14/2016')
Insert into EmpDateCalc values('Jd','Nosin','Male',6000,'1/10/2015')
Insert into EmpDateCalc values('Todd','Heir','Male',7000,'2/14/2015')
Insert into EmpDateCalc values('San','Hughes','Male',7000,'3/15/2015')
Insert into EmpDateCalc values('Nico','Night','Male',6500,'4/19/2015')
Insert into EmpDateCalc values('Martin','Jany','Male',5500,'5/23/2015')
Insert into EmpDateCalc values('Mathew','Mann','Male',4500,'6/23/2015')
Insert into EmpDateCalc values('Baker','Barn','Male',3500,'7/23/2015')
Insert into EmpDateCalc values('Mosin','Barn','Male',8500,'8/21/2015')
Insert into EmpDateCalc values('Rachel','Aril','Female',6500,'9/14/2015')
Insert into EmpDateCalc values('Pameela','Son','Female',4500,'10/14/2015')
Insert into EmpDateCalc values('Thomas','Cook','Male',3500,'11/14/2015')
Insert into EmpDateCalc values('Malik','Md','Male',6500,'12/14/2015')
Insert into EmpDateCalc values('Josh','Anderson','Male',4900,'5/1/2016')
Insert into EmpDateCalc values('Geek','Ging','Male',2600,'4/1/2016')
Insert into EmpDateCalc values('Sony','Sony','Male',2900,'4/30/2016')
Insert into EmpDateCalc values('Aziz','Sk','Male',3800,'3/1/2016')
Insert into EmpDateCalc values('Amit','Naru','Male',3100,'3/31/2016')

*/

SELECT * FROM EmpDateCalc
WHERE DATEDIFF(DAY, HIREDATE, GETDATE()) BETWEEN 60 AND 90
