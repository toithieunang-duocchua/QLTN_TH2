-- =============================================
-- Script SQL hoàn chỉnh cho SQL Server Management Studio
-- Hệ thống Quản lý Thuê nhà - Chỉ cấu trúc
-- Version: 1.0
-- =============================================

-- Tạo database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QLTN2')
BEGIN
    CREATE DATABASE QLTN2;
END
GO

USE QLTN2;
GO

-- =============================================
-- Xóa các ràng buộc và bảng cũ (nếu có)
-- =============================================
IF OBJECT_ID('dbo.lichsuguitb', 'U') IS NOT NULL DROP TABLE dbo.lichsuguitb;
IF OBJECT_ID('dbo.template_thongbao', 'U') IS NOT NULL DROP TABLE dbo.template_thongbao;
IF OBJECT_ID('dbo.danhsachnguoinhan', 'U') IS NOT NULL DROP TABLE dbo.danhsachnguoinhan;
IF OBJECT_ID('dbo.loghoatdong', 'U') IS NOT NULL DROP TABLE dbo.loghoatdong;
IF OBJECT_ID('dbo.saoluudulieu', 'U') IS NOT NULL DROP TABLE dbo.saoluudulieu;
IF OBJECT_ID('dbo.filedinhkem', 'U') IS NOT NULL DROP TABLE dbo.filedinhkem;
IF OBJECT_ID('dbo.lichsugiathue', 'U') IS NOT NULL DROP TABLE dbo.lichsugiathue;
IF OBJECT_ID('dbo.thanhtoan', 'U') IS NOT NULL DROP TABLE dbo.thanhtoan;
IF OBJECT_ID('dbo.chitietthongbaophi', 'U') IS NOT NULL DROP TABLE dbo.chitietthongbaophi;
IF OBJECT_ID('dbo.thongbaophi', 'U') IS NOT NULL DROP TABLE dbo.thongbaophi;
IF OBJECT_ID('dbo.yeucaubaotri', 'U') IS NOT NULL DROP TABLE dbo.yeucaubaotri;
IF OBJECT_ID('dbo.chiphiphatsinh', 'U') IS NOT NULL DROP TABLE dbo.chiphiphatsinh;
IF OBJECT_ID('dbo.chisodien', 'U') IS NOT NULL DROP TABLE dbo.chisodien;
IF OBJECT_ID('dbo.chisonuoc', 'U') IS NOT NULL DROP TABLE dbo.chisonuoc;
IF OBJECT_ID('dbo.thongtinvantay', 'U') IS NOT NULL DROP TABLE dbo.thongtinvantay;
IF OBJECT_ID('dbo.thucung', 'U') IS NOT NULL DROP TABLE dbo.thucung;
IF OBJECT_ID('dbo.thongtinxe', 'U') IS NOT NULL DROP TABLE dbo.thongtinxe;
IF OBJECT_ID('dbo.chitietnguoio', 'U') IS NOT NULL DROP TABLE dbo.chitietnguoio;
IF OBJECT_ID('dbo.hopdong', 'U') IS NOT NULL DROP TABLE dbo.hopdong;
IF OBJECT_ID('dbo.nguoithue', 'U') IS NOT NULL DROP TABLE dbo.nguoithue;
IF OBJECT_ID('dbo.phong', 'U') IS NOT NULL DROP TABLE dbo.phong;
IF OBJECT_ID('dbo.loaiphong', 'U') IS NOT NULL DROP TABLE dbo.loaiphong;
IF OBJECT_ID('dbo.cannha', 'U') IS NOT NULL DROP TABLE dbo.cannha;
IF OBJECT_ID('dbo.cauhinh', 'U') IS NOT NULL DROP TABLE dbo.cauhinh;
IF OBJECT_ID('dbo.cauhinhethong', 'U') IS NOT NULL DROP TABLE dbo.cauhinhethong;
IF OBJECT_ID('dbo.thongbaohethong', 'U') IS NOT NULL DROP TABLE dbo.thongbaohethong;
IF OBJECT_ID('dbo.nguoidung', 'U') IS NOT NULL DROP TABLE dbo.nguoidung;
GO

-- =============================================
-- TẠO CÁC BẢNG
-- =============================================

