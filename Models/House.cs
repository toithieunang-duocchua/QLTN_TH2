using System;

namespace QLTN.Models
{
    /// <summary>
    /// DTO đại diện cho một căn nhà trong hệ thống.
    /// </summary>
    public sealed class House
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal? Area { get; set; }
        public int? FloorCount { get; set; }
        public int RoomCount { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
