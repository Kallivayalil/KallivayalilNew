USE Kallivayalil;

if( (select COUNT(*) from Kallivayalil.dbo.NextIds a where a.type = 'EVT' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('EVT','Events',1)
GO





