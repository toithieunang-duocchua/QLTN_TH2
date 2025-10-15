using System;

namespace QLTN.Models
{
    public class VerificationRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }

        public VerificationRequest()
        {
        }

        public VerificationRequest(string email, string code)
        {
            Email = email;
            Code = code;
        }
    }
}

