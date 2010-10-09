USE [Kallivayalil]
GO

/****** Object:  Table [dbo].[Constituents]    Script Date: 10/09/2010 12:01:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Constituents](
	[Id] [int] NOT NULL,
	[BranchName] [int] NOT NULL,
	[HouseName] [nvarchar](50) NULL,
	[BornOn] [date] NULL,
	[DiedOn] [date] NULL,
	[HasExpired] [bit] NULL,
	[MaritialStatus] [int] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[IsRegistered] [bit] NOT NULL,	
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedDateTime] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,	
 CONSTRAINT [PK_Constituents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


