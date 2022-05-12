namespace DigiShop.ViewModels.Manager
{
    public class ModifySettingViewModel
    {
        public string?EmailAddress { get; set; }
        public string ?EmailPassword { get; set; }
        public string ?SiteDescription { get; set; }
        public string ?SiteKey { get; set; }
        public string ?SiteName { get; set; }
        public string ?SmsApi { get; set; }
        public string?SmsSender { get; set; }
        public string?Message { get; set; }
        public bool? IsCompleted { get; set; }
    }
}