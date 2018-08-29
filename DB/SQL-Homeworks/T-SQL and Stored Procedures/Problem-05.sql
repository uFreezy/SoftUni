CREATE PROCEDURE usp_WithdrawMoney @AccountId INT
	,@Money MONEY
AS
BEGIN TRANSACTION

UPDATE Accounts
SET Balance = Balance - @Money
WHERE Id = @AccountId

COMMIT TRANSACTION
GO

CREATE PROCEDURE usp_DepositMoney @AccountId INT
	,@Money MONEY
AS
BEGIN TRANSACTION

UPDATE Accounts
SET Balance = Balance + @Money
WHERE Id = @AccountId

COMMIT TRANSACTION
GO

