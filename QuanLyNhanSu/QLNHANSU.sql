create database QLNhansu1
go
use QLNhanSu1
go 

CREATE TABLE Account(
	UserName	nvarchar(100)	not null PRIMARY KEY ,
	DisplayName nvarchar(100)	not null DEFAULT N'Si',
	Password	nvarchar(1000)	not null DEFAULT '1962026656160185351301320480154111117132155' ,
	Type		int				not null DEFAULT 0 --0 ADMIN && 3: STAFF
)

create table BoPhan
(
	MaBP	varchar(20) primary key not null,
	TenBP	Nvarchar(150)			not null,
	NgayTL	date,
	GhiChu	nvarchar(500) 
)

create table PhongBan
(
	MaPhong		varchar(20) primary key not null ,
	MaBP		varchar(20) REFERENCES BoPhan(MaBP) not null,
	tenBP		Nvarchar(150)	not null,
	TenPhong	Nvarchar(50)	not null,
	DiaChi		Nvarchar(150) ,
)

create table NhanVien
(
	MaNV		Varchar(20) PRIMARY KEY not null,
	TenNV		Nvarchar(50)	not null,
	GioiTinh	nvarchar(20)	not null,
	NgaySinh	varchar(20)		not null,
	QueQuan		nvarchar(200)	not null,
	SDT			int				null,
	DiaChi		nvarchar(200)	null,
	Cmnd		int				null,
	Email		varchar(50)		null,
	TenTDHV		nvarchar(100)	null,
	CNganh		nvarchar(100)	null,
	ChucVu	    nvarchar(200)	null,
	TinhTrang	nvarchar(200)	null,
	NgayVaoLam	varchar(20)		null,
	UserName	nvarchar(100) REFERENCES Account(UserName) not null,
	MaPhong		varchar(20) REFERENCES PhongBan(MaPhong) not null,
	MaBP		varchar(20) REFERENCES BoPhan(MaBP) not null,
)

create table ChamCong
(
	MaCC		INT IDENTITY PRIMARY KEY not null,
	UserName	nvarchar(100) REFERENCES Account(UserName) not null,
	MaNV		varchar(20) REFERENCES NhanVien(MaNV) ON DELETE CASCADE not null,
	TenNV		Nvarchar(50)	not null,
	NgayCham	varchar(250)        null,
	GioVao		varchar(250)		null,
	StatusIn	varchar(20)	        null,	
	GioRa		varchar(250) 	    null,
	StatusOut	varchar(20)	        null,
	DiTre		Nvarchar(20)	    null,
)


create table Luong
(
	MaLuong		INT IDENTITY PRIMARY KEY not null,
	TenNV		Nvarchar(50)	not null,
	LuongCB		float			null,
	ChucVu		nvarchar(200)	null,
	MaNV		varchar(20) REFERENCES NhanVien(MaNV) ON DELETE CASCADE not null,
)


create table DSBaoHiem
(
	MaBH		INT IDENTITY PRIMARY KEY not null,
	MaNV		Varchar(20) REFERENCES NhanVien(MaNV)	ON DELETE CASCADE not null,
	TenNV		Nvarchar(50)							not null,
	LoaiBH		Nvarchar(50)	 null,
	MaTheBH		varchar(20)		 null,
	NgayCap		varchar(20),
	NgayHetHan	varchar(20),
	NoiCap		nvarchar(100),
	PhiBaoHiem	float			NULL,
)

create table DSKhenThuong
(
	MaThuong	INT IDENTITY PRIMARY KEY				not null,
	MaNV		Varchar(20) REFERENCES NhanVien(MaNV)	ON DELETE CASCADE not null,
	TenNV		Nvarchar(50)							not null,
	NgayThuong	varchar(20)			 null,
	LyDo		nvarchar(300),
	HinhThuc	nvarchar(300),
	TienThuong	float
)

