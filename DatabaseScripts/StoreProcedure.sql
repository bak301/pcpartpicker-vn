USE pcpartpickerdatabase
GO

---GET ALL Cpus---
IF OBJECT_ID('pc.GetAllCpus') IS NOT NULL
BEGIN
	DROP PROCEDURE pc.GetAllCpus
END;
GO

CREATE PROCEDURE pc.GetAllCpus
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

---GET ALL Storages---
IF OBJECT_ID('pc.GetAllStorages') IS NOT NULL
BEGIN
	DROP PROCEDURE pc.GetAllStorages
END;
GO

CREATE PROCEDURE pc.GetAllStorages
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

---GET ALL PowerSupplies---
IF OBJECT_ID('pc.GetAllPowerSupplies') IS NOT NULL
BEGIN
	DROP PROCEDURE pc.GetAllPowerSupplies 
END;
GO

CREATE PROCEDURE pc.GetAllPowerSupplies
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

---GET ALL GPUs---
IF OBJECT_ID('pc.GetAllGPUs') IS NOT NULL
BEGIN
	DROP PROCEDURE pc.GetAllGPUs
END;
GO

CREATE PROCEDURE pc.GetAllGPUs
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

---GET ALL PcCase---
IF OBJECT_ID('pc.GetAllPcCases') IS NOT NULL
BEGIN
	DROP PROCEDURE pc.GetAllPcCases
END;
GO

CREATE PROCEDURE pc.GetAllPcCases
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

---GET ALL Memory devices---
IF OBJECT_ID('pc.GetAllMemoryDevices') IS NOT NULL
BEGIN
	DROP PROCEDURE pc.GetAllMemoryDevices
END;
GO

CREATE PROCEDURE pc.GetAllMemoryDevices
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

---GET ALL Motherboards---
IF OBJECT_ID('pc.GetAllMotherBoards') IS NOT NULL
BEGIN
	DROP PROCEDURE pc.GetAllMotherBoards
END;
GO

CREATE PROCEDURE pc.GetAllMotherBoards
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

---GET ALL built pcs---
IF OBJECT_ID('pc.GetAllBuilds') IS NOT NULL
BEGIN
	DROP PROCEDURE pc.GetAllBuilds
END;
GO

CREATE PROCEDURE pc.GetAllBuilds
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

---GET ALL Parts---
IF OBJECT_ID('pc.GetAllParts') IS NOT NULL
BEGIN
	DROP PROCEDURE pc.GetAllParts
END;
GO

CREATE PROCEDURE pc.GetAllParts
AS
	SELECT
		id, 
		name, 
		manufacturer, 
		partname
	FROM
		pc.part
GO

---Create A new CPU---
IF OBJECT_ID('pc.CreateCpu') IS NOT NULL
BEGIN
	DROP PROCEDURE pc.CreateCpu
END;
GO

CREATE PROCEDURE pc.CreateCpu
					@Name  VARCHAR(100) = NULL,
					@Manufacturer VARCHAR(10) = NULL,
					@PartName VARCHAR(50) = NULL,
					@DataWidth TINYINT = NULL,
					@Socket VARCHAR(20) = NULL,
					@Basefrequency VARCHAR(10) = NULL,
					@Boostfrequency VARCHAR(10) = NULL,
					@Corescount TINYINT = NULL,
					@L1cache VARCHAR(100) = NULL,
					@L2cache VARCHAR(30) = NULL,
					@L3cache VARCHAR(30) = NULL,
					@Lithography SMALLINT = NULL,
					@Tdp SMALLINT = NULL,
					@Iscoolerincluded BIT = NULL,
					@Ishyperthreaded BIT = NULL,
					@Maxmemory SMALLINT = NULL,
					@Igpu VARCHAR(50) = NULL
AS
	INSERT INTO pc.part
	(
		name,
		manufacturer,
		partname
	)
	SELECT
		@Name,
		@Manufacturer,
		@PartName;
	INSERT INTO pc.Cpu
	(
		id,
		datawidth,
		socket,
		basefrequency,
		boostfrequency,
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
	)
	SELECT
		SCOPE_IDENTITY(),
		@DataWidth, 
		@Socket, 
		@Basefrequency, 
		@Boostfrequency, 
		@Corescount,
		@L1cache,
		@L2cache, 
		@L3cache, 
		@Lithography, 
		@Tdp, 
		@Iscoolerincluded, 
		@Ishyperthreaded,
		@Maxmemory, 
		@Igpu;
GO


USE pcpartpickerdatabase
	EXEC pc.CreateCpu 
	@Name = 'core i3', 
	@Manufacturer = 'Intel', 
	@PartName = 'Cpu',
	@DataWidth = 1,
	@Socket = 'goodsocket',
	@Basefrequency = 'good',
	@Boostfrequency = 'normal'
