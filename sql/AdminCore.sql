USE [AdminCore]
GO
/****** Object:  Table [dbo].[Sys_Function]    Script Date: 2019/8/27 0:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Function](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Code] [nvarchar](20) NULL,
	[Number] [int] NULL,
	[IsDelete] [bit] NULL,
	[CreateID] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateID] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_Sys_Function] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Menu]    Script Date: 2019/8/27 0:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Menu](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Url] [nvarchar](50) NULL,
	[ParentID] [nvarchar](50) NULL,
	[Number] [int] NULL,
	[Icon] [nvarchar](20) NULL,
	[IsParent] [bit] NULL,
	[Remark] [nvarchar](200) NULL,
	[IsDelete] [bit] NULL,
	[CreateID] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateID] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_Sys_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Menu_Function]    Script Date: 2019/8/27 0:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Menu_Function](
	[ID] [nvarchar](50) NOT NULL,
	[MenuID] [nvarchar](50) NULL,
	[FunctionID] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[CreateID] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateID] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_Sys_Menu_Function] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Role]    Script Date: 2019/8/27 0:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Role](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Code] [nvarchar](20) NULL,
	[Remark] [nvarchar](200) NULL,
	[IsDelete] [bit] NULL,
	[CreateID] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateID] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_Sys_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Role_Menu_Function]    Script Date: 2019/8/27 0:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Role_Menu_Function](
	[ID] [nvarchar](50) NOT NULL,
	[RoleID] [nvarchar](50) NULL,
	[MenuID] [nvarchar](50) NULL,
	[FunctionID] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[CreateID] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateID] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_Sys_Role_Menu_Function] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_User]    Script Date: 2019/8/27 0:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_User](
	[ID] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](20) NULL,
	[UserPwd] [nvarchar](50) NULL,
	[RealName] [nvarchar](20) NULL,
	[Age] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[IsAdmin] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreateID] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateID] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_Sys_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_User_Role]    Script Date: 2019/8/27 0:53:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_User_Role](
	[ID] [nvarchar](50) NOT NULL,
	[UserID] [nvarchar](50) NULL,
	[RoleID] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[CreateID] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[UpdateID] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_Sys_User_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Sys_Function] ([ID], [Name], [Code], [Number], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'4A3CF571-47C5-4990-BD1A-CF6BDF6FA088', N'新增', N'Insert', 2, NULL, NULL, CAST(N'2019-03-22T01:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Function] ([ID], [Name], [Code], [Number], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'CB670444-09CA-4BA3-ADC2-50454879BED8', N'详情', N'Detail', 5, NULL, NULL, CAST(N'2019-03-22T01:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Function] ([ID], [Name], [Code], [Number], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'ED66AC82-DB6F-41F0-8575-BE959479C446', N'显示', N'View', 1, NULL, NULL, CAST(N'2019-03-22T01:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Function] ([ID], [Name], [Code], [Number], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'EE2F37C4-B101-4623-9D57-194846D5C549', N'修改', N'Update', 3, NULL, NULL, CAST(N'2019-03-22T01:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Function] ([ID], [Name], [Code], [Number], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'F6798AAC-AAFE-474C-AE65-049D9EC93035', N'删除', N'Delete', 4, NULL, NULL, CAST(N'2019-03-22T01:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'0452FA83-A546-4049-A2A2-8FE61FAA85E1', N'授权测试', N'/Auth/AuthTest', N'EE2AB269-3D03-4F9E-967E-976F6A0D84C7', 14, NULL, 0, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'1C1CF97B-B2F7-41B2-914F-0420052AD99F', N'评分', N'/Other/Score', N'AB13CBEE-E007-4E6D-AAE7-AED85742792C', 13, NULL, 0, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'2D4985AB-3C2D-450B-AAF0-608AA9038889', N'普通用户权限', N'/Auth/UserTest', N'EE2AB269-3D03-4F9E-967E-976F6A0D84C7', 9, NULL, 0, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'53BAFFA1-D651-4044-A302-FD52608B1D60', N'功能管理', N'/Function/Index', N'8725361D-F2E1-4431-8D57-35C0E6F54231', 3, NULL, 0, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'7C5C4B93-7E75-4181-9503-479D1649D49E', N'菜单管理', N'/Menu/Index', N'8725361D-F2E1-4431-8D57-35C0E6F54231', 4, NULL, 0, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'8725361D-F2E1-4431-8D57-35C0E6F54231', N'权限管理', NULL, N'0', 1, NULL, 1, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'AB13CBEE-E007-4E6D-AAE7-AED85742792C', N'组件', NULL, N'EC44358E-8A0D-4F5E-BBA5-C49578745C50', 11, NULL, 1, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'E287BFF7-B536-4E99-BE35-B92E95DD55C9', N'管理员权限', N'/Auth/AdminTest', N'EE2AB269-3D03-4F9E-967E-976F6A0D84C7', 8, NULL, 0, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'EC44358E-8A0D-4F5E-BBA5-C49578745C50', N'其他', NULL, N'0', 10, NULL, 1, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'ED78EF7A-891E-4F53-A0E4-0C7EC310D72B', N'权限分配', N'/Auth/Index', N'8725361D-F2E1-4431-8D57-35C0E6F54231', 6, NULL, 0, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'EE2AB269-3D03-4F9E-967E-976F6A0D84C7', N'测试页面', NULL, N'0', 7, NULL, 1, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'F67DCA5A-0518-4D12-9FB3-7C8AD5F6EFE0', N'用户管理', N'/User/Index', N'8725361D-F2E1-4431-8D57-35C0E6F54231', 2, NULL, 0, NULL, NULL, NULL, CAST(N'2019-03-23T10:13:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Menu] ([ID], [Name], [Url], [ParentID], [Number], [Icon], [IsParent], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'FFC6246E-2968-4607-AF51-B09034CF05F3', N'角色管理', N'/Role/Index', N'8725361D-F2E1-4431-8D57-35C0E6F54231', 5, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'00802CA9-B65A-4AEB-B114-69BBF5FB1887', N'E287BFF7-B536-4E99-BE35-B92E95DD55C9', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'0EB07E94-EF0B-4B89-9760-427D732ADEE7', N'FFC6246E-2968-4607-AF51-B09034CF05F3', N'EE2F37C4-B101-4623-9D57-194846D5C549', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'18D748A0-B91C-413D-8224-53E12044DDC3', N'1C1CF97B-B2F7-41B2-914F-0420052AD99F', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'23B612B6-D7C0-4862-B629-0A7583F63E79', N'53BAFFA1-D651-4044-A302-FD52608B1D60', N'4A3CF571-47C5-4990-BD1A-CF6BDF6FA088', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'2EF57482-87E9-4AEC-AEAB-7AE9AE7F80CA', N'0452FA83-A546-4049-A2A2-8FE61FAA85E1', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'30220372-42DE-45EA-BAE9-E2BAAF9D3DD9', N'7C5C4B93-7E75-4181-9503-479D1649D49E', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'35078352-F8EF-415E-8EA6-4293FB79C213', N'F67DCA5A-0518-4D12-9FB3-7C8AD5F6EFE0', N'4A3CF571-47C5-4990-BD1A-CF6BDF6FA088', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'3C5DC3B1-B2C4-4562-867D-1C6F9DF3CBF7', N'53BAFFA1-D651-4044-A302-FD52608B1D60', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'445DB3C7-E829-499D-829D-5B22E5510B5A', N'ED78EF7A-891E-4F53-A0E4-0C7EC310D72B', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'639960E2-2E8F-4939-A40E-2BED25EE9EA5', N'FFC6246E-2968-4607-AF51-B09034CF05F3', N'4A3CF571-47C5-4990-BD1A-CF6BDF6FA088', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'67A289CD-3E59-43EC-AE9D-6BB35B9FC3F8', N'F67DCA5A-0518-4D12-9FB3-7C8AD5F6EFE0', N'F6798AAC-AAFE-474C-AE65-049D9EC93035', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'686C4357-9273-424F-9673-711A6DAA55EF', N'F67DCA5A-0518-4D12-9FB3-7C8AD5F6EFE0', N'EE2F37C4-B101-4623-9D57-194846D5C549', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'730B13E0-ABDB-4957-AE89-29D0A7096BF8', N'7C5C4B93-7E75-4181-9503-479D1649D49E', N'EE2F37C4-B101-4623-9D57-194846D5C549', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'74244FC1-0D42-4E0A-B4D5-5477874CA6F1', N'FFC6246E-2968-4607-AF51-B09034CF05F3', N'CB670444-09CA-4BA3-ADC2-50454879BED8', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'76D0D88C-B16D-421F-8F9A-5CB2D1E8E93B', N'2D4985AB-3C2D-450B-AAF0-608AA9038889', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'7E97B16B-8C97-4EA7-BE83-C0E5AB9D4051', N'F67DCA5A-0518-4D12-9FB3-7C8AD5F6EFE0', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'8D78A2AF-9200-450E-8244-12F9A73533E1', N'53BAFFA1-D651-4044-A302-FD52608B1D60', N'F6798AAC-AAFE-474C-AE65-049D9EC93035', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'980C3CB4-0F50-4BD3-AF28-22F0CEEA91F1', N'FFC6246E-2968-4607-AF51-B09034CF05F3', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'997678F4-539A-4525-997F-0AE89D096027', N'FFC6246E-2968-4607-AF51-B09034CF05F3', N'F6798AAC-AAFE-474C-AE65-049D9EC93035', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'ADDD5CEB-AA97-49E1-ABEC-64099DCFEC10', N'53BAFFA1-D651-4044-A302-FD52608B1D60', N'CB670444-09CA-4BA3-ADC2-50454879BED8', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'C2550660-C0AE-4A61-B9CD-1AA9BCB49CDF', N'7C5C4B93-7E75-4181-9503-479D1649D49E', N'4A3CF571-47C5-4990-BD1A-CF6BDF6FA088', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'D2A102B5-6371-487C-A5BC-119DCF4E418D', N'7C5C4B93-7E75-4181-9503-479D1649D49E', N'F6798AAC-AAFE-474C-AE65-049D9EC93035', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'D8494BE3-5EC6-4E5B-BAEE-CB3DF661CF93', N'7C5C4B93-7E75-4181-9503-479D1649D49E', N'CB670444-09CA-4BA3-ADC2-50454879BED8', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'E4164BA5-9C2C-4816-A55B-6A27A52AC40F', N'53BAFFA1-D651-4044-A302-FD52608B1D60', N'EE2F37C4-B101-4623-9D57-194846D5C549', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Menu_Function] ([ID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'FA33429F-0EBF-43FA-ABAE-B419A853E039', N'F67DCA5A-0518-4D12-9FB3-7C8AD5F6EFE0', N'CB670444-09CA-4BA3-ADC2-50454879BED8', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Role] ([ID], [Name], [Code], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'C7967D2A-5CE7-4D80-B578-A13646945C45', N'普通用户', N'user', NULL, NULL, NULL, CAST(N'2019-03-23T10:20:39.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Role] ([ID], [Name], [Code], [Remark], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'E6B06333-53DA-4C03-9745-F9727ED66867', N'管理员', N'Admin', NULL, NULL, NULL, CAST(N'2019-03-23T10:20:39.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_Role_Menu_Function] ([ID], [RoleID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'01BAA761-74E9-4271-8DFC-30BB02382A2C', N'C7967D2A-5CE7-4D80-B578-A13646945C45', N'FFC6246E-2968-4607-AF51-B09034CF05F3', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Role_Menu_Function] ([ID], [RoleID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'274701C2-3241-49CB-9C35-BB24FEF9EBDD', N'C7967D2A-5CE7-4D80-B578-A13646945C45', N'53BAFFA1-D651-4044-A302-FD52608B1D60', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Role_Menu_Function] ([ID], [RoleID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'3864D889-4004-4792-8A63-0046FCD1ED58', N'C7967D2A-5CE7-4D80-B578-A13646945C45', N'1C1CF97B-B2F7-41B2-914F-0420052AD99F', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Role_Menu_Function] ([ID], [RoleID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'6A43B548-F571-471F-A215-AFFD9151D6FC', N'C7967D2A-5CE7-4D80-B578-A13646945C45', N'F67DCA5A-0518-4D12-9FB3-7C8AD5F6EFE0', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Role_Menu_Function] ([ID], [RoleID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'6ADA5CDE-12FC-47E7-9AB9-8D16749B55AC', N'C7967D2A-5CE7-4D80-B578-A13646945C45', N'F67DCA5A-0518-4D12-9FB3-7C8AD5F6EFE0', N'CB670444-09CA-4BA3-ADC2-50454879BED8', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Role_Menu_Function] ([ID], [RoleID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'6BC3F187-C218-4111-A651-8E5818BD3984', N'C7967D2A-5CE7-4D80-B578-A13646945C45', N'7C5C4B93-7E75-4181-9503-479D1649D49E', N'CB670444-09CA-4BA3-ADC2-50454879BED8', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Role_Menu_Function] ([ID], [RoleID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'9C6E97EA-9F91-4DD7-8F93-347079F3B28B', N'C7967D2A-5CE7-4D80-B578-A13646945C45', N'53BAFFA1-D651-4044-A302-FD52608B1D60', N'CB670444-09CA-4BA3-ADC2-50454879BED8', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Role_Menu_Function] ([ID], [RoleID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'A2882CB9-F476-41F8-B93B-3A2FB45779B3', N'C7967D2A-5CE7-4D80-B578-A13646945C45', N'FFC6246E-2968-4607-AF51-B09034CF05F3', N'CB670444-09CA-4BA3-ADC2-50454879BED8', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Role_Menu_Function] ([ID], [RoleID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'A4138AA3-9682-45F7-BCE6-6511041C98DF', N'C7967D2A-5CE7-4D80-B578-A13646945C45', N'7C5C4B93-7E75-4181-9503-479D1649D49E', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_Role_Menu_Function] ([ID], [RoleID], [MenuID], [FunctionID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'BB8FFD62-FEEB-4EBE-923F-A0523DDE401A', N'C7967D2A-5CE7-4D80-B578-A13646945C45', N'2D4985AB-3C2D-450B-AAF0-608AA9038889', N'ED66AC82-DB6F-41F0-8575-BE959479C446', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Sys_User] ([ID], [UserName], [UserPwd], [RealName], [Age], [Email], [Phone], [IsAdmin], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'09A19C87-ACE1-4A67-AFB9-CE7AA9E4C67B', N'admin', N'123', N'管理员', 30, N'admin134@qq.com', N'13367974546', 1, 0, NULL, CAST(N'2019-03-24T10:20:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_User] ([ID], [UserName], [UserPwd], [RealName], [Age], [Email], [Phone], [IsAdmin], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'AFF4F87C-F715-46D0-B79A-66184EDA08C9', N'user', N'123', N'普通用户', 20, N'user345@163.com', N'18888888888', 0, 0, NULL, CAST(N'2019-03-24T10:20:39.560' AS DateTime), NULL, NULL)
INSERT [dbo].[Sys_User_Role] ([ID], [UserID], [RoleID], [IsDelete], [CreateID], [CreateTime], [UpdateID], [UpdateTime]) VALUES (N'ACAABE97-8D32-41EB-9CE8-38526DAF14EC', N'AFF4F87C-F715-46D0-B79A-66184EDA08C9', N'C7967D2A-5CE7-4D80-B578-A13646945C45', NULL, NULL, NULL, NULL, NULL)
USE [master]
GO
ALTER DATABASE [AdminCore] SET  READ_WRITE 
GO