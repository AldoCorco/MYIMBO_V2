USE [master]
GO

/****** Object:  Database [SeguridadDB]    Script Date: 5/3/2024 10:21:43 ******/
CREATE DATABASE [SeguridadDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SeguridadDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SeguridadDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SeguridadDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SeguridadDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SeguridadDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SeguridadDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SeguridadDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SeguridadDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SeguridadDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SeguridadDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [SeguridadDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SeguridadDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SeguridadDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SeguridadDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SeguridadDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SeguridadDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SeguridadDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SeguridadDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SeguridadDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SeguridadDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SeguridadDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SeguridadDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SeguridadDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SeguridadDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SeguridadDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SeguridadDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SeguridadDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SeguridadDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [SeguridadDB] SET  MULTI_USER 
GO

ALTER DATABASE [SeguridadDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SeguridadDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [SeguridadDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [SeguridadDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [SeguridadDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [SeguridadDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [SeguridadDB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [SeguridadDB] SET  READ_WRITE 
GO