USE [master]
GO
/****** Object:  Database [ProjectManagerDB]    Script Date: 11.04.2023 16:49:42 ******/
CREATE DATABASE [ProjectManagerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectManagerDB', FILENAME = N'D:\Progs\SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProjectManagerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectManagerDB_log', FILENAME = N'D:\Progs\SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProjectManagerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProjectManagerDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectManagerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectManagerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectManagerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectManagerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectManagerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectManagerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectManagerDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectManagerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectManagerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectManagerDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectManagerDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectManagerDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectManagerDB', N'ON'
GO
ALTER DATABASE [ProjectManagerDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProjectManagerDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProjectManagerDB]
GO
/****** Object:  Table [dbo].[CostOfWork]    Script Date: 11.04.2023 16:49:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostOfWork](
	[MycroobjectId] [int] NOT NULL,
	[TypeOfWorkId] [int] NOT NULL,
	[Cost(h)] [decimal](3, 2) NULL,
 CONSTRAINT [PK_CostOfWork] PRIMARY KEY CLUSTERED 
(
	[MycroobjectId] ASC,
	[TypeOfWorkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 11.04.2023 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [nchar](1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mycroobject]    Script Date: 11.04.2023 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mycroobject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mycroobject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 11.04.2023 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ProjectTeamId] [int] NOT NULL,
	[CreationDate] [date] NOT NULL,
	[CompletionDate] [date] NULL,
	[Deadline] [date] NOT NULL,
	[LaborCost(h)] [float] NULL,
	[Description] [nvarchar](max) NULL,
	[IsCompleted] [bit] NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTeam]    Script Date: 11.04.2023 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTeam](
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_ProjectTeam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialization]    Script Date: 11.04.2023 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Specialization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 11.04.2023 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 11.04.2023 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ExecutorId] [int] NULL,
	[CreationDate] [date] NOT NULL,
	[CompletionDate] [date] NULL,
	[Deadline] [date] NOT NULL,
	[MycroobjectId] [int] NOT NULL,
	[TypeOFWorkId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ProjectId] [int] NOT NULL,
	[StatusId] [int] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfUser]    Script Date: 11.04.2023 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TypeOfUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfWork]    Script Date: 11.04.2023 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfWork](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_TypeOfWork] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11.04.2023 16:49:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[SecondName] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[GenderId] [nchar](1) NOT NULL,
	[TypeOfUserId] [int] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[ProjectTeamId] [int] NULL,
	[SpecializationId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (1, 1, CAST(0.60 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (1, 2, CAST(2.40 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (1, 3, CAST(4.80 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (2, 1, CAST(0.53 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (2, 2, CAST(2.10 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (2, 3, CAST(4.20 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (3, 1, CAST(0.45 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (3, 2, CAST(1.80 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (3, 3, CAST(3.60 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (4, 1, CAST(0.38 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (4, 2, CAST(1.50 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (4, 3, CAST(3.00 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (5, 1, CAST(0.30 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (5, 2, CAST(1.20 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (5, 3, CAST(2.40 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (6, 1, CAST(0.23 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (6, 2, CAST(0.90 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (6, 3, CAST(1.80 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (7, 1, CAST(0.15 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (7, 2, CAST(0.60 AS Decimal(3, 2)))
INSERT [dbo].[CostOfWork] ([MycroobjectId], [TypeOfWorkId], [Cost(h)]) VALUES (7, 3, CAST(1.20 AS Decimal(3, 2)))
GO
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (N'Ж', N'Женский')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (N'М', N'Мужской')
GO
SET IDENTITY_INSERT [dbo].[Mycroobject] ON 

INSERT [dbo].[Mycroobject] ([Id], [Name]) VALUES (1, N'Запрос к БД')
INSERT [dbo].[Mycroobject] ([Id], [Name]) VALUES (2, N'Процедура')
INSERT [dbo].[Mycroobject] ([Id], [Name]) VALUES (3, N'Обработка события')
INSERT [dbo].[Mycroobject] ([Id], [Name]) VALUES (4, N'Экранная форма')
INSERT [dbo].[Mycroobject] ([Id], [Name]) VALUES (5, N'Набор данных')
INSERT [dbo].[Mycroobject] ([Id], [Name]) VALUES (6, N'Макет')
INSERT [dbo].[Mycroobject] ([Id], [Name]) VALUES (7, N'Документация')
INSERT [dbo].[Mycroobject] ([Id], [Name]) VALUES (8, N'Манипуляция с данными')
SET IDENTITY_INSERT [dbo].[Mycroobject] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Name], [ProjectTeamId], [CreationDate], [CompletionDate], [Deadline], [LaborCost(h)], [Description], [IsCompleted]) VALUES (1, N'Проект', 1, CAST(N'2023-02-03' AS Date), NULL, CAST(N'2023-03-03' AS Date), NULL, N'Тестовый проект, который предназначен для тестирования', 0)
INSERT [dbo].[Project] ([Id], [Name], [ProjectTeamId], [CreationDate], [CompletionDate], [Deadline], [LaborCost(h)], [Description], [IsCompleted]) VALUES (2, N'Тестовый архивный', 1, CAST(N'2022-02-15' AS Date), CAST(N'2022-07-05' AS Date), CAST(N'2022-07-20' AS Date), NULL, N'Тестовый проект', 1)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
INSERT [dbo].[ProjectTeam] ([Id]) VALUES (1)
INSERT [dbo].[ProjectTeam] ([Id]) VALUES (2)
GO
SET IDENTITY_INSERT [dbo].[Specialization] ON 

INSERT [dbo].[Specialization] ([Id], [Name]) VALUES (1, N'Программист')
INSERT [dbo].[Specialization] ([Id], [Name]) VALUES (2, N'Дизайнер')
INSERT [dbo].[Specialization] ([Id], [Name]) VALUES (4, N'Менеджер проекта')
SET IDENTITY_INSERT [dbo].[Specialization] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Name]) VALUES (1, N'Сделать')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (2, N'В разработке')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (3, N'На проверке')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (4, N'Завершено')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([Id], [Name], [ExecutorId], [CreationDate], [CompletionDate], [Deadline], [MycroobjectId], [TypeOFWorkId], [Description], [ProjectId], [StatusId]) VALUES (2, N'Тестовое задание 1', 5, CAST(N'2023-02-03' AS Date), NULL, CAST(N'2023-02-05' AS Date), 1, 1, N'Тестовое описание тестовой задачи', 1, 2)
INSERT [dbo].[Task] ([Id], [Name], [ExecutorId], [CreationDate], [CompletionDate], [Deadline], [MycroobjectId], [TypeOFWorkId], [Description], [ProjectId], [StatusId]) VALUES (3, N'Тестовое задание 2', 6, CAST(N'2023-03-02' AS Date), NULL, CAST(N'2023-03-03' AS Date), 3, 1, N'Тестовое описание для тестовой задачи', 1, 2)
INSERT [dbo].[Task] ([Id], [Name], [ExecutorId], [CreationDate], [CompletionDate], [Deadline], [MycroobjectId], [TypeOFWorkId], [Description], [ProjectId], [StatusId]) VALUES (5, N'Тестовое задание 3', 7, CAST(N'2023-03-01' AS Date), NULL, CAST(N'2023-04-01' AS Date), 1, 1, N'Описание', 1, 3)
INSERT [dbo].[Task] ([Id], [Name], [ExecutorId], [CreationDate], [CompletionDate], [Deadline], [MycroobjectId], [TypeOFWorkId], [Description], [ProjectId], [StatusId]) VALUES (7, N'Тестовое задание 4', 8, CAST(N'2023-03-02' AS Date), NULL, CAST(N'2023-05-01' AS Date), 1, 1, N'Описание', 1, 4)
INSERT [dbo].[Task] ([Id], [Name], [ExecutorId], [CreationDate], [CompletionDate], [Deadline], [MycroobjectId], [TypeOFWorkId], [Description], [ProjectId], [StatusId]) VALUES (1006, N'Тест 1', 8, CAST(N'2023-04-07' AS Date), NULL, CAST(N'2023-04-28' AS Date), 1, 1, N'теасавп', 1, 1)
SET IDENTITY_INSERT [dbo].[Task] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeOfUser] ON 

INSERT [dbo].[TypeOfUser] ([Id], [Name]) VALUES (1, N'Менеджер проекта')
INSERT [dbo].[TypeOfUser] ([Id], [Name]) VALUES (2, N'Разработчик')
INSERT [dbo].[TypeOfUser] ([Id], [Name]) VALUES (3, N'Директор')
SET IDENTITY_INSERT [dbo].[TypeOfUser] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeOfWork] ON 

INSERT [dbo].[TypeOfWork] ([Id], [Name]) VALUES (1, N'Корректировка')
INSERT [dbo].[TypeOfWork] ([Id], [Name]) VALUES (2, N'Изменение')
INSERT [dbo].[TypeOfWork] ([Id], [Name]) VALUES (3, N'Создание')
SET IDENTITY_INSERT [dbo].[TypeOfWork] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FirstName], [SecondName], [Patronymic], [GenderId], [TypeOfUserId], [Login], [Password], [ProjectTeamId], [SpecializationId]) VALUES (2, N'Иван', N'Иванов', N'Иванович', N'М', 1, N'ivan', N'123', NULL, NULL)
INSERT [dbo].[User] ([Id], [FirstName], [SecondName], [Patronymic], [GenderId], [TypeOfUserId], [Login], [Password], [ProjectTeamId], [SpecializationId]) VALUES (3, N'Ангелина', N'Калинина', N'Евгеньевна', N'Ж', 3, N'angi', N'123', 1, 4)
INSERT [dbo].[User] ([Id], [FirstName], [SecondName], [Patronymic], [GenderId], [TypeOfUserId], [Login], [Password], [ProjectTeamId], [SpecializationId]) VALUES (5, N'Юлия', N'Копейко', N'Александровна', N'Ж', 2, N'yulii', N'123', 1, 1)
INSERT [dbo].[User] ([Id], [FirstName], [SecondName], [Patronymic], [GenderId], [TypeOfUserId], [Login], [Password], [ProjectTeamId], [SpecializationId]) VALUES (6, N'Наталья', N'Митягина', N'Павловна', N'Ж', 2, N'natali', N'123', 1, 2)
INSERT [dbo].[User] ([Id], [FirstName], [SecondName], [Patronymic], [GenderId], [TypeOfUserId], [Login], [Password], [ProjectTeamId], [SpecializationId]) VALUES (7, N'Ярослава', N'Головко', N'Андреевна', N'Ж', 2, N'yaros', N'123', 2, 1)
INSERT [dbo].[User] ([Id], [FirstName], [SecondName], [Patronymic], [GenderId], [TypeOfUserId], [Login], [Password], [ProjectTeamId], [SpecializationId]) VALUES (8, N'Екатерина', N'Ефанова', N'Евгеньевна', N'Ж', 2, N'katia', N'123', 2, 1)
INSERT [dbo].[User] ([Id], [FirstName], [SecondName], [Patronymic], [GenderId], [TypeOfUserId], [Login], [Password], [ProjectTeamId], [SpecializationId]) VALUES (9, N'frfrfr', N'frfrfr', N'rfrfrf', N'Ж', 2, N'frfr', N'frffr', 1, 1)
INSERT [dbo].[User] ([Id], [FirstName], [SecondName], [Patronymic], [GenderId], [TypeOfUserId], [Login], [Password], [ProjectTeamId], [SpecializationId]) VALUES (10, N'.l.l.l..', N'l.l..', N'l.l.l.l.l', N'Ж', 2, N'l..ll.', N'.ll.ll.', 2, 1)
INSERT [dbo].[User] ([Id], [FirstName], [SecondName], [Patronymic], [GenderId], [TypeOfUserId], [Login], [Password], [ProjectTeamId], [SpecializationId]) VALUES (11, N'kkk', N'kkk', N'kkkk', N'М', 2, N'kkkk', N'kkk', 1, 1)
INSERT [dbo].[User] ([Id], [FirstName], [SecondName], [Patronymic], [GenderId], [TypeOfUserId], [Login], [Password], [ProjectTeamId], [SpecializationId]) VALUES (12, N'kkk', N'kkk', N'kkkk', N'М', 2, N'kkkk', N'kkk', 1, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[CostOfWork]  WITH CHECK ADD  CONSTRAINT [FK_CostOfWork_Mycroobject] FOREIGN KEY([MycroobjectId])
REFERENCES [dbo].[Mycroobject] ([Id])
GO
ALTER TABLE [dbo].[CostOfWork] CHECK CONSTRAINT [FK_CostOfWork_Mycroobject]
GO
ALTER TABLE [dbo].[CostOfWork]  WITH CHECK ADD  CONSTRAINT [FK_CostOfWork_TypeOfWork] FOREIGN KEY([TypeOfWorkId])
REFERENCES [dbo].[TypeOfWork] ([Id])
GO
ALTER TABLE [dbo].[CostOfWork] CHECK CONSTRAINT [FK_CostOfWork_TypeOfWork]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectTeam] FOREIGN KEY([ProjectTeamId])
REFERENCES [dbo].[ProjectTeam] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ProjectTeam]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Mycroobject] FOREIGN KEY([MycroobjectId])
REFERENCES [dbo].[Mycroobject] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Mycroobject]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Status]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_TypeOfWork] FOREIGN KEY([TypeOFWorkId])
REFERENCES [dbo].[TypeOfWork] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_TypeOfWork]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_User] FOREIGN KEY([ExecutorId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Gender] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Gender]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_ProjectTeam] FOREIGN KEY([ProjectTeamId])
REFERENCES [dbo].[ProjectTeam] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_ProjectTeam]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Specialization] FOREIGN KEY([SpecializationId])
REFERENCES [dbo].[Specialization] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Specialization]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_TypeOfUser] FOREIGN KEY([TypeOfUserId])
REFERENCES [dbo].[TypeOfUser] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_TypeOfUser]
GO
USE [master]
GO
ALTER DATABASE [ProjectManagerDB] SET  READ_WRITE 
GO
