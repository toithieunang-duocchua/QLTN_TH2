create database quanlythuenha;
go

USE quanlythuenha;
GO

-- ------------------------
-- Bảng căn nhà
-- ------------------------
CREATE TABLE cannha (
    id INT IDENTITY(1,1) PRIMARY KEY,
    diaChi NVARCHAR(255) NOT NULL,
    tongSoPhong INT NOT NULL,
    sotang INT NULL,
    tenTN NVARCHAR(255) NULL,
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO



ALTER TABLE cannha
DROP COLUMN id;

ALTER TABLE cannha
ADD id INT IDENTITY(1,1) PRIMARY KEY;


-- ------------------------
-- Bảng loại phòng
-- ------------------------
CREATE TABLE loaiphong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenLoai NVARCHAR(100) NOT NULL,
    moTa NVARCHAR(MAX) NULL,
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO



-- ------------------------
-- Bảng phòng
-- ------------------------
CREATE TABLE phong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    maPhong NVARCHAR(50) NOT NULL UNIQUE,
    idCanNha INT NOT NULL,
    idLoaiPhong INT NOT NULL,
    dienTich FLOAT NULL,
	soNguoiO int null,
    giaThue DECIMAL(15,0) NOT NULL,
    trangThai NVARCHAR(20) NOT NULL DEFAULT N'Trống',
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Phong_CanNha FOREIGN KEY (idCanNha) REFERENCES cannha(id) ON DELETE CASCADE,
    CONSTRAINT FK_Phong_LoaiPhong FOREIGN KEY (idLoaiPhong) REFERENCES loaiphong(id)
);
GO



ALTER TABLE phong
DROP CONSTRAINT chk_Phong_TrangThai;


-- ------------------------
-- Bảng người thuê
-- ------------------------
CREATE TABLE nguoithue (
    id INT IDENTITY(1,1) PRIMARY KEY,
    hoTen NVARCHAR(100) NOT NULL,
    soDienThoai NVARCHAR(20) NOT NULL,
    soCCCD NVARCHAR(20) NULL,
    email NVARCHAR(100) NULL,
    ngaySinh DATE NULL,
    gioiTinh NVARCHAR(10) NULL,
    diaChiThuongTru NVARCHAR(255) NULL,
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE()
);
GO


CREATE TRIGGER trg_UpdateNguoiThue
ON nguoithue
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE nguoithue
    SET ngayCapNhat = GETDATE()
    FROM inserted i
    WHERE nguoithue.id = i.id;
END;
GO

ALTER TABLE nguoithue
ADD CONSTRAINT chk_NguoiThue_GioiTinh CHECK (gioiTinh IN (N'Nam',N'Nữ',N'Khác'));
GO

-- ------------------------
-- Bảng hợp đồng
-- ------------------------
CREATE TABLE hopdong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT NOT NULL,
    idNguoiDaiDien INT NOT NULL,
    soHopDong NVARCHAR(50) NOT NULL UNIQUE,
    ngayBatDau DATE NOT NULL,
    ngayKetThuc DATE NOT NULL,
    tienCoc DECIMAL(15,0) NOT NULL,
    ghiChu NVARCHAR(MAX) NULL,
    fileHopDong NVARCHAR(255) NULL,
    trangThai NVARCHAR(20) NOT NULL DEFAULT N'Đang hiệu lực',
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_HopDong_Phong FOREIGN KEY (idPhong) REFERENCES phong(id),
    CONSTRAINT FK_HopDong_NguoiThue FOREIGN KEY (idNguoiDaiDien) REFERENCES nguoithue(id)
);
GO

CREATE TRIGGER trg_UpdateHopDong
ON hopdong
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE hopdong
    SET ngayCapNhat = GETDATE()
    FROM inserted i
    WHERE hopdong.id = i.id;
END;
GO

ALTER TABLE hopdong
ADD CONSTRAINT chk_HopDong_TrangThai CHECK (trangThai IN (N'Đang hiệu lực',N'Đã kết thúc',N'Đã hủy'));
GO

-- ------------------------
-- Bảng chi tiết người ở
-- ------------------------
CREATE TABLE chitietnguoio (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idHopDong INT NOT NULL,
    idNguoiThue INT NOT NULL,
    ngayBatDau DATE NOT NULL,
    ngayKetThuc DATE NULL,
    trangThai NVARCHAR(20) NOT NULL DEFAULT N'Đang ở',
    daXoaVanTay BIT DEFAULT 0,
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_ChiTietNguoiO_HopDong FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietNguoiO_NguoiThue FOREIGN KEY (idNguoiThue) REFERENCES nguoithue(id)
);
GO


