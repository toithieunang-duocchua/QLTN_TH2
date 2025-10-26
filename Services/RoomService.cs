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
    /// Quản lý dữ liệu phòng và các thao tác liên quan.
    /// </summary>
    public sealed class RoomService
    {
        private readonly HouseService houseService = new HouseService();

        public IReadOnlyList<Room> GetRoomsByHouse(int houseId)
        {
            const string query = @"
SELECT p.id,
       p.idCanNha,
       c.maNha,
       p.maPhong,
       p.tang,
       p.dienTich,
       p.giaThue,
       p.trangThai,
       p.noiThat,
       p.ghiChu,
       p.ngayTao,
       p.ngayCapNhat
FROM phong AS p
INNER JOIN cannha AS c ON c.id = p.idCanNha
WHERE p.idCanNha = @HouseId
ORDER BY p.maPhong";

            SqlParameter[] parameters = { new SqlParameter("@HouseId", houseId) };
            DataTable table = DatabaseConnection.Instance.ExecuteQuery(query, parameters);
            List<Room> rooms = new List<Room>(table.Rows.Count);

            foreach (DataRow row in table.Rows)
            {
                rooms.Add(MapRoom(row));
            }

            return rooms;
        }

        public Room GetRoomById(int id)
        {
            const string query = @"
SELECT TOP 1 p.id,
       p.idCanNha,
       c.maNha,
       p.maPhong,
       p.tang,
       p.dienTich,
       p.giaThue,
       p.trangThai,
       p.noiThat,
       p.ghiChu,
       p.ngayTao,
       p.ngayCapNhat
FROM phong AS p
INNER JOIN cannha AS c ON c.id = p.idCanNha
WHERE p.id = @Id";

            SqlParameter[] parameters = { new SqlParameter("@Id", id) };
            DataTable table = DatabaseConnection.Instance.ExecuteQuery(query, parameters);
            return table.Rows.Count > 0 ? MapRoom(table.Rows[0]) : null;
        }

        public Room GetRoomByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return null;
            }

            const string query = @"
SELECT TOP 1 p.id,
       p.idCanNha,
       c.maNha,
       p.maPhong,
       p.tang,
       p.dienTich,
       p.giaThue,
       p.trangThai,
       p.noiThat,
       p.ghiChu,
       p.ngayTao,
       p.ngayCapNhat
FROM phong AS p
INNER JOIN cannha AS c ON c.id = p.idCanNha
WHERE p.maPhong = @Code";

            SqlParameter[] parameters = { new SqlParameter("@Code", InputSanitizer.Sanitize(code)) };
            DataTable table = DatabaseConnection.Instance.ExecuteQuery(query, parameters);
            return table.Rows.Count > 0 ? MapRoom(table.Rows[0]) : null;
        }

        public IReadOnlyList<Room> GetVacantRooms()
        {
            const string query = @"
SELECT p.id,
       p.idCanNha,
       c.maNha,
       p.maPhong,
       p.tang,
       p.dienTich,
       p.giaThue,
       p.trangThai,
       p.noiThat,
       p.ghiChu,
       p.ngayTao,
       p.ngayCapNhat
FROM phong AS p
INNER JOIN cannha AS c ON c.id = p.idCanNha
WHERE p.trangThai = @Status
ORDER BY c.tenNha, p.maPhong";

            SqlParameter[] parameters = { new SqlParameter("@Status", MapStatusToDatabase(RoomStatus.Vacant)) };
            DataTable table = DatabaseConnection.Instance.ExecuteQuery(query, parameters);
            List<Room> rooms = new List<Room>(table.Rows.Count);

            foreach (DataRow row in table.Rows)
            {
                rooms.Add(MapRoom(row));
            }

            return rooms;
        }

        public int CreateRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            if (room.HouseId <= 0)
            {
                throw new ArgumentException("HouseId must be valid.", nameof(room.HouseId));
            }

            string code = string.IsNullOrWhiteSpace(room.Code)
                ? GenerateRoomCode(room.HouseCode, room.Floor)
                : InputSanitizer.Sanitize(room.Code);

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Room code cannot be empty.", nameof(room.Code));
            }

            string status = MapStatusToDatabase(room.Status);

            const string query = @"
INSERT INTO phong (maPhong, idCanNha, idLoaiPhong, tang, dienTich, giaThue, trangThai, noiThat, ghiChu)
VALUES (@Code, @HouseId, @RoomTypeId, @Floor, @Area, @RentPrice, @Status, @Amenities, @Notes);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Code", code),
                new SqlParameter("@HouseId", room.HouseId),
                new SqlParameter("@RoomTypeId", 1), // TODO: expose room type selection
                new SqlParameter("@Floor", room.Floor.HasValue ? (object)room.Floor.Value : DBNull.Value),
                new SqlParameter("@Area", room.Area.HasValue ? (object)room.Area.Value : DBNull.Value),
                new SqlParameter("@RentPrice", room.RentPrice),
                new SqlParameter("@Status", status),
                new SqlParameter("@Amenities", string.IsNullOrWhiteSpace(room.Amenities) ? (object)DBNull.Value : room.Amenities),
                new SqlParameter("@Notes", string.IsNullOrWhiteSpace(room.Notes) ? (object)DBNull.Value : room.Notes)
            };

            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            int newId = Convert.ToInt32(result);

            houseService.UpdateRoomCountFromRooms(room.HouseId);

            room.Id = newId;
            room.Code = code;
            return newId;
        }

        public void UpdateRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            if (room.Id <= 0)
            {
                throw new ArgumentException("Room id must be positive.", nameof(room.Id));
            }

            string code = InputSanitizer.Sanitize(room.Code);
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Room code cannot be empty.", nameof(room.Code));
            }

            string status = MapStatusToDatabase(room.Status);

            const string query = @"
