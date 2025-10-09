CREATE DATABASE quanlythuenha;
GO
USE quanlythuenha;
GO

DELETE FROM thucung;
DELETE FROM thongtinxe;
DELETE FROM chitietnguoio;
DELETE FROM hopdong;
DELETE FROM nguoithue;
DELETE FROM phong;
DELETE FROM loaiphong;
DELETE FROM cannha;

drop table thucung;
drop table thongtinxe;
drop table chitietnguoio;
drop table hopdong;
drop table nguoithue;
drop table phong;
drop table loaiphong;
drop table cannha;



-- 1. Chèn dữ liệu căn nhà
INSERT INTO cannha(diaChi, tongSoPhong, sotang, tenTN, ghiChu)
VALUES 
(N'123 Đường A', 10, 3, N'Căn A', NULL),
(N'456 Đường B', 8, 2, N'Căn B', NULL);


select * from cannha;

-- 2. Chèn dữ liệu loại phòng
INSERT INTO loaiphong(tenLoai, moTa)
VALUES 
(N'Phòng đơn', N'Phòng cho 1 người'),
(N'Phòng đôi', N'Phòng cho 2 người');
drop table loaiphong;
select * from loaiphong;

-- 3. Chèn dữ liệu phòng
INSERT INTO phong(maPhong, idCanNha, idLoaiPhong, dienTich, soNguoiO, giaThue, trangThai)
VALUES
(N'A101', 1, 1, 25.5, 0, 5000000, N'Trống'),
(N'A102', 1, 2, 30.0, 0, 7000000, N'Trống');

-- 4. Chèn người thuê
INSERT INTO nguoithue(hoTen, soDienThoai, gioiTinh)
VALUES
(N'Nguyễn Văn A', '0912345678', N'Nam'),
(N'Lê Thị B', '0987654321', N'Nữ');

-- 5. Chèn hợp đồng
INSERT INTO hopdong(idPhong, idNguoiDaiDien, soHopDong, ngayBatDau, ngayKetThuc, tienCoc, trangThai)
VALUES
(1, 1, N'HD001', '2025-10-01', '2026-10-01', 1000000, N'Đang hiệu lực'),
(2, 2, N'HD002', '2025-10-05', '2026-10-05', 1500000, N'Đang hiệu lực');

-- 6. Chèn chi tiết người ở
INSERT INTO chitietnguoio(idHopDong, idNguoiThue, ngayBatDau, trangThai)
VALUES
(1, 1, '2025-10-01', N'Đang ở'),
(2, 2, '2025-10-05', N'Đang ở');

-- 7. Chèn thông tin xe
INSERT INTO thongtinxe(idNguoiThue, idHopDong, bienSo)
VALUES
(1, 1, N'30A-12345'),
(2, 2, N'29B-67890');

-- 8. Chèn thú cưng
INSERT INTO thucung(idHopDong, loaiThuCung, tenThuCung)
VALUES
(1, N'Mèo', N'Minu'),
(2, N'Chó', N'Boby');


ALTER TABLE phong
DROP CONSTRAINT chk_Phong_TrangThai;
GO

ALTER TABLE phong
ADD CONSTRAINT chk_Phong_TrangThai 
CHECK (trangThai IN (N'Bảo trì', N'Dự kiến', N'Đang thuê', N'Trống'));
GO




--DROP TRIGGER IF EXISTS trg_UpdateCannha;
--DROP TRIGGER IF EXISTS trg_UpdateLoaiPhong;
--DROP TRIGGER IF EXISTS trg_UpdatePhong;
--DROP TRIGGER IF EXISTS trg_UpdateChiTietNguoiO;
--DROP TRIGGER IF EXISTS trg_UpdateThongTinXe;
--DROP TRIGGER IF EXISTS trg_UpdateThuCung;
--DROP TRIGGER IF EXISTS trg_thongtinvantay_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_chisodien_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_chisonuoc_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_cauhinh_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_thongbaophi_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_chitietthongbaophi_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_thanhtoan_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_yeucaubaotri_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_chiphiphatsinh_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_nguoidung_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_thongbaohethong_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_cauhinhethong_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_filedinhkem_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_danhsachnguoinhan_Update_NgayCapNhat;
--DROP TRIGGER IF EXISTS trg_template_thongbao_Update_NgayCapNhat;
--GO



-- Xóa CHECK của bảng phong
ALTER TABLE phong DROP CONSTRAINT IF EXISTS chk_Phong_TrangThai;

-- Xóa CHECK của bảng nguoithue
ALTER TABLE nguoithue DROP CONSTRAINT IF EXISTS chk_NguoiThue_GioiTinh;

-- Xóa CHECK của bảng hopdong
ALTER TABLE hopdong DROP CONSTRAINT IF EXISTS chk_HopDong_TrangThai;

-- Xóa CHECK của bảng chitietnguoio
ALTER TABLE chitietnguoio DROP CONSTRAINT IF EXISTS chk_ChiTietNguoiO_TrangThai;

-- Xóa CHECK của bảng thongtinvantay
ALTER TABLE thongtinvantay DROP CONSTRAINT IF EXISTS chk_thongtinvantay_trangThai;

-- Xóa CHECK của bảng thongbaophi
ALTER TABLE thongbaophi DROP CONSTRAINT IF EXISTS chk_thongbaophi_trangThaiThanhToan;

-- Xóa CHECK của bảng yeucaubaotri
ALTER TABLE yeucaubaotri DROP CONSTRAINT IF EXISTS chk_yeucaubaotri_mucDoUuTien;
ALTER TABLE yeucaubaotri DROP CONSTRAINT IF EXISTS chk_yeucaubaotri_trangThai;

-- Xóa CHECK của bảng filedinhkem
ALTER TABLE filedinhkem DROP CONSTRAINT IF EXISTS chk_filedinhkem_loai;

-- Xóa CHECK của bảng danhsachnguoinhan
ALTER TABLE danhsachnguoinhan DROP CONSTRAINT IF EXISTS chk_danhsachnguoinhan_loai;

-- Xóa CHECK của bảng lichsuguitb
ALTER TABLE lichsuguitb DROP CONSTRAINT IF EXISTS chk_lichsuguitb_kenhGui;
ALTER TABLE lichsuguitb DROP CONSTRAINT IF EXISTS chk_lichsuguitb_trangThai;

-- Xóa CHECK của bảng template_thongbao
ALTER TABLE template_thongbao DROP CONSTRAINT IF EXISTS chk_template_thongbao_loai;

-- Xóa CHECK của bảng thongbaohethong
ALTER TABLE thongbaohethong DROP CONSTRAINT IF EXISTS chk_thongbaohethong_loai;
ALTER TABLE thongbaohethong DROP CONSTRAINT IF EXISTS chk_thongbaohethong_kenhGui;
ALTER TABLE thongbaohethong DROP CONSTRAINT IF EXISTS chk_thongbaohethong_trangThaiGui;
