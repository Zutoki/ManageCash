CREATE PROCEDURE [dbo].[GetAllAdminModels]
  @Type INT
AS
BEGIN
  IF @Type = 0
    BEGIN
      SELECT * 
	   FROM [MCRoles] 
	   WHERE [Available] = 1;
	END
  ELSE IF @Type = 1
    BEGIN
      SELECT *
       FROM [MCUsers]
       WHERE [Available] = 1;
    END
END