USE [careers]
GO

/****** Object:  Table [dbo].[Employment]    Script Date: 01/28/2012 07:48:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employment](
	[userName] [nvarchar](50) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[company] [nvarchar](50) NOT NULL,
	[industry] [nvarchar](50) NOT NULL,
	[town] [nvarchar](50) NOT NULL,
	[province] [nvarchar](50) NOT NULL,
	[country] [nvarchar](50) NOT NULL,
	[empType] [nvarchar](50) NOT NULL,
	[currentEmployer] [nvarchar](50) NOT NULL,
	[gross] [money] NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
	[responsibilities] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employment] PRIMARY KEY CLUSTERED 
(
	[userName] ASC,
	[startDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Employment]  WITH CHECK ADD  CONSTRAINT [FK_Employment_Account] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[Employment] CHECK CONSTRAINT [FK_Employment_Account]
GO

