USE [careers]
GO

/****** Object:  Table [dbo].[Inbox]    Script Date: 01/28/2012 07:48:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Inbox](
	[userName] [nvarchar](50) NOT NULL,
	[messageId] [int] NOT NULL,
	[date] [date] NOT NULL,
	[unread] [nvarchar](50) NOT NULL,
	[message] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Inbox] PRIMARY KEY CLUSTERED 
(
	[userName] ASC,
	[messageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Inbox]  WITH CHECK ADD  CONSTRAINT [FK_Inbox_Account] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[Inbox] CHECK CONSTRAINT [FK_Inbox_Account]
GO

