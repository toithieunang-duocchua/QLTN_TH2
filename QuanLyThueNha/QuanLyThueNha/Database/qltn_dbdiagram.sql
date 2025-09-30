-- =====================================================
-- DATABASE SCHEMA CHO DBDIAGRAM.IO
-- Quản lý thuê nhà - ERD Diagram
-- =====================================================

-- Căn nhà
CREATE TABLE cannha (
    id INT AUTO_INCREMENT PRIMARY KEY,
    diaChi VARCHAR(255) NOT NULL,
    tongSoPhong INT NOT NULL,
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Loại phòng
CREATE TABLE loaiphong (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tenLoai VARCHAR(100) NOT NULL,
    moTa TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Phòng
CREATE TABLE phong (
    id INT AUTO_INCREMENT PRIMARY KEY,
    maPhong VARCHAR(50) NOT NULL UNIQUE,
    idCanNha INT NOT NULL,
    idLoaiPhong INT NOT NULL,
    dienTich FLOAT,
    giaThue DECIMAL(15, 0) NOT NULL,
    trangThai ENUM('Trống', 'Đang thuê', 'Dự kiến') DEFAULT 'Trống',
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idCanNha) REFERENCES cannha(id) ON DELETE CASCADE,
    FOREIGN KEY (idLoaiPhong) REFERENCES loaiphong(id)
);

-- Người thuê
CREATE TABLE nguoithue (
    id INT AUTO_INCREMENT PRIMARY KEY,
    hoTen VARCHAR(100) NOT NULL,
    soDienThoai VARCHAR(20) NOT NULL,
    soCCCD VARCHAR(20),
    email VARCHAR(100),
    ngaySinh DATE,
    gioiTinh ENUM('Nam', 'Nữ', 'Khác'),
    diaChiThuongTru VARCHAR(255),
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Hợp đồng
CREATE TABLE hopdong (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idPhong INT NOT NULL,
    idNguoiDaiDien INT NOT NULL,
    soHopDong VARCHAR(50) NOT NULL UNIQUE,
    ngayBatDau DATE NOT NULL,
    ngayKetThuc DATE NOT NULL,
    tienCoc DECIMAL(15, 0) NOT NULL,
    ghiChu TEXT,
    fileHopDong VARCHAR(255),
    trangThai ENUM('Đang hiệu lực', 'Đã kết thúc', 'Đã hủy') DEFAULT 'Đang hiệu lực',
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idPhong) REFERENCES phong(id),
    FOREIGN KEY (idNguoiDaiDien) REFERENCES nguoithue(id)
);

-- Chi tiết người ở
CREATE TABLE chitietnguoio (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idHopDong INT NOT NULL,
    idNguoiThue INT NOT NULL,
    ngayBatDau DATE NOT NULL,
    ngayKetThuc DATE,
    trangThai ENUM('Đang ở', 'Đã trả phòng', 'Lịch hẹn trả') DEFAULT 'Đang ở',
    daXoaVanTay BOOLEAN DEFAULT FALSE,
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE,
    FOREIGN KEY (idNguoiThue) REFERENCES nguoithue(id)
);

-- Thông tin xe
CREATE TABLE thongtinxe (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idNguoiThue INT NOT NULL,
    idHopDong INT NOT NULL,
    loaiXe VARCHAR(50),
    bienSo VARCHAR(20) NOT NULL,
    tinhTrangSuDung BOOLEAN DEFAULT TRUE,
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idNguoiThue) REFERENCES nguoithue(id),
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE
);

-- Thông tin thú cưng
CREATE TABLE thucung (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idHopDong INT NOT NULL,
    loaiThuCung VARCHAR(50) NOT NULL,
    tenThuCung VARCHAR(50),
    soLuong INT DEFAULT 1,
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE
);

-- Thông tin vân tay
CREATE TABLE thongtinvantay (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idNguoiThue INT NOT NULL,
    idHopDong INT NOT NULL,
    trangThai ENUM('Đã cài đặt', 'Đã xóa', 'Chưa cài đặt') DEFAULT 'Chưa cài đặt',
    ngayCaiDat DATETIME,
    ngayXoa DATETIME,
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idNguoiThue) REFERENCES nguoithue(id),
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id) ON DELETE CASCADE
);

