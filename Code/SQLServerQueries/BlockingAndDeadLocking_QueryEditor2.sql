--BLOCKING
--Transaction 2
Begin Tran
Update TableABlockingAndDeadLocking set Name='Mark Transaction 2' where Id = 1

Commit Transaction

--DEADLOCK

-- Transaction 2
Begin Tran
Update TableBBlockingAndDeadLocking Set Name = 'Mark Transaction 2' where Id = 1

-- From Transaction 1 window execute the second update statement
Update TableABlockingAndDeadLocking Set Name = 'Mary Transaction 2' where Id = 1

-- From Transaction 2 window execute the second update statement
Commit Transaction
