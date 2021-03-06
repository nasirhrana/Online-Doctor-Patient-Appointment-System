USE [master]
GO
/****** Object:  Database [ODAS]    Script Date: 13-Aug-18 12:00:50 PM ******/
CREATE DATABASE [ODAS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ODAS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ODAS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ODAS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ODAS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ODAS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ODAS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ODAS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ODAS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ODAS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ODAS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ODAS] SET ARITHABORT OFF 
GO
ALTER DATABASE [ODAS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ODAS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ODAS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ODAS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ODAS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ODAS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ODAS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ODAS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ODAS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ODAS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ODAS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ODAS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ODAS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ODAS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ODAS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ODAS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ODAS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ODAS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ODAS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ODAS] SET  MULTI_USER 
GO
ALTER DATABASE [ODAS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ODAS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ODAS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ODAS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ODAS]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 13-Aug-18 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 13-Aug-18 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Appointment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[StartTime] [varchar](50) NOT NULL,
	[EndTime] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DrRegistration]    Script Date: 13-Aug-18 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DrRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varchar](50) NOT NULL,
	[DoctorName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[RegistrationNo] [varchar](50) NOT NULL,
	[NID] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[Degree] [varchar](50) NOT NULL,
	[SpecialityId] [int] NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DrRegistration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DrSchedule]    Script Date: 13-Aug-18 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DrSchedule](
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorId] [int] NOT NULL,
	[AppointmentDate] [date] NOT NULL,
	[StartTime] [varchar](50) NOT NULL,
	[EndTime] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DrSchedule_1] PRIMARY KEY CLUSTERED 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PtRegistration]    Script Date: 13-Aug-18 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PtRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varchar](50) NULL,
	[PatientName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[DOB] [date] NOT NULL,
	[NID] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PtRegistration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Speciality]    Script Date: 13-Aug-18 12:00:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Speciality](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpecialityName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Speciality] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Id], [Name], [Email], [Password]) VALUES (1, N'Nasir', N'nasirhrana@gmail.com', N'123456')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Appointment] ON 

INSERT [dbo].[Appointment] ([Id], [ScheduleId], [DoctorId], [PatientId], [Date], [StartTime], [EndTime], [Status]) VALUES (1, 3018, 4005, 2002, CAST(0xEE3E0B00 AS Date), N'07:00', N'09:00', N'Approved')
INSERT [dbo].[Appointment] ([Id], [ScheduleId], [DoctorId], [PatientId], [Date], [StartTime], [EndTime], [Status]) VALUES (1002, 3018, 4005, 2002, CAST(0xEE3E0B00 AS Date), N'07:00', N'09:00', N'Approved')
INSERT [dbo].[Appointment] ([Id], [ScheduleId], [DoctorId], [PatientId], [Date], [StartTime], [EndTime], [Status]) VALUES (1003, 3018, 4005, 2002, CAST(0xEE3E0B00 AS Date), N'07:00', N'09:00', N'Approved')
INSERT [dbo].[Appointment] ([Id], [ScheduleId], [DoctorId], [PatientId], [Date], [StartTime], [EndTime], [Status]) VALUES (1004, 3019, 4005, 2002, CAST(0xEE3E0B00 AS Date), N'14:00', N'20:00', N'Approved')
INSERT [dbo].[Appointment] ([Id], [ScheduleId], [DoctorId], [PatientId], [Date], [StartTime], [EndTime], [Status]) VALUES (1013, 3018, 4005, 3002, CAST(0xEE3E0B00 AS Date), N'07:00', N'09:00', N'Submit')
SET IDENTITY_INSERT [dbo].[Appointment] OFF
SET IDENTITY_INSERT [dbo].[DrRegistration] ON 

