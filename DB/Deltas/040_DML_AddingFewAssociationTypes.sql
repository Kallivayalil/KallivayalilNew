INSERT INTO [dbo].[AssociationType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Spouse',GETDATE(),'Admin',GETDATE(),'Admin')
GO


UPDATE [dbo].[AssociationType]
SET [ReciprocalType] = (SELECT [ID] FROM  [dbo].[AssociationType] WHERE [Description]='Spouse') where [Description] ='Spouse'
GO

INSERT INTO [dbo].[AssociationType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Parent',GETDATE(),'Admin',GETDATE(),'Admin')
GO


INSERT INTO [dbo].[AssociationType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Child',GETDATE(),'Admin',GETDATE(),'Admin')
GO


UPDATE [dbo].[AssociationType]
SET [ReciprocalType] = (SELECT [ID] FROM  [dbo].[AssociationType] WHERE [Description]='Child')
WHERE [Description] = 'Parent'
GO


UPDATE [dbo].[AssociationType]
SET [ReciprocalType] = (SELECT [ID] FROM  [dbo].[AssociationType] WHERE [Description]='Parent')
WHERE [Description] = 'Child'
GO