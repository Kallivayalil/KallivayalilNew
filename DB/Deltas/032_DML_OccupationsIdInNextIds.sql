

if( (select COUNT(*) from dbo.NextIds a where a.type = 'OCC' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('OCC','Occupations',10)
GO





