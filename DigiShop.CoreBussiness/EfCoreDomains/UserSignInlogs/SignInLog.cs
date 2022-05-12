using System;
using System.Globalization;
using DigiShop.CoreBussiness.EfCoreDomains.Users;

namespace DigiShop.CoreBussiness.EfCoreDomains.UserSignInlogs
{
    public class SignInLog
    {
        public SignInLog()
        {
            SignInTime = GetSignInTime();
        }
        public int id { get; set; }
        public string? SignInTime { get; set; }
        public string? Username { get; set; }
        public string? DeviceName { get; set; }
        public string? Browser { get; set; }
        public string? UrlAction { get; set; }
        public string? GetSignInTime(){var pc = new PersianCalendar(); var time = pc.GetHour(DateTime.Now) + ":" + pc.GetMinute(DateTime.Now) + ":" + pc.GetSecond(DateTime.Now); return time;}
        
        public int userId { get; set; }
        public User User { get; set; }
    }
}