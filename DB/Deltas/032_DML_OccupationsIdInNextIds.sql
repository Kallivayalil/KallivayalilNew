USE Kallivayalil;

if( (select COUNT(*) from Kallivayalil.dbo.NextIds a where a.type = 'OCC' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('OCC','Occupations',1)
GO





