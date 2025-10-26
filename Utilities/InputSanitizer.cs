using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace QLTN.Utilities
{
    public static class InputSanitizer
    {
        /// <summary>
        /// Loại bỏ ký tự điều khiển không in được và cắt khoảng trắng dư thừa.
        /// </summary>
        public static string Sanitize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            var filtered = input.Where(c => !char.IsControl(c) || char.IsWhiteSpace(c)).ToArray();
            return new string(filtered).Trim();
        }

        /// <summary>
        /// Loại bỏ dấu tiếng Việt để phục vụ tạo mã định danh.
        /// </summary>
        public static string RemoveDiacritics(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            string normalized = input.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder(normalized.Length);

            foreach (char c in normalized)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(c);
                }
            }

            return builder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
