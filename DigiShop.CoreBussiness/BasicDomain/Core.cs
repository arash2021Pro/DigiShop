using System;
using System.Globalization;

namespace DigiShop.CoreBussiness.BasicDomain
{
    public class Core
    {
        public Core()
        {
            CurrentTime = GetCurrentTime();
            CurrentDate = GetCurrentDate();
        }
        public int id { get; set; }
        public string CurrentTime { get; set; }
        public string CurrentDate { get; set; }
        public string ModificationTime { get; set; }
        public bool IsDeleted { get; set; }
        public string GetCurrentTime() { var pc = new PersianCalendar(); var time = pc.GetHour(DateTime.Now) + ":" + pc.GetMinute(DateTime.Now) + ":" + pc.GetSecond(DateTime.Now); return time; }
        public string GetCurrentDate() { var pc = new PersianCalendar(); var date = pc.GetYear(DateTime.Now) + "/" + pc.GetMonth(DateTime.Now) + "/" + pc.GetDayOfMonth(DateTime.Now); return date; }
    }
}