CREATE PROCEDURE SP_InsertDatesList
(
@STORED_DATE DATE ='',
@USERS_NAME VARCHAR (50) = '',
@PLANNED_ID INT = 0 
)
AS
BEGIN
INSERT INTO DATES_LIST (STORED_DATE,USERS_NAME,PLANNED_ID)
VALUES (@STORED_DATE,@USERS_NAME,@PLANNED_ID)
END