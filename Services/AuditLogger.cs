using System;
using System.Data.SqlClient;
using QLTN.Database;

namespace QLTN.Services
{
    /// <summary>
    /// Ghi nhan hoat dong phuc vu audit.
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

            SqlParameter[] parameters =
            {
                new SqlParameter("@Phone", phone),
                new SqlParameter("@Action", success ? "Dang nhap thanh cong" : "Dang nhap that bai"),
                new SqlParameter("@Detail", $"Phone: {phone}")
            };

            TryExecute(query, parameters);
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
    'Loi he thong',
    'system',
    @Detail,
    GETDATE()
)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Detail", message)
            };

            TryExecute(query, parameters);
        }

        public static void LogActivity(string action, string tableName, int? recordId, string details, string phone = null)
        {
            if (string.IsNullOrWhiteSpace(action) || string.IsNullOrWhiteSpace(tableName))
            {
                return;
            }

            const string query = @"
INSERT INTO loghoatdong (idNguoiDung, hoatDong, bangTacDong, idDoiTuong, chiTiet, thoiGian)
VALUES (
    (SELECT TOP 1 id FROM nguoidung WHERE soDienThoai = @Phone),
    @Action,
    @Table,
    @RecordId,
    @Detail,
    GETDATE()
)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Phone", (object)(phone ?? string.Empty)),
                new SqlParameter("@Action", action),
                new SqlParameter("@Table", tableName),
                new SqlParameter("@RecordId", recordId.HasValue ? (object)recordId.Value : DBNull.Value),
                new SqlParameter("@Detail", details ?? string.Empty)
            };

            TryExecute(query, parameters);
        }

        public static void LogHouseCreated(int houseId)
        {
            LogActivity("Tao nha", "cannha", houseId, $"HouseId={houseId}");
        }

        public static void LogRoomDeleted(int roomId, int? houseId = null)
        {
            string detail = houseId.HasValue ? $"RoomId={roomId};HouseId={houseId}" : $"RoomId={roomId}";
            LogActivity("Xoa phong", "phong", roomId, detail);
        }

        public static void LogContractTerminated(int contractId)
        {
            LogActivity("Ket thuc hop dong", "hopdong", contractId, $"ContractId={contractId}");
        }

        private static void TryExecute(string query, SqlParameter[] parameters)
        {
            try
            {
                DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            }
            catch
            {
                // Khong lam gian luong chinh neu viec ghi log that bai.
            }
        }
    }
}