create table DSKyLuat
(
	MaKyLuat	INT IDENTITY PRIMARY KEY				not null,
	MaNV		Varchar(20) REFERENCES NhanVien(MaNV)	ON DELETE CASCADE not null,
	TenNV		Nvarchar(50)							not null,
	NgayKyLuat	varchar(20)			 null,
	LyDo		nvarchar(300),
	HinhThuc	nvarchar(300),
	TienPhat	float
)
create table DSThaiSan
(
	MaThaiSan	INT IDENTITY PRIMARY KEY				not null,
	MaNV		Varchar(20) REFERENCES NhanVien(MaNV)	ON DELETE CASCADE not null,
	TenNV		Nvarchar(50)							not null,
	NgayBatDau	varchar(20)			 null,
	NgayKetThuc	varchar(20)			 null,
	TrangThai	nvarchar(300)
)
create table HopDong
(
	MaHD		varchar(20) primary key not null,
	MaNV		varchar(20) REFERENCES NhanVien(MaNV)  ON DELETE CASCADE not null,
	TenNV		Nvarchar(50)	not null,
	MaBP		varchar(20)		not null,
	tenBP		Nvarchar(150)	not null,
	MaPhong		varchar(20)		not null,
	TenPhong	Nvarchar(50)	not null,
	LoaiHD		nvarchar(150)	not null,
	NgayBD		varchar(20)		not null,
	NgayKT		varchar(20)		not null
)
create table TongLuong
(	
	MaTongLuong		INT IDENTITY PRIMARY KEY NOT NULL,	
	MaNV			Varchar(20) REFERENCES NhanVien(MaNV)	ON DELETE CASCADE not null,
	TenNV			Nvarchar(50)		NOT NULL,
	TuNgay			varchar(20)			null,
	DenNgay			varchar(20)			null,
	SoNgayCong		int					null,
	LuongCB			float				null,
	TongPhiBH		float				NULL,
	TongTienThuong	float				NULL,
	TongTienPhat	float				NULL,
	TongLuong		float				NULL
)
------------------Insert DATA--------------------------------
insert into Account values ('admin', N'Người Quản Lý', '1962026656160185351301320480154111117132155', 0)
insert into Account values ('staff', N'Nhân Viên', '1962026656160185351301320480154111117132155', 3)
insert into BoPhan values ('BP001', N'Kỹ thuật', '3/3/2021', N'')
insert into BoPhan values ('BP002', N'Công nghệ', '3/2/2020', N'')
insert into BoPhan values ('BP003', N'Kiểm toán', '3/2/2020', N'')
insert into BoPhan values ('BP004', N'Hành chính', '3/2/2020', N'')
insert into BoPhan values ('BP005', N'Nhân sự', '3/2/2020', N'')
insert into BoPhan values ('BP006', N'Chăm sóc Khách hàng', '3/2/2020', N'')
insert into PhongBan values ('PB01', 'BP001', N'Kỹ thuật', N'Phần Mềm', N'Tôn Đức Thắng')
insert into PhongBan values ('PB02', 'BP002', N'Công nghệ', N'Sinh Học', N'Nguyễn Tất Thành')
insert into PhongBan values ('PB03', 'BP003', N'Kiểm toán', N'Kiểm toán', N'Nguyễn Tất Thành')
insert into PhongBan values ('PB04', 'BP004', N'Hành chính', N'Hành chính', N'Tôn Đức Thắng')
insert into PhongBan values ('PB05', 'BP005', N'Nhân sự', N'Nhân sự', N'Tôn Đức Thắng')
insert into PhongBan values ('PB06', 'BP006', N'Chăm sóc Khách hàng', N'Chăm sóc Khách hàng', N'Tôn Đức Thắng')

------------------Thủ tục login Account vào CSDL---------------------
go
create proc sp_LogintAccount
	@username varchar(100),
	@password varchar(1000)
as	
begin
	 select * from Account where UserName=@username and Password=@password
end
------------------Thủ tục thay doi mat khau Account vào CSDL---------------------
go
create proc sp_ChangeAccount
	@username nvarchar(100),
	@displayname nvarchar(100),
	@password nvarchar(1000),
	@newpassword nvarchar(1000)
