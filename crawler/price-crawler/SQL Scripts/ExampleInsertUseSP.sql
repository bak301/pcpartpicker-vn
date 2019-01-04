use PcPartPickerDatabase;
go

declare @path nvarchar(1000) = N'C:\Users\vn130\Desktop\project\pcpartpicker-project\crawler\price-crawler\data\';
declare @merchant nvarchar(50) = N'Mai Hoang';

EXEC pc.ImportFromJson
@rootPath = @path,
@merchant = @merchant,
@part = N'cpu'

EXEC pc.ImportFromJson
@rootPath = @path,
@merchant = @merchant,
@part = N'motherboard'

EXEC pc.ImportFromJson
@rootPath = @path,
@merchant = @merchant,
@part = N'memory'

EXEC pc.ImportFromJson
@rootPath = @path,
@merchant = @merchant,
@part = N'gpu'

EXEC pc.ImportFromJson
@rootPath = @path,
@merchant = @merchant,
@part = N'ssd'

EXEC pc.ImportFromJson
@rootPath = @path,
@merchant = @merchant,
@part = N'psu'

EXEC pc.ImportFromJson
@rootPath = @path,
@merchant = @merchant,
@part = N'case'