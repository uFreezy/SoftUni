CREATE PROCEDURE Usp_calcinterest @AccountID    INT,
                                  @InterestRate FLOAT
AS
    DECLARE @money MONEY

    SET @money = (SELECT Balance
                  FROM   Accounts
                  WHERE  Id = @AccountID)

    SELECT dbo.Calcsum(@money, @InterestRate, 1)

go 