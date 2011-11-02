

if( (select COUNT(*) from dbo.NextIds a where a.type = 'CNS' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('CNS','ContactUs',10)
GO





