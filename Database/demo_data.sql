-- Demo data for testing FormTenant
USE [qltn]
GO

-- Insert demo tenant (Nguyen Van A)
IF NOT EXISTS (SELECT 1 FROM nguoithue WHERE soDienThoai = '0901234567')
BEGIN
    INSERT INTO nguoithue (hoTen, soDienThoai, soCCCD, email, ngaySinh, gioiTinh, diaChiThuongTru, ghiChu, ngayTao, ngayCapNhat)
    VALUES (N'Nguyễn Văn A', '0901234567', '079012345678', 'nguyenvana@gmail.com', '1995-06-15', 'Nam', 
            N'123 Đường ABC, Quận 1, TP.HCM', N'Khách hàng demo cho testing', GETDATE(), GETDATE());
END
GO

-- Insert demo tenant (Tran Thi B)
IF NOT EXISTS (SELECT 1 FROM nguoithue WHERE soDienThoai = '0912345678')
BEGIN
    INSERT INTO nguoithue (hoTen, soDienThoai, soCCCD, email, ngaySinh, gioiTinh, diaChiThuongTru, ghiChu, ngayTao, ngayCapNhat)
    VALUES (N'Trần Thị B', '0912345678', '079187654321', 'tranthib@gmail.com', '1998-03-20', 'Nữ', 
            N'456 Đường XYZ, Quận 2, TP.HCM', N'Người thuê có hợp đồng dài hạn', GETDATE(), GETDATE());
END
GO

-- Insert demo tenant (Le Van C)
IF NOT EXISTS (SELECT 1 FROM nguoithue WHERE soDienThoai = '0923456789')
BEGIN
    INSERT INTO nguoithue (hoTen, soDienThoai, soCCCD, email, ngaySinh, gioiTinh, diaChiThuongTru, ghiChu, ngayTao, ngayCapNhat)
    VALUES (N'Lê Văn C', '0923456789', '079098765432', 'levanc@gmail.com', '2000-09-10', 'Nam', 
            N'789 Đường DEF, Quận 3, TP.HCM', N'Khách hàng mới', GETDATE(), GETDATE());
END
GO

-- Get ID of demo tenants
DECLARE @TenantA_ID INT = (SELECT id FROM nguoithue WHERE soDienThoai = '0901234567');
DECLARE @TenantB_ID INT = (SELECT id FROM nguoithue WHERE soDienThoai = '0912345678');
DECLARE @TenantC_ID INT = (SELECT id FROM nguoithue WHERE soDienThoai = '0923456789');

-- Get first available room
DECLARE @Room1_ID INT = (SELECT TOP 1 id FROM phong WHERE trangThai = 'Trong' ORDER BY id);
DECLARE @Room2_ID INT = (SELECT TOP 1 id FROM phong WHERE id != ISNULL(@Room1_ID, 0) AND trangThai = 'Trong' ORDER BY id);
DECLARE @Room3_ID INT = (SELECT TOP 1 id FROM phong WHERE id != ISNULL(@Room1_ID, 0) AND id != ISNULL(@Room2_ID, 0) AND trangThai = 'Trong' ORDER BY id);

-- Insert demo contracts if rooms exist
IF @Room1_ID IS NOT NULL AND @TenantA_ID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM hopdong WHERE idNguoiDaiDien = @TenantA_ID)
BEGIN
    INSERT INTO hopdong (idPhong, idNguoiDaiDien, soHopDong, ngayBatDau, ngayKetThuc, tienCoc, ghiChu, trangThai, ngayTao, ngayCapNhat)
    VALUES (@Room1_ID, @TenantA_ID, 'HD-' + CAST(@Room1_ID AS NVARCHAR) + '-' + FORMAT(GETDATE(), 'yyyyMMddHHmmss'), 
            DATEADD(MONTH, -3, GETDATE()), DATEADD(MONTH, 9, GETDATE()), 5000000, N'Đang hiệu lực', 'Đang hiệu lực', GETDATE(), GETDATE());
END
GO

IF @Room2_ID IS NOT NULL AND @TenantB_ID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM hopdong WHERE idNguoiDaiDien = @TenantB_ID)
BEGIN
    INSERT INTO hopdong (idPhong, idNguoiDaiDien, soHopDong, ngayBatDau, ngayKetThuc, tienCoc, ghiChu, trangThai, ngayTao, ngayCapNhat)
    VALUES (@Room2_ID, @TenantB_ID, 'HD-' + CAST(@Room2_ID AS NVARCHAR) + '-' + FORMAT(GETDATE(), 'yyyyMMddHHmmss'), 
            GETDATE(), DATEADD(MONTH, 12, GETDATE()), 7000000, N'Đang thuê', 'Đang hiệu lực', GETDATE(), GETDATE());
END
GO

IF @Room3_ID IS NOT NULL AND @TenantC_ID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM hopdong WHERE idNguoiDaiDien = @TenantC_ID)
BEGIN
    INSERT INTO hopdong (idPhong, idNguoiDaiDien, soHopDong, ngayBatDau, ngayKetThuc, tienCoc, ghiChu, trangThai, ngayTao, ngayCapNhat)
    VALUES (@Room3_ID, @TenantC_ID, 'HD-' + CAST(@Room3_ID AS NVARCHAR) + '-' + FORMAT(GETDATE(), 'yyyyMMddHHmmss'), 
            DATEADD(MONTH, -12, GETDATE()), DATEADD(MONTH, -1, GETDATE()), 6000000, N'Đã hết hạn', 'Hết hạn', GETDATE(), GETDATE());
END
GO

PRINT 'Demo data inserted successfully!'
GO

