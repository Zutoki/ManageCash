CREATE PROCEDURE [dbo].[UpdRole]
	@Id UNIQUEIDENTIFIER,
	@Name VARCHAR(50)
AS
BEGIN
  -- Declare all validations.
  DECLARE @Exist INT;
  DECLARE @ExistEqual INT;
  DECLARE @ExistDisableId UNIQUEIDENTIFIER;
  DECLARE @Unchange INT = 0;

  -- Get exit row with this id?
  SELECT @Exist = COUNT(*)
   FROM [MCRoles] 
   WHERE [Id] = @Id;

  -- Get if exist any row same with available = 1.
  SELECT @ExistEqual = COUNT(*) 
   FROM [MCRoles] 
   WHERE [Name] = @Name 
    AND [Available] = 1;

  -- Get Id if exist row with same param but with available = 0
  SELECT @ExistDisableId = [Id]
   FROM [MCRoles]
   WHERE [Name] = @Name
    AND [Available] = 0;

  -- Validate if exist changes or only updated date.
  SELECT @Unchange = COUNT(*) 
   FROM [MCRoles] 
   WHERE [Id] = @Id 
    AND [Name] = @Name;


  IF @Exist = 0
    BEGIN
	  RAISERROR('This Role not exist, please add first',16,1)
	END
  ELSE IF @ExistEqual > 0
    BEGIN
      RAISERROR('This Role exist, please update to other role that not exist',16,1)
    END
  ELSE IF @Unchange = 1
    BEGIN
      UPDATE [MCRoles]
       SET [LastUpdated] = GETDATE(),
           [Available] = 1
       WHERE [Id] = @Id;
    END
  ELSE IF @ExistDisableId != NULL
    BEGIN
      UPDATE [MCRoles]
       SET [LastUpdated] = GETDATE(),
           [Available] = 1
       WHERE [Id] = @ExistDisableId;
      
      UPDATE [MCRoles]
       SET [LastUpdated] = GETDATE(),
           [Available] = 0
       WHERE [Id] = @Id;
      SET @Id = @ExistDisableId;
    END
  ELSE
    BEGIN
      UPDATE [MCRoles]
       SET [Name] = @Name,
           [LastUpdated] = GETDATE(),
           [Available] = 1
       WHERE [Id] = @Id;
    END
  SELECT @Id AS [Id];
END