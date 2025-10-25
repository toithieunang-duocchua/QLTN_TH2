using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using QLTN.Models;

namespace QLTN.Services
{
    /// <summary>
    /// Service để lấy danh sách ngân hàng từ n8n free
    /// </summary>
    public sealed class VietQRBankService : IDisposable
    {
        private readonly VietQRConfig config;
        private readonly HttpClient httpClient;

        public VietQRBankService(VietQRConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.httpClient = new HttpClient();
        }

        public async Task<BankResponse> GetBanksAsync()
        {
            try
            {
                // Sử dụng n8n webhook free để lấy danh sách ngân hàng
                string webhookUrl = $"{config.BaseUrl.TrimEnd('/')}/webhook/bank-list";
                
                var response = await httpClient.GetAsync(webhookUrl);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var bankResponse = JsonConvert.DeserializeObject<BankResponse>(responseContent);

                return bankResponse ?? new BankResponse 
                { 
                    Success = false, 
                    Message = "Invalid response from n8n",
                    Data = new List<BankInfo>(),
                    Banks = new List<BankInfo>()
                };
            }
            catch (Exception ex)
            {
                return new BankResponse 
                { 
                    Success = false, 
                    Message = ex.Message,
                    Data = new List<BankInfo>(),
                    Banks = new List<BankInfo>()
                };
            }
        }

        public async Task<BankResponse> GetBanksWithTransferSupportAsync()
        {
            try
            {
                var banksResponse = await GetBanksAsync();
                
                if (banksResponse.Success && banksResponse.Data != null)
                {
                    // Lọc chỉ những ngân hàng hỗ trợ chuyển khoản
                    var supportedBanks = new List<BankInfo>();
                    foreach (var bank in banksResponse.Data)
                    {
                        if (bank.SupportsTransfer)
                        {
                            supportedBanks.Add(bank);
                        }
                    }

                    return new BankResponse
                    {
                        Success = true,
                        Message = "Success",
                        Data = supportedBanks,
                        Banks = supportedBanks
                    };
                }

                return banksResponse;
            }
            catch (Exception ex)
            {
                return new BankResponse 
                { 
                    Success = false, 
                    Message = ex.Message,
                    Data = new List<BankInfo>(),
                    Banks = new List<BankInfo>()
                };
            }
        }

        public List<BankInfo> GetDefaultBanks()
        {
            // Danh sách ngân hàng mặc định nếu không kết nối được n8n
            return new List<BankInfo>
            {
                new BankInfo { Bin = "970415", DisplayName = "Vietcombank", SupportsTransfer = true, BankId = "970415", BankName = "Vietcombank" },
                new BankInfo { Bin = "970422", DisplayName = "VietinBank", SupportsTransfer = true, BankId = "970422", BankName = "VietinBank" },
                new BankInfo { Bin = "970436", DisplayName = "Agribank", SupportsTransfer = true, BankId = "970436", BankName = "Agribank" },
                new BankInfo { Bin = "970441", DisplayName = "BIDV", SupportsTransfer = true, BankId = "970441", BankName = "BIDV" },
                new BankInfo { Bin = "970448", DisplayName = "Sacombank", SupportsTransfer = true, BankId = "970448", BankName = "Sacombank" },
                new BankInfo { Bin = "970454", DisplayName = "Techcombank", SupportsTransfer = true, BankId = "970454", BankName = "Techcombank" },
                new BankInfo { Bin = "970458", DisplayName = "MBBank", SupportsTransfer = true, BankId = "970458", BankName = "MBBank" },
                new BankInfo { Bin = "970461", DisplayName = "ACB", SupportsTransfer = true, BankId = "970461", BankName = "ACB" },
                new BankInfo { Bin = "970465", DisplayName = "VPBank", SupportsTransfer = true, BankId = "970465", BankName = "VPBank" },
                new BankInfo { Bin = "970470", DisplayName = "HDBank", SupportsTransfer = true, BankId = "970470", BankName = "HDBank" }
            };
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}