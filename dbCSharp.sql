﻿create database QuanLyThuPhiNuocSach
use QuanLyThuPhiNuocSach
create table tblTaiKhoan(
	sMaTK char(10) primary key not null,
	sMatKhau char(12),
	bQuyenTruyCap bit,
	bTrangThai bit default 0
)
create table tblNhanVien(
	sMaNV char(10) primary key not null,
	sTenNV nvarchar(255),
	dNgaySinh datetime,
	sDiaChi nvarchar(255),
	sGioiTinh nvarchar(10),
	sSDT char(11),
	sChucVu nvarchar(255),
	fHSL float,
	bTrangThai bit default 0 
)
alter table tblNhanVien
alter column dNgaySinh smalldatetime

create table tblKhachHang(
	sMaKH char(10) primary key not null,
	sTenKH nvarchar(255),
	dNgaySinh datetime,
	sDiaChi nvarchar(255),
	sGioiTinh nvarchar(10),
	sSDT char(11),
	sMaCongTo char(10),
	bTrangThai bit default 0
)
create table tblQuyenTruyCap
(
	iMaQuyenTruyCap bit primary key not null,
	sTenQuyenTruyCap nvarchar(255)
)
create table tblHoaDon(
	sMaHD char(10) primary key not null,
	sMaKH char(10),
	sMaNV char(10),
	dNgayLap datetime,
	dTuNgay datetime,
	dDenNgay datetime,
	fChiSoCu float,
	fChiSoMoi float,
	--fChiSoTieuThu float,
	--fMucTieuThuLoai1 float,
	--f,MucTieuThuLoai2 float
	--fMucTieuThuLoai3 float,
	--fMucTieuThuLoai4 float,
	fThueGTGT float default 0.1,
	--Tổng tiền là giá trị khi chưa công thêm tiền thuế giá trị gia tăng
	--fTongTien float,
	--Tổng thanh toán là giá trị khi đã cộng thêm tiền thuế giá trị gia tăng
	--fTongThanhToan float
)
alter table tblHoaDon
alter column dDenNgay date
alter table tblHoaDon
add bTrangThai bit default 1
alter table tblHoaDon
add fTongTien float null
--Khóa ngoại sMaKH
alter table tblHoaDon
add constraint FK_MaKH foreign key (sMaKH)
references tblKhachHang(sMaKH)
--Khóa ngoại sMaNV
alter table tblHoaDon
add constraint FK_MaNV foreign key (sMaNV)
references tblNhanVien(sMaNV)
--Khóa ngoại 
alter table tblTaiKhoan
add constraint FK_MaTK foreign key (sMaTK)
references tblNhanVien(sMaNV)
--Khóa ngoại quyền
alter table tblTaiKhoan
add constraint FK_MaQuyen foreign key (bQuyenTruyCap)
references tblQuyenTruyCap(iMaQuyenTruyCap)
--Trigger tự động thêm tài khoản khi thêm nhân viên
----------------------------SESSION
create table tblss
(
	id int primary key not null,
	ma char(10),
	matkhau varchar(100),
	quyen bit
)
alter table tblss
add matkhau nvarchar(100)
--select permission from tblss
create proc sp_getquyen
as
begin
	select quyen
	from tblss
end
--select id from tblss
create proc sp_getma
as
begin
	select ma
	from tblss
end
--insert to tblss
alter proc sp_session
@ma char(10),
@matkhau char(100),
@quyen int
as
begin
	delete from tblss where 1=1
	insert into tblss
	values(1,@ma,@quyen,@matkhau)
end
exec sp_session @ma = NV00000000,@quyen =1
--select to tblss
create proc sp_getss
as
begin
	select * from tblss where id = 1
end
----------------------------ENDSESSION
alter function fcgetMaNV()
returns varchar(10)
as
begin 
   declare @MaNV varchar(10)
   declare @MaxMaNV varchar(10)
   declare @Max float
   select @MaxMaNV=MAX(sMaNV) from tblNhanVien
   if exists (select sMaNV from tblNhanVien)
						set @Max = CONVERT(float, SUBSTRING(@MaxMaNV,3,8)) + 1
			else
						set @Max=1	
			if (@Max < 10)
						set @MaNV='NV' + '0000000' + Convert(varchar(1),@Max)
			else
			if (@Max < 100)
						set @MaNV='NV' + '000000' + Convert(varchar(2),@Max)
			else
			if (@Max < 1000)
						set @MaNV='NV' + '00000' + Convert(varchar(3),@Max)
			else
			if (@Max < 10000)
						set @MaNV='NV' + '0000' + Convert(varchar(4),@Max)
			else
			if (@Max < 100000)
						set @MaNV ='NV' + '000' + Convert(varchar(5),@Max)
			else
			if (@Max < 1000000)
						set @MaNV  ='NV' + '00' + Convert(varchar(6),@Max)
			else	
			if (@Max < 10000000)
						set @MaNV ='NV' + '0' + Convert(varchar(7),@Max)
			else
						set @MaNV ='NV' +  Convert(varchar(8),@Max)
			Return @MaNV