INSERT [dbo].[DrRegistration] ([Id], [Image], [DoctorName], [Email], [RegistrationNo], [NID], [PhoneNo], [Gender], [DOB], [Degree], [SpecialityId], [Password]) VALUES (2003, N'1223', N'Nora Alam', N'na@gmail.com', N'123233', N'12345', N'01819429443', N'Male', CAST(0x823E0B00 AS Date), N'MBBS', 1, N'12345')
INSERT [dbo].[DrRegistration] ([Id], [Image], [DoctorName], [Email], [RegistrationNo], [NID], [PhoneNo], [Gender], [DOB], [Degree], [SpecialityId], [Password]) VALUES (2004, N'1223', N'Nora Alam', N'na@gmail.com', N'123233', N'12345', N'01819429443', N'Male', CAST(0x823E0B00 AS Date), N'MBBS', 1, N'12345')
INSERT [dbo].[DrRegistration] ([Id], [Image], [DoctorName], [Email], [RegistrationNo], [NID], [PhoneNo], [Gender], [DOB], [Degree], [SpecialityId], [Password]) VALUES (2005, N'1223', N'Nora Alam', N'na@gmail.com', N'123233', N'12345', N'01819429443', N'Male', CAST(0x813E0B00 AS Date), N'MBBS', 1, N'12345')
INSERT [dbo].[DrRegistration] ([Id], [Image], [DoctorName], [Email], [RegistrationNo], [NID], [PhoneNo], [Gender], [DOB], [Degree], [SpecialityId], [Password]) VALUES (3003, N'1223', N'Bangle', N'nasirrana@gmail.com', N'123233', N'12345', N'01819429443', N'Male', CAST(0x8A3E0B00 AS Date), N'MBBS', 1, N'123456')
INSERT [dbo].[DrRegistration] ([Id], [Image], [DoctorName], [Email], [RegistrationNo], [NID], [PhoneNo], [Gender], [DOB], [Degree], [SpecialityId], [Password]) VALUES (4003, N'~/Image/YhGYD7PF3nvs2XGfZAD2G7-970-80183750426.jpg', N'anik', N'anik@gmail.com', N'123233', N'1234567890', N'01876315517', N'Male', CAST(0x8D3E0B00 AS Date), N'MBBS', 3, N'123456')
INSERT [dbo].[DrRegistration] ([Id], [Image], [DoctorName], [Email], [RegistrationNo], [NID], [PhoneNo], [Gender], [DOB], [Degree], [SpecialityId], [Password]) VALUES (4004, N'~/Image/12345.jpg', N'Nora Alam', N's@gmil.com', N'123233', N'12345', N'01819429443', N'Male', CAST(0x8B3E0B00 AS Date), N'MBBS', 1, N'12345')
INSERT [dbo].[DrRegistration] ([Id], [Image], [DoctorName], [Email], [RegistrationNo], [NID], [PhoneNo], [Gender], [DOB], [Degree], [SpecialityId], [Password]) VALUES (4005, N'~/Image/1234567890.jpg', N'mamun', N'm@gmail.com', N'123233', N'1234567890', N'01819429443', N'Male', CAST(0x8D3E0B00 AS Date), N'MBBS', 2, N'12345')
SET IDENTITY_INSERT [dbo].[DrRegistration] OFF
SET IDENTITY_INSERT [dbo].[DrSchedule] ON 

INSERT [dbo].[DrSchedule] ([ScheduleId], [DoctorId], [AppointmentDate], [StartTime], [EndTime]) VALUES (3018, 4005, CAST(0xB33E0B00 AS Date), N'07:00', N'09:00')
INSERT [dbo].[DrSchedule] ([ScheduleId], [DoctorId], [AppointmentDate], [StartTime], [EndTime]) VALUES (3019, 4005, CAST(0xB33E0B00 AS Date), N'14:00', N'20:00')
SET IDENTITY_INSERT [dbo].[DrSchedule] OFF
SET IDENTITY_INSERT [dbo].[PtRegistration] ON 

INSERT [dbo].[PtRegistration] ([Id], [Image], [PatientName], [Email], [PhoneNo], [Gender], [DOB], [NID], [Password]) VALUES (1002, N'1223', N'Bangle', N'nasirrana@gmail.com', N'01819429443', N'Male', CAST(0xA03E0B00 AS Date), N'12345', N'123456')
INSERT [dbo].[PtRegistration] ([Id], [Image], [PatientName], [Email], [PhoneNo], [Gender], [DOB], [NID], [Password]) VALUES (2002, N'~/Image/1234567890.jpg', N'mamun', N'm@gmail.com', N'01819429443', N'Male', CAST(0x8F3E0B00 AS Date), N'1234567890', N'12345')
INSERT [dbo].[PtRegistration] ([Id], [Image], [PatientName], [Email], [PhoneNo], [Gender], [DOB], [NID], [Password]) VALUES (3002, N'~/Image/1234567890.jpg', N'Nasir Uddin', N'dreamingboy289@gmail.com', N'01876315517', N'Male', CAST(0x0D1A0B00 AS Date), N'1234567890', N'Dreamingboy289#')
SET IDENTITY_INSERT [dbo].[PtRegistration] OFF
SET IDENTITY_INSERT [dbo].[Speciality] ON 

INSERT [dbo].[Speciality] ([Id], [SpecialityName]) VALUES (1, N'dentist')
INSERT [dbo].[Speciality] ([Id], [SpecialityName]) VALUES (2, N'neorologist')
INSERT [dbo].[Speciality] ([Id], [SpecialityName]) VALUES (3, N'scientist')
SET IDENTITY_INSERT [dbo].[Speciality] OFF
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_PtRegistration] FOREIGN KEY([PatientId])
REFERENCES [dbo].[PtRegistration] ([Id])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_PtRegistration]
GO
ALTER TABLE [dbo].[DrRegistration]  WITH CHECK ADD  CONSTRAINT [FK_DrRegistration_Speciality] FOREIGN KEY([SpecialityId])
REFERENCES [dbo].[Speciality] ([Id])
GO
ALTER TABLE [dbo].[DrRegistration] CHECK CONSTRAINT [FK_DrRegistration_Speciality]
GO
USE [master]
GO
ALTER DATABASE [ODAS] SET  READ_WRITE 
GO
