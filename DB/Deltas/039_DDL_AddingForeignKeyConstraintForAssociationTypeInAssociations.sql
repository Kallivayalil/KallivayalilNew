USE [Kallivayalil]
GO

/****** Object:  Table [dbo].[Associations]    Script Date: 01/29/2011 14:40:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


ALTER TABLE [dbo].[Associations]  WITH CHECK ADD  CONSTRAINT [FK_Associations_AssociationType] FOREIGN KEY([Type])
REFERENCES [dbo].[AssociationType] ([Id])
GO

ALTER TABLE [dbo].[Associations] CHECK CONSTRAINT [FK_Associations_AssociationType]
GO