
GO

/****** Object:  Table [dbo].[ConstituentNames]    Script Date: 01/29/2011 15:56:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO



ALTER TABLE [dbo].[ConstituentNames]  WITH CHECK ADD  CONSTRAINT [FK_ConstituentNames_SalutationType] FOREIGN KEY([Salutation])
REFERENCES [dbo].[SalutationType] ([Id])
GO

ALTER TABLE [dbo].[ConstituentNames] CHECK CONSTRAINT [FK_ConstituentNames_SalutationType]
GO
