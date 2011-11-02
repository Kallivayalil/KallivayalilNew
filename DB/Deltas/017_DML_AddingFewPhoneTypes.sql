INSERT INTO [dbo].[PhoneType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Mobile',GETDATE(),'Admin',GETDATE(),'Admin')
GO

INSERT INTO [dbo].[PhoneType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('LandLine',GETDATE(),'Admin',GETDATE(),'Admin')
GO
