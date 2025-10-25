using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using QLTN.Models;

namespace QLTN.API.N8n
{
    /// <summary>
    /// Client để giao tiếp với n8n webhook free (không cần API key)
    /// </summary>
    public sealed class N8nVietQRClient : IDisposable
    {
        private readonly HttpClient httpClient;

        public N8nVietQRClient()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<VietQRResponse> GenerateQrCodeAsync(VietQRRequest request)
        {
            try
            {
                // Sử dụng n8n webhook free
                string webhookUrl = "https://terrykozte.app.n8n.cloud/webhook/vietqr-generate";
                
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

                return qrResponse ?? new VietQRResponse 
                { 
                    Success = false, 
                    Desc = "Invalid response from n8n" 
                };
            }
            catch (Exception ex)
            {
                return new VietQRResponse 
                { 
                    Success = false, 
                    Desc = ex.Message 
                };
            }
        }

        public async Task<PaymentStatusResponse> CheckPaymentStatusAsync(string orderId)
        {
            try
            {
                // Sử dụng n8n webhook free để kiểm tra trạng thái
                string webhookUrl = "https://terrykozte.app.n8n.cloud/webhook/vietqr-status";
                
                var payload = new { orderId = orderId };
                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(webhookUrl, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var statusResponse = JsonConvert.DeserializeObject<PaymentStatusResponse>(responseContent);

                return statusResponse ?? new PaymentStatusResponse 
                { 
                    Success = false, 
                    Message = "Invalid response from n8n" 
                };
            }
            catch (Exception ex)
            {
                return new PaymentStatusResponse 
                { 
                    Success = false, 
                    Message = ex.Message 
                };
            }
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}