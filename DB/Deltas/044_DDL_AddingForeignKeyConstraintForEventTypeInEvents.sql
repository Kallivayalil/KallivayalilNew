
GO

/****** Object:  Table [dbo].[Events]    Script Date: 01/29/2011 14:40:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventType] FOREIGN KEY([Type])
REFERENCES [dbo].[EventType] ([Id])
GO

ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventType]
GO