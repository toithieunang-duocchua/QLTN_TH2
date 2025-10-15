using System;
using System.Data.SqlClient;
using QLTN.Database;
using QLTN.Models;

namespace QLTN.Services
{
    /// <summary>
    /// Business layer that coordinates user related operations between the UI and the database layer.
    /// Keeps SQL access out of the WinForms so we respect the three-tier architecture (UI - Business - Data).
    /// </summary>
    public class UserService
    {
        public bool Authenticate(LoginRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            const string query = "SELECT COUNT(*) FROM nguoidung WHERE soDienThoai = @Phone AND matKhau = @Password AND trangThai = 1";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Phone", request.Phone),
                new SqlParameter("@Password", request.Password)
            };

            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public bool IsPhoneRegistered(string phone)
        {
            const string query = "SELECT COUNT(*) FROM nguoidung WHERE soDienThoai = @Phone";
            SqlParameter[] parameters = { new SqlParameter("@Phone", phone) };
            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public bool IsEmailRegistered(string email)
        {
            const string query = "SELECT COUNT(*) FROM nguoidung WHERE email = @Email";
            SqlParameter[] parameters = { new SqlParameter("@Email", email) };
            object result = DatabaseConnection.Instance.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }

        public void RegisterUser(RegisterRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            const string query = @"INSERT INTO nguoidung (tenDangNhap, hoTen, soDienThoai, email, matKhau, gioiTinh, trangThai)
                                   VALUES (@Username, @Name, @Phone, @Email, @Password, @Gender, 1)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", request.Phone),
                new SqlParameter("@Name", request.Name),
                new SqlParameter("@Phone", request.Phone),
                new SqlParameter("@Email", request.Email),
                new SqlParameter("@Password", request.Password),
                new SqlParameter("@Gender", string.IsNullOrWhiteSpace(request.Gender) ? (object)DBNull.Value : request.Gender),
            };

            DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
        }

        public void UpdatePassword(ResetPasswordRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            const string query = "UPDATE nguoidung SET matKhau = @Password WHERE email = @Email";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Password", request.NewPassword),
                new SqlParameter("@Email", request.Email)
            };

            DatabaseConnection.Instance.ExecuteNonQuery(query, parameters);
        }
    }
}
