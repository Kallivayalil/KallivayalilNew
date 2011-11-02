
GO

/****** Object:  Table [dbo].[Phones]    Script Date: 11/13/2010 17:13:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Phones](
	[Id] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Number] [varchar](20) NOT NULL,
	[IsPrimary] [bit] NOT NULL default 1,
	[Inactive] [bit] NOT NULL default 0,
	[AddressId] [int] NULL,
	[ConstituentId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDateTime] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Phones]  WITH CHECK ADD  CONSTRAINT [FK_Phones_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([Id])
GO

ALTER TABLE [dbo].[Phones] CHECK CONSTRAINT [FK_Phones_Addresses]
GO

ALTER TABLE [dbo].[Phones]  WITH CHECK ADD  CONSTRAINT [FK_Phones_Constituents] FOREIGN KEY([ConstituentId])
REFERENCES [dbo].[Constituents] ([Id])
GO

ALTER TABLE [dbo].[Phones] CHECK CONSTRAINT [FK_Phones_Constituents]
GO

