USE [Factory]
GO
/****** Object:  Table [dbo].[DetailDirectory]    Script Date: 10.05.2023 16:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailDirectory](
	[DetailCode] [int] IDENTITY(1,1) NOT NULL,
	[DetailName] [nchar](10) NULL,
	[Cost] [int] NULL,
 CONSTRAINT [PK_DetailDirectory] PRIMARY KEY CLUSTERED 
(
	[DetailCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCompound]    Script Date: 10.05.2023 16:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCompound](
	[ProductCode] [int] NOT NULL,
	[DetailCode] [int] NOT NULL,
	[DetailCount] [int] NULL,
 CONSTRAINT [PK_ProductCompound_1] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC,
	[DetailCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDirectory]    Script Date: 10.05.2023 16:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDirectory](
	[ProductCode] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nchar](10) NULL,
	[MakeCost] [int] NULL,
 CONSTRAINT [PK_Справочник изделий] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReleasePlan]    Script Date: 10.05.2023 16:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReleasePlan](
	[ProductCode] [int] IDENTITY(1,1) NOT NULL,
	[ProductCount] [int] NULL,
	[WorkshopCode] [int] NULL,
 CONSTRAINT [PK_ReleasePlan] PRIMARY KEY CLUSTERED 
(
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workshop]    Script Date: 10.05.2023 16:26:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workshop](
	[WorkshopCode] [int] IDENTITY(1,1) NOT NULL,
	[WorkshopName] [nchar](10) NULL,
	[Boss] [nchar](10) NULL,
 CONSTRAINT [PK_Workshop] PRIMARY KEY CLUSTERED 
(
	[WorkshopCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductCompound]  WITH CHECK ADD  CONSTRAINT [FK_ProductCompound_DetailDirectory] FOREIGN KEY([DetailCode])
REFERENCES [dbo].[DetailDirectory] ([DetailCode])
GO
ALTER TABLE [dbo].[ProductCompound] CHECK CONSTRAINT [FK_ProductCompound_DetailDirectory]
GO
ALTER TABLE [dbo].[ProductCompound]  WITH CHECK ADD  CONSTRAINT [FK_ProductCompound_ProductDirectory] FOREIGN KEY([ProductCode])
REFERENCES [dbo].[ProductDirectory] ([ProductCode])
GO
ALTER TABLE [dbo].[ProductCompound] CHECK CONSTRAINT [FK_ProductCompound_ProductDirectory]
GO
ALTER TABLE [dbo].[ReleasePlan]  WITH CHECK ADD  CONSTRAINT [FK_ReleasePlan_ProductDirectory] FOREIGN KEY([ProductCode])
REFERENCES [dbo].[ProductDirectory] ([ProductCode])
GO
ALTER TABLE [dbo].[ReleasePlan] CHECK CONSTRAINT [FK_ReleasePlan_ProductDirectory]
GO
ALTER TABLE [dbo].[ReleasePlan]  WITH CHECK ADD  CONSTRAINT [FK_ReleasePlan_Workshop] FOREIGN KEY([WorkshopCode])
REFERENCES [dbo].[Workshop] ([WorkshopCode])
GO
ALTER TABLE [dbo].[ReleasePlan] CHECK CONSTRAINT [FK_ReleasePlan_Workshop]
GO
