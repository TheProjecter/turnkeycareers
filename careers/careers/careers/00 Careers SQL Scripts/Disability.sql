USE [careers]
GO

/****** Object:  Table [dbo].[Disability]    Script Date: 01/28/2012 07:48:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Disability](
	[userName] [nvarchar](50) NOT NULL,
	[disabilityType] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Disability] PRIMARY KEY CLUSTERED 
(
	[userName] ASC,
	[disabilityType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Disability]  WITH CHECK ADD  CONSTRAINT [FK_Disability_Account] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[Disability] CHECK CONSTRAINT [FK_Disability_Account]
GO

