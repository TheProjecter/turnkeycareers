USE [careers]
GO

/****** Object:  Table [dbo].[HigherEducation]    Script Date: 01/28/2012 07:48:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HigherEducation](
	[userName] [nvarchar](50) NOT NULL,
	[institution] [nvarchar](50) NOT NULL,
	[town] [nvarchar](50) NOT NULL,
	[province] [nvarchar](50) NOT NULL,
	[country] [nvarchar](50) NOT NULL,
	[educationType] [nvarchar](50) NOT NULL,
	[major] [nvarchar](50) NOT NULL,
	[industry] [nvarchar](50) NOT NULL,
	[length] [nvarchar](50) NOT NULL,
	[nqf] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HigherEducation] PRIMARY KEY CLUSTERED 
(
	[userName] ASC,
	[major] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[HigherEducation]  WITH CHECK ADD  CONSTRAINT [FK_HigherEducation_account] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[HigherEducation] CHECK CONSTRAINT [FK_HigherEducation_account]
GO

