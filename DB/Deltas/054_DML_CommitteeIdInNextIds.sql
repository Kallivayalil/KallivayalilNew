USE Kallivayalil;

if( (select COUNT(*) from Kallivayalil.dbo.NextIds a where a.type = 'COM' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('COM','Committees',10)
GO




