USE [master]

If Not Exists (Select name from syslogins Where name = '$(userName)')
	CREATE LOGIN [$(userName)] FROM WINDOWS WITH DEFAULT_DATABASE=[SmartShopper], DEFAULT_LANGUAGE=[us_english]
	GO

USE [$(database)]
GO

If Not Exists (Select name from sysusers Where name = '$(userName)')
  BEGIN
	CREATE USER [$(userName)] FOR LOGIN [$(userName)] WITH DEFAULT_SCHEMA=[dbo]
	
	EXEC sp_addrolemember N'db_datareader', '$(userName)'
	
	EXEC sp_addrolemember N'db_datawriter', '$(userName)'
  END
