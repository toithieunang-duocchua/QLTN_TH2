# Hệ thống QLTN

## Cài đặt và chạy

1. **Chạy file SQL:** Mở `qltn_main.sql` trong SQL Server Management Studio để tạo database QLTN2

2. **Tạo tài khoản admin:**
```sql
INSERT INTO nguoidung (tenDangNhap, matKhau, hoTen, email, soDienThoai, vaiTro, trangThai, ngayTao, ngayCapNhat)
VALUES ('admin', 'Admin@123', 'Admin User', 'admin@example.com', '0708624193', 'Admin', 1, GETDATE(), GETDATE());
```

3. **Build và chạy:** Mở `QLTN.sln` trong Visual Studio và chạy

## Tài khoản demo
- **Số điện thoại:** 0708624193
- **Mật khẩu:** Admin@123
- **Mã xác minh:** 123456

