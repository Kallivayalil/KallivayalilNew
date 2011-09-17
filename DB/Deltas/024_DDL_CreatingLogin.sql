USE [Kallivayalil]
GO
/****** Object:  Table [dbo].[Logins]    Script Date: 05/14/2011 13:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Logins](
	[Id] [int] NOT NULL,
	[Email] [int] NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedDateTime] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Logins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Logins]  WITH CHECK ADD  CONSTRAINT [FK_Logins_Emails] FOREIGN KEY([Email])
REFERENCES [dbo].[Emails] ([Id])
GO
ALTER TABLE [dbo].[Logins] CHECK CONSTRAINT [FK_Logins_Emails]


if( (select COUNT(*) from Kallivayalil.dbo.NextIds a where a.type = 'LGN' )= 0)
INSERT INTO [NextIds]
           ([Type]
           ,[Description]
           ,[NextId])
     VALUES  ('LGN','Logins',10)
GO
