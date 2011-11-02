INSERT INTO [dbo].[EmailType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Official',GETDATE(),'Admin',GETDATE(),'Admin')
GO

INSERT INTO [dbo].[EmailType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Personal',GETDATE(),'Admin',GETDATE(),'Admin')
GO
