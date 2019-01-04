USE [PcPartPickerDatabase]
GO

/****** Object:  StoredProcedure [pc].[CreateBuild]    Script Date: 12/5/2018 4:03:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [pc].[CreateBuild] 
					@Cpu int, 
					@MotherBoard int, 
					@Memory int, 
					@Gpu int, 
					@Storage int, 
					@PowerSupply int, 
					@PcCase int,
					@BuildName nvarchar(100),
					@UserId int = null
AS
	INSERT INTO pc.build
	(
		cpu, 
		motherboard, 
		memory, 
		gpu, 
		storage, 
		powersupply, 
		pccase, 
		buildname, 
		builddate,
		userId
	)
	SELECT 
		@Cpu, 
		@MotherBoard, 
		@Memory, 
		@Gpu, 
		@Storage, 
		@PowerSupply, 
		@PcCase,
		@BuildName,
		SYSDATETIME(),
		@UserId

GO


