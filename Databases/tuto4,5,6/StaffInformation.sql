USE [CsharpTuto]
GO
/****** Object:  Table [dbo].[StaffInformation]    Script Date: 3/18/2024 11:53:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffInformation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varchar](250) NULL,
	[Name] [varchar](50) NOT NULL,
	[JoinFrom] [date] NOT NULL,
	[StaffType] [varchar](10) NOT NULL,
	[NrcNo] [varchar](50) NOT NULL,
	[Gender] [varchar](10) NULL,
	[PhoneNo1] [varchar](9) NOT NULL,
	[PhoneNo2] [varchar](9) NULL,
	[Address] [varchar](300) NULL,
	[BirthDate] [date] NOT NULL
) ON [PRIMARY]
GO