-- Bảng Căn nhà
CREATE TABLE cannha (
    id INT IDENTITY(1,1) PRIMARY KEY,
    diaChi NVARCHAR(255) NOT NULL,
    tongSoPhong INT NOT NULL,
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Loại phòng
CREATE TABLE loaiphong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenLoai NVARCHAR(100) NOT NULL,
    moTa NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Phòng
CREATE TABLE phong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    maPhong NVARCHAR(50) NOT NULL UNIQUE,
    idCanNha INT NOT NULL,
    idLoaiPhong INT NOT NULL,
    dienTich FLOAT,
    giaThue DECIMAL(15, 0) NOT NULL,
    trangThai NVARCHAR(20) DEFAULT N'Trống' CHECK (trangThai IN (N'Trống', N'Đang thuê', N'Dự kiến')),
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idCanNha) REFERENCES cannha(id) ON DELETE CASCADE,
    FOREIGN KEY (idLoaiPhong) REFERENCES loaiphong(id)
);
GO

-- Bảng Người thuê
CREATE TABLE nguoithue (
    id INT IDENTITY(1,1) PRIMARY KEY,
    hoTen NVARCHAR(100) NOT NULL,
    soDienThoai NVARCHAR(20) NOT NULL,
    soCCCD NVARCHAR(20),
    email NVARCHAR(100),
    ngaySinh DATE,
    gioiTinh NVARCHAR(10) CHECK (gioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    diaChiThuongTru NVARCHAR(255),
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Hợp đồng
CREATE TABLE hopdong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT NOT NULL,
    idNguoiDaiDien INT NOT NULL,
    soHopDong NVARCHAR(50) NOT NULL UNIQUE,
    ngayBatDau DATE NOT NULL,
    ngayKetThuc DATE NOT NULL,
    tienCoc DECIMAL(15, 0) NOT NULL,
    ghiChu NVARCHAR(MAX),
    fileHopDong NVARCHAR(255),
    trangThai NVARCHAR(20) DEFAULT N'Đang hiệu lực' CHECK (trangThai IN (N'Đang hiệu lực', N'Đã kết thúc', N'Đã hủy')),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idPhong) REFERENCES phong(id),
    FOREIGN KEY (idNguoiDaiDien) REFERENCES nguoithue(id)
);
GO

-- Bảng Chi tiết người ở
CREATE TABLE chitietnguoio (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idHopDong INT NOT NULL,
    idNguoiThue INT NOT NULL,
    ngayBatDau DATE NOT NULL,
    ngayKetThuc DATE,
    trangThai NVARCHAR(20) DEFAULT N'Đang ở' CHECK (trangThai IN (N'Đang ở', N'Đã trả phòng', N'Lịch hẹn trả')),
    daXoaVanTay BIT DEFAULT 0,
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE,
    FOREIGN KEY (idNguoiThue) REFERENCES nguoithue(id)
);
GO

-- Bảng Thông tin xe
CREATE TABLE thongtinxe (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idNguoiThue INT NOT NULL,
    idHopDong INT NOT NULL,
    loaiXe NVARCHAR(50),
    bienSo NVARCHAR(20) NOT NULL,
    tinhTrangSuDung BIT DEFAULT 1,
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idNguoiThue) REFERENCES nguoithue(id),
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE
);
GO

-- Bảng Thông tin thú cưng
CREATE TABLE thucung (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idHopDong INT NOT NULL,
    loaiThuCung NVARCHAR(50) NOT NULL,
    tenThuCung NVARCHAR(50),
    soLuong INT DEFAULT 1,
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE
);
GO

-- Bảng Thông tin vân tay
CREATE TABLE thongtinvantay (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idNguoiThue INT NOT NULL,
    idHopDong INT NOT NULL,
    trangThai NVARCHAR(20) DEFAULT N'Chưa cài đặt' CHECK (trangThai IN (N'Đã cài đặt', N'Đã xóa', N'Chưa cài đặt')),
    ngayCaiDat DATETIME,
    ngayXoa DATETIME,
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idNguoiThue) REFERENCES nguoithue(id),
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE
);
GO

-- Bảng Chỉ số điện
CREATE TABLE chisodien (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT NOT NULL,
    chiSoCu INT NOT NULL,
    chiSoMoi INT NOT NULL,
    ngayGhi DATE NOT NULL,
    anhDongHo NVARCHAR(255),
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);
GO

-- Bảng Chỉ số nước
CREATE TABLE chisonuoc (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT NOT NULL,
    chiSoCu INT NOT NULL,
    chiSoMoi INT NOT NULL,
    ngayGhi DATE NOT NULL,
    anhDongHo NVARCHAR(255),
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);
GO

