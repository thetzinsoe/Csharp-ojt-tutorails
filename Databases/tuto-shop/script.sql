USE [ShopProductDb]
GO
/****** Object:  Table [dbo].[ProductTable]    Script Date: 3/28/2024 4:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTable](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[PrductImage] [nvarchar](200) NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[IsDeleted] [smallint] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[UpdatedUserId] [int] NOT NULL,
	[DeletedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[UpdatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ProductTable] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopProductTable]    Script Date: 3/28/2024 4:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopProductTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShopId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[IsDeleted] [smallint] NOT NULL,
 CONSTRAINT [PK_ShopProductTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopTable]    Script Date: 3/28/2024 4:25:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopTable](
	[ShopId] [int] IDENTITY(1,1) NOT NULL,
	[ShopName] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
	[IsDeleted] [smallint] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[UpdatedUserId] [int] NOT NULL,
	[DeletedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[UpdatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ShopTable] PRIMARY KEY CLUSTERED 
(
	[ShopId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductTable] ADD  CONSTRAINT [DF_ProductTable_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ProductTable] ADD  CONSTRAINT [DF_ProductTable_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[ProductTable] ADD  CONSTRAINT [DF_ProductTable_UpdatedDateTime]  DEFAULT (getdate()) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[ShopProductTable] ADD  CONSTRAINT [DF_ShopProductTable_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ShopTable] ADD  CONSTRAINT [DF_ShopTable_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[ShopTable] ADD  CONSTRAINT [DF_ShopTable_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[ShopTable] ADD  CONSTRAINT [DF_ShopTable_UpdatedDateTime]  DEFAULT (getdate()) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[ShopProductTable]  WITH CHECK ADD  CONSTRAINT [FK_ShopProductTable_ProductTable] FOREIGN KEY([ProductId])
REFERENCES [dbo].[ProductTable] ([ProductId])
GO
ALTER TABLE [dbo].[ShopProductTable] CHECK CONSTRAINT [FK_ShopProductTable_ProductTable]
GO
ALTER TABLE [dbo].[ShopProductTable]  WITH CHECK ADD  CONSTRAINT [FK_ShopProductTable_ShopTable] FOREIGN KEY([ShopId])
REFERENCES [dbo].[ShopTable] ([ShopId])
GO
ALTER TABLE [dbo].[ShopProductTable] CHECK CONSTRAINT [FK_ShopProductTable_ShopTable]
GO
