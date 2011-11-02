

if( (select COUNT(*) from dbo.NextIds a where a.type = 'PHN' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('PHN','Phones',10)
GO