-- Bảng Cấu hình phí
CREATE TABLE cauhinh (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenPhi NVARCHAR(100) NOT NULL,
    maPhi NVARCHAR(50) NOT NULL UNIQUE,
    giaTri DECIMAL(15, 0) NOT NULL,
    donVi NVARCHAR(20),
    ghiChu NVARCHAR(MAX),
    ngayBatDau DATE NOT NULL,
    ngayKetThuc DATE,
    trangThai BIT DEFAULT 1,
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Thông báo phí
CREATE TABLE thongbaophi (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idHopDong INT NOT NULL,
    thangNam NVARCHAR(7) NOT NULL,
    ngayLap DATE NOT NULL,
    tongTien DECIMAL(15, 0) NOT NULL,
    hanThanhToan DATE NOT NULL,
    trangThaiThanhToan NVARCHAR(30) DEFAULT N'Chưa thanh toán' CHECK (trangThaiThanhToan IN (N'Chưa thanh toán', N'Thanh toán một phần', N'Đã thanh toán')),
    filePDF NVARCHAR(255),
    daGuiThongBao BIT DEFAULT 0,
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id)
);
GO

-- Bảng Chi tiết thông báo phí
CREATE TABLE chitietthongbaophi (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idThongBaoPhi INT NOT NULL,
    tenKhoanPhi NVARCHAR(100) NOT NULL,
    soLuong FLOAT NOT NULL,
    donGia DECIMAL(15, 0) NOT NULL,
    thanhTien DECIMAL(15, 0) NOT NULL,
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idThongBaoPhi) REFERENCES thongbaophi(id) ON DELETE CASCADE
);
GO

-- Bảng Thanh toán
CREATE TABLE thanhtoan (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idThongBaoPhi INT NOT NULL,
    ngayThanhToan DATETIME NOT NULL,
    soTien DECIMAL(15, 0) NOT NULL,
    phuongThucThanhToan NVARCHAR(50) NOT NULL,
    ghiChu NVARCHAR(MAX),
    nguoiThu NVARCHAR(100),
    anhChungTu NVARCHAR(255),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idThongBaoPhi) REFERENCES thongbaophi(id) ON DELETE CASCADE
);
GO

-- Bảng Yêu cầu bảo trì
CREATE TABLE yeucaubaotri (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT NOT NULL,
    nguoiYeuCau NVARCHAR(100) NOT NULL,
    loaiYeuCau NVARCHAR(100) NOT NULL,
    moTa NVARCHAR(MAX) NOT NULL,
    mucDoUuTien NVARCHAR(20) DEFAULT N'Trung bình' CHECK (mucDoUuTien IN (N'Thấp', N'Trung bình', N'Cao', N'Khẩn cấp')),
    trangThai NVARCHAR(20) DEFAULT N'Chưa xử lý' CHECK (trangThai IN (N'Chưa xử lý', N'Đang xử lý', N'Hoàn tất', N'Đã hủy')),
    ngayYeuCau DATE NOT NULL,
    ngayHoanThanh DATE,
    chiPhi DECIMAL(15, 0) DEFAULT 0,
    ghiChu NVARCHAR(MAX),
    anhMinhHoa NVARCHAR(255),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);
GO

-- Bảng Chi phí phát sinh
CREATE TABLE chiphiphatsinh (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT,
    tenChiPhi NVARCHAR(100) NOT NULL,
    soTien DECIMAL(15, 0) NOT NULL,
    ngayChi DATE NOT NULL,
    ghiChu NVARCHAR(MAX),
    anhChungTu NVARCHAR(255),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);
GO

-- Bảng Người dùng
CREATE TABLE nguoidung (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    matKhau NVARCHAR(255) NOT NULL,
    hoTen NVARCHAR(100) NOT NULL,
    email NVARCHAR(100),
    soDienThoai NVARCHAR(20),
    gioiTinh NVARCHAR(10) CHECK (gioiTinh IN (N'Nam', N'Nữ')),
    vaiTro NVARCHAR(20) DEFAULT N'Admin' CHECK (vaiTro IN (N'Admin', N'Chủ nhà')),
    trangThai BIT DEFAULT 1,
    lanDangNhapCuoi DATETIME,
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Log hoạt động
CREATE TABLE loghoatdong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idNguoiDung INT,
    hoatDong NVARCHAR(255) NOT NULL,
    bangTacDong NVARCHAR(50),
    idDoiTuong INT,
    chiTiet NVARCHAR(MAX),
    ipThucHien NVARCHAR(50),
    thoiGian DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idNguoiDung) REFERENCES nguoidung(id)
);
GO

