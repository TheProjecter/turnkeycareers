USE [careers]
GO

/****** Object:  Table [dbo].[BasicEdu]    Script Date: 01/28/2012 07:47:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BasicEdu](
	[userName] [nvarchar](50) NOT NULL,
	[school] [nvarchar](50) NOT NULL,
	[town] [nvarchar](50) NOT NULL,
	[province] [nvarchar](50) NOT NULL,
	[country] [nvarchar](50) NOT NULL,
	[levelCompleted] [int] NOT NULL,
 CONSTRAINT [PK_BasicEdu] PRIMARY KEY CLUSTERED 
(
	[userName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BasicEdu]  WITH CHECK ADD  CONSTRAINT [FK_BasicEdu_account] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[BasicEdu] CHECK CONSTRAINT [FK_BasicEdu_account]
GO

