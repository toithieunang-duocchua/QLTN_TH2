using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace QLTN.Services
{
    /// <summary>
    /// Tải ảnh từ URL và lưu vào disk
    /// </summary>
    public class HttpImageLoader
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static readonly string LogsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        private static readonly string QrDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "QR-Generated");

        static HttpImageLoader()
        {
            // Thiết lập timeout cho HttpClient
            HttpClient.Timeout = TimeSpan.FromSeconds(30);
            
            // Tạo thư mục logs nếu chưa có
            if (!Directory.Exists(LogsDirectory))
            {
                Directory.CreateDirectory(LogsDirectory);
            }

            // Tạo thư mục QR-Generated nếu chưa có
            if (!Directory.Exists(QrDirectory))
            {
                Directory.CreateDirectory(QrDirectory);
            }
        }

        /// <summary>
        /// Tải ảnh từ URL
        /// </summary>
        /// <param name="url">URL của ảnh</param>
        /// <returns>Image object</returns>
        public static async Task<Image> LoadImageAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("URL không được để trống");

            try
            {
                LogMessage($"Bắt đầu tải ảnh từ: {url}");

                using (var response = await HttpClient.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        var image = Image.FromStream(stream);
                        LogMessage($"Tải ảnh thành công. Kích thước: {image.Width}x{image.Height}");
                        return image;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                string errorMsg = $"Lỗi HTTP khi tải ảnh: {ex.Message}";
                LogError(errorMsg, ex);
                throw new Exception(errorMsg, ex);
            }
            catch (TaskCanceledException ex)
            {
                string errorMsg = "Timeout khi tải ảnh";
                LogError(errorMsg, ex);
                throw new Exception(errorMsg, ex);
            }
            catch (Exception ex)
            {
                string errorMsg = $"Lỗi không xác định khi tải ảnh: {ex.Message}";
                LogError(errorMsg, ex);
                throw new Exception(errorMsg, ex);
            }
        }

        /// <summary>
        /// Tải ảnh và lưu vào disk
        /// </summary>
        /// <param name="url">URL của ảnh</param>
        /// <param name="filePath">Đường dẫn file để lưu</param>
        /// <returns>Image object</returns>
        public static async Task<Image> LoadAndSaveImageAsync(string url, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Đường dẫn file không được để trống");

            try
            {
                // Tải ảnh
                var image = await LoadImageAsync(url);

                // Tạo thư mục nếu chưa có
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Lưu ảnh
                image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                LogMessage($"Đã lưu ảnh vào: {filePath}");

                return image;
            }
            catch (Exception ex)
            {
                string errorMsg = $"Lỗi khi lưu ảnh vào {filePath}: {ex.Message}";
                LogError(errorMsg, ex);
                throw new Exception(errorMsg, ex);
            }
        }

        /// <summary>
        /// Tạo đường dẫn file QR theo cấu trúc thư mục
        /// </summary>
        /// <param name="roomId">Mã phòng</param>
        /// <param name="month">Tháng (yyyy-MM)</param>
        /// <returns>Đường dẫn file</returns>
        public static string GenerateQrFilePath(string roomId, string month)
        {
            if (string.IsNullOrWhiteSpace(roomId) || string.IsNullOrWhiteSpace(month))
                throw new ArgumentException("RoomId và Month không được để trống");

            try
            {
                // Parse tháng để lấy năm và tháng
                if (DateTime.TryParseExact(month, "yyyy-MM", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    string year = date.Year.ToString();
                    string monthStr = date.Month.ToString("00");
                    string fileName = $"{roomId}_{month}.png";
                    
                    return Path.Combine(QrDirectory, year, monthStr, fileName);
                }
                else
                {
                    throw new ArgumentException($"Format tháng không hợp lệ: {month}. Phải là yyyy-MM");
                }
            }
            catch (Exception ex)
            {
                string errorMsg = $"Lỗi khi tạo đường dẫn file QR: {ex.Message}";
                LogError(errorMsg, ex);
                throw new Exception(errorMsg, ex);
            }
        }

        /// <summary>
        /// Copy URL vào clipboard
        /// </summary>
        /// <param name="url">URL cần copy</param>
        public static void CopyToClipboard(string url)
        {
            try
            {
                System.Windows.Forms.Clipboard.SetText(url);
                LogMessage($"Đã copy URL vào clipboard: {url}");
            }
            catch (Exception ex)
            {
                string errorMsg = $"Lỗi khi copy vào clipboard: {ex.Message}";
                LogError(errorMsg, ex);
                throw new Exception(errorMsg, ex);
            }
        }

        /// <summary>
        /// Mở URL trong browser
        /// </summary>
        /// <param name="url">URL cần mở</param>
        public static void OpenInBrowser(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
                LogMessage($"Đã mở URL trong browser: {url}");
            }
            catch (Exception ex)
            {
                string errorMsg = $"Lỗi khi mở URL trong browser: {ex.Message}";
                LogError(errorMsg, ex);
                throw new Exception(errorMsg, ex);
            }
        }

        /// <summary>
        /// Ghi log message
        /// </summary>
        private static void LogMessage(string message)
        {
            try
            {
                string logFile = Path.Combine(LogsDirectory, "app.log");
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO: {message}{Environment.NewLine}";
                File.AppendAllText(logFile, logEntry);
            }
            catch
            {
                // Ignore logging errors
            }
        }

        /// <summary>
        /// Ghi log error
        /// </summary>
        private static void LogError(string message, Exception ex = null)
        {
            try
            {
                string logFile = Path.Combine(LogsDirectory, "app.log");
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message}";
                if (ex != null)
                {
                    logEntry += $"{Environment.NewLine}Exception: {ex}";
                }
                logEntry += Environment.NewLine;
                File.AppendAllText(logFile, logEntry);
            }
            catch
            {
                // Ignore logging errors
            }
        }
    }
}

