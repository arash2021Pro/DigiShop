using DigiShop.CoreBussiness.BasicDomain;

namespace DigiShop.CoreBussiness.EfCoreDomains.SiteSettings
{
    public class SiteSetting:Core
    {
        public string?EmailAddress { get; set; }
        public string ?EmailPassword { get; set; }
        public string ?SiteDescription { get; set; }
        public string ?SiteKey { get; set; }
        public string ?SiteName { get; set; }
        public string ?SmsApi { get; set; }
        public string?SmsSender { get; set; }
    }
}