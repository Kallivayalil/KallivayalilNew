INSERT INTO [dbo].[AssociationType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Sibiling',GETDATE(),'Admin',GETDATE(),'Admin')
GO


UPDATE [dbo].[AssociationType]
SET [ReciprocalType] = (SELECT [ID] FROM  [dbo].[AssociationType] WHERE [Description]='Sibiling') where [Description] ='Sibiling'
GO