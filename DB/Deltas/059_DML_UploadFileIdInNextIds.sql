USE Kallivayalil;

if( (select COUNT(*) from Kallivayalil.dbo.NextIds a where a.type = 'UPF' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('UPF','UploadFiles',10)
GO





