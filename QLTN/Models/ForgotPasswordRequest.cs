using System;

namespace QLTN.Models
{
    public class ForgotPasswordRequest
    {
        public string Email { get; set; }

        public ForgotPasswordRequest()
        {
        }

        public ForgotPasswordRequest(string email)
        {
            Email = email;
        }
    }
}

