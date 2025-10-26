using System;

namespace QLTN.Models
{
    /// <summary>
    /// Mô tả một người thuê và thông tin hợp đồng chính đi kèm.
    /// </summary>
    public sealed class Tenant
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string CitizenId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string PermanentAddress { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Contract snapshot
        public int? ContractId { get; set; }
        public string ContractNumber { get; set; } = string.Empty;
        public DateTime? ContractStart { get; set; }
        public DateTime? ContractEnd { get; set; }
        public string ContractStatus { get; set; } = string.Empty;
        public string RoomCode { get; set; } = string.Empty;
        public string FingerprintStatus { get; set; } = string.Empty;
    }
}
