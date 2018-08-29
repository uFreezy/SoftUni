CREATE FUNCTION dbo.Calcsum(@Sum MONEY,
@YearInt FLOAT ,
@Months INT)
returns MONEY AS
BEGIN
  DECLARE @result MONEY
  SET @result = @Sum + ((@YearInt / 12) * @Months)
  RETURN @result
END