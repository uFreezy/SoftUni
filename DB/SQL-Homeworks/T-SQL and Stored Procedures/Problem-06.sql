CREATE TRIGGER tr_AccChangeLog ON Accounts
FOR UPDATE
AS
IF 
	UPDATE (Balance)

BEGIN
	INSERT INTO Logs (
		AccountId
		,OldSum
		,NewSum
		)
	VALUES (
		(
			SELECT Id
			FROM deleted
			)
		,(
			SELECT Balance
			FROM deleted
			)
		,(
			SELECT Balance
			FROM inserted
			)
		)
END
GO
