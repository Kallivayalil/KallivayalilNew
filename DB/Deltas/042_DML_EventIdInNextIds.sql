

if( (select COUNT(*) from dbo.NextIds a where a.type = 'EVT' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('EVT','Events',1)
GO





