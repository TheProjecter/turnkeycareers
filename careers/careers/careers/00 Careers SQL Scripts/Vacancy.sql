USE [careers]
GO

/****** Object:  Table [dbo].[Vacancy]    Script Date: 01/28/2012 07:49:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vacancy](
	[vacancyNumber] [nvarchar](50) NOT NULL,
	[viewStatus] [nvarchar](50) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[department] [nvarchar](50) NOT NULL,
	[site] [nvarchar](50) NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
	[viewCount] [int] NOT NULL,
	[status] [nvarchar](50) NOT NULL,
	[manager] [nvarchar](50) NOT NULL,
	[recruiter] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Vacancy] PRIMARY KEY CLUSTERED 
(
	[vacancyNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

