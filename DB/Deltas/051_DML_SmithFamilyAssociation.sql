INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (3,1,3,4,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (4,1,4,3,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 4 where Id = 3;
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 3 where Id = 4;
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (5,2,4,6,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (6,3,6,4,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 6 where Id = 5;
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 5 where Id = 6;
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (7,2,3,6,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (8,3,6,3,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 8 where Id = 7;
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 7 where Id = 8;
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (9,4,5,6,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (10,4,6,5,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 10 where Id = 9;
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 9 where Id = 10;
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (11,4,7,6,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (12,4,6,7,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 12 where Id = 11;
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 11 where Id = 12;
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (13,1,6,8,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (14,1,8,6,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 13 where Id = 14;
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 14 where Id = 13;
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (15,2,6,9,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (16,3,9,6,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 16 where Id = 15;
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 15 where Id = 16;
GO



