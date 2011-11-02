
GO

/****** Object:  Table [dbo].[NextIds]    Script Date: 10/09/2010 14:04:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NextIds](
	[Type] [nvarchar](3) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[NextId] [int] NOT NULL,
 CONSTRAINT [PK_NextIds] PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