-- Chỉ số điện
CREATE TABLE chisodien (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idPhong INT NOT NULL,
    chiSoCu INT NOT NULL,
    chiSoMoi INT NOT NULL,
    ngayGhi DATE NOT NULL,
    anhDongHo VARCHAR(255),
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);

-- Chỉ số nước
CREATE TABLE chisonuoc (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idPhong INT NOT NULL,
    chiSoCu INT NOT NULL,
    chiSoMoi INT NOT NULL,
    ngayGhi DATE NOT NULL,
    anhDongHo VARCHAR(255),
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);

-- Cấu hình phí
CREATE TABLE cauhinh (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tenPhi VARCHAR(100) NOT NULL,
    maPhi VARCHAR(50) NOT NULL UNIQUE,
    giaTri DECIMAL(15, 0) NOT NULL,
    donVi VARCHAR(20),
    ghiChu TEXT,
    ngayBatDau DATE NOT NULL,
    ngayKetThuc DATE,
    trangThai BOOLEAN DEFAULT TRUE,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Thông báo phí
CREATE TABLE thongbaophi (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idHopDong INT NOT NULL,
    thangNam VARCHAR(7) NOT NULL,
    ngayLap DATE NOT NULL,
    tongTien DECIMAL(15, 0) NOT NULL,
    hanThanhToan DATE NOT NULL,
    trangThaiThanhToan ENUM('Chưa thanh toán', 'Thanh toán một phần', 'Đã thanh toán') DEFAULT 'Chưa thanh toán',
    filePDF VARCHAR(255),
    daGuiThongBao BOOLEAN DEFAULT FALSE,
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idHopDong) REFERENCES hopdong(id)
);

-- Chi tiết thông báo phí
CREATE TABLE chitietthongbaophi (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idThongBaoPhi INT NOT NULL,
    tenKhoanPhi VARCHAR(100) NOT NULL,
    soLuong FLOAT NOT NULL,
    donGia DECIMAL(15, 0) NOT NULL,
    thanhTien DECIMAL(15, 0) NOT NULL,
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idThongBaoPhi) REFERENCES thongbaophi(id) ON DELETE CASCADE
);

-- Thanh toán
CREATE TABLE thanhtoan (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idThongBaoPhi INT NOT NULL,
    ngayThanhToan DATETIME NOT NULL,
    soTien DECIMAL(15, 0) NOT NULL,
    phuongThucThanhToan VARCHAR(50) NOT NULL,
    ghiChu TEXT,
    nguoiThu VARCHAR(100),
    anhChungTu VARCHAR(255),
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idThongBaoPhi) REFERENCES thongbaophi(id) ON DELETE CASCADE
);

-- Yêu cầu bảo trì
CREATE TABLE yeucaubaotri (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idPhong INT NOT NULL,
    nguoiYeuCau VARCHAR(100) NOT NULL,
    loaiYeuCau VARCHAR(100) NOT NULL,
    moTa TEXT NOT NULL,
    mucDoUuTien ENUM('Thấp', 'Trung bình', 'Cao', 'Khẩn cấp') DEFAULT 'Trung bình',
    trangThai ENUM('Chưa xử lý', 'Đang xử lý', 'Hoàn tất', 'Đã hủy') DEFAULT 'Chưa xử lý',
    ngayYeuCau DATE NOT NULL,
    ngayHoanThanh DATE,
    chiPhi DECIMAL(15, 0) DEFAULT 0,
    ghiChu TEXT,
    anhMinhHoa VARCHAR(255),
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);

-- Chi phí phát sinh
CREATE TABLE chiphiphatsinh (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idPhong INT,
    tenChiPhi VARCHAR(100) NOT NULL,
    soTien DECIMAL(15, 0) NOT NULL,
    ngayChi DATE NOT NULL,
    ghiChu TEXT,
    anhChungTu VARCHAR(255),
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);

-- Người dùng
CREATE TABLE nguoidung (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    matKhau VARCHAR(255) NOT NULL,
    hoTen VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    soDienThoai VARCHAR(20),
    vaiTro ENUM('Admin') DEFAULT 'Admin',
    trangThai BOOLEAN DEFAULT TRUE,
    lanDangNhapCuoi DATETIME,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Log hoạt động
CREATE TABLE loghoatdong (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idNguoiDung INT,
    hoatDong VARCHAR(255) NOT NULL,
    bangTacDong VARCHAR(50),
    idDoiTuong INT,
    chiTiet TEXT,
    ipThucHien VARCHAR(50),
    thoiGian DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idNguoiDung) REFERENCES nguoidung(id)
);

