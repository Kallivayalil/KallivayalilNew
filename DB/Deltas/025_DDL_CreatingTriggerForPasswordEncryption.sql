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
