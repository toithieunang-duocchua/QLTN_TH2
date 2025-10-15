using System;

namespace QLTN.Models
{
    public class LoginRequest
    {
        public string Phone { get; set; }
        public string Password { get; set; }

        public LoginRequest()
        {
        }

        public LoginRequest(string phone, string password)
        {
            Phone = phone;
            Password = password;
        }
    }
}