end
SELECT dbo.fcgetMaNV();
delete from tblNhanVien
delete from tblTaiKhoan
create function fcgetMaKH()
returns varchar(10)
as
begin 
   declare @MaKH varchar(10)
   declare @MaxMaKH varchar(10)
   declare @Max float

   select @MaxMaKH=MAX(sMaKH) from tblKhachHang

   if exists (select sMaKH from tblKhachHang)
						set @Max = CONVERT(float, SUBSTRING(@MaxMaKH,3,8)) + 1
			else
						set @Max=1	
			if (@Max < 10)
						set @MaKH='KH' + '0000000' + Convert(varchar(1),@Max)
			else
			if (@Max < 100)
						set @MaKH='KH' + '000000' + Convert(varchar(2),@Max)
			else
			if (@Max < 1000)
						set @MaKH='KH' + '00000' + Convert(varchar(3),@Max)
			else
			if (@Max < 10000)
						set @MaKH='KH' + '0000' + Convert(varchar(4),@Max)
			else
			if (@Max < 100000)
						set @MaKH ='KH' + '000' + Convert(varchar(5),@Max)
			else
			if (@Max < 1000000)
						set @MaKH  ='KH' + '00' + Convert(varchar(6),@Max)
			else	
			if (@Max < 10000000)
						set @MaKH ='KH' + '0' + Convert(varchar(7),@Max)
			else
						set @MaKH ='KH' +  Convert(varchar(8),@Max)
			Return @MaKH
end
SELECT dbo.fcgetMaKH();
--Trigger tự động tạo tài khoản khi thêm nhân viên mới
alter trigger tudongthemtaikhoan
on tblNhanVien
for insert
as
begin
	declare @manv char(10) = (select sMaNV from inserted)
	declare @chucvu nvarchar(255) = (select sChucVu from inserted)
	if(@chucvu like N'Nhân viên' or @chucvu like N'Nhân Viên' or @chucvu like N'nhân Viên' or @chucvu like N'Nhân Viên' )
		insert into tblTaiKhoan values (@manv,'123456',0)
	if(@chucvu like N'Quản lý' or @chucvu like N'Quản Lý' or @chucvu like N'quản lý' or @chucvu like N'quản Lý' )
		insert into tblTaiKhoan values (@manv,'123456',1)
end
--tự động thêm hệ số lương tương đương với chức vụ

--Mấy cái  trigger tự động tính. 
--VD: tính tổng tiền hóa đơn có thể xử lý bên C#
-- tự động tính chỉ số loại 1, 2 , 3 ,4 có thể xử lý bên C# = TextChanged
--TRÊN LÀ CÁC HÀM MÌNH VIẾT VÍ DỤ, CÒN AI LÀM ĐẾN ĐÂU VIẾT THỦ TỤC(PROC) ĐẾN ĐÓ NHÉ. TƯƠNG TỰ TRÊN


-------------------------------------------STORED PROCEDURES LIÊN QUAN ĐẾN TBL_TAIKHOAN
create proc sp_taikhoan
@matk char(10)
as
begin
	
end
--ProC check đăng nhập
create proc sp_checkdangnhap
@tentaikhoan char(10),
@matkhau char(12)
as
begin
	select*from tblTaiKhoan 
	inner join tblNhanVien on tblNhanVien.sMaNV = tblTaiKhoan.sMaTK
	 where @tentaikhoan = sMaTK and @matkhau = sMatKhau and tblNhanVien.bTrangThai !=0 
end
select* from tblNhanVien
exec sp_checkdangnhap @tentaikhoan ='NV00000011', @matkhau = 'a'
--get taikhoan
create proc sp_gettaikhoan
@tentaikhoan char(10)
as
begin
	select * from tblTaiKhoan where sMaTK = @tentaikhoan
