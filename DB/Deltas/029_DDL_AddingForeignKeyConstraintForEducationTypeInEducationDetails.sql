
GO

/****** Object:  Table [dbo].[EducationDetails]    Script Date: 01/29/2011 14:40:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


ALTER TABLE [dbo].[EducationDetails]  WITH CHECK ADD  CONSTRAINT [FK_EducationDetails_EducationType] FOREIGN KEY([Type])
REFERENCES [dbo].[EducationType] ([Id])
GO

ALTER TABLE [dbo].[EducationDetails] CHECK CONSTRAINT [FK_EducationDetails_EducationType]
GO