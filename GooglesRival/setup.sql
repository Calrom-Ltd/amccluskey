USE [master]
GO

/****** Object:  Database [MyAPI]    Script Date: 26/02/2021 17:55:38 ******/
CREATE DATABASE [MyAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyAPI', FILENAME = N'/var/opt/mssql/data/MyAPI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyAPI_log', FILENAME = N'/var/opt/mssql/data/MyAPI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO


/****** Object:  Table [dbo].[MyAPI_Users]    Script Date: 19/02/2021 17:45:43 ******/
USE MyAPI
GO
CREATE TABLE [dbo].[MyAPI_Users](
	[MyAPI_Users_ID] [int] IDENTITY(1,1) NOT NULL,
	[MyAPI_Users_Username] [varchar](50) NOT NULL,
	[MyAPI_Users_Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MyAPI_Users] PRIMARY KEY CLUSTERED 
(
	[MyAPI_Users_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[MyAPI_Messages]    Script Date: 22/02/2021 16:27:19 ******/
CREATE TABLE [dbo].[MyAPI_Messages](
	[MyAPI_Messages_ID] [int] IDENTITY(1,1) NOT NULL,
	[MyAPI_Messages_UserID] [int] NOT NULL,
	[MyAPI_Messages_Date] [datetime] NOT NULL,
	[MyAPI_Messages_Subject] [varchar](50) NOT NULL,
	[MyAPI_Messages_Body] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MyAPI_Messages] PRIMARY KEY CLUSTERED 
(
	[MyAPI_Messages_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MyAPI_Messages]  WITH CHECK ADD  CONSTRAINT [FK_MyAPI_Messages_MyAPI_Users] FOREIGN KEY([MyAPI_Messages_UserID])
REFERENCES [dbo].[MyAPI_Users] ([MyAPI_Users_ID])
GO

ALTER TABLE [dbo].[MyAPI_Messages] CHECK CONSTRAINT [FK_MyAPI_Messages_MyAPI_Users]
GO
USE [MyAPI]
GO

INSERT INTO [dbo].[MyAPI_Users]
           ([MyAPI_Users_Username]
           ,[MyAPI_Users_Password])
     VALUES
           ('Admin','Password123'),
		   ('PapaJeff','HanzoMain'),
		   ('Fortnite','POGGERS')
GO


USE [MyAPI]
GO

INSERT INTO [dbo].[MyAPI_Messages]
           ([MyAPI_Messages_UserID]
           ,[MyAPI_Messages_Date]
           ,[MyAPI_Messages_Subject]
           ,[MyAPI_Messages_Body])
     VALUES
           (1,'01-01-2021','Test','Testing that this works')
GO