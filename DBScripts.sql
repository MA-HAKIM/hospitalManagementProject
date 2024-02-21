USE [master]
GO
/****** Object:  Database [HospitalManagement2024]    Script Date: 2/11/2024 10:02:29 PM ******/
CREATE DATABASE [HospitalManagement2024]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HospitalManagement2024', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HospitalManagement2024.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HospitalManagement2024_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HospitalManagement2024_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HospitalManagement2024] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HospitalManagement2024].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HospitalManagement2024] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET ARITHABORT OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HospitalManagement2024] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HospitalManagement2024] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HospitalManagement2024] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HospitalManagement2024] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HospitalManagement2024] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HospitalManagement2024] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HospitalManagement2024] SET  MULTI_USER 
GO
ALTER DATABASE [HospitalManagement2024] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HospitalManagement2024] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HospitalManagement2024] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HospitalManagement2024] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HospitalManagement2024] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HospitalManagement2024] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HospitalManagement2024] SET QUERY_STORE = ON
GO
ALTER DATABASE [HospitalManagement2024] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HospitalManagement2024]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/11/2024 10:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allergies]    Script Date: 2/11/2024 10:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergies](
	[AllergiesID] [int] IDENTITY(1,1) NOT NULL,
	[AllergiesName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Allergies] PRIMARY KEY CLUSTERED 
(
	[AllergiesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AllergiesDetails]    Script Date: 2/11/2024 10:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllergiesDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientInformationID] [int] NOT NULL,
	[AllergiesID] [int] NULL,
 CONSTRAINT [PK_AllergiesDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiseaseInformation]    Script Date: 2/11/2024 10:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiseaseInformation](
	[DiseaseID] [int] IDENTITY(1,1) NOT NULL,
	[DiseaseName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_DiseaseInformation] PRIMARY KEY CLUSTERED 
(
	[DiseaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCD]    Script Date: 2/11/2024 10:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCD](
	[NCDID] [int] IDENTITY(1,1) NOT NULL,
	[NCDName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_NCD] PRIMARY KEY CLUSTERED 
(
	[NCDID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NCDDetails]    Script Date: 2/11/2024 10:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NCDDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PatientInformationID] [int] NOT NULL,
	[NCDID] [int] NULL,
 CONSTRAINT [PK_NCDDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientInformation]    Script Date: 2/11/2024 10:02:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientInformation](
	[PatientInformationID] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [nvarchar](100) NOT NULL,
	[Epilepsy] [int] NOT NULL,
	[Age] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[ContactNo] [nvarchar](max) NULL,
	[DiseaseId] [int] NOT NULL,
 CONSTRAINT [PK_PatientInformation] PRIMARY KEY CLUSTERED 
(
	[PatientInformationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240207190445_CreateDatabase', N'6.0.26')
GO
SET IDENTITY_INSERT [dbo].[Allergies] ON 
GO
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (1, N'Drugs-Penicillin')
GO
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (2, N'Drugs-Others')
GO
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (3, N'Animals')
GO
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (4, N'Food')
GO
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (5, N'Oinments')
GO
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (6, N'Plant')
GO
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (7, N'Sprays')
GO
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (8, N'Others')
GO
INSERT [dbo].[Allergies] ([AllergiesID], [AllergiesName]) VALUES (9, N'No Allergies')
GO
SET IDENTITY_INSERT [dbo].[Allergies] OFF
GO
SET IDENTITY_INSERT [dbo].[AllergiesDetails] ON 
GO
INSERT [dbo].[AllergiesDetails] ([ID], [PatientInformationID], [AllergiesID]) VALUES (1, 1, 2)
GO
INSERT [dbo].[AllergiesDetails] ([ID], [PatientInformationID], [AllergiesID]) VALUES (2, 1, 9)
GO
SET IDENTITY_INSERT [dbo].[AllergiesDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[DiseaseInformation] ON 
GO
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (1, N'Heart Disease')
GO
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (2, N'Diabetes')
GO
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (3, N'Infectious Diseases')
GO
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (4, N'Influenza')
GO
INSERT [dbo].[DiseaseInformation] ([DiseaseID], [DiseaseName]) VALUES (5, N'Mental Illnesses')
GO
SET IDENTITY_INSERT [dbo].[DiseaseInformation] OFF
GO
SET IDENTITY_INSERT [dbo].[NCD] ON 
GO
INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (1, N'Asthma')
GO
INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (2, N'Cancer')
GO
INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (3, N'Disorders of ear')
GO
INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (4, N'Disorders of eye')
GO
INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (5, N'Mental illness')
GO
INSERT [dbo].[NCD] ([NCDID], [NCDName]) VALUES (6, N'Oral health problems')
GO
SET IDENTITY_INSERT [dbo].[NCD] OFF
GO
SET IDENTITY_INSERT [dbo].[NCDDetails] ON 
GO
INSERT [dbo].[NCDDetails] ([ID], [PatientInformationID], [NCDID]) VALUES (3, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[NCDDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[PatientInformation] ON 
GO
INSERT [dbo].[PatientInformation] ([PatientInformationID], [PatientName], [Epilepsy], [Age], [Address], [ContactNo], [DiseaseId]) VALUES (1, N'Mr. Touhid', 1, 0, NULL, NULL, 2)
GO
SET IDENTITY_INSERT [dbo].[PatientInformation] OFF
GO
ALTER TABLE [dbo].[AllergiesDetails]  WITH CHECK ADD  CONSTRAINT [FK_AllergiesDetails_PatientInformation_PatientInformationID] FOREIGN KEY([PatientInformationID])
REFERENCES [dbo].[PatientInformation] ([PatientInformationID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AllergiesDetails] CHECK CONSTRAINT [FK_AllergiesDetails_PatientInformation_PatientInformationID]
GO
ALTER TABLE [dbo].[NCDDetails]  WITH CHECK ADD  CONSTRAINT [FK_NCDDetails_PatientInformation_PatientInformationID] FOREIGN KEY([PatientInformationID])
REFERENCES [dbo].[PatientInformation] ([PatientInformationID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NCDDetails] CHECK CONSTRAINT [FK_NCDDetails_PatientInformation_PatientInformationID]
GO
ALTER TABLE [dbo].[PatientInformation]  WITH CHECK ADD  CONSTRAINT [FK_PatientInformation_DiseaseInformation_DiseaseId] FOREIGN KEY([DiseaseId])
REFERENCES [dbo].[DiseaseInformation] ([DiseaseID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientInformation] CHECK CONSTRAINT [FK_PatientInformation_DiseaseInformation_DiseaseId]
GO
USE [master]
GO
ALTER DATABASE [HospitalManagement2024] SET  READ_WRITE 
GO
