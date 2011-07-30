INSERT INTO [Kallivayalil].[dbo].[ConstituentNames]
           ([Id] ,[FirstName],[MiddleName],[LastName],[PreferedName],[Salutation],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy]) 
			VALUES(0,'James','','Franklin','James',1,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Constituents]
           ([Id],[NameId],[BranchName],[HouseName],[BornOn],[DiedOn],[HasExpired],[MaritialStatus],[Gender],[IsRegistered],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(0,0,1,'James',GETDATE(),NULL,NULL,1 ,'M',1,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Addresses]
           ([Id] ,[Line1],[Line2],[City],[State],[Postcode],[Country],[Type],[ConstituentId],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(0,'1234 Street','1234 Cross','City','State','560000','India',1,0,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Emails]
           ([Id] ,[Type],[Address],[ConstituentId],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(0,1,'james@franklin.com',0,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Logins]
           ([Id],[Email],[Password],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
			VALUES(0,0,'Password',GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Phones]
           ([Id],[Type],[Number],[AddressId],[ConstituentId],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
		    VALUES(0,1 ,'1234567890',0,0,GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[EducationDetails]
           ([Id],[Type],[ConstituentId],[Qualification],[InstituteName],[InstituteLocation],[YearOfGraduation],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
		    VALUES(0,1 ,0,'10th grade','SHY','Yercaud','11/13/2010 17:13:27',GETDATE(),'MAC',GETDATE(),'MAC');
INSERT INTO [Kallivayalil].[dbo].[Occupations]
           ([Id],[Type],[ConstituentId],[AddressId],[OccupationName],[Description],[CreatedDateTime],[CreatedBy],[UpdatedDateTime],[UpdatedBy])
		    VALUES(0,1,0 ,0,'Doctor','Senior Doctor',GETDATE(),'MAC',GETDATE(),'MAC');