USE [qltn]
GO
/****** Object:  Table [dbo].[hopdong]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hopdong](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPhong] [int] NOT NULL,
	[idNguoiDaiDien] [int] NOT NULL,
	[soHopDong] [nvarchar](50) NOT NULL,
	[ngayBatDau] [date] NOT NULL,
	[ngayKetThuc] [date] NOT NULL,
	[tienCoc] [decimal](15, 0) NOT NULL,
	[ghiChu] [nvarchar](max) NULL,
	[fileHopDong] [nvarchar](255) NULL,
	[trangThai] [nvarchar](20) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[soHopDong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thongbaophi]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thongbaophi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idHopDong] [int] NOT NULL,
	[thangNam] [nvarchar](7) NOT NULL,
	[ngayLap] [date] NOT NULL,
	[tongTien] [decimal](15, 0) NOT NULL,
	[hanThanhToan] [date] NOT NULL,
	[trangThaiThanhToan] [nvarchar](30) NULL,
	[filePDF] [nvarchar](255) NULL,
	[daGuiThongBao] [bit] NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
	[qrCodeUrl] [nvarchar](500) NULL,
	[qrImageData] [nvarchar](max) NULL,
	[qrGeneratedDate] [datetime] NULL,
	[bankAccountNumber] [nvarchar](50) NULL,
	[bankId] [nvarchar](20) NULL,
	[bankAccountName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cannha]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cannha](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[diaChi] [nvarchar](255) NOT NULL,
	[tongSoPhong] [int] NOT NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phong]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phong](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[maPhong] [nvarchar](50) NOT NULL,
	[idCanNha] [int] NOT NULL,
	[idLoaiPhong] [int] NOT NULL,
	[dienTich] [float] NULL,
	[giaThue] [decimal](15, 0) NOT NULL,
	[trangThai] [nvarchar](20) NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[maPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nguoithue]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nguoithue](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hoTen] [nvarchar](100) NOT NULL,
	[soDienThoai] [nvarchar](20) NOT NULL,
	[soCCCD] [nvarchar](20) NULL,
	[email] [nvarchar](100) NULL,
	[ngaySinh] [date] NULL,
	[gioiTinh] [nvarchar](10) NULL,
	[diaChiThuongTru] [nvarchar](255) NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_ThanhToanQR]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_ThanhToanQR] AS
SELECT 
    tb.id AS idThongBao,
    tb.thangNam,
    tb.ngayLap,
    tb.tongTien,
    tb.hanThanhToan,
    tb.trangThaiThanhToan,
    tb.qrCodeUrl,
    tb.qrGeneratedDate,
    tb.daGuiThongBao,
    
    p.id AS idPhong,
    p.maPhong,
    p.giaThue,
    
    cn.diaChi AS diaChiCanNha,
    
    hd.id AS idHopDong,
    hd.soHopDong,
    
    nt.id AS idNguoiThue,
    nt.hoTen AS tenNguoiThue,
    nt.soDienThoai,
    nt.email,
    
    CASE 
        WHEN tb.trangThaiThanhToan = N'Đã thanh toán' THEN 1
        WHEN GETDATE() > tb.hanThanhToan THEN 0
        ELSE NULL 
    END AS trangThaiQuaHan,
    
    DATEDIFF(DAY, GETDATE(), tb.hanThanhToan) AS soNgayConLai

FROM thongbaophi tb
    INNER JOIN hopdong hd ON tb.idHopDong = hd.id
    INNER JOIN phong p ON hd.idPhong = p.id
    INNER JOIN cannha cn ON p.idCanNha = cn.id
    INNER JOIN nguoithue nt ON hd.idNguoiDaiDien = nt.id
WHERE hd.trangThai = N'Đang hiệu lực';
GO
/****** Object:  Table [dbo].[cauhinh]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cauhinh](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenPhi] [nvarchar](100) NOT NULL,
	[maPhi] [nvarchar](50) NOT NULL,
	[giaTri] [decimal](15, 0) NOT NULL,
	[donVi] [nvarchar](20) NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayBatDau] [date] NOT NULL,
	[ngayKetThuc] [date] NULL,
	[trangThai] [bit] NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[maPhi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cauhinhethong]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cauhinhethong](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenCauHinh] [nvarchar](100) NOT NULL,
	[giaTri] [nvarchar](max) NOT NULL,
	[moTa] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[tenCauHinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cauhinhnhanhang]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cauhinhnhanhang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenNganHang] [nvarchar](100) NOT NULL,
	[maNganHang] [nvarchar](20) NOT NULL,
	[soTaiKhoan] [nvarchar](50) NOT NULL,
	[tenTaiKhoan] [nvarchar](100) NOT NULL,
	[qrApiBaseUrl] [nvarchar](255) NULL,
	[logo] [nvarchar](255) NULL,
	[trangThai] [bit] NULL,
	[laMacDinh] [bit] NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chiphiphatsinh]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chiphiphatsinh](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPhong] [int] NULL,
	[tenChiPhi] [nvarchar](100) NOT NULL,
	[soTien] [decimal](15, 0) NOT NULL,
	[ngayChi] [date] NOT NULL,
	[ghiChu] [nvarchar](max) NULL,
	[anhChungTu] [nvarchar](255) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chisodien]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chisodien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPhong] [int] NOT NULL,
	[chiSoCu] [int] NOT NULL,
	[chiSoMoi] [int] NOT NULL,
	[ngayGhi] [date] NOT NULL,
	[anhDongHo] [nvarchar](255) NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chisonuoc]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chisonuoc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPhong] [int] NOT NULL,
	[chiSoCu] [int] NOT NULL,
	[chiSoMoi] [int] NOT NULL,
	[ngayGhi] [date] NOT NULL,
	[anhDongHo] [nvarchar](255) NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitietnguoio]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitietnguoio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idHopDong] [int] NOT NULL,
	[idNguoiThue] [int] NOT NULL,
	[ngayBatDau] [date] NOT NULL,
	[ngayKetThuc] [date] NULL,
	[trangThai] [nvarchar](20) NULL,
	[daXoaVanTay] [bit] NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chitietthongbaophi]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitietthongbaophi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idThongBaoPhi] [int] NOT NULL,
	[tenKhoanPhi] [nvarchar](100) NOT NULL,
	[soLuong] [float] NOT NULL,
	[donGia] [decimal](15, 0) NOT NULL,
	[thanhTien] [decimal](15, 0) NOT NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[danhsachnguoinhan]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[danhsachnguoinhan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hoTen] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NULL,
	[soDienThoai] [nvarchar](20) NULL,
	[zaloId] [nvarchar](100) NULL,
	[loaiNguoiNhan] [nvarchar](20) NULL,
	[trangThai] [bit] NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[filedinhkem]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[filedinhkem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenFile] [nvarchar](255) NOT NULL,
	[duongDan] [nvarchar](500) NOT NULL,
	[loaiFile] [nvarchar](20) NOT NULL,
	[kichThuoc] [bigint] NULL,
	[bangLienKet] [nvarchar](50) NULL,
	[idDoiTuong] [int] NULL,
	[moTa] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lichsugiathue]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lichsugiathue](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPhong] [int] NOT NULL,
	[giaThueCu] [decimal](15, 0) NOT NULL,
	[giaThueMoi] [decimal](15, 0) NOT NULL,
	[ngayApDung] [date] NOT NULL,
	[lyDoThayDoi] [nvarchar](max) NULL,
	[nguoiThayDoi] [nvarchar](100) NULL,
	[ngayTao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lichsuguitb]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lichsuguitb](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idThongBao] [int] NOT NULL,
	[idNguoiNhan] [int] NOT NULL,
	[kenhGui] [nvarchar](20) NOT NULL,
	[trangThai] [nvarchar](20) NULL,
	[thoiGianGui] [datetime] NULL,
	[loiChiTiet] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lichsutaoqr]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lichsutaoqr](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idThongBaoPhi] [int] NOT NULL,
	[idPhong] [int] NOT NULL,
	[qrCodeUrl] [nvarchar](500) NOT NULL,
	[amount] [decimal](15, 0) NOT NULL,
	[message] [nvarchar](500) NULL,
	[n8nRequestId] [nvarchar](100) NULL,
	[n8nResponse] [nvarchar](max) NULL,
	[trangThai] [nvarchar](20) NULL,
	[nguoiTao] [nvarchar](100) NULL,
	[ngayTao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loaiphong]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaiphong](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenLoai] [nvarchar](100) NOT NULL,
	[moTa] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loghoatdong]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loghoatdong](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idNguoiDung] [int] NULL,
	[hoatDong] [nvarchar](255) NOT NULL,
	[bangTacDong] [nvarchar](50) NULL,
	[idDoiTuong] [int] NULL,
	[chiTiet] [nvarchar](max) NULL,
	[ipThucHien] [nvarchar](50) NULL,
	[thoiGian] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nguoidung]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nguoidung](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenDangNhap] [nvarchar](50) NOT NULL,
	[matKhau] [nvarchar](255) NOT NULL,
	[hoTen] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NULL,
	[soDienThoai] [nvarchar](20) NULL,
	[vaiTro] [nvarchar](20) NULL,
	[trangThai] [bit] NULL,
	[lanDangNhapCuoi] [datetime] NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
	[gioiTinh] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[tenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractId] [nvarchar](50) NOT NULL,
	[RoomId] [nvarchar](50) NOT NULL,
	[TenantName] [nvarchar](100) NOT NULL,
	[Period] [nvarchar](50) NOT NULL,
	[Amount] [decimal](15, 0) NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[OrderId] [nvarchar](100) NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[PaidAt] [datetime] NULL,
	[QrCodeUrl] [nvarchar](500) NULL,
	[PaymentLink] [nvarchar](500) NULL,
	[BankCode] [nvarchar](20) NULL,
	[BankName] [nvarchar](100) NULL,
	[TransactionId] [nvarchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[saoluudulieu]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[saoluudulieu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenFile] [nvarchar](255) NOT NULL,
	[duongDan] [nvarchar](500) NOT NULL,
	[kichThuoc] [bigint] NULL,
	[moTa] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[template_thongbao]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[template_thongbao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenTemplate] [nvarchar](100) NOT NULL,
	[loaiTemplate] [nvarchar](20) NOT NULL,
	[tieuDeTemplate] [nvarchar](255) NOT NULL,
	[noiDungTemplate] [nvarchar](max) NOT NULL,
	[cacBienSuDung] [nvarchar](max) NULL,
	[moTa] [nvarchar](max) NULL,
	[trangThai] [bit] NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thanhtoan]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thanhtoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idThongBaoPhi] [int] NOT NULL,
	[ngayThanhToan] [datetime] NOT NULL,
	[soTien] [decimal](15, 0) NOT NULL,
	[phuongThucThanhToan] [nvarchar](50) NOT NULL,
	[ghiChu] [nvarchar](max) NULL,
	[nguoiThu] [nvarchar](100) NULL,
	[anhChungTu] [nvarchar](255) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thongbaohethong]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thongbaohethong](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tieuDe] [nvarchar](255) NOT NULL,
	[noiDung] [nvarchar](max) NOT NULL,
	[loaiThongBao] [nvarchar](20) NULL,
	[kenhGui] [nvarchar](20) NULL,
	[trangThaiGui] [nvarchar](30) NULL,
	[emailGui] [bit] NULL,
	[zaloGui] [bit] NULL,
	[thoiGianGuiEmail] [datetime] NULL,
	[thoiGianGuiZalo] [datetime] NULL,
	[loiEmail] [nvarchar](max) NULL,
	[loiZalo] [nvarchar](max) NULL,
	[daDoc] [bit] NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thongtinvantay]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thongtinvantay](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idNguoiThue] [int] NOT NULL,
	[idHopDong] [int] NOT NULL,
	[trangThai] [nvarchar](20) NULL,
	[ngayCaiDat] [datetime] NULL,
	[ngayXoa] [datetime] NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thongtinxe]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thongtinxe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idNguoiThue] [int] NOT NULL,
	[idHopDong] [int] NOT NULL,
	[loaiXe] [nvarchar](50) NULL,
	[bienSo] [nvarchar](20) NOT NULL,
	[tinhTrangSuDung] [bit] NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thucung]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thucung](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idHopDong] [int] NOT NULL,
	[loaiThuCung] [nvarchar](50) NOT NULL,
	[tenThuCung] [nvarchar](50) NULL,
	[soLuong] [int] NULL,
	[ghiChu] [nvarchar](max) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VietQRConfig]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VietQRConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ConfigKey] [nvarchar](100) NOT NULL,
	[ConfigValue] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ConfigKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[yeucaubaotri]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[yeucaubaotri](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPhong] [int] NOT NULL,
	[nguoiYeuCau] [nvarchar](100) NOT NULL,
	[loaiYeuCau] [nvarchar](100) NOT NULL,
	[moTa] [nvarchar](max) NOT NULL,
	[mucDoUuTien] [nvarchar](20) NULL,
	[trangThai] [nvarchar](20) NULL,
	[ngayYeuCau] [date] NOT NULL,
	[ngayHoanThanh] [date] NULL,
	[chiPhi] [decimal](15, 0) NULL,
	[ghiChu] [nvarchar](max) NULL,
	[anhMinhHoa] [nvarchar](255) NULL,
	[ngayTao] [datetime] NULL,
	[ngayCapNhat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[cannha] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[cannha] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[cauhinh] ADD  DEFAULT ((1)) FOR [trangThai]
GO
ALTER TABLE [dbo].[cauhinh] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[cauhinh] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[cauhinhethong] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[cauhinhethong] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[cauhinhnhanhang] ADD  DEFAULT ('https://img.vietqr.io/image') FOR [qrApiBaseUrl]
GO
ALTER TABLE [dbo].[cauhinhnhanhang] ADD  DEFAULT ((1)) FOR [trangThai]
GO
ALTER TABLE [dbo].[cauhinhnhanhang] ADD  DEFAULT ((0)) FOR [laMacDinh]
GO
ALTER TABLE [dbo].[cauhinhnhanhang] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[cauhinhnhanhang] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[chiphiphatsinh] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[chiphiphatsinh] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[chisodien] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[chisodien] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[chisonuoc] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[chisonuoc] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[chitietnguoio] ADD  DEFAULT (N'Đang ở') FOR [trangThai]
GO
ALTER TABLE [dbo].[chitietnguoio] ADD  DEFAULT ((0)) FOR [daXoaVanTay]
GO
ALTER TABLE [dbo].[chitietnguoio] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[chitietnguoio] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[chitietthongbaophi] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[chitietthongbaophi] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[danhsachnguoinhan] ADD  DEFAULT (N'Người thuê') FOR [loaiNguoiNhan]
GO
ALTER TABLE [dbo].[danhsachnguoinhan] ADD  DEFAULT ((1)) FOR [trangThai]
GO
ALTER TABLE [dbo].[danhsachnguoinhan] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[danhsachnguoinhan] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[filedinhkem] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[filedinhkem] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[hopdong] ADD  DEFAULT (N'Đang hiệu lực') FOR [trangThai]
GO
ALTER TABLE [dbo].[hopdong] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[hopdong] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[lichsugiathue] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[lichsuguitb] ADD  DEFAULT (N'Đang xử lý') FOR [trangThai]
GO
ALTER TABLE [dbo].[lichsuguitb] ADD  DEFAULT (getdate()) FOR [thoiGianGui]
GO
ALTER TABLE [dbo].[lichsutaoqr] ADD  DEFAULT (N'Thành công') FOR [trangThai]
GO
ALTER TABLE [dbo].[lichsutaoqr] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[loaiphong] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[loaiphong] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[loghoatdong] ADD  DEFAULT (getdate()) FOR [thoiGian]
GO
ALTER TABLE [dbo].[nguoidung] ADD  DEFAULT (N'Admin') FOR [vaiTro]
GO
ALTER TABLE [dbo].[nguoidung] ADD  DEFAULT ((1)) FOR [trangThai]
GO
ALTER TABLE [dbo].[nguoidung] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[nguoidung] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[nguoithue] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[nguoithue] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (getdate()) FOR [UpdatedAt]
GO
DECLARE @phongStatusConstraint sysname;
SELECT @phongStatusConstraint = cc.name
FROM sys.check_constraints AS cc
WHERE cc.parent_object_id = OBJECT_ID(N'[dbo].[phong]')
  AND cc.definition LIKE N'%trangThai%';

IF @phongStatusConstraint IS NOT NULL
BEGIN
    EXEC(N'ALTER TABLE [dbo].[phong] DROP CONSTRAINT [' + @phongStatusConstraint + N']');
END
GO

ALTER TABLE [dbo].[phong]  WITH CHECK ADD CONSTRAINT [CK_phong_trangThai] CHECK  (([trangThai]=N'Du kien' OR [trangThai]=N'Dang thue' OR [trangThai]=N'Trong' OR [trangThai]=N'Dang sua' OR [trangThai]=N'Bao tri'));
GO
ALTER TABLE [dbo].[template_thongbao] ADD  DEFAULT ((1)) FOR [trangThai]
GO
ALTER TABLE [dbo].[template_thongbao] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[template_thongbao] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[thanhtoan] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[thanhtoan] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[thongbaohethong] ADD  DEFAULT (N'Thông báo') FOR [loaiThongBao]
GO
ALTER TABLE [dbo].[thongbaohethong] ADD  DEFAULT (N'Email') FOR [kenhGui]
GO
ALTER TABLE [dbo].[thongbaohethong] ADD  DEFAULT (N'Chưa gửi') FOR [trangThaiGui]
GO
ALTER TABLE [dbo].[thongbaohethong] ADD  DEFAULT ((0)) FOR [emailGui]
GO
ALTER TABLE [dbo].[thongbaohethong] ADD  DEFAULT ((0)) FOR [zaloGui]
GO
ALTER TABLE [dbo].[thongbaohethong] ADD  DEFAULT ((0)) FOR [daDoc]
GO
ALTER TABLE [dbo].[thongbaohethong] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[thongbaohethong] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[thongbaophi] ADD  DEFAULT (N'Chưa thanh toán') FOR [trangThaiThanhToan]
GO
ALTER TABLE [dbo].[thongbaophi] ADD  DEFAULT ((0)) FOR [daGuiThongBao]
GO
ALTER TABLE [dbo].[thongbaophi] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[thongbaophi] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[thongbaophi] ADD  DEFAULT ('1031839610') FOR [bankAccountNumber]
GO
ALTER TABLE [dbo].[thongbaophi] ADD  DEFAULT ('970436') FOR [bankId]
GO
ALTER TABLE [dbo].[thongbaophi] ADD  DEFAULT ('PHAM HOAI THUONG') FOR [bankAccountName]
GO
ALTER TABLE [dbo].[thongtinvantay] ADD  DEFAULT (N'Chưa cài đặt') FOR [trangThai]
GO
ALTER TABLE [dbo].[thongtinvantay] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[thongtinvantay] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[thongtinxe] ADD  DEFAULT ((1)) FOR [tinhTrangSuDung]
GO
ALTER TABLE [dbo].[thongtinxe] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[thongtinxe] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[thucung] ADD  DEFAULT ((1)) FOR [soLuong]
GO
ALTER TABLE [dbo].[thucung] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[thucung] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[VietQRConfig] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[VietQRConfig] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[VietQRConfig] ADD  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[yeucaubaotri] ADD  DEFAULT (N'Trung bình') FOR [mucDoUuTien]
GO
ALTER TABLE [dbo].[yeucaubaotri] ADD  DEFAULT (N'Chưa xử lý') FOR [trangThai]
GO
ALTER TABLE [dbo].[yeucaubaotri] ADD  DEFAULT ((0)) FOR [chiPhi]
GO
ALTER TABLE [dbo].[yeucaubaotri] ADD  DEFAULT (getdate()) FOR [ngayTao]
GO
ALTER TABLE [dbo].[yeucaubaotri] ADD  DEFAULT (getdate()) FOR [ngayCapNhat]
GO
ALTER TABLE [dbo].[chiphiphatsinh]  WITH CHECK ADD FOREIGN KEY([idPhong])
REFERENCES [dbo].[phong] ([id])
GO
ALTER TABLE [dbo].[chisodien]  WITH CHECK ADD FOREIGN KEY([idPhong])
REFERENCES [dbo].[phong] ([id])
GO
ALTER TABLE [dbo].[chisonuoc]  WITH CHECK ADD FOREIGN KEY([idPhong])
REFERENCES [dbo].[phong] ([id])
GO
ALTER TABLE [dbo].[chitietnguoio]  WITH CHECK ADD FOREIGN KEY([idHopDong])
REFERENCES [dbo].[hopdong] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chitietnguoio]  WITH CHECK ADD FOREIGN KEY([idNguoiThue])
REFERENCES [dbo].[nguoithue] ([id])
GO
ALTER TABLE [dbo].[chitietthongbaophi]  WITH CHECK ADD FOREIGN KEY([idThongBaoPhi])
REFERENCES [dbo].[thongbaophi] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[hopdong]  WITH CHECK ADD FOREIGN KEY([idNguoiDaiDien])
REFERENCES [dbo].[nguoithue] ([id])
GO
ALTER TABLE [dbo].[hopdong]  WITH CHECK ADD FOREIGN KEY([idPhong])
REFERENCES [dbo].[phong] ([id])
GO
ALTER TABLE [dbo].[lichsugiathue]  WITH CHECK ADD FOREIGN KEY([idPhong])
REFERENCES [dbo].[phong] ([id])
GO
ALTER TABLE [dbo].[lichsuguitb]  WITH CHECK ADD FOREIGN KEY([idNguoiNhan])
REFERENCES [dbo].[danhsachnguoinhan] ([id])
GO
ALTER TABLE [dbo].[lichsuguitb]  WITH CHECK ADD FOREIGN KEY([idThongBao])
REFERENCES [dbo].[thongbaohethong] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[lichsutaoqr]  WITH CHECK ADD FOREIGN KEY([idPhong])
REFERENCES [dbo].[phong] ([id])
GO
ALTER TABLE [dbo].[lichsutaoqr]  WITH CHECK ADD FOREIGN KEY([idThongBaoPhi])
REFERENCES [dbo].[thongbaophi] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[loghoatdong]  WITH CHECK ADD FOREIGN KEY([idNguoiDung])
REFERENCES [dbo].[nguoidung] ([id])
GO


ALTER TABLE [dbo].[thanhtoan]  WITH CHECK ADD FOREIGN KEY([idThongBaoPhi])
REFERENCES [dbo].[thongbaophi] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[thongbaophi]  WITH CHECK ADD FOREIGN KEY([idHopDong])
REFERENCES [dbo].[hopdong] ([id])
GO
ALTER TABLE [dbo].[thongtinvantay]  WITH CHECK ADD FOREIGN KEY([idHopDong])
REFERENCES [dbo].[hopdong] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[thongtinvantay]  WITH CHECK ADD FOREIGN KEY([idNguoiThue])
REFERENCES [dbo].[nguoithue] ([id])
GO
ALTER TABLE [dbo].[thongtinxe]  WITH CHECK ADD FOREIGN KEY([idHopDong])
REFERENCES [dbo].[hopdong] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[thongtinxe]  WITH CHECK ADD FOREIGN KEY([idNguoiThue])
REFERENCES [dbo].[nguoithue] ([id])
GO
ALTER TABLE [dbo].[thucung]  WITH CHECK ADD FOREIGN KEY([idHopDong])
REFERENCES [dbo].[hopdong] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[yeucaubaotri]  WITH CHECK ADD FOREIGN KEY([idPhong])
REFERENCES [dbo].[phong] ([id])
GO
ALTER TABLE [dbo].[chitietnguoio]  WITH CHECK ADD CHECK  (([trangThai]=N'Lịch hẹn trả' OR [trangThai]=N'Đã trả phòng' OR [trangThai]=N'Đang ở'))
GO
ALTER TABLE [dbo].[danhsachnguoinhan]  WITH CHECK ADD CHECK  (([loaiNguoiNhan]=N'Khác' OR [loaiNguoiNhan]=N'Khách hàng' OR [loaiNguoiNhan]=N'Admin' OR [loaiNguoiNhan]=N'Người thuê'))
GO
ALTER TABLE [dbo].[filedinhkem]  WITH CHECK ADD CHECK  (([loaiFile]=N'Khác' OR [loaiFile]=N'Ảnh minh họa' OR [loaiFile]=N'Ảnh đồng hồ' OR [loaiFile]=N'Chứng từ' OR [loaiFile]=N'Hợp đồng'))
GO
ALTER TABLE [dbo].[hopdong]  WITH CHECK ADD CHECK  (([trangThai]=N'Đã hủy' OR [trangThai]=N'Đã kết thúc' OR [trangThai]=N'Đang hiệu lực'))
GO
ALTER TABLE [dbo].[lichsuguitb]  WITH CHECK ADD CHECK  (([kenhGui]=N'Zalo' OR [kenhGui]=N'Email'))
GO
ALTER TABLE [dbo].[lichsuguitb]  WITH CHECK ADD CHECK  (([trangThai]=N'Đang xử lý' OR [trangThai]=N'Thất bại' OR [trangThai]=N'Thành công'))
GO
ALTER TABLE [dbo].[nguoidung]  WITH CHECK ADD CHECK  (([vaiTro]=N'Chủ nhà' OR [vaiTro]=N'Admin'))
GO
ALTER TABLE [dbo].[nguoidung]  WITH CHECK ADD  CONSTRAINT [CK_nguoidung_gioiTinh] CHECK  (([gioiTinh]=N'Nữ' OR [gioiTinh]=N'Nam' OR [gioiTinh] IS NULL))
GO
ALTER TABLE [dbo].[nguoidung] CHECK CONSTRAINT [CK_nguoidung_gioiTinh]
GO
ALTER TABLE [dbo].[nguoithue]  WITH CHECK ADD CHECK  (([gioiTinh]=N'Khác' OR [gioiTinh]=N'Nữ' OR [gioiTinh]=N'Nam'))
GO

ALTER TABLE [dbo].[template_thongbao]  WITH CHECK ADD CHECK  (([loaiTemplate]=N'Cả hai' OR [loaiTemplate]=N'Zalo' OR [loaiTemplate]=N'Email'))
GO
ALTER TABLE [dbo].[thongbaohethong]  WITH CHECK ADD CHECK  (([kenhGui]=N'Cả hai' OR [kenhGui]=N'Zalo' OR [kenhGui]=N'Email'))
GO
ALTER TABLE [dbo].[thongbaohethong]  WITH CHECK ADD CHECK  (([loaiThongBao]=N'Thành công' OR [loaiThongBao]=N'Lỗi' OR [loaiThongBao]=N'Cảnh báo' OR [loaiThongBao]=N'Thông báo'))
GO
ALTER TABLE [dbo].[thongbaohethong]  WITH CHECK ADD CHECK  (([trangThaiGui]=N'Gửi thất bại' OR [trangThaiGui]=N'Đã gửi thành công' OR [trangThaiGui]=N'Đang gửi' OR [trangThaiGui]=N'Chưa gửi'))
GO
ALTER TABLE [dbo].[thongbaophi]  WITH CHECK ADD CHECK  (([trangThaiThanhToan]=N'Đã thanh toán' OR [trangThaiThanhToan]=N'Thanh toán một phần' OR [trangThaiThanhToan]=N'Chưa thanh toán'))
GO
ALTER TABLE [dbo].[thongtinvantay]  WITH CHECK ADD CHECK  (([trangThai]=N'Chưa cài đặt' OR [trangThai]=N'Đã xóa' OR [trangThai]=N'Đã cài đặt'))
GO
ALTER TABLE [dbo].[yeucaubaotri]  WITH CHECK ADD CHECK  (([mucDoUuTien]=N'Khẩn cấp' OR [mucDoUuTien]=N'Cao' OR [mucDoUuTien]=N'Trung bình' OR [mucDoUuTien]=N'Thấp'))
GO
ALTER TABLE [dbo].[yeucaubaotri]  WITH CHECK ADD CHECK  (([trangThai]=N'Đã hủy' OR [trangThai]=N'Hoàn tất' OR [trangThai]=N'Đang xử lý' OR [trangThai]=N'Chưa xử lý'))
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPayments]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetPayments]
    @ContractId NVARCHAR(50) = NULL,
    @Status INT = NULL,
    @FromDate DATETIME = NULL,
    @ToDate DATETIME = NULL
AS
BEGIN
    SELECT Id, ContractId, RoomId, TenantName, Period, Amount, DueDate, 
           Description, OrderId, Status, CreatedAt, PaidAt, QrCodeUrl, PaymentLink,
           BankCode, BankName, TransactionId, UpdatedAt
    FROM Payments
    WHERE (@ContractId IS NULL OR ContractId = @ContractId)
      AND (@Status IS NULL OR Status = @Status)
      AND (@FromDate IS NULL OR CreatedAt >= @FromDate)
      AND (@ToDate IS NULL OR CreatedAt <= @ToDate)
    ORDER BY CreatedAt DESC;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GetVietQRConfig]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetVietQRConfig]
AS
BEGIN
    SELECT ConfigKey, ConfigValue, Description, IsActive
    FROM VietQRConfig
    WHERE IsActive = 1;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_TaoThongBaoPhiThang]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_TaoThongBaoPhiThang]
    @ThangNam NVARCHAR(7) -- Format: MM/YYYY
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @NgayLap DATE = GETDATE();
    DECLARE @HanThanhToan DATE = DATEADD(DAY, 10, @NgayLap);
    
    -- Tạo thông báo cho tất cả hợp đồng đang hiệu lực
    INSERT INTO thongbaophi (
        idHopDong, 
        thangNam, 
        ngayLap, 
        tongTien, 
        hanThanhToan,
        trangThaiThanhToan,
        ghiChu
    )
    SELECT 
        hd.id,
        @ThangNam,
        @NgayLap,
        p.giaThue, -- Tính toán chi tiết sau
        @HanThanhToan,
        N'Chưa thanh toán',
        N'Tự động tạo cho tháng ' + @ThangNam
    FROM hopdong hd
        INNER JOIN phong p ON hd.idPhong = p.id
    WHERE hd.trangThai = N'Đang hiệu lực'
        AND NOT EXISTS (
            SELECT 1 FROM thongbaophi tb 
            WHERE tb.idHopDong = hd.id 
                AND tb.thangNam = @ThangNam
        );
    
    SELECT @@ROWCOUNT AS SoThongBaoTao;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePaymentStatus]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdatePaymentStatus]
    @OrderId NVARCHAR(100),
    @Status INT,
    @PaidAt DATETIME = NULL,
    @BankCode NVARCHAR(20) = NULL,
    @BankName NVARCHAR(100) = NULL,
    @TransactionId NVARCHAR(100) = NULL
AS
BEGIN
    UPDATE Payments 
    SET Status = @Status,
        PaidAt = @PaidAt,
        BankCode = @BankCode,
        BankName = @BankName,
        TransactionId = @TransactionId,
        UpdatedAt = GETDATE()
    WHERE OrderId = @OrderId;
END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateVietQRConfig]    Script Date: 10/26/2025 8:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_UpdateVietQRConfig]
    @ConfigKey NVARCHAR(100),
    @ConfigValue NVARCHAR(500)
AS
BEGIN
    UPDATE VietQRConfig 
    SET ConfigValue = @ConfigValue, UpdatedAt = GETDATE()
    WHERE ConfigKey = @ConfigKey;
    
    IF @@ROWCOUNT = 0
    BEGIN
        INSERT INTO VietQRConfig (ConfigKey, ConfigValue)
        VALUES (@ConfigKey, @ConfigValue);
    END
END

GO


