

if( (select COUNT(*) from dbo.NextIds a where a.type = 'ADD' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('ADD','Address',10)
GO