ALTER TABLE chitietnguoio
ADD CONSTRAINT chk_ChiTietNguoiO_TrangThai CHECK (trangThai IN (N'Đang ở',N'Đã trả phòng',N'Lịch hẹn trả'));
GO

-- ------------------------
-- Bảng thông tin xe
-- ------------------------
CREATE TABLE thongtinxe (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idNguoiThue INT NOT NULL,
    idHopDong INT NOT NULL,
    loaiXe NVARCHAR(50) NULL,
    bienSo NVARCHAR(20) NOT NULL,
    tinhTrangSuDung BIT DEFAULT 1,
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_ThongTinXe_NguoiThue FOREIGN KEY (idNguoiThue) REFERENCES nguoithue(id),
    CONSTRAINT FK_ThongTinXe_HopDong FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE
);
GO


-- ------------------------
-- Bảng thông tin thú cưng
-- ------------------------
CREATE TABLE thucung (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idHopDong INT NOT NULL,
    loaiThuCung NVARCHAR(50) NOT NULL,
    tenThuCung NVARCHAR(50) NULL,
    soLuong INT DEFAULT 1,
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME DEFAULT GETDATE(),
    ngayCapNhat DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_ThuCung_HopDong FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE
);
GO

-- Thông tin vân tay
CREATE TABLE thongtinvantay (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idNguoiThue INT NOT NULL,
    idHopDong INT NOT NULL,
    trangThai NVARCHAR(50) NOT NULL CONSTRAINT chk_thongtinvantay_trangThai CHECK (trangThai IN (N'Đã cài đặt', N'Đã xóa', N'Chưa cài đặt')) DEFAULT N'Chưa cài đặt',
    ngayCaiDat DATETIME2 NULL,
    ngayXoa DATETIME2 NULL,
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (idNguoiThue) REFERENCES nguoithue(id),
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE
);

-- Chỉ số điện
CREATE TABLE chisodien (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT NOT NULL,
    chiSoCu INT NOT NULL,
    chiSoMoi INT NOT NULL,
    ngayGhi DATE NOT NULL,
    anhDongHo NVARCHAR(255) NULL,
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);

-- Chỉ số nước
CREATE TABLE chisonuoc (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT NOT NULL,
    chiSoCu INT NOT NULL,
    chiSoMoi INT NOT NULL,
    ngayGhi DATE NOT NULL,
    anhDongHo NVARCHAR(255) NULL,
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);

-- Cấu hình phí
CREATE TABLE cauhinh (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenPhi NVARCHAR(100) NOT NULL,
    maPhi NVARCHAR(50) NOT NULL CONSTRAINT uq_cauhinh_maPhi UNIQUE,
    giaTri DECIMAL(15, 0) NOT NULL,
    donVi NVARCHAR(20) NULL,
    ghiChu NVARCHAR(MAX) NULL,
    ngayBatDau DATE NOT NULL,
    ngayKetThuc DATE NULL,
    trangThai BIT NOT NULL DEFAULT 1,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Thông báo phí
CREATE TABLE thongbaophi (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idHopDong INT NOT NULL,
    thangNam NVARCHAR(7) NOT NULL,
    ngayLap DATE NOT NULL,
    tongTien DECIMAL(15, 0) NOT NULL,
    hanThanhToan DATE NOT NULL,
    trangThaiThanhToan NVARCHAR(50) NOT NULL CONSTRAINT chk_thongbaophi_trangThaiThanhToan CHECK (trangThaiThanhToan IN (N'Chưa thanh toán', N'Thanh toán một phần', N'Đã thanh toán')) DEFAULT N'Chưa thanh toán',
    filePDF NVARCHAR(255) NULL,
    daGuiThongBao BIT NOT NULL DEFAULT 0,
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id)
);

-- Chi tiết thông báo phí
CREATE TABLE chitietthongbaophi (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idThongBaoPhi INT NOT NULL,
    tenKhoanPhi NVARCHAR(100) NOT NULL,
    soLuong FLOAT NOT NULL,
    donGia DECIMAL(15, 0) NOT NULL,
    thanhTien DECIMAL(15, 0) NOT NULL,
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (idThongBaoPhi) REFERENCES thongbaophi(id) ON DELETE CASCADE
);

