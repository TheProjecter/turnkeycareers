USE [careers]
GO

/****** Object:  Table [dbo].[BasicEduSubject]    Script Date: 01/28/2012 07:47:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BasicEduSubject](
	[userName] [nvarchar](50) NOT NULL,
	[subjectName] [nvarchar](50) NOT NULL,
	[subjectDescription] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BasicEduSubject] PRIMARY KEY CLUSTERED 
(
	[userName] ASC,
	[subjectName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BasicEduSubject]  WITH CHECK ADD  CONSTRAINT [FK_BasicEduSubject_BasicEdu] FOREIGN KEY([userName])
REFERENCES [dbo].[BasicEdu] ([userName])
GO

ALTER TABLE [dbo].[BasicEduSubject] CHECK CONSTRAINT [FK_BasicEduSubject_BasicEdu]
GO

