USE [PortalDB]
GO
/****** Object:  Table [dbo].[PortalRole]    Script Date: 2021/07/27 11:10:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortalRole](
	[PortalRoleId] [int] IDENTITY(1,1) NOT NULL,
	[PortalRoleDescription] [varchar](50) NOT NULL,
	[Company] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_PortalRole] PRIMARY KEY CLUSTERED 
(
	[PortalRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PortalUser]    Script Date: 2021/07/27 11:10:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortalUser](
	[UserId] [varchar](50) NOT NULL,
	[Nane] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
	[Division] [varchar](50) NOT NULL,
	[Department] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Email] [varchar](500) NOT NULL,
 CONSTRAINT [PK_PortalUser_1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PortalUserRole]    Script Date: 2021/07/27 11:10:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortalUserRole](
	[UserId] [varchar](50) NOT NULL,
	[PortalRoleId] [int] NOT NULL,
	[RoleDescription] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PortalUserRole]  WITH CHECK ADD  CONSTRAINT [FK_PortalUserRole_PortalRole] FOREIGN KEY([PortalRoleId])
REFERENCES [dbo].[PortalRole] ([PortalRoleId])
GO
ALTER TABLE [dbo].[PortalUserRole] CHECK CONSTRAINT [FK_PortalUserRole_PortalRole]
GO
ALTER TABLE [dbo].[PortalUserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[PortalUser] ([UserId])
GO
ALTER TABLE [dbo].[PortalUserRole] CHECK CONSTRAINT [FK_UserId]
GO


