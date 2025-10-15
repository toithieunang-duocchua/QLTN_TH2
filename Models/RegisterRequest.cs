using System;

namespace QLTN.Models
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public bool TermsAccepted { get; set; }

        public RegisterRequest()
        {
        }

        public RegisterRequest(string name, string phone, string email, string password, string gender, bool termsAccepted)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Password = password;
            Gender = gender;
            TermsAccepted = termsAccepted;
        }
    }
}

