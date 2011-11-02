

if( (select COUNT(*) from dbo.NextIds a where a.type = 'NAM' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('NAM','ConstituentName',10)
GO





