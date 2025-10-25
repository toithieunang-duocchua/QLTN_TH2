using System;
using System.Data.SqlClient;
using QLTN.Database;

namespace QLTN.Services
{
    /// <summary>
    /// Ghi nhận các sự kiện quan trọng để phục vụ audit và truy vết.
    /// </summary>
    public static class AuditLogger
    {
        public static void LogLogin(string phone, bool success)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return;
            }

            const string query = @"
                INSERT INTO loghoatdong (idNguoiDung, hoatDong, bangTacDong, chiTiet, thoiGian)
                VALUES (
                    (SELECT TOP 1 id FROM nguoidung WHERE soDienThoai = @Phone),
                    @Action,
                    'nguoidung',
                    @Detail,
                    GETDATE()
                )";

            var parameters = new[]
            {
                new SqlParameter("@Phone", phone),
                new SqlParameter("@Action", success ? "Đăng nhập thành công" : "Đăng nhập thất bại"),
                new SqlParameter("@Detail", $"Phone: {phone}")
            };

            try
            {
                DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                // Không làm gián đoạn luồng đăng nhập nếu việc ghi log thất bại.
            }
        }

        public static void LogError(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            const string query = @"
                INSERT INTO loghoatdong (idNguoiDung, hoatDong, bangTacDong, chiTiet, thoiGian)
                VALUES (
                    NULL,
                    'Lỗi hệ thống',
                    'system',
                    @Detail,
                    GETDATE()
                )";

            var parameters = new[]
            {
                new SqlParameter("@Detail", message)
            };

            try
            {
                DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            }
            catch (Exception)
            {
                // Không làm gián đoạn luồng chính nếu việc ghi log thất bại.
            }
        }
    }
}
