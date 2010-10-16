USE [Kallivayalil]
GO

/****** Object:  Table [dbo].[ConstituentNames]    Script Date: 10/16/2010 14:52:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ConstituentNames](
	[Id] [int] NOT NULL,
	[ConstituentId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[PreferedName] [varchar](50) NULL,
	[Salutation] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDateTime] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ConstituentNames] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ConstituentNames]  WITH CHECK ADD  CONSTRAINT [FK_ConstituentNames_Constituents] FOREIGN KEY([ConstituentId])
REFERENCES [dbo].[Constituents] ([Id])
GO

ALTER TABLE [dbo].[ConstituentNames] CHECK CONSTRAINT [FK_ConstituentNames_Constituents]
GO


