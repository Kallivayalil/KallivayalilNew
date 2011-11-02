

if( (select COUNT(*) from dbo.NextIds a where a.type = 'CON' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('CON','Constituent',10)
GO





