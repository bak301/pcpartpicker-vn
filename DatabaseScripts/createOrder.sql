USE [PcPartPickerDatabase]
GO

/****** Object:  StoredProcedure [pc].[CreateOrder]    Script Date: 12/5/2018 4:04:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [pc].[CreateOrder]
					@CustomerName varchar(30),
					@PhoneNumber varchar(30),
					@Address varchar(30),
					@OrderStatus bit,
					@BuildId int = null
AS
	INSERT INTO [pc].[order]
	(
		customerName,
		phoneNumber,
		[address],
		orderStatus,
		buildId
	)
	SELECT 
		@CustomerName,
		@PhoneNumber,
		@Address,
		@OrderStatus,
		@BuildId 
GO


