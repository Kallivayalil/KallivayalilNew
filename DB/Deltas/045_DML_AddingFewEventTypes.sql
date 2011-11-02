INSERT INTO [dbo].[EventType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Birthday',GETDATE(),'Admin',GETDATE(),'Admin')
GO


INSERT INTO [dbo].[EventType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Anniversary',GETDATE(),'Admin',GETDATE(),'Admin')
GO

