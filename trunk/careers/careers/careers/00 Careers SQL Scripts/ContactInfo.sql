USE [careers]
GO

/****** Object:  Table [dbo].[ContactInfo]    Script Date: 01/28/2012 07:47:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContactInfo](
	[userName] [nvarchar](50) NOT NULL,
	[contactType] [nvarchar](50) NOT NULL,
	[data] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_contactinfo] PRIMARY KEY CLUSTERED 
(
	[userName] ASC,
	[contactType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ContactInfo]  WITH CHECK ADD  CONSTRAINT [FK_contactinfo_username] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[ContactInfo] CHECK CONSTRAINT [FK_contactinfo_username]
GO

