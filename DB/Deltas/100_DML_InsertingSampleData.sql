-- James Franklin constituent with all sub entities --

INSERT INTO [Kallivayalil].[dbo].[ConstituentNames]
           ([Id] ,[FirstName],[MiddleName],[LastName],[PreferedName],[Salutation],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy]) 
			VALUES(1,'James','','Franklin','James',1,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Constituents]
           ([Id],[NameId],[BranchName],[HouseName],[BornOn],[DiedOn],[HasExpired],[MaritialStatus],[Gender],[IsRegistered],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(1,1,1,'James',GETDATE(),NULL,NULL,1 ,'M','R',GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Addresses]
           ([Id] ,[Line1],[Line2],[City],[State],[Postcode],[Country],[Type],[ConstituentId],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(1,'1234 Street','1234 Cross','City','State','560000','India',1,1,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Emails]
           ([Id] ,[Type],[Address],[ConstituentId],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(1,1,'james@franklin.com',1,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Logins]
           ([Id],[Email],[Password],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(1,1,'Password',GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Phones]
           ([Id],[Type],[Number],[AddressId],[ConstituentId],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
		    VALUES(1,1 ,'1234567890',1,1,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[EducationDetails]
           ([Id],[Type],[ConstituentId],[Qualification],[InstituteName],[InstituteLocation],[YearOfGraduation],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
		    VALUES(1,1 ,1,'10th grade','SHY','Yercaud','11/13/2010 17:13:27',GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Occupations]
           ([Id],[Type],[ConstituentId],[AddressId],[OccupationName],[Description],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
		    VALUES(1,1,1 ,1,'Doctor','Senior Doctor',GETDATE(),'MAC',GETDATE(),'MAC');
			
-- Mary Franklin constituent with all sub entites --
INSERT INTO [Kallivayalil].[dbo].[ConstituentNames]
           ([Id] ,[FirstName],[MiddleName],[LastName],[PreferedName],[Salutation],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy]) 
			VALUES(2,'Mary','','Franklin','Mary',1,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Constituents]
           ([Id],[NameId],[BranchName],[HouseName],[BornOn],[DiedOn],[HasExpired],[MaritialStatus],[Gender],[IsRegistered],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(2,2,1,'James',GETDATE(),NULL,NULL,1 ,'M','R',GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Addresses]
           ([Id] ,[Line1],[Line2],[City],[State],[Postcode],[Country],[Type],[ConstituentId],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(2,'1234 Street','1234 Cross','City','State','560000','India',1,2,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Emails]
           ([Id] ,[Type],[Address],[ConstituentId],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(2,1,'mary@franklin.com',2,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Logins]
           ([Id],[Email],[Password],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(2,2,'Password',GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Phones]
           ([Id],[Type],[Number],[AddressId],[ConstituentId],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
		    VALUES(2,1 ,'1234567890',2,2,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[EducationDetails]
           ([Id],[Type],[ConstituentId],[Qualification],[InstituteName],[InstituteLocation],[YearOfGraduation],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
		    VALUES(2,1 ,2,'10th grade','SHY','Yercaud','11/13/2010 17:13:27',GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Occupations]
           ([Id],[Type],[ConstituentId],[AddressId],[OccupationName],[Description],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
		    VALUES(2,1,2,2,'Doctor','Senior Doctor',GETDATE(),'MAC',GETDATE(),'MAC');
			
-- Association between James and Mary --

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (1,1,1,2,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

INSERT INTO [Kallivayalil].[dbo].[Associations]
           ([Id],[Type],[ConstituentId],[AssociatedConstituentId],[ReciprocalId]
           ,[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
     VALUES
           (2,1,2,1,null,GETDATE(),'MAC',GETDATE(),'MAC')
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 1 where Id = 2;
GO

UPDATE [Kallivayalil].[dbo].[Associations] set ReciprocalId = 2 where Id = 1;
GO

--- John Smith Constituent ----

--- Mary Smith Constituent ----
