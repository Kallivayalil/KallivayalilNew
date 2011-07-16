USE [Kallivayalil]
GO

/****** Object:  Table [dbo].[Occupations]    Script Date: 01/29/2011 14:40:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


ALTER TABLE [dbo].[Occupations]  WITH CHECK ADD  CONSTRAINT [FK_Occupations_OccupationType] FOREIGN KEY([Type])
REFERENCES [dbo].[OccupationType] ([Id])
GO

ALTER TABLE [dbo].[Occupations] CHECK CONSTRAINT [FK_Occupations_OccupationType]
GO