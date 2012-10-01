USE [careers]
GO

/****** Object:  Table [dbo].[KeyWord]    Script Date: 01/28/2012 07:48:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[KeyWord](
	[vacancyNumber] [nvarchar](50) NOT NULL,
	[word] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_KeyWord] PRIMARY KEY CLUSTERED 
(
	[vacancyNumber] ASC,
	[word] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[KeyWord]  WITH CHECK ADD  CONSTRAINT [FK_KeyWord_Vacancy] FOREIGN KEY([vacancyNumber])
REFERENCES [dbo].[Vacancy] ([vacancyNumber])
GO

ALTER TABLE [dbo].[KeyWord] CHECK CONSTRAINT [FK_KeyWord_Vacancy]
GO

