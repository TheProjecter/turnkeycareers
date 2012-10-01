USE [careers]
GO

/****** Object:  Table [dbo].[User]    Script Date: 01/28/2012 07:49:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[id] [nvarchar](50) NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[fullname] [nvarchar](50) NOT NULL,
	[nickName] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[gender] [nvarchar](50) NOT NULL,
	[race] [nvarchar](50) NOT NULL,
	[disabled] [bit] NOT NULL,
	[citizenship] [bit] NOT NULL,
	[idType] [nvarchar](50) NOT NULL,
	[license] [bit] NOT NULL,
	[basicEducation] [bit] NOT NULL,
	[higherEducaton] [bit] NOT NULL,
	[language] [bit] NOT NULL,
	[residentialAddress] [bit] NOT NULL,
	[postalAddress] [bit] NOT NULL,
	[employed] [bit] NOT NULL,
	[employmentHistory] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_account] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_account]
GO

