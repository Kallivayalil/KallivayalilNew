USE [Kallivayalil]
GO

/****** Object:  Table [dbo].[Committees]    Script Date: 11/13/2010 17:13:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Committees](
	[Id] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[StartYear] [varchar](4) NOT NULL,
	[EndYear] [varchar](4) NOT NULL,
	[ConstituentId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDateTime] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Committees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Committees]  WITH CHECK ADD  CONSTRAINT [FK_Committees_Constituents] FOREIGN KEY([ConstituentId])
REFERENCES [dbo].[Constituents] ([Id])
GO

ALTER TABLE [dbo].[Committees] CHECK CONSTRAINT [FK_Committees_Constituents]
GO

