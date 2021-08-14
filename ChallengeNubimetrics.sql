USE [master]
GO

/****** Object:  Database [ChallengeNubimetricDB]    Script Date: 09/08/2021 15:39:31 ******/
CREATE DATABASE [ChallengeNubimetricDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChallengeNubimetricDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ChallengeNubimetricDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChallengeNubimetricDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ChallengeNubimetricDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChallengeNubimetricDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ChallengeNubimetricDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET  MULTI_USER 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ChallengeNubimetricDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ChallengeNubimetricDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [ChallengeNubimetricDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [ChallengeNubimetricDB] SET  READ_WRITE 
GO


CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[email] [nvarchar](150) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[User]
     VALUES
           ('Pablo Ezequiel'
           ,'Porcel'
           ,'pabloporcel41@gmail.com'
           ,'pass'),

           ('Gerardo'
           ,'Ramirez'
           ,'geramirez@gmail.com'
           ,'password'),

           ('Romina'
           ,'Juarez'
           ,'rojuarez@gmail.com'
           ,'pass')

GO



