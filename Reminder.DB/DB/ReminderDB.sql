USE [ReminderDB]
GO
/****** Object:  Table [dbo].[CategoryTbl]    Script Date: 1/16/2023 11:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryTbl](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[CreatedBy] [int] NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReminderTbl]    Script Date: 1/16/2023 11:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReminderTbl](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[CategoryID] [int] NULL,
	[CreatedBy] [int] NULL,
	[ReminderDate] [datetime] NULL,
 CONSTRAINT [PK_Reminder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTbl]    Script Date: 1/16/2023 11:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTbl](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserTbl] ADD  CONSTRAINT [DF_Users_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[CategoryTbl]  WITH CHECK ADD  CONSTRAINT [FK_CategoryTbl_CategoryTbl] FOREIGN KEY([ParentID])
REFERENCES [dbo].[CategoryTbl] ([ID])
GO
ALTER TABLE [dbo].[CategoryTbl] CHECK CONSTRAINT [FK_CategoryTbl_CategoryTbl]
GO
ALTER TABLE [dbo].[CategoryTbl]  WITH CHECK ADD  CONSTRAINT [FK_CategoryTbl_UserTbl] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[UserTbl] ([ID])
GO
ALTER TABLE [dbo].[CategoryTbl] CHECK CONSTRAINT [FK_CategoryTbl_UserTbl]
GO
ALTER TABLE [dbo].[ReminderTbl]  WITH CHECK ADD  CONSTRAINT [FK_ReminderTbl_CategoryTbl] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[CategoryTbl] ([ID])
GO
ALTER TABLE [dbo].[ReminderTbl] CHECK CONSTRAINT [FK_ReminderTbl_CategoryTbl]
GO
ALTER TABLE [dbo].[ReminderTbl]  WITH CHECK ADD  CONSTRAINT [FK_ReminderTbl_UserTbl] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[UserTbl] ([ID])
GO
ALTER TABLE [dbo].[ReminderTbl] CHECK CONSTRAINT [FK_ReminderTbl_UserTbl]
GO
