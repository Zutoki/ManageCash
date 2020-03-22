CREATE PROCEDURE [dbo].[AddRole]
	@Name VARCHAR(50)
AS
BEGIN
  -- Declare all validations.
  DECLARE @ExistEqual INT;
  DECLARE @ExistDisableId UNIQUEIDENTIFIER;
  DECLARE @IdAdded UNIQUEIDENTIFIER;

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

  IF @ExistEqual > 0
    BEGIN
      RAISERROR('This Role exist, please add other role distinct',16,1)
    END
  ELSE IF @ExistDisableId != NULL
    BEGIN
      UPDATE [MCRoles]
       SET [LastUpdated] = GETDATE(),
           [Available] = 1
       WHERE [Id] = @ExistDisableId;
      SET @IdAdded = @ExistDisableId;
    END
  ELSE 
    BEGIN
      INSERT INTO [MCRoles]([Name])
       VALUES(@Name)
      SELECT @IdAdded = [Id] FROM [MCRoles] WHERE [Name] = @Name;
    END
  SELECT @IdAdded AS [Id];
END