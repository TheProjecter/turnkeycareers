USE [careers]
GO

/****** Object:  Table [dbo].[supportDoc]    Script Date: 01/28/2012 07:49:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[supportDoc](
	[title] [nvarchar](100) NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[content] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_supportDoc] PRIMARY KEY CLUSTERED 
(
	[title] ASC,
	[userName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[supportDoc]  WITH CHECK ADD  CONSTRAINT [FK_supportDoc_Account] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[supportDoc] CHECK CONSTRAINT [FK_supportDoc_Account]
GO

