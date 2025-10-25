using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.SqlClient;
using QLTN.Database;
using QLTN.Models;
using QLTN.Utilities;

namespace QLTN.Services
{
    /// <summary>
    /// Business layer xử lý nghiệp vụ người dùng, kiểm soát truy cập dữ liệu và áp dụng các biện pháp bảo mật.
    /// </summary>
    public class UserService
    {
        private const int MaxLoginAttempts = 5;
        private static readonly TimeSpan LockoutDuration = TimeSpan.FromMinutes(15);
        private static readonly ConcurrentDictionary<string, LoginAttemptInfo> LoginAttempts =
            new ConcurrentDictionary<string, LoginAttemptInfo>(StringComparer.OrdinalIgnoreCase);

        public bool Authenticate(LoginRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string phone = InputSanitizer.Sanitize(request.Phone);
            string password = request.Password ?? string.Empty;

            if (string.IsNullOrEmpty(phone))
            {
                throw new ArgumentException("Số điện thoại không được để trống.", nameof(request.Phone));
            }

            var attemptInfo = LoginAttempts.GetOrAdd(phone, _ => new LoginAttemptInfo());
            lock (attemptInfo.Lock)
            {
                if (attemptInfo.LockUntil > DateTime.UtcNow)
                {
                    throw new InvalidOperationException($"Tài khoản bị khóa đến {attemptInfo.LockUntil.ToLocalTime():HH:mm:ss}.");
                }

                if (attemptInfo.Attempts >= MaxLoginAttempts)
                {
                    attemptInfo.LockUntil = DateTime.UtcNow.Add(LockoutDuration);
                    throw new InvalidOperationException($"Quá nhiều lần đăng nhập sai. Vui lòng thử lại sau {LockoutDuration.TotalMinutes} phút.");
                }
            }

            const string query = @"SELECT TOP 1 id, hoTen, soDienThoai, email, matKhau, gioiTinh, trangThai, lanDangNhapCuoi, ngayTao
                                   FROM nguoidung
                                   WHERE soDienThoai = @Phone AND trangThai = 1";

            var parameters = new[] { new SqlParameter("@Phone", phone) };
            DataTable table = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            bool success = false;
            User user = null;

            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                string storedPassword = row["matKhau"]?.ToString();

                if (!string.IsNullOrWhiteSpace(storedPassword) && PasswordHasher.VerifyPassword(password, storedPassword))
                {
                    success = true;
                    user = MapUser(row);
                }
                else if (string.Equals(password, storedPassword, StringComparison.Ordinal))
                {
                    // Trường hợp dữ liệu cũ còn plaintext: cập nhật ngay lên hash an toàn.
                    string upgradedHash = PasswordHasher.HashPassword(password);
                    UpgradePasswordHash(row.Field<int>("id"), upgradedHash);
                    success = true;
                    user = MapUser(row);
                }
            }

            AuditLogger.LogLogin(phone, success);

            lock (attemptInfo.Lock)
            {
                if (!success)
                {
                    attemptInfo.Attempts++;
                    if (attemptInfo.Attempts >= MaxLoginAttempts)
                    {
                        attemptInfo.LockUntil = DateTime.UtcNow.Add(LockoutDuration);
                    }
                }
                else
                {
                    LoginAttempts.TryRemove(phone, out _);
                }
            }

            if (success && user != null)
            {
                SessionManager.Login(user);
            }

            return success;
        }

        public bool IsPhoneRegistered(string phone)
        {
            string sanitizedPhone = InputSanitizer.Sanitize(phone);
            if (string.IsNullOrEmpty(sanitizedPhone))
            {
                return false;
            }

            const string query = "SELECT COUNT(*) FROM nguoidung WHERE soDienThoai = @Phone";
            SqlParameter[] parameters = { new SqlParameter("@Phone", sanitizedPhone) };
            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public bool IsEmailRegistered(string email)
        {
            string sanitizedEmail = InputSanitizer.Sanitize(email);
            if (!EmailValidator.IsValid(sanitizedEmail))
            {
                return false;
            }

            const string query = "SELECT COUNT(*) FROM nguoidung WHERE email = @Email";
            SqlParameter[] parameters = { new SqlParameter("@Email", sanitizedEmail) };
            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public void RegisterUser(RegisterRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string name = InputSanitizer.Sanitize(request.Name);
            string phone = InputSanitizer.Sanitize(request.Phone);
            string email = InputSanitizer.Sanitize(request.Email);
            string gender = InputSanitizer.Sanitize(request.Gender);
            string password = request.Password ?? string.Empty;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                throw new ArgumentException("Tên và số điện thoại là bắt buộc.");
            }

            if (!string.IsNullOrEmpty(email) && !EmailValidator.IsValid(email))
            {
                throw new ArgumentException("Email không hợp lệ.", nameof(request.Email));
            }

            string hashedPassword = PasswordHasher.HashPassword(password);

            const string query = @"INSERT INTO nguoidung (tenDangNhap, hoTen, soDienThoai, email, matKhau, gioiTinh, trangThai)
                                   VALUES (@Username, @Name, @Phone, @Email, @Password, @Gender, 1)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", phone),
                new SqlParameter("@Name", name),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email),
                new SqlParameter("@Password", hashedPassword),
                new SqlParameter("@Gender", string.IsNullOrEmpty(gender) ? (object)DBNull.Value : gender),
            };

            DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
        }

        public void UpdatePassword(ResetPasswordRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string email = InputSanitizer.Sanitize(request.Email);
            string newPassword = request.NewPassword ?? string.Empty;

            if (!EmailValidator.IsValid(email))
            {
                throw new ArgumentException("Email không hợp lệ.", nameof(request.Email));
            }

            string hashedPassword = PasswordHasher.HashPassword(newPassword);

            const string query = "UPDATE nguoidung SET matKhau = @Password WHERE email = @Email";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Password", hashedPassword),
                new SqlParameter("@Email", email)
            };

            DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
        }

        public User GetUserByPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return null;
            }

            string sanitizedPhone = InputSanitizer.Sanitize(phone);
            const string query = @"SELECT TOP 1 id, hoTen, soDienThoai, email, matKhau, gioiTinh, trangThai, lanDangNhapCuoi, ngayTao
                                   FROM nguoidung
                                   WHERE soDienThoai = @Phone AND trangThai = 1";

            var parameters = new[] { new SqlParameter("@Phone", sanitizedPhone) };
            DataTable table = DatabaseConnection.Instance.ExecuteQuery(query, parameters);

            if (table.Rows.Count > 0)
            {
                return MapUser(table.Rows[0]);
            }

            return null;
        }

        private static void UpgradePasswordHash(int userId, string hashedPassword)
        {
            const string query = "UPDATE nguoidung SET matKhau = @Password WHERE id = @Id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Password", hashedPassword),
                new SqlParameter("@Id", userId)
            };

            DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
        }

        private static User MapUser(DataRow row)
        {
            return new User
            {
                Id = row.Field<int>("id"),
                Name = row.Field<string>("hoTen"),
                Phone = row.Field<string>("soDienThoai"),
                Email = row.Field<string>("email"),
                Password = null,
                Gender = row.Field<string>("gioiTinh"),
                IsActive = row.Field<bool?>("trangThai") ?? false,
                LastLoginDate = row.Field<DateTime?>("lanDangNhapCuoi"),
                CreatedDate = row.Field<DateTime?>("ngayTao") ?? DateTime.Now
            };
        }

        private sealed class LoginAttemptInfo
        {
            public int Attempts { get; set; }
            public DateTime LockUntil { get; set; }
            public object Lock { get; } = new object();
        }
    }
}
