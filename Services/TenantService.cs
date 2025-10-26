using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLTN.Database;
using QLTN.Models;
using QLTN.Utilities;

namespace QLTN.Services
{
    /// <summary>
    /// Xá»­ lÃ½ nghiá»‡p vá»¥ ngÆ°á»i thuÃª vÃ  há»£p Ä‘á»“ng.
    /// </summary>
    public sealed class TenantService
    {
        private readonly RoomService roomService = new RoomService();

        public IReadOnlyList<Tenant> GetTenantSummaries()
        {
            const string query = @"
SELECT nt.id,
       nt.hoTen,
       nt.soDienThoai,
       nt.soCCCD,
       nt.email,
       nt.ngaySinh,
       nt.gioiTinh,
       nt.diaChiThuongTru,
       nt.ghiChu,
       nt.ngayTao,
       nt.ngayCapNhat,
       hdLatest.id AS ContractId,
       hdLatest.soHopDong,
       hdLatest.ngayBatDau,
       hdLatest.ngayKetThuc,
       hdLatest.trangThai,
       p.maPhong
FROM nguoithue AS nt
OUTER APPLY (
    SELECT TOP 1 hd.id,
                 hd.soHopDong,
                 hd.ngayBatDau,
                 hd.ngayKetThuc,
                 hd.trangThai,
                 hd.idPhong
    FROM hopdong AS hd
    WHERE hd.idNguoiDaiDien = nt.id
    ORDER BY hd.ngayBatDau DESC, hd.id DESC
) AS hdLatest
LEFT JOIN phong AS p ON p.id = hdLatest.idPhong
ORDER BY nt.hoTen";

            DataTable table = DatabaseConnection.Instance.ExecuteQuery(query);
            List<Tenant> tenants = new List<Tenant>(table.Rows.Count);

            foreach (DataRow row in table.Rows)
            {
                tenants.Add(MapTenant(row));
            }

            return tenants;
        }

        public int CreateTenantWithContract(
            Tenant tenant,
            int roomId,
            DateTime contractStart,
            DateTime contractEnd,
            decimal depositAmount,
            string contractNotes = "")
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            if (roomId <= 0)
            {
                throw new ArgumentException("Room id must be valid.", nameof(roomId));
            }

            string fullName = InputSanitizer.Sanitize(tenant.FullName);
            string phoneNumber = InputSanitizer.Sanitize(tenant.PhoneNumber);
            string citizenId = InputSanitizer.Sanitize(tenant.CitizenId);
            string email = InputSanitizer.Sanitize(tenant.Email);

            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be empty.", nameof(tenant.FullName));
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException("Phone number cannot be empty.", nameof(tenant.PhoneNumber));
            }

            using (SqlConnection connection = DatabaseConnection.Instance.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int tenantId = InsertTenant(connection, transaction, fullName, phoneNumber, citizenId, email, tenant);
                        int contractId = InsertContract(connection, transaction, tenantId, roomId, contractStart, contractEnd, depositAmount, contractNotes);
                        UpdateRoomStatus(connection, transaction, roomId, "Dang thue");

                        transaction.Commit();

                        tenant.Id = tenantId;
                        tenant.ContractId = contractId;
                        tenant.ContractStart = contractStart;
                        tenant.ContractEnd = contractEnd;
                        tenant.ContractStatus = "Dang thue";

                        Room room = roomService.GetRoomById(roomId);
                        if (room != null)
                        {
                            tenant.RoomCode = room.Code;
                        }

                        return tenantId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        private static int InsertTenant(
            SqlConnection connection,
            SqlTransaction transaction,
            string fullName,
            string phoneNumber,
            string citizenId,
            string email,
            Tenant tenant)
        {
            const string query = @"
INSERT INTO nguoithue (hoTen, soDienThoai, soCCCD, email, ngaySinh, gioiTinh, diaChiThuongTru, ghiChu)
VALUES (@FullName, @Phone, @CitizenId, @Email, @BirthDate, @Gender, @Address, @Notes);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Phone", phoneNumber);
                command.Parameters.AddWithValue("@CitizenId", string.IsNullOrWhiteSpace(citizenId) ? (object)DBNull.Value : citizenId);
                command.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                command.Parameters.AddWithValue("@BirthDate", tenant.DateOfBirth.HasValue ? (object)tenant.DateOfBirth.Value : DBNull.Value);
                command.Parameters.AddWithValue("@Gender", string.IsNullOrWhiteSpace(tenant.Gender) ? (object)DBNull.Value : tenant.Gender);
                command.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(tenant.PermanentAddress) ? (object)DBNull.Value : tenant.PermanentAddress);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(tenant.Notes) ? (object)DBNull.Value : tenant.Notes);

