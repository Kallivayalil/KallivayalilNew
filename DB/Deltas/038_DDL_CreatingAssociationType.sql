USE [Kallivayalil]
GO

/****** Object:  Table [dbo].[AssocationType]    Script Date: 01/29/2011 15:47:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AssociationType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[ReciprocalType] [int] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDateTime] [datetime] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AssociationType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[AssociationType]  WITH CHECK ADD  CONSTRAINT [FK_AssociationType_Reciprocal_AssociationType] FOREIGN KEY([ReciprocalType])
REFERENCES [dbo].[AssociationType] ([Id])
GO

ALTER TABLE [dbo].[AssociationType] CHECK CONSTRAINT [FK_AssociationType_Reciprocal_AssociationType]
GO


SET ANSI_PADDING OFF
GO


