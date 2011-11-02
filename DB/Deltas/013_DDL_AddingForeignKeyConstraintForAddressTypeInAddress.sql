
GO

/****** Object:  Table [dbo].[Addresses]    Script Date: 01/29/2011 12:52:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_AddressType] FOREIGN KEY([Type])
REFERENCES [dbo].[AddressType] ([Id])
GO

ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_AddressType]
GO
