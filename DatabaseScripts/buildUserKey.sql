USE [PcPartPickerDatabase]
GO

ALTER TABLE [pc].[build]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [pc].[user] ([id])
GO

SELECT * FROM [pc].[order]


---Create cpu stored procedure---
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
