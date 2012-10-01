USE [careers]
GO

/****** Object:  Table [dbo].[Application]    Script Date: 01/28/2012 07:47:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Application](
	[userName] [nvarchar](50) NOT NULL,
	[vacancyNumber] [nvarchar](50) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[userName] ASC,
	[vacancyNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Account] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Account]
GO

ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Vacancy] FOREIGN KEY([vacancyNumber])
REFERENCES [dbo].[Vacancy] ([vacancyNumber])
GO

ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Vacancy]
GO

