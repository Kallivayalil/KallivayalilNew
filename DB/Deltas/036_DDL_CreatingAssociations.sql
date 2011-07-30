USE [Kallivayalil]
GO

/****** Object:  Table [dbo].[Associations]    Script Date: 11/13/2010 17:13:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Associations](
	[Id] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[ConstituentId] [int] NOT NULL,
	[AssociatedConstituentId] [int] NULL,
	[AssociatedConstituentName] [varchar](50) NULL,
	[ReciprocalId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDateTime] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Associations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Associations]  WITH CHECK ADD  CONSTRAINT [FK_Associations_Reciprocal_Association] FOREIGN KEY([ReciprocalId])
REFERENCES [dbo].[Associations] ([Id])
GO

ALTER TABLE [dbo].[Associations] CHECK CONSTRAINT [FK_Associations_Reciprocal_Association]
GO


ALTER TABLE [dbo].[Associations]  WITH CHECK ADD  CONSTRAINT [FK_Associations_Constituents] FOREIGN KEY([ConstituentId])
REFERENCES [dbo].[Constituents] ([Id])
GO

ALTER TABLE [dbo].[Associations] CHECK CONSTRAINT [FK_Associations_Constituents]
GO

ALTER TABLE [dbo].[Associations]  WITH CHECK ADD  CONSTRAINT [FK_Associations_Assoc_Constituents] FOREIGN KEY([AssociatedConstituentId])
REFERENCES [dbo].[Constituents] ([Id])
GO

ALTER TABLE [dbo].[Associations] CHECK CONSTRAINT [FK_Associations_Assoc_Constituents]
GO

