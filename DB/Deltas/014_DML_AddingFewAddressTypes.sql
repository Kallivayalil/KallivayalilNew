INSERT INTO [dbo].[AddressType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Home',GETDATE(),'Admin',GETDATE(),'Admin')
GO

INSERT INTO [dbo].[AddressType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Office',GETDATE(),'Admin',GETDATE(),'Admin')
GO
