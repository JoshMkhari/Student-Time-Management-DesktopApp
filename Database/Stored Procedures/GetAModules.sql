CREATE PROCEDURE SP_GetAModule
(
 @MODULES_ID VARCHAR(8) = ''
)
AS
BEGIN
	SELECT * FROM MODULES  WHERE MODULES_ID = @MODULES_ID
END

