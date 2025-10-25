using System;
using System.Collections.Generic;

namespace QLTN.Models
{
    /// <summary>
    /// Model cho bảng Payments
    /// </summary>
    public class Payment
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        public string Month { get; set; } // Format: yyyy-MM
        public int Amount { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// Model cho bảng PaymentQrHistory
    /// </summary>
    public class PaymentQrHistory
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        public string Month { get; set; }
        public int Amount { get; set; }
        public string BankId { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string Template { get; set; }
        public string Message { get; set; }
        public string QrUrl { get; set; }
        public string SavedPath { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Model cho thông tin ngân hàng
    /// </summary>
    public class BankInfo
    {
        public string Bin { get; set; }
        public string DisplayName { get; set; }
        public bool SupportsTransfer { get; set; }
        public string BankId { get; set; }
        public string BankName { get; set; }
    }

    /// <summary>
    /// Model cho cấu hình VietQR
    /// </summary>
    public class VietQRConfig
    {
        public string BaseUrl { get; set; }
        public string ApiKeyHeader { get; set; }
        public string ApiKey { get; set; }
        public string AcqId { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string Template { get; set; }
        public string MessagePattern { get; set; }
    }

    /// <summary>
    /// Model cho PaymentInfo (compatibility với code cũ)
    /// </summary>
    public class PaymentInfo
    {
        public string ContractId { get; set; }
        public string TenantName { get; set; }
        public string Period { get; set; }
        public int Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string OrderId { get; set; }
        public PaymentStatus Status { get; set; }
        public string QrCodeUrl { get; set; }
        public string PaymentLink { get; set; }
        public DateTime? PaidAt { get; set; }
        public string RoomId { get; set; }
        public string Month { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Model cho VietQRRequest (compatibility với code cũ)
    /// </summary>
    public class VietQRRequest
    {
        public string AcqId { get; set; }
        public string AddInfo { get; set; }
        public long Amount { get; set; }
        public string Format { get; set; }
        public string BankId { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string Template { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// Model cho VietQRResponse (compatibility với code cũ)
    /// </summary>
    public class VietQRResponse
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public VietQRData Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string QrUrl { get; set; }
        public string PaymentId { get; set; }
    }

    /// <summary>
    /// Model cho VietQRData
    /// </summary>
    public class VietQRData
    {
        public string QrCodeUrl { get; set; }
        public string PaymentLink { get; set; }
        public string OrderId { get; set; }
    }

    /// <summary>
    /// Model cho BankResponse (compatibility với code cũ)
    /// </summary>
    public class BankResponse
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public List<BankInfo> Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<BankInfo> Banks { get; set; }
    }

    /// <summary>
    /// Model cho PaymentStatusResponse (compatibility với code cũ)
    /// </summary>
    public class PaymentStatusResponse
    {
        public string Code { get; set; }
        public string Desc { get; set; }
        public PaymentStatusData Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentInfo PaymentInfo { get; set; }
    }

    /// <summary>
    /// Model cho PaymentStatusData
    /// </summary>
    public class PaymentStatusData
    {
        public PaymentStatus Status { get; set; }
        public DateTime? PaidAt { get; set; }
        public string OrderId { get; set; }
    }

    /// <summary>
    /// Model cho PaymentLinkResponse (compatibility với code cũ)
    /// </summary>
    public class PaymentLinkResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string PaymentLink { get; set; }
        public string QrUrl { get; set; }
    }

    /// <summary>
    /// Enum cho PaymentStatus (compatibility với code cũ)
    /// </summary>
    public enum PaymentStatus
    {
        Pending,
        Processing,
        Completed,
        Failed,
        Cancelled,
        Expired
    }
}