-- Bảng Thông báo hệ thống
CREATE TABLE thongbaohethong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tieuDe NVARCHAR(255) NOT NULL,
    noiDung NVARCHAR(MAX) NOT NULL,
    loaiThongBao NVARCHAR(20) DEFAULT N'Thông báo' CHECK (loaiThongBao IN (N'Thông báo', N'Cảnh báo', N'Lỗi', N'Thành công')),
    kenhGui NVARCHAR(20) DEFAULT N'Email' CHECK (kenhGui = N'Email'),
    trangThaiGui NVARCHAR(30) DEFAULT N'Chưa gửi' CHECK (trangThaiGui IN (N'Chưa gửi', N'Đang gửi', N'Đã gửi thành công', N'Gửi thất bại')),
    emailGui BIT DEFAULT 0,
    thoiGianGuiEmail DATETIME,
    loiEmail NVARCHAR(MAX),
    daDoc BIT DEFAULT 0,
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Cấu hình hệ thống
CREATE TABLE cauhinhethong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenCauHinh NVARCHAR(100) NOT NULL UNIQUE,
    giaTri NVARCHAR(MAX) NOT NULL,
    moTa NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Lịch sử giá thuê
CREATE TABLE lichsugiathue (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT NOT NULL,
    giaThueCu DECIMAL(15, 0) NOT NULL,
    giaThueMoi DECIMAL(15, 0) NOT NULL,
    ngayApDung DATE NOT NULL,
    lyDoThayDoi NVARCHAR(MAX),
    nguoiThayDoi NVARCHAR(100),
    ngayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);
GO

-- Bảng File đính kèm
CREATE TABLE filedinhkem (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenFile NVARCHAR(255) NOT NULL,
    duongDan NVARCHAR(500) NOT NULL,
    loaiFile NVARCHAR(20) NOT NULL CHECK (loaiFile IN (N'Hợp đồng', N'Chứng từ', N'Ảnh đồng hồ', N'Ảnh minh họa', N'Khác')),
    kichThuoc BIGINT,
    bangLienKet NVARCHAR(50),
    idDoiTuong INT,
    moTa NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Sao lưu dữ liệu
CREATE TABLE saoluudulieu (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenFile NVARCHAR(255) NOT NULL,
    duongDan NVARCHAR(500) NOT NULL,
    kichThuoc BIGINT,
    moTa NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Danh sách người nhận thông báo
CREATE TABLE danhsachnguoinhan (
    id INT IDENTITY(1,1) PRIMARY KEY,
    hoTen NVARCHAR(100) NOT NULL,
    email NVARCHAR(100),
    soDienThoai NVARCHAR(20),
    loaiNguoiNhan NVARCHAR(20) DEFAULT N'Người thuê' CHECK (loaiNguoiNhan IN (N'Người thuê', N'Admin', N'Khách hàng', N'Khác')),
    trangThai BIT DEFAULT 1,
    ghiChu NVARCHAR(MAX),
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- Bảng Lịch sử gửi thông báo
CREATE TABLE lichsuguitb (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idThongBao INT NOT NULL,
    idNguoiNhan INT NOT NULL,
    kenhGui NVARCHAR(20) NOT NULL CHECK (kenhGui = N'Email'),
    trangThai NVARCHAR(20) DEFAULT N'Đang xử lý' CHECK (trangThai IN (N'Thành công', N'Thất bại', N'Đang xử lý')),
    thoiGianGui DATETIME DEFAULT GETDATE(),
    loiChiTiet NVARCHAR(MAX),
    FOREIGN KEY (idThongBao) REFERENCES thongbaohethong(id) ON DELETE CASCADE,
    FOREIGN KEY (idNguoiNhan) REFERENCES danhsachnguoinhan(id)
);
GO

-- Bảng Template thông báo
CREATE TABLE template_thongbao (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenTemplate NVARCHAR(100) NOT NULL,
    loaiTemplate NVARCHAR(20) NOT NULL CHECK (loaiTemplate = N'Email'),
    tieuDeTemplate NVARCHAR(255) NOT NULL,
    noiDungTemplate NVARCHAR(MAX) NOT NULL,
    cacBienSuDung NVARCHAR(MAX),
    moTa NVARCHAR(MAX),
    trangThai BIT DEFAULT 1,
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- =============================================
-- TẠO INDEX CHO TỐI ƯU HIỆU SUẤT
-- =============================================

CREATE INDEX idx_phong_trangThai ON phong(trangThai);
CREATE INDEX idx_hopdong_trangThai ON hopdong(trangThai);
CREATE INDEX idx_thongbaophi_thangNam ON thongbaophi(thangNam);
CREATE INDEX idx_thongbaophi_trangThaiThanhToan ON thongbaophi(trangThaiThanhToan);
CREATE INDEX idx_chitietnguoio_trangThai ON chitietnguoio(trangThai);
GO

PRINT 'Database QLTN đã được tạo thành công với 29 bảng!';
PRINT 'Sẵn sàng để sử dụng trên SQL Server Management Studio.';
GO


