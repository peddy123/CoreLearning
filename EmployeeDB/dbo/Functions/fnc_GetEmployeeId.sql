
CREATE FUNCTION fnc_GetEmployeeId
(@Name VARCHAR(50))
ReturnS INT
AS
BEGIN
	dECLARE @Id INT = 0
	Select @Id = Id  FROM Employee WHERE Name = @Name
	return @Id

END