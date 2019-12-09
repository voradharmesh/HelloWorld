/*
--https://www.youtube.com/watch?v=hATX1eWj78o

Create table TableABlockingAndDeadLocking
(
Id int identity primary key,
Name nvarchar(50)
)
Go

Insert into TableABlockingAndDeadLocking values ('Mark')
Go

Create table TableBBlockingAndDeadLocking
(
Id int identity primary key,
Name nvarchar(50)
)
Go

Insert into TableBBlockingAndDeadLocking values ('Mary')
Go


*/
--BLOCKING
--Transaction 1
Begin Tran
Update TableABlockingAndDeadLocking set Name='Mark Transaction 1' where Id = 1
Waitfor Delay '00:00:10'

Commit Transaction

--DEADLOCK
-- Transaction 1
Begin Tran
Update TableABlockingAndDeadLocking Set Name = 'Mark Transaction 1' where Id = 1

-- From Transaction 2 window execute the first update statement
Update TableBBlockingAndDeadLocking Set Name = 'Mary Transaction 1' where Id = 1


-- After a few seconds notice that one of the transactions complete 
-- successfully while the other transaction is made the deadlock victim
Commit Transaction