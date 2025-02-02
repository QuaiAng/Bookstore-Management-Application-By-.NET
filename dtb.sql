
/****** Object:  Database [QLiCuaHangSach]    Script Date: 16/05/2024 8:39:25 CH ******/
CREATE DATABASE [QLiCuaHangSach]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLiCuaHangSach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLiCuaHangSach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLiCuaHangSach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLiCuaHangSach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLiCuaHangSach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLiCuaHangSach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET RECOVERY FULL 
GO
ALTER DATABASE [QLiCuaHangSach] SET  MULTI_USER 
GO
ALTER DATABASE [QLiCuaHangSach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLiCuaHangSach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLiCuaHangSach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLiCuaHangSach] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLiCuaHangSach] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLiCuaHangSach] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLiCuaHangSach', N'ON'
GO
ALTER DATABASE [QLiCuaHangSach] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLiCuaHangSach] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLiCuaHangSach]
GO
/****** Object:  Table [dbo].[CTDH]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDH](
	[maPhieuDat] [int] NOT NULL,
	[maMH] [int] NOT NULL,
	[soLuong] [int] NOT NULL,
	[maLoai] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHD_MH]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD_MH](
	[maHD] [int] NOT NULL,
	[maMH] [int] NOT NULL,
	[soLuongBan] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTNH]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTNH](
	[maPhieuNhap] [int] NOT NULL,
	[maMH] [int] NOT NULL,
	[giaNhap] [float] NOT NULL,
	[soLuong] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[maHD] [int] IDENTITY(1,1) NOT NULL,
	[tongTien] [float] NOT NULL,
	[ngayLap] [datetime] NOT NULL,
	[maNV] [int] NOT NULL,
	[maKH] [int] NULL,
	[trangThai] [bit] NOT NULL,
 CONSTRAINT [PK__HOADON__7A3E14860CFA4FC0] PRIMARY KEY CLUSTERED 
(
	[maHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[maKH] [int] IDENTITY(1,1) NOT NULL,
	[tenKH] [nvarchar](max) NOT NULL,
	[SDT] [char](10) NULL,
	[gioiTinh] [bit] NULL,
	[diaChi] [nvarchar](max) NOT NULL,
	[trangThai] [bit] NOT NULL,
	[tongTienDaMua] [bigint] NOT NULL,
 CONSTRAINT [PK__KHACHHAN__7A3ECFE4D74E8489] PRIMARY KEY CLUSTERED 
(
	[maKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIHANG]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIHANG](
	[maLoai] [int] IDENTITY(1,1) NOT NULL,
	[tenLoai] [nvarchar](max) NOT NULL,
	[trangThai] [bit] NOT NULL,
 CONSTRAINT [PK__LOAIHANG__E5A6B228FE24ADE0] PRIMARY KEY CLUSTERED 
(
	[maLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUONG]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUONG](
	[maLuong] [int] IDENTITY(1,1) NOT NULL,
	[luongCung] [float] NOT NULL,
	[phuCap] [float] NOT NULL,
	[tienPhat] [float] NOT NULL,
	[tongLuong] [float] NOT NULL,
	[tinhTrang] [bit] NOT NULL,
	[maNV] [int] NOT NULL,
	[trangThai] [bit] NOT NULL,
	[thoiGian] [date] NOT NULL,
	[soGioLamViec] [float] NOT NULL,
 CONSTRAINT [PK__LUONG__31F4B611DD92F715] PRIMARY KEY CLUSTERED 
(
	[maLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATHANG]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATHANG](
	[maMH] [int] IDENTITY(1,1) NOT NULL,
	[tenMH] [nvarchar](max) NOT NULL,
	[giaBan] [float] NOT NULL,
	[tonKho] [int] NOT NULL,
	[maLoai] [int] NOT NULL,
	[trangThai] [bit] NOT NULL,
 CONSTRAINT [PK__MATHANG__7A3EDFA6400E7373] PRIMARY KEY CLUSTERED 
(
	[maMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[maNCC] [int] IDENTITY(1,1) NOT NULL,
	[tenNCC] [nvarchar](max) NOT NULL,
	[trangThai] [bit] NOT NULL,
 CONSTRAINT [PK__NHACUNGC__2699C45FC11C4E2F] PRIMARY KEY CLUSTERED 
(
	[maNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[maNV] [int] IDENTITY(1,1) NOT NULL,
	[tenNV] [nvarchar](max) NOT NULL,
	[gioiTinh] [bit] NOT NULL,
	[ngaySinh] [datetime] NOT NULL,
	[SDT] [char](12) NOT NULL,
	[diaChi] [nvarchar](max) NOT NULL,
	[CCCD] [char](20) NOT NULL,
	[trangThai] [bit] NOT NULL,
 CONSTRAINT [PK__NHANVIEN__7A3EC7D569C205B4] PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUDATHANG]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUDATHANG](
	[maPhieuDat] [int] IDENTITY(1,1) NOT NULL,
	[ngayDat] [datetime] NOT NULL,
	[maNCC] [int] NOT NULL,
	[maNV] [int] NOT NULL,
 CONSTRAINT [PK__PHIEUDAT__E50D0A560BF50CF1] PRIMARY KEY CLUSTERED 
(
	[maPhieuDat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUNHAPHANG]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAPHANG](
	[maPhieuNhap] [int] IDENTITY(1,1) NOT NULL,
	[ngayNhap] [datetime] NOT NULL,
	[maNCC] [int] NOT NULL,
	[maNV] [int] NOT NULL,
	[tongTien] [float] NOT NULL,
 CONSTRAINT [PK__PHIEUNHA__E27639341129B73A] PRIMARY KEY CLUSTERED 
(
	[maPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[maTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[tenDangNhap] [char](50) NOT NULL,
	[matKhau] [nvarchar](max) NOT NULL,
	[maNV] [int] NOT NULL,
	[quyen] [bit] NOT NULL,
	[trangThai] [bit] NOT NULL,
 CONSTRAINT [PK__TAIKHOAN__8FFF6A9DF1A46DD7] PRIMARY KEY CLUSTERED 
(
	[maTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[CTDH] ([maPhieuDat], [maMH], [soLuong], [maLoai]) VALUES (8, 6, 4, 6)
INSERT [dbo].[CTDH] ([maPhieuDat], [maMH], [soLuong], [maLoai]) VALUES (8, 10, 1, 6)
GO
INSERT [dbo].[CTHD_MH] ([maHD], [maMH], [soLuongBan]) VALUES (73, 8, 1)
INSERT [dbo].[CTHD_MH] ([maHD], [maMH], [soLuongBan]) VALUES (74, 12, 1)
INSERT [dbo].[CTHD_MH] ([maHD], [maMH], [soLuongBan]) VALUES (74, 10, 1)
INSERT [dbo].[CTHD_MH] ([maHD], [maMH], [soLuongBan]) VALUES (75, 28, 1)
INSERT [dbo].[CTHD_MH] ([maHD], [maMH], [soLuongBan]) VALUES (75, 3, 1)
INSERT [dbo].[CTHD_MH] ([maHD], [maMH], [soLuongBan]) VALUES (75, 26, 1)
INSERT [dbo].[CTHD_MH] ([maHD], [maMH], [soLuongBan]) VALUES (77, 6, 1)
INSERT [dbo].[CTHD_MH] ([maHD], [maMH], [soLuongBan]) VALUES (80, 14, 1)
INSERT [dbo].[CTHD_MH] ([maHD], [maMH], [soLuongBan]) VALUES (81, 7, 1)
GO
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (11, 11, 91823, 1)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (12, 9, 123, 1)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (13, 7, 12312, 1)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (13, 13, 123123, 2)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (13, 6, 3123, 1)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (14, 22, 79000, 5)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (15, 22, 79000, 2)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (16, 22, 79000, 5)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (17, 22, 79000, 1)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (18, 13, 120000, 1)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (19, 13, 120000, 1)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (20, 13, 120000, 1)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (21, 13, 120000, 1)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (22, 13, 120000, 1)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (23, 13, 120000, 5)
INSERT [dbo].[CTNH] ([maPhieuNhap], [maMH], [giaNhap], [soLuong]) VALUES (24, 21, 100000, 9)
GO
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([maHD], [tongTien], [ngayLap], [maNV], [maKH], [trangThai]) VALUES (73, 18000, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, NULL, 1)
INSERT [dbo].[HOADON] ([maHD], [tongTien], [ngayLap], [maNV], [maKH], [trangThai]) VALUES (74, 179000, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, NULL, 1)
INSERT [dbo].[HOADON] ([maHD], [tongTien], [ngayLap], [maNV], [maKH], [trangThai]) VALUES (75, 438000, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 30, 1)
INSERT [dbo].[HOADON] ([maHD], [tongTien], [ngayLap], [maNV], [maKH], [trangThai]) VALUES (77, 18000, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 15, 1)
INSERT [dbo].[HOADON] ([maHD], [tongTien], [ngayLap], [maNV], [maKH], [trangThai]) VALUES (80, 20000, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, NULL, 1)
INSERT [dbo].[HOADON] ([maHD], [tongTien], [ngayLap], [maNV], [maKH], [trangThai]) VALUES (81, 20000, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 4, 1)
SET IDENTITY_INSERT [dbo].[HOADON] OFF
GO
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (3, N'Giang Hoàng Linh', N'0221487223', 1, N'Long An', 1, 820000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (4, N'Nguyễn Kim Quyên', N'0987985212', 0, N'Đà Lạt', 1, 50000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (5, N'Trần Thị Linh Giang', N'0128898621', 0, N'Đồng Nai', 1, 560000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (6, N'Lê Thị Nguyệt Minh', N'0936367632', 0, N'Bình Dương', 1, 80000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (8, N'Hồ Trọng Tấn', N'0832999762', 1, N'TPHCM', 1, 20000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (9, N'Nguyễn Thanh Tùng', N'0909878282', 0, N'Tiền Giang', 1, 120000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (13, N'Cao Hoài An', N'0916689625', 0, N'Long An', 0, 510000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (14, N'Cao Hoài An', N'0916689625', 1, N'Long An', 1, 100000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (15, N'Lê Phú Thành', N'0916689625', 1, N'Bình Dương', 1, 3257500)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (16, N'Phạm Lê Kim Thy', N'0912738123', 0, N'Long An', 1, 0)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (17, N'Nguyễn Văn Khánh', N'0912382632', 1, N'Lâm Đồng', 0, 0)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (18, N'Nguyễn Văn Khánh', N'0918239891', 1, N'Lâm Đồng', 0, 0)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (19, N'Nguyễn Văn Khánh', N'0912381287', 1, N'Lâm Đồng', 1, 120000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (20, N'Lâm Tuấn Tú', N'0912371728', 1, N'Bình Dương', 1, 360000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (21, N'Nguyễn Lâm Lê', N'0987898954', 1, N'Cà Mau', 1, 80000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (22, N'Lê La', N'0129392849', 1, N'Hà Nội', 1, 180000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (23, N'ABC', N'1029039102', 1, N'ákdkạ', 1, 20000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (24, N'Hà Duy Mạnh Gai', N'0912736712', 1, N'Sài Gòn', 1, 20000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (25, N'Bủ Nô', N'0912378172', 1, N'London', 1, 18000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (26, N'Lê La', N'0129392849', 1, N'Hà Nội', 1, 20000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (27, N'Lê Phú Thành', N'0916689625', 1, N'Bình Dương', 1, 2304000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (28, N'Lê Phú Thành', N'0916689625', 1, N'Bình Dương', 1, 2073600)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (29, N'Nguyễn Văn Ba', N'0912387817', 1, N'Đồng Tháp', 1, 179000)
INSERT [dbo].[KHACHHANG] ([maKH], [tenKH], [SDT], [gioiTinh], [diaChi], [trangThai], [tongTienDaMua]) VALUES (30, N'Phan Tấn Trung', N'0912388172', 1, N'Sa Đéc', 1, 438000)
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[LOAIHANG] ON 

INSERT [dbo].[LOAIHANG] ([maLoai], [tenLoai], [trangThai]) VALUES (1, N'Truyện tranh', 1)
INSERT [dbo].[LOAIHANG] ([maLoai], [tenLoai], [trangThai]) VALUES (2, N'Tiểu thuyết', 1)
INSERT [dbo].[LOAIHANG] ([maLoai], [tenLoai], [trangThai]) VALUES (3, N'Thiếu nhi', 1)
INSERT [dbo].[LOAIHANG] ([maLoai], [tenLoai], [trangThai]) VALUES (4, N'Lịch sử', 1)
INSERT [dbo].[LOAIHANG] ([maLoai], [tenLoai], [trangThai]) VALUES (5, N'Văn hóa xã hội', 1)
INSERT [dbo].[LOAIHANG] ([maLoai], [tenLoai], [trangThai]) VALUES (6, N'Tâm lý', 1)
INSERT [dbo].[LOAIHANG] ([maLoai], [tenLoai], [trangThai]) VALUES (7, N'Trinh thám', 1)
INSERT [dbo].[LOAIHANG] ([maLoai], [tenLoai], [trangThai]) VALUES (8, N'Kinh dị', 0)
INSERT [dbo].[LOAIHANG] ([maLoai], [tenLoai], [trangThai]) VALUES (9, N'OK', 0)
INSERT [dbo].[LOAIHANG] ([maLoai], [tenLoai], [trangThai]) VALUES (10, N'O', 0)
SET IDENTITY_INSERT [dbo].[LOAIHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[LUONG] ON 

INSERT [dbo].[LUONG] ([maLuong], [luongCung], [phuCap], [tienPhat], [tongLuong], [tinhTrang], [maNV], [trangThai], [thoiGian], [soGioLamViec]) VALUES (1, 20000, 0, 0, 320000, 1, 1, 1, CAST(N'2024-05-12' AS Date), 3.6800000000000006)
INSERT [dbo].[LUONG] ([maLuong], [luongCung], [phuCap], [tienPhat], [tongLuong], [tinhTrang], [maNV], [trangThai], [thoiGian], [soGioLamViec]) VALUES (6, 25000, 0, 0, 0, 0, 14, 1, CAST(N'2024-05-12' AS Date), 0.38)
INSERT [dbo].[LUONG] ([maLuong], [luongCung], [phuCap], [tienPhat], [tongLuong], [tinhTrang], [maNV], [trangThai], [thoiGian], [soGioLamViec]) VALUES (7, 1E+261, 0, 0, 0, 1, 15, 1, CAST(N'2024-05-12' AS Date), 0.15)
INSERT [dbo].[LUONG] ([maLuong], [luongCung], [phuCap], [tienPhat], [tongLuong], [tinhTrang], [maNV], [trangThai], [thoiGian], [soGioLamViec]) VALUES (8, 25000, 20000, 0, 0, 0, 16, 1, CAST(N'2024-05-13' AS Date), 0)
SET IDENTITY_INSERT [dbo].[LUONG] OFF
GO
SET IDENTITY_INSERT [dbo].[MATHANG] ON 

INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (3, N'Không Gia Đình - Hector Malot', 170000, 15, 2, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (4, N'Ông Già Và Biển Cả - Ernest Hemingway', 155000, 19, 2, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (5, N'Âm Thanh Và Cuồng Nộ - William Faulkner', 140000, 17, 2, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (6, N'Thám Tử Lừng Danh Conan', 20000, 90, 1, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (7, N'Shin Cậu Bé Bút Chì', 20000, 999, 1, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (8, N'Doreamon', 18000, 56, 1, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (9, N'Tư duy nhanh và chậm - Daniel Kahneman', 80000, 18, 6, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (10, N'Phi lý trí – Dan Ariely.', 79000, 13, 6, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (11, N'Bản Chất Của Dối Trá – Dan Ariely.', 89000, 17, 6, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (12, N'Lược Sử Thế Giới', 100000, 13, 4, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (13, N'Lịch Sử Chiến Tranh', 120000, 55, 4, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (14, N'Naruto', 20000, 16, 1, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (19, N'Hoàng Tử Bé - Antoine De Saint-Exupéry', 69000, 24, 3, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (20, N' Alice ở xứ sở diệu kỳ - Lewis Carroll', 79000, 32, 3, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (21, N' Charlie và nhà máy Sô-cô-la – Roald Dahl', 99000, 30, 3, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (22, N'Thương nhớ thời bao cấp', 70000, 30, 5, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (24, N'Bản sắc văn hóa Việt Nam', 39000, 23, 5, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (26, N'Vật tổ và cấm kỵ', 49000, 15, 5, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (27, N'Mật mã Da Vinci – Dan Brown', 120000, 14, 7, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (28, N'Sự im lặng của bầy cừu - Thomas Harris', 219000, 15, 7, 1)
INSERT [dbo].[MATHANG] ([maMH], [tenMH], [giaBan], [tonKho], [maLoai], [trangThai]) VALUES (29, N'Án mạng trên sông Nile - Agatha Christie', 199000, 17, 7, 1)
SET IDENTITY_INSERT [dbo].[MATHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[NHACUNGCAP] ON 

INSERT [dbo].[NHACUNGCAP] ([maNCC], [tenNCC], [trangThai]) VALUES (1, N'Phát Tài', 1)
INSERT [dbo].[NHACUNGCAP] ([maNCC], [tenNCC], [trangThai]) VALUES (2, N'Hồng Đức', 1)
INSERT [dbo].[NHACUNGCAP] ([maNCC], [tenNCC], [trangThai]) VALUES (3, N'An Khang', 0)
INSERT [dbo].[NHACUNGCAP] ([maNCC], [tenNCC], [trangThai]) VALUES (4, N'Kim Đồng', 1)
INSERT [dbo].[NHACUNGCAP] ([maNCC], [tenNCC], [trangThai]) VALUES (5, N'Kim Đồng', 0)
INSERT [dbo].[NHACUNGCAP] ([maNCC], [tenNCC], [trangThai]) VALUES (6, N'Thanh Niên', 1)
INSERT [dbo].[NHACUNGCAP] ([maNCC], [tenNCC], [trangThai]) VALUES (7, N'Mỹ Thuật', 1)
INSERT [dbo].[NHACUNGCAP] ([maNCC], [tenNCC], [trangThai]) VALUES (8, N'Lao Động', 1)
INSERT [dbo].[NHACUNGCAP] ([maNCC], [tenNCC], [trangThai]) VALUES (9, N'Phụ Nữ', 1)
SET IDENTITY_INSERT [dbo].[NHACUNGCAP] OFF
GO
SET IDENTITY_INSERT [dbo].[NHANVIEN] ON 

INSERT [dbo].[NHANVIEN] ([maNV], [tenNV], [gioiTinh], [ngaySinh], [SDT], [diaChi], [CCCD], [trangThai]) VALUES (1, N'Nguyễn Văn A', 1, CAST(N'2002-09-07T00:00:00.000' AS DateTime), N'0916672632  ', N'Hà Nội', N'091238718273123     ', 1)
INSERT [dbo].[NHANVIEN] ([maNV], [tenNV], [gioiTinh], [ngaySinh], [SDT], [diaChi], [CCCD], [trangThai]) VALUES (14, N'Lê Thị B', 0, CAST(N'2003-06-05T00:00:00.000' AS DateTime), N'0912773821  ', N'Bình Thuận', N'091238182301928     ', 1)
INSERT [dbo].[NHANVIEN] ([maNV], [tenNV], [gioiTinh], [ngaySinh], [SDT], [diaChi], [CCCD], [trangThai]) VALUES (15, N'Phạm Văn C', 1, CAST(N'2002-09-07T00:00:00.000' AS DateTime), N'0912378162  ', N'Lâm Đồng', N'091239128378178     ', 1)
INSERT [dbo].[NHANVIEN] ([maNV], [tenNV], [gioiTinh], [ngaySinh], [SDT], [diaChi], [CCCD], [trangThai]) VALUES (16, N'Chung Văn Dũng', 1, CAST(N'2006-05-13T00:00:00.000' AS DateTime), N'0967126381  ', N'Khánh Hòa', N'081238197283717     ', 1)
SET IDENTITY_INSERT [dbo].[NHANVIEN] OFF
GO
SET IDENTITY_INSERT [dbo].[PHIEUDATHANG] ON 

INSERT [dbo].[PHIEUDATHANG] ([maPhieuDat], [ngayDat], [maNCC], [maNV]) VALUES (8, CAST(N'2024-05-11T00:00:00.000' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[PHIEUDATHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[PHIEUNHAPHANG] ON 

INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (8, CAST(N'2024-05-11T00:00:00.000' AS DateTime), 7, 1, 0)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (9, CAST(N'2024-05-11T00:00:00.000' AS DateTime), 7, 1, 123)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (10, CAST(N'2024-05-11T00:00:00.000' AS DateTime), 1, 1, 111)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (11, CAST(N'2024-05-11T00:00:00.000' AS DateTime), 1, 1, 92135)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (12, CAST(N'2024-05-11T00:00:00.000' AS DateTime), 1, 1, 246)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (13, CAST(N'2024-05-11T00:00:00.000' AS DateTime), 1, 1, 261681)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (14, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 1, 395000)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (15, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 1, 158000)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (16, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 1, 395000)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (17, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 1, 199000)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (18, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 1, 120000)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (19, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 1, 120000)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (20, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 1, 120000)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (21, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 1, 120000)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (22, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 1, 120000)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (23, CAST(N'2024-05-13T00:00:00.000' AS DateTime), 1, 1, 600000)
INSERT [dbo].[PHIEUNHAPHANG] ([maPhieuNhap], [ngayNhap], [maNCC], [maNV], [tongTien]) VALUES (24, CAST(N'2024-05-14T00:00:00.000' AS DateTime), 1, 1, 900000)
SET IDENTITY_INSERT [dbo].[PHIEUNHAPHANG] OFF
GO
SET IDENTITY_INSERT [dbo].[TAIKHOAN] ON 

INSERT [dbo].[TAIKHOAN] ([maTaiKhoan], [tenDangNhap], [matKhau], [maNV], [quyen], [trangThai]) VALUES (1, N'Admin                                             ', N'81dc9bdb52d04dc20036dbd8313ed055', 1, 1, 1)
INSERT [dbo].[TAIKHOAN] ([maTaiKhoan], [tenDangNhap], [matKhau], [maNV], [quyen], [trangThai]) VALUES (24, N'User                                              ', N'81dc9bdb52d04dc20036dbd8313ed055', 14, 0, 1)
INSERT [dbo].[TAIKHOAN] ([maTaiKhoan], [tenDangNhap], [matKhau], [maNV], [quyen], [trangThai]) VALUES (25, N'User2                                             ', N'81dc9bdb52d04dc20036dbd8313ed055', 15, 0, 1)
INSERT [dbo].[TAIKHOAN] ([maTaiKhoan], [tenDangNhap], [matKhau], [maNV], [quyen], [trangThai]) VALUES (26, N'Admin2                                            ', N'81dc9bdb52d04dc20036dbd8313ed055', 16, 1, 1)
SET IDENTITY_INSERT [dbo].[TAIKHOAN] OFF
GO
ALTER TABLE [dbo].[CTDH]  WITH CHECK ADD  CONSTRAINT [FK__CTDH__maMH__4BAC3F29] FOREIGN KEY([maMH])
REFERENCES [dbo].[MATHANG] ([maMH])
GO
ALTER TABLE [dbo].[CTDH] CHECK CONSTRAINT [FK__CTDH__maMH__4BAC3F29]
GO
ALTER TABLE [dbo].[CTDH]  WITH CHECK ADD  CONSTRAINT [FK__CTDH__maPhieuDat__4CA06362] FOREIGN KEY([maPhieuDat])
REFERENCES [dbo].[PHIEUDATHANG] ([maPhieuDat])
GO
ALTER TABLE [dbo].[CTDH] CHECK CONSTRAINT [FK__CTDH__maPhieuDat__4CA06362]
GO
ALTER TABLE [dbo].[CTHD_MH]  WITH CHECK ADD  CONSTRAINT [FK__CTHD_MH__maHD__4E88ABD4] FOREIGN KEY([maHD])
REFERENCES [dbo].[HOADON] ([maHD])
GO
ALTER TABLE [dbo].[CTHD_MH] CHECK CONSTRAINT [FK__CTHD_MH__maHD__4E88ABD4]
GO
ALTER TABLE [dbo].[CTHD_MH]  WITH CHECK ADD  CONSTRAINT [FK__CTHD_MH__maMH__4D94879B] FOREIGN KEY([maMH])
REFERENCES [dbo].[MATHANG] ([maMH])
GO
ALTER TABLE [dbo].[CTHD_MH] CHECK CONSTRAINT [FK__CTHD_MH__maMH__4D94879B]
GO
ALTER TABLE [dbo].[CTNH]  WITH CHECK ADD  CONSTRAINT [FK__CTNH__maMH__4F7CD00D] FOREIGN KEY([maMH])
REFERENCES [dbo].[MATHANG] ([maMH])
GO
ALTER TABLE [dbo].[CTNH] CHECK CONSTRAINT [FK__CTNH__maMH__4F7CD00D]
GO
ALTER TABLE [dbo].[CTNH]  WITH CHECK ADD  CONSTRAINT [FK__CTNH__maPhieuNha__5070F446] FOREIGN KEY([maPhieuNhap])
REFERENCES [dbo].[PHIEUNHAPHANG] ([maPhieuNhap])
GO
ALTER TABLE [dbo].[CTNH] CHECK CONSTRAINT [FK__CTNH__maPhieuNha__5070F446]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK__HOADON__maKH__5165187F] FOREIGN KEY([maKH])
REFERENCES [dbo].[KHACHHANG] ([maKH])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK__HOADON__maKH__5165187F]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK__HOADON__maNV__52593CB8] FOREIGN KEY([maNV])
REFERENCES [dbo].[NHANVIEN] ([maNV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK__HOADON__maNV__52593CB8]
GO
ALTER TABLE [dbo].[LUONG]  WITH CHECK ADD  CONSTRAINT [FK__LUONG__maNV__534D60F1] FOREIGN KEY([maNV])
REFERENCES [dbo].[NHANVIEN] ([maNV])
GO
ALTER TABLE [dbo].[LUONG] CHECK CONSTRAINT [FK__LUONG__maNV__534D60F1]
GO
ALTER TABLE [dbo].[LUONG]  WITH CHECK ADD  CONSTRAINT [FK_LUONG_NHANVIEN] FOREIGN KEY([maNV])
REFERENCES [dbo].[NHANVIEN] ([maNV])
GO
ALTER TABLE [dbo].[LUONG] CHECK CONSTRAINT [FK_LUONG_NHANVIEN]
GO
ALTER TABLE [dbo].[MATHANG]  WITH CHECK ADD  CONSTRAINT [FK__MATHANG__maLoai__5535A963] FOREIGN KEY([maLoai])
REFERENCES [dbo].[LOAIHANG] ([maLoai])
GO
ALTER TABLE [dbo].[MATHANG] CHECK CONSTRAINT [FK__MATHANG__maLoai__5535A963]
GO
ALTER TABLE [dbo].[PHIEUDATHANG]  WITH CHECK ADD  CONSTRAINT [FK__PHIEUDATH__maNCC__5629CD9C] FOREIGN KEY([maNCC])
REFERENCES [dbo].[NHACUNGCAP] ([maNCC])
GO
ALTER TABLE [dbo].[PHIEUDATHANG] CHECK CONSTRAINT [FK__PHIEUDATH__maNCC__5629CD9C]
GO
ALTER TABLE [dbo].[PHIEUDATHANG]  WITH CHECK ADD  CONSTRAINT [FK__PHIEUDATHA__maNV__571DF1D5] FOREIGN KEY([maNV])
REFERENCES [dbo].[NHANVIEN] ([maNV])
GO
ALTER TABLE [dbo].[PHIEUDATHANG] CHECK CONSTRAINT [FK__PHIEUDATHA__maNV__571DF1D5]
GO
ALTER TABLE [dbo].[PHIEUNHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK__PHIEUNHAP__maNCC__5812160E] FOREIGN KEY([maNCC])
REFERENCES [dbo].[NHACUNGCAP] ([maNCC])
GO
ALTER TABLE [dbo].[PHIEUNHAPHANG] CHECK CONSTRAINT [FK__PHIEUNHAP__maNCC__5812160E]
GO
ALTER TABLE [dbo].[PHIEUNHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK__PHIEUNHAPH__maNV__59063A47] FOREIGN KEY([maNV])
REFERENCES [dbo].[NHANVIEN] ([maNV])
GO
ALTER TABLE [dbo].[PHIEUNHAPHANG] CHECK CONSTRAINT [FK__PHIEUNHAPH__maNV__59063A47]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK__TAIKHOAN__maNV__59FA5E80] FOREIGN KEY([maNV])
REFERENCES [dbo].[NHANVIEN] ([maNV])
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK__TAIKHOAN__maNV__59FA5E80]
GO
ALTER TABLE [dbo].[CTDH]  WITH CHECK ADD  CONSTRAINT [CK_soLuong] CHECK  (([soLuong]>(0)))
GO
ALTER TABLE [dbo].[CTDH] CHECK CONSTRAINT [CK_soLuong]
GO
ALTER TABLE [dbo].[CTNH]  WITH CHECK ADD  CONSTRAINT [CK_giaNhap] CHECK  (([giaNhap]>(0)))
GO
ALTER TABLE [dbo].[CTNH] CHECK CONSTRAINT [CK_giaNhap]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [CK_tongTien] CHECK  (([tongTien]>=(0)))
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [CK_tongTien]
GO
ALTER TABLE [dbo].[LUONG]  WITH CHECK ADD  CONSTRAINT [CK_luongCung] CHECK  (([luongCung]>(0)))
GO
ALTER TABLE [dbo].[LUONG] CHECK CONSTRAINT [CK_luongCung]
GO
ALTER TABLE [dbo].[LUONG]  WITH CHECK ADD  CONSTRAINT [CK_phuCap] CHECK  (([luongCung]>=(0)))
GO
ALTER TABLE [dbo].[LUONG] CHECK CONSTRAINT [CK_phuCap]
GO
ALTER TABLE [dbo].[LUONG]  WITH CHECK ADD  CONSTRAINT [CK_tienPhat] CHECK  (([tienPhat]>=(0)))
GO
ALTER TABLE [dbo].[LUONG] CHECK CONSTRAINT [CK_tienPhat]
GO
ALTER TABLE [dbo].[MATHANG]  WITH CHECK ADD  CONSTRAINT [CK_GiaBan_Positive] CHECK  (([giaBan]>=(0)))
GO
ALTER TABLE [dbo].[MATHANG] CHECK CONSTRAINT [CK_GiaBan_Positive]
GO
ALTER TABLE [dbo].[MATHANG]  WITH CHECK ADD  CONSTRAINT [CK_TonKho] CHECK  (([tonKho]>=(0)))
GO
ALTER TABLE [dbo].[MATHANG] CHECK CONSTRAINT [CK_TonKho]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [CK_ngaySinh] CHECK  ((datediff(year,[ngaySinh],getdate())>=(18)))
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [CK_ngaySinh]
GO
/****** Object:  StoredProcedure [dbo].[DangNhap]    Script Date: 16/05/2024 8:39:25 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DangNhap]
    @TenDangNhap char(50),
    @MatKhau char(15)
AS
BEGIN
    SELECT * FROM TAIKHOAN WHERE tenDangNhap = @tenDangNhap AND matKhau = @matKhau;
END;
GO
USE [master]
GO
ALTER DATABASE [QLiCuaHangSach] SET  READ_WRITE 
GO
