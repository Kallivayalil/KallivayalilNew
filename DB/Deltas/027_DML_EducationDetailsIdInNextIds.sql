

if( (select COUNT(*) from dbo.NextIds a where a.type = 'EDU' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('EDU','EducationDetails',10)
GO





