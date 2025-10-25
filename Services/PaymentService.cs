using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using QLTN.Models;
using QLTN.Database;

namespace QLTN.Services
{
    /// <summary>
    /// Service để tạo và quản lý thanh toán VietQR sử dụng n8n free
    /// </summary>
    public sealed class PaymentService : IDisposable
    {
        private readonly VietQRConfig config;
        private readonly DatabaseConnection dbConnection;
        private readonly HttpClient httpClient;

        public PaymentService(VietQRConfig config, DatabaseConnection dbConnection)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            this.httpClient = new HttpClient();
        }

        public async Task<PaymentInfo> CreatePaymentQrAsync(
            string contractId,
            string roomId,
            string tenantName,
            string period,
            decimal amount,
            DateTime dueDate)
        {
            if (string.IsNullOrWhiteSpace(contractId))
            {
                throw new ArgumentException("Contract id is required.", nameof(contractId));
            }

            if (string.IsNullOrWhiteSpace(roomId))
            {
                throw new ArgumentException("Room id is required.", nameof(roomId));
            }

            if (string.IsNullOrWhiteSpace(tenantName))
            {
                throw new ArgumentException("Tenant name is required.", nameof(tenantName));
            }

            if (string.IsNullOrWhiteSpace(period))
            {
                throw new ArgumentException("Period is required.", nameof(period));
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            }

            try
            {
                // Tạo PaymentInfo
                var paymentInfo = new PaymentInfo
                {
                    ContractId = contractId,
                    TenantName = tenantName,
                    Period = period,
                    Amount = (int)amount,
                    DueDate = dueDate,
                    OrderId = GenerateOrderId(),
                    Status = PaymentStatus.Pending,
                    RoomId = roomId,
                    Month = period,
                    Description = $"Thanh toan phong {roomId} thang {period}",
                    CreatedAt = DateTime.Now
                };

                // Tạo VietQR request
                var vietQrRequest = new VietQRRequest
                {
                    AcqId = config.AcqId,
                    AddInfo = FormatMessage(config.MessagePattern, roomId, period, (int)amount),
                    Amount = (long)amount,
                    Format = "text"
                };

                // Gọi n8n webhook để tạo QR
                var qrResponse = await GenerateQrCodeAsync(vietQrRequest);
                
                if (qrResponse.Success)
                {
                    paymentInfo.QrCodeUrl = qrResponse.Data?.QrCodeUrl;
                    paymentInfo.PaymentLink = qrResponse.Data?.PaymentLink;
                }
                else
                {
                    throw new Exception($"Failed to generate QR code: {qrResponse.Desc}");
                }

                // Lưu vào database
                await SavePaymentInfoAsync(paymentInfo);

                return paymentInfo;
            }
            catch (Exception ex)
            {
                AuditLogger.LogError($"Error creating payment QR: {ex.Message}");
                throw;
            }
        }

        public async Task<PaymentStatusResponse> CheckPaymentStatusAsync(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentException("Order ID is required.", nameof(orderId));
            }

