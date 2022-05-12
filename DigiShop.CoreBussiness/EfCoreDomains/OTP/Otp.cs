using System;
using DigiShop.CoreBussiness.BasicDomain;
using DigiShop.CoreBussiness.EfCoreDomains.Users;

namespace DigiShop.CoreBussiness.EfCoreDomains.OTP
{
    public class Otp:Core
    {
        public const int expirelimit = 15;

        public Otp()
        {
            expiretime = DateTimeOffset.Now.AddMinutes(expirelimit);
        }
        public int userId { get; set; }
        public User User { get; set; }
        public string code { get; set; }
        public bool IsUsed { get; set; }
        public DateTimeOffset expiretime { get; set; }
        public bool IsAuthentic => !IsUsed && DateTimeOffset.Now < expiretime;
    }
}