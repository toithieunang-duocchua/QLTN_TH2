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
    /// Business logic xử lý dữ liệu nhà (căn nhà/khu trọ).
    /// </summary>
    public sealed class HouseService
    {
        public IReadOnlyList<House> GetAllHouses()
        {
            const string query = @"
SELECT id, maNha, tenNha, diaChi, dienTich, soTang, tongSoPhong, ghiChu, ngayTao, ngayCapNhat
FROM cannha
ORDER BY tenNha";

            DataTable table = DatabaseConnection.Instance.ExecuteQuery(query);
            List<House> houses = new List<House>(table.Rows.Count);

            foreach (DataRow row in table.Rows)
            {
                houses.Add(MapHouse(row));
            }

            return houses;
        }

        public House GetHouseById(int id)
        {
            const string query = @"
SELECT TOP 1 id, maNha, tenNha, diaChi, dienTich, soTang, tongSoPhong, ghiChu, ngayTao, ngayCapNhat
FROM cannha
WHERE id = @Id";

            SqlParameter[] parameters = { new SqlParameter("@Id", id) };
            DataTable table = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            return table.Rows.Count > 0 ? MapHouse(table.Rows[0]) : null;
        }

        public House GetHouseByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return null;
            }

            const string query = @"
SELECT TOP 1 id, maNha, tenNha, diaChi, dienTich, soTang, tongSoPhong, ghiChu, ngayTao, ngayCapNhat
FROM cannha
WHERE maNha = @Code";

            SqlParameter[] parameters = { new SqlParameter("@Code", InputSanitizer.Sanitize(code)) };
            DataTable table = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            return table.Rows.Count > 0 ? MapHouse(table.Rows[0]) : null;
        }

        public int CreateHouse(House house)
        {
            if (house == null)
            {
                throw new ArgumentNullException(nameof(house));
            }

            string name = InputSanitizer.Sanitize(house.Name);
            string address = InputSanitizer.Sanitize(house.Address);
            string code = string.IsNullOrWhiteSpace(house.Code)
                ? GenerateHouseCode(name)
                : InputSanitizer.Sanitize(house.Code);

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("House name cannot be empty.", nameof(house.Name));
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address cannot be empty.", nameof(house.Address));
            }

            const string query = @"
INSERT INTO cannha (maNha, tenNha, diaChi, dienTich, soTang, tongSoPhong, ghiChu)
VALUES (@Code, @Name, @Address, @Area, @Floors, @RoomCount, @Notes);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Code", code),
                new SqlParameter("@Name", name),
                new SqlParameter("@Address", address),
                new SqlParameter("@Area", house.Area.HasValue ? (object)house.Area.Value : DBNull.Value),
                new SqlParameter("@Floors", house.FloorCount.HasValue ? (object)house.FloorCount.Value : DBNull.Value),
                new SqlParameter("@RoomCount", house.RoomCount),
                new SqlParameter("@Notes", string.IsNullOrWhiteSpace(house.Notes) ? (object)DBNull.Value : house.Notes)
            };

            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            int newId = Convert.ToInt32(result);
            house.Id = newId;
            house.Code = code;
            AuditLogger.LogHouseCreated(house.Id);
            return newId;
        }

        public void UpdateHouse(House house)
        {
            if (house == null)
            {
                throw new ArgumentNullException(nameof(house));
            }

            if (house.Id <= 0)
            {
                throw new ArgumentException("House id must be a positive number.", nameof(house.Id));
            }

            string name = InputSanitizer.Sanitize(house.Name);
            string address = InputSanitizer.Sanitize(house.Address);

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("House name cannot be empty.", nameof(house.Name));
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address cannot be empty.", nameof(house.Address));
            }

            const string query = @"
UPDATE cannha
SET maNha = @Code,
    tenNha = @Name,
    diaChi = @Address,
    dienTich = @Area,
    soTang = @Floors,
    tongSoPhong = @RoomCount,
    ghiChu = @Notes,
    ngayCapNhat = GETDATE()
