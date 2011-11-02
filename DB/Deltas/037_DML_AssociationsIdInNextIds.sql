

if( (select COUNT(*) from dbo.NextIds a where a.type = 'ASN' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('ASN','Associations',10)
GO





