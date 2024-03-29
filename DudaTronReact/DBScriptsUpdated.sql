USE [master]
GO
/****** Object:  Database [DudatronData]    Script Date: 30-Nov-18 12:57:47 ******/
CREATE DATABASE [DudatronData]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DudatronData', FILENAME = N'/var/opt/mssql/data/DudatronData.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DudatronData_log', FILENAME = N'/var/opt/mssql/data/DudatronData_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DudatronData] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DudatronData].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DudatronData] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DudatronData] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DudatronData] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DudatronData] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DudatronData] SET ARITHABORT OFF 
GO
ALTER DATABASE [DudatronData] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DudatronData] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DudatronData] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DudatronData] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DudatronData] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DudatronData] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DudatronData] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DudatronData] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DudatronData] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DudatronData] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DudatronData] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DudatronData] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DudatronData] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DudatronData] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DudatronData] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DudatronData] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DudatronData] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DudatronData] SET RECOVERY FULL 
GO
ALTER DATABASE [DudatronData] SET  MULTI_USER 
GO
ALTER DATABASE [DudatronData] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DudatronData] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DudatronData] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DudatronData] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DudatronData] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DudatronData', N'ON'
GO
ALTER DATABASE [DudatronData] SET QUERY_STORE = OFF
GO
USE [DudatronData]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passwords]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passwords](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OwnerId] [bigint] NOT NULL,
	[Password] [varchar](5000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[SessionGuid] [uniqueidentifier] NOT NULL,
	[ValidTo] [datetime] NOT NULL,
	[OwnerId] [bigint] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](80) NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersLog]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[LastName] [nchar](80) NOT NULL,
	[Email] [nchar](80) NOT NULL,
	[ActionType] [char](1) NOT NULL,
	[ActionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UsersLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wishes]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](500) NOT NULL,
	[OwnerId] [bigint] NOT NULL,
	[EventId] [bigint] NOT NULL,
 CONSTRAINT [PK_Wish] PRIMARY KEY CLUSTERED 
(
	[OwnerId] ASC,
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WishesLog]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WishesLog](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OwnerId] [bigint] NOT NULL,
	[EventId] [bigint] NOT NULL,
	[ActionType] [nchar](1) NOT NULL,
	[ActionDate] [datetime2](7) NULL,
 CONSTRAINT [PK_WishesLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20181129-135634]    Script Date: 30-Nov-18 12:57:47 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20181129-135634] ON [dbo].[Sessions]
(
	[SessionGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Trigger [dbo].[User_Log_Delete]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[User_Log_Delete] on [dbo].[Users]
after DELETE
as 
begin

Declare @insertedName as varchar(50);
Declare @insertedLastName as varchar(80);
Declare @insertedEmail as varchar(80);
select @insertedName =  name from deleted;
select @insertedLastName= LastName from deleted;
select @insertedEmail = Email from deleted;

if @insertedEmail != null and @insertedLastName !=null and @insertedName!=null

insert into UsersLog (Name, LastName,Email,ActionType, ActionDate)
values (@insertedName,@insertedLastName,@insertedEmail,'D' ,GETDATE())
end 

GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [User_Log_Delete]
GO
/****** Object:  Trigger [dbo].[User_Log_Insert]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create trigger [dbo].[User_Log_Insert] on [dbo].[Users]
after INSERT
as 
begin

Declare @insertedName as varchar(50);
Declare @insertedLastName as varchar(80);
Declare @insertedEmail as varchar(80);
select @insertedName =  name from inserted;
select @insertedLastName = LastName from inserted;
select @insertedEmail = Email from inserted;

insert into UsersLog (Name, LastName,Email,ActionType, ActionDate)
values (@insertedName,@insertedLastName,@insertedEmail,'I' ,GETDATE())

end
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [User_Log_Insert]
GO
/****** Object:  Trigger [dbo].[User_Log_update]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create trigger [dbo].[User_Log_update] on [dbo].[Users]
after UPDATE
as 
begin

if UPDATE(Name) or UPDATE (LastName) or UPDATE (Email)

Declare @insertedName as varchar(50);
Declare @insertedLastName as varchar(80);
Declare @insertedEmail as varchar(80);
select @insertedName =  name from inserted;
select @insertedLastName= LastName from inserted;
select @insertedEmail = Email from inserted;


insert into UsersLog (Name, LastName,Email,ActionType, ActionDate)
values (@insertedName,@insertedLastName,@insertedEmail,'U' ,GETDATE())

end
GO
ALTER TABLE [dbo].[Users] ENABLE TRIGGER [User_Log_update]
GO
/****** Object:  Trigger [dbo].[Wishes_Log_Delete]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE trigger [dbo].[Wishes_Log_Delete] on [dbo].[Wishes]
after Delete
as 
begin

Declare @insertedOwnerId as bigint;
Declare @insertedEventId as bigint;
select @insertedOwnerId =  OwnerId from deleted;
select @insertedEventId = EventId from deleted;

insert into WishesLog (EventId, OwnerId,ActionType, ActionDate)
values (@insertedEventId,@insertedOwnerId,'D' ,GETDATE())

end
GO
ALTER TABLE [dbo].[Wishes] ENABLE TRIGGER [Wishes_Log_Delete]
GO
/****** Object:  Trigger [dbo].[Wishes_Log_Insert]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create trigger [dbo].[Wishes_Log_Insert] on [dbo].[Wishes]
after INSERT
as 
begin

Declare @insertedOwnerId as bigint;
Declare @insertedEventId as bigint;
select @insertedOwnerId =  OwnerId from inserted;
select @insertedEventId = EventId from inserted;

insert into WishesLog (EventId, OwnerId,ActionType, ActionDate)
values (@insertedEventId,@insertedOwnerId,'I' ,GETDATE())

end
GO
ALTER TABLE [dbo].[Wishes] ENABLE TRIGGER [Wishes_Log_Insert]
GO
/****** Object:  Trigger [dbo].[Wishes_Log_Update]    Script Date: 30-Nov-18 12:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE trigger [dbo].[Wishes_Log_Update] on [dbo].[Wishes]
after Update
as 
begin


if UPDATE(Text) 

Declare @insertedOwnerId as bigint;
Declare @insertedEventId as bigint;
select @insertedOwnerId =  OwnerId from inserted;
select @insertedEventId = EventId from inserted;

insert into WishesLog (EventId, OwnerId,ActionType, ActionDate)
values (@insertedEventId,@insertedOwnerId,'U' ,GETDATE())

end
GO
ALTER TABLE [dbo].[Wishes] ENABLE TRIGGER [Wishes_Log_Update]
GO
USE [master]
GO
ALTER DATABASE [DudatronData] SET  READ_WRITE 
GO
