use PcPartPickerDatabase;
go

declare @datasource nvarchar(max);
declare @importScript nvarchar(max);
declare @rootPath nvarchar(max);
declare @merchant nvarchar(50);
declare @part nvarchar(30);

set @rootPath = N'C:\Users\vn130\Desktop\project\pcpartpicker-project\crawler\price-crawler\data\';
set @merchant = N'Mai Hoang';
set @part = N'\cpu';

set @importScript = N'select @datasourceout = BulkColumn from openrowset(bulk '''+ @rootPath + @merchant + @part +'.json'', single_clob) json;'
exec sp_executesql @importScript, N'@datasourceout nvarchar(max) OUTPUT'
,@datasourceout = @datasource output;


--insert into pc.price (partid, merchant, baseprice, isinstock, [date])
select distinct
pc.part.id,
pc.part.[name],
pc.part.partname,
'Mai Hoang' as merchant,
ISNULL(jsonSource.price,0) as price, 
jsonSource.inStock, 
jsonSource.[date]
from OPENJSON(@datasource,'$')
with (
	[name] varchar(100),
	[price] int,
	inStock bit,
	[date] datetime
) as jsonSource, pc.part
where UPPER(jsonSource.[name]) like '%'+UPPER(pc.part.[name])+' '
or UPPER(jsonSource.[name]) = UPPER(pc.part.[name])
