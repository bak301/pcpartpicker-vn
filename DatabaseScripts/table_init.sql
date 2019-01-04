USE master; 
GO 
IF NOT EXISTS (SELECT * 
               FROM   sys.databases 
               WHERE  NAME = N'PcPartPickerDatabase') 
BEGIN 
	CREATE DATABASE PcPartPickerDatabase 
END; 

GO 

USE PcPartPickerDatabase 

GO 

CREATE SCHEMA pc 

GO 

-- // Primary tables 
CREATE TABLE pc.part 
( 
    id           INT IDENTITY(1,1) PRIMARY KEY, 
    name         VARCHAR(100), 
    manufacturer VARCHAR(10), 
    partname     VARCHAR(50), 
); 

--// primary pc parts 
CREATE TABLE pc.cpu 
( 
	id               INT PRIMARY KEY REFERENCES pc.part(id), 
	datawidth        TINYINT, 
	socket           VARCHAR(20), 
	basefrequency    VARCHAR(10), 
	boostfrequency   VARCHAR(10), 
	corescount       TINYINT, 
	l1cache          VARCHAR(100), 
	l2cache          VARCHAR(30), 
	l3cache          VARCHAR(30), 
	lithography      SMALLINT, 
	tdp              SMALLINT, 
	iscoolerincluded BIT, 
	ishyperthreaded  BIT, 
	maxmemory        SMALLINT, 
	igpu             VARCHAR(50) 
); 

CREATE TABLE pc.motherboard 
( 
	id               INT PRIMARY KEY REFERENCES pc.part(id), 
	color            VARCHAR(20), 
	formfactor       VARCHAR(10), 
	socket           VARCHAR(20), 
	chipset          VARCHAR(10), 
	memoryslots      TINYINT, 
	memorytype       VARCHAR(100), 
	memorymaxsize    SMALLINT, 
	raidsupport      BIT, 
	isigpusupported  BIT, 
	isxfiresupported BIT, 
	isslisupported   BIT, 
	sata3portcounts  TINYINT, 
	onboardethernet  VARCHAR(50), 
	isusb3supported  BIT, 
); 

CREATE TABLE pc.gpu 
( 
	id                      INT PRIMARY KEY REFERENCES pc.part(id), 
	color                   VARCHAR(30), 
	interface               VARCHAR(30), 
	chipset                 VARCHAR(50), 
	memorysize              TINYINT, 
	memorytype              VARCHAR(10), 
	coreclock               FLOAT, 
	boostclock              FLOAT, 
	tdp                     SMALLINT, 
	isfanincluded           BIT, 
	isslisupported          BIT, 
	iscrossfiresupported    VARCHAR(30), 
	cardlength              SMALLINT, 
	isadaptivesyncsupported BIT, 
	dvicount                TINYINT, 
	displayportcount        TINYINT, 
	hdmicount               TINYINT, 
	vgacount                TINYINT 
); 

CREATE TABLE pc.memory 
( 
	id                     INT PRIMARY KEY REFERENCES pc.part(id), 
	color                  VARCHAR(30), 
	memorytype             TINYINT, 
	speed                  SMALLINT, 
	sticksize              VARCHAR(20), 
	caslatency             TINYINT, 
	memorytiming           VARCHAR(50), 
	memoryvoltage          FLOAT, 
	isheatspreaderincluded BIT, 
	isecc                  BIT, 
	isregistered           BIT 
); 

CREATE TABLE pc.storage 
( 
	id         INT PRIMARY KEY REFERENCES pc.part(id), 
	capacity   SMALLINT, 
	interface  VARCHAR(20), 
	cache      SMALLINT, 
	rpm        SMALLINT, 
	--// if RPM = 0 mean SSD 
	formfactor VARCHAR(10), 
); 

CREATE TABLE pc.powersupply 
( 
	id             INT PRIMARY KEY REFERENCES pc.part(id), 
	type           VARCHAR(10), 
	wattage        SMALLINT, 
	modularity     VARCHAR(5), 
	efficiencycert VARCHAR(20), 
); 

