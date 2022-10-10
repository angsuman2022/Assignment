USE [master]
GO
/****** Object:  Database [BookAuthor]    Script Date: 09-10-2022 17:03:19 ******/
CREATE DATABASE [BookAuthor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookAuthor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookAuthor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookAuthor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BookAuthor_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BookAuthor] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookAuthor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookAuthor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookAuthor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookAuthor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookAuthor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookAuthor] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookAuthor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookAuthor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookAuthor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookAuthor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookAuthor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookAuthor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookAuthor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookAuthor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookAuthor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookAuthor] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookAuthor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookAuthor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookAuthor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookAuthor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookAuthor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookAuthor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookAuthor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookAuthor] SET RECOVERY FULL 
GO
ALTER DATABASE [BookAuthor] SET  MULTI_USER 
GO
ALTER DATABASE [BookAuthor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookAuthor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookAuthor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookAuthor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookAuthor] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookAuthor] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookAuthor', N'ON'
GO
ALTER DATABASE [BookAuthor] SET QUERY_STORE = OFF
GO
USE [BookAuthor]
GO
/****** Object:  Table [dbo].[BookDet]    Script Date: 09-10-2022 17:03:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookDet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BookTitle] [nvarchar](50) NULL,
	[BookCategory] [nvarchar](50) NULL,
	[BookImg] [nvarchar](50) NULL,
	[BookPrice] [numeric](18, 2) NULL,
	[BookPublish] [nvarchar](50) NULL,
	[Active] [bit] NULL,
	[BookContent] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [int] NULL,
	[ModyDate] [datetime] NULL,
	[PublishDate] [nvarchar](50) NULL,
 CONSTRAINT [PK_BookDet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblInvoice]    Script Date: 09-10-2022 17:03:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInvoice](
	[Year] [nvarchar](50) NOT NULL,
	[Month] [nvarchar](50) NOT NULL,
	[SlNo] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_tblInvoice] PRIMARY KEY CLUSTERED 
(
	[Year] ASC,
	[Month] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPayment]    Script Date: 09-10-2022 17:03:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPayment](
	[paymentId] [int] IDENTITY(1,1) NOT NULL,
	[bookId] [int] NULL,
	[InvoiceNo] [nvarchar](50) NULL,
	[paymentBy] [int] NULL,
	[paymentDate] [date] NULL,
	[paymentName] [nvarchar](50) NULL,
	[paymentCard] [nvarchar](50) NULL,
	[cancelOrder] [bit] NULL,
 CONSTRAINT [PK_tblPayment] PRIMARY KEY CLUSTERED 
(
	[paymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 09-10-2022 17:03:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookDet] ON 

INSERT [dbo].[BookDet] ([id], [BookTitle], [BookCategory], [BookImg], [BookPrice], [BookPublish], [Active], [BookContent], [CreateDate], [CreateBy], [ModyDate], [PublishDate]) VALUES (3, N'3 Idiots', N'comedy-drama', N'book10.jfif', CAST(500.00 AS Numeric(18, 2)), N'Chetan Bhagat', 1, N'Cemedy Drama Book', CAST(N'2022-10-09T10:52:20.703' AS DateTime), 1, NULL, N'2022-10-09')
INSERT [dbo].[BookDet] ([id], [BookTitle], [BookCategory], [BookImg], [BookPrice], [BookPublish], [Active], [BookContent], [CreateDate], [CreateBy], [ModyDate], [PublishDate]) VALUES (4, N'Computer Network', N'Technology', N'bool120221009161909.jpg', CAST(600.00 AS Numeric(18, 2)), N'Tech Publication', 1, N'Computer Network', CAST(N'2022-10-09T15:03:52.393' AS DateTime), 1, CAST(N'2022-10-09T16:19:44.783' AS DateTime), N'2022-10-09')
INSERT [dbo].[BookDet] ([id], [BookTitle], [BookCategory], [BookImg], [BookPrice], [BookPublish], [Active], [BookContent], [CreateDate], [CreateBy], [ModyDate], [PublishDate]) VALUES (5, N'Computer Grapics', N'Technology', N'bool120221009161909.jpg', CAST(200.00 AS Numeric(18, 2)), N'Tech Publication', 1, N'Graphics', CAST(N'2022-10-09T16:14:35.003' AS DateTime), 1, CAST(N'2022-10-09T16:24:21.923' AS DateTime), N'2022-10-09')
SET IDENTITY_INSERT [dbo].[BookDet] OFF
GO
INSERT [dbo].[tblInvoice] ([Year], [Month], [SlNo], [Active]) VALUES (N'2022', N'OCT', 4, 1)
GO
SET IDENTITY_INSERT [dbo].[tblPayment] ON 

INSERT [dbo].[tblPayment] ([paymentId], [bookId], [InvoiceNo], [paymentBy], [paymentDate], [paymentName], [paymentCard], [cancelOrder]) VALUES (1, 1, N'INV_2022_OCT_1', 1, CAST(N'2022-10-06' AS Date), N'Angsuman', N'1234567890123', 0)
INSERT [dbo].[tblPayment] ([paymentId], [bookId], [InvoiceNo], [paymentBy], [paymentDate], [paymentName], [paymentCard], [cancelOrder]) VALUES (3, 3, N'Inv_2022_OCT_2', 1002, CAST(N'2022-10-09' AS Date), N'Antara Choudhury', N'1234 2345 1324', 1)
INSERT [dbo].[tblPayment] ([paymentId], [bookId], [InvoiceNo], [paymentBy], [paymentDate], [paymentName], [paymentCard], [cancelOrder]) VALUES (4, 4, N'Inv_2022_OCT_3', 1002, CAST(N'2022-10-09' AS Date), N'Antara', N'1234', 0)
SET IDENTITY_INSERT [dbo].[tblPayment] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [email], [FullName], [Phone], [Type], [Password]) VALUES (1, N'angsuman@gmail.com', N'Angsuman Patra', N'123456', N'Author', N'1234')
INSERT [dbo].[User] ([id], [email], [FullName], [Phone], [Type], [Password]) VALUES (2, N'abc@gmail.com', N'Abcd', N'1234', N'Author', N'1234')
INSERT [dbo].[User] ([id], [email], [FullName], [Phone], [Type], [Password]) VALUES (3, N'abce@gmail.com', N'Abcde', N'1234', N'Author', N'1234')
INSERT [dbo].[User] ([id], [email], [FullName], [Phone], [Type], [Password]) VALUES (1002, N'antra@gmail.com', N'Antara choudhury', N'1234567', N'Reader', N'1234')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
USE [master]
GO
ALTER DATABASE [BookAuthor] SET  READ_WRITE 
GO