WHERE id = @Id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", house.Id),
                new SqlParameter("@Code", InputSanitizer.Sanitize(house.Code)),
                new SqlParameter("@Name", name),
                new SqlParameter("@Address", address),
                new SqlParameter("@Area", house.Area.HasValue ? (object)house.Area.Value : DBNull.Value),
                new SqlParameter("@Floors", house.FloorCount.HasValue ? (object)house.FloorCount.Value : DBNull.Value),
                new SqlParameter("@RoomCount", house.RoomCount),
                new SqlParameter("@Notes", string.IsNullOrWhiteSpace(house.Notes) ? (object)DBNull.Value : house.Notes)
            };

            DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
        }

        public void UpdateRoomCountFromRooms(int houseId)
        {
            const string query = @"
UPDATE cannha
SET tongSoPhong = (
    SELECT COUNT(*)
    FROM phong
    WHERE idCanNha = @HouseId
),
    ngayCapNhat = GETDATE()
WHERE id = @HouseId";

            SqlParameter[] parameters = { new SqlParameter("@HouseId", houseId) };
            DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteHouse(int houseId)
        {
            if (houseId <= 0)
            {
                throw new ArgumentException("House id must be positive.", nameof(houseId));
            }

            if (!CanDeleteHouse(houseId))
            {
                throw new InvalidOperationException("Khong the xoa nha co hop dong dang hieu luc.");
            }

            const string query = "DELETE FROM cannha WHERE id = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", houseId) };
            int affected = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
            if (affected > 0)
            {
                AuditLogger.LogActivity("Xoa nha", "cannha", houseId, $"HouseId={houseId}");
            }

            return affected > 0;
        }

        public bool CanDeleteHouse(int houseId)
        {
            const string query = @"
SELECT COUNT(*)
FROM phong p
INNER JOIN hopdong hd ON p.id = hd.idPhong
WHERE p.idCanNha = @HouseId
  AND hd.trangThai = N'Dang hieu luc'";

            SqlParameter[] parameters = { new SqlParameter("@HouseId", houseId) };
            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            int count = Convert.ToInt32(result);
            return count == 0;
        }

        public int GetRoomCountByStatus(int houseId, string status)
        {
            const string query = @"
SELECT COUNT(*)
FROM phong
WHERE idCanNha = @HouseId
  AND trangThai = @Status";

            SqlParameter[] parameters =
            {
                new SqlParameter("@HouseId", houseId),
                new SqlParameter("@Status", status ?? string.Empty)
            };

            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        private static House MapHouse(DataRow row)
        {
            return new House
            {
                Id = row.Field<int>("id"),
                Code = row.Field<string>("maNha") ?? string.Empty,
                Name = row.Field<string>("tenNha") ?? string.Empty,
                Address = row.Field<string>("diaChi") ?? string.Empty,
                Area = row.IsNull("dienTich") ? null : (decimal?)Convert.ToDecimal(row["dienTich"]),
                FloorCount = row.IsNull("soTang") ? null : (int?)Convert.ToInt32(row["soTang"]),
                RoomCount = row.Field<int?>("tongSoPhong") ?? 0,
                Notes = row.Field<string>("ghiChu") ?? string.Empty,
                CreatedAt = row.Field<DateTime>("ngayTao"),
                UpdatedAt = row.Field<DateTime?>("ngayCapNhat")
            };
        }

        private static string GenerateHouseCode(string name)
        {
            string baseCode = "NHA";
            if (!string.IsNullOrWhiteSpace(name))
            {
                baseCode = InputSanitizer.RemoveDiacritics(name)
                    .ToUpperInvariant()
                    .Replace(" ", string.Empty);

                if (baseCode.Length > 8)
                {
                    baseCode = baseCode.Substring(0, 8);
                }
            }

            return $"{baseCode}_{DateTime.Now:yyyyMMddHHmmss}";
        }
    }
}
