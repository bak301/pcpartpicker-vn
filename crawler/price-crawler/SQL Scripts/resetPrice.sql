use PcPartPickerDatabase;
go

delete from pc.price;

DBCC CHECKIDENT ('pc.price', RESEED, 0)