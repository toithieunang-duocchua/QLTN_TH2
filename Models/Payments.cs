using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTN.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public string ContractId { get; set; }
        public string RoomId { get; set; }
        public string TenantName { get; set; }
        public string Period { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
        public string OrderId { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public string QrCodeUrl { get; set; }
        public string PaymentLink { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string TransactionId { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

