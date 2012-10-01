USE [careers]
GO

/****** Object:  Table [dbo].[VacancyKillerQuestion]    Script Date: 01/28/2012 07:49:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VacancyKillerQuestion](
	[vacancyNumber] [nvarchar](50) NOT NULL,
	[question] [nvarchar](50) NOT NULL,
	[answer] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_VacancyKillerQuestion] PRIMARY KEY CLUSTERED 
(
	[vacancyNumber] ASC,
	[question] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[VacancyKillerQuestion]  WITH CHECK ADD  CONSTRAINT [FK_VacancyKillerQuestion_Vacancy] FOREIGN KEY([vacancyNumber])
REFERENCES [dbo].[Vacancy] ([vacancyNumber])
GO

ALTER TABLE [dbo].[VacancyKillerQuestion] CHECK CONSTRAINT [FK_VacancyKillerQuestion_Vacancy]
GO