end
--
select* from tblss
--Proc đổi mật khẩu
create proc sp_doimatkhau
@matkhaumoi char(12),
@matk char(10)
as
begin
	update tblTaiKhoan
	set sMatKhau = @matkhaumoi
	where sMaTK = @matk
end

-------------------------------------------STORED PROCEDURES LIÊN QUAN ĐẾN TBL_NHANVIEN
-- procduce trên bảng tblNhanvien
alter proc sp_nhanvien
@manv char(10) = NULL,
@tennv nvarchar(255) = NULL,
@ngaysinh datetime = NULL,
@diachi nvarchar(255) = NULL,
@gioitinh nvarchar(5) = NULL,
@sdt char(11) = NULL,
@chucvu nvarchar(255) = NULL,
@hsl float = NULL,
@trangthai bit = NULL,
@action nvarchar(20) = NULL
as
begin
	if(@action = N'insert')
		begin
			insert into tblNhanVien
			values(dbo.fcgetMaNV(),@tennv,@ngaysinh,@diachi,@gioitinh,@sdt,@chucvu,@hsl,1)
		end
	if(@action = N'selectone')
		begin
			select * from tblNhanVien where sMaNV = @manv
		end
	if(@action = N'selectall')
		begin
			select * from tblNhanVien where bTrangThai = 1
			order by sMaNV DESC
		end
	if(@action = N'lock')
		begin
			update tblNhanVien 
			set bTrangThai = 0 
			where sMaNV = @manv
		end
	if(@action = N'update')
		begin
			update tblNhanVien 
			set sTenNV = @tennv, dNgaySinh = @ngaysinh , sDiaChi = @diachi , sGioiTinh = @gioitinh, sSDT = @sdt, sChucVu = @chucvu, fHSL = @hsl
			where sMaNV = @manv
		end
	if(@action = N'change')
		begin
			update tblNhanVien
			set sTenNV = @tennv, dNgaySinh = @ngaysinh , sDiaChi = @diachi , sGioiTinh = @gioitinh, sSDT = @sdt
			where sMaNV = @manv
		end
end
--Tìm kiếm sinh viên theo mã
create proc selectid 
@manv char(10)
as
begin
	select * from tblNhanVien 
	where sMaNV = @manv
end
select * from tblNhanVien
exec selectid @manv = 'NV00000001'
-------------------------------------------STORED PROCEDURES LIÊN QUAN ĐẾN TBL_KHACHHANG
-- procduce tblKhachHang
alter proc sp_khachhang
@makh char(10) = NULL,
@tenkh nvarchar(255) = NULL,
@ngaysinh datetime = NULL,
@diachi nvarchar(255) = NULL,
@gioitinh nvarchar(10) = NULL,
@sdt char(11) = NULL,
@macongto char(10) = NULL,
@trangthai bit = NULL,
@action nvarchar(20) = NULL
as
begin
	if(@action = 'selectall')
		begin
			select * from tblKhachHang where bTrangThai = 1
			order by sMaKH DESC
		end
	if(@action  = 'selectone')
		begin
			select * from tblKhachHang where sMaKH =  @makh
		end
	if(@action = 'insert')
		begin
			insert into  tblKhachHang
			values(dbo.fcgetMaKH(),@tenkh,@ngaysinh,@diachi,@gioitinh,@sdt,@macongto,1)
		end
	if(@action = 'lock')
		begin
			update tblKhachHang
			set bTrangThai = 0 where sMaKH = @makh
		end
	if(@action = 'update')
		begin
			update tblKhachHang 
			set sTenKH = @tenkh, dNgaySinh = @ngaysinh, sDiaChi = @diachi, sGioiTinh = @gioitinh, sSDT = @sdt, sMaCongTo = @macongto
			where sMaKH = @makh
		end
end
exec sp_khachhang @action = 'lock', @makh = 'KH00000004'
alter proc sp_insertKH
	@values nvarchar(900) = NULL
as 
	declare @query nvarchar(1000)
begin
	set @query = N'insert into tblKhachHang	values' + @values
	execute (@query)
end

-- Lấy mã mới của khach hàng
alter proc sp_mamoi
as
begin
	SELECT dbo.fcgetMaKH() as MaMoi
end
exec sp_mamoi
-- Lấy mã mới của nhân viên
create proc sp_mamoinhanvien
as
begin
	SELECT dbo.fcgetMaNV() as MaMoi
