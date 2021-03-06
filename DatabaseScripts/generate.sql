USE [master]
GO
/****** Object:  Database [PcPartPickerDatabase]    Script Date: 10/3/2018 5:22:07 PM ******/
CREATE DATABASE [PcPartPickerDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PcPartPickerDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PcPartPickerDatabase.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PcPartPickerDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PcPartPickerDatabase_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PcPartPickerDatabase] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PcPartPickerDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PcPartPickerDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PcPartPickerDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PcPartPickerDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PcPartPickerDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PcPartPickerDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PcPartPickerDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PcPartPickerDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [PcPartPickerDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PcPartPickerDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PcPartPickerDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PcPartPickerDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PcPartPickerDatabase]
GO
/****** Object:  Schema [pc]    Script Date: 10/3/2018 5:22:07 PM ******/
CREATE SCHEMA [pc]
GO
/****** Object:  Table [pc].[build]    Script Date: 10/3/2018 5:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pc].[build](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cpu] [int] NULL,
	[motherboard] [int] NULL,
	[memory] [int] NULL,
	[gpu] [int] NULL,
	[storage] [int] NULL,
	[powersupply] [int] NULL,
	[pccase] [int] NULL,
	[buildname] [nvarchar](100) NULL,
	[builddate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [pc].[cpu]    Script Date: 10/3/2018 5:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pc].[cpu](
	[id] [int] NOT NULL,
	[datawidth] [tinyint] NULL,
	[socket] [varchar](20) NULL,
	[basefrequency] [varchar](10) NULL,
	[boostfrequency] [varchar](10) NULL,
	[corescount] [tinyint] NULL,
	[l1cache] [varchar](100) NULL,
	[l2cache] [varchar](30) NULL,
	[l3cache] [varchar](30) NULL,
	[lithography] [smallint] NULL,
	[tdp] [smallint] NULL,
	[iscoolerincluded] [bit] NULL,
	[ishyperthreaded] [bit] NULL,
	[maxmemory] [smallint] NULL,
	[igpu] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [pc].[gpu]    Script Date: 10/3/2018 5:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pc].[gpu](
	[id] [int] NOT NULL,
	[color] [varchar](30) NULL,
	[interface] [varchar](30) NULL,
	[chipset] [varchar](50) NULL,
	[memorysize] [tinyint] NULL,
	[memorytype] [varchar](10) NULL,
	[coreclock] [float] NULL,
	[boostclock] [float] NULL,
	[tdp] [smallint] NULL,
	[isfanincluded] [bit] NULL,
	[isslisupported] [bit] NULL,
	[iscrossfiresupported] [varchar](30) NULL,
	[cardlength] [smallint] NULL,
	[isadaptivesyncsupported] [bit] NULL,
	[dvicount] [tinyint] NULL,
	[displayportcount] [tinyint] NULL,
	[hdmicount] [tinyint] NULL,
	[vgacount] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [pc].[image]    Script Date: 10/3/2018 5:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pc].[image](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[partid] [int] NOT NULL,
	[imageUrl] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [pc].[memory]    Script Date: 10/3/2018 5:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pc].[memory](
	[id] [int] NOT NULL,
	[color] [varchar](30) NULL,
	[memorytype] [tinyint] NULL,
	[speed] [smallint] NULL,
	[sticksize] [varchar](20) NULL,
	[caslatency] [tinyint] NULL,
	[memorytiming] [varchar](50) NULL,
	[memoryvoltage] [float] NULL,
	[isheatspreaderincluded] [bit] NULL,
	[isecc] [bit] NULL,
	[isregistered] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [pc].[motherboard]    Script Date: 10/3/2018 5:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pc].[motherboard](
	[id] [int] NOT NULL,
	[color] [varchar](20) NULL,
	[formfactor] [varchar](10) NULL,
	[socket] [varchar](20) NULL,
	[chipset] [varchar](10) NULL,
	[memoryslots] [tinyint] NULL,
	[memorytype] [varchar](100) NULL,
	[memorymaxsize] [smallint] NULL,
	[raidsupport] [bit] NULL,
	[isigpusupported] [bit] NULL,
	[isxfiresupported] [bit] NULL,
	[isslisupported] [bit] NULL,
	[sata3portcounts] [tinyint] NULL,
	[onboardethernet] [varchar](50) NULL,
	[isusb3supported] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [pc].[part]    Script Date: 10/3/2018 5:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pc].[part](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[manufacturer] [varchar](10) NULL,
	[partname] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [pc].[pccase]    Script Date: 10/3/2018 5:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pc].[pccase](
	[id] [int] NOT NULL,
	[color] [varchar](30) NULL,
	[type] [varchar](30) NULL,
	[wattagepsuincluded] [smallint] NULL,
	[internal525baycount] [tinyint] NULL,
	[internal35baycount] [tinyint] NULL,
	[external525baycount] [tinyint] NULL,
	[external35baycount] [tinyint] NULL,
	[motherboardformsupported] [varchar](50) NULL,
	[isfrontusb3supported] [bit] NULL,
	[vgamaxlength] [smallint] NULL,
	[dimensions] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [pc].[powersupply]    Script Date: 10/3/2018 5:22:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pc].[powersupply](
	[id] [int] NOT NULL,
	[type] [varchar](10) NULL,
	[wattage] [smallint] NULL,
	[modularity] [varchar](5) NULL,
	[efficiencycert] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [pc].[price]    Script Date: 10/3/2018 5:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pc].[price](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[partid] [int] NOT NULL,
	[merchant] [nvarchar](50) NOT NULL,
	[baseprice] [int] NOT NULL,
	[promotion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [pc].[storage]    Script Date: 10/3/2018 5:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [pc].[storage](
	[id] [int] NOT NULL,
	[capacity] [smallint] NULL,
	[interface] [varchar](20) NULL,
	[cache] [smallint] NULL,
	[rpm] [smallint] NULL,
	[formfactor] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [pc].[build]  WITH CHECK ADD  CONSTRAINT [FK_Cpu] FOREIGN KEY([cpu])
REFERENCES [pc].[cpu] ([id])
GO
ALTER TABLE [pc].[build] CHECK CONSTRAINT [FK_Cpu]
GO
ALTER TABLE [pc].[build]  WITH CHECK ADD  CONSTRAINT [FK_Gpu] FOREIGN KEY([gpu])
REFERENCES [pc].[gpu] ([id])
GO
ALTER TABLE [pc].[build] CHECK CONSTRAINT [FK_Gpu]
GO
ALTER TABLE [pc].[build]  WITH CHECK ADD  CONSTRAINT [FK_Memory] FOREIGN KEY([memory])
REFERENCES [pc].[memory] ([id])
GO
ALTER TABLE [pc].[build] CHECK CONSTRAINT [FK_Memory]
GO
ALTER TABLE [pc].[build]  WITH CHECK ADD  CONSTRAINT [FK_Motherboard] FOREIGN KEY([motherboard])
REFERENCES [pc].[motherboard] ([id])
GO
ALTER TABLE [pc].[build] CHECK CONSTRAINT [FK_Motherboard]
GO
ALTER TABLE [pc].[build]  WITH CHECK ADD  CONSTRAINT [FK_PcCase] FOREIGN KEY([pccase])
REFERENCES [pc].[pccase] ([id])
GO
ALTER TABLE [pc].[build] CHECK CONSTRAINT [FK_PcCase]
GO
ALTER TABLE [pc].[build]  WITH CHECK ADD  CONSTRAINT [FK_PowerSupply] FOREIGN KEY([powersupply])
REFERENCES [pc].[powersupply] ([id])
GO
ALTER TABLE [pc].[build] CHECK CONSTRAINT [FK_PowerSupply]
GO
ALTER TABLE [pc].[build]  WITH CHECK ADD  CONSTRAINT [FK_Storage] FOREIGN KEY([storage])
REFERENCES [pc].[storage] ([id])
GO
ALTER TABLE [pc].[build] CHECK CONSTRAINT [FK_Storage]
GO
ALTER TABLE [pc].[cpu]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [pc].[part] ([id])
GO
ALTER TABLE [pc].[gpu]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [pc].[part] ([id])
GO
ALTER TABLE [pc].[image]  WITH CHECK ADD FOREIGN KEY([partid])
REFERENCES [pc].[part] ([id])
GO
ALTER TABLE [pc].[memory]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [pc].[part] ([id])
GO
ALTER TABLE [pc].[motherboard]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [pc].[part] ([id])
GO
ALTER TABLE [pc].[pccase]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [pc].[part] ([id])
GO
ALTER TABLE [pc].[powersupply]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [pc].[part] ([id])
GO
ALTER TABLE [pc].[price]  WITH CHECK ADD FOREIGN KEY([partid])
REFERENCES [pc].[part] ([id])
GO
ALTER TABLE [pc].[storage]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [pc].[part] ([id])
GO
/****** Object:  StoredProcedure [pc].[GetAllBuilds]    Script Date: 10/3/2018 5:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pc].[GetAllBuilds]
AS
	SELECT
		id, 
		cpu, 
		motherboard, 
		memory, 
		gpu, 
		storage, 
		powersupply, 
		pccase, 
		buildname, 
		builddate
	FROM
		pc.build
GO
/****** Object:  StoredProcedure [pc].[GetAllCpus]    Script Date: 10/3/2018 5:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pc].[GetAllCpus]
AS
	SELECT 
		id,
		datawidth,
		socket,
		basefrequency,
		corescount,
		l1cache,
		l2cache,
		l3cache,
		lithography,
		tdp,
		iscoolerincluded,
		ishyperthreaded,
		maxmemory,
		igpu
	FROM
		pc.cpu
GO
/****** Object:  StoredProcedure [pc].[GetAllGPUs]    Script Date: 10/3/2018 5:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pc].[GetAllGPUs]
AS
	SELECT
		id, 
		color, 
		interface, 
		chipset, 
		memorysize, 
		memorytype, 
		coreclock, 
		boostclock, 
		tdp, 
		isfanincluded, 
		isslisupported, 
		iscrossfiresupported, 
		cardlength, 
		isadaptivesyncsupported, 
		dvicount, 
		displayportcount, 
		hdmicount, 
		vgacount
	FROM
		pc.gpu
GO
/****** Object:  StoredProcedure [pc].[GetAllMemoryDevices]    Script Date: 10/3/2018 5:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pc].[GetAllMemoryDevices]
AS
	SELECT
		id,
		color,
		memorytype,
		speed,
		sticksize,
		caslatency,
		memorytiming,
		memoryvoltage,
		isheatspreaderincluded,
		isecc,
		isregistered
	FROM
		pc.memory
GO
/****** Object:  StoredProcedure [pc].[GetAllMotherBoards]    Script Date: 10/3/2018 5:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pc].[GetAllMotherBoards]
AS
	SELECT
		id,
		color,
		formfactor,
		socket,
		chipset,
		memoryslots,
		memorytype,
		memorymaxsize,
		raidsupport,
		isigpusupported,
		isxfiresupported,
		isslisupported,
		sata3portcounts,
		onboardethernet,
		isusb3supported
	FROM
		pc.motherboard
GO
/****** Object:  StoredProcedure [pc].[GetAllParts]    Script Date: 10/3/2018 5:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pc].[GetAllParts]
AS
	SELECT
		id, 
		name, 
		manufacturer, 
		partname
	FROM
		pc.part
GO
/****** Object:  StoredProcedure [pc].[GetAllPcCases]    Script Date: 10/3/2018 5:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pc].[GetAllPcCases]
AS
	SELECT
		id,
		color,
		type,
		wattagepsuincluded,
		internal525baycount,
		internal35baycount,
		external525baycount,
		external35baycount,
		motherboardformsupported,
		isfrontusb3supported,
		vgamaxlength,
		dimensions
	FROM
		pc.pccase
GO
/****** Object:  StoredProcedure [pc].[GetAllPowerSupplies]    Script Date: 10/3/2018 5:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pc].[GetAllPowerSupplies]
AS
	SELECT
		id,
		type,
		wattage,
		modularity,
		efficiencycert
	FROM
		pc.powersupply
GO
/****** Object:  StoredProcedure [pc].[GetAllStorages]    Script Date: 10/3/2018 5:22:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pc].[GetAllStorages]
AS
	SELECT
		id,
		capacity,
		interface,
		cache,
		rpm,
		formfactor
	FROM
		pc.storage
GO
USE [master]
GO
ALTER DATABASE [PcPartPickerDatabase] SET  READ_WRITE 
GO
