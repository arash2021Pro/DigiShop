using System.ComponentModel.DataAnnotations;

namespace DigiShop.ViewModels.Sellers
{
    public class VerifyOtpViewModel
    {
        [Required(ErrorMessage = "کد تایید الزامیست")]
        public string code { get; set; }
        public string? email { get; set; }
        public string? Message { get; set; }
        public bool IsCompleted { get; set; }
    }
}