-- Thông báo hệ thống
CREATE TABLE thongbaohethong (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tieuDe VARCHAR(255) NOT NULL,
    noiDung TEXT NOT NULL,
    loaiThongBao ENUM('Thông báo', 'Cảnh báo', 'Lỗi', 'Thành công') DEFAULT 'Thông báo',
    kenhGui ENUM('Email', 'Zalo', 'Cả hai') DEFAULT 'Email',
    trangThaiGui ENUM('Chưa gửi', 'Đang gửi', 'Đã gửi thành công', 'Gửi thất bại') DEFAULT 'Chưa gửi',
    emailGui BOOLEAN DEFAULT FALSE,
    zaloGui BOOLEAN DEFAULT FALSE,
    thoiGianGuiEmail DATETIME,
    thoiGianGuiZalo DATETIME,
    loiEmail TEXT,
    loiZalo TEXT,
    daDoc BOOLEAN DEFAULT FALSE,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Cấu hình hệ thống
CREATE TABLE cauhinhethong (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tenCauHinh VARCHAR(100) NOT NULL UNIQUE,
    giaTri TEXT NOT NULL,
    moTa TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Lịch sử giá thuê
CREATE TABLE lichsugiathue (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idPhong INT NOT NULL,
    giaThueCu DECIMAL(15, 0) NOT NULL,
    giaThueMoi DECIMAL(15, 0) NOT NULL,
    ngayApDung DATE NOT NULL,
    lyDoThayDoi TEXT,
    nguoiThayDoi VARCHAR(100),
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idPhong) REFERENCES phong(id)
);

-- File đính kèm
CREATE TABLE filedinhkem (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tenFile VARCHAR(255) NOT NULL,
    duongDan VARCHAR(500) NOT NULL,
    loaiFile ENUM('Hợp đồng', 'Chứng từ', 'Ảnh đồng hồ', 'Ảnh minh họa', 'Khác') NOT NULL,
    kichThuoc BIGINT,
    bangLienKet VARCHAR(50),
    idDoiTuong INT,
    moTa TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Sao lưu dữ liệu
CREATE TABLE saoluudulieu (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tenFile VARCHAR(255) NOT NULL,
    duongDan VARCHAR(500) NOT NULL,
    kichThuoc BIGINT,
    moTa TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Danh sách người nhận thông báo
CREATE TABLE danhsachnguoinhan (
    id INT AUTO_INCREMENT PRIMARY KEY,
    hoTen VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    soDienThoai VARCHAR(20),
    zaloId VARCHAR(100),
    loaiNguoiNhan ENUM('Người thuê', 'Admin', 'Khách hàng', 'Khác') DEFAULT 'Người thuê',
    trangThai BOOLEAN DEFAULT TRUE,
    ghiChu TEXT,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Lịch sử gửi thông báo
CREATE TABLE lichsuguitb (
    id INT AUTO_INCREMENT PRIMARY KEY,
    idThongBao INT NOT NULL,
    idNguoiNhan INT NOT NULL,
    kenhGui ENUM('Email', 'Zalo') NOT NULL,
    trangThai ENUM('Thành công', 'Thất bại', 'Đang xử lý') DEFAULT 'Đang xử lý',
    thoiGianGui DATETIME DEFAULT CURRENT_TIMESTAMP,
    loiChiTiet TEXT,
    FOREIGN KEY (idThongBao) REFERENCES thongbaohethong(id) ON DELETE CASCADE,
    FOREIGN KEY (idNguoiNhan) REFERENCES danhsachnguoinhan(id)
);

-- Template thông báo
CREATE TABLE template_thongbao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tenTemplate VARCHAR(100) NOT NULL,
    loaiTemplate ENUM('Email', 'Zalo', 'Cả hai') NOT NULL,
    tieuDeTemplate VARCHAR(255) NOT NULL,
    noiDungTemplate TEXT NOT NULL,
    cacBienSuDung TEXT,
    moTa TEXT,
    trangThai BOOLEAN DEFAULT TRUE,
    ngayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    ngayCapNhat DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