-- Thanh toán
CREATE TABLE thanhtoan (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idThongBaoPhi INT NOT NULL,
    ngayThanhToan DATETIME2 NOT NULL,
    soTien DECIMAL(15, 0) NOT NULL,
    phuongThucThanhToan NVARCHAR(50) NOT NULL,
    ghiChu NVARCHAR(MAX) NULL,
    nguoiThu NVARCHAR(100) NULL,
    anhChungTu NVARCHAR(255) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (idThongBaoPhi) REFERENCES thongbaophi(id) ON DELETE CASCADE
);

-- Yêu cầu bảo trì
CREATE TABLE yeucaubaotri (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT NOT NULL,
    nguoiYeuCau NVARCHAR(100) NOT NULL,
    loaiYeuCau NVARCHAR(100) NOT NULL,
    moTa NVARCHAR(MAX) NOT NULL,
    mucDoUuTien NVARCHAR(20) NOT NULL CONSTRAINT chk_yeucaubaotri_mucDoUuTien CHECK (mucDoUuTien IN (N'Thấp', N'Trung bình', N'Cao', N'Khẩn cấp')) DEFAULT N'Trung bình',
    trangThai NVARCHAR(50) NOT NULL CONSTRAINT chk_yeucaubaotri_trangThai CHECK (trangThai IN (N'Chưa xử lý', N'Đang xử lý', N'Hoàn tất', N'Đã hủy')) DEFAULT N'Chưa xử lý',
    ngayYeuCau DATE NOT NULL,
    ngayHoanThanh DATE NULL,
    chiPhi DECIMAL(15, 0) NOT NULL DEFAULT 0,
    ghiChu NVARCHAR(MAX) NULL,
    anhMinhHoa NVARCHAR(255) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);

-- Chi phí phát sinh
CREATE TABLE chiphiphatsinh (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT NULL,
    tenChiPhi NVARCHAR(100) NOT NULL,
    soTien DECIMAL(15, 0) NOT NULL,
    ngayChi DATE NOT NULL,
    ghiChu NVARCHAR(MAX) NULL,
    anhChungTu NVARCHAR(255) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);

-- Người dùng
CREATE TABLE nguoidung (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenDangNhap NVARCHAR(50) NOT NULL CONSTRAINT uq_nguoidung_tenDangNhap UNIQUE,
    matKhau NVARCHAR(255) NOT NULL,
    hoTen NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NULL,
    soDienThoai NVARCHAR(20) NULL,
    vaiTro NVARCHAR(20) NOT NULL DEFAULT N'Admin',
    trangThai BIT NOT NULL DEFAULT 1,
    lanDangNhapCuoi DATETIME2 NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Log hoạt động
CREATE TABLE loghoatdong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idNguoiDung INT NULL,
    hoatDong NVARCHAR(255) NOT NULL,
    bangTacDong NVARCHAR(50) NULL,
    idDoiTuong INT NULL,
    chiTiet NVARCHAR(MAX) NULL,
    ipThucHien NVARCHAR(50) NULL,
    thoiGian DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (idNguoiDung) REFERENCES nguoidung(id)
);

-- Thông báo hệ thống
CREATE TABLE thongbaohethong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tieuDe NVARCHAR(255) NOT NULL,
    noiDung NVARCHAR(MAX) NOT NULL,
    loaiThongBao NVARCHAR(50) NOT NULL CONSTRAINT chk_thongbaohethong_loai CHECK (loaiThongBao IN (N'Thông báo', N'Cảnh báo', N'Lỗi', N'Thành công')) DEFAULT N'Thông báo',
    kenhGui NVARCHAR(20) NOT NULL CONSTRAINT chk_thongbaohethong_kenhGui CHECK (kenhGui IN (N'Email', N'Zalo', N'Cả hai')) DEFAULT N'Email',
    trangThaiGui NVARCHAR(50) NOT NULL CONSTRAINT chk_thongbaohethong_trangThaiGui CHECK (trangThaiGui IN (N'Chưa gửi', N'Đang gửi', N'Đã gửi thành công', N'Gửi thất bại')) DEFAULT N'Chưa gửi',
    emailGui BIT NOT NULL DEFAULT 0,
    zaloGui BIT NOT NULL DEFAULT 0,
    thoiGianGuiEmail DATETIME2 NULL,
    thoiGianGuiZalo DATETIME2 NULL,
    loiEmail NVARCHAR(MAX) NULL,
    loiZalo NVARCHAR(MAX) NULL,
    daDoc BIT NOT NULL DEFAULT 0,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Cấu hình hệ thống
