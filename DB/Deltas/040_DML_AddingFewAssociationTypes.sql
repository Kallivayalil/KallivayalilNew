INSERT INTO [Kallivayalil].[dbo].[AssociationType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Spouse',GETDATE(),'Admin',GETDATE(),'Admin')
GO


UPDATE [Kallivayalil].[dbo].[AssociationType]
SET [ReciprocalType] = (SELECT [ID] FROM  [Kallivayalil].[dbo].[AssociationType] WHERE [Description]='Spouse') where [Description] ='Spouse'
GO

INSERT INTO [Kallivayalil].[dbo].[AssociationType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Parent',GETDATE(),'Admin',GETDATE(),'Admin')
GO


INSERT INTO [Kallivayalil].[dbo].[AssociationType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Child',GETDATE(),'Admin',GETDATE(),'Admin')
GO


UPDATE [Kallivayalil].[dbo].[AssociationType]
SET [ReciprocalType] = (SELECT [ID] FROM  [Kallivayalil].[dbo].[AssociationType] WHERE [Description]='Child')
WHERE [Description] = 'Parent'
GO


UPDATE [Kallivayalil].[dbo].[AssociationType]
SET [ReciprocalType] = (SELECT [ID] FROM  [Kallivayalil].[dbo].[AssociationType] WHERE [Description]='Parent')
WHERE [Description] = 'Child'
GO