USE [master]
GO
/****** Object:  Database [NHDK_final]    Script Date: 18/06/2025 15:31:23 ******/
CREATE DATABASE [NHDK_final]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NHDK_final', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NHDK_final.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NHDK_final_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NHDK_final_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NHDK_final] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NHDK_final].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NHDK_final] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NHDK_final] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NHDK_final] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NHDK_final] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NHDK_final] SET ARITHABORT OFF 
GO
ALTER DATABASE [NHDK_final] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NHDK_final] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NHDK_final] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NHDK_final] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NHDK_final] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NHDK_final] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NHDK_final] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NHDK_final] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NHDK_final] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NHDK_final] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NHDK_final] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NHDK_final] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NHDK_final] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NHDK_final] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NHDK_final] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NHDK_final] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NHDK_final] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NHDK_final] SET RECOVERY FULL 
GO
ALTER DATABASE [NHDK_final] SET  MULTI_USER 
GO
ALTER DATABASE [NHDK_final] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NHDK_final] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NHDK_final] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NHDK_final] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NHDK_final] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NHDK_final] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NHDK_final', N'ON'
GO
ALTER DATABASE [NHDK_final] SET QUERY_STORE = ON
GO
ALTER DATABASE [NHDK_final] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NHDK_final]
GO
/****** Object:  Table [dbo].[BanAn]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BanAn](
	[MaBan] [int] IDENTITY(1,1) NOT NULL,
	[SoGhe] [int] NULL,
	[TrangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CaLamViec]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaLamViec](
	[MaCa] [int] IDENTITY(1,1) NOT NULL,
	[TenCa] [nvarchar](50) NULL,
	[GioBatDau] [time](7) NULL,
	[GioKetThuc] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDonBan]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonBan](
	[MaHDB] [int] NOT NULL,
	[MaDichVu] [int] NOT NULL,
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC,
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDonNhap]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDonNhap](
	[MaHDN] [int] NOT NULL,
	[MaNL] [int] NOT NULL,
	[SoLuongNhap] [int] NULL,
	[DonGiaNhap] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC,
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [int] IDENTITY(1,1) NOT NULL,
	[TenChucVu] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDichVu] [int] IDENTITY(1,1) NOT NULL,
	[TenDichVu] [nvarchar](100) NULL,
	[DonGia] [int] NULL,
	[DonViTinh] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonBan]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBan](
	[MaHDB] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NULL,
	[MaBan] [int] NULL,
	[ThoiGian] [datetime] NULL,
	[MaKM] [int] NULL,
	[TongTien] [int] NULL,
	[HinhThucThanhToan] [nvarchar](50) NULL,
	[TrangThai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhap](
	[MaHDN] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NULL,
	[MaNCC] [int] NULL,
	[NgayNhap] [date] NULL,
	[TongTien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachCho]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachCho](
	[MaKH] [bigint] NOT NULL,
	[TenKH] [nvarchar](100) NULL,
	[SDT] [varchar](15) NULL,
	[SoNguoi] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[MaKM] [int] IDENTITY(1,1) NOT NULL,
	[TenKM] [nvarchar](100) NULL,
	[PhanTramGiam] [int] NULL,
	[DieuKien] [nvarchar](200) NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguyenLieu]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguyenLieu](
	[MaNL] [int] IDENTITY(1,1) NOT NULL,
	[TenNL] [nvarchar](100) NULL,
	[DonViTinh] [nvarchar](20) NULL,
	[SoLuongTon] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](100) NULL,
	[SDT] [varchar](15) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[Email] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](100) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [nvarchar](100) NULL,
	[SDT] [nvarchar](20) NULL,
	[MaChucVu] [int] NULL,
	[Luong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong](
	[MaNhanVien] [int] NOT NULL,
	[MaCa] [int] NOT NULL,
	[NgayLamViec] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[MaCa] ASC,
	[NgayLamViec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 18/06/2025 15:31:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien] [int] NULL,
	[TenDangNhap] [varchar](50) NULL,
	[MatKhau] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BanAn] ON 

INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (1, 4, 1)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (2, 6, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (3, 2, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (5, 2, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (6, 2, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (7, 2, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (8, 2, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (9, 4, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (10, 4, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (11, 4, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (12, 4, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (13, 4, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (14, 6, 0)
INSERT [dbo].[BanAn] ([MaBan], [SoGhe], [TrangThai]) VALUES (15, 6, 0)
SET IDENTITY_INSERT [dbo].[BanAn] OFF
GO
SET IDENTITY_INSERT [dbo].[CaLamViec] ON 

INSERT [dbo].[CaLamViec] ([MaCa], [TenCa], [GioBatDau], [GioKetThuc]) VALUES (1, N'Ca sáng', CAST(N'07:00:00' AS Time), CAST(N'13:00:00' AS Time))
INSERT [dbo].[CaLamViec] ([MaCa], [TenCa], [GioBatDau], [GioKetThuc]) VALUES (2, N'Ca chiều', CAST(N'13:00:00' AS Time), CAST(N'19:00:00' AS Time))
INSERT [dbo].[CaLamViec] ([MaCa], [TenCa], [GioBatDau], [GioKetThuc]) VALUES (3, N'Ca tối', CAST(N'19:00:00' AS Time), CAST(N'23:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[CaLamViec] OFF
GO
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (12, 1, 2)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (12, 2, 3)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (12, 3, 2)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (13, 1, 6)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (14, 1, 3)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (15, 1, 2)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (16, 1, 1)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (20, 1, 2)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (21, 1, 2)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (22, 1, 2)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (23, 1, 2)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (24, 1, 2)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (25, 1, 2)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (26, 2, 3)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (27, 2, 3)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (28, 3, 4)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (29, 1, 2)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (30, 1, 3)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (31, 1, 3)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (32, 1, 6)
INSERT [dbo].[ChiTietHoaDonBan] ([MaHDB], [MaDichVu], [SoLuong]) VALUES (33, 1, 2)
GO
INSERT [dbo].[ChiTietHoaDonNhap] ([MaHDN], [MaNL], [SoLuongNhap], [DonGiaNhap]) VALUES (1, 1, 10, 200000)
INSERT [dbo].[ChiTietHoaDonNhap] ([MaHDN], [MaNL], [SoLuongNhap], [DonGiaNhap]) VALUES (1, 2, 5, 30000)
INSERT [dbo].[ChiTietHoaDonNhap] ([MaHDN], [MaNL], [SoLuongNhap], [DonGiaNhap]) VALUES (1, 3, 50, 100000)
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (1, N'Quản lý')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (2, N'Nhân viên phục vụ')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (3, N'Đầu bếp')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (4, N'Thu ngân')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (5, N'Thủ kho')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
SET IDENTITY_INSERT [dbo].[DichVu] ON 

INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonGia], [DonViTinh]) VALUES (1, N'Buffet Người lớn', 139000, N'Suất')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonGia], [DonViTinh]) VALUES (2, N'Buffet Trẻ em', 79000, N'Suất')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonGia], [DonViTinh]) VALUES (3, N'Pizza', 150000, N'Phần')
SET IDENTITY_INSERT [dbo].[DichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonBan] ON 

INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (9, 4, 1, CAST(N'2025-06-04T16:35:39.097' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (10, 4, 1, CAST(N'2025-06-04T16:38:12.070' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (11, 4, 2, CAST(N'2025-06-04T16:40:07.617' AS DateTime), NULL, NULL, NULL, 0)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (12, 4, 1, CAST(N'2025-06-04T16:40:16.340' AS DateTime), NULL, 880200, N'Tiền mặt', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (13, 4, 2, CAST(N'2025-06-04T16:52:58.670' AS DateTime), NULL, 900720, N'Mobile Banking', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (14, 4, 1, CAST(N'2025-06-04T22:23:04.237' AS DateTime), NULL, 450360, N'Tiền mặt', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (15, 4, 1, CAST(N'2025-06-05T01:40:21.383' AS DateTime), NULL, 300240, N'Tiền mặt', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (16, 4, 2, CAST(N'2025-06-05T01:42:20.483' AS DateTime), NULL, 150120, N'Tiền mặt', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (17, 4, 2, CAST(N'2025-06-05T01:49:37.483' AS DateTime), NULL, 0, NULL, 0)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (18, 4, 3, CAST(N'2025-06-05T01:50:13.763' AS DateTime), NULL, 0, NULL, 0)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (19, 4, 5, CAST(N'2025-06-05T01:57:21.663' AS DateTime), NULL, 0, NULL, 0)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (20, 4, 7, CAST(N'2025-06-05T02:01:06.523' AS DateTime), NULL, 300240, N'Tiền mặt', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (21, 4, 1, CAST(N'2025-06-06T08:32:01.487' AS DateTime), NULL, 300240, N'Mobile Banking', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (22, 4, 1, CAST(N'2025-06-06T08:42:36.570' AS DateTime), NULL, 300240, N'Tiền mặt', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (23, 4, 1, CAST(N'2025-06-06T08:47:41.547' AS DateTime), NULL, 300240, N'Tiền mặt', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (24, 4, 1, CAST(N'2025-06-06T08:48:27.830' AS DateTime), NULL, 300240, N'Tiền mặt', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (25, 4, 1, CAST(N'2025-06-06T08:51:11.443' AS DateTime), NULL, 300240, N'Tiền mặt', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (26, 4, 1, CAST(N'2025-06-06T08:58:14.710' AS DateTime), NULL, 255960, N'Tiền mặt', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (27, 4, 2, CAST(N'2025-06-06T08:58:26.480' AS DateTime), NULL, 255960, N'Tiền mặt', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (28, 4, 3, CAST(N'2025-06-06T09:01:01.390' AS DateTime), NULL, 648000, N'Thẻ tín dụng', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (29, 4, 5, CAST(N'2025-06-06T09:02:27.537' AS DateTime), NULL, 300240, N'Mobile Banking', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (30, 4, 1, CAST(N'2025-06-06T09:07:49.143' AS DateTime), NULL, 450360, N'Mobile Banking', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (31, 4, 1, CAST(N'2025-06-06T09:08:19.757' AS DateTime), 2, 382806, N'Mobile Banking', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (32, 4, 2, CAST(N'2025-06-06T13:48:03.443' AS DateTime), 2, 650771, N'Mobile Banking', 1)
INSERT [dbo].[HoaDonBan] ([MaHDB], [MaNV], [MaBan], [ThoiGian], [MaKM], [TongTien], [HinhThucThanhToan], [TrangThai]) VALUES (33, 4, 1, CAST(N'2025-06-06T13:51:01.983' AS DateTime), NULL, 300240, NULL, 0)
SET IDENTITY_INSERT [dbo].[HoaDonBan] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonNhap] ON 

INSERT [dbo].[HoaDonNhap] ([MaHDN], [MaNV], [MaNCC], [NgayNhap], [TongTien]) VALUES (1, 1, 1, CAST(N'2025-05-19' AS Date), 7150000)
SET IDENTITY_INSERT [dbo].[HoaDonNhap] OFF
GO
INSERT [dbo].[KhachCho] ([MaKH], [TenKH], [SDT], [SoNguoi]) VALUES (20250606140910480, N'Tuấn', N'0123456789', 2)
INSERT [dbo].[KhachCho] ([MaKH], [TenKH], [SDT], [SoNguoi]) VALUES (20250606141144263, N'Tín', N'013546498', 2)
INSERT [dbo].[KhachCho] ([MaKH], [TenKH], [SDT], [SoNguoi]) VALUES (20250606141314650, N'útdhfj', N'32134654', 4)
GO
SET IDENTITY_INSERT [dbo].[KhuyenMai] ON 

INSERT [dbo].[KhuyenMai] ([MaKM], [TenKM], [PhanTramGiam], [DieuKien], [NgayBatDau], [NgayKetThuc]) VALUES (1, N'Giảm 10% cho hóa đơn > 500k', 10, N'Hóa đơn trên 500k', CAST(N'2025-05-01' AS Date), CAST(N'2025-06-01' AS Date))
INSERT [dbo].[KhuyenMai] ([MaKM], [TenKM], [PhanTramGiam], [DieuKien], [NgayBatDau], [NgayKetThuc]) VALUES (2, N'Khuyến mãi chào hè', 15, N'Ăn tại cửa hàng', CAST(N'2025-06-04' AS Date), CAST(N'2025-06-08' AS Date))
SET IDENTITY_INSERT [dbo].[KhuyenMai] OFF
GO
SET IDENTITY_INSERT [dbo].[NguyenLieu] ON 

INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonViTinh], [SoLuongTon]) VALUES (1, N'Bò Mỹ', N'kg', 50)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonViTinh], [SoLuongTon]) VALUES (2, N'Rau xà lách', N'kg', 20)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonViTinh], [SoLuongTon]) VALUES (3, N'Thịt heo', N'kg', 90)
INSERT [dbo].[NguyenLieu] ([MaNL], [TenNL], [DonViTinh], [SoLuongTon]) VALUES (4, N'Bún', N'gói', 100)
SET IDENTITY_INSERT [dbo].[NguyenLieu] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi], [Email]) VALUES (1, N'Công ty Thực phẩm ABC', N'0901234567', N'123 Lê Lợi, Hà Nội', N'abc@food.vn')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi], [Email]) VALUES (2, N'Rau sạch GreenFarm', N'0978123456', N'456 Trần Phú, Đà Lạt', N'green@farm.vn')
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [MaChucVu], [Luong]) VALUES (1, N'Nguyễn Văn A', N'Nam', CAST(N'1990-05-10' AS Date), N'Hà Nội', N'0912345678', 1, 15000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [MaChucVu], [Luong]) VALUES (2, N'Trần Thị B', N'Nữ', CAST(N'1995-08-20' AS Date), N'Đà Nẵng', N'0987654321', 2, 8000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [MaChucVu], [Luong]) VALUES (3, N'Lê Văn C', N'Nam', CAST(N'1992-11-15' AS Date), N'TP.HCM', N'0933222111', 3, 12000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [MaChucVu], [Luong]) VALUES (4, N'Phạm Thị D', N'Nữ', CAST(N'1998-02-05' AS Date), N'Cần Thơ', N'0966333444', 4, 9000000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [HoTen], [GioiTinh], [NgaySinh], [QueQuan], [SDT], [MaChucVu], [Luong]) VALUES (5, N'Tuấn', N'Nam', CAST(N'2004-02-27' AS Date), N'Nghệ An', N'031945768', 5, 1000000000)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
INSERT [dbo].[PhanCong] ([MaNhanVien], [MaCa], [NgayLamViec]) VALUES (1, 1, CAST(N'2025-05-20' AS Date))
INSERT [dbo].[PhanCong] ([MaNhanVien], [MaCa], [NgayLamViec]) VALUES (2, 2, CAST(N'2025-05-20' AS Date))
INSERT [dbo].[PhanCong] ([MaNhanVien], [MaCa], [NgayLamViec]) VALUES (3, 3, CAST(N'2025-05-20' AS Date))
INSERT [dbo].[PhanCong] ([MaNhanVien], [MaCa], [NgayLamViec]) VALUES (4, 2, CAST(N'2025-05-20' AS Date))
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau]) VALUES (1, 1, N'admin', N'123')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau]) VALUES (2, 2, N'phucvu', N'123')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau]) VALUES (3, 3, N'daubep', N'123')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau]) VALUES (4, 4, N'thungan', N'123')
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau]) VALUES (5, 5, N'thukho', N'123')
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
ALTER TABLE [dbo].[BanAn] ADD  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[HoaDonBan] ADD  DEFAULT (getdate()) FOR [ThoiGian]
GO
ALTER TABLE [dbo].[HoaDonBan] ADD  DEFAULT ((0)) FOR [TongTien]
GO
ALTER TABLE [dbo].[HoaDonBan] ADD  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[HoaDonNhap] ADD  DEFAULT ((0)) FOR [TongTien]
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan]  WITH CHECK ADD FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan]  WITH CHECK ADD FOREIGN KEY([MaHDB])
REFERENCES [dbo].[HoaDonBan] ([MaHDB])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap]  WITH CHECK ADD FOREIGN KEY([MaHDN])
REFERENCES [dbo].[HoaDonNhap] ([MaHDN])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap]  WITH CHECK ADD FOREIGN KEY([MaNL])
REFERENCES [dbo].[NguyenLieu] ([MaNL])
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD FOREIGN KEY([MaBan])
REFERENCES [dbo].[BanAn] ([MaBan])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD FOREIGN KEY([MaKM])
REFERENCES [dbo].[KhuyenMai] ([MaKM])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaCa])
REFERENCES [dbo].[CaLamViec] ([MaCa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON DELETE CASCADE
GO
/****** Object:  Trigger [dbo].[trg_UpdateTongTienHDB]    Script Date: 18/06/2025 15:31:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateTongTienHDB]
ON [dbo].[ChiTietHoaDonBan]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật tổng tiền cho tất cả MaHDB bị ảnh hưởng
    UPDATE h
    SET TongTien = 
        ROUND(
            (
                SELECT SUM(c.SoLuong * d.DonGia)
                FROM ChiTietHoaDonBan c
                JOIN DichVu d ON c.MaDichVu = d.MaDichVu
                WHERE c.MaHDB = h.MaHDB
            ) * 
            (1 - ISNULL(k.PhanTramGiam, 0) / 100.0) 
			* 1.08,
        0)
    FROM HoaDonBan h
    LEFT JOIN KhuyenMai k ON h.MaKM = k.MaKM
    WHERE h.MaHDB IN (
        SELECT MaHDB FROM inserted
        UNION
        SELECT MaHDB FROM deleted
    );
END;
GO
ALTER TABLE [dbo].[ChiTietHoaDonBan] ENABLE TRIGGER [trg_UpdateTongTienHDB]
GO
/****** Object:  Trigger [dbo].[trg_CapNhat_TongTien_HoaDonNhap]    Script Date: 18/06/2025 15:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_CapNhat_TongTien_HoaDonNhap]
ON [dbo].[ChiTietHoaDonNhap]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE HDN
    SET TongTien = (
        SELECT SUM(CT.SoLuongNhap * CT.DonGiaNhap)
        FROM ChiTietHoaDonNhap CT
        WHERE CT.MaHDN = HDN.MaHDN
    )
    FROM HoaDonNhap HDN
    WHERE HDN.MaHDN IN (
        SELECT DISTINCT MaHDN FROM inserted
        UNION
        SELECT DISTINCT MaHDN FROM deleted
    );
END;
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap] ENABLE TRIGGER [trg_CapNhat_TongTien_HoaDonNhap]
GO
/****** Object:  Trigger [dbo].[trg_TangTonKho_KhiNhap]    Script Date: 18/06/2025 15:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Trigger cập nhật tăng tồn kho khi nhập nguyên liệu
CREATE TRIGGER [dbo].[trg_TangTonKho_KhiNhap]
ON [dbo].[ChiTietHoaDonNhap]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE NL
    SET NL.SoLuongTon = NL.SoLuongTon + CT.SoLuongNhap
    FROM NguyenLieu NL
    JOIN inserted CT ON NL.MaNL = CT.MaNL;
END;
GO
ALTER TABLE [dbo].[ChiTietHoaDonNhap] ENABLE TRIGGER [trg_TangTonKho_KhiNhap]
GO
/****** Object:  Trigger [dbo].[trg_CapNhatBanAn_SauInsert_HoaDonBan]    Script Date: 18/06/2025 15:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_CapNhatBanAn_SauInsert_HoaDonBan]
ON [dbo].[HoaDonBan]
AFTER INSERT
AS
BEGIN
    UPDATE BanAn
    SET TrangThai = 1
    FROM BanAn B
    INNER JOIN inserted I ON B.MaBan = I.MaBan
    WHERE I.MaBan IS NOT NULL;
END;
GO
ALTER TABLE [dbo].[HoaDonBan] ENABLE TRIGGER [trg_CapNhatBanAn_SauInsert_HoaDonBan]
GO
/****** Object:  Trigger [dbo].[trg_CapNhatBanAn_SauUpdate_HoaDonBan]    Script Date: 18/06/2025 15:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_CapNhatBanAn_SauUpdate_HoaDonBan]
ON [dbo].[HoaDonBan]
AFTER UPDATE
AS
BEGIN
    -- Chỉ cập nhật bàn nếu hóa đơn đã chuyển trạng thái từ chưa thanh toán sang đã thanh toán
    UPDATE BanAn
    SET TrangThai = 0
    FROM BanAn B
    INNER JOIN inserted I ON B.MaBan = I.MaBan
    INNER JOIN deleted D ON I.MaHDB = D.MaHDB
    WHERE I.TrangThai = 1 AND D.TrangThai <> 1 AND I.MaBan IS NOT NULL;
END;
GO
ALTER TABLE [dbo].[HoaDonBan] ENABLE TRIGGER [trg_CapNhatBanAn_SauUpdate_HoaDonBan]
GO
/****** Object:  Trigger [dbo].[trg_KhachCho_Insert]    Script Date: 18/06/2025 15:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_KhachCho_Insert]
ON [dbo].[KhachCho]
INSTEAD OF INSERT
AS
BEGIN
    INSERT INTO KhachCho (MaKH, TenKH, SDT, SoNguoi)
    SELECT 
        CAST(FORMAT(GETDATE(), 'yyyyMMddHHmmssfff') AS BIGINT),
        TenKH,
        SDT,
        SoNguoi
    FROM INSERTED;
END;
GO
ALTER TABLE [dbo].[KhachCho] ENABLE TRIGGER [trg_KhachCho_Insert]
GO
USE [master]
GO
ALTER DATABASE [NHDK_final] SET  READ_WRITE 
GO
