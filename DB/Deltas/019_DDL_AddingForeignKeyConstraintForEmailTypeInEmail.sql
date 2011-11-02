
GO

/****** Object:  Table [dbo].[Emails]    Script Date: 01/29/2011 15:46:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[Emails]  WITH CHECK ADD  CONSTRAINT [FK_Emails_EmailType] FOREIGN KEY([Type])
REFERENCES [dbo].[EmailType] ([Id])
GO

ALTER TABLE [dbo].[Emails] CHECK CONSTRAINT [FK_Emails_EmailType]
GO