end
---
exec sp_mamoinhanvien
---
exec sp_khachhang @tenkh = N'Ngọc', @ngaysinh = '01/01/1999', @diachi = N'Dak lak',@gioitinh = 'Nam', @sdt = '0123456789' , @macongto = 'CT001', @action = 'insert', @trangthai = 1
--Tìm kiếm nhân viên theo tên
create proc sp_timkiemnhanvien
@data nvarchar(255)
as
begin
	select * from tblNhanVien
	where (sTenNV like '%'+@data+'%') and bTrangThai = 1
end
exec timkiemnhanvien @tennv = N'Hùng'
--Tìm kiếm Khách hàng theo tên.
alter proc timkiemkhachhang
@data nvarchar(255)
as
begin
	select * from tblKhachHang
	where (sTenKH like N'%'+@data+'%' or sMaKH like N'%'+@data+'%' or sDiaChi like N'%'+@data+'%' or sSDT like N'%'+@data+'%' or sMaCongTo like N'%'+@data+'%') and bTrangThai = 1
end

exec timkiemkhachhang @data = N'Ngọc'
select * from tblKhachHang where sTenKH like N'%Ngọc%'
-------------------------------------------STORED PROCEDURES LIÊN QUAN ĐẾN TBL_KHACHHANG
-------------------------------------------STORED PROCEDURES LIÊN QUAN ĐẾN TBL_HOADON
create function fcgetMaHD()
returns varchar(10)
as
begin 
   declare @MaHD varchar(10)
   declare @MaxMaHD varchar(10)
   declare @Max float

   select @MaxMaHD=MAX(sMaHD) from tblHoaDon

   if exists (select sMaHD from tblHoaDon)
						set @Max = CONVERT(float, SUBSTRING(@MaxMaHD,3,8)) + 1
			else
						set @Max=1	
			if (@Max < 10)
						set @MaHD='HD' + '0000000' + Convert(varchar(1),@Max)
			else
			if (@Max < 100)
						set @MaHD='HD' + '000000' + Convert(varchar(2),@Max)
			else
			if (@Max < 1000)
						set @MaHD='HD' + '00000' + Convert(varchar(3),@Max)
			else
			if (@Max < 10000)
						set @MaHD='HD' + '0000' + Convert(varchar(4),@Max)
			else
			if (@Max < 100000)
						set @MaHD ='HD' + '000' + Convert(varchar(5),@Max)
			else
			if (@Max < 1000000)
						set @MaHD  ='HD' + '00' + Convert(varchar(6),@Max)
			else	
			if (@Max < 10000000)
						set @MaHD ='HD' + '0' + Convert(varchar(7),@Max)
			else
						set @MaHD ='HD' +  Convert(varchar(8),@Max)
			Return @MaHD
end
SELECT dbo.fcgetMaHD();
-----------------------------------------
SELECT * FROM tblHoaDon
--Hóa đơn
alter proc sp_hoadon
@mahd char(10) = null,
@makh char(10) = null,
@manv char(10) = null,
@ngaylap date = null,
@tungay date = null,
@denngay date = null,
@chisocu float = null,
@chisomoi float = null,
@thuegtgt float = null,
@tongtien float = null,
@action varchar(10) = null
as
begin
	if(@action = N'insert')
		begin
			insert into tblHoaDon(sMaHD,sMaKH,sMaNV,dNgayLap,dTuNgay,dDenNgay,fChiSoCu,fChiSoMoi,fThueGTGT,fTongTien,bTrangThai)
			values(dbo.fcgetMaHD(),@makh,@manv,@ngaylap,@tungay,@denngay,@chisocu,@chisomoi,@thuegtgt,@tongtien,1)
		end
	if(@action = 'selectall')
		begin
			select sMaHD, tblNhanVien.sTenNV, tblKhachHang.sTenKH, dNgayLap, dTuNgay, dDenNgay, fChiSoCu, fChiSoMoi, fThueGTGT, tblHoaDon.bTrangThai, tblHoaDon.sMaKH, tblHoaDon.fTongTien
			from tblHoaDon, tblKhachHang, tblNhanVien
			where tblHoaDon.bTrangThai = 1 and 
			tblHoaDon.sMaKH = tblKhachHang.sMaKH and 
			tblHoaDon.sMaNV = tblNhanVien.sMaNV
			order by sMaHD DESC
		end
	if(@action = 'selectone')
		begin
			select * from tblHoaDon where sMaHD = @mahd
		end
	if(@action = 'update')
		begin
			update tblHoaDon
			set sMaNV = @manv, dNgayLap = @ngaylap, dTuNgay = @tungay, dDenNgay = @denngay, fChiSoCu = @chisocu, fChiSoMoi = @chisomoi, fThueGTGT = @thuegtgt, fTongTien = @tongtien
			where sMaHD = @mahd	
		end
	if(@action = 'lock')
		begin
			update tblHoaDon
			set bTrangThai = 0
			where sMaHD = @mahd
		end
	if(@action = 'unlock')
		begin
			update tblHoaDon
			set bTrangThai = 1
			where sMaHD = @mahd
		end
	if(@action = 'thongke')
		begin
			select sMaHD, tblNhanVien.sTenNV, tblKhachHang.sTenKH, dNgayLap, dTuNgay, dDenNgay, fChiSoCu, fChiSoMoi, fThueGTGT, tblHoaDon.bTrangThai, tblHoaDon.sMaKH, tblHoaDon.fTongTien
			from tblHoaDon, tblKhachHang, tblNhanVien
			where tblHoaDon.sMaKH = tblKhachHang.sMaKH and 
			tblHoaDon.sMaNV = tblNhanVien.sMaNV
			order by sMaHD DESC
		end
