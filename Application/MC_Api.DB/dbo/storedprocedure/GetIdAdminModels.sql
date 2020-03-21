CREATE PROCEDURE [dbo].[GetIdAdminModels]
	@Type INT,
	@Id UNIQUEIDENTIFIER
AS
BEGIN
  IF @Type = 0
    BEGIN
	  SELECT * 
	   FROM [MCRoles]
	   WHERE [Id] = @Id;
	END
  IF @Type = 1
    BEGIN
	  SELECT *
	   FROM [MCUsers]
	   WHERE [Id] = @Id;
	END
END