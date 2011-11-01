SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Hari/Lucy>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[T_PASSWORD_ENCRYPTION] 
   ON  [dbo].[LOGINS] 
   INSTEAD OF INSERT
AS 

	SET NOCOUNT ON
	
	open symmetric key encryptionkey 
	decryption by password = 'K@ll!v@y@l!l'
	
	insert into [dbo].[Logins] (id,email,password,createdby,createddatetime,updatedby,updateddatetime) 
	select id,email,encryptbykey(key_guid('encryptionkey'),password),createdby,createddatetime,updatedby,updateddatetime from inserted
	
	close symmetric key encryptionkey
Return
Go

CREATE TRIGGER [dbo].[T_UPDATE_PASSWORD_ENCRYPTION] 
   ON  [dbo].[LOGINS] 
   FOR UPDATE
AS 

	SET NOCOUNT ON
	
	if update(password)
	begin
		declare @password varchar(50)

		open symmetric key encryptionkey 
		decryption by password = 'K@ll!v@y@l!l'
		
		select @password = encryptbykey(key_guid('encryptionkey'),password) from inserted
		
		update a set password = @password from [dbo].[logins] a
		where a.id = (select id from inserted)
		
		close symmetric key encryptionkey
	end
Return
