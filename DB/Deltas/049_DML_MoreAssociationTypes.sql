INSERT INTO [Kallivayalil].[dbo].[AssociationType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Sibiling',GETDATE(),'Admin',GETDATE(),'Admin')
GO


UPDATE [Kallivayalil].[dbo].[AssociationType]
SET [ReciprocalType] = (SELECT [ID] FROM  [Kallivayalil].[dbo].[AssociationType] WHERE [Description]='Sibiling') where [Description] ='Sibiling'
GO