using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QLTN.Services
{
    /// <summary>
    /// Format message pattern với các tham số
    /// </summary>
    public class MessageFormatter
    {
        /// <summary>
        /// Format message pattern với dictionary các tham số
        /// </summary>
        /// <param name="pattern">Pattern string (ví dụ: "P{RoomId}_T{Month}")</param>
        /// <param name="parameters">Dictionary chứa các tham số</param>
        /// <returns>Chuỗi đã được format</returns>
        public static string Format(string pattern, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                return string.Empty;

            if (parameters == null || parameters.Count == 0)
                return pattern;

            string result = pattern;

            // Thay thế các placeholder {Key} bằng giá trị tương ứng
            foreach (var param in parameters)
            {
                string placeholder = $"{{{param.Key}}}";
                string value = param.Value?.ToString() ?? string.Empty;
                result = result.Replace(placeholder, value);
            }

            return result;
        }

        /// <summary>
        /// Format message pattern với các tham số cụ thể cho Payment
        /// </summary>
        /// <param name="pattern">Pattern string</param>
        /// <param name="roomId">Mã phòng</param>
        /// <param name="month">Tháng (yyyy-MM)</param>
        /// <param name="amount">Số tiền</param>
        /// <param name="additionalParams">Tham số bổ sung</param>
        /// <returns>Chuỗi đã được format</returns>
        public static string FormatPaymentMessage(string pattern, string roomId, string month, int amount, Dictionary<string, object> additionalParams = null)
        {
            var parameters = new Dictionary<string, object>
            {
                { "RoomId", roomId ?? string.Empty },
                { "Month", month ?? string.Empty },
                { "Amount", amount.ToString() }
            };

            // Thêm các tham số bổ sung nếu có
            if (additionalParams != null)
            {
                foreach (var param in additionalParams)
                {
                    parameters[param.Key] = param.Value;
                }
            }

            return Format(pattern, parameters);
        }

        /// <summary>
        /// Kiểm tra pattern có hợp lệ không
        /// </summary>
        /// <param name="pattern">Pattern string</param>
        /// <returns>True nếu hợp lệ</returns>
        public static bool IsValidPattern(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                return false;

            // Kiểm tra có chứa ít nhất một placeholder không
            return pattern.Contains("{") && pattern.Contains("}");
        }

        /// <summary>
        /// Lấy danh sách các placeholder trong pattern
        /// </summary>
        /// <param name="pattern">Pattern string</param>
        /// <returns>Danh sách placeholder</returns>
        public static List<string> GetPlaceholders(string pattern)
        {
            var placeholders = new List<string>();
            
            if (string.IsNullOrWhiteSpace(pattern))
                return placeholders;

            // Sử dụng regex để tìm các placeholder {Key}
            var regex = new Regex(@"\{([^}]+)\}");
            var matches = regex.Matches(pattern);

            foreach (Match match in matches)
            {
                if (match.Groups.Count > 1)
                {
                    string placeholder = match.Groups[1].Value;
                    if (!placeholders.Contains(placeholder))
                    {
                        placeholders.Add(placeholder);
                    }
                }
            }

            return placeholders;
        }

        /// <summary>
        /// Tạo pattern mặc định cho Payment
        /// </summary>
        /// <returns>Pattern mặc định</returns>
        public static string GetDefaultPattern()
        {
            return "P{RoomId}_T{Month}";
        }

        /// <summary>
        /// Tạo pattern với tên phòng và tháng bằng tiếng Việt
        /// </summary>
        /// <returns>Pattern tiếng Việt</returns>
        public static string GetVietnamesePattern()
        {
            return "Phong {RoomId} Thang {Month}";
        }
    }
}

