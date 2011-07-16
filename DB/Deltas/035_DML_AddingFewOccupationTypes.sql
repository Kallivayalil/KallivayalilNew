INSERT INTO [Kallivayalil].[dbo].[OccupationType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Primary',GETDATE(),'Admin',GETDATE(),'Admin')
GO

INSERT INTO [Kallivayalil].[dbo].[OccupationType]
           ([Description]
           ,[CreatedDateTime]
           ,[CreatedBy]
           ,[UpdatedDateTime]
           ,[UpdatedBy])
     VALUES
           ('Secondary',GETDATE(),'Admin',GETDATE(),'Admin')
GO
