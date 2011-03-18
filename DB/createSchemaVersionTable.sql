use [$(database)]
Go

If NOT exists (select * from dbo.sysobjects where id = object_id(N'[dbo].changelog') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	CREATE TABLE changelog (
	  change_number INTEGER NOT NULL,
	  delta_set VARCHAR(10) NOT NULL,
	  start_dt DATETIME NOT NULL,
	  complete_dt DATETIME NULL,
	  applied_by VARCHAR(100) NOT NULL,
	  description VARCHAR(500) NOT NULL,
	  CONSTRAINT Pkchangelog PRIMARY KEY (change_number, delta_set)
)
GO
