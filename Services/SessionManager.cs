using System;
using QLTN.Models;

namespace QLTN.Services
{
    /// <summary>
    /// Quản lý phiên đăng nhập hiện hành trong phạm vi tiến trình ứng dụng.
    /// </summary>
    public static class SessionManager
    {
        private static readonly object SyncRoot = new object();
        private static User currentUser;

        public static User CurrentUser
        {
            get
            {
                lock (SyncRoot)
                {
                    return currentUser;
                }
            }
            private set
            {
                lock (SyncRoot)
                {
                    currentUser = value;
                }
            }
        }

        public static bool IsAuthenticated
        {
            get
            {
                lock (SyncRoot)
                {
                    return currentUser != null;
                }
            }
        }

        public static void Login(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
