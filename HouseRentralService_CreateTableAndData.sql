USE [master]
GO
/****** Object:  Database [HouseRentalService]    Script Date: 2019-04-01 19:41:32 ******/
CREATE DATABASE [HouseRentalService]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HouseRentalService', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HouseRentalService.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HouseRentalService_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HouseRentalService_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HouseRentalService] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HouseRentalService].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HouseRentalService] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HouseRentalService] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HouseRentalService] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HouseRentalService] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HouseRentalService] SET ARITHABORT OFF 
GO
ALTER DATABASE [HouseRentalService] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HouseRentalService] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HouseRentalService] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HouseRentalService] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HouseRentalService] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HouseRentalService] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HouseRentalService] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HouseRentalService] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HouseRentalService] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HouseRentalService] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HouseRentalService] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HouseRentalService] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HouseRentalService] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HouseRentalService] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HouseRentalService] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HouseRentalService] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HouseRentalService] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HouseRentalService] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HouseRentalService] SET  MULTI_USER 
GO
ALTER DATABASE [HouseRentalService] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HouseRentalService] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HouseRentalService] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HouseRentalService] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HouseRentalService] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HouseRentalService]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 2019-04-01 19:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[PersonalNumber] [nvarchar](10) NULL,
	[FirstName] [nvarchar](150) NULL,
	[Lastname] [nvarchar](150) NULL,
	[MobileNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Houses]    Script Date: 2019-04-01 19:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Houses](
	[HouseID] [int] IDENTITY(1,1) NOT NULL,
	[PriceID] [int] NULL,
	[Type] [nvarchar](250) NULL,
	[MultiplicationValue] [float] NULL,
 CONSTRAINT [PK_Houses] PRIMARY KEY CLUSTERED 
(
	[HouseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Prices]    Script Date: 2019-04-01 19:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[PriceID] [int] IDENTITY(1,1) NOT NULL,
	[BaseDayFee] [float] NULL,
 CONSTRAINT [PK_Prices] PRIMARY KEY CLUSTERED 
(
	[PriceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ResarvationCustomerConnection]    Script Date: 2019-04-01 19:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResarvationCustomerConnection](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[ResarvationID] [int] NULL,
 CONSTRAINT [PK_ResarvationCustomerConnection] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 2019-04-01 19:41:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[HouseID] [int] NULL,
	[CustomerID] [int] NULL,
	[NumberOfDays] [int] NULL,
	[Date] [datetime2](7) NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Houses]  WITH CHECK ADD  CONSTRAINT [FK_Houses_Prices] FOREIGN KEY([PriceID])
REFERENCES [dbo].[Prices] ([PriceID])
GO
ALTER TABLE [dbo].[Houses] CHECK CONSTRAINT [FK_Houses_Prices]
GO
ALTER TABLE [dbo].[ResarvationCustomerConnection]  WITH CHECK ADD  CONSTRAINT [FK_ResarvationCustomerConnection_Customers1] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[ResarvationCustomerConnection] CHECK CONSTRAINT [FK_ResarvationCustomerConnection_Customers1]
GO
ALTER TABLE [dbo].[ResarvationCustomerConnection]  WITH CHECK ADD  CONSTRAINT [FK_ResarvationCustomerConnection_Reservation] FOREIGN KEY([ResarvationID])
REFERENCES [dbo].[Reservation] ([ReservationID])
GO
ALTER TABLE [dbo].[ResarvationCustomerConnection] CHECK CONSTRAINT [FK_ResarvationCustomerConnection_Reservation]
GO
USE [master]
GO
ALTER DATABASE [HouseRentalService] SET  READ_WRITE 
GO
