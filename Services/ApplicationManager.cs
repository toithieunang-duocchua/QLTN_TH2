using System;
using System.Windows.Forms;
using QLTN.Forms;
using QLTN.Models;

namespace QLTN.Services
{
    /// <summary>
    /// Quản lý flow chính của ứng dụng từ login đến main system
    /// </summary>
    public static class ApplicationManager
    {
        private static LoginForm loginForm;
        private static FormMainSystem mainSystemForm;
        private static User currentUser;

        /// <summary>
        /// Bắt đầu ứng dụng với màn hình login
        /// </summary>
        public static void StartApplication()
        {
            try
            {
                // Tạo và hiển thị form login
                loginForm = new LoginForm();
                loginForm.FormClosed += OnLoginFormClosed;
                
                // Đăng ký event để nhận thông báo login thành công
                LoginContentForm.OnLoginSuccess += OnLoginSuccess;
                
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi động ứng dụng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý khi login thành công
        /// </summary>
        private static void OnLoginSuccess(User user)
        {
            try
            {
                currentUser = user;
                
                // Đóng form login
                if (loginForm != null && !loginForm.IsDisposed)
                {
                    loginForm.FormClosed -= OnLoginFormClosed;
                    loginForm.Hide();
                }

                // Tạo và hiển thị main system
                mainSystemForm = new FormMainSystem();
                mainSystemForm.FormClosed += OnMainSystemFormClosed;
                mainSystemForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chuyển đổi sang main system: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Nếu có lỗi, đóng ứng dụng
                Application.Exit();
            }
        }

        /// <summary>
        /// Xử lý khi form login đóng
        /// </summary>
        private static void OnLoginFormClosed(object sender, FormClosedEventArgs e)
        {
            // Nếu login form đóng mà chưa có main system, thoát ứng dụng
            if (mainSystemForm == null || mainSystemForm.IsDisposed)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Xử lý khi main system đóng
        /// </summary>
        private static void OnMainSystemFormClosed(object sender, FormClosedEventArgs e)
        {
            // Đóng form login nếu còn tồn tại
            if (loginForm != null && !loginForm.IsDisposed)
            {
                loginForm.FormClosed -= OnLoginFormClosed;
                loginForm.Close();
            }

            // Thoát ứng dụng
            Application.Exit();
        }

        /// <summary>
        /// Lấy thông tin user hiện tại
        /// </summary>
        public static User GetCurrentUser()
        {
            return currentUser;
        }

        /// <summary>
        /// Đăng xuất và quay về màn hình login
        /// </summary>
        public static void Logout()
        {
            try
            {
                // Đóng main system
                if (mainSystemForm != null && !mainSystemForm.IsDisposed)
                {
                    mainSystemForm.FormClosed -= OnMainSystemFormClosed;
                    mainSystemForm.Close();
                }

                // Reset user
                currentUser = null;

                // Tạo lại login form
                loginForm = new LoginForm();
                loginForm.FormClosed += OnLoginFormClosed;
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng xuất: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}

