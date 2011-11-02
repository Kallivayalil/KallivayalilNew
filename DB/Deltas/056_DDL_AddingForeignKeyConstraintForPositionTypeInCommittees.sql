
GO

/****** Object:  Table [dbo].[Committees]    Script Date: 01/29/2011 12:52:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[Committees]  WITH CHECK ADD  CONSTRAINT [FK_Committees_PositionType] FOREIGN KEY([Position])
REFERENCES [dbo].[PositionType] ([Id])
GO

ALTER TABLE [dbo].[Committees] CHECK CONSTRAINT [FK_Committees_PositionType]
GO
