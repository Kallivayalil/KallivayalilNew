USE [master]
GO

If Not Exists (Select * from sys.databases where name = '[$(database)]')
	CREATE DATABASE [$(database)] 
GO
