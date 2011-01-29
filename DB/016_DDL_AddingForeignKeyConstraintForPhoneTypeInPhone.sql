USE [Kallivayalil]
GO

/****** Object:  Table [dbo].[Phones]    Script Date: 01/29/2011 14:40:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


ALTER TABLE [dbo].[Phones]  WITH CHECK ADD  CONSTRAINT [FK_Phones_PhoneType] FOREIGN KEY([Type])
REFERENCES [dbo].[PhoneType] ([Id])
GO

ALTER TABLE [dbo].[Phones] CHECK CONSTRAINT [FK_Phones_PhoneType]
GO