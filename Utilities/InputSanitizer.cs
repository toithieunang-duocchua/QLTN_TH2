using System;
using System.Linq;

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
    }
}