CREATE TABLE cauhinhethong (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenCauHinh NVARCHAR(100) NOT NULL CONSTRAINT uq_cauhinhethong_tenCauHinh UNIQUE,
    giaTri NVARCHAR(MAX) NOT NULL,
    moTa NVARCHAR(MAX) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Lịch sử giá thuê
CREATE TABLE lichsugiathue (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPhong INT NOT NULL,
    giaThueCu DECIMAL(15, 0) NOT NULL,
    giaThueMoi DECIMAL(15, 0) NOT NULL,
    ngayApDung DATE NOT NULL,
    lyDoThayDoi NVARCHAR(MAX) NULL,
    nguoiThayDoi NVARCHAR(100) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);

-- File đính kèm
CREATE TABLE filedinhkem (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenFile NVARCHAR(255) NOT NULL,
    duongDan NVARCHAR(500) NOT NULL,
    loaiFile NVARCHAR(50) NOT NULL CONSTRAINT chk_filedinhkem_loai CHECK (loaiFile IN (N'Hợp đồng', N'Chứng từ', N'Ảnh đồng hồ', N'Ảnh minh họa', N'Khác')),
    kichThuoc BIGINT NULL,
    bangLienKet NVARCHAR(50) NULL,
    idDoiTuong INT NULL,
    moTa NVARCHAR(MAX) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Sao lưu dữ liệu
CREATE TABLE saoluudulieu (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenFile NVARCHAR(255) NOT NULL,
    duongDan NVARCHAR(500) NOT NULL,
    kichThuoc BIGINT NULL,
    moTa NVARCHAR(MAX) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Danh sách người nhận thông báo
CREATE TABLE danhsachnguoinhan (
    id INT IDENTITY(1,1) PRIMARY KEY,
    hoTen NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NULL,
    soDienThoai NVARCHAR(20) NULL,
    zaloId NVARCHAR(100) NULL,
    loaiNguoiNhan NVARCHAR(50) NOT NULL CONSTRAINT chk_danhsachnguoinhan_loai CHECK (loaiNguoiNhan IN (N'Người thuê', N'Admin', N'Khách hàng', N'Khác')) DEFAULT N'Người thuê',
    trangThai BIT NOT NULL DEFAULT 1,
    ghiChu NVARCHAR(MAX) NULL,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Lịch sử gửi thông báo
CREATE TABLE lichsuguitb (
    id INT IDENTITY(1,1) PRIMARY KEY,
    idThongBao INT NOT NULL,
    idNguoiNhan INT NOT NULL,
    kenhGui NVARCHAR(20) NOT NULL CONSTRAINT chk_lichsuguitb_kenhGui CHECK (kenhGui IN (N'Email', N'Zalo')),
    trangThai NVARCHAR(50) NOT NULL CONSTRAINT chk_lichsuguitb_trangThai CHECK (trangThai IN (N'Thành công', N'Thất bại', N'Đang xử lý')) DEFAULT N'Đang xử lý',
    thoiGianGui DATETIME2 NOT NULL DEFAULT GETDATE(),
    loiChiTiet NVARCHAR(MAX) NULL,
    FOREIGN KEY (idThongBao) REFERENCES thongbaohethong(id) ON DELETE CASCADE,
    FOREIGN KEY (idNguoiNhan) REFERENCES danhsachnguoinhan(id)
);

-- Template thông báo
CREATE TABLE template_thongbao (
    id INT IDENTITY(1,1) PRIMARY KEY,
    tenTemplate NVARCHAR(100) NOT NULL,
    loaiTemplate NVARCHAR(20) NOT NULL CONSTRAINT chk_template_thongbao_loai CHECK (loaiTemplate IN (N'Email', N'Zalo', N'Cả hai')),
    tieuDeTemplate NVARCHAR(255) NOT NULL,
    noiDungTemplate NVARCHAR(MAX) NOT NULL,
    cacBienSuDung NVARCHAR(MAX) NULL,
    moTa NVARCHAR(MAX) NULL,
    trangThai BIT NOT NULL DEFAULT 1,
    ngayTao DATETIME2 NOT NULL DEFAULT GETDATE(),
    ngayCapNhat DATETIME2 NOT NULL DEFAULT GETDATE()
);
go


-- ========================================================
--TRIGGER TỰ ĐỘNG
--===========================================================


-- Trigger cho bảng cannha
CREATE TRIGGER trg_UpdateCannha
ON cannha
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE cannha
    SET ngayCapNhat = GETDATE()
    FROM inserted i
    WHERE cannha.id = i.id;
END;
GO

-- Trigger cho bảng loaiphong
CREATE TRIGGER trg_UpdateLoaiPhong
ON loaiphong
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE loaiphong
    SET ngayCapNhat = GETDATE()
    FROM inserted i
    WHERE loaiphong.id = i.id;
END;
GO

-- Trigger cho bảng phong
CREATE TRIGGER trg_UpdatePhong
ON phong
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE phong
    SET ngayCapNhat = GETDATE()
    FROM inserted i
    WHERE phong.id = i.id;
END;
GO

-- Trigger cho bảng chitietnguoio
CREATE TRIGGER trg_UpdateChiTietNguoiO
ON chitietnguoio
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE chitietnguoio
    SET ngayCapNhat = GETDATE()
    FROM inserted i
    WHERE chitietnguoio.id = i.id;
END;
GO

-- Trigger cho bảng thongtinxe
CREATE TRIGGER trg_UpdateThongTinXe
ON thongtinxe
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE thongtinxe
    SET ngayCapNhat = GETDATE()
    FROM inserted i
    WHERE thongtinxe.id = i.id;
END;
GO

-- Trigger cho bảng thucung
CREATE TRIGGER trg_UpdateThuCung
ON thucung
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE thucung
    SET ngayCapNhat = GETDATE()
    FROM inserted i
    WHERE thucung.id = i.id;
END;
GO

-- Trigger cho bảng thongtinvantay
CREATE TRIGGER trg_thongtinvantay_Update_NgayCapNhat
ON thongtinvantay
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET ngayCapNhat = GETDATE()
    FROM thongtinvantay t
    JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng chisodien
CREATE TRIGGER trg_chisodien_Update_NgayCapNhat
ON chisodien
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM chisodien t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng chisonuoc
CREATE TRIGGER trg_chisonuoc_Update_NgayCapNhat
ON chisonuoc
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM chisonuoc t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng cauhinh
CREATE TRIGGER trg_cauhinh_Update_NgayCapNhat
ON cauhinh
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM cauhinh t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng thongbaophi
CREATE TRIGGER trg_thongbaophi_Update_NgayCapNhat
ON thongbaophi
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM thongbaophi t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng chitietthongbaophi
CREATE TRIGGER trg_chitietthongbaophi_Update_NgayCapNhat
ON chitietthongbaophi
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM chitietthongbaophi t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng thanhtoan
CREATE TRIGGER trg_thanhtoan_Update_NgayCapNhat
ON thanhtoan
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM thanhtoan t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng yeucaubaotri
CREATE TRIGGER trg_yeucaubaotri_Update_NgayCapNhat
ON yeucaubaotri
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM yeucaubaotri t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng chiphiphatsinh
CREATE TRIGGER trg_chiphiphatsinh_Update_NgayCapNhat
ON chiphiphatsinh
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM chiphiphatsinh t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng nguoidung
CREATE TRIGGER trg_nguoidung_Update_NgayCapNhat
ON nguoidung
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM nguoidung t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng thongbaohethong
CREATE TRIGGER trg_thongbaohethong_Update_NgayCapNhat
ON thongbaohethong
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM thongbaohethong t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng cauhinhethong
CREATE TRIGGER trg_cauhinhethong_Update_NgayCapNhat
ON cauhinhethong
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM cauhinhethong t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng filedinhkem
CREATE TRIGGER trg_filedinhkem_Update_NgayCapNhat
ON filedinhkem
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM filedinhkem t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng danhsachnguoinhan
CREATE TRIGGER trg_danhsachnguoinhan_Update_NgayCapNhat
ON danhsachnguoinhan
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM danhsachnguoinhan t JOIN inserted i ON t.id = i.id;
END
GO

-- Trigger cho bảng template_thongbao
CREATE TRIGGER trg_template_thongbao_Update_NgayCapNhat
ON template_thongbao
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t SET ngayCapNhat = GETDATE() FROM template_thongbao t JOIN inserted i ON t.id = i.id;
END
GO

