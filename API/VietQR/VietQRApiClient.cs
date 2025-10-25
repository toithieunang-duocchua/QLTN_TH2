using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using QLTN.Models;
using System.Net;
using System.IO;
using System.Drawing;

namespace QLTN.API.VietQR
{
    /// <summary>
    /// Client để tích hợp với VietQR API cho thanh toán qua QR code
    /// Sử dụng cách tiếp cận từ VietQR.io API v2
    /// </summary>
    public class VietQRApiClient
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly string _apiKeyHeader;

        public VietQRApiClient(string apiKey = "", string baseUrl = "https://api.vietqr.io/v2", string apiKeyHeader = "x-client-id")
        {
            _apiKey = apiKey ?? string.Empty;
            _baseUrl = string.IsNullOrWhiteSpace(baseUrl)
                ? "https://api.vietqr.io/v2"
                : baseUrl.TrimEnd('/');
            _apiKeyHeader = string.IsNullOrWhiteSpace(apiKeyHeader)
                ? "x-client-id"
                : apiKeyHeader.Trim();
        }

        /// <summary>
        /// Tạo mã QR thanh toán sử dụng VietQR API v2
        /// </summary>
        /// <param name="request">Thông tin thanh toán</param>
        /// <returns>Thông tin mã QR được tạo</returns>
        public async Task<VietQRResponse> CreatePaymentQRAsync(VietQRRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                });

                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Accept", "application/json");
                    
                    if (!string.IsNullOrEmpty(_apiKey))
                    {
                        client.Headers.Add(_apiKeyHeader, _apiKey);
                    }

                    var response = await client.UploadStringTaskAsync($"{_baseUrl}/generate", "POST", json);
                    var result = JsonConvert.DeserializeObject<VietQRResponse>(response, new JsonSerializerSettings
                    {
                        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                    });
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo mã QR VietQR: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Chuyển đổi Base64 thành Image
        /// </summary>
        /// <param name="base64String">Chuỗi Base64</param>
        /// <returns>Image object</returns>
        public Image Base64ToImage(string base64String)
        {
            try
            {
                // Loại bỏ prefix nếu có
                if (base64String.Contains(","))
                {
                    base64String = base64String.Substring(base64String.IndexOf(",") + 1);
                }

                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    return Image.FromStream(ms, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi chuyển đổi Base64 thành Image: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Lấy danh sách ngân hàng từ VietQR API
        /// </summary>
        /// <returns>Danh sách ngân hàng</returns>
        public async Task<BankResponse> GetBanksAsync()
        {
            try
            {
                using (var client = new WebClient())
                {
                    var response = await client.DownloadStringTaskAsync($"{_baseUrl}/banks");
                    var result = JsonConvert.DeserializeObject<BankResponse>(response, new JsonSerializerSettings
                    {
                        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                    });
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách ngân hàng: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tạo Quicklink VietQR (theo VietQR.io)
        /// </summary>
        /// <param name="bankCode">Mã ngân hàng</param>
        /// <param name="accountNo">Số tài khoản</param>
        /// <param name="amount">Số tiền</param>
        /// <param name="description">Mô tả</param>
        /// <param name="template">Template (compact, compact2, qr_only, print)</param>
        /// <returns>URL Quicklink</returns>
        public string CreateQuicklink(string bankCode, string accountNo, long amount, string description, string template = "compact")
        {
            try
            {
                var quicklinkUrl = $"https://img.vietqr.io/image/{bankCode}-{accountNo}-{template}.jpg";
                
                if (amount > 0)
                {
                    quicklinkUrl += $"?amount={amount}";
                }
                
                if (!string.IsNullOrEmpty(description))
                {
                    var encodedDescription = Uri.EscapeDataString(description);
                    quicklinkUrl += $"&addInfo={encodedDescription}";
                }
                
                return quicklinkUrl;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo Quicklink: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Kiểm tra trạng thái thanh toán
        /// </summary>
        /// <param name="orderId">Mã đơn hàng</param>
        /// <returns>Trạng thái thanh toán</returns>
        public async Task<PaymentStatusResponse> CheckPaymentStatusAsync(string orderId)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add("Accept", "application/json");
                    
                    if (!string.IsNullOrEmpty(_apiKey))
                    {
                        client.Headers.Add(_apiKeyHeader, _apiKey);
                    }

                    var response = await client.DownloadStringTaskAsync($"{_baseUrl}/payment-status/{orderId}");
                    var result = JsonConvert.DeserializeObject<PaymentStatusResponse>(response, new JsonSerializerSettings
                    {
                        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                    });
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra trạng thái thanh toán: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tạo link thanh toán
        /// </summary>
        /// <param name="request">Thông tin thanh toán</param>
        /// <returns>Link thanh toán</returns>
        public async Task<PaymentLinkResponse> CreatePaymentLinkAsync(VietQRRequest request)
        {
            try
            {
                var json = JsonConvert.SerializeObject(request, new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                });

                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Accept", "application/json");
                    
                    if (!string.IsNullOrEmpty(_apiKey))
                    {
                        client.Headers.Add(_apiKeyHeader, _apiKey);
                    }

                    var response = await client.UploadStringTaskAsync($"{_baseUrl}/payment-link", "POST", json);
                    var result = JsonConvert.DeserializeObject<PaymentLinkResponse>(response, new JsonSerializerSettings
                    {
                        ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                    });
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo link thanh toán: {ex.Message}", ex);
            }
        }

        public void Dispose()
        {
            // WebClient không cần dispose
        }
    }
}
