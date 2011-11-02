

if( (select COUNT(*) from dbo.NextIds a where a.type = 'UPF' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('UPF','UploadFiles',10)
GO





