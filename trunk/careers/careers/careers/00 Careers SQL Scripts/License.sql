USE [careers]
GO

/****** Object:  Table [dbo].[License]    Script Date: 01/28/2012 07:48:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[License](
	[userName] [nvarchar](50) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_License] PRIMARY KEY CLUSTERED 
(
	[userName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[License]  WITH CHECK ADD  CONSTRAINT [FK_License_Account] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[License] CHECK CONSTRAINT [FK_License_Account]
GO

