using System;
using System.Security.Cryptography;

namespace QLTN.Utilities
{
    /// <summary>
    /// Cung cấp hàm hash mật khẩu an toàn bằng PBKDF2 kèm salt, tránh lưu plaintext.
    /// </summary>
    public static class PasswordHasher
    {
        private const byte Version = 1;
        private const int Iterations = 100_000;
        private const int SaltSize = 16;
        private const int HashSize = 32;

        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hash = Pbkdf2(password, salt, Iterations, HashSize);
            var payload = new byte[1 + sizeof(int) + SaltSize + HashSize];

            payload[0] = Version;
            Buffer.BlockCopy(BitConverter.GetBytes(Iterations), 0, payload, 1, sizeof(int));
            Buffer.BlockCopy(salt, 0, payload, 1 + sizeof(int), SaltSize);
            Buffer.BlockCopy(hash, 0, payload, 1 + sizeof(int) + SaltSize, HashSize);

            return Convert.ToBase64String(payload);
        }

        public static bool VerifyPassword(string password, string encodedHash)
        {
            if (password == null || encodedHash == null)
            {
                return false;
            }

            byte[] payload;
            try
            {
                payload = Convert.FromBase64String(encodedHash);
            }
            catch (FormatException)
            {
                return false;
            }

            if (payload.Length != 1 + sizeof(int) + SaltSize + HashSize)
            {
                return false;
            }

            if (payload[0] != Version)
            {
                return false;
            }

            var iterations = BitConverter.ToInt32(payload, 1);
            var salt = new byte[SaltSize];
            var storedHash = new byte[HashSize];

            Buffer.BlockCopy(payload, 1 + sizeof(int), salt, 0, SaltSize);
            Buffer.BlockCopy(payload, 1 + sizeof(int) + SaltSize, storedHash, 0, HashSize);

            var computedHash = Pbkdf2(password, salt, iterations, storedHash.Length);
            return FixedTimeEquals(storedHash, computedHash);
        }

        private static byte[] Pbkdf2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(outputBytes);
            }
        }

        private static bool FixedTimeEquals(byte[] left, byte[] right)
        {
            if (left == null || right == null || left.Length != right.Length)
            {
                return false;
            }

            int diff = 0;
            for (int i = 0; i < left.Length; i++)
            {
                diff |= left[i] ^ right[i];
            }
            return diff == 0;
        }
    }
}
