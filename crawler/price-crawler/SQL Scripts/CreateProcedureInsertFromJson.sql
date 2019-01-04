USE [PcPartPickerDatabase]
GO
/****** Object:  StoredProcedure [pc].[ImportFromJson]    Script Date: 29-Oct-18 5:34:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [pc].[ImportFromJson] 
	@rootPath nvarchar(max),
	@merchant nvarchar(50),
	@part nvarchar(30)
as
-- BEGIN PROCEDURE

declare @importSQL nvarchar(max);
declare @datasource nvarchar(max);
declare @jsonSize int;
declare @partId int;

set @importSQL= N'select @datasourceout = BulkColumn from openrowset(bulk '''+ @rootPath + @merchant + '\' + @part +'.json'', single_clob) json;'
exec sp_executesql @importSQL, N'@datasourceout nvarchar(max) OUTPUT'
,@datasourceout = @datasource output;

select distinct
	pc.part.id as partid,
	ISNULL(jsource.price,0) as price, 
	jsource.inStock as inStock, 
	jsource.[date] as [date],
	[url] as partUrl
into pc.jsonSource 
from OPENJSON(@datasource,'$')
with (
	[name] varchar(100),
	[price] int,
	inStock bit,
	[date] datetime,
	[url] nvarchar(2083) '$.url'
) as jsource, pc.part
where jsource.[name] like 
	(case when @part = N'memory' or @part = N'ssd'
				then '%' + replace(pc.part.partname,'-',' ') +'%'
			when @part = N'gpu'
				then concat('%', pc.part.[name], '%')
			else '%' + replace(pc.part.[name],'-',' ') + ' %'
	end)
and jsource.[name] like '%' + pc.part.manufacturer + '%';

select @jsonSize = count(*) from OPENJSON(@datasource,'$');

insert into pc.price (partid, merchant, baseprice, isinstock, [date])
select partid, @merchant, price, inStock, [date] from jsonSource

print cast(@@ROWCOUNT as varchar(5)) + '/' + cast(@jsonSize as varchar(5)) + ' ' + @part +' has been insert to Price'

merge pc.link as [Target]
using pc.jsonSource as [Source]
on ( [Target].partid = [Source].partid and [Target].merchant = @merchant)
when matched and [Target].[url] <> [Source].partUrl then
	update set [Target].[url] = [Source].partUrl
when not matched by target then
	insert VALUES ([Source].partid, @merchant, [Source].partUrl);

drop table if exists pc.jsonSource;
