

if( (select COUNT(*) from dbo.NextIds a where a.type = 'EML' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('EML','Emails',10)
GO





