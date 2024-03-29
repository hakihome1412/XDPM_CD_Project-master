USE [QLCD]
GO
/****** Object:  Table [dbo].[ChiTietPhieuDat]    Script Date: 10/31/2019 2:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuDat](
	[IdChiTietPhieuDat] [int] IDENTITY(1,1) NOT NULL,
	[IdTieuDe] [nvarchar](50) NULL,
	[TenTieuDe] [nvarchar](50) NULL,
	[NgayXuLyDonDat] [datetime] NULL,
	[IdPhieuDat] [int] NULL
PRIMARY KEY CLUSTERED 
(
	[IdChiTietPhieuDat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietPhieuThue]    Script Date: 10/31/2019 2:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuThue](
	[IdChiTietPhieuThue] [int] IDENTITY(1,1) NOT NULL,
	[IdDia] [nvarchar](50) NULL,
	[NgayTraDiaDuKien] [datetime] NULL,
	[PhiThue] [decimal](18, 2) NULL,
	[NgayTraDiaThucTe] [datetime] NULL,
	[PhiTre] [decimal](18, 2) NULL,
	[TrangThaiNoPhiTre] [bit] NULL,
	[TrangThaiTraPhiTre] [bit] NULL,
	[IdPhieuThue] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdChiTietPhieuThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 10/31/2019 2:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[IdDanhMuc] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](50) NULL,
	[TrangThaiXoa] [bit] NULL,
	[PhiThue] [decimal](18, 2) NULL,
	[PhiTreHan] [decimal](18, 2) NULL,
	[SoNgayThue] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dia]    Script Date: 10/31/2019 2:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dia](
	[IdDia] [nvarchar](50) NOT NULL,
	[TrangThaiThue] [nvarchar](50) NULL,
	[TrangThaiXoa] [bit] NULL,
	[IdTieuDe] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 10/31/2019 2:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[IdKhachHang] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[TrangThaiXoa] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/31/2019 2:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[IdNhanVien] [nvarchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuDat]    Script Date: 10/31/2019 2:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuDat](
	[IdPhieuDat] [int] IDENTITY(1,1) NOT NULL,
	[NgayTao] [datetime] NULL,
	[IdKhachHang] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPhieuDat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuThue]    Script Date: 10/31/2019 2:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuThue](
	[IdPhieuThue] [int] NOT NULL,
	[NgayTao] [datetime] NULL,
	[TongPhiThue] [decimal](18, 2) NULL,
	[IdKhachHang] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPhieuThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 10/31/2019 2:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[IdTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TenTaiKhoan] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[IdNhanVien] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TieuDe]    Script Date: 10/31/2019 2:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TieuDe](
	[IdTieuDe] [nvarchar](50) NOT NULL,
	[TenTieuDe] [nvarchar](50) NULL,
	[SoLuongDia] [int] NULL,
	[SoLuongDiaCoSan] [int] NULL,
	[TrangThaiXoa] [bit] NULL,
	[IdDanhMuc] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTieuDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ChiTietPhieuDat]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuDat_PhieuDat] FOREIGN KEY([IdPhieuDat])
REFERENCES [dbo].[PhieuDat] ([IdPhieuDat])
GO
ALTER TABLE [dbo].[ChiTietPhieuDat] CHECK CONSTRAINT [FK_ChiTietPhieuDat_PhieuDat]
GO
ALTER TABLE [dbo].[ChiTietPhieuDat]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuDat_TieuDe] FOREIGN KEY([IdTieuDe])
REFERENCES [dbo].[TieuDe] ([IdTieuDe])
GO
ALTER TABLE [dbo].[ChiTietPhieuDat] CHECK CONSTRAINT [FK_ChiTietPhieuDat_TieuDe]
GO
ALTER TABLE [dbo].[ChiTietPhieuThue]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuThue_Dia] FOREIGN KEY([IdDia])
REFERENCES [dbo].[Dia] ([IdDia])
GO
ALTER TABLE [dbo].[ChiTietPhieuThue] CHECK CONSTRAINT [FK_ChiTietPhieuThue_Dia]
GO
ALTER TABLE [dbo].[ChiTietPhieuThue]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuThue_PhieuThue] FOREIGN KEY([IdPhieuThue])
REFERENCES [dbo].[PhieuThue] ([IdPhieuThue])
GO
ALTER TABLE [dbo].[ChiTietPhieuThue] CHECK CONSTRAINT [FK_ChiTietPhieuThue_PhieuThue]
GO
ALTER TABLE [dbo].[Dia]  WITH CHECK ADD  CONSTRAINT [FK_Dia_TieuDe] FOREIGN KEY([IdTieuDe])
REFERENCES [dbo].[TieuDe] ([IdTieuDe])
GO
ALTER TABLE [dbo].[Dia] CHECK CONSTRAINT [FK_Dia_TieuDe]
GO
ALTER TABLE [dbo].[PhieuDat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDat_KhachHang] FOREIGN KEY([IdKhachHang])
REFERENCES [dbo].[KhachHang] ([IdKhachHang])
GO
ALTER TABLE [dbo].[PhieuDat] CHECK CONSTRAINT [FK_PhieuDat_KhachHang]
GO
ALTER TABLE [dbo].[PhieuThue]  WITH CHECK ADD  CONSTRAINT [FK_PhieuThue_KhachHang] FOREIGN KEY([IdKhachHang])
REFERENCES [dbo].[KhachHang] ([IdKhachHang])
GO
ALTER TABLE [dbo].[PhieuThue] CHECK CONSTRAINT [FK_PhieuThue_KhachHang]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([IdNhanVien])
REFERENCES [dbo].[NhanVien] ([IdNhanVien])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
ALTER TABLE [dbo].[TieuDe]  WITH CHECK ADD  CONSTRAINT [FK_TieuDe_DanhMuc] FOREIGN KEY([IdDanhMuc])
REFERENCES [dbo].[DanhMuc] ([IdDanhMuc])
GO
ALTER TABLE [dbo].[TieuDe] CHECK CONSTRAINT [FK_TieuDe_DanhMuc]
GO


insert into DanhMuc values('DVD',0,3,2,5);
insert into DanhMuc values('Game',0,4,3,6);

insert into TieuDe values('TD00000001',N'Titanic',3,3,0,1);
insert into TieuDe values('TD00000002',N'English for today 1',3,3,0,1);
insert into TieuDe values('TD00000003',N'English for today 2',3,3,0,1);
insert into TieuDe values('TD00000004',N'Dota2',3,3,0,2);
insert into TieuDe values('TD00000005',N'Assasin Creed 1',3,3,0,2);
insert into TieuDe values('TD00000006',N'Assasin Creed 2',3,3,0,2);
insert into TieuDe values('TD00000007',N'Life of Pi',3,3,0,1);

insert into Dia values('CD00000001','cosan',0,'TD00000001');
insert into Dia values('CD00000002','cosan',0,'TD00000001');
insert into Dia values('CD00000003','cosan',0,'TD00000001');
insert into Dia values('CD00000004','cosan',0,'TD00000002');
insert into Dia values('CD00000005','cosan',0,'TD00000002');
insert into Dia values('CD00000006','cosan',0,'TD00000002');
insert into Dia values('CD00000007','cosan',0,'TD00000003');
insert into Dia values('CD00000008','cosan',0,'TD00000003');
insert into Dia values('CD00000009','cosan',0,'TD00000003');
insert into Dia values('CD00000010','cosan',0,'TD00000004');
insert into Dia values('CD00000011','cosan',0,'TD00000004');
insert into Dia values('CD00000012','cosan',0,'TD00000004');
insert into Dia values('CD00000013','cosan',0,'TD00000005');
insert into Dia values('CD00000014','cosan',0,'TD00000005');
insert into Dia values('CD00000015','cosan',0,'TD00000005');
insert into Dia values('CD00000016','cosan',0,'TD00000006');
insert into Dia values('CD00000017','cosan',0,'TD00000006');
insert into Dia values('CD00000018','cosan',0,'TD00000006');
insert into Dia values('CD00000019','cosan',0,'TD00000007');
insert into Dia values('CD00000020','cosan',0,'TD00000007');
insert into Dia values('CD00000021','cosan',0,'TD00000007');

insert into NhanVien values('NV000001',N'Huỳnh Phúc Huy',N'4 đường số 2 phường 10 quận Tân Bình TP.HCM','0932774940');
insert into NhanVien values('NV000002',N'Nguyễn Hồng Quang',N'34 đường 3 tháng 2 phường 10 quận 3 TP.HCM','0978829989');
insert into NhanVien values('NV000003',N'Huỳnh Anh Khang',N'33 đường Hoàng Hoa Thám phường 10 quận Tân Bình TP.HCM','0908763778');
insert into NhanVien values('NV000004',N'Lâm Hồng Huy',N'44 Đề Thám phường 6 quận 1 TP.HCM','0988930009');
insert into NhanVien values('NV000005',N'Bùi Đức Tâm',N'398 Trường Chinh phường 14 quận Tân Bình TP.HCM TP.HCM','0922667385');

insert into KhachHang values('KH00000001',N'Nguyễn Đức Thịnh',N'456 Bàn Cờ phường 4 quận 3 TP.HCM','0988376647',0);
insert into KhachHang values('KH00000002',N'Nguyễn Thiên Ân',N'56 Âu Cơ phường 10 quận Tân Bình TP.HCM','0938889388',0);
insert into KhachHang values('KH00000003',N'Trần Minh Giàu',N'78 Thành Thái phường 7 quận 10 TP.HCM','0994887490',0);
insert into KhachHang values('KH00000004',N'Trần Trung Hào',N'22 Lê Lợi phường 4 quận Gò Vấp TP.HCM','0948337899',0);

insert into TaiKhoan values('NV000001','123','NV000001');
insert into TaiKhoan values('NV000002','123','NV000002');
insert into TaiKhoan values('NV000003','123','NV000003');




