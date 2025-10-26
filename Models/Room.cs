using System;

namespace QLTN.Models
{
    /// <summary>
    /// Thong tin phong thuoc mot can nha.
    /// </summary>
    public sealed class Room
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public string HouseCode { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int? Floor { get; set; }
        public double? Area { get; set; }
        public decimal RentPrice { get; set; }
        public RoomStatus Status { get; set; } = RoomStatus.Vacant;
        public string Notes { get; set; } = string.Empty;
        public string Amenities { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public enum RoomStatus
    {
        Vacant,        // phong trong
        Occupied,      // dang thue
        Reserved,      // du kien
        UnderRepair,   // dang sua chua
        Maintenance    // bao tri dinh ky
    }
}
