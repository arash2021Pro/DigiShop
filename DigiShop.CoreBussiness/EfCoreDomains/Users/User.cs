using System;
using System.Collections.Generic;
using DigiShop.CoreBussiness.BasicDomain;
using DigiShop.CoreBussiness.EfCoreDomains.AccessPermissions;
using DigiShop.CoreBussiness.EfCoreDomains.Documents;
using DigiShop.CoreBussiness.EfCoreDomains.OTP;
using DigiShop.CoreBussiness.EfCoreDomains.Stores;
using DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs;

namespace DigiShop.CoreBussiness.EfCoreDomains.Users
{
    public class User:Core
    {
        public string GenerateUserserial() => Guid.NewGuid().ToString().Substring(1, 6);
        public User()
        {
            Userserial = GenerateUserserial(); 
        }
        public string Phonenumber { get; set; }
        public string Password { get; set; }
        public string Userserial { get; set; }
        public string? NationalCode { get; set; }
        public UserStatus UserStatus { get; set; }
        public bool IsRulesAccepted { get; set; }
        public int roleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Otp>Otps { get; set; }
        public ICollection<SignInLog>SignInLogs { get; set; }
        public ICollection<Document>Documents { get; set; }
        public Store Store { get; set; }
    }
}