end
--lấy mã tiếp theo trong bảng tblHoaDon
create proc sp_mahd
as
begin
	select dbo.fcgetMaHD()
end
exec sp_mahd
--Lấy ra thuế của hóa đơn với mã truyền vào
create proc sp_getthue
@mahd char(10)
as
begin
	select fThueGTGT
	from tblHoaDon
	where sMaHD = @mahd
end
exec sp_getthue @mahd = 'HD00000001'
--Tìm kiếm hóa đơn
alter proc sp_timkiemhoadon
@data varchar(255)
as
begin
	select * from tblHoaDon
	where (sMaHD like	N'%'+@data+'%' 
	or	sMaNV like		N'%'+@data+'%' 
	or sMaKH like		N'%'+@data+'%' 
	or dNgayLap like	'%'+@data+'%' 
	or dTuNgay like		'%'+@data+'%' 
	or dDenNgay like	'%'+@data+'%') 
	and tblHoaDon.bTrangThai = 1
	order by sMaHD DESC
end
execute sp_timkiemhoadon 'HD00000009'
-----------------------------------------------------------PROC THỐNG KÊ
alter proc thongkenhanvien
as
begin
	select tblNhanVien.sMaNV, tblNhanVien.sTenNV, tblNhanVien.dNgaySinh, sDiaChi, sGioiTinh, sSDT, sChucVu, COUNT(tblHoaDon.sMaNV) as SoLuongHoaDon, tblNhanVien.bTrangThai
	from tblNhanVien
	left join tblHoaDon on tblNhanVien.sMaNV = tblHoaDon.sMaNV
	group by tblNhanVien.sMaNV, tblNhanVien.sTenNV, tblNhanVien.dNgaySinh, tblHoaDon.sMaNV, sDiaChi, sGioiTinh, sSDT, sChucVu, tblNhanVien.bTrangThai
	order by SoLuongHoaDon DESC
end
exec thongkenhanvien
--thống kê nhân viên
select *from tblNhanVien
alter proc sp_locnhanvien
@action nvarchar(255)
as
	declare @query nvarchar(1000)
begin
	set @query = N'select * from tblNhanVien where ' + @action
	execute(@query)
end
-----------------
alter proc sp_lockhachhang
@action nvarchar(255)
as
	declare @query nvarchar(1000)
begin
	set @query = N'select tblKhachHang.sMaKH, sTenKH, dNgaySinh, sDiaChi, sGioiTinh, sSDT, sMaCongTo, tblKhachHang.bTrangThai, sum(tblHoaDon.fChiSoMoi) as SoNuocDaDung
	from tblKhachHang
	left join tblHoaDon on tblKhachHang.sMaKH = tblHoaDon.sMaKH 
	group by tblKhachHang.sMaKH, sTenKH, dNgaySinh, sDiaChi, sGioiTinh, sSDT, sMaCongTo, tblKhachHang.bTrangThai 
	having ' + @action
	execute(@query)
end
exec sp_lockhachhang @action = '1=1'
exec sp_lockhachhang @action = 'sGioiTinh = N''Nam'''
-------------------
create proc sp_lockhachhang
as
begin
	