CREATE TABLE pc.pccase 
( 
	id                       INT PRIMARY KEY REFERENCES pc.part(id), 
	color                    VARCHAR(30), 
	type                     VARCHAR(30), 
	wattagepsuincluded       SMALLINT, 
	internal525baycount      TINYINT, 
	internal35baycount       TINYINT, 
	external525baycount      TINYINT, 
	external35baycount       TINYINT, 
	motherboardformsupported VARCHAR(50), 
	isfrontusb3supported     BIT, 
	vgamaxlength             SMALLINT, 
	dimensions               VARCHAR(50), 
); 

--// secondary pc part 
--create table monitor ( 
--) 
--create table mouse ( 
--) 
--create table keyboard ( 
--) 
--create table speaker ( 
--); 
----//  
--create table pcbuild ( 
--) 

CREATE TABLE [pc].[build] 
( 
	[id]          INT IDENTITY(1, 1) NOT NULL, 
	[cpu]         INT NULL, 
	[motherboard] INT NULL, 
	[memory]      INT NULL, 
	[gpu]         INT NULL, 
	[storage]     INT NULL, 
	[powersupply] INT NULL, 
	[pccase]      INT NULL, 
	[buildname]   [NVARCHAR](100) NULL, 
	[builddate]   [DATE] NULL, 
	PRIMARY KEY CLUSTERED ( [id] ASC )WITH (pad_index = OFF, 
	statistics_norecompute = OFF, ignore_dup_key = OFF, allow_row_locks = on, 
	allow_page_locks = on) ON [PRIMARY] 
) 
ON [PRIMARY] 

GO 

ALTER TABLE [pc].[build] 
  WITH CHECK ADD CONSTRAINT [FK_Cpu] FOREIGN KEY([cpu]) REFERENCES [pc].[cpu] ( 
  [id]) 

GO 

ALTER TABLE [pc].[build] 
  CHECK CONSTRAINT [FK_Cpu] 

GO 

ALTER TABLE [pc].[build] 
  WITH CHECK ADD CONSTRAINT [FK_Gpu] FOREIGN KEY([gpu]) REFERENCES [pc].[gpu] ( 
  [id]) 

GO 

ALTER TABLE [pc].[build] 
  CHECK CONSTRAINT [FK_Gpu] 

GO 

ALTER TABLE [pc].[build] 
  WITH CHECK ADD CONSTRAINT [FK_Memory] FOREIGN KEY([memory]) REFERENCES 
  [pc].[memory] ([id]) 

GO 

ALTER TABLE [pc].[build] 
  CHECK CONSTRAINT [FK_Memory] 

GO 

ALTER TABLE [pc].[build] 
  WITH CHECK ADD CONSTRAINT [FK_Motherboard] FOREIGN KEY([motherboard]) 
  REFERENCES [pc].[motherboard] ([id]) 

GO 

ALTER TABLE [pc].[build] 
  CHECK CONSTRAINT [FK_Motherboard] 

GO 

ALTER TABLE [pc].[build] 
  WITH CHECK ADD CONSTRAINT [FK_PcCase] FOREIGN KEY([pccase]) REFERENCES 
  [pc].[pccase] ([id]) 

GO 

ALTER TABLE [pc].[build] 
  CHECK CONSTRAINT [FK_PcCase] 

GO 

ALTER TABLE [pc].[build] 
  WITH CHECK ADD CONSTRAINT [FK_PowerSupply] FOREIGN KEY([powersupply]) 
  REFERENCES [pc].[powersupply] ([id]) 

GO 

ALTER TABLE [pc].[build] 
  CHECK CONSTRAINT [FK_PowerSupply] 

GO 

ALTER TABLE [pc].[build] 
  WITH CHECK ADD CONSTRAINT [FK_Storage] FOREIGN KEY([storage]) REFERENCES 
  [pc].[storage] ([id]) 

GO 

ALTER TABLE [pc].[build] 
  CHECK CONSTRAINT [FK_Storage] 

GO 

--create table partprice ( 
--) 
CREATE TABLE pc.price 
( 
	id        INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, 
	partid    INT NOT NULL REFERENCES pc.part(id), 
	merchant  NVARCHAR(50) NOT NULL, 
	baseprice INT NOT NULL, 
	promotion INT 
); 

--create table image---

CREATE TABLE pc.[image] 
(
	id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	partid INT NOT NULL REFERENCES pc.part(id),
	imageUrl varchar(MAX)
)

