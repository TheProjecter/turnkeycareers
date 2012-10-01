USE [careers]
GO

/****** Object:  Table [dbo].[Language]    Script Date: 01/28/2012 07:48:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Language](
	[userName] [nvarchar](50) NOT NULL,
	[languageName] [nvarchar](50) NOT NULL,
	[reads] [nvarchar](50) NOT NULL,
	[write] [nvarchar](50) NOT NULL,
	[speak] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED 
(
	[userName] ASC,
	[languageName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Language]  WITH CHECK ADD  CONSTRAINT [FK_Language_Account] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[Language] CHECK CONSTRAINT [FK_Language_Account]
GO

