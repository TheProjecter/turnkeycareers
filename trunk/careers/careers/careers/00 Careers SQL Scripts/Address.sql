USE [careers]
GO

/****** Object:  Table [dbo].[Address]    Script Date: 01/28/2012 07:47:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Address](
	[userName] [nvarchar](50) NOT NULL,
	[addressType] [nvarchar](50) NOT NULL,
	[unitNumber] [int] NOT NULL,
	[street] [nvarchar](50) NOT NULL,
	[suburb] [nvarchar](50) NOT NULL,
	[town] [nvarchar](50) NOT NULL,
	[province] [nvarchar](50) NOT NULL,
	[country] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_address] PRIMARY KEY CLUSTERED 
(
	[userName] ASC,
	[addressType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_address_username] FOREIGN KEY([userName])
REFERENCES [dbo].[Account] ([userName])
GO

ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_address_username]
GO