as
begin
	declare @isRightPass INT = 0
	select @isRightPass=COUNT(*) From Account where UserName=@username and Password=@password
	if(@isRightPass > 0)
	begin
		if(@newpassword = '')
		begin
			update Account Set DisplayName=@displayname where UserName=@username
		end
		else
			update Account Set DisplayName=@displayname, Password=@newpassword where UserName=@username
	end
end

------------------Thủ tục kiểm tra bảo hiểm đã quá hạn hoặc thông tin không hợp lệ---------------------
go
create proc sp_CheckBaoHiemIsExists 
	@manv		varchar(20),
	@loaibh		nvarchar(50),
	@tungay		varchar(20),
	@denngay	varchar(20)
as
begin
	select * from DSBaoHiem where MaNV = @manv and LoaiBH = @loaibh and 
					(NgayHetHan between DATEADD(day, 0, @tungay+ ' 00:00:00') and @denngay
					or @denngay < NgayHetHan)
end
------------------------------Thủ tục kiểm tra chấm công theo ngày----------------------------
go
create proc sp_CheckChamCongExists 
	@manv		varchar(20),
	@ngaycham		varchar(20)
as
begin
	select * from ChamCong where MaNV = @manv and NgayCham=@ngaycham
end
------------------------------Thủ tục lọc chấm công theo MaBP theo ngày----------------------------
go
create proc RP_ChamCongByMaBP
	@mabp	varchar(20),
	@tungay varchar(20),
	@denngay varchar(20)
as
begin
	select cc.* 
	from	ChamCong cc, NhanVien nv, BoPhan bp
	where	cc.MaNV = nv.MaNV and
			nv.MaBP = bp.MaBP and
			bp.MaBP = @mabp and 
			NgayCham between DATEADD(day, 0, @tungay+ ' 00:00:00') and @denngay
end
-------------------------------Thủ tục lọc nhân viên theo Bộ Phận----------------------------------
go
create proc RP_NhanVienbyMaBP
	@mabp	varchar(20)
as
begin
	select nv.*
	from NhanVien nv, BoPhan bp
	where	nv.MaBP = bp.MaBP and
			bp.MaBP = @mabp 		
end
-------------------------------Thủ tục lọc nhân viên chấm công đi trễ giờ----------------------------------
go
create proc RP_NhanVienDiTre
	@manv varchar(20),
	@ngaybatdau varchar(20),
	@ngayketthuc varchar(20)
as
begin 
	select MaNV,TenNV,NgayCham,GioVao,DiTre 
	from ChamCong
	where MaNV=@manv and DiTre=N'Trễ giờ làm' and
		NgayCham between @ngaybatdau and @ngayketthuc
end
-------------------------------Thủ tục lọc nhân viên chấm công làm thêm giờ----------------------------------
go
create proc RP_ThemGio
	@ngaybatdau varchar(20),
	@ngayketthuc varchar(20)
as
begin
	select cc.*, DATEDIFF(MINUTE,'17:00', cc.GioRa) as GioLamThem
	from ChamCong cc
	where  cc.GioRa>'17:30' and cc.GioRa<'24:00' and NgayCham between @ngaybatdau and @ngayketthuc
end
------------------------------Thủ tục lọc thâm niên-------------------------------------------
go
create proc RP_ThamNien
	@ngaybatdau varchar(20),
	@ngayketthuc varchar(20)
as
begin
	select nv.*, DATEDIFF(year, nv.NgayVaoLam,Getdate()) as ThamNien
	from NhanVien nv
end
-------------------------------Thủ tục lọc theo hợp đồng sắp hết hạn ----------------------------------
go
create proc RP_HopDong
	
	@ngaybatdau varchar(20),
	@ngayketthuc varchar(20)
as
begin 
	select hd.*
	from HopDong hd
	where NgayKT between @ngaybatdau and @ngayketthuc
end
exec RP_HopDong '12/01/2021','12/09/2021'
--------------------------------------------------------------
-------------------------------TEST------------------------------
--------------------------------------------------------------