                object result = command.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        private static int InsertContract(
            SqlConnection connection,
            SqlTransaction transaction,
            int tenantId,
            int roomId,
            DateTime contractStart,
            DateTime contractEnd,
            decimal depositAmount,
            string contractNotes)
        {
            const string query = @"
INSERT INTO hopdong (idPhong, idNguoiDaiDien, soHopDong, ngayBatDau, ngayKetThuc, tienCoc, ghiChu, trangThai)
VALUES (@RoomId, @TenantId, @ContractNumber, @StartDate, @EndDate, @Deposit, @Notes, @Status);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

            string contractNumber = GenerateContractNumber(roomId);

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@RoomId", roomId);
                command.Parameters.AddWithValue("@TenantId", tenantId);
                command.Parameters.AddWithValue("@ContractNumber", contractNumber);
                command.Parameters.AddWithValue("@StartDate", contractStart);
                command.Parameters.AddWithValue("@EndDate", contractEnd);
                command.Parameters.AddWithValue("@Deposit", depositAmount);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(contractNotes) ? (object)DBNull.Value : contractNotes);
                command.Parameters.AddWithValue("@Status", "Dang hieu luc");
                object result = command.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        private static void UpdateRoomStatus(SqlConnection connection, SqlTransaction transaction, int roomId, string status)
        {
            const string query = @"
UPDATE phong
SET trangThai = @Status,
    ngayCapNhat = GETDATE()
WHERE id = @RoomId";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@RoomId", roomId);
                command.ExecuteNonQuery();
            }
        }

        public void EndContract(int contractId, DateTime actualEndDate, string reason)
        {
            using (SqlConnection connection = DatabaseConnection.Instance.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int roomId = GetRoomIdByContract(connection, transaction, contractId);

                        const string updateContract = @"
UPDATE hopdong
SET trangThai = N'Het han',
    ngayKetThuc = @EndDate,
    ngayCapNhat = GETDATE(),
    ghiChu = @Reason
WHERE id = @Id";

                        using (SqlCommand command = new SqlCommand(updateContract, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@EndDate", actualEndDate);
                            command.Parameters.AddWithValue("@Reason", reason ?? string.Empty);
                            command.Parameters.AddWithValue("@Id", contractId);
                            command.ExecuteNonQuery();
                        }

                        UpdateRoomStatus(connection, transaction, roomId, "Trong");
                        transaction.Commit();
                        AuditLogger.LogContractTerminated(contractId);
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void RenewContract(int contractId, DateTime newEndDate, decimal? newRentPrice = null)
        {
            using (SqlConnection connection = DatabaseConnection.Instance.GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        ContractSnapshot snapshot = GetContractSnapshot(connection, transaction, contractId);
                        if (snapshot == null)
                        {
                            throw new InvalidOperationException("Khong tim thay hop dong de gia han.");
                        }

                        const string closeOld = @"
UPDATE hopdong
SET trangThai = N'Het han',
    ngayCapNhat = GETDATE()
WHERE id = @Id";

                        using (SqlCommand command = new SqlCommand(closeOld, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", contractId);
                            command.ExecuteNonQuery();
                        }

                        DateTime newStart = DateTime.Now.Date;
                        DateTime newEnd = newEndDate.Date;
                        if (newEnd <= newStart)
                        {
                            throw new ArgumentException("Ngay ket thuc moi phai sau ngay bat dau.", nameof(newEndDate));
                        }

                        int newContractId = InsertContract(
                            connection,
                            transaction,
                            snapshot.TenantId,
                            snapshot.RoomId,
                            newStart,
                            newEnd,
                            snapshot.Deposit,
                            snapshot.Note);

                        if (newRentPrice.HasValue)
                        {
                            const string updateRent = @"
UPDATE phong
SET giaThue = @Rent,
    ngayCapNhat = GETDATE()
WHERE id = @RoomId";

                            using (SqlCommand rentCommand = new SqlCommand(updateRent, connection, transaction))
                            {
                                rentCommand.Parameters.AddWithValue("@Rent", newRentPrice.Value);
                                rentCommand.Parameters.AddWithValue("@RoomId", snapshot.RoomId);
                                rentCommand.ExecuteNonQuery();
                            }
                        }

                        UpdateRoomStatus(connection, transaction, snapshot.RoomId, "Dang thue");
                        transaction.Commit();
                        AuditLogger.LogActivity("Gia han hop dong", "hopdong", newContractId, $"OldContract={contractId};NewContract={newContractId}");
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public int? GetActiveContractByRoom(int roomId)
        {
            const string query = @"
SELECT id
FROM hopdong
WHERE idPhong = @RoomId
  AND trangThai = N'Dang hieu luc'";

            SqlParameter[] parameters = { new SqlParameter("@RoomId", roomId) };
            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return result == null ? (int?)null : Convert.ToInt32(result);
        }

        private static int GetRoomIdByContract(SqlConnection connection, SqlTransaction transaction, int contractId)
        {
            const string query = "SELECT idPhong FROM hopdong WHERE id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Id", contractId);
                object result = command.ExecuteScalar();
                if (result == null)
                {
                    throw new InvalidOperationException("Khong tim thay hop dong.");
                }

                return Convert.ToInt32(result);
            }
        }

        private static ContractSnapshot GetContractSnapshot(SqlConnection connection, SqlTransaction transaction, int contractId)
        {
            const string query = @"
SELECT TOP 1 idPhong, idNguoiDaiDien, tienCoc, ghiChu
FROM hopdong
WHERE id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Id", contractId);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new ContractSnapshot
                    {
                        RoomId = reader.GetInt32(0),
                        TenantId = reader.GetInt32(1),
                        Deposit = reader.GetDecimal(2),
                        Note = reader.IsDBNull(3) ? null : reader.GetString(3)
                    };
                }
            }
        }

        private static Tenant MapTenant(DataRow row)
        {
            return new Tenant
            {
                Id = row.Field<int>("id"),
                FullName = row.Field<string>("hoTen") ?? string.Empty,
                PhoneNumber = row.Field<string>("soDienThoai") ?? string.Empty,
                CitizenId = row.Field<string>("soCCCD") ?? string.Empty,
                Email = row.Field<string>("email") ?? string.Empty,
                DateOfBirth = row.Field<DateTime?>("ngaySinh"),
                Gender = row.Field<string>("gioiTinh") ?? string.Empty,
                PermanentAddress = row.Field<string>("diaChiThuongTru") ?? string.Empty,
                Notes = row.Field<string>("ghiChu") ?? string.Empty,
                CreatedAt = row.Field<DateTime>("ngayTao"),
                UpdatedAt = row.Field<DateTime?>("ngayCapNhat"),
                ContractId = row.Field<int?>("ContractId"),
                ContractNumber = row.Field<string>("soHopDong") ?? string.Empty,
                ContractStart = row.Field<DateTime?>("ngayBatDau"),
                ContractEnd = row.Field<DateTime?>("ngayKetThuc"),
                ContractStatus = row.Field<string>("trangThai") ?? string.Empty,
                RoomCode = row.Field<string>("maPhong") ?? string.Empty,
                FingerprintStatus = row.Field<string>("ghiChu") ?? string.Empty
            };
        }

        private static string GenerateContractNumber(int roomId)
        {
            return $"HD-{roomId}-{DateTime.Now:yyyyMMddHHmmss}";
        }

        private sealed class ContractSnapshot
        {
            public int RoomId { get; set; }
            public int TenantId { get; set; }
            public decimal Deposit { get; set; }
            public string Note { get; set; }
        }
    }
}