end
--@query = "sGioiTinh = 'Nam'"
-- query ben c# sẽ tương tự như trên
exec sp_locnhanvien @action = 'sGioiTinh = N''Nam'''
exec sp_locnhanvien @action = '1=1'
---TÌm kiếm thống kê hóa đơn
alter proc sp_timkiemthongkehoadon
@data varchar(255)
as
begin
	select sMaHD, sTenNV, sTenKH, dNgayLap, dTuNgay, dDenNgay, fChiSoCu, fChiSoMoi , fTongTien, fThueGTGT
	from tblHoaDon,tblNhanVien,tblKhachHang
	where (sMaHD like	N'%'+@data+'%' 
	or	sTenNV like		N'%'+@data+'%' 
	or sTenKH like		N'%'+@data+'%' 
	or dNgayLap like	'%'+@data+'%' 
	or dTuNgay like		'%'+@data+'%' 
	or dDenNgay like	'%'+@data+'%') 
	and tblKhachHang.sMaKH = tblHoaDon.sMaKH and tblHoaDon.sMaNV = tblNhanVien.sMaNV
	order by sMaHD DESC
end
--thống kê khách hàng
alter proc sp_thongkekhachhang
as
begin
	select tblKhachHang.sMaKH, sTenKH, dNgaySinh, sDiaChi, sGioiTinh, sSDT, sMaCongTo, tblKhachHang.bTrangThai, sum(tblHoaDon.fChiSoMoi) as SoNuocDaDung
	from tblKhachHang
	left join tblHoaDon on tblKhachHang.sMaKH = tblHoaDon.sMaKH
	group by tblKhachHang.sMaKH, sTenKH, dNgaySinh, sDiaChi, sGioiTinh, sSDT, sMaCongTo, tblKhachHang.bTrangThai
end
exec sp_thongkekhachhang
--thống kê hóa đơn
select *from tblHoaDon where dNgayLap >= '2019-04-17'
alter proc sp_lochoadon
@action nvarchar(255)
as
	declare @query nvarchar(1000)
begin
	set @query = N'select sMaHD, tblNhanVien.sTenNV, tblKhachHang.sTenKH, dNgayLap, dTuNgay, dDenNgay, fChiSoCu, fChiSoMoi, fThueGTGT, tblHoaDon.bTrangThai, tblHoaDon.sMaKH, tblHoaDon.fTongTien
			from tblHoaDon, tblKhachHang, tblNhanVien
			where tblHoaDon.sMaKH = tblKhachHang.sMaKH and 
			tblHoaDon.sMaNV = tblNhanVien.sMaNV and ' + @action
	execute(@query)
end


exec sp_lochoadon @action = 'dNgayLap >= ''2019-04-17'' and 1=1'
--------------------------------------------CRYSTAL REPORT
alter proc cr_danhsachnhanvien
as
begin
	select *from tblNhanVien
	where bTrangThai = 1
end
alter proc cr_danhsachkhachhang
as
begin
	select *from tblKhachHang
	where bTrangThai = 1
end
alter proc cr_danhsachhoadon
as
begin
	select sMaHD, sTenNV, sTenKH, dNgayLap, dTuNgay, dDenNgay, fChiSoCu, fChiSoMoi, fTongTien
	from tblHoaDon,tblNhanVien, tblKhachHang
	where tblHoaDon.bTrangThai = 1 and tblKhachHang.sMaKH = tblHoaDon.sMaKH and tblNhanVien.sMaNV = tblHoaDon.sMaNV
end

create proc cr_nhanvientheoma
@manv char(10)
as
begin
	select * from tblNhanVien
	where sMaNV = @manv
end
create proc cr_khachhangtheoma
@makh char(10)
as
begin
	select * from tblKhachHang
	where sMaKH = @makh
end
create proc cr_hoadontheoma
@mahd char(10)
as
begin
	select sMaHD, sTenNV, sTenKH, dNgayLap, dTuNgay, dDenNgay, fChiSoCu, fChiSoMoi, fTongTien
	from tblHoaDon,tblNhanVien, tblKhachHang
	where tblHoaDon.bTrangThai = 1 
	and tblKhachHang.sMaKH = tblHoaDon.sMaKH 
	and tblNhanVien.sMaNV = tblHoaDon.sMaNV 
	and sMaHD = @mahd
end
select * from tblHoaDon
exec cr_hoadontheoma  @mahd = 'HD00000004'