UPDATE phong
SET maPhong = @Code,
    tang = @Floor,
    dienTich = @Area,
    giaThue = @RentPrice,
    trangThai = @Status,
    noiThat = @Amenities,
    ghiChu = @Notes,
    ngayCapNhat = GETDATE()
WHERE id = @Id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", room.Id),
                new SqlParameter("@Code", code),
                new SqlParameter("@Floor", room.Floor.HasValue ? (object)room.Floor.Value : DBNull.Value),
                new SqlParameter("@Area", room.Area.HasValue ? (object)room.Area.Value : DBNull.Value),
                new SqlParameter("@RentPrice", room.RentPrice),
                new SqlParameter("@Status", status),
                new SqlParameter("@Amenities", string.IsNullOrWhiteSpace(room.Amenities) ? (object)DBNull.Value : room.Amenities),
                new SqlParameter("@Notes", string.IsNullOrWhiteSpace(room.Notes) ? (object)DBNull.Value : room.Notes)
            };

            DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
        }

        public void UpdateRoomStatus(int roomId, RoomStatus status)
        {
            const string query = @"
UPDATE phong
SET trangThai = @Status,
    ngayCapNhat = GETDATE()
WHERE id = @Id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", roomId),
                new SqlParameter("@Status", MapStatusToDatabase(status))
            };

            DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
        }

        private static Room MapRoom(DataRow row)
        {
            RoomStatus status = MapStatusFromDatabase(row.Field<string>("trangThai"));

            return new Room
            {
                Id = row.Field<int>("id"),
                HouseId = row.Field<int>("idCanNha"),
                HouseCode = row.Field<string>("maNha") ?? string.Empty,
                Code = row.Field<string>("maPhong") ?? string.Empty,
                Floor = row.IsNull("tang") ? null : (int?)Convert.ToInt32(row["tang"]),
                Area = row.IsNull("dienTich") ? null : (double?)Convert.ToDouble(row["dienTich"]),
                RentPrice = row.IsNull("giaThue") ? 0 : Convert.ToDecimal(row["giaThue"]),
                Status = status,
                Amenities = row.Field<string>("noiThat") ?? string.Empty,
                Notes = row.Field<string>("ghiChu") ?? string.Empty,
                CreatedAt = row.Field<DateTime>("ngayTao"),
                UpdatedAt = row.Field<DateTime?>("ngayCapNhat")
            };
        }

        private static RoomStatus MapStatusFromDatabase(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return RoomStatus.Vacant;
            }

            string normalized = value.Trim().ToLowerInvariant();

            if (normalized.Contains("thue"))
            {
                return RoomStatus.Occupied;
            }

            if (normalized.Contains("du"))
            {
                return RoomStatus.Reserved;
            }

            if (normalized.Contains("sua"))
            {
                return RoomStatus.UnderRepair;
            }

            if (normalized.Contains("bao") || normalized.Contains("tri"))
            {
                return RoomStatus.Maintenance;
            }

            return RoomStatus.Vacant;
        }

        private static string MapStatusToDatabase(RoomStatus status)
        {
            switch (status)
            {
                case RoomStatus.Occupied:
                    return "Dang thue";
                case RoomStatus.Reserved:
                    return "Du kien";
                case RoomStatus.UnderRepair:
                    return "Dang sua";
                case RoomStatus.Maintenance:
                    return "Bao tri";
                default:
                    return "Trong";
            }
        }

        private static string GenerateRoomCode(string houseCode, int? floor)
        {
            string sanitizedHouse = string.IsNullOrWhiteSpace(houseCode)
                ? "PHONG"
                : InputSanitizer.RemoveDiacritics(houseCode).ToUpperInvariant();

            string suffix = floor.HasValue ? floor.Value.ToString("D2") : DateTime.Now.ToString("HHmm");
            return $"{sanitizedHouse}_{suffix}_{DateTime.Now:MMdd}";
        }

        public bool IsRoomOccupied(int roomId)
        {
            const string query = @"
SELECT COUNT(*)
FROM hopdong
WHERE idPhong = @RoomId
  AND trangThai = N'Dang hieu luc'";

            SqlParameter[] parameters = { new SqlParameter("@RoomId", roomId) };
            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public bool IsRoomCodeExists(string roomCode, int excludeRoomId = 0)
        {
            const string query = @"
SELECT COUNT(*)
FROM phong
WHERE maPhong = @Code
  AND (@ExcludeId = 0 OR id <> @ExcludeId)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Code", roomCode ?? string.Empty),
                new SqlParameter("@ExcludeId", excludeRoomId)
            };

            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public bool DeleteRoom(int roomId)
        {
            if (roomId <= 0)
            {
                throw new ArgumentException("Room id must be positive.", nameof(roomId));
            }

            if (IsRoomOccupied(roomId))
            {
                throw new InvalidOperationException("Khong the xoa phong dang cho thue. Vui long ket thuc hop dong truoc.");
            }

            int? houseId = GetHouseIdForRoom(roomId);
            if (houseId == null)
            {
                return false;
            }

            const string query = "DELETE FROM phong WHERE id = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", roomId) };
            int affected = DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);

            if (affected > 0)
            {
                houseService.UpdateRoomCountFromRooms(houseId.Value);
                AuditLogger.LogRoomDeleted(roomId, houseId);
            }

            return affected > 0;
        }

        private static int? GetHouseIdForRoom(int roomId)
        {
            const string query = "SELECT idCanNha FROM phong WHERE id = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", roomId) };
            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return result == null ? (int?)null : Convert.ToInt32(result);
        }
    }
}
