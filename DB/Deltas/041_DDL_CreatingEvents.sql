
GO

/****** Object:  Table [dbo].[Events]    Script Date: 11/13/2010 17:13:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Events](
	[Id] [int] NOT NULL,
	[Type] [int] NOT NULL,	
	[IsApproved] [int] NOT NULL,	
	[EventTitle]  [varchar](50) NOT NULL,
	[EventDescription]  [varchar](50) NULL,
	[ContactPerson]  [varchar](50) NULL,
	[ContactNumber]  [varchar](20) NULL,
	[ConstituentId] [int] NULL,	
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDateTime] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Constituent] FOREIGN KEY([ConstituentId])
REFERENCES [dbo].[Constituents] ([Id])
GO

ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Constituent]
GO


