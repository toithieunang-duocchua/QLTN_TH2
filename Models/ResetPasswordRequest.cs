using System;

namespace QLTN.Models
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        public ResetPasswordRequest()
        {
        }

        public ResetPasswordRequest(string email, string newPassword, string confirmPassword)
        {
            Email = email;
            NewPassword = newPassword;
            ConfirmPassword = confirmPassword;
        }
    }
}

