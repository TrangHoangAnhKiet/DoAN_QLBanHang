USE [master]
GO
/****** Object:  Database [QL_BanHangDienTu]    Script Date: 11/17/2024 4:01:13 PM ******/
CREATE DATABASE [QL_BanHangDienTu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_BanHangDienTu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QL_BanHangDienTu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QL_BanHangDienTu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QL_BanHangDienTu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QL_BanHangDienTu] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_BanHangDienTu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_BanHangDienTu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_BanHangDienTu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_BanHangDienTu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QL_BanHangDienTu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_BanHangDienTu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_BanHangDienTu] SET  MULTI_USER 
GO
ALTER DATABASE [QL_BanHangDienTu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_BanHangDienTu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_BanHangDienTu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_BanHangDienTu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QL_BanHangDienTu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QL_BanHangDienTu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QL_BanHangDienTu] SET QUERY_STORE = ON
GO
ALTER DATABASE [QL_BanHangDienTu] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QL_BanHangDienTu]
GO
/****** Object:  Table [dbo].[BaoCao]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCao](
	[MaBC] [nvarchar](50) NOT NULL,
	[LoaiBC] [nvarchar](100) NULL,
	[NoidungBC] [nvarchar](250) NULL,
	[NgayLapBC] [date] NULL,
 CONSTRAINT [PK__BaoCao__272475A638790236] PRIMARY KEY CLUSTERED 
(
	[MaBC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatHangSanPham]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatHangSanPham](
	[MaKH] [nvarchar](50) NOT NULL,
	[MaDH] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__DatHangS__25579778058FCC0A] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC,
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [nvarchar](50) NOT NULL,
	[TenDonHang] [nvarchar](50) NULL,
	[NgayDatHang] [date] NULL,
	[NgayXuatHang] [date] NULL,
	[TrangThaiDH] [nvarchar](255) NULL,
	[TongGiaTriDH] [decimal](10, 2) NULL,
	[MaKH] [nvarchar](50) NULL,
	[MaHoaDon] [nvarchar](50) NULL,
 CONSTRAINT [PK__DonHang__272586619435C7B9] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonThanhToan]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonThanhToan](
	[MaHoaDon] [nvarchar](50) NOT NULL,
	[NgayThanhToan] [date] NULL,
	[SoTienThanhToan] [decimal](10, 2) NULL,
	[PhuongThucThanhToan] [nvarchar](255) NULL,
	[MaDH] [int] NULL,
 CONSTRAINT [PK__HoaDonTh__835ED13BDF7DFF40] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KenhBanHang]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KenhBanHang](
	[MaKenh] [nvarchar](50) NOT NULL,
	[TenKenh] [nvarchar](255) NULL,
	[MoTaKenh] [text] NULL,
	[MaDH] [nvarchar](50) NULL,
 CONSTRAINT [PK__KenhBanH__65774D04B9B5CF88] PRIMARY KEY CLUSTERED 
(
	[MaKenh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [nvarchar](50) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[SoDienThoai] [varchar](15) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[ChuongTrinhKHTT] [varchar](255) NULL,
	[KhuyenMai] [varchar](255) NULL,
	[TaiKhoan] [nvarchar](100) NULL,
 CONSTRAINT [PK__KhachHan__2725CF1E143285B8] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoHang]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoHang](
	[MaKhoHang] [nvarchar](50) NOT NULL,
	[DiaChiKho] [nvarchar](255) NULL,
	[MaSP] [nvarchar](50) NULL,
	[MaNV] [nvarchar](50) NULL,
 CONSTRAINT [PK__KhoHang__C5B727D7B2E9F1F0] PRIMARY KEY CLUSTERED 
(
	[MaKhoHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MuaSanPham]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MuaSanPham](
	[MaKH] [nvarchar](50) NOT NULL,
	[MaSP] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__MuaSanPh__F5579F9F685273A6] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](50) NOT NULL,
	[TenNV] [nvarchar](255) NOT NULL,
	[NamSinh] [date] NULL,
	[GioiTinh] [nchar](255) NULL,
	[LoaiCongViec] [nchar](100) NULL,
	[HeSoLuong] [float] NULL,
	[MaDH] [varchar](50) NULL,
	[MaBC] [nvarchar](50) NULL,
	[MaHoaDon] [nvarchar](50) NULL,
	[TaiKhoan] [nvarchar](100) NULL,
 CONSTRAINT [PK__NhanVien__2725D70A0C8F8AB3] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanLySanPham]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLySanPham](
	[MaNV] [nvarchar](50) NOT NULL,
	[MaSP] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__QuanLySa__F557878B0848E207] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [nvarchar](50) NOT NULL,
	[TenSP] [nvarchar](255) NOT NULL,
	[Gia] [decimal](10, 2) NULL,
	[MoTa] [text] NULL,
	[ThongSoKT] [text] NULL,
	[TonKho] [int] NULL,
 CONSTRAINT [PK__SanPham__2725081C33611514] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenDangNhap] [nvarchar](100) NOT NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
	[LoaiTK] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XemKenh]    Script Date: 11/17/2024 4:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XemKenh](
	[MaKH] [nvarchar](50) NOT NULL,
	[MaSP] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__XemKenh__F5579F9FD6D69322] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BaoCao] ([MaBC], [LoaiBC], [NoidungBC], [NgayLapBC]) VALUES (N'BC01', N'baocao', N'baocaoaoao', CAST(N'2024-11-01' AS Date))
GO
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [LoaiTK]) VALUES (N'admin', N'123', N'Admin')
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [LoaiTK]) VALUES (N'John', N'456', NULL)
INSERT [dbo].[TaiKhoan] ([TenDangNhap], [MatKhau], [LoaiTK]) VALUES (N'user', N'123', NULL)
GO
ALTER TABLE [dbo].[DatHangSanPham]  WITH CHECK ADD  CONSTRAINT [FK__DatHangSan__MaDH__4D94879B] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO
ALTER TABLE [dbo].[DatHangSanPham] CHECK CONSTRAINT [FK__DatHangSan__MaDH__4D94879B]
GO
ALTER TABLE [dbo].[DatHangSanPham]  WITH CHECK ADD  CONSTRAINT [FK__DatHangSan__MaKH__4CA06362] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[DatHangSanPham] CHECK CONSTRAINT [FK__DatHangSan__MaKH__4CA06362]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK__DonHang__MaHoaDo__3E52440B] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDonThanhToan] ([MaHoaDon])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK__DonHang__MaHoaDo__3E52440B]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK__DonHang__MaKH__3D5E1FD2] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK__DonHang__MaKH__3D5E1FD2]
GO
ALTER TABLE [dbo].[KenhBanHang]  WITH CHECK ADD  CONSTRAINT [FK__KenhBanHan__MaDH__49C3F6B7] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO
ALTER TABLE [dbo].[KenhBanHang] CHECK CONSTRAINT [FK__KenhBanHan__MaDH__49C3F6B7]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_TaiKhoan] FOREIGN KEY([TaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([TenDangNhap])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_TaiKhoan]
GO
ALTER TABLE [dbo].[KhoHang]  WITH CHECK ADD  CONSTRAINT [FK__KhoHang__MaNV__46E78A0C] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[KhoHang] CHECK CONSTRAINT [FK__KhoHang__MaNV__46E78A0C]
GO
ALTER TABLE [dbo].[KhoHang]  WITH CHECK ADD  CONSTRAINT [FK__KhoHang__MaSP__45F365D3] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[KhoHang] CHECK CONSTRAINT [FK__KhoHang__MaSP__45F365D3]
GO
ALTER TABLE [dbo].[MuaSanPham]  WITH CHECK ADD  CONSTRAINT [FK__MuaSanPham__MaKH__5812160E] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[MuaSanPham] CHECK CONSTRAINT [FK__MuaSanPham__MaKH__5812160E]
GO
ALTER TABLE [dbo].[MuaSanPham]  WITH CHECK ADD  CONSTRAINT [FK__MuaSanPham__MaSP__59063A47] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[MuaSanPham] CHECK CONSTRAINT [FK__MuaSanPham__MaSP__59063A47]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_BaoCao] FOREIGN KEY([MaBC])
REFERENCES [dbo].[BaoCao] ([MaBC])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_BaoCao]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_HoaDonThanhToan] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDonThanhToan] ([MaHoaDon])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_HoaDonThanhToan]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_TaiKhoan] FOREIGN KEY([TaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([TenDangNhap])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_TaiKhoan]
GO
ALTER TABLE [dbo].[QuanLySanPham]  WITH CHECK ADD  CONSTRAINT [FK__QuanLySanP__MaNV__5070F446] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[QuanLySanPham] CHECK CONSTRAINT [FK__QuanLySanP__MaNV__5070F446]
GO
ALTER TABLE [dbo].[QuanLySanPham]  WITH CHECK ADD  CONSTRAINT [FK__QuanLySanP__MaSP__5165187F] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[QuanLySanPham] CHECK CONSTRAINT [FK__QuanLySanP__MaSP__5165187F]
GO
ALTER TABLE [dbo].[XemKenh]  WITH CHECK ADD  CONSTRAINT [FK__XemKenh__MaKH__5441852A] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[XemKenh] CHECK CONSTRAINT [FK__XemKenh__MaKH__5441852A]
GO
ALTER TABLE [dbo].[XemKenh]  WITH CHECK ADD  CONSTRAINT [FK__XemKenh__MaSP__5535A963] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[XemKenh] CHECK CONSTRAINT [FK__XemKenh__MaSP__5535A963]
GO
USE [master]
GO
ALTER DATABASE [QL_BanHangDienTu] SET  READ_WRITE 
GO
