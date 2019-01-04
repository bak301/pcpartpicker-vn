USE [PcPartPickerDatabase]
GO

/****** Object:  StoredProcedure [pc].[GetAllBuilds]    Script Date: 12/5/2018 4:03:41 PM ******/
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
		builddate,
		userId
	FROM
		pc.build
GO


