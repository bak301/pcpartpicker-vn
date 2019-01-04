USE [PcPartPickerDatabase]
GO

/****** Object:  StoredProcedure [pc].[GetBuildById]    Script Date: 12/5/2018 4:03:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [pc].[GetBuildById] @Id int
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
	WHERE
		id = @Id
GO


