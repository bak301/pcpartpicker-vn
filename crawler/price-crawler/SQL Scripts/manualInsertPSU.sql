use PcPartPickerDatabase;
go

insert into pc.link values
((select pc.part.id from pc.part where pc.part.[partname] like '%SSR-750FX%'),
'Mai Hoang', 'http://maihoang.com.vn/seasonic-focus-plus-750w-fx-750-80-plus-gold'),
((select pc.part.id from pc.part where pc.part.[partname] like '%SSR-650FX%'),
'Mai Hoang', 'http://maihoang.com.vn/seasonic-focus-plus-650w-fx-750-80-plus-gold'),
((select pc.part.id from pc.part where pc.part.[partname] like '%SSR-850FX%'),
'Mai Hoang', 'http://maihoang.com.vn/seasonic-focus-plus-850w-fx-850-80-plus-gold'),
((select pc.part.id from pc.part where pc.part.[partname] like '%SSR-1000GD%'),
'Mai Hoang', 'http://maihoang.com.vn/seasonic-prime-ultra-1000w-1000gd-80-plus-gold'),
((select pc.part.id from pc.part where pc.part.[partname] like '%SSR-1000FX%'),
'Mai Hoang', 'http://maihoang.com.vn/seasonic-focus-plus-fx-1000-80-plus%C2%AEgold')