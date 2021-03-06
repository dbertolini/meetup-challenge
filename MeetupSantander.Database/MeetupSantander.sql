USE [master]
GO
/****** Object:  Database [MeetupSantander]    Script Date: 28/04/2020 18:19:14 ******/
CREATE DATABASE [MeetupSantander]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MeetupSantander', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MeetupSantander.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MeetupSantander_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MeetupSantander_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MeetupSantander] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MeetupSantander].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MeetupSantander] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MeetupSantander] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MeetupSantander] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MeetupSantander] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MeetupSantander] SET ARITHABORT OFF 
GO
ALTER DATABASE [MeetupSantander] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MeetupSantander] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MeetupSantander] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MeetupSantander] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MeetupSantander] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MeetupSantander] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MeetupSantander] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MeetupSantander] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MeetupSantander] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MeetupSantander] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MeetupSantander] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MeetupSantander] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MeetupSantander] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MeetupSantander] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MeetupSantander] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MeetupSantander] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MeetupSantander] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MeetupSantander] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MeetupSantander] SET  MULTI_USER 
GO
ALTER DATABASE [MeetupSantander] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MeetupSantander] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MeetupSantander] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MeetupSantander] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MeetupSantander] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MeetupSantander]
GO
/****** Object:  Table [dbo].[BeerTemperature]    Script Date: 28/04/2020 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BeerTemperature](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TemperatureMin] [decimal](10, 2) NOT NULL,
	[TemperatureMax] [decimal](10, 2) NOT NULL,
	[BeersPerPerson] [decimal](10, 2) NOT NULL,
	[BeersPerBox] [int] NOT NULL,
 CONSTRAINT [PK_BeerTemperature] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inscription]    Script Date: 28/04/2020 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscription](
	[UserId] [int] NOT NULL,
	[MeetupId] [int] NOT NULL,
	[Due] [datetime] NOT NULL,
	[Checkin] [bit] NOT NULL CONSTRAINT [DF_Inscription_Checkin]  DEFAULT ((0)),
 CONSTRAINT [PK_Inscription] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[MeetupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Meetup]    Script Date: 28/04/2020 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Meetup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[Due] [datetime] NOT NULL,
 CONSTRAINT [PK_Meetup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 28/04/2020 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](150) NOT NULL,
	[Password] [varchar](150) NOT NULL,
	[Role] [varchar](50) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BeerTemperature] ON 

INSERT [dbo].[BeerTemperature] ([Id], [TemperatureMin], [TemperatureMax], [BeersPerPerson], [BeersPerBox]) VALUES (1, CAST(20.00 AS Decimal(10, 2)), CAST(24.00 AS Decimal(10, 2)), CAST(1.00 AS Decimal(10, 2)), 6)
INSERT [dbo].[BeerTemperature] ([Id], [TemperatureMin], [TemperatureMax], [BeersPerPerson], [BeersPerBox]) VALUES (2, CAST(-50.00 AS Decimal(10, 2)), CAST(19.99 AS Decimal(10, 2)), CAST(0.75 AS Decimal(10, 2)), 6)
INSERT [dbo].[BeerTemperature] ([Id], [TemperatureMin], [TemperatureMax], [BeersPerPerson], [BeersPerBox]) VALUES (3, CAST(24.01 AS Decimal(10, 2)), CAST(50.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), 6)
SET IDENTITY_INSERT [dbo].[BeerTemperature] OFF
INSERT [dbo].[Inscription] ([UserId], [MeetupId], [Due], [Checkin]) VALUES (1, 1, CAST(N'2020-04-24 00:42:18.607' AS DateTime), 1)
INSERT [dbo].[Inscription] ([UserId], [MeetupId], [Due], [Checkin]) VALUES (2, 1, CAST(N'2020-04-28 04:23:27.353' AS DateTime), 1)
INSERT [dbo].[Inscription] ([UserId], [MeetupId], [Due], [Checkin]) VALUES (2, 2, CAST(N'2020-04-28 04:22:58.007' AS DateTime), 1)
INSERT [dbo].[Inscription] ([UserId], [MeetupId], [Due], [Checkin]) VALUES (2, 3, CAST(N'2020-04-28 04:25:43.617' AS DateTime), 1)
INSERT [dbo].[Inscription] ([UserId], [MeetupId], [Due], [Checkin]) VALUES (2, 4, CAST(N'2020-04-28 04:29:37.833' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Meetup] ON 

INSERT [dbo].[Meetup] ([Id], [Name], [Location], [Due]) VALUES (1, N'Meetup 1', N'buenosaires,ar', CAST(N'2020-04-28 00:00:00.000' AS DateTime))
INSERT [dbo].[Meetup] ([Id], [Name], [Location], [Due]) VALUES (2, N'Meetup 2', N'london,uk', CAST(N'2020-04-28 00:00:00.000' AS DateTime))
INSERT [dbo].[Meetup] ([Id], [Name], [Location], [Due]) VALUES (3, N'Meetup 3', N'buenosaires,ar', CAST(N'2020-04-29 00:00:00.000' AS DateTime))
INSERT [dbo].[Meetup] ([Id], [Name], [Location], [Due]) VALUES (4, N'Meetup 4', N'buenosaires,ar', CAST(N'2020-04-30 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Meetup] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [Name]) VALUES (1, N'dbertolini', N'd74ff0ee8da3b9806b18c877dbf29bbde50b5bd8e4dad7a3a725000feb82e8f1', N'administrator', N'Diego Bertolini')
INSERT [dbo].[User] ([Id], [Username], [Password], [Role], [Name]) VALUES (2, N'mperez', N'd74ff0ee8da3b9806b18c877dbf29bbde50b5bd8e4dad7a3a725000feb82e8f1', N'user', N'Martin Perez')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_Meetup] FOREIGN KEY([MeetupId])
REFERENCES [dbo].[Meetup] ([Id])
GO
ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_Meetup]
GO
ALTER TABLE [dbo].[Inscription]  WITH CHECK ADD  CONSTRAINT [FK_Inscription_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Inscription] CHECK CONSTRAINT [FK_Inscription_User]
GO
USE [master]
GO
ALTER DATABASE [MeetupSantander] SET  READ_WRITE 
GO