            try
            {
                // Gọi n8n webhook để kiểm tra trạng thái
                var statusResponse = await CheckPaymentStatusFromN8nAsync(orderId);
                
                if (statusResponse.Success && statusResponse.Data != null)
                {
                    // Cập nhật database
                    await UpdatePaymentStatusAsync(orderId, statusResponse.Data.Status, statusResponse.Data.PaidAt);
                }

                return statusResponse;
            }
            catch (Exception ex)
            {
                AuditLogger.LogError($"Error checking payment status: {ex.Message}");
                throw;
            }
        }

        public async Task<List<PaymentInfo>> GetPaymentsAsync(string roomId = null, string month = null)
        {
            try
            {
                var payments = new List<PaymentInfo>();
                string query = "SELECT * FROM Payments WHERE 1=1";
                var parameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(roomId))
                {
                    query += " AND RoomId = @RoomId";
                    parameters.Add(new SqlParameter("@RoomId", roomId));
                }

                if (!string.IsNullOrWhiteSpace(month))
                {
                    query += " AND Month = @Month";
                    parameters.Add(new SqlParameter("@Month", month));
                }

                query += " ORDER BY CreatedAt DESC";

                // Execute the synchronous DB call on a background thread to provide real async behavior
                var dataTable = await Task.Run(() => dbConnection.ExecuteQuery(query, parameters.ToArray()));
                
                foreach (System.Data.DataRow row in dataTable.Rows)
                {
                    var payment = new PaymentInfo
                    {
                        ContractId = row["ContractId"]?.ToString(),
                        TenantName = row["TenantName"]?.ToString(),
                        Period = row["Period"]?.ToString(),
                        Amount = Convert.ToInt32(row["Amount"]),
                        DueDate = Convert.ToDateTime(row["DueDate"]),
                        OrderId = row["OrderId"]?.ToString(),
                        Status = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), row["Status"]?.ToString() ?? "Pending"),
                        PaidAt = row["PaidAt"] != DBNull.Value ? Convert.ToDateTime(row["PaidAt"]) : (DateTime?)null,
                        QrCodeUrl = row["QrCodeUrl"]?.ToString(),
                        PaymentLink = row["PaymentLink"]?.ToString(),
                        RoomId = row["RoomId"]?.ToString(),
                        Month = row["Month"]?.ToString(),
                        Description = row["Description"]?.ToString(),
                        CreatedAt = Convert.ToDateTime(row["CreatedAt"])
                    };
                    payments.Add(payment);
                }

                return payments;
            }
            catch (Exception ex)
            {
                AuditLogger.LogError($"Error getting payments: {ex.Message}");
                throw;
            }
        }

        private async Task<VietQRResponse> GenerateQrCodeAsync(VietQRRequest request)
        {
            try
            {
                // Sử dụng n8n webhook free (không cần API key)
                string webhookUrl = $"{config.BaseUrl.TrimEnd('/')}/webhook/vietqr-generate";
                
                var payload = new
                {
                    acqId = request.AcqId,
                    addInfo = request.AddInfo,
                    amount = request.Amount,
                    format = request.Format
                };

                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(webhookUrl, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var qrResponse = JsonConvert.DeserializeObject<VietQRResponse>(responseContent);

                return qrResponse ?? new VietQRResponse { Success = false, Desc = "Invalid response from n8n" };
            }
            catch (Exception ex)
            {
                return new VietQRResponse { Success = false, Desc = ex.Message };
            }
        }

        private async Task<PaymentStatusResponse> CheckPaymentStatusFromN8nAsync(string orderId)
        {
            try
            {
                // Sử dụng n8n webhook free để kiểm tra trạng thái
                string webhookUrl = $"{config.BaseUrl.TrimEnd('/')}/webhook/vietqr-status";
                
                var payload = new { orderId = orderId };
                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(webhookUrl, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var statusResponse = JsonConvert.DeserializeObject<PaymentStatusResponse>(responseContent);

                return statusResponse ?? new PaymentStatusResponse { Success = false, Message = "Invalid response from n8n" };
            }
            catch (Exception ex)
            {
                return new PaymentStatusResponse { Success = false, Message = ex.Message };
            }
        }

        private async Task SavePaymentInfoAsync(PaymentInfo paymentInfo)
        {
            try
            {
                string query = @"INSERT INTO Payments 
                    (ContractId, TenantName, Period, Amount, DueDate, OrderId, Status, 
                     QrCodeUrl, PaymentLink, RoomId, Month, Description, CreatedAt)
                    VALUES 
                    (@ContractId, @TenantName, @Period, @Amount, @DueDate, @OrderId, @Status,
                     @QrCodeUrl, @PaymentLink, @RoomId, @Month, @Description, @CreatedAt)";

                var parameters = new[]
                {
                    new SqlParameter("@ContractId", paymentInfo.ContractId),
                    new SqlParameter("@TenantName", paymentInfo.TenantName),
                    new SqlParameter("@Period", paymentInfo.Period),
                    new SqlParameter("@Amount", paymentInfo.Amount),
                    new SqlParameter("@DueDate", paymentInfo.DueDate),
                    new SqlParameter("@OrderId", paymentInfo.OrderId),
                    new SqlParameter("@Status", paymentInfo.Status.ToString()),
                    new SqlParameter("@QrCodeUrl", paymentInfo.QrCodeUrl ?? (object)DBNull.Value),
                    new SqlParameter("@PaymentLink", paymentInfo.PaymentLink ?? (object)DBNull.Value),
                    new SqlParameter("@RoomId", paymentInfo.RoomId),
                    new SqlParameter("@Month", paymentInfo.Month),
                    new SqlParameter("@Description", paymentInfo.Description),
                    new SqlParameter("@CreatedAt", paymentInfo.CreatedAt)
                };

                await Task.Run(() => dbConnection.ExecuteNonQuery(query, parameters));
            }
            catch (Exception ex)
            {
                AuditLogger.LogError($"Error saving payment info: {ex.Message}");
                throw;
            }
        }

        private async Task UpdatePaymentStatusAsync(string orderId, PaymentStatus status, DateTime? paidAt)
        {
            try
            {
                string query = @"UPDATE Payments 
                    SET Status = @Status, PaidAt = @PaidAt, UpdatedAt = @UpdatedAt
                    WHERE OrderId = @OrderId";

                var parameters = new[]
                {
                    new SqlParameter("@Status", status.ToString()),
                    new SqlParameter("@PaidAt", paidAt ?? (object)DBNull.Value),
                    new SqlParameter("@UpdatedAt", DateTime.Now),
                    new SqlParameter("@OrderId", orderId)
                };

                await Task.Run(() => dbConnection.ExecuteNonQuery(query, parameters));
            }
            catch (Exception ex)
            {
                AuditLogger.LogError($"Error updating payment status: {ex.Message}");
                throw;
            }
        }

        private string GenerateOrderId()
        {
            return $"ORD_{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString("N").Substring(0, 8)}";
        }

        private string FormatMessage(string pattern, string roomId, string month, int amount)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                return $"Thanh toan phong {roomId} thang {month}";

            return pattern
                .Replace("{RoomId}", roomId)
                .Replace("{Month}", month)
                .Replace("{Amount}", amount.ToString());
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}