USE [Kallivayalil]
GO

/****** Object:  Table [dbo].[Constituents]    Script Date: 01/29/2011 12:52:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[Constituents]  WITH CHECK ADD  CONSTRAINT [FK_Constituents_BranchType] FOREIGN KEY([BranchName])
REFERENCES [dbo].[BranchType] ([Id])
GO

ALTER TABLE [dbo].[Constituents] CHECK CONSTRAINT [FK_Constituents_BranchType]
GO
